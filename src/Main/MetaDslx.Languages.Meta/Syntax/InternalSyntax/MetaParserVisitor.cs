﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Balazs\source\repos\meta-cs\src\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaParser.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="MetaParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IMetaParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMain([NotNull] MetaParser.MainContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitName([NotNull] MetaParser.NameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQualifiedName([NotNull] MetaParser.QualifiedNameContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQualifier([NotNull] MetaParser.QualifierContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute([NotNull] MetaParser.AttributeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.namespaceDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamespaceDeclaration([NotNull] MetaParser.NamespaceDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.namespaceBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamespaceBody([NotNull] MetaParser.NamespaceBodyContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.metamodelDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetamodelDeclaration([NotNull] MetaParser.MetamodelDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.metamodelPropertyList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetamodelPropertyList([NotNull] MetaParser.MetamodelPropertyListContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.metamodelProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetamodelProperty([NotNull] MetaParser.MetamodelPropertyContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.metamodelUriProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetamodelUriProperty([NotNull] MetaParser.MetamodelUriPropertyContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] MetaParser.DeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumDeclaration([NotNull] MetaParser.EnumDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumBody([NotNull] MetaParser.EnumBodyContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumValues"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumValues([NotNull] MetaParser.EnumValuesContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumValue([NotNull] MetaParser.EnumValueContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumMemberDeclaration([NotNull] MetaParser.EnumMemberDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassDeclaration([NotNull] MetaParser.ClassDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassBody([NotNull] MetaParser.ClassBodyContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classAncestors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassAncestors([NotNull] MetaParser.ClassAncestorsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classAncestor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassAncestor([NotNull] MetaParser.ClassAncestorContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassMemberDeclaration([NotNull] MetaParser.ClassMemberDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.fieldDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFieldDeclaration([NotNull] MetaParser.FieldDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.fieldModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFieldModifier([NotNull] MetaParser.FieldModifierContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.redefinitionsOrSubsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRedefinitionsOrSubsettings([NotNull] MetaParser.RedefinitionsOrSubsettingsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.redefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRedefinitions([NotNull] MetaParser.RedefinitionsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.subsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubsettings([NotNull] MetaParser.SubsettingsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.nameUseList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNameUseList([NotNull] MetaParser.NameUseListContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.constDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstDeclaration([NotNull] MetaParser.ConstDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.returnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnType([NotNull] MetaParser.ReturnTypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.typeOfReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeOfReference([NotNull] MetaParser.TypeOfReferenceContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.typeReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeReference([NotNull] MetaParser.TypeReferenceContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.simpleType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSimpleType([NotNull] MetaParser.SimpleTypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassType([NotNull] MetaParser.ClassTypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.objectType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObjectType([NotNull] MetaParser.ObjectTypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveType([NotNull] MetaParser.PrimitiveTypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.voidType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVoidType([NotNull] MetaParser.VoidTypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.nullableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullableType([NotNull] MetaParser.NullableTypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.collectionType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCollectionType([NotNull] MetaParser.CollectionTypeContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.collectionKind"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCollectionKind([NotNull] MetaParser.CollectionKindContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.operationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperationDeclaration([NotNull] MetaParser.OperationDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterList([NotNull] MetaParser.ParameterListContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] MetaParser.ParameterContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.associationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssociationDeclaration([NotNull] MetaParser.AssociationDeclarationContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] MetaParser.IdentifierContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] MetaParser.LiteralContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullLiteral([NotNull] MetaParser.NullLiteralContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.booleanLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBooleanLiteral([NotNull] MetaParser.BooleanLiteralContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.integerLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntegerLiteral([NotNull] MetaParser.IntegerLiteralContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.decimalLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDecimalLiteral([NotNull] MetaParser.DecimalLiteralContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.scientificLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScientificLiteral([NotNull] MetaParser.ScientificLiteralContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringLiteral([NotNull] MetaParser.StringLiteralContext context);
}
} // namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax

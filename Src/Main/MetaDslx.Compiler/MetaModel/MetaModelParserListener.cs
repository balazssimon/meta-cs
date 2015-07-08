//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from MetaModelParser.g4 by ANTLR 4.5

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace MetaDslx.Compiler {

using MetaDslx.Core;

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="MetaModelParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5")]
[System.CLSCompliant(false)]
public interface IMetaModelParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMain([NotNull] MetaModelParser.MainContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMain([NotNull] MetaModelParser.MainContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifiedName([NotNull] MetaModelParser.QualifiedNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifiedName([NotNull] MetaModelParser.QualifiedNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.identifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierList([NotNull] MetaModelParser.IdentifierListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.identifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierList([NotNull] MetaModelParser.IdentifierListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.qualifiedNameList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifiedNameList([NotNull] MetaModelParser.QualifiedNameListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.qualifiedNameList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifiedNameList([NotNull] MetaModelParser.QualifiedNameListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.namespaceDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamespaceDeclaration([NotNull] MetaModelParser.NamespaceDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.namespaceDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamespaceDeclaration([NotNull] MetaModelParser.NamespaceDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.metamodelDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMetamodelDeclaration([NotNull] MetaModelParser.MetamodelDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.metamodelDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMetamodelDeclaration([NotNull] MetaModelParser.MetamodelDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] MetaModelParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] MetaModelParser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.enumDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumDeclaration([NotNull] MetaModelParser.EnumDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.enumDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumDeclaration([NotNull] MetaModelParser.EnumDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.enumValues"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumValues([NotNull] MetaModelParser.EnumValuesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.enumValues"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumValues([NotNull] MetaModelParser.EnumValuesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.enumValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumValue([NotNull] MetaModelParser.EnumValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.enumValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumValue([NotNull] MetaModelParser.EnumValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.enumMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumMemberDeclaration([NotNull] MetaModelParser.EnumMemberDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.enumMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumMemberDeclaration([NotNull] MetaModelParser.EnumMemberDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.classDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassDeclaration([NotNull] MetaModelParser.ClassDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.classDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassDeclaration([NotNull] MetaModelParser.ClassDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.classAncestors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassAncestors([NotNull] MetaModelParser.ClassAncestorsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.classAncestors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassAncestors([NotNull] MetaModelParser.ClassAncestorsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.classAncestor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassAncestor([NotNull] MetaModelParser.ClassAncestorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.classAncestor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassAncestor([NotNull] MetaModelParser.ClassAncestorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.classMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassMemberDeclaration([NotNull] MetaModelParser.ClassMemberDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.classMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassMemberDeclaration([NotNull] MetaModelParser.ClassMemberDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.fieldDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldDeclaration([NotNull] MetaModelParser.FieldDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.fieldDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldDeclaration([NotNull] MetaModelParser.FieldDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.fieldModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldModifier([NotNull] MetaModelParser.FieldModifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.fieldModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldModifier([NotNull] MetaModelParser.FieldModifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.redefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRedefinitions([NotNull] MetaModelParser.RedefinitionsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.redefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRedefinitions([NotNull] MetaModelParser.RedefinitionsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.subsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubsettings([NotNull] MetaModelParser.SubsettingsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.subsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubsettings([NotNull] MetaModelParser.SubsettingsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.nameUseList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNameUseList([NotNull] MetaModelParser.NameUseListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.nameUseList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNameUseList([NotNull] MetaModelParser.NameUseListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.constDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstDeclaration([NotNull] MetaModelParser.ConstDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.constDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstDeclaration([NotNull] MetaModelParser.ConstDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.returnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnType([NotNull] MetaModelParser.ReturnTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.returnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnType([NotNull] MetaModelParser.ReturnTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.typeReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeReference([NotNull] MetaModelParser.TypeReferenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.typeReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeReference([NotNull] MetaModelParser.TypeReferenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.simpleType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleType([NotNull] MetaModelParser.SimpleTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.simpleType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleType([NotNull] MetaModelParser.SimpleTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.objectType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterObjectType([NotNull] MetaModelParser.ObjectTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.objectType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitObjectType([NotNull] MetaModelParser.ObjectTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimitiveType([NotNull] MetaModelParser.PrimitiveTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimitiveType([NotNull] MetaModelParser.PrimitiveTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.voidType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVoidType([NotNull] MetaModelParser.VoidTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.voidType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVoidType([NotNull] MetaModelParser.VoidTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.nullableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNullableType([NotNull] MetaModelParser.NullableTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.nullableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNullableType([NotNull] MetaModelParser.NullableTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.collectionType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCollectionType([NotNull] MetaModelParser.CollectionTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.collectionType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCollectionType([NotNull] MetaModelParser.CollectionTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.collectionKind"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCollectionKind([NotNull] MetaModelParser.CollectionKindContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.collectionKind"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCollectionKind([NotNull] MetaModelParser.CollectionKindContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.operationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperationDeclaration([NotNull] MetaModelParser.OperationDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.operationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperationDeclaration([NotNull] MetaModelParser.OperationDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameterList([NotNull] MetaModelParser.ParameterListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameterList([NotNull] MetaModelParser.ParameterListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameter([NotNull] MetaModelParser.ParameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameter([NotNull] MetaModelParser.ParameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.associationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssociationDeclaration([NotNull] MetaModelParser.AssociationDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.associationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssociationDeclaration([NotNull] MetaModelParser.AssociationDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] MetaModelParser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] MetaModelParser.IdentifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] MetaModelParser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] MetaModelParser.LiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNullLiteral([NotNull] MetaModelParser.NullLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNullLiteral([NotNull] MetaModelParser.NullLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.booleanLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBooleanLiteral([NotNull] MetaModelParser.BooleanLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.booleanLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBooleanLiteral([NotNull] MetaModelParser.BooleanLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.integerLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntegerLiteral([NotNull] MetaModelParser.IntegerLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.integerLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntegerLiteral([NotNull] MetaModelParser.IntegerLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.decimalLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDecimalLiteral([NotNull] MetaModelParser.DecimalLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.decimalLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDecimalLiteral([NotNull] MetaModelParser.DecimalLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.scientificLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScientificLiteral([NotNull] MetaModelParser.ScientificLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.scientificLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScientificLiteral([NotNull] MetaModelParser.ScientificLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaModelParser.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringLiteral([NotNull] MetaModelParser.StringLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaModelParser.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringLiteral([NotNull] MetaModelParser.StringLiteralContext context);
}
} // namespace MetaDslx.Compiler

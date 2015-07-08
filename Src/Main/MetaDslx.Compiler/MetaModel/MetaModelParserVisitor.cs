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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="MetaModelParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5")]
[System.CLSCompliant(false)]
public interface IMetaModelParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMain([NotNull] MetaModelParser.MainContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQualifiedName([NotNull] MetaModelParser.QualifiedNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.identifierList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierList([NotNull] MetaModelParser.IdentifierListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.qualifiedNameList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQualifiedNameList([NotNull] MetaModelParser.QualifiedNameListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.namespaceDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamespaceDeclaration([NotNull] MetaModelParser.NamespaceDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.metamodelDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetamodelDeclaration([NotNull] MetaModelParser.MetamodelDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] MetaModelParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.enumDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumDeclaration([NotNull] MetaModelParser.EnumDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.enumValues"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumValues([NotNull] MetaModelParser.EnumValuesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.enumValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumValue([NotNull] MetaModelParser.EnumValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.enumMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnumMemberDeclaration([NotNull] MetaModelParser.EnumMemberDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.classDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassDeclaration([NotNull] MetaModelParser.ClassDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.classAncestors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassAncestors([NotNull] MetaModelParser.ClassAncestorsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.classAncestor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassAncestor([NotNull] MetaModelParser.ClassAncestorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.classMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassMemberDeclaration([NotNull] MetaModelParser.ClassMemberDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.fieldDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFieldDeclaration([NotNull] MetaModelParser.FieldDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.fieldModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFieldModifier([NotNull] MetaModelParser.FieldModifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.redefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRedefinitions([NotNull] MetaModelParser.RedefinitionsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.subsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubsettings([NotNull] MetaModelParser.SubsettingsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.nameUseList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNameUseList([NotNull] MetaModelParser.NameUseListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.constDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstDeclaration([NotNull] MetaModelParser.ConstDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.returnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnType([NotNull] MetaModelParser.ReturnTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.typeReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeReference([NotNull] MetaModelParser.TypeReferenceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.simpleType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSimpleType([NotNull] MetaModelParser.SimpleTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.objectType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObjectType([NotNull] MetaModelParser.ObjectTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveType([NotNull] MetaModelParser.PrimitiveTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.voidType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVoidType([NotNull] MetaModelParser.VoidTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.nullableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullableType([NotNull] MetaModelParser.NullableTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.collectionType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCollectionType([NotNull] MetaModelParser.CollectionTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.collectionKind"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCollectionKind([NotNull] MetaModelParser.CollectionKindContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.operationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperationDeclaration([NotNull] MetaModelParser.OperationDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterList([NotNull] MetaModelParser.ParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] MetaModelParser.ParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.associationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssociationDeclaration([NotNull] MetaModelParser.AssociationDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] MetaModelParser.IdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] MetaModelParser.LiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullLiteral([NotNull] MetaModelParser.NullLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.booleanLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBooleanLiteral([NotNull] MetaModelParser.BooleanLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.integerLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntegerLiteral([NotNull] MetaModelParser.IntegerLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.decimalLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDecimalLiteral([NotNull] MetaModelParser.DecimalLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.scientificLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScientificLiteral([NotNull] MetaModelParser.ScientificLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringLiteral([NotNull] MetaModelParser.StringLiteralContext context);
}
} // namespace MetaDslx.Compiler

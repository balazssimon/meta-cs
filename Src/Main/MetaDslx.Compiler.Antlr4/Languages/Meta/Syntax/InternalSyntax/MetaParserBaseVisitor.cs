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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IMetaParserVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class MetaParserBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, IMetaParserVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.main"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMain([NotNull] MetaParser.MainContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.name"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitName([NotNull] MetaParser.NameContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.qualifiedName"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitQualifiedName([NotNull] MetaParser.QualifiedNameContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.qualifier"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitQualifier([NotNull] MetaParser.QualifierContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.annotation"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAnnotation([NotNull] MetaParser.AnnotationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.namespaceDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNamespaceDeclaration([NotNull] MetaParser.NamespaceDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.namespaceBody"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNamespaceBody([NotNull] MetaParser.NamespaceBodyContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.metamodelDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMetamodelDeclaration([NotNull] MetaParser.MetamodelDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.metamodelPropertyList"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMetamodelPropertyList([NotNull] MetaParser.MetamodelPropertyListContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.metamodelProperty"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMetamodelProperty([NotNull] MetaParser.MetamodelPropertyContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.metamodelUriProperty"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMetamodelUriProperty([NotNull] MetaParser.MetamodelUriPropertyContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.declaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclaration([NotNull] MetaParser.DeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEnumDeclaration([NotNull] MetaParser.EnumDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumBody"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEnumBody([NotNull] MetaParser.EnumBodyContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumValues"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEnumValues([NotNull] MetaParser.EnumValuesContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumValue"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEnumValue([NotNull] MetaParser.EnumValueContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.enumMemberDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEnumMemberDeclaration([NotNull] MetaParser.EnumMemberDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitClassDeclaration([NotNull] MetaParser.ClassDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classBody"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitClassBody([NotNull] MetaParser.ClassBodyContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classAncestors"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitClassAncestors([NotNull] MetaParser.ClassAncestorsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classAncestor"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitClassAncestor([NotNull] MetaParser.ClassAncestorContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classMemberDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitClassMemberDeclaration([NotNull] MetaParser.ClassMemberDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.fieldDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFieldDeclaration([NotNull] MetaParser.FieldDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.fieldModifier"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFieldModifier([NotNull] MetaParser.FieldModifierContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.redefinitionsOrSubsettings"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRedefinitionsOrSubsettings([NotNull] MetaParser.RedefinitionsOrSubsettingsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.redefinitions"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRedefinitions([NotNull] MetaParser.RedefinitionsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.subsettings"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSubsettings([NotNull] MetaParser.SubsettingsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.nameUseList"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNameUseList([NotNull] MetaParser.NameUseListContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.constDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitConstDeclaration([NotNull] MetaParser.ConstDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.externTypeDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitExternTypeDeclaration([NotNull] MetaParser.ExternTypeDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.externClassTypeDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitExternClassTypeDeclaration([NotNull] MetaParser.ExternClassTypeDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.externStructTypeDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitExternStructTypeDeclaration([NotNull] MetaParser.ExternStructTypeDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.returnType"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitReturnType([NotNull] MetaParser.ReturnTypeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.typeOfReference"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTypeOfReference([NotNull] MetaParser.TypeOfReferenceContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.typeReference"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTypeReference([NotNull] MetaParser.TypeReferenceContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.simpleType"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSimpleType([NotNull] MetaParser.SimpleTypeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.classType"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitClassType([NotNull] MetaParser.ClassTypeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.objectType"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitObjectType([NotNull] MetaParser.ObjectTypeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.primitiveType"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPrimitiveType([NotNull] MetaParser.PrimitiveTypeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.voidType"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVoidType([NotNull] MetaParser.VoidTypeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.nullableType"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNullableType([NotNull] MetaParser.NullableTypeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.collectionType"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitCollectionType([NotNull] MetaParser.CollectionTypeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.collectionKind"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitCollectionKind([NotNull] MetaParser.CollectionKindContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.operationDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitOperationDeclaration([NotNull] MetaParser.OperationDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.parameterList"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitParameterList([NotNull] MetaParser.ParameterListContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.parameter"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitParameter([NotNull] MetaParser.ParameterContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.associationDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAssociationDeclaration([NotNull] MetaParser.AssociationDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.identifier"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIdentifier([NotNull] MetaParser.IdentifierContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.literal"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitLiteral([NotNull] MetaParser.LiteralContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.nullLiteral"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNullLiteral([NotNull] MetaParser.NullLiteralContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.booleanLiteral"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitBooleanLiteral([NotNull] MetaParser.BooleanLiteralContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.integerLiteral"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIntegerLiteral([NotNull] MetaParser.IntegerLiteralContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.decimalLiteral"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDecimalLiteral([NotNull] MetaParser.DecimalLiteralContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.scientificLiteral"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitScientificLiteral([NotNull] MetaParser.ScientificLiteralContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaParser.stringLiteral"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStringLiteral([NotNull] MetaParser.StringLiteralContext context) { return VisitChildren(context); }
}
} // namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax


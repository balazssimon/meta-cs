//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\balaz\AppData\Local\Temp\ow0l2pty.3du\MetaModelParser.g4 by ANTLR 4.5.1

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
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.1")]
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
	/// Visit a parse tree produced by <see cref="MetaModelParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotation([NotNull] MetaModelParser.AnnotationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.annotationParams"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotationParams([NotNull] MetaModelParser.AnnotationParamsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.annotationParamList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotationParamList([NotNull] MetaModelParser.AnnotationParamListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.annotationParam"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotationParam([NotNull] MetaModelParser.AnnotationParamContext context);
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
	/// Visit a parse tree produced by <see cref="MetaModelParser.metamodelPropertyList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetamodelPropertyList([NotNull] MetaModelParser.MetamodelPropertyListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.metamodelProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMetamodelProperty([NotNull] MetaModelParser.MetamodelPropertyContext context);
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
	/// Visit a parse tree produced by <see cref="MetaModelParser.functionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDeclaration([NotNull] MetaModelParser.FunctionDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.returnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnType([NotNull] MetaModelParser.ReturnTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.typeOfReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeOfReference([NotNull] MetaModelParser.TypeOfReferenceContext context);
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
	/// Visit a parse tree produced by <see cref="MetaModelParser.classType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassType([NotNull] MetaModelParser.ClassTypeContext context);
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
	/// Visit a parse tree produced by <see cref="MetaModelParser.invisibleType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInvisibleType([NotNull] MetaModelParser.InvisibleTypeContext context);
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
	/// Visit a parse tree produced by <see cref="MetaModelParser.constructorDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstructorDeclaration([NotNull] MetaModelParser.ConstructorDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.initializerDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitializerDeclaration([NotNull] MetaModelParser.InitializerDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.synthetizedPropertyInitializer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSynthetizedPropertyInitializer([NotNull] MetaModelParser.SynthetizedPropertyInitializerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.inheritedPropertyInitializer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInheritedPropertyInitializer([NotNull] MetaModelParser.InheritedPropertyInitializerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionList([NotNull] MetaModelParser.ExpressionListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.expressionOrNewExpressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionOrNewExpressionList([NotNull] MetaModelParser.ExpressionOrNewExpressionListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.expressionOrNewExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionOrNewExpression([NotNull] MetaModelParser.ExpressionOrNewExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>indexerExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexerExpression([NotNull] MetaModelParser.IndexerExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>additiveExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditiveExpression([NotNull] MetaModelParser.AdditiveExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpression([NotNull] MetaModelParser.IdentifierExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>comparisonExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparisonExpression([NotNull] MetaModelParser.ComparisonExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>postExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPostExpression([NotNull] MetaModelParser.PostExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bracketExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBracketExpression([NotNull] MetaModelParser.BracketExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>castExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCastExpression([NotNull] MetaModelParser.CastExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bitwiseAndExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseAndExpression([NotNull] MetaModelParser.BitwiseAndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicalAndExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalAndExpression([NotNull] MetaModelParser.LogicalAndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCallExpression([NotNull] MetaModelParser.FunctionCallExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>memberAccessExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMemberAccessExpression([NotNull] MetaModelParser.MemberAccessExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>typeConversionExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeConversionExpression([NotNull] MetaModelParser.TypeConversionExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>unaryExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryExpression([NotNull] MetaModelParser.UnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bitwiseXorExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseXorExpression([NotNull] MetaModelParser.BitwiseXorExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantExpression([NotNull] MetaModelParser.ConstantExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>shiftExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitShiftExpression([NotNull] MetaModelParser.ShiftExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>conditionalExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditionalExpression([NotNull] MetaModelParser.ConditionalExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>assignmentExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentExpression([NotNull] MetaModelParser.AssignmentExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multiplicativeExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicativeExpression([NotNull] MetaModelParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicalOrExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalOrExpression([NotNull] MetaModelParser.LogicalOrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>preExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPreExpression([NotNull] MetaModelParser.PreExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bitwiseOrExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseOrExpression([NotNull] MetaModelParser.BitwiseOrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>typeofExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeofExpression([NotNull] MetaModelParser.TypeofExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>typeCheckExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeCheckExpression([NotNull] MetaModelParser.TypeCheckExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>thisExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitThisExpression([NotNull] MetaModelParser.ThisExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>equalityExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityExpression([NotNull] MetaModelParser.EqualityExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nullCoalescingExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullCoalescingExpression([NotNull] MetaModelParser.NullCoalescingExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.literalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteralExpression([NotNull] MetaModelParser.LiteralExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>newObjectExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.newExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNewObjectExpression([NotNull] MetaModelParser.NewObjectExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>newCollectionExpression</c>
	/// labeled alternative in <see cref="MetaModelParser.newExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNewCollectionExpression([NotNull] MetaModelParser.NewCollectionExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.newPropertyInitList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNewPropertyInitList([NotNull] MetaModelParser.NewPropertyInitListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.newPropertyInit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNewPropertyInit([NotNull] MetaModelParser.NewPropertyInitContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.postOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPostOperator([NotNull] MetaModelParser.PostOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.preOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPreOperator([NotNull] MetaModelParser.PreOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.unaryOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryOperator([NotNull] MetaModelParser.UnaryOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.multiplicativeOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicativeOperator([NotNull] MetaModelParser.MultiplicativeOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.additiveOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditiveOperator([NotNull] MetaModelParser.AdditiveOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.shiftOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitShiftOperator([NotNull] MetaModelParser.ShiftOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.comparisonOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparisonOperator([NotNull] MetaModelParser.ComparisonOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.equalityOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityOperator([NotNull] MetaModelParser.EqualityOperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MetaModelParser.assignmentOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentOperator([NotNull] MetaModelParser.AssignmentOperatorContext context);
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

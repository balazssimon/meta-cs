﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Users\Balazs\source\repos\meta-cs\src\Main\MetaDslx.Languages.Meta\Syntax\InternalSyntax\MetaParser.g4 by ANTLR 4.6.6

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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IMetaParserListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class MetaParserBaseListener : IMetaParserListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.main"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMain([NotNull] MetaParser.MainContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.main"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMain([NotNull] MetaParser.MainContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterName([NotNull] MetaParser.NameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitName([NotNull] MetaParser.NameContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.qualifiedName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterQualifiedName([NotNull] MetaParser.QualifiedNameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.qualifiedName"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitQualifiedName([NotNull] MetaParser.QualifiedNameContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.qualifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterQualifier([NotNull] MetaParser.QualifierContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.qualifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitQualifier([NotNull] MetaParser.QualifierContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.attribute"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAttribute([NotNull] MetaParser.AttributeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.attribute"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAttribute([NotNull] MetaParser.AttributeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.namespaceDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNamespaceDeclaration([NotNull] MetaParser.NamespaceDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.namespaceDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNamespaceDeclaration([NotNull] MetaParser.NamespaceDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.namespaceBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNamespaceBody([NotNull] MetaParser.NamespaceBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.namespaceBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNamespaceBody([NotNull] MetaParser.NamespaceBodyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.metamodelDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMetamodelDeclaration([NotNull] MetaParser.MetamodelDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.metamodelDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMetamodelDeclaration([NotNull] MetaParser.MetamodelDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.metamodelPropertyList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMetamodelPropertyList([NotNull] MetaParser.MetamodelPropertyListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.metamodelPropertyList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMetamodelPropertyList([NotNull] MetaParser.MetamodelPropertyListContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.metamodelProperty"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMetamodelProperty([NotNull] MetaParser.MetamodelPropertyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.metamodelProperty"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMetamodelProperty([NotNull] MetaParser.MetamodelPropertyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.metamodelUriProperty"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMetamodelUriProperty([NotNull] MetaParser.MetamodelUriPropertyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.metamodelUriProperty"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMetamodelUriProperty([NotNull] MetaParser.MetamodelUriPropertyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDeclaration([NotNull] MetaParser.DeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDeclaration([NotNull] MetaParser.DeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumDeclaration([NotNull] MetaParser.EnumDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumDeclaration([NotNull] MetaParser.EnumDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumBody([NotNull] MetaParser.EnumBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumBody([NotNull] MetaParser.EnumBodyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumValues"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumValues([NotNull] MetaParser.EnumValuesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumValues"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumValues([NotNull] MetaParser.EnumValuesContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumValue([NotNull] MetaParser.EnumValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumValue([NotNull] MetaParser.EnumValueContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumMemberDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnumMemberDeclaration([NotNull] MetaParser.EnumMemberDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumMemberDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnumMemberDeclaration([NotNull] MetaParser.EnumMemberDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClassDeclaration([NotNull] MetaParser.ClassDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClassDeclaration([NotNull] MetaParser.ClassDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClassBody([NotNull] MetaParser.ClassBodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classBody"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClassBody([NotNull] MetaParser.ClassBodyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classAncestors"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClassAncestors([NotNull] MetaParser.ClassAncestorsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classAncestors"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClassAncestors([NotNull] MetaParser.ClassAncestorsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classAncestor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClassAncestor([NotNull] MetaParser.ClassAncestorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classAncestor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClassAncestor([NotNull] MetaParser.ClassAncestorContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classMemberDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClassMemberDeclaration([NotNull] MetaParser.ClassMemberDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classMemberDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClassMemberDeclaration([NotNull] MetaParser.ClassMemberDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.fieldDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFieldDeclaration([NotNull] MetaParser.FieldDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.fieldDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFieldDeclaration([NotNull] MetaParser.FieldDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.fieldModifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFieldModifier([NotNull] MetaParser.FieldModifierContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.fieldModifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFieldModifier([NotNull] MetaParser.FieldModifierContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.redefinitionsOrSubsettings"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRedefinitionsOrSubsettings([NotNull] MetaParser.RedefinitionsOrSubsettingsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.redefinitionsOrSubsettings"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRedefinitionsOrSubsettings([NotNull] MetaParser.RedefinitionsOrSubsettingsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.redefinitions"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRedefinitions([NotNull] MetaParser.RedefinitionsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.redefinitions"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRedefinitions([NotNull] MetaParser.RedefinitionsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.subsettings"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSubsettings([NotNull] MetaParser.SubsettingsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.subsettings"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSubsettings([NotNull] MetaParser.SubsettingsContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.nameUseList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNameUseList([NotNull] MetaParser.NameUseListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.nameUseList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNameUseList([NotNull] MetaParser.NameUseListContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.constDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstDeclaration([NotNull] MetaParser.ConstDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.constDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstDeclaration([NotNull] MetaParser.ConstDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.returnType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturnType([NotNull] MetaParser.ReturnTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.returnType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturnType([NotNull] MetaParser.ReturnTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.typeOfReference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTypeOfReference([NotNull] MetaParser.TypeOfReferenceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.typeOfReference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTypeOfReference([NotNull] MetaParser.TypeOfReferenceContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.typeReference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTypeReference([NotNull] MetaParser.TypeReferenceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.typeReference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTypeReference([NotNull] MetaParser.TypeReferenceContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.simpleType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSimpleType([NotNull] MetaParser.SimpleTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.simpleType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSimpleType([NotNull] MetaParser.SimpleTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClassType([NotNull] MetaParser.ClassTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClassType([NotNull] MetaParser.ClassTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.objectType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterObjectType([NotNull] MetaParser.ObjectTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.objectType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitObjectType([NotNull] MetaParser.ObjectTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.primitiveType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrimitiveType([NotNull] MetaParser.PrimitiveTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.primitiveType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrimitiveType([NotNull] MetaParser.PrimitiveTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.voidType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVoidType([NotNull] MetaParser.VoidTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.voidType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVoidType([NotNull] MetaParser.VoidTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.nullableType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNullableType([NotNull] MetaParser.NullableTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.nullableType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNullableType([NotNull] MetaParser.NullableTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.collectionType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCollectionType([NotNull] MetaParser.CollectionTypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.collectionType"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCollectionType([NotNull] MetaParser.CollectionTypeContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.collectionKind"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCollectionKind([NotNull] MetaParser.CollectionKindContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.collectionKind"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCollectionKind([NotNull] MetaParser.CollectionKindContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.operationDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOperationDeclaration([NotNull] MetaParser.OperationDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.operationDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOperationDeclaration([NotNull] MetaParser.OperationDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.parameterList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParameterList([NotNull] MetaParser.ParameterListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.parameterList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParameterList([NotNull] MetaParser.ParameterListContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.parameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParameter([NotNull] MetaParser.ParameterContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.parameter"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParameter([NotNull] MetaParser.ParameterContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.associationDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssociationDeclaration([NotNull] MetaParser.AssociationDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.associationDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssociationDeclaration([NotNull] MetaParser.AssociationDeclarationContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.identifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdentifier([NotNull] MetaParser.IdentifierContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.identifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdentifier([NotNull] MetaParser.IdentifierContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteral([NotNull] MetaParser.LiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteral([NotNull] MetaParser.LiteralContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.nullLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNullLiteral([NotNull] MetaParser.NullLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.nullLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNullLiteral([NotNull] MetaParser.NullLiteralContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.booleanLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBooleanLiteral([NotNull] MetaParser.BooleanLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.booleanLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBooleanLiteral([NotNull] MetaParser.BooleanLiteralContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.integerLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIntegerLiteral([NotNull] MetaParser.IntegerLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.integerLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIntegerLiteral([NotNull] MetaParser.IntegerLiteralContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.decimalLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDecimalLiteral([NotNull] MetaParser.DecimalLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.decimalLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDecimalLiteral([NotNull] MetaParser.DecimalLiteralContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.scientificLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterScientificLiteral([NotNull] MetaParser.ScientificLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.scientificLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitScientificLiteral([NotNull] MetaParser.ScientificLiteralContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.stringLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStringLiteral([NotNull] MetaParser.StringLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.stringLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStringLiteral([NotNull] MetaParser.StringLiteralContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax

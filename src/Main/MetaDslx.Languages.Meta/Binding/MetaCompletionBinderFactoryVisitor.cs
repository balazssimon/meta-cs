// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Symbols;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaCompletionBinderFactoryVisitor : CompletionBinderFactoryVisitor, IMetaSyntaxVisitor
    {
		public static object UnassignedUse = new object();
		public static object FinishedUse = new object();
		public static object Use_Main_UsingNamespaceOrMetamodel = new object();
		public static object Use_Main_NamespaceDeclaration = new object();
		public static object Use_Name_Identifier = new object();
		public static object Use_QualifiedName_Qualifier = new object();
		public static object Use_Qualifier_Identifier = new object();
		public static object Use_Attribute_Qualifier = new object();
		public static object Use_UsingNamespaceOrMetamodel_UsingNamespace = new object();
		public static object Use_UsingNamespaceOrMetamodel_UsingMetamodel = new object();
		public static object Use_UsingNamespace_Name = new object();
		public static object Use_UsingNamespace_Qualifier = new object();
		public static object Use_UsingMetamodel_Name = new object();
		public static object Use_UsingMetamodel_UsingMetamodelReference = new object();
		public static object Use_UsingMetamodelReference_Qualifier = new object();
		public static object Use_UsingMetamodelReference_StringLiteral = new object();
		public static object Use_NamespaceDeclaration_Attribute = new object();
		public static object Use_NamespaceDeclaration_QualifiedName = new object();
		public static object Use_NamespaceDeclaration_NamespaceBody = new object();
		public static object Use_NamespaceBody_UsingNamespaceOrMetamodel = new object();
		public static object Use_NamespaceBody_MetamodelDeclaration = new object();
		public static object Use_NamespaceBody_Declaration = new object();
		public static object Use_MetamodelDeclaration_Attribute = new object();
		public static object Use_MetamodelDeclaration_Name = new object();
		public static object Use_MetamodelDeclaration_MetamodelPropertyList = new object();
		public static object Use_MetamodelPropertyList_MetamodelProperty = new object();
		public static object Use_MetamodelProperty_MetamodelUriProperty = new object();
		public static object Use_MetamodelProperty_MetamodelPrefixProperty = new object();
		public static object Use_MetamodelUriProperty_StringLiteral = new object();
		public static object Use_MetamodelPrefixProperty_StringLiteral = new object();
		public static object Use_Declaration_EnumDeclaration = new object();
		public static object Use_Declaration_ClassDeclaration = new object();
		public static object Use_Declaration_AssociationDeclaration = new object();
		public static object Use_Declaration_ConstDeclaration = new object();
		public static object Use_EnumDeclaration_Attribute = new object();
		public static object Use_EnumDeclaration_Name = new object();
		public static object Use_EnumDeclaration_EnumBody = new object();
		public static object Use_EnumBody_EnumValues = new object();
		public static object Use_EnumBody_EnumMemberDeclaration = new object();
		public static object Use_EnumValues_EnumValue = new object();
		public static object Use_EnumValue_Attribute = new object();
		public static object Use_EnumValue_Name = new object();
		public static object Use_EnumMemberDeclaration_OperationDeclaration = new object();
		public static object Use_ClassDeclaration_Attribute = new object();
		public static object Use_ClassDeclaration_SymbolAttribute = new object();
		public static object Use_ClassDeclaration_KAbstract = new object();
		public static object Use_ClassDeclaration_Name = new object();
		public static object Use_ClassDeclaration_ClassAncestors = new object();
		public static object Use_ClassDeclaration_ClassBody = new object();
		public static object Use_SymbolAttribute_SymbolSymbolAttribute = new object();
		public static object Use_SymbolAttribute_ExpressionSymbolAttribute = new object();
		public static object Use_SymbolAttribute_StatementSymbolTypeAttribute = new object();
		public static object Use_SymbolAttribute_TypeSymbolTypeAttribute = new object();
		public static object Use_SymbolSymbolAttribute_Qualifier = new object();
		public static object Use_ExpressionSymbolAttribute_Qualifier = new object();
		public static object Use_StatementSymbolTypeAttribute_Qualifier = new object();
		public static object Use_TypeSymbolTypeAttribute_Qualifier = new object();
		public static object Use_ClassBody_ClassMemberDeclaration = new object();
		public static object Use_ClassAncestors_ClassAncestor = new object();
		public static object Use_ClassAncestor_Qualifier = new object();
		public static object Use_ClassMemberDeclaration_FieldDeclaration = new object();
		public static object Use_ClassMemberDeclaration_OperationDeclaration = new object();
		public static object Use_FieldDeclaration_Attribute = new object();
		public static object Use_FieldDeclaration_FieldSymbolPropertyAttribute = new object();
		public static object Use_FieldDeclaration_FieldContainment = new object();
		public static object Use_FieldDeclaration_FieldModifier = new object();
		public static object Use_FieldDeclaration_TypeReference = new object();
		public static object Use_FieldDeclaration_Name = new object();
		public static object Use_FieldDeclaration_DefaultValue = new object();
		public static object Use_FieldDeclaration_RedefinitionsOrSubsettings = new object();
		public static object Use_FieldSymbolPropertyAttribute_Identifier = new object();
		public static object Use_FieldModifier_FieldModifier = new object();
		public static object Use_DefaultValue_StringLiteral = new object();
		public static object Use_RedefinitionsOrSubsettings_Redefinitions = new object();
		public static object Use_RedefinitionsOrSubsettings_Subsettings = new object();
		public static object Use_Redefinitions_NameUseList = new object();
		public static object Use_Subsettings_NameUseList = new object();
		public static object Use_NameUseList_Qualifier = new object();
		public static object Use_ConstDeclaration_TypeReference = new object();
		public static object Use_ConstDeclaration_Name = new object();
		public static object Use_ConstDeclaration_ConstValue = new object();
		public static object Use_ConstValue_StringLiteral = new object();
		public static object Use_ReturnType_TypeReference = new object();
		public static object Use_ReturnType_VoidType = new object();
		public static object Use_TypeOfReference_TypeReference = new object();
		public static object Use_TypeReference_CollectionType = new object();
		public static object Use_TypeReference_SimpleType = new object();
		public static object Use_SimpleType_PrimitiveType = new object();
		public static object Use_SimpleType_ObjectType = new object();
		public static object Use_SimpleType_NullableType = new object();
		public static object Use_SimpleType_ClassType = new object();
		public static object Use_ClassType_Qualifier = new object();
		public static object Use_ObjectType_ObjectType = new object();
		public static object Use_PrimitiveType_PrimitiveType = new object();
		public static object Use_VoidType_KVoid = new object();
		public static object Use_NullableType_PrimitiveType = new object();
		public static object Use_CollectionType_CollectionKind = new object();
		public static object Use_CollectionType_SimpleType = new object();
		public static object Use_CollectionKind_CollectionKind = new object();
		public static object Use_OperationDeclaration_Attribute = new object();
		public static object Use_OperationDeclaration_OperationModifier = new object();
		public static object Use_OperationDeclaration_ReturnType = new object();
		public static object Use_OperationDeclaration_Name = new object();
		public static object Use_OperationDeclaration_ParameterList = new object();
		public static object Use_OperationModifier_OperationModifierBuilder = new object();
		public static object Use_OperationModifier_OperationModifierReadonly = new object();
		public static object Use_ParameterList_Parameter = new object();
		public static object Use_Parameter_Attribute = new object();
		public static object Use_Parameter_TypeReference = new object();
		public static object Use_Parameter_Name = new object();
		public static object Use_AssociationDeclaration_Attribute = new object();
		public static object Use_AssociationDeclaration_Source = new object();
		public static object Use_AssociationDeclaration_Target = new object();
		public static object Use_Literal_NullLiteral = new object();
		public static object Use_Literal_BooleanLiteral = new object();
		public static object Use_Literal_IntegerLiteral = new object();
		public static object Use_Literal_DecimalLiteral = new object();
		public static object Use_Literal_ScientificLiteral = new object();
		public static object Use_Literal_StringLiteral = new object();

        private bool[] _visited = new bool[69];

        public MetaCompletionBinderFactoryVisitor(BinderFactory binderFactory)
			: base(binderFactory)
        {

        }

		public new MetaBinderFactory BinderFactory => (MetaBinderFactory)base.BinderFactory;

		
		public void VisitMain(MainSyntax parent) // 0
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.UsingNamespaceOrMetamodel.Node == null || parent.UsingNamespaceOrMetamodel.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.UsingNamespaceOrMetamodel.Node == null || !parent.UsingNamespaceOrMetamodel.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UsingNamespaceOrMetamodel.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMain(Use_Main_UsingNamespaceOrMetamodel, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.UsingNamespaceOrMetamodel)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.UsingNamespaceOrMetamodel.FullSpan.Length;
		    if (parent.NamespaceDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.NamespaceDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NamespaceDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMain(Use_Main_NamespaceDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NamespaceDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NamespaceDeclaration == null || parent.NamespaceDeclaration.IsMissing) AddResultsForMain(Use_Main_NamespaceDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NamespaceDeclaration);
		        }
		    }
		    position += parent.NamespaceDeclaration.FullSpan.Length;
		    position += parent.EndOfFileToken.FullSpan.Length;
		}
		
		public void VisitName(NameSyntax parent) // 1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForName(Use_Name_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForName(Use_Name_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax parent) // 2
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifiedName(Use_QualifiedName_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForQualifiedName(Use_QualifiedName_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		}
		
		public void VisitQualifier(QualifierSyntax parent) // 3
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.Node == null || parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Identifier.Node == null || !parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifier(Use_Qualifier_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Identifier.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitAttribute(AttributeSyntax parent) // 4
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBracket, operation);
		        }
		    }
		    position += parent.TOpenBracket.FullSpan.Length;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAttribute(Use_Attribute_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForAttribute(Use_Attribute_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		}
		
		public void VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax parent) // 5
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.UsingNamespace == null || parent.UsingNamespace.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.UsingNamespace == null || !parent.UsingNamespace.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UsingNamespace);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingNamespaceOrMetamodel(Use_UsingNamespaceOrMetamodel_UsingNamespace, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.UsingNamespace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.UsingNamespace == null || parent.UsingNamespace.IsMissing) AddResultsForUsingNamespaceOrMetamodel(Use_UsingNamespaceOrMetamodel_UsingNamespace, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.UsingNamespace);
		        }
		    }
		    if (parent.UsingNamespace != null) position += parent.UsingNamespace.FullSpan.Length;
		    if (parent.UsingMetamodel == null || parent.UsingMetamodel.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.UsingMetamodel == null || !parent.UsingMetamodel.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UsingMetamodel);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingNamespaceOrMetamodel(Use_UsingNamespaceOrMetamodel_UsingMetamodel, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.UsingMetamodel);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.UsingMetamodel == null || parent.UsingMetamodel.IsMissing) AddResultsForUsingNamespaceOrMetamodel(Use_UsingNamespaceOrMetamodel_UsingMetamodel, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.UsingMetamodel);
		        }
		    }
		    if (parent.UsingMetamodel != null) position += parent.UsingMetamodel.FullSpan.Length;
		}
		
		public void VisitUsingNamespace(UsingNamespaceSyntax parent) // 6
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KUsing.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KUsing);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KUsing, operation);
		        }
		    }
		    position += parent.KUsing.FullSpan.Length;
		    if (parent.Name == null || parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Name == null || !parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingNamespace(Use_UsingNamespace_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForUsingNamespace(Use_UsingNamespace_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    if (parent.Name != null) position += parent.Name.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingNamespace(Use_UsingNamespace_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForUsingNamespace(Use_UsingNamespace_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitUsingMetamodel(UsingMetamodelSyntax parent) // 7
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KUsing.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KUsing);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KUsing, operation);
		        }
		    }
		    position += parent.KUsing.FullSpan.Length;
		    if (parent.KMetamodel.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KMetamodel);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KMetamodel, operation);
		        }
		    }
		    position += parent.KMetamodel.FullSpan.Length;
		    if (parent.Name == null || parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Name == null || !parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingMetamodel(Use_UsingMetamodel_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForUsingMetamodel(Use_UsingMetamodel_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    if (parent.Name != null) position += parent.Name.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.UsingMetamodelReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.UsingMetamodelReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UsingMetamodelReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingMetamodel(Use_UsingMetamodel_UsingMetamodelReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.UsingMetamodelReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.UsingMetamodelReference == null || parent.UsingMetamodelReference.IsMissing) AddResultsForUsingMetamodel(Use_UsingMetamodel_UsingMetamodelReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.UsingMetamodelReference);
		        }
		    }
		    position += parent.UsingMetamodelReference.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax parent) // 8
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier == null || parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Qualifier == null || !parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingMetamodelReference(Use_UsingMetamodelReference_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForUsingMetamodelReference(Use_UsingMetamodelReference_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    if (parent.Qualifier != null) position += parent.Qualifier.FullSpan.Length;
		    if (parent.StringLiteral == null || parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.StringLiteral == null || !parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingMetamodelReference(Use_UsingMetamodelReference_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForUsingMetamodelReference(Use_UsingMetamodelReference_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    if (parent.StringLiteral != null) position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitNamespaceDeclaration(NamespaceDeclarationSyntax parent) // 9
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.KNamespace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KNamespace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KNamespace, operation);
		        }
		    }
		    position += parent.KNamespace.FullSpan.Length;
		    if (parent.QualifiedName.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.QualifiedName.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.QualifiedName);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_QualifiedName, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.QualifiedName);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.QualifiedName == null || parent.QualifiedName.IsMissing) AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_QualifiedName, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.QualifiedName);
		        }
		    }
		    position += parent.QualifiedName.FullSpan.Length;
		    if (parent.NamespaceBody.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.NamespaceBody.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NamespaceBody);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_NamespaceBody, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NamespaceBody);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NamespaceBody == null || parent.NamespaceBody.IsMissing) AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_NamespaceBody, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NamespaceBody);
		        }
		    }
		    position += parent.NamespaceBody.FullSpan.Length;
		}
		
		public void VisitNamespaceBody(NamespaceBodySyntax parent) // 10
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBrace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBrace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBrace, operation);
		        }
		    }
		    position += parent.TOpenBrace.FullSpan.Length;
		    if (parent.UsingNamespaceOrMetamodel.Node == null || parent.UsingNamespaceOrMetamodel.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.UsingNamespaceOrMetamodel.Node == null || !parent.UsingNamespaceOrMetamodel.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UsingNamespaceOrMetamodel.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceBody(Use_NamespaceBody_UsingNamespaceOrMetamodel, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.UsingNamespaceOrMetamodel)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.UsingNamespaceOrMetamodel.FullSpan.Length;
		    if (parent.MetamodelDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.MetamodelDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.MetamodelDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceBody(Use_NamespaceBody_MetamodelDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.MetamodelDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.MetamodelDeclaration == null || parent.MetamodelDeclaration.IsMissing) AddResultsForNamespaceBody(Use_NamespaceBody_MetamodelDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.MetamodelDeclaration);
		        }
		    }
		    position += parent.MetamodelDeclaration.FullSpan.Length;
		    if (parent.Declaration.Node == null || parent.Declaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Declaration.Node == null || !parent.Declaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Declaration.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceBody(Use_NamespaceBody_Declaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Declaration)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Declaration.FullSpan.Length;
		    if (parent.TCloseBrace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBrace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBrace, operation);
		        }
		    }
		    position += parent.TCloseBrace.FullSpan.Length;
		}
		
		public void VisitMetamodelDeclaration(MetamodelDeclarationSyntax parent) // 11
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMetamodelDeclaration(Use_MetamodelDeclaration_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.KMetamodel.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KMetamodel);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KMetamodel, operation);
		        }
		    }
		    position += parent.KMetamodel.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMetamodelDeclaration(Use_MetamodelDeclaration_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForMetamodelDeclaration(Use_MetamodelDeclaration_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.MetamodelPropertyList == null || parent.MetamodelPropertyList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.MetamodelPropertyList == null || !parent.MetamodelPropertyList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.MetamodelPropertyList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMetamodelDeclaration(Use_MetamodelDeclaration_MetamodelPropertyList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.MetamodelPropertyList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.MetamodelPropertyList == null || parent.MetamodelPropertyList.IsMissing) AddResultsForMetamodelDeclaration(Use_MetamodelDeclaration_MetamodelPropertyList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.MetamodelPropertyList);
		        }
		    }
		    if (parent.MetamodelPropertyList != null) position += parent.MetamodelPropertyList.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitMetamodelPropertyList(MetamodelPropertyListSyntax parent) // 12
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.MetamodelProperty.Node == null || parent.MetamodelProperty.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.MetamodelProperty.Node == null || !parent.MetamodelProperty.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.MetamodelProperty.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMetamodelPropertyList(Use_MetamodelPropertyList_MetamodelProperty, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.MetamodelProperty.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.MetamodelProperty.FullSpan.Length;
		}
		
		public void VisitMetamodelProperty(MetamodelPropertySyntax parent) // 13
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.MetamodelUriProperty == null || parent.MetamodelUriProperty.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.MetamodelUriProperty == null || !parent.MetamodelUriProperty.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.MetamodelUriProperty);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMetamodelProperty(Use_MetamodelProperty_MetamodelUriProperty, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.MetamodelUriProperty);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.MetamodelUriProperty == null || parent.MetamodelUriProperty.IsMissing) AddResultsForMetamodelProperty(Use_MetamodelProperty_MetamodelUriProperty, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.MetamodelUriProperty);
		        }
		    }
		    if (parent.MetamodelUriProperty != null) position += parent.MetamodelUriProperty.FullSpan.Length;
		    if (parent.MetamodelPrefixProperty == null || parent.MetamodelPrefixProperty.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.MetamodelPrefixProperty == null || !parent.MetamodelPrefixProperty.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.MetamodelPrefixProperty);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMetamodelProperty(Use_MetamodelProperty_MetamodelPrefixProperty, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.MetamodelPrefixProperty);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.MetamodelPrefixProperty == null || parent.MetamodelPrefixProperty.IsMissing) AddResultsForMetamodelProperty(Use_MetamodelProperty_MetamodelPrefixProperty, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.MetamodelPrefixProperty);
		        }
		    }
		    if (parent.MetamodelPrefixProperty != null) position += parent.MetamodelPrefixProperty.FullSpan.Length;
		}
		
		public void VisitMetamodelUriProperty(MetamodelUriPropertySyntax parent) // 14
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.IUri.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.IUri);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.IUri, operation);
		        }
		    }
		    position += parent.IUri.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMetamodelUriProperty(Use_MetamodelUriProperty_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForMetamodelUriProperty(Use_MetamodelUriProperty_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax parent) // 15
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.IPrefix.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.IPrefix);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.IPrefix, operation);
		        }
		    }
		    position += parent.IPrefix.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMetamodelPrefixProperty(Use_MetamodelPrefixProperty_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForMetamodelPrefixProperty(Use_MetamodelPrefixProperty_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitDeclaration(DeclarationSyntax parent) // 16
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.EnumDeclaration == null || parent.EnumDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.EnumDeclaration == null || !parent.EnumDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.EnumDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDeclaration(Use_Declaration_EnumDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.EnumDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.EnumDeclaration == null || parent.EnumDeclaration.IsMissing) AddResultsForDeclaration(Use_Declaration_EnumDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.EnumDeclaration);
		        }
		    }
		    if (parent.EnumDeclaration != null) position += parent.EnumDeclaration.FullSpan.Length;
		    if (parent.ClassDeclaration == null || parent.ClassDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ClassDeclaration == null || !parent.ClassDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ClassDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDeclaration(Use_Declaration_ClassDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ClassDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ClassDeclaration == null || parent.ClassDeclaration.IsMissing) AddResultsForDeclaration(Use_Declaration_ClassDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ClassDeclaration);
		        }
		    }
		    if (parent.ClassDeclaration != null) position += parent.ClassDeclaration.FullSpan.Length;
		    if (parent.AssociationDeclaration == null || parent.AssociationDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.AssociationDeclaration == null || !parent.AssociationDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.AssociationDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDeclaration(Use_Declaration_AssociationDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.AssociationDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.AssociationDeclaration == null || parent.AssociationDeclaration.IsMissing) AddResultsForDeclaration(Use_Declaration_AssociationDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.AssociationDeclaration);
		        }
		    }
		    if (parent.AssociationDeclaration != null) position += parent.AssociationDeclaration.FullSpan.Length;
		    if (parent.ConstDeclaration == null || parent.ConstDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ConstDeclaration == null || !parent.ConstDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ConstDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDeclaration(Use_Declaration_ConstDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ConstDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ConstDeclaration == null || parent.ConstDeclaration.IsMissing) AddResultsForDeclaration(Use_Declaration_ConstDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ConstDeclaration);
		        }
		    }
		    if (parent.ConstDeclaration != null) position += parent.ConstDeclaration.FullSpan.Length;
		}
		
		public void VisitEnumDeclaration(EnumDeclarationSyntax parent) // 17
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumDeclaration(Use_EnumDeclaration_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.KEnum.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KEnum);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KEnum, operation);
		        }
		    }
		    position += parent.KEnum.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumDeclaration(Use_EnumDeclaration_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForEnumDeclaration(Use_EnumDeclaration_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		    if (parent.EnumBody.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.EnumBody.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.EnumBody);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumDeclaration(Use_EnumDeclaration_EnumBody, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.EnumBody);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.EnumBody == null || parent.EnumBody.IsMissing) AddResultsForEnumDeclaration(Use_EnumDeclaration_EnumBody, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.EnumBody);
		        }
		    }
		    position += parent.EnumBody.FullSpan.Length;
		}
		
		public void VisitEnumBody(EnumBodySyntax parent) // 18
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBrace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBrace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBrace, operation);
		        }
		    }
		    position += parent.TOpenBrace.FullSpan.Length;
		    if (parent.EnumValues.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.EnumValues.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.EnumValues);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumBody(Use_EnumBody_EnumValues, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.EnumValues);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.EnumValues == null || parent.EnumValues.IsMissing) AddResultsForEnumBody(Use_EnumBody_EnumValues, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.EnumValues);
		        }
		    }
		    position += parent.EnumValues.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		    if (parent.EnumMemberDeclaration.Node == null || parent.EnumMemberDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.EnumMemberDeclaration.Node == null || !parent.EnumMemberDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.EnumMemberDeclaration.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumBody(Use_EnumBody_EnumMemberDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.EnumMemberDeclaration)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.EnumMemberDeclaration.FullSpan.Length;
		    if (parent.TCloseBrace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBrace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBrace, operation);
		        }
		    }
		    position += parent.TCloseBrace.FullSpan.Length;
		}
		
		public void VisitEnumValues(EnumValuesSyntax parent) // 19
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.EnumValue.Node == null || parent.EnumValue.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.EnumValue.Node == null || !parent.EnumValue.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.EnumValue.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumValues(Use_EnumValues_EnumValue, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.EnumValue.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.EnumValue.FullSpan.Length;
		}
		
		public void VisitEnumValue(EnumValueSyntax parent) // 20
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumValue(Use_EnumValue_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumValue(Use_EnumValue_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForEnumValue(Use_EnumValue_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		}
		
		public void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax parent) // 21
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.OperationDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.OperationDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.OperationDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEnumMemberDeclaration(Use_EnumMemberDeclaration_OperationDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.OperationDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.OperationDeclaration == null || parent.OperationDeclaration.IsMissing) AddResultsForEnumMemberDeclaration(Use_EnumMemberDeclaration_OperationDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.OperationDeclaration);
		        }
		    }
		    position += parent.OperationDeclaration.FullSpan.Length;
		}
		
		public void VisitClassDeclaration(ClassDeclarationSyntax parent) // 22
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassDeclaration(Use_ClassDeclaration_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.SymbolAttribute == null || parent.SymbolAttribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.SymbolAttribute == null || !parent.SymbolAttribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.SymbolAttribute);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassDeclaration(Use_ClassDeclaration_SymbolAttribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.SymbolAttribute);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.SymbolAttribute == null || parent.SymbolAttribute.IsMissing) AddResultsForClassDeclaration(Use_ClassDeclaration_SymbolAttribute, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.SymbolAttribute);
		        }
		    }
		    if (parent.SymbolAttribute != null) position += parent.SymbolAttribute.FullSpan.Length;
		    if (parent.KAbstract.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.KAbstract.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.KAbstract);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassDeclaration(Use_ClassDeclaration_KAbstract, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.KAbstract);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.KAbstract.GetKind() == SyntaxKind.None || parent.KAbstract.IsMissing) AddResultsForClassDeclaration(Use_ClassDeclaration_KAbstract, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.KAbstract, operation);
		        }
		    }
		    position += parent.KAbstract.FullSpan.Length;
		    if (parent.KClass.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KClass);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KClass, operation);
		        }
		    }
		    position += parent.KClass.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassDeclaration(Use_ClassDeclaration_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForClassDeclaration(Use_ClassDeclaration_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.ClassAncestors == null || parent.ClassAncestors.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ClassAncestors == null || !parent.ClassAncestors.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ClassAncestors);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassDeclaration(Use_ClassDeclaration_ClassAncestors, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ClassAncestors);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ClassAncestors == null || parent.ClassAncestors.IsMissing) AddResultsForClassDeclaration(Use_ClassDeclaration_ClassAncestors, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ClassAncestors);
		        }
		    }
		    if (parent.ClassAncestors != null) position += parent.ClassAncestors.FullSpan.Length;
		    if (parent.ClassBody.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ClassBody.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ClassBody);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassDeclaration(Use_ClassDeclaration_ClassBody, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ClassBody);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ClassBody == null || parent.ClassBody.IsMissing) AddResultsForClassDeclaration(Use_ClassDeclaration_ClassBody, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ClassBody);
		        }
		    }
		    position += parent.ClassBody.FullSpan.Length;
		}
		
		public void VisitSymbolAttribute(SymbolAttributeSyntax parent) // 23
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.SymbolSymbolAttribute == null || parent.SymbolSymbolAttribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.SymbolSymbolAttribute == null || !parent.SymbolSymbolAttribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.SymbolSymbolAttribute);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSymbolAttribute(Use_SymbolAttribute_SymbolSymbolAttribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.SymbolSymbolAttribute);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.SymbolSymbolAttribute == null || parent.SymbolSymbolAttribute.IsMissing) AddResultsForSymbolAttribute(Use_SymbolAttribute_SymbolSymbolAttribute, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.SymbolSymbolAttribute);
		        }
		    }
		    if (parent.SymbolSymbolAttribute != null) position += parent.SymbolSymbolAttribute.FullSpan.Length;
		    if (parent.ExpressionSymbolAttribute == null || parent.ExpressionSymbolAttribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ExpressionSymbolAttribute == null || !parent.ExpressionSymbolAttribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ExpressionSymbolAttribute);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSymbolAttribute(Use_SymbolAttribute_ExpressionSymbolAttribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ExpressionSymbolAttribute);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ExpressionSymbolAttribute == null || parent.ExpressionSymbolAttribute.IsMissing) AddResultsForSymbolAttribute(Use_SymbolAttribute_ExpressionSymbolAttribute, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ExpressionSymbolAttribute);
		        }
		    }
		    if (parent.ExpressionSymbolAttribute != null) position += parent.ExpressionSymbolAttribute.FullSpan.Length;
		    if (parent.StatementSymbolTypeAttribute == null || parent.StatementSymbolTypeAttribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.StatementSymbolTypeAttribute == null || !parent.StatementSymbolTypeAttribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StatementSymbolTypeAttribute);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSymbolAttribute(Use_SymbolAttribute_StatementSymbolTypeAttribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StatementSymbolTypeAttribute);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StatementSymbolTypeAttribute == null || parent.StatementSymbolTypeAttribute.IsMissing) AddResultsForSymbolAttribute(Use_SymbolAttribute_StatementSymbolTypeAttribute, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StatementSymbolTypeAttribute);
		        }
		    }
		    if (parent.StatementSymbolTypeAttribute != null) position += parent.StatementSymbolTypeAttribute.FullSpan.Length;
		    if (parent.TypeSymbolTypeAttribute == null || parent.TypeSymbolTypeAttribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.TypeSymbolTypeAttribute == null || !parent.TypeSymbolTypeAttribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeSymbolTypeAttribute);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSymbolAttribute(Use_SymbolAttribute_TypeSymbolTypeAttribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeSymbolTypeAttribute);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeSymbolTypeAttribute == null || parent.TypeSymbolTypeAttribute.IsMissing) AddResultsForSymbolAttribute(Use_SymbolAttribute_TypeSymbolTypeAttribute, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeSymbolTypeAttribute);
		        }
		    }
		    if (parent.TypeSymbolTypeAttribute != null) position += parent.TypeSymbolTypeAttribute.FullSpan.Length;
		}
		
		public void VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax parent) // 24
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBracket, operation);
		        }
		    }
		    position += parent.TOpenBracket.FullSpan.Length;
		    if (parent.KSymbol.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KSymbol);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KSymbol, operation);
		        }
		    }
		    position += parent.KSymbol.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSymbolSymbolAttribute(Use_SymbolSymbolAttribute_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForSymbolSymbolAttribute(Use_SymbolSymbolAttribute_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		}
		
		public void VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax parent) // 25
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBracket, operation);
		        }
		    }
		    position += parent.TOpenBracket.FullSpan.Length;
		    if (parent.KExpression.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KExpression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KExpression, operation);
		        }
		    }
		    position += parent.KExpression.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForExpressionSymbolAttribute(Use_ExpressionSymbolAttribute_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForExpressionSymbolAttribute(Use_ExpressionSymbolAttribute_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		}
		
		public void VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax parent) // 26
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBracket, operation);
		        }
		    }
		    position += parent.TOpenBracket.FullSpan.Length;
		    if (parent.KStatement.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KStatement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KStatement, operation);
		        }
		    }
		    position += parent.KStatement.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForStatementSymbolTypeAttribute(Use_StatementSymbolTypeAttribute_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForStatementSymbolTypeAttribute(Use_StatementSymbolTypeAttribute_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		}
		
		public void VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax parent) // 27
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBracket, operation);
		        }
		    }
		    position += parent.TOpenBracket.FullSpan.Length;
		    if (parent.KType.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KType, operation);
		        }
		    }
		    position += parent.KType.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeSymbolTypeAttribute(Use_TypeSymbolTypeAttribute_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForTypeSymbolTypeAttribute(Use_TypeSymbolTypeAttribute_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		}
		
		public void VisitClassBody(ClassBodySyntax parent) // 28
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBrace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBrace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBrace, operation);
		        }
		    }
		    position += parent.TOpenBrace.FullSpan.Length;
		    if (parent.ClassMemberDeclaration.Node == null || parent.ClassMemberDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ClassMemberDeclaration.Node == null || !parent.ClassMemberDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ClassMemberDeclaration.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassBody(Use_ClassBody_ClassMemberDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.ClassMemberDeclaration)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.ClassMemberDeclaration.FullSpan.Length;
		    if (parent.TCloseBrace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBrace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBrace, operation);
		        }
		    }
		    position += parent.TCloseBrace.FullSpan.Length;
		}
		
		public void VisitClassAncestors(ClassAncestorsSyntax parent) // 29
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ClassAncestor.Node == null || parent.ClassAncestor.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ClassAncestor.Node == null || !parent.ClassAncestor.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ClassAncestor.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassAncestors(Use_ClassAncestors_ClassAncestor, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.ClassAncestor.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.ClassAncestor.FullSpan.Length;
		}
		
		public void VisitClassAncestor(ClassAncestorSyntax parent) // 30
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassAncestor(Use_ClassAncestor_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForClassAncestor(Use_ClassAncestor_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		}
		
		public void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax parent) // 31
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.FieldDeclaration == null || parent.FieldDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.FieldDeclaration == null || !parent.FieldDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FieldDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassMemberDeclaration(Use_ClassMemberDeclaration_FieldDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.FieldDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.FieldDeclaration == null || parent.FieldDeclaration.IsMissing) AddResultsForClassMemberDeclaration(Use_ClassMemberDeclaration_FieldDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.FieldDeclaration);
		        }
		    }
		    if (parent.FieldDeclaration != null) position += parent.FieldDeclaration.FullSpan.Length;
		    if (parent.OperationDeclaration == null || parent.OperationDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.OperationDeclaration == null || !parent.OperationDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.OperationDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassMemberDeclaration(Use_ClassMemberDeclaration_OperationDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.OperationDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.OperationDeclaration == null || parent.OperationDeclaration.IsMissing) AddResultsForClassMemberDeclaration(Use_ClassMemberDeclaration_OperationDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.OperationDeclaration);
		        }
		    }
		    if (parent.OperationDeclaration != null) position += parent.OperationDeclaration.FullSpan.Length;
		}
		
		public void VisitFieldDeclaration(FieldDeclarationSyntax parent) // 32
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldDeclaration(Use_FieldDeclaration_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.FieldSymbolPropertyAttribute == null || parent.FieldSymbolPropertyAttribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.FieldSymbolPropertyAttribute == null || !parent.FieldSymbolPropertyAttribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FieldSymbolPropertyAttribute);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldDeclaration(Use_FieldDeclaration_FieldSymbolPropertyAttribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.FieldSymbolPropertyAttribute);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.FieldSymbolPropertyAttribute == null || parent.FieldSymbolPropertyAttribute.IsMissing) AddResultsForFieldDeclaration(Use_FieldDeclaration_FieldSymbolPropertyAttribute, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.FieldSymbolPropertyAttribute);
		        }
		    }
		    if (parent.FieldSymbolPropertyAttribute != null) position += parent.FieldSymbolPropertyAttribute.FullSpan.Length;
		    if (parent.FieldContainment == null || parent.FieldContainment.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.FieldContainment == null || !parent.FieldContainment.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FieldContainment);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldDeclaration(Use_FieldDeclaration_FieldContainment, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.FieldContainment);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.FieldContainment == null || parent.FieldContainment.IsMissing) AddResultsForFieldDeclaration(Use_FieldDeclaration_FieldContainment, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.FieldContainment);
		        }
		    }
		    if (parent.FieldContainment != null) position += parent.FieldContainment.FullSpan.Length;
		    if (parent.FieldModifier == null || parent.FieldModifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.FieldModifier == null || !parent.FieldModifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FieldModifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldDeclaration(Use_FieldDeclaration_FieldModifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.FieldModifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.FieldModifier == null || parent.FieldModifier.IsMissing) AddResultsForFieldDeclaration(Use_FieldDeclaration_FieldModifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.FieldModifier);
		        }
		    }
		    if (parent.FieldModifier != null) position += parent.FieldModifier.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldDeclaration(Use_FieldDeclaration_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForFieldDeclaration(Use_FieldDeclaration_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldDeclaration(Use_FieldDeclaration_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForFieldDeclaration(Use_FieldDeclaration_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		    if (parent.DefaultValue == null || parent.DefaultValue.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.DefaultValue == null || !parent.DefaultValue.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.DefaultValue);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldDeclaration(Use_FieldDeclaration_DefaultValue, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.DefaultValue);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.DefaultValue == null || parent.DefaultValue.IsMissing) AddResultsForFieldDeclaration(Use_FieldDeclaration_DefaultValue, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.DefaultValue);
		        }
		    }
		    if (parent.DefaultValue != null) position += parent.DefaultValue.FullSpan.Length;
		    if (parent.RedefinitionsOrSubsettings.Node == null || parent.RedefinitionsOrSubsettings.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.RedefinitionsOrSubsettings.Node == null || !parent.RedefinitionsOrSubsettings.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.RedefinitionsOrSubsettings.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldDeclaration(Use_FieldDeclaration_RedefinitionsOrSubsettings, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.RedefinitionsOrSubsettings)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.RedefinitionsOrSubsettings.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax parent) // 33
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBracket, operation);
		        }
		    }
		    position += parent.TOpenBracket.FullSpan.Length;
		    if (parent.KProperty.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KProperty);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KProperty, operation);
		        }
		    }
		    position += parent.KProperty.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldSymbolPropertyAttribute(Use_FieldSymbolPropertyAttribute_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForFieldSymbolPropertyAttribute(Use_FieldSymbolPropertyAttribute_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		}
		
		public void VisitFieldContainment(FieldContainmentSyntax parent) // 34
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KContainment.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KContainment);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KContainment, operation);
		        }
		    }
		    position += parent.KContainment.FullSpan.Length;
		}
		
		public void VisitFieldModifier(FieldModifierSyntax parent) // 35
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.FieldModifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.FieldModifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FieldModifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldModifier(Use_FieldModifier_FieldModifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.FieldModifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForFieldModifier(Use_FieldModifier_FieldModifier, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.FieldModifier.FullSpan.Length;
		}
		
		public void VisitDefaultValue(DefaultValueSyntax parent) // 36
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDefaultValue(Use_DefaultValue_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForDefaultValue(Use_DefaultValue_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax parent) // 37
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Redefinitions == null || parent.Redefinitions.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Redefinitions == null || !parent.Redefinitions.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Redefinitions);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRedefinitionsOrSubsettings(Use_RedefinitionsOrSubsettings_Redefinitions, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Redefinitions);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Redefinitions == null || parent.Redefinitions.IsMissing) AddResultsForRedefinitionsOrSubsettings(Use_RedefinitionsOrSubsettings_Redefinitions, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Redefinitions);
		        }
		    }
		    if (parent.Redefinitions != null) position += parent.Redefinitions.FullSpan.Length;
		    if (parent.Subsettings == null || parent.Subsettings.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Subsettings == null || !parent.Subsettings.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Subsettings);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRedefinitionsOrSubsettings(Use_RedefinitionsOrSubsettings_Subsettings, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Subsettings);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Subsettings == null || parent.Subsettings.IsMissing) AddResultsForRedefinitionsOrSubsettings(Use_RedefinitionsOrSubsettings_Subsettings, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Subsettings);
		        }
		    }
		    if (parent.Subsettings != null) position += parent.Subsettings.FullSpan.Length;
		}
		
		public void VisitRedefinitions(RedefinitionsSyntax parent) // 38
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KRedefines.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KRedefines);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KRedefines, operation);
		        }
		    }
		    position += parent.KRedefines.FullSpan.Length;
		    if (parent.NameUseList == null || parent.NameUseList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.NameUseList == null || !parent.NameUseList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NameUseList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRedefinitions(Use_Redefinitions_NameUseList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NameUseList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NameUseList == null || parent.NameUseList.IsMissing) AddResultsForRedefinitions(Use_Redefinitions_NameUseList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NameUseList);
		        }
		    }
		    if (parent.NameUseList != null) position += parent.NameUseList.FullSpan.Length;
		}
		
		public void VisitSubsettings(SubsettingsSyntax parent) // 39
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KSubsets.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KSubsets);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KSubsets, operation);
		        }
		    }
		    position += parent.KSubsets.FullSpan.Length;
		    if (parent.NameUseList == null || parent.NameUseList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.NameUseList == null || !parent.NameUseList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NameUseList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSubsettings(Use_Subsettings_NameUseList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NameUseList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NameUseList == null || parent.NameUseList.IsMissing) AddResultsForSubsettings(Use_Subsettings_NameUseList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NameUseList);
		        }
		    }
		    if (parent.NameUseList != null) position += parent.NameUseList.FullSpan.Length;
		}
		
		public void VisitNameUseList(NameUseListSyntax parent) // 40
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier.Node == null || parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Qualifier.Node == null || !parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNameUseList(Use_NameUseList_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Qualifier.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		}
		
		public void VisitConstDeclaration(ConstDeclarationSyntax parent) // 41
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KConst.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KConst);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KConst, operation);
		        }
		    }
		    position += parent.KConst.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForConstDeclaration(Use_ConstDeclaration_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForConstDeclaration(Use_ConstDeclaration_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForConstDeclaration(Use_ConstDeclaration_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForConstDeclaration(Use_ConstDeclaration_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		    if (parent.ConstValue == null || parent.ConstValue.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ConstValue == null || !parent.ConstValue.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ConstValue);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForConstDeclaration(Use_ConstDeclaration_ConstValue, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ConstValue);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ConstValue == null || parent.ConstValue.IsMissing) AddResultsForConstDeclaration(Use_ConstDeclaration_ConstValue, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ConstValue);
		        }
		    }
		    if (parent.ConstValue != null) position += parent.ConstValue.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitConstValue(ConstValueSyntax parent) // 42
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForConstValue(Use_ConstValue_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForConstValue(Use_ConstValue_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitReturnType(ReturnTypeSyntax parent) // 43
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TypeReference == null || parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.TypeReference == null || !parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForReturnType(Use_ReturnType_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForReturnType(Use_ReturnType_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    if (parent.TypeReference != null) position += parent.TypeReference.FullSpan.Length;
		    if (parent.VoidType == null || parent.VoidType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.VoidType == null || !parent.VoidType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.VoidType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForReturnType(Use_ReturnType_VoidType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.VoidType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.VoidType == null || parent.VoidType.IsMissing) AddResultsForReturnType(Use_ReturnType_VoidType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.VoidType);
		        }
		    }
		    if (parent.VoidType != null) position += parent.VoidType.FullSpan.Length;
		}
		
		public void VisitTypeOfReference(TypeOfReferenceSyntax parent) // 44
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeOfReference(Use_TypeOfReference_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForTypeOfReference(Use_TypeOfReference_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		}
		
		public void VisitTypeReference(TypeReferenceSyntax parent) // 45
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.CollectionType == null || parent.CollectionType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.CollectionType == null || !parent.CollectionType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.CollectionType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeReference(Use_TypeReference_CollectionType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.CollectionType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.CollectionType == null || parent.CollectionType.IsMissing) AddResultsForTypeReference(Use_TypeReference_CollectionType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.CollectionType);
		        }
		    }
		    if (parent.CollectionType != null) position += parent.CollectionType.FullSpan.Length;
		    if (parent.SimpleType == null || parent.SimpleType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.SimpleType == null || !parent.SimpleType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.SimpleType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeReference(Use_TypeReference_SimpleType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.SimpleType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.SimpleType == null || parent.SimpleType.IsMissing) AddResultsForTypeReference(Use_TypeReference_SimpleType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.SimpleType);
		        }
		    }
		    if (parent.SimpleType != null) position += parent.SimpleType.FullSpan.Length;
		}
		
		public void VisitSimpleType(SimpleTypeSyntax parent) // 46
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.PrimitiveType == null || parent.PrimitiveType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.PrimitiveType == null || !parent.PrimitiveType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.PrimitiveType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSimpleType(Use_SimpleType_PrimitiveType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.PrimitiveType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.PrimitiveType == null || parent.PrimitiveType.IsMissing) AddResultsForSimpleType(Use_SimpleType_PrimitiveType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.PrimitiveType);
		        }
		    }
		    if (parent.PrimitiveType != null) position += parent.PrimitiveType.FullSpan.Length;
		    if (parent.ObjectType == null || parent.ObjectType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ObjectType == null || !parent.ObjectType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ObjectType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSimpleType(Use_SimpleType_ObjectType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ObjectType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ObjectType == null || parent.ObjectType.IsMissing) AddResultsForSimpleType(Use_SimpleType_ObjectType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ObjectType);
		        }
		    }
		    if (parent.ObjectType != null) position += parent.ObjectType.FullSpan.Length;
		    if (parent.NullableType == null || parent.NullableType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.NullableType == null || !parent.NullableType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NullableType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSimpleType(Use_SimpleType_NullableType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NullableType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NullableType == null || parent.NullableType.IsMissing) AddResultsForSimpleType(Use_SimpleType_NullableType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NullableType);
		        }
		    }
		    if (parent.NullableType != null) position += parent.NullableType.FullSpan.Length;
		    if (parent.ClassType == null || parent.ClassType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ClassType == null || !parent.ClassType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ClassType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSimpleType(Use_SimpleType_ClassType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ClassType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ClassType == null || parent.ClassType.IsMissing) AddResultsForSimpleType(Use_SimpleType_ClassType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ClassType);
		        }
		    }
		    if (parent.ClassType != null) position += parent.ClassType.FullSpan.Length;
		}
		
		public void VisitClassType(ClassTypeSyntax parent) // 47
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForClassType(Use_ClassType_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForClassType(Use_ClassType_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		}
		
		public void VisitObjectType(ObjectTypeSyntax parent) // 48
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ObjectType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ObjectType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ObjectType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForObjectType(Use_ObjectType_ObjectType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ObjectType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForObjectType(Use_ObjectType_ObjectType, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.ObjectType.FullSpan.Length;
		}
		
		public void VisitPrimitiveType(PrimitiveTypeSyntax parent) // 49
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.PrimitiveType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.PrimitiveType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.PrimitiveType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForPrimitiveType(Use_PrimitiveType_PrimitiveType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.PrimitiveType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForPrimitiveType(Use_PrimitiveType_PrimitiveType, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.PrimitiveType.FullSpan.Length;
		}
		
		public void VisitVoidType(VoidTypeSyntax parent) // 50
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KVoid.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.KVoid.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.KVoid);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForVoidType(Use_VoidType_KVoid, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.KVoid);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.KVoid.GetKind() == SyntaxKind.None || parent.KVoid.IsMissing) AddResultsForVoidType(Use_VoidType_KVoid, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.KVoid, operation);
		        }
		    }
		    position += parent.KVoid.FullSpan.Length;
		}
		
		public void VisitNullableType(NullableTypeSyntax parent) // 51
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.PrimitiveType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.PrimitiveType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.PrimitiveType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNullableType(Use_NullableType_PrimitiveType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.PrimitiveType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.PrimitiveType == null || parent.PrimitiveType.IsMissing) AddResultsForNullableType(Use_NullableType_PrimitiveType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.PrimitiveType);
		        }
		    }
		    position += parent.PrimitiveType.FullSpan.Length;
		    if (parent.TQuestion.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TQuestion);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TQuestion, operation);
		        }
		    }
		    position += parent.TQuestion.FullSpan.Length;
		}
		
		public void VisitCollectionType(CollectionTypeSyntax parent) // 52
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.CollectionKind.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.CollectionKind.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.CollectionKind);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCollectionType(Use_CollectionType_CollectionKind, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.CollectionKind);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.CollectionKind == null || parent.CollectionKind.IsMissing) AddResultsForCollectionType(Use_CollectionType_CollectionKind, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.CollectionKind);
		        }
		    }
		    position += parent.CollectionKind.FullSpan.Length;
		    if (parent.TLessThan.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TLessThan);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TLessThan, operation);
		        }
		    }
		    position += parent.TLessThan.FullSpan.Length;
		    if (parent.SimpleType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.SimpleType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.SimpleType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCollectionType(Use_CollectionType_SimpleType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.SimpleType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.SimpleType == null || parent.SimpleType.IsMissing) AddResultsForCollectionType(Use_CollectionType_SimpleType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.SimpleType);
		        }
		    }
		    position += parent.SimpleType.FullSpan.Length;
		    if (parent.TGreaterThan.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TGreaterThan);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TGreaterThan, operation);
		        }
		    }
		    position += parent.TGreaterThan.FullSpan.Length;
		}
		
		public void VisitCollectionKind(CollectionKindSyntax parent) // 53
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.CollectionKind.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.CollectionKind.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.CollectionKind);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCollectionKind(Use_CollectionKind_CollectionKind, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.CollectionKind);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForCollectionKind(Use_CollectionKind_CollectionKind, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.CollectionKind.FullSpan.Length;
		}
		
		public void VisitOperationDeclaration(OperationDeclarationSyntax parent) // 54
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOperationDeclaration(Use_OperationDeclaration_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.OperationModifier.Node == null || parent.OperationModifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.OperationModifier.Node == null || !parent.OperationModifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.OperationModifier.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOperationDeclaration(Use_OperationDeclaration_OperationModifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.OperationModifier)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.OperationModifier.FullSpan.Length;
		    if (parent.ReturnType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ReturnType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ReturnType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOperationDeclaration(Use_OperationDeclaration_ReturnType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ReturnType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ReturnType == null || parent.ReturnType.IsMissing) AddResultsForOperationDeclaration(Use_OperationDeclaration_ReturnType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ReturnType);
		        }
		    }
		    position += parent.ReturnType.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOperationDeclaration(Use_OperationDeclaration_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForOperationDeclaration(Use_OperationDeclaration_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.ParameterList == null || parent.ParameterList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParameterList == null || !parent.ParameterList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParameterList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOperationDeclaration(Use_OperationDeclaration_ParameterList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParameterList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParameterList == null || parent.ParameterList.IsMissing) AddResultsForOperationDeclaration(Use_OperationDeclaration_ParameterList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParameterList);
		        }
		    }
		    if (parent.ParameterList != null) position += parent.ParameterList.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitOperationModifier(OperationModifierSyntax parent) // 55
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.OperationModifierBuilder == null || parent.OperationModifierBuilder.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.OperationModifierBuilder == null || !parent.OperationModifierBuilder.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.OperationModifierBuilder);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOperationModifier(Use_OperationModifier_OperationModifierBuilder, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.OperationModifierBuilder);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.OperationModifierBuilder == null || parent.OperationModifierBuilder.IsMissing) AddResultsForOperationModifier(Use_OperationModifier_OperationModifierBuilder, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.OperationModifierBuilder);
		        }
		    }
		    if (parent.OperationModifierBuilder != null) position += parent.OperationModifierBuilder.FullSpan.Length;
		    if (parent.OperationModifierReadonly == null || parent.OperationModifierReadonly.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.OperationModifierReadonly == null || !parent.OperationModifierReadonly.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.OperationModifierReadonly);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOperationModifier(Use_OperationModifier_OperationModifierReadonly, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.OperationModifierReadonly);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.OperationModifierReadonly == null || parent.OperationModifierReadonly.IsMissing) AddResultsForOperationModifier(Use_OperationModifier_OperationModifierReadonly, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.OperationModifierReadonly);
		        }
		    }
		    if (parent.OperationModifierReadonly != null) position += parent.OperationModifierReadonly.FullSpan.Length;
		}
		
		public void VisitOperationModifierBuilder(OperationModifierBuilderSyntax parent) // 56
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KBuilder.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KBuilder);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KBuilder, operation);
		        }
		    }
		    position += parent.KBuilder.FullSpan.Length;
		}
		
		public void VisitOperationModifierReadonly(OperationModifierReadonlySyntax parent) // 57
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KReadonly.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KReadonly);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KReadonly, operation);
		        }
		    }
		    position += parent.KReadonly.FullSpan.Length;
		}
		
		public void VisitParameterList(ParameterListSyntax parent) // 58
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Parameter.Node == null || parent.Parameter.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Parameter.Node == null || !parent.Parameter.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Parameter.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParameterList(Use_ParameterList_Parameter, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Parameter.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.Parameter.FullSpan.Length;
		}
		
		public void VisitParameter(ParameterSyntax parent) // 59
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParameter(Use_Parameter_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParameter(Use_Parameter_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForParameter(Use_Parameter_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParameter(Use_Parameter_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForParameter(Use_Parameter_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		}
		
		public void VisitAssociationDeclaration(AssociationDeclarationSyntax parent) // 60
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Attribute.Node == null || parent.Attribute.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Attribute.Node == null || !parent.Attribute.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Attribute.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAssociationDeclaration(Use_AssociationDeclaration_Attribute, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Attribute)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Attribute.FullSpan.Length;
		    if (parent.KAssociation.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KAssociation);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KAssociation, operation);
		        }
		    }
		    position += parent.KAssociation.FullSpan.Length;
		    if (parent.Source.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Source.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Source);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAssociationDeclaration(Use_AssociationDeclaration_Source, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Source);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Source == null || parent.Source.IsMissing) AddResultsForAssociationDeclaration(Use_AssociationDeclaration_Source, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Source);
		        }
		    }
		    position += parent.Source.FullSpan.Length;
		    if (parent.KWith.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KWith);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KWith, operation);
		        }
		    }
		    position += parent.KWith.FullSpan.Length;
		    if (parent.Target.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Target.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Target);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAssociationDeclaration(Use_AssociationDeclaration_Target, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Target);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Target == null || parent.Target.IsMissing) AddResultsForAssociationDeclaration(Use_AssociationDeclaration_Target, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Target);
		        }
		    }
		    position += parent.Target.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitIdentifier(IdentifierSyntax parent) // 61
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitLiteral(LiteralSyntax parent) // 62
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.NullLiteral == null || parent.NullLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.NullLiteral == null || !parent.NullLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NullLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_NullLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NullLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NullLiteral == null || parent.NullLiteral.IsMissing) AddResultsForLiteral(Use_Literal_NullLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NullLiteral);
		        }
		    }
		    if (parent.NullLiteral != null) position += parent.NullLiteral.FullSpan.Length;
		    if (parent.BooleanLiteral == null || parent.BooleanLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.BooleanLiteral == null || !parent.BooleanLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.BooleanLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_BooleanLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.BooleanLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.BooleanLiteral == null || parent.BooleanLiteral.IsMissing) AddResultsForLiteral(Use_Literal_BooleanLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.BooleanLiteral);
		        }
		    }
		    if (parent.BooleanLiteral != null) position += parent.BooleanLiteral.FullSpan.Length;
		    if (parent.IntegerLiteral == null || parent.IntegerLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.IntegerLiteral == null || !parent.IntegerLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.IntegerLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_IntegerLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.IntegerLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.IntegerLiteral == null || parent.IntegerLiteral.IsMissing) AddResultsForLiteral(Use_Literal_IntegerLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.IntegerLiteral);
		        }
		    }
		    if (parent.IntegerLiteral != null) position += parent.IntegerLiteral.FullSpan.Length;
		    if (parent.DecimalLiteral == null || parent.DecimalLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.DecimalLiteral == null || !parent.DecimalLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.DecimalLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_DecimalLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.DecimalLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.DecimalLiteral == null || parent.DecimalLiteral.IsMissing) AddResultsForLiteral(Use_Literal_DecimalLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.DecimalLiteral);
		        }
		    }
		    if (parent.DecimalLiteral != null) position += parent.DecimalLiteral.FullSpan.Length;
		    if (parent.ScientificLiteral == null || parent.ScientificLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ScientificLiteral == null || !parent.ScientificLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ScientificLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_ScientificLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ScientificLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ScientificLiteral == null || parent.ScientificLiteral.IsMissing) AddResultsForLiteral(Use_Literal_ScientificLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ScientificLiteral);
		        }
		    }
		    if (parent.ScientificLiteral != null) position += parent.ScientificLiteral.FullSpan.Length;
		    if (parent.StringLiteral == null || parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.StringLiteral == null || !parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForLiteral(Use_Literal_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    if (parent.StringLiteral != null) position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitNullLiteral(NullLiteralSyntax parent) // 63
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KNull.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KNull);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KNull, operation);
		        }
		    }
		    position += parent.KNull.FullSpan.Length;
		}
		
		public void VisitBooleanLiteral(BooleanLiteralSyntax parent) // 64
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.BooleanLiteral.FullSpan.Length;
		}
		
		public void VisitIntegerLiteral(IntegerLiteralSyntax parent) // 65
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LInteger.FullSpan.Length;
		}
		
		public void VisitDecimalLiteral(DecimalLiteralSyntax parent) // 66
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LDecimal.FullSpan.Length;
		}
		
		public void VisitScientificLiteral(ScientificLiteralSyntax parent) // 67
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LScientific.FullSpan.Length;
		}
		
		public void VisitStringLiteral(StringLiteralSyntax parent) // 68
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LRegularString.FullSpan.Length;
		}

        public void VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node)
        {
        }

        
        public void AddResultsForMain(object use, CompletionSearchFlags operation, Binder parentBinder) // 0
        {
            if (_visited[0]) return;
            _visited[0] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_Main_UsingNamespaceOrMetamodel)
            {
                var binder = ruleBinder;
                AddResultsForUsingNamespaceOrMetamodel(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Main_NamespaceDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForNamespaceDeclaration(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.Eof, operation);
                use = FinishedUse;
            }
            _visited[0] = false;
        }
        
        public void AddResultsForName(object use, CompletionSearchFlags operation, Binder parentBinder) // 1
        {
            if (_visited[1]) return;
            _visited[1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_Name_Identifier)
            {
                var binder = ruleBinder;
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[1] = false;
        }
        
        public void AddResultsForQualifiedName(object use, CompletionSearchFlags operation, Binder parentBinder) // 2
        {
            if (_visited[2]) return;
            _visited[2] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_QualifiedName_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[2] = false;
        }
        
        public void AddResultsForQualifier(object use, CompletionSearchFlags operation, Binder parentBinder) // 3
        {
            if (_visited[3]) return;
            _visited[3] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateQualifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_Qualifier_Identifier)
            {
                var binder = ruleBinder;
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[3] = false;
        }
        
        public void AddResultsForAttribute(object use, CompletionSearchFlags operation, Binder parentBinder) // 4
        {
            if (_visited[4]) return;
            _visited[4] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Attributes", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(MetaAttribute)), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_Attribute_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            _visited[4] = false;
        }
        
        public void AddResultsForUsingNamespaceOrMetamodel(object use, CompletionSearchFlags operation, Binder parentBinder) // 5
        {
            if (_visited[5]) return;
            _visited[5] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_UsingNamespaceOrMetamodel_UsingNamespace)
            {
                var binder = ruleBinder;
                AddResultsForUsingNamespace(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_UsingNamespaceOrMetamodel_UsingMetamodel)
            {
                var binder = ruleBinder;
                AddResultsForUsingMetamodel(UnassignedUse, operation, binder);
            }
            _visited[5] = false;
        }
        
        public void AddResultsForUsingNamespace(object use, CompletionSearchFlags operation, Binder parentBinder) // 6
        {
            if (_visited[6]) return;
            _visited[6] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateImportBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KUsing, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_UsingNamespace_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TAssign, operation);
            }
            if (use == UnassignedUse || use == Use_UsingNamespace_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[6] = false;
        }
        
        public void AddResultsForUsingMetamodel(object use, CompletionSearchFlags operation, Binder parentBinder) // 7
        {
            if (_visited[7]) return;
            _visited[7] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateMetamodelImportBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KUsing, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KMetamodel, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_UsingMetamodel_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TAssign, operation);
            }
            if (use == UnassignedUse || use == Use_UsingMetamodel_UsingMetamodelReference)
            {
                var binder = ruleBinder;
                AddResultsForUsingMetamodelReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[7] = false;
        }
        
        public void AddResultsForUsingMetamodelReference(object use, CompletionSearchFlags operation, Binder parentBinder) // 8
        {
            if (_visited[8]) return;
            _visited[8] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_UsingMetamodelReference_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_UsingMetamodelReference_StringLiteral)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateValueBinder(binder, null, forCompletion: true);
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
            }
            _visited[8] = false;
        }
        
        public void AddResultsForNamespaceDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 9
        {
            if (_visited[9]) return;
            _visited[9] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaNamespace), nestingProperty: "Declarations", merge: true, forCompletion: true);
            if (use == UnassignedUse || use == Use_NamespaceDeclaration_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KNamespace, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NamespaceDeclaration_QualifiedName)
            {
                var binder = ruleBinder;
                AddResultsForQualifiedName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NamespaceDeclaration_NamespaceBody)
            {
                var binder = ruleBinder;
                AddResultsForNamespaceBody(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[9] = false;
        }
        
        public void AddResultsForNamespaceBody(object use, CompletionSearchFlags operation, Binder parentBinder) // 10
        {
            if (_visited[10]) return;
            _visited[10] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateScopeBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBrace, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NamespaceBody_UsingNamespaceOrMetamodel)
            {
                var binder = ruleBinder;
                AddResultsForUsingNamespaceOrMetamodel(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_NamespaceBody_MetamodelDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForMetamodelDeclaration(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NamespaceBody_Declaration)
            {
                var binder = ruleBinder;
                AddResultsForDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBrace, operation);
                use = FinishedUse;
            }
            _visited[10] = false;
        }
        
        public void AddResultsForMetamodelDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 11
        {
            if (_visited[11]) return;
            _visited[11] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "DefinedMetaModel", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaModel), forCompletion: true);
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Documentation", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDocumentationBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_MetamodelDeclaration_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KMetamodel, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_MetamodelDeclaration_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenParen, operation);
            }
            if (use == UnassignedUse || use == Use_MetamodelDeclaration_MetamodelPropertyList)
            {
                var binder = ruleBinder;
                AddResultsForMetamodelPropertyList(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseParen, operation);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[11] = false;
        }
        
        public void AddResultsForMetamodelPropertyList(object use, CompletionSearchFlags operation, Binder parentBinder) // 12
        {
            if (_visited[12]) return;
            _visited[12] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_MetamodelPropertyList_MetamodelProperty)
            {
                var binder = ruleBinder;
                AddResultsForMetamodelProperty(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[12] = false;
        }
        
        public void AddResultsForMetamodelProperty(object use, CompletionSearchFlags operation, Binder parentBinder) // 13
        {
            if (_visited[13]) return;
            _visited[13] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_MetamodelProperty_MetamodelUriProperty)
            {
                var binder = ruleBinder;
                AddResultsForMetamodelUriProperty(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_MetamodelProperty_MetamodelPrefixProperty)
            {
                var binder = ruleBinder;
                AddResultsForMetamodelPrefixProperty(UnassignedUse, operation, binder);
            }
            _visited[13] = false;
        }
        
        public void AddResultsForMetamodelUriProperty(object use, CompletionSearchFlags operation, Binder parentBinder) // 14
        {
            if (_visited[14]) return;
            _visited[14] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Uri", forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.IUri, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TAssign, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_MetamodelUriProperty_StringLiteral)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateValueBinder(binder, null, forCompletion: true);
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[14] = false;
        }
        
        public void AddResultsForMetamodelPrefixProperty(object use, CompletionSearchFlags operation, Binder parentBinder) // 15
        {
            if (_visited[15]) return;
            _visited[15] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Prefix", forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.IPrefix, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TAssign, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_MetamodelPrefixProperty_StringLiteral)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateValueBinder(binder, null, forCompletion: true);
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[15] = false;
        }
        
        public void AddResultsForDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 16
        {
            if (_visited[16]) return;
            _visited[16] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_Declaration_EnumDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForEnumDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Declaration_ClassDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForClassDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Declaration_AssociationDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForAssociationDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Declaration_ConstDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForConstDeclaration(UnassignedUse, operation, binder);
            }
            _visited[16] = false;
        }
        
        public void AddResultsForEnumDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 17
        {
            if (_visited[17]) return;
            _visited[17] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Declarations", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaEnum), forCompletion: true);
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Documentation", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDocumentationBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_EnumDeclaration_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KEnum, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_EnumDeclaration_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_EnumDeclaration_EnumBody)
            {
                var binder = ruleBinder;
                AddResultsForEnumBody(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[17] = false;
        }
        
        public void AddResultsForEnumBody(object use, CompletionSearchFlags operation, Binder parentBinder) // 18
        {
            if (_visited[18]) return;
            _visited[18] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateScopeBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBrace, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_EnumBody_EnumValues)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "EnumLiterals", forCompletion: true);
                AddResultsForEnumValues(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TSemicolon, operation);
            }
            if (use == UnassignedUse || use == Use_EnumBody_EnumMemberDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForEnumMemberDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBrace, operation);
                use = FinishedUse;
            }
            _visited[18] = false;
        }
        
        public void AddResultsForEnumValues(object use, CompletionSearchFlags operation, Binder parentBinder) // 19
        {
            if (_visited[19]) return;
            _visited[19] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_EnumValues_EnumValue)
            {
                var binder = ruleBinder;
                AddResultsForEnumValue(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[19] = false;
        }
        
        public void AddResultsForEnumValue(object use, CompletionSearchFlags operation, Binder parentBinder) // 20
        {
            if (_visited[20]) return;
            _visited[20] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaEnumLiteral), forCompletion: true);
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Documentation", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDocumentationBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_EnumValue_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_EnumValue_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[20] = false;
        }
        
        public void AddResultsForEnumMemberDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 21
        {
            if (_visited[21]) return;
            _visited[21] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_EnumMemberDeclaration_OperationDeclaration)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operations", forCompletion: true);
                AddResultsForOperationDeclaration(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[21] = false;
        }
        
        public void AddResultsForClassDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 22
        {
            if (_visited[22]) return;
            _visited[22] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Declarations", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaClass), forCompletion: true);
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Documentation", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDocumentationBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_ClassDeclaration_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ClassDeclaration_SymbolAttribute)
            {
                var binder = ruleBinder;
                AddResultsForSymbolAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ClassDeclaration_KAbstract)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "IsAbstract", value: true, forCompletion: true);
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KAbstract, operation);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KClass, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ClassDeclaration_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TColon, operation);
            }
            if (use == UnassignedUse || use == Use_ClassDeclaration_ClassAncestors)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "SuperClasses", forCompletion: true);
                AddResultsForClassAncestors(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ClassDeclaration_ClassBody)
            {
                var binder = ruleBinder;
                AddResultsForClassBody(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[22] = false;
        }
        
        public void AddResultsForSymbolAttribute(object use, CompletionSearchFlags operation, Binder parentBinder) // 23
        {
            if (_visited[23]) return;
            _visited[23] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "SymbolType", forCompletion: true);
            if (use == UnassignedUse || use == Use_SymbolAttribute_SymbolSymbolAttribute)
            {
                var binder = ruleBinder;
                AddResultsForSymbolSymbolAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_SymbolAttribute_ExpressionSymbolAttribute)
            {
                var binder = ruleBinder;
                AddResultsForExpressionSymbolAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_SymbolAttribute_StatementSymbolTypeAttribute)
            {
                var binder = ruleBinder;
                AddResultsForStatementSymbolTypeAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_SymbolAttribute_TypeSymbolTypeAttribute)
            {
                var binder = ruleBinder;
                AddResultsForTypeSymbolTypeAttribute(UnassignedUse, operation, binder);
            }
            _visited[23] = false;
        }
        
        public void AddResultsForSymbolSymbolAttribute(object use, CompletionSearchFlags operation, Binder parentBinder) // 24
        {
            if (_visited[24]) return;
            _visited[24] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateSymbolSymbolBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KSymbol, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TColon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_SymbolSymbolAttribute_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            _visited[24] = false;
        }
        
        public void AddResultsForExpressionSymbolAttribute(object use, CompletionSearchFlags operation, Binder parentBinder) // 25
        {
            if (_visited[25]) return;
            _visited[25] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateExpressionSymbolBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KExpression, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TColon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ExpressionSymbolAttribute_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            _visited[25] = false;
        }
        
        public void AddResultsForStatementSymbolTypeAttribute(object use, CompletionSearchFlags operation, Binder parentBinder) // 26
        {
            if (_visited[26]) return;
            _visited[26] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateStatementSymbolBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KStatement, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TColon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_StatementSymbolTypeAttribute_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            _visited[26] = false;
        }
        
        public void AddResultsForTypeSymbolTypeAttribute(object use, CompletionSearchFlags operation, Binder parentBinder) // 27
        {
            if (_visited[27]) return;
            _visited[27] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateTypeSymbolBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KType, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TColon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_TypeSymbolTypeAttribute_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            _visited[27] = false;
        }
        
        public void AddResultsForClassBody(object use, CompletionSearchFlags operation, Binder parentBinder) // 28
        {
            if (_visited[28]) return;
            _visited[28] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateScopeBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBrace, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ClassBody_ClassMemberDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForClassMemberDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBrace, operation);
                use = FinishedUse;
            }
            _visited[28] = false;
        }
        
        public void AddResultsForClassAncestors(object use, CompletionSearchFlags operation, Binder parentBinder) // 29
        {
            if (_visited[29]) return;
            _visited[29] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ClassAncestors_ClassAncestor)
            {
                var binder = ruleBinder;
                AddResultsForClassAncestor(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[29] = false;
        }
        
        public void AddResultsForClassAncestor(object use, CompletionSearchFlags operation, Binder parentBinder) // 30
        {
            if (_visited[30]) return;
            _visited[30] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ClassAncestor_Qualifier)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(MetaClass)), forCompletion: true);
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[30] = false;
        }
        
        public void AddResultsForClassMemberDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 31
        {
            if (_visited[31]) return;
            _visited[31] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ClassMemberDeclaration_FieldDeclaration)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Properties", forCompletion: true);
                AddResultsForFieldDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ClassMemberDeclaration_OperationDeclaration)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operations", forCompletion: true);
                AddResultsForOperationDeclaration(UnassignedUse, operation, binder);
            }
            _visited[31] = false;
        }
        
        public void AddResultsForFieldDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 32
        {
            if (_visited[32]) return;
            _visited[32] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaProperty), forCompletion: true);
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Documentation", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDocumentationBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_FieldDeclaration_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_FieldDeclaration_FieldSymbolPropertyAttribute)
            {
                var binder = ruleBinder;
                AddResultsForFieldSymbolPropertyAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_FieldDeclaration_FieldContainment)
            {
                var binder = ruleBinder;
                AddResultsForFieldContainment(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_FieldDeclaration_FieldModifier)
            {
                var binder = ruleBinder;
                AddResultsForFieldModifier(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_FieldDeclaration_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Type", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_FieldDeclaration_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_FieldDeclaration_DefaultValue)
            {
                var binder = ruleBinder;
                AddResultsForDefaultValue(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_FieldDeclaration_RedefinitionsOrSubsettings)
            {
                var binder = ruleBinder;
                AddResultsForRedefinitionsOrSubsettings(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[32] = false;
        }
        
        public void AddResultsForFieldSymbolPropertyAttribute(object use, CompletionSearchFlags operation, Binder parentBinder) // 33
        {
            if (_visited[33]) return;
            _visited[33] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "SymbolProperty", forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KProperty, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TColon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_FieldSymbolPropertyAttribute_Identifier)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateSymbolPropertyBinder(binder, null, forCompletion: true);
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            _visited[33] = false;
        }
        
        public void AddResultsForFieldContainment(object use, CompletionSearchFlags operation, Binder parentBinder) // 34
        {
            if (_visited[34]) return;
            _visited[34] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "IsContainment", value: true, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KContainment, operation);
                use = FinishedUse;
            }
            _visited[34] = false;
        }
        
        public void AddResultsForFieldModifier(object use, CompletionSearchFlags operation, Binder parentBinder) // 35
        {
            if (_visited[35]) return;
            _visited[35] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Kind", forCompletion: true);
            if (use == UnassignedUse || use == Use_FieldModifier_FieldModifier)
            {
                var binder = ruleBinder;
            	var KReadonlyBinder = binder;
            	KReadonlyBinder = this.BinderFactory.CreateValueBinder(KReadonlyBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KReadonly), value: MetaPropertyKind.Readonly, forCompletion: true);
            	AddBinder(KReadonlyBinder, (MetaSyntaxKind)MetaSyntaxKind.KReadonly, operation);
            	var KLazyBinder = binder;
            	KLazyBinder = this.BinderFactory.CreateValueBinder(KLazyBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KLazy), value: MetaPropertyKind.Lazy, forCompletion: true);
            	AddBinder(KLazyBinder, (MetaSyntaxKind)MetaSyntaxKind.KLazy, operation);
            	var KDerivedBinder = binder;
            	KDerivedBinder = this.BinderFactory.CreateValueBinder(KDerivedBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KDerived), value: MetaPropertyKind.Derived, forCompletion: true);
            	AddBinder(KDerivedBinder, (MetaSyntaxKind)MetaSyntaxKind.KDerived, operation);
            	var KUnionBinder = binder;
            	KUnionBinder = this.BinderFactory.CreateValueBinder(KUnionBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KUnion), value: MetaPropertyKind.DerivedUnion, forCompletion: true);
            	AddBinder(KUnionBinder, (MetaSyntaxKind)MetaSyntaxKind.KUnion, operation);
                use = FinishedUse;
            }
            _visited[35] = false;
        }
        
        public void AddResultsForDefaultValue(object use, CompletionSearchFlags operation, Binder parentBinder) // 36
        {
            if (_visited[36]) return;
            _visited[36] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "DefaultValue", forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TAssign, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_DefaultValue_StringLiteral)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateValueBinder(binder, null, forCompletion: true);
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[36] = false;
        }
        
        public void AddResultsForRedefinitionsOrSubsettings(object use, CompletionSearchFlags operation, Binder parentBinder) // 37
        {
            if (_visited[37]) return;
            _visited[37] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_RedefinitionsOrSubsettings_Redefinitions)
            {
                var binder = ruleBinder;
                AddResultsForRedefinitions(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_RedefinitionsOrSubsettings_Subsettings)
            {
                var binder = ruleBinder;
                AddResultsForSubsettings(UnassignedUse, operation, binder);
            }
            _visited[37] = false;
        }
        
        public void AddResultsForRedefinitions(object use, CompletionSearchFlags operation, Binder parentBinder) // 38
        {
            if (_visited[38]) return;
            _visited[38] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KRedefines, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_Redefinitions_NameUseList)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RedefinedProperties", forCompletion: true);
                AddResultsForNameUseList(UnassignedUse, operation, binder);
            }
            _visited[38] = false;
        }
        
        public void AddResultsForSubsettings(object use, CompletionSearchFlags operation, Binder parentBinder) // 39
        {
            if (_visited[39]) return;
            _visited[39] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KSubsets, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_Subsettings_NameUseList)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "SubsettedProperties", forCompletion: true);
                AddResultsForNameUseList(UnassignedUse, operation, binder);
            }
            _visited[39] = false;
        }
        
        public void AddResultsForNameUseList(object use, CompletionSearchFlags operation, Binder parentBinder) // 40
        {
            if (_visited[40]) return;
            _visited[40] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(MetaProperty)), forCompletion: true);
            if (use == UnassignedUse || use == Use_NameUseList_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[40] = false;
        }
        
        public void AddResultsForConstDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 41
        {
            if (_visited[41]) return;
            _visited[41] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Declarations", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaConstant), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KConst, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ConstDeclaration_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Type", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ConstDeclaration_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ConstDeclaration_ConstValue)
            {
                var binder = ruleBinder;
                AddResultsForConstValue(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[41] = false;
        }
        
        public void AddResultsForConstValue(object use, CompletionSearchFlags operation, Binder parentBinder) // 42
        {
            if (_visited[42]) return;
            _visited[42] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "DotNetName", forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TAssign, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ConstValue_StringLiteral)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateValueBinder(binder, null, forCompletion: true);
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[42] = false;
        }
        
        public void AddResultsForReturnType(object use, CompletionSearchFlags operation, Binder parentBinder) // 43
        {
            if (_visited[43]) return;
            _visited[43] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(MetaType)), forCompletion: true);
            if (use == UnassignedUse || use == Use_ReturnType_TypeReference)
            {
                var binder = ruleBinder;
                AddResultsForTypeReference(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ReturnType_VoidType)
            {
                var binder = ruleBinder;
                AddResultsForVoidType(UnassignedUse, operation, binder);
            }
            _visited[43] = false;
        }
        
        public void AddResultsForTypeOfReference(object use, CompletionSearchFlags operation, Binder parentBinder) // 44
        {
            if (_visited[44]) return;
            _visited[44] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(MetaType)), forCompletion: true);
            if (use == UnassignedUse || use == Use_TypeOfReference_TypeReference)
            {
                var binder = ruleBinder;
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[44] = false;
        }
        
        public void AddResultsForTypeReference(object use, CompletionSearchFlags operation, Binder parentBinder) // 45
        {
            if (_visited[45]) return;
            _visited[45] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(MetaType)), forCompletion: true);
            if (use == UnassignedUse || use == Use_TypeReference_CollectionType)
            {
                var binder = ruleBinder;
                AddResultsForCollectionType(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_TypeReference_SimpleType)
            {
                var binder = ruleBinder;
                AddResultsForSimpleType(UnassignedUse, operation, binder);
            }
            _visited[45] = false;
        }
        
        public void AddResultsForSimpleType(object use, CompletionSearchFlags operation, Binder parentBinder) // 46
        {
            if (_visited[46]) return;
            _visited[46] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(MetaType)), forCompletion: true);
            if (use == UnassignedUse || use == Use_SimpleType_PrimitiveType)
            {
                var binder = ruleBinder;
                AddResultsForPrimitiveType(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_SimpleType_ObjectType)
            {
                var binder = ruleBinder;
                AddResultsForObjectType(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_SimpleType_NullableType)
            {
                var binder = ruleBinder;
                AddResultsForNullableType(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_SimpleType_ClassType)
            {
                var binder = ruleBinder;
                AddResultsForClassType(UnassignedUse, operation, binder);
            }
            _visited[46] = false;
        }
        
        public void AddResultsForClassType(object use, CompletionSearchFlags operation, Binder parentBinder) // 47
        {
            if (_visited[47]) return;
            _visited[47] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(MetaClass), typeof(MetaEnum), typeof(MetaConstant)), forCompletion: true);
            if (use == UnassignedUse || use == Use_ClassType_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[47] = false;
        }
        
        public void AddResultsForObjectType(object use, CompletionSearchFlags operation, Binder parentBinder) // 48
        {
            if (_visited[48]) return;
            _visited[48] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ObjectType_ObjectType)
            {
                var binder = ruleBinder;
            	var KObjectBinder = binder;
            	KObjectBinder = this.BinderFactory.CreateValueBinder(KObjectBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KObject), value: MetaInstance.Object, forCompletion: true);
            	AddBinder(KObjectBinder, (MetaSyntaxKind)MetaSyntaxKind.KObject, operation);
            	var KSymbolBinder = binder;
            	KSymbolBinder = this.BinderFactory.CreateValueBinder(KSymbolBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KSymbol), value: MetaInstance.ModelObject, forCompletion: true);
            	AddBinder(KSymbolBinder, (MetaSyntaxKind)MetaSyntaxKind.KSymbol, operation);
            	var KStringBinder = binder;
            	KStringBinder = this.BinderFactory.CreateValueBinder(KStringBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KString), value: MetaInstance.String, forCompletion: true);
            	AddBinder(KStringBinder, (MetaSyntaxKind)MetaSyntaxKind.KString, operation);
                use = FinishedUse;
            }
            _visited[48] = false;
        }
        
        public void AddResultsForPrimitiveType(object use, CompletionSearchFlags operation, Binder parentBinder) // 49
        {
            if (_visited[49]) return;
            _visited[49] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_PrimitiveType_PrimitiveType)
            {
                var binder = ruleBinder;
            	var KIntBinder = binder;
            	KIntBinder = this.BinderFactory.CreateValueBinder(KIntBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KInt), value: MetaInstance.Int, forCompletion: true);
            	AddBinder(KIntBinder, (MetaSyntaxKind)MetaSyntaxKind.KInt, operation);
            	var KLongBinder = binder;
            	KLongBinder = this.BinderFactory.CreateValueBinder(KLongBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KLong), value: MetaInstance.Long, forCompletion: true);
            	AddBinder(KLongBinder, (MetaSyntaxKind)MetaSyntaxKind.KLong, operation);
            	var KFloatBinder = binder;
            	KFloatBinder = this.BinderFactory.CreateValueBinder(KFloatBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KFloat), value: MetaInstance.Float, forCompletion: true);
            	AddBinder(KFloatBinder, (MetaSyntaxKind)MetaSyntaxKind.KFloat, operation);
            	var KDoubleBinder = binder;
            	KDoubleBinder = this.BinderFactory.CreateValueBinder(KDoubleBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KDouble), value: MetaInstance.Double, forCompletion: true);
            	AddBinder(KDoubleBinder, (MetaSyntaxKind)MetaSyntaxKind.KDouble, operation);
            	var KByteBinder = binder;
            	KByteBinder = this.BinderFactory.CreateValueBinder(KByteBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KByte), value: MetaInstance.Byte, forCompletion: true);
            	AddBinder(KByteBinder, (MetaSyntaxKind)MetaSyntaxKind.KByte, operation);
            	var KBoolBinder = binder;
            	KBoolBinder = this.BinderFactory.CreateValueBinder(KBoolBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KBool), value: MetaInstance.Bool, forCompletion: true);
            	AddBinder(KBoolBinder, (MetaSyntaxKind)MetaSyntaxKind.KBool, operation);
                use = FinishedUse;
            }
            _visited[49] = false;
        }
        
        public void AddResultsForVoidType(object use, CompletionSearchFlags operation, Binder parentBinder) // 50
        {
            if (_visited[50]) return;
            _visited[50] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_VoidType_KVoid)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateValueBinder(binder, null, value: MetaInstance.Void, forCompletion: true);
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KVoid, operation);
                use = FinishedUse;
            }
            _visited[50] = false;
        }
        
        public void AddResultsForNullableType(object use, CompletionSearchFlags operation, Binder parentBinder) // 51
        {
            if (_visited[51]) return;
            _visited[51] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaNullableType), forCompletion: true);
            if (use == UnassignedUse || use == Use_NullableType_PrimitiveType)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "InnerType", forCompletion: true);
                AddResultsForPrimitiveType(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TQuestion, operation);
                use = FinishedUse;
            }
            _visited[51] = false;
        }
        
        public void AddResultsForCollectionType(object use, CompletionSearchFlags operation, Binder parentBinder) // 52
        {
            if (_visited[52]) return;
            _visited[52] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaCollectionType), forCompletion: true);
            if (use == UnassignedUse || use == Use_CollectionType_CollectionKind)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Kind", forCompletion: true);
                AddResultsForCollectionKind(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TLessThan, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_CollectionType_SimpleType)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "InnerType", forCompletion: true);
                AddResultsForSimpleType(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TGreaterThan, operation);
                use = FinishedUse;
            }
            _visited[52] = false;
        }
        
        public void AddResultsForCollectionKind(object use, CompletionSearchFlags operation, Binder parentBinder) // 53
        {
            if (_visited[53]) return;
            _visited[53] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_CollectionKind_CollectionKind)
            {
                var binder = ruleBinder;
            	var KSetBinder = binder;
            	KSetBinder = this.BinderFactory.CreateValueBinder(KSetBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KSet), value: MetaCollectionKind.Set, forCompletion: true);
            	AddBinder(KSetBinder, (MetaSyntaxKind)MetaSyntaxKind.KSet, operation);
            	var KListBinder = binder;
            	KListBinder = this.BinderFactory.CreateValueBinder(KListBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KList), value: MetaCollectionKind.List, forCompletion: true);
            	AddBinder(KListBinder, (MetaSyntaxKind)MetaSyntaxKind.KList, operation);
            	var KMultiSetBinder = binder;
            	KMultiSetBinder = this.BinderFactory.CreateValueBinder(KMultiSetBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KMultiSet), value: MetaCollectionKind.MultiSet, forCompletion: true);
            	AddBinder(KMultiSetBinder, (MetaSyntaxKind)MetaSyntaxKind.KMultiSet, operation);
            	var KMultiListBinder = binder;
            	KMultiListBinder = this.BinderFactory.CreateValueBinder(KMultiListBinder, this.SyntaxFactory.MissingToken((MetaSyntaxKind)MetaSyntaxKind.KMultiList), value: MetaCollectionKind.MultiList, forCompletion: true);
            	AddBinder(KMultiListBinder, (MetaSyntaxKind)MetaSyntaxKind.KMultiList, operation);
                use = FinishedUse;
            }
            _visited[53] = false;
        }
        
        public void AddResultsForOperationDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 54
        {
            if (_visited[54]) return;
            _visited[54] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaOperation), forCompletion: true);
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Documentation", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDocumentationBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_OperationDeclaration_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_OperationDeclaration_OperationModifier)
            {
                var binder = ruleBinder;
                AddResultsForOperationModifier(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_OperationDeclaration_ReturnType)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "ReturnType", forCompletion: true);
                AddResultsForReturnType(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_OperationDeclaration_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_OperationDeclaration_ParameterList)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Parameters", forCompletion: true);
                AddResultsForParameterList(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[54] = false;
        }
        
        public void AddResultsForOperationModifier(object use, CompletionSearchFlags operation, Binder parentBinder) // 55
        {
            if (_visited[55]) return;
            _visited[55] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_OperationModifier_OperationModifierBuilder)
            {
                var binder = ruleBinder;
                AddResultsForOperationModifierBuilder(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_OperationModifier_OperationModifierReadonly)
            {
                var binder = ruleBinder;
                AddResultsForOperationModifierReadonly(UnassignedUse, operation, binder);
            }
            _visited[55] = false;
        }
        
        public void AddResultsForOperationModifierBuilder(object use, CompletionSearchFlags operation, Binder parentBinder) // 56
        {
            if (_visited[56]) return;
            _visited[56] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "IsBuilder", value: true, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KBuilder, operation);
                use = FinishedUse;
            }
            _visited[56] = false;
        }
        
        public void AddResultsForOperationModifierReadonly(object use, CompletionSearchFlags operation, Binder parentBinder) // 57
        {
            if (_visited[57]) return;
            _visited[57] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "IsReadonly", value: true, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KReadonly, operation);
                use = FinishedUse;
            }
            _visited[57] = false;
        }
        
        public void AddResultsForParameterList(object use, CompletionSearchFlags operation, Binder parentBinder) // 58
        {
            if (_visited[58]) return;
            _visited[58] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ParameterList_Parameter)
            {
                var binder = ruleBinder;
                AddResultsForParameter(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[58] = false;
        }
        
        public void AddResultsForParameter(object use, CompletionSearchFlags operation, Binder parentBinder) // 59
        {
            if (_visited[59]) return;
            _visited[59] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(MetaParameter), forCompletion: true);
            if (use == UnassignedUse || use == Use_Parameter_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Parameter_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Type", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_Parameter_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[59] = false;
        }
        
        public void AddResultsForAssociationDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 60
        {
            if (_visited[60]) return;
            _visited[60] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateSymbolBinder(ruleBinder, null, type: typeof(AssociationSymbol), forCompletion: true);
            if (use == UnassignedUse || use == Use_AssociationDeclaration_Attribute)
            {
                var binder = ruleBinder;
                AddResultsForAttribute(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KAssociation, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AssociationDeclaration_Source)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Left", forCompletion: true);
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(MetaProperty)), forCompletion: true);
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KWith, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AssociationDeclaration_Target)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Right", forCompletion: true);
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(MetaProperty)), forCompletion: true);
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[60] = false;
        }
        
        public void AddResultsForIdentifier(object use, CompletionSearchFlags operation, Binder parentBinder) // 61
        {
            if (_visited[61]) return;
            _visited[61] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateIdentifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	var IdentifierNormalBinder = binder;
            	AddBinder(IdentifierNormalBinder, (MetaSyntaxKind)MetaSyntaxKind.IdentifierNormal, operation);
            	var IdentifierVerbatimBinder = binder;
            	AddBinder(IdentifierVerbatimBinder, (MetaSyntaxKind)MetaSyntaxKind.IdentifierVerbatim, operation);
            	var IUriBinder = binder;
            	AddBinder(IUriBinder, (MetaSyntaxKind)MetaSyntaxKind.IUri, operation);
            	var IPrefixBinder = binder;
            	AddBinder(IPrefixBinder, (MetaSyntaxKind)MetaSyntaxKind.IPrefix, operation);
                use = FinishedUse;
            }
            _visited[61] = false;
        }
        
        public void AddResultsForLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 62
        {
            if (_visited[62]) return;
            _visited[62] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_Literal_NullLiteral)
            {
                var binder = ruleBinder;
                AddResultsForNullLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_BooleanLiteral)
            {
                var binder = ruleBinder;
                AddResultsForBooleanLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_IntegerLiteral)
            {
                var binder = ruleBinder;
                AddResultsForIntegerLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_DecimalLiteral)
            {
                var binder = ruleBinder;
                AddResultsForDecimalLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_ScientificLiteral)
            {
                var binder = ruleBinder;
                AddResultsForScientificLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_StringLiteral)
            {
                var binder = ruleBinder;
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
            }
            _visited[62] = false;
        }
        
        public void AddResultsForNullLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 63
        {
            if (_visited[63]) return;
            _visited[63] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.KNull, operation);
                use = FinishedUse;
            }
            _visited[63] = false;
        }
        
        public void AddResultsForBooleanLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 64
        {
            if (_visited[64]) return;
            _visited[64] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	var KTrueBinder = binder;
            	AddBinder(KTrueBinder, (MetaSyntaxKind)MetaSyntaxKind.KTrue, operation);
            	var KFalseBinder = binder;
            	AddBinder(KFalseBinder, (MetaSyntaxKind)MetaSyntaxKind.KFalse, operation);
                use = FinishedUse;
            }
            _visited[64] = false;
        }
        
        public void AddResultsForIntegerLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 65
        {
            if (_visited[65]) return;
            _visited[65] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.LInteger, operation);
                use = FinishedUse;
            }
            _visited[65] = false;
        }
        
        public void AddResultsForDecimalLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 66
        {
            if (_visited[66]) return;
            _visited[66] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.LDecimal, operation);
                use = FinishedUse;
            }
            _visited[66] = false;
        }
        
        public void AddResultsForScientificLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 67
        {
            if (_visited[67]) return;
            _visited[67] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.LScientific, operation);
                use = FinishedUse;
            }
            _visited[67] = false;
        }
        
        public void AddResultsForStringLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 68
        {
            if (_visited[68]) return;
            _visited[68] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (MetaSyntaxKind)MetaSyntaxKind.LRegularString, operation);
                use = FinishedUse;
            }
            _visited[68] = false;
        }
    }
}


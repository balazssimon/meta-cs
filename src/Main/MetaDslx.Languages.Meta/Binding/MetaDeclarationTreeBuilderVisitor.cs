// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Symbols;

using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.Languages.Meta.Binding
{
	public class MetaDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, IMetaSyntaxVisitor
	{
        protected MetaDeclarationTreeBuilderVisitor(MetaSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            MetaSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new MetaDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }

		public virtual void VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node)
		{
		}
		
		public virtual void VisitMain(MainSyntax node)
		{
			if (node.UsingNamespace != null)
			{
				foreach (var child in node.UsingNamespace)
				{
			        this.Visit(child);
				}
			}
			this.Visit(node.NamespaceDeclaration);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
			this.BeginQualifier(node);
			try
			{
				if (node.Identifier != null)
				{
					foreach (var child in node.Identifier)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndQualifier();
			}
		}
		
		public virtual void VisitAttribute(AttributeSyntax node)
		{
			this.BeginProperty(node, name: "Attributes");
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitUsingNamespace(UsingNamespaceSyntax node)
		{
			this.BeginImport(node);
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndImport();
			}
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaNamespace), nestingProperty: "Declarations", merge: true);
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.UsingNamespace != null)
				{
					foreach (var child in node.UsingNamespace)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.MetamodelDeclaration);
				if (node.Declaration != null)
				{
					foreach (var child in node.Declaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
			this.BeginProperty(node, name: "DefinedMetaModel");
			try
			{
				this.BeginSymbolDef(node, type: typeof(MetaModel));
				try
				{
					if (node.Attribute != null)
					{
						foreach (var child in node.Attribute)
						{
					        this.Visit(child);
						}
					}
					this.Visit(node.Name);
					this.Visit(node.MetamodelPropertyList);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
			if (node.MetamodelProperty != null)
			{
				foreach (var child in node.MetamodelProperty)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
			this.Visit(node.MetamodelUriProperty);
			this.Visit(node.MetamodelPrefixProperty);
		}
		
		public virtual void VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
			this.BeginProperty(node, name: "Uri");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node)
		{
			this.BeginProperty(node, name: "Prefix");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.Visit(node.EnumDeclaration);
				this.Visit(node.ClassDeclaration);
				this.Visit(node.AssociationDeclaration);
				this.Visit(node.ConstDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaEnum));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Name);
				this.Visit(node.EnumBody);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
			this.BeginScope(node);
			try
			{
				this.BeginProperty(node.EnumValues, name: "EnumLiterals");
				try
				{
					this.Visit(node.EnumValues);
				}
				finally
				{
					this.EndProperty();
				}
				if (node.EnumMemberDeclaration != null)
				{
					foreach (var child in node.EnumMemberDeclaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitEnumValues(EnumValuesSyntax node)
		{
			if (node.EnumValue != null)
			{
				foreach (var child in node.EnumValue)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitEnumValue(EnumValueSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaEnumLiteral));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			this.BeginProperty(node.OperationDeclaration, name: "Operations");
			try
			{
				this.Visit(node.OperationDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaClass));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				switch (node.KAbstract.GetKind().Switch())
				{
					default:
						break;
				}
				this.Visit(node.Name);
				this.BeginProperty(node.ClassAncestors, name: "SuperClasses");
				try
				{
					this.Visit(node.ClassAncestors);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.ClassBody);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitClassBody(ClassBodySyntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.ClassMemberDeclaration != null)
				{
					foreach (var child in node.ClassMemberDeclaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitClassAncestors(ClassAncestorsSyntax node)
		{
			if (node.ClassAncestor != null)
			{
				foreach (var child in node.ClassAncestor)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitClassAncestor(ClassAncestorSyntax node)
		{
			this.BeginSymbolUse(node.Qualifier, types: ImmutableArray.Create(typeof(MetaClass)));
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			this.BeginProperty(node.FieldDeclaration, name: "Properties");
			try
			{
				this.Visit(node.FieldDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
			this.BeginProperty(node.OperationDeclaration, name: "Operations");
			try
			{
				this.Visit(node.OperationDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaProperty));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.FieldContainment);
				this.Visit(node.FieldModifier);
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
				this.Visit(node.DefaultValue);
				if (node.RedefinitionsOrSubsettings != null)
				{
					foreach (var child in node.RedefinitionsOrSubsettings)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitFieldContainment(FieldContainmentSyntax node)
		{
			this.BeginProperty(node, name: "IsContainment", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitFieldModifier(FieldModifierSyntax node)
		{
			this.BeginProperty(node, name: "Kind");
			try
			{
				switch (node.FieldModifier.GetKind().Switch())
				{
					case MetaSyntaxKind.KReadonly:
						break;
					case MetaSyntaxKind.KLazy:
						break;
					case MetaSyntaxKind.KDerived:
						break;
					case MetaSyntaxKind.KUnion:
						break;
					default:
						break;
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitDefaultValue(DefaultValueSyntax node)
		{
			this.BeginProperty(node, name: "DefaultValue");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
			this.Visit(node.Redefinitions);
			this.Visit(node.Subsettings);
		}
		
		public virtual void VisitRedefinitions(RedefinitionsSyntax node)
		{
			this.BeginProperty(node.NameUseList, name: "RedefinedProperties");
			try
			{
				this.Visit(node.NameUseList);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSubsettings(SubsettingsSyntax node)
		{
			this.BeginProperty(node.NameUseList, name: "SubsettedProperties");
			try
			{
				this.Visit(node.NameUseList);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNameUseList(NameUseListSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(MetaProperty)));
			try
			{
				if (node.Qualifier != null)
				{
					foreach (var child in node.Qualifier)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitConstDeclaration(ConstDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaConstant));
			try
			{
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
				this.Visit(node.ConstValue);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitConstValue(ConstValueSyntax node)
		{
			this.BeginProperty(node, name: "DotNetName");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
				this.Visit(node.TypeReference);
				this.Visit(node.VoidType);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
				this.Visit(node.TypeReference);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
				this.Visit(node.CollectionType);
				this.Visit(node.SimpleType);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
				this.Visit(node.PrimitiveType);
				this.Visit(node.ObjectType);
				this.Visit(node.NullableType);
				this.Visit(node.ClassType);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitClassType(ClassTypeSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(MetaClass), typeof(MetaEnum), typeof(MetaConstant)));
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaNullableType));
			try
			{
				this.BeginProperty(node.PrimitiveType, name: "InnerType");
				try
				{
					this.Visit(node.PrimitiveType);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitCollectionType(CollectionTypeSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaCollectionType));
			try
			{
				this.BeginProperty(node.CollectionKind, name: "Kind");
				try
				{
					this.Visit(node.CollectionKind);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.SimpleType, name: "InnerType");
				try
				{
					this.Visit(node.SimpleType);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitCollectionKind(CollectionKindSyntax node)
		{
			switch (node.CollectionKind.GetKind().Switch())
			{
				case MetaSyntaxKind.KSet:
					break;
				case MetaSyntaxKind.KList:
					break;
				case MetaSyntaxKind.KMultiSet:
					break;
				case MetaSyntaxKind.KMultiList:
					break;
				default:
					break;
			}
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaOperation));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				if (node.OperationModifier != null)
				{
					foreach (var child in node.OperationModifier)
					{
				        this.Visit(child);
					}
				}
				this.BeginProperty(node.ReturnType, name: "ReturnType");
				try
				{
					this.Visit(node.ReturnType);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
				this.BeginProperty(node.ParameterList, name: "Parameters");
				try
				{
					this.Visit(node.ParameterList);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitOperationModifier(OperationModifierSyntax node)
		{
			this.Visit(node.OperationModifierBuilder);
			this.Visit(node.OperationModifierReadonly);
		}
		
		public virtual void VisitOperationModifierBuilder(OperationModifierBuilderSyntax node)
		{
			this.BeginProperty(node, name: "IsBuilder", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitOperationModifierReadonly(OperationModifierReadonlySyntax node)
		{
			this.BeginProperty(node, name: "IsReadonly", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitParameterList(ParameterListSyntax node)
		{
			if (node.Parameter != null)
			{
				foreach (var child in node.Parameter)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(MetaParameter));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
			if (node.Attribute != null)
			{
				foreach (var child in node.Attribute)
				{
			        this.Visit(child);
				}
			}
			this.BeginSymbolUse(node.Source, types: ImmutableArray.Create(typeof(MetaProperty)));
			try
			{
				this.Visit(node.Source);
			}
			finally
			{
				this.EndSymbolUse();
			}
			this.BeginSymbolUse(node.Target, types: ImmutableArray.Create(typeof(MetaProperty)));
			try
			{
				this.Visit(node.Target);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
			this.Visit(node.NullLiteral);
			this.Visit(node.BooleanLiteral);
			this.Visit(node.IntegerLiteral);
			this.Visit(node.DecimalLiteral);
			this.Visit(node.ScientificLiteral);
			this.Visit(node.StringLiteral);
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
		}
	}
}


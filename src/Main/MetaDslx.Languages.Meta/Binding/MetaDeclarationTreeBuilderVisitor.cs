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

using MetaDslx.CodeAnalysis.Symbols;
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


        protected virtual void BeginSymbolType(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndSymbolType(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void BeginSymbolProperty(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndSymbolProperty(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void BeginOpposite(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndOpposite(SyntaxNodeOrToken syntax)
        {
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
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName(node);
			try
			{
			}
			finally
			{
				this.EndName(node);
			}
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginName(node);
			try
			{
			}
			finally
			{
				this.EndName(node);
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
				this.EndQualifier(node);
			}
		}
		
		public virtual void VisitAttribute(AttributeSyntax node)
		{
			this.BeginProperty(node, name: "Attributes");
			try
			{
				this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaAttribute)));
				try
				{
				}
				finally
				{
					this.EndUse(node, types: ImmutableArray.Create(typeof(MetaAttribute)));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Attributes");
			}
		}
		
		public virtual void VisitUsingNamespace(UsingNamespaceSyntax node)
		{
			this.BeginImport(node);
			try
			{
			}
			finally
			{
				this.EndImport(node);
			}
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaNamespace), nestingProperty: "Declarations", merge: true);
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaNamespace), nestingProperty: "Declarations", merge: true);
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
				this.EndScope(node);
			}
		}
		
		public virtual void VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
			this.BeginProperty(node, name: "DefinedMetaModel");
			try
			{
				this.BeginDefine(node, type: typeof(MetaModel));
				try
				{
					this.BeginDocumentation(node);
					try
					{
						if (node.Attribute != null)
						{
							foreach (var child in node.Attribute)
							{
						        this.Visit(child);
							}
						}
					}
					finally
					{
						this.EndDocumentation(node);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(MetaModel));
				}
			}
			finally
			{
				this.EndProperty(node, name: "DefinedMetaModel");
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
		}
		
		public virtual void VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
			this.BeginProperty(node, name: "Uri");
			try
			{
				this.BeginValue(node.StringLiteral);
				try
				{
				}
				finally
				{
					this.EndValue(node.StringLiteral);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Uri");
			}
		}
		
		public virtual void VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node)
		{
			this.BeginProperty(node, name: "Prefix");
			try
			{
				this.BeginValue(node.StringLiteral);
				try
				{
				}
				finally
				{
					this.EndValue(node.StringLiteral);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Prefix");
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
			}
			finally
			{
				this.EndProperty(node, name: "Declarations");
			}
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaEnum));
			try
			{
				this.BeginDocumentation(node);
				try
				{
					if (node.Attribute != null)
					{
						foreach (var child in node.Attribute)
						{
					        this.Visit(child);
						}
					}
				}
				finally
				{
					this.EndDocumentation(node);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaEnum));
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
				}
				finally
				{
					this.EndProperty(node.EnumValues, name: "EnumLiterals");
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
				this.EndScope(node);
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
			this.BeginDefine(node, type: typeof(MetaEnumLiteral));
			try
			{
				this.BeginDocumentation(node);
				try
				{
					if (node.Attribute != null)
					{
						foreach (var child in node.Attribute)
						{
					        this.Visit(child);
						}
					}
				}
				finally
				{
					this.EndDocumentation(node);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaEnumLiteral));
			}
		}
		
		public virtual void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			this.BeginProperty(node.OperationDeclaration, name: "Operations");
			try
			{
			}
			finally
			{
				this.EndProperty(node.OperationDeclaration, name: "Operations");
			}
		}
		
		public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaClass));
			try
			{
				this.BeginDocumentation(node);
				try
				{
					if (node.Attribute != null)
					{
						foreach (var child in node.Attribute)
						{
					        this.Visit(child);
						}
					}
					this.BeginProperty(node.KAbstract, name: "IsAbstract", value: true);
					try
					{
					}
					finally
					{
						this.EndProperty(node.KAbstract, name: "IsAbstract", value: true);
					}
					this.BeginProperty(node.ClassAncestors, name: "SuperClasses");
					try
					{
					}
					finally
					{
						this.EndProperty(node.ClassAncestors, name: "SuperClasses");
					}
				}
				finally
				{
					this.EndDocumentation(node);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaClass));
			}
		}
		
		public virtual void VisitSymbolTypeAttribute(SymbolTypeAttributeSyntax node)
		{
			this.BeginProperty(node, name: "SymbolType");
			try
			{
				this.BeginSymbolType(node);
				try
				{
				}
				finally
				{
					this.EndSymbolType(node);
				}
			}
			finally
			{
				this.EndProperty(node, name: "SymbolType");
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
				this.EndScope(node);
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
			this.BeginUse(node.Qualifier, types: ImmutableArray.Create(typeof(MetaClass)));
			try
			{
			}
			finally
			{
				this.EndUse(node.Qualifier, types: ImmutableArray.Create(typeof(MetaClass)));
			}
		}
		
		public virtual void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			this.BeginProperty(node.FieldDeclaration, name: "Properties");
			try
			{
			}
			finally
			{
				this.EndProperty(node.FieldDeclaration, name: "Properties");
			}
			this.BeginProperty(node.OperationDeclaration, name: "Operations");
			try
			{
			}
			finally
			{
				this.EndProperty(node.OperationDeclaration, name: "Operations");
			}
		}
		
		public virtual void VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaProperty));
			try
			{
				this.BeginDocumentation(node);
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
					}
					finally
					{
						this.EndProperty(node.TypeReference, name: "Type");
					}
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
					this.EndDocumentation(node);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaProperty));
			}
		}
		
		public virtual void VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node)
		{
			this.BeginProperty(node, name: "SymbolProperty");
			try
			{
				this.BeginSymbolProperty(node.Identifier);
				try
				{
				}
				finally
				{
					this.EndSymbolProperty(node.Identifier);
				}
			}
			finally
			{
				this.EndProperty(node, name: "SymbolProperty");
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
				this.EndProperty(node, name: "IsContainment", value: true);
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
						this.BeginValue(node.FieldModifier, value: MetaPropertyKind.Readonly);
						try
						{
						}
						finally
						{
							this.EndValue(node.FieldModifier, value: MetaPropertyKind.Readonly);
						}
						break;
					case MetaSyntaxKind.KLazy:
						this.BeginValue(node.FieldModifier, value: MetaPropertyKind.Lazy);
						try
						{
						}
						finally
						{
							this.EndValue(node.FieldModifier, value: MetaPropertyKind.Lazy);
						}
						break;
					case MetaSyntaxKind.KDerived:
						this.BeginValue(node.FieldModifier, value: MetaPropertyKind.Derived);
						try
						{
						}
						finally
						{
							this.EndValue(node.FieldModifier, value: MetaPropertyKind.Derived);
						}
						break;
					case MetaSyntaxKind.KUnion:
						this.BeginValue(node.FieldModifier, value: MetaPropertyKind.DerivedUnion);
						try
						{
						}
						finally
						{
							this.EndValue(node.FieldModifier, value: MetaPropertyKind.DerivedUnion);
						}
						break;
					default:
						break;
				}
			}
			finally
			{
				this.EndProperty(node, name: "Kind");
			}
		}
		
		public virtual void VisitDefaultValue(DefaultValueSyntax node)
		{
			this.BeginProperty(node, name: "DefaultValue");
			try
			{
				this.BeginValue(node.StringLiteral);
				try
				{
				}
				finally
				{
					this.EndValue(node.StringLiteral);
				}
			}
			finally
			{
				this.EndProperty(node, name: "DefaultValue");
			}
		}
		
		public virtual void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
		}
		
		public virtual void VisitRedefinitions(RedefinitionsSyntax node)
		{
			this.BeginProperty(node.NameUseList, name: "RedefinedProperties");
			try
			{
			}
			finally
			{
				this.EndProperty(node.NameUseList, name: "RedefinedProperties");
			}
		}
		
		public virtual void VisitSubsettings(SubsettingsSyntax node)
		{
			this.BeginProperty(node.NameUseList, name: "SubsettedProperties");
			try
			{
			}
			finally
			{
				this.EndProperty(node.NameUseList, name: "SubsettedProperties");
			}
		}
		
		public virtual void VisitNameUseList(NameUseListSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaProperty)));
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
				this.EndUse(node, types: ImmutableArray.Create(typeof(MetaProperty)));
			}
		}
		
		public virtual void VisitConstDeclaration(ConstDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaConstant));
			try
			{
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
				}
				finally
				{
					this.EndProperty(node.TypeReference, name: "Type");
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaConstant));
			}
		}
		
		public virtual void VisitConstValue(ConstValueSyntax node)
		{
			this.BeginProperty(node, name: "DotNetName");
			try
			{
				this.BeginValue(node.StringLiteral);
				try
				{
				}
				finally
				{
					this.EndValue(node.StringLiteral);
				}
			}
			finally
			{
				this.EndProperty(node, name: "DotNetName");
			}
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			}
		}
		
		public virtual void VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			}
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			}
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			}
		}
		
		public virtual void VisitClassType(ClassTypeSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaClass), typeof(MetaEnum), typeof(MetaConstant)));
			try
			{
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(MetaClass), typeof(MetaEnum), typeof(MetaConstant)));
			}
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
			this.BeginIdentifier(node);
			try
			{
			}
			finally
			{
				this.EndIdentifier(node);
			}
		}
		
		public virtual void VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
			this.BeginIdentifier(node);
			try
			{
			}
			finally
			{
				this.EndIdentifier(node);
			}
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
			this.BeginIdentifier(node);
			try
			{
			}
			finally
			{
				this.EndIdentifier(node);
			}
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaNullableType));
			try
			{
				this.BeginProperty(node.PrimitiveType, name: "InnerType");
				try
				{
				}
				finally
				{
					this.EndProperty(node.PrimitiveType, name: "InnerType");
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaNullableType));
			}
		}
		
		public virtual void VisitCollectionType(CollectionTypeSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaCollectionType));
			try
			{
				this.BeginProperty(node.CollectionKind, name: "Kind");
				try
				{
				}
				finally
				{
					this.EndProperty(node.CollectionKind, name: "Kind");
				}
				this.BeginProperty(node.SimpleType, name: "InnerType");
				try
				{
				}
				finally
				{
					this.EndProperty(node.SimpleType, name: "InnerType");
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaCollectionType));
			}
		}
		
		public virtual void VisitCollectionKind(CollectionKindSyntax node)
		{
			switch (node.CollectionKind.GetKind().Switch())
			{
				case MetaSyntaxKind.KSet:
					this.BeginValue(node.CollectionKind, value: MetaCollectionKind.Set);
					try
					{
					}
					finally
					{
						this.EndValue(node.CollectionKind, value: MetaCollectionKind.Set);
					}
					break;
				case MetaSyntaxKind.KList:
					this.BeginValue(node.CollectionKind, value: MetaCollectionKind.List);
					try
					{
					}
					finally
					{
						this.EndValue(node.CollectionKind, value: MetaCollectionKind.List);
					}
					break;
				case MetaSyntaxKind.KMultiSet:
					this.BeginValue(node.CollectionKind, value: MetaCollectionKind.MultiSet);
					try
					{
					}
					finally
					{
						this.EndValue(node.CollectionKind, value: MetaCollectionKind.MultiSet);
					}
					break;
				case MetaSyntaxKind.KMultiList:
					this.BeginValue(node.CollectionKind, value: MetaCollectionKind.MultiList);
					try
					{
					}
					finally
					{
						this.EndValue(node.CollectionKind, value: MetaCollectionKind.MultiList);
					}
					break;
				default:
					break;
			}
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaOperation));
			try
			{
				this.BeginDocumentation(node);
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
					}
					finally
					{
						this.EndProperty(node.ReturnType, name: "ReturnType");
					}
					this.BeginProperty(node.ParameterList, name: "Parameters");
					try
					{
					}
					finally
					{
						this.EndProperty(node.ParameterList, name: "Parameters");
					}
				}
				finally
				{
					this.EndDocumentation(node);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaOperation));
			}
		}
		
		public virtual void VisitOperationModifier(OperationModifierSyntax node)
		{
		}
		
		public virtual void VisitOperationModifierBuilder(OperationModifierBuilderSyntax node)
		{
			this.BeginProperty(node, name: "IsBuilder", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty(node, name: "IsBuilder", value: true);
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
				this.EndProperty(node, name: "IsReadonly", value: true);
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
			this.BeginDefine(node, type: typeof(MetaParameter));
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
				}
				finally
				{
					this.EndProperty(node.TypeReference, name: "Type");
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaParameter));
			}
		}
		
		public virtual void VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
			this.BeginOpposite(node);
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.BeginUse(node.Source, types: ImmutableArray.Create(typeof(MetaProperty)));
				try
				{
				}
				finally
				{
					this.EndUse(node.Source, types: ImmutableArray.Create(typeof(MetaProperty)));
				}
				this.BeginUse(node.Target, types: ImmutableArray.Create(typeof(MetaProperty)));
				try
				{
				}
				finally
				{
					this.EndUse(node.Target, types: ImmutableArray.Create(typeof(MetaProperty)));
				}
			}
			finally
			{
				this.EndOpposite(node);
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			this.BeginIdentifier(node);
			try
			{
			}
			finally
			{
				this.EndIdentifier(node);
			}
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
	}
}


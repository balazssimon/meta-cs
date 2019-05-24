// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Languages.Meta.Syntax;

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
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.Visit(node.NamespaceDeclaration);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName();
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
			this.BeginName();
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
			this.BeginQualifier();
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
		
		public virtual void VisitAnnotation(AnnotationSyntax node)
		{
			this.BeginProperty("Annotations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.MetaAnnotation), node);
				try
				{
					this.BeginProperty("Name");
					try
					{
						this.Visit(node.Name);
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.MetaNamespace), node);
			try
			{
				this.RegisterNestingProperty("Declarations");
				this.RegisterCanMerge(true);
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
						this.Visit(child);
					}
				}
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.Visit(node.MetamodelDeclaration);
			if (node.Declaration != null)
			{
				foreach (var child in node.Declaration)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
			this.BeginProperty("MetaModel");
			try
			{
				this.BeginDeclaration(typeof(Symbols.MetaModel), node);
				try
				{
					if (node.Annotation != null)
					{
						foreach (var child in node.Annotation)
						{
							this.Visit(child);
						}
					}
					this.Visit(node.Name);
					this.Visit(node.MetamodelPropertyList);
				}
				finally
				{
					this.EndDeclaration();
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
		}
		
		public virtual void VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
			this.BeginProperty("Uri");
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.Visit(node.EnumDeclaration);
			this.Visit(node.ClassDeclaration);
			this.Visit(node.AssociationDeclaration);
			this.Visit(node.ConstDeclaration);
			this.Visit(node.ExternTypeDeclaration);
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.MetaEnum), node);
				try
				{
					if (node.Annotation != null)
					{
						foreach (var child in node.Annotation)
						{
							this.Visit(child);
						}
					}
					this.Visit(node.Name);
					this.Visit(node.EnumBody);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
			this.BeginProperty("EnumLiterals");
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
			this.BeginDeclaration(typeof(Symbols.MetaEnumLiteral), node);
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
						this.Visit(child);
					}
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			this.BeginProperty("Operations");
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
			this.BeginProperty("Declarations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.MetaClass), node);
				try
				{
					if (node.Annotation != null)
					{
						foreach (var child in node.Annotation)
						{
							this.Visit(child);
						}
					}
					if (node.KAbstract != null)
					{
						switch (node.KAbstract.GetKind().Switch())
						{
							default:
								break;
						}
					}
					this.Visit(node.Name);
					this.BeginProperty("SuperClasses");
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
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitClassBody(ClassBodySyntax node)
		{
			if (node.ClassMemberDeclaration != null)
			{
				foreach (var child in node.ClassMemberDeclaration)
				{
					this.Visit(child);
				}
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
		}
		
		public virtual void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			this.BeginProperty("Properties");
			try
			{
				this.Visit(node.FieldDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
			this.BeginProperty("Operations");
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
			this.BeginDeclaration(typeof(Symbols.MetaProperty), node);
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
						this.Visit(child);
					}
				}
				this.BeginProperty("Kind");
				try
				{
					this.Visit(node.FieldModifier);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty("Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
				this.Visit(node.RedefinitionsOrSubsettings);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitFieldModifier(FieldModifierSyntax node)
		{
			if (node.FieldModifier != null)
			{
				switch (node.FieldModifier.GetKind().Switch())
				{
					case MetaSyntaxKind.KContainment:
						break;
					case MetaSyntaxKind.KReadonly:
						break;
					case MetaSyntaxKind.KLazy:
						break;
					case MetaSyntaxKind.KDerived:
						break;
					default:
						break;
				}
			}
		}
		
		public virtual void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
			this.Visit(node.Redefinitions);
			this.Visit(node.Subsettings);
		}
		
		public virtual void VisitRedefinitions(RedefinitionsSyntax node)
		{
			this.BeginProperty("RedefinedProperties");
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
			this.BeginProperty("SubsettedProperties");
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
		}
		
		public virtual void VisitConstDeclaration(ConstDeclarationSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.MetaConstant), node);
				try
				{
					this.BeginProperty("Type");
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
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitExternTypeDeclaration(ExternTypeDeclarationSyntax node)
		{
			this.Visit(node.ExternClassTypeDeclaration);
			this.Visit(node.ExternStructTypeDeclaration);
		}
		
		public virtual void VisitExternClassTypeDeclaration(ExternClassTypeDeclarationSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.MetaExternalType), node);
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitExternStructTypeDeclaration(ExternStructTypeDeclarationSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.MetaExternalType), node);
				try
				{
					if (node.KStruct != null)
					{
						switch (node.KStruct.GetKind().Switch())
						{
							default:
								break;
						}
					}
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
		}
		
		public virtual void VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
		}
		
		public virtual void VisitClassType(ClassTypeSyntax node)
		{
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
			if (node.ObjectType != null)
			{
				switch (node.ObjectType.GetKind().Switch())
				{
					case MetaSyntaxKind.KObject:
						break;
					case MetaSyntaxKind.KSymbol:
						break;
					case MetaSyntaxKind.KString:
						break;
					default:
						break;
				}
			}
		}
		
		public virtual void VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
			if (node.PrimitiveType != null)
			{
				switch (node.PrimitiveType.GetKind().Switch())
				{
					case MetaSyntaxKind.KInt:
						break;
					case MetaSyntaxKind.KLong:
						break;
					case MetaSyntaxKind.KFloat:
						break;
					case MetaSyntaxKind.KDouble:
						break;
					case MetaSyntaxKind.KByte:
						break;
					case MetaSyntaxKind.KBool:
						break;
					default:
						break;
				}
			}
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
		}
		
		public virtual void VisitCollectionType(CollectionTypeSyntax node)
		{
		}
		
		public virtual void VisitCollectionKind(CollectionKindSyntax node)
		{
			if (node.CollectionKind != null)
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
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.MetaOperation), node);
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
						this.Visit(child);
					}
				}
				this.BeginProperty("ReturnType");
				try
				{
					this.Visit(node.ReturnType);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
				this.BeginProperty("Parameters");
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
				this.EndDeclaration();
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
			this.BeginDeclaration(typeof(Symbols.MetaParameter), node);
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
						this.Visit(child);
					}
				}
				this.BeginProperty("Type");
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
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
			if (node.Annotation != null)
			{
				foreach (var child in node.Annotation)
				{
					this.Visit(child);
				}
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


// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Symbols;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.Languages.Meta.Binding
{
	public class MetaDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, IMetaSyntaxVisitor
	{
        protected MetaDeclarationTreeBuilderVisitor(MetaSyntaxTree syntaxTree, SymbolFacts symbolFacts, string scriptClassName, bool isSubmission)
            : base(syntaxTree, symbolFacts, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            MetaSyntaxTree syntaxTree,
            SymbolFacts symbolFacts,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new MetaDeclarationTreeBuilderVisitor(syntaxTree, symbolFacts, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }


        protected virtual void BeginMetamodelImport(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndMetamodelImport(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void BeginSymbolSymbol(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndSymbolSymbol(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void BeginExpressionSymbol(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndExpressionSymbol(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void BeginStatementSymbol(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndStatementSymbol(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void BeginTypeSymbol(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndTypeSymbol(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void BeginSymbolProperty(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndSymbolProperty(SyntaxNodeOrToken syntax)
        {
        }

		public virtual void VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node)
		{
		}
		
		public virtual void VisitMain(MainSyntax node)
		{
			if (node.UsingNamespaceOrMetamodel != null)
			{
				foreach (var child in node.UsingNamespaceOrMetamodel)
				{
			        this.Visit(child);
				}
			}
			if (node.NamespaceDeclaration != null)
			{
			    this.Visit(node.NamespaceDeclaration);
			}
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName(node);
			try
			{
				if (node.Identifier != null)
				{
				    this.Visit(node.Identifier);
				}
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
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
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
					if (node.Qualifier != null)
					{
					    this.Visit(node.Qualifier);
					}
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
		
		public virtual void VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node)
		{
			if (node.UsingNamespace != null)
			{
			    this.Visit(node.UsingNamespace);
			}
			if (node.UsingMetamodel != null)
			{
			    this.Visit(node.UsingMetamodel);
			}
		}
		
		public virtual void VisitUsingNamespace(UsingNamespaceSyntax node)
		{
			this.BeginImport(node);
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndImport(node);
			}
		}
		
		public virtual void VisitUsingMetamodel(UsingMetamodelSyntax node)
		{
			this.BeginMetamodelImport(node);
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.UsingMetamodelReference != null)
				{
				    this.Visit(node.UsingMetamodelReference);
				}
			}
			finally
			{
				this.EndMetamodelImport(node);
			}
		}
		
		public virtual void VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax node)
		{
			if (node.Qualifier != null)
			{
			    this.Visit(node.Qualifier);
			}
			if (node.StringLiteral != null)
			{
			    this.BeginValue(node.StringLiteral);
			    try
			    {
			    	this.Visit(node.StringLiteral);
			    }
			    finally
			    {
			    	this.EndValue(node.StringLiteral);
			    }
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
				if (node.QualifiedName != null)
				{
				    this.Visit(node.QualifiedName);
				}
				if (node.NamespaceBody != null)
				{
				    this.Visit(node.NamespaceBody);
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
				if (node.UsingNamespaceOrMetamodel != null)
				{
					foreach (var child in node.UsingNamespaceOrMetamodel)
					{
				        this.Visit(child);
					}
				}
				if (node.MetamodelDeclaration != null)
				{
				    this.Visit(node.MetamodelDeclaration);
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
					this.BeginProperty(node, name: "Documentation");
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
							if (node.Name != null)
							{
							    this.Visit(node.Name);
							}
							if (node.MetamodelPropertyList != null)
							{
							    this.Visit(node.MetamodelPropertyList);
							}
						}
						finally
						{
							this.EndDocumentation(node);
						}
					}
					finally
					{
						this.EndProperty(node, name: "Documentation");
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
			if (node.MetamodelUriProperty != null)
			{
			    this.Visit(node.MetamodelUriProperty);
			}
			if (node.MetamodelPrefixProperty != null)
			{
			    this.Visit(node.MetamodelPrefixProperty);
			}
			if (node.MajorVersionProperty != null)
			{
			    this.Visit(node.MajorVersionProperty);
			}
			if (node.MinorVersionProperty != null)
			{
			    this.Visit(node.MinorVersionProperty);
			}
		}
		
		public virtual void VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
			this.BeginProperty(node, name: "Uri");
			try
			{
				if (node.StringLiteral != null)
				{
				    this.BeginValue(node.StringLiteral);
				    try
				    {
				    	this.Visit(node.StringLiteral);
				    }
				    finally
				    {
				    	this.EndValue(node.StringLiteral);
				    }
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
				if (node.StringLiteral != null)
				{
				    this.BeginValue(node.StringLiteral);
				    try
				    {
				    	this.Visit(node.StringLiteral);
				    }
				    finally
				    {
				    	this.EndValue(node.StringLiteral);
				    }
				}
			}
			finally
			{
				this.EndProperty(node, name: "Prefix");
			}
		}
		
		public virtual void VisitMajorVersionProperty(MajorVersionPropertySyntax node)
		{
			this.BeginProperty(node, name: "MajorVersion");
			try
			{
				if (node.IntegerLiteral != null)
				{
				    this.BeginValue(node.IntegerLiteral);
				    try
				    {
				    	this.Visit(node.IntegerLiteral);
				    }
				    finally
				    {
				    	this.EndValue(node.IntegerLiteral);
				    }
				}
			}
			finally
			{
				this.EndProperty(node, name: "MajorVersion");
			}
		}
		
		public virtual void VisitMinorVersionProperty(MinorVersionPropertySyntax node)
		{
			this.BeginProperty(node, name: "MinorVersion");
			try
			{
				if (node.IntegerLiteral != null)
				{
				    this.BeginValue(node.IntegerLiteral);
				    try
				    {
				    	this.Visit(node.IntegerLiteral);
				    }
				    finally
				    {
				    	this.EndValue(node.IntegerLiteral);
				    }
				}
			}
			finally
			{
				this.EndProperty(node, name: "MinorVersion");
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			if (node.EnumDeclaration != null)
			{
			    this.Visit(node.EnumDeclaration);
			}
			if (node.ClassDeclaration != null)
			{
			    this.Visit(node.ClassDeclaration);
			}
			if (node.AssociationDeclaration != null)
			{
			    this.Visit(node.AssociationDeclaration);
			}
			if (node.ConstDeclaration != null)
			{
			    this.Visit(node.ConstDeclaration);
			}
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginDefine(node, type: typeof(MetaEnum));
				try
				{
					this.BeginProperty(node, name: "Documentation");
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
							if (node.Name != null)
							{
							    this.Visit(node.Name);
							}
							if (node.EnumBody != null)
							{
							    this.Visit(node.EnumBody);
							}
						}
						finally
						{
							this.EndDocumentation(node);
						}
					}
					finally
					{
						this.EndProperty(node, name: "Documentation");
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(MetaEnum));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Declarations");
			}
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.EnumValues != null)
				{
				    this.BeginProperty(node.EnumValues, name: "EnumLiterals");
				    try
				    {
				    	this.Visit(node.EnumValues);
				    }
				    finally
				    {
				    	this.EndProperty(node.EnumValues, name: "EnumLiterals");
				    }
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
				this.BeginProperty(node, name: "Documentation");
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
						if (node.Name != null)
						{
						    this.Visit(node.Name);
						}
					}
					finally
					{
						this.EndDocumentation(node);
					}
				}
				finally
				{
					this.EndProperty(node, name: "Documentation");
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaEnumLiteral));
			}
		}
		
		public virtual void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			if (node.OperationDeclaration != null)
			{
			    this.BeginProperty(node.OperationDeclaration, name: "Operations");
			    try
			    {
			    	this.Visit(node.OperationDeclaration);
			    }
			    finally
			    {
			    	this.EndProperty(node.OperationDeclaration, name: "Operations");
			    }
			}
		}
		
		public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginDefine(node, type: typeof(MetaClass));
				try
				{
					this.BeginProperty(node, name: "Documentation");
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
							if (node.SymbolAttribute != null)
							{
							    this.Visit(node.SymbolAttribute);
							}
							if (node.KAbstract.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
							{
							    this.BeginProperty(node.KAbstract, name: "IsAbstract", value: true);
							    try
							    {
							    	this.Visit(node.KAbstract);
							    }
							    finally
							    {
							    	this.EndProperty(node.KAbstract, name: "IsAbstract", value: true);
							    }
							}
							if (node.Name != null)
							{
							    this.Visit(node.Name);
							}
							if (node.ClassAncestors != null)
							{
							    this.BeginProperty(node.ClassAncestors, name: "SuperClasses");
							    try
							    {
							    	this.Visit(node.ClassAncestors);
							    }
							    finally
							    {
							    	this.EndProperty(node.ClassAncestors, name: "SuperClasses");
							    }
							}
							if (node.ClassBody != null)
							{
							    this.Visit(node.ClassBody);
							}
						}
						finally
						{
							this.EndDocumentation(node);
						}
					}
					finally
					{
						this.EndProperty(node, name: "Documentation");
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(MetaClass));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Declarations");
			}
		}
		
		public virtual void VisitSymbolAttribute(SymbolAttributeSyntax node)
		{
			this.BeginProperty(node, name: "SymbolType");
			try
			{
				if (node.SymbolSymbolAttribute != null)
				{
				    this.Visit(node.SymbolSymbolAttribute);
				}
				if (node.ExpressionSymbolAttribute != null)
				{
				    this.Visit(node.ExpressionSymbolAttribute);
				}
				if (node.StatementSymbolTypeAttribute != null)
				{
				    this.Visit(node.StatementSymbolTypeAttribute);
				}
				if (node.TypeSymbolTypeAttribute != null)
				{
				    this.Visit(node.TypeSymbolTypeAttribute);
				}
			}
			finally
			{
				this.EndProperty(node, name: "SymbolType");
			}
		}
		
		public virtual void VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node)
		{
			this.BeginSymbolSymbol(node);
			try
			{
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndSymbolSymbol(node);
			}
		}
		
		public virtual void VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node)
		{
			this.BeginExpressionSymbol(node);
			try
			{
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndExpressionSymbol(node);
			}
		}
		
		public virtual void VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node)
		{
			this.BeginStatementSymbol(node);
			try
			{
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndStatementSymbol(node);
			}
		}
		
		public virtual void VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node)
		{
			this.BeginTypeSymbol(node);
			try
			{
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndTypeSymbol(node);
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
			if (node.Qualifier != null)
			{
			    this.BeginUse(node.Qualifier, types: ImmutableArray.Create(typeof(MetaClass)));
			    try
			    {
			    	this.Visit(node.Qualifier);
			    }
			    finally
			    {
			    	this.EndUse(node.Qualifier, types: ImmutableArray.Create(typeof(MetaClass)));
			    }
			}
		}
		
		public virtual void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			if (node.FieldDeclaration != null)
			{
			    this.BeginProperty(node.FieldDeclaration, name: "Properties");
			    try
			    {
			    	this.Visit(node.FieldDeclaration);
			    }
			    finally
			    {
			    	this.EndProperty(node.FieldDeclaration, name: "Properties");
			    }
			}
			if (node.OperationDeclaration != null)
			{
			    this.BeginProperty(node.OperationDeclaration, name: "Operations");
			    try
			    {
			    	this.Visit(node.OperationDeclaration);
			    }
			    finally
			    {
			    	this.EndProperty(node.OperationDeclaration, name: "Operations");
			    }
			}
		}
		
		public virtual void VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaProperty));
			try
			{
				this.BeginProperty(node, name: "Documentation");
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
						if (node.FieldSymbolPropertyAttribute != null)
						{
						    this.Visit(node.FieldSymbolPropertyAttribute);
						}
						if (node.FieldContainment != null)
						{
						    this.Visit(node.FieldContainment);
						}
						if (node.FieldModifier != null)
						{
						    this.Visit(node.FieldModifier);
						}
						if (node.TypeReference != null)
						{
						    this.BeginProperty(node.TypeReference, name: "Type");
						    try
						    {
						    	this.Visit(node.TypeReference);
						    }
						    finally
						    {
						    	this.EndProperty(node.TypeReference, name: "Type");
						    }
						}
						if (node.Name != null)
						{
						    this.Visit(node.Name);
						}
						if (node.DefaultValue != null)
						{
						    this.Visit(node.DefaultValue);
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
					this.EndProperty(node, name: "Documentation");
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
				if (node.Identifier != null)
				{
				    this.BeginSymbolProperty(node.Identifier);
				    try
				    {
				    	this.Visit(node.Identifier);
				    }
				    finally
				    {
				    	this.EndSymbolProperty(node.Identifier);
				    }
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
				if (node.FieldModifier != null)
				{
				    switch (node.FieldModifier.GetKind().Switch())
				    {
				    	case MetaSyntaxKind.KReadonly:
				    		this.BeginValue(node.FieldModifier, value: MetaPropertyKind.Readonly);
				    		try
				    		{
				    			this.Visit(node.FieldModifier);
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
				    			this.Visit(node.FieldModifier);
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
				    			this.Visit(node.FieldModifier);
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
				    			this.Visit(node.FieldModifier);
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
				if (node.StringLiteral != null)
				{
				    this.BeginValue(node.StringLiteral);
				    try
				    {
				    	this.Visit(node.StringLiteral);
				    }
				    finally
				    {
				    	this.EndValue(node.StringLiteral);
				    }
				}
			}
			finally
			{
				this.EndProperty(node, name: "DefaultValue");
			}
		}
		
		public virtual void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
			if (node.Redefinitions != null)
			{
			    this.Visit(node.Redefinitions);
			}
			if (node.Subsettings != null)
			{
			    this.Visit(node.Subsettings);
			}
		}
		
		public virtual void VisitRedefinitions(RedefinitionsSyntax node)
		{
			if (node.NameUseList != null)
			{
			    this.BeginProperty(node.NameUseList, name: "RedefinedProperties");
			    try
			    {
			    	this.Visit(node.NameUseList);
			    }
			    finally
			    {
			    	this.EndProperty(node.NameUseList, name: "RedefinedProperties");
			    }
			}
		}
		
		public virtual void VisitSubsettings(SubsettingsSyntax node)
		{
			if (node.NameUseList != null)
			{
			    this.BeginProperty(node.NameUseList, name: "SubsettedProperties");
			    try
			    {
			    	this.Visit(node.NameUseList);
			    }
			    finally
			    {
			    	this.EndProperty(node.NameUseList, name: "SubsettedProperties");
			    }
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
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginDefine(node, type: typeof(MetaConstant));
				try
				{
					if (node.TypeReference != null)
					{
					    this.BeginProperty(node.TypeReference, name: "Type");
					    try
					    {
					    	this.Visit(node.TypeReference);
					    }
					    finally
					    {
					    	this.EndProperty(node.TypeReference, name: "Type");
					    }
					}
					if (node.Name != null)
					{
					    this.Visit(node.Name);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(MetaConstant));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Declarations");
			}
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			try
			{
				if (node.TypeReference != null)
				{
				    this.Visit(node.TypeReference);
				}
				if (node.VoidType != null)
				{
				    this.Visit(node.VoidType);
				}
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
				if (node.TypeReference != null)
				{
				    this.Visit(node.TypeReference);
				}
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
				if (node.CollectionType != null)
				{
				    this.Visit(node.CollectionType);
				}
				if (node.SimpleType != null)
				{
				    this.Visit(node.SimpleType);
				}
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
				if (node.PrimitiveType != null)
				{
				    this.Visit(node.PrimitiveType);
				}
				if (node.ObjectType != null)
				{
				    this.Visit(node.ObjectType);
				}
				if (node.NullableType != null)
				{
				    this.Visit(node.NullableType);
				}
				if (node.ClassType != null)
				{
				    this.Visit(node.ClassType);
				}
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(MetaType)));
			}
		}
		
		public virtual void VisitClassType(ClassTypeSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(MetaClass), typeof(MetaEnum)));
			try
			{
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(MetaClass), typeof(MetaEnum)));
			}
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
			if (node.ObjectType != null)
			{
			    switch (node.ObjectType.GetKind().Switch())
			    {
			    	case MetaSyntaxKind.KObject:
			    		this.BeginValue(node.ObjectType, value: MetaInstance.Object);
			    		try
			    		{
			    			this.Visit(node.ObjectType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.ObjectType, value: MetaInstance.Object);
			    		}
			    		break;
			    	case MetaSyntaxKind.KSymbol:
			    		this.BeginValue(node.ObjectType, value: MetaInstance.ModelObject);
			    		try
			    		{
			    			this.Visit(node.ObjectType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.ObjectType, value: MetaInstance.ModelObject);
			    		}
			    		break;
			    	case MetaSyntaxKind.KString:
			    		this.BeginValue(node.ObjectType, value: MetaInstance.String);
			    		try
			    		{
			    			this.Visit(node.ObjectType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.ObjectType, value: MetaInstance.String);
			    		}
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
			    		this.BeginValue(node.PrimitiveType, value: MetaInstance.Int);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: MetaInstance.Int);
			    		}
			    		break;
			    	case MetaSyntaxKind.KLong:
			    		this.BeginValue(node.PrimitiveType, value: MetaInstance.Long);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: MetaInstance.Long);
			    		}
			    		break;
			    	case MetaSyntaxKind.KFloat:
			    		this.BeginValue(node.PrimitiveType, value: MetaInstance.Float);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: MetaInstance.Float);
			    		}
			    		break;
			    	case MetaSyntaxKind.KDouble:
			    		this.BeginValue(node.PrimitiveType, value: MetaInstance.Double);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: MetaInstance.Double);
			    		}
			    		break;
			    	case MetaSyntaxKind.KByte:
			    		this.BeginValue(node.PrimitiveType, value: MetaInstance.Byte);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: MetaInstance.Byte);
			    		}
			    		break;
			    	case MetaSyntaxKind.KBool:
			    		this.BeginValue(node.PrimitiveType, value: MetaInstance.Bool);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: MetaInstance.Bool);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
			if (node.KVoid.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
			{
			    this.BeginValue(node.KVoid, value: MetaInstance.Void);
			    try
			    {
			    	this.Visit(node.KVoid);
			    }
			    finally
			    {
			    	this.EndValue(node.KVoid, value: MetaInstance.Void);
			    }
			}
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaNullableType));
			try
			{
				if (node.PrimitiveType != null)
				{
				    this.BeginProperty(node.PrimitiveType, name: "InnerType");
				    try
				    {
				    	this.Visit(node.PrimitiveType);
				    }
				    finally
				    {
				    	this.EndProperty(node.PrimitiveType, name: "InnerType");
				    }
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
				if (node.CollectionKind != null)
				{
				    this.BeginProperty(node.CollectionKind, name: "Kind");
				    try
				    {
				    	this.Visit(node.CollectionKind);
				    }
				    finally
				    {
				    	this.EndProperty(node.CollectionKind, name: "Kind");
				    }
				}
				if (node.SimpleType != null)
				{
				    this.BeginProperty(node.SimpleType, name: "InnerType");
				    try
				    {
				    	this.Visit(node.SimpleType);
				    }
				    finally
				    {
				    	this.EndProperty(node.SimpleType, name: "InnerType");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaCollectionType));
			}
		}
		
		public virtual void VisitCollectionKind(CollectionKindSyntax node)
		{
			if (node.CollectionKind != null)
			{
			    switch (node.CollectionKind.GetKind().Switch())
			    {
			    	case MetaSyntaxKind.KSet:
			    		this.BeginValue(node.CollectionKind, value: MetaCollectionKind.Set);
			    		try
			    		{
			    			this.Visit(node.CollectionKind);
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
			    			this.Visit(node.CollectionKind);
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
			    			this.Visit(node.CollectionKind);
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
			    			this.Visit(node.CollectionKind);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CollectionKind, value: MetaCollectionKind.MultiList);
			    		}
			    		break;
			    	case MetaSyntaxKind.KEnumerable:
			    		this.BeginValue(node.CollectionKind, value: MetaCollectionKind.Enumerable);
			    		try
			    		{
			    			this.Visit(node.CollectionKind);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CollectionKind, value: MetaCollectionKind.Enumerable);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(MetaOperation));
			try
			{
				this.BeginProperty(node, name: "Documentation");
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
						if (node.ReturnType != null)
						{
						    this.BeginProperty(node.ReturnType, name: "ReturnType");
						    try
						    {
						    	this.Visit(node.ReturnType);
						    }
						    finally
						    {
						    	this.EndProperty(node.ReturnType, name: "ReturnType");
						    }
						}
						if (node.Name != null)
						{
						    this.Visit(node.Name);
						}
						if (node.ParameterList != null)
						{
						    this.BeginProperty(node.ParameterList, name: "Parameters");
						    try
						    {
						    	this.Visit(node.ParameterList);
						    }
						    finally
						    {
						    	this.EndProperty(node.ParameterList, name: "Parameters");
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
					this.EndProperty(node, name: "Documentation");
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaOperation));
			}
		}
		
		public virtual void VisitOperationModifier(OperationModifierSyntax node)
		{
			if (node.OperationModifierBuilder != null)
			{
			    this.Visit(node.OperationModifierBuilder);
			}
			if (node.OperationModifierReadonly != null)
			{
			    this.Visit(node.OperationModifierReadonly);
			}
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
				if (node.TypeReference != null)
				{
				    this.BeginProperty(node.TypeReference, name: "Type");
				    try
				    {
				    	this.Visit(node.TypeReference);
				    }
				    finally
				    {
				    	this.EndProperty(node.TypeReference, name: "Type");
				    }
				}
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(MetaParameter));
			}
		}
		
		public virtual void VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
			this.BeginSymbol(node, type: typeof(AssociationSymbol));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				if (node.Source != null)
				{
				    this.BeginProperty(node.Source, name: "Left");
				    try
				    {
				    	this.BeginUse(node.Source, types: ImmutableArray.Create(typeof(MetaProperty)));
				    	try
				    	{
				    		this.Visit(node.Source);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Source, types: ImmutableArray.Create(typeof(MetaProperty)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Source, name: "Left");
				    }
				}
				if (node.Target != null)
				{
				    this.BeginProperty(node.Target, name: "Right");
				    try
				    {
				    	this.BeginUse(node.Target, types: ImmutableArray.Create(typeof(MetaProperty)));
				    	try
				    	{
				    		this.Visit(node.Target);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Target, types: ImmutableArray.Create(typeof(MetaProperty)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Target, name: "Right");
				    }
				}
			}
			finally
			{
				this.EndSymbol(node, type: typeof(AssociationSymbol));
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
			if (node.NullLiteral != null)
			{
			    this.Visit(node.NullLiteral);
			}
			if (node.BooleanLiteral != null)
			{
			    this.Visit(node.BooleanLiteral);
			}
			if (node.IntegerLiteral != null)
			{
			    this.Visit(node.IntegerLiteral);
			}
			if (node.DecimalLiteral != null)
			{
			    this.Visit(node.DecimalLiteral);
			}
			if (node.ScientificLiteral != null)
			{
			    this.Visit(node.ScientificLiteral);
			}
			if (node.StringLiteral != null)
			{
			    this.Visit(node.StringLiteral);
			}
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


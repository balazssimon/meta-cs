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
    public class MetaBinderFactoryVisitor : BinderFactoryVisitor, IMetaSyntaxVisitor<Binder>
    {
		public static object UseStringLiteral = new object();
		public static object UseEnumValues = new object();
		public static object UseOperationDeclaration = new object();
		public static object UseKAbstract = new object();
		public static object UseClassAncestors = new object();
		public static object UseQualifier = new object();
		public static object UseFieldDeclaration = new object();
		public static object UseTypeReference = new object();
		public static object UseIdentifier = new object();
		public static object UseKReadonly = new object();
		public static object UseKLazy = new object();
		public static object UseKDerived = new object();
		public static object UseKUnion = new object();
		public static object UseNameUseList = new object();
		public static object UseKObject = new object();
		public static object UseKSymbol = new object();
		public static object UseKString = new object();
		public static object UseKInt = new object();
		public static object UseKLong = new object();
		public static object UseKFloat = new object();
		public static object UseKDouble = new object();
		public static object UseKByte = new object();
		public static object UseKBool = new object();
		public static object UseKVoid = new object();
		public static object UsePrimitiveType = new object();
		public static object UseCollectionKind = new object();
		public static object UseSimpleType = new object();
		public static object UseKSet = new object();
		public static object UseKList = new object();
		public static object UseKMultiSet = new object();
		public static object UseKMultiList = new object();
		public static object UseReturnType = new object();
		public static object UseParameterList = new object();
		public static object UseSource = new object();
		public static object UseTarget = new object();
		public static object UseUsingNamespace = new object();
		public static object UseNamespaceDeclaration = new object();
		public static object UseAttribute = new object();
		public static object UseQualifiedName = new object();
		public static object UseNamespaceBody = new object();
		public static object UseMetamodelDeclaration = new object();
		public static object UseName = new object();
		public static object UseMetamodelUriProperty = new object();
		public static object UseMetamodelPrefixProperty = new object();
		public static object UseEnumDeclaration = new object();
		public static object UseClassDeclaration = new object();
		public static object UseAssociationDeclaration = new object();
		public static object UseConstDeclaration = new object();
		public static object UseEnumBody = new object();
		public static object UseEnumValue = new object();
		public static object UseSymbolAttribute = new object();
		public static object Use = new object();
		public static object UseClassBody = new object();
		public static object UseSymbolSymbolAttribute = new object();
		public static object UseExpressionSymbolAttribute = new object();
		public static object UseStatementSymbolTypeAttribute = new object();
		public static object UseTypeSymbolTypeAttribute = new object();
		public static object UseFieldSymbolPropertyAttribute = new object();
		public static object UseFieldContainment = new object();
		public static object UseFieldModifier = new object();
		public static object UseDefaultValue = new object();
		public static object UseConstValue = new object();
		public static object UseCollectionType = new object();
		public static object UseNullableType = new object();
		public static object UseClassType = new object();
		public static object UseObjectType = new object();
		public static object UseOperationModifierBuilder = new object();
		public static object UseOperationModifierReadonly = new object();
		public static object UseParameter = new object();
		public static object UseNullLiteral = new object();
		public static object UseBooleanLiteral = new object();
		public static object UseIntegerLiteral = new object();
		public static object UseDecimalLiteral = new object();
		public static object UseScientificLiteral = new object();
		public static object UseDeclaration = new object();
		public static object UseMetamodelProperty = new object();
		public static object UseEnumMemberDeclaration = new object();
		public static object UseClassMemberDeclaration = new object();
		public static object UseClassAncestor = new object();
		public static object UseRedefinitions = new object();
		public static object UseSubsettings = new object();
		public static object UseVoidType = new object();
		public static object UseOperationModifier = new object();
		public static object UseMetamodelPropertyList = new object();
		public static object UseRedefinitionsOrSubsettings = new object();

        public MetaBinderFactoryVisitor(MetaBinderFactory binderFactory)
			: base(binderFactory)
        {

        }

		public new MetaBinderFactory BinderFactory => (MetaBinderFactory)base.BinderFactory;

        public Binder VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax parent)
        {
            return null;
        }

		
		public Binder VisitMain(MainSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
			    return this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
			    resultBinder = this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitName(NameSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateNameBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifiedName(QualifiedNameSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateNameBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifier(QualifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateQualifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitAttribute(AttributeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Attributes");
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaAttribute)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitUsingNamespace(UsingNamespaceSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateImportBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceDeclaration(NamespaceDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaNamespace), nestingProperty: "Declarations", merge: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceBody(NamespaceBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelDeclaration(MetamodelDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "DefinedMetaModel");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaModel));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Documentation");
				resultBinder = this.BinderFactory.CreateDocumentationBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelPropertyList(MetamodelPropertyListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelProperty(MetamodelPropertySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelUriProperty(MetamodelUriPropertySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.StringLiteral)) use = UseStringLiteral;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Uri");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.StringLiteral);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.StringLiteral)) use = UseStringLiteral;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Prefix");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.StringLiteral);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDeclaration(DeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumDeclaration(EnumDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaEnum));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Documentation");
				resultBinder = this.BinderFactory.CreateDocumentationBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumBody(EnumBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.EnumValues)) use = UseEnumValues;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseEnumValues)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.EnumValues, name: "EnumLiterals");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEnumValues(EnumValuesSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumValue(EnumValueSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaEnumLiteral));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Documentation");
				resultBinder = this.BinderFactory.CreateDocumentationBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.OperationDeclaration)) use = UseOperationDeclaration;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseOperationDeclaration)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.OperationDeclaration, name: "Operations");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitClassDeclaration(ClassDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KAbstract)) use = UseKAbstract;
				if (LookupPosition.IsInNode(this.Position, parent.ClassAncestors)) use = UseClassAncestors;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaClass));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Documentation");
				resultBinder = this.BinderFactory.CreateDocumentationBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKAbstract)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.KAbstract, name: "IsAbstract", value: true);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseClassAncestors)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.ClassAncestors, name: "SuperClasses");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSymbolAttribute(SymbolAttributeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "SymbolType");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateSymbolSymbolBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateExpressionSymbolBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateStatementSymbolBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateTypeSymbolBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassBody(ClassBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassAncestors(ClassAncestorsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassAncestor(ClassAncestorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Qualifier, types: ImmutableArray.Create(typeof(MetaClass)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitClassMemberDeclaration(ClassMemberDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.FieldDeclaration)) use = UseFieldDeclaration;
				if (LookupPosition.IsInNode(this.Position, parent.OperationDeclaration)) use = UseOperationDeclaration;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseFieldDeclaration)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.FieldDeclaration, name: "Properties");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseOperationDeclaration)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.OperationDeclaration, name: "Operations");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFieldDeclaration(FieldDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaProperty));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Documentation");
				resultBinder = this.BinderFactory.CreateDocumentationBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Identifier)) use = UseIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "SymbolProperty");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.BinderFactory.CreateSymbolPropertyBinder(resultBinder, parent.Identifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFieldContainment(FieldContainmentSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "IsContainment", value: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitFieldModifier(FieldModifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.FieldModifier)) use = UseFieldModifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Kind");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseFieldModifier)
				{
					switch (parent.FieldModifier.GetKind().Switch())
					{
						case MetaSyntaxKind.KReadonly:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.FieldModifier, value: MetaPropertyKind.Readonly);
							break;
						case MetaSyntaxKind.KLazy:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.FieldModifier, value: MetaPropertyKind.Lazy);
							break;
						case MetaSyntaxKind.KDerived:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.FieldModifier, value: MetaPropertyKind.Derived);
							break;
						case MetaSyntaxKind.KUnion:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.FieldModifier, value: MetaPropertyKind.DerivedUnion);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDefaultValue(DefaultValueSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.StringLiteral)) use = UseStringLiteral;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "DefaultValue");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.StringLiteral);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitRedefinitions(RedefinitionsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.NameUseList)) use = UseNameUseList;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseNameUseList)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.NameUseList, name: "RedefinedProperties");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSubsettings(SubsettingsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.NameUseList)) use = UseNameUseList;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseNameUseList)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.NameUseList, name: "SubsettedProperties");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNameUseList(NameUseListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaProperty)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitConstDeclaration(ConstDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaConstant));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitConstValue(ConstValueSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.StringLiteral)) use = UseStringLiteral;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "DotNetName");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.StringLiteral);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitReturnType(ReturnTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeOfReference(TypeOfReferenceSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeReference(TypeReferenceSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSimpleType(SimpleTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassType(ClassTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaClass), typeof(MetaEnum), typeof(MetaConstant)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitObjectType(ObjectTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ObjectType)) use = UseObjectType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseObjectType)
				{
					switch (parent.ObjectType.GetKind().Switch())
					{
						case MetaSyntaxKind.KObject:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.ObjectType, value: MetaInstance.Object);
							break;
						case MetaSyntaxKind.KSymbol:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.ObjectType, value: MetaInstance.ModelObject);
							break;
						case MetaSyntaxKind.KString:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.ObjectType, value: MetaInstance.String);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitPrimitiveType(PrimitiveTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PrimitiveType)) use = UsePrimitiveType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePrimitiveType)
				{
					switch (parent.PrimitiveType.GetKind().Switch())
					{
						case MetaSyntaxKind.KInt:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: MetaInstance.Int);
							break;
						case MetaSyntaxKind.KLong:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: MetaInstance.Long);
							break;
						case MetaSyntaxKind.KFloat:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: MetaInstance.Float);
							break;
						case MetaSyntaxKind.KDouble:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: MetaInstance.Double);
							break;
						case MetaSyntaxKind.KByte:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: MetaInstance.Byte);
							break;
						case MetaSyntaxKind.KBool:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: MetaInstance.Bool);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitVoidType(VoidTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KVoid)) use = UseKVoid;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKVoid)
				{
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.KVoid, value: MetaInstance.Void);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNullableType(NullableTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PrimitiveType)) use = UsePrimitiveType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaNullableType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePrimitiveType)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.PrimitiveType, name: "InnerType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCollectionType(CollectionTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.CollectionKind)) use = UseCollectionKind;
				if (LookupPosition.IsInNode(this.Position, parent.SimpleType)) use = UseSimpleType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaCollectionType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCollectionKind)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.CollectionKind, name: "Kind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseSimpleType)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.SimpleType, name: "InnerType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCollectionKind(CollectionKindSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.CollectionKind)) use = UseCollectionKind;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCollectionKind)
				{
					switch (parent.CollectionKind.GetKind().Switch())
					{
						case MetaSyntaxKind.KSet:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CollectionKind, value: MetaCollectionKind.Set);
							break;
						case MetaSyntaxKind.KList:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CollectionKind, value: MetaCollectionKind.List);
							break;
						case MetaSyntaxKind.KMultiSet:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CollectionKind, value: MetaCollectionKind.MultiSet);
							break;
						case MetaSyntaxKind.KMultiList:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CollectionKind, value: MetaCollectionKind.MultiList);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitOperationDeclaration(OperationDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ReturnType)) use = UseReturnType;
				if (LookupPosition.IsInNode(this.Position, parent.ParameterList)) use = UseParameterList;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaOperation));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Documentation");
				resultBinder = this.BinderFactory.CreateDocumentationBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseReturnType)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.ReturnType, name: "ReturnType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseParameterList)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.ParameterList, name: "Parameters");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitOperationModifier(OperationModifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitOperationModifierBuilder(OperationModifierBuilderSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "IsBuilder", value: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitOperationModifierReadonly(OperationModifierReadonlySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "IsReadonly", value: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParameterList(ParameterListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParameter(ParameterSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(MetaParameter));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAssociationDeclaration(AssociationDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Source)) use = UseSource;
				if (LookupPosition.IsInNode(this.Position, parent.Target)) use = UseTarget;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateSymbolBinder(resultBinder, parent, type: typeof(AssociationSymbol));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseSource)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Source, name: "Left");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Source, types: ImmutableArray.Create(typeof(MetaProperty)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTarget)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Target, name: "Right");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Target, types: ImmutableArray.Create(typeof(MetaProperty)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifier(IdentifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLiteral(LiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNullLiteral(NullLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBooleanLiteral(BooleanLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIntegerLiteral(IntegerLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDecimalLiteral(DecimalLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitScientificLiteral(ScientificLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStringLiteral(StringLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}


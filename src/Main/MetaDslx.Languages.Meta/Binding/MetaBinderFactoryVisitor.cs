// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
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
		public static object UseFieldModifier = new object();
		public static object UseTypeReference = new object();
		public static object UseKContainment = new object();
		public static object UseKReadonly = new object();
		public static object UseKLazy = new object();
		public static object UseKDerived = new object();
		public static object UseKUnion = new object();
		public static object UseNameUseList = new object();
		public static object UsePrimitiveType = new object();
		public static object UseCollectionKind = new object();
		public static object UseSimpleType = new object();
		public static object UseKSet = new object();
		public static object UseKList = new object();
		public static object UseKMultiSet = new object();
		public static object UseKMultiList = new object();
		public static object UseKBuilder = new object();
		public static object UseReturnType = new object();
		public static object UseParameterList = new object();
		public static object UseSource = new object();
		public static object UseTarget = new object();
		public static object UseNamespaceDeclaration = new object();
		public static object UseIdentifier = new object();
		public static object UseAttribute = new object();
		public static object UseQualifiedName = new object();
		public static object UseNamespaceBody = new object();
		public static object UseMetamodelDeclaration = new object();
		public static object UseDeclaration = new object();
		public static object UseName = new object();
		public static object UseMetamodelUriProperty = new object();
		public static object UseEnumDeclaration = new object();
		public static object UseClassDeclaration = new object();
		public static object UseAssociationDeclaration = new object();
		public static object UseConstDeclaration = new object();
		public static object UseEnumBody = new object();
		public static object UseEnumValue = new object();
		public static object Use = new object();
		public static object UseClassBody = new object();
		public static object UseDefaultValue = new object();
		public static object UseVoidType = new object();
		public static object UseCollectionType = new object();
		public static object UseObjectType = new object();
		public static object UseNullableType = new object();
		public static object UseClassType = new object();
		public static object UseParameter = new object();
		public static object UseNullLiteral = new object();
		public static object UseBooleanLiteral = new object();
		public static object UseIntegerLiteral = new object();
		public static object UseDecimalLiteral = new object();
		public static object UseScientificLiteral = new object();
		public static object UseMetamodelProperty = new object();
		public static object UseEnumMemberDeclaration = new object();
		public static object UseClassMemberDeclaration = new object();
		public static object UseClassAncestor = new object();
		public static object UseRedefinitions = new object();
		public static object UseSubsettings = new object();
		public static object UseMetamodelPropertyList = new object();
		public static object UseRedefinitionsOrSubsettings = new object();

        public MetaBinderFactoryVisitor(BinderFactory symbolBuilder)
			: base(symbolBuilder)
        {

        }

        protected virtual Binder CreateOppositeBinder(Binder parentBinder, LanguageSyntaxNode syntax)
        {
            return this.CreateOppositeBinderCore(parentBinder, syntax);
        }

        protected virtual Binder CreateOppositeBinderCore(Binder parentBinder, LanguageSyntaxNode syntax)
        {
            return new OppositeBinder(parentBinder, syntax);
        }

        /// <summary>
        /// Returns binder that binds usings and aliases 
        /// </summary>
        /// <param name="unit">
        /// Specify <see cref="LanguageSyntaxNode"/> imports in the corresponding syntax node, or
        /// <see cref="CompilationUnitSyntax"/> for top-level imports.
        /// </param>
        /// <param name="inUsing">True if the binder will be used to bind a using directive.</param>
        public override Binder GetImportsBinder(LanguageSyntaxNode unit, bool inUsing)
        {
            if (unit.Kind == MetaSyntaxKind.Main)
            {
                return this.GetCompilationUnitBinder(unit, inUsing: inUsing, inScript: InScript);
            }
            else
            {
                // TODO:MetaDslx - non-compilation-unit imports
                return null;
            }
        }

		
		public Binder VisitMain(MainSyntax parent)
		{
			return this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
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
				resultBinder = this.CreateNameBinder(resultBinder, parent);
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
				resultBinder = this.CreateNameBinder(resultBinder, parent);
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
				resultBinder = this.CreateQualifierBinder(resultBinder, parent);
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Attributes");
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaAttribute)));
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaNamespace), nestingProperty: "Declarations", merge: true);
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
				resultBinder = this.CreateScopeBinder(resultBinder, parent);
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "DefinedMetaModel");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaModel));
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Uri");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.CreateValueBinder(resultBinder, parent.StringLiteral);
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaEnum));
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
				resultBinder = this.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseEnumValues)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.EnumValues, name: "EnumLiterals");
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaEnumLiteral));
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
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OperationDeclaration, name: "Operations");
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaClass));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKAbstract)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.KAbstract, name: "IsAbstract", value: true);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseClassAncestors)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ClassAncestors, name: "SuperClasses");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
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
				resultBinder = this.CreateScopeBinder(resultBinder, parent);
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
					resultBinder = this.CreateSymbolUseBinder(resultBinder, parent.Qualifier, types: ImmutableArray.Create(typeof(MetaClass)));
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
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.FieldDeclaration, name: "Properties");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseOperationDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OperationDeclaration, name: "Operations");
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
				if (LookupPosition.IsInNode(this.Position, parent.FieldModifier)) use = UseFieldModifier;
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaProperty));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseFieldModifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.FieldModifier, name: "Kind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "DefaultValue");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.CreateValueBinder(resultBinder, parent.StringLiteral);
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
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.NameUseList, name: "RedefinedProperties");
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
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.NameUseList, name: "SubsettedProperties");
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaProperty)));
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaConstant));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaType)));
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaType)));
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaType)));
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaType)));
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(MetaClass), typeof(MetaEnum)));
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaNullableType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePrimitiveType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.PrimitiveType, name: "InnerType");
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaCollectionType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCollectionKind)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.CollectionKind, name: "Kind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseSimpleType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.SimpleType, name: "InnerType");
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
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
				if (LookupPosition.IsInNode(this.Position, parent.KBuilder)) use = UseKBuilder;
				if (LookupPosition.IsInNode(this.Position, parent.ReturnType)) use = UseReturnType;
				if (LookupPosition.IsInNode(this.Position, parent.ParameterList)) use = UseParameterList;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaOperation));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKBuilder)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.KBuilder, name: "IsBuilder", value: true);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseReturnType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ReturnType, name: "ReturnType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseParameterList)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ParameterList, name: "Parameters");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(MetaParameter));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
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
				resultBinder = this.CreateOppositeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseSource)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, parent.Source, types: ImmutableArray.Create(typeof(MetaProperty)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTarget)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, parent.Target, types: ImmutableArray.Create(typeof(MetaProperty)));
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
				resultBinder = this.CreateIdentifierBinder(resultBinder, parent);
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
				resultBinder = this.CreateValueBinder(resultBinder, parent);
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
				resultBinder = this.CreateValueBinder(resultBinder, parent);
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
				resultBinder = this.CreateValueBinder(resultBinder, parent);
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
				resultBinder = this.CreateValueBinder(resultBinder, parent);
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
				resultBinder = this.CreateValueBinder(resultBinder, parent);
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
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}


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
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaBinderFactoryVisitor : BinderFactoryVisitor, IMetaSyntaxVisitor<Binder>
    {
		public static object UseName = new object();
		public static object UseStringLiteral = new object();
		public static object UseEnumValues = new object();
		public static object UseOperationDeclaration = new object();
		public static object UseKAbstract = new object();
		public static object UseClassAncestors = new object();
		public static object UseQualifier = new object();
		public static object UseFieldDeclaration = new object();
		public static object UseFieldModifier = new object();
		public static object UseTypeReference = new object();
		public static object UseNameUseList = new object();
		public static object UseKStruct = new object();
		public static object UseObjectType = new object();
		public static object UsePrimitiveType = new object();
		public static object UseKVoid = new object();
		public static object UseCollectionKind = new object();
		public static object UseSimpleType = new object();
		public static object UseReturnType = new object();
		public static object UseParameterList = new object();
		public static object UseSource = new object();
		public static object UseTarget = new object();

        public MetaBinderFactoryVisitor(BinderFactory symbolBuilder)
			: base(symbolBuilder)
        {

        }

        protected virtual Binder CreateOppositeBinder(Binder parentBinder, LanguageSyntaxNode node)
        {
            return this.CreateOppositeBinderCore(parentBinder, node);
        }

        protected virtual Binder CreateOppositeBinderCore(Binder parentBinder, LanguageSyntaxNode node)
        {
            return new OppositeBinder(parentBinder, node);
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
            if (unit.Kind == Language.SyntaxFacts.CompilationUnitKind)
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
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateNameBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifiedName(QualifiedNameSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateNameBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifier(QualifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateQualifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitAnnotation(AnnotationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.Name)) use = UseName;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, "Annotations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaAnnotation));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseName)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Name, "Name");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceDeclaration(NamespaceDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaNamespace));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceBody(NamespaceBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelDeclaration(MetamodelDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, "MetaModel");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaModel));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelPropertyList(MetamodelPropertyListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelProperty(MetamodelPropertySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelUriProperty(MetamodelUriPropertySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.StringLiteral)) use = UseStringLiteral;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, "Uri");
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
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumDeclaration(EnumDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaEnum));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumBody(EnumBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.EnumValues)) use = UseEnumValues;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseEnumValues)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.EnumValues, "EnumLiterals");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEnumValues(EnumValuesSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumValue(EnumValueSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaEnumLiteral));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.OperationDeclaration)) use = UseOperationDeclaration;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseOperationDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OperationDeclaration, "Operations");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitClassDeclaration(ClassDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.KAbstract)) use = UseKAbstract;
			if (LookupPosition.IsInNode(this.Position, parent.ClassAncestors)) use = UseClassAncestors;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaClass));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKAbstract)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.KAbstract, "IsAbstract", true);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseClassAncestors)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ClassAncestors, "SuperClasses");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitClassBody(ClassBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassAncestors(ClassAncestorsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassAncestor(ClassAncestorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.Qualifier)) use = UseQualifier;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, parent.Qualifier, ImmutableArray.Create(typeof(Symbols.MetaClass)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitClassMemberDeclaration(ClassMemberDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.FieldDeclaration)) use = UseFieldDeclaration;
			if (LookupPosition.IsInNode(this.Position, parent.OperationDeclaration)) use = UseOperationDeclaration;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseFieldDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.FieldDeclaration, "Properties");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseOperationDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OperationDeclaration, "Operations");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFieldDeclaration(FieldDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.FieldModifier)) use = UseFieldModifier;
			if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaProperty));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseFieldModifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.FieldModifier, "Kind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFieldModifier(FieldModifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.FieldModifier)) use = UseFieldModifier;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseFieldModifier)
				{
					switch (parent.FieldModifier.GetKind().Switch())
					{
						case MetaSyntaxKind.KContainment:
							resultBinder = this.CreateValueBinder(resultBinder, parent.FieldModifier, MetaPropertyKind.Containment);
							break;
						case MetaSyntaxKind.KReadonly:
							resultBinder = this.CreateValueBinder(resultBinder, parent.FieldModifier, MetaPropertyKind.Readonly);
							break;
						case MetaSyntaxKind.KLazy:
							resultBinder = this.CreateValueBinder(resultBinder, parent.FieldModifier, MetaPropertyKind.Lazy);
							break;
						case MetaSyntaxKind.KDerived:
							resultBinder = this.CreateValueBinder(resultBinder, parent.FieldModifier, MetaPropertyKind.Derived);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitRedefinitions(RedefinitionsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.NameUseList)) use = UseNameUseList;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseNameUseList)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.NameUseList, "RedefinedProperties");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSubsettings(SubsettingsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.NameUseList)) use = UseNameUseList;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseNameUseList)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.NameUseList, "SubsettedProperties");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNameUseList(NameUseListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, ImmutableArray.Create(typeof(Symbols.MetaProperty)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitConstDeclaration(ConstDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaConstant));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitExternTypeDeclaration(ExternTypeDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitExternClassTypeDeclaration(ExternClassTypeDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.Qualifier)) use = UseQualifier;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaExternalType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Qualifier, "ExternalName");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Qualifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitExternStructTypeDeclaration(ExternStructTypeDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.KStruct)) use = UseKStruct;
			if (LookupPosition.IsInNode(this.Position, parent.Qualifier)) use = UseQualifier;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaExternalType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKStruct)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.KStruct, "IsValueType", true);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Qualifier, "ExternalName");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Qualifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitReturnType(ReturnTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, ImmutableArray.Create(typeof(Symbols.MetaType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeOfReference(TypeOfReferenceSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, ImmutableArray.Create(typeof(Symbols.MetaType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeReference(TypeReferenceSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, ImmutableArray.Create(typeof(Symbols.MetaType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSimpleType(SimpleTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, ImmutableArray.Create(typeof(Symbols.MetaType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassType(ClassTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, ImmutableArray<Type>.Empty);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitObjectType(ObjectTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.ObjectType)) use = UseObjectType;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseObjectType)
				{
					switch (parent.ObjectType.GetKind().Switch())
					{
						case MetaSyntaxKind.KObject:
							resultBinder = this.CreateValueBinder(resultBinder, parent.ObjectType, MetaInstance.Object);
							break;
						case MetaSyntaxKind.KSymbol:
							resultBinder = this.CreateValueBinder(resultBinder, parent.ObjectType, MetaInstance.Symbol);
							break;
						case MetaSyntaxKind.KString:
							resultBinder = this.CreateValueBinder(resultBinder, parent.ObjectType, MetaInstance.String);
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
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.PrimitiveType)) use = UsePrimitiveType;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePrimitiveType)
				{
					switch (parent.PrimitiveType.GetKind().Switch())
					{
						case MetaSyntaxKind.KInt:
							resultBinder = this.CreateValueBinder(resultBinder, parent.PrimitiveType, MetaInstance.Int);
							break;
						case MetaSyntaxKind.KLong:
							resultBinder = this.CreateValueBinder(resultBinder, parent.PrimitiveType, MetaInstance.Long);
							break;
						case MetaSyntaxKind.KFloat:
							resultBinder = this.CreateValueBinder(resultBinder, parent.PrimitiveType, MetaInstance.Float);
							break;
						case MetaSyntaxKind.KDouble:
							resultBinder = this.CreateValueBinder(resultBinder, parent.PrimitiveType, MetaInstance.Double);
							break;
						case MetaSyntaxKind.KByte:
							resultBinder = this.CreateValueBinder(resultBinder, parent.PrimitiveType, MetaInstance.Byte);
							break;
						case MetaSyntaxKind.KBool:
							resultBinder = this.CreateValueBinder(resultBinder, parent.PrimitiveType, MetaInstance.Bool);
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
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.KVoid)) use = UseKVoid;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKVoid)
				{
					resultBinder = this.CreateValueBinder(resultBinder, parent.KVoid, MetaInstance.Void);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNullableType(NullableTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.PrimitiveType)) use = UsePrimitiveType;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, parent, typeof(Symbols.MetaNullableType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePrimitiveType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.PrimitiveType, "InnerType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCollectionType(CollectionTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.CollectionKind)) use = UseCollectionKind;
			if (LookupPosition.IsInNode(this.Position, parent.SimpleType)) use = UseSimpleType;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, parent, typeof(Symbols.MetaCollectionType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCollectionKind)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.CollectionKind, "Kind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseSimpleType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.SimpleType, "InnerType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCollectionKind(CollectionKindSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.CollectionKind)) use = UseCollectionKind;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCollectionKind)
				{
					switch (parent.CollectionKind.GetKind().Switch())
					{
						case MetaSyntaxKind.KSet:
							resultBinder = this.CreateValueBinder(resultBinder, parent.CollectionKind, MetaCollectionKind.Set);
							break;
						case MetaSyntaxKind.KList:
							resultBinder = this.CreateValueBinder(resultBinder, parent.CollectionKind, MetaCollectionKind.List);
							break;
						case MetaSyntaxKind.KMultiSet:
							resultBinder = this.CreateValueBinder(resultBinder, parent.CollectionKind, MetaCollectionKind.MultiSet);
							break;
						case MetaSyntaxKind.KMultiList:
							resultBinder = this.CreateValueBinder(resultBinder, parent.CollectionKind, MetaCollectionKind.MultiList);
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
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.ReturnType)) use = UseReturnType;
			if (LookupPosition.IsInNode(this.Position, parent.ParameterList)) use = UseParameterList;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaOperation));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseReturnType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ReturnType, "ReturnType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseParameterList)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ParameterList, "Parameters");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitParameterList(ParameterListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParameter(ParameterSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, typeof(Symbols.MetaParameter));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAssociationDeclaration(AssociationDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			if (LookupPosition.IsInNode(this.Position, parent.Source)) use = UseSource;
			if (LookupPosition.IsInNode(this.Position, parent.Target)) use = UseTarget;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateOppositeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseSource)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, parent.Source, ImmutableArray.Create(typeof(Symbols.MetaProperty)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTarget)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, parent.Target, ImmutableArray.Create(typeof(Symbols.MetaProperty)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifier(IdentifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLiteral(LiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNullLiteral(NullLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBooleanLiteral(BooleanLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIntegerLiteral(IntegerLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDecimalLiteral(DecimalLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitScientificLiteral(ScientificLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStringLiteral(StringLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitCore(parent.Parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitCore(parent.Parent);
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}


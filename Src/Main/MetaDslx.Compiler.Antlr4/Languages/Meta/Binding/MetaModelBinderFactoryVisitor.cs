// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Symbols;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaModelBinderFactoryVisitor : BinderFactoryVisitor, IMetaModelSyntaxVisitor<Binder>
    {
		public static object UseNamespaceDeclaration = new object();
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
		public static object UseObjectType = new object();
		public static object UsePrimitiveType = new object();
		public static object UseKVoid = new object();
		public static object UseCollectionKind = new object();
		public static object UseSimpleType = new object();
		public static object UseReturnType = new object();
		public static object UseParameterList = new object();
		public static object UseSource = new object();
		public static object UseTarget = new object();

        public MetaModelBinderFactoryVisitor(BinderFactory symbolBuilder)
			: base(symbolBuilder)
        {

        }

        protected virtual Binder CreateOppositeBinder(Binder parentBinder, RedNode node)
        {
            return this.CreateOppositeBinderCore(parentBinder, node);
        }

        protected virtual Binder CreateOppositeBinderCore(Binder parentBinder, RedNode node)
        {
            return new OppositeBinder(parentBinder, node);
        }
		
		public Binder VisitMain(MainSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration)) use = UseNamespaceDeclaration;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateRootBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseNamespaceDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.NamespaceDeclaration, "Symbols");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitName(NameSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateNameBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifiedName(QualifiedNameSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateNameBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifier(QualifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateQualifierBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitAnnotation(AnnotationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Name)) use = UseName;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Annotations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaAnnotation));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseName)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Name, "Name");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaNamespace));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateBodyBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "MetaModel");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaModel));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.StringLiteral)) use = UseStringLiteral;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Uri");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.CreateValueBinder(resultBinder, node.StringLiteral);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDeclaration(DeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaEnum));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumBody(EnumBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.EnumValues)) use = UseEnumValues;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateBodyBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseEnumValues)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.EnumValues, "EnumLiterals");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEnumValues(EnumValuesSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumValue(EnumValueSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaEnumLiteral));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration)) use = UseOperationDeclaration;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseOperationDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.OperationDeclaration, "Operations");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitClassDeclaration(ClassDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.KAbstract)) use = UseKAbstract;
				if (LookupPosition.IsInNode(this.Position, node.ClassAncestors)) use = UseClassAncestors;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaClass));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseKAbstract)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.KAbstract, "IsAbstract", true);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
				if (use == UseClassAncestors)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.ClassAncestors, "SuperClasses");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitClassBody(ClassBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateBodyBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassAncestors(ClassAncestorsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassAncestor(ClassAncestorSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.MetaClass)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.FieldDeclaration)) use = UseFieldDeclaration;
				if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration)) use = UseOperationDeclaration;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseFieldDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.FieldDeclaration, "Properties");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
				if (use == UseOperationDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.OperationDeclaration, "Operations");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.FieldModifier)) use = UseFieldModifier;
				if (LookupPosition.IsInNode(this.Position, node.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaProperty));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseFieldModifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.FieldModifier, "Kind");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFieldModifier(FieldModifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.FieldModifier)) use = UseFieldModifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseFieldModifier)
				{
					switch (((MetaModelSyntaxToken)node.FieldModifier).Kind)
					{
						case MetaModelSyntaxKind.KContainment:
							resultBinder = this.CreateValueBinder(resultBinder, node.FieldModifier, MetaPropertyKind.Containment);
							break;
						case MetaModelSyntaxKind.KReadonly:
							resultBinder = this.CreateValueBinder(resultBinder, node.FieldModifier, MetaPropertyKind.Readonly);
							break;
						case MetaModelSyntaxKind.KLazy:
							resultBinder = this.CreateValueBinder(resultBinder, node.FieldModifier, MetaPropertyKind.Lazy);
							break;
						case MetaModelSyntaxKind.KDerived:
							resultBinder = this.CreateValueBinder(resultBinder, node.FieldModifier, MetaPropertyKind.Derived);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitRedefinitions(RedefinitionsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.NameUseList)) use = UseNameUseList;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseNameUseList)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.NameUseList, "RedefinedProperties");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSubsettings(SubsettingsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.NameUseList)) use = UseNameUseList;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseNameUseList)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.NameUseList, "SubsettedProperties");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNameUseList(NameUseListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray.Create(typeof(Symbols.MetaProperty)));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitConstDeclaration(ConstDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaConstant));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitReturnType(ReturnTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray.Create(typeof(Symbols.MetaType)));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeReference(TypeReferenceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray.Create(typeof(Symbols.MetaType)));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSimpleType(SimpleTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray<Type>.Empty);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitClassType(ClassTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray.Create(typeof(Symbols.MetaClass)));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitObjectType(ObjectTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.ObjectType)) use = UseObjectType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseObjectType)
				{
					switch (((MetaModelSyntaxToken)node.ObjectType).Kind)
					{
						case MetaModelSyntaxKind.KObject:
							resultBinder = this.CreateValueBinder(resultBinder, node.ObjectType, MetaInstance.Object);
							break;
						case MetaModelSyntaxKind.KSymbol:
							resultBinder = this.CreateValueBinder(resultBinder, node.ObjectType, MetaInstance.Symbol);
							break;
						case MetaModelSyntaxKind.KString:
							resultBinder = this.CreateValueBinder(resultBinder, node.ObjectType, MetaInstance.String);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.PrimitiveType)) use = UsePrimitiveType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UsePrimitiveType)
				{
					switch (((MetaModelSyntaxToken)node.PrimitiveType).Kind)
					{
						case MetaModelSyntaxKind.KInt:
							resultBinder = this.CreateValueBinder(resultBinder, node.PrimitiveType, MetaInstance.Int);
							break;
						case MetaModelSyntaxKind.KLong:
							resultBinder = this.CreateValueBinder(resultBinder, node.PrimitiveType, MetaInstance.Long);
							break;
						case MetaModelSyntaxKind.KFloat:
							resultBinder = this.CreateValueBinder(resultBinder, node.PrimitiveType, MetaInstance.Float);
							break;
						case MetaModelSyntaxKind.KDouble:
							resultBinder = this.CreateValueBinder(resultBinder, node.PrimitiveType, MetaInstance.Double);
							break;
						case MetaModelSyntaxKind.KByte:
							resultBinder = this.CreateValueBinder(resultBinder, node.PrimitiveType, MetaInstance.Byte);
							break;
						case MetaModelSyntaxKind.KBool:
							resultBinder = this.CreateValueBinder(resultBinder, node.PrimitiveType, MetaInstance.Bool);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitVoidType(VoidTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.KVoid)) use = UseKVoid;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseKVoid)
				{
					resultBinder = this.CreateValueBinder(resultBinder, node.KVoid, MetaInstance.Void);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNullableType(NullableTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.PrimitiveType)) use = UsePrimitiveType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, node, typeof(Symbols.MetaNullableType));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UsePrimitiveType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.PrimitiveType, "InnerType");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCollectionType(CollectionTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.CollectionKind)) use = UseCollectionKind;
				if (LookupPosition.IsInNode(this.Position, node.SimpleType)) use = UseSimpleType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, node, typeof(Symbols.MetaCollectionType));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseCollectionKind)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.CollectionKind, "Kind");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
				if (use == UseSimpleType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.SimpleType, "InnerType");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCollectionKind(CollectionKindSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.CollectionKind)) use = UseCollectionKind;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseCollectionKind)
				{
					switch (((MetaModelSyntaxToken)node.CollectionKind).Kind)
					{
						case MetaModelSyntaxKind.KSet:
							resultBinder = this.CreateValueBinder(resultBinder, node.CollectionKind, MetaCollectionKind.Set);
							break;
						case MetaModelSyntaxKind.KList:
							resultBinder = this.CreateValueBinder(resultBinder, node.CollectionKind, MetaCollectionKind.List);
							break;
						case MetaModelSyntaxKind.KMultiSet:
							resultBinder = this.CreateValueBinder(resultBinder, node.CollectionKind, MetaCollectionKind.MultiSet);
							break;
						case MetaModelSyntaxKind.KMultiList:
							resultBinder = this.CreateValueBinder(resultBinder, node.CollectionKind, MetaCollectionKind.MultiList);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.ReturnType)) use = UseReturnType;
				if (LookupPosition.IsInNode(this.Position, node.ParameterList)) use = UseParameterList;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaOperation));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseReturnType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.ReturnType, "ReturnType");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
				if (use == UseParameterList)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.ParameterList, "Parameters");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitParameterList(ParameterListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParameter(ParameterSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.MetaParameter));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Source)) use = UseSource;
				if (LookupPosition.IsInNode(this.Position, node.Target)) use = UseTarget;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateOppositeBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseSource)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Source, ImmutableArray.Create(typeof(Symbols.MetaProperty)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
				if (use == UseTarget)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Target, ImmutableArray.Create(typeof(Symbols.MetaProperty)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifier(IdentifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateIdentifierBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLiteral(LiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNullLiteral(NullLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateValueBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateValueBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateValueBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateValueBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateValueBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStringLiteral(StringLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateValueBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}


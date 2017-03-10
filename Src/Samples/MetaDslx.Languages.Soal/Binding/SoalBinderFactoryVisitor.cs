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
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Symbols;

namespace MetaDslx.Languages.Soal.Binding
{
    public class SoalBinderFactoryVisitor : BinderFactoryVisitor, ISoalSyntaxVisitor<Binder>
    {
		public static object UseNamespaceDeclaration = new object();
		public static object UseAnnotationPropertyValue = new object();
		public static object UseIdentifier = new object();
		public static object UseStringLiteral = new object();
		public static object UseQualifier = new object();
		public static object UseTypeReference = new object();
		public static object UseQualifierList = new object();
		public static object UseKAbstract = new object();
		public static object UseObjectType = new object();
		public static object UseValueType = new object();
		public static object UseOnewayType = new object();
		public static object UseReferenceType = new object();
		public static object UseArrayType = new object();
		public static object UseSimpleType = new object();
		public static object UseNulledType = new object();

        public SoalBinderFactoryVisitor(BinderFactory symbolBuilder)
			: base(symbolBuilder)
        {

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
				if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration.Node)) use = UseNamespaceDeclaration;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateRootBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseNamespaceDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.NamespaceDeclaration.Node, "Symbols");
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
		
		public Binder VisitIdentifierList(IdentifierListSyntax node)
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
		
		public Binder VisitQualifierList(QualifierListSyntax node)
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
		
		public Binder VisitAnnotationList(AnnotationListSyntax node)
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
		
		public Binder VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
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
		
		public Binder VisitAnnotation(AnnotationSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Annotations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Annotation));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitReturnAnnotation(ReturnAnnotationSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Annotations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Annotation));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitAnnotationHead(AnnotationHeadSyntax node)
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
		
		public Binder VisitAnnotationBody(AnnotationBodySyntax node)
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
		
		public Binder VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
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
		
		public Binder VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.AnnotationPropertyValue)) use = UseAnnotationPropertyValue;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Properties");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.AnnotationProperty));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseAnnotationPropertyValue)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.AnnotationPropertyValue, "Value");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
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
		
		public Binder VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Identifier)) use = UseIdentifier;
				if (LookupPosition.IsInNode(this.Position, node.StringLiteral)) use = UseStringLiteral;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Namespace));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Identifier, "Prefix");
					resultBinder = this.CreateValueBinder(resultBinder, node.Identifier);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
				if (use == UseStringLiteral)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.StringLiteral, "Uri");
					resultBinder = this.CreateValueBinder(resultBinder, node.StringLiteral);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Declarations");
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Enum));
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateBodyBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumLiterals(EnumLiteralsSyntax node)
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
		
		public Binder VisitEnumLiteral(EnumLiteralSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "EnumLiterals");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.EnumLiteral));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStructDeclaration(StructDeclarationSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Struct));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStructBody(StructBodySyntax node)
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
		
		public Binder VisitPropertyDeclaration(PropertyDeclarationSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Properties");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Property));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Database));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDatabaseBody(DatabaseBodySyntax node)
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
		
		public Binder VisitEntityReference(EntityReferenceSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Entities");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Struct)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Interface));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitInterfaceBody(InterfaceBodySyntax node)
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
		
		public Binder VisitOperationDeclaration(OperationDeclarationSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Operations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Operation));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitOperationHead(OperationHeadSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Parameters");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.InputParameter));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitOperationResult(OperationResultSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Result");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.OutputParameter));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitComponentDeclaration(ComponentDeclarationSyntax node)
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
				if (LookupPosition.IsInNode(this.Position, node.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Component));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseKAbstract)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.KAbstract, "IsAbstract", true);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "BaseComponent");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Component)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitComponentBody(ComponentBodySyntax node)
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
		
		public Binder VisitComponentElements(ComponentElementsSyntax node)
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
		
		public Binder VisitComponentElement(ComponentElementSyntax node)
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
		
		public Binder VisitComponentService(ComponentServiceSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Services");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Service));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Interface");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Interface)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitComponentReference(ComponentReferenceSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "References");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Reference));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Interface");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Interface)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
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
		
		public Binder VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
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
		
		public Binder VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
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
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Binding");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Binding)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitComponentProperty(ComponentPropertySyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Properties");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Property));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.TypeReference, "Type");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitComponentImplementation(ComponentImplementationSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Implementation");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Implementation));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitComponentLanguage(ComponentLanguageSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Language");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Language));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitCompositeDeclaration(CompositeDeclarationSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Composite));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitCompositeBody(CompositeBodySyntax node)
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
		
		public Binder VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Assembly));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitCompositeElements(CompositeElementsSyntax node)
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
		
		public Binder VisitCompositeElement(CompositeElementSyntax node)
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
		
		public Binder VisitCompositeComponent(CompositeComponentSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Components");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Component)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCompositeWire(CompositeWireSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Wires");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Wire));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitWireSource(WireSourceSyntax node)
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
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Source");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Port)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitWireTarget(WireTargetSyntax node)
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
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Target");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Port)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Deployment));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDeploymentBody(DeploymentBodySyntax node)
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
		
		public Binder VisitDeploymentElements(DeploymentElementsSyntax node)
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
		
		public Binder VisitDeploymentElement(DeploymentElementSyntax node)
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
		
		public Binder VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Environments");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Environment));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnvironmentBody(EnvironmentBodySyntax node)
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
		
		public Binder VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Runtime");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Runtime));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitRuntimeReference(RuntimeReferenceSyntax node)
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
		
		public Binder VisitAssemblyReference(AssemblyReferenceSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Assemblies");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Assembly)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDatabaseReference(DatabaseReferenceSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Databases");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Database)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitBindingDeclaration(BindingDeclarationSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Binding));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBindingBody(BindingBodySyntax node)
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
		
		public Binder VisitBindingLayers(BindingLayersSyntax node)
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
		
		public Binder VisitTransportLayer(TransportLayerSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Transport");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitHttpTransportLayer(HttpTransportLayerSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.HttpTransportBindingElement));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
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
		
		public Binder VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
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
		
		public Binder VisitRestTransportLayer(RestTransportLayerSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.RestTransportBindingElement));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
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
		
		public Binder VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
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
		
		public Binder VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.WebSocketTransportBindingElement));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
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
		
		public Binder VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
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
		
		public Binder VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
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
		
		public Binder VisitHttpSslProperty(HttpSslPropertySyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Ssl");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "ClientAuthentication");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEncodingLayer(EncodingLayerSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Encodings");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.SoapEncodingBindingElement));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
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
		
		public Binder VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
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
		
		public Binder VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.XmlEncodingBindingElement));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
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
		
		public Binder VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
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
		
		public Binder VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.JsonEncodingBindingElement));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
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
		
		public Binder VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
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
		
		public Binder VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
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
		
		public Binder VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Identifier)) use = UseIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Version");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.CreateEnumValueBinder(resultBinder, node.Identifier, typeof(Symbols.SoapVersion));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSoapMtomProperty(SoapMtomPropertySyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Mtom");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Identifier)) use = UseIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Style");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.CreateEnumValueBinder(resultBinder, node.Identifier, typeof(Symbols.SoapEncodingStyle));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitProtocolLayer(ProtocolLayerSyntax node)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Protocols");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
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
		
		public Binder VisitWsAddressing(WsAddressingSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.WsAddressingBindingElement));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEndpointDeclaration(EndpointDeclarationSyntax node)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Endpoint));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Interface");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Interface)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEndpointBody(EndpointBodySyntax node)
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
		
		public Binder VisitEndpointProperties(EndpointPropertiesSyntax node)
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
		
		public Binder VisitEndpointProperty(EndpointPropertySyntax node)
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
		
		public Binder VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
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
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Binding");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Binding)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
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
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.StringLiteral, "Address");
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray<Type>.Empty);
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray.Create(typeof(Symbols.SoalType)));
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
		
		public Binder VisitNulledType(NulledTypeSyntax node)
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
		
		public Binder VisitReferenceType(ReferenceTypeSyntax node)
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray<Type>.Empty);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseObjectType)
				{
					switch (((SoalSyntaxToken)node.ObjectType).Kind)
					{
						case SoalSyntaxKind.KObject:
							resultBinder = this.CreateValueBinder(resultBinder, node.ObjectType, SoalInstance.Object);
							break;
						case SoalSyntaxKind.KString:
							resultBinder = this.CreateValueBinder(resultBinder, node.ObjectType, SoalInstance.String);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitValueType(ValueTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.ValueType)) use = UseValueType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolUseBinder(resultBinder, node, ImmutableArray<Type>.Empty);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseValueType)
				{
					switch (((SoalSyntaxToken)node.ValueType).Kind)
					{
						case SoalSyntaxKind.KInt:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.Int);
							break;
						case SoalSyntaxKind.KLong:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.Long);
							break;
						case SoalSyntaxKind.KFloat:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.Float);
							break;
						case SoalSyntaxKind.KDouble:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.Double);
							break;
						case SoalSyntaxKind.KByte:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.Byte);
							break;
						case SoalSyntaxKind.KBool:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.Bool);
							break;
						case SoalSyntaxKind.IDate:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.Date);
							break;
						case SoalSyntaxKind.ITime:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.Time);
							break;
						case SoalSyntaxKind.IDateTime:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.DateTime);
							break;
						case SoalSyntaxKind.ITimeSpan:
							resultBinder = this.CreateValueBinder(resultBinder, node.ValueType, SoalInstance.TimeSpan);
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateValueBinder(resultBinder, node, SoalInstance.Void);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitOnewayType(OnewayTypeSyntax node)
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
				resultBinder = this.CreateValueBinder(resultBinder, node, SoalInstance.Void);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.OnewayType)) use = UseOnewayType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Type");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseOnewayType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.OnewayType, "IsOneway", true);
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
				if (LookupPosition.IsInNode(this.Position, node.ValueType)) use = UseValueType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, node, typeof(Symbols.NullableType));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseValueType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.ValueType, "InnerType");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNonNullableType(NonNullableTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.ReferenceType)) use = UseReferenceType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, node, typeof(Symbols.NonNullableType));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseReferenceType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.ReferenceType, "InnerType");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.ArrayType)) use = UseArrayType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, node, typeof(Symbols.NonNullableType));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseArrayType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.ArrayType, "InnerType");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitArrayType(ArrayTypeSyntax node)
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
		
		public Binder VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.SimpleType)) use = UseSimpleType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, node, typeof(Symbols.ArrayType));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseSimpleType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.SimpleType, "InnerType");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.NulledType)) use = UseNulledType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolCtrBinder(resultBinder, node, typeof(Symbols.ArrayType));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseNulledType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.NulledType, "InnerType");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitConstantValue(ConstantValueSyntax node)
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
		
		public Binder VisitTypeofValue(TypeofValueSyntax node)
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
		
		public Binder VisitIdentifiers(IdentifiersSyntax node)
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
		
		public Binder VisitContextualKeywords(ContextualKeywordsSyntax node)
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
    }
}


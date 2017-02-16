using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Symbols;

namespace MetaDslx.Languages.Soal.Binding
{
    public class SoalBindVisitor : BindVisitor, ISoalSyntaxVisitor
    {
        public SoalBindVisitor(Binder binder)
			: base(binder)
        {

        }
		
		public void VisitMain(MainSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.NamespaceDeclaration.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitName(NameSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Identifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Identifier))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Qualifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitQualifier(QualifierSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.BeginQualifier();
				try
				{
					this.VisitList(node.Identifier);
				}
				finally
				{
					this.EndQualifier();
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				this.BeginQualifier();
				try
				{
					if (this.CanVisitChild(node.Identifier.Node))
					{
						this.VisitRed(this.RootNode);
					}
				}
				finally
				{
					this.EndQualifier();
				}
			}
		}
		
		public void VisitIdentifierList(IdentifierListSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.Identifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Identifier.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitQualifierList(QualifierListSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.Qualifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAnnotationList(AnnotationListSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.Annotation);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Annotation.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.ReturnAnnotation);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ReturnAnnotation.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAnnotation(AnnotationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationHead);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationHead))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationHead);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationHead))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				this.Visit(node.AnnotationBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.AnnotationBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAnnotationBody(AnnotationBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationPropertyList);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationPropertyList))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.AnnotationProperty);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationProperty.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.AnnotationPropertyValue))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.ConstantValue);
				this.Visit(node.TypeofValue);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ConstantValue))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.TypeofValue))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationList);
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.QualifiedName))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Identifier))
				{
					if (node.Identifier != null)
					{
						this.RegisterValue(node.Identifier);
					}
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.StringLiteral))
				{
					if (node.StringLiteral != null)
					{
						this.RegisterValue(node.StringLiteral);
					}
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.NamespaceBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.Declaration);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Declaration.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitDeclaration(DeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.EnumDeclaration);
				this.Visit(node.StructDeclaration);
				this.Visit(node.DatabaseDeclaration);
				this.Visit(node.InterfaceDeclaration);
				this.Visit(node.ComponentDeclaration);
				this.Visit(node.CompositeDeclaration);
				this.Visit(node.AssemblyDeclaration);
				this.Visit(node.BindingDeclaration);
				this.Visit(node.EndpointDeclaration);
				this.Visit(node.DeploymentDeclaration);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.EnumDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.StructDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.DatabaseDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.InterfaceDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.CompositeDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.AssemblyDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.BindingDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.EndpointDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.DeploymentDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.EnumBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Enum));
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.EnumBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEnumBody(EnumBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.EnumLiterals);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.EnumLiterals))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.EnumLiteral);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.EnumLiteral.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitStructDeclaration(StructDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.StructBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Struct));
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.StructBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitStructBody(StructBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.PropertyDeclaration);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.PropertyDeclaration.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.TypeReference))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.DatabaseBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.DatabaseBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitDatabaseBody(DatabaseBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.EntityReference);
				this.VisitList(node.OperationDeclaration);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.EntityReference.Node))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.OperationDeclaration.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEntityReference(EntityReferenceSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Struct));
				this.Visit(node.Qualifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Struct));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.InterfaceBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.InterfaceBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitInterfaceBody(InterfaceBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.OperationDeclaration);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.OperationDeclaration.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.OperationHead);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.OperationHead))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitOperationHead(OperationHeadSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.OperationResult);
				this.Visit(node.Name);
				this.Visit(node.ParameterList);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.OperationResult))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ParameterList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.QualifierList))
				{
					if (node.QualifierList != null) this.RegisterSymbolType(typeof(Symbols.Struct));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitParameterList(ParameterListSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.Parameter);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Parameter.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitParameter(ParameterSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.TypeReference))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitOperationResult(OperationResultSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.ReturnAnnotationList);
				this.Visit(node.OperationReturnType);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ReturnAnnotationList))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.OperationReturnType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.VisitToken(node.KAbstract);
				this.Visit(node.Name);
				this.Visit(node.ComponentBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.KAbstract))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Component));
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentBody(ComponentBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.ComponentElements);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ComponentElements))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentElements(ComponentElementsSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.ComponentElement);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ComponentElement.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentElement(ComponentElementSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.ComponentService);
				this.Visit(node.ComponentReference);
				this.Visit(node.ComponentProperty);
				this.Visit(node.ComponentImplementation);
				this.Visit(node.ComponentLanguage);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ComponentService))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentReference))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentProperty))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentImplementation))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentLanguage))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentService(ComponentServiceSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
				this.Visit(node.ComponentServiceOrReferenceBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Interface));
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentServiceOrReferenceBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentReference(ComponentReferenceSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
				this.Visit(node.ComponentServiceOrReferenceBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Interface));
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentServiceOrReferenceBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.ComponentServiceOrReferenceElement);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ComponentServiceOrReferenceElement.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Binding));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentProperty(ComponentPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.TypeReference))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
				this.Visit(node.CompositeBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Component));
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.CompositeBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitCompositeBody(CompositeBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.CompositeElements);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.CompositeElements))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
				this.Visit(node.CompositeBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Component));
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.CompositeBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitCompositeElements(CompositeElementsSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.CompositeElement);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.CompositeElement.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitCompositeElement(CompositeElementSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.ComponentService);
				this.Visit(node.ComponentReference);
				this.Visit(node.ComponentProperty);
				this.Visit(node.ComponentImplementation);
				this.Visit(node.ComponentLanguage);
				this.Visit(node.CompositeComponent);
				this.Visit(node.CompositeWire);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ComponentService))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentReference))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentProperty))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentImplementation))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ComponentLanguage))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.CompositeComponent))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.CompositeWire))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitCompositeComponent(CompositeComponentSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Component));
				this.Visit(node.Qualifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Component));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitCompositeWire(CompositeWireSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.WireSource);
				this.Visit(node.WireTarget);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.WireSource))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.WireTarget))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitWireSource(WireSourceSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Port));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitWireTarget(WireTargetSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Port));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
				this.Visit(node.DeploymentBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.DeploymentBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitDeploymentBody(DeploymentBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.DeploymentElements);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.DeploymentElements))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.DeploymentElement);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.DeploymentElement.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitDeploymentElement(DeploymentElementSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.EnvironmentDeclaration);
				this.Visit(node.CompositeWire);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.EnvironmentDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.CompositeWire))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
				this.Visit(node.EnvironmentBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.EnvironmentBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.RuntimeDeclaration);
				this.VisitList(node.RuntimeReference);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.RuntimeDeclaration))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.RuntimeReference.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.AssemblyReference);
				this.Visit(node.DatabaseReference);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.AssemblyReference))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.DatabaseReference))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Assembly));
				this.Visit(node.Qualifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Assembly));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Database));
				this.Visit(node.Qualifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Database));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
				this.Visit(node.BindingBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.BindingBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitBindingBody(BindingBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.BindingLayers);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.BindingLayers))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitBindingLayers(BindingLayersSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.TransportLayer);
				this.VisitList(node.EncodingLayer);
				this.VisitList(node.ProtocolLayer);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.TransportLayer))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.EncodingLayer.Node))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ProtocolLayer.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitTransportLayer(TransportLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.HttpTransportLayer);
				this.Visit(node.RestTransportLayer);
				this.Visit(node.WebSocketTransportLayer);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.HttpTransportLayer))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.RestTransportLayer))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.WebSocketTransportLayer))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.HttpTransportLayerBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.HttpTransportLayerBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.HttpTransportLayerProperties);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.HttpTransportLayerProperties.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.RestTransportLayerBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.RestTransportLayerBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.WebSocketTransportLayerBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.WebSocketTransportLayerBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.HttpSslProperty);
				this.Visit(node.HttpClientAuthenticationProperty);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.HttpSslProperty))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.HttpClientAuthenticationProperty))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.BooleanLiteral);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.BooleanLiteral))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.BooleanLiteral);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.BooleanLiteral))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEncodingLayer(EncodingLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.SoapEncodingLayer);
				this.Visit(node.XmlEncodingLayer);
				this.Visit(node.JsonEncodingLayer);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.SoapEncodingLayer))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.XmlEncodingLayer))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.JsonEncodingLayer))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.SoapEncodingLayerBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.SoapEncodingLayerBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.SoapEncodingProperties);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.SoapEncodingProperties.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.XmlEncodingLayerBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.XmlEncodingLayerBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.JsonEncodingLayerBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.JsonEncodingLayerBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.SoapVersionProperty);
				this.Visit(node.SoapMtomProperty);
				this.Visit(node.SoapStyleProperty);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.SoapVersionProperty))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.SoapMtomProperty))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.SoapStyleProperty))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Identifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Identifier))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.BooleanLiteral);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.BooleanLiteral))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Identifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Identifier))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.ProtocolLayerKind);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ProtocolLayerKind))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.WsAddressing);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.WsAddressing))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitWsAddressing(WsAddressingSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.Name);
				this.Visit(node.EndpointBody);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Name))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Interface));
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.EndpointBody))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEndpointBody(EndpointBodySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.EndpointProperties);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.EndpointProperties))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.VisitList(node.EndpointProperty);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.EndpointProperty.Node))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEndpointProperty(EndpointPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.EndpointBindingProperty);
				this.Visit(node.EndpointAddressProperty);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.EndpointBindingProperty))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.EndpointAddressProperty))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Qualifier))
				{
					if (node.Qualifier != null) this.RegisterSymbolType(typeof(Symbols.Binding));
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.StringLiteral))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitReturnType(ReturnTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null) this.RegisterSymbolType(null);
				this.Visit(node.TypeReference);
				this.Visit(node.VoidType);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null) this.RegisterSymbolType(null);
				if (this.CanVisitChild(node.TypeReference))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.VoidType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitTypeReference(TypeReferenceSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null) this.RegisterSymbolType(null);
				this.Visit(node.NonNullableArrayType);
				this.Visit(node.ArrayType);
				this.Visit(node.SimpleType);
				this.Visit(node.NulledType);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null) this.RegisterSymbolType(null);
				if (this.CanVisitChild(node.NonNullableArrayType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ArrayType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.SimpleType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.NulledType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitSimpleType(SimpleTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null) this.RegisterSymbolType(null);
				this.Visit(node.ValueType);
				this.Visit(node.ObjectType);
				this.Visit(node.Qualifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null) this.RegisterSymbolType(null);
				if (this.CanVisitChild(node.ValueType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ObjectType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Qualifier))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitNulledType(NulledTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null) this.RegisterSymbolType(null);
				this.Visit(node.NullableType);
				this.Visit(node.NonNullableType);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null) this.RegisterSymbolType(null);
				if (this.CanVisitChild(node.NullableType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.NonNullableType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitReferenceType(ReferenceTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null) this.RegisterSymbolType(null);
				this.Visit(node.ObjectType);
				this.Visit(node.Qualifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null) this.RegisterSymbolType(null);
				if (this.CanVisitChild(node.ObjectType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Qualifier))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitObjectType(ObjectTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null) this.RegisterSymbolType(null);
				if (node != null) this.RegisterIdentifier(node);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null) this.RegisterSymbolType(null);
				if (node != null) this.RegisterIdentifier(node);
			}
		}
		
		public void VisitValueType(ValueTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null) this.RegisterSymbolType(null);
				if (node != null) this.RegisterIdentifier(node);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null) this.RegisterSymbolType(null);
				if (node != null) this.RegisterIdentifier(node);
			}
		}
		
		public void VisitVoidType(VoidTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null)
				{
					this.RegisterValue(node, SoalInstance.Void);
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null)
				{
					this.RegisterValue(node, SoalInstance.Void);
				}
			}
		}
		
		public void VisitOnewayType(OnewayTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null)
				{
					this.RegisterValue(node, SoalInstance.Void);
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null)
				{
					this.RegisterValue(node, SoalInstance.Void);
				}
			}
		}
		
		public void VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
				this.Visit(node.ReturnType);
				this.Visit(node.OnewayType);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ReturnType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.OnewayType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitNullableType(NullableTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ValueType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitNonNullableType(NonNullableTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ReferenceType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ArrayType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitArrayType(ArrayTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.SimpleArrayType);
				this.Visit(node.NulledArrayType);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.SimpleArrayType))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.NulledArrayType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.SimpleType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (!this.CanEnterDeclaration()) return;
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.NulledType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitConstantValue(ConstantValueSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.Literal);
				this.Visit(node.Identifier);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.Literal))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.Identifier))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitTypeofValue(TypeofValueSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.ReturnType);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.ReturnType))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitIdentifier(IdentifierSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null) this.RegisterIdentifier(node);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null) this.RegisterIdentifier(node);
			}
		}
		
		public void VisitIdentifiers(IdentifiersSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
		
		public void VisitLiteral(LiteralSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				this.Visit(node.NullLiteral);
				this.Visit(node.BooleanLiteral);
				this.Visit(node.IntegerLiteral);
				this.Visit(node.DecimalLiteral);
				this.Visit(node.ScientificLiteral);
				this.Visit(node.StringLiteral);
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (this.CanVisitChild(node.NullLiteral))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.BooleanLiteral))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.IntegerLiteral))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.DecimalLiteral))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.ScientificLiteral))
				{
					this.VisitRed(this.RootNode);
				}
				if (this.CanVisitChild(node.StringLiteral))
				{
					this.VisitRed(this.RootNode);
				}
			}
		}
		
		public void VisitNullLiteral(NullLiteralSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
		}
		
		public void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
		}
		
		public void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
		}
		
		public void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
		}
		
		public void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
		}
		
		public void VisitStringLiteral(StringLiteralSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
				if (node != null)
				{
					this.RegisterValue(node);
				}
			}
		}
		
		public void VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
			if (node.Parent == null) this.StartBinding();
			if (this.IsBinding)
			{
			}
			else if (this.CanVisitParent(node.Parent))
			{
				node.Parent.Accept(this);
			}
			else 
			{
			}
		}
    }
}


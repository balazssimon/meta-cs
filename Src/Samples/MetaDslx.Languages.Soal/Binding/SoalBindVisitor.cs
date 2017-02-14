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
    public class SoalBindVisitor : BindVisitor, ISoalSyntaxVisitor<Optional<object>>
    {
        public SoalBindVisitor(Binder binder)
			: base(binder)
        {

        }
		
		public Optional<object> VisitMain(MainSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.NamespaceDeclaration);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.NamespaceDeclaration);
			}
			return null;
		}
		
		public Optional<object> VisitName(NameSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Identifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Identifier);
			}
			return null;
		}
		
		public Optional<object> VisitQualifiedName(QualifiedNameSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitQualifier(QualifierSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.Identifier);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.Identifier);
			}
			return null;
		}
		
		public Optional<object> VisitIdentifierList(IdentifierListSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.Identifier);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.Identifier);
			}
			return null;
		}
		
		public Optional<object> VisitQualifierList(QualifierListSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitAnnotationList(AnnotationListSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.Annotation);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.Annotation);
			}
			return null;
		}
		
		public Optional<object> VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.ReturnAnnotation);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.ReturnAnnotation);
			}
			return null;
		}
		
		public Optional<object> VisitAnnotation(AnnotationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationHead);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationHead);
			}
			return null;
		}
		
		public Optional<object> VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationHead);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationHead);
			}
			return null;
		}
		
		public Optional<object> VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Identifier);
				this.Visit(node.AnnotationBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Identifier);
				this.Visit(node.AnnotationBody);
			}
			return null;
		}
		
		public Optional<object> VisitAnnotationBody(AnnotationBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationPropertyList);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationPropertyList);
			}
			return null;
		}
		
		public Optional<object> VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.AnnotationProperty);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.AnnotationProperty);
			}
			return null;
		}
		
		public Optional<object> VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Identifier);
				this.Visit(node.AnnotationPropertyValue);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Identifier);
				this.Visit(node.AnnotationPropertyValue);
			}
			return null;
		}
		
		public Optional<object> VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ConstantValue);
				this.Visit(node.TypeofValue);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ConstantValue);
				this.Visit(node.TypeofValue);
			}
			return null;
		}
		
		public Optional<object> VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.QualifiedName);
				this.Visit(node.Identifier);
				this.Visit(node.StringLiteral);
				this.Visit(node.NamespaceBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.QualifiedName);
				this.Visit(node.Identifier);
				this.Visit(node.StringLiteral);
				this.Visit(node.NamespaceBody);
			}
			return null;
		}
		
		public Optional<object> VisitNamespaceBody(NamespaceBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.Declaration);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.Declaration);
			}
			return null;
		}
		
		public Optional<object> VisitDeclaration(DeclarationSyntax node)
		{
			if (this.IsBinding)
			{
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
				return this.BindResult(node);
			}
			else
			{
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
			return null;
		}
		
		public Optional<object> VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.EnumBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.EnumBody);
			}
			return null;
		}
		
		public Optional<object> VisitEnumBody(EnumBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.EnumLiterals);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.EnumLiterals);
			}
			return null;
		}
		
		public Optional<object> VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.EnumLiteral);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.EnumLiteral);
			}
			return null;
		}
		
		public Optional<object> VisitEnumLiteral(EnumLiteralSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
			}
			return null;
		}
		
		public Optional<object> VisitStructDeclaration(StructDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.StructBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.StructBody);
			}
			return null;
		}
		
		public Optional<object> VisitStructBody(StructBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.PropertyDeclaration);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.PropertyDeclaration);
			}
			return null;
		}
		
		public Optional<object> VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.TypeReference);
				this.Visit(node.Name);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.TypeReference);
				this.Visit(node.Name);
			}
			return null;
		}
		
		public Optional<object> VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.DatabaseBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.DatabaseBody);
			}
			return null;
		}
		
		public Optional<object> VisitDatabaseBody(DatabaseBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.EntityReference);
				this.VisitList(node.OperationDeclaration);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.EntityReference);
				this.VisitList(node.OperationDeclaration);
			}
			return null;
		}
		
		public Optional<object> VisitEntityReference(EntityReferenceSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.InterfaceBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.InterfaceBody);
			}
			return null;
		}
		
		public Optional<object> VisitInterfaceBody(InterfaceBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.OperationDeclaration);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.OperationDeclaration);
			}
			return null;
		}
		
		public Optional<object> VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.OperationHead);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.OperationHead);
			}
			return null;
		}
		
		public Optional<object> VisitOperationHead(OperationHeadSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.OperationResult);
				this.Visit(node.Name);
				this.Visit(node.ParameterList);
				this.Visit(node.QualifierList);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.OperationResult);
				this.Visit(node.Name);
				this.Visit(node.ParameterList);
				this.Visit(node.QualifierList);
			}
			return null;
		}
		
		public Optional<object> VisitParameterList(ParameterListSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.Parameter);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.Parameter);
			}
			return null;
		}
		
		public Optional<object> VisitParameter(ParameterSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.TypeReference);
				this.Visit(node.Name);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.TypeReference);
				this.Visit(node.Name);
			}
			return null;
		}
		
		public Optional<object> VisitOperationResult(OperationResultSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ReturnAnnotationList);
				this.Visit(node.OperationReturnType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ReturnAnnotationList);
				this.Visit(node.OperationReturnType);
			}
			return null;
		}
		
		public Optional<object> VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitToken(node.KAbstract);
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.ComponentBody);
				return this.BindResult(node);
			}
			else
			{
				this.VisitToken(node.KAbstract);
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.ComponentBody);
			}
			return null;
		}
		
		public Optional<object> VisitComponentBody(ComponentBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ComponentElements);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ComponentElements);
			}
			return null;
		}
		
		public Optional<object> VisitComponentElements(ComponentElementsSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.ComponentElement);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.ComponentElement);
			}
			return null;
		}
		
		public Optional<object> VisitComponentElement(ComponentElementSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ComponentService);
				this.Visit(node.ComponentReference);
				this.Visit(node.ComponentProperty);
				this.Visit(node.ComponentImplementation);
				this.Visit(node.ComponentLanguage);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ComponentService);
				this.Visit(node.ComponentReference);
				this.Visit(node.ComponentProperty);
				this.Visit(node.ComponentImplementation);
				this.Visit(node.ComponentLanguage);
			}
			return null;
		}
		
		public Optional<object> VisitComponentService(ComponentServiceSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				this.Visit(node.Name);
				this.Visit(node.ComponentServiceOrReferenceBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
				this.Visit(node.Name);
				this.Visit(node.ComponentServiceOrReferenceBody);
			}
			return null;
		}
		
		public Optional<object> VisitComponentReference(ComponentReferenceSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				this.Visit(node.Name);
				this.Visit(node.ComponentServiceOrReferenceBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
				this.Visit(node.Name);
				this.Visit(node.ComponentServiceOrReferenceBody);
			}
			return null;
		}
		
		public Optional<object> VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.ComponentServiceOrReferenceElement);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.ComponentServiceOrReferenceElement);
			}
			return null;
		}
		
		public Optional<object> VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitComponentProperty(ComponentPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.TypeReference);
				this.Visit(node.Name);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.TypeReference);
				this.Visit(node.Name);
			}
			return null;
		}
		
		public Optional<object> VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
			}
			return null;
		}
		
		public Optional<object> VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
			}
			return null;
		}
		
		public Optional<object> VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.CompositeBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.CompositeBody);
			}
			return null;
		}
		
		public Optional<object> VisitCompositeBody(CompositeBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.CompositeElements);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.CompositeElements);
			}
			return null;
		}
		
		public Optional<object> VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.CompositeBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.CompositeBody);
			}
			return null;
		}
		
		public Optional<object> VisitCompositeElements(CompositeElementsSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.CompositeElement);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.CompositeElement);
			}
			return null;
		}
		
		public Optional<object> VisitCompositeElement(CompositeElementSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ComponentService);
				this.Visit(node.ComponentReference);
				this.Visit(node.ComponentProperty);
				this.Visit(node.ComponentImplementation);
				this.Visit(node.ComponentLanguage);
				this.Visit(node.CompositeComponent);
				this.Visit(node.CompositeWire);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ComponentService);
				this.Visit(node.ComponentReference);
				this.Visit(node.ComponentProperty);
				this.Visit(node.ComponentImplementation);
				this.Visit(node.ComponentLanguage);
				this.Visit(node.CompositeComponent);
				this.Visit(node.CompositeWire);
			}
			return null;
		}
		
		public Optional<object> VisitCompositeComponent(CompositeComponentSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitCompositeWire(CompositeWireSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.WireSource);
				this.Visit(node.WireTarget);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.WireSource);
				this.Visit(node.WireTarget);
			}
			return null;
		}
		
		public Optional<object> VisitWireSource(WireSourceSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitWireTarget(WireTargetSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				this.Visit(node.DeploymentBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
				this.Visit(node.DeploymentBody);
			}
			return null;
		}
		
		public Optional<object> VisitDeploymentBody(DeploymentBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.DeploymentElements);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.DeploymentElements);
			}
			return null;
		}
		
		public Optional<object> VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.DeploymentElement);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.DeploymentElement);
			}
			return null;
		}
		
		public Optional<object> VisitDeploymentElement(DeploymentElementSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.EnvironmentDeclaration);
				this.Visit(node.CompositeWire);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.EnvironmentDeclaration);
				this.Visit(node.CompositeWire);
			}
			return null;
		}
		
		public Optional<object> VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				this.Visit(node.EnvironmentBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
				this.Visit(node.EnvironmentBody);
			}
			return null;
		}
		
		public Optional<object> VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.RuntimeDeclaration);
				this.VisitList(node.RuntimeReference);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.RuntimeDeclaration);
				this.VisitList(node.RuntimeReference);
			}
			return null;
		}
		
		public Optional<object> VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
			}
			return null;
		}
		
		public Optional<object> VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.AssemblyReference);
				this.Visit(node.DatabaseReference);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.AssemblyReference);
				this.Visit(node.DatabaseReference);
			}
			return null;
		}
		
		public Optional<object> VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				this.Visit(node.BindingBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
				this.Visit(node.BindingBody);
			}
			return null;
		}
		
		public Optional<object> VisitBindingBody(BindingBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.BindingLayers);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.BindingLayers);
			}
			return null;
		}
		
		public Optional<object> VisitBindingLayers(BindingLayersSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.TransportLayer);
				this.VisitList(node.EncodingLayer);
				this.VisitList(node.ProtocolLayer);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.TransportLayer);
				this.VisitList(node.EncodingLayer);
				this.VisitList(node.ProtocolLayer);
			}
			return null;
		}
		
		public Optional<object> VisitTransportLayer(TransportLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.HttpTransportLayer);
				this.Visit(node.RestTransportLayer);
				this.Visit(node.WebSocketTransportLayer);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.HttpTransportLayer);
				this.Visit(node.RestTransportLayer);
				this.Visit(node.WebSocketTransportLayer);
			}
			return null;
		}
		
		public Optional<object> VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.HttpTransportLayerBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.HttpTransportLayerBody);
			}
			return null;
		}
		
		public Optional<object> VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.HttpTransportLayerProperties);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.HttpTransportLayerProperties);
			}
			return null;
		}
		
		public Optional<object> VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.RestTransportLayerBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.RestTransportLayerBody);
			}
			return null;
		}
		
		public Optional<object> VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.WebSocketTransportLayerBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.WebSocketTransportLayerBody);
			}
			return null;
		}
		
		public Optional<object> VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.HttpSslProperty);
				this.Visit(node.HttpClientAuthenticationProperty);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.HttpSslProperty);
				this.Visit(node.HttpClientAuthenticationProperty);
			}
			return null;
		}
		
		public Optional<object> VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.BooleanLiteral);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.BooleanLiteral);
			}
			return null;
		}
		
		public Optional<object> VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.BooleanLiteral);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.BooleanLiteral);
			}
			return null;
		}
		
		public Optional<object> VisitEncodingLayer(EncodingLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.SoapEncodingLayer);
				this.Visit(node.XmlEncodingLayer);
				this.Visit(node.JsonEncodingLayer);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.SoapEncodingLayer);
				this.Visit(node.XmlEncodingLayer);
				this.Visit(node.JsonEncodingLayer);
			}
			return null;
		}
		
		public Optional<object> VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.SoapEncodingLayerBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.SoapEncodingLayerBody);
			}
			return null;
		}
		
		public Optional<object> VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.SoapEncodingProperties);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.SoapEncodingProperties);
			}
			return null;
		}
		
		public Optional<object> VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.XmlEncodingLayerBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.XmlEncodingLayerBody);
			}
			return null;
		}
		
		public Optional<object> VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.JsonEncodingLayerBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.JsonEncodingLayerBody);
			}
			return null;
		}
		
		public Optional<object> VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.SoapVersionProperty);
				this.Visit(node.SoapMtomProperty);
				this.Visit(node.SoapStyleProperty);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.SoapVersionProperty);
				this.Visit(node.SoapMtomProperty);
				this.Visit(node.SoapStyleProperty);
			}
			return null;
		}
		
		public Optional<object> VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Identifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Identifier);
			}
			return null;
		}
		
		public Optional<object> VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.BooleanLiteral);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.BooleanLiteral);
			}
			return null;
		}
		
		public Optional<object> VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Identifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Identifier);
			}
			return null;
		}
		
		public Optional<object> VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ProtocolLayerKind);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ProtocolLayerKind);
			}
			return null;
		}
		
		public Optional<object> VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Identifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Identifier);
			}
			return null;
		}
		
		public Optional<object> VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.EndpointBody);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Name);
				this.Visit(node.Qualifier);
				this.Visit(node.EndpointBody);
			}
			return null;
		}
		
		public Optional<object> VisitEndpointBody(EndpointBodySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.EndpointProperties);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.EndpointProperties);
			}
			return null;
		}
		
		public Optional<object> VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			if (this.IsBinding)
			{
				this.VisitList(node.EndpointProperty);
				return this.BindResult(node);
			}
			else
			{
				this.VisitList(node.EndpointProperty);
			}
			return null;
		}
		
		public Optional<object> VisitEndpointProperty(EndpointPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.EndpointBindingProperty);
				this.Visit(node.EndpointAddressProperty);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.EndpointBindingProperty);
				this.Visit(node.EndpointAddressProperty);
			}
			return null;
		}
		
		public Optional<object> VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.StringLiteral);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.StringLiteral);
			}
			return null;
		}
		
		public Optional<object> VisitReturnType(ReturnTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.TypeReference);
				this.Visit(node.VoidType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.TypeReference);
				this.Visit(node.VoidType);
			}
			return null;
		}
		
		public Optional<object> VisitTypeReference(TypeReferenceSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.NonNullableArrayType);
				this.Visit(node.ArrayType);
				this.Visit(node.SimpleType);
				this.Visit(node.NulledType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.NonNullableArrayType);
				this.Visit(node.ArrayType);
				this.Visit(node.SimpleType);
				this.Visit(node.NulledType);
			}
			return null;
		}
		
		public Optional<object> VisitSimpleType(SimpleTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ValueType);
				this.Visit(node.ObjectType);
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ValueType);
				this.Visit(node.ObjectType);
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitNulledType(NulledTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.NullableType);
				this.Visit(node.NonNullableType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.NullableType);
				this.Visit(node.NonNullableType);
			}
			return null;
		}
		
		public Optional<object> VisitReferenceType(ReferenceTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ObjectType);
				this.Visit(node.Qualifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ObjectType);
				this.Visit(node.Qualifier);
			}
			return null;
		}
		
		public Optional<object> VisitObjectType(ObjectTypeSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitValueType(ValueTypeSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitVoidType(VoidTypeSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitOnewayType(OnewayTypeSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ReturnType);
				this.Visit(node.OnewayType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ReturnType);
				this.Visit(node.OnewayType);
			}
			return null;
		}
		
		public Optional<object> VisitNullableType(NullableTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ValueType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ValueType);
			}
			return null;
		}
		
		public Optional<object> VisitNonNullableType(NonNullableTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ReferenceType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ReferenceType);
			}
			return null;
		}
		
		public Optional<object> VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ArrayType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ArrayType);
			}
			return null;
		}
		
		public Optional<object> VisitArrayType(ArrayTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.SimpleArrayType);
				this.Visit(node.NulledArrayType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.SimpleArrayType);
				this.Visit(node.NulledArrayType);
			}
			return null;
		}
		
		public Optional<object> VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.SimpleType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.SimpleType);
			}
			return null;
		}
		
		public Optional<object> VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.NulledType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.NulledType);
			}
			return null;
		}
		
		public Optional<object> VisitConstantValue(ConstantValueSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.Literal);
				this.Visit(node.Identifier);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.Literal);
				this.Visit(node.Identifier);
			}
			return null;
		}
		
		public Optional<object> VisitTypeofValue(TypeofValueSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.ReturnType);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.ReturnType);
			}
			return null;
		}
		
		public Optional<object> VisitIdentifier(IdentifierSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitIdentifiers(IdentifiersSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitLiteral(LiteralSyntax node)
		{
			if (this.IsBinding)
			{
				this.Visit(node.NullLiteral);
				this.Visit(node.BooleanLiteral);
				this.Visit(node.IntegerLiteral);
				this.Visit(node.DecimalLiteral);
				this.Visit(node.ScientificLiteral);
				this.Visit(node.StringLiteral);
				return this.BindResult(node);
			}
			else
			{
				this.Visit(node.NullLiteral);
				this.Visit(node.BooleanLiteral);
				this.Visit(node.IntegerLiteral);
				this.Visit(node.DecimalLiteral);
				this.Visit(node.ScientificLiteral);
				this.Visit(node.StringLiteral);
			}
			return null;
		}
		
		public Optional<object> VisitNullLiteral(NullLiteralSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitStringLiteral(StringLiteralSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
		
		public Optional<object> VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
			if (this.IsBinding)
			{
				return this.BindResult(node);
			}
			else
			{
			}
			return null;
		}
    }
}


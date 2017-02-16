using MetaDslx.Compiler.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Core;
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Symbols;

namespace MetaDslx.Languages.Soal.Binding
{
    public class SoalSymbolTreeBuilderVisitor : SymbolTreeBuilderVisitor, ISoalSyntaxVisitor
    {
        public SoalSymbolTreeBuilderVisitor(SymbolTreeBuilder symbolBuilder)
			: base(symbolBuilder)
        {

        }
		
		public void VisitMain(MainSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				this.VisitList(node.NamespaceDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitName(NameSyntax node)
		{
			if (node.Identifier != null)
			{
			}
			this.Visit(node.Identifier);
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax node)
		{
			if (node.Qualifier != null)
			{
			}
			this.Visit(node.Qualifier);
		}
		
		public void VisitQualifier(QualifierSyntax node)
		{
			if (node.Identifier != null)
			{
			}
			this.VisitList(node.Identifier);
		}
		
		public void VisitIdentifierList(IdentifierListSyntax node)
		{
			if (node.Identifier != null)
			{
			}
			this.VisitList(node.Identifier);
		}
		
		public void VisitQualifierList(QualifierListSyntax node)
		{
			if (node.Qualifier != null)
			{
			}
			this.VisitList(node.Qualifier);
		}
		
		public void VisitAnnotationList(AnnotationListSyntax node)
		{
			if (node.Annotation != null)
			{
			}
			this.VisitList(node.Annotation);
		}
		
		public void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			if (node.ReturnAnnotation != null)
			{
			}
			this.VisitList(node.ReturnAnnotation);
		}
		
		public void VisitAnnotation(AnnotationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Annotations");
			try
			{
				if (node.AnnotationHead != null)
				{
				}
				this.Visit(node.AnnotationHead);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Annotations");
			try
			{
				if (node.AnnotationHead != null)
				{
				}
				this.Visit(node.AnnotationHead);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			if (node.AnnotationBody != null)
			{
			}
			this.Visit(node.AnnotationBody);
		}
		
		public void VisitAnnotationBody(AnnotationBodySyntax node)
		{
			if (node.AnnotationPropertyList != null)
			{
			}
			this.Visit(node.AnnotationPropertyList);
		}
		
		public void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			if (node.AnnotationProperty != null)
			{
			}
			this.VisitList(node.AnnotationProperty);
		}
		
		public void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Properties");
			try
			{
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
				this.BeginProperty("Value");
				try
				{
					this.Visit(node.AnnotationPropertyValue);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			if (node.ConstantValue != null)
			{
			}
			this.Visit(node.ConstantValue);
			if (node.TypeofValue != null)
			{
			}
			this.Visit(node.TypeofValue);
		}
		
		public void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.AnnotationList != null)
			{
			}
			this.Visit(node.AnnotationList);
			if (node.QualifiedName != null)
			{
			}
			this.Visit(node.QualifiedName);
			this.BeginProperty("Prefix");
			try
			{
				if (node.Identifier != null) this.RegisterValue(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
			this.BeginProperty("Uri");
			try
			{
				if (node.StringLiteral != null) this.RegisterValue(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
			if (node.NamespaceBody != null)
			{
			}
			this.Visit(node.NamespaceBody);
		}
		
		public void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			if (node.Declaration != null)
			{
			}
			this.VisitList(node.Declaration);
		}
		
		public void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				if (node.EnumDeclaration != null)
				{
				}
				this.Visit(node.EnumDeclaration);
				if (node.StructDeclaration != null)
				{
				}
				this.Visit(node.StructDeclaration);
				if (node.DatabaseDeclaration != null)
				{
				}
				this.Visit(node.DatabaseDeclaration);
				if (node.InterfaceDeclaration != null)
				{
				}
				this.Visit(node.InterfaceDeclaration);
				if (node.ComponentDeclaration != null)
				{
				}
				this.Visit(node.ComponentDeclaration);
				if (node.CompositeDeclaration != null)
				{
				}
				this.Visit(node.CompositeDeclaration);
				if (node.AssemblyDeclaration != null)
				{
				}
				this.Visit(node.AssemblyDeclaration);
				if (node.BindingDeclaration != null)
				{
				}
				this.Visit(node.BindingDeclaration);
				if (node.EndpointDeclaration != null)
				{
				}
				this.Visit(node.EndpointDeclaration);
				if (node.DeploymentDeclaration != null)
				{
				}
				this.Visit(node.DeploymentDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.AnnotationList != null)
			{
			}
			this.Visit(node.AnnotationList);
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			this.BeginProperty("BaseType");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
			if (node.EnumBody != null)
			{
			}
			this.Visit(node.EnumBody);
		}
		
		public void VisitEnumBody(EnumBodySyntax node)
		{
			if (node.EnumLiterals != null)
			{
			}
			this.Visit(node.EnumLiterals);
		}
		
		public void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			if (node.EnumLiteral != null)
			{
			}
			this.VisitList(node.EnumLiteral);
		}
		
		public void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("EnumLiterals");
			try
			{
				if (node.AnnotationList != null)
				{
				}
				this.Visit(node.AnnotationList);
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitStructDeclaration(StructDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.AnnotationList != null)
			{
			}
			this.Visit(node.AnnotationList);
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			this.BeginProperty("BaseType");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
			if (node.StructBody != null)
			{
			}
			this.Visit(node.StructBody);
		}
		
		public void VisitStructBody(StructBodySyntax node)
		{
			if (node.PropertyDeclaration != null)
			{
			}
			this.VisitList(node.PropertyDeclaration);
		}
		
		public void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Properties");
			try
			{
				if (node.AnnotationList != null)
				{
				}
				this.Visit(node.AnnotationList);
				this.BeginProperty("Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.AnnotationList != null)
			{
			}
			this.Visit(node.AnnotationList);
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			if (node.DatabaseBody != null)
			{
			}
			this.Visit(node.DatabaseBody);
		}
		
		public void VisitDatabaseBody(DatabaseBodySyntax node)
		{
			if (node.EntityReference != null)
			{
			}
			this.VisitList(node.EntityReference);
			if (node.OperationDeclaration != null)
			{
			}
			this.VisitList(node.OperationDeclaration);
		}
		
		public void VisitEntityReference(EntityReferenceSyntax node)
		{
			this.BeginProperty("Entities");
			try
			{
				if (node.Qualifier != null)
				{
				}
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.AnnotationList != null)
			{
			}
			this.Visit(node.AnnotationList);
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			if (node.InterfaceBody != null)
			{
			}
			this.Visit(node.InterfaceBody);
		}
		
		public void VisitInterfaceBody(InterfaceBodySyntax node)
		{
			if (node.OperationDeclaration != null)
			{
			}
			this.VisitList(node.OperationDeclaration);
		}
		
		public void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Operations");
			try
			{
				if (node.OperationHead != null)
				{
				}
				this.Visit(node.OperationHead);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitOperationHead(OperationHeadSyntax node)
		{
			if (node.AnnotationList != null)
			{
			}
			this.Visit(node.AnnotationList);
			if (node.OperationResult != null)
			{
			}
			this.Visit(node.OperationResult);
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			if (node.ParameterList != null)
			{
			}
			this.Visit(node.ParameterList);
			this.BeginProperty("Exceptions");
			try
			{
				if (node.QualifierList != null) this.RegisterValue(node.QualifierList);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitParameterList(ParameterListSyntax node)
		{
			if (node.Parameter != null)
			{
			}
			this.VisitList(node.Parameter);
		}
		
		public void VisitParameter(ParameterSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Parameters");
			try
			{
				if (node.AnnotationList != null)
				{
				}
				this.Visit(node.AnnotationList);
				this.BeginProperty("Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitOperationResult(OperationResultSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Result");
			try
			{
				if (node.ReturnAnnotationList != null)
				{
				}
				this.Visit(node.ReturnAnnotationList);
				if (node.OperationReturnType != null)
				{
				}
				this.Visit(node.OperationReturnType);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.KAbstract != null)
			{
				this.RegisterProperty("IsAbstract", true);
			}
			this.VisitToken(node.KAbstract);
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			this.BeginProperty("BaseComponent");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
			if (node.ComponentBody != null)
			{
			}
			this.Visit(node.ComponentBody);
		}
		
		public void VisitComponentBody(ComponentBodySyntax node)
		{
			if (node.ComponentElements != null)
			{
			}
			this.Visit(node.ComponentElements);
		}
		
		public void VisitComponentElements(ComponentElementsSyntax node)
		{
			if (node.ComponentElement != null)
			{
			}
			this.VisitList(node.ComponentElement);
		}
		
		public void VisitComponentElement(ComponentElementSyntax node)
		{
			if (node.ComponentService != null)
			{
			}
			this.Visit(node.ComponentService);
			if (node.ComponentReference != null)
			{
			}
			this.Visit(node.ComponentReference);
			if (node.ComponentProperty != null)
			{
			}
			this.Visit(node.ComponentProperty);
			if (node.ComponentImplementation != null)
			{
			}
			this.Visit(node.ComponentImplementation);
			if (node.ComponentLanguage != null)
			{
			}
			this.Visit(node.ComponentLanguage);
		}
		
		public void VisitComponentService(ComponentServiceSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Services");
			try
			{
				this.BeginProperty("Interface");
				try
				{
					if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
				}
				finally
				{
					this.EndProperty();
				}
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
				if (node.ComponentServiceOrReferenceBody != null)
				{
				}
				this.Visit(node.ComponentServiceOrReferenceBody);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitComponentReference(ComponentReferenceSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("References");
			try
			{
				this.BeginProperty("Interface");
				try
				{
					if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
				}
				finally
				{
					this.EndProperty();
				}
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
				if (node.ComponentServiceOrReferenceBody != null)
				{
				}
				this.Visit(node.ComponentServiceOrReferenceBody);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
		}
		
		public void VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
			if (node.ComponentServiceOrReferenceElement != null)
			{
			}
			this.VisitList(node.ComponentServiceOrReferenceElement);
		}
		
		public void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			this.BeginProperty("Binding");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitComponentProperty(ComponentPropertySyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Properties");
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
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Implementation");
			try
			{
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Language");
			try
			{
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			this.BeginProperty("BaseComponent");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
			if (node.CompositeBody != null)
			{
			}
			this.Visit(node.CompositeBody);
		}
		
		public void VisitCompositeBody(CompositeBodySyntax node)
		{
			if (node.CompositeElements != null)
			{
			}
			this.Visit(node.CompositeElements);
		}
		
		public void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			this.BeginProperty("BaseComponent");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
			if (node.CompositeBody != null)
			{
			}
			this.Visit(node.CompositeBody);
		}
		
		public void VisitCompositeElements(CompositeElementsSyntax node)
		{
			if (node.CompositeElement != null)
			{
			}
			this.VisitList(node.CompositeElement);
		}
		
		public void VisitCompositeElement(CompositeElementSyntax node)
		{
			if (node.ComponentService != null)
			{
			}
			this.Visit(node.ComponentService);
			if (node.ComponentReference != null)
			{
			}
			this.Visit(node.ComponentReference);
			if (node.ComponentProperty != null)
			{
			}
			this.Visit(node.ComponentProperty);
			if (node.ComponentImplementation != null)
			{
			}
			this.Visit(node.ComponentImplementation);
			if (node.ComponentLanguage != null)
			{
			}
			this.Visit(node.ComponentLanguage);
			if (node.CompositeComponent != null)
			{
			}
			this.Visit(node.CompositeComponent);
			if (node.CompositeWire != null)
			{
			}
			this.Visit(node.CompositeWire);
		}
		
		public void VisitCompositeComponent(CompositeComponentSyntax node)
		{
			this.BeginProperty("Components");
			try
			{
				if (node.Qualifier != null)
				{
				}
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitCompositeWire(CompositeWireSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Wires");
			try
			{
				if (node.WireSource != null)
				{
				}
				this.Visit(node.WireSource);
				if (node.WireTarget != null)
				{
				}
				this.Visit(node.WireTarget);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitWireSource(WireSourceSyntax node)
		{
			this.BeginProperty("Source");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitWireTarget(WireTargetSyntax node)
		{
			this.BeginProperty("Target");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			if (node.DeploymentBody != null)
			{
			}
			this.Visit(node.DeploymentBody);
		}
		
		public void VisitDeploymentBody(DeploymentBodySyntax node)
		{
			if (node.DeploymentElements != null)
			{
			}
			this.Visit(node.DeploymentElements);
		}
		
		public void VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			if (node.DeploymentElement != null)
			{
			}
			this.VisitList(node.DeploymentElement);
		}
		
		public void VisitDeploymentElement(DeploymentElementSyntax node)
		{
			if (node.EnvironmentDeclaration != null)
			{
			}
			this.Visit(node.EnvironmentDeclaration);
			if (node.CompositeWire != null)
			{
			}
			this.Visit(node.CompositeWire);
		}
		
		public void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Environments");
			try
			{
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
				if (node.EnvironmentBody != null)
				{
				}
				this.Visit(node.EnvironmentBody);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
			if (node.RuntimeDeclaration != null)
			{
			}
			this.Visit(node.RuntimeDeclaration);
			if (node.RuntimeReference != null)
			{
			}
			this.VisitList(node.RuntimeReference);
		}
		
		public void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Runtime");
			try
			{
				if (node.Name != null)
				{
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			if (node.AssemblyReference != null)
			{
			}
			this.Visit(node.AssemblyReference);
			if (node.DatabaseReference != null)
			{
			}
			this.Visit(node.DatabaseReference);
		}
		
		public void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			this.BeginProperty("Assemblies");
			try
			{
				if (node.Qualifier != null)
				{
				}
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			this.BeginProperty("Databases");
			try
			{
				if (node.Qualifier != null)
				{
				}
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			if (node.BindingBody != null)
			{
			}
			this.Visit(node.BindingBody);
		}
		
		public void VisitBindingBody(BindingBodySyntax node)
		{
			if (node.BindingLayers != null)
			{
			}
			this.Visit(node.BindingLayers);
		}
		
		public void VisitBindingLayers(BindingLayersSyntax node)
		{
			if (node.TransportLayer != null)
			{
			}
			this.Visit(node.TransportLayer);
			if (node.EncodingLayer != null)
			{
			}
			this.VisitList(node.EncodingLayer);
			if (node.ProtocolLayer != null)
			{
			}
			this.VisitList(node.ProtocolLayer);
		}
		
		public void VisitTransportLayer(TransportLayerSyntax node)
		{
			this.BeginProperty("Transport");
			try
			{
				if (node.HttpTransportLayer != null)
				{
				}
				this.Visit(node.HttpTransportLayer);
				if (node.RestTransportLayer != null)
				{
				}
				this.Visit(node.RestTransportLayer);
				if (node.WebSocketTransportLayer != null)
				{
				}
				this.Visit(node.WebSocketTransportLayer);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.HttpTransportLayerBody != null)
			{
			}
			this.Visit(node.HttpTransportLayerBody);
		}
		
		public void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			if (node.HttpTransportLayerProperties != null)
			{
			}
			this.VisitList(node.HttpTransportLayerProperties);
		}
		
		public void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.RestTransportLayerBody != null)
			{
			}
			this.Visit(node.RestTransportLayerBody);
		}
		
		public void VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.WebSocketTransportLayerBody != null)
			{
			}
			this.Visit(node.WebSocketTransportLayerBody);
		}
		
		public void VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			if (node.HttpSslProperty != null)
			{
			}
			this.Visit(node.HttpSslProperty);
			if (node.HttpClientAuthenticationProperty != null)
			{
			}
			this.Visit(node.HttpClientAuthenticationProperty);
		}
		
		public void VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			this.BeginProperty("Ssl");
			try
			{
				if (node.BooleanLiteral != null)
				{
				}
				this.Visit(node.BooleanLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			this.BeginProperty("ClientAuthentication");
			try
			{
				if (node.BooleanLiteral != null)
				{
				}
				this.Visit(node.BooleanLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitEncodingLayer(EncodingLayerSyntax node)
		{
			this.BeginProperty("Encodings");
			try
			{
				if (node.SoapEncodingLayer != null)
				{
				}
				this.Visit(node.SoapEncodingLayer);
				if (node.XmlEncodingLayer != null)
				{
				}
				this.Visit(node.XmlEncodingLayer);
				if (node.JsonEncodingLayer != null)
				{
				}
				this.Visit(node.JsonEncodingLayer);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.SoapEncodingLayerBody != null)
			{
			}
			this.Visit(node.SoapEncodingLayerBody);
		}
		
		public void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			if (node.SoapEncodingProperties != null)
			{
			}
			this.VisitList(node.SoapEncodingProperties);
		}
		
		public void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.XmlEncodingLayerBody != null)
			{
			}
			this.Visit(node.XmlEncodingLayerBody);
		}
		
		public void VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.JsonEncodingLayerBody != null)
			{
			}
			this.Visit(node.JsonEncodingLayerBody);
		}
		
		public void VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			if (node.SoapVersionProperty != null)
			{
			}
			this.Visit(node.SoapVersionProperty);
			if (node.SoapMtomProperty != null)
			{
			}
			this.Visit(node.SoapMtomProperty);
			if (node.SoapStyleProperty != null)
			{
			}
			this.Visit(node.SoapStyleProperty);
		}
		
		public void VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			this.BeginProperty("Version");
			try
			{
				if (node.Identifier != null)
				{
				}
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			this.BeginProperty("Mtom");
			try
			{
				if (node.BooleanLiteral != null)
				{
				}
				this.Visit(node.BooleanLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			this.BeginProperty("Style");
			try
			{
				if (node.Identifier != null)
				{
				}
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			this.BeginProperty("Protocols");
			try
			{
				if (node.ProtocolLayerKind != null)
				{
				}
				this.Visit(node.ProtocolLayerKind);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			if (node.WsAddressing != null)
			{
			}
			this.Visit(node.WsAddressing);
		}
		
		public void VisitWsAddressing(WsAddressingSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
		}
		
		public void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			if (node.Name != null)
			{
			}
			this.Visit(node.Name);
			this.BeginProperty("Interface");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
			if (node.EndpointBody != null)
			{
			}
			this.Visit(node.EndpointBody);
		}
		
		public void VisitEndpointBody(EndpointBodySyntax node)
		{
			if (node.EndpointProperties != null)
			{
			}
			this.Visit(node.EndpointProperties);
		}
		
		public void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			if (node.EndpointProperty != null)
			{
			}
			this.VisitList(node.EndpointProperty);
		}
		
		public void VisitEndpointProperty(EndpointPropertySyntax node)
		{
			if (node.EndpointBindingProperty != null)
			{
			}
			this.Visit(node.EndpointBindingProperty);
			if (node.EndpointAddressProperty != null)
			{
			}
			this.Visit(node.EndpointAddressProperty);
		}
		
		public void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
			this.BeginProperty("Binding");
			try
			{
				if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			this.BeginProperty("Address");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitReturnType(ReturnTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitTypeReference(TypeReferenceSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitSimpleType(SimpleTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitNulledType(NulledTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitReferenceType(ReferenceTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitObjectType(ObjectTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitValueType(ValueTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitVoidType(VoidTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitOnewayType(OnewayTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			this.BeginProperty("Type");
			try
			{
				if (node.ReturnType != null)
				{
				}
				this.Visit(node.ReturnType);
				if (node.OnewayType != null)
				{
					this.RegisterProperty("IsOneway", true);
				}
				this.Visit(node.OnewayType);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitNullableType(NullableTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitNonNullableType(NonNullableTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitArrayType(ArrayTypeSyntax node)
		{
			if (node.SimpleArrayType != null)
			{
			}
			this.Visit(node.SimpleArrayType);
			if (node.NulledArrayType != null)
			{
			}
			this.Visit(node.NulledArrayType);
		}
		
		public void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitConstantValue(ConstantValueSyntax node)
		{
			if (node.Literal != null)
			{
			}
			this.Visit(node.Literal);
			if (node.Identifier != null)
			{
			}
			this.Visit(node.Identifier);
		}
		
		public void VisitTypeofValue(TypeofValueSyntax node)
		{
			if (node.ReturnType != null)
			{
			}
			this.Visit(node.ReturnType);
		}
		
		public void VisitIdentifier(IdentifierSyntax node)
		{
		}
		
		public void VisitIdentifiers(IdentifiersSyntax node)
		{
		}
		
		public void VisitLiteral(LiteralSyntax node)
		{
			if (node.NullLiteral != null)
			{
			}
			this.Visit(node.NullLiteral);
			if (node.BooleanLiteral != null)
			{
			}
			this.Visit(node.BooleanLiteral);
			if (node.IntegerLiteral != null)
			{
			}
			this.Visit(node.IntegerLiteral);
			if (node.DecimalLiteral != null)
			{
			}
			this.Visit(node.DecimalLiteral);
			if (node.ScientificLiteral != null)
			{
			}
			this.Visit(node.ScientificLiteral);
			if (node.StringLiteral != null)
			{
			}
			this.Visit(node.StringLiteral);
		}
		
		public void VisitNullLiteral(NullLiteralSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitStringLiteral(StringLiteralSyntax node)
		{
			if (node != null) this.RegisterValue(node);
		}
		
		public void VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
		}
    }
}


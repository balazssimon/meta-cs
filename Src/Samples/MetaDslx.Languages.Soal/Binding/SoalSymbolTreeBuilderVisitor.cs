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
			this.Visit(node.Identifier);
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.Visit(node.Qualifier);
		}
		
		public void VisitQualifier(QualifierSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public void VisitIdentifierList(IdentifierListSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public void VisitQualifierList(QualifierListSyntax node)
		{
			this.VisitList(node.Qualifier);
		}
		
		public void VisitAnnotationList(AnnotationListSyntax node)
		{
			this.VisitList(node.Annotation);
		}
		
		public void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			this.VisitList(node.ReturnAnnotation);
		}
		
		public void VisitAnnotation(AnnotationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Annotations");
			try
			{
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
				this.Visit(node.AnnotationHead);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			this.Visit(node.Name);
			this.Visit(node.AnnotationBody);
		}
		
		public void VisitAnnotationBody(AnnotationBodySyntax node)
		{
			this.Visit(node.AnnotationPropertyList);
		}
		
		public void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			this.VisitList(node.AnnotationProperty);
		}
		
		public void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Properties");
			try
			{
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
			this.Visit(node.ConstantValue);
			this.Visit(node.TypeofValue);
		}
		
		public void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.Visit(node.AnnotationList);
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
			this.Visit(node.NamespaceBody);
		}
		
		public void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.VisitList(node.Declaration);
		}
		
		public void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty("Declarations");
			try
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.Visit(node.AnnotationList);
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
			this.Visit(node.EnumBody);
		}
		
		public void VisitEnumBody(EnumBodySyntax node)
		{
			this.Visit(node.EnumLiterals);
		}
		
		public void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			this.VisitList(node.EnumLiteral);
		}
		
		public void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("EnumLiterals");
			try
			{
				this.Visit(node.AnnotationList);
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
			this.Visit(node.AnnotationList);
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
			this.Visit(node.StructBody);
		}
		
		public void VisitStructBody(StructBodySyntax node)
		{
			this.VisitList(node.PropertyDeclaration);
		}
		
		public void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Properties");
			try
			{
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
			this.Visit(node.AnnotationList);
			this.Visit(node.Name);
			this.Visit(node.DatabaseBody);
		}
		
		public void VisitDatabaseBody(DatabaseBodySyntax node)
		{
			this.VisitList(node.EntityReference);
			this.VisitList(node.OperationDeclaration);
		}
		
		public void VisitEntityReference(EntityReferenceSyntax node)
		{
			this.BeginProperty("Entities");
			try
			{
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
			this.Visit(node.AnnotationList);
			this.Visit(node.Name);
			this.Visit(node.InterfaceBody);
		}
		
		public void VisitInterfaceBody(InterfaceBodySyntax node)
		{
			this.VisitList(node.OperationDeclaration);
		}
		
		public void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Operations");
			try
			{
				this.Visit(node.OperationHead);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitOperationHead(OperationHeadSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.OperationResult);
			this.Visit(node.Name);
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
			this.VisitList(node.Parameter);
		}
		
		public void VisitParameter(ParameterSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Parameters");
			try
			{
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
				this.Visit(node.ReturnAnnotationList);
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
			this.BeginProperty("IsAbstract");
			try
			{
				this.VisitToken(node.KAbstract);
			}
			finally
			{
				this.EndProperty();
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
			this.Visit(node.ComponentBody);
		}
		
		public void VisitComponentBody(ComponentBodySyntax node)
		{
			this.Visit(node.ComponentElements);
		}
		
		public void VisitComponentElements(ComponentElementsSyntax node)
		{
			this.VisitList(node.ComponentElement);
		}
		
		public void VisitComponentElement(ComponentElementSyntax node)
		{
			this.Visit(node.ComponentService);
			this.Visit(node.ComponentReference);
			this.Visit(node.ComponentProperty);
			this.Visit(node.ComponentImplementation);
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
				this.Visit(node.Name);
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
				this.Visit(node.Name);
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
			this.VisitList(node.ComponentServiceOrReferenceElement);
		}
		
		public void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			this.BeginProperty("Binding");
			try
			{
				this.Visit(node.Qualifier);
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
				this.Visit(node.TypeReference);
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
			this.Visit(node.CompositeBody);
		}
		
		public void VisitCompositeBody(CompositeBodySyntax node)
		{
			this.Visit(node.CompositeElements);
		}
		
		public void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
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
			this.Visit(node.CompositeBody);
		}
		
		public void VisitCompositeElements(CompositeElementsSyntax node)
		{
			this.VisitList(node.CompositeElement);
		}
		
		public void VisitCompositeElement(CompositeElementSyntax node)
		{
			this.Visit(node.ComponentService);
			this.Visit(node.ComponentReference);
			this.Visit(node.ComponentProperty);
			this.Visit(node.ComponentImplementation);
			this.Visit(node.ComponentLanguage);
			this.Visit(node.CompositeComponent);
			this.Visit(node.CompositeWire);
		}
		
		public void VisitCompositeComponent(CompositeComponentSyntax node)
		{
			this.BeginProperty("Components");
			try
			{
				this.Visit(node.Qualifier);
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
				this.Visit(node.WireSource);
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
				this.Visit(node.Qualifier);
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
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.Visit(node.Name);
			this.Visit(node.DeploymentBody);
		}
		
		public void VisitDeploymentBody(DeploymentBodySyntax node)
		{
			this.Visit(node.DeploymentElements);
		}
		
		public void VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			this.VisitList(node.DeploymentElement);
		}
		
		public void VisitDeploymentElement(DeploymentElementSyntax node)
		{
			this.Visit(node.EnvironmentDeclaration);
			this.Visit(node.CompositeWire);
		}
		
		public void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Environments");
			try
			{
				this.Visit(node.Name);
				this.Visit(node.EnvironmentBody);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
			this.Visit(node.RuntimeDeclaration);
			this.VisitList(node.RuntimeReference);
		}
		
		public void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
			this.BeginProperty("Runtime");
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			this.Visit(node.AssemblyReference);
			this.Visit(node.DatabaseReference);
		}
		
		public void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			this.BeginProperty("Assemblies");
			try
			{
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
			this.Visit(node.Name);
			this.Visit(node.BindingBody);
		}
		
		public void VisitBindingBody(BindingBodySyntax node)
		{
			this.Visit(node.BindingLayers);
		}
		
		public void VisitBindingLayers(BindingLayersSyntax node)
		{
			this.Visit(node.TransportLayer);
			this.VisitList(node.EncodingLayer);
			this.VisitList(node.ProtocolLayer);
		}
		
		public void VisitTransportLayer(TransportLayerSyntax node)
		{
			this.BeginProperty("Transport");
			try
			{
				this.Visit(node.HttpTransportLayer);
				this.Visit(node.RestTransportLayer);
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
			this.Visit(node.HttpTransportLayerBody);
		}
		
		public void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			this.VisitList(node.HttpTransportLayerProperties);
		}
		
		public void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
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
			this.Visit(node.HttpSslProperty);
			this.Visit(node.HttpClientAuthenticationProperty);
		}
		
		public void VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			this.BeginProperty("Ssl");
			try
			{
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
				this.Visit(node.SoapEncodingLayer);
				this.Visit(node.XmlEncodingLayer);
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
			this.Visit(node.SoapEncodingLayerBody);
		}
		
		public void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			this.VisitList(node.SoapEncodingProperties);
		}
		
		public void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
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
			this.Visit(node.SoapVersionProperty);
			this.Visit(node.SoapMtomProperty);
			this.Visit(node.SoapStyleProperty);
		}
		
		public void VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			this.BeginProperty("Version");
			try
			{
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
				this.Visit(node.ProtocolLayerKind);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			this.Visit(node.WsAddressing);
		}
		
		public void VisitWsAddressing(WsAddressingSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
		}
		
		public void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			if (!this.CanEnterDeclaration()) return;
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
			this.Visit(node.EndpointBody);
		}
		
		public void VisitEndpointBody(EndpointBodySyntax node)
		{
			this.Visit(node.EndpointProperties);
		}
		
		public void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			this.VisitList(node.EndpointProperty);
		}
		
		public void VisitEndpointProperty(EndpointPropertySyntax node)
		{
			this.Visit(node.EndpointBindingProperty);
			this.Visit(node.EndpointAddressProperty);
		}
		
		public void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
			this.BeginProperty("Binding");
			try
			{
				this.Visit(node.Qualifier);
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
			this.Visit(node.TypeReference);
			this.Visit(node.VoidType);
		}
		
		public void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.Visit(node.NonNullableArrayType);
			this.Visit(node.ArrayType);
			this.Visit(node.SimpleType);
			this.Visit(node.NulledType);
		}
		
		public void VisitSimpleType(SimpleTypeSyntax node)
		{
			this.Visit(node.ValueType);
			this.Visit(node.ObjectType);
			if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
		}
		
		public void VisitNulledType(NulledTypeSyntax node)
		{
			this.Visit(node.NullableType);
			this.Visit(node.NonNullableType);
		}
		
		public void VisitReferenceType(ReferenceTypeSyntax node)
		{
			this.Visit(node.ObjectType);
			if (node.Qualifier != null) this.RegisterValue(node.Qualifier);
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
				this.Visit(node.ReturnType);
			}
			finally
			{
				this.EndProperty();
			}
			this.BeginProperty("Type");
			try
			{
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
			this.Visit(node.SimpleArrayType);
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
			this.Visit(node.Literal);
			this.Visit(node.Identifier);
		}
		
		public void VisitTypeofValue(TypeofValueSyntax node)
		{
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
			this.Visit(node.NullLiteral);
			this.Visit(node.BooleanLiteral);
			this.Visit(node.IntegerLiteral);
			this.Visit(node.DecimalLiteral);
			this.Visit(node.ScientificLiteral);
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


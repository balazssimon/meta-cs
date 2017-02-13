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
    public class SoalSymbolBuilderVisitor : SymbolBuilderVisitor, ISoalSyntaxVisitor
    {
        public SoalSymbolBuilderVisitor(SymbolBuilder symbolBuilder)
			: base(symbolBuilder)
        {

        }
		
		public void VisitMain(MainSyntax node)
		{
			this.VisitList(node.NamespaceDeclaration);
		}
		
		public void VisitNameDef(NameDefSyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public void VisitQualifiedNameDef(QualifiedNameDefSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public void VisitIdentifierList(IdentifierListSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public void VisitQualifiedNameList(QualifiedNameListSyntax node)
		{
			this.VisitList(node.QualifiedName);
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
			this.Visit(node.AnnotationHead);
		}
		
		public void VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			this.Visit(node.AnnotationHead);
		}
		
		public void VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			this.Visit(node.Identifier);
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
			this.Visit(node.Identifier);
			this.Visit(node.AnnotationPropertyValue);
		}
		
		public void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			this.Visit(node.ConstantValue);
			this.Visit(node.TypeofValue);
		}
		
		public void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.QualifiedNameDef);
			this.Visit(node.Identifier);
			this.Visit(node.StringLiteral);
			this.Visit(node.NamespaceBody);
		}
		
		public void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.VisitList(node.Declaration);
		}
		
		public void VisitDeclaration(DeclarationSyntax node)
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
		
		public void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.NameDef);
			this.Visit(node.QualifiedName);
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
			this.Visit(node.AnnotationList);
			this.Visit(node.NameDef);
		}
		
		public void VisitStructDeclaration(StructDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.NameDef);
			this.Visit(node.QualifiedName);
			this.Visit(node.StructBody);
		}
		
		public void VisitStructBody(StructBodySyntax node)
		{
			this.VisitList(node.PropertyDeclaration);
		}
		
		public void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.TypeReference);
			this.Visit(node.NameDef);
		}
		
		public void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.NameDef);
			this.Visit(node.DatabaseBody);
		}
		
		public void VisitDatabaseBody(DatabaseBodySyntax node)
		{
			this.VisitList(node.EntityReference);
			this.VisitList(node.OperationDeclaration);
		}
		
		public void VisitEntityReference(EntityReferenceSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.NameDef);
			this.Visit(node.InterfaceBody);
		}
		
		public void VisitInterfaceBody(InterfaceBodySyntax node)
		{
			this.VisitList(node.OperationDeclaration);
		}
		
		public void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.Visit(node.OperationHead);
		}
		
		public void VisitOperationHead(OperationHeadSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.OperationResult);
			this.Visit(node.NameDef);
			this.Visit(node.ParameterList);
			this.Visit(node.QualifiedNameList);
		}
		
		public void VisitParameterList(ParameterListSyntax node)
		{
			this.VisitList(node.Parameter);
		}
		
		public void VisitParameter(ParameterSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.TypeReference);
			this.Visit(node.NameDef);
		}
		
		public void VisitOperationResult(OperationResultSyntax node)
		{
			this.Visit(node.ReturnAnnotationList);
			this.Visit(node.OperationReturnType);
		}
		
		public void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			this.VisitToken(node.KAbstract);
			this.Visit(node.NameDef);
			this.Visit(node.QualifiedName);
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
			this.Visit(node.QualifiedName);
			this.Visit(node.NameDef);
			this.Visit(node.ComponentServiceOrReferenceBody);
		}
		
		public void VisitComponentReference(ComponentReferenceSyntax node)
		{
			this.Visit(node.QualifiedName);
			this.Visit(node.NameDef);
			this.Visit(node.ComponentServiceOrReferenceBody);
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
			this.Visit(node.QualifiedName);
		}
		
		public void VisitComponentProperty(ComponentPropertySyntax node)
		{
			this.Visit(node.TypeReference);
			this.Visit(node.NameDef);
		}
		
		public void VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			this.Visit(node.NameDef);
		}
		
		public void VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			this.Visit(node.NameDef);
		}
		
		public void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			this.Visit(node.NameDef);
			this.Visit(node.QualifiedName);
			this.Visit(node.CompositeBody);
		}
		
		public void VisitCompositeBody(CompositeBodySyntax node)
		{
			this.Visit(node.CompositeElements);
		}
		
		public void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			this.Visit(node.NameDef);
			this.Visit(node.QualifiedName);
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
			this.Visit(node.QualifiedName);
		}
		
		public void VisitCompositeWire(CompositeWireSyntax node)
		{
			this.Visit(node.WireSource);
			this.Visit(node.WireTarget);
		}
		
		public void VisitWireSource(WireSourceSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public void VisitWireTarget(WireTargetSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			this.Visit(node.NameDef);
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
			this.Visit(node.NameDef);
			this.Visit(node.EnvironmentBody);
		}
		
		public void VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
			this.Visit(node.RuntimeDeclaration);
			this.VisitList(node.RuntimeReference);
		}
		
		public void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			this.Visit(node.NameDef);
		}
		
		public void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			this.Visit(node.AssemblyReference);
			this.Visit(node.DatabaseReference);
		}
		
		public void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public void VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			this.Visit(node.NameDef);
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
			this.Visit(node.HttpTransportLayer);
			this.Visit(node.RestTransportLayer);
			this.Visit(node.WebSocketTransportLayer);
		}
		
		public void VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
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
			this.Visit(node.BooleanLiteral);
		}
		
		public void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			this.Visit(node.BooleanLiteral);
		}
		
		public void VisitEncodingLayer(EncodingLayerSyntax node)
		{
			this.Visit(node.SoapEncodingLayer);
			this.Visit(node.XmlEncodingLayer);
			this.Visit(node.JsonEncodingLayer);
		}
		
		public void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
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
			this.Visit(node.Identifier);
		}
		
		public void VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			this.Visit(node.BooleanLiteral);
		}
		
		public void VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public void VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			this.Visit(node.ProtocolLayerKind);
		}
		
		public void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			this.Visit(node.NameDef);
			this.Visit(node.QualifiedName);
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
			this.Visit(node.QualifiedName);
		}
		
		public void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			this.Visit(node.StringLiteral);
		}
		
		public void VisitReturnType(ReturnTypeSyntax node)
		{
			this.Visit(node.TypeReference);
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
			this.Visit(node.QualifiedName);
		}
		
		public void VisitNulledType(NulledTypeSyntax node)
		{
			this.Visit(node.NullableType);
			this.Visit(node.NonNullableType);
		}
		
		public void VisitReferenceType(ReferenceTypeSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public void VisitObjectType(ObjectTypeSyntax node)
		{
		}
		
		public void VisitValueType(ValueTypeSyntax node)
		{
		}
		
		public void VisitVoidType(VoidTypeSyntax node)
		{
		}
		
		public void VisitOnewayType(OnewayTypeSyntax node)
		{
		}
		
		public void VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			this.Visit(node.ReturnType);
			this.Visit(node.OnewayType);
		}
		
		public void VisitNullableType(NullableTypeSyntax node)
		{
			this.Visit(node.ValueType);
		}
		
		public void VisitNonNullableType(NonNullableTypeSyntax node)
		{
			this.Visit(node.ReferenceType);
		}
		
		public void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			this.Visit(node.ArrayType);
		}
		
		public void VisitArrayType(ArrayTypeSyntax node)
		{
			this.Visit(node.SimpleArrayType);
			this.Visit(node.NulledArrayType);
		}
		
		public void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			this.Visit(node.SimpleType);
		}
		
		public void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			this.Visit(node.NulledType);
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
		}
		
		public void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		}
		
		public void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		}
		
		public void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		}
		
		public void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		}
		
		public void VisitStringLiteral(StringLiteralSyntax node)
		{
		}
		
		public void VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
		}
    }
}


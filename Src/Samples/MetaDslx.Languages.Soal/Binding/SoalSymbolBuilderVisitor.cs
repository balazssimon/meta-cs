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
		}
		
		public void VisitNameDef(NameDefSyntax node)
		{
		}
		
		public void VisitQualifiedNameDef(QualifiedNameDefSyntax node)
		{
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax node)
		{
		}
		
		public void VisitIdentifierList(IdentifierListSyntax node)
		{
		}
		
		public void VisitQualifiedNameList(QualifiedNameListSyntax node)
		{
		}
		
		public void VisitAnnotationList(AnnotationListSyntax node)
		{
		}
		
		public void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
		}
		
		public void VisitAnnotation(AnnotationSyntax node)
		{
		}
		
		public void VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
		}
		
		public void VisitAnnotationHead(AnnotationHeadSyntax node)
		{
		}
		
		public void VisitAnnotationBody(AnnotationBodySyntax node)
		{
		}
		
		public void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
		}
		
		public void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
		}
		
		public void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
		}
		
		public void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		}
		
		public void VisitNamespaceBody(NamespaceBodySyntax node)
		{
		}
		
		public void VisitDeclaration(DeclarationSyntax node)
		{
		}
		
		public void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
		}
		
		public void VisitEnumBody(EnumBodySyntax node)
		{
		}
		
		public void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
		}
		
		public void VisitEnumLiteral(EnumLiteralSyntax node)
		{
		}
		
		public void VisitStructDeclaration(StructDeclarationSyntax node)
		{
		}
		
		public void VisitStructBody(StructBodySyntax node)
		{
		}
		
		public void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
		}
		
		public void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
		}
		
		public void VisitDatabaseBody(DatabaseBodySyntax node)
		{
		}
		
		public void VisitEntityReference(EntityReferenceSyntax node)
		{
		}
		
		public void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
		}
		
		public void VisitInterfaceBody(InterfaceBodySyntax node)
		{
		}
		
		public void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		}
		
		public void VisitOperationHead(OperationHeadSyntax node)
		{
		}
		
		public void VisitParameterList(ParameterListSyntax node)
		{
		}
		
		public void VisitParameter(ParameterSyntax node)
		{
		}
		
		public void VisitOperationResult(OperationResultSyntax node)
		{
		}
		
		public void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
		}
		
		public void VisitComponentBody(ComponentBodySyntax node)
		{
		}
		
		public void VisitComponentElements(ComponentElementsSyntax node)
		{
		}
		
		public void VisitComponentElement(ComponentElementSyntax node)
		{
		}
		
		public void VisitComponentService(ComponentServiceSyntax node)
		{
		}
		
		public void VisitComponentReference(ComponentReferenceSyntax node)
		{
		}
		
		public void VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
		}
		
		public void VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
		}
		
		public void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
		}
		
		public void VisitComponentProperty(ComponentPropertySyntax node)
		{
		}
		
		public void VisitComponentImplementation(ComponentImplementationSyntax node)
		{
		}
		
		public void VisitComponentLanguage(ComponentLanguageSyntax node)
		{
		}
		
		public void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
		}
		
		public void VisitCompositeBody(CompositeBodySyntax node)
		{
		}
		
		public void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
		}
		
		public void VisitCompositeElements(CompositeElementsSyntax node)
		{
		}
		
		public void VisitCompositeElement(CompositeElementSyntax node)
		{
		}
		
		public void VisitCompositeComponent(CompositeComponentSyntax node)
		{
		}
		
		public void VisitCompositeWire(CompositeWireSyntax node)
		{
		}
		
		public void VisitWireSource(WireSourceSyntax node)
		{
		}
		
		public void VisitWireTarget(WireTargetSyntax node)
		{
		}
		
		public void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
		}
		
		public void VisitDeploymentBody(DeploymentBodySyntax node)
		{
		}
		
		public void VisitDeploymentElements(DeploymentElementsSyntax node)
		{
		}
		
		public void VisitDeploymentElement(DeploymentElementSyntax node)
		{
		}
		
		public void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
		}
		
		public void VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
		}
		
		public void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
		}
		
		public void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
		}
		
		public void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
		}
		
		public void VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
		}
		
		public void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
		}
		
		public void VisitBindingBody(BindingBodySyntax node)
		{
		}
		
		public void VisitBindingLayers(BindingLayersSyntax node)
		{
		}
		
		public void VisitTransportLayer(TransportLayerSyntax node)
		{
		}
		
		public void VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
		}
		
		public void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
		}
		
		public void VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
		}
		
		public void VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
		}
		
		public void VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
		}
		
		public void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
		}
		
		public void VisitEncodingLayer(EncodingLayerSyntax node)
		{
		}
		
		public void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
		}
		
		public void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
		}
		
		public void VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
		}
		
		public void VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public void VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
		}
		
		public void VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
		}
		
		public void VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
		}
		
		public void VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
		}
		
		public void VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
		}
		
		public void VisitProtocolLayer(ProtocolLayerSyntax node)
		{
		}
		
		public void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
		}
		
		public void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
		}
		
		public void VisitEndpointBody(EndpointBodySyntax node)
		{
		}
		
		public void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
		}
		
		public void VisitEndpointProperty(EndpointPropertySyntax node)
		{
		}
		
		public void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
		}
		
		public void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
		}
		
		public void VisitReturnType(ReturnTypeSyntax node)
		{
		}
		
		public void VisitTypeReference(TypeReferenceSyntax node)
		{
		}
		
		public void VisitSimpleType(SimpleTypeSyntax node)
		{
		}
		
		public void VisitNulledType(NulledTypeSyntax node)
		{
		}
		
		public void VisitReferenceType(ReferenceTypeSyntax node)
		{
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
		}
		
		public void VisitNullableType(NullableTypeSyntax node)
		{
		}
		
		public void VisitNonNullableType(NonNullableTypeSyntax node)
		{
		}
		
		public void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
		}
		
		public void VisitArrayType(ArrayTypeSyntax node)
		{
		}
		
		public void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
		}
		
		public void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
		}
		
		public void VisitConstantValue(ConstantValueSyntax node)
		{
		}
		
		public void VisitTypeofValue(TypeofValueSyntax node)
		{
		}
		
		public void VisitIdentifier(IdentifierSyntax node)
		{
		}
		
		public void VisitIdentifiers(IdentifiersSyntax node)
		{
		}
		
		public void VisitLiteral(LiteralSyntax node)
		{
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


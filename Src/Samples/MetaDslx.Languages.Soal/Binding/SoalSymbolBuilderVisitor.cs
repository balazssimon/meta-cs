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
    public class SoalSymbolBuilderVisitor : SoalDetailedSyntaxVisitor, ISymbolBuilderVisitor
    {
        private MergedDeclaration _declaration;
        private MutableSymbol _symbol;

        public SoalSymbolBuilderVisitor(SymbolBuilder symbolBuilder)
        {

        }

        public MergedDeclaration Declaration
        {
            get { return _declaration; }
            set { _declaration = value; }
        }

        public MutableSymbol Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
		
		public override void VisitMain(MainSyntax node)
		{
			this.VisitList(node.NamespaceDeclaration);
			this.VisitToken(node.Eof);
		}
		
		public override void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public override void VisitIdentifierList(IdentifierListSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public override void VisitQualifiedNameList(QualifiedNameListSyntax node)
		{
			this.VisitList(node.QualifiedName);
		}
		
		public override void VisitAnnotationList(AnnotationListSyntax node)
		{
			this.VisitList(node.Annotation);
		}
		
		public override void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			this.VisitList(node.ReturnAnnotation);
		}
		
		public override void VisitAnnotation(AnnotationSyntax node)
		{
			this.VisitToken(node.TOpenBracket);
			this.Visit(node.AnnotationBody);
			this.VisitToken(node.TCloseBracket);
		}
		
		public override void VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			this.VisitToken(node.TOpenBracket);
			this.VisitToken(node.KReturn);
			this.VisitToken(node.TColon);
			this.Visit(node.AnnotationBody);
			this.VisitToken(node.TCloseBracket);
		}
		
		public override void VisitAnnotationBody(AnnotationBodySyntax node)
		{
			this.Visit(node.Identifier);
			this.Visit(node.AnnotationProperties);
		}
		
		public override void VisitAnnotationProperties(AnnotationPropertiesSyntax node)
		{
			this.VisitToken(node.TOpenParen);
			this.Visit(node.AnnotationPropertyList);
			this.VisitToken(node.TCloseParen);
		}
		
		public override void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			this.VisitList(node.AnnotationProperty);
		}
		
		public override void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			this.Visit(node.Identifier);
			this.VisitToken(node.TAssign);
			this.Visit(node.AnnotationPropertyValue);
		}
		
		public override void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			this.Visit(node.ConstantValue);
			this.Visit(node.TypeofValue);
		}
		
		public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.VisitToken(node.KNamespace);
			this.Visit(node.QualifiedNameDef);
			this.VisitToken(node.TAssign);
			this.Visit(node.Identifier);
			this.VisitToken(node.TColon);
			this.Visit(node.StringLiteral);
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.Declaration);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitDeclaration(DeclarationSyntax node)
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
		
		public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.VisitToken(node.KEnum);
			this.Visit(node.NameDef);
			this.VisitToken(node.TColon);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.EnumLiterals);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			this.VisitList(node.EnumLiteral);
		}
		
		public override void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.NameDef);
		}
		
		public override void VisitStructDeclaration(StructDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.VisitToken(node.KStruct);
			this.Visit(node.NameDef);
			this.VisitToken(node.TColon);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.PropertyDeclaration);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.TypeReference);
			this.Visit(node.NameDef);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.VisitToken(node.KDatabase);
			this.Visit(node.NameDef);
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.EntityReference);
			this.VisitList(node.OperationDeclaration);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitEntityReference(EntityReferenceSyntax node)
		{
			this.VisitToken(node.KEntity);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.VisitToken(node.KInterface);
			this.Visit(node.NameDef);
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.OperationDeclaration);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.OperationResult);
			this.Visit(node.NameDef);
			this.VisitToken(node.TOpenParen);
			this.Visit(node.ParameterList);
			this.VisitToken(node.TCloseParen);
			this.VisitToken(node.KThrows);
			this.Visit(node.QualifiedNameList);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitParameterList(ParameterListSyntax node)
		{
			this.VisitList(node.Parameter);
		}
		
		public override void VisitParameter(ParameterSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.TypeReference);
			this.Visit(node.NameDef);
		}
		
		public override void VisitOperationResult(OperationResultSyntax node)
		{
			this.Visit(node.ReturnAnnotationList);
			this.Visit(node.OperationReturnType);
		}
		
		public override void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			this.VisitToken(node.KAbstract);
			this.VisitToken(node.KComponent);
			this.Visit(node.NameDef);
			this.VisitToken(node.TColon);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.ComponentElements);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitComponentElements(ComponentElementsSyntax node)
		{
			this.VisitList(node.ComponentElement);
		}
		
		public override void VisitComponentElement(ComponentElementSyntax node)
		{
			this.Visit(node.ComponentService);
			this.Visit(node.ComponentReference);
			this.Visit(node.ComponentProperty);
			this.Visit(node.ComponentImplementation);
			this.Visit(node.ComponentLanguage);
		}
		
		public override void VisitComponentService(ComponentServiceSyntax node)
		{
			this.VisitToken(node.KService);
			this.Visit(node.QualifiedName);
			this.Visit(node.NameDef);
			this.Visit(node.ComponentServiceOrReferenceBody);
		}
		
		public override void VisitComponentReference(ComponentReferenceSyntax node)
		{
			this.VisitToken(node.KReference);
			this.Visit(node.QualifiedName);
			this.Visit(node.NameDef);
			this.Visit(node.ComponentServiceOrReferenceBody);
		}
		
		public override void VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.ComponentServiceOrReferenceElement);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			this.VisitToken(node.KBinding);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitComponentProperty(ComponentPropertySyntax node)
		{
			this.Visit(node.TypeReference);
			this.Visit(node.NameDef);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			this.VisitToken(node.KImplementation);
			this.Visit(node.NameDef);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			this.VisitToken(node.KLanguage);
			this.Visit(node.NameDef);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			this.VisitToken(node.KComposite);
			this.Visit(node.NameDef);
			this.VisitToken(node.TColon);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.CompositeElements);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			this.VisitToken(node.KAssembly);
			this.Visit(node.NameDef);
			this.VisitToken(node.TColon);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.CompositeElements);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitCompositeElements(CompositeElementsSyntax node)
		{
			this.VisitList(node.CompositeElement);
		}
		
		public override void VisitCompositeElement(CompositeElementSyntax node)
		{
			this.Visit(node.ComponentService);
			this.Visit(node.ComponentReference);
			this.Visit(node.ComponentProperty);
			this.Visit(node.ComponentImplementation);
			this.Visit(node.ComponentLanguage);
			this.Visit(node.CompositeComponent);
			this.Visit(node.CompositeWire);
		}
		
		public override void VisitCompositeComponent(CompositeComponentSyntax node)
		{
			this.VisitToken(node.KComponent);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitCompositeWire(CompositeWireSyntax node)
		{
			this.VisitToken(node.KWire);
			this.Visit(node.WireSource);
			this.VisitToken(node.KTo);
			this.Visit(node.WireTarget);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitWireSource(WireSourceSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public override void VisitWireTarget(WireTargetSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public override void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			this.VisitToken(node.KDeployment);
			this.Visit(node.NameDef);
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.DeploymentElements);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			this.VisitList(node.DeploymentElement);
		}
		
		public override void VisitDeploymentElement(DeploymentElementSyntax node)
		{
			this.Visit(node.EnvironmentDeclaration);
			this.Visit(node.CompositeWire);
		}
		
		public override void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			this.VisitToken(node.KEnvironment);
			this.Visit(node.NameDef);
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.RuntimeDeclaration);
			this.VisitList(node.RuntimeReference);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			this.VisitToken(node.KRuntime);
			this.Visit(node.NameDef);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			this.Visit(node.AssemblyReference);
			this.Visit(node.DatabaseReference);
		}
		
		public override void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			this.VisitToken(node.KAssembly);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			this.VisitToken(node.KDatabase);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			this.VisitToken(node.KBinding);
			this.Visit(node.NameDef);
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.BindingLayers);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitBindingLayers(BindingLayersSyntax node)
		{
			this.Visit(node.TransportLayer);
			this.VisitList(node.EncodingLayer);
			this.VisitList(node.ProtocolLayer);
		}
		
		public override void VisitTransportLayer(TransportLayerSyntax node)
		{
			this.Visit(node.HttpTransportLayer);
			this.Visit(node.RestTransportLayer);
			this.Visit(node.WebSocketTransportLayer);
		}
		
		public override void VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
			this.VisitToken(node.KTransport);
			this.VisitToken(node.IHTTP);
			this.Visit(node.HttpTransportLayerBody);
		}
		
		public override void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.HttpTransportLayerProperties);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			this.VisitToken(node.KTransport);
			this.VisitToken(node.IREST);
			this.Visit(node.RestTransportLayerBody);
		}
		
		public override void VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
			this.VisitToken(node.KTransport);
			this.VisitToken(node.IWebSocket);
			this.Visit(node.WebSocketTransportLayerBody);
		}
		
		public override void VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			this.Visit(node.HttpSslProperty);
			this.Visit(node.HttpClientAuthenticationProperty);
		}
		
		public override void VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			this.VisitToken(node.ISSL);
			this.VisitToken(node.TAssign);
			this.Visit(node.BooleanLiteral);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			this.VisitToken(node.IClientAuthentication);
			this.VisitToken(node.TAssign);
			this.Visit(node.BooleanLiteral);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitEncodingLayer(EncodingLayerSyntax node)
		{
			this.Visit(node.SoapEncodingLayer);
			this.Visit(node.XmlEncodingLayer);
			this.Visit(node.JsonEncodingLayer);
		}
		
		public override void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
			this.VisitToken(node.KEncoding);
			this.VisitToken(node.ISOAP);
			this.Visit(node.SoapEncodingLayerBody);
		}
		
		public override void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.SoapEncodingProperties);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			this.VisitToken(node.KEncoding);
			this.VisitToken(node.IXML);
			this.Visit(node.XmlEncodingLayerBody);
		}
		
		public override void VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
			this.VisitToken(node.KEncoding);
			this.VisitToken(node.IJSON);
			this.Visit(node.JsonEncodingLayerBody);
		}
		
		public override void VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			this.Visit(node.SoapVersionProperty);
			this.Visit(node.SoapMtomProperty);
			this.Visit(node.SoapStyleProperty);
		}
		
		public override void VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			this.VisitToken(node.IVersion);
			this.VisitToken(node.TAssign);
			this.Visit(node.Identifier);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			this.VisitToken(node.IMTOM);
			this.VisitToken(node.TAssign);
			this.Visit(node.BooleanLiteral);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			this.VisitToken(node.IStyle);
			this.VisitToken(node.TAssign);
			this.Visit(node.Identifier);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			this.VisitToken(node.KProtocol);
			this.Visit(node.ProtocolLayerKind);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public override void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			this.VisitToken(node.KEndpoint);
			this.Visit(node.NameDef);
			this.VisitToken(node.TColon);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.EndpointProperties);
			this.VisitToken(node.TCloseBrace);
		}
		
		public override void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			this.VisitList(node.EndpointProperty);
		}
		
		public override void VisitEndpointProperty(EndpointPropertySyntax node)
		{
			this.Visit(node.EndpointBindingProperty);
			this.Visit(node.EndpointAddressProperty);
		}
		
		public override void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
			this.VisitToken(node.KBinding);
			this.Visit(node.QualifiedName);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			this.VisitToken(node.KAddress);
			this.Visit(node.StringLiteral);
			this.VisitToken(node.TSemicolon);
		}
		
		public override void VisitReturnType(ReturnTypeSyntax node)
		{
			this.Visit(node.TypeReference);
			this.Visit(node.VoidType);
		}
		
		public override void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.Visit(node.NonNullableArrayType);
			this.Visit(node.ArrayType);
			this.Visit(node.SimpleType);
			this.Visit(node.NulledType);
		}
		
		public override void VisitSimpleType(SimpleTypeSyntax node)
		{
			this.Visit(node.ValueType);
			this.Visit(node.ObjectType);
			this.Visit(node.QualifiedName);
		}
		
		public override void VisitNulledType(NulledTypeSyntax node)
		{
			this.Visit(node.NullableType);
			this.Visit(node.NonNullableType);
		}
		
		public override void VisitReferenceType(ReferenceTypeSyntax node)
		{
			this.Visit(node.ObjectType);
			this.Visit(node.QualifiedName);
		}
		
		public override void VisitObjectType(ObjectTypeSyntax node)
		{
			this.VisitToken(node.ObjectType);
		}
		
		public override void VisitValueType(ValueTypeSyntax node)
		{
			this.VisitToken(node.ValueType);
		}
		
		public override void VisitVoidType(VoidTypeSyntax node)
		{
			this.VisitToken(node.KVoid);
		}
		
		public override void VisitOnewayType(OnewayTypeSyntax node)
		{
			this.VisitToken(node.KOneway);
		}
		
		public override void VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			this.Visit(node.ReturnType);
			this.Visit(node.OnewayType);
		}
		
		public override void VisitNullableType(NullableTypeSyntax node)
		{
			this.Visit(node.ValueType);
			this.VisitToken(node.TQuestion);
		}
		
		public override void VisitNonNullableType(NonNullableTypeSyntax node)
		{
			this.Visit(node.ReferenceType);
			this.VisitToken(node.TExclamation);
		}
		
		public override void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			this.Visit(node.ArrayType);
			this.VisitToken(node.TExclamation);
		}
		
		public override void VisitArrayType(ArrayTypeSyntax node)
		{
			this.Visit(node.SimpleArrayType);
			this.Visit(node.NulledArrayType);
		}
		
		public override void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			this.Visit(node.SimpleType);
			this.VisitToken(node.TOpenBracket);
			this.VisitToken(node.TCloseBracket);
		}
		
		public override void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			this.Visit(node.NulledType);
			this.VisitToken(node.TOpenBracket);
			this.VisitToken(node.TCloseBracket);
		}
		
		public override void VisitConstantValue(ConstantValueSyntax node)
		{
			this.Visit(node.Literal);
			this.Visit(node.Identifier);
		}
		
		public override void VisitTypeofValue(TypeofValueSyntax node)
		{
			this.VisitToken(node.KTypeof);
			this.VisitToken(node.TOpenParen);
			this.Visit(node.ReturnType);
			this.VisitToken(node.TCloseParen);
		}
		
		public override void VisitNameDef(NameDefSyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public override void VisitQualifiedNameDef(QualifiedNameDefSyntax node)
		{
			this.Visit(node.QualifiedName);
		}
		
		public override void VisitIdentifier(IdentifierSyntax node)
		{
			this.Visit(node.Identifiers);
			this.Visit(node.ContextualKeywords);
		}
		
		public override void VisitIdentifiers(IdentifiersSyntax node)
		{
			this.VisitToken(node.Identifiers);
		}
		
		public override void VisitLiteral(LiteralSyntax node)
		{
			this.Visit(node.NullLiteral);
			this.Visit(node.BooleanLiteral);
			this.Visit(node.IntegerLiteral);
			this.Visit(node.DecimalLiteral);
			this.Visit(node.ScientificLiteral);
			this.Visit(node.StringLiteral);
		}
		
		public override void VisitNullLiteral(NullLiteralSyntax node)
		{
			this.VisitToken(node.KNull);
		}
		
		public override void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			this.VisitToken(node.BooleanLiteral);
		}
		
		public override void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			this.VisitToken(node.LInteger);
		}
		
		public override void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			this.VisitToken(node.LDecimal);
		}
		
		public override void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			this.VisitToken(node.LScientific);
		}
		
		public override void VisitStringLiteral(StringLiteralSyntax node)
		{
			this.VisitToken(node.StringLiteral);
		}
		
		public override void VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
			this.VisitToken(node.ContextualKeywords);
		}
    }
}


// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Soal.Syntax
{
	public class SoalSyntaxKind : SoalTokensSyntaxKind
	{
        public static new readonly SoalSyntaxKind __FirstToken;
        public static new readonly SoalSyntaxKind __LastToken;
        public static new readonly SoalSyntaxKind __FirstFixedToken;
        public static new readonly SoalSyntaxKind __LastFixedToken;
        public static readonly SoalSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly SoalSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string Name = nameof(Name);
		public const string QualifiedName = nameof(QualifiedName);
		public const string Qualifier = nameof(Qualifier);
		public const string IdentifierList = nameof(IdentifierList);
		public const string QualifierList = nameof(QualifierList);
		public const string AnnotationList = nameof(AnnotationList);
		public const string ReturnAnnotationList = nameof(ReturnAnnotationList);
		public const string Annotation = nameof(Annotation);
		public const string ReturnAnnotation = nameof(ReturnAnnotation);
		public const string AnnotationHead = nameof(AnnotationHead);
		public const string AnnotationBody = nameof(AnnotationBody);
		public const string AnnotationPropertyList = nameof(AnnotationPropertyList);
		public const string AnnotationProperty = nameof(AnnotationProperty);
		public const string AnnotationPropertyValue = nameof(AnnotationPropertyValue);
		public const string NamespaceDeclaration = nameof(NamespaceDeclaration);
		public const string NamespacePrefix = nameof(NamespacePrefix);
		public const string NamespaceUri = nameof(NamespaceUri);
		public const string NamespaceBody = nameof(NamespaceBody);
		public const string Declaration = nameof(Declaration);
		public const string EnumDeclaration = nameof(EnumDeclaration);
		public const string EnumBody = nameof(EnumBody);
		public const string EnumLiterals = nameof(EnumLiterals);
		public const string EnumLiteral = nameof(EnumLiteral);
		public const string StructDeclaration = nameof(StructDeclaration);
		public const string StructBody = nameof(StructBody);
		public const string PropertyDeclaration = nameof(PropertyDeclaration);
		public const string DatabaseDeclaration = nameof(DatabaseDeclaration);
		public const string DatabaseBody = nameof(DatabaseBody);
		public const string EntityReference = nameof(EntityReference);
		public const string InterfaceDeclaration = nameof(InterfaceDeclaration);
		public const string InterfaceBody = nameof(InterfaceBody);
		public const string OperationDeclaration = nameof(OperationDeclaration);
		public const string OperationHead = nameof(OperationHead);
		public const string ParameterList = nameof(ParameterList);
		public const string Parameter = nameof(Parameter);
		public const string OperationResult = nameof(OperationResult);
		public const string ThrowsList = nameof(ThrowsList);
		public const string ComponentDeclaration = nameof(ComponentDeclaration);
		public const string ComponentBody = nameof(ComponentBody);
		public const string ComponentElements = nameof(ComponentElements);
		public const string ComponentElement = nameof(ComponentElement);
		public const string ComponentService = nameof(ComponentService);
		public const string ComponentReference = nameof(ComponentReference);
		public const string ComponentServiceOrReferenceEmptyBody = nameof(ComponentServiceOrReferenceEmptyBody);
		public const string ComponentServiceOrReferenceNonEmptyBody = nameof(ComponentServiceOrReferenceNonEmptyBody);
		public const string ComponentServiceOrReferenceElement = nameof(ComponentServiceOrReferenceElement);
		public const string ComponentProperty = nameof(ComponentProperty);
		public const string ComponentImplementation = nameof(ComponentImplementation);
		public const string ComponentLanguage = nameof(ComponentLanguage);
		public const string CompositeDeclaration = nameof(CompositeDeclaration);
		public const string CompositeBody = nameof(CompositeBody);
		public const string AssemblyDeclaration = nameof(AssemblyDeclaration);
		public const string CompositeElements = nameof(CompositeElements);
		public const string CompositeElement = nameof(CompositeElement);
		public const string CompositeComponent = nameof(CompositeComponent);
		public const string CompositeWire = nameof(CompositeWire);
		public const string WireSource = nameof(WireSource);
		public const string WireTarget = nameof(WireTarget);
		public const string DeploymentDeclaration = nameof(DeploymentDeclaration);
		public const string DeploymentBody = nameof(DeploymentBody);
		public const string DeploymentElements = nameof(DeploymentElements);
		public const string DeploymentElement = nameof(DeploymentElement);
		public const string EnvironmentDeclaration = nameof(EnvironmentDeclaration);
		public const string EnvironmentBody = nameof(EnvironmentBody);
		public const string RuntimeDeclaration = nameof(RuntimeDeclaration);
		public const string RuntimeReference = nameof(RuntimeReference);
		public const string AssemblyReference = nameof(AssemblyReference);
		public const string DatabaseReference = nameof(DatabaseReference);
		public const string BindingDeclaration = nameof(BindingDeclaration);
		public const string BindingBody = nameof(BindingBody);
		public const string BindingLayers = nameof(BindingLayers);
		public const string TransportLayer = nameof(TransportLayer);
		public const string HttpTransportLayer = nameof(HttpTransportLayer);
		public const string HttpTransportLayerEmptyBody = nameof(HttpTransportLayerEmptyBody);
		public const string HttpTransportLayerNonEmptyBody = nameof(HttpTransportLayerNonEmptyBody);
		public const string RestTransportLayer = nameof(RestTransportLayer);
		public const string RestTransportLayerEmptyBody = nameof(RestTransportLayerEmptyBody);
		public const string RestTransportLayerNonEmptyBody = nameof(RestTransportLayerNonEmptyBody);
		public const string WebSocketTransportLayer = nameof(WebSocketTransportLayer);
		public const string WebSocketTransportLayerEmptyBody = nameof(WebSocketTransportLayerEmptyBody);
		public const string WebSocketTransportLayerNonEmptyBody = nameof(WebSocketTransportLayerNonEmptyBody);
		public const string HttpTransportLayerProperties = nameof(HttpTransportLayerProperties);
		public const string HttpSslProperty = nameof(HttpSslProperty);
		public const string HttpClientAuthenticationProperty = nameof(HttpClientAuthenticationProperty);
		public const string EncodingLayer = nameof(EncodingLayer);
		public const string SoapEncodingLayer = nameof(SoapEncodingLayer);
		public const string SoapEncodingLayerEmptyBody = nameof(SoapEncodingLayerEmptyBody);
		public const string SoapEncodingLayerNonEmptyBody = nameof(SoapEncodingLayerNonEmptyBody);
		public const string XmlEncodingLayer = nameof(XmlEncodingLayer);
		public const string XmlEncodingLayerEmptyBody = nameof(XmlEncodingLayerEmptyBody);
		public const string XmlEncodingLayerNonEmptyBody = nameof(XmlEncodingLayerNonEmptyBody);
		public const string JsonEncodingLayer = nameof(JsonEncodingLayer);
		public const string JsonEncodingLayerEmptyBody = nameof(JsonEncodingLayerEmptyBody);
		public const string JsonEncodingLayerNonEmptyBody = nameof(JsonEncodingLayerNonEmptyBody);
		public const string SoapEncodingProperties = nameof(SoapEncodingProperties);
		public const string SoapVersionProperty = nameof(SoapVersionProperty);
		public const string SoapMtomProperty = nameof(SoapMtomProperty);
		public const string SoapStyleProperty = nameof(SoapStyleProperty);
		public const string ProtocolLayer = nameof(ProtocolLayer);
		public const string ProtocolLayerKind = nameof(ProtocolLayerKind);
		public const string WsAddressing = nameof(WsAddressing);
		public const string EndpointDeclaration = nameof(EndpointDeclaration);
		public const string EndpointBody = nameof(EndpointBody);
		public const string EndpointProperties = nameof(EndpointProperties);
		public const string EndpointProperty = nameof(EndpointProperty);
		public const string EndpointBindingProperty = nameof(EndpointBindingProperty);
		public const string EndpointAddressProperty = nameof(EndpointAddressProperty);
		public const string ReturnType = nameof(ReturnType);
		public const string TypeReference = nameof(TypeReference);
		public const string SimpleType = nameof(SimpleType);
		public const string NulledType = nameof(NulledType);
		public const string ReferenceType = nameof(ReferenceType);
		public const string ObjectType = nameof(ObjectType);
		public const string ValueType = nameof(ValueType);
		public const string VoidType = nameof(VoidType);
		public const string OnewayType = nameof(OnewayType);
		public const string OperationReturnType = nameof(OperationReturnType);
		public const string NullableType = nameof(NullableType);
		public const string NonNullableType = nameof(NonNullableType);
		public const string NonNullableArrayType = nameof(NonNullableArrayType);
		public const string ArrayType = nameof(ArrayType);
		public const string SimpleArrayType = nameof(SimpleArrayType);
		public const string NulledArrayType = nameof(NulledArrayType);
		public const string ConstantValue = nameof(ConstantValue);
		public const string TypeofValue = nameof(TypeofValue);
		public const string Identifier = nameof(Identifier);
		public const string Identifiers = nameof(Identifiers);
		public const string Literal = nameof(Literal);
		public const string NullLiteral = nameof(NullLiteral);
		public const string BooleanLiteral = nameof(BooleanLiteral);
		public const string IntegerLiteral = nameof(IntegerLiteral);
		public const string DecimalLiteral = nameof(DecimalLiteral);
		public const string ScientificLiteral = nameof(ScientificLiteral);
		public const string StringLiteral = nameof(StringLiteral);
		public const string ContextualKeywords = nameof(ContextualKeywords);

		protected SoalSyntaxKind(string name)
            : base(name)
        {
        }

        protected SoalSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static SoalSyntaxKind()
        {
            EnumObject.AutoInit<SoalSyntaxKind>();
            __FirstToken = KNamespace;
            __LastToken = LCommentStart;
            __FirstFixedToken = KNamespace;
            __LastFixedToken = LCommentStart;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = ContextualKeywords;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator SoalSyntaxKind(string name)
        {
            return FromString<SoalSyntaxKind>(name);
        }

        public static explicit operator SoalSyntaxKind(int value)
        {
            return FromIntUnsafe<SoalSyntaxKind>(value);
        }

	}
}


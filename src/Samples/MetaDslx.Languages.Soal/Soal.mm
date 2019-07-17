namespace MetaDslx.Languages.Soal.Symbols
{
	metamodel Soal(Uri="http://MetaDslx.Languages.Soal/1.0");

	const PrimitiveType Object;
	const PrimitiveType String;
	const PrimitiveType Int;
	const PrimitiveType Long;
	const PrimitiveType Float;
	const PrimitiveType Double;
	const PrimitiveType Byte;
	const PrimitiveType Bool;
	const PrimitiveType Void;
	const PrimitiveType Date;
	const PrimitiveType Time;
	const PrimitiveType DateTime;
	const PrimitiveType TimeSpan;

	/*
	Represents an annotated element.
	*/
	abstract class AnnotatedElement
	{
		// List of annotations
		containment list<Annotation> Annotations; 
	}

	class Annotation : NamedElement
	{
		containment list<AnnotationProperty> Properties;
	}

	class AnnotationProperty : NamedElement
	{
		object Value;
	}

	abstract class DocumentedElement
	{
		string Documentation;
		list<string> GetDocumentationLines();
	}

	abstract class NamedElement : DocumentedElement
	{
		[Name]
		string Name;
	}

	abstract class TypedElement
	{
		[Type]
		SoalType Type;
	}

	[Type]
	abstract class SoalType
	{
	}

	class NamedType : SoalType, NamedElement
	{
	}

	abstract class Declaration : NamedElement, AnnotatedElement
	{
		Namespace Namespace;
		derived string FullName;
	}

	[Scope]
	class Namespace : Declaration
	{
		string Uri;
		string Prefix;
		containment list<Declaration> Declarations;
	}

	association Namespace.Declarations with Declaration.Namespace;
	
	class ArrayType : SoalType
	{
		SoalType InnerType;
	}

	class NullableType : SoalType
	{
		SoalType InnerType;
	}

	class NonNullableType : SoalType
	{
		SoalType InnerType;
	}

	class PrimitiveType : SoalType, Declaration
	{
		bool Nullable;
	}

	[Scope]
	class Enum : SoalType, Declaration
	{
		[BaseScope]
		Enum BaseType;
		containment list<EnumLiteral> EnumLiterals;
	}

	class EnumLiteral : NamedElement, TypedElement, AnnotatedElement
	{
		Enum Enum redefines TypedElement.Type;
	}

	association EnumLiteral.Enum with Enum.EnumLiterals;

	class Property : NamedElement, TypedElement, AnnotatedElement
	{
	}

	[Scope]
	class Struct : SoalType, Declaration
	{
		[BaseScope]
		Struct BaseType;
		containment list<Property> Properties;
	}

	[Scope]
	class Interface : SoalType, Declaration
	{
		containment list<Operation> Operations;
	}

	class Database : Interface
	{
		list<Struct> Entities;
	}

	[Scope]
	class Operation : NamedElement, AnnotatedElement
	{
		string Action;
		containment list<InputParameter> Parameters;
		containment OutputParameter Result;
		list<Struct> Exceptions;
	}

	class InputParameter : NamedElement, TypedElement, AnnotatedElement
	{
	}

	class OutputParameter : TypedElement, AnnotatedElement
	{
		bool IsOneway;
	}

	[Scope]
	class Component : Declaration
	{
		[BaseScope]
		Component BaseComponent;
		bool IsAbstract;
		containment list<Port> Ports;
		containment list<Service> Services subsets Ports;
		containment list<Reference> References subsets Ports;
		containment list<Property> Properties;
		containment Implementation Implementation;
		containment ProgrammingLanguage Language;
	}

	class Composite : Component
	{
		list<Component> Components;
		containment list<Wire> Wires;
	}

	class Assembly : Composite
	{
	}

	class Wire
	{
		Port Source;
		Port Target;
	}

	class Port : NamedElement
	{
		Component Component;
		Interface Interface;
		Binding Binding;
	}

	association Port.Component with Component.Ports;

	class Service : Port
	{
	}

	class Reference : Port
	{
	}

	class Implementation : NamedElement
	{
	}
	
	class ProgrammingLanguage : NamedElement
	{
	}
	
	class Deployment : Declaration
	{
		containment list<Environment> Environments;
		containment list<Wire> Wires;
	}

	class Environment : NamedElement
	{
		containment Runtime Runtime;
		list<Interface> Databases;
		list<Assembly> Assemblies;
	}

	class Runtime : NamedElement
	{
	}

	class Binding : Declaration
	{
		containment TransportBindingElement Transport;
		containment list<EncodingBindingElement> Encodings;
		containment list<ProtocolBindingElement> Protocols;
	}

	class Endpoint : Declaration
	{
		Interface Interface;
		Binding Binding;
		string Address;
	}

	abstract class BindingElement : NamedElement
	{
	}

	abstract class TransportBindingElement : BindingElement
	{
	}

	abstract class EncodingBindingElement : BindingElement
	{
	}

	abstract class ProtocolBindingElement : BindingElement
	{
	}


	class HttpTransportBindingElement : TransportBindingElement
	{
		bool Ssl;
		bool ClientAuthentication;
	}

	class RestTransportBindingElement : TransportBindingElement
	{
	}

	class WebSocketTransportBindingElement : TransportBindingElement
	{
	}

	
	enum SoapVersion
	{
		Soap11,
		Soap12
	}
	
	enum SoapEncodingStyle
	{
		DocumentWrapped,
		DocumentLiteral,
		RpcLiteral,
		RpcEncoded
	}

	class SoapEncodingBindingElement : EncodingBindingElement
	{
		SoapEncodingStyle Style;
		SoapVersion Version;
		bool Mtom;
	}

	class XmlEncodingBindingElement : EncodingBindingElement
	{
	}

	class JsonEncodingBindingElement : EncodingBindingElement
	{
	}

	
	abstract class WsProtocolBindingElement : ProtocolBindingElement
	{
	}

	class WsAddressingBindingElement : WsProtocolBindingElement
	{
	}


}

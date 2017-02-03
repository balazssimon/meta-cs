namespace MetaDslx.Languages.Soal.Symbols
{
	metamodel Soal(Uri="http://MetaDslx.Languages.Soal/1.0");

	const PrimitiveType Object;// = new PrimitiveType() { Name = "object", Nullable = true };
	const PrimitiveType String;// = new PrimitiveType() { Name = "string", Nullable = true };
	const PrimitiveType Int;// = new PrimitiveType() { Name = "int" };
	const PrimitiveType Long;// = new PrimitiveType() { Name = "long" };
	const PrimitiveType Float;// = new PrimitiveType() { Name = "float" };
	const PrimitiveType Double;// = new PrimitiveType() { Name = "double" };
	const PrimitiveType Byte;// = new PrimitiveType() { Name = "byte" };
	const PrimitiveType Bool;// = new PrimitiveType() { Name = "bool" };
	const PrimitiveType Void;// = new PrimitiveType() { Name = "void" };
	const PrimitiveType Date;// = new PrimitiveType() { Name = "Date" };
	const PrimitiveType Time;// = new PrimitiveType() { Name = "Time" };
	const PrimitiveType DateTime;// = new PrimitiveType() { Name = "DateTime" };
	const PrimitiveType TimeSpan;// = new PrimitiveType() { Name = "TimeSpan" };

	
	abstract class AnnotatedElement
	{
		containment list<Annotation> Annotations;
		//Annotation AddAnnotation(string name);
		bool HasAnnotation(string name);
		Annotation GetAnnotation(string name);
		list<Annotation> GetAnnotations(string name);
		bool HasAnnotationProperty(string annotationName, string propertyName);
		object GetAnnotationPropertyValue(string annotationName, string propertyName);
		//AnnotationProperty SetAnnotationPropertyValue(string annotationName, string propertyName, object propertyValue);
	}

	class Annotation : NamedElement
	{
		AnnotatedElement AnnotatedElement;
		containment list<AnnotationProperty> Properties;
		bool HasProperty(string name);
		AnnotationProperty GetProperty(string name);
		object GetPropertyValue(string name);
		//AnnotationProperty SetPropertyValue(string name, object value);
	}

	association Annotation.AnnotatedElement with AnnotatedElement.Annotations;

	class AnnotationProperty : NamedElement
	{
		object Value;
	}
	
	abstract class NamedElement
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

	[Scope]
	class Namespace : Declaration
	{
		string Uri;
		string Prefix;
		derived string FullName;
		[ScopeEntry]
		containment list<Declaration> Declarations;
	}

	abstract class Declaration : NamedElement, AnnotatedElement
	{
		Namespace Namespace;
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
		[InheritedScope]
		Enum BaseType;
		[ScopeEntry]
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
		[InheritedScope]
		Struct BaseType;
		[ScopeEntry]
		containment list<Property> Properties;
	}

	[Scope]
	class Interface : SoalType, Declaration
	{
		[ScopeEntry]
		containment list<Operation> Operations;
	}

	class Database : Interface
	{
		[ScopeEntry]
		list<Struct> Entities;
	}

	class Operation : NamedElement, AnnotatedElement
	{
		string Action;
		containment list<InputParameter> Parameters;
		readonly OutputParameter Result;
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
		[InheritedScope]
		Component BaseComponent;
		bool IsAbstract;
		[ScopeEntry]
		containment list<Port> Ports;
		containment list<Service> Services subsets Ports;
		containment list<Reference> References subsets Ports;
		[ScopeEntry]
		containment list<Property> Properties;
		containment Implementation Implementation;
		containment Language Language;
	}

	class Composite : Component
	{
		[ScopeEntry]
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

	class Port
	{
		Component Component;
		[Name]
		derived string Name;
		string OptionalName;
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
	
	class Language : NamedElement
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
		list<Database> Databases;
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

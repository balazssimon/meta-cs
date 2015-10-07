namespace MetaDslx.Soal
{
	metamodel Soal(Uri="http://MetaDslx.Soal/1.0");

	const PrimitiveType Object = new PrimitiveType() { Name = "object" };
	const PrimitiveType String = new PrimitiveType() { Name = "string" };
	const PrimitiveType Int = new PrimitiveType() { Name = "int" };
	const PrimitiveType Long = new PrimitiveType() { Name = "long" };
	const PrimitiveType Float = new PrimitiveType() { Name = "float" };
	const PrimitiveType Double = new PrimitiveType() { Name = "double" };
	const PrimitiveType Byte = new PrimitiveType() { Name = "byte" };
	const PrimitiveType Bool = new PrimitiveType() { Name = "bool" };
	const PrimitiveType Void = new PrimitiveType() { Name = "void" };
	const PrimitiveType DateTime = new PrimitiveType() { Name = "DateTime" };
	const PrimitiveType TimeSpan = new PrimitiveType() { Name = "TimeSpan" };

	
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
		[ScopeEntry]
		containment list<Declaration> Declarations;
	}

	abstract class Declaration : NamedElement
	{
		Namespace Namespace;
	}

	association Namespace.Declarations with Declaration.Namespace;

	class ArrayType : SoalType
	{
		ArrayType()
		{
			Namespace = InnerType is Declaration ? ((Declaration)InnerType).Namespace : null;
		}

		SoalType InnerType;
		derived Namespace Namespace;
	}

	class NullableType : SoalType
	{
		NullableType()
		{
			Namespace = InnerType is Declaration ? ((Declaration)InnerType).Namespace : null;
		}

		SoalType InnerType;
		derived Namespace Namespace;
	}

	class PrimitiveType : SoalType, NamedElement
	{
	}

	[Scope]
	class Enum : SoalType, Declaration
	{
		[ScopeEntry]
		containment list<EnumLiteral> EnumLiterals;
	}

	class EnumLiteral : NamedElement, TypedElement
	{
		EnumLiteral()
		{
			Type = Enum;
		}

		Enum Enum;
	}

	association EnumLiteral.Enum with Enum.EnumLiterals;

	abstract class StructuredType : SoalType, Declaration
	{
		containment list<Property> Properties;
	}

	class Property : NamedElement, TypedElement
	{
		StructuredType Parent;
	}

	association StructuredType.Properties with Property.Parent;

	class Struct : StructuredType
	{
		Struct BaseType;
	}

	class Exception : StructuredType
	{
		Exception BaseType;
	}

	[Scope]
	class Interface : SoalType, Declaration
	{
		[ScopeEntry]
		containment list<Operation> Operations;
	}

	class Operation : NamedElement
	{
		Interface Parent;
		bool IsOneway;
		SoalType ReturnType;
		containment list<Parameter> Parameters;
		list<Exception> Exceptions;
	}

	association Interface.Operations with Operation.Parent;

	class Parameter : NamedElement, TypedElement
	{
		Operation Operation;
	}

	association Operation.Parameters with Parameter.Operation;

	class Binding : Declaration
	{
		TransportBindingElement Transport;
		list<EncodingBindingElement> Encodings;
		list<ProtocolBindingElement> Protocols;
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

	class SoapEncodingBindingElement : EncodingBindingElement
	{
		SoapVersion Version;
		bool MtomEnabled;
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

namespace MetaDslx.Languages.MetaCompiler.Model
{
	metamodel MetaCompiler(Uri="http://metadslx.core/1.0"); 

	const PrimitiveType Object = "object";
	const PrimitiveType String = "string";
	const PrimitiveType Int = "int";
	const PrimitiveType Long = "long";
	const PrimitiveType Float = "float";
	const PrimitiveType Double = "double";
	const PrimitiveType Byte = "byte";
	const PrimitiveType Bool = "bool";
	const PrimitiveType Void = "void";
	
	class Compiler : Declaration
	{
	}

	abstract class Element
	{
		list<Annotation> Annotations; 
	}

	abstract class NamedElement
	{
		[Name]
		string Name;
	}

	abstract class TypedElement : Element
	{
		[Type]
		DataType Type;
	}

	[Type]
	abstract class DataType
	{
		bool ConformsTo(DataType type);
	}

	class NamedType : DataType, Declaration
	{
	}

	class Annotation : NamedElement
	{
	}

	abstract class Declaration : NamedElement
	{
		Namespace Namespace;
		derived string FullName;
	}
	
	[Scope]
	class Namespace : Declaration
	{
		containment list<Declaration> Declarations;
	}

	association Namespace.Declarations with Declaration.Namespace;

	class PrimitiveType : NamedType
	{
		bool ConformsTo(DataType type);
	}

	class TypeDefType : NamedType
	{
		string DotNetType;
	}

	class NullableType : NamedType
	{
		DataType InnerType;
	}

	class GenericType : NamedType
	{
		DataType Type;
		list<DataType> TypeArguments;
	}

	[Scope]
	class EnumType : NamedType
	{
		containment list<EnumLiteral> EnumLiterals;
		containment list<Operation> Operations;
	}

	class EnumLiteral : NamedElement, TypedElement
	{
		EnumType Enum redefines TypedElement.Type;
	}

	association EnumLiteral.Enum with EnumType.EnumLiterals;

	enum ClassKind
	{
		Class,
		Symbol,
		Binder
	}

	[Scope]
	class Class : NamedType
	{
		ClassKind Kind;
		bool IsAbstract;
		[BaseScope]
		list<Class> SuperClasses;
		containment list<Property> Properties;
		containment list<Operation> Operations;
		bool ConformsTo(DataType type);
		list<Class> GetAllSuperClasses(bool includeSelf);
		list<Property> GetAllSuperProperties(bool includeSelf);
		list<Operation> GetAllSuperOperations(bool includeSelf);
		list<Property> GetAllProperties();
		list<Operation> GetAllOperations();
		list<Property> GetAllFinalProperties();
		list<Operation> GetAllFinalOperations();
	}

	class Phase : Declaration
	{
		bool IsLocked;
		Phase JoinsPhase;
		list<Phase> AfterPhases;
		list<Phase> BeforePhases;
	}

	[LocalScope]
	class Operation : NamedElement
	{
		Class Class;
		EnumType Enum;
		containment list<Parameter> Parameters;
		DataType ReturnType;
		bool ConformsTo(Operation operation);
	}

	association Operation.Class with Class.Operations;
	association Operation.Enum with EnumType.Operations;

	class Parameter : NamedElement, TypedElement
	{
		Operation Operation;
	}

	association Operation.Parameters with Parameter.Operation;

	enum PropertyKind
	{
		Normal,
		Readonly,
		Lazy,
		Derived
	}

	class Property : NamedElement, TypedElement
	{
		PropertyKind Kind;
		Class Class;
		string DefaultValue;
		Phase Phase;
		bool ConformsTo(Property property);
	}

	association Property.Class with Class.Properties;
}

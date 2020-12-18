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

	const Phase None = "None";
	const Phase All = "All";

	enum VisibilityKind
	{
		None,
		Public,
		Protected,
		Private,
		Internal
	}

	/*enum SymbolModifierKind
	{
		None,
		Base,
		Meta,
		Source
	}*/
	
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

	class ArrayType : DataType
	{
		DataType InnerType;
	}

	class DictionaryType : DataType
	{
		DataType KeyType;
		DataType ValueType;
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
		ClassKind Kind = "ClassKind.Class";
		VisibilityKind Visibility = "VisibilityKind.Public";
		bool IsAbstract;
		bool IsStatic;
		bool IsSealed;
		bool IsPartial;

		[BaseScope]
		list<Class> SuperClasses;
		containment list<Property> Properties;
		containment list<Operation> Operations;

		bool ConformsTo(DataType type);
		list<Class> GetAllSuperClasses(bool includeSelf);
		list<Property> GetAllProperties(bool includeSelf);
		list<Operation> GetAllOperations(bool includeSelf);
		list<Property> GetAllFinalProperties();
		list<Operation> GetAllFinalOperations();
	}

	class Symbol : Class
	{
		ClassKind Kind = "ClassKind.Symbol";
		list<Phase> Phases;
		bool IsVisit;
		//SymbolModifierKind SymbolModifier;
		list<Phase> GetPhases();
		list<Phase> GetAllPhases(bool includeSelf);
	}

	class Phase : Declaration
	{
		bool IsLocked;
		Phase JoinsPhase;
		list<Phase> AfterPhases;
		list<Phase> BeforePhases;
	}

	class MemberDeclaration : NamedElement
	{
		PropertyKind Kind = "PropertyKind.Normal";
		VisibilityKind Visibility = "VisibilityKind.Public";
		bool IsSealed;
		bool IsPartial;
		bool IsStatic;
		bool IsAbstract;
		bool IsVirtual;
		bool IsOverride;
		bool IsNew;
	}

	[LocalScope]
	class Operation : MemberDeclaration
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
		string DefaultValue;
	}

	association Operation.Parameters with Parameter.Operation;

	enum PropertyKind
	{
		Normal,
		Readonly,
		Lazy,
		Derived
	}

	class Property : MemberDeclaration, TypedElement
	{
		Class Class;
		string DefaultValue;
		Phase Phase;
		bool ConformsTo(Property property);
	}

	association Property.Class with Class.Properties;
}

namespace EntitiesSample
{
	metamodel Entities(Uri="http://metadslx.entities.sample/1.0"); 

	abstract class NamedElement
	{
		[Name]
		string Name;
	}

	[Type]
	abstract class Type
	{
	}

	abstract class Declaration : NamedElement
	{
		Namespace Namespace;
	}

	[Scope]
	class Namespace : Declaration
	{
		containment list<Declaration> Declarations;
	}

	association Namespace.Declarations with Declaration.Namespace;

	enum PrimitiveTypeKind
	{
		Int,
		String,
		Bool
	}

	class PrimitiveType : Type
	{
		PrimitiveTypeKind Kind;
	}

	[Scope]
	class Entity : Declaration, Type
	{
		bool IsAbstract;
		[BaseScope]
		list<Entity> BaseEntities;
		containment list<Field> Fields;
	}
	
	class Field : NamedElement
	{
		[Type]
		Type Type;
		Entity Entity;
		set<Field> Opposite;
	}

	association Field.Entity with Entity.Fields;
	association Field.Opposite with Field.Opposite;
}

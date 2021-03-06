namespace EntitiesSample.Sample
{
	metamodel Entities(Uri="http://metadslx.entities.sample/1.0"); 
	
	abstract class NamedElement
	{
		[Name]
		string Name;
	}

	[Type]
	abstract class EType
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
	
	association Namespace.Declarations with EntitiesSample.Sample.Declaration.Namespace;

	enum PrimitiveTypeKind
	{
		Int,
		String,
		Bool
	}

	class PrimitiveType : EType
	{
		PrimitiveTypeKind Kind;
	}

	[Scope]
	class Entity : Declaration, EType
	{
		bool IsAbstract;
		[BaseScope]
		list<Entity> BaseEntities;
		containment list<Field> Fields;
	}
	
	class Field : NamedElement
	{
		[Type]
		EType Type;
		Entity Entity;
		set<Field> Opposite;
	}

	association Field.Entity with Entity.Fields;
	association Field.Opposite with Field.Opposite;
}

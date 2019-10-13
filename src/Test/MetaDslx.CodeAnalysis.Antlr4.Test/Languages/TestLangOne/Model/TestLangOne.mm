namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Model
{
	metamodel TestLangOne;

	class NamedElement
	{
		[Name]
		string Name;
	}

	[Type]
	class Type
	{
	}

	class TypedElement
	{
		[Type]
		Type Type;
	}

	class Declaration
	{
		Declaration Owner;
		containment list<Declaration> Declarations;
	}

	association Declaration.Owner with Declaration.Declarations;

	class NamedDeclaration : Declaration, NamedElement
	{
	}

	[Scope]
	class Scope : Declaration
	{
	}

	class Namespace : Scope, NamedDeclaration
	{
	}

	class Class : Type, NamedDeclaration, Scope
	{
		containment list<Property> Properties subsets Declaration.Declarations;
	}

	class Member : NamedDeclaration
	{
	}

	class Property : NamedDeclaration, TypedElement
	{
		Class Class;
	}

	class Vertex : NamedDeclaration
	{
	}

	class Arrow : Declaration
	{
		Vertex Source;
		Vertex Target;
	}
}

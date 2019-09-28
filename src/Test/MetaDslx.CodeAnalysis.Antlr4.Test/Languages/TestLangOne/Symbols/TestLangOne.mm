namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Symbols
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
		containment list<Declaration> Members;
	}

	association Declaration.Owner with Declaration.Members;

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
		containment list<Property> Properties subsets Declaration.Members;
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

	class Edge : Declaration
	{
		Vertex Start;
		Vertex End;
	}
}

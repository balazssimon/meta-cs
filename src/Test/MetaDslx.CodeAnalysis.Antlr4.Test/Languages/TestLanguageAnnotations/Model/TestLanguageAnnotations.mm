namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model
{
	using MetaDslx.CodeAnalysis.Symbols;

	metamodel TestLanguageAnnotations;

	[symbol: DeclaredSymbol]
	class NamedElement
	{
		[symbol: Name]
		string Name;
	}

	[symbol: TypeSymbol]
	class Type
	{
	}

	class TypedElement
	{
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

	class Scope : Declaration
	{
	}

	[symbol: NamespaceSymbol]
	class Namespace : Scope, NamedDeclaration
	{
	}

	[symbol: NamedTypeSymbol]
	class Class : Type, NamedDeclaration, Scope
	{
		[symbol: Members]
		containment list<Property> Properties subsets Declaration.Declarations;
	}

	[symbol: MemberSymbol]
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

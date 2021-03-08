namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model
{
	using MetaDslx.CodeAnalysis.Symbols;

	metamodel TestLanguageAnnotations;

	class NamedElement[DeclaredSymbol]
	{
		string Name[Name];
	}

	class Type[TypeSymbol]
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

	class Namespace[NamespaceSymbol] : Scope, NamedDeclaration
	{
	}

	class Class[NamedTypeSymbol] : Type, NamedDeclaration, Scope
	{
		containment list<Property> Properties[Members] subsets Declaration.Declarations;
	}

	class Member[MemberSymbol] : NamedDeclaration
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

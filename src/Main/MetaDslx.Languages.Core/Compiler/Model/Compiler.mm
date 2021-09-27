namespace MetaDslx.Languages.Compiler.Model
{
	using MetaDslx.Languages.Meta.Model;
	using MetaDslx.CodeAnalysis.Symbols;

	metamodel Compiler(Uri="http://MetaDslx.Languages.Compiler/1.0",MajorVersion=1,MinorVersion=0);

	[symbol: Namespace]
	class Namespace : NamedElement
	{
		[property: Members]
		containment list<NamedElement> Members;
	}

	[symbol: Member]
	class NamedElement
	{
		[property: Name]
		string Name;
	}

	[symbol: NamedType]
	class Grammar : NamedElement
	{
		containment GrammarOptions Options;
		[property: Members]
		containment list<Rule> Rules;
	}

	class GrammarOptions
	{
		bool IsCaseInsensitive;
		bool IsWhitespaceIndented;
	}

	[symbol: NamedType]
	abstract class Rule : NamedElement
	{
		SystemType DefinedModelObject;
		[property: Members]
		containment list<RuleAlternative> Alternatives;
	}

	class RuleAlternative : NamedElement
	{
		containment list<RuleElement> Elements;
	}

	[symbol: NamedType]
	class RuleElement : NamedElement
	{
		bool IsNegated;
		[property: Members]
		Element Element;
		AssignmentOperator AssignmentOperator;
		Multiplicity Multiplicity;
	}

	[symbol: Member]
	abstract class Element
	{
	}

	class RuleReference : Element
	{
		Rule Rule;
	}

	class RuleBlock : Rule, Element
	{
	}

	class EofElement : Element
	{
	}

	class FixedElement : Element
	{
		string Value;
	}
	
	class WildcardElement : Element
	{
	}

	class RangeElement : Element
	{
		containment FixedElement Start;
		containment FixedElement End;
	}

	class ParserRule : Rule
	{
	}

	class LexerRule : Rule
	{
		bool IsFragment;
		bool IsHidden;
	}

	enum Multiplicity
	{
		ExactlyOne,
		ZeroOrOne,
		ZeroOrMore,
		OneOrMore,
		NonGreedyZeroOrOne,
		NonGreedyZeroOrMore,
		NonGreedyOneOrMore
	}

	enum AssignmentOperator
	{
		Assign,
		QuestionAssign,
		NegatedAssign,
		PlusAssign
	}
}

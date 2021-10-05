namespace MetaDslx.Languages.Compiler.Model
{
	using MetaDslx.Languages.Meta.Model;
	using MetaDslx.CodeAnalysis.Symbols;

	metamodel Compiler(Uri="http://MetaDslx.Languages.Compiler/1.0",MajorVersion=1,MinorVersion=0);

	class AnnotatedElement
	{
		containment list<Annotation> Annotations;
	}

	class Annotation : NamedElement
	{
		[property: Members]
		containment list<AnnotationProperty> Properties;
	}

	class AnnotationProperty : NamedElement
	{
		string Value;
	}

	[symbol: Namespace]
	class Namespace : NamedElement
	{
		[property: Members]
		containment list<NamedElement> Members;
	}

	[symbol: Member]
	class NamedElement : AnnotatedElement
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
	}

	class ParserRule : Rule
	{
		SystemType DefinedModelObject;
	}

	class ParserRuleAlt : ParserRule
	{
		[property: Members]
		containment list<ParserRule> Alternatives;
	}

	class ParserRuleSimple : ParserRule
	{
		[property: Members]
		containment list<ParserRuleNamedElement> Elements;
	}

	[symbol: NamedType]
	class ParserRuleNamedElement : NamedElement
	{
		bool IsNegated;
		[property: Members]
		containment ParserRuleElement Element;
		AssignmentOperator AssignmentOperator;
		Multiplicity Multiplicity;
	}

	[symbol: Member]
	abstract class ParserRuleElement : AnnotatedElement
	{
	}

	class ParserRuleReferenceElement : ParserRuleElement
	{
		Rule Rule;
	}

	class ParserRuleEofElement : ParserRuleElement
	{
	}

	class ParserRuleFixedElement : ParserRuleElement
	{
		string Value;
	}
	
	class ParserRuleWildcardElement : ParserRuleElement
	{
	}

	class ParserRuleBlockElement : ParserRuleElement, ParserRuleSimple
	{
	}

	class LexerRule : Rule
	{
		bool IsFragment;
		bool IsHidden;
		SystemType ValueType;
		object Value;
		[property: Members]
		containment list<LexerRuleAlternative> Alternatives;
	}

	[symbol: Member]
	class LexerRuleAlternative
	{
		[property: Members]
		containment list<LexerRuleAlternativeElement> Elements;
	}

	[symbol: Member]
	class LexerRuleAlternativeElement
	{
		bool IsNegated;
		LexerRuleElement Element;
		Multiplicity Multiplicity;
	}

	[symbol: Member]
	abstract class LexerRuleElement
	{
	}

	class LexerRuleReferenceElement : LexerRuleElement
	{
		LexerRule Rule;
	}

	class LexerRuleFixedStringElement : LexerRuleElement
	{
		string Value;
	}
	
	class LexerRuleFixedCharElement : LexerRuleElement
	{
		string Value;
	}
	
	class LexerRuleWildcardElement : LexerRuleElement
	{
	}

	class LexerRuleBlockElement : LexerRuleElement
	{
		[property: Members]
		containment list<LexerRuleAlternative> Alternatives;
	}

	class LexerRuleRangeElement : LexerRuleElement
	{
		containment LexerRuleFixedCharElement Start;
		containment LexerRuleFixedCharElement End;
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

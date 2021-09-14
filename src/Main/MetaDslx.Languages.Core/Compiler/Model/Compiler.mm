namespace MetaDslx.Languages.Compiler.Model
{
	metamodel Compiler(Uri="http://MetaDslx.Languages.Compiler/1.0",MajorVersion=1,MinorVersion=0);

	abstract class NamedElement
	{
		string Name;
	}

	class Grammar : NamedElement
	{
		list<Rule> Rules;
	}

	abstract class Rule : NamedElement
	{
	}

	abstract class RuleElement : NamedElement
	{
		Multiplicity Multiplicity;
	}

	class ParserRule : Rule
	{
		list<ParserRuleAlternative> Alternatives;
	}

	class ParserRuleAlternative
	{
		list<ParserRuleElement> Elements;
	}

	abstract class ParserRuleElement : RuleElement
	{
	}

	class ParserRuleReference : RuleElement
	{
		Rule Rule;
	}

	class ParserRuleBlock : RuleElement
	{
		list<ParserRuleAlternative> Alternatives;
	}

	class LexerRule : Rule
	{
		bool IsFragment;
		bool IsHidden;
		list<LexerRuleAlternative> Alternatives;
	}

	class LexerRuleAlternative
	{
		list<LexerRuleElement> Elements;
	}

	class LexerRuleElement : RuleElement
	{
	}

	enum Multiplicity
	{
		ExactlyOne,
		ZeroOrOne,
		ZeroOrMore,
		OneOrMore
	}

}

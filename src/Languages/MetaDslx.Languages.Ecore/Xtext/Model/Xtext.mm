namespace MetaDslx.Languages.Xtext.Model
{
	metamodel Xtext(Uri="http://www.eclipse.org/2008/Xtext"); 

	// TODO: import
	class EPackage {}
	class EClassifier {}
	class EEnumLiteral {}

	class Grammar
	{
		string Name;
		list<Grammar> UsedGrammars;
		bool DefinesHiddenTokens;
		list<AbstractRule> HiddenTokens;
		containment list<AbstractMetamodelDeclaration> MetamodelDeclarations;
		containment list<AbstractRule> Rules;
	}

	class AbstractRule
	{
		string Name;
		containment TypeRef Type;
		containment AbstractElement Alternatives;
		containment list<Annotation> Annotations;
	}

	class AbstractMetamodelDeclaration
	{
		EPackage EPackage;
		string Alias;
	}

	class GeneratedMetamodel : AbstractMetamodelDeclaration
	{
		string Name;
	}

	class ReferencedMetamodel : AbstractMetamodelDeclaration
	{
	}

	class ParserRule : AbstractRule
	{
		bool DefinesHiddenTokens;
		list<AbstractRule> HiddenTokens;
		containment list<Parameter> Parameters;
		bool Fragment;
		bool Wildcard;
	}

	class TypeRef
	{
		AbstractMetamodelDeclaration Metamodel;
		EClassifier Classifier;
	}

	class AbstractElement
	{
		string Cardinality;
		bool Predicated;
		bool FirstSetPredicated;
	}

	class Action : AbstractElement
	{
		containment TypeRef Type;
		string Feature;
		string Operator;
	}

	class Keyword : AbstractElement
	{
		string Value;
	}

	class RuleCall : AbstractElement
	{
		AbstractRule Rule;
		containment list<NamedArgument> Arguments;
		bool ExplicitlyCalled;
	}

	class Assignment : AbstractElement
	{
		string Feature;
		string Operator;
		containment AbstractElement Terminal;
	}

	class CrossReference : AbstractElement
	{
		containment TypeRef Type;
		containment AbstractElement Terminal;
	}

	class TerminalRule : AbstractElement
	{
		bool Fragment;
	}

	class AbstractNegatedToken : AbstractElement
	{
		containment AbstractElement Terminal;
	}

	class NegatedToken : AbstractNegatedToken
	{
	}

	class UntilToken : AbstractNegatedToken
	{
	}

	class Wildcard : AbstractElement
	{
	}

	class EnumRule : AbstractRule
	{
	}

	class EnumLiteralDeclaration : AbstractElement
	{
		EEnumLiteral EnumLiteral;
		containment Keyword Literal;
	}
	
	class CompoundElement : AbstractElement
	{
		containment list<AbstractElement> Elements;
	}

	class Alternatives : CompoundElement
	{
	}

	class UnorderedGroup : CompoundElement
	{
	}

	class Group : CompoundElement
	{
		containment Condition GuardCondition;
	}

	class CharacterRange : AbstractElement
	{
		containment Keyword Left;
		containment Keyword Right;
	}

	class EOF : AbstractElement
	{
	}

	class Parameter
	{
		string Name;
	}

	class NamedArgument
	{
		Parameter Parameter;
		containment Condition Value;
		bool CalledByName;
	}

	class Condition
	{
	}

	class Negation : Condition
	{
		containment Condition Value;
	}

	class CompositeCondition : Condition
	{
		containment Condition Left;
		containment Condition Right;
	}

	class Conjunction : CompositeCondition
	{
	}

	class Disjunction : CompositeCondition
	{
	}

	class ParameterReference : Condition
	{
		Parameter Parameter;
	}

	class LiteralCondition : Condition
	{
		bool True;
	}

	class Annotation
	{
		string Name;
	}
}

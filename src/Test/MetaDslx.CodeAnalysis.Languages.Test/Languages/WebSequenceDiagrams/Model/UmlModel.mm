namespace MetaDslx.CodeAnalysis.Languages.Test.Languages.WebSequenceDiagrams.Model
{
	using MetaDslx.CodeAnalysis.Symbols;

	metamodel Uml;

	class Interaction[NamespaceSymbol]
	{
		string Name[Name];
		containment list<Declaration> Declarations[Members];
	}

	class Declaration
	{
	}

	class Lifeline[MemberSymbol] : Declaration
	{
		string Name[Name];
	}

	enum MessageKind
	{
		Sync,
		Async,
		Return,
		Create
	}

	class Message : Declaration
	{
		MessageKind Kind;
		string Text;
		Lifeline Source;
		Lifeline Target;
	}

	abstract class LifelineEvent : Declaration
	{
		Lifeline Lifeline;
	}

	class Destroy : LifelineEvent
	{
	}

	class Activate : LifelineEvent
	{
	}

	class Deactivate : LifelineEvent
	{
	}

	enum FragmentKind
	{
		Loop,
		Opt,
		Alt,
		Else,
		Ref
	}

	class Fragment[NamespaceSymbol] : Declaration
	{
		FragmentKind Kind;
		string Text;
		containment list<Declaration> Declarations[Members];
	}

	class MultiFragment : Declaration
	{
		containment list<Fragment> Fragments;
	}

	class RefFragment : Fragment, Lifeline
	{
		Message Input;
		Message Output;
	}
}

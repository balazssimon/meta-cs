namespace WebSequenceDiagramsModel.Symbols
{
	metamodel Uml;

	[Scope]
	class Interaction
	{
		[Name]
		string Name;
		containment list<Declaration> Declarations;
	}

	class Declaration
	{
	}

	class Lifeline : Declaration
	{
		[Name]
		string Name;
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

	class Destroy : Declaration
	{
		Lifeline Lifeline;
	}

	enum FragmentKind
	{
		Loop,
		Opt,
		Alt,
		Else,
		Ref
	}

	class Fragment : Declaration
	{
		FragmentKind Kind;
		string Text;
		containment list<Declaration> Declarations;
	}

	class MultiFragment : Declaration
	{
		containment list<Fragment> Fragment;
	}

	class RefFragment : Fragment, Lifeline
	{
		Lifeline Input;
		Lifeline Output;
	}
}

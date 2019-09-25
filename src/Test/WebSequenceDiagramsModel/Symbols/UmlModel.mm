﻿namespace WebSequenceDiagramsModel.Symbols
{
	metamodel Uml;

	[Scope]
	class Interaction
	{
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

	[Scope]
	class Fragment : Declaration
	{
		FragmentKind Kind;
		string Text;
		containment list<Declaration> Declarations;
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

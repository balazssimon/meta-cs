namespace PilV2.Symbols
{
	metamodel Pil;

	const NamedType String = "string";
	const NamedType Bool = "bool";
	const NamedType Int = "int";
	const NamedType Object = "object";

	enum ResponseKind
	{
		Accept,
		Refuse,
		Cancel
	}

	class TypeAlias : NamedType, Declaration
	{
		PilType TargetType;
	}

	class NamedElement
	{
		[Name]
		string Name;
	}

	class CommentedElement
	{
		string Comment;
	}

	class Declaration : NamedElement
	{
	}

	[Type]
	class PilType
	{
	}

	class NamedType : PilType, NamedElement
	{
	}

	class TypedElement
	{
		[Type]
		PilType Type;
	}

	class PilEnum : NamedType, Declaration
	{
		containment list<EnumLiteral> Literals;
	}

	class EnumLiteral : NamedElement
	{
		PilEnum Enum;
	}

	association PilEnum.Literals with EnumLiteral.Enum;

	class PilObject : NamedType, Declaration
	{
		containment list<Port> Ports;
		containment list<ExternalParameter> ExternalParameters;
		containment list<Variable> Fields;
		containment list<Function> Functions;
	}

	class Port : NamedElement, TypedElement
	{
	}

	[Scope]
	class Query : NamedElement, Declaration
	{
		containment list<Variable> RequestParameters;
		containment list<Variable> AcceptParameters;
		containment list<Variable> RefuseParameters;
		containment list<Variable> CancelParameters;
		containment list<ExternalParameter> ExternalParameters;
		containment list<Variable> Fields;
		containment list<Function> Functions;
		containment list<QueryObject> Objects;
	}

	class Variable : NamedElement, TypedElement
	{
		containment Expression DefaultValue;
	}
	
	class ExternalParameter : Variable
	{
	}

	[Scope]
	class Function : NamedElement, StatementBlock, CommentedElement
	{
		PilType ReturnType;
		containment list<Variable> Parameters;
	}
	
	[Scope]
	class QueryObject : NamedType, Declaration
	{
		Query Query;
		containment list<Variable> Fields;
		containment list<Function> Functions;
		containment list<Event> Events;
	}

	association Query.Objects with QueryObject.Query;

	class Event : StatementBlock, CommentedElement
	{
		QueryObject QueryObject;
	}

	association QueryObject.Events with Event.QueryObject;

	class Trigger : Event
	{
		containment list<string> TriggerVariables;
	}

	class InputEvent : Event
	{
		containment list<RequestPort> Ports;
	}

	class RequestPort
	{
		string PortName;
		string QueryName;
	}

	class StatementBlock : CommentedElement
	{
		containment list<Statement> Statements;
	}

	class Statement : CommentedElement
	{
	}

	class VariableDeclarationStatement : Statement
	{
		containment Variable Variable;
	}

	class ForkStatement : Statement
	{
		containment Expression SwitchValue;
		containment list<Branch> Branches;
	}

	class Branch : StatementBlock
	{
		containment Expression Value;
	}

	class ForkRequestStatement : Statement
	{
		containment RequestStatement SwitchRequest;
		string SwitchVariable;
		containment list<ForkRequestBranch> Branches;
	}

	class ForkRequestBranch : StatementBlock
	{
		ResponseKind Kind;
	}
	
	class AssertStatement : Statement
	{
		containment Expression Condition;
	}

	class RequestStatement : Statement
	{
		string RequestVariable;
		string PortName;
		string QueryName;
		containment AssertStatement Assertion;
		containment list<Expression> Arguments;
	}

	class ResponseStatement : Statement
	{
		ResponseKind Kind;
		containment AssertStatement Assertion;
		containment list<Expression> Arguments;
	}

	class AssignmentStatement : Statement
	{
		string LeftSide;
		containment Expression Value;
		containment Expression UndoValue;
	}

	class Expression
	{
	}

	enum BinaryOperator
	{
		None,
		Add,
		Subtract,
		Multiply,
		Divide,
		AndAlso,
		OrElse,
		Equal,
		NotEqual,
		LessThan,
		LessThanOrEqual,
		GreaterThan,
		GreaterThanOrEqual
	}

	enum UnaryOperator
	{
		Minus,
		Negate
	}

	class BinaryExpression : Expression
	{
		containment Expression Left;
		BinaryOperator Operator;
		containment Expression Right;
	}
	
	class UnaryExpression : Expression
	{
		UnaryOperator Operator;
		containment Expression Inner;
	}
		
	class ParenthesizedExpression : Expression
	{
		containment Expression Inner;
	}
		
	class ElementOfExpression : Expression
	{
		containment Expression Value;
		list<string> Set;
	}
		
	class FunctionCallExpression : Expression
	{
		string Name;
		containment list<Expression> Arguments;
	}
		
	class LiteralExpression : Expression
	{
		object Value;
	}
		
	class ReferenceExpression : Expression
	{
		list<object> Qualifier;
	}
}

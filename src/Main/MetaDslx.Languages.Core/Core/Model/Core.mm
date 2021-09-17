namespace MetaDslx.Languages.Core.Model
{
	using MetaDslx.CodeAnalysis.Symbols;

	metamodel Core(Uri="http://MetaDslx.Languages.Core/1.0",MajorVersion=1,MinorVersion=0);

	const PrimitiveType Object;
	const PrimitiveType Void;
	const PrimitiveType Boolean;
	const PrimitiveType Char;
	const PrimitiveType SByte;
	const PrimitiveType Byte;
	const PrimitiveType Int16;
	const PrimitiveType UInt16;
	const PrimitiveType Int32;
	const PrimitiveType UInt32;
	const PrimitiveType Int64;
	const PrimitiveType UInt64;
	const PrimitiveType Decimal;
	const PrimitiveType Single;
	const PrimitiveType Double;
	const PrimitiveType String;
	const PrimitiveType SystemType;
	const PrimitiveType SystemEnum;
	const PrimitiveType SystemRange;
	const PrimitiveType SystemIndex;
	const PrimitiveType VarType;

	//=============================
	// Base classes
	//=============================

	[symbol: Symbol]
	abstract class Element
	{
		[property: Attributes]
		list<Attribute> Attributes;
	}
	
	[symbol: Attribute]
	class Attribute : NamedElement, TypedElement
	{
		[property: AttributeType]
		DataType Type redefines TypedElement.Type;
	}

	abstract class NamedElement : Element
	{
		[property: Name]
		string Name;
	}

	abstract class TypedElement : Element
	{
		DataType Type;
	}

	[symbol: Type]
	abstract class DataType : Element
	{
		derived DataType ResolvedType;
	}

	//=============================
	// Namespaces and declarations
	//=============================

	[symbol: Declared]
	abstract class Declaration : NamedElement
	{
		[property: TypeParameters]
		containment list<TypeParameter> TypeParameters;
		[property: Members]
		containment list<Declaration> Members;
	}

	abstract class TypedDeclaration : Declaration, TypedElement
	{
	}

	[symbol: Namespace]
	class Namespace : Declaration
	{
	}

	[symbol: Alias]
	class Alias : Declaration
	{
		[property: Target]
		Declaration Target;
	}

	[symbol: NamedType]
	abstract class NamedType : Declaration, DataType
	{
		string DotNetName;
		[property: IsAbstract]
		bool IsAbstract;
		[property: IsSealed]
		bool IsSealed;
		[property: TypeArguments]
		containment list<DataType> TypeArguments;
		[property: BaseTypes]
		list<NamedType> BaseTypes;
	}
	
	//=============================
	// Types
	//=============================

	[type: Primitive]
	class PrimitiveType : NamedType
	{
	}

	class ClassifierType : NamedType
	{
	}

	[type: Interface]
	class InterfaceType : ClassifierType
	{
	}

	[type: Class]
	class ClassType : ClassifierType
	{
	}

	[type: Struct]
	class StructType : ClassifierType
	{
	}

	[type: Enum]
	class EnumType : NamedType
	{
		derived list<EnumLiteral> Literals;
	}

	[symbol: EnumLiteral]
	class EnumLiteral : Member, TypedElement
	{
		derived EnumType Type redefines TypedElement.Type;
	}

	[type: Delegate]
	class DelegateType : NamedType
	{
		[property: ReturnType]
		DataType ReturnType;
		[property: Parameters]
		containment list<Parameter> Parameters;
	}

	[type: Array]
	class ArrayType : DataType
	{
		[property: LowerBound]
		int LowerBound;
		[property: Size]
		int Size;
		[property: ElementType]
		DataType ElementType;
	}

	[type: Collection]
	class CollectionType : DataType
	{
		[property: IsUnique]
		bool IsUnique;
		[property: IsUnordered]
		bool IsUnordered;
		[property: ItemType]
		DataType ItemType;
	}

	[type: Dictionary]
	class DictionaryType : DataType
	{
		[property: IsUnordered]
		bool IsUnordered;
		[property: KeyType]
		DataType KeyType;
		[property: ValueType]
		DataType ValueType;
	}

	[type: Nullable]
	class NullableType : DataType
	{
		[property: InnerType]
		DataType InnerType;
	}
	
	[type: Tuple]
	class TupleType : DataType
	{
	}
	
	[symbol: TypeParameter]
	class TypeParameter : NamedType
	{
	}

	[type: GenericTypeReference]
	class GenericTypeReference : DataType
	{
		[property: ReferencedType]
		NamedType ReferencedType;
		[property: TypeArguments]
		containment list<DataType> TypeArguments;
		derived NamedType ConstructedType;
		derived DataType ResolvedType;
	}

	//=============================
	// Members
	//=============================

	[symbol: Member]
	abstract class Member : Declaration
	{
		[property: IsStatic]
		bool IsStatic;
		[property: IsVirtual]
		bool IsVirtual;
		[property: IsOverride]
		bool IsOverride;
		[property: IsAbstract]
		bool IsAbstract;
		[property: IsSealed]
		bool IsSealed;
	}

	[symbol: FieldLike]
	abstract class FieldLikeMember : Member, TypedDeclaration
	{
		[property: Type]
		DataType Type redefines TypedElement.Type;
	}

	[symbol: Field]
	class Field : FieldLikeMember
	{
	}

	[symbol: Property]
	class Property : FieldLikeMember
	{
		[property: GetMethod]
		containment Method GetMethod;
		[property: SetMethod]
		containment Method SetMethod;
	}

	[symbol: Indexer]
	class Indexer : Property
	{
		[property: Parameters]
		containment list<Parameter> Parameters;
	}

	[symbol: MethodLike]
	abstract class MethodLikeMember : Member
	{
		[property: IsAsync]
		bool IsAsync;
		[property: Result]
		Parameter Result;
		[property: Parameters]
		containment list<Parameter> Parameters;
		[property: Body]
		containment Statement Body;
	}

	[symbol: Method]
	class Method : MethodLikeMember
	{
	}

	[symbol: Parameter]
	class Parameter : Variable
	{
		[property: IsVarArg]
		bool IsVarArg;
	}

	[symbol: Constructor]
	class Constructor : MethodLikeMember
	{
		[property: NextConstructorInvocation]
		containment InvocationExpression NextConstructorInvocation;
	}

	[symbol: Destructor]
	class Destructor : MethodLikeMember
	{
	}

	[symbol: Lambda]
	class Lambda : MethodLikeMember
	{
	}

	abstract class Operator : MethodLikeMember
	{
	}

	[symbol: ConversionOperator]
	abstract class ConversionOperator : Operator
	{
	}

	[symbol: UnaryOperator]
	abstract class UnaryOperator : Operator
	{
		[property: OperatorKind]
		object OperatorKind;
	}

	[symbol: BinaryOperator]
	abstract class BinaryOperator : Operator
	{
		[property: OperatorKind]
		object OperatorKind;
	}

	//=============================
	// Statements
	//=============================

	[symbol: Statement]
	abstract class Statement : Element
	{
	}

	abstract class Local : Declaration
	{
	}

	[symbol: Variable]
	class Variable : Local
	{
		[property: IsDeclaredConst]
		bool IsDeclaredConst;
		[property: DeclaredType]
		DataType DeclaredType;
		[property: DeclaredInitializer]
		containment Expression DeclaredInitializer;
	}

	[symbol: Label]
	class Label : Local
	{
	}

	[statement: Block]
	class BlockStatement : Statement
	{
		[property: Statements]
		containment list<Statement> Statements;
	}

	[statement: Empty]
	class EmptyStatement : Statement
	{
	}
	
	[statement: Expression]
	class ExpressionStatement : Statement
	{
		[property: Expression]
		containment Expression Expression;
	}
	
	[statement: ForEachLoop]
	class ForEachLoopStatement : LoopStatement
	{
		[property: LoopControlVariable]
		containment Expression LoopControlVariable;
		[property: Collection]
		containment Expression Collection;
	}

	[statement: ForLoop]
	class ForLoopStatement : LoopStatement
	{
		[property: Before]
		containment list<Expression> Before;
		[property: Condition]
		containment Expression Condition;
		[property: AtLoopBottom]
		containment list<Expression> AtLoopBottom;
	}
	
	[statement: ForToLoop]
	class ForToLoopStatement : LoopStatement
	{
		[property: LoopControlVariable]
		containment Expression LoopControlVariable;
		[property: InitialValue]
		containment Expression InitialValue;
		[property: LimitValue]
		containment Expression LimitValue;
		[property: StepValue]
		containment Expression StepValue;
	}
	
	[statement: If]
	class IfStatement : Statement
	{
		[property: Condition]
		containment Expression Condition;
		[property: IfTrue]
		containment Statement IfTrue;
		[property: IfFalse]
		containment Statement IfFalse;
	}
	
	[statement: Jump]
	class JumpStatement : Statement
	{
		[property: JumpKind]
		object JumpKind;
		[property: Target]
		Label Target;
	}
	
	[statement: Labeled]
	class LabeledStatement : Statement
	{
		[property: Label]
		containment Label Label;
		[property: Statement]
		containment Statement Statement;
	}
	
	[statement: Lock]
	class LockStatement : Statement
	{
		[property: LockedValue]
		containment Expression LockedValue;
		[property: Body]
		containment Statement Body;
	}
	
	[statement: Loop]
	abstract class LoopStatement : Statement
	{
		[property: Body]
		containment Statement Body;
	}
	
	[statement: Return]
	class ReturnStatement : Statement
	{
		[property: ReturnedValue]
		containment Expression ReturnedValue;
	}
	
	[statement: Switch]
	class SwitchStatement : Statement
	{
		[property: Value]
		containment Expression Value;
		[property: Cases]
		containment list<SwitchCase> Cases;
	}

	[symbol: SwitchCase]
	class SwitchCase : Element
	{
		[property: Clauses]
		containment list<CaseClause> Clauses;
		[property: Body]
		containment Statement Body;
	}

	[symbol: CaseClause]
	abstract class CaseClause : Element
	{
		[property: Label]
		containment Label Label;
	}
	
	[symbol: DefaultCaseClause]
	class DefaultCaseClause : CaseClause
	{
	}
	
	[symbol: SingleValueCaseClause]
	class SingleValueCaseClause : CaseClause
	{
		[property: Value]
		containment Expression Value;
	}

	[statement: Try]
	class TryStatement : Statement
	{
		[property: Body]
		containment Statement Body;
		[property: Catches]
		containment list<CatchClause> Catches;
		[property: Finally]
		containment Statement Finally;
		[property: ExitLabel]
		containment Label ExitLabel;
	}

	[symbol: CatchClause]
	class CatchClause : Element
	{
		[property: ExceptionDeclarationOrExpression]
		containment Expression ExceptionDeclarationOrExpression;
		[property: Filter]
		containment Expression Filter;
		[property: Handler]
		containment Statement Handler;
	}
	
	[statement: Using]
	class UsingStatement : Statement
	{
		[property: Resources]
		containment list<Expression> Resources;
		[property: Body]
		containment Statement Body;
	}
	
	[statement: WhileLoop]
	class WhileLoopStatement : LoopStatement
	{
		[property: Condition]
		containment Expression Condition;
		[property: ConditionIsTop]
		bool ConditionIsTop;
		[property: ConditionIsUntil]
		bool ConditionIsUntil;
	}

	//=============================
	// Expressions
	//=============================

	[symbol: Expression]
	abstract class Expression : Element
	{	
		DataType Type;
	}

	[symbol: Argument]
	class Argument : Expression, NamedElement
	{
		[property: Value]
		containment Expression Value;
	}
	
	[expression: Assignment]
	class AssignmentExpression : Expression
	{
		[property: Target]
		containment Expression Target;
		[property: Value]
		containment Expression Value;
	}
	
	[expression: Await]
	class AwaitExpression : Expression
	{
		[property: Operation]
		containment Expression Operation;
	}
	
	[expression: Binary]
	class BinaryExpression : Expression
	{
		[property: OperatorKind]
		object OperatorKind;
		[property: LeftOperand]
		containment Expression LeftOperand;
		[property: RightOperand]
		containment Expression RightOperand;
		[property: IsChecked]
		bool IsChecked;
		[property: OperatorMethod]
		BinaryOperator OperatorMethod;
	}
	
	[expression: Coalesce]
	class CoalesceExpression : Expression
	{
		[property: Value]
		containment Expression Value;
		[property: WhenNull]
		containment Expression WhenNull;
	}
	
	[expression: CompoundAssignment]
	class CompoundAssignmentExpression : AssignmentExpression
	{
		[property: OperatorKind]
		object OperatorKind;
		[property: IsChecked]
		bool IsChecked;
	}
	
	[expression: Conditional]
	class ConditionalExpression : Expression
	{
		[property: Condition]
		containment Expression Condition;
		[property: WhenTrue]
		containment Expression WhenTrue;
		[property: WhenFalse]
		containment Expression WhenFalse;
	}
	
	[expression: Conversion]
	class ConversionExpression : Expression
	{
		[property: Operand]
		containment Expression Operand;
		[property: TargetType]
		DataType TargetType;
		[property: IsTryCast]
		bool IsTryCast;
		[property: IsChecked]
		bool IsChecked;
	}
	
	[expression: DefaultValue]
	class DefaultValueExpression : Expression
	{
	}
	
	[expression: Discard]
	class DiscardExpression : Expression
	{
	}
	
	[expression: Dynamic]
	class DynamicExpression : Expression
	{
	}
	
	[expression: IncrementOrDecrement]
	class IncrementOrDecrementExpression : Expression
	{
		[property: Target]
		containment Expression Target;
		[property: IsPostfix]
		bool IsPostfix;
		[property: IsChecked]
		bool IsChecked;
	}
	
	[expression: IndexerAccess]
	class IndexerAccessExpression : Expression
	{
		[property: Receiver]
		containment Expression Receiver;
		[property: IsNullConditional]
		bool IsNullConditional;
		[property: Arguments]
		containment list<Argument> Arguments;
		[property: Target]
		Indexer Target;
	}

	[expression: InstanceReference]
	class InstanceReferenceExpression : Expression
	{
		[property: AccessThroughBaseType]
		NamedType AccessThroughBaseType;
	}
	
	[expression: Invocation]
	class InvocationExpression : Expression
	{
		[property: Receiver]
		containment Expression Receiver;
		[property: Arguments]
		containment list<Argument> Arguments;
	}
	
	[expression: IsType]
	class IsTypeExpression : Expression
	{
		[property: ValueOperand]
		containment Expression ValueOperand;
		[property: TypeOperand]
		DataType TypeOperand;
		[property: IsNegated]
		bool IsNegated;
		[property: DeclaredVariable]
		Variable DeclaredVariable;
	}
	
	[expression: Lambda]
	class LambdaExpression : Expression
	{
		[property: ReturnType]
		DataType ReturnType;
		[property: Parameters]
		containment list<Parameter> Parameters;
		[property: Body]
		containment Statement Body;
	}
	
	[expression: Literal]
	class LiteralExpression : Expression
	{
		[property: Value]
		object Value;
		[property: Type]
		DataType Type;
	}
	
	[expression: NameOf]
	class NameOfExpression : Expression
	{
		[property: Argument]
		containment Expression Argument;
	}
	
	[expression: NullForgiving]
	class NullForgivingExpression : Expression
	{
		[property: Operand]
		containment Expression Operand;
	}
	
	[expression: ObjectCreation]
	class ObjectCreationExpression : Expression
	{
		[property: ObjectType]
		DataType ObjectType;
		[property: Arguments]
		containment list<Argument> Arguments;
		[property: Arguments]
		containment list<Expression> Initializers;
	}
	
	[expression: Parenthesized]
	class ParenthesizedExpression : Expression
	{
		[property: Operand]
		containment Expression Operand;
	}
	
	[expression: Reference]
	class ReferenceExpression : Expression
	{
		[property: Qualifier]
		containment Expression Qualifier;
		[property: IsNullConditional]
		bool IsNullConditional;
		[property: TypeArguments]
		list<DataType> TypeArguments;
		[property: IsDeclaration]
		bool IsDeclaration;
		[property: ReferenceThroughType]
		DataType ReferenceThroughType;
		[property: ReferencedSymbol]
		Declaration ReferencedSymbol;
	}
	
	[expression: SizeOf]
	class SizeOfExpression : Expression
	{
		[property: TypeOperand]
		DataType TypeOperand;
	}
	
	[expression: TypeOf]
	class TypeOfExpression : Expression
	{
		[property: TypeOperand]
		DataType TypeOperand;
	}
	
	[expression: Throw]
	class ThrowExpression : Expression
	{
		[property: Exception]
		containment Expression Exception;
	}
	
	[expression: Tuple]
	class TupleExpression : Expression
	{
		[property: Arguments]
		containment list<Argument> Arguments;
	}
	
	[expression: Unary]
	class UnaryExpression : Expression
	{
		[property: OperatorKind]
		object OperatorKind;
		[property: Operand]
		containment Expression Operand;
		[property: IsChecked]
		bool IsChecked;
		[property: OperatorMethod]
		UnaryOperator OperatorMethod;
	}
	
	[expression: VariableDeclaration]
	class VariableDeclarationExpression : Expression
	{
		[property: IsDeclaredConst]
		bool IsDeclaredConst;
		[property: DeclaredType]
		DataType DeclaredType;
		[property: Variables]
		containment list<Variable> Variables;
		[property: DeclaredInitializer]
		containment Expression DeclaredInitializer;
	}
	
}

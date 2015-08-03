namespace MetaDslx.Core="http://metadslx.core/1.0"
{
	metamodel MetaModel//(Uri="http://metadslx.core/1.0", Prefix="Meta")
	{
		/*
		const PrimitiveType ObjectType(Name="object");
		const PrimitiveType BoolType(Name="bool");
		const PrimitiveType StringType(Name="string");
		const PrimitiveType ByteType(Name="byte");
		const PrimitiveType IntType(Name="int");
		const PrimitiveType LongType(Name="long");
		const PrimitiveType FloatType(Name="float");
		const PrimitiveType DoubleType(Name="double");
		const PrimitiveType VoidType(Name="void");
		const PrimitiveType AnyType;
		const PrimitiveType UnknownType;
		const PrimitiveType ErrorType;

		Type Balance(Type leftType, Type rightType);
		Type GetType(object value);
		list<NamedElement> ResolveName(Scope scope, string name);
		list<NamedElement> ResolveName(string name);
		list<Type> ResolveType(Scope scope, string name);
		list<Type> ResolveType(string name);
		ScopeEntry Bind(object caller, list<ScopeEntry> entries);
		*/

		abstract class AnnotatedElement
		{
			containment list<Annotation> Annotations;
		}

		abstract class NamedElement
		{
			[Name]
			string Name;
		}

		abstract class TypedElement
		{
			[Type]
			Type Type;
		}

		[Type]
		abstract class Type
		{
		}

		class Annotation : NamedElement
		{
		}

		[Scope]
		class Namespace : NamedElement, AnnotatedElement
		{
			Namespace Parent;
			[ImportedScope]
			list<Namespace> Usings;
			[ScopeEntry]
			containment list<Namespace> Namespaces;
			[ScopeEntry]
			containment list<Model> Models;
		}

		association Namespace.Namespaces with Namespace.Parent;

		[Scope]
		class Model : NamedElement, AnnotatedElement
		{
			string Uri;
			string Prefix;
			Namespace Namespace;
			[ScopeEntry]
			containment list<Type> Types;
			[ScopeEntry]
			containment list<Property> Properties;
			[ScopeEntry]
			containment list<Operation> Operations;
		}

		association Namespace.Models with Model.Namespace;

		abstract class Declaration : NamedElement, AnnotatedElement
		{
			Model Model;
			derived Namespace Namespace;
		}

		association Model.Types with Declaration.Model;

		enum CollectionKind
		{
			Set,
			List
		}

		class CollectionType : Type
		{
			CollectionKind Kind;
			Type InnerType;
		}

		class NullableType : Type
		{
			Type InnerType;
		}

		class PrimitiveType : Type, NamedElement
		{
		}

		[Scope]
		class Enum : Type, Declaration
		{
			[ScopeEntry]
			containment list<EnumLiteral> EnumLiterals;
			[ScopeEntry]
			containment list<Operation> Operations;
		}

		class EnumLiteral : NamedElement, TypedElement
		{
			EnumLiteral()
			{
				Type = Enum;
			}

			Enum Enum;
		}

		association EnumLiteral.Enum with Enum.EnumLiterals;

		[Scope]
		class Class : Type, Declaration
		{
			bool IsAbstract;
			[InheritedScope]
			list<Class> SuperClasses;
			[ScopeEntry]
			containment list<Property> Properties;
			[ScopeEntry]
			containment list<Operation> Operations;
			containment Constructor Constructor;
			list<Class> GetAllSuperClasses();
			list<Property> GetAllProperties();
			list<Operation> GetAllOperations();
		}

		class Operation : NamedElement, AnnotatedElement
		{
			Type Parent;
			containment list<Parameter> Parameters;
			Type ReturnType;
		}

		class Constructor : NamedElement, AnnotatedElement
		{
			containment list<PropertyInitializer> Initializers;
		}

		association Operation.Parent with Class.Operations;
		association Operation.Parent with Enum.Operations;

		class Parameter : NamedElement, TypedElement, AnnotatedElement
		{
			Operation Operation;
		}

		association Operation.Parameters with Parameter.Operation;

		enum PropertyKind
		{
			Normal,
			Readonly,
			Lazy,
			Derived,
			Containment,
			Synthetized,
			Inherited
		}

		class Property : NamedElement, TypedElement, AnnotatedElement
		{
			Type Parent;
			PropertyKind Kind;
			Class Class;
			list<Property> OppositeProperties;
			list<Property> SubsettedProperties;
			list<Property> SubsettingProperties;
			list<Property> RedefinedProperties;
			list<Property> RedefiningProperties;
		}

		association Property.Parent with Class.Properties;

		abstract class PropertyInitializer
		{
			Property Property;
			containment Expression Value;
		}

		class SynthetizedPropertyInitializer : PropertyInitializer
		{
		}

		class InheritedPropertyInitializer : PropertyInitializer
		{
			string PropertyName;
			Property Object;
		}

		association Class.Properties with Property.Class;
		association Property.OppositeProperties with Property.OppositeProperties;
		association Property.SubsettedProperties with Property.SubsettingProperties;
		association Property.RedefinedProperties with Property.RedefiningProperties;

		enum ExpressionKind
		{
			None,
			Identifier,
			Literal,
			Bracket,
			TypeOf,
			TypeCast,
			MemberAccess,
			FunctionCall,
			Indexer,
			TypeIs,
			TypeAs,
			And,
			Or,
			ExclusiveOr,
			AndAlso,
			OrElse,
			Coalesce,
			Conditional,
			PostIncrementAssign,
			PostDecrementAssign,
			PreIncrementAssign,
			PreDecrementAssign,
			UnaryPlus,
			Negate,
			OnesComplement,
			Not,
			Multiply,
			Divide,
			Modulo,
			Add,
			Subtract,
			LeftShift,
			RightShift,
			LessThan,
			GreaterThan,
			LessThanOrEqual,
			GreaterThanOrEqual,
			Equal,
			NotEqual,
			Assign,
			MultiplyAssign,
			DivideAssign,
			ModuloAssign,
			AddAssign,
			SubtractAssign,
			LeftShiftAssign,
			RightShiftAssign,
			AndAssign,
			ExclusiveOrAssign,
			OrAssign
		}

		abstract class Expression : TypedElement
		{
			Expression()
			{
				Kind = ExpressionKind.None;
			}

			ExpressionKind Kind;// = ExpressionKind.None;
			inherited Type ExpectedType;
		}

		abstract class BoundExpression : Expression
		{
			BoundExpression()
			{
			    Definition = bind(this, Definitions);
				Type = get_type(Definition);
			}

			synthetized list<object> Definitions;
			synthetized object Definition;
		}

		class ThisExpression : BoundExpression
		{
			ThisExpression()
			{
				Definitions = current_type(this);
			}
		}

		class UnaryExpression : Expression
		{
			UnaryExpression()
			{
				Type = Expression.Type;
				Expression.ExpectedType = this.ExpectedType;
			}

			containment Expression Expression;
		}

		abstract class BinaryExpression : Expression
		{
			containment Expression Left;
			containment Expression Right;
		}

		class BinaryArithmeticExpression : BinaryExpression
		{
			BinaryArithmeticExpression()
			{
				Type = balance(Left.Type, Right.Type);
				Left.ExpectedType = ExpectedType;
				Right.ExpectedType = ExpectedType;
			}
		}

		class BinaryComparisonExpression : BinaryExpression
		{
			lazy Type BalancedType;
			/*init
			{
				Type = BoolType;
				BalancedType = balance(Left.Type, Right.Type);
				Left.ExpectedType = BalancedType;
				Right.ExpectedType = BalancedType;
			}*/
		}

		class BinaryLogicalExpression : BinaryExpression
		{
			/*init
			{
				Type = BoolType;
				Left.ExpectedType = BoolType;
				Right.ExpectedType = BoolType;
			}*/
		}

		class NullCoalescingExpression : BinaryExpression
		{
			lazy Type BalancedType;
			/*init
			{
				Type = balance(Left.Type, Right.Type);
				Left.ExpectedType = Type;
				Right.ExpectedType = Type;
			}*/
		}

		class AssignmentExpression : BinaryExpression
		{
			/*init
			{
				Type = Left.Type;
				Right.ExpectedType = Type;
			}*/
		}

		class TypeConversionExpression : Expression
		{
			Type TypeReference;
			containment Expression Expression;
			/*init
			{
				Type = TypeReference;
				Expression.ExpectedType = AnyType;
			}*/
		}

		class TypeCheckExpression : Expression
		{
			Type TypeReference;
			containment Expression Expression;
			/*init
			{
				Type = BoolType;
				Expression.ExpectedType = AnyType;
			}*/
		}

		class TypeOfExpression : Expression
		{
			Type TypeReference;
			/*init
			{
				Type = TypeReference;
			}*/
		}

		class ConstantExpression : Expression
		{
			object Value;
			/*init
			{
				Type = get_type(Value);
			}*/
		}

		class IdentifierExpression : BoundExpression
		{
			string Name;
			/*init
			{
				Definitions = resolve_name(Name);
				Value.ExpectedType = ExpectedType;
			}*/
		}

		class MemberAccessExpression : BoundExpression
		{
			containment Expression Expression;
			string Name;
			/*init
			{
				Definitions = resolve_name(Expression.Type, Name);
				Value.ExpectedType = ExpectedType;
			}*/
		}

		class FunctionCallExpression : BoundExpression
		{
			containment Expression Expression;
			containment list<Expression> Arguments;
			FunctionCallExpression()
			{
				Definitions = select_of_type(Expression.Definitions, typeof(Operation));
				Value.ExpectedType = ExpectedType;
			}
		}	

		class IndexerExpression : BoundExpression
		{
			containment Expression Expression;
			containment list<Expression> Arguments;
			/*init
			{
				Definitions = Expression.Definitions;
				Value.ExpectedType = ExpectedType;
			}*/
		}	

		class ConditionalExpression : Expression
		{
			containment Expression Condition;
			Type BalancedType;
			containment Expression Then;
			containment Expression Else;
			/*init
			{
				Condition.ExpectedType = BoolType;
				Type = balance(Then.Type, Else.Type);
				Left.ExpectedType = ExpectedType;
				Right.ExpectedType = ExpectedType;
			}*/
		}
	}
}
/*
namespace MetaDslx.Core.X = "http://metadslx.core/1.0/X"
{
	metamodel X
	{
	}
}

namespace MetaDslx.Core = "http://metadslx.core/1.0"
{
	metamodel Z
	{
		class MetaClass
		{
		}
	}
}

*/
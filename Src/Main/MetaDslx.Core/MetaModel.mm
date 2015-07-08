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

		abstract class ScopeEntry
		{
			Scope Parent;
		}
		
		abstract class NamedElement : ScopeEntry
		{
			string Name;
		}

		abstract class TypedElement : ScopeEntry
		{
			Type Type;
		}

		abstract class Type : ScopeEntry
		{
			bool IsAssignableFrom(Type valueType);
			bool Equals(Type otherType);
		}

		abstract class Scope : ScopeEntry
		{
			containment list<ScopeEntry> Entries;
			list<Scope> ImportedScopes;
			list<Scope> InheritedScopes;
			list<ScopeEntry> ImportedEntries;
			list<ScopeEntry> ResolveEntries(string name);
			list<ScopeEntry> GetEntries(string name);
		}

		association ScopeEntry.Parent with Scope.Entries;

		class Namespace : NamedElement, Scope
		{
			Namespace Parent redefines ScopeEntry.Parent;
			list<Namespace> Usings redefines Scope.ImportedScopes;
			list<Namespace> Namespaces subsets Scope.Entries;
			list<Model> Models subsets Scope.Entries;
		}

		association Namespace.Namespaces with Namespace.Parent;

		class Model : Type, NamedElement, Scope
		{
			string Uri;
			string Prefix;
			Namespace Namespace redefines ScopeEntry.Parent;
			list<Type> Types subsets Scope.Entries;
			list<Property> Properties subsets Scope.Entries;
			list<Operation> Operations subsets Scope.Entries;
		}

		association Namespace.Models with Model.Namespace;

		abstract class Declaration : ScopeEntry
		{
			Model Model redefines ScopeEntry.Parent;
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

		class Enum : Type, NamedElement, Scope, Declaration
		{
			list<EnumLiteral> EnumLiterals subsets Scope.Entries;
			list<Operation> Operations subsets Scope.Entries;
		}

		class EnumLiteral : NamedElement
		{
			Enum Enum redefines ScopeEntry.Parent;
		}

		association EnumLiteral.Enum with Enum.EnumLiterals;

		class Class : Type, NamedElement, Scope, Declaration
		{
			bool IsAbstract;
			list<Class> SuperClasses redefines Scope.InheritedScopes;
			list<Property> Properties subsets Scope.Entries;
			list<Operation> Operations subsets Scope.Entries;
			list<PropertyInitializer> Initializers;
			list<Class> GetAllSuperClasses();
			list<Property> GetAllProperties();
			list<Operation> GetAllOperations();
		}

		class Operation : NamedElement
		{
			containment list<Parameter> Parameters;
			Type ReturnType;
		}

		class Parameter : NamedElement, TypedElement
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

		class Property : NamedElement, TypedElement
		{
			PropertyKind Kind;
			Class Class redefines ScopeEntry.Parent;
			list<Property> OppositeProperties;
			list<Property> SubsettedProperties;
			list<Property> SubsettingProperties;
			list<Property> RedefinedProperties;
			list<Property> RedefiningProperties;
		}

		abstract class PropertyInitializer
		{
			Property Property;
			Expression Value;
		}

		class SynthetizedPropertyInitializer : PropertyInitializer
		{
		}

		class InheritedPropertyInitializer : PropertyInitializer
		{
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

		abstract class Expression
		{
			ExpressionKind Kind;// = ExpressionKind.None;
			synthetized Type Type;
			inherited Type ExpectedType;
			synthetized list<ScopeEntry> Definitions;
			synthetized ScopeEntry Definition;
			/*init
			{
			    Definition = Bind(this, Definitions);
			}*/
		}

		class UnaryExpression : Expression
		{
			containment Expression Expression;
			/*init
			{
				Type = Expression.Type;
				Expression.ExpectedType = this.ExpectedType;
			}*/
		}

		abstract class BinaryExpression : Expression
		{
			containment Expression Left;
			containment Expression Right;
		}

		class BinaryArithmeticExpression : BinaryExpression
		{
			/*init
			{
				Type = Balance(Left.Type, Right.Type);
				Left.ExpectedType = ExpectedType;
				Right.ExpectedType = ExpectedType;
			}*/
		}

		class BinaryComparisonExpression : BinaryExpression
		{
			lazy Type BalancedType;
			/*init
			{
				Type = BoolType;
				BalancedType = Balance(Left.Type, Right.Type);
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

		class AssignmentExpression : Expression
		{
			containment Expression Target;
			containment Expression Value;
			/*init
			{
				Type = Target.Type;
				Value.ExpectedType = Type;
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
				Type = GetType(Value);
			}*/
		}

		class IdentifierExpression : Expression
		{
			string Name;
			/*init
			{
				Definitions = ResolveName(Name);
				Type = GetType(Definition);
				Value.ExpectedType = ExpectedType;
			}*/
		}

		class MemberAccessExpression : Expression
		{
			containment Expression Expression;
			string Name;
			/*init
			{
				Definitions = ResolveName(Expression.Type, Name);
				Type = GetType(Definition);
				Value.ExpectedType = ExpectedType;
			}*/
		}

		class FunctionCallExpression : Expression
		{
			containment Expression Expression;
			containment list<Expression> Arguments;
			/*init
			{
				Definitions = Expression.Definitions;
				Type = GetType(Definition);
				Value.ExpectedType = ExpectedType;
			}*/
		}	

		class IndexerExpression : Expression
		{
			containment Expression Expression;
			containment list<Expression> Arguments;
			/*init
			{
				Definitions = Expression.Definitions;
				Type = GetType(Definition);
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
				Type = Balance(Then.Type, Else.Type);
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

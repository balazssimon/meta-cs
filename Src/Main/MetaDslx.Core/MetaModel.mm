namespace MetaDslx.Core="http://metadslx.core/1.0"
{
	metamodel MetaModel//(Uri="http://metadslx.core/1.0", Prefix="Meta")
	{
		/* 
		Function Bind = 
			new Function()
			{
				Name = "bind",
				Parameters = 
					new ModelList<Parameter>()
					{
						new Parameter() { Name = "symbols", Type = typeof(list<object>) }
					},
				ReturnType = typeof(object)
			};
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

		class FunctionType : Type
		{
			list<Type> ParameterTypes;
			Type ReturnType;
		}

		class Function : NamedElement, TypedElement, AnnotatedElement
		{
			[Type]
			readonly FunctionType Type redefines TypedElement.Type;
			containment list<Parameter> Parameters;
			Type ReturnType;
		}

		class Operation : Function
		{
			Type Parent;
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
			string PropertyName;
			Property Property;
			containment Expression Value;

			PropertyInitializer()
			{
				Property = resolve_name(PropertyName);
			}
		}

		class SynthetizedPropertyInitializer : PropertyInitializer
		{
		}

		class InheritedPropertyInitializer : PropertyInitializer
		{
			string ObjectName;
			Property Object;

			PropertyInitializer()
			{
				Object = resolve_name(ObjectName);
				Property = resolve_name(Object.Type, PropertyName);
			}
		}

		association Class.Properties with Property.Class;
		association Property.OppositeProperties with Property.OppositeProperties;
		association Property.SubsettedProperties with Property.SubsettingProperties;
		association Property.RedefinedProperties with Property.RedefiningProperties;


		abstract class Expression : TypedElement
		{
			inherited Type ExpectedType;
		}

		class BracketExpression : Expression
		{
			BracketExpression()
			{
				Type = Expression.Type;
				Expression.ExpectedType = ExpectedType;
			}

			containment Expression Expression;
		}


		abstract class BoundExpression : Expression
		{
			BoundExpression()
			{
			    Definition = bind(this);
				Type = get_type(Definition);
			}

			containment list<Expression> Arguments;
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

		abstract class TypeConversionExpression : Expression
		{
			Type TypeReference;
			containment Expression Expression;
			TypeConversionExpression()
			{
				Type = TypeReference;
				Expression.ExpectedType = null;
			}
		}

		class TypeAsExpression : TypeConversionExpression
		{
		}

		class TypeCastExpression : TypeConversionExpression
		{
		}


		class TypeCheckExpression : Expression
		{
			Type TypeReference;
			containment Expression Expression;

			TypeCheckExpression()
			{
				Type = typeof(bool);
				Expression.ExpectedType = null;
			}
		}

		class TypeOfExpression : Expression
		{
			Type TypeReference;

			TypeOfExpression()
			{
				Type = typeof(Type);
			}
		}

		class ConditionalExpression : Expression
		{
			containment Expression Condition;
			Type BalancedType;
			containment Expression Then;
			containment Expression Else;

			ConditionalExpression()
			{
				Condition.ExpectedType = typeof(bool);
				Type = balance(Then.Type, Else.Type);
				Then.ExpectedType = ExpectedType;
				Else.ExpectedType = ExpectedType;
			}
		}

		class ConstantExpression : Expression
		{
			object Value;

			ConstantExpression()
			{
				Type = get_type(Value);
			}
		}

		class IdentifierExpression : BoundExpression
		{
			string Name;

			IdentifierExpression()
			{
				Definitions = resolve_name(Name);
			}
		}

		class MemberAccessExpression : BoundExpression
		{
			containment Expression Expression;
			string Name;

			MemberAccessExpression()
			{
				Definitions = resolve_name(Expression.Type, Name);
			}
		}

		class FunctionCallExpression : BoundExpression
		{
			containment Expression Expression;

			FunctionCallExpression()
			{
				Definitions = select_of_type(Expression, typeof(FunctionType));
			}
		}	

		class IndexerExpression : BoundExpression
		{
			containment Expression Expression;

			IndexerExpression()
			{
				Definitions = select_of_name(select_of_type(Expression, typeof(FunctionType)), "operator[]");
			}
		}	

		abstract class OperatorExpression : BoundExpression
		{
			string Name;

			OperatorExpression()
			{
				Definitions = resolve_name(Name);
			}
		}

		abstract class UnaryExpression : OperatorExpression
		{
			UnaryExpression()
			{
				Arguments = Expression;
			}

			containment Expression Expression;
		}

		class UnaryPlusExpression : UnaryExpression
		{
			UnaryPlusExpression()
			{
				Name = "operator+()";
			}
		}

		class NegateExpression : UnaryExpression
		{
			NegateExpression()
			{
				Name ="operator-()";
			}
		}

		class OnesComplementExpression : UnaryExpression
		{
			OnesComplementExpression()
			{
				Name ="operator~()";
			}
		}

		class NotExpression : UnaryExpression
		{
			NotExpression()
			{
				Name ="operator!()";
			}
		}


		abstract class UnaryAssignExpression : UnaryExpression
		{
		}

		class PostIncrementAssignExpression : UnaryAssignExpression
		{
			PostIncrementAssignExpression()
			{
				Name ="operator()++";
			}
		}

		class PostDecrementAssignExpression : UnaryAssignExpression
		{
			PostDecrementAssignExpression()
			{
				Name ="operator()--";
			}
		}

		class PreIncrementAssignExpression : UnaryAssignExpression
		{
			PreIncrementAssignExpression()
			{
				Name ="operator++()";
			}
		}

		class PreDecrementAssignExpression : UnaryAssignExpression
		{
			PreDecrementAssignExpression()
			{
				Name ="operator--()";
			}
		}


		abstract class BinaryExpression : OperatorExpression
		{
			BinaryExpression()
			{
				Arguments = Left;
				Arguments = Right;
			}

			containment Expression Left;
			containment Expression Right;
		}

		abstract class BinaryArithmeticExpression : BinaryExpression
		{
		}

		class MultiplyExpression : BinaryArithmeticExpression
		{
			MultiplyExpression()
			{
				Name = "operator()*()";
			}
		}

		class DivideExpression : BinaryArithmeticExpression
		{
			DivideExpression()
			{
				Name = "operator()/()";
			}
		}

		class ModuloExpression : BinaryArithmeticExpression
		{
			ModuloExpression()
			{
				Name = "operator()%()";
			}
		}

		class AddExpression : BinaryArithmeticExpression
		{
			AddExpression()
			{
				Name = "operator()+()";
			}
		}

		class SubtractExpression : BinaryArithmeticExpression
		{
			SubtractExpression()
			{
				Name = "operator()-()";
			}
		}

		class LeftShiftExpression : BinaryArithmeticExpression
		{
			LeftShiftExpression()
			{
				Name = "operator()<<()";
			}
		}

		class RightShiftExpression : BinaryArithmeticExpression
		{
			RightShiftExpression()
			{
				Name = "operator()>>()";
			}
		}


		abstract class BinaryComparisonExpression : BinaryExpression
		{
		}

		class LessThanExpression : BinaryComparisonExpression
		{
			LessThanExpression()
			{
				Name = "operator()<()";
			}
		}

		class LessThanOrEqualExpression : BinaryComparisonExpression
		{
			LessThanOrEqualExpression()
			{
				Name = "operator()<=()";
			}
		}

		class GreaterThanExpression : BinaryComparisonExpression
		{
			GreaterThanExpression()
			{
				Name = "operator()>()";
			}
		}

		class GreaterThanOrEqualExpression : BinaryComparisonExpression
		{
			GreaterThanOrEqualExpression()
			{
				Name = "operator()>=()";
			}
		}

		class EqualExpression : BinaryComparisonExpression
		{
			EqualExpression()
			{
				Name = "operator()==()";
			}
		}

		class NotEqualExpression : BinaryComparisonExpression
		{
			NotEqualExpression()
			{
				Name = "operator()!=()";
			}
		}


		abstract class BinaryLogicalExpression : BinaryExpression
		{
		}

		class AndExpression : BinaryLogicalExpression
		{
			AndExpression()
			{
				Name = "operator()&()";
			}
		}

		class OrExpression : BinaryLogicalExpression
		{
			OrExpression()
			{
				Name = "operator()|()";
			}
		}

		class ExclusiveOrExpression : BinaryLogicalExpression
		{
			ExclusiveOrExpression()
			{
				Name = "operator()^()";
			}
		}

		class AndAlsoExpression : BinaryLogicalExpression
		{
			AndAlsoExpression()
			{
				Name = "operator()&&()";
			}
		}

		class OrElseExpression : BinaryLogicalExpression
		{
			OrElseExpression()
			{
				Name = "operator()||()";
			}
		}


		class NullCoalescingExpression : BinaryExpression
		{
			NullCoalescingExpression()
			{
				Name = "operator()??()";
			}
		}

		abstract class AssignmentExpression : BinaryExpression
		{
			AssignmentExpression()
			{
				Type = Left.Type;
				Right.ExpectedType = Type;
			}
		}

		class AssignExpression : AssignmentExpression
		{
			AssignExpression()
			{
				Name = "operator()=()";
			}
		}


		abstract class ArithmeticAssignmentExpression : AssignmentExpression
		{
		}

		class MultiplyAssignExpression : ArithmeticAssignmentExpression
		{
			MultiplyAssignExpression()
			{
				Name = "operator()*=()";
			}
		}

		class DivideAssignExpression : ArithmeticAssignmentExpression
		{
			DivideAssignExpression()
			{
				Name = "operator()/=()";
			}
		}

		class ModuloAssignExpression : ArithmeticAssignmentExpression
		{
			ModuloAssignExpression()
			{
				Name = "operator()%=()";
			}
		}

		class AddAssignExpression : ArithmeticAssignmentExpression
		{
			AddAssignExpression()
			{
				Name = "operator()+=()";
			}
		}

		class SubtractAssignExpression : ArithmeticAssignmentExpression
		{
			SubtractAssignExpression()
			{
				Name = "operator()-=()";
			}
		}

		class LeftShiftAssignExpression : ArithmeticAssignmentExpression
		{
			LeftShiftAssignExpression()
			{
				Name = "operator()<<=()";
			}
		}

		class RightShiftAssignExpression : ArithmeticAssignmentExpression
		{
			RightShiftAssignExpression()
			{
				Name = "operator()>>=()";
			}
		}


		abstract class LogicalAssignmentExpression : AssignmentExpression
		{
		}

		class AndAssignExpression : LogicalAssignmentExpression
		{
			AndAssignExpression()
			{
				Name = "operator()&=()";
			}
		}

		class ExclusiveOrAssignExpression : LogicalAssignmentExpression
		{
			ExclusiveOrAssignExpression()
			{
				Name = "operator()^=()";
			}
		}

		class OrAssignExpression : LogicalAssignmentExpression
		{
			OrAssignExpression()
			{
				Name = "operator()|=()";
			}
		}

	}
}

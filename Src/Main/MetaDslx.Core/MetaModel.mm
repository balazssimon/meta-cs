﻿namespace MetaDslx.Core
{

	metamodel Meta(Uri="http://metadslx.core/1.0");

	const MetaPrimitiveType Object = new MetaPrimitiveType() { Name = "object" };
	const MetaPrimitiveType String = new MetaPrimitiveType() { Name = "string" };
	const MetaPrimitiveType Int = new MetaPrimitiveType() { Name = "int" };
	const MetaPrimitiveType Long = new MetaPrimitiveType() { Name = "long" };
	const MetaPrimitiveType Float = new MetaPrimitiveType() { Name = "float" };
	const MetaPrimitiveType Double = new MetaPrimitiveType() { Name = "double" };
	const MetaPrimitiveType Byte = new MetaPrimitiveType() { Name = "byte" };
	const MetaPrimitiveType Bool = new MetaPrimitiveType() { Name = "bool" };
	const MetaPrimitiveType Void = new MetaPrimitiveType() { Name = "void" };
	const MetaPrimitiveType None = new MetaPrimitiveType() { Name = "*none*" };
	const MetaPrimitiveType Any = new MetaPrimitiveType() { Name = "*any*" };
	const MetaPrimitiveType Error = new MetaPrimitiveType() { Name = "*error*" };
	const MetaPrimitiveType ModelObject = new MetaPrimitiveType() { Name = "ModelObject" };
	const MetaCollectionType ModelObjectList = new MetaCollectionType() { InnerType = typeof(ModelObject) };


	[Name(Name="typeof")]
	extern MetaType TypeOf(object type);
	[Name(Name="get_type")]
	extern MetaType GetValueType(object value);
	[Name(Name="get_return_type")]
	extern MetaType GetReturnType(object value);
	[Name(Name="current_type")]
	extern MetaType CurrentType(ModelObject symbol);
	[Name(Name="type_check")]
	extern bool TypeCheck(ModelObject symbol);
	[Name(Name="balance")]
	extern MetaType Balance(MetaType left, MetaType right);

	[Name(Name="resolve")]
	extern list<ModelObject> Resolve1(string name);
	[Name(Name="resolve")]
	extern list<ModelObject> Resolve2(ModelObject context, string name);
	[Name(Name="resolve_type")]
	extern list<ModelObject> ResolveType1(string name);
	[Name(Name="resolve_type")]
	extern list<ModelObject> ResolveType2(ModelObject context, string name);
	[Name(Name="resolve_name")]
	extern list<ModelObject> ResolveName1(string name);
	[Name(Name="resolve_name")]
	extern list<ModelObject> ResolveName2(ModelObject context, string name);

	[Name(Name="bind")]
	extern ModelObject Bind1(ModelObject symbol);
	[Name(Name="bind")]
	extern ModelObject Bind2(list<ModelObject> symbols);
	[Name(Name="bind")]
	extern ModelObject Bind3(ModelObject context, ModelObject symbol);
	[Name(Name="bind")]
	extern ModelObject Bind4(ModelObject context, list<ModelObject> symbols);

	[Name(Name="select_of_type")]
	extern list<ModelObject> SelectOfType1(ModelObject symbol, MetaType type);
	[Name(Name="select_of_type")]
	extern list<ModelObject> SelectOfType2(list<ModelObject> symbols, MetaType type);
	[Name(Name="select_of_name")]
	extern list<ModelObject> SelectOfName1(ModelObject symbol, string name);
	[Name(Name="select_of_name")]
	extern list<ModelObject> SelectOfName2(list<ModelObject> symbols, string name);
		

	abstract class MetaAnnotatedElement
	{
		containment list<MetaAnnotation> Annotations;
	}

	abstract class MetaNamedElement
	{
		[Name]
		string Name;
	}

	abstract class MetaTypedElement
	{
		[Type]
		MetaType Type;
	}

	[Type]
	abstract class MetaType
	{
	}

	class MetaAnnotation : MetaNamedElement
	{
		containment list<MetaAnnotationProperty> Properties;
	}

	class MetaAnnotationProperty : MetaNamedElement
	{
		MetaExpression Value;

		MetaAnnotationProperty()
		{
			Value.ExpectedType = typeof(any);
		}
	}

	[Scope]
	class MetaNamespace : MetaNamedElement, MetaAnnotatedElement
	{
		MetaNamespace Parent;
		[ImportedScope]
		list<MetaNamespace> Usings;
		containment MetaModel MetaModel;
		[ScopeEntry]
		containment list<MetaNamespace> Namespaces;
		[ScopeEntry]
		containment list<MetaDeclaration> Declarations;
	}

	association MetaNamespace.Namespaces with MetaNamespace.Parent;

	abstract class MetaDeclaration : MetaNamedElement, MetaAnnotatedElement
	{
		MetaDeclaration()
		{
			Model = Namespace.MetaModel;
		}

		MetaNamespace Namespace;
		derived MetaModel Model;
	}

	association MetaNamespace.Declarations with MetaDeclaration.Namespace;

	class MetaModel : MetaNamedElement, MetaAnnotatedElement
	{
		string Uri;
		MetaNamespace Namespace;
	}

	association MetaNamespace.MetaModel with MetaModel.Namespace;

	enum MetaCollectionKind
	{
		List,
		Set,
		MultiList,
		MultiSet
	}

	class MetaCollectionType : MetaType
	{
		MetaCollectionKind Kind;
		MetaType InnerType;
	}

	class MetaNullableType : MetaType
	{
		MetaType InnerType;
	}

	class MetaPrimitiveType : MetaType, MetaNamedElement
	{
	}

	[Scope]
	class MetaEnum : MetaType, MetaDeclaration
	{
		[ScopeEntry]
		containment list<MetaEnumLiteral> EnumLiterals;
		[ScopeEntry]
		containment list<MetaOperation> Operations;
	}

	class MetaEnumLiteral : MetaNamedElement, MetaTypedElement
	{
		MetaEnumLiteral()
		{
			Type = Enum;
		}

		MetaEnum Enum;
	}

	association MetaEnumLiteral.Enum with MetaEnum.EnumLiterals;

	[Scope]
	class MetaClass : MetaType, MetaDeclaration
	{
		bool IsAbstract;
		[InheritedScope]
		list<MetaClass> SuperClasses;
		[ScopeEntry]
		containment list<MetaProperty> Properties;
		[ScopeEntry]
		containment list<MetaOperation> Operations;
		containment MetaConstructor Constructor;
		list<MetaClass> GetAllSuperClasses();
		list<MetaProperty> GetAllProperties();
		list<MetaOperation> GetAllOperations();
	}

	class MetaFunctionType : MetaType
	{
		multi_list<MetaType> ParameterTypes;
		MetaType ReturnType;
	}

	class MetaFunction : MetaTypedElement, MetaDeclaration
	{
		MetaFunction()
		{
			// Type = new MetaFunctionType();
			// Type.ReturnType = ReturnType;
			// Type.ParameterTypes = map(Parameters, p => p.Type);
		}

		[Type]
		readonly MetaFunctionType Type redefines MetaTypedElement.Type;
		containment list<MetaParameter> Parameters;
		MetaType ReturnType;
	}

	class MetaOperation : MetaFunction
	{
		MetaType Parent;
	}

	class MetaConstant : MetaTypedElement, MetaDeclaration
	{
		MetaConstant()
		{
			Value.ExpectedType = Type;
		}

		MetaExpression Value;
	}

	class MetaConstructor : MetaNamedElement, MetaAnnotatedElement
	{
		MetaClass Parent;
		containment list<MetaPropertyInitializer> Initializers;
	}

	association MetaConstructor.Parent with MetaClass.Constructor;
	association MetaOperation.Parent with MetaClass.Operations;
	association MetaOperation.Parent with MetaEnum.Operations;

	class MetaParameter : MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
	{
		MetaFunction Function;
	}

	association MetaFunction.Parameters with MetaParameter.Function;

	enum MetaPropertyKind
	{
		Normal,
		Readonly,
		Lazy,
		Derived,
		Containment,
		Synthetized,
		Inherited
	}

	class MetaProperty : MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
	{
		MetaPropertyKind Kind;
		MetaClass Class;
		list<MetaProperty> OppositeProperties;
		list<MetaProperty> SubsettedProperties;
		list<MetaProperty> SubsettingProperties;
		list<MetaProperty> RedefinedProperties;
		list<MetaProperty> RedefiningProperties;
	}

	association MetaProperty.Class with MetaClass.Properties;
	association MetaProperty.OppositeProperties with MetaProperty.OppositeProperties;
	association MetaProperty.SubsettedProperties with MetaProperty.SubsettingProperties;
	association MetaProperty.RedefinedProperties with MetaProperty.RedefiningProperties;


	abstract class MetaPropertyInitializer
	{
		MetaConstructor Constructor;
		string PropertyName;
		MetaClass PropertyContext;
		MetaProperty Property;
		containment MetaExpression Value;

		MetaPropertyInitializer()
		{
			PropertyContext = current_type(this) as MetaClass;
			Property = bind(resolve_name(this.PropertyContext, PropertyName));
			Value.ExpectedType = get_type(Property);
		}
	}

	association MetaPropertyInitializer.Constructor with MetaConstructor.Initializers;

	class MetaSynthetizedPropertyInitializer : MetaPropertyInitializer
	{
	}

	class MetaInheritedPropertyInitializer : MetaPropertyInitializer
	{
		string ObjectName;
		MetaProperty Object;

		MetaPropertyInitializer()
		{
			Object = bind(resolve_name(ObjectName));
			PropertyContext = get_type(Object) as MetaClass;
			Property = bind(resolve_name(PropertyContext, PropertyName));
		}
	}


	abstract class MetaExpression : MetaTypedElement
	{
		MetaExpression()
		{
			NoTypeError = type_check(this);
		}

		readonly bool NoTypeError;
		inherited MetaType ExpectedType;
	}

	class MetaBracketExpression : MetaExpression
	{
		MetaBracketExpression()
		{
			Type = Expression.Type;
			Expression.ExpectedType = ExpectedType;
		}

		containment MetaExpression Expression;
	}


	abstract class MetaBoundExpression : MetaExpression
	{
		MetaBoundExpression()
		{
			UniqueDefinition = true;
			Definition = bind(Definitions);
			Type = get_type(Definition);
		}

		inherited bool UniqueDefinition;
		containment list<MetaExpression> Arguments;
		synthetized list<ModelObject> Definitions;
		synthetized ModelObject Definition;
	}

	class MetaThisExpression : MetaBoundExpression
	{
		MetaThisExpression()
		{
			Definition = current_type(this);
		}
	}

	class MetaNullExpression : MetaExpression
	{
		NullExpression()
		{
			Type = typeof(any);
		}
	}

	abstract class MetaTypeConversionExpression : MetaExpression
	{
		MetaType TypeReference;
		containment MetaExpression Expression;

		MetaTypeConversionExpression()
		{
			Type = TypeReference;
			Expression.ExpectedType = typeof(any);
		}
	}

	class MetaTypeAsExpression : MetaTypeConversionExpression
	{
	}

	class MetaTypeCastExpression : MetaTypeConversionExpression
	{
	}


	class MetaTypeCheckExpression : MetaExpression
	{
		MetaType TypeReference;
		containment MetaExpression Expression;

		MetaTypeCheckExpression()
		{
			Type = typeof(bool);
			Expression.ExpectedType = typeof(any);
		}
	}

	class MetaTypeOfExpression : MetaExpression
	{
		MetaType TypeReference;

		MetaTypeOfExpression()
		{
			Type = typeof(MetaType);
		}
	}

	class MetaConditionalExpression : MetaExpression
	{
		containment MetaExpression Condition;
		MetaType BalancedType;
		containment MetaExpression Then;
		containment MetaExpression Else;

		MetaConditionalExpression()
		{
			Condition.ExpectedType = typeof(bool);
			Type = balance(Then.Type, Else.Type);
			Then.ExpectedType = ExpectedType;
			Else.ExpectedType = ExpectedType;
		}
	}

	class MetaConstantExpression : MetaExpression
	{
		object Value;

		MetaConstantExpression()
		{
			Type = get_type(Value);
		}
	}

	class MetaIdentifierExpression : MetaBoundExpression
	{
		string Name;

		MetaIdentifierExpression()
		{
			Definitions = resolve_name(Name);
		}
	}

	class MetaMemberAccessExpression : MetaBoundExpression
	{
		containment MetaExpression Expression;
		string Name;

		MetaMemberAccessExpression()
		{
			Expression.[MetaBoundExpression]UniqueDefinition = false;
			Expression.ExpectedType = typeof(none);
			Definitions = resolve_name(Expression.Type, Name);
		}
	}

	class MetaFunctionCallExpression : MetaBoundExpression
	{
		containment MetaExpression Expression;

		MetaFunctionCallExpression()
		{
			Expression.[MetaBoundExpression]UniqueDefinition = false;
			Expression.ExpectedType = typeof(none);
			Definitions = Expression is MetaBoundExpression ? select_of_type(((MetaBoundExpression)Expression).Definitions, typeof(MetaFunctionType)) : null; // TODO
			Type = get_return_type(Definition);
		}
	}	

	class MetaIndexerExpression : MetaBoundExpression
	{
		containment MetaExpression Expression;

		MetaIndexerExpression()
		{
			Expression.[MetaBoundExpression]UniqueDefinition = false;
			Expression.ExpectedType = typeof(none);
			Definitions = Expression is MetaBoundExpression ? select_of_name(select_of_type(((MetaBoundExpression)Expression).Definitions, typeof(MetaFunctionType)), "operator[]") : null; // TODO
		}
	}	

	class MetaNewExpression : MetaExpression
	{
		MetaClass TypeReference;
		containment list<MetaNewPropertyInitializer> PropertyInitializers;
			
		MetaNewExpression()
		{
			Type = TypeReference;
		}
	}

	class MetaNewPropertyInitializer 
	{
		MetaNewExpression Parent;
		string PropertyName;
		MetaExpression Value;
		MetaProperty Property;

		NewPropertyInitializer()
		{
			Property = bind(resolve_name(Parent.Type, PropertyName));
			Value.ExpectedType = get_type(Property);
		}
	}

	association MetaNewExpression.PropertyInitializers with MetaNewPropertyInitializer.Parent;

	class MetaNewCollectionExpression : MetaExpression
	{
		MetaCollectionType TypeReference;
		containment list<MetaExpression> Values;

		MetaNewCollectionExpression()
		{
			// Values.ExpectedType = TypeReference.InnerType;
			Type = TypeReference;
		}
	}

	abstract class MetaOperatorExpression : MetaBoundExpression
	{
		readonly string Name;

		MetaOperatorExpression()
		{
			Definitions = resolve_name(Name);
		}
	}

	abstract class MetaUnaryExpression : MetaOperatorExpression
	{
		MetaUnaryExpression()
		{
			//Arguments += Expression;
		}

		containment MetaExpression Expression;
	}

	class MetaUnaryPlusExpression : MetaUnaryExpression
	{
		MetaUnaryPlusExpression()
		{
			Name = "operator+()";
		}
	}

	class MetaNegateExpression : MetaUnaryExpression
	{
		MetaNegateExpression()
		{
			Name ="operator-()";
		}
	}

	class MetaOnesComplementExpression : MetaUnaryExpression
	{
		MetaOnesComplementExpression()
		{
			Name ="operator~()";
		}
	}

	class MetaNotExpression : MetaUnaryExpression
	{
		MetaNotExpression()
		{
			Name ="operator!()";
		}
	}


	abstract class MetaUnaryAssignExpression : MetaUnaryExpression
	{
	}

	class MetaPostIncrementAssignExpression : MetaUnaryAssignExpression
	{
		MetaPostIncrementAssignExpression()
		{
			Name ="operator()++";
		}
	}

	class MetaPostDecrementAssignExpression : MetaUnaryAssignExpression
	{
		MetaPostDecrementAssignExpression()
		{
			Name ="operator()--";
		}
	}

	class MetaPreIncrementAssignExpression : MetaUnaryAssignExpression
	{
		MetaPreIncrementAssignExpression()
		{
			Name ="operator++()";
		}
	}

	class MetaPreDecrementAssignExpression : MetaUnaryAssignExpression
	{
		MetaPreDecrementAssignExpression()
		{
			Name ="operator--()";
		}
	}


	abstract class MetaBinaryExpression : MetaOperatorExpression
	{
		BinaryExpression()
		{
			//Arguments += Left;
			//Arguments += Right;
		}

		containment MetaExpression Left;
		containment MetaExpression Right;
	}

	abstract class MetaBinaryArithmeticExpression : MetaBinaryExpression
	{
	}

	class MetaMultiplyExpression : MetaBinaryArithmeticExpression
	{
		MetaMultiplyExpression()
		{
			Name = "operator()*()";
		}
	}

	class MetaDivideExpression : MetaBinaryArithmeticExpression
	{
		MetaDivideExpression()
		{
			Name = "operator()/()";
		}
	}

	class MetaModuloExpression : MetaBinaryArithmeticExpression
	{
		MetaModuloExpression()
		{
			Name = "operator()%()";
		}
	}

	class MetaAddExpression : MetaBinaryArithmeticExpression
	{
		MetaAddExpression()
		{
			Name = "operator()+()";
		}
	}

	class MetaSubtractExpression : MetaBinaryArithmeticExpression
	{
		MetaSubtractExpression()
		{
			Name = "operator()-()";
		}
	}

	class MetaLeftShiftExpression : MetaBinaryArithmeticExpression
	{
		MetaLeftShiftExpression()
		{
			Name = "operator()<<()";
		}
	}

	class MetaRightShiftExpression : MetaBinaryArithmeticExpression
	{
		MetaRightShiftExpression()
		{
			Name = "operator()>>()";
		}
	}


	abstract class MetaBinaryComparisonExpression : MetaBinaryExpression
	{
	}

	class MetaLessThanExpression : MetaBinaryComparisonExpression
	{
		MetaLessThanExpression()
		{
			Name = "operator()<()";
		}
	}

	class MetaLessThanOrEqualExpression : MetaBinaryComparisonExpression
	{
		MetaLessThanOrEqualExpression()
		{
			Name = "operator()<=()";
		}
	}

	class MetaGreaterThanExpression : MetaBinaryComparisonExpression
	{
		MetaGreaterThanExpression()
		{
			Name = "operator()>()";
		}
	}

	class MetaGreaterThanOrEqualExpression : MetaBinaryComparisonExpression
	{
		MetaGreaterThanOrEqualExpression()
		{
			Name = "operator()>=()";
		}
	}

	class MetaEqualExpression : MetaBinaryComparisonExpression
	{
		MetaEqualExpression()
		{
			Name = "operator()==()";
		}
	}

	class MetaNotEqualExpression : MetaBinaryComparisonExpression
	{
		MetaNotEqualExpression()
		{
			Name = "operator()!=()";
		}
	}


	abstract class MetaBinaryLogicalExpression : MetaBinaryExpression
	{
	}

	class MetaAndExpression : MetaBinaryLogicalExpression
	{
		MetaAndExpression()
		{
			Name = "operator()&()";
		}
	}

	class MetaOrExpression : MetaBinaryLogicalExpression
	{
		MetaOrExpression()
		{
			Name = "operator()|()";
		}
	}

	class MetaExclusiveOrExpression : MetaBinaryLogicalExpression
	{
		MetaExclusiveOrExpression()
		{
			Name = "operator()^()";
		}
	}

	class MetaAndAlsoExpression : MetaBinaryLogicalExpression
	{
		MetaAndAlsoExpression()
		{
			Name = "operator()&&()";
		}
	}

	class MetaOrElseExpression : MetaBinaryLogicalExpression
	{
		MetaOrElseExpression()
		{
			Name = "operator()||()";
		}
	}


	class MetaNullCoalescingExpression : MetaBinaryExpression
	{
		MetaNullCoalescingExpression()
		{
			Name = "operator()??()";
		}
	}

	abstract class MetaAssignmentExpression : MetaBinaryExpression
	{
		MetaAssignmentExpression()
		{
			Type = get_type(Left);
			Left.ExpectedType = ExpectedType;
			Right.ExpectedType = Type;
		}
	}

	class MetaAssignExpression : MetaAssignmentExpression
	{
		MetaAssignExpression()
		{
			Name = "operator()=()";
		}
	}


	abstract class MetaArithmeticAssignmentExpression : MetaAssignmentExpression
	{
	}

	class MetaMultiplyAssignExpression : MetaArithmeticAssignmentExpression
	{
		MetaMultiplyAssignExpression()
		{
			Name = "operator()*=()";
		}
	}

	class MetaDivideAssignExpression : MetaArithmeticAssignmentExpression
	{
		MetaDivideAssignExpression()
		{
			Name = "operator()/=()";
		}
	}

	class MetaModuloAssignExpression : MetaArithmeticAssignmentExpression
	{
		MetaModuloAssignExpression()
		{
			Name = "operator()%=()";
		}
	}

	class MetaAddAssignExpression : MetaArithmeticAssignmentExpression
	{
		MetaAddAssignExpression()
		{
			Name = "operator()+=()";
		}
	}

	class MetaSubtractAssignExpression : MetaArithmeticAssignmentExpression
	{
		MetaSubtractAssignExpression()
		{
			Name = "operator()-=()";
		}
	}

	class MetaLeftShiftAssignExpression : MetaArithmeticAssignmentExpression
	{
		MetaLeftShiftAssignExpression()
		{
			Name = "operator()<<=()";
		}
	}

	class MetaRightShiftAssignExpression : MetaArithmeticAssignmentExpression
	{
		MetaRightShiftAssignExpression()
		{
			Name = "operator()>>=()";
		}
	}


	abstract class MetaLogicalAssignmentExpression : MetaAssignmentExpression
	{
	}

	class MetaAndAssignExpression : MetaLogicalAssignmentExpression
	{
		MetaAndAssignExpression()
		{
			Name = "operator()&=()";
		}
	}

	class MetaExclusiveOrAssignExpression : MetaLogicalAssignmentExpression
	{
		MetaExclusiveOrAssignExpression()
		{
			Name = "operator()^=()";
		}
	}

	class MetaOrAssignExpression : MetaLogicalAssignmentExpression
	{
		MetaOrAssignExpression()
		{
			Name = "operator()|=()";
		}
	}

}
namespace MetaDslx.Core
{
	/*
	Represents the MetaModel.
	*/
	metamodel Meta(Uri="http://metadslx.core/1.0"); 

	const MetaPrimitiveType Object;
	const MetaPrimitiveType String;
	const MetaPrimitiveType Int;
	const MetaPrimitiveType Long;
	const MetaPrimitiveType Float;
	const MetaPrimitiveType Double;
	const MetaPrimitiveType Byte;
	const MetaPrimitiveType Bool;
	const MetaPrimitiveType Void;
	const MetaPrimitiveType Symbol;

	[Scope]
	class RootScope
	{
		[ScopeEntry]
		list<object> BuiltInEntries;
		[ScopeEntry]
		containment list<object> Entries;
	}

	/*
	Represents an annotated element.
	*/
	abstract class MetaAnnotatedElement
	{
		// List of annotations
		containment list<MetaAnnotation> Annotations; 
	}

	abstract class MetaDocumentedElement
	{
		string Documentation;
		list<string> GetDocumentationLines();
	}

	abstract class MetaNamedElement : MetaDocumentedElement
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
		MetaNamespace Namespace;
		derived MetaModel MetaModel;
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
		MetaEnum Enum redefines MetaTypedElement.Type;
	}

	association MetaEnumLiteral.Enum with MetaEnum.EnumLiterals;

	class MetaConstant : MetaTypedElement, MetaDeclaration
	{
	}

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
		list<MetaClass> GetAllSuperClasses(bool includeSelf);
		list<MetaProperty> GetAllSuperProperties(bool includeSelf);
		list<MetaOperation> GetAllSuperOperations(bool includeSelf);
		list<MetaProperty> GetAllProperties();
		list<MetaOperation> GetAllOperations();
		list<MetaProperty> GetAllFinalProperties();
		list<MetaOperation> GetAllFinalOperations();
	}
	
	class MetaFunctionType : MetaType
	{
		multi_list<MetaType> ParameterTypes;
		MetaType ReturnType;
	}

	abstract class MetaFunction : MetaTypedElement, MetaNamedElement, MetaAnnotatedElement
	{
		[Type]
		derived MetaFunctionType Type redefines MetaTypedElement.Type;
		containment list<MetaParameter> Parameters;
		MetaType ReturnType;
	}

	class MetaOperation : MetaFunction
	{
		MetaType Parent;
	}

	class MetaConstructor : MetaNamedElement, MetaAnnotatedElement
	{
		MetaClass Parent;
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
		DerivedUnion,
		Containment
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
}

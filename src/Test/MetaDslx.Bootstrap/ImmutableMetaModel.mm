namespace MetaDslx.Languages.Meta.Symbols
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
	class MetaRootNamespace
	{
		containment list<symbol> Symbols;
	}

	class MetaErrorSymbol : MetaNamedElement
	{
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

	class MetaNamedType : MetaType, MetaNamedElement
	{
	}

	class MetaAnnotation : MetaNamedElement
	{
	}

	abstract class MetaDeclaration : MetaNamedElement, MetaAnnotatedElement
	{
		MetaNamespace Namespace;
		derived MetaModel MetaModel;
	}

	[Scope]
	class MetaNamespace : MetaDeclaration
	{
		[Import]
		list<MetaNamespace> Usings;
		containment MetaModel MetaModel;
		containment list<MetaDeclaration> Declarations;
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

	class MetaPrimitiveType : MetaDeclaration, MetaType
	{
	}

	class MetaExternalType : MetaPrimitiveType
	{
		string ExternalName;
		bool IsValueType;
	}

	[Scope]
	class MetaEnum : MetaDeclaration, MetaType
	{
		containment list<MetaEnumLiteral> EnumLiterals;
		containment list<MetaOperation> Operations;
	}

	class MetaEnumLiteral : MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
	{
		MetaEnum Enum redefines Type;
	}

	association MetaEnumLiteral.Enum with MetaEnum.EnumLiterals;

	class MetaConstant : MetaDeclaration, MetaTypedElement
	{
	}

	[Scope]
	class MetaClass : MetaDeclaration, MetaType
	{
		bool IsAbstract;
		[BaseScope]
		list<MetaClass> SuperClasses;
		containment list<MetaProperty> Properties;
		containment list<MetaOperation> Operations;
		list<MetaClass> GetAllSuperClasses(bool includeSelf);
		list<MetaProperty> GetAllSuperProperties(bool includeSelf);
		list<MetaOperation> GetAllSuperOperations(bool includeSelf);
		list<MetaProperty> GetAllProperties();
		list<MetaOperation> GetAllOperations();
		list<MetaProperty> GetAllFinalProperties();
		list<MetaOperation> GetAllFinalOperations();
	}
	
	[LocalScope]
	class MetaOperation : MetaNamedElement, MetaAnnotatedElement
	{
		MetaType Parent;
		containment list<MetaParameter> Parameters;
		MetaType ReturnType;
	}

	association MetaOperation.Parent with MetaClass.Operations;
	association MetaOperation.Parent with MetaEnum.Operations;

	class MetaParameter : MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
	{
		MetaOperation Operation;
	}

	association MetaOperation.Parameters with MetaParameter.Operation;

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

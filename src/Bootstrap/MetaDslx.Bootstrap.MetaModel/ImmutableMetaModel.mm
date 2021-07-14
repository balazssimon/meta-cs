namespace MetaDslx.Languages.Meta.Model
{
	using MetaDslx.CodeAnalysis.Symbols;

	/**
	Represents the MetaModel.
	*/
	metamodel Meta(Uri="http://metadslx.core/1.0"); 

	const MetaPrimitiveType Object = "object";
	const MetaPrimitiveType String = "string";
	const MetaPrimitiveType Int = "int";
	const MetaPrimitiveType Long = "long";
	const MetaPrimitiveType Float = "float";
	const MetaPrimitiveType Double = "double";
	const MetaPrimitiveType Byte = "byte";
	const MetaPrimitiveType Bool = "bool";
	const MetaPrimitiveType Void = "void";
	const MetaPrimitiveType SystemType = "global::System.Type";
	const MetaPrimitiveType ModelObject = "global::MetaDslx.Modeling.IModelObject";
	
	/**
	Represents an element.
	*/
	abstract class MetaElement
	{
		// List of attributes
    [symbol: Attributes]
		list<MetaAttribute> Attributes; 
	}

	abstract class MetaDocumentedElement : MetaElement
	{
		string Documentation;
	}

	[symbol: MemberSymbol]
	abstract class MetaNamedElement : MetaDocumentedElement
	{
		[symbol: Name]
		string Name;
	}

	abstract class MetaTypedElement : MetaElement
	{
		MetaType Type;
	}

	[symbol: TypeSymbol]
	abstract class MetaType
	{
		bool ConformsTo(MetaType type);
	}

	[symbol: NamedTypeSymbol]
	class MetaNamedType : MetaType, MetaDeclaration
	{
	}

	class MetaAttribute : MetaNamedType
	{
	}

	abstract class MetaDeclaration : MetaNamedElement
	{
		MetaNamespace Namespace;
		derived MetaModel MetaModel;
		derived string FullName;
	}
	
	[symbol: NamespaceSymbol]
	class MetaNamespace : MetaDeclaration
	{
		[symbol: Members]
		containment MetaModel DefinedMetaModel;
		[symbol: Members]
		containment list<MetaDeclaration> Declarations;
	}

	association MetaNamespace.Declarations with MetaDeclaration.Namespace;

	class MetaModel : MetaNamedElement
	{
		string Uri;
		string Prefix;
		MetaNamespace Namespace;
	}

	association MetaNamespace.DefinedMetaModel with MetaModel.Namespace;

	enum MetaCollectionKind
	{
		List,
		Set,
		MultiList,
		MultiSet
	}

	[symbol: NamedTypeSymbol]
	class MetaCollectionType : MetaType
	{
		MetaCollectionKind Kind;
		MetaType InnerType;
		bool ConformsTo(MetaType type);
	}

	[symbol: NamedTypeSymbol]
	class MetaNullableType : MetaType
	{
		MetaType InnerType;
		bool ConformsTo(MetaType type);
	}

	class MetaPrimitiveType : MetaNamedType
	{
		bool ConformsTo(MetaType type);
	}

	class MetaEnum : MetaNamedType
	{
		[symbol: Members]
		containment list<MetaEnumLiteral> EnumLiterals;
		[symbol: Members]
		containment list<MetaOperation> Operations;
	}

	class MetaEnumLiteral : MetaNamedElement, MetaTypedElement
	{
		MetaEnum Enum redefines MetaTypedElement.Type;
	}

	association MetaEnumLiteral.Enum with MetaEnum.EnumLiterals;

	class MetaConstant : MetaNamedType, MetaTypedElement
	{
		string DotNetName;
		readonly ModelObject Value;
		bool ConformsTo(MetaType type);
	}

	class MetaClass : MetaNamedType
	{
    [symbol: Attributes]
		SystemType SymbolType;
		bool IsAbstract;
		[symbol: BaseTypes]
		list<MetaClass> SuperClasses;
		[symbol: Members]
		containment list<MetaProperty> Properties;
		[symbol: Members]
		containment list<MetaOperation> Operations;
		bool ConformsTo(MetaType type);
		list<MetaClass> GetAllSuperClasses(bool includeSelf);
		list<MetaProperty> GetAllSuperProperties(bool includeSelf);
		list<MetaOperation> GetAllSuperOperations(bool includeSelf);
		list<MetaProperty> GetAllProperties();
		list<MetaOperation> GetAllOperations();
		list<MetaProperty> GetAllFinalProperties();
		list<MetaOperation> GetAllFinalOperations();
	}
	
	class MetaOperation : MetaNamedElement
	{
		MetaClass Class;
		MetaEnum Enum;
		bool IsBuilder;
		bool IsReadonly;
		containment list<MetaParameter> Parameters;
		MetaType ReturnType;
		bool ConformsTo(MetaOperation operation);
	}

	association MetaOperation.Class with MetaClass.Operations;
	association MetaOperation.Enum with MetaEnum.Operations;

	class MetaParameter : MetaNamedElement, MetaTypedElement
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
		DerivedUnion
	}

	class MetaProperty : MetaNamedElement, MetaTypedElement
	{
		string SymbolProperty;
		MetaPropertyKind Kind;
		MetaClass Class;
		string DefaultValue;
		bool IsContainment;
		list<MetaProperty> OppositeProperties;
		list<MetaProperty> SubsettedProperties;
		list<MetaProperty> SubsettingProperties;
		list<MetaProperty> RedefinedProperties;
		list<MetaProperty> RedefiningProperties;
		bool ConformsTo(MetaProperty property);
	}

	association MetaProperty.Class with MetaClass.Properties;
	association MetaProperty.OppositeProperties with MetaProperty.OppositeProperties;
	association MetaProperty.SubsettedProperties with MetaProperty.SubsettingProperties;
	association MetaProperty.RedefinedProperties with MetaProperty.RedefiningProperties;
}

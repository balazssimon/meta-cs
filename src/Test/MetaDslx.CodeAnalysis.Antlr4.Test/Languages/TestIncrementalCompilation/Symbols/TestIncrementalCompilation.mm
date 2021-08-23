namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols
{
	using MetaDslx.CodeAnalysis.Symbols;

	/**
	Represents the MetaModel.
	*/
	metamodel TestIncrementalCompilation(Uri="http://metadslx.core/1.0"); 

	const MetaPrimitiveType Object = "System.Object";
	const MetaPrimitiveType String = "System.String";
	const MetaPrimitiveType Int = "System.Int32";
	const MetaPrimitiveType Long = "System.Int64";
	const MetaPrimitiveType Float = "System.Single";
	const MetaPrimitiveType Double = "System.Double";
	const MetaPrimitiveType Byte = "System.Byte";
	const MetaPrimitiveType Bool = "System.Boolean";
	const MetaPrimitiveType Void = "System.Void";
	const MetaPrimitiveType SystemType = "System.Type";
	const MetaPrimitiveType ModelObject = "MetaDslx.Modeling.IModelObject";
	
	/**
	Represents an element.
	*/
	[symbol: Symbol]
	abstract class MetaElement
	{
		// List of attributes
		[property: Attributes]
		list<MetaAttribute> Attributes; 
	}

	abstract class MetaDocumentedElement : MetaElement
	{
		string Documentation;
	}

	abstract class MetaNamedElement : MetaDocumentedElement
	{
		[property: Name]
		string Name;
	}

	abstract class MetaTypedElement : MetaElement
	{
		MetaType Type;
	}

	[type: TypeSymbol]
	abstract class MetaType
	{
		bool ConformsTo(MetaType type);
	}
	
	[type: Named]
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
	
	[symbol: Namespace]
	class MetaNamespace : MetaDeclaration
	{
		[property: Members]
		containment MetaModel DefinedMetaModel;
		[property: Members]
		containment list<MetaDeclaration> Declarations;
	}

	association MetaNamespace.Declarations with MetaDeclaration.Namespace;

	[type: Named]
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

	[type: Array]
	class MetaCollectionType : MetaType
	{
		MetaCollectionKind Kind;
		[property: ElementType]
		MetaType InnerType;
		bool ConformsTo(MetaType type);
	}

	[type: Nullable]
	class MetaNullableType : MetaType
	{
		[property: InnerType]
		MetaType InnerType;
		bool ConformsTo(MetaType type);
	}

	class MetaPrimitiveType : MetaNamedType
	{
		string DotNetName;
		bool ConformsTo(MetaType type);
	}

	[type: Enum]
	class MetaEnum : MetaNamedType
	{
		[property: Members]
		containment list<MetaEnumLiteral> EnumLiterals;
		[property: Members]
		containment list<MetaOperation> Operations;
	}

	[symbol: EnumLiteral]
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

	[type: Class]
	class MetaClass : MetaNamedType
	{
		[property: Attributes]
		SystemType SymbolType;
		bool IsAbstract;
		[property: BaseTypes]
		list<MetaClass> SuperClasses;
		[property: Members]
		containment list<MetaProperty> Properties;
		[property: Members]
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
	
	[symbol: Method]
	class MetaOperation : MetaNamedElement
	{
		MetaClass Class;
		MetaEnum Enum;
		bool IsBuilder;
		bool IsReadonly;
		[property: Members]
		containment list<MetaParameter> Parameters;
		[property: ReturnType]
		MetaType ReturnType;
		bool ConformsTo(MetaOperation operation);
	}

	association MetaOperation.Class with MetaClass.Operations;
	association MetaOperation.Enum with MetaEnum.Operations;

	[symbol: Parameter]
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

	[symbol: Property]
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


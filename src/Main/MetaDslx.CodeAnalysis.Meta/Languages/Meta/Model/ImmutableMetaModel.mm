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
		list<MetaAttribute> Attributes; 
	}

	abstract class MetaDocumentedElement : MetaElement
	{
		string Documentation;
	}

	abstract class MetaNamedElement[MemberSymbol] : MetaDocumentedElement
	{
		string Name[Name];
	}

	abstract class MetaTypedElement : MetaElement
	{
		MetaType Type;
	}

	abstract class MetaType[TypeSymbol]
	{
		bool ConformsTo(MetaType type);
	}

	class MetaNamedType[NamedTypeSymbol] : MetaType, MetaDeclaration
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
	
	class MetaNamespace[NamespaceSymbol] : MetaDeclaration
	{
		containment MetaModel DefinedMetaModel[Members];
		containment list<MetaDeclaration> Declarations[Members];
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

	class MetaCollectionType[NamedTypeSymbol] : MetaType
	{
		MetaCollectionKind Kind;
		MetaType InnerType;
		bool ConformsTo(MetaType type);
	}

	class MetaNullableType[NamedTypeSymbol] : MetaType
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
		containment list<MetaEnumLiteral> EnumLiterals[Members];
		containment list<MetaOperation> Operations[Members];
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
		SystemType SymbolType;
		bool IsAbstract;
		list<MetaClass> SuperClasses[DeclaredBaseTypes];
		containment list<MetaProperty> Properties[Members];
		containment list<MetaOperation> Operations[Members];
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

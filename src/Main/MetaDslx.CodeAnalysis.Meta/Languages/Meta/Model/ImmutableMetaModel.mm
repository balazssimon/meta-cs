namespace MetaDslx.Languages.Meta.Model
{
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
	const MetaPrimitiveType ModelObject = "global::MetaDslx.Modeling.IModelObject";
	
	const MetaAttribute NameAttribute = "NameAttribute";
	const MetaAttribute TypeAttribute = "TypeAttribute";
	const MetaAttribute ScopeAttribute = "ScopeAttribute";
	const MetaAttribute BaseScopeAttribute = "BaseScopeAttribute";
	const MetaAttribute LocalScopeAttribute = "LocalScopeAttribute";
	
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
		list<string> GetDocumentationLines();
	}

	abstract class MetaNamedElement : MetaDocumentedElement
	{
		[Name]
		string Name;
	}

	abstract class MetaTypedElement : MetaElement
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

	class MetaAttribute : MetaNamedElement
	{
	}

	abstract class MetaDeclaration : MetaNamedElement
	{
		MetaNamespace Namespace;
		derived MetaModel MetaModel;
		derived string FullName;
	}
	
	[Scope]
	class MetaNamespace : MetaDeclaration
	{
		containment MetaModel DefinedMetaModel;
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

	[Scope]
	class MetaEnum : MetaDeclaration, MetaType
	{
		containment list<MetaEnumLiteral> EnumLiterals;
		containment list<MetaOperation> Operations;
	}

	class MetaEnumLiteral : MetaNamedElement, MetaTypedElement
	{
		MetaEnum Enum redefines MetaTypedElement.Type;
	}

	association MetaEnumLiteral.Enum with MetaEnum.EnumLiterals;

	class MetaConstant : MetaDeclaration, MetaTypedElement, MetaType
	{
		string DotNetName;
		readonly ModelObject Value;
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
	class MetaOperation : MetaNamedElement
	{
		MetaType Parent;
		bool IsBuilder;
		bool IsReadonly;
		containment list<MetaParameter> Parameters;
		MetaType ReturnType;
	}

	association MetaOperation.Parent with MetaClass.Operations;
	association MetaOperation.Parent with MetaEnum.Operations;

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
		DerivedUnion,
		Containment
	}

	class MetaProperty : MetaNamedElement, MetaTypedElement
	{
		MetaPropertyKind Kind;
		MetaClass Class;
		string DefaultValue;
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

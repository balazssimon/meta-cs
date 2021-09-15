﻿namespace MetaDslx.Languages.Meta.Model
{
	using MetaDslx.CodeAnalysis.Symbols;

	/**
	Represents the MetaModel.
	*/
	metamodel Meta(Uri="http://MetaDslx.Languages.Meta/1.0",MajorVersion=1,MinorVersion=0); 
	
	const MetaPrimitiveType Object;
	const MetaPrimitiveType String;
	const MetaPrimitiveType Int;
	const MetaPrimitiveType Long;
	const MetaPrimitiveType Float;
	const MetaPrimitiveType Double;
	const MetaPrimitiveType Byte;
	const MetaPrimitiveType Bool;
	const MetaPrimitiveType Void;
	const MetaPrimitiveType SystemType;
	const MetaPrimitiveType Model;
	const MetaPrimitiveType ModelObject;
	
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
	abstract class MetaType : MetaElement
	{
		bool ConformsTo(MetaType @type);
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
		int MajorVersion;
		int MinorVersion;
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
		MultiSet,
		Enumerable
	}

	[type: Array]
	class MetaCollectionType : MetaType
	{
		MetaCollectionKind Kind;
		[property: ElementType]
		MetaType InnerType;
		bool ConformsTo(MetaType @type);
	}

	[type: Nullable]
	class MetaNullableType : MetaType
	{
		[property: InnerType]
		MetaType InnerType;
		bool ConformsTo(MetaType @type);
	}

	[type: Named]
	class MetaPrimitiveType : MetaNamedType
	{
		string DotNetName;
		bool ConformsTo(MetaType @type);
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

	[symbol: Variable]
	class MetaConstant : MetaDeclaration, MetaTypedElement
	{
		[property: Type]
		MetaType Type redefines MetaTypedElement.Type;
		readonly object Value;
	}

	[type: Class]
	class MetaClass : MetaNamedType
	{
		SystemType SymbolType;
		bool IsAbstract;
		[property: BaseTypes]
		list<MetaClass> SuperClasses;
		[property: Members]
		containment list<MetaProperty> Properties;
		[property: Members]
		containment list<MetaOperation> Operations;
		bool ConformsTo(MetaType @type);
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
		[property: Result]
		MetaParameter Result;
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
		bool ConformsTo(MetaProperty @property);
	}

	association MetaProperty.Class with MetaClass.Properties;
	association MetaProperty.OppositeProperties with MetaProperty.OppositeProperties;
	association MetaProperty.SubsettedProperties with MetaProperty.SubsettingProperties;
	association MetaProperty.RedefinedProperties with MetaProperty.RedefiningProperties;
}

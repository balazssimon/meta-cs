namespace MetaDslx.Core = "http://metadslx.core/1.0"
{
	metamodel Meta
	{
		const MetaPrimitiveType ObjectType;
		const MetaPrimitiveType BoolType;
		const MetaPrimitiveType StringType;
		const MetaPrimitiveType ByteType;
		const MetaPrimitiveType IntType;
		const MetaPrimitiveType LongType;
		const MetaPrimitiveType FloatType;
		const MetaPrimitiveType DoubleType;
		const MetaPrimitiveType VoidType;

		class MetaNamespace
		{
			string Name;
			string Uri;
			containment set<MetaModel> Models;
		}

		class MetaModel
		{
			string Name;
			MetaNamespace Namespace;
			containment set<MetaType> Types;
		}

		association MetaNamespace.Models with MetaModel.Namespace;

		class MetaType
		{
			string Name;
			MetaModel Model;
			derived MetaNamespace Namespace;
		}

		association MetaModel.Types with MetaType.Model;

		enum MetaCollectionKind
		{
			Set,
			List
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

		class MetaPrimitiveType : MetaType
		{
		}

		class MetaEnum : MetaType
		{
			containment list<MetaEnumLiteral> EnumLiterals;
			containment set<MetaOperation> Operations;
		}

		class MetaEnumLiteral
		{
			string Name;
		}

		class MetaClass : MetaType
		{
			list<MetaClass> SuperClasses;
			containment set<MetaProperty> Properties;
			containment set<MetaOperation> Operations;
			set<MetaClass> GetAllSuperClasses();
			set<MetaProperty> GetAllProperties();
			set<MetaOperation> GetAllOperations();
		}

		class MetaOperation
		{
			string Name;
			containment list<MetaParameter> Parameters;
			MetaType ReturnType;
			MetaClass Class;
			MetaEnum Enum;
		}

		association MetaClass.Operations with MetaOperation.Class;
		association MetaEnum.Operations with MetaOperation.Enum;

		class MetaParameter
		{
			string Name;
			MetaType Type;
			MetaOperation Operation;
		}

		association MetaOperation.Parameters with MetaParameter.Operation;

		enum MetaPropertyKind
		{
			Normal,
			Readonly,
			Lazy,
			Derived,
			Containment
		}

		class MetaProperty
		{
			string Name;
			MetaPropertyKind Kind;
			MetaType Type;
			MetaClass Class;
			set<MetaProperty> Opposites;
		}

		association MetaClass.Properties with MetaProperty.Class;
		association MetaProperty.Opposites with MetaProperty.Opposites;

	}
}
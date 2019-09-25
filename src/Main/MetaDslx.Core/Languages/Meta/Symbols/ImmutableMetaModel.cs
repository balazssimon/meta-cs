using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetaDslx.Languages.Meta.Symbols
{
	using global::MetaDslx.Languages.Meta.Symbols.Internal;

	public class MetaInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return MetaInstance.initialized; }
		}
	
		public static readonly MetaModel MetaMetaModel;
		public static readonly global::MetaDslx.Modeling.ImmutableModel Model;
	
		public static readonly MetaPrimitiveType Object;
		public static readonly MetaPrimitiveType String;
		public static readonly MetaPrimitiveType Int;
		public static readonly MetaPrimitiveType Long;
		public static readonly MetaPrimitiveType Float;
		public static readonly MetaPrimitiveType Double;
		public static readonly MetaPrimitiveType Byte;
		public static readonly MetaPrimitiveType Bool;
		public static readonly MetaPrimitiveType Void;
		public static readonly MetaPrimitiveType ModelObject;
		public static readonly MetaAttribute NameAttribute;
		public static readonly MetaAttribute TypeAttribute;
		public static readonly MetaAttribute ScopeAttribute;
		public static readonly MetaAttribute BaseScopeAttribute;
		public static readonly MetaAttribute LocalScopeAttribute;
	
		public static readonly MetaClass MetaElement;
		public static readonly MetaProperty MetaElement_Attributes;
		public static readonly MetaClass MetaDocumentedElement;
		public static readonly MetaProperty MetaDocumentedElement_Documentation;
		public static readonly MetaClass MetaNamedElement;
		public static readonly MetaProperty MetaNamedElement_Name;
		public static readonly MetaClass MetaTypedElement;
		public static readonly MetaProperty MetaTypedElement_Type;
		public static readonly MetaClass MetaType;
		public static readonly MetaClass MetaNamedType;
		public static readonly MetaClass MetaAttribute;
		public static readonly MetaClass MetaDeclaration;
		public static readonly MetaProperty MetaDeclaration_Namespace;
		public static readonly MetaProperty MetaDeclaration_MetaModel;
		public static readonly MetaClass MetaNamespace;
		public static readonly MetaProperty MetaNamespace_DefinedMetaModel;
		public static readonly MetaProperty MetaNamespace_Declarations;
		public static readonly MetaClass MetaModel;
		public static readonly MetaProperty MetaModel_Uri;
		public static readonly MetaProperty MetaModel_Namespace;
		public static readonly MetaClass MetaCollectionType;
		public static readonly MetaProperty MetaCollectionType_Kind;
		public static readonly MetaProperty MetaCollectionType_InnerType;
		public static readonly MetaClass MetaNullableType;
		public static readonly MetaProperty MetaNullableType_InnerType;
		public static readonly MetaClass MetaPrimitiveType;
		public static readonly MetaClass MetaEnum;
		public static readonly MetaProperty MetaEnum_EnumLiterals;
		public static readonly MetaProperty MetaEnum_Operations;
		public static readonly MetaClass MetaEnumLiteral;
		public static readonly MetaProperty MetaEnumLiteral_Enum;
		public static readonly MetaClass MetaConstant;
		public static readonly MetaClass MetaClass;
		public static readonly MetaProperty MetaClass_IsAbstract;
		public static readonly MetaProperty MetaClass_SuperClasses;
		public static readonly MetaProperty MetaClass_Properties;
		public static readonly MetaProperty MetaClass_Operations;
		public static readonly MetaClass MetaOperation;
		public static readonly MetaProperty MetaOperation_Parent;
		public static readonly MetaProperty MetaOperation_Parameters;
		public static readonly MetaProperty MetaOperation_ReturnType;
		public static readonly MetaClass MetaParameter;
		public static readonly MetaProperty MetaParameter_Operation;
		public static readonly MetaClass MetaProperty;
		public static readonly MetaProperty MetaProperty_Kind;
		public static readonly MetaProperty MetaProperty_Class;
		public static readonly MetaProperty MetaProperty_OppositeProperties;
		public static readonly MetaProperty MetaProperty_SubsettedProperties;
		public static readonly MetaProperty MetaProperty_SubsettingProperties;
		public static readonly MetaProperty MetaProperty_RedefinedProperties;
		public static readonly MetaProperty MetaProperty_RedefiningProperties;
	
		static MetaInstance()
		{
			MetaBuilderInstance.instance.Create();
			MetaBuilderInstance.instance.EvaluateLazyValues();
			MetaMetaModel = MetaBuilderInstance.instance.MetaMetaModel.ToImmutable();
			Model = MetaBuilderInstance.instance.Model.ToImmutable();
	
			Object = MetaBuilderInstance.instance.Object.ToImmutable(Model);
			String = MetaBuilderInstance.instance.String.ToImmutable(Model);
			Int = MetaBuilderInstance.instance.Int.ToImmutable(Model);
			Long = MetaBuilderInstance.instance.Long.ToImmutable(Model);
			Float = MetaBuilderInstance.instance.Float.ToImmutable(Model);
			Double = MetaBuilderInstance.instance.Double.ToImmutable(Model);
			Byte = MetaBuilderInstance.instance.Byte.ToImmutable(Model);
			Bool = MetaBuilderInstance.instance.Bool.ToImmutable(Model);
			Void = MetaBuilderInstance.instance.Void.ToImmutable(Model);
			ModelObject = MetaBuilderInstance.instance.ModelObject.ToImmutable(Model);
			NameAttribute = MetaBuilderInstance.instance.NameAttribute.ToImmutable(Model);
			TypeAttribute = MetaBuilderInstance.instance.TypeAttribute.ToImmutable(Model);
			ScopeAttribute = MetaBuilderInstance.instance.ScopeAttribute.ToImmutable(Model);
			BaseScopeAttribute = MetaBuilderInstance.instance.BaseScopeAttribute.ToImmutable(Model);
			LocalScopeAttribute = MetaBuilderInstance.instance.LocalScopeAttribute.ToImmutable(Model);
	
			MetaElement = MetaBuilderInstance.instance.MetaElement.ToImmutable(Model);
			MetaElement_Attributes = MetaBuilderInstance.instance.MetaElement_Attributes.ToImmutable(Model);
			MetaDocumentedElement = MetaBuilderInstance.instance.MetaDocumentedElement.ToImmutable(Model);
			MetaDocumentedElement_Documentation = MetaBuilderInstance.instance.MetaDocumentedElement_Documentation.ToImmutable(Model);
			MetaNamedElement = MetaBuilderInstance.instance.MetaNamedElement.ToImmutable(Model);
			MetaNamedElement_Name = MetaBuilderInstance.instance.MetaNamedElement_Name.ToImmutable(Model);
			MetaTypedElement = MetaBuilderInstance.instance.MetaTypedElement.ToImmutable(Model);
			MetaTypedElement_Type = MetaBuilderInstance.instance.MetaTypedElement_Type.ToImmutable(Model);
			MetaType = MetaBuilderInstance.instance.MetaType.ToImmutable(Model);
			MetaNamedType = MetaBuilderInstance.instance.MetaNamedType.ToImmutable(Model);
			MetaAttribute = MetaBuilderInstance.instance.MetaAttribute.ToImmutable(Model);
			MetaDeclaration = MetaBuilderInstance.instance.MetaDeclaration.ToImmutable(Model);
			MetaDeclaration_Namespace = MetaBuilderInstance.instance.MetaDeclaration_Namespace.ToImmutable(Model);
			MetaDeclaration_MetaModel = MetaBuilderInstance.instance.MetaDeclaration_MetaModel.ToImmutable(Model);
			MetaNamespace = MetaBuilderInstance.instance.MetaNamespace.ToImmutable(Model);
			MetaNamespace_DefinedMetaModel = MetaBuilderInstance.instance.MetaNamespace_DefinedMetaModel.ToImmutable(Model);
			MetaNamespace_Declarations = MetaBuilderInstance.instance.MetaNamespace_Declarations.ToImmutable(Model);
			MetaModel = MetaBuilderInstance.instance.MetaModel.ToImmutable(Model);
			MetaModel_Uri = MetaBuilderInstance.instance.MetaModel_Uri.ToImmutable(Model);
			MetaModel_Namespace = MetaBuilderInstance.instance.MetaModel_Namespace.ToImmutable(Model);
			MetaCollectionType = MetaBuilderInstance.instance.MetaCollectionType.ToImmutable(Model);
			MetaCollectionType_Kind = MetaBuilderInstance.instance.MetaCollectionType_Kind.ToImmutable(Model);
			MetaCollectionType_InnerType = MetaBuilderInstance.instance.MetaCollectionType_InnerType.ToImmutable(Model);
			MetaNullableType = MetaBuilderInstance.instance.MetaNullableType.ToImmutable(Model);
			MetaNullableType_InnerType = MetaBuilderInstance.instance.MetaNullableType_InnerType.ToImmutable(Model);
			MetaPrimitiveType = MetaBuilderInstance.instance.MetaPrimitiveType.ToImmutable(Model);
			MetaEnum = MetaBuilderInstance.instance.MetaEnum.ToImmutable(Model);
			MetaEnum_EnumLiterals = MetaBuilderInstance.instance.MetaEnum_EnumLiterals.ToImmutable(Model);
			MetaEnum_Operations = MetaBuilderInstance.instance.MetaEnum_Operations.ToImmutable(Model);
			MetaEnumLiteral = MetaBuilderInstance.instance.MetaEnumLiteral.ToImmutable(Model);
			MetaEnumLiteral_Enum = MetaBuilderInstance.instance.MetaEnumLiteral_Enum.ToImmutable(Model);
			MetaConstant = MetaBuilderInstance.instance.MetaConstant.ToImmutable(Model);
			MetaClass = MetaBuilderInstance.instance.MetaClass.ToImmutable(Model);
			MetaClass_IsAbstract = MetaBuilderInstance.instance.MetaClass_IsAbstract.ToImmutable(Model);
			MetaClass_SuperClasses = MetaBuilderInstance.instance.MetaClass_SuperClasses.ToImmutable(Model);
			MetaClass_Properties = MetaBuilderInstance.instance.MetaClass_Properties.ToImmutable(Model);
			MetaClass_Operations = MetaBuilderInstance.instance.MetaClass_Operations.ToImmutable(Model);
			MetaOperation = MetaBuilderInstance.instance.MetaOperation.ToImmutable(Model);
			MetaOperation_Parent = MetaBuilderInstance.instance.MetaOperation_Parent.ToImmutable(Model);
			MetaOperation_Parameters = MetaBuilderInstance.instance.MetaOperation_Parameters.ToImmutable(Model);
			MetaOperation_ReturnType = MetaBuilderInstance.instance.MetaOperation_ReturnType.ToImmutable(Model);
			MetaParameter = MetaBuilderInstance.instance.MetaParameter.ToImmutable(Model);
			MetaParameter_Operation = MetaBuilderInstance.instance.MetaParameter_Operation.ToImmutable(Model);
			MetaProperty = MetaBuilderInstance.instance.MetaProperty.ToImmutable(Model);
			MetaProperty_Kind = MetaBuilderInstance.instance.MetaProperty_Kind.ToImmutable(Model);
			MetaProperty_Class = MetaBuilderInstance.instance.MetaProperty_Class.ToImmutable(Model);
			MetaProperty_OppositeProperties = MetaBuilderInstance.instance.MetaProperty_OppositeProperties.ToImmutable(Model);
			MetaProperty_SubsettedProperties = MetaBuilderInstance.instance.MetaProperty_SubsettedProperties.ToImmutable(Model);
			MetaProperty_SubsettingProperties = MetaBuilderInstance.instance.MetaProperty_SubsettingProperties.ToImmutable(Model);
			MetaProperty_RedefinedProperties = MetaBuilderInstance.instance.MetaProperty_RedefinedProperties.ToImmutable(Model);
			MetaProperty_RedefiningProperties = MetaBuilderInstance.instance.MetaProperty_RedefiningProperties.ToImmutable(Model);
	
			MetaInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class MetaFactory : global::MetaDslx.Modeling.ModelFactory
	{
		public MetaFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
			: base(model, flags)
		{
			MetaDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Modeling.MutableSymbol Create(string type)
		{
			switch (type)
			{
				case "MetaElement": return this.MetaElement();
				case "MetaDocumentedElement": return this.MetaDocumentedElement();
				case "MetaNamedElement": return this.MetaNamedElement();
				case "MetaTypedElement": return this.MetaTypedElement();
				case "MetaType": return this.MetaType();
				case "MetaNamedType": return this.MetaNamedType();
				case "MetaAttribute": return this.MetaAttribute();
				case "MetaDeclaration": return this.MetaDeclaration();
				case "MetaNamespace": return this.MetaNamespace();
				case "MetaModel": return this.MetaModel();
				case "MetaCollectionType": return this.MetaCollectionType();
				case "MetaNullableType": return this.MetaNullableType();
				case "MetaPrimitiveType": return this.MetaPrimitiveType();
				case "MetaEnum": return this.MetaEnum();
				case "MetaEnumLiteral": return this.MetaEnumLiteral();
				case "MetaConstant": return this.MetaConstant();
				case "MetaClass": return this.MetaClass();
				case "MetaOperation": return this.MetaOperation();
				case "MetaParameter": return this.MetaParameter();
				case "MetaProperty": return this.MetaProperty();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::Microsoft.CodeAnalysis.Location.None, new global::MetaDslx.CodeAnalysis.LanguageDiagnosticInfo(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName, type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of MetaElement.
		/// </summary>
		public MetaElementBuilder MetaElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaElementId());
			return (MetaElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaDocumentedElement.
		/// </summary>
		public MetaDocumentedElementBuilder MetaDocumentedElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaDocumentedElementId());
			return (MetaDocumentedElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNamedElement.
		/// </summary>
		public MetaNamedElementBuilder MetaNamedElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaNamedElementId());
			return (MetaNamedElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaTypedElement.
		/// </summary>
		public MetaTypedElementBuilder MetaTypedElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaTypedElementId());
			return (MetaTypedElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaType.
		/// </summary>
		public MetaTypeBuilder MetaType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaTypeId());
			return (MetaTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNamedType.
		/// </summary>
		public MetaNamedTypeBuilder MetaNamedType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaNamedTypeId());
			return (MetaNamedTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaAttribute.
		/// </summary>
		public MetaAttributeBuilder MetaAttribute()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaAttributeId());
			return (MetaAttributeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaDeclaration.
		/// </summary>
		public MetaDeclarationBuilder MetaDeclaration()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaDeclarationId());
			return (MetaDeclarationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNamespace.
		/// </summary>
		public MetaNamespaceBuilder MetaNamespace()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaNamespaceId());
			return (MetaNamespaceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaModel.
		/// </summary>
		public MetaModelBuilder MetaModel()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaModelId());
			return (MetaModelBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaCollectionType.
		/// </summary>
		public MetaCollectionTypeBuilder MetaCollectionType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaCollectionTypeId());
			return (MetaCollectionTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNullableType.
		/// </summary>
		public MetaNullableTypeBuilder MetaNullableType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaNullableTypeId());
			return (MetaNullableTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaPrimitiveType.
		/// </summary>
		public MetaPrimitiveTypeBuilder MetaPrimitiveType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaPrimitiveTypeId());
			return (MetaPrimitiveTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaEnum.
		/// </summary>
		public MetaEnumBuilder MetaEnum()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaEnumId());
			return (MetaEnumBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaEnumLiteral.
		/// </summary>
		public MetaEnumLiteralBuilder MetaEnumLiteral()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaEnumLiteralId());
			return (MetaEnumLiteralBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaConstant.
		/// </summary>
		public MetaConstantBuilder MetaConstant()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaConstantId());
			return (MetaConstantBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaClass.
		/// </summary>
		public MetaClassBuilder MetaClass()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaClassId());
			return (MetaClassBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaOperation.
		/// </summary>
		public MetaOperationBuilder MetaOperation()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaOperationId());
			return (MetaOperationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaParameter.
		/// </summary>
		public MetaParameterBuilder MetaParameter()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaParameterId());
			return (MetaParameterBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaProperty.
		/// </summary>
		public MetaPropertyBuilder MetaProperty()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MetaPropertyId());
			return (MetaPropertyBuilder)symbol;
		}
	}
	

	
	public enum MetaCollectionKind
	{
		List,
		Set,
		MultiList,
		MultiSet
	}
	
	public static class MetaCollectionKindExtensions
	{
	}
	
	public enum MetaPropertyKind
	{
		Normal,
		Readonly,
		Lazy,
		Derived,
		DerivedUnion,
		Containment
	}
	
	public static class MetaPropertyKindExtensions
	{
	}
	
	public interface MetaElement : global::MetaDslx.Modeling.ImmutableSymbol
	{
		global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes { get; }
	
	
		new MetaElementBuilder ToMutable();
		new MetaElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaElementBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
		global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes { get; }
	
		new MetaElement ToImmutable();
		new MetaElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaDocumentedElement : MetaElement
	{
		string Documentation { get; }
	
		global::MetaDslx.Modeling.ImmutableModelList<string> GetDocumentationLines();
	
		new MetaDocumentedElementBuilder ToMutable();
		new MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaDocumentedElementBuilder : MetaElementBuilder
	{
		string Documentation { get; set; }
		Func<string> DocumentationLazy { get; set; }
	
		new MetaDocumentedElement ToImmutable();
		new MetaDocumentedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaNamedElement : MetaDocumentedElement
	{
		string Name { get; }
	
	
		new MetaNamedElementBuilder ToMutable();
		new MetaNamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaNamedElementBuilder : MetaDocumentedElementBuilder
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
	
		new MetaNamedElement ToImmutable();
		new MetaNamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaTypedElement : MetaElement
	{
		MetaType Type { get; }
	
	
		new MetaTypedElementBuilder ToMutable();
		new MetaTypedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaTypedElementBuilder : MetaElementBuilder
	{
		MetaTypeBuilder Type { get; set; }
		Func<MetaTypeBuilder> TypeLazy { get; set; }
	
		new MetaTypedElement ToImmutable();
		new MetaTypedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaType : global::MetaDslx.Modeling.ImmutableSymbol
	{
	
	
		new MetaTypeBuilder ToMutable();
		new MetaTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaTypeBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
	
		new MetaType ToImmutable();
		new MetaType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaNamedType : MetaType, MetaNamedElement
	{
	
	
		new MetaNamedTypeBuilder ToMutable();
		new MetaNamedTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaNamedTypeBuilder : MetaTypeBuilder, MetaNamedElementBuilder
	{
	
		new MetaNamedType ToImmutable();
		new MetaNamedType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaAttribute : MetaNamedElement
	{
	
	
		new MetaAttributeBuilder ToMutable();
		new MetaAttributeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaAttributeBuilder : MetaNamedElementBuilder
	{
	
		new MetaAttribute ToImmutable();
		new MetaAttribute ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaDeclaration : MetaNamedElement
	{
		MetaNamespace Namespace { get; }
		MetaModel MetaModel { get; }
	
	
		new MetaDeclarationBuilder ToMutable();
		new MetaDeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaDeclarationBuilder : MetaNamedElementBuilder
	{
		MetaNamespaceBuilder Namespace { get; set; }
		Func<MetaNamespaceBuilder> NamespaceLazy { get; set; }
		MetaModelBuilder MetaModel { get; }
		Func<MetaModelBuilder> MetaModelLazy { get; set; }
	
		new MetaDeclaration ToImmutable();
		new MetaDeclaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaNamespace : MetaDeclaration
	{
		MetaModel DefinedMetaModel { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaDeclaration> Declarations { get; }
	
	
		new MetaNamespaceBuilder ToMutable();
		new MetaNamespaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaNamespaceBuilder : MetaDeclarationBuilder
	{
		MetaModelBuilder DefinedMetaModel { get; set; }
		Func<MetaModelBuilder> DefinedMetaModelLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<MetaDeclarationBuilder> Declarations { get; }
	
		new MetaNamespace ToImmutable();
		new MetaNamespace ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaModel : MetaNamedElement
	{
		string Uri { get; }
		MetaNamespace Namespace { get; }
	
	
		new MetaModelBuilder ToMutable();
		new MetaModelBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaModelBuilder : MetaNamedElementBuilder
	{
		string Uri { get; set; }
		Func<string> UriLazy { get; set; }
		MetaNamespaceBuilder Namespace { get; set; }
		Func<MetaNamespaceBuilder> NamespaceLazy { get; set; }
	
		new MetaModel ToImmutable();
		new MetaModel ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaCollectionType : MetaType
	{
		MetaCollectionKind Kind { get; }
		MetaType InnerType { get; }
	
	
		new MetaCollectionTypeBuilder ToMutable();
		new MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaCollectionTypeBuilder : MetaTypeBuilder
	{
		MetaCollectionKind Kind { get; set; }
		Func<MetaCollectionKind> KindLazy { get; set; }
		MetaTypeBuilder InnerType { get; set; }
		Func<MetaTypeBuilder> InnerTypeLazy { get; set; }
	
		new MetaCollectionType ToImmutable();
		new MetaCollectionType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaNullableType : MetaType
	{
		MetaType InnerType { get; }
	
	
		new MetaNullableTypeBuilder ToMutable();
		new MetaNullableTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaNullableTypeBuilder : MetaTypeBuilder
	{
		MetaTypeBuilder InnerType { get; set; }
		Func<MetaTypeBuilder> InnerTypeLazy { get; set; }
	
		new MetaNullableType ToImmutable();
		new MetaNullableType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaPrimitiveType : MetaDeclaration, MetaType
	{
	
	
		new MetaPrimitiveTypeBuilder ToMutable();
		new MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaPrimitiveTypeBuilder : MetaDeclarationBuilder, MetaTypeBuilder
	{
	
		new MetaPrimitiveType ToImmutable();
		new MetaPrimitiveType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaEnum : MetaDeclaration, MetaType
	{
		global::MetaDslx.Modeling.ImmutableModelList<MetaEnumLiteral> EnumLiterals { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations { get; }
	
	
		new MetaEnumBuilder ToMutable();
		new MetaEnumBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaEnumBuilder : MetaDeclarationBuilder, MetaTypeBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations { get; }
	
		new MetaEnum ToImmutable();
		new MetaEnum ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaEnumLiteral : MetaNamedElement, MetaTypedElement
	{
		MetaEnum Enum { get; }
	
	
		new MetaEnumLiteralBuilder ToMutable();
		new MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaEnumLiteralBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder
	{
		MetaEnumBuilder Enum { get; set; }
		Func<MetaEnumBuilder> EnumLazy { get; set; }
	
		new MetaEnumLiteral ToImmutable();
		new MetaEnumLiteral ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaConstant : MetaDeclaration, MetaTypedElement
	{
	
	
		new MetaConstantBuilder ToMutable();
		new MetaConstantBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaConstantBuilder : MetaDeclarationBuilder, MetaTypedElementBuilder
	{
	
		new MetaConstant ToImmutable();
		new MetaConstant ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaClass : MetaDeclaration, MetaType
	{
		bool IsAbstract { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaClass> SuperClasses { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> Properties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations { get; }
	
		global::MetaDslx.Modeling.ImmutableModelList<MetaClass> GetAllSuperClasses(bool includeSelf);
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> GetAllSuperProperties(bool includeSelf);
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> GetAllSuperOperations(bool includeSelf);
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> GetAllProperties();
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> GetAllOperations();
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> GetAllFinalProperties();
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> GetAllFinalOperations();
	
		new MetaClassBuilder ToMutable();
		new MetaClassBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaClassBuilder : MetaDeclarationBuilder, MetaTypeBuilder
	{
		bool IsAbstract { get; set; }
		Func<bool> IsAbstractLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<MetaClassBuilder> SuperClasses { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> Properties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations { get; }
	
		new MetaClass ToImmutable();
		new MetaClass ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaOperation : MetaNamedElement
	{
		MetaType Parent { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaParameter> Parameters { get; }
		MetaType ReturnType { get; }
	
	
		new MetaOperationBuilder ToMutable();
		new MetaOperationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaOperationBuilder : MetaNamedElementBuilder
	{
		MetaTypeBuilder Parent { get; set; }
		Func<MetaTypeBuilder> ParentLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<MetaParameterBuilder> Parameters { get; }
		MetaTypeBuilder ReturnType { get; set; }
		Func<MetaTypeBuilder> ReturnTypeLazy { get; set; }
	
		new MetaOperation ToImmutable();
		new MetaOperation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaParameter : MetaNamedElement, MetaTypedElement
	{
		MetaOperation Operation { get; }
	
	
		new MetaParameterBuilder ToMutable();
		new MetaParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaParameterBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder
	{
		MetaOperationBuilder Operation { get; set; }
		Func<MetaOperationBuilder> OperationLazy { get; set; }
	
		new MetaParameter ToImmutable();
		new MetaParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaProperty : MetaNamedElement, MetaTypedElement
	{
		MetaPropertyKind Kind { get; }
		MetaClass Class { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> OppositeProperties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettedProperties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettingProperties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefinedProperties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefiningProperties { get; }
	
	
		new MetaPropertyBuilder ToMutable();
		new MetaPropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaPropertyBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder
	{
		MetaPropertyKind Kind { get; set; }
		Func<MetaPropertyKind> KindLazy { get; set; }
		MetaClassBuilder Class { get; set; }
		Func<MetaClassBuilder> ClassLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> OppositeProperties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettedProperties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettingProperties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefinedProperties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefiningProperties { get; }
	
		new MetaProperty ToImmutable();
		new MetaProperty ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}

	public static class MetaDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static MetaDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty>();
			MetaElement.Initialize();
			MetaDocumentedElement.Initialize();
			MetaNamedElement.Initialize();
			MetaTypedElement.Initialize();
			MetaType.Initialize();
			MetaNamedType.Initialize();
			MetaAttribute.Initialize();
			MetaDeclaration.Initialize();
			MetaNamespace.Initialize();
			MetaModel.Initialize();
			MetaCollectionType.Initialize();
			MetaNullableType.Initialize();
			MetaPrimitiveType.Initialize();
			MetaEnum.Initialize();
			MetaEnumLiteral.Initialize();
			MetaConstant.Initialize();
			MetaClass.Initialize();
			MetaOperation.Initialize();
			MetaParameter.Initialize();
			MetaProperty.Initialize();
			properties.Add(MetaDescriptor.MetaElement.AttributesProperty);
			properties.Add(MetaDescriptor.MetaDocumentedElement.DocumentationProperty);
			properties.Add(MetaDescriptor.MetaNamedElement.NameProperty);
			properties.Add(MetaDescriptor.MetaTypedElement.TypeProperty);
			properties.Add(MetaDescriptor.MetaDeclaration.NamespaceProperty);
			properties.Add(MetaDescriptor.MetaDeclaration.MetaModelProperty);
			properties.Add(MetaDescriptor.MetaNamespace.DefinedMetaModelProperty);
			properties.Add(MetaDescriptor.MetaNamespace.DeclarationsProperty);
			properties.Add(MetaDescriptor.MetaModel.UriProperty);
			properties.Add(MetaDescriptor.MetaModel.NamespaceProperty);
			properties.Add(MetaDescriptor.MetaCollectionType.KindProperty);
			properties.Add(MetaDescriptor.MetaCollectionType.InnerTypeProperty);
			properties.Add(MetaDescriptor.MetaNullableType.InnerTypeProperty);
			properties.Add(MetaDescriptor.MetaEnum.EnumLiteralsProperty);
			properties.Add(MetaDescriptor.MetaEnum.OperationsProperty);
			properties.Add(MetaDescriptor.MetaEnumLiteral.EnumProperty);
			properties.Add(MetaDescriptor.MetaClass.IsAbstractProperty);
			properties.Add(MetaDescriptor.MetaClass.SuperClassesProperty);
			properties.Add(MetaDescriptor.MetaClass.PropertiesProperty);
			properties.Add(MetaDescriptor.MetaClass.OperationsProperty);
			properties.Add(MetaDescriptor.MetaOperation.ParentProperty);
			properties.Add(MetaDescriptor.MetaOperation.ParametersProperty);
			properties.Add(MetaDescriptor.MetaOperation.ReturnTypeProperty);
			properties.Add(MetaDescriptor.MetaParameter.OperationProperty);
			properties.Add(MetaDescriptor.MetaProperty.KindProperty);
			properties.Add(MetaDescriptor.MetaProperty.ClassProperty);
			properties.Add(MetaDescriptor.MetaProperty.OppositePropertiesProperty);
			properties.Add(MetaDescriptor.MetaProperty.SubsettedPropertiesProperty);
			properties.Add(MetaDescriptor.MetaProperty.SubsettingPropertiesProperty);
			properties.Add(MetaDescriptor.MetaProperty.RedefinedPropertiesProperty);
			properties.Add(MetaDescriptor.MetaProperty.RedefiningPropertiesProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string Uri = "http://metadslx.core/1.0";
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaElementId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaElement), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaElementBuilder))]
		public static class MetaElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty AttributesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaElement), "Attributes",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAttribute), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaAttribute>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAttributeBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaAttributeBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaElement_Attributes);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaDocumentedElementId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDocumentedElement), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDocumentedElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaElement) })]
		public static class MetaDocumentedElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaDocumentedElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaDocumentedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDocumentedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DocumentationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaDocumentedElement), "Documentation",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDocumentedElement_Documentation);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaNamedElementId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamedElement), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamedElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDocumentedElement) })]
		public static class MetaNamedElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNamedElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaNamedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamedElement; }
			}
			
			[global::MetaDslx.Modeling.NameAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaNamedElement), "Name",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamedElement_Name);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaTypedElementId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypedElement), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypedElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaElement) })]
		public static class MetaTypedElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaTypedElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaTypedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaTypedElement; }
			}
			
			[global::MetaDslx.Modeling.TypeAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty TypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaTypedElement), "Type",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaTypedElement_Type);
		}
	
		[global::MetaDslx.Modeling.TypeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaTypeId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder))]
		public static class MetaType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaType; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaNamedTypeId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamedType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamedTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaNamedType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNamedType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaNamedType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamedType; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaAttributeId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAttribute), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAttributeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaAttribute
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaAttribute()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaAttribute));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaAttribute; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaDeclarationId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDeclaration), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDeclarationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaDeclaration
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaDeclaration()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaDeclaration));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDeclaration; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "Declarations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NamespaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaDeclaration), "Namespace",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDeclaration_Namespace);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty MetaModelProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaDeclaration), "MetaModel",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModel), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDeclaration_MetaModel);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaNamespaceId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration) })]
		public static class MetaNamespace
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNamespace()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaNamespace));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaModel), "Namespace")]
			public static readonly global::MetaDslx.Modeling.ModelProperty DefinedMetaModelProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaNamespace), "DefinedMetaModel",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModel), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace_DefinedMetaModel);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaDeclaration), "Namespace")]
			public static readonly global::MetaDslx.Modeling.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaNamespace), "Declarations",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDeclaration), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaDeclaration>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDeclarationBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaDeclarationBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace_Declarations);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaModelId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModel), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaModel
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaModel()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaModel));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaModel; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty UriProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaModel), "Uri",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaModel_Uri);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "DefinedMetaModel")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NamespaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaModel), "Namespace",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaModel_Namespace);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaCollectionTypeId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaCollectionType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType) })]
		public static class MetaCollectionType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaCollectionType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaCollectionType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaCollectionType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaCollectionType), "Kind",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaCollectionType_Kind);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaCollectionType), "InnerType",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaCollectionType_InnerType);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaNullableTypeId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNullableType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNullableTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType) })]
		public static class MetaNullableType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNullableType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaNullableType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNullableType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaNullableType), "InnerType",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNullableType_InnerType);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaPrimitiveTypeId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPrimitiveType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPrimitiveTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaType) })]
		public static class MetaPrimitiveType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaPrimitiveType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaPrimitiveType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaPrimitiveType; }
			}
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaEnumId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnum), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaType) })]
		public static class MetaEnum
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaEnum()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaEnum));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnum; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaEnumLiteral), "Enum")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumLiteralsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaEnum), "EnumLiterals",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteral), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteral>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnum_EnumLiterals);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parent")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaEnum), "Operations",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperation), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaOperation>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnum_Operations);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaEnumLiteralId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteral), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaEnumLiteral
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaEnumLiteral()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaEnumLiteral));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnumLiteral; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "EnumLiterals")]
			[global::MetaDslx.Modeling.RedefinesAttribute(typeof(MetaDescriptor.MetaTypedElement), "Type")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaEnumLiteral), "Enum",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnum), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnumLiteral_Enum);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaConstantId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaConstant), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaConstant
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaConstant()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaConstant));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaConstant; }
			}
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaClassId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClass), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaType) })]
		public static class MetaClass
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaClass()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaClass));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass _MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaClass), "IsAbstract",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_IsAbstract);
			
			[global::MetaDslx.Modeling.BaseScopeAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty SuperClassesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaClass), "SuperClasses",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClass), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaClass>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_SuperClasses);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "Class")]
			public static readonly global::MetaDslx.Modeling.ModelProperty PropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaClass), "Properties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_Properties);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parent")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaClass), "Operations",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperation), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaOperation>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_Operations);
		}
	
		[global::MetaDslx.Modeling.LocalScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaOperationId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperation), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaOperation
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaOperation()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaOperation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaOperation; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Operations")]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "Operations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ParentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaOperation), "Parent",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaOperation_Parent);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaParameter), "Operation")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ParametersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaOperation), "Parameters",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaParameter), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaParameter>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaOperation_Parameters);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaOperation), "ReturnType",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaOperation_ReturnType);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaParameterId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaParameter), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaParameter
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaParameter()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaParameter));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaParameter; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parameters")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaParameter), "Operation",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperation), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaParameter_Operation);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.Internal.MetaPropertyId), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaProperty
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MetaProperty()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaProperty));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaProperty), "Kind",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_Kind);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Properties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ClassProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaProperty), "Class",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClass), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_Class);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "OppositeProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OppositePropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaProperty), "OppositeProperties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_OppositeProperties);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "SubsettingProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty SubsettedPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaProperty), "SubsettedProperties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_SubsettedProperties);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "SubsettedProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty SubsettingPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaProperty), "SubsettingProperties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_SubsettingProperties);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "RedefiningProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty RedefinedPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaProperty), "RedefinedProperties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_RedefinedProperties);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "RedefinedProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty RedefiningPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MetaProperty), "RedefiningProperties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_RedefiningProperties);
		}
	}
}

namespace MetaDslx.Languages.Meta.Symbols.Internal
{
	
	internal class MetaElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
	
		internal MetaElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaElement; }
		}
	
		public new MetaElementBuilder ToMutable()
		{
			return (MetaElementBuilder)base.ToMutable();
		}
	
		public new MetaElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaElementBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	}
	
	internal class MetaElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaElement; }
		}
	
		public new MetaElement ToImmutable()
		{
			return (MetaElement)base.ToImmutable();
		}
	
		public new MetaElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaElement)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	}
	
	internal class MetaDocumentedElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaDocumentedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaDocumentedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaDocumentedElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaDocumentedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
	
		internal MetaDocumentedElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaDocumentedElement; }
		}
	
		public new MetaDocumentedElementBuilder ToMutable()
		{
			return (MetaDocumentedElementBuilder)base.ToMutable();
		}
	
		public new MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaDocumentedElementBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaDocumentedElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaDocumentedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaDocumentedElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaDocumentedElement; }
		}
	
		public new MetaDocumentedElement ToImmutable()
		{
			return (MetaDocumentedElement)base.ToImmutable();
		}
	
		public new MetaDocumentedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaDocumentedElement)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	}
	
	internal class MetaNamedElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaNamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaNamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamedElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaNamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal MetaNamedElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamedElement; }
		}
	
		public new MetaNamedElementBuilder ToMutable()
		{
			return (MetaNamedElementBuilder)base.ToMutable();
		}
	
		public new MetaNamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaNamedElementBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaNamedElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaNamedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaNamedElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNamedElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamedElement; }
		}
	
		public new MetaNamedElement ToImmutable()
		{
			return (MetaNamedElement)base.ToImmutable();
		}
	
		public new MetaNamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaNamedElement)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	}
	
	internal class MetaTypedElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaTypedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaTypedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaTypedElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaTypedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
	
		internal MetaTypedElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaTypedElement; }
		}
	
		public new MetaTypedElementBuilder ToMutable()
		{
			return (MetaTypedElementBuilder)base.ToMutable();
		}
	
		public new MetaTypedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaTypedElementBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	}
	
	internal class MetaTypedElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaTypedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaTypedElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaTypedElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaTypedElement; }
		}
	
		public new MetaTypedElement ToImmutable()
		{
			return (MetaTypedElement)base.ToImmutable();
		}
	
		public new MetaTypedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaTypedElement)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	}
	
	internal class MetaTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaType
	{
	
		internal MetaTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaType; }
		}
	
		public new MetaTypeBuilder ToMutable()
		{
			return (MetaTypeBuilder)base.ToMutable();
		}
	
		public new MetaTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaTypeBuilder)base.ToMutable(model);
		}
	}
	
	internal class MetaTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaTypeBuilder
	{
	
		internal MetaTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaType; }
		}
	
		public new MetaType ToImmutable()
		{
			return (MetaType)base.ToImmutable();
		}
	
		public new MetaType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaType)base.ToImmutable(model);
		}
	}
	
	internal class MetaNamedTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaNamedTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaNamedTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamedTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaNamedType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal MetaNamedTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamedType; }
		}
	
		public new MetaNamedTypeBuilder ToMutable()
		{
			return (MetaNamedTypeBuilder)base.ToMutable();
		}
	
		public new MetaNamedTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaNamedTypeBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaNamedTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaNamedTypeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaNamedTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNamedType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamedType; }
		}
	
		public new MetaNamedType ToImmutable()
		{
			return (MetaNamedType)base.ToImmutable();
		}
	
		public new MetaNamedType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaNamedType)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	}
	
	internal class MetaAttributeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAttribute.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaAttributeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaAttributeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaAttributeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaAttribute
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal MetaAttributeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAttribute; }
		}
	
		public new MetaAttributeBuilder ToMutable()
		{
			return (MetaAttributeBuilder)base.ToMutable();
		}
	
		public new MetaAttributeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaAttributeBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaAttributeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaAttributeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaAttributeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaAttribute(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAttribute; }
		}
	
		public new MetaAttribute ToImmutable()
		{
			return (MetaAttribute)base.ToImmutable();
		}
	
		public new MetaAttribute ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaAttribute)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	}
	
	internal class MetaDeclarationId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaDeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaDeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaDeclarationImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaDeclaration
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
	
		internal MetaDeclarationImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaDeclaration; }
		}
	
		public new MetaDeclarationBuilder ToMutable()
		{
			return (MetaDeclarationBuilder)base.ToMutable();
		}
	
		public new MetaDeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaDeclarationBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaDeclarationBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaDeclarationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaDeclarationBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaDeclaration(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaDeclaration; }
		}
	
		public new MetaDeclaration ToImmutable()
		{
			return (MetaDeclaration)base.ToImmutable();
		}
	
		public new MetaDeclaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaDeclaration)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	}
	
	internal class MetaNamespaceId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaNamespaceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaNamespaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamespaceImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaNamespace
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel definedMetaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaDeclaration> declarations0;
	
		internal MetaNamespaceImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamespace; }
		}
	
		public new MetaNamespaceBuilder ToMutable()
		{
			return (MetaNamespaceBuilder)base.ToMutable();
		}
	
		public new MetaNamespaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaNamespaceBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public MetaModel DefinedMetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, ref definedMetaModel0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaDeclaration> Declarations
		{
		    get { return this.GetList<MetaDeclaration>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaNamespaceBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaNamespaceBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaDeclarationBuilder> declarations0;
	
		internal MetaNamespaceBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNamespace(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamespace; }
		}
	
		public new MetaNamespace ToImmutable()
		{
			return (MetaNamespace)base.ToImmutable();
		}
	
		public new MetaNamespace ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaNamespace)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	
		
		public MetaModelBuilder DefinedMetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.DefinedMetaModelProperty); }
			set { this.SetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, value); }
		}
		
		public Func<MetaModelBuilder> DefinedMetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.DefinedMetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaDeclarationBuilder> Declarations
		{
			get { return this.GetList<MetaDeclarationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class MetaModelId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaModelImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaModelBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaModelImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaModel
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string uri0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
	
		internal MetaModelImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaModel; }
		}
	
		public new MetaModelBuilder ToMutable()
		{
			return (MetaModelBuilder)base.ToMutable();
		}
	
		public new MetaModelBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaModelBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public string Uri
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.UriProperty, ref uri0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.NamespaceProperty, ref namespace0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaModelBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaModelBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaModelBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaModel(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaModel; }
		}
	
		public new MetaModel ToImmutable()
		{
			return (MetaModel)base.ToImmutable();
		}
	
		public new MetaModel ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaModel)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public string Uri
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.UriProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.UriProperty, value); }
		}
		
		public Func<string> UriLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.UriProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaModel.UriProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaModel.NamespaceProperty, value); }
		}
	}
	
	internal class MetaCollectionTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaCollectionTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaCollectionTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaCollectionTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaCollectionType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaCollectionKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType innerType0;
	
		internal MetaCollectionTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaCollectionType; }
		}
	
		public new MetaCollectionTypeBuilder ToMutable()
		{
			return (MetaCollectionTypeBuilder)base.ToMutable();
		}
	
		public new MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaCollectionTypeBuilder)base.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public MetaCollectionKind Kind
		{
		    get { return this.GetValue<MetaCollectionKind>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.KindProperty, ref kind0); }
		}
	
		
		public MetaType InnerType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class MetaCollectionTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaCollectionTypeBuilder
	{
	
		internal MetaCollectionTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaCollectionType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaCollectionType; }
		}
	
		public new MetaCollectionType ToImmutable()
		{
			return (MetaCollectionType)base.ToImmutable();
		}
	
		public new MetaCollectionType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaCollectionType)base.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public MetaCollectionKind Kind
		{
			get { return this.GetValue<MetaCollectionKind>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.KindProperty); }
			set { this.SetValue<MetaCollectionKind>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.KindProperty, value); }
		}
		
		public Func<MetaCollectionKind> KindLazy
		{
			get { return this.GetLazyValue<MetaCollectionKind>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.KindProperty); }
			set { this.SetLazyValue(MetaDescriptor.MetaCollectionType.KindProperty, value); }
		}
	
		
		public MetaTypeBuilder InnerType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.InnerTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.InnerTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.InnerTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaCollectionType.InnerTypeProperty, value); }
		}
	}
	
	internal class MetaNullableTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNullableType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaNullableTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaNullableTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNullableTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaNullableType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType innerType0;
	
		internal MetaNullableTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNullableType; }
		}
	
		public new MetaNullableTypeBuilder ToMutable()
		{
			return (MetaNullableTypeBuilder)base.ToMutable();
		}
	
		public new MetaNullableTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaNullableTypeBuilder)base.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public MetaType InnerType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNullableType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class MetaNullableTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaNullableTypeBuilder
	{
	
		internal MetaNullableTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNullableType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNullableType; }
		}
	
		public new MetaNullableType ToImmutable()
		{
			return (MetaNullableType)base.ToImmutable();
		}
	
		public new MetaNullableType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaNullableType)base.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public MetaTypeBuilder InnerType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNullableType.InnerTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNullableType.InnerTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNullableType.InnerTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNullableType.InnerTypeProperty, value); }
		}
	}
	
	internal class MetaPrimitiveTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaPrimitiveType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaPrimitiveTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaPrimitiveTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaPrimitiveTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaPrimitiveType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
	
		internal MetaPrimitiveTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaPrimitiveType; }
		}
	
		public new MetaPrimitiveTypeBuilder ToMutable()
		{
			return (MetaPrimitiveTypeBuilder)base.ToMutable();
		}
	
		public new MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaPrimitiveTypeBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaPrimitiveTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaPrimitiveTypeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaPrimitiveTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaPrimitiveType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaPrimitiveType; }
		}
	
		public new MetaPrimitiveType ToImmutable()
		{
			return (MetaPrimitiveType)base.ToImmutable();
		}
	
		public new MetaPrimitiveType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaPrimitiveType)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	}
	
	internal class MetaEnumId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaEnumImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaEnumBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaEnumImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaEnum
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaEnumLiteral> enumLiterals0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> operations0;
	
		internal MetaEnumImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaEnum; }
		}
	
		public new MetaEnumBuilder ToMutable()
		{
			return (MetaEnumBuilder)base.ToMutable();
		}
	
		public new MetaEnumBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaEnumBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaEnumLiteral> EnumLiterals
		{
		    get { return this.GetList<MetaEnumLiteral>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaEnumBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaEnumBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaEnumLiteralBuilder> enumLiterals0;
		private global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> operations0;
	
		internal MetaEnumBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaEnum(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaEnum; }
		}
	
		public new MetaEnum ToImmutable()
		{
			return (MetaEnum)base.ToImmutable();
		}
	
		public new MetaEnum ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaEnum)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals
		{
			get { return this.GetList<MetaEnumLiteralBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	}
	
	internal class MetaEnumLiteralId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnumLiteral.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaEnumLiteralImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaEnumLiteralBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaEnumLiteralImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaEnumLiteral
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaEnum enum0;
	
		internal MetaEnumLiteralImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaEnumLiteral; }
		}
	
		public new MetaEnumLiteralBuilder ToMutable()
		{
			return (MetaEnumLiteralBuilder)base.ToMutable();
		}
	
		public new MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaEnumLiteralBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaEnum Enum
		{
		    get { return this.GetReference<MetaEnum>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnumLiteral.EnumProperty, ref enum0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaEnumLiteralBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaEnumLiteralBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaEnumLiteralBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaEnumLiteral(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaEnumLiteral; }
		}
	
		public new MetaEnumLiteral ToImmutable()
		{
			return (MetaEnumLiteral)base.ToImmutable();
		}
	
		public new MetaEnumLiteral ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaEnumLiteral)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaEnumBuilder Enum
		{
			get { return this.GetReference<MetaEnumBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnumLiteral.EnumProperty); }
			set { this.SetReference<MetaEnumBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnumLiteral.EnumProperty, value); }
		}
		
		public Func<MetaEnumBuilder> EnumLazy
		{
			get { return this.GetLazyReference<MetaEnumBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnumLiteral.EnumProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaEnumLiteral.EnumProperty, value); }
		}
	}
	
	internal class MetaConstantId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaConstant.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaConstantImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaConstantBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaConstantImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaConstant
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
	
		internal MetaConstantImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaConstant; }
		}
	
		public new MetaConstantBuilder ToMutable()
		{
			return (MetaConstantBuilder)base.ToMutable();
		}
	
		public new MetaConstantBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaConstantBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaConstantBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaConstantBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaConstantBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaConstant(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaConstant; }
		}
	
		public new MetaConstant ToImmutable()
		{
			return (MetaConstant)base.ToImmutable();
		}
	
		public new MetaConstant ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaConstant)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	}
	
	internal class MetaClassId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaClassImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaClassBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaClassImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaClass
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaClass> superClasses0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> operations0;
	
		internal MetaClassImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaClass; }
		}
	
		public new MetaClassBuilder ToMutable()
		{
			return (MetaClassBuilder)base.ToMutable();
		}
	
		public new MetaClassBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaClassBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaClass> SuperClasses
		{
		    get { return this.GetList<MetaClass>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> Properties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<MetaClass> MetaClass.GetAllSuperClasses(bool includeSelf)
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this, includeSelf);
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> MetaClass.GetAllSuperProperties(bool includeSelf)
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperProperties(this, includeSelf);
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> MetaClass.GetAllSuperOperations(bool includeSelf)
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperOperations(this, includeSelf);
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> MetaClass.GetAllProperties()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> MetaClass.GetAllOperations()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> MetaClass.GetAllFinalProperties()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllFinalProperties(this);
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> MetaClass.GetAllFinalOperations()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllFinalOperations(this);
		}
	}
	
	internal class MetaClassBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaClassBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaClassBuilder> superClasses0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> properties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> operations0;
	
		internal MetaClassBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaClass(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaClass; }
		}
	
		public new MetaClass ToImmutable()
		{
			return (MetaClass)base.ToImmutable();
		}
	
		public new MetaClass ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaClass)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.IsAbstractProperty, value); }
		}
		
		public Func<bool> IsAbstractLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.IsAbstractProperty); }
			set { this.SetLazyValue(MetaDescriptor.MetaClass.IsAbstractProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaClassBuilder> SuperClasses
		{
			get { return this.GetList<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> Properties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	}
	
	internal class MetaOperationId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaOperationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaOperationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaOperationImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaOperation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType parent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaParameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType returnType0;
	
		internal MetaOperationImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaOperation; }
		}
	
		public new MetaOperationBuilder ToMutable()
		{
			return (MetaOperationBuilder)base.ToMutable();
		}
	
		public new MetaOperationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaOperationBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaType Parent
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ParentProperty, ref parent0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaParameter> Parameters
		{
		    get { return this.GetList<MetaParameter>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ReturnTypeProperty, ref returnType0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaOperationBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaOperationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaParameterBuilder> parameters0;
	
		internal MetaOperationBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaOperation(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaOperation; }
		}
	
		public new MetaOperation ToImmutable()
		{
			return (MetaOperation)base.ToImmutable();
		}
	
		public new MetaOperation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaOperation)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaTypeBuilder Parent
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ParentProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ParentProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ParentLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ParentProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaOperation.ParentProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaParameterBuilder> Parameters
		{
			get { return this.GetList<MetaParameterBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ReturnTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ReturnTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ReturnTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaOperation.ReturnTypeProperty, value); }
		}
	}
	
	internal class MetaParameterId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaParameterImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaOperation operation0;
	
		internal MetaParameterImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaParameter; }
		}
	
		public new MetaParameterBuilder ToMutable()
		{
			return (MetaParameterBuilder)base.ToMutable();
		}
	
		public new MetaParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaParameterBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaOperation Operation
		{
		    get { return this.GetReference<MetaOperation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.OperationProperty, ref operation0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaParameterBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaParameterBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaParameterBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaParameter(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaParameter; }
		}
	
		public new MetaParameter ToImmutable()
		{
			return (MetaParameter)base.ToImmutable();
		}
	
		public new MetaParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaParameter)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaOperationBuilder Operation
		{
			get { return this.GetReference<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.OperationProperty); }
			set { this.SetReference<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.OperationProperty, value); }
		}
		
		public Func<MetaOperationBuilder> OperationLazy
		{
			get { return this.GetLazyReference<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.OperationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaParameter.OperationProperty, value); }
		}
	}
	
	internal class MetaPropertyId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaPropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaPropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaPropertyImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MetaProperty
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaPropertyKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaClass class0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> oppositeProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> subsettedProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> subsettingProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> redefinedProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> redefiningProperties0;
	
		internal MetaPropertyImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaProperty; }
		}
	
		public new MetaPropertyBuilder ToMutable()
		{
			return (MetaPropertyBuilder)base.ToMutable();
		}
	
		public new MetaPropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MetaPropertyBuilder)base.ToMutable(model);
		}
	
		MetaElementBuilder MetaElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaElementBuilder MetaElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaPropertyKind Kind
		{
		    get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.KindProperty, ref kind0); }
		}
	
		
		public MetaClass Class
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.ClassProperty, ref class0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> OppositeProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettingProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefinedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefiningProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaPropertyBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MetaPropertyBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> oppositeProperties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> subsettedProperties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> subsettingProperties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> redefinedProperties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> redefiningProperties0;
	
		internal MetaPropertyBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaProperty(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaProperty; }
		}
	
		public new MetaProperty ToImmutable()
		{
			return (MetaProperty)base.ToImmutable();
		}
	
		public new MetaProperty ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MetaProperty)base.ToImmutable(model);
		}
	
		MetaElement MetaElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaElement MetaElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaPropertyKind Kind
		{
			get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.KindProperty); }
			set { this.SetValue<MetaPropertyKind>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.KindProperty, value); }
		}
		
		public Func<MetaPropertyKind> KindLazy
		{
			get { return this.GetLazyValue<MetaPropertyKind>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.KindProperty); }
			set { this.SetLazyValue(MetaDescriptor.MetaProperty.KindProperty, value); }
		}
	
		
		public MetaClassBuilder Class
		{
			get { return this.GetReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.ClassProperty); }
			set { this.SetReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.ClassProperty, value); }
		}
		
		public Func<MetaClassBuilder> ClassLazy
		{
			get { return this.GetLazyReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.ClassProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaProperty.ClassProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> OppositeProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettingProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefinedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefiningProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	}

	internal class MetaBuilderInstance
	{
		internal static MetaBuilderInstance instance = new MetaBuilderInstance();
	
		private bool creating;
		private bool created;
		internal MetaModelBuilder MetaMetaModel;
		internal global::MetaDslx.Modeling.MutableModel Model;
	
		internal MetaPrimitiveTypeBuilder Object = null;
		internal MetaPrimitiveTypeBuilder String = null;
		internal MetaPrimitiveTypeBuilder Int = null;
		internal MetaPrimitiveTypeBuilder Long = null;
		internal MetaPrimitiveTypeBuilder Float = null;
		internal MetaPrimitiveTypeBuilder Double = null;
		internal MetaPrimitiveTypeBuilder Byte = null;
		internal MetaPrimitiveTypeBuilder Bool = null;
		internal MetaPrimitiveTypeBuilder Void = null;
		internal MetaPrimitiveTypeBuilder ModelObject = null;
		internal MetaAttributeBuilder NameAttribute = null;
		internal MetaAttributeBuilder TypeAttribute = null;
		internal MetaAttributeBuilder ScopeAttribute = null;
		internal MetaAttributeBuilder BaseScopeAttribute = null;
		internal MetaAttributeBuilder LocalScopeAttribute = null;
	
		private MetaNamespaceBuilder __tmp1;
		private MetaNamespaceBuilder __tmp2;
		private MetaNamespaceBuilder __tmp3;
		private MetaNamespaceBuilder __tmp4;
		internal MetaClassBuilder MetaElement;
		internal MetaPropertyBuilder MetaElement_Attributes;
		internal MetaClassBuilder MetaDocumentedElement;
		internal MetaPropertyBuilder MetaDocumentedElement_Documentation;
		private MetaOperationBuilder __tmp28;
		internal MetaClassBuilder MetaNamedElement;
		internal MetaPropertyBuilder MetaNamedElement_Name;
		internal MetaClassBuilder MetaTypedElement;
		internal MetaPropertyBuilder MetaTypedElement_Type;
		internal MetaClassBuilder MetaType;
		internal MetaClassBuilder MetaNamedType;
		internal MetaClassBuilder MetaAttribute;
		internal MetaClassBuilder MetaDeclaration;
		internal MetaPropertyBuilder MetaDeclaration_Namespace;
		internal MetaPropertyBuilder MetaDeclaration_MetaModel;
		internal MetaClassBuilder MetaNamespace;
		internal MetaPropertyBuilder MetaNamespace_DefinedMetaModel;
		internal MetaPropertyBuilder MetaNamespace_Declarations;
		internal MetaClassBuilder MetaModel;
		internal MetaPropertyBuilder MetaModel_Uri;
		internal MetaPropertyBuilder MetaModel_Namespace;
		internal MetaEnumBuilder MetaCollectionKind;
		private MetaEnumLiteralBuilder __tmp21;
		private MetaEnumLiteralBuilder __tmp22;
		private MetaEnumLiteralBuilder __tmp23;
		private MetaEnumLiteralBuilder __tmp24;
		internal MetaClassBuilder MetaCollectionType;
		internal MetaPropertyBuilder MetaCollectionType_Kind;
		internal MetaPropertyBuilder MetaCollectionType_InnerType;
		internal MetaClassBuilder MetaNullableType;
		internal MetaPropertyBuilder MetaNullableType_InnerType;
		internal MetaClassBuilder MetaPrimitiveType;
		internal MetaClassBuilder MetaEnum;
		internal MetaPropertyBuilder MetaEnum_EnumLiterals;
		internal MetaPropertyBuilder MetaEnum_Operations;
		internal MetaClassBuilder MetaEnumLiteral;
		internal MetaPropertyBuilder MetaEnumLiteral_Enum;
		internal MetaClassBuilder MetaConstant;
		internal MetaClassBuilder MetaClass;
		internal MetaPropertyBuilder MetaClass_IsAbstract;
		internal MetaPropertyBuilder MetaClass_SuperClasses;
		internal MetaPropertyBuilder MetaClass_Properties;
		internal MetaPropertyBuilder MetaClass_Operations;
		private MetaOperationBuilder __tmp30;
		private MetaParameterBuilder __tmp55;
		private MetaOperationBuilder __tmp34;
		private MetaParameterBuilder __tmp57;
		private MetaOperationBuilder __tmp35;
		private MetaParameterBuilder __tmp59;
		private MetaOperationBuilder __tmp36;
		private MetaOperationBuilder __tmp37;
		private MetaOperationBuilder __tmp38;
		private MetaOperationBuilder __tmp42;
		internal MetaClassBuilder MetaOperation;
		internal MetaPropertyBuilder MetaOperation_Parent;
		internal MetaPropertyBuilder MetaOperation_Parameters;
		internal MetaPropertyBuilder MetaOperation_ReturnType;
		internal MetaClassBuilder MetaParameter;
		internal MetaPropertyBuilder MetaParameter_Operation;
		internal MetaEnumBuilder MetaPropertyKind;
		private MetaEnumLiteralBuilder __tmp31;
		private MetaEnumLiteralBuilder __tmp32;
		private MetaEnumLiteralBuilder __tmp33;
		private MetaEnumLiteralBuilder __tmp39;
		private MetaEnumLiteralBuilder __tmp40;
		private MetaEnumLiteralBuilder __tmp41;
		internal MetaClassBuilder MetaProperty;
		internal MetaPropertyBuilder MetaProperty_Kind;
		internal MetaPropertyBuilder MetaProperty_Class;
		internal MetaPropertyBuilder MetaProperty_OppositeProperties;
		internal MetaPropertyBuilder MetaProperty_SubsettedProperties;
		internal MetaPropertyBuilder MetaProperty_SubsettingProperties;
		internal MetaPropertyBuilder MetaProperty_RedefinedProperties;
		internal MetaPropertyBuilder MetaProperty_RedefiningProperties;
		private MetaModelBuilder __tmp5;
		private MetaConstantBuilder __tmp6;
		private MetaConstantBuilder __tmp7;
		private MetaConstantBuilder __tmp8;
		private MetaConstantBuilder __tmp9;
		private MetaConstantBuilder __tmp10;
		private MetaConstantBuilder __tmp11;
		private MetaConstantBuilder __tmp12;
		private MetaConstantBuilder __tmp13;
		private MetaConstantBuilder __tmp14;
		private MetaConstantBuilder __tmp15;
		private MetaConstantBuilder __tmp16;
		private MetaConstantBuilder __tmp17;
		private MetaConstantBuilder __tmp18;
		private MetaConstantBuilder __tmp19;
		private MetaConstantBuilder __tmp20;
		private MetaCollectionTypeBuilder __tmp25;
		private MetaCollectionTypeBuilder __tmp26;
		private MetaCollectionTypeBuilder __tmp27;
		private MetaCollectionTypeBuilder __tmp29;
		private MetaCollectionTypeBuilder __tmp43;
		private MetaCollectionTypeBuilder __tmp44;
		private MetaCollectionTypeBuilder __tmp45;
		private MetaCollectionTypeBuilder __tmp46;
		private MetaCollectionTypeBuilder __tmp47;
		private MetaCollectionTypeBuilder __tmp48;
		private MetaCollectionTypeBuilder __tmp49;
		private MetaCollectionTypeBuilder __tmp50;
		private MetaCollectionTypeBuilder __tmp51;
		private MetaCollectionTypeBuilder __tmp52;
		private MetaCollectionTypeBuilder __tmp53;
		private MetaCollectionTypeBuilder __tmp54;
		private MetaCollectionTypeBuilder __tmp56;
		private MetaCollectionTypeBuilder __tmp58;
		private MetaCollectionTypeBuilder __tmp60;
		private MetaCollectionTypeBuilder __tmp61;
		private MetaCollectionTypeBuilder __tmp62;
	
		internal MetaBuilderInstance()
		{
			this.Model = new global::MetaDslx.Modeling.MutableModel("MetaDslx.Modeling");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			MetaImplementationProvider.Implementation.MetaBuilderInstance(this);
			this.CreateSymbols();
			lock (this)
			{
				this.created = true;
			}
		}
	
		internal void EvaluateLazyValues()
		{
			if (!this.created) return;
			this.Model.EvaluateLazyValues();
		}
	
		private void CreateSymbols()
		{
			global::MetaDslx.Languages.Meta.Symbols.MetaFactory factory = new global::MetaDslx.Languages.Meta.Symbols.MetaFactory(this.Model, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaNamespace();
			MetaElement = factory.MetaClass();
			MetaElement_Attributes = factory.MetaProperty();
			MetaDocumentedElement = factory.MetaClass();
			MetaDocumentedElement_Documentation = factory.MetaProperty();
			__tmp28 = factory.MetaOperation();
			MetaNamedElement = factory.MetaClass();
			MetaNamedElement_Name = factory.MetaProperty();
			MetaTypedElement = factory.MetaClass();
			MetaTypedElement_Type = factory.MetaProperty();
			MetaType = factory.MetaClass();
			MetaNamedType = factory.MetaClass();
			MetaAttribute = factory.MetaClass();
			MetaDeclaration = factory.MetaClass();
			MetaDeclaration_Namespace = factory.MetaProperty();
			MetaDeclaration_MetaModel = factory.MetaProperty();
			MetaNamespace = factory.MetaClass();
			MetaNamespace_DefinedMetaModel = factory.MetaProperty();
			MetaNamespace_Declarations = factory.MetaProperty();
			MetaModel = factory.MetaClass();
			MetaModel_Uri = factory.MetaProperty();
			MetaModel_Namespace = factory.MetaProperty();
			MetaCollectionKind = factory.MetaEnum();
			__tmp21 = factory.MetaEnumLiteral();
			__tmp22 = factory.MetaEnumLiteral();
			__tmp23 = factory.MetaEnumLiteral();
			__tmp24 = factory.MetaEnumLiteral();
			MetaCollectionType = factory.MetaClass();
			MetaCollectionType_Kind = factory.MetaProperty();
			MetaCollectionType_InnerType = factory.MetaProperty();
			MetaNullableType = factory.MetaClass();
			MetaNullableType_InnerType = factory.MetaProperty();
			MetaPrimitiveType = factory.MetaClass();
			MetaEnum = factory.MetaClass();
			MetaEnum_EnumLiterals = factory.MetaProperty();
			MetaEnum_Operations = factory.MetaProperty();
			MetaEnumLiteral = factory.MetaClass();
			MetaEnumLiteral_Enum = factory.MetaProperty();
			MetaConstant = factory.MetaClass();
			MetaClass = factory.MetaClass();
			MetaClass_IsAbstract = factory.MetaProperty();
			MetaClass_SuperClasses = factory.MetaProperty();
			MetaClass_Properties = factory.MetaProperty();
			MetaClass_Operations = factory.MetaProperty();
			__tmp30 = factory.MetaOperation();
			__tmp55 = factory.MetaParameter();
			__tmp34 = factory.MetaOperation();
			__tmp57 = factory.MetaParameter();
			__tmp35 = factory.MetaOperation();
			__tmp59 = factory.MetaParameter();
			__tmp36 = factory.MetaOperation();
			__tmp37 = factory.MetaOperation();
			__tmp38 = factory.MetaOperation();
			__tmp42 = factory.MetaOperation();
			MetaOperation = factory.MetaClass();
			MetaOperation_Parent = factory.MetaProperty();
			MetaOperation_Parameters = factory.MetaProperty();
			MetaOperation_ReturnType = factory.MetaProperty();
			MetaParameter = factory.MetaClass();
			MetaParameter_Operation = factory.MetaProperty();
			MetaPropertyKind = factory.MetaEnum();
			__tmp31 = factory.MetaEnumLiteral();
			__tmp32 = factory.MetaEnumLiteral();
			__tmp33 = factory.MetaEnumLiteral();
			__tmp39 = factory.MetaEnumLiteral();
			__tmp40 = factory.MetaEnumLiteral();
			__tmp41 = factory.MetaEnumLiteral();
			MetaProperty = factory.MetaClass();
			MetaProperty_Kind = factory.MetaProperty();
			MetaProperty_Class = factory.MetaProperty();
			MetaProperty_OppositeProperties = factory.MetaProperty();
			MetaProperty_SubsettedProperties = factory.MetaProperty();
			MetaProperty_SubsettingProperties = factory.MetaProperty();
			MetaProperty_RedefinedProperties = factory.MetaProperty();
			MetaProperty_RedefiningProperties = factory.MetaProperty();
			__tmp5 = factory.MetaModel();
			MetaMetaModel = __tmp5;
			__tmp6 = factory.MetaConstant();
			__tmp7 = factory.MetaConstant();
			__tmp8 = factory.MetaConstant();
			__tmp9 = factory.MetaConstant();
			__tmp10 = factory.MetaConstant();
			__tmp11 = factory.MetaConstant();
			__tmp12 = factory.MetaConstant();
			__tmp13 = factory.MetaConstant();
			__tmp14 = factory.MetaConstant();
			__tmp15 = factory.MetaConstant();
			__tmp16 = factory.MetaConstant();
			__tmp17 = factory.MetaConstant();
			__tmp18 = factory.MetaConstant();
			__tmp19 = factory.MetaConstant();
			__tmp20 = factory.MetaConstant();
			__tmp25 = factory.MetaCollectionType();
			__tmp26 = factory.MetaCollectionType();
			__tmp27 = factory.MetaCollectionType();
			__tmp29 = factory.MetaCollectionType();
			__tmp43 = factory.MetaCollectionType();
			__tmp44 = factory.MetaCollectionType();
			__tmp45 = factory.MetaCollectionType();
			__tmp46 = factory.MetaCollectionType();
			__tmp47 = factory.MetaCollectionType();
			__tmp48 = factory.MetaCollectionType();
			__tmp49 = factory.MetaCollectionType();
			__tmp50 = factory.MetaCollectionType();
			__tmp51 = factory.MetaCollectionType();
			__tmp52 = factory.MetaCollectionType();
			__tmp53 = factory.MetaCollectionType();
			__tmp54 = factory.MetaCollectionType();
			__tmp56 = factory.MetaCollectionType();
			__tmp58 = factory.MetaCollectionType();
			__tmp60 = factory.MetaCollectionType();
			__tmp61 = factory.MetaCollectionType();
			__tmp62 = factory.MetaCollectionType();
	
			// __tmp1.MetaModel = null;
			// __tmp1.Namespace = null;
			__tmp1.Documentation = null;
			__tmp1.Name = "MetaDslx";
			// __tmp1.DefinedMetaModel = null;
			__tmp1.Declarations.AddLazy(() => __tmp2);
			// __tmp2.MetaModel = null;
			__tmp2.NamespaceLazy = () => __tmp1;
			__tmp2.Documentation = null;
			__tmp2.Name = "Languages";
			// __tmp2.DefinedMetaModel = null;
			__tmp2.Declarations.AddLazy(() => __tmp3);
			// __tmp3.MetaModel = null;
			__tmp3.NamespaceLazy = () => __tmp2;
			__tmp3.Documentation = null;
			__tmp3.Name = "Meta";
			// __tmp3.DefinedMetaModel = null;
			__tmp3.Declarations.AddLazy(() => __tmp4);
			// __tmp4.MetaModel = null;
			__tmp4.NamespaceLazy = () => __tmp3;
			__tmp4.Documentation = null;
			__tmp4.Name = "Symbols";
			__tmp4.DefinedMetaModelLazy = () => __tmp5;
			__tmp4.Declarations.AddLazy(() => MetaElement);
			__tmp4.Declarations.AddLazy(() => MetaDocumentedElement);
			__tmp4.Declarations.AddLazy(() => MetaNamedElement);
			__tmp4.Declarations.AddLazy(() => MetaTypedElement);
			__tmp4.Declarations.AddLazy(() => MetaType);
			__tmp4.Declarations.AddLazy(() => MetaNamedType);
			__tmp4.Declarations.AddLazy(() => MetaAttribute);
			__tmp4.Declarations.AddLazy(() => MetaDeclaration);
			__tmp4.Declarations.AddLazy(() => MetaNamespace);
			__tmp4.Declarations.AddLazy(() => MetaModel);
			__tmp4.Declarations.AddLazy(() => MetaCollectionKind);
			__tmp4.Declarations.AddLazy(() => MetaCollectionType);
			__tmp4.Declarations.AddLazy(() => MetaNullableType);
			__tmp4.Declarations.AddLazy(() => MetaPrimitiveType);
			__tmp4.Declarations.AddLazy(() => MetaEnum);
			__tmp4.Declarations.AddLazy(() => MetaEnumLiteral);
			__tmp4.Declarations.AddLazy(() => MetaConstant);
			__tmp4.Declarations.AddLazy(() => MetaClass);
			__tmp4.Declarations.AddLazy(() => MetaOperation);
			__tmp4.Declarations.AddLazy(() => MetaParameter);
			__tmp4.Declarations.AddLazy(() => MetaPropertyKind);
			__tmp4.Declarations.AddLazy(() => MetaProperty);
			__tmp4.Declarations.AddLazy(() => __tmp6);
			__tmp4.Declarations.AddLazy(() => __tmp7);
			__tmp4.Declarations.AddLazy(() => __tmp8);
			__tmp4.Declarations.AddLazy(() => __tmp9);
			__tmp4.Declarations.AddLazy(() => __tmp10);
			__tmp4.Declarations.AddLazy(() => __tmp11);
			__tmp4.Declarations.AddLazy(() => __tmp12);
			__tmp4.Declarations.AddLazy(() => __tmp13);
			__tmp4.Declarations.AddLazy(() => __tmp14);
			__tmp4.Declarations.AddLazy(() => __tmp15);
			__tmp4.Declarations.AddLazy(() => __tmp16);
			__tmp4.Declarations.AddLazy(() => __tmp17);
			__tmp4.Declarations.AddLazy(() => __tmp18);
			__tmp4.Declarations.AddLazy(() => __tmp19);
			__tmp4.Declarations.AddLazy(() => __tmp20);
			MetaElement.MetaModelLazy = () => __tmp5;
			MetaElement.NamespaceLazy = () => __tmp4;
			MetaElement.Documentation = null;
			MetaElement.Name = "MetaElement";
			// MetaElement.IsAbstract = null;
			MetaElement.Properties.AddLazy(() => MetaElement_Attributes);
			MetaElement_Attributes.TypeLazy = () => __tmp25;
			MetaElement_Attributes.Name = "Attributes";
			MetaElement_Attributes.Documentation = null;
			// MetaElement_Attributes.Kind = null;
			MetaElement_Attributes.ClassLazy = () => MetaElement;
			MetaDocumentedElement.MetaModelLazy = () => __tmp5;
			MetaDocumentedElement.NamespaceLazy = () => __tmp4;
			MetaDocumentedElement.Documentation = null;
			MetaDocumentedElement.Name = "MetaDocumentedElement";
			// MetaDocumentedElement.IsAbstract = null;
			MetaDocumentedElement.SuperClasses.AddLazy(() => MetaElement);
			MetaDocumentedElement.Properties.AddLazy(() => MetaDocumentedElement_Documentation);
			MetaDocumentedElement.Operations.AddLazy(() => __tmp28);
			MetaDocumentedElement_Documentation.TypeLazy = () => String;
			MetaDocumentedElement_Documentation.Name = "Documentation";
			MetaDocumentedElement_Documentation.Documentation = null;
			// MetaDocumentedElement_Documentation.Kind = null;
			MetaDocumentedElement_Documentation.ClassLazy = () => MetaDocumentedElement;
			__tmp28.Name = "GetDocumentationLines";
			__tmp28.Documentation = null;
			__tmp28.ParentLazy = () => MetaDocumentedElement;
			__tmp28.ReturnTypeLazy = () => __tmp29;
			MetaNamedElement.MetaModelLazy = () => __tmp5;
			MetaNamedElement.NamespaceLazy = () => __tmp4;
			MetaNamedElement.Documentation = null;
			MetaNamedElement.Name = "MetaNamedElement";
			// MetaNamedElement.IsAbstract = null;
			MetaNamedElement.SuperClasses.AddLazy(() => MetaDocumentedElement);
			MetaNamedElement.Properties.AddLazy(() => MetaNamedElement_Name);
			MetaNamedElement_Name.TypeLazy = () => String;
			MetaNamedElement_Name.Attributes.Add(NameAttribute);
			MetaNamedElement_Name.Name = "Name";
			MetaNamedElement_Name.Documentation = null;
			// MetaNamedElement_Name.Kind = null;
			MetaNamedElement_Name.ClassLazy = () => MetaNamedElement;
			MetaTypedElement.MetaModelLazy = () => __tmp5;
			MetaTypedElement.NamespaceLazy = () => __tmp4;
			MetaTypedElement.Documentation = null;
			MetaTypedElement.Name = "MetaTypedElement";
			// MetaTypedElement.IsAbstract = null;
			MetaTypedElement.SuperClasses.AddLazy(() => MetaElement);
			MetaTypedElement.Properties.AddLazy(() => MetaTypedElement_Type);
			MetaTypedElement_Type.TypeLazy = () => MetaType;
			MetaTypedElement_Type.Attributes.Add(TypeAttribute);
			MetaTypedElement_Type.Name = "Type";
			MetaTypedElement_Type.Documentation = null;
			// MetaTypedElement_Type.Kind = null;
			MetaTypedElement_Type.ClassLazy = () => MetaTypedElement;
			MetaTypedElement_Type.RedefiningProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaType.MetaModelLazy = () => __tmp5;
			MetaType.NamespaceLazy = () => __tmp4;
			MetaType.Documentation = null;
			MetaType.Attributes.Add(TypeAttribute);
			MetaType.Name = "MetaType";
			// MetaType.IsAbstract = null;
			MetaNamedType.MetaModelLazy = () => __tmp5;
			MetaNamedType.NamespaceLazy = () => __tmp4;
			MetaNamedType.Documentation = null;
			MetaNamedType.Name = "MetaNamedType";
			// MetaNamedType.IsAbstract = null;
			MetaNamedType.SuperClasses.AddLazy(() => MetaType);
			MetaNamedType.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaAttribute.MetaModelLazy = () => __tmp5;
			MetaAttribute.NamespaceLazy = () => __tmp4;
			MetaAttribute.Documentation = null;
			MetaAttribute.Name = "MetaAttribute";
			// MetaAttribute.IsAbstract = null;
			MetaAttribute.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.MetaModelLazy = () => __tmp5;
			MetaDeclaration.NamespaceLazy = () => __tmp4;
			MetaDeclaration.Documentation = null;
			MetaDeclaration.Name = "MetaDeclaration";
			// MetaDeclaration.IsAbstract = null;
			MetaDeclaration.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_Namespace);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_MetaModel);
			MetaDeclaration_Namespace.TypeLazy = () => MetaNamespace;
			MetaDeclaration_Namespace.Name = "Namespace";
			MetaDeclaration_Namespace.Documentation = null;
			// MetaDeclaration_Namespace.Kind = null;
			MetaDeclaration_Namespace.ClassLazy = () => MetaDeclaration;
			MetaDeclaration_Namespace.OppositeProperties.AddLazy(() => MetaNamespace_Declarations);
			MetaDeclaration_MetaModel.TypeLazy = () => MetaModel;
			MetaDeclaration_MetaModel.Name = "MetaModel";
			MetaDeclaration_MetaModel.Documentation = null;
			MetaDeclaration_MetaModel.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Derived;
			MetaDeclaration_MetaModel.ClassLazy = () => MetaDeclaration;
			MetaNamespace.MetaModelLazy = () => __tmp5;
			MetaNamespace.NamespaceLazy = () => __tmp4;
			MetaNamespace.Documentation = null;
			MetaNamespace.Attributes.Add(ScopeAttribute);
			MetaNamespace.Name = "MetaNamespace";
			// MetaNamespace.IsAbstract = null;
			MetaNamespace.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_DefinedMetaModel);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Declarations);
			MetaNamespace_DefinedMetaModel.TypeLazy = () => MetaModel;
			MetaNamespace_DefinedMetaModel.Name = "DefinedMetaModel";
			MetaNamespace_DefinedMetaModel.Documentation = null;
			MetaNamespace_DefinedMetaModel.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaNamespace_DefinedMetaModel.ClassLazy = () => MetaNamespace;
			MetaNamespace_DefinedMetaModel.OppositeProperties.AddLazy(() => MetaModel_Namespace);
			MetaNamespace_Declarations.TypeLazy = () => __tmp26;
			MetaNamespace_Declarations.Name = "Declarations";
			MetaNamespace_Declarations.Documentation = null;
			MetaNamespace_Declarations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaNamespace_Declarations.ClassLazy = () => MetaNamespace;
			MetaNamespace_Declarations.OppositeProperties.AddLazy(() => MetaDeclaration_Namespace);
			MetaModel.MetaModelLazy = () => __tmp5;
			MetaModel.NamespaceLazy = () => __tmp4;
			MetaModel.Documentation = null;
			MetaModel.Name = "MetaModel";
			// MetaModel.IsAbstract = null;
			MetaModel.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaModel.Properties.AddLazy(() => MetaModel_Uri);
			MetaModel.Properties.AddLazy(() => MetaModel_Namespace);
			MetaModel_Uri.TypeLazy = () => String;
			MetaModel_Uri.Name = "Uri";
			MetaModel_Uri.Documentation = null;
			// MetaModel_Uri.Kind = null;
			MetaModel_Uri.ClassLazy = () => MetaModel;
			MetaModel_Namespace.TypeLazy = () => MetaNamespace;
			MetaModel_Namespace.Name = "Namespace";
			MetaModel_Namespace.Documentation = null;
			// MetaModel_Namespace.Kind = null;
			MetaModel_Namespace.ClassLazy = () => MetaModel;
			MetaModel_Namespace.OppositeProperties.AddLazy(() => MetaNamespace_DefinedMetaModel);
			MetaCollectionKind.MetaModelLazy = () => __tmp5;
			MetaCollectionKind.NamespaceLazy = () => __tmp4;
			MetaCollectionKind.Documentation = null;
			MetaCollectionKind.Name = "MetaCollectionKind";
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp21);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp22);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp23);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp24);
			__tmp21.TypeLazy = () => MetaCollectionKind;
			__tmp21.Name = "List";
			__tmp21.Documentation = null;
			__tmp21.EnumLazy = () => MetaCollectionKind;
			__tmp22.TypeLazy = () => MetaCollectionKind;
			__tmp22.Name = "Set";
			__tmp22.Documentation = null;
			__tmp22.EnumLazy = () => MetaCollectionKind;
			__tmp23.TypeLazy = () => MetaCollectionKind;
			__tmp23.Name = "MultiList";
			__tmp23.Documentation = null;
			__tmp23.EnumLazy = () => MetaCollectionKind;
			__tmp24.TypeLazy = () => MetaCollectionKind;
			__tmp24.Name = "MultiSet";
			__tmp24.Documentation = null;
			__tmp24.EnumLazy = () => MetaCollectionKind;
			MetaCollectionType.MetaModelLazy = () => __tmp5;
			MetaCollectionType.NamespaceLazy = () => __tmp4;
			MetaCollectionType.Documentation = null;
			MetaCollectionType.Name = "MetaCollectionType";
			// MetaCollectionType.IsAbstract = null;
			MetaCollectionType.SuperClasses.AddLazy(() => MetaType);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_Kind);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_InnerType);
			MetaCollectionType_Kind.TypeLazy = () => MetaCollectionKind;
			MetaCollectionType_Kind.Name = "Kind";
			MetaCollectionType_Kind.Documentation = null;
			// MetaCollectionType_Kind.Kind = null;
			MetaCollectionType_Kind.ClassLazy = () => MetaCollectionType;
			MetaCollectionType_InnerType.TypeLazy = () => MetaType;
			MetaCollectionType_InnerType.Name = "InnerType";
			MetaCollectionType_InnerType.Documentation = null;
			// MetaCollectionType_InnerType.Kind = null;
			MetaCollectionType_InnerType.ClassLazy = () => MetaCollectionType;
			MetaNullableType.MetaModelLazy = () => __tmp5;
			MetaNullableType.NamespaceLazy = () => __tmp4;
			MetaNullableType.Documentation = null;
			MetaNullableType.Name = "MetaNullableType";
			// MetaNullableType.IsAbstract = null;
			MetaNullableType.SuperClasses.AddLazy(() => MetaType);
			MetaNullableType.Properties.AddLazy(() => MetaNullableType_InnerType);
			MetaNullableType_InnerType.TypeLazy = () => MetaType;
			MetaNullableType_InnerType.Name = "InnerType";
			MetaNullableType_InnerType.Documentation = null;
			// MetaNullableType_InnerType.Kind = null;
			MetaNullableType_InnerType.ClassLazy = () => MetaNullableType;
			MetaPrimitiveType.MetaModelLazy = () => __tmp5;
			MetaPrimitiveType.NamespaceLazy = () => __tmp4;
			MetaPrimitiveType.Documentation = null;
			MetaPrimitiveType.Name = "MetaPrimitiveType";
			// MetaPrimitiveType.IsAbstract = null;
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaType);
			MetaEnum.MetaModelLazy = () => __tmp5;
			MetaEnum.NamespaceLazy = () => __tmp4;
			MetaEnum.Documentation = null;
			MetaEnum.Attributes.Add(ScopeAttribute);
			MetaEnum.Name = "MetaEnum";
			// MetaEnum.IsAbstract = null;
			MetaEnum.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaEnum.SuperClasses.AddLazy(() => MetaType);
			MetaEnum.Properties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnum.Properties.AddLazy(() => MetaEnum_Operations);
			MetaEnum_EnumLiterals.TypeLazy = () => __tmp46;
			MetaEnum_EnumLiterals.Name = "EnumLiterals";
			MetaEnum_EnumLiterals.Documentation = null;
			MetaEnum_EnumLiterals.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaEnum_EnumLiterals.ClassLazy = () => MetaEnum;
			MetaEnum_EnumLiterals.OppositeProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaEnum_Operations.TypeLazy = () => __tmp27;
			MetaEnum_Operations.Name = "Operations";
			MetaEnum_Operations.Documentation = null;
			MetaEnum_Operations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaEnum_Operations.ClassLazy = () => MetaEnum;
			MetaEnum_Operations.OppositeProperties.AddLazy(() => MetaOperation_Parent);
			MetaEnumLiteral.MetaModelLazy = () => __tmp5;
			MetaEnumLiteral.NamespaceLazy = () => __tmp4;
			MetaEnumLiteral.Documentation = null;
			MetaEnumLiteral.Name = "MetaEnumLiteral";
			// MetaEnumLiteral.IsAbstract = null;
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaEnumLiteral.Properties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaEnumLiteral_Enum.TypeLazy = () => MetaEnum;
			MetaEnumLiteral_Enum.Name = "Enum";
			MetaEnumLiteral_Enum.Documentation = null;
			// MetaEnumLiteral_Enum.Kind = null;
			MetaEnumLiteral_Enum.ClassLazy = () => MetaEnumLiteral;
			MetaEnumLiteral_Enum.OppositeProperties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnumLiteral_Enum.RedefinedProperties.AddLazy(() => MetaTypedElement_Type);
			MetaConstant.MetaModelLazy = () => __tmp5;
			MetaConstant.NamespaceLazy = () => __tmp4;
			MetaConstant.Documentation = null;
			MetaConstant.Name = "MetaConstant";
			// MetaConstant.IsAbstract = null;
			MetaConstant.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaConstant.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaClass.MetaModelLazy = () => __tmp5;
			MetaClass.NamespaceLazy = () => __tmp4;
			MetaClass.Documentation = null;
			MetaClass.Attributes.Add(ScopeAttribute);
			MetaClass.Name = "MetaClass";
			// MetaClass.IsAbstract = null;
			MetaClass.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaClass.SuperClasses.AddLazy(() => MetaType);
			MetaClass.Properties.AddLazy(() => MetaClass_IsAbstract);
			MetaClass.Properties.AddLazy(() => MetaClass_SuperClasses);
			MetaClass.Properties.AddLazy(() => MetaClass_Properties);
			MetaClass.Properties.AddLazy(() => MetaClass_Operations);
			MetaClass.Operations.AddLazy(() => __tmp30);
			MetaClass.Operations.AddLazy(() => __tmp34);
			MetaClass.Operations.AddLazy(() => __tmp35);
			MetaClass.Operations.AddLazy(() => __tmp36);
			MetaClass.Operations.AddLazy(() => __tmp37);
			MetaClass.Operations.AddLazy(() => __tmp38);
			MetaClass.Operations.AddLazy(() => __tmp42);
			MetaClass_IsAbstract.TypeLazy = () => Bool;
			MetaClass_IsAbstract.Name = "IsAbstract";
			MetaClass_IsAbstract.Documentation = null;
			// MetaClass_IsAbstract.Kind = null;
			MetaClass_IsAbstract.ClassLazy = () => MetaClass;
			MetaClass_SuperClasses.TypeLazy = () => __tmp51;
			MetaClass_SuperClasses.Attributes.Add(BaseScopeAttribute);
			MetaClass_SuperClasses.Name = "SuperClasses";
			MetaClass_SuperClasses.Documentation = null;
			// MetaClass_SuperClasses.Kind = null;
			MetaClass_SuperClasses.ClassLazy = () => MetaClass;
			MetaClass_Properties.TypeLazy = () => __tmp52;
			MetaClass_Properties.Name = "Properties";
			MetaClass_Properties.Documentation = null;
			MetaClass_Properties.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaClass_Properties.ClassLazy = () => MetaClass;
			MetaClass_Properties.OppositeProperties.AddLazy(() => MetaProperty_Class);
			MetaClass_Operations.TypeLazy = () => __tmp53;
			MetaClass_Operations.Name = "Operations";
			MetaClass_Operations.Documentation = null;
			MetaClass_Operations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaClass_Operations.ClassLazy = () => MetaClass;
			MetaClass_Operations.OppositeProperties.AddLazy(() => MetaOperation_Parent);
			__tmp30.Name = "GetAllSuperClasses";
			__tmp30.Documentation = null;
			__tmp30.ParentLazy = () => MetaClass;
			__tmp30.Parameters.AddLazy(() => __tmp55);
			__tmp30.ReturnTypeLazy = () => __tmp54;
			__tmp55.TypeLazy = () => Bool;
			__tmp55.Name = "includeSelf";
			__tmp55.Documentation = null;
			__tmp55.OperationLazy = () => __tmp30;
			__tmp34.Name = "GetAllSuperProperties";
			__tmp34.Documentation = null;
			__tmp34.ParentLazy = () => MetaClass;
			__tmp34.Parameters.AddLazy(() => __tmp57);
			__tmp34.ReturnTypeLazy = () => __tmp56;
			__tmp57.TypeLazy = () => Bool;
			__tmp57.Name = "includeSelf";
			__tmp57.Documentation = null;
			__tmp57.OperationLazy = () => __tmp34;
			__tmp35.Name = "GetAllSuperOperations";
			__tmp35.Documentation = null;
			__tmp35.ParentLazy = () => MetaClass;
			__tmp35.Parameters.AddLazy(() => __tmp59);
			__tmp35.ReturnTypeLazy = () => __tmp58;
			__tmp59.TypeLazy = () => Bool;
			__tmp59.Name = "includeSelf";
			__tmp59.Documentation = null;
			__tmp59.OperationLazy = () => __tmp35;
			__tmp36.Name = "GetAllProperties";
			__tmp36.Documentation = null;
			__tmp36.ParentLazy = () => MetaClass;
			__tmp36.ReturnTypeLazy = () => __tmp60;
			__tmp37.Name = "GetAllOperations";
			__tmp37.Documentation = null;
			__tmp37.ParentLazy = () => MetaClass;
			__tmp37.ReturnTypeLazy = () => __tmp61;
			__tmp38.Name = "GetAllFinalProperties";
			__tmp38.Documentation = null;
			__tmp38.ParentLazy = () => MetaClass;
			__tmp38.ReturnTypeLazy = () => __tmp62;
			__tmp42.Name = "GetAllFinalOperations";
			__tmp42.Documentation = null;
			__tmp42.ParentLazy = () => MetaClass;
			__tmp42.ReturnTypeLazy = () => __tmp43;
			MetaOperation.MetaModelLazy = () => __tmp5;
			MetaOperation.NamespaceLazy = () => __tmp4;
			MetaOperation.Documentation = null;
			MetaOperation.Attributes.Add(LocalScopeAttribute);
			MetaOperation.Name = "MetaOperation";
			// MetaOperation.IsAbstract = null;
			MetaOperation.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Parent);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Parameters);
			MetaOperation.Properties.AddLazy(() => MetaOperation_ReturnType);
			MetaOperation_Parent.TypeLazy = () => MetaType;
			MetaOperation_Parent.Name = "Parent";
			MetaOperation_Parent.Documentation = null;
			// MetaOperation_Parent.Kind = null;
			MetaOperation_Parent.ClassLazy = () => MetaOperation;
			MetaOperation_Parent.OppositeProperties.AddLazy(() => MetaClass_Operations);
			MetaOperation_Parent.OppositeProperties.AddLazy(() => MetaEnum_Operations);
			MetaOperation_Parameters.TypeLazy = () => __tmp44;
			MetaOperation_Parameters.Name = "Parameters";
			MetaOperation_Parameters.Documentation = null;
			MetaOperation_Parameters.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaOperation_Parameters.ClassLazy = () => MetaOperation;
			MetaOperation_Parameters.OppositeProperties.AddLazy(() => MetaParameter_Operation);
			MetaOperation_ReturnType.TypeLazy = () => MetaType;
			MetaOperation_ReturnType.Name = "ReturnType";
			MetaOperation_ReturnType.Documentation = null;
			// MetaOperation_ReturnType.Kind = null;
			MetaOperation_ReturnType.ClassLazy = () => MetaOperation;
			MetaParameter.MetaModelLazy = () => __tmp5;
			MetaParameter.NamespaceLazy = () => __tmp4;
			MetaParameter.Documentation = null;
			MetaParameter.Name = "MetaParameter";
			// MetaParameter.IsAbstract = null;
			MetaParameter.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaParameter.Properties.AddLazy(() => MetaParameter_Operation);
			MetaParameter_Operation.TypeLazy = () => MetaOperation;
			MetaParameter_Operation.Name = "Operation";
			MetaParameter_Operation.Documentation = null;
			// MetaParameter_Operation.Kind = null;
			MetaParameter_Operation.ClassLazy = () => MetaParameter;
			MetaParameter_Operation.OppositeProperties.AddLazy(() => MetaOperation_Parameters);
			MetaPropertyKind.MetaModelLazy = () => __tmp5;
			MetaPropertyKind.NamespaceLazy = () => __tmp4;
			MetaPropertyKind.Documentation = null;
			MetaPropertyKind.Name = "MetaPropertyKind";
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp31);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp32);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp33);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp39);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp40);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp41);
			__tmp31.TypeLazy = () => MetaPropertyKind;
			__tmp31.Name = "Normal";
			__tmp31.Documentation = null;
			__tmp31.EnumLazy = () => MetaPropertyKind;
			__tmp32.TypeLazy = () => MetaPropertyKind;
			__tmp32.Name = "Readonly";
			__tmp32.Documentation = null;
			__tmp32.EnumLazy = () => MetaPropertyKind;
			__tmp33.TypeLazy = () => MetaPropertyKind;
			__tmp33.Name = "Lazy";
			__tmp33.Documentation = null;
			__tmp33.EnumLazy = () => MetaPropertyKind;
			__tmp39.TypeLazy = () => MetaPropertyKind;
			__tmp39.Name = "Derived";
			__tmp39.Documentation = null;
			__tmp39.EnumLazy = () => MetaPropertyKind;
			__tmp40.TypeLazy = () => MetaPropertyKind;
			__tmp40.Name = "DerivedUnion";
			__tmp40.Documentation = null;
			__tmp40.EnumLazy = () => MetaPropertyKind;
			__tmp41.TypeLazy = () => MetaPropertyKind;
			__tmp41.Name = "Containment";
			__tmp41.Documentation = null;
			__tmp41.EnumLazy = () => MetaPropertyKind;
			MetaProperty.MetaModelLazy = () => __tmp5;
			MetaProperty.NamespaceLazy = () => __tmp4;
			MetaProperty.Documentation = null;
			MetaProperty.Name = "MetaProperty";
			// MetaProperty.IsAbstract = null;
			MetaProperty.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaProperty.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaProperty.Properties.AddLazy(() => MetaProperty_Kind);
			MetaProperty.Properties.AddLazy(() => MetaProperty_Class);
			MetaProperty.Properties.AddLazy(() => MetaProperty_OppositeProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettingProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefinedProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefiningProperties);
			MetaProperty_Kind.TypeLazy = () => MetaPropertyKind;
			MetaProperty_Kind.Name = "Kind";
			MetaProperty_Kind.Documentation = null;
			// MetaProperty_Kind.Kind = null;
			MetaProperty_Kind.ClassLazy = () => MetaProperty;
			MetaProperty_Class.TypeLazy = () => MetaClass;
			MetaProperty_Class.Name = "Class";
			MetaProperty_Class.Documentation = null;
			// MetaProperty_Class.Kind = null;
			MetaProperty_Class.ClassLazy = () => MetaProperty;
			MetaProperty_Class.OppositeProperties.AddLazy(() => MetaClass_Properties);
			MetaProperty_OppositeProperties.TypeLazy = () => __tmp47;
			MetaProperty_OppositeProperties.Name = "OppositeProperties";
			MetaProperty_OppositeProperties.Documentation = null;
			// MetaProperty_OppositeProperties.Kind = null;
			MetaProperty_OppositeProperties.ClassLazy = () => MetaProperty;
			MetaProperty_OppositeProperties.OppositeProperties.AddLazy(() => MetaProperty_OppositeProperties);
			MetaProperty_SubsettedProperties.TypeLazy = () => __tmp48;
			MetaProperty_SubsettedProperties.Name = "SubsettedProperties";
			MetaProperty_SubsettedProperties.Documentation = null;
			// MetaProperty_SubsettedProperties.Kind = null;
			MetaProperty_SubsettedProperties.ClassLazy = () => MetaProperty;
			MetaProperty_SubsettedProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettingProperties);
			MetaProperty_SubsettingProperties.TypeLazy = () => __tmp49;
			MetaProperty_SubsettingProperties.Name = "SubsettingProperties";
			MetaProperty_SubsettingProperties.Documentation = null;
			// MetaProperty_SubsettingProperties.Kind = null;
			MetaProperty_SubsettingProperties.ClassLazy = () => MetaProperty;
			MetaProperty_SubsettingProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty_RedefinedProperties.TypeLazy = () => __tmp50;
			MetaProperty_RedefinedProperties.Name = "RedefinedProperties";
			MetaProperty_RedefinedProperties.Documentation = null;
			// MetaProperty_RedefinedProperties.Kind = null;
			MetaProperty_RedefinedProperties.ClassLazy = () => MetaProperty;
			MetaProperty_RedefinedProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefiningProperties);
			MetaProperty_RedefiningProperties.TypeLazy = () => __tmp45;
			MetaProperty_RedefiningProperties.Name = "RedefiningProperties";
			MetaProperty_RedefiningProperties.Documentation = null;
			// MetaProperty_RedefiningProperties.Kind = null;
			MetaProperty_RedefiningProperties.ClassLazy = () => MetaProperty;
			MetaProperty_RedefiningProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefinedProperties);
			__tmp5.Name = "Meta";
			__tmp5.Documentation = null;
			__tmp5.Uri = "http://metadslx.core/1.0";
			__tmp5.NamespaceLazy = () => __tmp4;
			__tmp6.TypeLazy = () => MetaPrimitiveType;
			__tmp6.MetaModelLazy = () => __tmp5;
			__tmp6.NamespaceLazy = () => __tmp4;
			__tmp6.Documentation = null;
			__tmp6.Name = "Object";
			__tmp7.TypeLazy = () => MetaPrimitiveType;
			__tmp7.MetaModelLazy = () => __tmp5;
			__tmp7.NamespaceLazy = () => __tmp4;
			__tmp7.Documentation = null;
			__tmp7.Name = "String";
			__tmp8.TypeLazy = () => MetaPrimitiveType;
			__tmp8.MetaModelLazy = () => __tmp5;
			__tmp8.NamespaceLazy = () => __tmp4;
			__tmp8.Documentation = null;
			__tmp8.Name = "Int";
			__tmp9.TypeLazy = () => MetaPrimitiveType;
			__tmp9.MetaModelLazy = () => __tmp5;
			__tmp9.NamespaceLazy = () => __tmp4;
			__tmp9.Documentation = null;
			__tmp9.Name = "Long";
			__tmp10.TypeLazy = () => MetaPrimitiveType;
			__tmp10.MetaModelLazy = () => __tmp5;
			__tmp10.NamespaceLazy = () => __tmp4;
			__tmp10.Documentation = null;
			__tmp10.Name = "Float";
			__tmp11.TypeLazy = () => MetaPrimitiveType;
			__tmp11.MetaModelLazy = () => __tmp5;
			__tmp11.NamespaceLazy = () => __tmp4;
			__tmp11.Documentation = null;
			__tmp11.Name = "Double";
			__tmp12.TypeLazy = () => MetaPrimitiveType;
			__tmp12.MetaModelLazy = () => __tmp5;
			__tmp12.NamespaceLazy = () => __tmp4;
			__tmp12.Documentation = null;
			__tmp12.Name = "Byte";
			__tmp13.TypeLazy = () => MetaPrimitiveType;
			__tmp13.MetaModelLazy = () => __tmp5;
			__tmp13.NamespaceLazy = () => __tmp4;
			__tmp13.Documentation = null;
			__tmp13.Name = "Bool";
			__tmp14.TypeLazy = () => MetaPrimitiveType;
			__tmp14.MetaModelLazy = () => __tmp5;
			__tmp14.NamespaceLazy = () => __tmp4;
			__tmp14.Documentation = null;
			__tmp14.Name = "Void";
			__tmp15.TypeLazy = () => MetaPrimitiveType;
			__tmp15.MetaModelLazy = () => __tmp5;
			__tmp15.NamespaceLazy = () => __tmp4;
			__tmp15.Documentation = null;
			__tmp15.Name = "ModelObject";
			__tmp16.TypeLazy = () => MetaAttribute;
			__tmp16.MetaModelLazy = () => __tmp5;
			__tmp16.NamespaceLazy = () => __tmp4;
			__tmp16.Documentation = null;
			__tmp16.Name = "NameAttribute";
			__tmp17.TypeLazy = () => MetaAttribute;
			__tmp17.MetaModelLazy = () => __tmp5;
			__tmp17.NamespaceLazy = () => __tmp4;
			__tmp17.Documentation = null;
			__tmp17.Name = "TypeAttribute";
			__tmp18.TypeLazy = () => MetaAttribute;
			__tmp18.MetaModelLazy = () => __tmp5;
			__tmp18.NamespaceLazy = () => __tmp4;
			__tmp18.Documentation = null;
			__tmp18.Name = "ScopeAttribute";
			__tmp19.TypeLazy = () => MetaAttribute;
			__tmp19.MetaModelLazy = () => __tmp5;
			__tmp19.NamespaceLazy = () => __tmp4;
			__tmp19.Documentation = null;
			__tmp19.Name = "BaseScopeAttribute";
			__tmp20.TypeLazy = () => MetaAttribute;
			__tmp20.MetaModelLazy = () => __tmp5;
			__tmp20.NamespaceLazy = () => __tmp4;
			__tmp20.Documentation = null;
			__tmp20.Name = "LocalScopeAttribute";
			__tmp25.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp25.InnerTypeLazy = () => MetaAttribute;
			__tmp26.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp26.InnerTypeLazy = () => MetaDeclaration;
			__tmp27.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp27.InnerTypeLazy = () => MetaOperation;
			__tmp29.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp29.InnerTypeLazy = () => String;
			__tmp43.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp43.InnerTypeLazy = () => MetaOperation;
			__tmp44.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp44.InnerTypeLazy = () => MetaParameter;
			__tmp45.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp45.InnerTypeLazy = () => MetaProperty;
			__tmp46.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp46.InnerTypeLazy = () => MetaEnumLiteral;
			__tmp47.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp47.InnerTypeLazy = () => MetaProperty;
			__tmp48.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp48.InnerTypeLazy = () => MetaProperty;
			__tmp49.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp49.InnerTypeLazy = () => MetaProperty;
			__tmp50.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp50.InnerTypeLazy = () => MetaProperty;
			__tmp51.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp51.InnerTypeLazy = () => MetaClass;
			__tmp52.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp52.InnerTypeLazy = () => MetaProperty;
			__tmp53.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp53.InnerTypeLazy = () => MetaOperation;
			__tmp54.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp54.InnerTypeLazy = () => MetaClass;
			__tmp56.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp56.InnerTypeLazy = () => MetaProperty;
			__tmp58.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp58.InnerTypeLazy = () => MetaOperation;
			__tmp60.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp60.InnerTypeLazy = () => MetaProperty;
			__tmp61.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp61.InnerTypeLazy = () => MetaOperation;
			__tmp62.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp62.InnerTypeLazy = () => MetaProperty;
	
			foreach (global::MetaDslx.Modeling.MutableSymbol symbol in this.Model.Symbols)
			{
				symbol.MMakeCreated();
			}
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class MetaImplementationBase
	{
		/// <summary>
		/// Implements the constructor: MetaBuilderInstance()
		/// </summary>
		internal virtual void MetaBuilderInstance(MetaBuilderInstance _this)
		{
		}
	
		/// <summary>
		/// Implements the constructor: MetaElement()
		/// </summary>
		public virtual void MetaElement(MetaElementBuilder _this)
		{
			this.CallMetaElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaElement
		/// </summary>
		protected virtual void CallMetaElementSuperConstructors(MetaElementBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaDocumentedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		/// </ul>
		public virtual void MetaDocumentedElement(MetaDocumentedElementBuilder _this)
		{
			this.CallMetaDocumentedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaDocumentedElement
		/// </summary>
		protected virtual void CallMetaDocumentedElementSuperConstructors(MetaDocumentedElementBuilder _this)
		{
			this.MetaElement(_this);
		}
	
		/// <summary>
		/// Implements the operation: MetaDocumentedElement.GetDocumentationLines()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<string> MetaDocumentedElement_GetDocumentationLines(MetaDocumentedElement _this)
		{
			throw new NotImplementedException();
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaNamedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		/// </ul>
		public virtual void MetaNamedElement(MetaNamedElementBuilder _this)
		{
			this.CallMetaNamedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaNamedElement
		/// </summary>
		protected virtual void CallMetaNamedElementSuperConstructors(MetaNamedElementBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaTypedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		/// </ul>
		public virtual void MetaTypedElement(MetaTypedElementBuilder _this)
		{
			this.CallMetaTypedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaTypedElement
		/// </summary>
		protected virtual void CallMetaTypedElementSuperConstructors(MetaTypedElementBuilder _this)
		{
			this.MetaElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaType()
		/// </summary>
		public virtual void MetaType(MetaTypeBuilder _this)
		{
			this.CallMetaTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaType
		/// </summary>
		protected virtual void CallMetaTypeSuperConstructors(MetaTypeBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaNamedType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaType</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaType</li>
		/// </ul>
		public virtual void MetaNamedType(MetaNamedTypeBuilder _this)
		{
			this.CallMetaNamedTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaNamedType
		/// </summary>
		protected virtual void CallMetaNamedTypeSuperConstructors(MetaNamedTypeBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaAttribute()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		public virtual void MetaAttribute(MetaAttributeBuilder _this)
		{
			this.CallMetaAttributeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaAttribute
		/// </summary>
		protected virtual void CallMetaAttributeSuperConstructors(MetaAttributeBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaDeclaration()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>MetaModel</li>
		/// </ul>
		public virtual void MetaDeclaration(MetaDeclarationBuilder _this)
		{
			this.CallMetaDeclarationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaDeclaration
		/// </summary>
		protected virtual void CallMetaDeclarationSuperConstructors(MetaDeclarationBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaNamespace()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaDeclaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		public virtual void MetaNamespace(MetaNamespaceBuilder _this)
		{
			this.CallMetaNamespaceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaNamespace
		/// </summary>
		protected virtual void CallMetaNamespaceSuperConstructors(MetaNamespaceBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaModel()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		public virtual void MetaModel(MetaModelBuilder _this)
		{
			this.CallMetaModelSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaModel
		/// </summary>
		protected virtual void CallMetaModelSuperConstructors(MetaModelBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaCollectionType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaType</li>
		/// </ul>
		public virtual void MetaCollectionType(MetaCollectionTypeBuilder _this)
		{
			this.CallMetaCollectionTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaCollectionType
		/// </summary>
		protected virtual void CallMetaCollectionTypeSuperConstructors(MetaCollectionTypeBuilder _this)
		{
			this.MetaType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaNullableType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaType</li>
		/// </ul>
		public virtual void MetaNullableType(MetaNullableTypeBuilder _this)
		{
			this.CallMetaNullableTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaNullableType
		/// </summary>
		protected virtual void CallMetaNullableTypeSuperConstructors(MetaNullableTypeBuilder _this)
		{
			this.MetaType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaPrimitiveType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaType</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		public virtual void MetaPrimitiveType(MetaPrimitiveTypeBuilder _this)
		{
			this.CallMetaPrimitiveTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaPrimitiveType
		/// </summary>
		protected virtual void CallMetaPrimitiveTypeSuperConstructors(MetaPrimitiveTypeBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaType(_this);
			this.MetaDeclaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaEnum()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaType</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		public virtual void MetaEnum(MetaEnumBuilder _this)
		{
			this.CallMetaEnumSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaEnum
		/// </summary>
		protected virtual void CallMetaEnumSuperConstructors(MetaEnumBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaType(_this);
			this.MetaDeclaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaEnumLiteral()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		///     <li>MetaTypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		public virtual void MetaEnumLiteral(MetaEnumLiteralBuilder _this)
		{
			this.CallMetaEnumLiteralSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaEnumLiteral
		/// </summary>
		protected virtual void CallMetaEnumLiteralSuperConstructors(MetaEnumLiteralBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaTypedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaConstant()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaDeclaration</li>
		///     <li>MetaTypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		public virtual void MetaConstant(MetaConstantBuilder _this)
		{
			this.CallMetaConstantSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaConstant
		/// </summary>
		protected virtual void CallMetaConstantSuperConstructors(MetaConstantBuilder _this)
		{
			this.MetaDocumentedElement(_this);
			this.MetaElement(_this);
			this.MetaNamedElement(_this);
			this.MetaTypedElement(_this);
			this.MetaDeclaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaClass()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaType</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		public virtual void MetaClass(MetaClassBuilder _this)
		{
			this.CallMetaClassSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaClass
		/// </summary>
		protected virtual void CallMetaClassSuperConstructors(MetaClassBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaType(_this);
			this.MetaDeclaration(_this);
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperClasses()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperProperties()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> MetaClass_GetAllSuperProperties(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperOperations()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> MetaClass_GetAllSuperOperations(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllProperties()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> MetaClass_GetAllProperties(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllOperations()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> MetaClass_GetAllOperations(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllFinalProperties()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> MetaClass_GetAllFinalProperties(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllFinalOperations()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> MetaClass_GetAllFinalOperations(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaOperation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		public virtual void MetaOperation(MetaOperationBuilder _this)
		{
			this.CallMetaOperationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaOperation
		/// </summary>
		protected virtual void CallMetaOperationSuperConstructors(MetaOperationBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaParameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		///     <li>MetaTypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		public virtual void MetaParameter(MetaParameterBuilder _this)
		{
			this.CallMetaParameterSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaParameter
		/// </summary>
		protected virtual void CallMetaParameterSuperConstructors(MetaParameterBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaTypedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaProperty()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		///     <li>MetaTypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		public virtual void MetaProperty(MetaPropertyBuilder _this)
		{
			this.CallMetaPropertySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaProperty
		/// </summary>
		protected virtual void CallMetaPropertySuperConstructors(MetaPropertyBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaTypedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
	
	}

	internal class MetaImplementationProvider
	{
		// If there is a compile error at this line, create a new class called MetaImplementation
		// which is a subclass of global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationBase:
		private static MetaImplementation implementation = new MetaImplementation();
	
		public static MetaImplementation Implementation
		{
			get { return implementation; }
		}
	}
}

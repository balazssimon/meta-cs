// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetaDslx.Languages.Meta.Model
{
	using global::MetaDslx.Languages.Meta.Model.Internal;

	internal class MetaMetaModel : global::MetaDslx.Modeling.IMetaModel
	{
		internal MetaMetaModel()
		{
		}
	
		public global::MetaDslx.Modeling.ModelId Id => MetaInstance.MModel.Id;
		public string Name => "Meta";
		public global::MetaDslx.Modeling.ModelVersion Version => MetaInstance.MModel.Version;
		public global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> Objects => MetaInstance.MModel.Objects;
		public string Uri => "http://metadslx.core/1.0";
		public string Prefix => "";
		public global::MetaDslx.Modeling.IModelGroup ModelGroup => MetaInstance.MModel.ModelGroup;
		public string Namespace => "MetaDslx.Languages.Meta.Model";
	
		public global::MetaDslx.Modeling.IModelFactory CreateFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
		{
			return new MetaFactory(model, flags);
		}
	
	    public override string ToString()
	    {
	        return $"{Name} ({Version})";
	    }
	}

	public class MetaInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return MetaInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Modeling.IMetaModel MMetaModel;
		public static readonly global::MetaDslx.Modeling.ImmutableModel MModel;
	
		public static readonly MetaPrimitiveType Object;
		public static readonly MetaPrimitiveType String;
		public static readonly MetaPrimitiveType Int;
		public static readonly MetaPrimitiveType Long;
		public static readonly MetaPrimitiveType Float;
		public static readonly MetaPrimitiveType Double;
		public static readonly MetaPrimitiveType Byte;
		public static readonly MetaPrimitiveType Bool;
		public static readonly MetaPrimitiveType Void;
		public static readonly MetaPrimitiveType SystemType;
		public static readonly MetaPrimitiveType ModelObject;
	
		///
		///	Represents an element.
		///	
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
		public static readonly MetaProperty MetaDeclaration_FullName;
		public static readonly MetaClass MetaNamespace;
		public static readonly MetaProperty MetaNamespace_DefinedMetaModel;
		public static readonly MetaProperty MetaNamespace_Declarations;
		public static readonly MetaClass MetaModel;
		public static readonly MetaProperty MetaModel_Uri;
		public static readonly MetaProperty MetaModel_Prefix;
		public static readonly MetaProperty MetaModel_Namespace;
		public static readonly MetaClass MetaCollectionType;
		public static readonly MetaProperty MetaCollectionType_Kind;
		public static readonly MetaProperty MetaCollectionType_InnerType;
		public static readonly MetaClass MetaNullableType;
		public static readonly MetaProperty MetaNullableType_InnerType;
		public static readonly MetaClass MetaPrimitiveType;
		public static readonly MetaProperty MetaPrimitiveType_DotNetName;
		public static readonly MetaClass MetaEnum;
		public static readonly MetaProperty MetaEnum_EnumLiterals;
		public static readonly MetaProperty MetaEnum_Operations;
		public static readonly MetaClass MetaEnumLiteral;
		public static readonly MetaProperty MetaEnumLiteral_Enum;
		public static readonly MetaClass MetaConstant;
		public static readonly MetaProperty MetaConstant_DotNetName;
		public static readonly MetaProperty MetaConstant_Value;
		public static readonly MetaClass MetaClass;
		public static readonly MetaProperty MetaClass_SymbolType;
		public static readonly MetaProperty MetaClass_IsAbstract;
		public static readonly MetaProperty MetaClass_SuperClasses;
		public static readonly MetaProperty MetaClass_Properties;
		public static readonly MetaProperty MetaClass_Operations;
		public static readonly MetaClass MetaOperation;
		public static readonly MetaProperty MetaOperation_Class;
		public static readonly MetaProperty MetaOperation_Enum;
		public static readonly MetaProperty MetaOperation_IsBuilder;
		public static readonly MetaProperty MetaOperation_IsReadonly;
		public static readonly MetaProperty MetaOperation_Parameters;
		public static readonly MetaProperty MetaOperation_ReturnType;
		public static readonly MetaClass MetaParameter;
		public static readonly MetaProperty MetaParameter_Operation;
		public static readonly MetaClass MetaProperty;
		public static readonly MetaProperty MetaProperty_SymbolProperty;
		public static readonly MetaProperty MetaProperty_Kind;
		public static readonly MetaProperty MetaProperty_Class;
		public static readonly MetaProperty MetaProperty_DefaultValue;
		public static readonly MetaProperty MetaProperty_IsContainment;
		public static readonly MetaProperty MetaProperty_OppositeProperties;
		public static readonly MetaProperty MetaProperty_SubsettedProperties;
		public static readonly MetaProperty MetaProperty_SubsettingProperties;
		public static readonly MetaProperty MetaProperty_RedefinedProperties;
		public static readonly MetaProperty MetaProperty_RedefiningProperties;
	
		static MetaInstance()
		{
			MetaBuilderInstance.instance.Create();
			MetaBuilderInstance.instance.EvaluateLazyValues();
			MMetaModel = new MetaMetaModel();
			MModel = MetaBuilderInstance.instance.MModel.ToImmutable();
	
			Object = MetaBuilderInstance.instance.Object.ToImmutable(MModel);
			String = MetaBuilderInstance.instance.String.ToImmutable(MModel);
			Int = MetaBuilderInstance.instance.Int.ToImmutable(MModel);
			Long = MetaBuilderInstance.instance.Long.ToImmutable(MModel);
			Float = MetaBuilderInstance.instance.Float.ToImmutable(MModel);
			Double = MetaBuilderInstance.instance.Double.ToImmutable(MModel);
			Byte = MetaBuilderInstance.instance.Byte.ToImmutable(MModel);
			Bool = MetaBuilderInstance.instance.Bool.ToImmutable(MModel);
			Void = MetaBuilderInstance.instance.Void.ToImmutable(MModel);
			SystemType = MetaBuilderInstance.instance.SystemType.ToImmutable(MModel);
			ModelObject = MetaBuilderInstance.instance.ModelObject.ToImmutable(MModel);
	
			MetaElement = MetaBuilderInstance.instance.MetaElement.ToImmutable(MModel);
			MetaElement_Attributes = MetaBuilderInstance.instance.MetaElement_Attributes.ToImmutable(MModel);
			MetaDocumentedElement = MetaBuilderInstance.instance.MetaDocumentedElement.ToImmutable(MModel);
			MetaDocumentedElement_Documentation = MetaBuilderInstance.instance.MetaDocumentedElement_Documentation.ToImmutable(MModel);
			MetaNamedElement = MetaBuilderInstance.instance.MetaNamedElement.ToImmutable(MModel);
			MetaNamedElement_Name = MetaBuilderInstance.instance.MetaNamedElement_Name.ToImmutable(MModel);
			MetaTypedElement = MetaBuilderInstance.instance.MetaTypedElement.ToImmutable(MModel);
			MetaTypedElement_Type = MetaBuilderInstance.instance.MetaTypedElement_Type.ToImmutable(MModel);
			MetaType = MetaBuilderInstance.instance.MetaType.ToImmutable(MModel);
			MetaNamedType = MetaBuilderInstance.instance.MetaNamedType.ToImmutable(MModel);
			MetaAttribute = MetaBuilderInstance.instance.MetaAttribute.ToImmutable(MModel);
			MetaDeclaration = MetaBuilderInstance.instance.MetaDeclaration.ToImmutable(MModel);
			MetaDeclaration_Namespace = MetaBuilderInstance.instance.MetaDeclaration_Namespace.ToImmutable(MModel);
			MetaDeclaration_MetaModel = MetaBuilderInstance.instance.MetaDeclaration_MetaModel.ToImmutable(MModel);
			MetaDeclaration_FullName = MetaBuilderInstance.instance.MetaDeclaration_FullName.ToImmutable(MModel);
			MetaNamespace = MetaBuilderInstance.instance.MetaNamespace.ToImmutable(MModel);
			MetaNamespace_DefinedMetaModel = MetaBuilderInstance.instance.MetaNamespace_DefinedMetaModel.ToImmutable(MModel);
			MetaNamespace_Declarations = MetaBuilderInstance.instance.MetaNamespace_Declarations.ToImmutable(MModel);
			MetaModel = MetaBuilderInstance.instance.MetaModel.ToImmutable(MModel);
			MetaModel_Uri = MetaBuilderInstance.instance.MetaModel_Uri.ToImmutable(MModel);
			MetaModel_Prefix = MetaBuilderInstance.instance.MetaModel_Prefix.ToImmutable(MModel);
			MetaModel_Namespace = MetaBuilderInstance.instance.MetaModel_Namespace.ToImmutable(MModel);
			MetaCollectionType = MetaBuilderInstance.instance.MetaCollectionType.ToImmutable(MModel);
			MetaCollectionType_Kind = MetaBuilderInstance.instance.MetaCollectionType_Kind.ToImmutable(MModel);
			MetaCollectionType_InnerType = MetaBuilderInstance.instance.MetaCollectionType_InnerType.ToImmutable(MModel);
			MetaNullableType = MetaBuilderInstance.instance.MetaNullableType.ToImmutable(MModel);
			MetaNullableType_InnerType = MetaBuilderInstance.instance.MetaNullableType_InnerType.ToImmutable(MModel);
			MetaPrimitiveType = MetaBuilderInstance.instance.MetaPrimitiveType.ToImmutable(MModel);
			MetaPrimitiveType_DotNetName = MetaBuilderInstance.instance.MetaPrimitiveType_DotNetName.ToImmutable(MModel);
			MetaEnum = MetaBuilderInstance.instance.MetaEnum.ToImmutable(MModel);
			MetaEnum_EnumLiterals = MetaBuilderInstance.instance.MetaEnum_EnumLiterals.ToImmutable(MModel);
			MetaEnum_Operations = MetaBuilderInstance.instance.MetaEnum_Operations.ToImmutable(MModel);
			MetaEnumLiteral = MetaBuilderInstance.instance.MetaEnumLiteral.ToImmutable(MModel);
			MetaEnumLiteral_Enum = MetaBuilderInstance.instance.MetaEnumLiteral_Enum.ToImmutable(MModel);
			MetaConstant = MetaBuilderInstance.instance.MetaConstant.ToImmutable(MModel);
			MetaConstant_DotNetName = MetaBuilderInstance.instance.MetaConstant_DotNetName.ToImmutable(MModel);
			MetaConstant_Value = MetaBuilderInstance.instance.MetaConstant_Value.ToImmutable(MModel);
			MetaClass = MetaBuilderInstance.instance.MetaClass.ToImmutable(MModel);
			MetaClass_SymbolType = MetaBuilderInstance.instance.MetaClass_SymbolType.ToImmutable(MModel);
			MetaClass_IsAbstract = MetaBuilderInstance.instance.MetaClass_IsAbstract.ToImmutable(MModel);
			MetaClass_SuperClasses = MetaBuilderInstance.instance.MetaClass_SuperClasses.ToImmutable(MModel);
			MetaClass_Properties = MetaBuilderInstance.instance.MetaClass_Properties.ToImmutable(MModel);
			MetaClass_Operations = MetaBuilderInstance.instance.MetaClass_Operations.ToImmutable(MModel);
			MetaOperation = MetaBuilderInstance.instance.MetaOperation.ToImmutable(MModel);
			MetaOperation_Class = MetaBuilderInstance.instance.MetaOperation_Class.ToImmutable(MModel);
			MetaOperation_Enum = MetaBuilderInstance.instance.MetaOperation_Enum.ToImmutable(MModel);
			MetaOperation_IsBuilder = MetaBuilderInstance.instance.MetaOperation_IsBuilder.ToImmutable(MModel);
			MetaOperation_IsReadonly = MetaBuilderInstance.instance.MetaOperation_IsReadonly.ToImmutable(MModel);
			MetaOperation_Parameters = MetaBuilderInstance.instance.MetaOperation_Parameters.ToImmutable(MModel);
			MetaOperation_ReturnType = MetaBuilderInstance.instance.MetaOperation_ReturnType.ToImmutable(MModel);
			MetaParameter = MetaBuilderInstance.instance.MetaParameter.ToImmutable(MModel);
			MetaParameter_Operation = MetaBuilderInstance.instance.MetaParameter_Operation.ToImmutable(MModel);
			MetaProperty = MetaBuilderInstance.instance.MetaProperty.ToImmutable(MModel);
			MetaProperty_SymbolProperty = MetaBuilderInstance.instance.MetaProperty_SymbolProperty.ToImmutable(MModel);
			MetaProperty_Kind = MetaBuilderInstance.instance.MetaProperty_Kind.ToImmutable(MModel);
			MetaProperty_Class = MetaBuilderInstance.instance.MetaProperty_Class.ToImmutable(MModel);
			MetaProperty_DefaultValue = MetaBuilderInstance.instance.MetaProperty_DefaultValue.ToImmutable(MModel);
			MetaProperty_IsContainment = MetaBuilderInstance.instance.MetaProperty_IsContainment.ToImmutable(MModel);
			MetaProperty_OppositeProperties = MetaBuilderInstance.instance.MetaProperty_OppositeProperties.ToImmutable(MModel);
			MetaProperty_SubsettedProperties = MetaBuilderInstance.instance.MetaProperty_SubsettedProperties.ToImmutable(MModel);
			MetaProperty_SubsettingProperties = MetaBuilderInstance.instance.MetaProperty_SubsettingProperties.ToImmutable(MModel);
			MetaProperty_RedefinedProperties = MetaBuilderInstance.instance.MetaProperty_RedefinedProperties.ToImmutable(MModel);
			MetaProperty_RedefiningProperties = MetaBuilderInstance.instance.MetaProperty_RedefiningProperties.ToImmutable(MModel);
	
			MetaInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class MetaFactory : global::MetaDslx.Modeling.ModelFactoryBase
	{
		public MetaFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
			: base(model, flags)
		{
			MetaDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel => global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel;
	
		public override global::MetaDslx.Modeling.MutableObject Create(string type)
		{
			switch (type)
			{
				case "MetaNamedType": return this.MetaNamedType();
				case "MetaAttribute": return this.MetaAttribute();
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
					throw new global::MetaDslx.Modeling.ModelException(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of MetaNamedType.
		/// </summary>
		public MetaNamedTypeBuilder MetaNamedType()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaNamedTypeId());
			return (MetaNamedTypeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaAttribute.
		/// </summary>
		public MetaAttributeBuilder MetaAttribute()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaAttributeId());
			return (MetaAttributeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNamespace.
		/// </summary>
		public MetaNamespaceBuilder MetaNamespace()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaNamespaceId());
			return (MetaNamespaceBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaModel.
		/// </summary>
		public MetaModelBuilder MetaModel()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaModelId());
			return (MetaModelBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaCollectionType.
		/// </summary>
		public MetaCollectionTypeBuilder MetaCollectionType()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaCollectionTypeId());
			return (MetaCollectionTypeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNullableType.
		/// </summary>
		public MetaNullableTypeBuilder MetaNullableType()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaNullableTypeId());
			return (MetaNullableTypeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaPrimitiveType.
		/// </summary>
		public MetaPrimitiveTypeBuilder MetaPrimitiveType()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaPrimitiveTypeId());
			return (MetaPrimitiveTypeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaEnum.
		/// </summary>
		public MetaEnumBuilder MetaEnum()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaEnumId());
			return (MetaEnumBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaEnumLiteral.
		/// </summary>
		public MetaEnumLiteralBuilder MetaEnumLiteral()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaEnumLiteralId());
			return (MetaEnumLiteralBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaConstant.
		/// </summary>
		public MetaConstantBuilder MetaConstant()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaConstantId());
			return (MetaConstantBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaClass.
		/// </summary>
		public MetaClassBuilder MetaClass()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaClassId());
			return (MetaClassBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaOperation.
		/// </summary>
		public MetaOperationBuilder MetaOperation()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaOperationId());
			return (MetaOperationBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaParameter.
		/// </summary>
		public MetaParameterBuilder MetaParameter()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaParameterId());
			return (MetaParameterBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaProperty.
		/// </summary>
		public MetaPropertyBuilder MetaProperty()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaPropertyId());
			return (MetaPropertyBuilder)obj;
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
		DerivedUnion
	}
	
	public static class MetaPropertyKindExtensions
	{
	}
	
	///
	///	Represents an element.
	///	
	public interface MetaElement : global::MetaDslx.Modeling.ImmutableObject
	{
		global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaElement"/> object to a builder <see cref="MetaElementBuilder"/> object.
		/// </summary>
		new MetaElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaElement"/> object to a builder <see cref="MetaElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	///
	///	Represents an element.
	///	
	public interface MetaElementBuilder : global::MetaDslx.Modeling.MutableObject
	{
		global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaElementBuilder"/> object to an immutable <see cref="MetaElement"/> object.
		/// </summary>
		new MetaElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaElementBuilder"/> object to an immutable <see cref="MetaElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaDocumentedElement : MetaElement
	{
		String Documentation { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaDocumentedElement"/> object to a builder <see cref="MetaDocumentedElementBuilder"/> object.
		/// </summary>
		new MetaDocumentedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaDocumentedElement"/> object to a builder <see cref="MetaDocumentedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaDocumentedElementBuilder : MetaElementBuilder
	{
		String Documentation { get; set; }
		void SetDocumentationLazy(global::System.Func<String> lazy);
		void SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy);
		void SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="MetaDocumentedElementBuilder"/> object to an immutable <see cref="MetaDocumentedElement"/> object.
		/// </summary>
		new MetaDocumentedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaDocumentedElementBuilder"/> object to an immutable <see cref="MetaDocumentedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaDocumentedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaNamedElement : MetaDocumentedElement
	{
		String Name { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaNamedElement"/> object to a builder <see cref="MetaNamedElementBuilder"/> object.
		/// </summary>
		new MetaNamedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaNamedElement"/> object to a builder <see cref="MetaNamedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaNamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaNamedElementBuilder : MetaDocumentedElementBuilder
	{
		String Name { get; set; }
		void SetNameLazy(global::System.Func<String> lazy);
		void SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy);
		void SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="MetaNamedElementBuilder"/> object to an immutable <see cref="MetaNamedElement"/> object.
		/// </summary>
		new MetaNamedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaNamedElementBuilder"/> object to an immutable <see cref="MetaNamedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaNamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaTypedElement : MetaElement
	{
		MetaType Type { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaTypedElement"/> object to a builder <see cref="MetaTypedElementBuilder"/> object.
		/// </summary>
		new MetaTypedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaTypedElement"/> object to a builder <see cref="MetaTypedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaTypedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaTypedElementBuilder : MetaElementBuilder
	{
		MetaTypeBuilder Type { get; set; }
		void SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy);
		void SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy);
		void SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="MetaTypedElementBuilder"/> object to an immutable <see cref="MetaTypedElement"/> object.
		/// </summary>
		new MetaTypedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaTypedElementBuilder"/> object to an immutable <see cref="MetaTypedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaTypedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaType : global::MetaDslx.Modeling.ImmutableObject
	{
	
		bool ConformsTo(MetaType type);
	
		/// <summary>
		/// Convert the <see cref="MetaType"/> object to a builder <see cref="MetaTypeBuilder"/> object.
		/// </summary>
		new MetaTypeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaType"/> object to a builder <see cref="MetaTypeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaTypeBuilder : global::MetaDslx.Modeling.MutableObject
	{
	
		bool ConformsTo(MetaTypeBuilder type);
	
		/// <summary>
		/// Convert the <see cref="MetaTypeBuilder"/> object to an immutable <see cref="MetaType"/> object.
		/// </summary>
		new MetaType ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaTypeBuilder"/> object to an immutable <see cref="MetaType"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaNamedType : MetaType, MetaDeclaration
	{
	
	
		/// <summary>
		/// Convert the <see cref="MetaNamedType"/> object to a builder <see cref="MetaNamedTypeBuilder"/> object.
		/// </summary>
		new MetaNamedTypeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaNamedType"/> object to a builder <see cref="MetaNamedTypeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaNamedTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaNamedTypeBuilder : MetaTypeBuilder, MetaDeclarationBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="MetaNamedTypeBuilder"/> object to an immutable <see cref="MetaNamedType"/> object.
		/// </summary>
		new MetaNamedType ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaNamedTypeBuilder"/> object to an immutable <see cref="MetaNamedType"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaNamedType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaAttribute : MetaNamedType
	{
	
	
		/// <summary>
		/// Convert the <see cref="MetaAttribute"/> object to a builder <see cref="MetaAttributeBuilder"/> object.
		/// </summary>
		new MetaAttributeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaAttribute"/> object to a builder <see cref="MetaAttributeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaAttributeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaAttributeBuilder : MetaNamedTypeBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="MetaAttributeBuilder"/> object to an immutable <see cref="MetaAttribute"/> object.
		/// </summary>
		new MetaAttribute ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaAttributeBuilder"/> object to an immutable <see cref="MetaAttribute"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaAttribute ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaDeclaration : MetaNamedElement
	{
		MetaNamespace Namespace { get; }
		MetaModel MetaModel { get; }
		String FullName { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaDeclaration"/> object to a builder <see cref="MetaDeclarationBuilder"/> object.
		/// </summary>
		new MetaDeclarationBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaDeclaration"/> object to a builder <see cref="MetaDeclarationBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaDeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaDeclarationBuilder : MetaNamedElementBuilder
	{
		MetaNamespaceBuilder Namespace { get; set; }
		void SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy);
		void SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy);
		void SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy);
		MetaModelBuilder MetaModel { get; }
		void SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy);
		void SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy);
		void SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy);
		String FullName { get; }
		void SetFullNameLazy(global::System.Func<String> lazy);
		void SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy);
		void SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="MetaDeclarationBuilder"/> object to an immutable <see cref="MetaDeclaration"/> object.
		/// </summary>
		new MetaDeclaration ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaDeclarationBuilder"/> object to an immutable <see cref="MetaDeclaration"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaDeclaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaNamespace : MetaDeclaration
	{
		MetaModel DefinedMetaModel { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaDeclaration> Declarations { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaNamespace"/> object to a builder <see cref="MetaNamespaceBuilder"/> object.
		/// </summary>
		new MetaNamespaceBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaNamespace"/> object to a builder <see cref="MetaNamespaceBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaNamespaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaNamespaceBuilder : MetaDeclarationBuilder
	{
		MetaModelBuilder DefinedMetaModel { get; set; }
		void SetDefinedMetaModelLazy(global::System.Func<MetaModelBuilder> lazy);
		void SetDefinedMetaModelLazy(global::System.Func<MetaNamespaceBuilder, MetaModelBuilder> lazy);
		void SetDefinedMetaModelLazy(global::System.Func<MetaNamespace, MetaModel> immutableLazy, global::System.Func<MetaNamespaceBuilder, MetaModelBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<MetaDeclarationBuilder> Declarations { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaNamespaceBuilder"/> object to an immutable <see cref="MetaNamespace"/> object.
		/// </summary>
		new MetaNamespace ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaNamespaceBuilder"/> object to an immutable <see cref="MetaNamespace"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaNamespace ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaModel : MetaNamedElement, global::MetaDslx.Modeling.IMetaModel
	{
		/// <summary>
		/// The name of the metamodel.
		/// </summary>
		new string Name { get; }
		new String Uri { get; }
		new String Prefix { get; }
		new MetaNamespace Namespace { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaModel"/> object to a builder <see cref="MetaModelBuilder"/> object.
		/// </summary>
		new MetaModelBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaModel"/> object to a builder <see cref="MetaModelBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaModelBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaModelBuilder : MetaNamedElementBuilder, global::MetaDslx.Modeling.IMetaModel
	{
		/// <summary>
		/// The name of the metamodel.
		/// </summary>
		new string Name { get; set; }
		new String Uri { get; set; }
		void SetUriLazy(global::System.Func<String> lazy);
		void SetUriLazy(global::System.Func<MetaModelBuilder, String> lazy);
		void SetUriLazy(global::System.Func<MetaModel, String> immutableLazy, global::System.Func<MetaModelBuilder, String> mutableLazy);
		new String Prefix { get; set; }
		void SetPrefixLazy(global::System.Func<String> lazy);
		void SetPrefixLazy(global::System.Func<MetaModelBuilder, String> lazy);
		void SetPrefixLazy(global::System.Func<MetaModel, String> immutableLazy, global::System.Func<MetaModelBuilder, String> mutableLazy);
		new MetaNamespaceBuilder Namespace { get; set; }
		void SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy);
		void SetNamespaceLazy(global::System.Func<MetaModelBuilder, MetaNamespaceBuilder> lazy);
		void SetNamespaceLazy(global::System.Func<MetaModel, MetaNamespace> immutableLazy, global::System.Func<MetaModelBuilder, MetaNamespaceBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="MetaModelBuilder"/> object to an immutable <see cref="MetaModel"/> object.
		/// </summary>
		new MetaModel ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaModelBuilder"/> object to an immutable <see cref="MetaModel"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaModel ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaCollectionType : MetaType
	{
		MetaCollectionKind Kind { get; }
		MetaType InnerType { get; }
	
		bool ConformsTo(MetaType type);
	
		/// <summary>
		/// Convert the <see cref="MetaCollectionType"/> object to a builder <see cref="MetaCollectionTypeBuilder"/> object.
		/// </summary>
		new MetaCollectionTypeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaCollectionType"/> object to a builder <see cref="MetaCollectionTypeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaCollectionTypeBuilder : MetaTypeBuilder
	{
		MetaCollectionKind Kind { get; set; }
		void SetKindLazy(global::System.Func<MetaCollectionKind> lazy);
		void SetKindLazy(global::System.Func<MetaCollectionTypeBuilder, MetaCollectionKind> lazy);
		void SetKindLazy(global::System.Func<MetaCollectionType, MetaCollectionKind> immutableLazy, global::System.Func<MetaCollectionTypeBuilder, MetaCollectionKind> mutableLazy);
		MetaTypeBuilder InnerType { get; set; }
		void SetInnerTypeLazy(global::System.Func<MetaTypeBuilder> lazy);
		void SetInnerTypeLazy(global::System.Func<MetaCollectionTypeBuilder, MetaTypeBuilder> lazy);
		void SetInnerTypeLazy(global::System.Func<MetaCollectionType, MetaType> immutableLazy, global::System.Func<MetaCollectionTypeBuilder, MetaTypeBuilder> mutableLazy);
	
		bool ConformsTo(MetaTypeBuilder type);
	
		/// <summary>
		/// Convert the <see cref="MetaCollectionTypeBuilder"/> object to an immutable <see cref="MetaCollectionType"/> object.
		/// </summary>
		new MetaCollectionType ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaCollectionTypeBuilder"/> object to an immutable <see cref="MetaCollectionType"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaCollectionType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaNullableType : MetaType
	{
		MetaType InnerType { get; }
	
		bool ConformsTo(MetaType type);
	
		/// <summary>
		/// Convert the <see cref="MetaNullableType"/> object to a builder <see cref="MetaNullableTypeBuilder"/> object.
		/// </summary>
		new MetaNullableTypeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaNullableType"/> object to a builder <see cref="MetaNullableTypeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaNullableTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaNullableTypeBuilder : MetaTypeBuilder
	{
		MetaTypeBuilder InnerType { get; set; }
		void SetInnerTypeLazy(global::System.Func<MetaTypeBuilder> lazy);
		void SetInnerTypeLazy(global::System.Func<MetaNullableTypeBuilder, MetaTypeBuilder> lazy);
		void SetInnerTypeLazy(global::System.Func<MetaNullableType, MetaType> immutableLazy, global::System.Func<MetaNullableTypeBuilder, MetaTypeBuilder> mutableLazy);
	
		bool ConformsTo(MetaTypeBuilder type);
	
		/// <summary>
		/// Convert the <see cref="MetaNullableTypeBuilder"/> object to an immutable <see cref="MetaNullableType"/> object.
		/// </summary>
		new MetaNullableType ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaNullableTypeBuilder"/> object to an immutable <see cref="MetaNullableType"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaNullableType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaPrimitiveType : MetaNamedType
	{
		String DotNetName { get; }
	
		bool ConformsTo(MetaType type);
	
		/// <summary>
		/// Convert the <see cref="MetaPrimitiveType"/> object to a builder <see cref="MetaPrimitiveTypeBuilder"/> object.
		/// </summary>
		new MetaPrimitiveTypeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaPrimitiveType"/> object to a builder <see cref="MetaPrimitiveTypeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaPrimitiveTypeBuilder : MetaNamedTypeBuilder
	{
		String DotNetName { get; set; }
		void SetDotNetNameLazy(global::System.Func<String> lazy);
		void SetDotNetNameLazy(global::System.Func<MetaPrimitiveTypeBuilder, String> lazy);
		void SetDotNetNameLazy(global::System.Func<MetaPrimitiveType, String> immutableLazy, global::System.Func<MetaPrimitiveTypeBuilder, String> mutableLazy);
	
		bool ConformsTo(MetaTypeBuilder type);
	
		/// <summary>
		/// Convert the <see cref="MetaPrimitiveTypeBuilder"/> object to an immutable <see cref="MetaPrimitiveType"/> object.
		/// </summary>
		new MetaPrimitiveType ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaPrimitiveTypeBuilder"/> object to an immutable <see cref="MetaPrimitiveType"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaPrimitiveType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaEnum : MetaNamedType
	{
		global::MetaDslx.Modeling.ImmutableModelList<MetaEnumLiteral> EnumLiterals { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaEnum"/> object to a builder <see cref="MetaEnumBuilder"/> object.
		/// </summary>
		new MetaEnumBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaEnum"/> object to a builder <see cref="MetaEnumBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaEnumBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaEnumBuilder : MetaNamedTypeBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaEnumBuilder"/> object to an immutable <see cref="MetaEnum"/> object.
		/// </summary>
		new MetaEnum ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaEnumBuilder"/> object to an immutable <see cref="MetaEnum"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaEnum ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaEnumLiteral : MetaNamedElement, MetaTypedElement
	{
		MetaEnum Enum { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaEnumLiteral"/> object to a builder <see cref="MetaEnumLiteralBuilder"/> object.
		/// </summary>
		new MetaEnumLiteralBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaEnumLiteral"/> object to a builder <see cref="MetaEnumLiteralBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaEnumLiteralBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder
	{
		MetaEnumBuilder Enum { get; set; }
		void SetEnumLazy(global::System.Func<MetaEnumBuilder> lazy);
		void SetEnumLazy(global::System.Func<MetaEnumLiteralBuilder, MetaEnumBuilder> lazy);
		void SetEnumLazy(global::System.Func<MetaEnumLiteral, MetaEnum> immutableLazy, global::System.Func<MetaEnumLiteralBuilder, MetaEnumBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="MetaEnumLiteralBuilder"/> object to an immutable <see cref="MetaEnumLiteral"/> object.
		/// </summary>
		new MetaEnumLiteral ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaEnumLiteralBuilder"/> object to an immutable <see cref="MetaEnumLiteral"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaEnumLiteral ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaConstant : MetaNamedType, MetaTypedElement
	{
		String DotNetName { get; }
		MetaDslx.Modeling.IModelObject Value { get; }
	
		bool ConformsTo(MetaType type);
	
		/// <summary>
		/// Convert the <see cref="MetaConstant"/> object to a builder <see cref="MetaConstantBuilder"/> object.
		/// </summary>
		new MetaConstantBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaConstant"/> object to a builder <see cref="MetaConstantBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaConstantBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaConstantBuilder : MetaNamedTypeBuilder, MetaTypedElementBuilder
	{
		String DotNetName { get; set; }
		void SetDotNetNameLazy(global::System.Func<String> lazy);
		void SetDotNetNameLazy(global::System.Func<MetaConstantBuilder, String> lazy);
		void SetDotNetNameLazy(global::System.Func<MetaConstant, String> immutableLazy, global::System.Func<MetaConstantBuilder, String> mutableLazy);
		MetaDslx.Modeling.IModelObject Value { get; }
		void SetValueLazy(global::System.Func<MetaDslx.Modeling.IModelObject> lazy);
		void SetValueLazy(global::System.Func<MetaConstantBuilder, MetaDslx.Modeling.IModelObject> lazy);
		void SetValueLazy(global::System.Func<MetaConstant, MetaDslx.Modeling.IModelObject> immutableLazy, global::System.Func<MetaConstantBuilder, MetaDslx.Modeling.IModelObject> mutableLazy);
	
		bool ConformsTo(MetaTypeBuilder type);
	
		/// <summary>
		/// Convert the <see cref="MetaConstantBuilder"/> object to an immutable <see cref="MetaConstant"/> object.
		/// </summary>
		new MetaConstant ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaConstantBuilder"/> object to an immutable <see cref="MetaConstant"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaConstant ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaClass : MetaNamedType
	{
		System.Type SymbolType { get; }
		bool IsAbstract { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaClass> SuperClasses { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> Properties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations { get; }
	
		bool ConformsTo(MetaType type);
		global::System.Collections.Generic.IReadOnlyList<MetaClass> GetAllSuperClasses(bool includeSelf);
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> GetAllSuperProperties(bool includeSelf);
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> GetAllSuperOperations(bool includeSelf);
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> GetAllProperties();
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> GetAllOperations();
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> GetAllFinalProperties();
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> GetAllFinalOperations();
	
		/// <summary>
		/// Convert the <see cref="MetaClass"/> object to a builder <see cref="MetaClassBuilder"/> object.
		/// </summary>
		new MetaClassBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaClass"/> object to a builder <see cref="MetaClassBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaClassBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaClassBuilder : MetaNamedTypeBuilder
	{
		System.Type SymbolType { get; set; }
		void SetSymbolTypeLazy(global::System.Func<System.Type> lazy);
		void SetSymbolTypeLazy(global::System.Func<MetaClassBuilder, System.Type> lazy);
		void SetSymbolTypeLazy(global::System.Func<MetaClass, System.Type> immutableLazy, global::System.Func<MetaClassBuilder, System.Type> mutableLazy);
		bool IsAbstract { get; set; }
		void SetIsAbstractLazy(global::System.Func<bool> lazy);
		void SetIsAbstractLazy(global::System.Func<MetaClassBuilder, bool> lazy);
		void SetIsAbstractLazy(global::System.Func<MetaClass, bool> immutableLazy, global::System.Func<MetaClassBuilder, bool> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<MetaClassBuilder> SuperClasses { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> Properties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations { get; }
	
		bool ConformsTo(MetaTypeBuilder type);
		global::System.Collections.Generic.IReadOnlyList<MetaClassBuilder> GetAllSuperClasses(bool includeSelf);
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> GetAllSuperProperties(bool includeSelf);
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> GetAllSuperOperations(bool includeSelf);
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> GetAllProperties();
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> GetAllOperations();
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> GetAllFinalProperties();
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> GetAllFinalOperations();
	
		/// <summary>
		/// Convert the <see cref="MetaClassBuilder"/> object to an immutable <see cref="MetaClass"/> object.
		/// </summary>
		new MetaClass ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaClassBuilder"/> object to an immutable <see cref="MetaClass"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaClass ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaOperation : MetaNamedElement
	{
		MetaClass Class { get; }
		MetaEnum Enum { get; }
		bool IsBuilder { get; }
		bool IsReadonly { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaParameter> Parameters { get; }
		MetaType ReturnType { get; }
	
		bool ConformsTo(MetaOperation operation);
	
		/// <summary>
		/// Convert the <see cref="MetaOperation"/> object to a builder <see cref="MetaOperationBuilder"/> object.
		/// </summary>
		new MetaOperationBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaOperation"/> object to a builder <see cref="MetaOperationBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaOperationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaOperationBuilder : MetaNamedElementBuilder
	{
		MetaClassBuilder Class { get; set; }
		void SetClassLazy(global::System.Func<MetaClassBuilder> lazy);
		void SetClassLazy(global::System.Func<MetaOperationBuilder, MetaClassBuilder> lazy);
		void SetClassLazy(global::System.Func<MetaOperation, MetaClass> immutableLazy, global::System.Func<MetaOperationBuilder, MetaClassBuilder> mutableLazy);
		MetaEnumBuilder Enum { get; set; }
		void SetEnumLazy(global::System.Func<MetaEnumBuilder> lazy);
		void SetEnumLazy(global::System.Func<MetaOperationBuilder, MetaEnumBuilder> lazy);
		void SetEnumLazy(global::System.Func<MetaOperation, MetaEnum> immutableLazy, global::System.Func<MetaOperationBuilder, MetaEnumBuilder> mutableLazy);
		bool IsBuilder { get; set; }
		void SetIsBuilderLazy(global::System.Func<bool> lazy);
		void SetIsBuilderLazy(global::System.Func<MetaOperationBuilder, bool> lazy);
		void SetIsBuilderLazy(global::System.Func<MetaOperation, bool> immutableLazy, global::System.Func<MetaOperationBuilder, bool> mutableLazy);
		bool IsReadonly { get; set; }
		void SetIsReadonlyLazy(global::System.Func<bool> lazy);
		void SetIsReadonlyLazy(global::System.Func<MetaOperationBuilder, bool> lazy);
		void SetIsReadonlyLazy(global::System.Func<MetaOperation, bool> immutableLazy, global::System.Func<MetaOperationBuilder, bool> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<MetaParameterBuilder> Parameters { get; }
		MetaTypeBuilder ReturnType { get; set; }
		void SetReturnTypeLazy(global::System.Func<MetaTypeBuilder> lazy);
		void SetReturnTypeLazy(global::System.Func<MetaOperationBuilder, MetaTypeBuilder> lazy);
		void SetReturnTypeLazy(global::System.Func<MetaOperation, MetaType> immutableLazy, global::System.Func<MetaOperationBuilder, MetaTypeBuilder> mutableLazy);
	
		bool ConformsTo(MetaOperationBuilder operation);
	
		/// <summary>
		/// Convert the <see cref="MetaOperationBuilder"/> object to an immutable <see cref="MetaOperation"/> object.
		/// </summary>
		new MetaOperation ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaOperationBuilder"/> object to an immutable <see cref="MetaOperation"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaOperation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaParameter : MetaNamedElement, MetaTypedElement
	{
		MetaOperation Operation { get; }
	
	
		/// <summary>
		/// Convert the <see cref="MetaParameter"/> object to a builder <see cref="MetaParameterBuilder"/> object.
		/// </summary>
		new MetaParameterBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaParameter"/> object to a builder <see cref="MetaParameterBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaParameterBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder
	{
		MetaOperationBuilder Operation { get; set; }
		void SetOperationLazy(global::System.Func<MetaOperationBuilder> lazy);
		void SetOperationLazy(global::System.Func<MetaParameterBuilder, MetaOperationBuilder> lazy);
		void SetOperationLazy(global::System.Func<MetaParameter, MetaOperation> immutableLazy, global::System.Func<MetaParameterBuilder, MetaOperationBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="MetaParameterBuilder"/> object to an immutable <see cref="MetaParameter"/> object.
		/// </summary>
		new MetaParameter ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaParameterBuilder"/> object to an immutable <see cref="MetaParameter"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new MetaParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MetaProperty : MetaNamedElement, MetaTypedElement
	{
		String SymbolProperty { get; }
		MetaPropertyKind Kind { get; }
		MetaClass Class { get; }
		String DefaultValue { get; }
		bool IsContainment { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> OppositeProperties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettedProperties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettingProperties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefinedProperties { get; }
		global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefiningProperties { get; }
	
		bool ConformsTo(MetaProperty property);
	
		/// <summary>
		/// Convert the <see cref="MetaProperty"/> object to a builder <see cref="MetaPropertyBuilder"/> object.
		/// </summary>
		new MetaPropertyBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="MetaProperty"/> object to a builder <see cref="MetaPropertyBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new MetaPropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MetaPropertyBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder
	{
		String SymbolProperty { get; set; }
		void SetSymbolPropertyLazy(global::System.Func<String> lazy);
		void SetSymbolPropertyLazy(global::System.Func<MetaPropertyBuilder, String> lazy);
		void SetSymbolPropertyLazy(global::System.Func<MetaProperty, String> immutableLazy, global::System.Func<MetaPropertyBuilder, String> mutableLazy);
		MetaPropertyKind Kind { get; set; }
		void SetKindLazy(global::System.Func<MetaPropertyKind> lazy);
		void SetKindLazy(global::System.Func<MetaPropertyBuilder, MetaPropertyKind> lazy);
		void SetKindLazy(global::System.Func<MetaProperty, MetaPropertyKind> immutableLazy, global::System.Func<MetaPropertyBuilder, MetaPropertyKind> mutableLazy);
		MetaClassBuilder Class { get; set; }
		void SetClassLazy(global::System.Func<MetaClassBuilder> lazy);
		void SetClassLazy(global::System.Func<MetaPropertyBuilder, MetaClassBuilder> lazy);
		void SetClassLazy(global::System.Func<MetaProperty, MetaClass> immutableLazy, global::System.Func<MetaPropertyBuilder, MetaClassBuilder> mutableLazy);
		String DefaultValue { get; set; }
		void SetDefaultValueLazy(global::System.Func<String> lazy);
		void SetDefaultValueLazy(global::System.Func<MetaPropertyBuilder, String> lazy);
		void SetDefaultValueLazy(global::System.Func<MetaProperty, String> immutableLazy, global::System.Func<MetaPropertyBuilder, String> mutableLazy);
		bool IsContainment { get; set; }
		void SetIsContainmentLazy(global::System.Func<bool> lazy);
		void SetIsContainmentLazy(global::System.Func<MetaPropertyBuilder, bool> lazy);
		void SetIsContainmentLazy(global::System.Func<MetaProperty, bool> immutableLazy, global::System.Func<MetaPropertyBuilder, bool> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> OppositeProperties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettedProperties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettingProperties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefinedProperties { get; }
		global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefiningProperties { get; }
	
		bool ConformsTo(MetaPropertyBuilder property);
	
		/// <summary>
		/// Convert the <see cref="MetaPropertyBuilder"/> object to an immutable <see cref="MetaProperty"/> object.
		/// </summary>
		new MetaProperty ToImmutable();
		/// <summary>
		/// Convert the <see cref="MetaPropertyBuilder"/> object to an immutable <see cref="MetaProperty"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
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
			properties.Add(MetaDescriptor.MetaDeclaration.FullNameProperty);
			properties.Add(MetaDescriptor.MetaNamespace.DefinedMetaModelProperty);
			properties.Add(MetaDescriptor.MetaNamespace.DeclarationsProperty);
			properties.Add(MetaDescriptor.MetaModel.UriProperty);
			properties.Add(MetaDescriptor.MetaModel.PrefixProperty);
			properties.Add(MetaDescriptor.MetaModel.NamespaceProperty);
			properties.Add(MetaDescriptor.MetaCollectionType.KindProperty);
			properties.Add(MetaDescriptor.MetaCollectionType.InnerTypeProperty);
			properties.Add(MetaDescriptor.MetaNullableType.InnerTypeProperty);
			properties.Add(MetaDescriptor.MetaPrimitiveType.DotNetNameProperty);
			properties.Add(MetaDescriptor.MetaEnum.EnumLiteralsProperty);
			properties.Add(MetaDescriptor.MetaEnum.OperationsProperty);
			properties.Add(MetaDescriptor.MetaEnumLiteral.EnumProperty);
			properties.Add(MetaDescriptor.MetaConstant.DotNetNameProperty);
			properties.Add(MetaDescriptor.MetaConstant.ValueProperty);
			properties.Add(MetaDescriptor.MetaClass.SymbolTypeProperty);
			properties.Add(MetaDescriptor.MetaClass.IsAbstractProperty);
			properties.Add(MetaDescriptor.MetaClass.SuperClassesProperty);
			properties.Add(MetaDescriptor.MetaClass.PropertiesProperty);
			properties.Add(MetaDescriptor.MetaClass.OperationsProperty);
			properties.Add(MetaDescriptor.MetaOperation.ClassProperty);
			properties.Add(MetaDescriptor.MetaOperation.EnumProperty);
			properties.Add(MetaDescriptor.MetaOperation.IsBuilderProperty);
			properties.Add(MetaDescriptor.MetaOperation.IsReadonlyProperty);
			properties.Add(MetaDescriptor.MetaOperation.ParametersProperty);
			properties.Add(MetaDescriptor.MetaOperation.ReturnTypeProperty);
			properties.Add(MetaDescriptor.MetaParameter.OperationProperty);
			properties.Add(MetaDescriptor.MetaProperty.SymbolPropertyProperty);
			properties.Add(MetaDescriptor.MetaProperty.KindProperty);
			properties.Add(MetaDescriptor.MetaProperty.ClassProperty);
			properties.Add(MetaDescriptor.MetaProperty.DefaultValueProperty);
			properties.Add(MetaDescriptor.MetaProperty.IsContainmentProperty);
			properties.Add(MetaDescriptor.MetaProperty.OppositePropertiesProperty);
			properties.Add(MetaDescriptor.MetaProperty.SubsettedPropertiesProperty);
			properties.Add(MetaDescriptor.MetaProperty.SubsettingPropertiesProperty);
			properties.Add(MetaDescriptor.MetaProperty.RedefinedPropertiesProperty);
			properties.Add(MetaDescriptor.MetaProperty.RedefiningPropertiesProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string MUri = "http://metadslx.core/1.0";
		public const string MPrefix = "";
	
		///
		///	Represents an element.
		///	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.Symbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaElementId), typeof(global::MetaDslx.Languages.Meta.Model.MetaElement), typeof(global::MetaDslx.Languages.Meta.Model.MetaElementBuilder))]
		public static class MetaElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaElement; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Attributes")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AttributesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaElement), name: "Attributes",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaAttribute),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaAttributeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaElement_Attributes,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaDocumentedElementId), typeof(global::MetaDslx.Languages.Meta.Model.MetaDocumentedElement), typeof(global::MetaDslx.Languages.Meta.Model.MetaDocumentedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaElement) })]
		public static class MetaDocumentedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaDocumentedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaDocumentedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaDocumentedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DocumentationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaDocumentedElement), name: "Documentation",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaDocumentedElement_Documentation,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaNamedElementId), typeof(global::MetaDslx.Languages.Meta.Model.MetaNamedElement), typeof(global::MetaDslx.Languages.Meta.Model.MetaNamedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDocumentedElement) })]
		public static class MetaNamedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaNamedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaNamedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNamedElement; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Name")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNamedElement), name: "Name",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNamedElement_Name,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaTypedElementId), typeof(global::MetaDslx.Languages.Meta.Model.MetaTypedElement), typeof(global::MetaDslx.Languages.Meta.Model.MetaTypedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaElement) })]
		public static class MetaTypedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaTypedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaTypedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaTypedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty TypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaTypedElement), name: "Type",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaTypedElement_Type,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.TypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaTypeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaType), typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder))]
		public static class MetaType
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaType()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaType; }
			}
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaNamedTypeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaNamedType), typeof(global::MetaDslx.Languages.Meta.Model.MetaNamedTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaDeclaration) })]
		public static class MetaNamedType
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaNamedType()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaNamedType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNamedType; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaAttributeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaAttribute), typeof(global::MetaDslx.Languages.Meta.Model.MetaAttributeBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedType) })]
		public static class MetaAttribute
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaAttribute()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaAttribute));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaAttribute; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaDeclarationId), typeof(global::MetaDslx.Languages.Meta.Model.MetaDeclaration), typeof(global::MetaDslx.Languages.Meta.Model.MetaDeclarationBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaDeclaration
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaDeclaration()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaDeclaration));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaDeclaration; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "Declarations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NamespaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaDeclaration), name: "Namespace",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaNamespace),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaDeclaration_Namespace,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty MetaModelProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaDeclaration), name: "MetaModel",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaModel),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaModelBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaDeclaration_MetaModel,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty FullNameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaDeclaration), name: "FullName",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaDeclaration_FullName,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamespaceSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaNamespaceId), typeof(global::MetaDslx.Languages.Meta.Model.MetaNamespace), typeof(global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration) })]
		public static class MetaNamespace
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaNamespace()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaNamespace));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNamespace; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaModel), "Namespace")]
			public static readonly global::MetaDslx.Modeling.ModelProperty DefinedMetaModelProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNamespace), name: "DefinedMetaModel",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaModel),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaModelBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNamespace_DefinedMetaModel,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaDeclaration), "Namespace")]
			public static readonly global::MetaDslx.Modeling.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNamespace), name: "Declarations",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaDeclaration),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaDeclarationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNamespace_Declarations,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaModelId), typeof(global::MetaDslx.Languages.Meta.Model.MetaModel), typeof(global::MetaDslx.Languages.Meta.Model.MetaModelBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaModel
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaModel()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaModel));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaModel; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty UriProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaModel), name: "Uri",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaModel_Uri,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty PrefixProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaModel), name: "Prefix",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaModel_Prefix,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "DefinedMetaModel")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NamespaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaModel), name: "Namespace",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaNamespace),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaModel_Namespace,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.ArrayTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaCollectionTypeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaCollectionType), typeof(global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType) })]
		public static class MetaCollectionType
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaCollectionType()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaCollectionType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaCollectionType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaCollectionType), name: "Kind",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaCollectionKind),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaCollectionKind),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaCollectionType_Kind,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("ElementType")]
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaCollectionType), name: "InnerType",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaCollectionType_InnerType,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NullableTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaNullableTypeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaNullableType), typeof(global::MetaDslx.Languages.Meta.Model.MetaNullableTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType) })]
		public static class MetaNullableType
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaNullableType()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaNullableType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNullableType; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("InnerType")]
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNullableType), name: "InnerType",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNullableType_InnerType,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaPrimitiveTypeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaPrimitiveType), typeof(global::MetaDslx.Languages.Meta.Model.MetaPrimitiveTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedType) })]
		public static class MetaPrimitiveType
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaPrimitiveType()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaPrimitiveType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaPrimitiveType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DotNetNameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaPrimitiveType), name: "DotNetName",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaPrimitiveType_DotNetName,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.EnumTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaEnumId), typeof(global::MetaDslx.Languages.Meta.Model.MetaEnum), typeof(global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedType) })]
		public static class MetaEnum
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaEnum()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaEnum));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaEnum; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaEnumLiteral), "Enum")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumLiteralsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaEnum), name: "EnumLiterals",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaEnumLiteral),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaEnum_EnumLiterals,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Enum")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaEnum), name: "Operations",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperation),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaEnum_Operations,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.EnumLiteralSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaEnumLiteralId), typeof(global::MetaDslx.Languages.Meta.Model.MetaEnumLiteral), typeof(global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaEnumLiteral
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaEnumLiteral()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaEnumLiteral));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaEnumLiteral; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "EnumLiterals")]
			[global::MetaDslx.Modeling.RedefinesAttribute(typeof(MetaDescriptor.MetaTypedElement), "Type")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaEnumLiteral), name: "Enum",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaEnum),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaEnumLiteral_Enum,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaConstantId), typeof(global::MetaDslx.Languages.Meta.Model.MetaConstant), typeof(global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedType), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaConstant
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaConstant()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaConstant));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaConstant; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DotNetNameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaConstant), name: "DotNetName",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaConstant_DotNetName,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaConstant), name: "Value",
			        immutableType: typeof(MetaDslx.Modeling.IModelObject),
			        mutableType: typeof(MetaDslx.Modeling.IModelObject),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaConstant_Value,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.ClassTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaClassId), typeof(global::MetaDslx.Languages.Meta.Model.MetaClass), typeof(global::MetaDslx.Languages.Meta.Model.MetaClassBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedType) })]
		public static class MetaClass
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaClass()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaClass));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Attributes")]
			public static readonly global::MetaDslx.Modeling.ModelProperty SymbolTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "SymbolType",
			        immutableType: typeof(System.Type),
			        mutableType: typeof(System.Type),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass_SymbolType,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "IsAbstract",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass_IsAbstract,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("BaseTypes")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty SuperClassesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "SuperClasses",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaClass),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass_SuperClasses,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "Class")]
			public static readonly global::MetaDslx.Modeling.ModelProperty PropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "Properties",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaProperty),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass_Properties,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Class")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "Operations",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperation),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass_Operations,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.MethodSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaOperationId), typeof(global::MetaDslx.Languages.Meta.Model.MetaOperation), typeof(global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaOperation
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaOperation()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaOperation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Operations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ClassProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "Class",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaClass),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation_Class,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "Operations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "Enum",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaEnum),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation_Enum,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsBuilderProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "IsBuilder",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation_IsBuilder,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsReadonlyProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "IsReadonly",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation_IsReadonly,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaParameter), "Operation")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ParametersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "Parameters",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaParameter),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation_Parameters,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("ReturnType")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "ReturnType",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation_ReturnType,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.ParameterSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaParameterId), typeof(global::MetaDslx.Languages.Meta.Model.MetaParameter), typeof(global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaParameter
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaParameter()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaParameter));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaParameter; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parameters")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaParameter), name: "Operation",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperation),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaParameter_Operation,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.PropertySymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaPropertyId), typeof(global::MetaDslx.Languages.Meta.Model.MetaProperty), typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaProperty
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static MetaProperty()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(MetaProperty));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SymbolPropertyProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "SymbolProperty",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_SymbolProperty,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "Kind",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyKind),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyKind),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_Kind,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Properties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ClassProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "Class",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaClass),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_Class,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DefaultValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "DefaultValue",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_DefaultValue,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsContainmentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "IsContainment",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_IsContainment,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "OppositeProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OppositePropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "OppositeProperties",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaProperty),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_OppositeProperties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "SubsettingProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty SubsettedPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "SubsettedProperties",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaProperty),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_SubsettedProperties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "SubsettedProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty SubsettingPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "SubsettingProperties",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaProperty),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_SubsettingProperties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "RedefiningProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty RedefinedPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "RedefinedProperties",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaProperty),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_RedefinedProperties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "RedefinedProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty RedefiningPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "RedefiningProperties",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaProperty),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaProperty_RedefiningProperties,
					defaultValue: null);
		}
	}
}

namespace MetaDslx.Languages.Meta.Model.Internal
{
	
	internal class MetaElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
	
		internal MetaElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	}
	
	internal class MetaElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaElement(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	}
	
	internal class MetaDocumentedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaDocumentedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaDocumentedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaDocumentedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaDocumentedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
	
		internal MetaDocumentedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	}
	
	internal class MetaDocumentedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaDocumentedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaDocumentedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaNamedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaNamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaNamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaNamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
	
		internal MetaNamedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class MetaNamedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaNamedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaNamedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNamedElement(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaTypedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaTypedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaTypedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaTypedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaTypedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
	
		internal MetaTypedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	}
	
	internal class MetaTypedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaTypedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaTypedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaTypedElement(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaType.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaTypeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaType
	{
	
		internal MetaTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaTypeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaTypeBuilder
	{
	
		internal MetaTypeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaType(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaNamedTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedType.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaNamedTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaNamedTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamedTypeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaNamedType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String fullName0;
	
		internal MetaNamedTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public String FullName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaNamedTypeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaNamedTypeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaNamedTypeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNamedType(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public String FullName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaAttributeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaAttribute.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaAttributeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaAttributeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaAttributeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaAttribute
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String fullName0;
	
		internal MetaAttributeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
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
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public String FullName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaAttributeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaAttributeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaAttributeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaAttribute(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public String FullName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaDeclarationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaDeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaDeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaDeclarationImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaDeclaration
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String fullName0;
	
		internal MetaDeclarationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public String FullName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	}
	
	internal class MetaDeclarationBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaDeclarationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaDeclarationBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaDeclaration(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public String FullName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaNamespaceId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamespace.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaNamespaceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaNamespaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamespaceImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaNamespace
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel definedMetaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaDeclaration> declarations0;
	
		internal MetaNamespaceImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public String FullName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public MetaModel DefinedMetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, ref definedMetaModel0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaDeclaration> Declarations
		{
		    get { return this.GetList<MetaDeclaration>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class MetaNamespaceBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaNamespaceBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaDeclarationBuilder> declarations0;
	
		internal MetaNamespaceBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNamespace(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public String FullName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder DefinedMetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamespace.DefinedMetaModelProperty); }
			set { this.SetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, value); }
		}
		
		void MetaNamespaceBuilder.SetDefinedMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, lazy);
		}
		
		void MetaNamespaceBuilder.SetDefinedMetaModelLazy(global::System.Func<MetaNamespaceBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, lazy);
		}
		
		void MetaNamespaceBuilder.SetDefinedMetaModelLazy(global::System.Func<MetaNamespace, MetaModel> immutableLazy, global::System.Func<MetaNamespaceBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaDeclarationBuilder> Declarations
		{
			get { return this.GetList<MetaDeclarationBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class MetaModelId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaModelImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaModelBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaModelImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaModel
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String uri0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String prefix0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
	
		internal MetaModelImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public String Uri
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.UriProperty, ref uri0); }
		}
	
		
		public String Prefix
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.PrefixProperty, ref prefix0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.NamespaceProperty, ref namespace0); }
		}
		global::MetaDslx.Modeling.ModelId global::MetaDslx.Modeling.IModel.Id => MetaInstance.MModel.Id;
		string global::MetaDslx.Modeling.IModel.Name => this.Name;
		global::MetaDslx.Modeling.ModelVersion global::MetaDslx.Modeling.IModel.Version => MetaInstance.MModel.Version;
		global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> global::MetaDslx.Modeling.IModel.Objects => MetaInstance.MModel.Objects;
		string global::MetaDslx.Modeling.IMetaModel.Uri => this.Uri;
		string global::MetaDslx.Modeling.IMetaModel.Prefix => this.Prefix;
		global::MetaDslx.Modeling.IModelGroup global::MetaDslx.Modeling.IModel.ModelGroup => MetaInstance.MModel.ModelGroup;
		string global::MetaDslx.Modeling.IMetaModel.Namespace => this.Namespace.FullName;
	
		public global::MetaDslx.Modeling.IModelFactory CreateFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
		{
			return new MetaFactory(model, flags);
		}
	}
	
	internal class MetaModelBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaModelBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaModelBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaModel(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Uri
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.UriProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.UriProperty, value); }
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.UriProperty, lazy);
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<MetaModelBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.UriProperty, lazy);
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<MetaModel, String> immutableLazy, global::System.Func<MetaModelBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.UriProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Prefix
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.PrefixProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.PrefixProperty, value); }
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.PrefixProperty, lazy);
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<MetaModelBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.PrefixProperty, lazy);
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<MetaModel, String> immutableLazy, global::System.Func<MetaModelBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.PrefixProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.NamespaceProperty, value); }
		}
		
		void MetaModelBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.NamespaceProperty, lazy);
		}
		
		void MetaModelBuilder.SetNamespaceLazy(global::System.Func<MetaModelBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.NamespaceProperty, lazy);
		}
		
		void MetaModelBuilder.SetNamespaceLazy(global::System.Func<MetaModel, MetaNamespace> immutableLazy, global::System.Func<MetaModelBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		global::MetaDslx.Modeling.ModelId global::MetaDslx.Modeling.IModel.Id => MetaInstance.MModel.Id;
		string global::MetaDslx.Modeling.IModel.Name => this.Name;
		global::MetaDslx.Modeling.ModelVersion global::MetaDslx.Modeling.IModel.Version => MetaInstance.MModel.Version;
		global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> global::MetaDslx.Modeling.IModel.Objects => MetaInstance.MModel.Objects;
		string global::MetaDslx.Modeling.IMetaModel.Uri => this.Uri;
		string global::MetaDslx.Modeling.IMetaModel.Prefix => this.Prefix;
		global::MetaDslx.Modeling.IModelGroup global::MetaDslx.Modeling.IModel.ModelGroup => MetaInstance.MModel.ModelGroup;
		string global::MetaDslx.Modeling.IMetaModel.Namespace => this.Namespace.FullName;
	
		public global::MetaDslx.Modeling.IModelFactory CreateFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
		{
			return new MetaFactory(model, flags);
		}
	}
	
	internal class MetaCollectionTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaCollectionType.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaCollectionTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaCollectionTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaCollectionTypeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaCollectionType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaCollectionKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType innerType0;
	
		internal MetaCollectionTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetValue<MetaCollectionKind>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaCollectionType.KindProperty, ref kind0); }
		}
	
		
		public MetaType InnerType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaCollectionType.InnerTypeProperty, ref innerType0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaCollectionType_ConformsTo(this, type);
		}
	
		
		bool MetaCollectionType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaCollectionType_ConformsTo(this, type);
		}
	}
	
	internal class MetaCollectionTypeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaCollectionTypeBuilder
	{
	
		internal MetaCollectionTypeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaCollectionType(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetValue<MetaCollectionKind>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaCollectionType.KindProperty); }
			set { this.SetValue<MetaCollectionKind>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaCollectionType.KindProperty, value); }
		}
		
		void MetaCollectionTypeBuilder.SetKindLazy(global::System.Func<MetaCollectionKind> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaCollectionType.KindProperty, lazy);
		}
		
		void MetaCollectionTypeBuilder.SetKindLazy(global::System.Func<MetaCollectionTypeBuilder, MetaCollectionKind> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaCollectionType.KindProperty, lazy);
		}
		
		void MetaCollectionTypeBuilder.SetKindLazy(global::System.Func<MetaCollectionType, MetaCollectionKind> immutableLazy, global::System.Func<MetaCollectionTypeBuilder, MetaCollectionKind> mutableLazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaCollectionType.KindProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder InnerType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaCollectionType.InnerTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaCollectionType.InnerTypeProperty, value); }
		}
		
		void MetaCollectionTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaCollectionType.InnerTypeProperty, lazy);
		}
		
		void MetaCollectionTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaCollectionTypeBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaCollectionType.InnerTypeProperty, lazy);
		}
		
		void MetaCollectionTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaCollectionType, MetaType> immutableLazy, global::System.Func<MetaCollectionTypeBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaCollectionType.InnerTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaCollectionType_ConformsTo(this, type);
		}
	
		
		bool MetaCollectionTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaCollectionType_ConformsTo(this, type);
		}
	}
	
	internal class MetaNullableTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNullableType.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaNullableTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaNullableTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNullableTypeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaNullableType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType innerType0;
	
		internal MetaNullableTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNullableType.InnerTypeProperty, ref innerType0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaNullableType_ConformsTo(this, type);
		}
	
		
		bool MetaNullableType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaNullableType_ConformsTo(this, type);
		}
	}
	
	internal class MetaNullableTypeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaNullableTypeBuilder
	{
	
		internal MetaNullableTypeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNullableType(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNullableType.InnerTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNullableType.InnerTypeProperty, value); }
		}
		
		void MetaNullableTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNullableType.InnerTypeProperty, lazy);
		}
		
		void MetaNullableTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaNullableTypeBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNullableType.InnerTypeProperty, lazy);
		}
		
		void MetaNullableTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaNullableType, MetaType> immutableLazy, global::System.Func<MetaNullableTypeBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNullableType.InnerTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaNullableType_ConformsTo(this, type);
		}
	
		
		bool MetaNullableTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaNullableType_ConformsTo(this, type);
		}
	}
	
	internal class MetaPrimitiveTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaPrimitiveType.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaPrimitiveTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaPrimitiveTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaPrimitiveTypeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaPrimitiveType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String dotNetName0;
	
		internal MetaPrimitiveTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
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
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public String FullName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public String DotNetName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaPrimitiveType.DotNetNameProperty, ref dotNetName0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaPrimitiveType_ConformsTo(this, type);
		}
	
		
		bool MetaPrimitiveType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaPrimitiveType_ConformsTo(this, type);
		}
	}
	
	internal class MetaPrimitiveTypeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaPrimitiveTypeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaPrimitiveTypeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaPrimitiveType(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public String FullName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public String DotNetName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaPrimitiveType.DotNetNameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaPrimitiveType.DotNetNameProperty, value); }
		}
		
		void MetaPrimitiveTypeBuilder.SetDotNetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaPrimitiveType.DotNetNameProperty, lazy);
		}
		
		void MetaPrimitiveTypeBuilder.SetDotNetNameLazy(global::System.Func<MetaPrimitiveTypeBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaPrimitiveType.DotNetNameProperty, lazy);
		}
		
		void MetaPrimitiveTypeBuilder.SetDotNetNameLazy(global::System.Func<MetaPrimitiveType, String> immutableLazy, global::System.Func<MetaPrimitiveTypeBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaPrimitiveType.DotNetNameProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaPrimitiveType_ConformsTo(this, type);
		}
	
		
		bool MetaPrimitiveTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaPrimitiveType_ConformsTo(this, type);
		}
	}
	
	internal class MetaEnumId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnum.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaEnumImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaEnumBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaEnumImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaEnum
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaEnumLiteral> enumLiterals0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> operations0;
	
		internal MetaEnumImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
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
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public String FullName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaEnumLiteral> EnumLiterals
		{
		    get { return this.GetList<MetaEnumLiteral>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaEnumBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaEnumBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaEnumLiteralBuilder> enumLiterals0;
		private global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> operations0;
	
		internal MetaEnumBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaEnum(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public String FullName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals
		{
			get { return this.GetList<MetaEnumLiteralBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaEnumLiteralId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnumLiteral.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaEnumLiteralImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaEnumLiteralBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaEnumLiteralImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaEnumLiteral
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaEnum enum0;
	
		internal MetaEnumLiteralImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaEnum Enum
		{
		    get { return this.GetReference<MetaEnum>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnumLiteral.EnumProperty, ref enum0); }
		}
	}
	
	internal class MetaEnumLiteralBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaEnumLiteralBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaEnumLiteralBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaEnumLiteral(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaEnumBuilder Enum
		{
			get { return this.GetReference<MetaEnumBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnumLiteral.EnumProperty); }
			set { this.SetReference<MetaEnumBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnumLiteral.EnumProperty, value); }
		}
		
		void MetaEnumLiteralBuilder.SetEnumLazy(global::System.Func<MetaEnumBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaEnumLiteral.EnumProperty, lazy);
		}
		
		void MetaEnumLiteralBuilder.SetEnumLazy(global::System.Func<MetaEnumLiteralBuilder, MetaEnumBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaEnumLiteral.EnumProperty, lazy);
		}
		
		void MetaEnumLiteralBuilder.SetEnumLazy(global::System.Func<MetaEnumLiteral, MetaEnum> immutableLazy, global::System.Func<MetaEnumLiteralBuilder, MetaEnumBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaEnumLiteral.EnumProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaConstantId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaConstantImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaConstantBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaConstantImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaConstant
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String dotNetName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaDslx.Modeling.IModelObject value0;
	
		internal MetaConstantImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
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
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
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
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public String FullName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public String DotNetName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.DotNetNameProperty, ref dotNetName0); }
		}
	
		
		public MetaDslx.Modeling.IModelObject Value
		{
		    get { return this.GetReference<MetaDslx.Modeling.IModelObject>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.ValueProperty, ref value0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaConstant_ConformsTo(this, type);
		}
	
		
		bool MetaConstant.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaConstant_ConformsTo(this, type);
		}
	}
	
	internal class MetaConstantBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaConstantBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaConstantBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaConstant(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public String FullName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public String DotNetName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.DotNetNameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.DotNetNameProperty, value); }
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.DotNetNameProperty, lazy);
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<MetaConstantBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.DotNetNameProperty, lazy);
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<MetaConstant, String> immutableLazy, global::System.Func<MetaConstantBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.DotNetNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaDslx.Modeling.IModelObject Value
		{
			get { return this.GetReference<MetaDslx.Modeling.IModelObject>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.ValueProperty); }
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<MetaDslx.Modeling.IModelObject> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.ValueProperty, lazy);
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<MetaConstantBuilder, MetaDslx.Modeling.IModelObject> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.ValueProperty, lazy);
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<MetaConstant, MetaDslx.Modeling.IModelObject> immutableLazy, global::System.Func<MetaConstantBuilder, MetaDslx.Modeling.IModelObject> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.ValueProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaConstant_ConformsTo(this, type);
		}
	
		
		bool MetaConstantBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaConstant_ConformsTo(this, type);
		}
	}
	
	internal class MetaClassId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaClassImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaClassBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaClassImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaClass
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type symbolType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaClass> superClasses0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> operations0;
	
		internal MetaClassImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
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
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedTypeBuilder MetaNamedType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public String FullName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public System.Type SymbolType
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.SymbolTypeProperty, ref symbolType0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaClass> SuperClasses
		{
		    get { return this.GetList<MetaClass>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> Properties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_ConformsTo(this, type);
		}
	
		
		bool MetaClass.ConformsTo(MetaType type)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_ConformsTo(this, type);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaClass> MetaClass.GetAllSuperClasses(bool includeSelf)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass.GetAllSuperProperties(bool includeSelf)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllSuperProperties(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass.GetAllSuperOperations(bool includeSelf)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllSuperOperations(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass.GetAllProperties()
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass.GetAllOperations()
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass.GetAllFinalProperties()
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllFinalProperties(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass.GetAllFinalOperations()
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllFinalOperations(this);
		}
	}
	
	internal class MetaClassBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaClassBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaClassBuilder> superClasses0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> properties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> operations0;
	
		internal MetaClassBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaClass(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedType MetaNamedTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public String FullName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, String> immutableLazy, global::System.Func<MetaDeclarationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public System.Type SymbolType
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.SymbolTypeProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.SymbolTypeProperty, value); }
		}
		
		void MetaClassBuilder.SetSymbolTypeLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaClass.SymbolTypeProperty, lazy);
		}
		
		void MetaClassBuilder.SetSymbolTypeLazy(global::System.Func<MetaClassBuilder, System.Type> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaClass.SymbolTypeProperty, lazy);
		}
		
		void MetaClassBuilder.SetSymbolTypeLazy(global::System.Func<MetaClass, System.Type> immutableLazy, global::System.Func<MetaClassBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaClass.SymbolTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.IsAbstractProperty, value); }
		}
		
		void MetaClassBuilder.SetIsAbstractLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaClass.IsAbstractProperty, lazy);
		}
		
		void MetaClassBuilder.SetIsAbstractLazy(global::System.Func<MetaClassBuilder, bool> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaClass.IsAbstractProperty, lazy);
		}
		
		void MetaClassBuilder.SetIsAbstractLazy(global::System.Func<MetaClass, bool> immutableLazy, global::System.Func<MetaClassBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaClass.IsAbstractProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaClassBuilder> SuperClasses
		{
			get { return this.GetList<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> Properties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_ConformsTo(this, type);
		}
	
		
		bool MetaClassBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_ConformsTo(this, type);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaClassBuilder> MetaClassBuilder.GetAllSuperClasses(bool includeSelf)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClassBuilder.GetAllSuperProperties(bool includeSelf)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllSuperProperties(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClassBuilder.GetAllSuperOperations(bool includeSelf)
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllSuperOperations(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClassBuilder.GetAllProperties()
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClassBuilder.GetAllOperations()
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClassBuilder.GetAllFinalProperties()
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllFinalProperties(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClassBuilder.GetAllFinalOperations()
		{
		    return MetaImplementationProvider.Implementation.MetaClass_GetAllFinalOperations(this);
		}
	}
	
	internal class MetaOperationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaOperationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaOperationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaOperationImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaOperation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaClass class0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaEnum enum0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isBuilder0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isReadonly0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaParameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType returnType0;
	
		internal MetaOperationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaClass Class
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ClassProperty, ref class0); }
		}
	
		
		public MetaEnum Enum
		{
		    get { return this.GetReference<MetaEnum>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.EnumProperty, ref enum0); }
		}
	
		
		public bool IsBuilder
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.IsBuilderProperty, ref isBuilder0); }
		}
	
		
		public bool IsReadonly
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.IsReadonlyProperty, ref isReadonly0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaParameter> Parameters
		{
		    get { return this.GetList<MetaParameter>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ReturnTypeProperty, ref returnType0); }
		}
	
		
		bool MetaOperation.ConformsTo(MetaOperation operation)
		{
		    return MetaImplementationProvider.Implementation.MetaOperation_ConformsTo(this, operation);
		}
	}
	
	internal class MetaOperationBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaOperationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaParameterBuilder> parameters0;
	
		internal MetaOperationBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaOperation(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaClassBuilder Class
		{
			get { return this.GetReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ClassProperty); }
			set { this.SetReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ClassProperty, value); }
		}
		
		void MetaOperationBuilder.SetClassLazy(global::System.Func<MetaClassBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ClassProperty, lazy);
		}
		
		void MetaOperationBuilder.SetClassLazy(global::System.Func<MetaOperationBuilder, MetaClassBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ClassProperty, lazy);
		}
		
		void MetaOperationBuilder.SetClassLazy(global::System.Func<MetaOperation, MetaClass> immutableLazy, global::System.Func<MetaOperationBuilder, MetaClassBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaEnumBuilder Enum
		{
			get { return this.GetReference<MetaEnumBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.EnumProperty); }
			set { this.SetReference<MetaEnumBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.EnumProperty, value); }
		}
		
		void MetaOperationBuilder.SetEnumLazy(global::System.Func<MetaEnumBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.EnumProperty, lazy);
		}
		
		void MetaOperationBuilder.SetEnumLazy(global::System.Func<MetaOperationBuilder, MetaEnumBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.EnumProperty, lazy);
		}
		
		void MetaOperationBuilder.SetEnumLazy(global::System.Func<MetaOperation, MetaEnum> immutableLazy, global::System.Func<MetaOperationBuilder, MetaEnumBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.EnumProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsBuilder
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.IsBuilderProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.IsBuilderProperty, value); }
		}
		
		void MetaOperationBuilder.SetIsBuilderLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaOperation.IsBuilderProperty, lazy);
		}
		
		void MetaOperationBuilder.SetIsBuilderLazy(global::System.Func<MetaOperationBuilder, bool> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaOperation.IsBuilderProperty, lazy);
		}
		
		void MetaOperationBuilder.SetIsBuilderLazy(global::System.Func<MetaOperation, bool> immutableLazy, global::System.Func<MetaOperationBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaOperation.IsBuilderProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsReadonly
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.IsReadonlyProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.IsReadonlyProperty, value); }
		}
		
		void MetaOperationBuilder.SetIsReadonlyLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaOperation.IsReadonlyProperty, lazy);
		}
		
		void MetaOperationBuilder.SetIsReadonlyLazy(global::System.Func<MetaOperationBuilder, bool> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaOperation.IsReadonlyProperty, lazy);
		}
		
		void MetaOperationBuilder.SetIsReadonlyLazy(global::System.Func<MetaOperation, bool> immutableLazy, global::System.Func<MetaOperationBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaOperation.IsReadonlyProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaParameterBuilder> Parameters
		{
			get { return this.GetList<MetaParameterBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ReturnTypeProperty, value); }
		}
		
		void MetaOperationBuilder.SetReturnTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ReturnTypeProperty, lazy);
		}
		
		void MetaOperationBuilder.SetReturnTypeLazy(global::System.Func<MetaOperationBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ReturnTypeProperty, lazy);
		}
		
		void MetaOperationBuilder.SetReturnTypeLazy(global::System.Func<MetaOperation, MetaType> immutableLazy, global::System.Func<MetaOperationBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ReturnTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaOperationBuilder.ConformsTo(MetaOperationBuilder operation)
		{
		    return MetaImplementationProvider.Implementation.MetaOperation_ConformsTo(this, operation);
		}
	}
	
	internal class MetaParameterId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaParameter.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaParameterImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaOperation operation0;
	
		internal MetaParameterImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaOperation Operation
		{
		    get { return this.GetReference<MetaOperation>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaParameter.OperationProperty, ref operation0); }
		}
	}
	
	internal class MetaParameterBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaParameterBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
	
		internal MetaParameterBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaParameter(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaOperationBuilder Operation
		{
			get { return this.GetReference<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaParameter.OperationProperty); }
			set { this.SetReference<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaParameter.OperationProperty, value); }
		}
		
		void MetaParameterBuilder.SetOperationLazy(global::System.Func<MetaOperationBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaParameter.OperationProperty, lazy);
		}
		
		void MetaParameterBuilder.SetOperationLazy(global::System.Func<MetaParameterBuilder, MetaOperationBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaParameter.OperationProperty, lazy);
		}
		
		void MetaParameterBuilder.SetOperationLazy(global::System.Func<MetaParameter, MetaOperation> immutableLazy, global::System.Func<MetaParameterBuilder, MetaOperationBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaParameter.OperationProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaPropertyId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MetaPropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MetaPropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaPropertyImpl : global::MetaDslx.Modeling.ImmutableObjectBase, MetaProperty
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String symbolProperty0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaPropertyKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaClass class0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isContainment0;
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
	
		internal MetaPropertyImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public String SymbolProperty
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.SymbolPropertyProperty, ref symbolProperty0); }
		}
	
		
		public MetaPropertyKind Kind
		{
		    get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.KindProperty, ref kind0); }
		}
	
		
		public MetaClass Class
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.ClassProperty, ref class0); }
		}
	
		
		public String DefaultValue
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		public bool IsContainment
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.IsContainmentProperty, ref isContainment0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> OppositeProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettingProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefinedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefiningProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	
		
		bool MetaProperty.ConformsTo(MetaProperty property)
		{
		    return MetaImplementationProvider.Implementation.MetaProperty_ConformsTo(this, property);
		}
	}
	
	internal class MetaPropertyBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, MetaPropertyBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> attributes0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> oppositeProperties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> subsettedProperties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> subsettingProperties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> redefinedProperties0;
		private global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> redefiningProperties0;
	
		internal MetaPropertyBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaProperty(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Model.MetaInstance.MMetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public String Documentation
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, String> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, String> immutableLazy, global::System.Func<MetaNamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public String SymbolProperty
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.SymbolPropertyProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.SymbolPropertyProperty, value); }
		}
		
		void MetaPropertyBuilder.SetSymbolPropertyLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.SymbolPropertyProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetSymbolPropertyLazy(global::System.Func<MetaPropertyBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.SymbolPropertyProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetSymbolPropertyLazy(global::System.Func<MetaProperty, String> immutableLazy, global::System.Func<MetaPropertyBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.SymbolPropertyProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaPropertyKind Kind
		{
			get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.KindProperty); }
			set { this.SetValue<MetaPropertyKind>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.KindProperty, value); }
		}
		
		void MetaPropertyBuilder.SetKindLazy(global::System.Func<MetaPropertyKind> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaProperty.KindProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetKindLazy(global::System.Func<MetaPropertyBuilder, MetaPropertyKind> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaProperty.KindProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetKindLazy(global::System.Func<MetaProperty, MetaPropertyKind> immutableLazy, global::System.Func<MetaPropertyBuilder, MetaPropertyKind> mutableLazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaProperty.KindProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaClassBuilder Class
		{
			get { return this.GetReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.ClassProperty); }
			set { this.SetReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.ClassProperty, value); }
		}
		
		void MetaPropertyBuilder.SetClassLazy(global::System.Func<MetaClassBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.ClassProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetClassLazy(global::System.Func<MetaPropertyBuilder, MetaClassBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.ClassProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetClassLazy(global::System.Func<MetaProperty, MetaClass> immutableLazy, global::System.Func<MetaPropertyBuilder, MetaClassBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.ClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public String DefaultValue
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.DefaultValueProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.DefaultValueProperty, value); }
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.DefaultValueProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<MetaPropertyBuilder, String> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.DefaultValueProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<MetaProperty, String> immutableLazy, global::System.Func<MetaPropertyBuilder, String> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsContainment
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.IsContainmentProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.IsContainmentProperty, value); }
		}
		
		void MetaPropertyBuilder.SetIsContainmentLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaProperty.IsContainmentProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetIsContainmentLazy(global::System.Func<MetaPropertyBuilder, bool> lazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaProperty.IsContainmentProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetIsContainmentLazy(global::System.Func<MetaProperty, bool> immutableLazy, global::System.Func<MetaPropertyBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(MetaDescriptor.MetaProperty.IsContainmentProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> OppositeProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettingProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefinedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefiningProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	
		
		bool MetaPropertyBuilder.ConformsTo(MetaPropertyBuilder property)
		{
		    return MetaImplementationProvider.Implementation.MetaProperty_ConformsTo(this, property);
		}
	}

	internal class MetaBuilderInstance
	{
		internal static MetaBuilderInstance instance = new MetaBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Modeling.MutableModel MModel;
	
		internal MetaPrimitiveTypeBuilder Object = null;
		internal MetaPrimitiveTypeBuilder String = null;
		internal MetaPrimitiveTypeBuilder Int = null;
		internal MetaPrimitiveTypeBuilder Long = null;
		internal MetaPrimitiveTypeBuilder Float = null;
		internal MetaPrimitiveTypeBuilder Double = null;
		internal MetaPrimitiveTypeBuilder Byte = null;
		internal MetaPrimitiveTypeBuilder Bool = null;
		internal MetaPrimitiveTypeBuilder Void = null;
		internal MetaPrimitiveTypeBuilder SystemType = null;
		internal MetaPrimitiveTypeBuilder ModelObject = null;
	
		private MetaNamespaceBuilder __tmp1;
		private MetaNamespaceBuilder __tmp2;
		private MetaNamespaceBuilder __tmp3;
		private MetaNamespaceBuilder __tmp4;
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
		internal MetaClassBuilder MetaElement;
		internal MetaPropertyBuilder MetaElement_Attributes;
		internal MetaClassBuilder MetaDocumentedElement;
		internal MetaPropertyBuilder MetaDocumentedElement_Documentation;
		internal MetaClassBuilder MetaNamedElement;
		internal MetaPropertyBuilder MetaNamedElement_Name;
		internal MetaClassBuilder MetaTypedElement;
		internal MetaPropertyBuilder MetaTypedElement_Type;
		internal MetaClassBuilder MetaType;
		private MetaOperationBuilder __tmp18;
		private MetaParameterBuilder __tmp19;
		internal MetaClassBuilder MetaNamedType;
		internal MetaClassBuilder MetaAttribute;
		internal MetaClassBuilder MetaDeclaration;
		internal MetaPropertyBuilder MetaDeclaration_Namespace;
		internal MetaPropertyBuilder MetaDeclaration_MetaModel;
		internal MetaPropertyBuilder MetaDeclaration_FullName;
		internal MetaClassBuilder MetaNamespace;
		internal MetaPropertyBuilder MetaNamespace_DefinedMetaModel;
		internal MetaPropertyBuilder MetaNamespace_Declarations;
		internal MetaClassBuilder MetaModel;
		internal MetaPropertyBuilder MetaModel_Uri;
		internal MetaPropertyBuilder MetaModel_Prefix;
		internal MetaPropertyBuilder MetaModel_Namespace;
		internal MetaEnumBuilder MetaCollectionKind;
		private MetaEnumLiteralBuilder __tmp21;
		private MetaEnumLiteralBuilder __tmp22;
		private MetaEnumLiteralBuilder __tmp23;
		private MetaEnumLiteralBuilder __tmp24;
		internal MetaClassBuilder MetaCollectionType;
		internal MetaPropertyBuilder MetaCollectionType_Kind;
		internal MetaPropertyBuilder MetaCollectionType_InnerType;
		private MetaOperationBuilder __tmp25;
		private MetaParameterBuilder __tmp26;
		internal MetaClassBuilder MetaNullableType;
		internal MetaPropertyBuilder MetaNullableType_InnerType;
		private MetaOperationBuilder __tmp27;
		private MetaParameterBuilder __tmp28;
		internal MetaClassBuilder MetaPrimitiveType;
		internal MetaPropertyBuilder MetaPrimitiveType_DotNetName;
		private MetaOperationBuilder __tmp29;
		private MetaParameterBuilder __tmp30;
		internal MetaClassBuilder MetaEnum;
		internal MetaPropertyBuilder MetaEnum_EnumLiterals;
		internal MetaPropertyBuilder MetaEnum_Operations;
		internal MetaClassBuilder MetaEnumLiteral;
		internal MetaPropertyBuilder MetaEnumLiteral_Enum;
		internal MetaClassBuilder MetaConstant;
		internal MetaPropertyBuilder MetaConstant_DotNetName;
		internal MetaPropertyBuilder MetaConstant_Value;
		private MetaOperationBuilder __tmp33;
		private MetaParameterBuilder __tmp34;
		internal MetaClassBuilder MetaClass;
		internal MetaPropertyBuilder MetaClass_SymbolType;
		internal MetaPropertyBuilder MetaClass_IsAbstract;
		internal MetaPropertyBuilder MetaClass_SuperClasses;
		internal MetaPropertyBuilder MetaClass_Properties;
		internal MetaPropertyBuilder MetaClass_Operations;
		private MetaOperationBuilder __tmp35;
		private MetaParameterBuilder __tmp46;
		private MetaOperationBuilder __tmp36;
		private MetaParameterBuilder __tmp48;
		private MetaOperationBuilder __tmp37;
		private MetaParameterBuilder __tmp50;
		private MetaOperationBuilder __tmp38;
		private MetaParameterBuilder __tmp52;
		private MetaOperationBuilder __tmp39;
		private MetaOperationBuilder __tmp40;
		private MetaOperationBuilder __tmp41;
		private MetaOperationBuilder __tmp42;
		internal MetaClassBuilder MetaOperation;
		internal MetaPropertyBuilder MetaOperation_Class;
		internal MetaPropertyBuilder MetaOperation_Enum;
		internal MetaPropertyBuilder MetaOperation_IsBuilder;
		internal MetaPropertyBuilder MetaOperation_IsReadonly;
		internal MetaPropertyBuilder MetaOperation_Parameters;
		internal MetaPropertyBuilder MetaOperation_ReturnType;
		private MetaOperationBuilder __tmp57;
		private MetaParameterBuilder __tmp59;
		internal MetaClassBuilder MetaParameter;
		internal MetaPropertyBuilder MetaParameter_Operation;
		internal MetaEnumBuilder MetaPropertyKind;
		private MetaEnumLiteralBuilder __tmp60;
		private MetaEnumLiteralBuilder __tmp61;
		private MetaEnumLiteralBuilder __tmp62;
		private MetaEnumLiteralBuilder __tmp63;
		private MetaEnumLiteralBuilder __tmp64;
		internal MetaClassBuilder MetaProperty;
		internal MetaPropertyBuilder MetaProperty_SymbolProperty;
		internal MetaPropertyBuilder MetaProperty_Kind;
		internal MetaPropertyBuilder MetaProperty_Class;
		internal MetaPropertyBuilder MetaProperty_DefaultValue;
		internal MetaPropertyBuilder MetaProperty_IsContainment;
		internal MetaPropertyBuilder MetaProperty_OppositeProperties;
		internal MetaPropertyBuilder MetaProperty_SubsettedProperties;
		internal MetaPropertyBuilder MetaProperty_SubsettingProperties;
		internal MetaPropertyBuilder MetaProperty_RedefinedProperties;
		internal MetaPropertyBuilder MetaProperty_RedefiningProperties;
		private MetaOperationBuilder __tmp65;
		private MetaParameterBuilder __tmp71;
		private MetaCollectionTypeBuilder __tmp17;
		private MetaCollectionTypeBuilder __tmp20;
		private MetaCollectionTypeBuilder __tmp31;
		private MetaCollectionTypeBuilder __tmp32;
		private MetaCollectionTypeBuilder __tmp43;
		private MetaCollectionTypeBuilder __tmp44;
		private MetaCollectionTypeBuilder __tmp45;
		private MetaCollectionTypeBuilder __tmp47;
		private MetaCollectionTypeBuilder __tmp49;
		private MetaCollectionTypeBuilder __tmp51;
		private MetaCollectionTypeBuilder __tmp53;
		private MetaCollectionTypeBuilder __tmp54;
		private MetaCollectionTypeBuilder __tmp55;
		private MetaCollectionTypeBuilder __tmp56;
		private MetaCollectionTypeBuilder __tmp58;
		private MetaCollectionTypeBuilder __tmp66;
		private MetaCollectionTypeBuilder __tmp67;
		private MetaCollectionTypeBuilder __tmp68;
		private MetaCollectionTypeBuilder __tmp69;
		private MetaCollectionTypeBuilder __tmp70;
	
		internal MetaBuilderInstance()
		{
			this.MModel = new global::MetaDslx.Modeling.MutableModel("Meta");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			this.CreateInstances();
			MetaImplementationProvider.Implementation.MetaBuilderInstance(this);
	        foreach (global::MetaDslx.Modeling.MutableObject obj in this.MModel.Objects)
	        {
	            obj.MMakeCreated();
	        }
			lock (this)
			{
				this.created = true;
			}
		}
	
		internal void EvaluateLazyValues()
		{
			if (!this.created) return;
			this.MModel.EvaluateLazyValues();
		}
	
		private void CreateInstances()
		{
			global::MetaDslx.Languages.Meta.Model.MetaFactory factory = new global::MetaDslx.Languages.Meta.Model.MetaFactory(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);
	
			Object = factory.MetaPrimitiveType();
			Object.MName = "Object";
			Object.DotNetName = "System.Object";
			String = factory.MetaPrimitiveType();
			String.MName = "String";
			String.DotNetName = "System.String";
			Int = factory.MetaPrimitiveType();
			Int.MName = "Int";
			Int.DotNetName = "System.Int32";
			Long = factory.MetaPrimitiveType();
			Long.MName = "Long";
			Long.DotNetName = "System.Int64";
			Float = factory.MetaPrimitiveType();
			Float.MName = "Float";
			Float.DotNetName = "System.Single";
			Double = factory.MetaPrimitiveType();
			Double.MName = "Double";
			Double.DotNetName = "System.Double";
			Byte = factory.MetaPrimitiveType();
			Byte.MName = "Byte";
			Byte.DotNetName = "System.Byte";
			Bool = factory.MetaPrimitiveType();
			Bool.MName = "Bool";
			Bool.DotNetName = "System.Boolean";
			Void = factory.MetaPrimitiveType();
			Void.MName = "Void";
			Void.DotNetName = "System.Void";
			SystemType = factory.MetaPrimitiveType();
			SystemType.MName = "SystemType";
			SystemType.DotNetName = "System.Type";
			ModelObject = factory.MetaPrimitiveType();
			ModelObject.MName = "ModelObject";
			ModelObject.DotNetName = "MetaDslx.Modeling.IModelObject";
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaNamespace();
			__tmp5 = factory.MetaModel();
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
			MetaElement = factory.MetaClass();
			MetaElement_Attributes = factory.MetaProperty();
			MetaDocumentedElement = factory.MetaClass();
			MetaDocumentedElement_Documentation = factory.MetaProperty();
			MetaNamedElement = factory.MetaClass();
			MetaNamedElement_Name = factory.MetaProperty();
			MetaTypedElement = factory.MetaClass();
			MetaTypedElement_Type = factory.MetaProperty();
			MetaType = factory.MetaClass();
			__tmp18 = factory.MetaOperation();
			__tmp19 = factory.MetaParameter();
			MetaNamedType = factory.MetaClass();
			MetaAttribute = factory.MetaClass();
			MetaDeclaration = factory.MetaClass();
			MetaDeclaration_Namespace = factory.MetaProperty();
			MetaDeclaration_MetaModel = factory.MetaProperty();
			MetaDeclaration_FullName = factory.MetaProperty();
			MetaNamespace = factory.MetaClass();
			MetaNamespace_DefinedMetaModel = factory.MetaProperty();
			MetaNamespace_Declarations = factory.MetaProperty();
			MetaModel = factory.MetaClass();
			MetaModel_Uri = factory.MetaProperty();
			MetaModel_Prefix = factory.MetaProperty();
			MetaModel_Namespace = factory.MetaProperty();
			MetaCollectionKind = factory.MetaEnum();
			__tmp21 = factory.MetaEnumLiteral();
			__tmp22 = factory.MetaEnumLiteral();
			__tmp23 = factory.MetaEnumLiteral();
			__tmp24 = factory.MetaEnumLiteral();
			MetaCollectionType = factory.MetaClass();
			MetaCollectionType_Kind = factory.MetaProperty();
			MetaCollectionType_InnerType = factory.MetaProperty();
			__tmp25 = factory.MetaOperation();
			__tmp26 = factory.MetaParameter();
			MetaNullableType = factory.MetaClass();
			MetaNullableType_InnerType = factory.MetaProperty();
			__tmp27 = factory.MetaOperation();
			__tmp28 = factory.MetaParameter();
			MetaPrimitiveType = factory.MetaClass();
			MetaPrimitiveType_DotNetName = factory.MetaProperty();
			__tmp29 = factory.MetaOperation();
			__tmp30 = factory.MetaParameter();
			MetaEnum = factory.MetaClass();
			MetaEnum_EnumLiterals = factory.MetaProperty();
			MetaEnum_Operations = factory.MetaProperty();
			MetaEnumLiteral = factory.MetaClass();
			MetaEnumLiteral_Enum = factory.MetaProperty();
			MetaConstant = factory.MetaClass();
			MetaConstant_DotNetName = factory.MetaProperty();
			MetaConstant_Value = factory.MetaProperty();
			__tmp33 = factory.MetaOperation();
			__tmp34 = factory.MetaParameter();
			MetaClass = factory.MetaClass();
			MetaClass_SymbolType = factory.MetaProperty();
			MetaClass_IsAbstract = factory.MetaProperty();
			MetaClass_SuperClasses = factory.MetaProperty();
			MetaClass_Properties = factory.MetaProperty();
			MetaClass_Operations = factory.MetaProperty();
			__tmp35 = factory.MetaOperation();
			__tmp46 = factory.MetaParameter();
			__tmp36 = factory.MetaOperation();
			__tmp48 = factory.MetaParameter();
			__tmp37 = factory.MetaOperation();
			__tmp50 = factory.MetaParameter();
			__tmp38 = factory.MetaOperation();
			__tmp52 = factory.MetaParameter();
			__tmp39 = factory.MetaOperation();
			__tmp40 = factory.MetaOperation();
			__tmp41 = factory.MetaOperation();
			__tmp42 = factory.MetaOperation();
			MetaOperation = factory.MetaClass();
			MetaOperation_Class = factory.MetaProperty();
			MetaOperation_Enum = factory.MetaProperty();
			MetaOperation_IsBuilder = factory.MetaProperty();
			MetaOperation_IsReadonly = factory.MetaProperty();
			MetaOperation_Parameters = factory.MetaProperty();
			MetaOperation_ReturnType = factory.MetaProperty();
			__tmp57 = factory.MetaOperation();
			__tmp59 = factory.MetaParameter();
			MetaParameter = factory.MetaClass();
			MetaParameter_Operation = factory.MetaProperty();
			MetaPropertyKind = factory.MetaEnum();
			__tmp60 = factory.MetaEnumLiteral();
			__tmp61 = factory.MetaEnumLiteral();
			__tmp62 = factory.MetaEnumLiteral();
			__tmp63 = factory.MetaEnumLiteral();
			__tmp64 = factory.MetaEnumLiteral();
			MetaProperty = factory.MetaClass();
			MetaProperty_SymbolProperty = factory.MetaProperty();
			MetaProperty_Kind = factory.MetaProperty();
			MetaProperty_Class = factory.MetaProperty();
			MetaProperty_DefaultValue = factory.MetaProperty();
			MetaProperty_IsContainment = factory.MetaProperty();
			MetaProperty_OppositeProperties = factory.MetaProperty();
			MetaProperty_SubsettedProperties = factory.MetaProperty();
			MetaProperty_SubsettingProperties = factory.MetaProperty();
			MetaProperty_RedefinedProperties = factory.MetaProperty();
			MetaProperty_RedefiningProperties = factory.MetaProperty();
			__tmp65 = factory.MetaOperation();
			__tmp71 = factory.MetaParameter();
			__tmp17 = factory.MetaCollectionType();
			__tmp20 = factory.MetaCollectionType();
			__tmp31 = factory.MetaCollectionType();
			__tmp32 = factory.MetaCollectionType();
			__tmp43 = factory.MetaCollectionType();
			__tmp44 = factory.MetaCollectionType();
			__tmp45 = factory.MetaCollectionType();
			__tmp47 = factory.MetaCollectionType();
			__tmp49 = factory.MetaCollectionType();
			__tmp51 = factory.MetaCollectionType();
			__tmp53 = factory.MetaCollectionType();
			__tmp54 = factory.MetaCollectionType();
			__tmp55 = factory.MetaCollectionType();
			__tmp56 = factory.MetaCollectionType();
			__tmp58 = factory.MetaCollectionType();
			__tmp66 = factory.MetaCollectionType();
			__tmp67 = factory.MetaCollectionType();
			__tmp68 = factory.MetaCollectionType();
			__tmp69 = factory.MetaCollectionType();
			__tmp70 = factory.MetaCollectionType();
	
			__tmp1.Documentation = null;
			__tmp1.Name = "MetaDslx";
			// __tmp1.Namespace = null;
			// __tmp1.DefinedMetaModel = null;
			__tmp1.Declarations.AddLazy(() => __tmp2);
			__tmp2.Documentation = null;
			__tmp2.Name = "Languages";
			__tmp2.SetNamespaceLazy(() => __tmp1);
			// __tmp2.DefinedMetaModel = null;
			__tmp2.Declarations.AddLazy(() => __tmp3);
			__tmp3.Documentation = null;
			__tmp3.Name = "Meta";
			__tmp3.SetNamespaceLazy(() => __tmp2);
			// __tmp3.DefinedMetaModel = null;
			__tmp3.Declarations.AddLazy(() => __tmp4);
			__tmp4.Documentation = null;
			__tmp4.Name = "Model";
			__tmp4.SetNamespaceLazy(() => __tmp3);
			__tmp4.SetDefinedMetaModelLazy(() => __tmp5);
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
			__tmp5.Documentation = "\n\tRepresents the MetaModel.\n\t\r\n";
			__tmp5.Name = "Meta";
			__tmp5.Uri = "http://metadslx.core/1.0";
			__tmp5.Prefix = null;
			__tmp5.SetNamespaceLazy(() => __tmp4);
			__tmp6.SetTypeLazy(() => MetaPrimitiveType);
			__tmp6.Documentation = null;
			__tmp6.Name = "Object";
			__tmp6.SetNamespaceLazy(() => __tmp4);
			__tmp6.DotNetName = "System.Object";
			__tmp6.SetValueLazy(() => Object);
			__tmp7.SetTypeLazy(() => MetaPrimitiveType);
			__tmp7.Documentation = null;
			__tmp7.Name = "String";
			__tmp7.SetNamespaceLazy(() => __tmp4);
			__tmp7.DotNetName = "System.String";
			__tmp7.SetValueLazy(() => String);
			__tmp8.SetTypeLazy(() => MetaPrimitiveType);
			__tmp8.Documentation = null;
			__tmp8.Name = "Int";
			__tmp8.SetNamespaceLazy(() => __tmp4);
			__tmp8.DotNetName = "System.Int32";
			__tmp8.SetValueLazy(() => Int);
			__tmp9.SetTypeLazy(() => MetaPrimitiveType);
			__tmp9.Documentation = null;
			__tmp9.Name = "Long";
			__tmp9.SetNamespaceLazy(() => __tmp4);
			__tmp9.DotNetName = "System.Int64";
			__tmp9.SetValueLazy(() => Long);
			__tmp10.SetTypeLazy(() => MetaPrimitiveType);
			__tmp10.Documentation = null;
			__tmp10.Name = "Float";
			__tmp10.SetNamespaceLazy(() => __tmp4);
			__tmp10.DotNetName = "System.Single";
			__tmp10.SetValueLazy(() => Float);
			__tmp11.SetTypeLazy(() => MetaPrimitiveType);
			__tmp11.Documentation = null;
			__tmp11.Name = "Double";
			__tmp11.SetNamespaceLazy(() => __tmp4);
			__tmp11.DotNetName = "System.Double";
			__tmp11.SetValueLazy(() => Double);
			__tmp12.SetTypeLazy(() => MetaPrimitiveType);
			__tmp12.Documentation = null;
			__tmp12.Name = "Byte";
			__tmp12.SetNamespaceLazy(() => __tmp4);
			__tmp12.DotNetName = "System.Byte";
			__tmp12.SetValueLazy(() => Byte);
			__tmp13.SetTypeLazy(() => MetaPrimitiveType);
			__tmp13.Documentation = null;
			__tmp13.Name = "Bool";
			__tmp13.SetNamespaceLazy(() => __tmp4);
			__tmp13.DotNetName = "System.Boolean";
			__tmp13.SetValueLazy(() => Bool);
			__tmp14.SetTypeLazy(() => MetaPrimitiveType);
			__tmp14.Documentation = null;
			__tmp14.Name = "Void";
			__tmp14.SetNamespaceLazy(() => __tmp4);
			__tmp14.DotNetName = "System.Void";
			__tmp14.SetValueLazy(() => Void);
			__tmp15.SetTypeLazy(() => MetaPrimitiveType);
			__tmp15.Documentation = null;
			__tmp15.Name = "SystemType";
			__tmp15.SetNamespaceLazy(() => __tmp4);
			__tmp15.DotNetName = "System.Type";
			__tmp15.SetValueLazy(() => SystemType);
			__tmp16.SetTypeLazy(() => MetaPrimitiveType);
			__tmp16.Documentation = null;
			__tmp16.Name = "ModelObject";
			__tmp16.SetNamespaceLazy(() => __tmp4);
			__tmp16.DotNetName = "MetaDslx.Modeling.IModelObject";
			__tmp16.SetValueLazy(() => ModelObject);
			MetaElement.Documentation = "\n\tRepresents an element.\n\t\r\n";
			MetaElement.Name = "MetaElement";
			MetaElement.SetNamespaceLazy(() => __tmp4);
			MetaElement.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.Symbol);
			MetaElement.IsAbstract = true;
			MetaElement.Properties.AddLazy(() => MetaElement_Attributes);
			MetaElement_Attributes.SetTypeLazy(() => __tmp17);
			MetaElement_Attributes.Documentation = null;
			MetaElement_Attributes.Name = "Attributes";
			MetaElement_Attributes.SymbolProperty = "Attributes";
			MetaElement_Attributes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaElement_Attributes.SetClassLazy(() => MetaElement);
			MetaElement_Attributes.DefaultValue = null;
			MetaElement_Attributes.IsContainment = false;
			MetaDocumentedElement.Documentation = null;
			MetaDocumentedElement.Name = "MetaDocumentedElement";
			MetaDocumentedElement.SetNamespaceLazy(() => __tmp4);
			MetaDocumentedElement.SymbolType = null;
			MetaDocumentedElement.IsAbstract = true;
			MetaDocumentedElement.SuperClasses.AddLazy(() => MetaElement);
			MetaDocumentedElement.Properties.AddLazy(() => MetaDocumentedElement_Documentation);
			MetaDocumentedElement_Documentation.SetTypeLazy(() => String);
			MetaDocumentedElement_Documentation.Documentation = null;
			MetaDocumentedElement_Documentation.Name = "Documentation";
			MetaDocumentedElement_Documentation.SymbolProperty = null;
			MetaDocumentedElement_Documentation.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaDocumentedElement_Documentation.SetClassLazy(() => MetaDocumentedElement);
			MetaDocumentedElement_Documentation.DefaultValue = null;
			MetaDocumentedElement_Documentation.IsContainment = false;
			MetaNamedElement.Documentation = null;
			MetaNamedElement.Name = "MetaNamedElement";
			MetaNamedElement.SetNamespaceLazy(() => __tmp4);
			MetaNamedElement.SymbolType = null;
			MetaNamedElement.IsAbstract = true;
			MetaNamedElement.SuperClasses.AddLazy(() => MetaDocumentedElement);
			MetaNamedElement.Properties.AddLazy(() => MetaNamedElement_Name);
			MetaNamedElement_Name.SetTypeLazy(() => String);
			MetaNamedElement_Name.Documentation = null;
			MetaNamedElement_Name.Name = "Name";
			MetaNamedElement_Name.SymbolProperty = "Name";
			MetaNamedElement_Name.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaNamedElement_Name.SetClassLazy(() => MetaNamedElement);
			MetaNamedElement_Name.DefaultValue = null;
			MetaNamedElement_Name.IsContainment = false;
			MetaTypedElement.Documentation = null;
			MetaTypedElement.Name = "MetaTypedElement";
			MetaTypedElement.SetNamespaceLazy(() => __tmp4);
			MetaTypedElement.SymbolType = null;
			MetaTypedElement.IsAbstract = true;
			MetaTypedElement.SuperClasses.AddLazy(() => MetaElement);
			MetaTypedElement.Properties.AddLazy(() => MetaTypedElement_Type);
			MetaTypedElement_Type.SetTypeLazy(() => MetaType);
			MetaTypedElement_Type.Documentation = null;
			MetaTypedElement_Type.Name = "Type";
			MetaTypedElement_Type.SymbolProperty = null;
			MetaTypedElement_Type.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaTypedElement_Type.SetClassLazy(() => MetaTypedElement);
			MetaTypedElement_Type.DefaultValue = null;
			MetaTypedElement_Type.IsContainment = false;
			MetaTypedElement_Type.RedefiningProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaType.Documentation = null;
			MetaType.Name = "MetaType";
			MetaType.SetNamespaceLazy(() => __tmp4);
			MetaType.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.TypeSymbol);
			MetaType.IsAbstract = true;
			MetaType.Operations.AddLazy(() => __tmp18);
			__tmp18.Documentation = null;
			__tmp18.Name = "ConformsTo";
			__tmp18.SetClassLazy(() => MetaType);
			// __tmp18.Enum = null;
			__tmp18.IsBuilder = false;
			__tmp18.IsReadonly = false;
			__tmp18.Parameters.AddLazy(() => __tmp19);
			__tmp18.SetReturnTypeLazy(() => Bool);
			__tmp19.SetTypeLazy(() => MetaType);
			__tmp19.Documentation = null;
			__tmp19.Name = "type";
			__tmp19.SetOperationLazy(() => __tmp18);
			MetaNamedType.Documentation = null;
			MetaNamedType.Name = "MetaNamedType";
			MetaNamedType.SetNamespaceLazy(() => __tmp4);
			MetaNamedType.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			MetaNamedType.IsAbstract = false;
			MetaNamedType.SuperClasses.AddLazy(() => MetaType);
			MetaNamedType.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaAttribute.Documentation = null;
			MetaAttribute.Name = "MetaAttribute";
			MetaAttribute.SetNamespaceLazy(() => __tmp4);
			MetaAttribute.SymbolType = null;
			MetaAttribute.IsAbstract = false;
			MetaAttribute.SuperClasses.AddLazy(() => MetaNamedType);
			MetaDeclaration.Documentation = null;
			MetaDeclaration.Name = "MetaDeclaration";
			MetaDeclaration.SetNamespaceLazy(() => __tmp4);
			MetaDeclaration.SymbolType = null;
			MetaDeclaration.IsAbstract = true;
			MetaDeclaration.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_Namespace);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_MetaModel);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_FullName);
			MetaDeclaration_Namespace.SetTypeLazy(() => MetaNamespace);
			MetaDeclaration_Namespace.Documentation = null;
			MetaDeclaration_Namespace.Name = "Namespace";
			MetaDeclaration_Namespace.SymbolProperty = null;
			MetaDeclaration_Namespace.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaDeclaration_Namespace.SetClassLazy(() => MetaDeclaration);
			MetaDeclaration_Namespace.DefaultValue = null;
			MetaDeclaration_Namespace.IsContainment = false;
			MetaDeclaration_Namespace.OppositeProperties.AddLazy(() => MetaNamespace_Declarations);
			MetaDeclaration_MetaModel.SetTypeLazy(() => MetaModel);
			MetaDeclaration_MetaModel.Documentation = null;
			MetaDeclaration_MetaModel.Name = "MetaModel";
			MetaDeclaration_MetaModel.SymbolProperty = null;
			MetaDeclaration_MetaModel.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			MetaDeclaration_MetaModel.SetClassLazy(() => MetaDeclaration);
			MetaDeclaration_MetaModel.DefaultValue = null;
			MetaDeclaration_MetaModel.IsContainment = false;
			MetaDeclaration_FullName.SetTypeLazy(() => String);
			MetaDeclaration_FullName.Documentation = null;
			MetaDeclaration_FullName.Name = "FullName";
			MetaDeclaration_FullName.SymbolProperty = null;
			MetaDeclaration_FullName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			MetaDeclaration_FullName.SetClassLazy(() => MetaDeclaration);
			MetaDeclaration_FullName.DefaultValue = null;
			MetaDeclaration_FullName.IsContainment = false;
			MetaNamespace.Documentation = null;
			MetaNamespace.Name = "MetaNamespace";
			MetaNamespace.SetNamespaceLazy(() => __tmp4);
			MetaNamespace.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamespaceSymbol);
			MetaNamespace.IsAbstract = false;
			MetaNamespace.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_DefinedMetaModel);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Declarations);
			MetaNamespace_DefinedMetaModel.SetTypeLazy(() => MetaModel);
			MetaNamespace_DefinedMetaModel.Documentation = null;
			MetaNamespace_DefinedMetaModel.Name = "DefinedMetaModel";
			MetaNamespace_DefinedMetaModel.SymbolProperty = "Members";
			MetaNamespace_DefinedMetaModel.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaNamespace_DefinedMetaModel.SetClassLazy(() => MetaNamespace);
			MetaNamespace_DefinedMetaModel.DefaultValue = null;
			MetaNamespace_DefinedMetaModel.IsContainment = true;
			MetaNamespace_DefinedMetaModel.OppositeProperties.AddLazy(() => MetaModel_Namespace);
			MetaNamespace_Declarations.SetTypeLazy(() => __tmp20);
			MetaNamespace_Declarations.Documentation = null;
			MetaNamespace_Declarations.Name = "Declarations";
			MetaNamespace_Declarations.SymbolProperty = "Members";
			MetaNamespace_Declarations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaNamespace_Declarations.SetClassLazy(() => MetaNamespace);
			MetaNamespace_Declarations.DefaultValue = null;
			MetaNamespace_Declarations.IsContainment = true;
			MetaNamespace_Declarations.OppositeProperties.AddLazy(() => MetaDeclaration_Namespace);
			MetaModel.Documentation = null;
			MetaModel.Name = "MetaModel";
			MetaModel.SetNamespaceLazy(() => __tmp4);
			MetaModel.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			MetaModel.IsAbstract = false;
			MetaModel.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaModel.Properties.AddLazy(() => MetaModel_Uri);
			MetaModel.Properties.AddLazy(() => MetaModel_Prefix);
			MetaModel.Properties.AddLazy(() => MetaModel_Namespace);
			MetaModel_Uri.SetTypeLazy(() => String);
			MetaModel_Uri.Documentation = null;
			MetaModel_Uri.Name = "Uri";
			MetaModel_Uri.SymbolProperty = null;
			MetaModel_Uri.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaModel_Uri.SetClassLazy(() => MetaModel);
			MetaModel_Uri.DefaultValue = null;
			MetaModel_Uri.IsContainment = false;
			MetaModel_Prefix.SetTypeLazy(() => String);
			MetaModel_Prefix.Documentation = null;
			MetaModel_Prefix.Name = "Prefix";
			MetaModel_Prefix.SymbolProperty = null;
			MetaModel_Prefix.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaModel_Prefix.SetClassLazy(() => MetaModel);
			MetaModel_Prefix.DefaultValue = null;
			MetaModel_Prefix.IsContainment = false;
			MetaModel_Namespace.SetTypeLazy(() => MetaNamespace);
			MetaModel_Namespace.Documentation = null;
			MetaModel_Namespace.Name = "Namespace";
			MetaModel_Namespace.SymbolProperty = null;
			MetaModel_Namespace.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaModel_Namespace.SetClassLazy(() => MetaModel);
			MetaModel_Namespace.DefaultValue = null;
			MetaModel_Namespace.IsContainment = false;
			MetaModel_Namespace.OppositeProperties.AddLazy(() => MetaNamespace_DefinedMetaModel);
			MetaCollectionKind.Documentation = null;
			MetaCollectionKind.Name = "MetaCollectionKind";
			MetaCollectionKind.SetNamespaceLazy(() => __tmp4);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp21);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp22);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp23);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp24);
			__tmp21.Documentation = null;
			__tmp21.Name = "List";
			__tmp21.SetEnumLazy(() => MetaCollectionKind);
			__tmp22.Documentation = null;
			__tmp22.Name = "Set";
			__tmp22.SetEnumLazy(() => MetaCollectionKind);
			__tmp23.Documentation = null;
			__tmp23.Name = "MultiList";
			__tmp23.SetEnumLazy(() => MetaCollectionKind);
			__tmp24.Documentation = null;
			__tmp24.Name = "MultiSet";
			__tmp24.SetEnumLazy(() => MetaCollectionKind);
			MetaCollectionType.Documentation = null;
			MetaCollectionType.Name = "MetaCollectionType";
			MetaCollectionType.SetNamespaceLazy(() => __tmp4);
			MetaCollectionType.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.ArrayTypeSymbol);
			MetaCollectionType.IsAbstract = false;
			MetaCollectionType.SuperClasses.AddLazy(() => MetaType);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_Kind);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_InnerType);
			MetaCollectionType.Operations.AddLazy(() => __tmp25);
			MetaCollectionType_Kind.SetTypeLazy(() => MetaCollectionKind);
			MetaCollectionType_Kind.Documentation = null;
			MetaCollectionType_Kind.Name = "Kind";
			MetaCollectionType_Kind.SymbolProperty = null;
			MetaCollectionType_Kind.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaCollectionType_Kind.SetClassLazy(() => MetaCollectionType);
			MetaCollectionType_Kind.DefaultValue = null;
			MetaCollectionType_Kind.IsContainment = false;
			MetaCollectionType_InnerType.SetTypeLazy(() => MetaType);
			MetaCollectionType_InnerType.Documentation = null;
			MetaCollectionType_InnerType.Name = "InnerType";
			MetaCollectionType_InnerType.SymbolProperty = "ElementType";
			MetaCollectionType_InnerType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaCollectionType_InnerType.SetClassLazy(() => MetaCollectionType);
			MetaCollectionType_InnerType.DefaultValue = null;
			MetaCollectionType_InnerType.IsContainment = false;
			__tmp25.Documentation = null;
			__tmp25.Name = "ConformsTo";
			__tmp25.SetClassLazy(() => MetaCollectionType);
			// __tmp25.Enum = null;
			__tmp25.IsBuilder = false;
			__tmp25.IsReadonly = false;
			__tmp25.Parameters.AddLazy(() => __tmp26);
			__tmp25.SetReturnTypeLazy(() => Bool);
			__tmp26.SetTypeLazy(() => MetaType);
			__tmp26.Documentation = null;
			__tmp26.Name = "type";
			__tmp26.SetOperationLazy(() => __tmp25);
			MetaNullableType.Documentation = null;
			MetaNullableType.Name = "MetaNullableType";
			MetaNullableType.SetNamespaceLazy(() => __tmp4);
			MetaNullableType.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NullableTypeSymbol);
			MetaNullableType.IsAbstract = false;
			MetaNullableType.SuperClasses.AddLazy(() => MetaType);
			MetaNullableType.Properties.AddLazy(() => MetaNullableType_InnerType);
			MetaNullableType.Operations.AddLazy(() => __tmp27);
			MetaNullableType_InnerType.SetTypeLazy(() => MetaType);
			MetaNullableType_InnerType.Documentation = null;
			MetaNullableType_InnerType.Name = "InnerType";
			MetaNullableType_InnerType.SymbolProperty = "InnerType";
			MetaNullableType_InnerType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaNullableType_InnerType.SetClassLazy(() => MetaNullableType);
			MetaNullableType_InnerType.DefaultValue = null;
			MetaNullableType_InnerType.IsContainment = false;
			__tmp27.Documentation = null;
			__tmp27.Name = "ConformsTo";
			__tmp27.SetClassLazy(() => MetaNullableType);
			// __tmp27.Enum = null;
			__tmp27.IsBuilder = false;
			__tmp27.IsReadonly = false;
			__tmp27.Parameters.AddLazy(() => __tmp28);
			__tmp27.SetReturnTypeLazy(() => Bool);
			__tmp28.SetTypeLazy(() => MetaType);
			__tmp28.Documentation = null;
			__tmp28.Name = "type";
			__tmp28.SetOperationLazy(() => __tmp27);
			MetaPrimitiveType.Documentation = null;
			MetaPrimitiveType.Name = "MetaPrimitiveType";
			MetaPrimitiveType.SetNamespaceLazy(() => __tmp4);
			MetaPrimitiveType.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			MetaPrimitiveType.IsAbstract = false;
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaNamedType);
			MetaPrimitiveType.Properties.AddLazy(() => MetaPrimitiveType_DotNetName);
			MetaPrimitiveType.Operations.AddLazy(() => __tmp29);
			MetaPrimitiveType_DotNetName.SetTypeLazy(() => String);
			MetaPrimitiveType_DotNetName.Documentation = null;
			MetaPrimitiveType_DotNetName.Name = "DotNetName";
			MetaPrimitiveType_DotNetName.SymbolProperty = null;
			MetaPrimitiveType_DotNetName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaPrimitiveType_DotNetName.SetClassLazy(() => MetaPrimitiveType);
			MetaPrimitiveType_DotNetName.DefaultValue = null;
			MetaPrimitiveType_DotNetName.IsContainment = false;
			__tmp29.Documentation = null;
			__tmp29.Name = "ConformsTo";
			__tmp29.SetClassLazy(() => MetaPrimitiveType);
			// __tmp29.Enum = null;
			__tmp29.IsBuilder = false;
			__tmp29.IsReadonly = false;
			__tmp29.Parameters.AddLazy(() => __tmp30);
			__tmp29.SetReturnTypeLazy(() => Bool);
			__tmp30.SetTypeLazy(() => MetaType);
			__tmp30.Documentation = null;
			__tmp30.Name = "type";
			__tmp30.SetOperationLazy(() => __tmp29);
			MetaEnum.Documentation = null;
			MetaEnum.Name = "MetaEnum";
			MetaEnum.SetNamespaceLazy(() => __tmp4);
			MetaEnum.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.EnumTypeSymbol);
			MetaEnum.IsAbstract = false;
			MetaEnum.SuperClasses.AddLazy(() => MetaNamedType);
			MetaEnum.Properties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnum.Properties.AddLazy(() => MetaEnum_Operations);
			MetaEnum_EnumLiterals.SetTypeLazy(() => __tmp31);
			MetaEnum_EnumLiterals.Documentation = null;
			MetaEnum_EnumLiterals.Name = "EnumLiterals";
			MetaEnum_EnumLiterals.SymbolProperty = "Members";
			MetaEnum_EnumLiterals.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaEnum_EnumLiterals.SetClassLazy(() => MetaEnum);
			MetaEnum_EnumLiterals.DefaultValue = null;
			MetaEnum_EnumLiterals.IsContainment = true;
			MetaEnum_EnumLiterals.OppositeProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaEnum_Operations.SetTypeLazy(() => __tmp32);
			MetaEnum_Operations.Documentation = null;
			MetaEnum_Operations.Name = "Operations";
			MetaEnum_Operations.SymbolProperty = "Members";
			MetaEnum_Operations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaEnum_Operations.SetClassLazy(() => MetaEnum);
			MetaEnum_Operations.DefaultValue = null;
			MetaEnum_Operations.IsContainment = true;
			MetaEnum_Operations.OppositeProperties.AddLazy(() => MetaOperation_Enum);
			MetaEnumLiteral.Documentation = null;
			MetaEnumLiteral.Name = "MetaEnumLiteral";
			MetaEnumLiteral.SetNamespaceLazy(() => __tmp4);
			MetaEnumLiteral.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.EnumLiteralSymbol);
			MetaEnumLiteral.IsAbstract = false;
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaEnumLiteral.Properties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaEnumLiteral_Enum.SetTypeLazy(() => MetaEnum);
			MetaEnumLiteral_Enum.Documentation = null;
			MetaEnumLiteral_Enum.Name = "Enum";
			MetaEnumLiteral_Enum.SymbolProperty = null;
			MetaEnumLiteral_Enum.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaEnumLiteral_Enum.SetClassLazy(() => MetaEnumLiteral);
			MetaEnumLiteral_Enum.DefaultValue = null;
			MetaEnumLiteral_Enum.IsContainment = false;
			MetaEnumLiteral_Enum.OppositeProperties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnumLiteral_Enum.RedefinedProperties.AddLazy(() => MetaTypedElement_Type);
			MetaConstant.Documentation = null;
			MetaConstant.Name = "MetaConstant";
			MetaConstant.SetNamespaceLazy(() => __tmp4);
			MetaConstant.SymbolType = null;
			MetaConstant.IsAbstract = false;
			MetaConstant.SuperClasses.AddLazy(() => MetaNamedType);
			MetaConstant.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaConstant.Properties.AddLazy(() => MetaConstant_DotNetName);
			MetaConstant.Properties.AddLazy(() => MetaConstant_Value);
			MetaConstant.Operations.AddLazy(() => __tmp33);
			MetaConstant_DotNetName.SetTypeLazy(() => String);
			MetaConstant_DotNetName.Documentation = null;
			MetaConstant_DotNetName.Name = "DotNetName";
			MetaConstant_DotNetName.SymbolProperty = null;
			MetaConstant_DotNetName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaConstant_DotNetName.SetClassLazy(() => MetaConstant);
			MetaConstant_DotNetName.DefaultValue = null;
			MetaConstant_DotNetName.IsContainment = false;
			MetaConstant_Value.SetTypeLazy(() => __tmp16);
			MetaConstant_Value.Documentation = null;
			MetaConstant_Value.Name = "Value";
			MetaConstant_Value.SymbolProperty = null;
			MetaConstant_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Readonly;
			MetaConstant_Value.SetClassLazy(() => MetaConstant);
			MetaConstant_Value.DefaultValue = null;
			MetaConstant_Value.IsContainment = false;
			__tmp33.Documentation = null;
			__tmp33.Name = "ConformsTo";
			__tmp33.SetClassLazy(() => MetaConstant);
			// __tmp33.Enum = null;
			__tmp33.IsBuilder = false;
			__tmp33.IsReadonly = false;
			__tmp33.Parameters.AddLazy(() => __tmp34);
			__tmp33.SetReturnTypeLazy(() => Bool);
			__tmp34.SetTypeLazy(() => MetaType);
			__tmp34.Documentation = null;
			__tmp34.Name = "type";
			__tmp34.SetOperationLazy(() => __tmp33);
			MetaClass.Documentation = null;
			MetaClass.Name = "MetaClass";
			MetaClass.SetNamespaceLazy(() => __tmp4);
			MetaClass.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.ClassTypeSymbol);
			MetaClass.IsAbstract = false;
			MetaClass.SuperClasses.AddLazy(() => MetaNamedType);
			MetaClass.Properties.AddLazy(() => MetaClass_SymbolType);
			MetaClass.Properties.AddLazy(() => MetaClass_IsAbstract);
			MetaClass.Properties.AddLazy(() => MetaClass_SuperClasses);
			MetaClass.Properties.AddLazy(() => MetaClass_Properties);
			MetaClass.Properties.AddLazy(() => MetaClass_Operations);
			MetaClass.Operations.AddLazy(() => __tmp35);
			MetaClass.Operations.AddLazy(() => __tmp36);
			MetaClass.Operations.AddLazy(() => __tmp37);
			MetaClass.Operations.AddLazy(() => __tmp38);
			MetaClass.Operations.AddLazy(() => __tmp39);
			MetaClass.Operations.AddLazy(() => __tmp40);
			MetaClass.Operations.AddLazy(() => __tmp41);
			MetaClass.Operations.AddLazy(() => __tmp42);
			MetaClass_SymbolType.SetTypeLazy(() => __tmp15);
			MetaClass_SymbolType.Documentation = null;
			MetaClass_SymbolType.Name = "SymbolType";
			MetaClass_SymbolType.SymbolProperty = "Attributes";
			MetaClass_SymbolType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaClass_SymbolType.SetClassLazy(() => MetaClass);
			MetaClass_SymbolType.DefaultValue = null;
			MetaClass_SymbolType.IsContainment = false;
			MetaClass_IsAbstract.SetTypeLazy(() => Bool);
			MetaClass_IsAbstract.Documentation = null;
			MetaClass_IsAbstract.Name = "IsAbstract";
			MetaClass_IsAbstract.SymbolProperty = null;
			MetaClass_IsAbstract.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaClass_IsAbstract.SetClassLazy(() => MetaClass);
			MetaClass_IsAbstract.DefaultValue = null;
			MetaClass_IsAbstract.IsContainment = false;
			MetaClass_SuperClasses.SetTypeLazy(() => __tmp43);
			MetaClass_SuperClasses.Documentation = null;
			MetaClass_SuperClasses.Name = "SuperClasses";
			MetaClass_SuperClasses.SymbolProperty = "BaseTypes";
			MetaClass_SuperClasses.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaClass_SuperClasses.SetClassLazy(() => MetaClass);
			MetaClass_SuperClasses.DefaultValue = null;
			MetaClass_SuperClasses.IsContainment = false;
			MetaClass_Properties.SetTypeLazy(() => __tmp44);
			MetaClass_Properties.Documentation = null;
			MetaClass_Properties.Name = "Properties";
			MetaClass_Properties.SymbolProperty = "Members";
			MetaClass_Properties.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaClass_Properties.SetClassLazy(() => MetaClass);
			MetaClass_Properties.DefaultValue = null;
			MetaClass_Properties.IsContainment = true;
			MetaClass_Properties.OppositeProperties.AddLazy(() => MetaProperty_Class);
			MetaClass_Operations.SetTypeLazy(() => __tmp45);
			MetaClass_Operations.Documentation = null;
			MetaClass_Operations.Name = "Operations";
			MetaClass_Operations.SymbolProperty = "Members";
			MetaClass_Operations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaClass_Operations.SetClassLazy(() => MetaClass);
			MetaClass_Operations.DefaultValue = null;
			MetaClass_Operations.IsContainment = true;
			MetaClass_Operations.OppositeProperties.AddLazy(() => MetaOperation_Class);
			__tmp35.Documentation = null;
			__tmp35.Name = "ConformsTo";
			__tmp35.SetClassLazy(() => MetaClass);
			// __tmp35.Enum = null;
			__tmp35.IsBuilder = false;
			__tmp35.IsReadonly = false;
			__tmp35.Parameters.AddLazy(() => __tmp46);
			__tmp35.SetReturnTypeLazy(() => Bool);
			__tmp46.SetTypeLazy(() => MetaType);
			__tmp46.Documentation = null;
			__tmp46.Name = "type";
			__tmp46.SetOperationLazy(() => __tmp35);
			__tmp36.Documentation = null;
			__tmp36.Name = "GetAllSuperClasses";
			__tmp36.SetClassLazy(() => MetaClass);
			// __tmp36.Enum = null;
			__tmp36.IsBuilder = false;
			__tmp36.IsReadonly = false;
			__tmp36.Parameters.AddLazy(() => __tmp48);
			__tmp36.SetReturnTypeLazy(() => __tmp47);
			__tmp48.SetTypeLazy(() => Bool);
			__tmp48.Documentation = null;
			__tmp48.Name = "includeSelf";
			__tmp48.SetOperationLazy(() => __tmp36);
			__tmp37.Documentation = null;
			__tmp37.Name = "GetAllSuperProperties";
			__tmp37.SetClassLazy(() => MetaClass);
			// __tmp37.Enum = null;
			__tmp37.IsBuilder = false;
			__tmp37.IsReadonly = false;
			__tmp37.Parameters.AddLazy(() => __tmp50);
			__tmp37.SetReturnTypeLazy(() => __tmp49);
			__tmp50.SetTypeLazy(() => Bool);
			__tmp50.Documentation = null;
			__tmp50.Name = "includeSelf";
			__tmp50.SetOperationLazy(() => __tmp37);
			__tmp38.Documentation = null;
			__tmp38.Name = "GetAllSuperOperations";
			__tmp38.SetClassLazy(() => MetaClass);
			// __tmp38.Enum = null;
			__tmp38.IsBuilder = false;
			__tmp38.IsReadonly = false;
			__tmp38.Parameters.AddLazy(() => __tmp52);
			__tmp38.SetReturnTypeLazy(() => __tmp51);
			__tmp52.SetTypeLazy(() => Bool);
			__tmp52.Documentation = null;
			__tmp52.Name = "includeSelf";
			__tmp52.SetOperationLazy(() => __tmp38);
			__tmp39.Documentation = null;
			__tmp39.Name = "GetAllProperties";
			__tmp39.SetClassLazy(() => MetaClass);
			// __tmp39.Enum = null;
			__tmp39.IsBuilder = false;
			__tmp39.IsReadonly = false;
			__tmp39.SetReturnTypeLazy(() => __tmp53);
			__tmp40.Documentation = null;
			__tmp40.Name = "GetAllOperations";
			__tmp40.SetClassLazy(() => MetaClass);
			// __tmp40.Enum = null;
			__tmp40.IsBuilder = false;
			__tmp40.IsReadonly = false;
			__tmp40.SetReturnTypeLazy(() => __tmp54);
			__tmp41.Documentation = null;
			__tmp41.Name = "GetAllFinalProperties";
			__tmp41.SetClassLazy(() => MetaClass);
			// __tmp41.Enum = null;
			__tmp41.IsBuilder = false;
			__tmp41.IsReadonly = false;
			__tmp41.SetReturnTypeLazy(() => __tmp55);
			__tmp42.Documentation = null;
			__tmp42.Name = "GetAllFinalOperations";
			__tmp42.SetClassLazy(() => MetaClass);
			// __tmp42.Enum = null;
			__tmp42.IsBuilder = false;
			__tmp42.IsReadonly = false;
			__tmp42.SetReturnTypeLazy(() => __tmp56);
			MetaOperation.Documentation = null;
			MetaOperation.Name = "MetaOperation";
			MetaOperation.SetNamespaceLazy(() => __tmp4);
			MetaOperation.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.MethodSymbol);
			MetaOperation.IsAbstract = false;
			MetaOperation.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Class);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Enum);
			MetaOperation.Properties.AddLazy(() => MetaOperation_IsBuilder);
			MetaOperation.Properties.AddLazy(() => MetaOperation_IsReadonly);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Parameters);
			MetaOperation.Properties.AddLazy(() => MetaOperation_ReturnType);
			MetaOperation.Operations.AddLazy(() => __tmp57);
			MetaOperation_Class.SetTypeLazy(() => MetaClass);
			MetaOperation_Class.Documentation = null;
			MetaOperation_Class.Name = "Class";
			MetaOperation_Class.SymbolProperty = null;
			MetaOperation_Class.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaOperation_Class.SetClassLazy(() => MetaOperation);
			MetaOperation_Class.DefaultValue = null;
			MetaOperation_Class.IsContainment = false;
			MetaOperation_Class.OppositeProperties.AddLazy(() => MetaClass_Operations);
			MetaOperation_Enum.SetTypeLazy(() => MetaEnum);
			MetaOperation_Enum.Documentation = null;
			MetaOperation_Enum.Name = "Enum";
			MetaOperation_Enum.SymbolProperty = null;
			MetaOperation_Enum.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaOperation_Enum.SetClassLazy(() => MetaOperation);
			MetaOperation_Enum.DefaultValue = null;
			MetaOperation_Enum.IsContainment = false;
			MetaOperation_Enum.OppositeProperties.AddLazy(() => MetaEnum_Operations);
			MetaOperation_IsBuilder.SetTypeLazy(() => Bool);
			MetaOperation_IsBuilder.Documentation = null;
			MetaOperation_IsBuilder.Name = "IsBuilder";
			MetaOperation_IsBuilder.SymbolProperty = null;
			MetaOperation_IsBuilder.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaOperation_IsBuilder.SetClassLazy(() => MetaOperation);
			MetaOperation_IsBuilder.DefaultValue = null;
			MetaOperation_IsBuilder.IsContainment = false;
			MetaOperation_IsReadonly.SetTypeLazy(() => Bool);
			MetaOperation_IsReadonly.Documentation = null;
			MetaOperation_IsReadonly.Name = "IsReadonly";
			MetaOperation_IsReadonly.SymbolProperty = null;
			MetaOperation_IsReadonly.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaOperation_IsReadonly.SetClassLazy(() => MetaOperation);
			MetaOperation_IsReadonly.DefaultValue = null;
			MetaOperation_IsReadonly.IsContainment = false;
			MetaOperation_Parameters.SetTypeLazy(() => __tmp58);
			MetaOperation_Parameters.Documentation = null;
			MetaOperation_Parameters.Name = "Parameters";
			MetaOperation_Parameters.SymbolProperty = "Members";
			MetaOperation_Parameters.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaOperation_Parameters.SetClassLazy(() => MetaOperation);
			MetaOperation_Parameters.DefaultValue = null;
			MetaOperation_Parameters.IsContainment = true;
			MetaOperation_Parameters.OppositeProperties.AddLazy(() => MetaParameter_Operation);
			MetaOperation_ReturnType.SetTypeLazy(() => MetaType);
			MetaOperation_ReturnType.Documentation = null;
			MetaOperation_ReturnType.Name = "ReturnType";
			MetaOperation_ReturnType.SymbolProperty = "ReturnType";
			MetaOperation_ReturnType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaOperation_ReturnType.SetClassLazy(() => MetaOperation);
			MetaOperation_ReturnType.DefaultValue = null;
			MetaOperation_ReturnType.IsContainment = false;
			__tmp57.Documentation = null;
			__tmp57.Name = "ConformsTo";
			__tmp57.SetClassLazy(() => MetaOperation);
			// __tmp57.Enum = null;
			__tmp57.IsBuilder = false;
			__tmp57.IsReadonly = false;
			__tmp57.Parameters.AddLazy(() => __tmp59);
			__tmp57.SetReturnTypeLazy(() => Bool);
			__tmp59.SetTypeLazy(() => MetaOperation);
			__tmp59.Documentation = null;
			__tmp59.Name = "operation";
			__tmp59.SetOperationLazy(() => __tmp57);
			MetaParameter.Documentation = null;
			MetaParameter.Name = "MetaParameter";
			MetaParameter.SetNamespaceLazy(() => __tmp4);
			MetaParameter.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.ParameterSymbol);
			MetaParameter.IsAbstract = false;
			MetaParameter.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaParameter.Properties.AddLazy(() => MetaParameter_Operation);
			MetaParameter_Operation.SetTypeLazy(() => MetaOperation);
			MetaParameter_Operation.Documentation = null;
			MetaParameter_Operation.Name = "Operation";
			MetaParameter_Operation.SymbolProperty = null;
			MetaParameter_Operation.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaParameter_Operation.SetClassLazy(() => MetaParameter);
			MetaParameter_Operation.DefaultValue = null;
			MetaParameter_Operation.IsContainment = false;
			MetaParameter_Operation.OppositeProperties.AddLazy(() => MetaOperation_Parameters);
			MetaPropertyKind.Documentation = null;
			MetaPropertyKind.Name = "MetaPropertyKind";
			MetaPropertyKind.SetNamespaceLazy(() => __tmp4);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp60);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp61);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp62);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp63);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp64);
			__tmp60.Documentation = null;
			__tmp60.Name = "Normal";
			__tmp60.SetEnumLazy(() => MetaPropertyKind);
			__tmp61.Documentation = null;
			__tmp61.Name = "Readonly";
			__tmp61.SetEnumLazy(() => MetaPropertyKind);
			__tmp62.Documentation = null;
			__tmp62.Name = "Lazy";
			__tmp62.SetEnumLazy(() => MetaPropertyKind);
			__tmp63.Documentation = null;
			__tmp63.Name = "Derived";
			__tmp63.SetEnumLazy(() => MetaPropertyKind);
			__tmp64.Documentation = null;
			__tmp64.Name = "DerivedUnion";
			__tmp64.SetEnumLazy(() => MetaPropertyKind);
			MetaProperty.Documentation = null;
			MetaProperty.Name = "MetaProperty";
			MetaProperty.SetNamespaceLazy(() => __tmp4);
			MetaProperty.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.PropertySymbol);
			MetaProperty.IsAbstract = false;
			MetaProperty.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaProperty.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SymbolProperty);
			MetaProperty.Properties.AddLazy(() => MetaProperty_Kind);
			MetaProperty.Properties.AddLazy(() => MetaProperty_Class);
			MetaProperty.Properties.AddLazy(() => MetaProperty_DefaultValue);
			MetaProperty.Properties.AddLazy(() => MetaProperty_IsContainment);
			MetaProperty.Properties.AddLazy(() => MetaProperty_OppositeProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettingProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefinedProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefiningProperties);
			MetaProperty.Operations.AddLazy(() => __tmp65);
			MetaProperty_SymbolProperty.SetTypeLazy(() => String);
			MetaProperty_SymbolProperty.Documentation = null;
			MetaProperty_SymbolProperty.Name = "SymbolProperty";
			MetaProperty_SymbolProperty.SymbolProperty = null;
			MetaProperty_SymbolProperty.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_SymbolProperty.SetClassLazy(() => MetaProperty);
			MetaProperty_SymbolProperty.DefaultValue = null;
			MetaProperty_SymbolProperty.IsContainment = false;
			MetaProperty_Kind.SetTypeLazy(() => MetaPropertyKind);
			MetaProperty_Kind.Documentation = null;
			MetaProperty_Kind.Name = "Kind";
			MetaProperty_Kind.SymbolProperty = null;
			MetaProperty_Kind.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_Kind.SetClassLazy(() => MetaProperty);
			MetaProperty_Kind.DefaultValue = null;
			MetaProperty_Kind.IsContainment = false;
			MetaProperty_Class.SetTypeLazy(() => MetaClass);
			MetaProperty_Class.Documentation = null;
			MetaProperty_Class.Name = "Class";
			MetaProperty_Class.SymbolProperty = null;
			MetaProperty_Class.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_Class.SetClassLazy(() => MetaProperty);
			MetaProperty_Class.DefaultValue = null;
			MetaProperty_Class.IsContainment = false;
			MetaProperty_Class.OppositeProperties.AddLazy(() => MetaClass_Properties);
			MetaProperty_DefaultValue.SetTypeLazy(() => String);
			MetaProperty_DefaultValue.Documentation = null;
			MetaProperty_DefaultValue.Name = "DefaultValue";
			MetaProperty_DefaultValue.SymbolProperty = null;
			MetaProperty_DefaultValue.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_DefaultValue.SetClassLazy(() => MetaProperty);
			MetaProperty_DefaultValue.DefaultValue = null;
			MetaProperty_DefaultValue.IsContainment = false;
			MetaProperty_IsContainment.SetTypeLazy(() => Bool);
			MetaProperty_IsContainment.Documentation = null;
			MetaProperty_IsContainment.Name = "IsContainment";
			MetaProperty_IsContainment.SymbolProperty = null;
			MetaProperty_IsContainment.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_IsContainment.SetClassLazy(() => MetaProperty);
			MetaProperty_IsContainment.DefaultValue = null;
			MetaProperty_IsContainment.IsContainment = false;
			MetaProperty_OppositeProperties.SetTypeLazy(() => __tmp66);
			MetaProperty_OppositeProperties.Documentation = null;
			MetaProperty_OppositeProperties.Name = "OppositeProperties";
			MetaProperty_OppositeProperties.SymbolProperty = null;
			MetaProperty_OppositeProperties.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_OppositeProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_OppositeProperties.DefaultValue = null;
			MetaProperty_OppositeProperties.IsContainment = false;
			MetaProperty_OppositeProperties.OppositeProperties.AddLazy(() => MetaProperty_OppositeProperties);
			MetaProperty_SubsettedProperties.SetTypeLazy(() => __tmp67);
			MetaProperty_SubsettedProperties.Documentation = null;
			MetaProperty_SubsettedProperties.Name = "SubsettedProperties";
			MetaProperty_SubsettedProperties.SymbolProperty = null;
			MetaProperty_SubsettedProperties.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_SubsettedProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_SubsettedProperties.DefaultValue = null;
			MetaProperty_SubsettedProperties.IsContainment = false;
			MetaProperty_SubsettedProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettingProperties);
			MetaProperty_SubsettingProperties.SetTypeLazy(() => __tmp68);
			MetaProperty_SubsettingProperties.Documentation = null;
			MetaProperty_SubsettingProperties.Name = "SubsettingProperties";
			MetaProperty_SubsettingProperties.SymbolProperty = null;
			MetaProperty_SubsettingProperties.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_SubsettingProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_SubsettingProperties.DefaultValue = null;
			MetaProperty_SubsettingProperties.IsContainment = false;
			MetaProperty_SubsettingProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty_RedefinedProperties.SetTypeLazy(() => __tmp69);
			MetaProperty_RedefinedProperties.Documentation = null;
			MetaProperty_RedefinedProperties.Name = "RedefinedProperties";
			MetaProperty_RedefinedProperties.SymbolProperty = null;
			MetaProperty_RedefinedProperties.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_RedefinedProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_RedefinedProperties.DefaultValue = null;
			MetaProperty_RedefinedProperties.IsContainment = false;
			MetaProperty_RedefinedProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefiningProperties);
			MetaProperty_RedefiningProperties.SetTypeLazy(() => __tmp70);
			MetaProperty_RedefiningProperties.Documentation = null;
			MetaProperty_RedefiningProperties.Name = "RedefiningProperties";
			MetaProperty_RedefiningProperties.SymbolProperty = null;
			MetaProperty_RedefiningProperties.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			MetaProperty_RedefiningProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_RedefiningProperties.DefaultValue = null;
			MetaProperty_RedefiningProperties.IsContainment = false;
			MetaProperty_RedefiningProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefinedProperties);
			__tmp65.Documentation = null;
			__tmp65.Name = "ConformsTo";
			__tmp65.SetClassLazy(() => MetaProperty);
			// __tmp65.Enum = null;
			__tmp65.IsBuilder = false;
			__tmp65.IsReadonly = false;
			__tmp65.Parameters.AddLazy(() => __tmp71);
			__tmp65.SetReturnTypeLazy(() => Bool);
			__tmp71.SetTypeLazy(() => MetaProperty);
			__tmp71.Documentation = null;
			__tmp71.Name = "property";
			__tmp71.SetOperationLazy(() => __tmp65);
			__tmp17.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp17.SetInnerTypeLazy(() => MetaAttribute);
			__tmp20.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp20.SetInnerTypeLazy(() => MetaDeclaration);
			__tmp31.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp31.SetInnerTypeLazy(() => MetaEnumLiteral);
			__tmp32.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp32.SetInnerTypeLazy(() => MetaOperation);
			__tmp43.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp43.SetInnerTypeLazy(() => MetaClass);
			__tmp44.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp44.SetInnerTypeLazy(() => MetaProperty);
			__tmp45.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp45.SetInnerTypeLazy(() => MetaOperation);
			__tmp47.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp47.SetInnerTypeLazy(() => MetaClass);
			__tmp49.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp49.SetInnerTypeLazy(() => MetaProperty);
			__tmp51.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp51.SetInnerTypeLazy(() => MetaOperation);
			__tmp53.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp53.SetInnerTypeLazy(() => MetaProperty);
			__tmp54.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp54.SetInnerTypeLazy(() => MetaOperation);
			__tmp55.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp55.SetInnerTypeLazy(() => MetaProperty);
			__tmp56.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp56.SetInnerTypeLazy(() => MetaOperation);
			__tmp58.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp58.SetInnerTypeLazy(() => MetaParameter);
			__tmp66.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp66.SetInnerTypeLazy(() => MetaProperty);
			__tmp67.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp67.SetInnerTypeLazy(() => MetaProperty);
			__tmp68.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp68.SetInnerTypeLazy(() => MetaProperty);
			__tmp69.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp69.SetInnerTypeLazy(() => MetaProperty);
			__tmp70.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp70.SetInnerTypeLazy(() => MetaProperty);
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.Languages.Meta.Model.MetaImplementation to provide custom
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
		/// Implements the operation: MetaType.ConformsTo()
		/// </summary>
		public virtual bool MetaType_ConformsTo(MetaType _this, MetaType type)
		{
			return this.MetaType_ConformsTo(_this.ToMutable(), type.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaTypeBuilder.ConformsTo()
		/// </summary>
		public abstract bool MetaType_ConformsTo(MetaTypeBuilder _this, MetaTypeBuilder type);
	
	
		/// <summary>
		/// Implements the constructor: MetaNamedType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaType</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		/// </ul>
		public virtual void MetaNamedType(MetaNamedTypeBuilder _this)
		{
			this.CallMetaNamedTypeSuperConstructors(_this);
			_this.SetFullNameLazy(this.MetaDeclaration_ComputeProperty_FullName);
			_this.SetMetaModelLazy(this.MetaDeclaration_ComputeProperty_MetaModel);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaNamedType
		/// </summary>
		protected virtual void CallMetaNamedTypeSuperConstructors(MetaNamedTypeBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: MetaAttribute()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		///     <li>MetaNamedType</li>
		/// </ul>
		public virtual void MetaAttribute(MetaAttributeBuilder _this)
		{
			this.CallMetaAttributeSuperConstructors(_this);
			_this.SetFullNameLazy(this.MetaDeclaration_ComputeProperty_FullName);
			_this.SetMetaModelLazy(this.MetaDeclaration_ComputeProperty_MetaModel);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaAttribute
		/// </summary>
		protected virtual void CallMetaAttributeSuperConstructors(MetaAttributeBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
			this.MetaNamedType(_this);
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
		///     <li>FullName</li>
		/// </ul>
		public virtual void MetaDeclaration(MetaDeclarationBuilder _this)
		{
			this.CallMetaDeclarationSuperConstructors(_this);
			_this.SetFullNameLazy(this.MetaDeclaration_ComputeProperty_FullName);
			_this.SetMetaModelLazy(this.MetaDeclaration_ComputeProperty_MetaModel);
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
		/// Computes the value of the property: MetaDeclaration.MetaModel
		/// </summary	
		public abstract MetaModelBuilder MetaDeclaration_ComputeProperty_MetaModel(MetaDeclarationBuilder _this);
		/// <summary>
		/// Computes the value of the property: MetaDeclaration.FullName
		/// </summary	
		public abstract String MetaDeclaration_ComputeProperty_FullName(MetaDeclarationBuilder _this);
	
	
	
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
			_this.SetFullNameLazy(this.MetaDeclaration_ComputeProperty_FullName);
			_this.SetMetaModelLazy(this.MetaDeclaration_ComputeProperty_MetaModel);
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
		/// Implements the operation: MetaCollectionType.ConformsTo()
		/// </summary>
		public virtual bool MetaCollectionType_ConformsTo(MetaCollectionType _this, MetaType type)
		{
			return this.MetaCollectionType_ConformsTo(_this.ToMutable(), type.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaCollectionTypeBuilder.ConformsTo()
		/// </summary>
		public abstract bool MetaCollectionType_ConformsTo(MetaCollectionTypeBuilder _this, MetaTypeBuilder type);
	
	
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
		/// Implements the operation: MetaNullableType.ConformsTo()
		/// </summary>
		public virtual bool MetaNullableType_ConformsTo(MetaNullableType _this, MetaType type)
		{
			return this.MetaNullableType_ConformsTo(_this.ToMutable(), type.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaNullableTypeBuilder.ConformsTo()
		/// </summary>
		public abstract bool MetaNullableType_ConformsTo(MetaNullableTypeBuilder _this, MetaTypeBuilder type);
	
	
		/// <summary>
		/// Implements the constructor: MetaPrimitiveType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		///     <li>MetaNamedType</li>
		/// </ul>
		public virtual void MetaPrimitiveType(MetaPrimitiveTypeBuilder _this)
		{
			this.CallMetaPrimitiveTypeSuperConstructors(_this);
			_this.SetFullNameLazy(this.MetaDeclaration_ComputeProperty_FullName);
			_this.SetMetaModelLazy(this.MetaDeclaration_ComputeProperty_MetaModel);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaPrimitiveType
		/// </summary>
		protected virtual void CallMetaPrimitiveTypeSuperConstructors(MetaPrimitiveTypeBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
			this.MetaNamedType(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: MetaPrimitiveType.ConformsTo()
		/// </summary>
		public virtual bool MetaPrimitiveType_ConformsTo(MetaPrimitiveType _this, MetaType type)
		{
			return this.MetaPrimitiveType_ConformsTo(_this.ToMutable(), type.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaPrimitiveTypeBuilder.ConformsTo()
		/// </summary>
		public abstract bool MetaPrimitiveType_ConformsTo(MetaPrimitiveTypeBuilder _this, MetaTypeBuilder type);
	
	
		/// <summary>
		/// Implements the constructor: MetaEnum()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		///     <li>MetaNamedType</li>
		/// </ul>
		public virtual void MetaEnum(MetaEnumBuilder _this)
		{
			this.CallMetaEnumSuperConstructors(_this);
			_this.SetFullNameLazy(this.MetaDeclaration_ComputeProperty_FullName);
			_this.SetMetaModelLazy(this.MetaDeclaration_ComputeProperty_MetaModel);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaEnum
		/// </summary>
		protected virtual void CallMetaEnumSuperConstructors(MetaEnumBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
			this.MetaNamedType(_this);
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
		///     <li>MetaNamedType</li>
		///     <li>MetaTypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaNamedType</li>
		/// </ul>
		/// Initializes the following readonly properties:
		/// <ul>
		///     <li>Value</li>
		/// </ul>
		public virtual void MetaConstant(MetaConstantBuilder _this)
		{
			this.CallMetaConstantSuperConstructors(_this);
			_this.SetFullNameLazy(this.MetaDeclaration_ComputeProperty_FullName);
			_this.SetMetaModelLazy(this.MetaDeclaration_ComputeProperty_MetaModel);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaConstant
		/// </summary>
		protected virtual void CallMetaConstantSuperConstructors(MetaConstantBuilder _this)
		{
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
			this.MetaTypedElement(_this);
			this.MetaNamedType(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: MetaConstant.ConformsTo()
		/// </summary>
		public virtual bool MetaConstant_ConformsTo(MetaConstant _this, MetaType type)
		{
			return this.MetaConstant_ConformsTo(_this.ToMutable(), type.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaConstantBuilder.ConformsTo()
		/// </summary>
		public abstract bool MetaConstant_ConformsTo(MetaConstantBuilder _this, MetaTypeBuilder type);
	
	
		/// <summary>
		/// Implements the constructor: MetaClass()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaElement</li>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
		///     <li>MetaNamedType</li>
		/// </ul>
		public virtual void MetaClass(MetaClassBuilder _this)
		{
			this.CallMetaClassSuperConstructors(_this);
			_this.SetFullNameLazy(this.MetaDeclaration_ComputeProperty_FullName);
			_this.SetMetaModelLazy(this.MetaDeclaration_ComputeProperty_MetaModel);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaClass
		/// </summary>
		protected virtual void CallMetaClassSuperConstructors(MetaClassBuilder _this)
		{
			this.MetaElement(_this);
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
			this.MetaNamedType(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: MetaClass.ConformsTo()
		/// </summary>
		public virtual bool MetaClass_ConformsTo(MetaClass _this, MetaType type)
		{
			return this.MetaClass_ConformsTo(_this.ToMutable(), type.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaClassBuilder.ConformsTo()
		/// </summary>
		public abstract bool MetaClass_ConformsTo(MetaClassBuilder _this, MetaTypeBuilder type);
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperClasses()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass _this, bool includeSelf)
		{
			return this.MetaClass_GetAllSuperClasses(_this.ToMutable(), includeSelf).Select(obj => obj.ToImmutable()).ToList();
		}
	
		/// <summary>
		/// Implements the operation: MetaClassBuilder.GetAllSuperClasses()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<MetaClassBuilder> MetaClass_GetAllSuperClasses(MetaClassBuilder _this, bool includeSelf);
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperProperties()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass_GetAllSuperProperties(MetaClass _this, bool includeSelf)
		{
			return this.MetaClass_GetAllSuperProperties(_this.ToMutable(), includeSelf).Select(obj => obj.ToImmutable()).ToList();
		}
	
		/// <summary>
		/// Implements the operation: MetaClassBuilder.GetAllSuperProperties()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClass_GetAllSuperProperties(MetaClassBuilder _this, bool includeSelf);
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperOperations()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass_GetAllSuperOperations(MetaClass _this, bool includeSelf)
		{
			return this.MetaClass_GetAllSuperOperations(_this.ToMutable(), includeSelf).Select(obj => obj.ToImmutable()).ToList();
		}
	
		/// <summary>
		/// Implements the operation: MetaClassBuilder.GetAllSuperOperations()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClass_GetAllSuperOperations(MetaClassBuilder _this, bool includeSelf);
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllProperties()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass_GetAllProperties(MetaClass _this)
		{
			return this.MetaClass_GetAllProperties(_this.ToMutable()).Select(obj => obj.ToImmutable()).ToList();
		}
	
		/// <summary>
		/// Implements the operation: MetaClassBuilder.GetAllProperties()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClass_GetAllProperties(MetaClassBuilder _this);
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllOperations()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass_GetAllOperations(MetaClass _this)
		{
			return this.MetaClass_GetAllOperations(_this.ToMutable()).Select(obj => obj.ToImmutable()).ToList();
		}
	
		/// <summary>
		/// Implements the operation: MetaClassBuilder.GetAllOperations()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClass_GetAllOperations(MetaClassBuilder _this);
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllFinalProperties()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass_GetAllFinalProperties(MetaClass _this)
		{
			return this.MetaClass_GetAllFinalProperties(_this.ToMutable()).Select(obj => obj.ToImmutable()).ToList();
		}
	
		/// <summary>
		/// Implements the operation: MetaClassBuilder.GetAllFinalProperties()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClass_GetAllFinalProperties(MetaClassBuilder _this);
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllFinalOperations()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass_GetAllFinalOperations(MetaClass _this)
		{
			return this.MetaClass_GetAllFinalOperations(_this.ToMutable()).Select(obj => obj.ToImmutable()).ToList();
		}
	
		/// <summary>
		/// Implements the operation: MetaClassBuilder.GetAllFinalOperations()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClass_GetAllFinalOperations(MetaClassBuilder _this);
	
	
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
		/// Implements the operation: MetaOperation.ConformsTo()
		/// </summary>
		public virtual bool MetaOperation_ConformsTo(MetaOperation _this, MetaOperation operation)
		{
			return this.MetaOperation_ConformsTo(_this.ToMutable(), operation.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaOperationBuilder.ConformsTo()
		/// </summary>
		public abstract bool MetaOperation_ConformsTo(MetaOperationBuilder _this, MetaOperationBuilder operation);
	
	
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
	
	
	
		/// <summary>
		/// Implements the operation: MetaProperty.ConformsTo()
		/// </summary>
		public virtual bool MetaProperty_ConformsTo(MetaProperty _this, MetaProperty property)
		{
			return this.MetaProperty_ConformsTo(_this.ToMutable(), property.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaPropertyBuilder.ConformsTo()
		/// </summary>
		public abstract bool MetaProperty_ConformsTo(MetaPropertyBuilder _this, MetaPropertyBuilder property);
	
	
	
	}

	internal class MetaImplementationProvider
	{
		// If there is a compile error at this line, create a new class called MetaImplementation
		// which is a subclass of global::MetaDslx.Languages.Meta.Model.MetaImplementationBase:
		private static MetaImplementation implementation = new MetaImplementation();
	
		public static MetaImplementation Implementation
		{
			get { return implementation; }
		}
	}
}


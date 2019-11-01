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
		public static readonly MetaPrimitiveType ModelObject;
		public static readonly MetaAttribute NameAttribute;
		public static readonly MetaAttribute TypeAttribute;
		public static readonly MetaAttribute ScopeAttribute;
		public static readonly MetaAttribute BaseScopeAttribute;
		public static readonly MetaAttribute LocalScopeAttribute;
	
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
		public static readonly MetaClass MetaEnum;
		public static readonly MetaProperty MetaEnum_EnumLiterals;
		public static readonly MetaProperty MetaEnum_Operations;
		public static readonly MetaClass MetaEnumLiteral;
		public static readonly MetaProperty MetaEnumLiteral_Enum;
		public static readonly MetaClass MetaConstant;
		public static readonly MetaProperty MetaConstant_DotNetName;
		public static readonly MetaProperty MetaConstant_Value;
		public static readonly MetaClass MetaClass;
		public static readonly MetaProperty MetaClass_IsAbstract;
		public static readonly MetaProperty MetaClass_SuperClasses;
		public static readonly MetaProperty MetaClass_Properties;
		public static readonly MetaProperty MetaClass_Operations;
		public static readonly MetaClass MetaOperation;
		public static readonly MetaProperty MetaOperation_Parent;
		public static readonly MetaProperty MetaOperation_IsBuilder;
		public static readonly MetaProperty MetaOperation_IsReadonly;
		public static readonly MetaProperty MetaOperation_Parameters;
		public static readonly MetaProperty MetaOperation_ReturnType;
		public static readonly MetaClass MetaParameter;
		public static readonly MetaProperty MetaParameter_Operation;
		public static readonly MetaClass MetaProperty;
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
			ModelObject = MetaBuilderInstance.instance.ModelObject.ToImmutable(MModel);
			NameAttribute = MetaBuilderInstance.instance.NameAttribute.ToImmutable(MModel);
			TypeAttribute = MetaBuilderInstance.instance.TypeAttribute.ToImmutable(MModel);
			ScopeAttribute = MetaBuilderInstance.instance.ScopeAttribute.ToImmutable(MModel);
			BaseScopeAttribute = MetaBuilderInstance.instance.BaseScopeAttribute.ToImmutable(MModel);
			LocalScopeAttribute = MetaBuilderInstance.instance.LocalScopeAttribute.ToImmutable(MModel);
	
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
			MetaEnum = MetaBuilderInstance.instance.MetaEnum.ToImmutable(MModel);
			MetaEnum_EnumLiterals = MetaBuilderInstance.instance.MetaEnum_EnumLiterals.ToImmutable(MModel);
			MetaEnum_Operations = MetaBuilderInstance.instance.MetaEnum_Operations.ToImmutable(MModel);
			MetaEnumLiteral = MetaBuilderInstance.instance.MetaEnumLiteral.ToImmutable(MModel);
			MetaEnumLiteral_Enum = MetaBuilderInstance.instance.MetaEnumLiteral_Enum.ToImmutable(MModel);
			MetaConstant = MetaBuilderInstance.instance.MetaConstant.ToImmutable(MModel);
			MetaConstant_DotNetName = MetaBuilderInstance.instance.MetaConstant_DotNetName.ToImmutable(MModel);
			MetaConstant_Value = MetaBuilderInstance.instance.MetaConstant_Value.ToImmutable(MModel);
			MetaClass = MetaBuilderInstance.instance.MetaClass.ToImmutable(MModel);
			MetaClass_IsAbstract = MetaBuilderInstance.instance.MetaClass_IsAbstract.ToImmutable(MModel);
			MetaClass_SuperClasses = MetaBuilderInstance.instance.MetaClass_SuperClasses.ToImmutable(MModel);
			MetaClass_Properties = MetaBuilderInstance.instance.MetaClass_Properties.ToImmutable(MModel);
			MetaClass_Operations = MetaBuilderInstance.instance.MetaClass_Operations.ToImmutable(MModel);
			MetaOperation = MetaBuilderInstance.instance.MetaOperation.ToImmutable(MModel);
			MetaOperation_Parent = MetaBuilderInstance.instance.MetaOperation_Parent.ToImmutable(MModel);
			MetaOperation_IsBuilder = MetaBuilderInstance.instance.MetaOperation_IsBuilder.ToImmutable(MModel);
			MetaOperation_IsReadonly = MetaBuilderInstance.instance.MetaOperation_IsReadonly.ToImmutable(MModel);
			MetaOperation_Parameters = MetaBuilderInstance.instance.MetaOperation_Parameters.ToImmutable(MModel);
			MetaOperation_ReturnType = MetaBuilderInstance.instance.MetaOperation_ReturnType.ToImmutable(MModel);
			MetaParameter = MetaBuilderInstance.instance.MetaParameter.ToImmutable(MModel);
			MetaParameter_Operation = MetaBuilderInstance.instance.MetaParameter_Operation.ToImmutable(MModel);
			MetaProperty = MetaBuilderInstance.instance.MetaProperty.ToImmutable(MModel);
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
					throw new global::MetaDslx.Modeling.ModelException(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of MetaElement.
		/// </summary>
		public MetaElementBuilder MetaElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaElementId());
			return (MetaElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaDocumentedElement.
		/// </summary>
		public MetaDocumentedElementBuilder MetaDocumentedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaDocumentedElementId());
			return (MetaDocumentedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNamedElement.
		/// </summary>
		public MetaNamedElementBuilder MetaNamedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaNamedElementId());
			return (MetaNamedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaTypedElement.
		/// </summary>
		public MetaTypedElementBuilder MetaTypedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaTypedElementId());
			return (MetaTypedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of MetaType.
		/// </summary>
		public MetaTypeBuilder MetaType()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaTypeId());
			return (MetaTypeBuilder)obj;
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
		/// Creates a new instance of MetaDeclaration.
		/// </summary>
		public MetaDeclarationBuilder MetaDeclaration()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new MetaDeclarationId());
			return (MetaDeclarationBuilder)obj;
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
		string Documentation { get; }
	
		global::System.Collections.Generic.IReadOnlyList<string> GetDocumentationLines();
	
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
		string Documentation { get; set; }
		void SetDocumentationLazy(global::System.Func<string> lazy);
		void SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy);
		void SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy);
	
		global::System.Collections.Generic.IReadOnlyList<string> GetDocumentationLines();
	
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
		string Name { get; }
	
	
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
		string Name { get; set; }
		void SetNameLazy(global::System.Func<string> lazy);
		void SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy);
		void SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy);
	
	
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
	
	public interface MetaNamedType : MetaType, MetaNamedElement
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
	
	public interface MetaNamedTypeBuilder : MetaTypeBuilder, MetaNamedElementBuilder
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
	
	public interface MetaAttribute : MetaNamedElement
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
	
	public interface MetaAttributeBuilder : MetaNamedElementBuilder
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
		string FullName { get; }
	
	
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
		string FullName { get; }
		void SetFullNameLazy(global::System.Func<string> lazy);
		void SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy);
		void SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy);
	
	
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
		new string Uri { get; }
		new string Prefix { get; }
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
		new string Uri { get; set; }
		void SetUriLazy(global::System.Func<string> lazy);
		void SetUriLazy(global::System.Func<MetaModelBuilder, string> lazy);
		void SetUriLazy(global::System.Func<MetaModel, string> immutableLazy, global::System.Func<MetaModelBuilder, string> mutableLazy);
		new string Prefix { get; set; }
		void SetPrefixLazy(global::System.Func<string> lazy);
		void SetPrefixLazy(global::System.Func<MetaModelBuilder, string> lazy);
		void SetPrefixLazy(global::System.Func<MetaModel, string> immutableLazy, global::System.Func<MetaModelBuilder, string> mutableLazy);
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
	
	public interface MetaPrimitiveType : MetaDeclaration, MetaType
	{
	
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
	
	public interface MetaPrimitiveTypeBuilder : MetaDeclarationBuilder, MetaTypeBuilder
	{
	
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
	
	public interface MetaEnum : MetaDeclaration, MetaType
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
	
	public interface MetaEnumBuilder : MetaDeclarationBuilder, MetaTypeBuilder
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
	
	public interface MetaConstant : MetaDeclaration, MetaTypedElement, MetaType
	{
		string DotNetName { get; }
		global::MetaDslx.Modeling.IModelObject Value { get; }
	
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
	
	public interface MetaConstantBuilder : MetaDeclarationBuilder, MetaTypedElementBuilder, MetaTypeBuilder
	{
		string DotNetName { get; set; }
		void SetDotNetNameLazy(global::System.Func<string> lazy);
		void SetDotNetNameLazy(global::System.Func<MetaConstantBuilder, string> lazy);
		void SetDotNetNameLazy(global::System.Func<MetaConstant, string> immutableLazy, global::System.Func<MetaConstantBuilder, string> mutableLazy);
		global::MetaDslx.Modeling.IModelObject Value { get; }
		void SetValueLazy(global::System.Func<global::MetaDslx.Modeling.IModelObject> lazy);
		void SetValueLazy(global::System.Func<MetaConstantBuilder, global::MetaDslx.Modeling.IModelObject> lazy);
		void SetValueLazy(global::System.Func<MetaConstant, global::MetaDslx.Modeling.IModelObject> immutableLazy, global::System.Func<MetaConstantBuilder, global::MetaDslx.Modeling.IModelObject> mutableLazy);
	
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
	
	public interface MetaClass : MetaDeclaration, MetaType
	{
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
	
	public interface MetaClassBuilder : MetaDeclarationBuilder, MetaTypeBuilder
	{
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
		MetaType Parent { get; }
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
		MetaTypeBuilder Parent { get; set; }
		void SetParentLazy(global::System.Func<MetaTypeBuilder> lazy);
		void SetParentLazy(global::System.Func<MetaOperationBuilder, MetaTypeBuilder> lazy);
		void SetParentLazy(global::System.Func<MetaOperation, MetaType> immutableLazy, global::System.Func<MetaOperationBuilder, MetaTypeBuilder> mutableLazy);
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
		MetaPropertyKind Kind { get; }
		MetaClass Class { get; }
		string DefaultValue { get; }
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
		MetaPropertyKind Kind { get; set; }
		void SetKindLazy(global::System.Func<MetaPropertyKind> lazy);
		void SetKindLazy(global::System.Func<MetaPropertyBuilder, MetaPropertyKind> lazy);
		void SetKindLazy(global::System.Func<MetaProperty, MetaPropertyKind> immutableLazy, global::System.Func<MetaPropertyBuilder, MetaPropertyKind> mutableLazy);
		MetaClassBuilder Class { get; set; }
		void SetClassLazy(global::System.Func<MetaClassBuilder> lazy);
		void SetClassLazy(global::System.Func<MetaPropertyBuilder, MetaClassBuilder> lazy);
		void SetClassLazy(global::System.Func<MetaProperty, MetaClass> immutableLazy, global::System.Func<MetaPropertyBuilder, MetaClassBuilder> mutableLazy);
		string DefaultValue { get; set; }
		void SetDefaultValueLazy(global::System.Func<string> lazy);
		void SetDefaultValueLazy(global::System.Func<MetaPropertyBuilder, string> lazy);
		void SetDefaultValueLazy(global::System.Func<MetaProperty, string> immutableLazy, global::System.Func<MetaPropertyBuilder, string> mutableLazy);
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
			properties.Add(MetaDescriptor.MetaEnum.EnumLiteralsProperty);
			properties.Add(MetaDescriptor.MetaEnum.OperationsProperty);
			properties.Add(MetaDescriptor.MetaEnumLiteral.EnumProperty);
			properties.Add(MetaDescriptor.MetaConstant.DotNetNameProperty);
			properties.Add(MetaDescriptor.MetaConstant.ValueProperty);
			properties.Add(MetaDescriptor.MetaClass.IsAbstractProperty);
			properties.Add(MetaDescriptor.MetaClass.SuperClassesProperty);
			properties.Add(MetaDescriptor.MetaClass.PropertiesProperty);
			properties.Add(MetaDescriptor.MetaClass.OperationsProperty);
			properties.Add(MetaDescriptor.MetaOperation.ParentProperty);
			properties.Add(MetaDescriptor.MetaOperation.IsBuilderProperty);
			properties.Add(MetaDescriptor.MetaOperation.IsReadonlyProperty);
			properties.Add(MetaDescriptor.MetaOperation.ParametersProperty);
			properties.Add(MetaDescriptor.MetaOperation.ReturnTypeProperty);
			properties.Add(MetaDescriptor.MetaParameter.OperationProperty);
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
			        immutableType: typeof(string),
			        mutableType: typeof(string),
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
			
			[global::MetaDslx.Modeling.NameAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNamedElement), name: "Name",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
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
			
			[global::MetaDslx.Modeling.TypeAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty TypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaTypedElement), name: "Type",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaTypedElement_Type,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.TypeAttribute]
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
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaNamedTypeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaNamedType), typeof(global::MetaDslx.Languages.Meta.Model.MetaNamedTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaNamedElement) })]
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
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaAttributeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaAttribute), typeof(global::MetaDslx.Languages.Meta.Model.MetaAttributeBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
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
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaDeclaration_FullName,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
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
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaModel), "Namespace")]
			public static readonly global::MetaDslx.Modeling.ModelProperty DefinedMetaModelProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNamespace), name: "DefinedMetaModel",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaModel),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaModelBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNamespace_DefinedMetaModel,
					defaultValue: null);
			
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
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaModel_Uri,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty PrefixProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaModel), name: "Prefix",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
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
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaCollectionType), name: "InnerType",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaCollectionType_InnerType,
					defaultValue: null);
		}
	
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
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNullableType), name: "InnerType",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaNullableType_InnerType,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaPrimitiveTypeId), typeof(global::MetaDslx.Languages.Meta.Model.MetaPrimitiveType), typeof(global::MetaDslx.Languages.Meta.Model.MetaPrimitiveTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaType) })]
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
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaEnumId), typeof(global::MetaDslx.Languages.Meta.Model.MetaEnum), typeof(global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaType) })]
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
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parent")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaEnum), name: "Operations",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperation),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaEnum_Operations,
					defaultValue: null);
		}
	
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
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaConstantId), typeof(global::MetaDslx.Languages.Meta.Model.MetaConstant), typeof(global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaType) })]
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
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaConstant_DotNetName,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaConstant), name: "Value",
			        immutableType: typeof(global::MetaDslx.Modeling.IModelObject),
			        mutableType: typeof(global::MetaDslx.Modeling.IModelObject),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaConstant_Value,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Model.Internal.MetaClassId), typeof(global::MetaDslx.Languages.Meta.Model.MetaClass), typeof(global::MetaDslx.Languages.Meta.Model.MetaClassBuilder), BaseDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaType) })]
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
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "IsAbstract",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass_IsAbstract,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.BaseScopeAttribute]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty SuperClassesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "SuperClasses",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaClass),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass_SuperClasses,
					defaultValue: null);
			
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
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parent")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "Operations",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperation),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaClass_Operations,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.LocalScopeAttribute]
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
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "Operations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ParentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "Parent",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation_Parent,
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
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "ReturnType",
			        immutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaType),
			        mutableType: typeof(global::MetaDslx.Languages.Meta.Model.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Meta.Model.MetaInstance.MetaOperation_ReturnType,
					defaultValue: null);
		}
	
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
			        immutableType: typeof(string),
			        mutableType: typeof(string),
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaElement_MValidate(this, diagnostics);
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
		private string documentation0;
	
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaDocumentedElement_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaNamedElement_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaTypedElement_MValidate(this, diagnostics);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaType_MValidate(this, diagnostics);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaNamedType_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
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
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaAttribute_MValidate(this, diagnostics);
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
	
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaDeclaration_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
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
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public MetaModel DefinedMetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamespace.DefinedMetaModelProperty, ref definedMetaModel0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaDeclaration> Declarations
		{
		    get { return this.GetList<MetaDeclaration>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaNamespace_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
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
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string uri0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string prefix0;
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public string Uri
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.UriProperty, ref uri0); }
		}
	
		
		public string Prefix
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.PrefixProperty, ref prefix0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.NamespaceProperty, ref namespace0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaModel_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Uri
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.UriProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.UriProperty, value); }
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.UriProperty, lazy);
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<MetaModelBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.UriProperty, lazy);
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<MetaModel, string> immutableLazy, global::System.Func<MetaModelBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.UriProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Prefix
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.PrefixProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaModel.PrefixProperty, value); }
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.PrefixProperty, lazy);
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<MetaModelBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaModel.PrefixProperty, lazy);
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<MetaModel, string> immutableLazy, global::System.Func<MetaModelBuilder, string> mutableLazy)
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaCollectionType_MValidate(this, diagnostics);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaNullableType_MValidate(this, diagnostics);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
	
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaPrimitiveType_MValidate(this, diagnostics);
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
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
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaEnumLiteral> EnumLiterals
		{
		    get { return this.GetList<MetaEnumLiteral>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaEnum_MValidate(this, diagnostics);
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
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
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaEnum Enum
		{
		    get { return this.GetReference<MetaEnum>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaEnumLiteral.EnumProperty, ref enum0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaEnumLiteral_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string dotNetName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.IModelObject value0;
	
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
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public string DotNetName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.DotNetNameProperty, ref dotNetName0); }
		}
	
		
		public global::MetaDslx.Modeling.IModelObject Value
		{
		    get { return this.GetReference<global::MetaDslx.Modeling.IModelObject>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.ValueProperty, ref value0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaConstant_MValidate(this, diagnostics);
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
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
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
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.DotNetNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.DotNetNameProperty, value); }
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.DotNetNameProperty, lazy);
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<MetaConstantBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.DotNetNameProperty, lazy);
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<MetaConstant, string> immutableLazy, global::System.Func<MetaConstantBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.DotNetNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.IModelObject Value
		{
			get { return this.GetReference<global::MetaDslx.Modeling.IModelObject>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaConstant.ValueProperty); }
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<global::MetaDslx.Modeling.IModelObject> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.ValueProperty, lazy);
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<MetaConstantBuilder, global::MetaDslx.Modeling.IModelObject> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.ValueProperty, lazy);
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<MetaConstant, global::MetaDslx.Modeling.IModelObject> immutableLazy, global::System.Func<MetaConstantBuilder, global::MetaDslx.Modeling.IModelObject> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaConstant.ValueProperty, immutableLazy, mutableLazy);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaClass_MValidate(this, diagnostics);
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
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
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType parent0;
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaType Parent
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ParentProperty, ref parent0); }
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaOperation_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Parent
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ParentProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaOperation.ParentProperty, value); }
		}
		
		void MetaOperationBuilder.SetParentLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ParentProperty, lazy);
		}
		
		void MetaOperationBuilder.SetParentLazy(global::System.Func<MetaOperationBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ParentProperty, lazy);
		}
		
		void MetaOperationBuilder.SetParentLazy(global::System.Func<MetaOperation, MetaType> immutableLazy, global::System.Func<MetaOperationBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaOperation.ParentProperty, immutableLazy, mutableLazy);
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaOperation Operation
		{
		    get { return this.GetReference<MetaOperation>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaParameter.OperationProperty, ref operation0); }
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaParameter_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private string defaultValue0;
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaPropertyKind Kind
		{
		    get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.KindProperty, ref kind0); }
		}
	
		
		public MetaClass Class
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.ClassProperty, ref class0); }
		}
	
		
		public string DefaultValue
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.DefaultValueProperty, ref defaultValue0); }
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
			MetaImplementationProvider.Implementation.MetaProperty_MValidate(this, diagnostics);
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
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
	
		
		public string DefaultValue
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.DefaultValueProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Meta.Model.MetaDescriptor.MetaProperty.DefaultValueProperty, value); }
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.DefaultValueProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<MetaPropertyBuilder, string> lazy)
		{
			this.SetLazyReference(MetaDescriptor.MetaProperty.DefaultValueProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<MetaProperty, string> immutableLazy, global::System.Func<MetaPropertyBuilder, string> mutableLazy)
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
	
		
		global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElementBuilder.GetDocumentationLines()
		{
		    return MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
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
		private MetaConstantBuilder __tmp5;
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
		internal MetaClassBuilder MetaElement;
		internal MetaPropertyBuilder MetaElement_Attributes;
		internal MetaClassBuilder MetaDocumentedElement;
		internal MetaPropertyBuilder MetaDocumentedElement_Documentation;
		private MetaOperationBuilder __tmp37;
		internal MetaClassBuilder MetaNamedElement;
		internal MetaPropertyBuilder MetaNamedElement_Name;
		internal MetaClassBuilder MetaTypedElement;
		internal MetaPropertyBuilder MetaTypedElement_Type;
		internal MetaClassBuilder MetaType;
		private MetaOperationBuilder __tmp22;
		private MetaParameterBuilder __tmp34;
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
		private MetaEnumLiteralBuilder __tmp23;
		private MetaEnumLiteralBuilder __tmp24;
		private MetaEnumLiteralBuilder __tmp25;
		private MetaEnumLiteralBuilder __tmp26;
		internal MetaClassBuilder MetaCollectionType;
		internal MetaPropertyBuilder MetaCollectionType_Kind;
		internal MetaPropertyBuilder MetaCollectionType_InnerType;
		private MetaOperationBuilder __tmp38;
		private MetaParameterBuilder __tmp55;
		internal MetaClassBuilder MetaNullableType;
		internal MetaPropertyBuilder MetaNullableType_InnerType;
		private MetaOperationBuilder __tmp21;
		private MetaParameterBuilder __tmp53;
		internal MetaClassBuilder MetaPrimitiveType;
		private MetaOperationBuilder __tmp39;
		private MetaParameterBuilder __tmp40;
		internal MetaClassBuilder MetaEnum;
		internal MetaPropertyBuilder MetaEnum_EnumLiterals;
		internal MetaPropertyBuilder MetaEnum_Operations;
		internal MetaClassBuilder MetaEnumLiteral;
		internal MetaPropertyBuilder MetaEnumLiteral_Enum;
		internal MetaClassBuilder MetaConstant;
		internal MetaPropertyBuilder MetaConstant_DotNetName;
		internal MetaPropertyBuilder MetaConstant_Value;
		private MetaOperationBuilder __tmp27;
		private MetaParameterBuilder __tmp60;
		internal MetaClassBuilder MetaClass;
		internal MetaPropertyBuilder MetaClass_IsAbstract;
		internal MetaPropertyBuilder MetaClass_SuperClasses;
		internal MetaPropertyBuilder MetaClass_Properties;
		internal MetaPropertyBuilder MetaClass_Operations;
		private MetaOperationBuilder __tmp41;
		private MetaParameterBuilder __tmp67;
		private MetaOperationBuilder __tmp42;
		private MetaParameterBuilder __tmp69;
		private MetaOperationBuilder __tmp43;
		private MetaParameterBuilder __tmp71;
		private MetaOperationBuilder __tmp44;
		private MetaParameterBuilder __tmp73;
		private MetaOperationBuilder __tmp45;
		private MetaOperationBuilder __tmp46;
		private MetaOperationBuilder __tmp47;
		private MetaOperationBuilder __tmp48;
		internal MetaClassBuilder MetaOperation;
		internal MetaPropertyBuilder MetaOperation_Parent;
		internal MetaPropertyBuilder MetaOperation_IsBuilder;
		internal MetaPropertyBuilder MetaOperation_IsReadonly;
		internal MetaPropertyBuilder MetaOperation_Parameters;
		internal MetaPropertyBuilder MetaOperation_ReturnType;
		private MetaOperationBuilder __tmp28;
		private MetaParameterBuilder __tmp59;
		internal MetaClassBuilder MetaParameter;
		internal MetaPropertyBuilder MetaParameter_Operation;
		internal MetaEnumBuilder MetaPropertyKind;
		private MetaEnumLiteralBuilder __tmp29;
		private MetaEnumLiteralBuilder __tmp30;
		private MetaEnumLiteralBuilder __tmp31;
		private MetaEnumLiteralBuilder __tmp32;
		private MetaEnumLiteralBuilder __tmp33;
		internal MetaClassBuilder MetaProperty;
		internal MetaPropertyBuilder MetaProperty_Kind;
		internal MetaPropertyBuilder MetaProperty_Class;
		internal MetaPropertyBuilder MetaProperty_DefaultValue;
		internal MetaPropertyBuilder MetaProperty_IsContainment;
		internal MetaPropertyBuilder MetaProperty_OppositeProperties;
		internal MetaPropertyBuilder MetaProperty_SubsettedProperties;
		internal MetaPropertyBuilder MetaProperty_SubsettingProperties;
		internal MetaPropertyBuilder MetaProperty_RedefinedProperties;
		internal MetaPropertyBuilder MetaProperty_RedefiningProperties;
		private MetaOperationBuilder __tmp49;
		private MetaParameterBuilder __tmp64;
		private MetaModelBuilder __tmp20;
		private MetaCollectionTypeBuilder __tmp35;
		private MetaCollectionTypeBuilder __tmp36;
		private MetaCollectionTypeBuilder __tmp50;
		private MetaCollectionTypeBuilder __tmp51;
		private MetaCollectionTypeBuilder __tmp52;
		private MetaCollectionTypeBuilder __tmp54;
		private MetaCollectionTypeBuilder __tmp56;
		private MetaCollectionTypeBuilder __tmp57;
		private MetaCollectionTypeBuilder __tmp58;
		private MetaCollectionTypeBuilder __tmp61;
		private MetaCollectionTypeBuilder __tmp62;
		private MetaCollectionTypeBuilder __tmp63;
		private MetaCollectionTypeBuilder __tmp65;
		private MetaCollectionTypeBuilder __tmp66;
		private MetaCollectionTypeBuilder __tmp68;
		private MetaCollectionTypeBuilder __tmp70;
		private MetaCollectionTypeBuilder __tmp72;
		private MetaCollectionTypeBuilder __tmp74;
		private MetaCollectionTypeBuilder __tmp75;
		private MetaCollectionTypeBuilder __tmp76;
		private MetaCollectionTypeBuilder __tmp77;
	
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
			Object.MName = "object";
			String = factory.MetaPrimitiveType();
			String.MName = "string";
			Int = factory.MetaPrimitiveType();
			Int.MName = "int";
			Long = factory.MetaPrimitiveType();
			Long.MName = "long";
			Float = factory.MetaPrimitiveType();
			Float.MName = "float";
			Double = factory.MetaPrimitiveType();
			Double.MName = "double";
			Byte = factory.MetaPrimitiveType();
			Byte.MName = "byte";
			Bool = factory.MetaPrimitiveType();
			Bool.MName = "bool";
			Void = factory.MetaPrimitiveType();
			Void.MName = "void";
			ModelObject = factory.MetaPrimitiveType();
			ModelObject.MName = "global::MetaDslx.Modeling.IModelObject";
			NameAttribute = factory.MetaAttribute();
			NameAttribute.MName = "NameAttribute";
			TypeAttribute = factory.MetaAttribute();
			TypeAttribute.MName = "TypeAttribute";
			ScopeAttribute = factory.MetaAttribute();
			ScopeAttribute.MName = "ScopeAttribute";
			BaseScopeAttribute = factory.MetaAttribute();
			BaseScopeAttribute.MName = "BaseScopeAttribute";
			LocalScopeAttribute = factory.MetaAttribute();
			LocalScopeAttribute.MName = "LocalScopeAttribute";
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaNamespace();
			__tmp5 = factory.MetaConstant();
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
			MetaElement = factory.MetaClass();
			MetaElement_Attributes = factory.MetaProperty();
			MetaDocumentedElement = factory.MetaClass();
			MetaDocumentedElement_Documentation = factory.MetaProperty();
			__tmp37 = factory.MetaOperation();
			MetaNamedElement = factory.MetaClass();
			MetaNamedElement_Name = factory.MetaProperty();
			MetaTypedElement = factory.MetaClass();
			MetaTypedElement_Type = factory.MetaProperty();
			MetaType = factory.MetaClass();
			__tmp22 = factory.MetaOperation();
			__tmp34 = factory.MetaParameter();
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
			__tmp23 = factory.MetaEnumLiteral();
			__tmp24 = factory.MetaEnumLiteral();
			__tmp25 = factory.MetaEnumLiteral();
			__tmp26 = factory.MetaEnumLiteral();
			MetaCollectionType = factory.MetaClass();
			MetaCollectionType_Kind = factory.MetaProperty();
			MetaCollectionType_InnerType = factory.MetaProperty();
			__tmp38 = factory.MetaOperation();
			__tmp55 = factory.MetaParameter();
			MetaNullableType = factory.MetaClass();
			MetaNullableType_InnerType = factory.MetaProperty();
			__tmp21 = factory.MetaOperation();
			__tmp53 = factory.MetaParameter();
			MetaPrimitiveType = factory.MetaClass();
			__tmp39 = factory.MetaOperation();
			__tmp40 = factory.MetaParameter();
			MetaEnum = factory.MetaClass();
			MetaEnum_EnumLiterals = factory.MetaProperty();
			MetaEnum_Operations = factory.MetaProperty();
			MetaEnumLiteral = factory.MetaClass();
			MetaEnumLiteral_Enum = factory.MetaProperty();
			MetaConstant = factory.MetaClass();
			MetaConstant_DotNetName = factory.MetaProperty();
			MetaConstant_Value = factory.MetaProperty();
			__tmp27 = factory.MetaOperation();
			__tmp60 = factory.MetaParameter();
			MetaClass = factory.MetaClass();
			MetaClass_IsAbstract = factory.MetaProperty();
			MetaClass_SuperClasses = factory.MetaProperty();
			MetaClass_Properties = factory.MetaProperty();
			MetaClass_Operations = factory.MetaProperty();
			__tmp41 = factory.MetaOperation();
			__tmp67 = factory.MetaParameter();
			__tmp42 = factory.MetaOperation();
			__tmp69 = factory.MetaParameter();
			__tmp43 = factory.MetaOperation();
			__tmp71 = factory.MetaParameter();
			__tmp44 = factory.MetaOperation();
			__tmp73 = factory.MetaParameter();
			__tmp45 = factory.MetaOperation();
			__tmp46 = factory.MetaOperation();
			__tmp47 = factory.MetaOperation();
			__tmp48 = factory.MetaOperation();
			MetaOperation = factory.MetaClass();
			MetaOperation_Parent = factory.MetaProperty();
			MetaOperation_IsBuilder = factory.MetaProperty();
			MetaOperation_IsReadonly = factory.MetaProperty();
			MetaOperation_Parameters = factory.MetaProperty();
			MetaOperation_ReturnType = factory.MetaProperty();
			__tmp28 = factory.MetaOperation();
			__tmp59 = factory.MetaParameter();
			MetaParameter = factory.MetaClass();
			MetaParameter_Operation = factory.MetaProperty();
			MetaPropertyKind = factory.MetaEnum();
			__tmp29 = factory.MetaEnumLiteral();
			__tmp30 = factory.MetaEnumLiteral();
			__tmp31 = factory.MetaEnumLiteral();
			__tmp32 = factory.MetaEnumLiteral();
			__tmp33 = factory.MetaEnumLiteral();
			MetaProperty = factory.MetaClass();
			MetaProperty_Kind = factory.MetaProperty();
			MetaProperty_Class = factory.MetaProperty();
			MetaProperty_DefaultValue = factory.MetaProperty();
			MetaProperty_IsContainment = factory.MetaProperty();
			MetaProperty_OppositeProperties = factory.MetaProperty();
			MetaProperty_SubsettedProperties = factory.MetaProperty();
			MetaProperty_SubsettingProperties = factory.MetaProperty();
			MetaProperty_RedefinedProperties = factory.MetaProperty();
			MetaProperty_RedefiningProperties = factory.MetaProperty();
			__tmp49 = factory.MetaOperation();
			__tmp64 = factory.MetaParameter();
			__tmp20 = factory.MetaModel();
			__tmp35 = factory.MetaCollectionType();
			__tmp36 = factory.MetaCollectionType();
			__tmp50 = factory.MetaCollectionType();
			__tmp51 = factory.MetaCollectionType();
			__tmp52 = factory.MetaCollectionType();
			__tmp54 = factory.MetaCollectionType();
			__tmp56 = factory.MetaCollectionType();
			__tmp57 = factory.MetaCollectionType();
			__tmp58 = factory.MetaCollectionType();
			__tmp61 = factory.MetaCollectionType();
			__tmp62 = factory.MetaCollectionType();
			__tmp63 = factory.MetaCollectionType();
			__tmp65 = factory.MetaCollectionType();
			__tmp66 = factory.MetaCollectionType();
			__tmp68 = factory.MetaCollectionType();
			__tmp70 = factory.MetaCollectionType();
			__tmp72 = factory.MetaCollectionType();
			__tmp74 = factory.MetaCollectionType();
			__tmp75 = factory.MetaCollectionType();
			__tmp76 = factory.MetaCollectionType();
			__tmp77 = factory.MetaCollectionType();
	
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
			__tmp4.SetDefinedMetaModelLazy(() => __tmp20);
			__tmp4.Declarations.AddLazy(() => __tmp5);
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
			__tmp5.SetTypeLazy(() => MetaPrimitiveType);
			__tmp5.Documentation = null;
			__tmp5.Name = "Object";
			__tmp5.SetNamespaceLazy(() => __tmp4);
			__tmp5.DotNetName = "object";
			__tmp5.SetValueLazy(() => Object);
			__tmp6.SetTypeLazy(() => MetaPrimitiveType);
			__tmp6.Documentation = null;
			__tmp6.Name = "String";
			__tmp6.SetNamespaceLazy(() => __tmp4);
			__tmp6.DotNetName = "string";
			__tmp6.SetValueLazy(() => String);
			__tmp7.SetTypeLazy(() => MetaPrimitiveType);
			__tmp7.Documentation = null;
			__tmp7.Name = "Int";
			__tmp7.SetNamespaceLazy(() => __tmp4);
			__tmp7.DotNetName = "int";
			__tmp7.SetValueLazy(() => Int);
			__tmp8.SetTypeLazy(() => MetaPrimitiveType);
			__tmp8.Documentation = null;
			__tmp8.Name = "Long";
			__tmp8.SetNamespaceLazy(() => __tmp4);
			__tmp8.DotNetName = "long";
			__tmp8.SetValueLazy(() => Long);
			__tmp9.SetTypeLazy(() => MetaPrimitiveType);
			__tmp9.Documentation = null;
			__tmp9.Name = "Float";
			__tmp9.SetNamespaceLazy(() => __tmp4);
			__tmp9.DotNetName = "float";
			__tmp9.SetValueLazy(() => Float);
			__tmp10.SetTypeLazy(() => MetaPrimitiveType);
			__tmp10.Documentation = null;
			__tmp10.Name = "Double";
			__tmp10.SetNamespaceLazy(() => __tmp4);
			__tmp10.DotNetName = "double";
			__tmp10.SetValueLazy(() => Double);
			__tmp11.SetTypeLazy(() => MetaPrimitiveType);
			__tmp11.Documentation = null;
			__tmp11.Name = "Byte";
			__tmp11.SetNamespaceLazy(() => __tmp4);
			__tmp11.DotNetName = "byte";
			__tmp11.SetValueLazy(() => Byte);
			__tmp12.SetTypeLazy(() => MetaPrimitiveType);
			__tmp12.Documentation = null;
			__tmp12.Name = "Bool";
			__tmp12.SetNamespaceLazy(() => __tmp4);
			__tmp12.DotNetName = "bool";
			__tmp12.SetValueLazy(() => Bool);
			__tmp13.SetTypeLazy(() => MetaPrimitiveType);
			__tmp13.Documentation = null;
			__tmp13.Name = "Void";
			__tmp13.SetNamespaceLazy(() => __tmp4);
			__tmp13.DotNetName = "void";
			__tmp13.SetValueLazy(() => Void);
			__tmp14.SetTypeLazy(() => MetaPrimitiveType);
			__tmp14.Documentation = null;
			__tmp14.Name = "ModelObject";
			__tmp14.SetNamespaceLazy(() => __tmp4);
			__tmp14.DotNetName = "global::MetaDslx.Modeling.IModelObject";
			__tmp14.SetValueLazy(() => ModelObject);
			__tmp15.SetTypeLazy(() => MetaAttribute);
			__tmp15.Documentation = null;
			__tmp15.Name = "NameAttribute";
			__tmp15.SetNamespaceLazy(() => __tmp4);
			__tmp15.DotNetName = "NameAttribute";
			__tmp15.SetValueLazy(() => NameAttribute);
			__tmp16.SetTypeLazy(() => MetaAttribute);
			__tmp16.Documentation = null;
			__tmp16.Name = "TypeAttribute";
			__tmp16.SetNamespaceLazy(() => __tmp4);
			__tmp16.DotNetName = "TypeAttribute";
			__tmp16.SetValueLazy(() => TypeAttribute);
			__tmp17.SetTypeLazy(() => MetaAttribute);
			__tmp17.Documentation = null;
			__tmp17.Name = "ScopeAttribute";
			__tmp17.SetNamespaceLazy(() => __tmp4);
			__tmp17.DotNetName = "ScopeAttribute";
			__tmp17.SetValueLazy(() => ScopeAttribute);
			__tmp18.SetTypeLazy(() => MetaAttribute);
			__tmp18.Documentation = null;
			__tmp18.Name = "BaseScopeAttribute";
			__tmp18.SetNamespaceLazy(() => __tmp4);
			__tmp18.DotNetName = "BaseScopeAttribute";
			__tmp18.SetValueLazy(() => BaseScopeAttribute);
			__tmp19.SetTypeLazy(() => MetaAttribute);
			__tmp19.Documentation = null;
			__tmp19.Name = "LocalScopeAttribute";
			__tmp19.SetNamespaceLazy(() => __tmp4);
			__tmp19.DotNetName = "LocalScopeAttribute";
			__tmp19.SetValueLazy(() => LocalScopeAttribute);
			MetaElement.Documentation = "\n\tRepresents an element.\n\t\r\n";
			MetaElement.Name = "MetaElement";
			MetaElement.SetNamespaceLazy(() => __tmp4);
			// MetaElement.IsAbstract = null;
			MetaElement.Properties.AddLazy(() => MetaElement_Attributes);
			MetaElement_Attributes.SetTypeLazy(() => __tmp36);
			MetaElement_Attributes.Documentation = "";
			MetaElement_Attributes.Name = "Attributes";
			// MetaElement_Attributes.Kind = null;
			MetaElement_Attributes.SetClassLazy(() => MetaElement);
			MetaElement_Attributes.DefaultValue = null;
			// MetaElement_Attributes.IsContainment = null;
			MetaDocumentedElement.Documentation = "";
			MetaDocumentedElement.Name = "MetaDocumentedElement";
			MetaDocumentedElement.SetNamespaceLazy(() => __tmp4);
			// MetaDocumentedElement.IsAbstract = null;
			MetaDocumentedElement.SuperClasses.AddLazy(() => MetaElement);
			MetaDocumentedElement.Properties.AddLazy(() => MetaDocumentedElement_Documentation);
			MetaDocumentedElement.Operations.AddLazy(() => __tmp37);
			MetaDocumentedElement_Documentation.SetTypeLazy(() => String);
			MetaDocumentedElement_Documentation.Documentation = "";
			MetaDocumentedElement_Documentation.Name = "Documentation";
			// MetaDocumentedElement_Documentation.Kind = null;
			MetaDocumentedElement_Documentation.SetClassLazy(() => MetaDocumentedElement);
			MetaDocumentedElement_Documentation.DefaultValue = null;
			// MetaDocumentedElement_Documentation.IsContainment = null;
			__tmp37.Documentation = "";
			__tmp37.Name = "GetDocumentationLines";
			__tmp37.SetParentLazy(() => MetaDocumentedElement);
			// __tmp37.IsBuilder = null;
			// __tmp37.IsReadonly = null;
			__tmp37.SetReturnTypeLazy(() => __tmp52);
			MetaNamedElement.Documentation = "";
			MetaNamedElement.Name = "MetaNamedElement";
			MetaNamedElement.SetNamespaceLazy(() => __tmp4);
			// MetaNamedElement.IsAbstract = null;
			MetaNamedElement.SuperClasses.AddLazy(() => MetaDocumentedElement);
			MetaNamedElement.Properties.AddLazy(() => MetaNamedElement_Name);
			MetaNamedElement_Name.Attributes.Add(NameAttribute);
			MetaNamedElement_Name.SetTypeLazy(() => String);
			MetaNamedElement_Name.Documentation = "";
			MetaNamedElement_Name.Name = "Name";
			// MetaNamedElement_Name.Kind = null;
			MetaNamedElement_Name.SetClassLazy(() => MetaNamedElement);
			MetaNamedElement_Name.DefaultValue = null;
			// MetaNamedElement_Name.IsContainment = null;
			MetaTypedElement.Documentation = "";
			MetaTypedElement.Name = "MetaTypedElement";
			MetaTypedElement.SetNamespaceLazy(() => __tmp4);
			// MetaTypedElement.IsAbstract = null;
			MetaTypedElement.SuperClasses.AddLazy(() => MetaElement);
			MetaTypedElement.Properties.AddLazy(() => MetaTypedElement_Type);
			MetaTypedElement_Type.Attributes.Add(TypeAttribute);
			MetaTypedElement_Type.SetTypeLazy(() => MetaType);
			MetaTypedElement_Type.Documentation = "";
			MetaTypedElement_Type.Name = "Type";
			// MetaTypedElement_Type.Kind = null;
			MetaTypedElement_Type.SetClassLazy(() => MetaTypedElement);
			MetaTypedElement_Type.DefaultValue = null;
			// MetaTypedElement_Type.IsContainment = null;
			MetaTypedElement_Type.RedefiningProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaType.Attributes.Add(TypeAttribute);
			MetaType.Documentation = "";
			MetaType.Name = "MetaType";
			MetaType.SetNamespaceLazy(() => __tmp4);
			// MetaType.IsAbstract = null;
			MetaType.Operations.AddLazy(() => __tmp22);
			__tmp22.Documentation = "";
			__tmp22.Name = "ConformsTo";
			__tmp22.SetParentLazy(() => MetaType);
			// __tmp22.IsBuilder = null;
			// __tmp22.IsReadonly = null;
			__tmp22.Parameters.AddLazy(() => __tmp34);
			__tmp22.SetReturnTypeLazy(() => Bool);
			__tmp34.SetTypeLazy(() => MetaType);
			__tmp34.Documentation = null;
			__tmp34.Name = "type";
			__tmp34.SetOperationLazy(() => __tmp22);
			MetaNamedType.Documentation = "";
			MetaNamedType.Name = "MetaNamedType";
			MetaNamedType.SetNamespaceLazy(() => __tmp4);
			// MetaNamedType.IsAbstract = null;
			MetaNamedType.SuperClasses.AddLazy(() => MetaType);
			MetaNamedType.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaAttribute.Documentation = "";
			MetaAttribute.Name = "MetaAttribute";
			MetaAttribute.SetNamespaceLazy(() => __tmp4);
			// MetaAttribute.IsAbstract = null;
			MetaAttribute.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.Documentation = "";
			MetaDeclaration.Name = "MetaDeclaration";
			MetaDeclaration.SetNamespaceLazy(() => __tmp4);
			// MetaDeclaration.IsAbstract = null;
			MetaDeclaration.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_Namespace);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_MetaModel);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_FullName);
			MetaDeclaration_Namespace.SetTypeLazy(() => MetaNamespace);
			MetaDeclaration_Namespace.Documentation = "";
			MetaDeclaration_Namespace.Name = "Namespace";
			// MetaDeclaration_Namespace.Kind = null;
			MetaDeclaration_Namespace.SetClassLazy(() => MetaDeclaration);
			MetaDeclaration_Namespace.DefaultValue = null;
			// MetaDeclaration_Namespace.IsContainment = null;
			MetaDeclaration_Namespace.OppositeProperties.AddLazy(() => MetaNamespace_Declarations);
			MetaDeclaration_MetaModel.SetTypeLazy(() => MetaModel);
			MetaDeclaration_MetaModel.Documentation = "";
			MetaDeclaration_MetaModel.Name = "MetaModel";
			MetaDeclaration_MetaModel.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			MetaDeclaration_MetaModel.SetClassLazy(() => MetaDeclaration);
			MetaDeclaration_MetaModel.DefaultValue = null;
			// MetaDeclaration_MetaModel.IsContainment = null;
			MetaDeclaration_FullName.SetTypeLazy(() => String);
			MetaDeclaration_FullName.Documentation = "";
			MetaDeclaration_FullName.Name = "FullName";
			MetaDeclaration_FullName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			MetaDeclaration_FullName.SetClassLazy(() => MetaDeclaration);
			MetaDeclaration_FullName.DefaultValue = null;
			// MetaDeclaration_FullName.IsContainment = null;
			MetaNamespace.Attributes.Add(ScopeAttribute);
			MetaNamespace.Documentation = "";
			MetaNamespace.Name = "MetaNamespace";
			MetaNamespace.SetNamespaceLazy(() => __tmp4);
			// MetaNamespace.IsAbstract = null;
			MetaNamespace.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_DefinedMetaModel);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Declarations);
			MetaNamespace_DefinedMetaModel.SetTypeLazy(() => MetaModel);
			MetaNamespace_DefinedMetaModel.Documentation = "";
			MetaNamespace_DefinedMetaModel.Name = "DefinedMetaModel";
			// MetaNamespace_DefinedMetaModel.Kind = null;
			MetaNamespace_DefinedMetaModel.SetClassLazy(() => MetaNamespace);
			MetaNamespace_DefinedMetaModel.DefaultValue = null;
			MetaNamespace_DefinedMetaModel.IsContainment = true;
			MetaNamespace_DefinedMetaModel.OppositeProperties.AddLazy(() => MetaModel_Namespace);
			MetaNamespace_Declarations.SetTypeLazy(() => __tmp54);
			MetaNamespace_Declarations.Documentation = "";
			MetaNamespace_Declarations.Name = "Declarations";
			// MetaNamespace_Declarations.Kind = null;
			MetaNamespace_Declarations.SetClassLazy(() => MetaNamespace);
			MetaNamespace_Declarations.DefaultValue = null;
			MetaNamespace_Declarations.IsContainment = true;
			MetaNamespace_Declarations.OppositeProperties.AddLazy(() => MetaDeclaration_Namespace);
			MetaModel.Documentation = "";
			MetaModel.Name = "MetaModel";
			MetaModel.SetNamespaceLazy(() => __tmp4);
			// MetaModel.IsAbstract = null;
			MetaModel.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaModel.Properties.AddLazy(() => MetaModel_Uri);
			MetaModel.Properties.AddLazy(() => MetaModel_Prefix);
			MetaModel.Properties.AddLazy(() => MetaModel_Namespace);
			MetaModel_Uri.SetTypeLazy(() => String);
			MetaModel_Uri.Documentation = "";
			MetaModel_Uri.Name = "Uri";
			// MetaModel_Uri.Kind = null;
			MetaModel_Uri.SetClassLazy(() => MetaModel);
			MetaModel_Uri.DefaultValue = null;
			// MetaModel_Uri.IsContainment = null;
			MetaModel_Prefix.SetTypeLazy(() => String);
			MetaModel_Prefix.Documentation = "";
			MetaModel_Prefix.Name = "Prefix";
			// MetaModel_Prefix.Kind = null;
			MetaModel_Prefix.SetClassLazy(() => MetaModel);
			MetaModel_Prefix.DefaultValue = null;
			// MetaModel_Prefix.IsContainment = null;
			MetaModel_Namespace.SetTypeLazy(() => MetaNamespace);
			MetaModel_Namespace.Documentation = "";
			MetaModel_Namespace.Name = "Namespace";
			// MetaModel_Namespace.Kind = null;
			MetaModel_Namespace.SetClassLazy(() => MetaModel);
			MetaModel_Namespace.DefaultValue = null;
			// MetaModel_Namespace.IsContainment = null;
			MetaModel_Namespace.OppositeProperties.AddLazy(() => MetaNamespace_DefinedMetaModel);
			MetaCollectionKind.Documentation = "";
			MetaCollectionKind.Name = "MetaCollectionKind";
			MetaCollectionKind.SetNamespaceLazy(() => __tmp4);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp23);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp24);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp25);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp26);
			__tmp23.Documentation = "";
			__tmp23.Name = "List";
			__tmp23.SetEnumLazy(() => MetaCollectionKind);
			__tmp24.Documentation = "";
			__tmp24.Name = "Set";
			__tmp24.SetEnumLazy(() => MetaCollectionKind);
			__tmp25.Documentation = "";
			__tmp25.Name = "MultiList";
			__tmp25.SetEnumLazy(() => MetaCollectionKind);
			__tmp26.Documentation = "";
			__tmp26.Name = "MultiSet";
			__tmp26.SetEnumLazy(() => MetaCollectionKind);
			MetaCollectionType.Documentation = "";
			MetaCollectionType.Name = "MetaCollectionType";
			MetaCollectionType.SetNamespaceLazy(() => __tmp4);
			// MetaCollectionType.IsAbstract = null;
			MetaCollectionType.SuperClasses.AddLazy(() => MetaType);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_Kind);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_InnerType);
			MetaCollectionType.Operations.AddLazy(() => __tmp38);
			MetaCollectionType_Kind.SetTypeLazy(() => MetaCollectionKind);
			MetaCollectionType_Kind.Documentation = "";
			MetaCollectionType_Kind.Name = "Kind";
			// MetaCollectionType_Kind.Kind = null;
			MetaCollectionType_Kind.SetClassLazy(() => MetaCollectionType);
			MetaCollectionType_Kind.DefaultValue = null;
			// MetaCollectionType_Kind.IsContainment = null;
			MetaCollectionType_InnerType.SetTypeLazy(() => MetaType);
			MetaCollectionType_InnerType.Documentation = "";
			MetaCollectionType_InnerType.Name = "InnerType";
			// MetaCollectionType_InnerType.Kind = null;
			MetaCollectionType_InnerType.SetClassLazy(() => MetaCollectionType);
			MetaCollectionType_InnerType.DefaultValue = null;
			// MetaCollectionType_InnerType.IsContainment = null;
			__tmp38.Documentation = "";
			__tmp38.Name = "ConformsTo";
			__tmp38.SetParentLazy(() => MetaCollectionType);
			// __tmp38.IsBuilder = null;
			// __tmp38.IsReadonly = null;
			__tmp38.Parameters.AddLazy(() => __tmp55);
			__tmp38.SetReturnTypeLazy(() => Bool);
			__tmp55.SetTypeLazy(() => MetaType);
			__tmp55.Documentation = null;
			__tmp55.Name = "type";
			__tmp55.SetOperationLazy(() => __tmp38);
			MetaNullableType.Documentation = "";
			MetaNullableType.Name = "MetaNullableType";
			MetaNullableType.SetNamespaceLazy(() => __tmp4);
			// MetaNullableType.IsAbstract = null;
			MetaNullableType.SuperClasses.AddLazy(() => MetaType);
			MetaNullableType.Properties.AddLazy(() => MetaNullableType_InnerType);
			MetaNullableType.Operations.AddLazy(() => __tmp21);
			MetaNullableType_InnerType.SetTypeLazy(() => MetaType);
			MetaNullableType_InnerType.Documentation = "";
			MetaNullableType_InnerType.Name = "InnerType";
			// MetaNullableType_InnerType.Kind = null;
			MetaNullableType_InnerType.SetClassLazy(() => MetaNullableType);
			MetaNullableType_InnerType.DefaultValue = null;
			// MetaNullableType_InnerType.IsContainment = null;
			__tmp21.Documentation = "";
			__tmp21.Name = "ConformsTo";
			__tmp21.SetParentLazy(() => MetaNullableType);
			// __tmp21.IsBuilder = null;
			// __tmp21.IsReadonly = null;
			__tmp21.Parameters.AddLazy(() => __tmp53);
			__tmp21.SetReturnTypeLazy(() => Bool);
			__tmp53.SetTypeLazy(() => MetaType);
			__tmp53.Documentation = null;
			__tmp53.Name = "type";
			__tmp53.SetOperationLazy(() => __tmp21);
			MetaPrimitiveType.Documentation = "";
			MetaPrimitiveType.Name = "MetaPrimitiveType";
			MetaPrimitiveType.SetNamespaceLazy(() => __tmp4);
			// MetaPrimitiveType.IsAbstract = null;
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaType);
			MetaPrimitiveType.Operations.AddLazy(() => __tmp39);
			__tmp39.Documentation = "";
			__tmp39.Name = "ConformsTo";
			__tmp39.SetParentLazy(() => MetaPrimitiveType);
			// __tmp39.IsBuilder = null;
			// __tmp39.IsReadonly = null;
			__tmp39.Parameters.AddLazy(() => __tmp40);
			__tmp39.SetReturnTypeLazy(() => Bool);
			__tmp40.SetTypeLazy(() => MetaType);
			__tmp40.Documentation = null;
			__tmp40.Name = "type";
			__tmp40.SetOperationLazy(() => __tmp39);
			MetaEnum.Attributes.Add(ScopeAttribute);
			MetaEnum.Documentation = "";
			MetaEnum.Name = "MetaEnum";
			MetaEnum.SetNamespaceLazy(() => __tmp4);
			// MetaEnum.IsAbstract = null;
			MetaEnum.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaEnum.SuperClasses.AddLazy(() => MetaType);
			MetaEnum.Properties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnum.Properties.AddLazy(() => MetaEnum_Operations);
			MetaEnum_EnumLiterals.SetTypeLazy(() => __tmp35);
			MetaEnum_EnumLiterals.Documentation = "";
			MetaEnum_EnumLiterals.Name = "EnumLiterals";
			// MetaEnum_EnumLiterals.Kind = null;
			MetaEnum_EnumLiterals.SetClassLazy(() => MetaEnum);
			MetaEnum_EnumLiterals.DefaultValue = null;
			MetaEnum_EnumLiterals.IsContainment = true;
			MetaEnum_EnumLiterals.OppositeProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaEnum_Operations.SetTypeLazy(() => __tmp51);
			MetaEnum_Operations.Documentation = "";
			MetaEnum_Operations.Name = "Operations";
			// MetaEnum_Operations.Kind = null;
			MetaEnum_Operations.SetClassLazy(() => MetaEnum);
			MetaEnum_Operations.DefaultValue = null;
			MetaEnum_Operations.IsContainment = true;
			MetaEnum_Operations.OppositeProperties.AddLazy(() => MetaOperation_Parent);
			MetaEnumLiteral.Documentation = "";
			MetaEnumLiteral.Name = "MetaEnumLiteral";
			MetaEnumLiteral.SetNamespaceLazy(() => __tmp4);
			// MetaEnumLiteral.IsAbstract = null;
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaEnumLiteral.Properties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaEnumLiteral_Enum.SetTypeLazy(() => MetaEnum);
			MetaEnumLiteral_Enum.Documentation = "";
			MetaEnumLiteral_Enum.Name = "Enum";
			// MetaEnumLiteral_Enum.Kind = null;
			MetaEnumLiteral_Enum.SetClassLazy(() => MetaEnumLiteral);
			MetaEnumLiteral_Enum.DefaultValue = null;
			// MetaEnumLiteral_Enum.IsContainment = null;
			MetaEnumLiteral_Enum.OppositeProperties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnumLiteral_Enum.RedefinedProperties.AddLazy(() => MetaTypedElement_Type);
			MetaConstant.Documentation = "";
			MetaConstant.Name = "MetaConstant";
			MetaConstant.SetNamespaceLazy(() => __tmp4);
			// MetaConstant.IsAbstract = null;
			MetaConstant.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaConstant.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaConstant.SuperClasses.AddLazy(() => MetaType);
			MetaConstant.Properties.AddLazy(() => MetaConstant_DotNetName);
			MetaConstant.Properties.AddLazy(() => MetaConstant_Value);
			MetaConstant.Operations.AddLazy(() => __tmp27);
			MetaConstant_DotNetName.SetTypeLazy(() => String);
			MetaConstant_DotNetName.Documentation = "";
			MetaConstant_DotNetName.Name = "DotNetName";
			// MetaConstant_DotNetName.Kind = null;
			MetaConstant_DotNetName.SetClassLazy(() => MetaConstant);
			MetaConstant_DotNetName.DefaultValue = null;
			// MetaConstant_DotNetName.IsContainment = null;
			MetaConstant_Value.SetTypeLazy(() => __tmp14);
			MetaConstant_Value.Documentation = "";
			MetaConstant_Value.Name = "Value";
			MetaConstant_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Readonly;
			MetaConstant_Value.SetClassLazy(() => MetaConstant);
			MetaConstant_Value.DefaultValue = null;
			// MetaConstant_Value.IsContainment = null;
			__tmp27.Documentation = "";
			__tmp27.Name = "ConformsTo";
			__tmp27.SetParentLazy(() => MetaConstant);
			// __tmp27.IsBuilder = null;
			// __tmp27.IsReadonly = null;
			__tmp27.Parameters.AddLazy(() => __tmp60);
			__tmp27.SetReturnTypeLazy(() => Bool);
			__tmp60.SetTypeLazy(() => MetaType);
			__tmp60.Documentation = null;
			__tmp60.Name = "type";
			__tmp60.SetOperationLazy(() => __tmp27);
			MetaClass.Attributes.Add(ScopeAttribute);
			MetaClass.Documentation = "";
			MetaClass.Name = "MetaClass";
			MetaClass.SetNamespaceLazy(() => __tmp4);
			// MetaClass.IsAbstract = null;
			MetaClass.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaClass.SuperClasses.AddLazy(() => MetaType);
			MetaClass.Properties.AddLazy(() => MetaClass_IsAbstract);
			MetaClass.Properties.AddLazy(() => MetaClass_SuperClasses);
			MetaClass.Properties.AddLazy(() => MetaClass_Properties);
			MetaClass.Properties.AddLazy(() => MetaClass_Operations);
			MetaClass.Operations.AddLazy(() => __tmp41);
			MetaClass.Operations.AddLazy(() => __tmp42);
			MetaClass.Operations.AddLazy(() => __tmp43);
			MetaClass.Operations.AddLazy(() => __tmp44);
			MetaClass.Operations.AddLazy(() => __tmp45);
			MetaClass.Operations.AddLazy(() => __tmp46);
			MetaClass.Operations.AddLazy(() => __tmp47);
			MetaClass.Operations.AddLazy(() => __tmp48);
			MetaClass_IsAbstract.SetTypeLazy(() => Bool);
			MetaClass_IsAbstract.Documentation = "";
			MetaClass_IsAbstract.Name = "IsAbstract";
			// MetaClass_IsAbstract.Kind = null;
			MetaClass_IsAbstract.SetClassLazy(() => MetaClass);
			MetaClass_IsAbstract.DefaultValue = null;
			// MetaClass_IsAbstract.IsContainment = null;
			MetaClass_SuperClasses.Attributes.Add(BaseScopeAttribute);
			MetaClass_SuperClasses.SetTypeLazy(() => __tmp50);
			MetaClass_SuperClasses.Documentation = "";
			MetaClass_SuperClasses.Name = "SuperClasses";
			// MetaClass_SuperClasses.Kind = null;
			MetaClass_SuperClasses.SetClassLazy(() => MetaClass);
			MetaClass_SuperClasses.DefaultValue = null;
			// MetaClass_SuperClasses.IsContainment = null;
			MetaClass_Properties.SetTypeLazy(() => __tmp65);
			MetaClass_Properties.Documentation = "";
			MetaClass_Properties.Name = "Properties";
			// MetaClass_Properties.Kind = null;
			MetaClass_Properties.SetClassLazy(() => MetaClass);
			MetaClass_Properties.DefaultValue = null;
			MetaClass_Properties.IsContainment = true;
			MetaClass_Properties.OppositeProperties.AddLazy(() => MetaProperty_Class);
			MetaClass_Operations.SetTypeLazy(() => __tmp66);
			MetaClass_Operations.Documentation = "";
			MetaClass_Operations.Name = "Operations";
			// MetaClass_Operations.Kind = null;
			MetaClass_Operations.SetClassLazy(() => MetaClass);
			MetaClass_Operations.DefaultValue = null;
			MetaClass_Operations.IsContainment = true;
			MetaClass_Operations.OppositeProperties.AddLazy(() => MetaOperation_Parent);
			__tmp41.Documentation = "";
			__tmp41.Name = "ConformsTo";
			__tmp41.SetParentLazy(() => MetaClass);
			// __tmp41.IsBuilder = null;
			// __tmp41.IsReadonly = null;
			__tmp41.Parameters.AddLazy(() => __tmp67);
			__tmp41.SetReturnTypeLazy(() => Bool);
			__tmp67.SetTypeLazy(() => MetaType);
			__tmp67.Documentation = null;
			__tmp67.Name = "type";
			__tmp67.SetOperationLazy(() => __tmp41);
			__tmp42.Documentation = "";
			__tmp42.Name = "GetAllSuperClasses";
			__tmp42.SetParentLazy(() => MetaClass);
			// __tmp42.IsBuilder = null;
			// __tmp42.IsReadonly = null;
			__tmp42.Parameters.AddLazy(() => __tmp69);
			__tmp42.SetReturnTypeLazy(() => __tmp68);
			__tmp69.SetTypeLazy(() => Bool);
			__tmp69.Documentation = null;
			__tmp69.Name = "includeSelf";
			__tmp69.SetOperationLazy(() => __tmp42);
			__tmp43.Documentation = "";
			__tmp43.Name = "GetAllSuperProperties";
			__tmp43.SetParentLazy(() => MetaClass);
			// __tmp43.IsBuilder = null;
			// __tmp43.IsReadonly = null;
			__tmp43.Parameters.AddLazy(() => __tmp71);
			__tmp43.SetReturnTypeLazy(() => __tmp70);
			__tmp71.SetTypeLazy(() => Bool);
			__tmp71.Documentation = null;
			__tmp71.Name = "includeSelf";
			__tmp71.SetOperationLazy(() => __tmp43);
			__tmp44.Documentation = "";
			__tmp44.Name = "GetAllSuperOperations";
			__tmp44.SetParentLazy(() => MetaClass);
			// __tmp44.IsBuilder = null;
			// __tmp44.IsReadonly = null;
			__tmp44.Parameters.AddLazy(() => __tmp73);
			__tmp44.SetReturnTypeLazy(() => __tmp72);
			__tmp73.SetTypeLazy(() => Bool);
			__tmp73.Documentation = null;
			__tmp73.Name = "includeSelf";
			__tmp73.SetOperationLazy(() => __tmp44);
			__tmp45.Documentation = "";
			__tmp45.Name = "GetAllProperties";
			__tmp45.SetParentLazy(() => MetaClass);
			// __tmp45.IsBuilder = null;
			// __tmp45.IsReadonly = null;
			__tmp45.SetReturnTypeLazy(() => __tmp74);
			__tmp46.Documentation = "";
			__tmp46.Name = "GetAllOperations";
			__tmp46.SetParentLazy(() => MetaClass);
			// __tmp46.IsBuilder = null;
			// __tmp46.IsReadonly = null;
			__tmp46.SetReturnTypeLazy(() => __tmp75);
			__tmp47.Documentation = "";
			__tmp47.Name = "GetAllFinalProperties";
			__tmp47.SetParentLazy(() => MetaClass);
			// __tmp47.IsBuilder = null;
			// __tmp47.IsReadonly = null;
			__tmp47.SetReturnTypeLazy(() => __tmp76);
			__tmp48.Documentation = "";
			__tmp48.Name = "GetAllFinalOperations";
			__tmp48.SetParentLazy(() => MetaClass);
			// __tmp48.IsBuilder = null;
			// __tmp48.IsReadonly = null;
			__tmp48.SetReturnTypeLazy(() => __tmp77);
			MetaOperation.Attributes.Add(LocalScopeAttribute);
			MetaOperation.Documentation = "";
			MetaOperation.Name = "MetaOperation";
			MetaOperation.SetNamespaceLazy(() => __tmp4);
			// MetaOperation.IsAbstract = null;
			MetaOperation.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Parent);
			MetaOperation.Properties.AddLazy(() => MetaOperation_IsBuilder);
			MetaOperation.Properties.AddLazy(() => MetaOperation_IsReadonly);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Parameters);
			MetaOperation.Properties.AddLazy(() => MetaOperation_ReturnType);
			MetaOperation.Operations.AddLazy(() => __tmp28);
			MetaOperation_Parent.SetTypeLazy(() => MetaType);
			MetaOperation_Parent.Documentation = "";
			MetaOperation_Parent.Name = "Parent";
			// MetaOperation_Parent.Kind = null;
			MetaOperation_Parent.SetClassLazy(() => MetaOperation);
			MetaOperation_Parent.DefaultValue = null;
			// MetaOperation_Parent.IsContainment = null;
			MetaOperation_Parent.OppositeProperties.AddLazy(() => MetaClass_Operations);
			MetaOperation_Parent.OppositeProperties.AddLazy(() => MetaEnum_Operations);
			MetaOperation_IsBuilder.SetTypeLazy(() => Bool);
			MetaOperation_IsBuilder.Documentation = "";
			MetaOperation_IsBuilder.Name = "IsBuilder";
			// MetaOperation_IsBuilder.Kind = null;
			MetaOperation_IsBuilder.SetClassLazy(() => MetaOperation);
			MetaOperation_IsBuilder.DefaultValue = null;
			// MetaOperation_IsBuilder.IsContainment = null;
			MetaOperation_IsReadonly.SetTypeLazy(() => Bool);
			MetaOperation_IsReadonly.Documentation = "";
			MetaOperation_IsReadonly.Name = "IsReadonly";
			// MetaOperation_IsReadonly.Kind = null;
			MetaOperation_IsReadonly.SetClassLazy(() => MetaOperation);
			MetaOperation_IsReadonly.DefaultValue = null;
			// MetaOperation_IsReadonly.IsContainment = null;
			MetaOperation_Parameters.SetTypeLazy(() => __tmp56);
			MetaOperation_Parameters.Documentation = "";
			MetaOperation_Parameters.Name = "Parameters";
			// MetaOperation_Parameters.Kind = null;
			MetaOperation_Parameters.SetClassLazy(() => MetaOperation);
			MetaOperation_Parameters.DefaultValue = null;
			MetaOperation_Parameters.IsContainment = true;
			MetaOperation_Parameters.OppositeProperties.AddLazy(() => MetaParameter_Operation);
			MetaOperation_ReturnType.SetTypeLazy(() => MetaType);
			MetaOperation_ReturnType.Documentation = "";
			MetaOperation_ReturnType.Name = "ReturnType";
			// MetaOperation_ReturnType.Kind = null;
			MetaOperation_ReturnType.SetClassLazy(() => MetaOperation);
			MetaOperation_ReturnType.DefaultValue = null;
			// MetaOperation_ReturnType.IsContainment = null;
			__tmp28.Documentation = "";
			__tmp28.Name = "ConformsTo";
			__tmp28.SetParentLazy(() => MetaOperation);
			// __tmp28.IsBuilder = null;
			// __tmp28.IsReadonly = null;
			__tmp28.Parameters.AddLazy(() => __tmp59);
			__tmp28.SetReturnTypeLazy(() => Bool);
			__tmp59.SetTypeLazy(() => MetaOperation);
			__tmp59.Documentation = null;
			__tmp59.Name = "operation";
			__tmp59.SetOperationLazy(() => __tmp28);
			MetaParameter.Documentation = "";
			MetaParameter.Name = "MetaParameter";
			MetaParameter.SetNamespaceLazy(() => __tmp4);
			// MetaParameter.IsAbstract = null;
			MetaParameter.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaParameter.Properties.AddLazy(() => MetaParameter_Operation);
			MetaParameter_Operation.SetTypeLazy(() => MetaOperation);
			MetaParameter_Operation.Documentation = "";
			MetaParameter_Operation.Name = "Operation";
			// MetaParameter_Operation.Kind = null;
			MetaParameter_Operation.SetClassLazy(() => MetaParameter);
			MetaParameter_Operation.DefaultValue = null;
			// MetaParameter_Operation.IsContainment = null;
			MetaParameter_Operation.OppositeProperties.AddLazy(() => MetaOperation_Parameters);
			MetaPropertyKind.Documentation = "";
			MetaPropertyKind.Name = "MetaPropertyKind";
			MetaPropertyKind.SetNamespaceLazy(() => __tmp4);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp29);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp30);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp31);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp32);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp33);
			__tmp29.Documentation = "";
			__tmp29.Name = "Normal";
			__tmp29.SetEnumLazy(() => MetaPropertyKind);
			__tmp30.Documentation = "";
			__tmp30.Name = "Readonly";
			__tmp30.SetEnumLazy(() => MetaPropertyKind);
			__tmp31.Documentation = "";
			__tmp31.Name = "Lazy";
			__tmp31.SetEnumLazy(() => MetaPropertyKind);
			__tmp32.Documentation = "";
			__tmp32.Name = "Derived";
			__tmp32.SetEnumLazy(() => MetaPropertyKind);
			__tmp33.Documentation = "";
			__tmp33.Name = "DerivedUnion";
			__tmp33.SetEnumLazy(() => MetaPropertyKind);
			MetaProperty.Documentation = "";
			MetaProperty.Name = "MetaProperty";
			MetaProperty.SetNamespaceLazy(() => __tmp4);
			// MetaProperty.IsAbstract = null;
			MetaProperty.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaProperty.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaProperty.Properties.AddLazy(() => MetaProperty_Kind);
			MetaProperty.Properties.AddLazy(() => MetaProperty_Class);
			MetaProperty.Properties.AddLazy(() => MetaProperty_DefaultValue);
			MetaProperty.Properties.AddLazy(() => MetaProperty_IsContainment);
			MetaProperty.Properties.AddLazy(() => MetaProperty_OppositeProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettingProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefinedProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefiningProperties);
			MetaProperty.Operations.AddLazy(() => __tmp49);
			MetaProperty_Kind.SetTypeLazy(() => MetaPropertyKind);
			MetaProperty_Kind.Documentation = "";
			MetaProperty_Kind.Name = "Kind";
			// MetaProperty_Kind.Kind = null;
			MetaProperty_Kind.SetClassLazy(() => MetaProperty);
			MetaProperty_Kind.DefaultValue = null;
			// MetaProperty_Kind.IsContainment = null;
			MetaProperty_Class.SetTypeLazy(() => MetaClass);
			MetaProperty_Class.Documentation = "";
			MetaProperty_Class.Name = "Class";
			// MetaProperty_Class.Kind = null;
			MetaProperty_Class.SetClassLazy(() => MetaProperty);
			MetaProperty_Class.DefaultValue = null;
			// MetaProperty_Class.IsContainment = null;
			MetaProperty_Class.OppositeProperties.AddLazy(() => MetaClass_Properties);
			MetaProperty_DefaultValue.SetTypeLazy(() => String);
			MetaProperty_DefaultValue.Documentation = "";
			MetaProperty_DefaultValue.Name = "DefaultValue";
			// MetaProperty_DefaultValue.Kind = null;
			MetaProperty_DefaultValue.SetClassLazy(() => MetaProperty);
			MetaProperty_DefaultValue.DefaultValue = null;
			// MetaProperty_DefaultValue.IsContainment = null;
			MetaProperty_IsContainment.SetTypeLazy(() => Bool);
			MetaProperty_IsContainment.Documentation = "";
			MetaProperty_IsContainment.Name = "IsContainment";
			// MetaProperty_IsContainment.Kind = null;
			MetaProperty_IsContainment.SetClassLazy(() => MetaProperty);
			MetaProperty_IsContainment.DefaultValue = null;
			// MetaProperty_IsContainment.IsContainment = null;
			MetaProperty_OppositeProperties.SetTypeLazy(() => __tmp57);
			MetaProperty_OppositeProperties.Documentation = "";
			MetaProperty_OppositeProperties.Name = "OppositeProperties";
			// MetaProperty_OppositeProperties.Kind = null;
			MetaProperty_OppositeProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_OppositeProperties.DefaultValue = null;
			// MetaProperty_OppositeProperties.IsContainment = null;
			MetaProperty_OppositeProperties.OppositeProperties.AddLazy(() => MetaProperty_OppositeProperties);
			MetaProperty_SubsettedProperties.SetTypeLazy(() => __tmp58);
			MetaProperty_SubsettedProperties.Documentation = "";
			MetaProperty_SubsettedProperties.Name = "SubsettedProperties";
			// MetaProperty_SubsettedProperties.Kind = null;
			MetaProperty_SubsettedProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_SubsettedProperties.DefaultValue = null;
			// MetaProperty_SubsettedProperties.IsContainment = null;
			MetaProperty_SubsettedProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettingProperties);
			MetaProperty_SubsettingProperties.SetTypeLazy(() => __tmp61);
			MetaProperty_SubsettingProperties.Documentation = "";
			MetaProperty_SubsettingProperties.Name = "SubsettingProperties";
			// MetaProperty_SubsettingProperties.Kind = null;
			MetaProperty_SubsettingProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_SubsettingProperties.DefaultValue = null;
			// MetaProperty_SubsettingProperties.IsContainment = null;
			MetaProperty_SubsettingProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty_RedefinedProperties.SetTypeLazy(() => __tmp62);
			MetaProperty_RedefinedProperties.Documentation = "";
			MetaProperty_RedefinedProperties.Name = "RedefinedProperties";
			// MetaProperty_RedefinedProperties.Kind = null;
			MetaProperty_RedefinedProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_RedefinedProperties.DefaultValue = null;
			// MetaProperty_RedefinedProperties.IsContainment = null;
			MetaProperty_RedefinedProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefiningProperties);
			MetaProperty_RedefiningProperties.SetTypeLazy(() => __tmp63);
			MetaProperty_RedefiningProperties.Documentation = "";
			MetaProperty_RedefiningProperties.Name = "RedefiningProperties";
			// MetaProperty_RedefiningProperties.Kind = null;
			MetaProperty_RedefiningProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_RedefiningProperties.DefaultValue = null;
			// MetaProperty_RedefiningProperties.IsContainment = null;
			MetaProperty_RedefiningProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefinedProperties);
			__tmp49.Documentation = "";
			__tmp49.Name = "ConformsTo";
			__tmp49.SetParentLazy(() => MetaProperty);
			// __tmp49.IsBuilder = null;
			// __tmp49.IsReadonly = null;
			__tmp49.Parameters.AddLazy(() => __tmp64);
			__tmp49.SetReturnTypeLazy(() => Bool);
			__tmp64.SetTypeLazy(() => MetaProperty);
			__tmp64.Documentation = null;
			__tmp64.Name = "property";
			__tmp64.SetOperationLazy(() => __tmp49);
			__tmp20.Documentation = "\n\tRepresents the MetaModel.\n\t\r\n";
			__tmp20.Name = "Meta";
			__tmp20.Uri = "http://metadslx.core/1.0";
			__tmp20.Prefix = null;
			__tmp20.SetNamespaceLazy(() => __tmp4);
			__tmp35.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp35.SetInnerTypeLazy(() => MetaEnumLiteral);
			__tmp36.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp36.SetInnerTypeLazy(() => MetaAttribute);
			__tmp50.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp50.SetInnerTypeLazy(() => MetaClass);
			__tmp51.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp51.SetInnerTypeLazy(() => MetaOperation);
			__tmp52.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp52.SetInnerTypeLazy(() => String);
			__tmp54.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp54.SetInnerTypeLazy(() => MetaDeclaration);
			__tmp56.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp56.SetInnerTypeLazy(() => MetaParameter);
			__tmp57.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp57.SetInnerTypeLazy(() => MetaProperty);
			__tmp58.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp58.SetInnerTypeLazy(() => MetaProperty);
			__tmp61.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp61.SetInnerTypeLazy(() => MetaProperty);
			__tmp62.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp62.SetInnerTypeLazy(() => MetaProperty);
			__tmp63.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp63.SetInnerTypeLazy(() => MetaProperty);
			__tmp65.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp65.SetInnerTypeLazy(() => MetaProperty);
			__tmp66.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp66.SetInnerTypeLazy(() => MetaOperation);
			__tmp68.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp68.SetInnerTypeLazy(() => MetaClass);
			__tmp70.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp70.SetInnerTypeLazy(() => MetaProperty);
			__tmp72.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp72.SetInnerTypeLazy(() => MetaOperation);
			__tmp74.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp74.SetInnerTypeLazy(() => MetaProperty);
			__tmp75.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp75.SetInnerTypeLazy(() => MetaOperation);
			__tmp76.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp76.SetInnerTypeLazy(() => MetaProperty);
			__tmp77.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp77.SetInnerTypeLazy(() => MetaOperation);
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
	
	
		public virtual void MetaElement_MValidate(MetaElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
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
	
	
		public virtual void MetaDocumentedElement_MValidate(MetaDocumentedElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
		}
	
	
		/// <summary>
		/// Implements the operation: MetaDocumentedElement.GetDocumentationLines()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement_GetDocumentationLines(MetaDocumentedElement _this)
		{
			return this.MetaDocumentedElement_GetDocumentationLines(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: MetaDocumentedElementBuilder.GetDocumentationLines()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<string> MetaDocumentedElement_GetDocumentationLines(MetaDocumentedElementBuilder _this);
	
	
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
	
	
		public virtual void MetaNamedElement_MValidate(MetaNamedElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaTypedElement_MValidate(MetaTypedElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaType_MValidate(MetaTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
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
	
	
		public virtual void MetaNamedType_MValidate(MetaNamedTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaAttribute_MValidate(MetaAttributeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
		public abstract string MetaDeclaration_ComputeProperty_FullName(MetaDeclarationBuilder _this);
	
		public virtual void MetaDeclaration_MValidate(MetaDeclarationBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaNamespace_MValidate(MetaNamespaceBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaModel_MValidate(MetaModelBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaCollectionType_MValidate(MetaCollectionTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaNullableType_MValidate(MetaNullableTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
			this.MetaType(_this);
			this.MetaDeclaration(_this);
		}
	
	
		public virtual void MetaPrimitiveType_MValidate(MetaPrimitiveTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
			this.MetaType(_this);
			this.MetaDeclaration(_this);
		}
	
	
		public virtual void MetaEnum_MValidate(MetaEnumBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaEnumLiteral_MValidate(MetaEnumLiteralBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
		}
	
	
	
		/// <summary>
		/// Implements the constructor: MetaConstant()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaDeclaration</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaType</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaDeclaration</li>
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
			this.MetaElement(_this);
			this.MetaNamedElement(_this);
			this.MetaType(_this);
			this.MetaTypedElement(_this);
			this.MetaDeclaration(_this);
		}
	
	
		public virtual void MetaConstant_MValidate(MetaConstantBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
			this.MetaType(_this);
			this.MetaDeclaration(_this);
		}
	
	
		public virtual void MetaClass_MValidate(MetaClassBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaOperation_MValidate(MetaOperationBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaParameter_MValidate(MetaParameterBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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
	
	
		public virtual void MetaProperty_MValidate(MetaPropertyBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics)
		{
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

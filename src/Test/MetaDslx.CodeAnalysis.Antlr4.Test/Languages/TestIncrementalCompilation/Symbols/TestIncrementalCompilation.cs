using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols
{
	using global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal;

	internal class TestIncrementalCompilationMetaModel : global::MetaDslx.Modeling.IMetaModel
	{
		internal TestIncrementalCompilationMetaModel()
		{
		}
	
		public global::MetaDslx.Modeling.ModelId Id => TestIncrementalCompilationInstance.MModel.Id;
		public string Name => "TestIncrementalCompilation";
		public global::MetaDslx.Modeling.ModelVersion Version => TestIncrementalCompilationInstance.MModel.Version;
		public global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> Objects => TestIncrementalCompilationInstance.MModel.Objects;
		public string Uri => "http://metadslx.core/1.0";
		public string Prefix => "";
		public global::MetaDslx.Modeling.IModelGroup ModelGroup => TestIncrementalCompilationInstance.MModel.ModelGroup;
		public string Namespace => "MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols";
	
		public global::MetaDslx.Modeling.IModelFactory CreateFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
		{
			return new TestIncrementalCompilationFactory(model, flags);
		}
	
	    public override string ToString()
	    {
	        return $"{Name} ({Version})";
	    }
	}

	public class TestIncrementalCompilationInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return TestIncrementalCompilationInstance.initialized; }
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
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaElement_Attributes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaDocumentedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaDocumentedElement_Documentation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaNamedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaNamedElement_Name;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaTypedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaTypedElement_Type;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaNamedType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaAttribute;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaDeclaration;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaDeclaration_Namespace;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaDeclaration_MetaModel;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaDeclaration_FullName;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaNamespace;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaNamespace_DefinedMetaModel;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaNamespace_Declarations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaModel;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaModel_Uri;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaModel_Prefix;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaModel_Namespace;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaCollectionType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaCollectionType_Kind;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaCollectionType_InnerType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaNullableType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaNullableType_InnerType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaPrimitiveType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaEnum;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaEnum_EnumLiterals;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaEnum_Operations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaEnumLiteral;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaEnumLiteral_Enum;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaConstant;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaConstant_DotNetName;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaConstant_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaClass_IsAbstract;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaClass_SuperClasses;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaClass_Properties;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaClass_Operations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaOperation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaOperation_Class;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaOperation_Enum;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaOperation_IsBuilder;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaOperation_IsReadonly;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaOperation_Parameters;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaOperation_ReturnType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaParameter;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaParameter_Operation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass MetaProperty;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_Kind;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_Class;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_DefaultValue;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_IsContainment;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_OppositeProperties;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_SubsettedProperties;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_SubsettingProperties;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_RedefinedProperties;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty MetaProperty_RedefiningProperties;
	
		static TestIncrementalCompilationInstance()
		{
			TestIncrementalCompilationBuilderInstance.instance.Create();
			TestIncrementalCompilationBuilderInstance.instance.EvaluateLazyValues();
			MMetaModel = new TestIncrementalCompilationMetaModel();
			MModel = TestIncrementalCompilationBuilderInstance.instance.MModel.ToImmutable();
	
			Object = TestIncrementalCompilationBuilderInstance.instance.Object.ToImmutable(MModel);
			String = TestIncrementalCompilationBuilderInstance.instance.String.ToImmutable(MModel);
			Int = TestIncrementalCompilationBuilderInstance.instance.Int.ToImmutable(MModel);
			Long = TestIncrementalCompilationBuilderInstance.instance.Long.ToImmutable(MModel);
			Float = TestIncrementalCompilationBuilderInstance.instance.Float.ToImmutable(MModel);
			Double = TestIncrementalCompilationBuilderInstance.instance.Double.ToImmutable(MModel);
			Byte = TestIncrementalCompilationBuilderInstance.instance.Byte.ToImmutable(MModel);
			Bool = TestIncrementalCompilationBuilderInstance.instance.Bool.ToImmutable(MModel);
			Void = TestIncrementalCompilationBuilderInstance.instance.Void.ToImmutable(MModel);
			ModelObject = TestIncrementalCompilationBuilderInstance.instance.ModelObject.ToImmutable(MModel);
			NameAttribute = TestIncrementalCompilationBuilderInstance.instance.NameAttribute.ToImmutable(MModel);
			TypeAttribute = TestIncrementalCompilationBuilderInstance.instance.TypeAttribute.ToImmutable(MModel);
			ScopeAttribute = TestIncrementalCompilationBuilderInstance.instance.ScopeAttribute.ToImmutable(MModel);
			BaseScopeAttribute = TestIncrementalCompilationBuilderInstance.instance.BaseScopeAttribute.ToImmutable(MModel);
			LocalScopeAttribute = TestIncrementalCompilationBuilderInstance.instance.LocalScopeAttribute.ToImmutable(MModel);
	
			MetaElement = TestIncrementalCompilationBuilderInstance.instance.MetaElement.ToImmutable(MModel);
			MetaElement_Attributes = TestIncrementalCompilationBuilderInstance.instance.MetaElement_Attributes.ToImmutable(MModel);
			MetaDocumentedElement = TestIncrementalCompilationBuilderInstance.instance.MetaDocumentedElement.ToImmutable(MModel);
			MetaDocumentedElement_Documentation = TestIncrementalCompilationBuilderInstance.instance.MetaDocumentedElement_Documentation.ToImmutable(MModel);
			MetaNamedElement = TestIncrementalCompilationBuilderInstance.instance.MetaNamedElement.ToImmutable(MModel);
			MetaNamedElement_Name = TestIncrementalCompilationBuilderInstance.instance.MetaNamedElement_Name.ToImmutable(MModel);
			MetaTypedElement = TestIncrementalCompilationBuilderInstance.instance.MetaTypedElement.ToImmutable(MModel);
			MetaTypedElement_Type = TestIncrementalCompilationBuilderInstance.instance.MetaTypedElement_Type.ToImmutable(MModel);
			MetaType = TestIncrementalCompilationBuilderInstance.instance.MetaType.ToImmutable(MModel);
			MetaNamedType = TestIncrementalCompilationBuilderInstance.instance.MetaNamedType.ToImmutable(MModel);
			MetaAttribute = TestIncrementalCompilationBuilderInstance.instance.MetaAttribute.ToImmutable(MModel);
			MetaDeclaration = TestIncrementalCompilationBuilderInstance.instance.MetaDeclaration.ToImmutable(MModel);
			MetaDeclaration_Namespace = TestIncrementalCompilationBuilderInstance.instance.MetaDeclaration_Namespace.ToImmutable(MModel);
			MetaDeclaration_MetaModel = TestIncrementalCompilationBuilderInstance.instance.MetaDeclaration_MetaModel.ToImmutable(MModel);
			MetaDeclaration_FullName = TestIncrementalCompilationBuilderInstance.instance.MetaDeclaration_FullName.ToImmutable(MModel);
			MetaNamespace = TestIncrementalCompilationBuilderInstance.instance.MetaNamespace.ToImmutable(MModel);
			MetaNamespace_DefinedMetaModel = TestIncrementalCompilationBuilderInstance.instance.MetaNamespace_DefinedMetaModel.ToImmutable(MModel);
			MetaNamespace_Declarations = TestIncrementalCompilationBuilderInstance.instance.MetaNamespace_Declarations.ToImmutable(MModel);
			MetaModel = TestIncrementalCompilationBuilderInstance.instance.MetaModel.ToImmutable(MModel);
			MetaModel_Uri = TestIncrementalCompilationBuilderInstance.instance.MetaModel_Uri.ToImmutable(MModel);
			MetaModel_Prefix = TestIncrementalCompilationBuilderInstance.instance.MetaModel_Prefix.ToImmutable(MModel);
			MetaModel_Namespace = TestIncrementalCompilationBuilderInstance.instance.MetaModel_Namespace.ToImmutable(MModel);
			MetaCollectionType = TestIncrementalCompilationBuilderInstance.instance.MetaCollectionType.ToImmutable(MModel);
			MetaCollectionType_Kind = TestIncrementalCompilationBuilderInstance.instance.MetaCollectionType_Kind.ToImmutable(MModel);
			MetaCollectionType_InnerType = TestIncrementalCompilationBuilderInstance.instance.MetaCollectionType_InnerType.ToImmutable(MModel);
			MetaNullableType = TestIncrementalCompilationBuilderInstance.instance.MetaNullableType.ToImmutable(MModel);
			MetaNullableType_InnerType = TestIncrementalCompilationBuilderInstance.instance.MetaNullableType_InnerType.ToImmutable(MModel);
			MetaPrimitiveType = TestIncrementalCompilationBuilderInstance.instance.MetaPrimitiveType.ToImmutable(MModel);
			MetaEnum = TestIncrementalCompilationBuilderInstance.instance.MetaEnum.ToImmutable(MModel);
			MetaEnum_EnumLiterals = TestIncrementalCompilationBuilderInstance.instance.MetaEnum_EnumLiterals.ToImmutable(MModel);
			MetaEnum_Operations = TestIncrementalCompilationBuilderInstance.instance.MetaEnum_Operations.ToImmutable(MModel);
			MetaEnumLiteral = TestIncrementalCompilationBuilderInstance.instance.MetaEnumLiteral.ToImmutable(MModel);
			MetaEnumLiteral_Enum = TestIncrementalCompilationBuilderInstance.instance.MetaEnumLiteral_Enum.ToImmutable(MModel);
			MetaConstant = TestIncrementalCompilationBuilderInstance.instance.MetaConstant.ToImmutable(MModel);
			MetaConstant_DotNetName = TestIncrementalCompilationBuilderInstance.instance.MetaConstant_DotNetName.ToImmutable(MModel);
			MetaConstant_Value = TestIncrementalCompilationBuilderInstance.instance.MetaConstant_Value.ToImmutable(MModel);
			MetaClass = TestIncrementalCompilationBuilderInstance.instance.MetaClass.ToImmutable(MModel);
			MetaClass_IsAbstract = TestIncrementalCompilationBuilderInstance.instance.MetaClass_IsAbstract.ToImmutable(MModel);
			MetaClass_SuperClasses = TestIncrementalCompilationBuilderInstance.instance.MetaClass_SuperClasses.ToImmutable(MModel);
			MetaClass_Properties = TestIncrementalCompilationBuilderInstance.instance.MetaClass_Properties.ToImmutable(MModel);
			MetaClass_Operations = TestIncrementalCompilationBuilderInstance.instance.MetaClass_Operations.ToImmutable(MModel);
			MetaOperation = TestIncrementalCompilationBuilderInstance.instance.MetaOperation.ToImmutable(MModel);
			MetaOperation_Class = TestIncrementalCompilationBuilderInstance.instance.MetaOperation_Class.ToImmutable(MModel);
			MetaOperation_Enum = TestIncrementalCompilationBuilderInstance.instance.MetaOperation_Enum.ToImmutable(MModel);
			MetaOperation_IsBuilder = TestIncrementalCompilationBuilderInstance.instance.MetaOperation_IsBuilder.ToImmutable(MModel);
			MetaOperation_IsReadonly = TestIncrementalCompilationBuilderInstance.instance.MetaOperation_IsReadonly.ToImmutable(MModel);
			MetaOperation_Parameters = TestIncrementalCompilationBuilderInstance.instance.MetaOperation_Parameters.ToImmutable(MModel);
			MetaOperation_ReturnType = TestIncrementalCompilationBuilderInstance.instance.MetaOperation_ReturnType.ToImmutable(MModel);
			MetaParameter = TestIncrementalCompilationBuilderInstance.instance.MetaParameter.ToImmutable(MModel);
			MetaParameter_Operation = TestIncrementalCompilationBuilderInstance.instance.MetaParameter_Operation.ToImmutable(MModel);
			MetaProperty = TestIncrementalCompilationBuilderInstance.instance.MetaProperty.ToImmutable(MModel);
			MetaProperty_Kind = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_Kind.ToImmutable(MModel);
			MetaProperty_Class = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_Class.ToImmutable(MModel);
			MetaProperty_DefaultValue = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_DefaultValue.ToImmutable(MModel);
			MetaProperty_IsContainment = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_IsContainment.ToImmutable(MModel);
			MetaProperty_OppositeProperties = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_OppositeProperties.ToImmutable(MModel);
			MetaProperty_SubsettedProperties = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_SubsettedProperties.ToImmutable(MModel);
			MetaProperty_SubsettingProperties = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_SubsettingProperties.ToImmutable(MModel);
			MetaProperty_RedefinedProperties = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_RedefinedProperties.ToImmutable(MModel);
			MetaProperty_RedefiningProperties = TestIncrementalCompilationBuilderInstance.instance.MetaProperty_RedefiningProperties.ToImmutable(MModel);
	
			TestIncrementalCompilationInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class TestIncrementalCompilationFactory : global::MetaDslx.Modeling.ModelFactoryBase
	{
		public TestIncrementalCompilationFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
			: base(model, flags)
		{
			TestIncrementalCompilationDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel;
	
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
	
	public interface MetaModel : MetaNamedElement
	{
		string Uri { get; }
		string Prefix { get; }
		MetaNamespace Namespace { get; }
	
	
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
	
	public interface MetaModelBuilder : MetaNamedElementBuilder
	{
		string Uri { get; set; }
		void SetUriLazy(global::System.Func<string> lazy);
		void SetUriLazy(global::System.Func<MetaModelBuilder, string> lazy);
		void SetUriLazy(global::System.Func<MetaModel, string> immutableLazy, global::System.Func<MetaModelBuilder, string> mutableLazy);
		string Prefix { get; set; }
		void SetPrefixLazy(global::System.Func<string> lazy);
		void SetPrefixLazy(global::System.Func<MetaModelBuilder, string> lazy);
		void SetPrefixLazy(global::System.Func<MetaModel, string> immutableLazy, global::System.Func<MetaModelBuilder, string> mutableLazy);
		MetaNamespaceBuilder Namespace { get; set; }
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
	
	public interface MetaConstantBuilder : MetaNamedTypeBuilder, MetaTypedElementBuilder
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
	
	public interface MetaClass : MetaNamedType
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
	
	public interface MetaClassBuilder : MetaNamedTypeBuilder
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

	public static class TestIncrementalCompilationDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static TestIncrementalCompilationDescriptor()
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
			properties.Add(TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaNamespace.DefinedMetaModelProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaNamespace.DeclarationsProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaModel.UriProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaModel.PrefixProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaModel.NamespaceProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaCollectionType.KindProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaCollectionType.InnerTypeProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaNullableType.InnerTypeProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaEnum.EnumLiteralsProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaEnum.OperationsProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaEnumLiteral.EnumProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaConstant.DotNetNameProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaConstant.ValueProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaClass.IsAbstractProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaClass.SuperClassesProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaClass.PropertiesProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaClass.OperationsProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaOperation.ClassProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaOperation.EnumProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaOperation.IsBuilderProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaOperation.IsReadonlyProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaOperation.ParametersProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaOperation.ReturnTypeProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaParameter.OperationProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.KindProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.ClassProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.DefaultValueProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.IsContainmentProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.OppositePropertiesProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.SubsettedPropertiesProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.SubsettingPropertiesProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.RedefinedPropertiesProperty);
			properties.Add(TestIncrementalCompilationDescriptor.MetaProperty.RedefiningPropertiesProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string MUri = "http://metadslx.core/1.0";
		public const string MPrefix = "";
	
		///
		///	Represents an element.
		///	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaElementId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaElement), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaElementBuilder))]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaElement; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AttributesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaElement), name: "Attributes",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaAttribute),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaAttributeBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaElement_Attributes,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaDocumentedElementId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaDocumentedElement), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaDocumentedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaDocumentedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DocumentationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaDocumentedElement), name: "Documentation",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaDocumentedElement_Documentation,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaNamedElementId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamedElement), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaDocumentedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaNamedElement; }
			}
			
			[global::MetaDslx.Modeling.NameAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNamedElement), name: "Name",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaNamedElement_Name,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaTypedElementId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaTypedElement), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaTypedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaTypedElement; }
			}
			
			[global::MetaDslx.Modeling.TypeAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty TypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaTypedElement), name: "Type",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaType),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaTypedElement_Type,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.TypeAttribute]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaTypeId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaType), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaTypeBuilder))]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaType; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaNamedTypeId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamedType), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamedTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaType), typeof(TestIncrementalCompilationDescriptor.MetaDeclaration) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaNamedType; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaAttributeId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaAttribute), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaAttributeBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaAttribute; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaDeclarationId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaDeclaration), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaDeclarationBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaDeclaration; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaNamespace), "Declarations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NamespaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaDeclaration), name: "Namespace",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamespace),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamespaceBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaDeclaration_Namespace,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty MetaModelProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaDeclaration), name: "MetaModel",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaModel),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaModelBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaDeclaration_MetaModel,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty FullNameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaDeclaration), name: "FullName",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaDeclaration_FullName,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaNamespaceId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamespace), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamespaceBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaDeclaration) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaNamespace; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaModel), "Namespace")]
			public static readonly global::MetaDslx.Modeling.ModelProperty DefinedMetaModelProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNamespace), name: "DefinedMetaModel",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaModel),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaModelBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaNamespace_DefinedMetaModel,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaDeclaration), "Namespace")]
			public static readonly global::MetaDslx.Modeling.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNamespace), name: "Declarations",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaDeclaration),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaDeclarationBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaNamespace_Declarations,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaModelId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaModel), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaModelBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaModel; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty UriProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaModel), name: "Uri",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaModel_Uri,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty PrefixProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaModel), name: "Prefix",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaModel_Prefix,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaNamespace), "DefinedMetaModel")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NamespaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaModel), name: "Namespace",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamespace),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNamespaceBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaModel_Namespace,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaCollectionTypeId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaCollectionType), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaCollectionTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaType) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaCollectionType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaCollectionType), name: "Kind",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaCollectionKind),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaCollectionKind),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaCollectionType_Kind,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaCollectionType), name: "InnerType",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaType),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaCollectionType_InnerType,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaNullableTypeId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNullableType), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaNullableTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaType) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaNullableType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaNullableType), name: "InnerType",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaType),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaNullableType_InnerType,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaPrimitiveTypeId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPrimitiveType), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPrimitiveTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedType) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaPrimitiveType; }
			}
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaEnumId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnum), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnumBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedType) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaEnum; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaEnumLiteral), "Enum")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumLiteralsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaEnum), name: "EnumLiterals",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnumLiteral),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnumLiteralBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaEnum_EnumLiterals,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaOperation), "Enum")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaEnum), name: "Operations",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaOperation),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaOperationBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaEnum_Operations,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaEnumLiteralId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnumLiteral), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnumLiteralBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedElement), typeof(TestIncrementalCompilationDescriptor.MetaTypedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaEnumLiteral; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaEnum), "EnumLiterals")]
			[global::MetaDslx.Modeling.RedefinesAttribute(typeof(TestIncrementalCompilationDescriptor.MetaTypedElement), "Type")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaEnumLiteral), name: "Enum",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnum),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnumBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaEnumLiteral_Enum,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaConstantId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaConstant), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaConstantBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedType), typeof(TestIncrementalCompilationDescriptor.MetaTypedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaConstant; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DotNetNameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaConstant), name: "DotNetName",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaConstant_DotNetName,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaConstant), name: "Value",
			        immutableType: typeof(global::MetaDslx.Modeling.IModelObject),
			        mutableType: typeof(global::MetaDslx.Modeling.IModelObject),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaConstant_Value,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaClassId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaClass), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaClassBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedType) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaClass; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "IsAbstract",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaClass_IsAbstract,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.BaseScopeAttribute]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty SuperClassesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "SuperClasses",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaClass),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaClassBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaClass_SuperClasses,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaProperty), "Class")]
			public static readonly global::MetaDslx.Modeling.ModelProperty PropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "Properties",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaProperty),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaClass_Properties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaOperation), "Class")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaClass), name: "Operations",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaOperation),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaOperationBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaClass_Operations,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.LocalScopeAttribute]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaOperationId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaOperation), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaOperationBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaOperation; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaClass), "Operations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ClassProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "Class",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaClass),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaClassBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaOperation_Class,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaEnum), "Operations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "Enum",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnum),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaEnumBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaOperation_Enum,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsBuilderProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "IsBuilder",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaOperation_IsBuilder,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsReadonlyProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "IsReadonly",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaOperation_IsReadonly,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaParameter), "Operation")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ParametersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "Parameters",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaParameter),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaParameterBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaOperation_Parameters,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaOperation), name: "ReturnType",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaType),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaTypeBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaOperation_ReturnType,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaParameterId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaParameter), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaParameterBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedElement), typeof(TestIncrementalCompilationDescriptor.MetaTypedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaParameter; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaOperation), "Parameters")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaParameter), name: "Operation",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaOperation),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaOperationBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaParameter_Operation,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal.MetaPropertyId), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaProperty), typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyBuilder), BaseDescriptors = new global::System.Type[] { typeof(TestIncrementalCompilationDescriptor.MetaNamedElement), typeof(TestIncrementalCompilationDescriptor.MetaTypedElement) })]
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
				get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "Kind",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyKind),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyKind),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_Kind,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaClass), "Properties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ClassProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "Class",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaClass),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaClassBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_Class,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DefaultValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "DefaultValue",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_DefaultValue,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsContainmentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "IsContainment",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_IsContainment,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaProperty), "OppositeProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty OppositePropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "OppositeProperties",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaProperty),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_OppositeProperties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaProperty), "SubsettingProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty SubsettedPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "SubsettedProperties",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaProperty),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_SubsettedProperties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaProperty), "SubsettedProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty SubsettingPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "SubsettingProperties",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaProperty),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_SubsettingProperties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaProperty), "RedefiningProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty RedefinedPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "RedefinedProperties",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaProperty),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_RedefinedProperties,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(TestIncrementalCompilationDescriptor.MetaProperty), "RedefinedProperties")]
			public static readonly global::MetaDslx.Modeling.ModelProperty RedefiningPropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(MetaProperty), name: "RedefiningProperties",
			        immutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaProperty),
			        mutableType: typeof(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.MetaPropertyBuilder),
					metaProperty: () => global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MetaProperty_RedefiningProperties,
					defaultValue: null);
		}
	}
}

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.Internal
{
	
	internal class MetaElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaElement; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaElement(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaElement_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaElement; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	}
	
	internal class MetaDocumentedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaDocumentedElement; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaDocumentedElement(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaDocumentedElement_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaDocumentedElement; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaNamedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaNamedElement; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaNamedElement(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaNamedElement_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaNamedElement; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaTypedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaTypedElement; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, ref type0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaTypedElement(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaTypedElement_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaTypedElement; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaType.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaType; }
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
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaType(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaType_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaType; }
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
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaNamedTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedType.MDescriptor; } }
	
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
	
		internal MetaNamedTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaNamedType; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaNamedType(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaNamedType_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaNamedType; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaAttributeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaAttribute.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaAttribute; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaAttribute(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaAttribute_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaAttribute; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaDeclarationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaDeclaration; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaDeclaration(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaDeclaration_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaDeclaration; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaNamespaceId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamespace.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaNamespace; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public MetaModel DefinedMetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamespace.DefinedMetaModelProperty, ref definedMetaModel0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaDeclaration> Declarations
		{
		    get { return this.GetList<MetaDeclaration>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaNamespace(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaNamespace_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaNamespace; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder DefinedMetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamespace.DefinedMetaModelProperty); }
			set { this.SetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamespace.DefinedMetaModelProperty, value); }
		}
		
		void MetaNamespaceBuilder.SetDefinedMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamespace.DefinedMetaModelProperty, lazy);
		}
		
		void MetaNamespaceBuilder.SetDefinedMetaModelLazy(global::System.Func<MetaNamespaceBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamespace.DefinedMetaModelProperty, lazy);
		}
		
		void MetaNamespaceBuilder.SetDefinedMetaModelLazy(global::System.Func<MetaNamespace, MetaModel> immutableLazy, global::System.Func<MetaNamespaceBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamespace.DefinedMetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaDeclarationBuilder> Declarations
		{
			get { return this.GetList<MetaDeclarationBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class MetaModelId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaModel; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public string Uri
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.UriProperty, ref uri0); }
		}
	
		
		public string Prefix
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.PrefixProperty, ref prefix0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.NamespaceProperty, ref namespace0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaModel(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaModel_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaModel; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Uri
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.UriProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.UriProperty, value); }
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.UriProperty, lazy);
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<MetaModelBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.UriProperty, lazy);
		}
		
		void MetaModelBuilder.SetUriLazy(global::System.Func<MetaModel, string> immutableLazy, global::System.Func<MetaModelBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.UriProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Prefix
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.PrefixProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.PrefixProperty, value); }
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.PrefixProperty, lazy);
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<MetaModelBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.PrefixProperty, lazy);
		}
		
		void MetaModelBuilder.SetPrefixLazy(global::System.Func<MetaModel, string> immutableLazy, global::System.Func<MetaModelBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.PrefixProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaModel.NamespaceProperty, value); }
		}
		
		void MetaModelBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.NamespaceProperty, lazy);
		}
		
		void MetaModelBuilder.SetNamespaceLazy(global::System.Func<MetaModelBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.NamespaceProperty, lazy);
		}
		
		void MetaModelBuilder.SetNamespaceLazy(global::System.Func<MetaModel, MetaNamespace> immutableLazy, global::System.Func<MetaModelBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaModel.NamespaceProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaCollectionTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaCollectionType.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaCollectionType; }
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
		    get { return this.GetValue<MetaCollectionKind>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaCollectionType.KindProperty, ref kind0); }
		}
	
		
		public MetaType InnerType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaCollectionType.InnerTypeProperty, ref innerType0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaCollectionType_ConformsTo(this, type);
		}
	
		
		bool MetaCollectionType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaCollectionType_ConformsTo(this, type);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaCollectionType(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaCollectionType_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaCollectionType; }
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
			get { return this.GetValue<MetaCollectionKind>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaCollectionType.KindProperty); }
			set { this.SetValue<MetaCollectionKind>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaCollectionType.KindProperty, value); }
		}
		
		void MetaCollectionTypeBuilder.SetKindLazy(global::System.Func<MetaCollectionKind> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaCollectionType.KindProperty, lazy);
		}
		
		void MetaCollectionTypeBuilder.SetKindLazy(global::System.Func<MetaCollectionTypeBuilder, MetaCollectionKind> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaCollectionType.KindProperty, lazy);
		}
		
		void MetaCollectionTypeBuilder.SetKindLazy(global::System.Func<MetaCollectionType, MetaCollectionKind> immutableLazy, global::System.Func<MetaCollectionTypeBuilder, MetaCollectionKind> mutableLazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaCollectionType.KindProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder InnerType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaCollectionType.InnerTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaCollectionType.InnerTypeProperty, value); }
		}
		
		void MetaCollectionTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaCollectionType.InnerTypeProperty, lazy);
		}
		
		void MetaCollectionTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaCollectionTypeBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaCollectionType.InnerTypeProperty, lazy);
		}
		
		void MetaCollectionTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaCollectionType, MetaType> immutableLazy, global::System.Func<MetaCollectionTypeBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaCollectionType.InnerTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaCollectionType_ConformsTo(this, type);
		}
	
		
		bool MetaCollectionTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaCollectionType_ConformsTo(this, type);
		}
	}
	
	internal class MetaNullableTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNullableType.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaNullableType; }
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
		    get { return this.GetReference<MetaType>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNullableType.InnerTypeProperty, ref innerType0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaNullableType_ConformsTo(this, type);
		}
	
		
		bool MetaNullableType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaNullableType_ConformsTo(this, type);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaNullableType(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaNullableType_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaNullableType; }
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
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNullableType.InnerTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNullableType.InnerTypeProperty, value); }
		}
		
		void MetaNullableTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNullableType.InnerTypeProperty, lazy);
		}
		
		void MetaNullableTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaNullableTypeBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNullableType.InnerTypeProperty, lazy);
		}
		
		void MetaNullableTypeBuilder.SetInnerTypeLazy(global::System.Func<MetaNullableType, MetaType> immutableLazy, global::System.Func<MetaNullableTypeBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNullableType.InnerTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaNullableType_ConformsTo(this, type);
		}
	
		
		bool MetaNullableTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaNullableType_ConformsTo(this, type);
		}
	}
	
	internal class MetaPrimitiveTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaPrimitiveType.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaPrimitiveType; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaPrimitiveType_ConformsTo(this, type);
		}
	
		
		bool MetaPrimitiveType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaPrimitiveType_ConformsTo(this, type);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaPrimitiveType(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaPrimitiveType_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaPrimitiveType; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaPrimitiveType_ConformsTo(this, type);
		}
	
		
		bool MetaPrimitiveTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaPrimitiveType_ConformsTo(this, type);
		}
	}
	
	internal class MetaEnumId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnum.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaEnum; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaEnumLiteral> EnumLiterals
		{
		    get { return this.GetList<MetaEnumLiteral>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaEnum(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaEnum_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaEnum; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals
		{
			get { return this.GetList<MetaEnumLiteralBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaType_ConformsTo(this, type);
		}
	}
	
	internal class MetaEnumLiteralId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnumLiteral.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaEnumLiteral; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaEnum Enum
		{
		    get { return this.GetReference<MetaEnum>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnumLiteral.EnumProperty, ref enum0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaEnumLiteral(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaEnumLiteral_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaEnumLiteral; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaEnumBuilder Enum
		{
			get { return this.GetReference<MetaEnumBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnumLiteral.EnumProperty); }
			set { this.SetReference<MetaEnumBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaEnumLiteral.EnumProperty, value); }
		}
		
		void MetaEnumLiteralBuilder.SetEnumLazy(global::System.Func<MetaEnumBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaEnumLiteral.EnumProperty, lazy);
		}
		
		void MetaEnumLiteralBuilder.SetEnumLazy(global::System.Func<MetaEnumLiteralBuilder, MetaEnumBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaEnumLiteral.EnumProperty, lazy);
		}
		
		void MetaEnumLiteralBuilder.SetEnumLazy(global::System.Func<MetaEnumLiteral, MetaEnum> immutableLazy, global::System.Func<MetaEnumLiteralBuilder, MetaEnumBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaEnumLiteral.EnumProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaConstantId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaConstant.MDescriptor; } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> attributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaConstant; }
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
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaAttribute> Attributes
		{
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string DotNetName
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaConstant.DotNetNameProperty, ref dotNetName0); }
		}
	
		
		public global::MetaDslx.Modeling.IModelObject Value
		{
		    get { return this.GetReference<global::MetaDslx.Modeling.IModelObject>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaConstant.ValueProperty, ref value0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaConstant_ConformsTo(this, type);
		}
	
		
		bool MetaConstant.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaConstant_ConformsTo(this, type);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaConstant(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaConstant_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaConstant; }
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
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaAttributeBuilder> Attributes
		{
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaConstant.DotNetNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaConstant.DotNetNameProperty, value); }
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaConstant.DotNetNameProperty, lazy);
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<MetaConstantBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaConstant.DotNetNameProperty, lazy);
		}
		
		void MetaConstantBuilder.SetDotNetNameLazy(global::System.Func<MetaConstant, string> immutableLazy, global::System.Func<MetaConstantBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaConstant.DotNetNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.IModelObject Value
		{
			get { return this.GetReference<global::MetaDslx.Modeling.IModelObject>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaConstant.ValueProperty); }
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<global::MetaDslx.Modeling.IModelObject> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaConstant.ValueProperty, lazy);
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<MetaConstantBuilder, global::MetaDslx.Modeling.IModelObject> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaConstant.ValueProperty, lazy);
		}
		
		void MetaConstantBuilder.SetValueLazy(global::System.Func<MetaConstant, global::MetaDslx.Modeling.IModelObject> immutableLazy, global::System.Func<MetaConstantBuilder, global::MetaDslx.Modeling.IModelObject> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaConstant.ValueProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaConstant_ConformsTo(this, type);
		}
	
		
		bool MetaConstantBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaConstant_ConformsTo(this, type);
		}
	}
	
	internal class MetaClassId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaClass; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, ref fullName0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaClass> SuperClasses
		{
		    get { return this.GetList<MetaClass>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> Properties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		bool MetaType.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_ConformsTo(this, type);
		}
	
		
		bool MetaClass.ConformsTo(MetaType type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_ConformsTo(this, type);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaClass> MetaClass.GetAllSuperClasses(bool includeSelf)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass.GetAllSuperProperties(bool includeSelf)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllSuperProperties(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass.GetAllSuperOperations(bool includeSelf)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllSuperOperations(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass.GetAllProperties()
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass.GetAllOperations()
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaProperty> MetaClass.GetAllFinalProperties()
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllFinalProperties(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperation> MetaClass.GetAllFinalOperations()
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllFinalOperations(this);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaClass(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaClass; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetNamespaceLazy(global::System.Func<MetaDeclaration, MetaNamespace> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaNamespaceBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.NamespaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetMetaModelLazy(global::System.Func<MetaDeclaration, MetaModel> immutableLazy, global::System.Func<MetaDeclarationBuilder, MetaModelBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.MetaModelProperty, immutableLazy, mutableLazy);
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty); }
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclarationBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, lazy);
		}
		
		void MetaDeclarationBuilder.SetFullNameLazy(global::System.Func<MetaDeclaration, string> immutableLazy, global::System.Func<MetaDeclarationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDeclaration.FullNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.IsAbstractProperty, value); }
		}
		
		void MetaClassBuilder.SetIsAbstractLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaClass.IsAbstractProperty, lazy);
		}
		
		void MetaClassBuilder.SetIsAbstractLazy(global::System.Func<MetaClassBuilder, bool> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaClass.IsAbstractProperty, lazy);
		}
		
		void MetaClassBuilder.SetIsAbstractLazy(global::System.Func<MetaClass, bool> immutableLazy, global::System.Func<MetaClassBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaClass.IsAbstractProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaClassBuilder> SuperClasses
		{
			get { return this.GetList<MetaClassBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> Properties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		bool MetaTypeBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_ConformsTo(this, type);
		}
	
		
		bool MetaClassBuilder.ConformsTo(MetaTypeBuilder type)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_ConformsTo(this, type);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaClassBuilder> MetaClassBuilder.GetAllSuperClasses(bool includeSelf)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClassBuilder.GetAllSuperProperties(bool includeSelf)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllSuperProperties(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClassBuilder.GetAllSuperOperations(bool includeSelf)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllSuperOperations(this, includeSelf);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClassBuilder.GetAllProperties()
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClassBuilder.GetAllOperations()
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaPropertyBuilder> MetaClassBuilder.GetAllFinalProperties()
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllFinalProperties(this);
		}
	
		
		global::System.Collections.Generic.IReadOnlyList<MetaOperationBuilder> MetaClassBuilder.GetAllFinalOperations()
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaClass_GetAllFinalOperations(this);
		}
	}
	
	internal class MetaOperationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaOperation; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaClass Class
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.ClassProperty, ref class0); }
		}
	
		
		public MetaEnum Enum
		{
		    get { return this.GetReference<MetaEnum>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.EnumProperty, ref enum0); }
		}
	
		
		public bool IsBuilder
		{
		    get { return this.GetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.IsBuilderProperty, ref isBuilder0); }
		}
	
		
		public bool IsReadonly
		{
		    get { return this.GetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.IsReadonlyProperty, ref isReadonly0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaParameter> Parameters
		{
		    get { return this.GetList<MetaParameter>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.ReturnTypeProperty, ref returnType0); }
		}
	
		
		bool MetaOperation.ConformsTo(MetaOperation operation)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaOperation_ConformsTo(this, operation);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaOperation(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaOperation_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaOperation; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaClassBuilder Class
		{
			get { return this.GetReference<MetaClassBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.ClassProperty); }
			set { this.SetReference<MetaClassBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.ClassProperty, value); }
		}
		
		void MetaOperationBuilder.SetClassLazy(global::System.Func<MetaClassBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.ClassProperty, lazy);
		}
		
		void MetaOperationBuilder.SetClassLazy(global::System.Func<MetaOperationBuilder, MetaClassBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.ClassProperty, lazy);
		}
		
		void MetaOperationBuilder.SetClassLazy(global::System.Func<MetaOperation, MetaClass> immutableLazy, global::System.Func<MetaOperationBuilder, MetaClassBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.ClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaEnumBuilder Enum
		{
			get { return this.GetReference<MetaEnumBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.EnumProperty); }
			set { this.SetReference<MetaEnumBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.EnumProperty, value); }
		}
		
		void MetaOperationBuilder.SetEnumLazy(global::System.Func<MetaEnumBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.EnumProperty, lazy);
		}
		
		void MetaOperationBuilder.SetEnumLazy(global::System.Func<MetaOperationBuilder, MetaEnumBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.EnumProperty, lazy);
		}
		
		void MetaOperationBuilder.SetEnumLazy(global::System.Func<MetaOperation, MetaEnum> immutableLazy, global::System.Func<MetaOperationBuilder, MetaEnumBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.EnumProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsBuilder
		{
			get { return this.GetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.IsBuilderProperty); }
			set { this.SetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.IsBuilderProperty, value); }
		}
		
		void MetaOperationBuilder.SetIsBuilderLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaOperation.IsBuilderProperty, lazy);
		}
		
		void MetaOperationBuilder.SetIsBuilderLazy(global::System.Func<MetaOperationBuilder, bool> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaOperation.IsBuilderProperty, lazy);
		}
		
		void MetaOperationBuilder.SetIsBuilderLazy(global::System.Func<MetaOperation, bool> immutableLazy, global::System.Func<MetaOperationBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaOperation.IsBuilderProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsReadonly
		{
			get { return this.GetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.IsReadonlyProperty); }
			set { this.SetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.IsReadonlyProperty, value); }
		}
		
		void MetaOperationBuilder.SetIsReadonlyLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaOperation.IsReadonlyProperty, lazy);
		}
		
		void MetaOperationBuilder.SetIsReadonlyLazy(global::System.Func<MetaOperationBuilder, bool> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaOperation.IsReadonlyProperty, lazy);
		}
		
		void MetaOperationBuilder.SetIsReadonlyLazy(global::System.Func<MetaOperation, bool> immutableLazy, global::System.Func<MetaOperationBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaOperation.IsReadonlyProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaParameterBuilder> Parameters
		{
			get { return this.GetList<MetaParameterBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaOperation.ReturnTypeProperty, value); }
		}
		
		void MetaOperationBuilder.SetReturnTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.ReturnTypeProperty, lazy);
		}
		
		void MetaOperationBuilder.SetReturnTypeLazy(global::System.Func<MetaOperationBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.ReturnTypeProperty, lazy);
		}
		
		void MetaOperationBuilder.SetReturnTypeLazy(global::System.Func<MetaOperation, MetaType> immutableLazy, global::System.Func<MetaOperationBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaOperation.ReturnTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		bool MetaOperationBuilder.ConformsTo(MetaOperationBuilder operation)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaOperation_ConformsTo(this, operation);
		}
	}
	
	internal class MetaParameterId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaParameter.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaParameter; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaOperation Operation
		{
		    get { return this.GetReference<MetaOperation>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaParameter.OperationProperty, ref operation0); }
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaParameter(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaParameter_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaParameter; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaOperationBuilder Operation
		{
			get { return this.GetReference<MetaOperationBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaParameter.OperationProperty); }
			set { this.SetReference<MetaOperationBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaParameter.OperationProperty, value); }
		}
		
		void MetaParameterBuilder.SetOperationLazy(global::System.Func<MetaOperationBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaParameter.OperationProperty, lazy);
		}
		
		void MetaParameterBuilder.SetOperationLazy(global::System.Func<MetaParameterBuilder, MetaOperationBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaParameter.OperationProperty, lazy);
		}
		
		void MetaParameterBuilder.SetOperationLazy(global::System.Func<MetaParameter, MetaOperation> immutableLazy, global::System.Func<MetaParameterBuilder, MetaOperationBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaParameter.OperationProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class MetaPropertyId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.MDescriptor; } }
	
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
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaProperty; }
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
		    get { return this.GetList<MetaAttribute>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaPropertyKind Kind
		{
		    get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.KindProperty, ref kind0); }
		}
	
		
		public MetaClass Class
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.ClassProperty, ref class0); }
		}
	
		
		public string DefaultValue
		{
		    get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		public bool IsContainment
		{
		    get { return this.GetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.IsContainmentProperty, ref isContainment0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> OppositeProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> SubsettingProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefinedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<MetaProperty> RedefiningProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	
		
		bool MetaProperty.ConformsTo(MetaProperty property)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaProperty_ConformsTo(this, property);
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
			TestIncrementalCompilationImplementationProvider.Implementation.MetaProperty(this);
		}
	
		public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
			TestIncrementalCompilationImplementationProvider.Implementation.MetaProperty_MValidate(this, diagnostics, cancellationToken);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return TestIncrementalCompilationInstance.MetaProperty; }
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
			get { return this.GetList<MetaAttributeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaElement.AttributesProperty, ref attributes0); }
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, lazy);
		}
		
		void MetaDocumentedElementBuilder.SetDocumentationLazy(global::System.Func<MetaDocumentedElement, string> immutableLazy, global::System.Func<MetaDocumentedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaDocumentedElement.DocumentationProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, lazy);
		}
		
		void MetaTypedElementBuilder.SetTypeLazy(global::System.Func<MetaTypedElement, MetaType> immutableLazy, global::System.Func<MetaTypedElementBuilder, MetaTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaTypedElement.TypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, lazy);
		}
		
		void MetaNamedElementBuilder.SetNameLazy(global::System.Func<MetaNamedElement, string> immutableLazy, global::System.Func<MetaNamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaNamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaPropertyKind Kind
		{
			get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.KindProperty); }
			set { this.SetValue<MetaPropertyKind>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.KindProperty, value); }
		}
		
		void MetaPropertyBuilder.SetKindLazy(global::System.Func<MetaPropertyKind> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaProperty.KindProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetKindLazy(global::System.Func<MetaPropertyBuilder, MetaPropertyKind> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaProperty.KindProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetKindLazy(global::System.Func<MetaProperty, MetaPropertyKind> immutableLazy, global::System.Func<MetaPropertyBuilder, MetaPropertyKind> mutableLazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaProperty.KindProperty, immutableLazy, mutableLazy);
		}
	
		
		public MetaClassBuilder Class
		{
			get { return this.GetReference<MetaClassBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.ClassProperty); }
			set { this.SetReference<MetaClassBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.ClassProperty, value); }
		}
		
		void MetaPropertyBuilder.SetClassLazy(global::System.Func<MetaClassBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaProperty.ClassProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetClassLazy(global::System.Func<MetaPropertyBuilder, MetaClassBuilder> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaProperty.ClassProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetClassLazy(global::System.Func<MetaProperty, MetaClass> immutableLazy, global::System.Func<MetaPropertyBuilder, MetaClassBuilder> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaProperty.ClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public string DefaultValue
		{
			get { return this.GetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.DefaultValueProperty); }
			set { this.SetReference<string>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.DefaultValueProperty, value); }
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaProperty.DefaultValueProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<MetaPropertyBuilder, string> lazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaProperty.DefaultValueProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetDefaultValueLazy(global::System.Func<MetaProperty, string> immutableLazy, global::System.Func<MetaPropertyBuilder, string> mutableLazy)
		{
			this.SetLazyReference(TestIncrementalCompilationDescriptor.MetaProperty.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsContainment
		{
			get { return this.GetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.IsContainmentProperty); }
			set { this.SetValue<bool>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.IsContainmentProperty, value); }
		}
		
		void MetaPropertyBuilder.SetIsContainmentLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaProperty.IsContainmentProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetIsContainmentLazy(global::System.Func<MetaPropertyBuilder, bool> lazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaProperty.IsContainmentProperty, lazy);
		}
		
		void MetaPropertyBuilder.SetIsContainmentLazy(global::System.Func<MetaProperty, bool> immutableLazy, global::System.Func<MetaPropertyBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(TestIncrementalCompilationDescriptor.MetaProperty.IsContainmentProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> OppositeProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> SubsettingProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefinedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<MetaPropertyBuilder> RedefiningProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	
		
		bool MetaPropertyBuilder.ConformsTo(MetaPropertyBuilder property)
		{
		    return TestIncrementalCompilationImplementationProvider.Implementation.MetaProperty_ConformsTo(this, property);
		}
	}

	internal class TestIncrementalCompilationBuilderInstance
	{
		internal static TestIncrementalCompilationBuilderInstance instance = new TestIncrementalCompilationBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Modeling.MutableModel MModel;
		internal global::MetaDslx.Modeling.MutableModelGroup MModelGroup;
	
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
	
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp2;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp4;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp5;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp6;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp7;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp8;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp9;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp10;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp11;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp12;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp13;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp14;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp15;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp16;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp17;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp18;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp19;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp20;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp21;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaElement_Attributes;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaDocumentedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaDocumentedElement_Documentation;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaNamedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaNamedElement_Name;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaTypedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaTypedElement_Type;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaType;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp26;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp32;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaNamedType;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaAttribute;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaDeclaration;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaDeclaration_Namespace;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaDeclaration_MetaModel;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaDeclaration_FullName;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaNamespace;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaNamespace_DefinedMetaModel;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaNamespace_Declarations;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaModel;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaModel_Uri;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaModel_Prefix;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaModel_Namespace;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder MetaCollectionKind;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp23;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp25;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp27;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp28;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaCollectionType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaCollectionType_Kind;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaCollectionType_InnerType;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp34;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp35;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaNullableType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaNullableType_InnerType;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp24;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp30;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaPrimitiveType;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp36;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp37;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaEnum;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaEnum_EnumLiterals;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaEnum_Operations;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaEnumLiteral;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaEnumLiteral_Enum;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaConstant;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaConstant_DotNetName;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaConstant_Value;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp45;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp46;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaClass;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaClass_IsAbstract;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaClass_SuperClasses;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaClass_Properties;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaClass_Operations;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp51;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp68;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp52;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp70;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp54;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp72;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp55;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp74;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp56;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp57;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp59;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp60;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaOperation;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaOperation_Class;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaOperation_Enum;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaOperation_IsBuilder;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaOperation_IsReadonly;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaOperation_Parameters;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaOperation_ReturnType;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp43;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp44;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaParameter;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaParameter_Operation;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder MetaPropertyKind;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp38;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp39;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp40;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp41;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp42;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder MetaProperty;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_Kind;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_Class;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_DefaultValue;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_IsContainment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_OppositeProperties;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_SubsettedProperties;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_SubsettingProperties;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_RedefinedProperties;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder MetaProperty_RedefiningProperties;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp47;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp48;
		private global::MetaDslx.Languages.Meta.Model.MetaModelBuilder __tmp22;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp29;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp31;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp33;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp49;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp50;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp53;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp58;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp61;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp62;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp63;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp64;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp65;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp66;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp67;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp69;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp71;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp73;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp75;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp76;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp77;
	
		internal TestIncrementalCompilationBuilderInstance()
		{
			this.MModelGroup = new global::MetaDslx.Modeling.MutableModelGroup();
			this.MModelGroup.AddReference(global::MetaDslx.Languages.Meta.Model.MetaInstance.MModel.ToMutable(true));
			this.MModel = this.MModelGroup.CreateModel("TestIncrementalCompilation");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			this.CreateInstances();
			TestIncrementalCompilationImplementationProvider.Implementation.TestIncrementalCompilationBuilderInstance(this);
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
			TestIncrementalCompilationFactory constantFactory = new TestIncrementalCompilationFactory(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);
	
			Object = constantFactory.MetaPrimitiveType();
			Object.MName = "object";
			String = constantFactory.MetaPrimitiveType();
			String.MName = "string";
			Int = constantFactory.MetaPrimitiveType();
			Int.MName = "int";
			Long = constantFactory.MetaPrimitiveType();
			Long.MName = "long";
			Float = constantFactory.MetaPrimitiveType();
			Float.MName = "float";
			Double = constantFactory.MetaPrimitiveType();
			Double.MName = "double";
			Byte = constantFactory.MetaPrimitiveType();
			Byte.MName = "byte";
			Bool = constantFactory.MetaPrimitiveType();
			Bool.MName = "bool";
			Void = constantFactory.MetaPrimitiveType();
			Void.MName = "void";
			ModelObject = constantFactory.MetaPrimitiveType();
			ModelObject.MName = "global::MetaDslx.Modeling.IModelObject";
			NameAttribute = constantFactory.MetaAttribute();
			NameAttribute.MName = "NameAttribute";
			TypeAttribute = constantFactory.MetaAttribute();
			TypeAttribute.MName = "TypeAttribute";
			ScopeAttribute = constantFactory.MetaAttribute();
			ScopeAttribute.MName = "ScopeAttribute";
			BaseScopeAttribute = constantFactory.MetaAttribute();
			BaseScopeAttribute.MName = "BaseScopeAttribute";
			LocalScopeAttribute = constantFactory.MetaAttribute();
			LocalScopeAttribute.MName = "LocalScopeAttribute";
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaNamespace();
			__tmp5 = factory.MetaNamespace();
			__tmp6 = factory.MetaNamespace();
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
			__tmp21 = factory.MetaConstant();
			MetaElement = factory.MetaClass();
			MetaElement_Attributes = factory.MetaProperty();
			MetaDocumentedElement = factory.MetaClass();
			MetaDocumentedElement_Documentation = factory.MetaProperty();
			MetaNamedElement = factory.MetaClass();
			MetaNamedElement_Name = factory.MetaProperty();
			MetaTypedElement = factory.MetaClass();
			MetaTypedElement_Type = factory.MetaProperty();
			MetaType = factory.MetaClass();
			__tmp26 = factory.MetaOperation();
			__tmp32 = factory.MetaParameter();
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
			__tmp25 = factory.MetaEnumLiteral();
			__tmp27 = factory.MetaEnumLiteral();
			__tmp28 = factory.MetaEnumLiteral();
			MetaCollectionType = factory.MetaClass();
			MetaCollectionType_Kind = factory.MetaProperty();
			MetaCollectionType_InnerType = factory.MetaProperty();
			__tmp34 = factory.MetaOperation();
			__tmp35 = factory.MetaParameter();
			MetaNullableType = factory.MetaClass();
			MetaNullableType_InnerType = factory.MetaProperty();
			__tmp24 = factory.MetaOperation();
			__tmp30 = factory.MetaParameter();
			MetaPrimitiveType = factory.MetaClass();
			__tmp36 = factory.MetaOperation();
			__tmp37 = factory.MetaParameter();
			MetaEnum = factory.MetaClass();
			MetaEnum_EnumLiterals = factory.MetaProperty();
			MetaEnum_Operations = factory.MetaProperty();
			MetaEnumLiteral = factory.MetaClass();
			MetaEnumLiteral_Enum = factory.MetaProperty();
			MetaConstant = factory.MetaClass();
			MetaConstant_DotNetName = factory.MetaProperty();
			MetaConstant_Value = factory.MetaProperty();
			__tmp45 = factory.MetaOperation();
			__tmp46 = factory.MetaParameter();
			MetaClass = factory.MetaClass();
			MetaClass_IsAbstract = factory.MetaProperty();
			MetaClass_SuperClasses = factory.MetaProperty();
			MetaClass_Properties = factory.MetaProperty();
			MetaClass_Operations = factory.MetaProperty();
			__tmp51 = factory.MetaOperation();
			__tmp68 = factory.MetaParameter();
			__tmp52 = factory.MetaOperation();
			__tmp70 = factory.MetaParameter();
			__tmp54 = factory.MetaOperation();
			__tmp72 = factory.MetaParameter();
			__tmp55 = factory.MetaOperation();
			__tmp74 = factory.MetaParameter();
			__tmp56 = factory.MetaOperation();
			__tmp57 = factory.MetaOperation();
			__tmp59 = factory.MetaOperation();
			__tmp60 = factory.MetaOperation();
			MetaOperation = factory.MetaClass();
			MetaOperation_Class = factory.MetaProperty();
			MetaOperation_Enum = factory.MetaProperty();
			MetaOperation_IsBuilder = factory.MetaProperty();
			MetaOperation_IsReadonly = factory.MetaProperty();
			MetaOperation_Parameters = factory.MetaProperty();
			MetaOperation_ReturnType = factory.MetaProperty();
			__tmp43 = factory.MetaOperation();
			__tmp44 = factory.MetaParameter();
			MetaParameter = factory.MetaClass();
			MetaParameter_Operation = factory.MetaProperty();
			MetaPropertyKind = factory.MetaEnum();
			__tmp38 = factory.MetaEnumLiteral();
			__tmp39 = factory.MetaEnumLiteral();
			__tmp40 = factory.MetaEnumLiteral();
			__tmp41 = factory.MetaEnumLiteral();
			__tmp42 = factory.MetaEnumLiteral();
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
			__tmp47 = factory.MetaOperation();
			__tmp48 = factory.MetaParameter();
			__tmp22 = factory.MetaModel();
			__tmp29 = factory.MetaCollectionType();
			__tmp31 = factory.MetaCollectionType();
			__tmp33 = factory.MetaCollectionType();
			__tmp49 = factory.MetaCollectionType();
			__tmp50 = factory.MetaCollectionType();
			__tmp53 = factory.MetaCollectionType();
			__tmp58 = factory.MetaCollectionType();
			__tmp61 = factory.MetaCollectionType();
			__tmp62 = factory.MetaCollectionType();
			__tmp63 = factory.MetaCollectionType();
			__tmp64 = factory.MetaCollectionType();
			__tmp65 = factory.MetaCollectionType();
			__tmp66 = factory.MetaCollectionType();
			__tmp67 = factory.MetaCollectionType();
			__tmp69 = factory.MetaCollectionType();
			__tmp71 = factory.MetaCollectionType();
			__tmp73 = factory.MetaCollectionType();
			__tmp75 = factory.MetaCollectionType();
			__tmp76 = factory.MetaCollectionType();
			__tmp77 = factory.MetaCollectionType();
	
			__tmp1.Documentation = null;
			__tmp1.Name = "MetaDslx";
			// __tmp1.Namespace = null;
			// __tmp1.DefinedMetaModel = null;
			__tmp1.Declarations.AddLazy(() => __tmp2);
			__tmp2.Documentation = null;
			__tmp2.Name = "CodeAnalysis";
			__tmp2.SetNamespaceLazy(() => __tmp1);
			// __tmp2.DefinedMetaModel = null;
			__tmp2.Declarations.AddLazy(() => __tmp3);
			__tmp3.Documentation = null;
			__tmp3.Name = "Antlr4Test";
			__tmp3.SetNamespaceLazy(() => __tmp2);
			// __tmp3.DefinedMetaModel = null;
			__tmp3.Declarations.AddLazy(() => __tmp4);
			__tmp4.Documentation = null;
			__tmp4.Name = "Languages";
			__tmp4.SetNamespaceLazy(() => __tmp3);
			// __tmp4.DefinedMetaModel = null;
			__tmp4.Declarations.AddLazy(() => __tmp5);
			__tmp5.Documentation = null;
			__tmp5.Name = "TestIncrementalCompilation";
			__tmp5.SetNamespaceLazy(() => __tmp4);
			// __tmp5.DefinedMetaModel = null;
			__tmp5.Declarations.AddLazy(() => __tmp6);
			__tmp6.Documentation = null;
			__tmp6.Name = "Symbols";
			__tmp6.SetNamespaceLazy(() => __tmp5);
			__tmp6.SetDefinedMetaModelLazy(() => __tmp22);
			__tmp6.Declarations.AddLazy(() => __tmp7);
			__tmp6.Declarations.AddLazy(() => __tmp8);
			__tmp6.Declarations.AddLazy(() => __tmp9);
			__tmp6.Declarations.AddLazy(() => __tmp10);
			__tmp6.Declarations.AddLazy(() => __tmp11);
			__tmp6.Declarations.AddLazy(() => __tmp12);
			__tmp6.Declarations.AddLazy(() => __tmp13);
			__tmp6.Declarations.AddLazy(() => __tmp14);
			__tmp6.Declarations.AddLazy(() => __tmp15);
			__tmp6.Declarations.AddLazy(() => __tmp16);
			__tmp6.Declarations.AddLazy(() => __tmp17);
			__tmp6.Declarations.AddLazy(() => __tmp18);
			__tmp6.Declarations.AddLazy(() => __tmp19);
			__tmp6.Declarations.AddLazy(() => __tmp20);
			__tmp6.Declarations.AddLazy(() => __tmp21);
			__tmp6.Declarations.AddLazy(() => MetaElement);
			__tmp6.Declarations.AddLazy(() => MetaDocumentedElement);
			__tmp6.Declarations.AddLazy(() => MetaNamedElement);
			__tmp6.Declarations.AddLazy(() => MetaTypedElement);
			__tmp6.Declarations.AddLazy(() => MetaType);
			__tmp6.Declarations.AddLazy(() => MetaNamedType);
			__tmp6.Declarations.AddLazy(() => MetaAttribute);
			__tmp6.Declarations.AddLazy(() => MetaDeclaration);
			__tmp6.Declarations.AddLazy(() => MetaNamespace);
			__tmp6.Declarations.AddLazy(() => MetaModel);
			__tmp6.Declarations.AddLazy(() => MetaCollectionKind);
			__tmp6.Declarations.AddLazy(() => MetaCollectionType);
			__tmp6.Declarations.AddLazy(() => MetaNullableType);
			__tmp6.Declarations.AddLazy(() => MetaPrimitiveType);
			__tmp6.Declarations.AddLazy(() => MetaEnum);
			__tmp6.Declarations.AddLazy(() => MetaEnumLiteral);
			__tmp6.Declarations.AddLazy(() => MetaConstant);
			__tmp6.Declarations.AddLazy(() => MetaClass);
			__tmp6.Declarations.AddLazy(() => MetaOperation);
			__tmp6.Declarations.AddLazy(() => MetaParameter);
			__tmp6.Declarations.AddLazy(() => MetaPropertyKind);
			__tmp6.Declarations.AddLazy(() => MetaProperty);
			__tmp7.SetTypeLazy(() => MetaPrimitiveType);
			__tmp7.Documentation = null;
			__tmp7.Name = "Object";
			__tmp7.SetNamespaceLazy(() => __tmp6);
			__tmp7.DotNetName = "object";
			__tmp7.SetValueLazy(() => Object);
			__tmp8.SetTypeLazy(() => MetaPrimitiveType);
			__tmp8.Documentation = null;
			__tmp8.Name = "String";
			__tmp8.SetNamespaceLazy(() => __tmp6);
			__tmp8.DotNetName = "string";
			__tmp8.SetValueLazy(() => String);
			__tmp9.SetTypeLazy(() => MetaPrimitiveType);
			__tmp9.Documentation = null;
			__tmp9.Name = "Int";
			__tmp9.SetNamespaceLazy(() => __tmp6);
			__tmp9.DotNetName = "int";
			__tmp9.SetValueLazy(() => Int);
			__tmp10.SetTypeLazy(() => MetaPrimitiveType);
			__tmp10.Documentation = null;
			__tmp10.Name = "Long";
			__tmp10.SetNamespaceLazy(() => __tmp6);
			__tmp10.DotNetName = "long";
			__tmp10.SetValueLazy(() => Long);
			__tmp11.SetTypeLazy(() => MetaPrimitiveType);
			__tmp11.Documentation = null;
			__tmp11.Name = "Float";
			__tmp11.SetNamespaceLazy(() => __tmp6);
			__tmp11.DotNetName = "float";
			__tmp11.SetValueLazy(() => Float);
			__tmp12.SetTypeLazy(() => MetaPrimitiveType);
			__tmp12.Documentation = null;
			__tmp12.Name = "Double";
			__tmp12.SetNamespaceLazy(() => __tmp6);
			__tmp12.DotNetName = "double";
			__tmp12.SetValueLazy(() => Double);
			__tmp13.SetTypeLazy(() => MetaPrimitiveType);
			__tmp13.Documentation = null;
			__tmp13.Name = "Byte";
			__tmp13.SetNamespaceLazy(() => __tmp6);
			__tmp13.DotNetName = "byte";
			__tmp13.SetValueLazy(() => Byte);
			__tmp14.SetTypeLazy(() => MetaPrimitiveType);
			__tmp14.Documentation = null;
			__tmp14.Name = "Bool";
			__tmp14.SetNamespaceLazy(() => __tmp6);
			__tmp14.DotNetName = "bool";
			__tmp14.SetValueLazy(() => Bool);
			__tmp15.SetTypeLazy(() => MetaPrimitiveType);
			__tmp15.Documentation = null;
			__tmp15.Name = "Void";
			__tmp15.SetNamespaceLazy(() => __tmp6);
			__tmp15.DotNetName = "void";
			__tmp15.SetValueLazy(() => Void);
			__tmp16.SetTypeLazy(() => MetaPrimitiveType);
			__tmp16.Documentation = null;
			__tmp16.Name = "ModelObject";
			__tmp16.SetNamespaceLazy(() => __tmp6);
			__tmp16.DotNetName = "global::MetaDslx.Modeling.IModelObject";
			__tmp16.SetValueLazy(() => ModelObject);
			__tmp17.SetTypeLazy(() => MetaAttribute);
			__tmp17.Documentation = null;
			__tmp17.Name = "NameAttribute";
			__tmp17.SetNamespaceLazy(() => __tmp6);
			__tmp17.DotNetName = "NameAttribute";
			__tmp17.SetValueLazy(() => NameAttribute);
			__tmp18.SetTypeLazy(() => MetaAttribute);
			__tmp18.Documentation = null;
			__tmp18.Name = "TypeAttribute";
			__tmp18.SetNamespaceLazy(() => __tmp6);
			__tmp18.DotNetName = "TypeAttribute";
			__tmp18.SetValueLazy(() => TypeAttribute);
			__tmp19.SetTypeLazy(() => MetaAttribute);
			__tmp19.Documentation = null;
			__tmp19.Name = "ScopeAttribute";
			__tmp19.SetNamespaceLazy(() => __tmp6);
			__tmp19.DotNetName = "ScopeAttribute";
			__tmp19.SetValueLazy(() => ScopeAttribute);
			__tmp20.SetTypeLazy(() => MetaAttribute);
			__tmp20.Documentation = null;
			__tmp20.Name = "BaseScopeAttribute";
			__tmp20.SetNamespaceLazy(() => __tmp6);
			__tmp20.DotNetName = "BaseScopeAttribute";
			__tmp20.SetValueLazy(() => BaseScopeAttribute);
			__tmp21.SetTypeLazy(() => MetaAttribute);
			__tmp21.Documentation = null;
			__tmp21.Name = "LocalScopeAttribute";
			__tmp21.SetNamespaceLazy(() => __tmp6);
			__tmp21.DotNetName = "LocalScopeAttribute";
			__tmp21.SetValueLazy(() => LocalScopeAttribute);
			MetaElement.Documentation = "\n\tRepresents an element.\n\t\r\n";
			MetaElement.Name = "MetaElement";
			MetaElement.SetNamespaceLazy(() => __tmp6);
			// MetaElement.IsAbstract = null;
			MetaElement.Properties.AddLazy(() => MetaElement_Attributes);
			MetaElement_Attributes.SetTypeLazy(() => __tmp33);
			MetaElement_Attributes.Documentation = "";
			MetaElement_Attributes.Name = "Attributes";
			// MetaElement_Attributes.Kind = null;
			MetaElement_Attributes.SetClassLazy(() => MetaElement);
			MetaElement_Attributes.DefaultValue = null;
			// MetaElement_Attributes.IsContainment = null;
			MetaDocumentedElement.Documentation = "";
			MetaDocumentedElement.Name = "MetaDocumentedElement";
			MetaDocumentedElement.SetNamespaceLazy(() => __tmp6);
			// MetaDocumentedElement.IsAbstract = null;
			MetaDocumentedElement.SuperClasses.AddLazy(() => MetaElement);
			MetaDocumentedElement.Properties.AddLazy(() => MetaDocumentedElement_Documentation);
			MetaDocumentedElement_Documentation.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			MetaDocumentedElement_Documentation.Documentation = "";
			MetaDocumentedElement_Documentation.Name = "Documentation";
			// MetaDocumentedElement_Documentation.Kind = null;
			MetaDocumentedElement_Documentation.SetClassLazy(() => MetaDocumentedElement);
			MetaDocumentedElement_Documentation.DefaultValue = null;
			// MetaDocumentedElement_Documentation.IsContainment = null;
			MetaNamedElement.Documentation = "";
			MetaNamedElement.Name = "MetaNamedElement";
			MetaNamedElement.SetNamespaceLazy(() => __tmp6);
			// MetaNamedElement.IsAbstract = null;
			MetaNamedElement.SuperClasses.AddLazy(() => MetaDocumentedElement);
			MetaNamedElement.Properties.AddLazy(() => MetaNamedElement_Name);
			MetaNamedElement_Name.Attributes.Add(global::MetaDslx.Languages.Meta.Model.MetaInstance.NameAttribute.ToMutable());
			MetaNamedElement_Name.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			MetaNamedElement_Name.Documentation = "";
			MetaNamedElement_Name.Name = "Name";
			// MetaNamedElement_Name.Kind = null;
			MetaNamedElement_Name.SetClassLazy(() => MetaNamedElement);
			MetaNamedElement_Name.DefaultValue = null;
			// MetaNamedElement_Name.IsContainment = null;
			MetaTypedElement.Documentation = "";
			MetaTypedElement.Name = "MetaTypedElement";
			MetaTypedElement.SetNamespaceLazy(() => __tmp6);
			// MetaTypedElement.IsAbstract = null;
			MetaTypedElement.SuperClasses.AddLazy(() => MetaElement);
			MetaTypedElement.Properties.AddLazy(() => MetaTypedElement_Type);
			MetaTypedElement_Type.Attributes.Add(global::MetaDslx.Languages.Meta.Model.MetaInstance.TypeAttribute.ToMutable());
			MetaTypedElement_Type.SetTypeLazy(() => MetaType);
			MetaTypedElement_Type.Documentation = "";
			MetaTypedElement_Type.Name = "Type";
			// MetaTypedElement_Type.Kind = null;
			MetaTypedElement_Type.SetClassLazy(() => MetaTypedElement);
			MetaTypedElement_Type.DefaultValue = null;
			// MetaTypedElement_Type.IsContainment = null;
			MetaTypedElement_Type.RedefiningProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaType.Attributes.Add(global::MetaDslx.Languages.Meta.Model.MetaInstance.TypeAttribute.ToMutable());
			MetaType.Documentation = "";
			MetaType.Name = "MetaType";
			MetaType.SetNamespaceLazy(() => __tmp6);
			// MetaType.IsAbstract = null;
			MetaType.Operations.AddLazy(() => __tmp26);
			__tmp26.Documentation = "";
			__tmp26.Name = "ConformsTo";
			__tmp26.SetClassLazy(() => MetaType);
			// __tmp26.Enum = null;
			// __tmp26.IsBuilder = null;
			// __tmp26.IsReadonly = null;
			__tmp26.Parameters.AddLazy(() => __tmp32);
			__tmp26.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp32.SetTypeLazy(() => MetaType);
			__tmp32.Documentation = null;
			__tmp32.Name = "type";
			__tmp32.SetOperationLazy(() => __tmp26);
			MetaNamedType.Documentation = "";
			MetaNamedType.Name = "MetaNamedType";
			MetaNamedType.SetNamespaceLazy(() => __tmp6);
			// MetaNamedType.IsAbstract = null;
			MetaNamedType.SuperClasses.AddLazy(() => MetaType);
			MetaNamedType.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaAttribute.Documentation = "";
			MetaAttribute.Name = "MetaAttribute";
			MetaAttribute.SetNamespaceLazy(() => __tmp6);
			// MetaAttribute.IsAbstract = null;
			MetaAttribute.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.Documentation = "";
			MetaDeclaration.Name = "MetaDeclaration";
			MetaDeclaration.SetNamespaceLazy(() => __tmp6);
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
			MetaDeclaration_FullName.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			MetaDeclaration_FullName.Documentation = "";
			MetaDeclaration_FullName.Name = "FullName";
			MetaDeclaration_FullName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			MetaDeclaration_FullName.SetClassLazy(() => MetaDeclaration);
			MetaDeclaration_FullName.DefaultValue = null;
			// MetaDeclaration_FullName.IsContainment = null;
			MetaNamespace.Attributes.Add(global::MetaDslx.Languages.Meta.Model.MetaInstance.ScopeAttribute.ToMutable());
			MetaNamespace.Documentation = "";
			MetaNamespace.Name = "MetaNamespace";
			MetaNamespace.SetNamespaceLazy(() => __tmp6);
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
			MetaNamespace_Declarations.SetTypeLazy(() => __tmp31);
			MetaNamespace_Declarations.Documentation = "";
			MetaNamespace_Declarations.Name = "Declarations";
			// MetaNamespace_Declarations.Kind = null;
			MetaNamespace_Declarations.SetClassLazy(() => MetaNamespace);
			MetaNamespace_Declarations.DefaultValue = null;
			MetaNamespace_Declarations.IsContainment = true;
			MetaNamespace_Declarations.OppositeProperties.AddLazy(() => MetaDeclaration_Namespace);
			MetaModel.Documentation = "";
			MetaModel.Name = "MetaModel";
			MetaModel.SetNamespaceLazy(() => __tmp6);
			// MetaModel.IsAbstract = null;
			MetaModel.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaModel.Properties.AddLazy(() => MetaModel_Uri);
			MetaModel.Properties.AddLazy(() => MetaModel_Prefix);
			MetaModel.Properties.AddLazy(() => MetaModel_Namespace);
			MetaModel_Uri.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			MetaModel_Uri.Documentation = "";
			MetaModel_Uri.Name = "Uri";
			// MetaModel_Uri.Kind = null;
			MetaModel_Uri.SetClassLazy(() => MetaModel);
			MetaModel_Uri.DefaultValue = null;
			// MetaModel_Uri.IsContainment = null;
			MetaModel_Prefix.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
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
			MetaCollectionKind.SetNamespaceLazy(() => __tmp6);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp23);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp25);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp27);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp28);
			__tmp23.Documentation = "";
			__tmp23.Name = "List";
			__tmp23.SetEnumLazy(() => MetaCollectionKind);
			__tmp25.Documentation = "";
			__tmp25.Name = "Set";
			__tmp25.SetEnumLazy(() => MetaCollectionKind);
			__tmp27.Documentation = "";
			__tmp27.Name = "MultiList";
			__tmp27.SetEnumLazy(() => MetaCollectionKind);
			__tmp28.Documentation = "";
			__tmp28.Name = "MultiSet";
			__tmp28.SetEnumLazy(() => MetaCollectionKind);
			MetaCollectionType.Documentation = "";
			MetaCollectionType.Name = "MetaCollectionType";
			MetaCollectionType.SetNamespaceLazy(() => __tmp6);
			// MetaCollectionType.IsAbstract = null;
			MetaCollectionType.SuperClasses.AddLazy(() => MetaType);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_Kind);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_InnerType);
			MetaCollectionType.Operations.AddLazy(() => __tmp34);
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
			__tmp34.Documentation = "";
			__tmp34.Name = "ConformsTo";
			__tmp34.SetClassLazy(() => MetaCollectionType);
			// __tmp34.Enum = null;
			// __tmp34.IsBuilder = null;
			// __tmp34.IsReadonly = null;
			__tmp34.Parameters.AddLazy(() => __tmp35);
			__tmp34.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp35.SetTypeLazy(() => MetaType);
			__tmp35.Documentation = null;
			__tmp35.Name = "type";
			__tmp35.SetOperationLazy(() => __tmp34);
			MetaNullableType.Documentation = "";
			MetaNullableType.Name = "MetaNullableType";
			MetaNullableType.SetNamespaceLazy(() => __tmp6);
			// MetaNullableType.IsAbstract = null;
			MetaNullableType.SuperClasses.AddLazy(() => MetaType);
			MetaNullableType.Properties.AddLazy(() => MetaNullableType_InnerType);
			MetaNullableType.Operations.AddLazy(() => __tmp24);
			MetaNullableType_InnerType.SetTypeLazy(() => MetaType);
			MetaNullableType_InnerType.Documentation = "";
			MetaNullableType_InnerType.Name = "InnerType";
			// MetaNullableType_InnerType.Kind = null;
			MetaNullableType_InnerType.SetClassLazy(() => MetaNullableType);
			MetaNullableType_InnerType.DefaultValue = null;
			// MetaNullableType_InnerType.IsContainment = null;
			__tmp24.Documentation = "";
			__tmp24.Name = "ConformsTo";
			__tmp24.SetClassLazy(() => MetaNullableType);
			// __tmp24.Enum = null;
			// __tmp24.IsBuilder = null;
			// __tmp24.IsReadonly = null;
			__tmp24.Parameters.AddLazy(() => __tmp30);
			__tmp24.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp30.SetTypeLazy(() => MetaType);
			__tmp30.Documentation = null;
			__tmp30.Name = "type";
			__tmp30.SetOperationLazy(() => __tmp24);
			MetaPrimitiveType.Documentation = "";
			MetaPrimitiveType.Name = "MetaPrimitiveType";
			MetaPrimitiveType.SetNamespaceLazy(() => __tmp6);
			// MetaPrimitiveType.IsAbstract = null;
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaNamedType);
			MetaPrimitiveType.Operations.AddLazy(() => __tmp36);
			__tmp36.Documentation = "";
			__tmp36.Name = "ConformsTo";
			__tmp36.SetClassLazy(() => MetaPrimitiveType);
			// __tmp36.Enum = null;
			// __tmp36.IsBuilder = null;
			// __tmp36.IsReadonly = null;
			__tmp36.Parameters.AddLazy(() => __tmp37);
			__tmp36.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp37.SetTypeLazy(() => MetaType);
			__tmp37.Documentation = null;
			__tmp37.Name = "type";
			__tmp37.SetOperationLazy(() => __tmp36);
			MetaEnum.Attributes.Add(global::MetaDslx.Languages.Meta.Model.MetaInstance.ScopeAttribute.ToMutable());
			MetaEnum.Documentation = "";
			MetaEnum.Name = "MetaEnum";
			MetaEnum.SetNamespaceLazy(() => __tmp6);
			// MetaEnum.IsAbstract = null;
			MetaEnum.SuperClasses.AddLazy(() => MetaNamedType);
			MetaEnum.Properties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnum.Properties.AddLazy(() => MetaEnum_Operations);
			MetaEnum_EnumLiterals.SetTypeLazy(() => __tmp49);
			MetaEnum_EnumLiterals.Documentation = "";
			MetaEnum_EnumLiterals.Name = "EnumLiterals";
			// MetaEnum_EnumLiterals.Kind = null;
			MetaEnum_EnumLiterals.SetClassLazy(() => MetaEnum);
			MetaEnum_EnumLiterals.DefaultValue = null;
			MetaEnum_EnumLiterals.IsContainment = true;
			MetaEnum_EnumLiterals.OppositeProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaEnum_Operations.SetTypeLazy(() => __tmp29);
			MetaEnum_Operations.Documentation = "";
			MetaEnum_Operations.Name = "Operations";
			// MetaEnum_Operations.Kind = null;
			MetaEnum_Operations.SetClassLazy(() => MetaEnum);
			MetaEnum_Operations.DefaultValue = null;
			MetaEnum_Operations.IsContainment = true;
			MetaEnum_Operations.OppositeProperties.AddLazy(() => MetaOperation_Enum);
			MetaEnumLiteral.Documentation = "";
			MetaEnumLiteral.Name = "MetaEnumLiteral";
			MetaEnumLiteral.SetNamespaceLazy(() => __tmp6);
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
			MetaConstant.SetNamespaceLazy(() => __tmp6);
			// MetaConstant.IsAbstract = null;
			MetaConstant.SuperClasses.AddLazy(() => MetaNamedType);
			MetaConstant.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaConstant.Properties.AddLazy(() => MetaConstant_DotNetName);
			MetaConstant.Properties.AddLazy(() => MetaConstant_Value);
			MetaConstant.Operations.AddLazy(() => __tmp45);
			MetaConstant_DotNetName.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			MetaConstant_DotNetName.Documentation = "";
			MetaConstant_DotNetName.Name = "DotNetName";
			// MetaConstant_DotNetName.Kind = null;
			MetaConstant_DotNetName.SetClassLazy(() => MetaConstant);
			MetaConstant_DotNetName.DefaultValue = null;
			// MetaConstant_DotNetName.IsContainment = null;
			MetaConstant_Value.SetTypeLazy(() => __tmp16);
			MetaConstant_Value.Documentation = "";
			MetaConstant_Value.Name = "Value";
			MetaConstant_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Readonly;
			MetaConstant_Value.SetClassLazy(() => MetaConstant);
			MetaConstant_Value.DefaultValue = null;
			// MetaConstant_Value.IsContainment = null;
			__tmp45.Documentation = "";
			__tmp45.Name = "ConformsTo";
			__tmp45.SetClassLazy(() => MetaConstant);
			// __tmp45.Enum = null;
			// __tmp45.IsBuilder = null;
			// __tmp45.IsReadonly = null;
			__tmp45.Parameters.AddLazy(() => __tmp46);
			__tmp45.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp46.SetTypeLazy(() => MetaType);
			__tmp46.Documentation = null;
			__tmp46.Name = "type";
			__tmp46.SetOperationLazy(() => __tmp45);
			MetaClass.Attributes.Add(global::MetaDslx.Languages.Meta.Model.MetaInstance.ScopeAttribute.ToMutable());
			MetaClass.Documentation = "";
			MetaClass.Name = "MetaClass";
			MetaClass.SetNamespaceLazy(() => __tmp6);
			// MetaClass.IsAbstract = null;
			MetaClass.SuperClasses.AddLazy(() => MetaNamedType);
			MetaClass.Properties.AddLazy(() => MetaClass_IsAbstract);
			MetaClass.Properties.AddLazy(() => MetaClass_SuperClasses);
			MetaClass.Properties.AddLazy(() => MetaClass_Properties);
			MetaClass.Properties.AddLazy(() => MetaClass_Operations);
			MetaClass.Operations.AddLazy(() => __tmp51);
			MetaClass.Operations.AddLazy(() => __tmp52);
			MetaClass.Operations.AddLazy(() => __tmp54);
			MetaClass.Operations.AddLazy(() => __tmp55);
			MetaClass.Operations.AddLazy(() => __tmp56);
			MetaClass.Operations.AddLazy(() => __tmp57);
			MetaClass.Operations.AddLazy(() => __tmp59);
			MetaClass.Operations.AddLazy(() => __tmp60);
			MetaClass_IsAbstract.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			MetaClass_IsAbstract.Documentation = "";
			MetaClass_IsAbstract.Name = "IsAbstract";
			// MetaClass_IsAbstract.Kind = null;
			MetaClass_IsAbstract.SetClassLazy(() => MetaClass);
			MetaClass_IsAbstract.DefaultValue = null;
			// MetaClass_IsAbstract.IsContainment = null;
			MetaClass_SuperClasses.Attributes.Add(global::MetaDslx.Languages.Meta.Model.MetaInstance.BaseScopeAttribute.ToMutable());
			MetaClass_SuperClasses.SetTypeLazy(() => __tmp64);
			MetaClass_SuperClasses.Documentation = "";
			MetaClass_SuperClasses.Name = "SuperClasses";
			// MetaClass_SuperClasses.Kind = null;
			MetaClass_SuperClasses.SetClassLazy(() => MetaClass);
			MetaClass_SuperClasses.DefaultValue = null;
			// MetaClass_SuperClasses.IsContainment = null;
			MetaClass_Properties.SetTypeLazy(() => __tmp66);
			MetaClass_Properties.Documentation = "";
			MetaClass_Properties.Name = "Properties";
			// MetaClass_Properties.Kind = null;
			MetaClass_Properties.SetClassLazy(() => MetaClass);
			MetaClass_Properties.DefaultValue = null;
			MetaClass_Properties.IsContainment = true;
			MetaClass_Properties.OppositeProperties.AddLazy(() => MetaProperty_Class);
			MetaClass_Operations.SetTypeLazy(() => __tmp67);
			MetaClass_Operations.Documentation = "";
			MetaClass_Operations.Name = "Operations";
			// MetaClass_Operations.Kind = null;
			MetaClass_Operations.SetClassLazy(() => MetaClass);
			MetaClass_Operations.DefaultValue = null;
			MetaClass_Operations.IsContainment = true;
			MetaClass_Operations.OppositeProperties.AddLazy(() => MetaOperation_Class);
			__tmp51.Documentation = "";
			__tmp51.Name = "ConformsTo";
			__tmp51.SetClassLazy(() => MetaClass);
			// __tmp51.Enum = null;
			// __tmp51.IsBuilder = null;
			// __tmp51.IsReadonly = null;
			__tmp51.Parameters.AddLazy(() => __tmp68);
			__tmp51.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp68.SetTypeLazy(() => MetaType);
			__tmp68.Documentation = null;
			__tmp68.Name = "type";
			__tmp68.SetOperationLazy(() => __tmp51);
			__tmp52.Documentation = "";
			__tmp52.Name = "GetAllSuperClasses";
			__tmp52.SetClassLazy(() => MetaClass);
			// __tmp52.Enum = null;
			// __tmp52.IsBuilder = null;
			// __tmp52.IsReadonly = null;
			__tmp52.Parameters.AddLazy(() => __tmp70);
			__tmp52.SetReturnTypeLazy(() => __tmp69);
			__tmp70.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp70.Documentation = null;
			__tmp70.Name = "includeSelf";
			__tmp70.SetOperationLazy(() => __tmp52);
			__tmp54.Documentation = "";
			__tmp54.Name = "GetAllSuperProperties";
			__tmp54.SetClassLazy(() => MetaClass);
			// __tmp54.Enum = null;
			// __tmp54.IsBuilder = null;
			// __tmp54.IsReadonly = null;
			__tmp54.Parameters.AddLazy(() => __tmp72);
			__tmp54.SetReturnTypeLazy(() => __tmp71);
			__tmp72.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp72.Documentation = null;
			__tmp72.Name = "includeSelf";
			__tmp72.SetOperationLazy(() => __tmp54);
			__tmp55.Documentation = "";
			__tmp55.Name = "GetAllSuperOperations";
			__tmp55.SetClassLazy(() => MetaClass);
			// __tmp55.Enum = null;
			// __tmp55.IsBuilder = null;
			// __tmp55.IsReadonly = null;
			__tmp55.Parameters.AddLazy(() => __tmp74);
			__tmp55.SetReturnTypeLazy(() => __tmp73);
			__tmp74.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp74.Documentation = null;
			__tmp74.Name = "includeSelf";
			__tmp74.SetOperationLazy(() => __tmp55);
			__tmp56.Documentation = "";
			__tmp56.Name = "GetAllProperties";
			__tmp56.SetClassLazy(() => MetaClass);
			// __tmp56.Enum = null;
			// __tmp56.IsBuilder = null;
			// __tmp56.IsReadonly = null;
			__tmp56.SetReturnTypeLazy(() => __tmp75);
			__tmp57.Documentation = "";
			__tmp57.Name = "GetAllOperations";
			__tmp57.SetClassLazy(() => MetaClass);
			// __tmp57.Enum = null;
			// __tmp57.IsBuilder = null;
			// __tmp57.IsReadonly = null;
			__tmp57.SetReturnTypeLazy(() => __tmp76);
			__tmp59.Documentation = "";
			__tmp59.Name = "GetAllFinalProperties";
			__tmp59.SetClassLazy(() => MetaClass);
			// __tmp59.Enum = null;
			// __tmp59.IsBuilder = null;
			// __tmp59.IsReadonly = null;
			__tmp59.SetReturnTypeLazy(() => __tmp77);
			__tmp60.Documentation = "";
			__tmp60.Name = "GetAllFinalOperations";
			__tmp60.SetClassLazy(() => MetaClass);
			// __tmp60.Enum = null;
			// __tmp60.IsBuilder = null;
			// __tmp60.IsReadonly = null;
			__tmp60.SetReturnTypeLazy(() => __tmp61);
			MetaOperation.Attributes.Add(global::MetaDslx.Languages.Meta.Model.MetaInstance.LocalScopeAttribute.ToMutable());
			MetaOperation.Documentation = "";
			MetaOperation.Name = "MetaOperation";
			MetaOperation.SetNamespaceLazy(() => __tmp6);
			// MetaOperation.IsAbstract = null;
			MetaOperation.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Class);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Enum);
			MetaOperation.Properties.AddLazy(() => MetaOperation_IsBuilder);
			MetaOperation.Properties.AddLazy(() => MetaOperation_IsReadonly);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Parameters);
			MetaOperation.Properties.AddLazy(() => MetaOperation_ReturnType);
			MetaOperation.Operations.AddLazy(() => __tmp43);
			MetaOperation_Class.SetTypeLazy(() => MetaClass);
			MetaOperation_Class.Documentation = "";
			MetaOperation_Class.Name = "Class";
			// MetaOperation_Class.Kind = null;
			MetaOperation_Class.SetClassLazy(() => MetaOperation);
			MetaOperation_Class.DefaultValue = null;
			// MetaOperation_Class.IsContainment = null;
			MetaOperation_Class.OppositeProperties.AddLazy(() => MetaClass_Operations);
			MetaOperation_Enum.SetTypeLazy(() => MetaEnum);
			MetaOperation_Enum.Documentation = "";
			MetaOperation_Enum.Name = "Enum";
			// MetaOperation_Enum.Kind = null;
			MetaOperation_Enum.SetClassLazy(() => MetaOperation);
			MetaOperation_Enum.DefaultValue = null;
			// MetaOperation_Enum.IsContainment = null;
			MetaOperation_Enum.OppositeProperties.AddLazy(() => MetaEnum_Operations);
			MetaOperation_IsBuilder.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			MetaOperation_IsBuilder.Documentation = "";
			MetaOperation_IsBuilder.Name = "IsBuilder";
			// MetaOperation_IsBuilder.Kind = null;
			MetaOperation_IsBuilder.SetClassLazy(() => MetaOperation);
			MetaOperation_IsBuilder.DefaultValue = null;
			// MetaOperation_IsBuilder.IsContainment = null;
			MetaOperation_IsReadonly.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			MetaOperation_IsReadonly.Documentation = "";
			MetaOperation_IsReadonly.Name = "IsReadonly";
			// MetaOperation_IsReadonly.Kind = null;
			MetaOperation_IsReadonly.SetClassLazy(() => MetaOperation);
			MetaOperation_IsReadonly.DefaultValue = null;
			// MetaOperation_IsReadonly.IsContainment = null;
			MetaOperation_Parameters.SetTypeLazy(() => __tmp53);
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
			__tmp43.Documentation = "";
			__tmp43.Name = "ConformsTo";
			__tmp43.SetClassLazy(() => MetaOperation);
			// __tmp43.Enum = null;
			// __tmp43.IsBuilder = null;
			// __tmp43.IsReadonly = null;
			__tmp43.Parameters.AddLazy(() => __tmp44);
			__tmp43.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp44.SetTypeLazy(() => MetaOperation);
			__tmp44.Documentation = null;
			__tmp44.Name = "operation";
			__tmp44.SetOperationLazy(() => __tmp43);
			MetaParameter.Documentation = "";
			MetaParameter.Name = "MetaParameter";
			MetaParameter.SetNamespaceLazy(() => __tmp6);
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
			MetaPropertyKind.SetNamespaceLazy(() => __tmp6);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp38);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp39);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp40);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp41);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp42);
			__tmp38.Documentation = "";
			__tmp38.Name = "Normal";
			__tmp38.SetEnumLazy(() => MetaPropertyKind);
			__tmp39.Documentation = "";
			__tmp39.Name = "Readonly";
			__tmp39.SetEnumLazy(() => MetaPropertyKind);
			__tmp40.Documentation = "";
			__tmp40.Name = "Lazy";
			__tmp40.SetEnumLazy(() => MetaPropertyKind);
			__tmp41.Documentation = "";
			__tmp41.Name = "Derived";
			__tmp41.SetEnumLazy(() => MetaPropertyKind);
			__tmp42.Documentation = "";
			__tmp42.Name = "DerivedUnion";
			__tmp42.SetEnumLazy(() => MetaPropertyKind);
			MetaProperty.Documentation = "";
			MetaProperty.Name = "MetaProperty";
			MetaProperty.SetNamespaceLazy(() => __tmp6);
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
			MetaProperty.Operations.AddLazy(() => __tmp47);
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
			MetaProperty_DefaultValue.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			MetaProperty_DefaultValue.Documentation = "";
			MetaProperty_DefaultValue.Name = "DefaultValue";
			// MetaProperty_DefaultValue.Kind = null;
			MetaProperty_DefaultValue.SetClassLazy(() => MetaProperty);
			MetaProperty_DefaultValue.DefaultValue = null;
			// MetaProperty_DefaultValue.IsContainment = null;
			MetaProperty_IsContainment.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			MetaProperty_IsContainment.Documentation = "";
			MetaProperty_IsContainment.Name = "IsContainment";
			// MetaProperty_IsContainment.Kind = null;
			MetaProperty_IsContainment.SetClassLazy(() => MetaProperty);
			MetaProperty_IsContainment.DefaultValue = null;
			// MetaProperty_IsContainment.IsContainment = null;
			MetaProperty_OppositeProperties.SetTypeLazy(() => __tmp50);
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
			MetaProperty_SubsettingProperties.SetTypeLazy(() => __tmp62);
			MetaProperty_SubsettingProperties.Documentation = "";
			MetaProperty_SubsettingProperties.Name = "SubsettingProperties";
			// MetaProperty_SubsettingProperties.Kind = null;
			MetaProperty_SubsettingProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_SubsettingProperties.DefaultValue = null;
			// MetaProperty_SubsettingProperties.IsContainment = null;
			MetaProperty_SubsettingProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty_RedefinedProperties.SetTypeLazy(() => __tmp63);
			MetaProperty_RedefinedProperties.Documentation = "";
			MetaProperty_RedefinedProperties.Name = "RedefinedProperties";
			// MetaProperty_RedefinedProperties.Kind = null;
			MetaProperty_RedefinedProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_RedefinedProperties.DefaultValue = null;
			// MetaProperty_RedefinedProperties.IsContainment = null;
			MetaProperty_RedefinedProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefiningProperties);
			MetaProperty_RedefiningProperties.SetTypeLazy(() => __tmp65);
			MetaProperty_RedefiningProperties.Documentation = "";
			MetaProperty_RedefiningProperties.Name = "RedefiningProperties";
			// MetaProperty_RedefiningProperties.Kind = null;
			MetaProperty_RedefiningProperties.SetClassLazy(() => MetaProperty);
			MetaProperty_RedefiningProperties.DefaultValue = null;
			// MetaProperty_RedefiningProperties.IsContainment = null;
			MetaProperty_RedefiningProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefinedProperties);
			__tmp47.Documentation = "";
			__tmp47.Name = "ConformsTo";
			__tmp47.SetClassLazy(() => MetaProperty);
			// __tmp47.Enum = null;
			// __tmp47.IsBuilder = null;
			// __tmp47.IsReadonly = null;
			__tmp47.Parameters.AddLazy(() => __tmp48);
			__tmp47.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp48.SetTypeLazy(() => MetaProperty);
			__tmp48.Documentation = null;
			__tmp48.Name = "property";
			__tmp48.SetOperationLazy(() => __tmp47);
			__tmp22.Documentation = "\n\tRepresents the MetaModel.\n\t\r\n";
			__tmp22.Name = "TestIncrementalCompilation";
			__tmp22.Uri = "http://metadslx.core/1.0";
			__tmp22.Prefix = null;
			__tmp22.SetNamespaceLazy(() => __tmp6);
			__tmp29.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp29.SetInnerTypeLazy(() => MetaOperation);
			__tmp31.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp31.SetInnerTypeLazy(() => MetaDeclaration);
			__tmp33.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp33.SetInnerTypeLazy(() => MetaAttribute);
			__tmp49.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp49.SetInnerTypeLazy(() => MetaEnumLiteral);
			__tmp50.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp50.SetInnerTypeLazy(() => MetaProperty);
			__tmp53.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp53.SetInnerTypeLazy(() => MetaParameter);
			__tmp58.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp58.SetInnerTypeLazy(() => MetaProperty);
			__tmp61.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp61.SetInnerTypeLazy(() => MetaOperation);
			__tmp62.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp62.SetInnerTypeLazy(() => MetaProperty);
			__tmp63.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp63.SetInnerTypeLazy(() => MetaProperty);
			__tmp64.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp64.SetInnerTypeLazy(() => MetaClass);
			__tmp65.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp65.SetInnerTypeLazy(() => MetaProperty);
			__tmp66.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp66.SetInnerTypeLazy(() => MetaProperty);
			__tmp67.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp67.SetInnerTypeLazy(() => MetaOperation);
			__tmp69.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp69.SetInnerTypeLazy(() => MetaClass);
			__tmp71.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp71.SetInnerTypeLazy(() => MetaProperty);
			__tmp73.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp73.SetInnerTypeLazy(() => MetaOperation);
			__tmp75.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp75.SetInnerTypeLazy(() => MetaProperty);
			__tmp76.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp76.SetInnerTypeLazy(() => MetaOperation);
			__tmp77.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp77.SetInnerTypeLazy(() => MetaProperty);
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class TestIncrementalCompilationImplementationBase
	{
		/// <summary>
		/// Implements the constructor: TestIncrementalCompilationBuilderInstance()
		/// </summary>
		internal virtual void TestIncrementalCompilationBuilderInstance(TestIncrementalCompilationBuilderInstance _this)
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
	
	
		public virtual void MetaElement_MValidate(MetaElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaDocumentedElement_MValidate(MetaDocumentedElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
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
	
	
		public virtual void MetaNamedElement_MValidate(MetaNamedElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaTypedElement_MValidate(MetaTypedElementBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaType_MValidate(MetaTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaNamedType_MValidate(MetaNamedTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaAttribute_MValidate(MetaAttributeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
		public virtual void MetaDeclaration_MValidate(MetaDeclarationBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaNamespace_MValidate(MetaNamespaceBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaModel_MValidate(MetaModelBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaCollectionType_MValidate(MetaCollectionTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaNullableType_MValidate(MetaNullableTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaPrimitiveType_MValidate(MetaPrimitiveTypeBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaEnum_MValidate(MetaEnumBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaEnumLiteral_MValidate(MetaEnumLiteralBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
		{
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
			_this.SetValueLazy(this.MetaConstant_ComputeProperty_Value);
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
		/// Computes the value of the property: MetaConstant.Value
		/// </summary	
		public abstract global::MetaDslx.Modeling.IModelObject MetaConstant_ComputeProperty_Value(MetaConstantBuilder _this);
	
		public virtual void MetaConstant_MValidate(MetaConstantBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaClass_MValidate(MetaClassBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaOperation_MValidate(MetaOperationBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaParameter_MValidate(MetaParameterBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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
	
	
		public virtual void MetaProperty_MValidate(MetaPropertyBuilder _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)
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

	internal class TestIncrementalCompilationImplementationProvider
	{
		// If there is a compile error at this line, create a new class called TestIncrementalCompilationImplementation
		// which is a subclass of global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols.TestIncrementalCompilationImplementationBase:
		private static TestIncrementalCompilationImplementation implementation = new TestIncrementalCompilationImplementation();
	
		public static TestIncrementalCompilationImplementation Implementation
		{
			get { return implementation; }
		}
	}
}

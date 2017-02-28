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
		public static readonly global::MetaDslx.Core.ImmutableModel Model;
	
		public static readonly MetaPrimitiveType Object;
		public static readonly MetaPrimitiveType String;
		public static readonly MetaPrimitiveType Int;
		public static readonly MetaPrimitiveType Long;
		public static readonly MetaPrimitiveType Float;
		public static readonly MetaPrimitiveType Double;
		public static readonly MetaPrimitiveType Byte;
		public static readonly MetaPrimitiveType Bool;
		public static readonly MetaPrimitiveType Void;
		public static readonly MetaPrimitiveType Symbol;
	
		public static readonly MetaClass MetaAnnotatedElement;
		public static readonly MetaProperty MetaAnnotatedElement_Annotations;
		public static readonly MetaClass MetaDocumentedElement;
		public static readonly MetaProperty MetaDocumentedElement_Documentation;
		public static readonly MetaClass MetaNamedElement;
		public static readonly MetaProperty MetaNamedElement_Name;
		public static readonly MetaClass MetaTypedElement;
		public static readonly MetaProperty MetaTypedElement_Type;
		public static readonly MetaClass MetaType;
		public static readonly MetaClass MetaAnnotation;
		public static readonly MetaClass MetaNamespace;
		public static readonly MetaProperty MetaNamespace_Parent;
		public static readonly MetaProperty MetaNamespace_Usings;
		public static readonly MetaProperty MetaNamespace_MetaModel;
		public static readonly MetaProperty MetaNamespace_Namespaces;
		public static readonly MetaProperty MetaNamespace_Declarations;
		public static readonly MetaClass MetaDeclaration;
		public static readonly MetaProperty MetaDeclaration_Namespace;
		public static readonly MetaProperty MetaDeclaration_MetaModel;
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
		public static readonly MetaProperty MetaClass_Constructor;
		public static readonly MetaClass MetaFunctionType;
		public static readonly MetaProperty MetaFunctionType_ParameterTypes;
		public static readonly MetaProperty MetaFunctionType_ReturnType;
		public static readonly MetaClass MetaFunction;
		public static readonly MetaProperty MetaFunction_Type;
		public static readonly MetaProperty MetaFunction_Parameters;
		public static readonly MetaProperty MetaFunction_ReturnType;
		public static readonly MetaClass MetaOperation;
		public static readonly MetaProperty MetaOperation_Parent;
		public static readonly MetaClass MetaConstructor;
		public static readonly MetaProperty MetaConstructor_Parent;
		public static readonly MetaClass MetaParameter;
		public static readonly MetaProperty MetaParameter_Function;
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
			Symbol = MetaBuilderInstance.instance.Symbol.ToImmutable(Model);
	
			MetaAnnotatedElement = MetaBuilderInstance.instance.MetaAnnotatedElement.ToImmutable(Model);
			MetaAnnotatedElement_Annotations = MetaBuilderInstance.instance.MetaAnnotatedElement_Annotations.ToImmutable(Model);
			MetaDocumentedElement = MetaBuilderInstance.instance.MetaDocumentedElement.ToImmutable(Model);
			MetaDocumentedElement_Documentation = MetaBuilderInstance.instance.MetaDocumentedElement_Documentation.ToImmutable(Model);
			MetaNamedElement = MetaBuilderInstance.instance.MetaNamedElement.ToImmutable(Model);
			MetaNamedElement_Name = MetaBuilderInstance.instance.MetaNamedElement_Name.ToImmutable(Model);
			MetaTypedElement = MetaBuilderInstance.instance.MetaTypedElement.ToImmutable(Model);
			MetaTypedElement_Type = MetaBuilderInstance.instance.MetaTypedElement_Type.ToImmutable(Model);
			MetaType = MetaBuilderInstance.instance.MetaType.ToImmutable(Model);
			MetaAnnotation = MetaBuilderInstance.instance.MetaAnnotation.ToImmutable(Model);
			MetaNamespace = MetaBuilderInstance.instance.MetaNamespace.ToImmutable(Model);
			MetaNamespace_Parent = MetaBuilderInstance.instance.MetaNamespace_Parent.ToImmutable(Model);
			MetaNamespace_Usings = MetaBuilderInstance.instance.MetaNamespace_Usings.ToImmutable(Model);
			MetaNamespace_MetaModel = MetaBuilderInstance.instance.MetaNamespace_MetaModel.ToImmutable(Model);
			MetaNamespace_Namespaces = MetaBuilderInstance.instance.MetaNamespace_Namespaces.ToImmutable(Model);
			MetaNamespace_Declarations = MetaBuilderInstance.instance.MetaNamespace_Declarations.ToImmutable(Model);
			MetaDeclaration = MetaBuilderInstance.instance.MetaDeclaration.ToImmutable(Model);
			MetaDeclaration_Namespace = MetaBuilderInstance.instance.MetaDeclaration_Namespace.ToImmutable(Model);
			MetaDeclaration_MetaModel = MetaBuilderInstance.instance.MetaDeclaration_MetaModel.ToImmutable(Model);
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
			MetaClass_Constructor = MetaBuilderInstance.instance.MetaClass_Constructor.ToImmutable(Model);
			MetaFunctionType = MetaBuilderInstance.instance.MetaFunctionType.ToImmutable(Model);
			MetaFunctionType_ParameterTypes = MetaBuilderInstance.instance.MetaFunctionType_ParameterTypes.ToImmutable(Model);
			MetaFunctionType_ReturnType = MetaBuilderInstance.instance.MetaFunctionType_ReturnType.ToImmutable(Model);
			MetaFunction = MetaBuilderInstance.instance.MetaFunction.ToImmutable(Model);
			MetaFunction_Type = MetaBuilderInstance.instance.MetaFunction_Type.ToImmutable(Model);
			MetaFunction_Parameters = MetaBuilderInstance.instance.MetaFunction_Parameters.ToImmutable(Model);
			MetaFunction_ReturnType = MetaBuilderInstance.instance.MetaFunction_ReturnType.ToImmutable(Model);
			MetaOperation = MetaBuilderInstance.instance.MetaOperation.ToImmutable(Model);
			MetaOperation_Parent = MetaBuilderInstance.instance.MetaOperation_Parent.ToImmutable(Model);
			MetaConstructor = MetaBuilderInstance.instance.MetaConstructor.ToImmutable(Model);
			MetaConstructor_Parent = MetaBuilderInstance.instance.MetaConstructor_Parent.ToImmutable(Model);
			MetaParameter = MetaBuilderInstance.instance.MetaParameter.ToImmutable(Model);
			MetaParameter_Function = MetaBuilderInstance.instance.MetaParameter_Function.ToImmutable(Model);
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
	public class MetaFactory : global::MetaDslx.Core.ModelFactory
	{
		public MetaFactory(global::MetaDslx.Core.MutableModel model, global::MetaDslx.Core.ModelFactoryFlags flags = global::MetaDslx.Core.ModelFactoryFlags.None)
			: base(model, flags)
		{
			MetaDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Core.MutableSymbol Create(string type)
		{
			switch (type)
			{
				case "MetaAnnotation": return this.MetaAnnotation();
				case "MetaNamespace": return this.MetaNamespace();
				case "MetaModel": return this.MetaModel();
				case "MetaCollectionType": return this.MetaCollectionType();
				case "MetaNullableType": return this.MetaNullableType();
				case "MetaPrimitiveType": return this.MetaPrimitiveType();
				case "MetaEnum": return this.MetaEnum();
				case "MetaEnumLiteral": return this.MetaEnumLiteral();
				case "MetaConstant": return this.MetaConstant();
				case "MetaClass": return this.MetaClass();
				case "MetaFunctionType": return this.MetaFunctionType();
				case "MetaOperation": return this.MetaOperation();
				case "MetaConstructor": return this.MetaConstructor();
				case "MetaParameter": return this.MetaParameter();
				case "MetaProperty": return this.MetaProperty();
				default:
					throw new global::MetaDslx.Core.ModelException(global::MetaDslx.Compiler.Diagnostics.Location.None, new global::MetaDslx.Compiler.Diagnostics.DiagnosticInfo(global::MetaDslx.Core.ModelErrorCode.ERR_UnknownTypeName, type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of MetaAnnotation.
		/// </summary>
		public MetaAnnotationBuilder MetaAnnotation()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaAnnotationId());
			return (MetaAnnotationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNamespace.
		/// </summary>
		public MetaNamespaceBuilder MetaNamespace()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaNamespaceId());
			return (MetaNamespaceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaModel.
		/// </summary>
		public MetaModelBuilder MetaModel()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaModelId());
			return (MetaModelBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaCollectionType.
		/// </summary>
		public MetaCollectionTypeBuilder MetaCollectionType()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaCollectionTypeId());
			return (MetaCollectionTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNullableType.
		/// </summary>
		public MetaNullableTypeBuilder MetaNullableType()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaNullableTypeId());
			return (MetaNullableTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaPrimitiveType.
		/// </summary>
		public MetaPrimitiveTypeBuilder MetaPrimitiveType()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaPrimitiveTypeId());
			return (MetaPrimitiveTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaEnum.
		/// </summary>
		public MetaEnumBuilder MetaEnum()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaEnumId());
			return (MetaEnumBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaEnumLiteral.
		/// </summary>
		public MetaEnumLiteralBuilder MetaEnumLiteral()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaEnumLiteralId());
			return (MetaEnumLiteralBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaConstant.
		/// </summary>
		public MetaConstantBuilder MetaConstant()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaConstantId());
			return (MetaConstantBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaClass.
		/// </summary>
		public MetaClassBuilder MetaClass()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaClassId());
			return (MetaClassBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaFunctionType.
		/// </summary>
		public MetaFunctionTypeBuilder MetaFunctionType()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaFunctionTypeId());
			return (MetaFunctionTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaOperation.
		/// </summary>
		public MetaOperationBuilder MetaOperation()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaOperationId());
			return (MetaOperationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaConstructor.
		/// </summary>
		public MetaConstructorBuilder MetaConstructor()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaConstructorId());
			return (MetaConstructorBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaParameter.
		/// </summary>
		public MetaParameterBuilder MetaParameter()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaParameterId());
			return (MetaParameterBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaProperty.
		/// </summary>
		public MetaPropertyBuilder MetaProperty()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new MetaPropertyId());
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
	
	public interface MetaAnnotatedElement : global::MetaDslx.Core.ImmutableSymbol
	{
		global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations { get; }
	
	
		new MetaAnnotatedElementBuilder ToMutable();
		new MetaAnnotatedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaAnnotatedElementBuilder : global::MetaDslx.Core.MutableSymbol
	{
		global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations { get; }
	
		new MetaAnnotatedElement ToImmutable();
		new MetaAnnotatedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaDocumentedElement : global::MetaDslx.Core.ImmutableSymbol
	{
		string Documentation { get; }
	
		global::MetaDslx.Core.ImmutableModelList<string> GetDocumentationLines();
	
		new MetaDocumentedElementBuilder ToMutable();
		new MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaDocumentedElementBuilder : global::MetaDslx.Core.MutableSymbol
	{
		string Documentation { get; set; }
		Func<string> DocumentationLazy { get; set; }
	
		new MetaDocumentedElement ToImmutable();
		new MetaDocumentedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaNamedElement : MetaDocumentedElement
	{
		string Name { get; }
	
	
		new MetaNamedElementBuilder ToMutable();
		new MetaNamedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaNamedElementBuilder : MetaDocumentedElementBuilder
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
	
		new MetaNamedElement ToImmutable();
		new MetaNamedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaTypedElement : global::MetaDslx.Core.ImmutableSymbol
	{
		MetaType Type { get; }
	
	
		new MetaTypedElementBuilder ToMutable();
		new MetaTypedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaTypedElementBuilder : global::MetaDslx.Core.MutableSymbol
	{
		MetaTypeBuilder Type { get; set; }
		Func<MetaTypeBuilder> TypeLazy { get; set; }
	
		new MetaTypedElement ToImmutable();
		new MetaTypedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaType : global::MetaDslx.Core.ImmutableSymbol
	{
	
	
		new MetaTypeBuilder ToMutable();
		new MetaTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaTypeBuilder : global::MetaDslx.Core.MutableSymbol
	{
	
		new MetaType ToImmutable();
		new MetaType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaAnnotation : MetaNamedElement
	{
	
	
		new MetaAnnotationBuilder ToMutable();
		new MetaAnnotationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaAnnotationBuilder : MetaNamedElementBuilder
	{
	
		new MetaAnnotation ToImmutable();
		new MetaAnnotation ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaNamespace : MetaNamedElement, MetaAnnotatedElement
	{
		MetaNamespace Parent { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaNamespace> Usings { get; }
		MetaModel MetaModel { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaNamespace> Namespaces { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaDeclaration> Declarations { get; }
	
	
		new MetaNamespaceBuilder ToMutable();
		new MetaNamespaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaNamespaceBuilder : MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaNamespaceBuilder Parent { get; set; }
		Func<MetaNamespaceBuilder> ParentLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<MetaNamespaceBuilder> Usings { get; }
		MetaModelBuilder MetaModel { get; set; }
		Func<MetaModelBuilder> MetaModelLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<MetaNamespaceBuilder> Namespaces { get; }
		global::MetaDslx.Core.MutableModelList<MetaDeclarationBuilder> Declarations { get; }
	
		new MetaNamespace ToImmutable();
		new MetaNamespace ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaDeclaration : MetaNamedElement, MetaAnnotatedElement
	{
		MetaNamespace Namespace { get; }
		MetaModel MetaModel { get; }
	
	
		new MetaDeclarationBuilder ToMutable();
		new MetaDeclarationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaDeclarationBuilder : MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaNamespaceBuilder Namespace { get; set; }
		Func<MetaNamespaceBuilder> NamespaceLazy { get; set; }
		MetaModelBuilder MetaModel { get; }
		Func<MetaModelBuilder> MetaModelLazy { get; set; }
	
		new MetaDeclaration ToImmutable();
		new MetaDeclaration ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaModel : MetaNamedElement, MetaAnnotatedElement
	{
		string Uri { get; }
		MetaNamespace Namespace { get; }
	
	
		new MetaModelBuilder ToMutable();
		new MetaModelBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaModelBuilder : MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		string Uri { get; set; }
		Func<string> UriLazy { get; set; }
		MetaNamespaceBuilder Namespace { get; set; }
		Func<MetaNamespaceBuilder> NamespaceLazy { get; set; }
	
		new MetaModel ToImmutable();
		new MetaModel ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaCollectionType : MetaType
	{
		MetaCollectionKind Kind { get; }
		MetaType InnerType { get; }
	
	
		new MetaCollectionTypeBuilder ToMutable();
		new MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaCollectionTypeBuilder : MetaTypeBuilder
	{
		MetaCollectionKind Kind { get; set; }
		Func<MetaCollectionKind> KindLazy { get; set; }
		MetaTypeBuilder InnerType { get; set; }
		Func<MetaTypeBuilder> InnerTypeLazy { get; set; }
	
		new MetaCollectionType ToImmutable();
		new MetaCollectionType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaNullableType : MetaType
	{
		MetaType InnerType { get; }
	
	
		new MetaNullableTypeBuilder ToMutable();
		new MetaNullableTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaNullableTypeBuilder : MetaTypeBuilder
	{
		MetaTypeBuilder InnerType { get; set; }
		Func<MetaTypeBuilder> InnerTypeLazy { get; set; }
	
		new MetaNullableType ToImmutable();
		new MetaNullableType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaPrimitiveType : MetaType, MetaDeclaration, MetaNamedElement
	{
	
	
		new MetaPrimitiveTypeBuilder ToMutable();
		new MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaPrimitiveTypeBuilder : MetaTypeBuilder, MetaDeclarationBuilder, MetaNamedElementBuilder
	{
	
		new MetaPrimitiveType ToImmutable();
		new MetaPrimitiveType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaEnum : MetaType, MetaDeclaration
	{
		global::MetaDslx.Core.ImmutableModelList<MetaEnumLiteral> EnumLiterals { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaOperation> Operations { get; }
	
	
		new MetaEnumBuilder ToMutable();
		new MetaEnumBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaEnumBuilder : MetaTypeBuilder, MetaDeclarationBuilder
	{
		global::MetaDslx.Core.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals { get; }
		global::MetaDslx.Core.MutableModelList<MetaOperationBuilder> Operations { get; }
	
		new MetaEnum ToImmutable();
		new MetaEnum ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaEnumLiteral : MetaNamedElement, MetaTypedElement
	{
		MetaEnum Enum { get; }
	
	
		new MetaEnumLiteralBuilder ToMutable();
		new MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaEnumLiteralBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder
	{
		MetaEnumBuilder Enum { get; set; }
		Func<MetaEnumBuilder> EnumLazy { get; set; }
	
		new MetaEnumLiteral ToImmutable();
		new MetaEnumLiteral ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaConstant : MetaTypedElement, MetaDeclaration
	{
	
	
		new MetaConstantBuilder ToMutable();
		new MetaConstantBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaConstantBuilder : MetaTypedElementBuilder, MetaDeclarationBuilder
	{
	
		new MetaConstant ToImmutable();
		new MetaConstant ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaClass : MetaType, MetaDeclaration
	{
		bool IsAbstract { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaClass> SuperClasses { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> Properties { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaOperation> Operations { get; }
		MetaConstructor Constructor { get; }
	
		global::MetaDslx.Core.ImmutableModelList<MetaClass> GetAllSuperClasses(bool includeSelf);
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> GetAllSuperProperties(bool includeSelf);
		global::MetaDslx.Core.ImmutableModelList<MetaOperation> GetAllSuperOperations(bool includeSelf);
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> GetAllProperties();
		global::MetaDslx.Core.ImmutableModelList<MetaOperation> GetAllOperations();
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> GetAllFinalProperties();
		global::MetaDslx.Core.ImmutableModelList<MetaOperation> GetAllFinalOperations();
	
		new MetaClassBuilder ToMutable();
		new MetaClassBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaClassBuilder : MetaTypeBuilder, MetaDeclarationBuilder
	{
		bool IsAbstract { get; set; }
		Func<bool> IsAbstractLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<MetaClassBuilder> SuperClasses { get; }
		global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> Properties { get; }
		global::MetaDslx.Core.MutableModelList<MetaOperationBuilder> Operations { get; }
		MetaConstructorBuilder Constructor { get; set; }
		Func<MetaConstructorBuilder> ConstructorLazy { get; set; }
	
		new MetaClass ToImmutable();
		new MetaClass ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaFunctionType : MetaType
	{
		global::MetaDslx.Core.ImmutableModelList<MetaType> ParameterTypes { get; }
		MetaType ReturnType { get; }
	
	
		new MetaFunctionTypeBuilder ToMutable();
		new MetaFunctionTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaFunctionTypeBuilder : MetaTypeBuilder
	{
		global::MetaDslx.Core.MutableModelList<MetaTypeBuilder> ParameterTypes { get; }
		MetaTypeBuilder ReturnType { get; set; }
		Func<MetaTypeBuilder> ReturnTypeLazy { get; set; }
	
		new MetaFunctionType ToImmutable();
		new MetaFunctionType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaFunction : MetaTypedElement, MetaNamedElement, MetaAnnotatedElement
	{
		new MetaFunctionType Type { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaParameter> Parameters { get; }
		MetaType ReturnType { get; }
	
	
		new MetaFunctionBuilder ToMutable();
		new MetaFunctionBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaFunctionBuilder : MetaTypedElementBuilder, MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		new MetaFunctionTypeBuilder Type { get; }
		new Func<MetaFunctionTypeBuilder> TypeLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<MetaParameterBuilder> Parameters { get; }
		MetaTypeBuilder ReturnType { get; set; }
		Func<MetaTypeBuilder> ReturnTypeLazy { get; set; }
	
		new MetaFunction ToImmutable();
		new MetaFunction ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaOperation : MetaFunction
	{
		MetaType Parent { get; }
	
	
		new MetaOperationBuilder ToMutable();
		new MetaOperationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaOperationBuilder : MetaFunctionBuilder
	{
		MetaTypeBuilder Parent { get; set; }
		Func<MetaTypeBuilder> ParentLazy { get; set; }
	
		new MetaOperation ToImmutable();
		new MetaOperation ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaConstructor : MetaNamedElement, MetaAnnotatedElement
	{
		MetaClass Parent { get; }
	
	
		new MetaConstructorBuilder ToMutable();
		new MetaConstructorBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaConstructorBuilder : MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaClassBuilder Parent { get; set; }
		Func<MetaClassBuilder> ParentLazy { get; set; }
	
		new MetaConstructor ToImmutable();
		new MetaConstructor ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaParameter : MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
	{
		MetaFunction Function { get; }
	
	
		new MetaParameterBuilder ToMutable();
		new MetaParameterBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaParameterBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaFunctionBuilder Function { get; set; }
		Func<MetaFunctionBuilder> FunctionLazy { get; set; }
	
		new MetaParameter ToImmutable();
		new MetaParameter ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface MetaProperty : MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
	{
		MetaPropertyKind Kind { get; }
		MetaClass Class { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> OppositeProperties { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> SubsettedProperties { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> SubsettingProperties { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> RedefinedProperties { get; }
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> RedefiningProperties { get; }
	
	
		new MetaPropertyBuilder ToMutable();
		new MetaPropertyBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface MetaPropertyBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaPropertyKind Kind { get; set; }
		Func<MetaPropertyKind> KindLazy { get; set; }
		MetaClassBuilder Class { get; set; }
		Func<MetaClassBuilder> ClassLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> OppositeProperties { get; }
		global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> SubsettedProperties { get; }
		global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> SubsettingProperties { get; }
		global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> RedefinedProperties { get; }
		global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> RedefiningProperties { get; }
	
		new MetaProperty ToImmutable();
		new MetaProperty ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}

	public static class MetaDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty> properties;
	
		static MetaDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty>();
			MetaAnnotatedElement.Initialize();
			MetaDocumentedElement.Initialize();
			MetaNamedElement.Initialize();
			MetaTypedElement.Initialize();
			MetaType.Initialize();
			MetaAnnotation.Initialize();
			MetaNamespace.Initialize();
			MetaDeclaration.Initialize();
			MetaModel.Initialize();
			MetaCollectionType.Initialize();
			MetaNullableType.Initialize();
			MetaPrimitiveType.Initialize();
			MetaEnum.Initialize();
			MetaEnumLiteral.Initialize();
			MetaConstant.Initialize();
			MetaClass.Initialize();
			MetaFunctionType.Initialize();
			MetaFunction.Initialize();
			MetaOperation.Initialize();
			MetaConstructor.Initialize();
			MetaParameter.Initialize();
			MetaProperty.Initialize();
			properties.Add(MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty);
			properties.Add(MetaDescriptor.MetaDocumentedElement.DocumentationProperty);
			properties.Add(MetaDescriptor.MetaNamedElement.NameProperty);
			properties.Add(MetaDescriptor.MetaTypedElement.TypeProperty);
			properties.Add(MetaDescriptor.MetaNamespace.ParentProperty);
			properties.Add(MetaDescriptor.MetaNamespace.UsingsProperty);
			properties.Add(MetaDescriptor.MetaNamespace.MetaModelProperty);
			properties.Add(MetaDescriptor.MetaNamespace.NamespacesProperty);
			properties.Add(MetaDescriptor.MetaNamespace.DeclarationsProperty);
			properties.Add(MetaDescriptor.MetaDeclaration.NamespaceProperty);
			properties.Add(MetaDescriptor.MetaDeclaration.MetaModelProperty);
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
			properties.Add(MetaDescriptor.MetaClass.ConstructorProperty);
			properties.Add(MetaDescriptor.MetaFunctionType.ParameterTypesProperty);
			properties.Add(MetaDescriptor.MetaFunctionType.ReturnTypeProperty);
			properties.Add(MetaDescriptor.MetaFunction.TypeProperty);
			properties.Add(MetaDescriptor.MetaFunction.ParametersProperty);
			properties.Add(MetaDescriptor.MetaFunction.ReturnTypeProperty);
			properties.Add(MetaDescriptor.MetaOperation.ParentProperty);
			properties.Add(MetaDescriptor.MetaConstructor.ParentProperty);
			properties.Add(MetaDescriptor.MetaParameter.FunctionProperty);
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
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAnnotatedElement), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAnnotatedElementBuilder))]
		public static class MetaAnnotatedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaAnnotatedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaAnnotatedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaAnnotatedElement; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty AnnotationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaAnnotatedElement), "Annotations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAnnotation), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaAnnotation>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaAnnotatedElement_Annotations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDocumentedElement), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDocumentedElementBuilder))]
		public static class MetaDocumentedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaDocumentedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaDocumentedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDocumentedElement; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty DocumentationProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaDocumentedElement), "Documentation",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDocumentedElement_Documentation);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamedElement), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamedElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaDocumentedElement) })]
		public static class MetaNamedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNamedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaNamedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamedElement; }
			}
			
			[global::MetaDslx.Core.Name]
			public static readonly global::MetaDslx.Core.ModelProperty NameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaNamedElement), "Name",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamedElement_Name);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypedElement), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypedElementBuilder))]
		public static class MetaTypedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaTypedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaTypedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaTypedElement; }
			}
			
			[global::MetaDslx.Core.Type]
			public static readonly global::MetaDslx.Core.ModelProperty TypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaTypedElement), "Type",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaTypedElement_Type);
		}
	
		[global::MetaDslx.Core.Type]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder))]
		public static class MetaType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaType; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAnnotation), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaAnnotation
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaAnnotation()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaAnnotation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaAnnotation; }
			}
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement) })]
		public static class MetaNamespace
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNamespace()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaNamespace));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "Namespaces")]
			public static readonly global::MetaDslx.Core.ModelProperty ParentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaNamespace), "Parent",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace_Parent);
			
			[global::MetaDslx.Core.ImportedScope]
			public static readonly global::MetaDslx.Core.ModelProperty UsingsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaNamespace), "Usings",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaNamespace>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace_Usings);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaModel), "Namespace")]
			public static readonly global::MetaDslx.Core.ModelProperty MetaModelProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaNamespace), "MetaModel",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModel), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace_MetaModel);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "Parent")]
			public static readonly global::MetaDslx.Core.ModelProperty NamespacesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaNamespace), "Namespaces",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaNamespace>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace_Namespaces);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaDeclaration), "Namespace")]
			public static readonly global::MetaDslx.Core.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaNamespace), "Declarations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDeclaration), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaDeclaration>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDeclarationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaDeclarationBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNamespace_Declarations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDeclaration), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaDeclarationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement) })]
		public static class MetaDeclaration
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaDeclaration()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaDeclaration));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDeclaration; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "Declarations")]
			public static readonly global::MetaDslx.Core.ModelProperty NamespaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaDeclaration), "Namespace",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDeclaration_Namespace);
			
			[global::MetaDslx.Core.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty MetaModelProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaDeclaration), "MetaModel",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModel), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaDeclaration_MetaModel);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModel), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement) })]
		public static class MetaModel
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaModel()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaModel));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaModel; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty UriProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaModel), "Uri",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaModel_Uri);
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "MetaModel")]
			public static readonly global::MetaDslx.Core.ModelProperty NamespaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaModel), "Namespace",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespace), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaModel_Namespace);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaCollectionType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType) })]
		public static class MetaCollectionType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaCollectionType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaCollectionType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaCollectionType; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty KindProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaCollectionType), "Kind",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaCollectionType_Kind);
			
			public static readonly global::MetaDslx.Core.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaCollectionType), "InnerType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaCollectionType_InnerType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNullableType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaNullableTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType) })]
		public static class MetaNullableType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNullableType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaNullableType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNullableType; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaNullableType), "InnerType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaNullableType_InnerType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPrimitiveType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPrimitiveTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaDeclaration), typeof(MetaDescriptor.MetaNamedElement) })]
		public static class MetaPrimitiveType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaPrimitiveType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaPrimitiveType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaPrimitiveType; }
			}
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnum), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaDeclaration) })]
		public static class MetaEnum
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaEnum()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaEnum));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnum; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaEnumLiteral), "Enum")]
			public static readonly global::MetaDslx.Core.ModelProperty EnumLiteralsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaEnum), "EnumLiterals",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteral), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteral>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnum_EnumLiterals);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parent")]
			public static readonly global::MetaDslx.Core.ModelProperty OperationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaEnum), "Operations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperation), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaOperation>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnum_Operations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteral), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement) })]
		public static class MetaEnumLiteral
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaEnumLiteral()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaEnumLiteral));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnumLiteral; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "EnumLiterals")]
			[global::MetaDslx.Core.RedefinesAttribute(typeof(MetaDescriptor.MetaTypedElement), "Type")]
			public static readonly global::MetaDslx.Core.ModelProperty EnumProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaEnumLiteral), "Enum",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnum), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaEnumLiteral_Enum);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaConstant), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaDeclaration) })]
		public static class MetaConstant
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaConstant()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaConstant));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaConstant; }
			}
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClass), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaDeclaration) })]
		public static class MetaClass
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaClass()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaClass));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass _MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaClass), "IsAbstract",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_IsAbstract);
			
			[global::MetaDslx.Core.InheritedScope]
			public static readonly global::MetaDslx.Core.ModelProperty SuperClassesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaClass), "SuperClasses",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClass), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaClass>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_SuperClasses);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "Class")]
			public static readonly global::MetaDslx.Core.ModelProperty PropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaClass), "Properties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_Properties);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parent")]
			public static readonly global::MetaDslx.Core.ModelProperty OperationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaClass), "Operations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperation), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaOperation>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_Operations);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaConstructor), "Parent")]
			public static readonly global::MetaDslx.Core.ModelProperty ConstructorProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaClass), "Constructor",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaConstructor), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaConstructorBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaClass_Constructor);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaFunctionType), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaFunctionTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaType) })]
		public static class MetaFunctionType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaFunctionType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaFunctionType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaFunctionType; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty ParameterTypesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaFunctionType), "ParameterTypes",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaType>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaFunctionType_ParameterTypes);
			
			public static readonly global::MetaDslx.Core.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaFunctionType), "ReturnType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaFunctionType_ReturnType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaFunction), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaFunctionBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement) })]
		public static class MetaFunction
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaFunction()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaFunction));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaFunction; }
			}
			
			[global::MetaDslx.Core.Type]
			[global::MetaDslx.Core.ReadonlyAttribute]
			[global::MetaDslx.Core.RedefinesAttribute(typeof(MetaDescriptor.MetaTypedElement), "Type")]
			public static readonly global::MetaDslx.Core.ModelProperty TypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaFunction), "Type",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaFunctionType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaFunctionTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaFunction_Type);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaParameter), "Function")]
			public static readonly global::MetaDslx.Core.ModelProperty ParametersProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaFunction), "Parameters",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaParameter), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaParameter>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaFunction_Parameters);
			
			public static readonly global::MetaDslx.Core.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaFunction), "ReturnType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaFunction_ReturnType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperation), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaFunction) })]
		public static class MetaOperation
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaOperation()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaOperation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaOperation; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "Operations")]
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Operations")]
			public static readonly global::MetaDslx.Core.ModelProperty ParentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaOperation), "Parent",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaTypeBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaOperation_Parent);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaConstructor), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaConstructorBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement) })]
		public static class MetaConstructor
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaConstructor()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaConstructor));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaConstructor; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Constructor")]
			public static readonly global::MetaDslx.Core.ModelProperty ParentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaConstructor), "Parent",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClass), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaConstructor_Parent);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaParameter), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaAnnotatedElement) })]
		public static class MetaParameter
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaParameter()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaParameter));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaParameter; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaFunction), "Parameters")]
			public static readonly global::MetaDslx.Core.ModelProperty FunctionProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaParameter), "Function",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaFunction), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaFunctionBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaParameter_Function);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaAnnotatedElement) })]
		public static class MetaProperty
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static MetaProperty()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MetaProperty));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty KindProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaProperty), "Kind",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_Kind);
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Properties")]
			public static readonly global::MetaDslx.Core.ModelProperty ClassProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaProperty), "Class",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClass), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder), null),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_Class);
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "OppositeProperties")]
			public static readonly global::MetaDslx.Core.ModelProperty OppositePropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaProperty), "OppositeProperties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_OppositeProperties);
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "SubsettingProperties")]
			public static readonly global::MetaDslx.Core.ModelProperty SubsettedPropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaProperty), "SubsettedProperties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_SubsettedProperties);
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "SubsettedProperties")]
			public static readonly global::MetaDslx.Core.ModelProperty SubsettingPropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaProperty), "SubsettingProperties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_SubsettingProperties);
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "RedefiningProperties")]
			public static readonly global::MetaDslx.Core.ModelProperty RedefinedPropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaProperty), "RedefinedProperties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_RedefinedProperties);
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "RedefinedProperties")]
			public static readonly global::MetaDslx.Core.ModelProperty RedefiningPropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(MetaProperty), "RedefiningProperties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaProperty), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaProperty>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder>)),
					() => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaProperty_RedefiningProperties);
		}
	}
}

namespace MetaDslx.Languages.Meta.Symbols.Internal
{
	
	internal class MetaAnnotatedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaAnnotatedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaAnnotatedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaAnnotatedElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaAnnotatedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
	
		internal MetaAnnotatedElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAnnotatedElement; }
		}
	
		public new MetaAnnotatedElementBuilder ToMutable()
		{
			return (MetaAnnotatedElementBuilder)base.ToMutable();
		}
	
		public new MetaAnnotatedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaAnnotatedElementBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class MetaAnnotatedElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaAnnotatedElementBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaAnnotatedElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAnnotatedElement; }
		}
	
		public new MetaAnnotatedElement ToImmutable()
		{
			return (MetaAnnotatedElement)base.ToImmutable();
		}
	
		public new MetaAnnotatedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaAnnotatedElement)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class MetaDocumentedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaDocumentedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaDocumentedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaDocumentedElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaDocumentedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
	
		internal MetaDocumentedElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaDocumentedElementBuilder)base.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaDocumentedElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaDocumentedElementBuilder
	{
	
		internal MetaDocumentedElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaDocumentedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaDocumentedElement)base.ToImmutable(model);
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
	
	internal class MetaNamedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaNamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaNamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamedElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaNamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal MetaNamedElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaNamedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaNamedElementBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaNamedElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaNamedElementBuilder
	{
	
		internal MetaNamedElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaNamedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaNamedElement)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class MetaTypedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaTypedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaTypedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaTypedElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaTypedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
	
		internal MetaTypedElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaTypedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaTypedElementBuilder)base.ToMutable(model);
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	}
	
	internal class MetaTypedElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaTypedElementBuilder
	{
	
		internal MetaTypedElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaTypedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaTypedElement)base.ToImmutable(model);
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
	
	internal class MetaTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaType
	{
	
		internal MetaTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaTypeBuilder)base.ToMutable(model);
		}
	}
	
	internal class MetaTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaTypeBuilder
	{
	
		internal MetaTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaType)base.ToImmutable(model);
		}
	}
	
	internal class MetaAnnotationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotation.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaAnnotationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaAnnotationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaAnnotationImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaAnnotation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal MetaAnnotationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAnnotation; }
		}
	
		public new MetaAnnotationBuilder ToMutable()
		{
			return (MetaAnnotationBuilder)base.ToMutable();
		}
	
		public new MetaAnnotationBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaAnnotationBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaAnnotationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaAnnotationBuilder
	{
	
		internal MetaAnnotationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaAnnotation(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAnnotation; }
		}
	
		public new MetaAnnotation ToImmutable()
		{
			return (MetaAnnotation)base.ToImmutable();
		}
	
		public new MetaAnnotation ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaAnnotation)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class MetaNamespaceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaNamespaceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaNamespaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamespaceImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaNamespace
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace parent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaNamespace> usings0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaNamespace> namespaces0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaDeclaration> declarations0;
	
		internal MetaNamespaceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaNamespaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaNamespaceBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Parent
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.ParentProperty, ref parent0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaNamespace> Usings
		{
		    get { return this.GetList<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.UsingsProperty, ref usings0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.MetaModelProperty, ref metaModel0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaNamespace> Namespaces
		{
		    get { return this.GetList<MetaNamespace>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.NamespacesProperty, ref namespaces0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaDeclaration> Declarations
		{
		    get { return this.GetList<MetaDeclaration>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaNamespaceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaNamespaceBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<MetaNamespaceBuilder> usings0;
		private global::MetaDslx.Core.MutableModelList<MetaNamespaceBuilder> namespaces0;
		private global::MetaDslx.Core.MutableModelList<MetaDeclarationBuilder> declarations0;
	
		internal MetaNamespaceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaNamespace ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaNamespace)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public MetaNamespaceBuilder Parent
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.ParentProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.ParentProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> ParentLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.ParentProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamespace.ParentProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaNamespaceBuilder> Usings
		{
			get { return this.GetList<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.UsingsProperty, ref usings0); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.MetaModelProperty); }
			set { this.SetReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.MetaModelProperty, value); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamespace.MetaModelProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaNamespaceBuilder> Namespaces
		{
			get { return this.GetList<MetaNamespaceBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.NamespacesProperty, ref namespaces0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaDeclarationBuilder> Declarations
		{
			get { return this.GetList<MetaDeclarationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class MetaDeclarationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDeclaration.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaDeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaDeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaDeclarationImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaDeclaration
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
	
		internal MetaDeclarationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaDeclarationBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaDeclarationBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaDeclarationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaDeclarationBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaDeclarationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaDeclaration ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaDeclaration)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
	internal class MetaModelId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaModel.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaModelImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaModelBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaModelImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaModel
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string uri0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
	
		internal MetaModelImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaModelBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaModelBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaModelBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaModelBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaModelBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaModel ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaModel)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
	internal class MetaCollectionTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaCollectionType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaCollectionTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaCollectionTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaCollectionTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaCollectionType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaCollectionKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType innerType0;
	
		internal MetaCollectionTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaCollectionTypeBuilder)base.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
	internal class MetaCollectionTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaCollectionTypeBuilder
	{
	
		internal MetaCollectionTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaCollectionType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaCollectionType)base.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class MetaNullableTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNullableType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaNullableTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaNullableTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNullableTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaNullableType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType innerType0;
	
		internal MetaNullableTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaNullableTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaNullableTypeBuilder)base.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public MetaType InnerType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNullableType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class MetaNullableTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaNullableTypeBuilder
	{
	
		internal MetaNullableTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaNullableType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaNullableType)base.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class MetaPrimitiveTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaPrimitiveType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaPrimitiveTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaPrimitiveTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaPrimitiveTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaPrimitiveType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
	
		internal MetaPrimitiveTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaPrimitiveTypeBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaPrimitiveTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaPrimitiveTypeBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaPrimitiveTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaPrimitiveType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaPrimitiveType)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
	internal class MetaEnumId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaEnumImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaEnumBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaEnumImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaEnum
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaEnumLiteral> enumLiterals0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaOperation> operations0;
	
		internal MetaEnumImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaEnumBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaEnumBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaEnumLiteral> EnumLiterals
		{
		    get { return this.GetList<MetaEnumLiteral>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaEnumBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaEnumBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<MetaEnumLiteralBuilder> enumLiterals0;
		private global::MetaDslx.Core.MutableModelList<MetaOperationBuilder> operations0;
	
		internal MetaEnumBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaEnum ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaEnum)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals
		{
			get { return this.GetList<MetaEnumLiteralBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	}
	
	internal class MetaEnumLiteralId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaEnumLiteral.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaEnumLiteralImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaEnumLiteralBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaEnumLiteralImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaEnumLiteral
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaEnum enum0;
	
		internal MetaEnumLiteralImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaEnumLiteralBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
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
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaEnumLiteralBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaEnumLiteralBuilder
	{
	
		internal MetaEnumLiteralBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaEnumLiteral ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaEnumLiteral)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class MetaConstantId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaConstant.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaConstantImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaConstantBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaConstantImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaConstant
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
	
		internal MetaConstantImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaConstantBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaConstantBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaConstantBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaConstantBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaConstantBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaConstant ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaConstant)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
	internal class MetaClassId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaClassImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaClassBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaClassImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaClass
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaClass> superClasses0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaProperty> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaOperation> operations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaConstructor constructor0;
	
		internal MetaClassImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaClassBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaClassBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaClass> SuperClasses
		{
		    get { return this.GetList<MetaClass>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaProperty> Properties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		public MetaConstructor Constructor
		{
		    get { return this.GetReference<MetaConstructor>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.ConstructorProperty, ref constructor0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<MetaClass> MetaClass.GetAllSuperClasses(bool includeSelf)
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this, includeSelf);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> MetaClass.GetAllSuperProperties(bool includeSelf)
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperProperties(this, includeSelf);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<MetaOperation> MetaClass.GetAllSuperOperations(bool includeSelf)
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperOperations(this, includeSelf);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> MetaClass.GetAllProperties()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<MetaOperation> MetaClass.GetAllOperations()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<MetaProperty> MetaClass.GetAllFinalProperties()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllFinalProperties(this);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<MetaOperation> MetaClass.GetAllFinalOperations()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllFinalOperations(this);
		}
	}
	
	internal class MetaClassBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaClassBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<MetaClassBuilder> superClasses0;
		private global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> properties0;
		private global::MetaDslx.Core.MutableModelList<MetaOperationBuilder> operations0;
	
		internal MetaClassBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaClass ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaClass)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaClassBuilder> SuperClasses
		{
			get { return this.GetList<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> Properties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		public MetaConstructorBuilder Constructor
		{
			get { return this.GetReference<MetaConstructorBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.ConstructorProperty); }
			set { this.SetReference<MetaConstructorBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.ConstructorProperty, value); }
		}
		
		public Func<MetaConstructorBuilder> ConstructorLazy
		{
			get { return this.GetLazyReference<MetaConstructorBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaClass.ConstructorProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaClass.ConstructorProperty, value); }
		}
	}
	
	internal class MetaFunctionTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunctionType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaFunctionTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaFunctionTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaFunctionTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaFunctionType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaType> parameterTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType returnType0;
	
		internal MetaFunctionTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaFunctionType; }
		}
	
		public new MetaFunctionTypeBuilder ToMutable()
		{
			return (MetaFunctionTypeBuilder)base.ToMutable();
		}
	
		public new MetaFunctionTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaFunctionTypeBuilder)base.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaType> ParameterTypes
		{
		    get { return this.GetList<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunctionType.ParameterTypesProperty, ref parameterTypes0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunctionType.ReturnTypeProperty, ref returnType0); }
		}
	}
	
	internal class MetaFunctionTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaFunctionTypeBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaTypeBuilder> parameterTypes0;
	
		internal MetaFunctionTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaFunctionType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaFunctionType; }
		}
	
		public new MetaFunctionType ToImmutable()
		{
			return (MetaFunctionType)base.ToImmutable();
		}
	
		public new MetaFunctionType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaFunctionType)base.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaTypeBuilder> ParameterTypes
		{
			get { return this.GetList<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunctionType.ParameterTypesProperty, ref parameterTypes0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunctionType.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunctionType.ReturnTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ReturnTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunctionType.ReturnTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunctionType.ReturnTypeProperty, value); }
		}
	}
	
	internal class MetaFunctionId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaFunctionImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaFunctionBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaFunctionImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaFunction
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaFunctionType type1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaParameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType returnType0;
	
		internal MetaFunctionImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaFunction; }
		}
	
		public new MetaFunctionBuilder ToMutable()
		{
			return (MetaFunctionBuilder)base.ToMutable();
		}
	
		public new MetaFunctionBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaFunctionBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		MetaType MetaTypedElement.Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public MetaFunctionType Type
		{
		    get { return this.GetReference<MetaFunctionType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.TypeProperty, ref type1); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaParameter> Parameters
		{
		    get { return this.GetList<MetaParameter>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ReturnTypeProperty, ref returnType0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaFunctionBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaFunctionBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<MetaParameterBuilder> parameters0;
	
		internal MetaFunctionBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaFunction(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaFunction; }
		}
	
		public new MetaFunction ToImmutable()
		{
			return (MetaFunction)base.ToImmutable();
		}
	
		public new MetaFunction ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaFunction)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		MetaTypeBuilder MetaTypedElementBuilder.Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Func<MetaTypeBuilder> MetaTypedElementBuilder.TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public MetaFunctionTypeBuilder Type
		{
			get { return this.GetReference<MetaFunctionTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.TypeProperty); }
		}
		
		public Func<MetaFunctionTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaFunctionTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunction.TypeProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaParameterBuilder> Parameters
		{
			get { return this.GetList<MetaParameterBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ReturnTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
		}
	}
	
	internal class MetaOperationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaOperationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaOperationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaOperationImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaOperation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaFunctionType type1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaParameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType returnType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType parent0;
	
		internal MetaOperationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaOperationBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaOperationBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaFunctionBuilder MetaFunction.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaFunctionBuilder MetaFunction.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		MetaType MetaTypedElement.Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public MetaFunctionType Type
		{
		    get { return this.GetReference<MetaFunctionType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.TypeProperty, ref type1); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaParameter> Parameters
		{
		    get { return this.GetList<MetaParameter>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ReturnTypeProperty, ref returnType0); }
		}
	
		
		public MetaType Parent
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaOperation.ParentProperty, ref parent0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaOperationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaOperationBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<MetaParameterBuilder> parameters0;
	
		internal MetaOperationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaOperation ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaOperation)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaFunction MetaFunctionBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaFunction MetaFunctionBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		MetaTypeBuilder MetaTypedElementBuilder.Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Func<MetaTypeBuilder> MetaTypedElementBuilder.TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public MetaFunctionTypeBuilder Type
		{
			get { return this.GetReference<MetaFunctionTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.TypeProperty); }
		}
		
		public Func<MetaFunctionTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaFunctionTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunction.TypeProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaParameterBuilder> Parameters
		{
			get { return this.GetList<MetaParameterBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ReturnTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
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
	}
	
	internal class MetaConstructorId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaConstructor.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaConstructorImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaConstructorBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaConstructorImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaConstructor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaClass parent0;
	
		internal MetaConstructorImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaConstructor; }
		}
	
		public new MetaConstructorBuilder ToMutable()
		{
			return (MetaConstructorBuilder)base.ToMutable();
		}
	
		public new MetaConstructorBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaConstructorBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaClass Parent
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaConstructor.ParentProperty, ref parent0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaConstructorBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaConstructorBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaConstructorBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaConstructor(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Meta.Symbols.MetaInstance.MetaMetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaConstructor; }
		}
	
		public new MetaConstructor ToImmutable()
		{
			return (MetaConstructor)base.ToImmutable();
		}
	
		public new MetaConstructor ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaConstructor)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public MetaClassBuilder Parent
		{
			get { return this.GetReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaConstructor.ParentProperty); }
			set { this.SetReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaConstructor.ParentProperty, value); }
		}
		
		public Func<MetaClassBuilder> ParentLazy
		{
			get { return this.GetLazyReference<MetaClassBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaConstructor.ParentProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaConstructor.ParentProperty, value); }
		}
	}
	
	internal class MetaParameterId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaParameterImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaFunction function0;
	
		internal MetaParameterImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaParameterBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaParameterBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaFunction Function
		{
		    get { return this.GetReference<MetaFunction>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.FunctionProperty, ref function0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaParameterBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaParameterBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaParameterBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaParameter ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaParameter)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public MetaFunctionBuilder Function
		{
			get { return this.GetReference<MetaFunctionBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.FunctionProperty); }
			set { this.SetReference<MetaFunctionBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.FunctionProperty, value); }
		}
		
		public Func<MetaFunctionBuilder> FunctionLazy
		{
			get { return this.GetLazyReference<MetaFunctionBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaParameter.FunctionProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaParameter.FunctionProperty, value); }
		}
	}
	
	internal class MetaPropertyId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new MetaPropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new MetaPropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaPropertyImpl : global::MetaDslx.Core.ImmutableSymbolBase, MetaProperty
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaPropertyKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaClass class0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaProperty> oppositeProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaProperty> subsettedProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaProperty> subsettingProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaProperty> redefinedProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<MetaProperty> redefiningProperties0;
	
		internal MetaPropertyImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new MetaPropertyBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (MetaPropertyBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaProperty> OppositeProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaProperty> SubsettedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaProperty> SubsettingProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaProperty> RedefinedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<MetaProperty> RedefiningProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Meta.Symbols.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaPropertyBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, MetaPropertyBuilder
	{
		private global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> oppositeProperties0;
		private global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> subsettedProperties0;
		private global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> subsettingProperties0;
		private global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> redefinedProperties0;
		private global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> redefiningProperties0;
	
		internal MetaPropertyBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new MetaProperty ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (MetaProperty)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> OppositeProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> SubsettedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> SubsettingProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> RedefinedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Languages.Meta.Symbols.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<MetaPropertyBuilder> RedefiningProperties
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
		internal global::MetaDslx.Core.MutableModel Model;
	
		internal MetaPrimitiveTypeBuilder Object = null;
		internal MetaPrimitiveTypeBuilder String = null;
		internal MetaPrimitiveTypeBuilder Int = null;
		internal MetaPrimitiveTypeBuilder Long = null;
		internal MetaPrimitiveTypeBuilder Float = null;
		internal MetaPrimitiveTypeBuilder Double = null;
		internal MetaPrimitiveTypeBuilder Byte = null;
		internal MetaPrimitiveTypeBuilder Bool = null;
		internal MetaPrimitiveTypeBuilder Void = null;
		internal MetaPrimitiveTypeBuilder Symbol = null;
	
		private MetaNamespaceBuilder __tmp1;
		private MetaNamespaceBuilder __tmp2;
		private MetaNamespaceBuilder __tmp3;
		private MetaNamespaceBuilder __tmp4;
		private MetaNamespaceBuilder __tmp5;
		private MetaModelBuilder __tmp6;
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
		internal MetaClassBuilder MetaAnnotatedElement;
		internal MetaClassBuilder MetaDocumentedElement;
		internal MetaClassBuilder MetaNamedElement;
		internal MetaClassBuilder MetaTypedElement;
		internal MetaClassBuilder MetaType;
		internal MetaClassBuilder MetaAnnotation;
		internal MetaClassBuilder MetaNamespace;
		internal MetaClassBuilder MetaDeclaration;
		internal MetaClassBuilder MetaModel;
		internal MetaEnumBuilder MetaCollectionKind;
		internal MetaClassBuilder MetaCollectionType;
		internal MetaClassBuilder MetaNullableType;
		internal MetaClassBuilder MetaPrimitiveType;
		internal MetaClassBuilder MetaEnum;
		internal MetaClassBuilder MetaEnumLiteral;
		internal MetaClassBuilder MetaConstant;
		internal MetaClassBuilder MetaClass;
		internal MetaClassBuilder MetaFunctionType;
		internal MetaClassBuilder MetaFunction;
		internal MetaClassBuilder MetaOperation;
		internal MetaClassBuilder MetaConstructor;
		internal MetaClassBuilder MetaParameter;
		internal MetaEnumBuilder MetaPropertyKind;
		internal MetaClassBuilder MetaProperty;
		private MetaAnnotationBuilder __tmp17;
		internal MetaPropertyBuilder MetaNamespace_Parent;
		internal MetaPropertyBuilder MetaNamespace_Usings;
		internal MetaPropertyBuilder MetaNamespace_MetaModel;
		internal MetaPropertyBuilder MetaNamespace_Namespaces;
		internal MetaPropertyBuilder MetaNamespace_Declarations;
		internal MetaPropertyBuilder MetaDeclaration_Namespace;
		internal MetaPropertyBuilder MetaDeclaration_MetaModel;
		internal MetaPropertyBuilder MetaModel_Uri;
		internal MetaPropertyBuilder MetaModel_Namespace;
		internal MetaPropertyBuilder MetaEnumLiteral_Enum;
		private MetaAnnotationBuilder __tmp18;
		internal MetaPropertyBuilder MetaEnum_EnumLiterals;
		internal MetaPropertyBuilder MetaEnum_Operations;
		internal MetaPropertyBuilder MetaConstructor_Parent;
		private MetaAnnotationBuilder __tmp19;
		internal MetaPropertyBuilder MetaClass_IsAbstract;
		internal MetaPropertyBuilder MetaClass_SuperClasses;
		internal MetaPropertyBuilder MetaClass_Properties;
		internal MetaPropertyBuilder MetaClass_Operations;
		internal MetaPropertyBuilder MetaClass_Constructor;
		private MetaOperationBuilder __tmp20;
		private MetaOperationBuilder __tmp21;
		private MetaOperationBuilder __tmp22;
		private MetaOperationBuilder __tmp23;
		private MetaOperationBuilder __tmp24;
		private MetaOperationBuilder __tmp25;
		private MetaOperationBuilder __tmp26;
		internal MetaPropertyBuilder MetaOperation_Parent;
		internal MetaPropertyBuilder MetaFunction_Type;
		internal MetaPropertyBuilder MetaFunction_Parameters;
		internal MetaPropertyBuilder MetaFunction_ReturnType;
		internal MetaPropertyBuilder MetaParameter_Function;
		internal MetaPropertyBuilder MetaProperty_Kind;
		internal MetaPropertyBuilder MetaProperty_Class;
		internal MetaPropertyBuilder MetaProperty_OppositeProperties;
		internal MetaPropertyBuilder MetaProperty_SubsettedProperties;
		internal MetaPropertyBuilder MetaProperty_SubsettingProperties;
		internal MetaPropertyBuilder MetaProperty_RedefinedProperties;
		internal MetaPropertyBuilder MetaProperty_RedefiningProperties;
		internal MetaPropertyBuilder MetaNullableType_InnerType;
		internal MetaPropertyBuilder MetaFunctionType_ParameterTypes;
		internal MetaPropertyBuilder MetaFunctionType_ReturnType;
		internal MetaPropertyBuilder MetaDocumentedElement_Documentation;
		private MetaOperationBuilder __tmp27;
		internal MetaPropertyBuilder MetaCollectionType_Kind;
		internal MetaPropertyBuilder MetaCollectionType_InnerType;
		internal MetaPropertyBuilder MetaTypedElement_Type;
		internal MetaPropertyBuilder MetaNamedElement_Name;
		private MetaEnumLiteralBuilder __tmp28;
		private MetaEnumLiteralBuilder __tmp29;
		private MetaEnumLiteralBuilder __tmp30;
		private MetaEnumLiteralBuilder __tmp31;
		private MetaEnumLiteralBuilder __tmp32;
		private MetaEnumLiteralBuilder __tmp33;
		private MetaAnnotationBuilder __tmp34;
		private MetaEnumLiteralBuilder __tmp35;
		private MetaEnumLiteralBuilder __tmp36;
		private MetaEnumLiteralBuilder __tmp37;
		private MetaEnumLiteralBuilder __tmp38;
		internal MetaPropertyBuilder MetaAnnotatedElement_Annotations;
		private MetaAnnotationBuilder __tmp39;
		private MetaCollectionTypeBuilder __tmp40;
		private MetaAnnotationBuilder __tmp41;
		private MetaCollectionTypeBuilder __tmp42;
		private MetaAnnotationBuilder __tmp43;
		private MetaCollectionTypeBuilder __tmp44;
		private MetaAnnotationBuilder __tmp45;
		private MetaCollectionTypeBuilder __tmp46;
		private MetaAnnotationBuilder __tmp47;
		private MetaCollectionTypeBuilder __tmp48;
		private MetaAnnotationBuilder __tmp49;
		private MetaCollectionTypeBuilder __tmp50;
		private MetaAnnotationBuilder __tmp51;
		private MetaCollectionTypeBuilder __tmp52;
		private MetaAnnotationBuilder __tmp53;
		private MetaCollectionTypeBuilder __tmp54;
		private MetaCollectionTypeBuilder __tmp55;
		private MetaParameterBuilder __tmp56;
		private MetaCollectionTypeBuilder __tmp57;
		private MetaParameterBuilder __tmp58;
		private MetaCollectionTypeBuilder __tmp59;
		private MetaParameterBuilder __tmp60;
		private MetaCollectionTypeBuilder __tmp61;
		private MetaCollectionTypeBuilder __tmp62;
		private MetaCollectionTypeBuilder __tmp63;
		private MetaCollectionTypeBuilder __tmp64;
		private MetaAnnotationBuilder __tmp65;
		private MetaCollectionTypeBuilder __tmp66;
		private MetaCollectionTypeBuilder __tmp67;
		private MetaCollectionTypeBuilder __tmp68;
		private MetaCollectionTypeBuilder __tmp69;
		private MetaCollectionTypeBuilder __tmp70;
		private MetaCollectionTypeBuilder __tmp71;
		private MetaCollectionTypeBuilder __tmp72;
		private MetaCollectionTypeBuilder __tmp73;
		private MetaAnnotationBuilder __tmp74;
		private MetaAnnotationBuilder __tmp75;
		private MetaCollectionTypeBuilder __tmp76;
	
		internal MetaBuilderInstance()
		{
			this.Model = new global::MetaDslx.Core.MutableModel("MetaDslx.Core");
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
			global::MetaDslx.Languages.Meta.Symbols.MetaFactory factory = new global::MetaDslx.Languages.Meta.Symbols.MetaFactory(this.Model, global::MetaDslx.Core.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaNamespace();
			__tmp5 = factory.MetaNamespace();
			__tmp6 = factory.MetaModel();
			MetaMetaModel = __tmp6;
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
			MetaAnnotatedElement = factory.MetaClass();
			MetaDocumentedElement = factory.MetaClass();
			MetaNamedElement = factory.MetaClass();
			MetaTypedElement = factory.MetaClass();
			MetaType = factory.MetaClass();
			MetaAnnotation = factory.MetaClass();
			MetaNamespace = factory.MetaClass();
			MetaDeclaration = factory.MetaClass();
			MetaModel = factory.MetaClass();
			MetaCollectionKind = factory.MetaEnum();
			MetaCollectionType = factory.MetaClass();
			MetaNullableType = factory.MetaClass();
			MetaPrimitiveType = factory.MetaClass();
			MetaEnum = factory.MetaClass();
			MetaEnumLiteral = factory.MetaClass();
			MetaConstant = factory.MetaClass();
			MetaClass = factory.MetaClass();
			MetaFunctionType = factory.MetaClass();
			MetaFunction = factory.MetaClass();
			MetaOperation = factory.MetaClass();
			MetaConstructor = factory.MetaClass();
			MetaParameter = factory.MetaClass();
			MetaPropertyKind = factory.MetaEnum();
			MetaProperty = factory.MetaClass();
			__tmp17 = factory.MetaAnnotation();
			MetaNamespace_Parent = factory.MetaProperty();
			MetaNamespace_Usings = factory.MetaProperty();
			MetaNamespace_MetaModel = factory.MetaProperty();
			MetaNamespace_Namespaces = factory.MetaProperty();
			MetaNamespace_Declarations = factory.MetaProperty();
			MetaDeclaration_Namespace = factory.MetaProperty();
			MetaDeclaration_MetaModel = factory.MetaProperty();
			MetaModel_Uri = factory.MetaProperty();
			MetaModel_Namespace = factory.MetaProperty();
			MetaEnumLiteral_Enum = factory.MetaProperty();
			__tmp18 = factory.MetaAnnotation();
			MetaEnum_EnumLiterals = factory.MetaProperty();
			MetaEnum_Operations = factory.MetaProperty();
			MetaConstructor_Parent = factory.MetaProperty();
			__tmp19 = factory.MetaAnnotation();
			MetaClass_IsAbstract = factory.MetaProperty();
			MetaClass_SuperClasses = factory.MetaProperty();
			MetaClass_Properties = factory.MetaProperty();
			MetaClass_Operations = factory.MetaProperty();
			MetaClass_Constructor = factory.MetaProperty();
			__tmp20 = factory.MetaOperation();
			__tmp21 = factory.MetaOperation();
			__tmp22 = factory.MetaOperation();
			__tmp23 = factory.MetaOperation();
			__tmp24 = factory.MetaOperation();
			__tmp25 = factory.MetaOperation();
			__tmp26 = factory.MetaOperation();
			MetaOperation_Parent = factory.MetaProperty();
			MetaFunction_Type = factory.MetaProperty();
			MetaFunction_Parameters = factory.MetaProperty();
			MetaFunction_ReturnType = factory.MetaProperty();
			MetaParameter_Function = factory.MetaProperty();
			MetaProperty_Kind = factory.MetaProperty();
			MetaProperty_Class = factory.MetaProperty();
			MetaProperty_OppositeProperties = factory.MetaProperty();
			MetaProperty_SubsettedProperties = factory.MetaProperty();
			MetaProperty_SubsettingProperties = factory.MetaProperty();
			MetaProperty_RedefinedProperties = factory.MetaProperty();
			MetaProperty_RedefiningProperties = factory.MetaProperty();
			MetaNullableType_InnerType = factory.MetaProperty();
			MetaFunctionType_ParameterTypes = factory.MetaProperty();
			MetaFunctionType_ReturnType = factory.MetaProperty();
			MetaDocumentedElement_Documentation = factory.MetaProperty();
			__tmp27 = factory.MetaOperation();
			MetaCollectionType_Kind = factory.MetaProperty();
			MetaCollectionType_InnerType = factory.MetaProperty();
			MetaTypedElement_Type = factory.MetaProperty();
			MetaNamedElement_Name = factory.MetaProperty();
			__tmp28 = factory.MetaEnumLiteral();
			__tmp29 = factory.MetaEnumLiteral();
			__tmp30 = factory.MetaEnumLiteral();
			__tmp31 = factory.MetaEnumLiteral();
			__tmp32 = factory.MetaEnumLiteral();
			__tmp33 = factory.MetaEnumLiteral();
			__tmp34 = factory.MetaAnnotation();
			__tmp35 = factory.MetaEnumLiteral();
			__tmp36 = factory.MetaEnumLiteral();
			__tmp37 = factory.MetaEnumLiteral();
			__tmp38 = factory.MetaEnumLiteral();
			MetaAnnotatedElement_Annotations = factory.MetaProperty();
			__tmp39 = factory.MetaAnnotation();
			__tmp40 = factory.MetaCollectionType();
			__tmp41 = factory.MetaAnnotation();
			__tmp42 = factory.MetaCollectionType();
			__tmp43 = factory.MetaAnnotation();
			__tmp44 = factory.MetaCollectionType();
			__tmp45 = factory.MetaAnnotation();
			__tmp46 = factory.MetaCollectionType();
			__tmp47 = factory.MetaAnnotation();
			__tmp48 = factory.MetaCollectionType();
			__tmp49 = factory.MetaAnnotation();
			__tmp50 = factory.MetaCollectionType();
			__tmp51 = factory.MetaAnnotation();
			__tmp52 = factory.MetaCollectionType();
			__tmp53 = factory.MetaAnnotation();
			__tmp54 = factory.MetaCollectionType();
			__tmp55 = factory.MetaCollectionType();
			__tmp56 = factory.MetaParameter();
			__tmp57 = factory.MetaCollectionType();
			__tmp58 = factory.MetaParameter();
			__tmp59 = factory.MetaCollectionType();
			__tmp60 = factory.MetaParameter();
			__tmp61 = factory.MetaCollectionType();
			__tmp62 = factory.MetaCollectionType();
			__tmp63 = factory.MetaCollectionType();
			__tmp64 = factory.MetaCollectionType();
			__tmp65 = factory.MetaAnnotation();
			__tmp66 = factory.MetaCollectionType();
			__tmp67 = factory.MetaCollectionType();
			__tmp68 = factory.MetaCollectionType();
			__tmp69 = factory.MetaCollectionType();
			__tmp70 = factory.MetaCollectionType();
			__tmp71 = factory.MetaCollectionType();
			__tmp72 = factory.MetaCollectionType();
			__tmp73 = factory.MetaCollectionType();
			__tmp74 = factory.MetaAnnotation();
			__tmp75 = factory.MetaAnnotation();
			__tmp76 = factory.MetaCollectionType();
	
			__tmp1.Name = "";
			__tmp1.Documentation = null;
			// __tmp1.Parent = null;
			// __tmp1.MetaModel = null;
			__tmp1.Namespaces.AddLazy(() => __tmp2);
			__tmp2.Name = "MetaDslx";
			__tmp2.Documentation = null;
			__tmp2.ParentLazy = () => __tmp1;
			// __tmp2.MetaModel = null;
			__tmp2.Namespaces.AddLazy(() => __tmp3);
			__tmp3.Name = "Languages";
			__tmp3.Documentation = null;
			__tmp3.ParentLazy = () => __tmp2;
			// __tmp3.MetaModel = null;
			__tmp3.Namespaces.AddLazy(() => __tmp4);
			__tmp4.Name = "Meta";
			__tmp4.Documentation = null;
			__tmp4.ParentLazy = () => __tmp3;
			// __tmp4.MetaModel = null;
			__tmp4.Namespaces.AddLazy(() => __tmp5);
			__tmp5.Name = "Symbols";
			__tmp5.Documentation = null;
			__tmp5.ParentLazy = () => __tmp4;
			__tmp5.MetaModelLazy = () => __tmp6;
			__tmp5.Declarations.AddLazy(() => __tmp7);
			__tmp5.Declarations.AddLazy(() => __tmp8);
			__tmp5.Declarations.AddLazy(() => __tmp9);
			__tmp5.Declarations.AddLazy(() => __tmp10);
			__tmp5.Declarations.AddLazy(() => __tmp11);
			__tmp5.Declarations.AddLazy(() => __tmp12);
			__tmp5.Declarations.AddLazy(() => __tmp13);
			__tmp5.Declarations.AddLazy(() => __tmp14);
			__tmp5.Declarations.AddLazy(() => __tmp15);
			__tmp5.Declarations.AddLazy(() => __tmp16);
			__tmp5.Declarations.AddLazy(() => MetaAnnotatedElement);
			__tmp5.Declarations.AddLazy(() => MetaDocumentedElement);
			__tmp5.Declarations.AddLazy(() => MetaNamedElement);
			__tmp5.Declarations.AddLazy(() => MetaTypedElement);
			__tmp5.Declarations.AddLazy(() => MetaType);
			__tmp5.Declarations.AddLazy(() => MetaAnnotation);
			__tmp5.Declarations.AddLazy(() => MetaNamespace);
			__tmp5.Declarations.AddLazy(() => MetaDeclaration);
			__tmp5.Declarations.AddLazy(() => MetaModel);
			__tmp5.Declarations.AddLazy(() => MetaCollectionKind);
			__tmp5.Declarations.AddLazy(() => MetaCollectionType);
			__tmp5.Declarations.AddLazy(() => MetaNullableType);
			__tmp5.Declarations.AddLazy(() => MetaPrimitiveType);
			__tmp5.Declarations.AddLazy(() => MetaEnum);
			__tmp5.Declarations.AddLazy(() => MetaEnumLiteral);
			__tmp5.Declarations.AddLazy(() => MetaConstant);
			__tmp5.Declarations.AddLazy(() => MetaClass);
			__tmp5.Declarations.AddLazy(() => MetaFunctionType);
			__tmp5.Declarations.AddLazy(() => MetaFunction);
			__tmp5.Declarations.AddLazy(() => MetaOperation);
			__tmp5.Declarations.AddLazy(() => MetaConstructor);
			__tmp5.Declarations.AddLazy(() => MetaParameter);
			__tmp5.Declarations.AddLazy(() => MetaPropertyKind);
			__tmp5.Declarations.AddLazy(() => MetaProperty);
			__tmp6.Name = "Meta";
			__tmp6.Documentation = null;
			__tmp6.Uri = "http://metadslx.core/1.0";
			__tmp6.NamespaceLazy = () => __tmp5;
			__tmp7.MetaModelLazy = () => __tmp6;
			__tmp7.NamespaceLazy = () => __tmp5;
			__tmp7.Documentation = null;
			__tmp7.Name = "Object";
			__tmp7.TypeLazy = () => MetaPrimitiveType;
			__tmp8.MetaModelLazy = () => __tmp6;
			__tmp8.NamespaceLazy = () => __tmp5;
			__tmp8.Documentation = null;
			__tmp8.Name = "String";
			__tmp8.TypeLazy = () => MetaPrimitiveType;
			__tmp9.MetaModelLazy = () => __tmp6;
			__tmp9.NamespaceLazy = () => __tmp5;
			__tmp9.Documentation = null;
			__tmp9.Name = "Int";
			__tmp9.TypeLazy = () => MetaPrimitiveType;
			__tmp10.MetaModelLazy = () => __tmp6;
			__tmp10.NamespaceLazy = () => __tmp5;
			__tmp10.Documentation = null;
			__tmp10.Name = "Long";
			__tmp10.TypeLazy = () => MetaPrimitiveType;
			__tmp11.MetaModelLazy = () => __tmp6;
			__tmp11.NamespaceLazy = () => __tmp5;
			__tmp11.Documentation = null;
			__tmp11.Name = "Float";
			__tmp11.TypeLazy = () => MetaPrimitiveType;
			__tmp12.MetaModelLazy = () => __tmp6;
			__tmp12.NamespaceLazy = () => __tmp5;
			__tmp12.Documentation = null;
			__tmp12.Name = "Double";
			__tmp12.TypeLazy = () => MetaPrimitiveType;
			__tmp13.MetaModelLazy = () => __tmp6;
			__tmp13.NamespaceLazy = () => __tmp5;
			__tmp13.Documentation = null;
			__tmp13.Name = "Byte";
			__tmp13.TypeLazy = () => MetaPrimitiveType;
			__tmp14.MetaModelLazy = () => __tmp6;
			__tmp14.NamespaceLazy = () => __tmp5;
			__tmp14.Documentation = null;
			__tmp14.Name = "Bool";
			__tmp14.TypeLazy = () => MetaPrimitiveType;
			__tmp15.MetaModelLazy = () => __tmp6;
			__tmp15.NamespaceLazy = () => __tmp5;
			__tmp15.Documentation = null;
			__tmp15.Name = "Void";
			__tmp15.TypeLazy = () => MetaPrimitiveType;
			__tmp16.MetaModelLazy = () => __tmp6;
			__tmp16.NamespaceLazy = () => __tmp5;
			__tmp16.Documentation = null;
			__tmp16.Name = "Symbol";
			__tmp16.TypeLazy = () => MetaPrimitiveType;
			MetaAnnotatedElement.MetaModelLazy = () => __tmp6;
			MetaAnnotatedElement.NamespaceLazy = () => __tmp5;
			MetaAnnotatedElement.Documentation = null;
			MetaAnnotatedElement.Name = "MetaAnnotatedElement";
			MetaAnnotatedElement.IsAbstract = true;
			MetaAnnotatedElement.Properties.AddLazy(() => MetaAnnotatedElement_Annotations);
			// MetaAnnotatedElement.Constructor = null;
			MetaDocumentedElement.MetaModelLazy = () => __tmp6;
			MetaDocumentedElement.NamespaceLazy = () => __tmp5;
			MetaDocumentedElement.Documentation = null;
			MetaDocumentedElement.Name = "MetaDocumentedElement";
			MetaDocumentedElement.IsAbstract = true;
			MetaDocumentedElement.Properties.AddLazy(() => MetaDocumentedElement_Documentation);
			MetaDocumentedElement.Operations.AddLazy(() => __tmp27);
			// MetaDocumentedElement.Constructor = null;
			MetaNamedElement.MetaModelLazy = () => __tmp6;
			MetaNamedElement.NamespaceLazy = () => __tmp5;
			MetaNamedElement.Documentation = null;
			MetaNamedElement.Name = "MetaNamedElement";
			MetaNamedElement.IsAbstract = true;
			MetaNamedElement.SuperClasses.AddLazy(() => MetaDocumentedElement);
			MetaNamedElement.Properties.AddLazy(() => MetaNamedElement_Name);
			// MetaNamedElement.Constructor = null;
			MetaTypedElement.MetaModelLazy = () => __tmp6;
			MetaTypedElement.NamespaceLazy = () => __tmp5;
			MetaTypedElement.Documentation = null;
			MetaTypedElement.Name = "MetaTypedElement";
			MetaTypedElement.IsAbstract = true;
			MetaTypedElement.Properties.AddLazy(() => MetaTypedElement_Type);
			// MetaTypedElement.Constructor = null;
			MetaType.MetaModelLazy = () => __tmp6;
			MetaType.NamespaceLazy = () => __tmp5;
			MetaType.Documentation = null;
			MetaType.Name = "MetaType";
			MetaType.Annotations.AddLazy(() => __tmp34);
			MetaType.IsAbstract = true;
			// MetaType.Constructor = null;
			MetaAnnotation.MetaModelLazy = () => __tmp6;
			MetaAnnotation.NamespaceLazy = () => __tmp5;
			MetaAnnotation.Documentation = null;
			MetaAnnotation.Name = "MetaAnnotation";
			// MetaAnnotation.IsAbstract = null;
			MetaAnnotation.SuperClasses.AddLazy(() => MetaNamedElement);
			// MetaAnnotation.Constructor = null;
			MetaNamespace.MetaModelLazy = () => __tmp6;
			MetaNamespace.NamespaceLazy = () => __tmp5;
			MetaNamespace.Documentation = null;
			MetaNamespace.Name = "MetaNamespace";
			MetaNamespace.Annotations.AddLazy(() => __tmp17);
			// MetaNamespace.IsAbstract = null;
			MetaNamespace.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaNamespace.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Parent);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Usings);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_MetaModel);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Namespaces);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Declarations);
			// MetaNamespace.Constructor = null;
			MetaDeclaration.MetaModelLazy = () => __tmp6;
			MetaDeclaration.NamespaceLazy = () => __tmp5;
			MetaDeclaration.Documentation = null;
			MetaDeclaration.Name = "MetaDeclaration";
			MetaDeclaration.IsAbstract = true;
			MetaDeclaration.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_Namespace);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_MetaModel);
			// MetaDeclaration.Constructor = null;
			MetaModel.MetaModelLazy = () => __tmp6;
			MetaModel.NamespaceLazy = () => __tmp5;
			MetaModel.Documentation = null;
			MetaModel.Name = "MetaModel";
			// MetaModel.IsAbstract = null;
			MetaModel.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaModel.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaModel.Properties.AddLazy(() => MetaModel_Uri);
			MetaModel.Properties.AddLazy(() => MetaModel_Namespace);
			// MetaModel.Constructor = null;
			MetaCollectionKind.MetaModelLazy = () => __tmp6;
			MetaCollectionKind.NamespaceLazy = () => __tmp5;
			MetaCollectionKind.Documentation = null;
			MetaCollectionKind.Name = "MetaCollectionKind";
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp35);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp36);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp37);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp38);
			MetaCollectionType.MetaModelLazy = () => __tmp6;
			MetaCollectionType.NamespaceLazy = () => __tmp5;
			MetaCollectionType.Documentation = null;
			MetaCollectionType.Name = "MetaCollectionType";
			// MetaCollectionType.IsAbstract = null;
			MetaCollectionType.SuperClasses.AddLazy(() => MetaType);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_Kind);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_InnerType);
			// MetaCollectionType.Constructor = null;
			MetaNullableType.MetaModelLazy = () => __tmp6;
			MetaNullableType.NamespaceLazy = () => __tmp5;
			MetaNullableType.Documentation = null;
			MetaNullableType.Name = "MetaNullableType";
			// MetaNullableType.IsAbstract = null;
			MetaNullableType.SuperClasses.AddLazy(() => MetaType);
			MetaNullableType.Properties.AddLazy(() => MetaNullableType_InnerType);
			// MetaNullableType.Constructor = null;
			MetaPrimitiveType.MetaModelLazy = () => __tmp6;
			MetaPrimitiveType.NamespaceLazy = () => __tmp5;
			MetaPrimitiveType.Documentation = null;
			MetaPrimitiveType.Name = "MetaPrimitiveType";
			// MetaPrimitiveType.IsAbstract = null;
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaType);
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaNamedElement);
			// MetaPrimitiveType.Constructor = null;
			MetaEnum.MetaModelLazy = () => __tmp6;
			MetaEnum.NamespaceLazy = () => __tmp5;
			MetaEnum.Documentation = null;
			MetaEnum.Name = "MetaEnum";
			MetaEnum.Annotations.AddLazy(() => __tmp18);
			// MetaEnum.IsAbstract = null;
			MetaEnum.SuperClasses.AddLazy(() => MetaType);
			MetaEnum.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaEnum.Properties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnum.Properties.AddLazy(() => MetaEnum_Operations);
			// MetaEnum.Constructor = null;
			MetaEnumLiteral.MetaModelLazy = () => __tmp6;
			MetaEnumLiteral.NamespaceLazy = () => __tmp5;
			MetaEnumLiteral.Documentation = null;
			MetaEnumLiteral.Name = "MetaEnumLiteral";
			// MetaEnumLiteral.IsAbstract = null;
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaEnumLiteral.Properties.AddLazy(() => MetaEnumLiteral_Enum);
			// MetaEnumLiteral.Constructor = null;
			MetaConstant.MetaModelLazy = () => __tmp6;
			MetaConstant.NamespaceLazy = () => __tmp5;
			MetaConstant.Documentation = null;
			MetaConstant.Name = "MetaConstant";
			// MetaConstant.IsAbstract = null;
			MetaConstant.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaConstant.SuperClasses.AddLazy(() => MetaDeclaration);
			// MetaConstant.Constructor = null;
			MetaClass.MetaModelLazy = () => __tmp6;
			MetaClass.NamespaceLazy = () => __tmp5;
			MetaClass.Documentation = null;
			MetaClass.Name = "MetaClass";
			MetaClass.Annotations.AddLazy(() => __tmp19);
			// MetaClass.IsAbstract = null;
			MetaClass.SuperClasses.AddLazy(() => MetaType);
			MetaClass.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaClass.Properties.AddLazy(() => MetaClass_IsAbstract);
			MetaClass.Properties.AddLazy(() => MetaClass_SuperClasses);
			MetaClass.Properties.AddLazy(() => MetaClass_Properties);
			MetaClass.Properties.AddLazy(() => MetaClass_Operations);
			MetaClass.Properties.AddLazy(() => MetaClass_Constructor);
			MetaClass.Operations.AddLazy(() => __tmp20);
			MetaClass.Operations.AddLazy(() => __tmp21);
			MetaClass.Operations.AddLazy(() => __tmp22);
			MetaClass.Operations.AddLazy(() => __tmp23);
			MetaClass.Operations.AddLazy(() => __tmp24);
			MetaClass.Operations.AddLazy(() => __tmp25);
			MetaClass.Operations.AddLazy(() => __tmp26);
			// MetaClass.Constructor = null;
			MetaFunctionType.MetaModelLazy = () => __tmp6;
			MetaFunctionType.NamespaceLazy = () => __tmp5;
			MetaFunctionType.Documentation = null;
			MetaFunctionType.Name = "MetaFunctionType";
			// MetaFunctionType.IsAbstract = null;
			MetaFunctionType.SuperClasses.AddLazy(() => MetaType);
			MetaFunctionType.Properties.AddLazy(() => MetaFunctionType_ParameterTypes);
			MetaFunctionType.Properties.AddLazy(() => MetaFunctionType_ReturnType);
			// MetaFunctionType.Constructor = null;
			MetaFunction.MetaModelLazy = () => __tmp6;
			MetaFunction.NamespaceLazy = () => __tmp5;
			MetaFunction.Documentation = null;
			MetaFunction.Name = "MetaFunction";
			MetaFunction.IsAbstract = true;
			MetaFunction.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaFunction.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaFunction.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaFunction.Properties.AddLazy(() => MetaFunction_Type);
			MetaFunction.Properties.AddLazy(() => MetaFunction_Parameters);
			MetaFunction.Properties.AddLazy(() => MetaFunction_ReturnType);
			// MetaFunction.Constructor = null;
			MetaOperation.MetaModelLazy = () => __tmp6;
			MetaOperation.NamespaceLazy = () => __tmp5;
			MetaOperation.Documentation = null;
			MetaOperation.Name = "MetaOperation";
			// MetaOperation.IsAbstract = null;
			MetaOperation.SuperClasses.AddLazy(() => MetaFunction);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Parent);
			// MetaOperation.Constructor = null;
			MetaConstructor.MetaModelLazy = () => __tmp6;
			MetaConstructor.NamespaceLazy = () => __tmp5;
			MetaConstructor.Documentation = null;
			MetaConstructor.Name = "MetaConstructor";
			// MetaConstructor.IsAbstract = null;
			MetaConstructor.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaConstructor.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaConstructor.Properties.AddLazy(() => MetaConstructor_Parent);
			// MetaConstructor.Constructor = null;
			MetaParameter.MetaModelLazy = () => __tmp6;
			MetaParameter.NamespaceLazy = () => __tmp5;
			MetaParameter.Documentation = null;
			MetaParameter.Name = "MetaParameter";
			// MetaParameter.IsAbstract = null;
			MetaParameter.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaParameter.Properties.AddLazy(() => MetaParameter_Function);
			// MetaParameter.Constructor = null;
			MetaPropertyKind.MetaModelLazy = () => __tmp6;
			MetaPropertyKind.NamespaceLazy = () => __tmp5;
			MetaPropertyKind.Documentation = null;
			MetaPropertyKind.Name = "MetaPropertyKind";
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp28);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp29);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp30);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp31);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp32);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp33);
			MetaProperty.MetaModelLazy = () => __tmp6;
			MetaProperty.NamespaceLazy = () => __tmp5;
			MetaProperty.Documentation = null;
			MetaProperty.Name = "MetaProperty";
			// MetaProperty.IsAbstract = null;
			MetaProperty.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaProperty.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaProperty.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaProperty.Properties.AddLazy(() => MetaProperty_Kind);
			MetaProperty.Properties.AddLazy(() => MetaProperty_Class);
			MetaProperty.Properties.AddLazy(() => MetaProperty_OppositeProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettingProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefinedProperties);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefiningProperties);
			// MetaProperty.Constructor = null;
			__tmp17.Name = "Scope";
			__tmp17.Documentation = null;
			MetaNamespace_Parent.TypeLazy = () => MetaNamespace;
			MetaNamespace_Parent.Name = "Parent";
			MetaNamespace_Parent.Documentation = null;
			// MetaNamespace_Parent.Kind = null;
			MetaNamespace_Parent.ClassLazy = () => MetaNamespace;
			MetaNamespace_Parent.OppositeProperties.AddLazy(() => MetaNamespace_Namespaces);
			MetaNamespace_Usings.Annotations.AddLazy(() => __tmp39);
			MetaNamespace_Usings.TypeLazy = () => __tmp40;
			MetaNamespace_Usings.Name = "Usings";
			MetaNamespace_Usings.Documentation = null;
			// MetaNamespace_Usings.Kind = null;
			MetaNamespace_Usings.ClassLazy = () => MetaNamespace;
			MetaNamespace_MetaModel.TypeLazy = () => MetaModel;
			MetaNamespace_MetaModel.Name = "MetaModel";
			MetaNamespace_MetaModel.Documentation = null;
			MetaNamespace_MetaModel.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaNamespace_MetaModel.ClassLazy = () => MetaNamespace;
			MetaNamespace_MetaModel.OppositeProperties.AddLazy(() => MetaModel_Namespace);
			MetaNamespace_Namespaces.Annotations.AddLazy(() => __tmp41);
			MetaNamespace_Namespaces.TypeLazy = () => __tmp42;
			MetaNamespace_Namespaces.Name = "Namespaces";
			MetaNamespace_Namespaces.Documentation = null;
			MetaNamespace_Namespaces.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaNamespace_Namespaces.ClassLazy = () => MetaNamespace;
			MetaNamespace_Namespaces.OppositeProperties.AddLazy(() => MetaNamespace_Parent);
			MetaNamespace_Declarations.Annotations.AddLazy(() => __tmp43);
			MetaNamespace_Declarations.TypeLazy = () => __tmp44;
			MetaNamespace_Declarations.Name = "Declarations";
			MetaNamespace_Declarations.Documentation = null;
			MetaNamespace_Declarations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaNamespace_Declarations.ClassLazy = () => MetaNamespace;
			MetaNamespace_Declarations.OppositeProperties.AddLazy(() => MetaDeclaration_Namespace);
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
			MetaModel_Namespace.OppositeProperties.AddLazy(() => MetaNamespace_MetaModel);
			MetaEnumLiteral_Enum.TypeLazy = () => MetaEnum;
			MetaEnumLiteral_Enum.Name = "Enum";
			MetaEnumLiteral_Enum.Documentation = null;
			// MetaEnumLiteral_Enum.Kind = null;
			MetaEnumLiteral_Enum.ClassLazy = () => MetaEnumLiteral;
			MetaEnumLiteral_Enum.OppositeProperties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnumLiteral_Enum.RedefinedProperties.AddLazy(() => MetaTypedElement_Type);
			__tmp18.Name = "Scope";
			__tmp18.Documentation = null;
			MetaEnum_EnumLiterals.Annotations.AddLazy(() => __tmp45);
			MetaEnum_EnumLiterals.TypeLazy = () => __tmp46;
			MetaEnum_EnumLiterals.Name = "EnumLiterals";
			MetaEnum_EnumLiterals.Documentation = null;
			MetaEnum_EnumLiterals.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaEnum_EnumLiterals.ClassLazy = () => MetaEnum;
			MetaEnum_EnumLiterals.OppositeProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaEnum_Operations.Annotations.AddLazy(() => __tmp47);
			MetaEnum_Operations.TypeLazy = () => __tmp48;
			MetaEnum_Operations.Name = "Operations";
			MetaEnum_Operations.Documentation = null;
			MetaEnum_Operations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaEnum_Operations.ClassLazy = () => MetaEnum;
			MetaEnum_Operations.OppositeProperties.AddLazy(() => MetaOperation_Parent);
			MetaConstructor_Parent.TypeLazy = () => MetaClass;
			MetaConstructor_Parent.Name = "Parent";
			MetaConstructor_Parent.Documentation = null;
			// MetaConstructor_Parent.Kind = null;
			MetaConstructor_Parent.ClassLazy = () => MetaConstructor;
			MetaConstructor_Parent.OppositeProperties.AddLazy(() => MetaClass_Constructor);
			__tmp19.Name = "Scope";
			__tmp19.Documentation = null;
			MetaClass_IsAbstract.TypeLazy = () => Bool;
			MetaClass_IsAbstract.Name = "IsAbstract";
			MetaClass_IsAbstract.Documentation = null;
			// MetaClass_IsAbstract.Kind = null;
			MetaClass_IsAbstract.ClassLazy = () => MetaClass;
			MetaClass_SuperClasses.Annotations.AddLazy(() => __tmp49);
			MetaClass_SuperClasses.TypeLazy = () => __tmp50;
			MetaClass_SuperClasses.Name = "SuperClasses";
			MetaClass_SuperClasses.Documentation = null;
			// MetaClass_SuperClasses.Kind = null;
			MetaClass_SuperClasses.ClassLazy = () => MetaClass;
			MetaClass_Properties.Annotations.AddLazy(() => __tmp51);
			MetaClass_Properties.TypeLazy = () => __tmp52;
			MetaClass_Properties.Name = "Properties";
			MetaClass_Properties.Documentation = null;
			MetaClass_Properties.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaClass_Properties.ClassLazy = () => MetaClass;
			MetaClass_Properties.OppositeProperties.AddLazy(() => MetaProperty_Class);
			MetaClass_Operations.Annotations.AddLazy(() => __tmp53);
			MetaClass_Operations.TypeLazy = () => __tmp54;
			MetaClass_Operations.Name = "Operations";
			MetaClass_Operations.Documentation = null;
			MetaClass_Operations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaClass_Operations.ClassLazy = () => MetaClass;
			MetaClass_Operations.OppositeProperties.AddLazy(() => MetaOperation_Parent);
			MetaClass_Constructor.TypeLazy = () => MetaConstructor;
			MetaClass_Constructor.Name = "Constructor";
			MetaClass_Constructor.Documentation = null;
			MetaClass_Constructor.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaClass_Constructor.ClassLazy = () => MetaClass;
			MetaClass_Constructor.OppositeProperties.AddLazy(() => MetaConstructor_Parent);
			__tmp20.ReturnTypeLazy = () => __tmp55;
			__tmp20.Parameters.AddLazy(() => __tmp56);
			// TODO: __tmp20.Type
			// TODO: __tmp20.Type
			__tmp20.Documentation = null;
			__tmp20.Name = "GetAllSuperClasses";
			__tmp20.ParentLazy = () => MetaClass;
			__tmp21.ReturnTypeLazy = () => __tmp57;
			__tmp21.Parameters.AddLazy(() => __tmp58);
			// TODO: __tmp21.Type
			// TODO: __tmp21.Type
			__tmp21.Documentation = null;
			__tmp21.Name = "GetAllSuperProperties";
			__tmp21.ParentLazy = () => MetaClass;
			__tmp22.ReturnTypeLazy = () => __tmp59;
			__tmp22.Parameters.AddLazy(() => __tmp60);
			// TODO: __tmp22.Type
			// TODO: __tmp22.Type
			__tmp22.Documentation = null;
			__tmp22.Name = "GetAllSuperOperations";
			__tmp22.ParentLazy = () => MetaClass;
			__tmp23.ReturnTypeLazy = () => __tmp61;
			// TODO: __tmp23.Type
			// TODO: __tmp23.Type
			__tmp23.Documentation = null;
			__tmp23.Name = "GetAllProperties";
			__tmp23.ParentLazy = () => MetaClass;
			__tmp24.ReturnTypeLazy = () => __tmp62;
			// TODO: __tmp24.Type
			// TODO: __tmp24.Type
			__tmp24.Documentation = null;
			__tmp24.Name = "GetAllOperations";
			__tmp24.ParentLazy = () => MetaClass;
			__tmp25.ReturnTypeLazy = () => __tmp63;
			// TODO: __tmp25.Type
			// TODO: __tmp25.Type
			__tmp25.Documentation = null;
			__tmp25.Name = "GetAllFinalProperties";
			__tmp25.ParentLazy = () => MetaClass;
			__tmp26.ReturnTypeLazy = () => __tmp64;
			// TODO: __tmp26.Type
			// TODO: __tmp26.Type
			__tmp26.Documentation = null;
			__tmp26.Name = "GetAllFinalOperations";
			__tmp26.ParentLazy = () => MetaClass;
			MetaOperation_Parent.TypeLazy = () => MetaType;
			MetaOperation_Parent.Name = "Parent";
			MetaOperation_Parent.Documentation = null;
			// MetaOperation_Parent.Kind = null;
			MetaOperation_Parent.ClassLazy = () => MetaOperation;
			MetaOperation_Parent.OppositeProperties.AddLazy(() => MetaEnum_Operations);
			MetaOperation_Parent.OppositeProperties.AddLazy(() => MetaClass_Operations);
			MetaFunction_Type.Annotations.AddLazy(() => __tmp65);
			MetaFunction_Type.TypeLazy = () => MetaFunctionType;
			MetaFunction_Type.Name = "Type";
			MetaFunction_Type.Documentation = null;
			MetaFunction_Type.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Derived;
			MetaFunction_Type.ClassLazy = () => MetaFunction;
			MetaFunction_Type.RedefinedProperties.AddLazy(() => MetaTypedElement_Type);
			MetaFunction_Parameters.TypeLazy = () => __tmp66;
			MetaFunction_Parameters.Name = "Parameters";
			MetaFunction_Parameters.Documentation = null;
			MetaFunction_Parameters.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaFunction_Parameters.ClassLazy = () => MetaFunction;
			MetaFunction_Parameters.OppositeProperties.AddLazy(() => MetaParameter_Function);
			MetaFunction_ReturnType.TypeLazy = () => MetaType;
			MetaFunction_ReturnType.Name = "ReturnType";
			MetaFunction_ReturnType.Documentation = null;
			// MetaFunction_ReturnType.Kind = null;
			MetaFunction_ReturnType.ClassLazy = () => MetaFunction;
			MetaParameter_Function.TypeLazy = () => MetaFunction;
			MetaParameter_Function.Name = "Function";
			MetaParameter_Function.Documentation = null;
			// MetaParameter_Function.Kind = null;
			MetaParameter_Function.ClassLazy = () => MetaParameter;
			MetaParameter_Function.OppositeProperties.AddLazy(() => MetaFunction_Parameters);
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
			MetaProperty_OppositeProperties.TypeLazy = () => __tmp67;
			MetaProperty_OppositeProperties.Name = "OppositeProperties";
			MetaProperty_OppositeProperties.Documentation = null;
			// MetaProperty_OppositeProperties.Kind = null;
			MetaProperty_OppositeProperties.ClassLazy = () => MetaProperty;
			MetaProperty_OppositeProperties.OppositeProperties.AddLazy(() => MetaProperty_OppositeProperties);
			MetaProperty_SubsettedProperties.TypeLazy = () => __tmp68;
			MetaProperty_SubsettedProperties.Name = "SubsettedProperties";
			MetaProperty_SubsettedProperties.Documentation = null;
			// MetaProperty_SubsettedProperties.Kind = null;
			MetaProperty_SubsettedProperties.ClassLazy = () => MetaProperty;
			MetaProperty_SubsettedProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettingProperties);
			MetaProperty_SubsettingProperties.TypeLazy = () => __tmp69;
			MetaProperty_SubsettingProperties.Name = "SubsettingProperties";
			MetaProperty_SubsettingProperties.Documentation = null;
			// MetaProperty_SubsettingProperties.Kind = null;
			MetaProperty_SubsettingProperties.ClassLazy = () => MetaProperty;
			MetaProperty_SubsettingProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettedProperties);
			MetaProperty_RedefinedProperties.TypeLazy = () => __tmp70;
			MetaProperty_RedefinedProperties.Name = "RedefinedProperties";
			MetaProperty_RedefinedProperties.Documentation = null;
			// MetaProperty_RedefinedProperties.Kind = null;
			MetaProperty_RedefinedProperties.ClassLazy = () => MetaProperty;
			MetaProperty_RedefinedProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefiningProperties);
			MetaProperty_RedefiningProperties.TypeLazy = () => __tmp71;
			MetaProperty_RedefiningProperties.Name = "RedefiningProperties";
			MetaProperty_RedefiningProperties.Documentation = null;
			// MetaProperty_RedefiningProperties.Kind = null;
			MetaProperty_RedefiningProperties.ClassLazy = () => MetaProperty;
			MetaProperty_RedefiningProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefinedProperties);
			MetaNullableType_InnerType.TypeLazy = () => MetaType;
			MetaNullableType_InnerType.Name = "InnerType";
			MetaNullableType_InnerType.Documentation = null;
			// MetaNullableType_InnerType.Kind = null;
			MetaNullableType_InnerType.ClassLazy = () => MetaNullableType;
			MetaFunctionType_ParameterTypes.TypeLazy = () => __tmp72;
			MetaFunctionType_ParameterTypes.Name = "ParameterTypes";
			MetaFunctionType_ParameterTypes.Documentation = null;
			// MetaFunctionType_ParameterTypes.Kind = null;
			MetaFunctionType_ParameterTypes.ClassLazy = () => MetaFunctionType;
			MetaFunctionType_ReturnType.TypeLazy = () => MetaType;
			MetaFunctionType_ReturnType.Name = "ReturnType";
			MetaFunctionType_ReturnType.Documentation = null;
			// MetaFunctionType_ReturnType.Kind = null;
			MetaFunctionType_ReturnType.ClassLazy = () => MetaFunctionType;
			MetaDocumentedElement_Documentation.TypeLazy = () => String;
			MetaDocumentedElement_Documentation.Name = "Documentation";
			MetaDocumentedElement_Documentation.Documentation = null;
			// MetaDocumentedElement_Documentation.Kind = null;
			MetaDocumentedElement_Documentation.ClassLazy = () => MetaDocumentedElement;
			__tmp27.ReturnTypeLazy = () => __tmp73;
			// TODO: __tmp27.Type
			// TODO: __tmp27.Type
			__tmp27.Documentation = null;
			__tmp27.Name = "GetDocumentationLines";
			__tmp27.ParentLazy = () => MetaDocumentedElement;
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
			MetaTypedElement_Type.Annotations.AddLazy(() => __tmp74);
			MetaTypedElement_Type.TypeLazy = () => MetaType;
			MetaTypedElement_Type.Name = "Type";
			MetaTypedElement_Type.Documentation = null;
			// MetaTypedElement_Type.Kind = null;
			MetaTypedElement_Type.ClassLazy = () => MetaTypedElement;
			MetaTypedElement_Type.RedefiningProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaTypedElement_Type.RedefiningProperties.AddLazy(() => MetaFunction_Type);
			MetaNamedElement_Name.Annotations.AddLazy(() => __tmp75);
			MetaNamedElement_Name.TypeLazy = () => String;
			MetaNamedElement_Name.Name = "Name";
			MetaNamedElement_Name.Documentation = null;
			// MetaNamedElement_Name.Kind = null;
			MetaNamedElement_Name.ClassLazy = () => MetaNamedElement;
			__tmp28.TypeLazy = () => MetaPropertyKind;
			__tmp28.Name = "Normal";
			__tmp28.Documentation = null;
			__tmp28.EnumLazy = () => MetaPropertyKind;
			__tmp29.TypeLazy = () => MetaPropertyKind;
			__tmp29.Name = "Readonly";
			__tmp29.Documentation = null;
			__tmp29.EnumLazy = () => MetaPropertyKind;
			__tmp30.TypeLazy = () => MetaPropertyKind;
			__tmp30.Name = "Lazy";
			__tmp30.Documentation = null;
			__tmp30.EnumLazy = () => MetaPropertyKind;
			__tmp31.TypeLazy = () => MetaPropertyKind;
			__tmp31.Name = "Derived";
			__tmp31.Documentation = null;
			__tmp31.EnumLazy = () => MetaPropertyKind;
			__tmp32.TypeLazy = () => MetaPropertyKind;
			__tmp32.Name = "DerivedUnion";
			__tmp32.Documentation = null;
			__tmp32.EnumLazy = () => MetaPropertyKind;
			__tmp33.TypeLazy = () => MetaPropertyKind;
			__tmp33.Name = "Containment";
			__tmp33.Documentation = null;
			__tmp33.EnumLazy = () => MetaPropertyKind;
			__tmp34.Name = "Type";
			__tmp34.Documentation = null;
			__tmp35.TypeLazy = () => MetaCollectionKind;
			__tmp35.Name = "List";
			__tmp35.Documentation = null;
			__tmp35.EnumLazy = () => MetaCollectionKind;
			__tmp36.TypeLazy = () => MetaCollectionKind;
			__tmp36.Name = "Set";
			__tmp36.Documentation = null;
			__tmp36.EnumLazy = () => MetaCollectionKind;
			__tmp37.TypeLazy = () => MetaCollectionKind;
			__tmp37.Name = "MultiList";
			__tmp37.Documentation = null;
			__tmp37.EnumLazy = () => MetaCollectionKind;
			__tmp38.TypeLazy = () => MetaCollectionKind;
			__tmp38.Name = "MultiSet";
			__tmp38.Documentation = null;
			__tmp38.EnumLazy = () => MetaCollectionKind;
			MetaAnnotatedElement_Annotations.TypeLazy = () => __tmp76;
			MetaAnnotatedElement_Annotations.Name = "Annotations";
			MetaAnnotatedElement_Annotations.Documentation = null;
			MetaAnnotatedElement_Annotations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MetaAnnotatedElement_Annotations.ClassLazy = () => MetaAnnotatedElement;
			__tmp39.Name = "ImportedScope";
			__tmp39.Documentation = null;
			__tmp40.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp40.InnerTypeLazy = () => MetaNamespace;
			__tmp41.Name = "ScopeEntry";
			__tmp41.Documentation = null;
			__tmp42.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp42.InnerTypeLazy = () => MetaNamespace;
			__tmp43.Name = "ScopeEntry";
			__tmp43.Documentation = null;
			__tmp44.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp44.InnerTypeLazy = () => MetaDeclaration;
			__tmp45.Name = "ScopeEntry";
			__tmp45.Documentation = null;
			__tmp46.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp46.InnerTypeLazy = () => MetaEnumLiteral;
			__tmp47.Name = "ScopeEntry";
			__tmp47.Documentation = null;
			__tmp48.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp48.InnerTypeLazy = () => MetaOperation;
			__tmp49.Name = "InheritedScope";
			__tmp49.Documentation = null;
			__tmp50.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp50.InnerTypeLazy = () => MetaClass;
			__tmp51.Name = "ScopeEntry";
			__tmp51.Documentation = null;
			__tmp52.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp52.InnerTypeLazy = () => MetaProperty;
			__tmp53.Name = "ScopeEntry";
			__tmp53.Documentation = null;
			__tmp54.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp54.InnerTypeLazy = () => MetaOperation;
			__tmp55.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp55.InnerTypeLazy = () => MetaClass;
			__tmp56.TypeLazy = () => Bool;
			__tmp56.Name = "includeSelf";
			__tmp56.Documentation = null;
			__tmp56.FunctionLazy = () => __tmp20;
			__tmp57.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp57.InnerTypeLazy = () => MetaProperty;
			__tmp58.TypeLazy = () => Bool;
			__tmp58.Name = "includeSelf";
			__tmp58.Documentation = null;
			__tmp58.FunctionLazy = () => __tmp21;
			__tmp59.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp59.InnerTypeLazy = () => MetaOperation;
			__tmp60.TypeLazy = () => Bool;
			__tmp60.Name = "includeSelf";
			__tmp60.Documentation = null;
			__tmp60.FunctionLazy = () => __tmp22;
			__tmp61.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp61.InnerTypeLazy = () => MetaProperty;
			__tmp62.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp62.InnerTypeLazy = () => MetaOperation;
			__tmp63.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp63.InnerTypeLazy = () => MetaProperty;
			__tmp64.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp64.InnerTypeLazy = () => MetaOperation;
			__tmp65.Name = "Type";
			__tmp65.Documentation = null;
			__tmp66.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp66.InnerTypeLazy = () => MetaParameter;
			__tmp67.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp67.InnerTypeLazy = () => MetaProperty;
			__tmp68.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp68.InnerTypeLazy = () => MetaProperty;
			__tmp69.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp69.InnerTypeLazy = () => MetaProperty;
			__tmp70.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp70.InnerTypeLazy = () => MetaProperty;
			__tmp71.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp71.InnerTypeLazy = () => MetaProperty;
			__tmp72.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.MultiList;
			__tmp72.InnerTypeLazy = () => MetaType;
			__tmp73.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp73.InnerTypeLazy = () => String;
			__tmp74.Name = "Type";
			__tmp74.Documentation = null;
			__tmp75.Name = "Name";
			__tmp75.Documentation = null;
			__tmp76.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp76.InnerTypeLazy = () => MetaAnnotation;
	
			foreach (global::MetaDslx.Core.MutableSymbol symbol in this.Model.Symbols)
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
		/// Implements the constructor: MetaAnnotatedElement()
		/// </summary>
		public virtual void MetaAnnotatedElement(MetaAnnotatedElementBuilder _this)
		{
			this.CallMetaAnnotatedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaAnnotatedElement
		/// </summary>
		protected virtual void CallMetaAnnotatedElementSuperConstructors(MetaAnnotatedElementBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaDocumentedElement()
		/// </summary>
		public virtual void MetaDocumentedElement(MetaDocumentedElementBuilder _this)
		{
			this.CallMetaDocumentedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaDocumentedElement
		/// </summary>
		protected virtual void CallMetaDocumentedElementSuperConstructors(MetaDocumentedElementBuilder _this)
		{
		}
	
		/// <summary>
		/// Implements the operation: MetaDocumentedElement.GetDocumentationLines()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<string> MetaDocumentedElement_GetDocumentationLines(MetaDocumentedElement _this)
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
			this.MetaDocumentedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaTypedElement()
		/// </summary>
		public virtual void MetaTypedElement(MetaTypedElementBuilder _this)
		{
			this.CallMetaTypedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaTypedElement
		/// </summary>
		protected virtual void CallMetaTypedElementSuperConstructors(MetaTypedElementBuilder _this)
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
	
	
		/// <summary>
		/// Implements the constructor: MetaAnnotation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		public virtual void MetaAnnotation(MetaAnnotationBuilder _this)
		{
			this.CallMetaAnnotationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaAnnotation
		/// </summary>
		protected virtual void CallMetaAnnotationSuperConstructors(MetaAnnotationBuilder _this)
		{
			this.MetaDocumentedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaNamespace()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		///     <li>MetaAnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
		///     <li>MetaNamedElement</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaDeclaration()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		///     <li>MetaAnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaModel()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		///     <li>MetaAnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
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
		///     <li>MetaType</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaEnum()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaType</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
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
			this.MetaDocumentedElement(_this);
			this.MetaTypedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaConstant()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaTypedElement</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaTypedElement</li>
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
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaTypedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaClass()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaType</li>
		///     <li>MetaDeclaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaDeclaration</li>
		///     <li>MetaType</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaDeclaration(_this);
			this.MetaType(_this);
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperClasses()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperProperties()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<MetaProperty> MetaClass_GetAllSuperProperties(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperOperations()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<MetaOperation> MetaClass_GetAllSuperOperations(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllProperties()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<MetaProperty> MetaClass_GetAllProperties(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllOperations()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<MetaOperation> MetaClass_GetAllOperations(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllFinalProperties()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<MetaProperty> MetaClass_GetAllFinalProperties(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllFinalOperations()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<MetaOperation> MetaClass_GetAllFinalOperations(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaFunctionType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaType</li>
		/// </ul>
		public virtual void MetaFunctionType(MetaFunctionTypeBuilder _this)
		{
			this.CallMetaFunctionTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaFunctionType
		/// </summary>
		protected virtual void CallMetaFunctionTypeSuperConstructors(MetaFunctionTypeBuilder _this)
		{
			this.MetaType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaFunction()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaTypedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaAnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaTypedElement</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>Type</li>
		/// </ul>
		public virtual void MetaFunction(MetaFunctionBuilder _this)
		{
			this.CallMetaFunctionSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaFunction
		/// </summary>
		protected virtual void CallMetaFunctionSuperConstructors(MetaFunctionBuilder _this)
		{
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaTypedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaOperation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaFunction</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
		///     <li>MetaNamedElement</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaFunction</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
			this.MetaTypedElement(_this);
			this.MetaFunction(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaConstructor()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		///     <li>MetaAnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
		///     <li>MetaNamedElement</li>
		/// </ul>
		public virtual void MetaConstructor(MetaConstructorBuilder _this)
		{
			this.CallMetaConstructorSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MetaConstructor
		/// </summary>
		protected virtual void CallMetaConstructorSuperConstructors(MetaConstructorBuilder _this)
		{
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
			this.MetaNamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MetaParameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>MetaNamedElement</li>
		///     <li>MetaTypedElement</li>
		///     <li>MetaAnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
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
		///     <li>MetaAnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaAnnotatedElement</li>
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
			this.MetaDocumentedElement(_this);
			this.MetaAnnotatedElement(_this);
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


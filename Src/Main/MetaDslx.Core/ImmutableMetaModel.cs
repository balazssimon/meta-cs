using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetaDslx.Core.Immutable
{
	using global::MetaDslx.Core.Immutable.Internal;

	public class MetaInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return MetaInstance.initialized; }
		}
	
		public static readonly MetaModel _MetaModel;
		public static readonly global::MetaDslx.Core.Immutable.ImmutableModel Model;
	
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
	
		public static readonly MetaClass RootScope;
		public static readonly MetaProperty RootScope_BuiltInEntries;
		public static readonly MetaProperty RootScope_Entries;
		/**
		 * <summary>
		 * Represents an annotated element.
		 * </summary>
		 */
		public static readonly MetaClass MetaAnnotatedElement;
		/**
		 * <summary>
		 * List of annotations
		 * </summary>
		 */
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
			_MetaModel = MetaBuilderInstance.instance._MetaModel.ToImmutable();
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
	
			RootScope = MetaBuilderInstance.instance.RootScope.ToImmutable(Model);
			RootScope_BuiltInEntries = MetaBuilderInstance.instance.RootScope_BuiltInEntries.ToImmutable(Model);
			RootScope_Entries = MetaBuilderInstance.instance.RootScope_Entries.ToImmutable(Model);
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
	public class MetaFactory : global::MetaDslx.Core.Immutable.ModelFactory
	{
		public MetaFactory(global::MetaDslx.Core.Immutable.MutableModel model, global::MetaDslx.Core.Immutable.ModelFactoryFlags flags = global::MetaDslx.Core.Immutable.ModelFactoryFlags.None)
			: base(model, flags)
		{
			MetaDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase Create(string type)
		{
			switch (type)
			{
				case "RootScope": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.RootScope();
				case "MetaAnnotation": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaAnnotation();
				case "MetaNamespace": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaNamespace();
				case "MetaModel": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaModel();
				case "MetaCollectionType": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaCollectionType();
				case "MetaNullableType": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaNullableType();
				case "MetaPrimitiveType": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaPrimitiveType();
				case "MetaEnum": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaEnum();
				case "MetaEnumLiteral": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaEnumLiteral();
				case "MetaConstant": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaConstant();
				case "MetaClass": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaClass();
				case "MetaFunctionType": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaFunctionType();
				case "MetaOperation": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaOperation();
				case "MetaConstructor": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaConstructor();
				case "MetaParameter": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaParameter();
				case "MetaProperty": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaProperty();
				default:
					throw new global::MetaDslx.Core.Immutable.ModelException("Unknown type name: " + type);
			}
		}
	
		/// <summary>
		/// Creates a new instance of RootScope.
		/// </summary>
		public RootScopeBuilder RootScope()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new RootScopeId());
			return (RootScopeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaAnnotation.
		/// </summary>
		public MetaAnnotationBuilder MetaAnnotation()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaAnnotationId());
			return (MetaAnnotationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNamespace.
		/// </summary>
		public MetaNamespaceBuilder MetaNamespace()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaNamespaceId());
			return (MetaNamespaceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaModel.
		/// </summary>
		public MetaModelBuilder MetaModel()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaModelId());
			return (MetaModelBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaCollectionType.
		/// </summary>
		public MetaCollectionTypeBuilder MetaCollectionType()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaCollectionTypeId());
			return (MetaCollectionTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaNullableType.
		/// </summary>
		public MetaNullableTypeBuilder MetaNullableType()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaNullableTypeId());
			return (MetaNullableTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaPrimitiveType.
		/// </summary>
		public MetaPrimitiveTypeBuilder MetaPrimitiveType()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaPrimitiveTypeId());
			return (MetaPrimitiveTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaEnum.
		/// </summary>
		public MetaEnumBuilder MetaEnum()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaEnumId());
			return (MetaEnumBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaEnumLiteral.
		/// </summary>
		public MetaEnumLiteralBuilder MetaEnumLiteral()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaEnumLiteralId());
			return (MetaEnumLiteralBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaConstant.
		/// </summary>
		public MetaConstantBuilder MetaConstant()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaConstantId());
			return (MetaConstantBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaClass.
		/// </summary>
		public MetaClassBuilder MetaClass()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaClassId());
			return (MetaClassBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaFunctionType.
		/// </summary>
		public MetaFunctionTypeBuilder MetaFunctionType()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaFunctionTypeId());
			return (MetaFunctionTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaOperation.
		/// </summary>
		public MetaOperationBuilder MetaOperation()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaOperationId());
			return (MetaOperationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaConstructor.
		/// </summary>
		public MetaConstructorBuilder MetaConstructor()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaConstructorId());
			return (MetaConstructorBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaParameter.
		/// </summary>
		public MetaParameterBuilder MetaParameter()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaParameterId());
			return (MetaParameterBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MetaProperty.
		/// </summary>
		public MetaPropertyBuilder MetaProperty()
		{
			global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaPropertyId());
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
	
	[Scope]
	public interface RootScope : global::MetaDslx.Core.Immutable.ImmutableSymbol
	{
		global::MetaDslx.Core.Immutable.ImmutableModelList<object> BuiltInEntries { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<object> Entries { get; }
	
	
		new RootScopeBuilder ToMutable();
		new RootScopeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	[Scope]
	public interface RootScopeBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
	{
		global::MetaDslx.Core.Immutable.MutableModelList<object> BuiltInEntries { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<object> Entries { get; }
	
		new RootScope ToImmutable();
		new RootScope ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	/**
	 * <summary>
	 * Represents an annotated element.
	 * </summary>
	 */
	public interface MetaAnnotatedElement : global::MetaDslx.Core.Immutable.ImmutableSymbol
	{
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations { get; }
	
	
		new MetaAnnotatedElementBuilder ToMutable();
		new MetaAnnotatedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	/**
	 * <summary>
	 * Represents an annotated element.
	 * </summary>
	 */
	public interface MetaAnnotatedElementBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
	{
		global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations { get; }
	
		new MetaAnnotatedElement ToImmutable();
		new MetaAnnotatedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaDocumentedElement : global::MetaDslx.Core.Immutable.ImmutableSymbol
	{
		string Documentation { get; }
	
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> GetDocumentationLines();
	
		new MetaDocumentedElementBuilder ToMutable();
		new MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaDocumentedElementBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
	{
		string Documentation { get; set; }
		Func<string> DocumentationLazy { get; set; }
	
		new MetaDocumentedElement ToImmutable();
		new MetaDocumentedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaNamedElement : MetaDocumentedElement
	{
		string Name { get; }
	
	
		new MetaNamedElementBuilder ToMutable();
		new MetaNamedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaNamedElementBuilder : MetaDocumentedElementBuilder
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
	
		new MetaNamedElement ToImmutable();
		new MetaNamedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaTypedElement : global::MetaDslx.Core.Immutable.ImmutableSymbol
	{
		MetaType Type { get; }
	
	
		new MetaTypedElementBuilder ToMutable();
		new MetaTypedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaTypedElementBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
	{
		MetaTypeBuilder Type { get; set; }
		Func<MetaTypeBuilder> TypeLazy { get; set; }
	
		new MetaTypedElement ToImmutable();
		new MetaTypedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	[Type]
	public interface MetaType : global::MetaDslx.Core.Immutable.ImmutableSymbol
	{
	
	
		new MetaTypeBuilder ToMutable();
		new MetaTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	[Type]
	public interface MetaTypeBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
	{
	
		new MetaType ToImmutable();
		new MetaType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaAnnotation : MetaNamedElement
	{
	
	
		new MetaAnnotationBuilder ToMutable();
		new MetaAnnotationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaAnnotationBuilder : MetaNamedElementBuilder
	{
	
		new MetaAnnotation ToImmutable();
		new MetaAnnotation ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	[Scope]
	public interface MetaNamespace : MetaNamedElement, MetaAnnotatedElement
	{
		MetaNamespace Parent { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaNamespace> Usings { get; }
		MetaModel MetaModel { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaNamespace> Namespaces { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaDeclaration> Declarations { get; }
	
	
		new MetaNamespaceBuilder ToMutable();
		new MetaNamespaceBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	[Scope]
	public interface MetaNamespaceBuilder : MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaNamespaceBuilder Parent { get; set; }
		Func<MetaNamespaceBuilder> ParentLazy { get; set; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaNamespaceBuilder> Usings { get; }
		MetaModelBuilder MetaModel { get; set; }
		Func<MetaModelBuilder> MetaModelLazy { get; set; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaNamespaceBuilder> Namespaces { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaDeclarationBuilder> Declarations { get; }
	
		new MetaNamespace ToImmutable();
		new MetaNamespace ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaDeclaration : MetaNamedElement, MetaAnnotatedElement
	{
		MetaNamespace Namespace { get; }
		MetaModel MetaModel { get; }
	
	
		new MetaDeclarationBuilder ToMutable();
		new MetaDeclarationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaDeclarationBuilder : MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaNamespaceBuilder Namespace { get; set; }
		Func<MetaNamespaceBuilder> NamespaceLazy { get; set; }
		MetaModelBuilder MetaModel { get; }
		Func<MetaModelBuilder> MetaModelLazy { get; set; }
	
		new MetaDeclaration ToImmutable();
		new MetaDeclaration ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaModel : MetaNamedElement, MetaAnnotatedElement
	{
		string Uri { get; }
		MetaNamespace Namespace { get; }
	
	
		new MetaModelBuilder ToMutable();
		new MetaModelBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaModelBuilder : MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		string Uri { get; set; }
		Func<string> UriLazy { get; set; }
		MetaNamespaceBuilder Namespace { get; set; }
		Func<MetaNamespaceBuilder> NamespaceLazy { get; set; }
	
		new MetaModel ToImmutable();
		new MetaModel ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaCollectionType : MetaType
	{
		MetaCollectionKind Kind { get; }
		MetaType InnerType { get; }
	
	
		new MetaCollectionTypeBuilder ToMutable();
		new MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaCollectionTypeBuilder : MetaTypeBuilder
	{
		MetaCollectionKind Kind { get; set; }
		Func<MetaCollectionKind> KindLazy { get; set; }
		MetaTypeBuilder InnerType { get; set; }
		Func<MetaTypeBuilder> InnerTypeLazy { get; set; }
	
		new MetaCollectionType ToImmutable();
		new MetaCollectionType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaNullableType : MetaType
	{
		MetaType InnerType { get; }
	
	
		new MetaNullableTypeBuilder ToMutable();
		new MetaNullableTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaNullableTypeBuilder : MetaTypeBuilder
	{
		MetaTypeBuilder InnerType { get; set; }
		Func<MetaTypeBuilder> InnerTypeLazy { get; set; }
	
		new MetaNullableType ToImmutable();
		new MetaNullableType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaPrimitiveType : MetaType, MetaNamedElement
	{
	
	
		new MetaPrimitiveTypeBuilder ToMutable();
		new MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaPrimitiveTypeBuilder : MetaTypeBuilder, MetaNamedElementBuilder
	{
	
		new MetaPrimitiveType ToImmutable();
		new MetaPrimitiveType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	[Scope]
	public interface MetaEnum : MetaType, MetaDeclaration
	{
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaEnumLiteral> EnumLiterals { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> Operations { get; }
	
	
		new MetaEnumBuilder ToMutable();
		new MetaEnumBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	[Scope]
	public interface MetaEnumBuilder : MetaTypeBuilder, MetaDeclarationBuilder
	{
		global::MetaDslx.Core.Immutable.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaOperationBuilder> Operations { get; }
	
		new MetaEnum ToImmutable();
		new MetaEnum ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaEnumLiteral : MetaNamedElement, MetaTypedElement
	{
		MetaEnum Enum { get; }
	
	
		new MetaEnumLiteralBuilder ToMutable();
		new MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaEnumLiteralBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder
	{
		MetaEnumBuilder Enum { get; set; }
		Func<MetaEnumBuilder> EnumLazy { get; set; }
	
		new MetaEnumLiteral ToImmutable();
		new MetaEnumLiteral ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaConstant : MetaTypedElement, MetaDeclaration
	{
	
	
		new MetaConstantBuilder ToMutable();
		new MetaConstantBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaConstantBuilder : MetaTypedElementBuilder, MetaDeclarationBuilder
	{
	
		new MetaConstant ToImmutable();
		new MetaConstant ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	[Scope]
	public interface MetaClass : MetaType, MetaDeclaration
	{
		bool IsAbstract { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaClass> SuperClasses { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> Properties { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> Operations { get; }
		MetaConstructor Constructor { get; }
	
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaClass> GetAllSuperClasses(bool includeSelf);
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> GetAllSuperProperties(bool includeSelf);
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> GetAllSuperOperations(bool includeSelf);
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> GetAllProperties();
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> GetAllOperations();
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> GetAllFinalProperties();
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> GetAllFinalOperations();
	
		new MetaClassBuilder ToMutable();
		new MetaClassBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	[Scope]
	public interface MetaClassBuilder : MetaTypeBuilder, MetaDeclarationBuilder
	{
		bool IsAbstract { get; set; }
		Func<bool> IsAbstractLazy { get; set; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaClassBuilder> SuperClasses { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> Properties { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaOperationBuilder> Operations { get; }
		MetaConstructorBuilder Constructor { get; set; }
		Func<MetaConstructorBuilder> ConstructorLazy { get; set; }
	
		new MetaClass ToImmutable();
		new MetaClass ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaFunctionType : MetaType
	{
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaType> ParameterTypes { get; }
		MetaType ReturnType { get; }
	
	
		new MetaFunctionTypeBuilder ToMutable();
		new MetaFunctionTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaFunctionTypeBuilder : MetaTypeBuilder
	{
		global::MetaDslx.Core.Immutable.MutableModelList<MetaTypeBuilder> ParameterTypes { get; }
		MetaTypeBuilder ReturnType { get; set; }
		Func<MetaTypeBuilder> ReturnTypeLazy { get; set; }
	
		new MetaFunctionType ToImmutable();
		new MetaFunctionType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaFunction : MetaTypedElement, MetaNamedElement, MetaAnnotatedElement
	{
		new MetaFunctionType Type { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaParameter> Parameters { get; }
		MetaType ReturnType { get; }
	
	
		new MetaFunctionBuilder ToMutable();
		new MetaFunctionBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaFunctionBuilder : MetaTypedElementBuilder, MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		new MetaFunctionTypeBuilder Type { get; }
		new Func<MetaFunctionTypeBuilder> TypeLazy { get; set; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaParameterBuilder> Parameters { get; }
		MetaTypeBuilder ReturnType { get; set; }
		Func<MetaTypeBuilder> ReturnTypeLazy { get; set; }
	
		new MetaFunction ToImmutable();
		new MetaFunction ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaOperation : MetaFunction
	{
		MetaType Parent { get; }
	
	
		new MetaOperationBuilder ToMutable();
		new MetaOperationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaOperationBuilder : MetaFunctionBuilder
	{
		MetaTypeBuilder Parent { get; set; }
		Func<MetaTypeBuilder> ParentLazy { get; set; }
	
		new MetaOperation ToImmutable();
		new MetaOperation ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaConstructor : MetaNamedElement, MetaAnnotatedElement
	{
		MetaClass Parent { get; }
	
	
		new MetaConstructorBuilder ToMutable();
		new MetaConstructorBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaConstructorBuilder : MetaNamedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaClassBuilder Parent { get; set; }
		Func<MetaClassBuilder> ParentLazy { get; set; }
	
		new MetaConstructor ToImmutable();
		new MetaConstructor ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaParameter : MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
	{
		MetaFunction Function { get; }
	
	
		new MetaParameterBuilder ToMutable();
		new MetaParameterBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaParameterBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaFunctionBuilder Function { get; set; }
		Func<MetaFunctionBuilder> FunctionLazy { get; set; }
	
		new MetaParameter ToImmutable();
		new MetaParameter ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}
	
	public interface MetaProperty : MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
	{
		MetaPropertyKind Kind { get; }
		MetaClass Class { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> OppositeProperties { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> SubsettedProperties { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> SubsettingProperties { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> RedefinedProperties { get; }
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> RedefiningProperties { get; }
	
	
		new MetaPropertyBuilder ToMutable();
		new MetaPropertyBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
	}
	
	public interface MetaPropertyBuilder : MetaNamedElementBuilder, MetaTypedElementBuilder, MetaAnnotatedElementBuilder
	{
		MetaPropertyKind Kind { get; set; }
		Func<MetaPropertyKind> KindLazy { get; set; }
		MetaClassBuilder Class { get; set; }
		Func<MetaClassBuilder> ClassLazy { get; set; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> OppositeProperties { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> SubsettedProperties { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> SubsettingProperties { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> RedefinedProperties { get; }
		global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> RedefiningProperties { get; }
	
		new MetaProperty ToImmutable();
		new MetaProperty ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
	}

	public static class MetaDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties;
	
		static MetaDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();
			properties.Add(MetaDescriptor.RootScope.BuiltInEntriesProperty);
			properties.Add(MetaDescriptor.RootScope.EntriesProperty);
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
	
		[Scope]
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute]
		public static class RootScope
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static RootScope()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(RootScope));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.RootScope; }
			}
			
			[ScopeEntry]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty BuiltInEntriesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(RootScope), "BuiltInEntries",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(object), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<object>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(object), typeof(global::MetaDslx.Core.Immutable.MutableModelList<object>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.RootScope_BuiltInEntries);
			
			[ScopeEntry]
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty EntriesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(RootScope), "Entries",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(object), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<object>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(object), typeof(global::MetaDslx.Core.Immutable.MutableModelList<object>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.RootScope_Entries);
		}
	
		/**
		 * <summary>
		 * Represents an annotated element.
		 * </summary>
		 */
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute]
		public static class MetaAnnotatedElement
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaAnnotatedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaAnnotatedElement));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaAnnotatedElement; }
			}
			
			/**
			 * <summary>
			 * List of annotations
			 * </summary>
			 */
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty AnnotationsProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaAnnotatedElement), "Annotations",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaAnnotation), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaAnnotationBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaAnnotatedElement_Annotations);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute]
		public static class MetaDocumentedElement
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaDocumentedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaDocumentedElement));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaDocumentedElement; }
			}
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty DocumentationProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDocumentedElement), "Documentation",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaDocumentedElement_Documentation);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaDocumentedElement))]
		public static class MetaNamedElement
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNamedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaNamedElement));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaNamedElement; }
			}
			
			[Name]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty NameProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaNamedElement), "Name",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaNamedElement_Name);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute]
		public static class MetaTypedElement
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaTypedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaTypedElement));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaTypedElement; }
			}
			
			[Type]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty TypeProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaTypedElement), "Type",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaTypedElement_Type);
		}
	
		[Type]
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute]
		public static class MetaType
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaType()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaType));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaType; }
			}
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaNamedElement))]
		public static class MetaAnnotation
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaAnnotation()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaAnnotation));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaAnnotation; }
			}
		}
	
		[Scope]
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement))]
		public static class MetaNamespace
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNamespace()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaNamespace));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaNamespace; }
			}
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "Namespaces")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParentProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaNamespace), "Parent",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaNamespace_Parent);
			
			[ImportedScope]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty UsingsProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaNamespace), "Usings",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaNamespace_Usings);
			
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaModel), "Namespace")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty MetaModelProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaNamespace), "MetaModel",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaModel), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaModelBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaNamespace_MetaModel);
			
			[ScopeEntry]
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "Parent")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty NamespacesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaNamespace), "Namespaces",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaNamespace_Namespaces);
			
			[ScopeEntry]
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaDeclaration), "Namespace")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaNamespace), "Declarations",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaDeclaration), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaDeclaration>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaDeclarationBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaDeclarationBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaNamespace_Declarations);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement))]
		public static class MetaDeclaration
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaDeclaration()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaDeclaration));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaDeclaration; }
			}
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "Declarations")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty NamespaceProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDeclaration), "Namespace",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaDeclaration_Namespace);
			
			[global::MetaDslx.Core.Immutable.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty MetaModelProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDeclaration), "MetaModel",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaModel), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaModelBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaDeclaration_MetaModel);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement))]
		public static class MetaModel
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaModel()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaModel));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaModel; }
			}
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty UriProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaModel), "Uri",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaModel_Uri);
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaNamespace), "MetaModel")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty NamespaceProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaModel), "Namespace",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaModel_Namespace);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaType))]
		public static class MetaCollectionType
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaCollectionType()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaCollectionType));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaCollectionType; }
			}
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty KindProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaCollectionType), "Kind",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaCollectionKind), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaCollectionKind), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaCollectionType_Kind);
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaCollectionType), "InnerType",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaCollectionType_InnerType);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaType))]
		public static class MetaNullableType
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaNullableType()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaNullableType));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaNullableType; }
			}
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaNullableType), "InnerType",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaNullableType_InnerType);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaNamedElement))]
		public static class MetaPrimitiveType
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaPrimitiveType()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaPrimitiveType));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaPrimitiveType; }
			}
		}
	
		[Scope]
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaDeclaration))]
		public static class MetaEnum
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaEnum()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaEnum));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaEnum; }
			}
			
			[ScopeEntry]
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaEnumLiteral), "Enum")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty EnumLiteralsProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaEnum), "EnumLiterals",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaEnumLiteral), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteral>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaEnum_EnumLiterals);
			
			[ScopeEntry]
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parent")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty OperationsProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaEnum), "Operations",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaOperation), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaOperationBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaEnum_Operations);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement))]
		public static class MetaEnumLiteral
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaEnumLiteral()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaEnumLiteral));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaEnumLiteral; }
			}
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "EnumLiterals")]
			[global::MetaDslx.Core.Immutable.RedefinesAttribute(typeof(MetaDescriptor.MetaTypedElement), "Type")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty EnumProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaEnumLiteral), "Enum",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaEnum), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaEnumBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaEnumLiteral_Enum);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaDeclaration))]
		public static class MetaConstant
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaConstant()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaConstant));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaConstant; }
			}
		}
	
		[Scope]
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaType), typeof(MetaDescriptor.MetaDeclaration))]
		public static class MetaClass
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaClass()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaClass));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaClass; }
			}
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaClass), "IsAbstract",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaClass_IsAbstract);
			
			[InheritedScope]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty SuperClassesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaClass), "SuperClasses",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClass), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaClass>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClassBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaClassBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaClass_SuperClasses);
			
			[ScopeEntry]
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "Class")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty PropertiesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaClass), "Properties",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaClass_Properties);
			
			[ScopeEntry]
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaOperation), "Parent")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty OperationsProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaClass), "Operations",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaOperation), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaOperationBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaClass_Operations);
			
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaConstructor), "Parent")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ConstructorProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaClass), "Constructor",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaConstructor), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaConstructorBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaClass_Constructor);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaType))]
		public static class MetaFunctionType
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaFunctionType()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaFunctionType));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaFunctionType; }
			}
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParameterTypesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaFunctionType), "ParameterTypes",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaType>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaTypeBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaFunctionType_ParameterTypes);
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaFunctionType), "ReturnType",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaFunctionType_ReturnType);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement))]
		public static class MetaFunction
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaFunction()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaFunction));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaFunction; }
			}
			
			[Type]
			[global::MetaDslx.Core.Immutable.ReadonlyAttribute]
			[global::MetaDslx.Core.Immutable.RedefinesAttribute(typeof(MetaDescriptor.MetaTypedElement), "Type")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty TypeProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaFunction), "Type",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaFunctionType), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaFunction_Type);
			
			[global::MetaDslx.Core.Immutable.ContainmentAttribute]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaParameter), "Function")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParametersProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaFunction), "Parameters",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaParameter), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaParameter>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaParameterBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaParameterBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaFunction_Parameters);
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaFunction), "ReturnType",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaFunction_ReturnType);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaFunction))]
		public static class MetaOperation
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaOperation()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaOperation));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaOperation; }
			}
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Operations")]
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaEnum), "Operations")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParentProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaOperation), "Parent",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaOperation_Parent);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaAnnotatedElement))]
		public static class MetaConstructor
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaConstructor()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaConstructor));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaConstructor; }
			}
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Constructor")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParentProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaConstructor), "Parent",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClass), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClassBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaConstructor_Parent);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaAnnotatedElement))]
		public static class MetaParameter
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaParameter()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaParameter));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaParameter; }
			}
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaFunction), "Parameters")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty FunctionProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaParameter), "Function",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaFunction), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaFunctionBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaParameter_Function);
		}
	
		[global::MetaDslx.Core.Immutable.ModelSymbolDescriptorAttribute(typeof(MetaDescriptor.MetaNamedElement), typeof(MetaDescriptor.MetaTypedElement), typeof(MetaDescriptor.MetaAnnotatedElement))]
		public static class MetaProperty
		{
			private static global::MetaDslx.Core.Immutable.ModelSymbolInfo modelSymbolInfo;
		
			static MetaProperty()
			{
				modelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaProperty));
			}
		
			public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
			{
				get { return global::MetaDslx.Core.Immutable.MetaInstance.MetaProperty; }
			}
			
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty KindProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaProperty), "Kind",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyKind), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyKind), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaProperty_Kind);
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaClass), "Properties")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty ClassProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaProperty), "Class",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClass), null),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClassBuilder), null),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaProperty_Class);
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "OppositeProperties")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty OppositePropertiesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaProperty), "OppositeProperties",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaProperty_OppositeProperties);
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "SubsettingProperties")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty SubsettedPropertiesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaProperty), "SubsettedProperties",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaProperty_SubsettedProperties);
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "SubsettedProperties")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty SubsettingPropertiesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaProperty), "SubsettingProperties",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaProperty_SubsettingProperties);
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "RedefiningProperties")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty RedefinedPropertiesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaProperty), "RedefinedProperties",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaProperty_RedefinedProperties);
			
			[global::MetaDslx.Core.Immutable.OppositeAttribute(typeof(MetaDescriptor.MetaProperty), "RedefinedProperties")]
			public static readonly global::MetaDslx.Core.Immutable.ModelProperty RedefiningPropertiesProperty =
			    global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaProperty), "RedefiningProperties",
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
			        new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)),
					() => global::MetaDslx.Core.Immutable.MetaInstance.MetaProperty_RedefiningProperties);
		}
	}
}

namespace MetaDslx.Core.Immutable.Internal
{
	
	internal class RootScopeId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.RootScope.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(RootScope); } }
		public override global::System.Type MutableType { get { return typeof(RootScopeBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new RootScopeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new RootScopeBuilderImpl(this, model, creating);
		}
	}
	
	internal class RootScopeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, RootScope
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<object> builtInEntries0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<object> entries0;
	
		internal RootScopeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.RootScope; }
		}
	
		public new RootScopeBuilder ToMutable()
		{
			return (RootScopeBuilder)base.ToMutable();
		}
	
		public new RootScopeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (RootScopeBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<object> BuiltInEntries
		{
		    get { return this.GetList<object>(global::MetaDslx.Core.Immutable.MetaDescriptor.RootScope.BuiltInEntriesProperty, ref builtInEntries0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<object> Entries
		{
		    get { return this.GetList<object>(global::MetaDslx.Core.Immutable.MetaDescriptor.RootScope.EntriesProperty, ref entries0); }
		}
	}
	
	internal class RootScopeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, RootScopeBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<object> builtInEntries0;
		private global::MetaDslx.Core.Immutable.MutableModelList<object> entries0;
	
		internal RootScopeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.RootScope(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.RootScope; }
		}
	
		public new RootScope ToImmutable()
		{
			return (RootScope)base.ToImmutable();
		}
	
		public new RootScope ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (RootScope)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<object> BuiltInEntries
		{
			get { return this.GetList<object>(global::MetaDslx.Core.Immutable.MetaDescriptor.RootScope.BuiltInEntriesProperty, ref builtInEntries0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<object> Entries
		{
			get { return this.GetList<object>(global::MetaDslx.Core.Immutable.MetaDescriptor.RootScope.EntriesProperty, ref entries0); }
		}
	}
	
	internal class MetaAnnotatedElementId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaAnnotatedElement); } }
		public override global::System.Type MutableType { get { return typeof(MetaAnnotatedElementBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaAnnotatedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaAnnotatedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaAnnotatedElementImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaAnnotatedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
	
		internal MetaAnnotatedElementImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAnnotatedElement; }
		}
	
		public new MetaAnnotatedElementBuilder ToMutable()
		{
			return (MetaAnnotatedElementBuilder)base.ToMutable();
		}
	
		public new MetaAnnotatedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaAnnotatedElementBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class MetaAnnotatedElementBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaAnnotatedElementBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaAnnotatedElementBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAnnotatedElement; }
		}
	
		public new MetaAnnotatedElement ToImmutable()
		{
			return (MetaAnnotatedElement)base.ToImmutable();
		}
	
		public new MetaAnnotatedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaAnnotatedElement)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class MetaDocumentedElementId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaDocumentedElement); } }
		public override global::System.Type MutableType { get { return typeof(MetaDocumentedElementBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaDocumentedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaDocumentedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaDocumentedElementImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaDocumentedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
	
		internal MetaDocumentedElementImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaDocumentedElement; }
		}
	
		public new MetaDocumentedElementBuilder ToMutable()
		{
			return (MetaDocumentedElementBuilder)base.ToMutable();
		}
	
		public new MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaDocumentedElementBuilder)base.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaDocumentedElementBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaDocumentedElementBuilder
	{
	
		internal MetaDocumentedElementBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaDocumentedElement; }
		}
	
		public new MetaDocumentedElement ToImmutable()
		{
			return (MetaDocumentedElement)base.ToImmutable();
		}
	
		public new MetaDocumentedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaDocumentedElement)base.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	}
	
	internal class MetaNamedElementId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaNamedElement); } }
		public override global::System.Type MutableType { get { return typeof(MetaNamedElementBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaNamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaNamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamedElementImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaNamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal MetaNamedElementImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamedElement; }
		}
	
		public new MetaNamedElementBuilder ToMutable()
		{
			return (MetaNamedElementBuilder)base.ToMutable();
		}
	
		public new MetaNamedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaNamedElementBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaNamedElementBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaNamedElementBuilder
	{
	
		internal MetaNamedElementBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNamedElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamedElement; }
		}
	
		public new MetaNamedElement ToImmutable()
		{
			return (MetaNamedElement)base.ToImmutable();
		}
	
		public new MetaNamedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaNamedElement)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	}
	
	internal class MetaTypedElementId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaTypedElement); } }
		public override global::System.Type MutableType { get { return typeof(MetaTypedElementBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaTypedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaTypedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaTypedElementImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaTypedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
	
		internal MetaTypedElementImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaTypedElement; }
		}
	
		public new MetaTypedElementBuilder ToMutable()
		{
			return (MetaTypedElementBuilder)base.ToMutable();
		}
	
		public new MetaTypedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaTypedElementBuilder)base.ToMutable(model);
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	}
	
	internal class MetaTypedElementBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaTypedElementBuilder
	{
	
		internal MetaTypedElementBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaTypedElement(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaTypedElement; }
		}
	
		public new MetaTypedElement ToImmutable()
		{
			return (MetaTypedElement)base.ToImmutable();
		}
	
		public new MetaTypedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaTypedElement)base.ToImmutable(model);
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	}
	
	internal class MetaTypeId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaType); } }
		public override global::System.Type MutableType { get { return typeof(MetaTypeBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaType
	{
	
		internal MetaTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaType; }
		}
	
		public new MetaTypeBuilder ToMutable()
		{
			return (MetaTypeBuilder)base.ToMutable();
		}
	
		public new MetaTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaTypeBuilder)base.ToMutable(model);
		}
	}
	
	internal class MetaTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaTypeBuilder
	{
	
		internal MetaTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaType; }
		}
	
		public new MetaType ToImmutable()
		{
			return (MetaType)base.ToImmutable();
		}
	
		public new MetaType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaType)base.ToImmutable(model);
		}
	}
	
	internal class MetaAnnotationId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotation.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaAnnotation); } }
		public override global::System.Type MutableType { get { return typeof(MetaAnnotationBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaAnnotationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaAnnotationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaAnnotationImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaAnnotation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal MetaAnnotationImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAnnotation; }
		}
	
		public new MetaAnnotationBuilder ToMutable()
		{
			return (MetaAnnotationBuilder)base.ToMutable();
		}
	
		public new MetaAnnotationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaAnnotationBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaAnnotationBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaAnnotationBuilder
	{
	
		internal MetaAnnotationBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaAnnotation(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaAnnotation; }
		}
	
		public new MetaAnnotation ToImmutable()
		{
			return (MetaAnnotation)base.ToImmutable();
		}
	
		public new MetaAnnotation ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaAnnotation)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	}
	
	internal class MetaNamespaceId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaNamespace); } }
		public override global::System.Type MutableType { get { return typeof(MetaNamespaceBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaNamespaceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaNamespaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNamespaceImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaNamespace
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace parent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaNamespace> usings0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaNamespace> namespaces0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaDeclaration> declarations0;
	
		internal MetaNamespaceImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamespace; }
		}
	
		public new MetaNamespaceBuilder ToMutable()
		{
			return (MetaNamespaceBuilder)base.ToMutable();
		}
	
		public new MetaNamespaceBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaNamespaceBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Parent
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty, ref parent0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaNamespace> Usings
		{
		    get { return this.GetList<MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.UsingsProperty, ref usings0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty, ref metaModel0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaNamespace> Namespaces
		{
		    get { return this.GetList<MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.NamespacesProperty, ref namespaces0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaDeclaration> Declarations
		{
		    get { return this.GetList<MetaDeclaration>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaNamespaceBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaNamespaceBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaNamespaceBuilder> usings0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaNamespaceBuilder> namespaces0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaDeclarationBuilder> declarations0;
	
		internal MetaNamespaceBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNamespace(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNamespace; }
		}
	
		public new MetaNamespace ToImmutable()
		{
			return (MetaNamespace)base.ToImmutable();
		}
	
		public new MetaNamespace ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaNamespace)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Parent
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> ParentLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamespace.ParentProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaNamespaceBuilder> Usings
		{
			get { return this.GetList<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.UsingsProperty, ref usings0); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty); }
			set { this.SetReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty, value); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamespace.MetaModelProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaNamespaceBuilder> Namespaces
		{
			get { return this.GetList<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.NamespacesProperty, ref namespaces0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaDeclarationBuilder> Declarations
		{
			get { return this.GetList<MetaDeclarationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class MetaDeclarationId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaDeclaration); } }
		public override global::System.Type MutableType { get { return typeof(MetaDeclarationBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaDeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaDeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaDeclarationImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaDeclaration
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
	
		internal MetaDeclarationImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaDeclaration; }
		}
	
		public new MetaDeclarationBuilder ToMutable()
		{
			return (MetaDeclarationBuilder)base.ToMutable();
		}
	
		public new MetaDeclarationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaDeclarationBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaDeclarationBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaDeclarationBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaDeclarationBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaDeclaration(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaDeclaration; }
		}
	
		public new MetaDeclaration ToImmutable()
		{
			return (MetaDeclaration)base.ToImmutable();
		}
	
		public new MetaDeclaration ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaDeclaration)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	}
	
	internal class MetaModelId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaModel); } }
		public override global::System.Type MutableType { get { return typeof(MetaModelBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaModelImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaModelBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaModelImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaModel
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string uri0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
	
		internal MetaModelImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaModel; }
		}
	
		public new MetaModelBuilder ToMutable()
		{
			return (MetaModelBuilder)base.ToMutable();
		}
	
		public new MetaModelBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaModelBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public string Uri
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty, ref uri0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty, ref namespace0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaModelBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaModelBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaModelBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaModel(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaModel; }
		}
	
		public new MetaModel ToImmutable()
		{
			return (MetaModel)base.ToImmutable();
		}
	
		public new MetaModel ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaModel)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public string Uri
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty, value); }
		}
		
		public Func<string> UriLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaModel.UriProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaModel.NamespaceProperty, value); }
		}
	}
	
	internal class MetaCollectionTypeId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaCollectionType); } }
		public override global::System.Type MutableType { get { return typeof(MetaCollectionTypeBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaCollectionTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaCollectionTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaCollectionTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaCollectionType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaCollectionKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType innerType0;
	
		internal MetaCollectionTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaCollectionType; }
		}
	
		public new MetaCollectionTypeBuilder ToMutable()
		{
			return (MetaCollectionTypeBuilder)base.ToMutable();
		}
	
		public new MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaCollectionTypeBuilder)base.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public MetaCollectionKind Kind
		{
		    get { return this.GetValue<MetaCollectionKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty, ref kind0); }
		}
	
		
		public MetaType InnerType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class MetaCollectionTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaCollectionTypeBuilder
	{
	
		internal MetaCollectionTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaCollectionType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaCollectionType; }
		}
	
		public new MetaCollectionType ToImmutable()
		{
			return (MetaCollectionType)base.ToImmutable();
		}
	
		public new MetaCollectionType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaCollectionType)base.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public MetaCollectionKind Kind
		{
			get { return this.GetValue<MetaCollectionKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty); }
			set { this.SetValue<MetaCollectionKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty, value); }
		}
		
		public Func<MetaCollectionKind> KindLazy
		{
			get { return this.GetLazyValue<MetaCollectionKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty); }
			set { this.SetLazyValue(MetaDescriptor.MetaCollectionType.KindProperty, value); }
		}
	
		
		public MetaTypeBuilder InnerType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaCollectionType.InnerTypeProperty, value); }
		}
	}
	
	internal class MetaNullableTypeId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaNullableType); } }
		public override global::System.Type MutableType { get { return typeof(MetaNullableTypeBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaNullableTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaNullableTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaNullableTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaNullableType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType innerType0;
	
		internal MetaNullableTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNullableType; }
		}
	
		public new MetaNullableTypeBuilder ToMutable()
		{
			return (MetaNullableTypeBuilder)base.ToMutable();
		}
	
		public new MetaNullableTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaNullableTypeBuilder)base.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public MetaType InnerType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class MetaNullableTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaNullableTypeBuilder
	{
	
		internal MetaNullableTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaNullableType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaNullableType; }
		}
	
		public new MetaNullableType ToImmutable()
		{
			return (MetaNullableType)base.ToImmutable();
		}
	
		public new MetaNullableType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaNullableType)base.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public MetaTypeBuilder InnerType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNullableType.InnerTypeProperty, value); }
		}
	}
	
	internal class MetaPrimitiveTypeId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaPrimitiveType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaPrimitiveType); } }
		public override global::System.Type MutableType { get { return typeof(MetaPrimitiveTypeBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaPrimitiveTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaPrimitiveTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaPrimitiveTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaPrimitiveType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal MetaPrimitiveTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaPrimitiveType; }
		}
	
		public new MetaPrimitiveTypeBuilder ToMutable()
		{
			return (MetaPrimitiveTypeBuilder)base.ToMutable();
		}
	
		public new MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaPrimitiveTypeBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaPrimitiveTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaPrimitiveTypeBuilder
	{
	
		internal MetaPrimitiveTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaPrimitiveType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaPrimitiveType; }
		}
	
		public new MetaPrimitiveType ToImmutable()
		{
			return (MetaPrimitiveType)base.ToImmutable();
		}
	
		public new MetaPrimitiveType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaPrimitiveType)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	}
	
	internal class MetaEnumId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaEnum); } }
		public override global::System.Type MutableType { get { return typeof(MetaEnumBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaEnumImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaEnumBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaEnumImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaEnum
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaEnumLiteral> enumLiterals0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> operations0;
	
		internal MetaEnumImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaEnum; }
		}
	
		public new MetaEnumBuilder ToMutable()
		{
			return (MetaEnumBuilder)base.ToMutable();
		}
	
		public new MetaEnumBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaEnumBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaEnumLiteral> EnumLiterals
		{
		    get { return this.GetList<MetaEnumLiteral>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaEnumBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaEnumBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaEnumLiteralBuilder> enumLiterals0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaOperationBuilder> operations0;
	
		internal MetaEnumBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaEnum(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaEnum; }
		}
	
		public new MetaEnum ToImmutable()
		{
			return (MetaEnum)base.ToImmutable();
		}
	
		public new MetaEnum ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaEnum)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaEnumLiteralBuilder> EnumLiterals
		{
			get { return this.GetList<MetaEnumLiteralBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
		}
	}
	
	internal class MetaEnumLiteralId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaEnumLiteral); } }
		public override global::System.Type MutableType { get { return typeof(MetaEnumLiteralBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaEnumLiteralImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaEnumLiteralBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaEnumLiteralImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaEnumLiteral
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaEnum enum0;
	
		internal MetaEnumLiteralImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaEnumLiteral; }
		}
	
		public new MetaEnumLiteralBuilder ToMutable()
		{
			return (MetaEnumLiteralBuilder)base.ToMutable();
		}
	
		public new MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaEnumLiteralBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaEnum Enum
		{
		    get { return this.GetReference<MetaEnum>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty, ref enum0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaEnumLiteralBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaEnumLiteralBuilder
	{
	
		internal MetaEnumLiteralBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaEnumLiteral(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaEnumLiteral; }
		}
	
		public new MetaEnumLiteral ToImmutable()
		{
			return (MetaEnumLiteral)base.ToImmutable();
		}
	
		public new MetaEnumLiteral ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaEnumLiteral)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaEnumBuilder Enum
		{
			get { return this.GetReference<MetaEnumBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty); }
			set { this.SetReference<MetaEnumBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty, value); }
		}
		
		public Func<MetaEnumBuilder> EnumLazy
		{
			get { return this.GetLazyReference<MetaEnumBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaEnumLiteral.EnumProperty, value); }
		}
	}
	
	internal class MetaConstantId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstant.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaConstant); } }
		public override global::System.Type MutableType { get { return typeof(MetaConstantBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaConstantImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaConstantBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaConstantImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaConstant
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
	
		internal MetaConstantImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaConstant; }
		}
	
		public new MetaConstantBuilder ToMutable()
		{
			return (MetaConstantBuilder)base.ToMutable();
		}
	
		public new MetaConstantBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaConstantBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaConstantBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaConstantBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaConstantBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaConstant(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaConstant; }
		}
	
		public new MetaConstant ToImmutable()
		{
			return (MetaConstant)base.ToImmutable();
		}
	
		public new MetaConstant ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaConstant)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	}
	
	internal class MetaClassId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaClass); } }
		public override global::System.Type MutableType { get { return typeof(MetaClassBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaClassImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaClassBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaClassImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaClass
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaNamespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaModel metaModel0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaClass> superClasses0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> operations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaConstructor constructor0;
	
		internal MetaClassImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaClass; }
		}
	
		public new MetaClassBuilder ToMutable()
		{
			return (MetaClassBuilder)base.ToMutable();
		}
	
		public new MetaClassBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaClassBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDeclarationBuilder MetaDeclaration.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaNamespace Namespace
		{
		    get { return this.GetReference<MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public MetaModel MetaModel
		{
		    get { return this.GetReference<MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty, ref metaModel0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaClass> SuperClasses
		{
		    get { return this.GetList<MetaClass>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> Properties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> Operations
		{
		    get { return this.GetList<MetaOperation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		public MetaConstructor Constructor
		{
		    get { return this.GetReference<MetaConstructor>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty, ref constructor0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaClass> MetaClass.GetAllSuperClasses(bool includeSelf)
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this, includeSelf);
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> MetaClass.GetAllSuperProperties(bool includeSelf)
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperProperties(this, includeSelf);
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> MetaClass.GetAllSuperOperations(bool includeSelf)
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperOperations(this, includeSelf);
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> MetaClass.GetAllProperties()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> MetaClass.GetAllOperations()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> MetaClass.GetAllFinalProperties()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllFinalProperties(this);
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> MetaClass.GetAllFinalOperations()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaClass_GetAllFinalOperations(this);
		}
	}
	
	internal class MetaClassBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaClassBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaClassBuilder> superClasses0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> properties0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaOperationBuilder> operations0;
	
		internal MetaClassBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaClass(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaClass; }
		}
	
		public new MetaClass ToImmutable()
		{
			return (MetaClass)base.ToImmutable();
		}
	
		public new MetaClass ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaClass)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDeclaration MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaNamespaceBuilder Namespace
		{
			get { return this.GetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
		
		public Func<MetaNamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
		}
	
		
		public MetaModelBuilder MetaModel
		{
			get { return this.GetReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
		}
		
		public Func<MetaModelBuilder> MetaModelLazy
		{
			get { return this.GetLazyReference<MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.MetaModelProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDeclaration.MetaModelProperty, value); }
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty, value); }
		}
		
		public Func<bool> IsAbstractLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty); }
			set { this.SetLazyValue(MetaDescriptor.MetaClass.IsAbstractProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaClassBuilder> SuperClasses
		{
			get { return this.GetList<MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> Properties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaOperationBuilder> Operations
		{
			get { return this.GetList<MetaOperationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
		}
	
		
		public MetaConstructorBuilder Constructor
		{
			get { return this.GetReference<MetaConstructorBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty); }
			set { this.SetReference<MetaConstructorBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty, value); }
		}
		
		public Func<MetaConstructorBuilder> ConstructorLazy
		{
			get { return this.GetLazyReference<MetaConstructorBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaClass.ConstructorProperty, value); }
		}
	}
	
	internal class MetaFunctionTypeId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaFunctionType); } }
		public override global::System.Type MutableType { get { return typeof(MetaFunctionTypeBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaFunctionTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaFunctionTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaFunctionTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaFunctionType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaType> parameterTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType returnType0;
	
		internal MetaFunctionTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaFunctionType; }
		}
	
		public new MetaFunctionTypeBuilder ToMutable()
		{
			return (MetaFunctionTypeBuilder)base.ToMutable();
		}
	
		public new MetaFunctionTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaFunctionTypeBuilder)base.ToMutable(model);
		}
	
		MetaTypeBuilder MetaType.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypeBuilder MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaType> ParameterTypes
		{
		    get { return this.GetList<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ParameterTypesProperty, ref parameterTypes0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty, ref returnType0); }
		}
	}
	
	internal class MetaFunctionTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaFunctionTypeBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaTypeBuilder> parameterTypes0;
	
		internal MetaFunctionTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaFunctionType(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaFunctionType; }
		}
	
		public new MetaFunctionType ToImmutable()
		{
			return (MetaFunctionType)base.ToImmutable();
		}
	
		public new MetaFunctionType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaFunctionType)base.ToImmutable(model);
		}
	
		MetaType MetaTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaType MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaTypeBuilder> ParameterTypes
		{
			get { return this.GetList<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ParameterTypesProperty, ref parameterTypes0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ReturnTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunctionType.ReturnTypeProperty, value); }
		}
	}
	
	internal class MetaFunctionId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaFunction); } }
		public override global::System.Type MutableType { get { return typeof(MetaFunctionBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaFunctionImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaFunctionBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaFunctionImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaFunction
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaFunctionType type1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaParameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType returnType0;
	
		internal MetaFunctionImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaFunction; }
		}
	
		public new MetaFunctionBuilder ToMutable()
		{
			return (MetaFunctionBuilder)base.ToMutable();
		}
	
		public new MetaFunctionBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaFunctionBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		MetaType MetaTypedElement.Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public MetaFunctionType Type
		{
		    get { return this.GetReference<MetaFunctionType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty, ref type1); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaParameter> Parameters
		{
		    get { return this.GetList<MetaParameter>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, ref returnType0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaFunctionBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaFunctionBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaParameterBuilder> parameters0;
	
		internal MetaFunctionBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaFunction(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaFunction; }
		}
	
		public new MetaFunction ToImmutable()
		{
			return (MetaFunction)base.ToImmutable();
		}
	
		public new MetaFunction ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaFunction)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		MetaTypeBuilder MetaTypedElementBuilder.Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Func<MetaTypeBuilder> MetaTypedElementBuilder.TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public MetaFunctionTypeBuilder Type
		{
			get { return this.GetReference<MetaFunctionTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty); }
		}
		
		public Func<MetaFunctionTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaFunctionTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunction.TypeProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaParameterBuilder> Parameters
		{
			get { return this.GetList<MetaParameterBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ReturnTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
		}
	}
	
	internal class MetaOperationId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaOperation); } }
		public override global::System.Type MutableType { get { return typeof(MetaOperationBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaOperationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaOperationBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaOperationImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaOperation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaFunctionType type1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaParameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType returnType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType parent0;
	
		internal MetaOperationImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaOperation; }
		}
	
		public new MetaOperationBuilder ToMutable()
		{
			return (MetaOperationBuilder)base.ToMutable();
		}
	
		public new MetaOperationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaOperationBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaFunctionBuilder MetaFunction.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaFunctionBuilder MetaFunction.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		MetaType MetaTypedElement.Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public MetaFunctionType Type
		{
		    get { return this.GetReference<MetaFunctionType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty, ref type1); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaParameter> Parameters
		{
		    get { return this.GetList<MetaParameter>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaType ReturnType
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, ref returnType0); }
		}
	
		
		public MetaType Parent
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty, ref parent0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaOperationBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaOperationBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaParameterBuilder> parameters0;
	
		internal MetaOperationBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaOperation(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaOperation; }
		}
	
		public new MetaOperation ToImmutable()
		{
			return (MetaOperation)base.ToImmutable();
		}
	
		public new MetaOperation ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaOperation)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaFunction MetaFunctionBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaFunction MetaFunctionBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		MetaTypeBuilder MetaTypedElementBuilder.Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Func<MetaTypeBuilder> MetaTypedElementBuilder.TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public MetaFunctionTypeBuilder Type
		{
			get { return this.GetReference<MetaFunctionTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty); }
		}
		
		public Func<MetaFunctionTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaFunctionTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunction.TypeProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaParameterBuilder> Parameters
		{
			get { return this.GetList<MetaParameterBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
		}
	
		
		public MetaTypeBuilder ReturnType
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ReturnTypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
		}
	
		
		public MetaTypeBuilder Parent
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty, value); }
		}
		
		public Func<MetaTypeBuilder> ParentLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaOperation.ParentProperty, value); }
		}
	}
	
	internal class MetaConstructorId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaConstructor); } }
		public override global::System.Type MutableType { get { return typeof(MetaConstructorBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaConstructorImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaConstructorBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaConstructorImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaConstructor
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaClass parent0;
	
		internal MetaConstructorImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaConstructor; }
		}
	
		public new MetaConstructorBuilder ToMutable()
		{
			return (MetaConstructorBuilder)base.ToMutable();
		}
	
		public new MetaConstructorBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaConstructorBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaClass Parent
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty, ref parent0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaConstructorBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaConstructorBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaConstructorBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaConstructor(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaConstructor; }
		}
	
		public new MetaConstructor ToImmutable()
		{
			return (MetaConstructor)base.ToImmutable();
		}
	
		public new MetaConstructor ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaConstructor)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaClassBuilder Parent
		{
			get { return this.GetReference<MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty); }
			set { this.SetReference<MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty, value); }
		}
		
		public Func<MetaClassBuilder> ParentLazy
		{
			get { return this.GetLazyReference<MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaConstructor.ParentProperty, value); }
		}
	}
	
	internal class MetaParameterId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaParameter); } }
		public override global::System.Type MutableType { get { return typeof(MetaParameterBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaParameterImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaFunction function0;
	
		internal MetaParameterImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaParameter; }
		}
	
		public new MetaParameterBuilder ToMutable()
		{
			return (MetaParameterBuilder)base.ToMutable();
		}
	
		public new MetaParameterBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaParameterBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaFunction Function
		{
		    get { return this.GetReference<MetaFunction>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty, ref function0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaParameterBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaParameterBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
	
		internal MetaParameterBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaParameter(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaParameter; }
		}
	
		public new MetaParameter ToImmutable()
		{
			return (MetaParameter)base.ToImmutable();
		}
	
		public new MetaParameter ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaParameter)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaFunctionBuilder Function
		{
			get { return this.GetReference<MetaFunctionBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty); }
			set { this.SetReference<MetaFunctionBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty, value); }
		}
		
		public Func<MetaFunctionBuilder> FunctionLazy
		{
			get { return this.GetLazyReference<MetaFunctionBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaParameter.FunctionProperty, value); }
		}
	}
	
	internal class MetaPropertyId : global::MetaDslx.Core.Immutable.SymbolId
	{
		public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(MetaProperty); } }
		public override global::System.Type MutableType { get { return typeof(MetaPropertyBuilder); } }
	
		public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return new MetaPropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
		{
			return new MetaPropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class MetaPropertyImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, MetaProperty
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaPropertyKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MetaClass class0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> oppositeProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> subsettedProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> subsettingProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> redefinedProperties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> redefiningProperties0;
	
		internal MetaPropertyImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaProperty; }
		}
	
		public new MetaPropertyBuilder ToMutable()
		{
			return (MetaPropertyBuilder)base.ToMutable();
		}
	
		public new MetaPropertyBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return (MetaPropertyBuilder)base.ToMutable(model);
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaDocumentedElementBuilder MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaAnnotatedElementBuilder MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaTypedElementBuilder MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		MetaNamedElementBuilder MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaAnnotation> Annotations
		{
		    get { return this.GetList<MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public MetaType Type
		{
		    get { return this.GetReference<MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
		}
	
		
		public MetaPropertyKind Kind
		{
		    get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty, ref kind0); }
		}
	
		
		public MetaClass Class
		{
		    get { return this.GetReference<MetaClass>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty, ref class0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> OppositeProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> SubsettedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> SubsettingProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> RedefinedProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> RedefiningProperties
		{
		    get { return this.GetList<MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	
		
		global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Core.Immutable.Internal.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class MetaPropertyBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, MetaPropertyBuilder
	{
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> annotations0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> oppositeProperties0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> subsettedProperties0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> subsettingProperties0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> redefinedProperties0;
		private global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> redefiningProperties0;
	
		internal MetaPropertyBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		internal protected override void MInit()
		{
			MetaImplementationProvider.Implementation.MetaProperty(this);
		}
	
		public override MetaModel MMetaModel
		{
			get { return global::MetaDslx.Core.Immutable.MetaInstance._MetaModel; }
		}
	
		public override MetaClass MMetaClass
		{
			get { return MetaInstance.MetaProperty; }
		}
	
		public new MetaProperty ToImmutable()
		{
			return (MetaProperty)base.ToImmutable();
		}
	
		public new MetaProperty ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return (MetaProperty)base.ToImmutable(model);
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaDocumentedElement MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaAnnotatedElement MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaTypedElement MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		MetaNamedElement MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaAnnotationBuilder> Annotations
		{
			get { return this.GetList<MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public MetaTypeBuilder Type
		{
			get { return this.GetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
		
		public Func<MetaTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaTypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaNamedElement.NameProperty, value); }
		}
	
		
		public MetaPropertyKind Kind
		{
			get { return this.GetValue<MetaPropertyKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty); }
			set { this.SetValue<MetaPropertyKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty, value); }
		}
		
		public Func<MetaPropertyKind> KindLazy
		{
			get { return this.GetLazyValue<MetaPropertyKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty); }
			set { this.SetLazyValue(MetaDescriptor.MetaProperty.KindProperty, value); }
		}
	
		
		public MetaClassBuilder Class
		{
			get { return this.GetReference<MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty); }
			set { this.SetReference<MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty, value); }
		}
		
		public Func<MetaClassBuilder> ClassLazy
		{
			get { return this.GetLazyReference<MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty); }
			set { this.SetLazyReference(MetaDescriptor.MetaProperty.ClassProperty, value); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> OppositeProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> SubsettedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> SubsettingProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> RedefinedProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
		}
	
		
		public global::MetaDslx.Core.Immutable.MutableModelList<MetaPropertyBuilder> RedefiningProperties
		{
			get { return this.GetList<MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
		}
	}

	internal class MetaBuilderInstance
	{
		internal static MetaBuilderInstance instance = new MetaBuilderInstance();
	
		private bool creating;
		private bool created;
		internal MetaModelBuilder _MetaModel;
		internal global::MetaDslx.Core.Immutable.MutableModel Model;
	
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
	
		private RootScopeBuilder __tmp1;
		private MetaNamespaceBuilder __tmp2;
		private MetaNamespaceBuilder __tmp3;
		private MetaModelBuilder __tmp4;
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
		private MetaAnnotationBuilder __tmp15;
		internal MetaClassBuilder RootScope;
		private MetaAnnotationBuilder __tmp16;
		private MetaCollectionTypeBuilder __tmp17;
		internal MetaPropertyBuilder RootScope_BuiltInEntries;
		private MetaAnnotationBuilder __tmp18;
		private MetaCollectionTypeBuilder __tmp19;
		internal MetaPropertyBuilder RootScope_Entries;
		internal MetaClassBuilder MetaAnnotatedElement;
		private MetaCollectionTypeBuilder __tmp20;
		internal MetaPropertyBuilder MetaAnnotatedElement_Annotations;
		internal MetaClassBuilder MetaDocumentedElement;
		internal MetaPropertyBuilder MetaDocumentedElement_Documentation;
		private MetaCollectionTypeBuilder __tmp21;
		private MetaOperationBuilder __tmp22;
		internal MetaClassBuilder MetaNamedElement;
		private MetaAnnotationBuilder __tmp23;
		internal MetaPropertyBuilder MetaNamedElement_Name;
		internal MetaClassBuilder MetaTypedElement;
		private MetaAnnotationBuilder __tmp24;
		internal MetaPropertyBuilder MetaTypedElement_Type;
		private MetaAnnotationBuilder __tmp25;
		internal MetaClassBuilder MetaType;
		internal MetaClassBuilder MetaAnnotation;
		private MetaAnnotationBuilder __tmp26;
		internal MetaClassBuilder MetaNamespace;
		internal MetaPropertyBuilder MetaNamespace_Parent;
		private MetaAnnotationBuilder __tmp27;
		private MetaCollectionTypeBuilder __tmp28;
		internal MetaPropertyBuilder MetaNamespace_Usings;
		internal MetaPropertyBuilder MetaNamespace_MetaModel;
		private MetaAnnotationBuilder __tmp29;
		private MetaCollectionTypeBuilder __tmp30;
		internal MetaPropertyBuilder MetaNamespace_Namespaces;
		private MetaAnnotationBuilder __tmp31;
		private MetaCollectionTypeBuilder __tmp32;
		internal MetaPropertyBuilder MetaNamespace_Declarations;
		internal MetaClassBuilder MetaDeclaration;
		internal MetaPropertyBuilder MetaDeclaration_Namespace;
		internal MetaPropertyBuilder MetaDeclaration_MetaModel;
		internal MetaClassBuilder MetaModel;
		internal MetaPropertyBuilder MetaModel_Uri;
		internal MetaPropertyBuilder MetaModel_Namespace;
		internal MetaEnumBuilder MetaCollectionKind;
		private MetaEnumLiteralBuilder __tmp33;
		private MetaEnumLiteralBuilder __tmp34;
		private MetaEnumLiteralBuilder __tmp35;
		private MetaEnumLiteralBuilder __tmp36;
		internal MetaClassBuilder MetaCollectionType;
		internal MetaPropertyBuilder MetaCollectionType_Kind;
		internal MetaPropertyBuilder MetaCollectionType_InnerType;
		internal MetaClassBuilder MetaNullableType;
		internal MetaPropertyBuilder MetaNullableType_InnerType;
		internal MetaClassBuilder MetaPrimitiveType;
		private MetaAnnotationBuilder __tmp37;
		internal MetaClassBuilder MetaEnum;
		private MetaAnnotationBuilder __tmp38;
		private MetaCollectionTypeBuilder __tmp39;
		internal MetaPropertyBuilder MetaEnum_EnumLiterals;
		private MetaAnnotationBuilder __tmp40;
		private MetaCollectionTypeBuilder __tmp41;
		internal MetaPropertyBuilder MetaEnum_Operations;
		internal MetaClassBuilder MetaEnumLiteral;
		internal MetaPropertyBuilder MetaEnumLiteral_Enum;
		internal MetaClassBuilder MetaConstant;
		private MetaAnnotationBuilder __tmp42;
		internal MetaClassBuilder MetaClass;
		internal MetaPropertyBuilder MetaClass_IsAbstract;
		private MetaAnnotationBuilder __tmp43;
		private MetaCollectionTypeBuilder __tmp44;
		internal MetaPropertyBuilder MetaClass_SuperClasses;
		private MetaAnnotationBuilder __tmp45;
		private MetaCollectionTypeBuilder __tmp46;
		internal MetaPropertyBuilder MetaClass_Properties;
		private MetaAnnotationBuilder __tmp47;
		private MetaCollectionTypeBuilder __tmp48;
		internal MetaPropertyBuilder MetaClass_Operations;
		internal MetaPropertyBuilder MetaClass_Constructor;
		private MetaCollectionTypeBuilder __tmp49;
		private MetaOperationBuilder __tmp50;
		private MetaParameterBuilder __tmp51;
		private MetaCollectionTypeBuilder __tmp52;
		private MetaOperationBuilder __tmp53;
		private MetaParameterBuilder __tmp54;
		private MetaCollectionTypeBuilder __tmp55;
		private MetaOperationBuilder __tmp56;
		private MetaParameterBuilder __tmp57;
		private MetaCollectionTypeBuilder __tmp58;
		private MetaOperationBuilder __tmp59;
		private MetaCollectionTypeBuilder __tmp60;
		private MetaOperationBuilder __tmp61;
		private MetaCollectionTypeBuilder __tmp62;
		private MetaOperationBuilder __tmp63;
		private MetaCollectionTypeBuilder __tmp64;
		private MetaOperationBuilder __tmp65;
		internal MetaClassBuilder MetaFunctionType;
		private MetaCollectionTypeBuilder __tmp66;
		internal MetaPropertyBuilder MetaFunctionType_ParameterTypes;
		internal MetaPropertyBuilder MetaFunctionType_ReturnType;
		internal MetaClassBuilder MetaFunction;
		private MetaAnnotationBuilder __tmp67;
		internal MetaPropertyBuilder MetaFunction_Type;
		private MetaCollectionTypeBuilder __tmp68;
		internal MetaPropertyBuilder MetaFunction_Parameters;
		internal MetaPropertyBuilder MetaFunction_ReturnType;
		internal MetaClassBuilder MetaOperation;
		internal MetaPropertyBuilder MetaOperation_Parent;
		internal MetaClassBuilder MetaConstructor;
		internal MetaPropertyBuilder MetaConstructor_Parent;
		internal MetaClassBuilder MetaParameter;
		internal MetaPropertyBuilder MetaParameter_Function;
		internal MetaEnumBuilder MetaPropertyKind;
		private MetaEnumLiteralBuilder __tmp69;
		private MetaEnumLiteralBuilder __tmp70;
		private MetaEnumLiteralBuilder __tmp71;
		private MetaEnumLiteralBuilder __tmp72;
		private MetaEnumLiteralBuilder __tmp73;
		private MetaEnumLiteralBuilder __tmp74;
		internal MetaClassBuilder MetaProperty;
		internal MetaPropertyBuilder MetaProperty_Kind;
		internal MetaPropertyBuilder MetaProperty_Class;
		private MetaCollectionTypeBuilder __tmp75;
		internal MetaPropertyBuilder MetaProperty_OppositeProperties;
		private MetaCollectionTypeBuilder __tmp76;
		internal MetaPropertyBuilder MetaProperty_SubsettedProperties;
		private MetaCollectionTypeBuilder __tmp77;
		internal MetaPropertyBuilder MetaProperty_SubsettingProperties;
		private MetaCollectionTypeBuilder __tmp78;
		internal MetaPropertyBuilder MetaProperty_RedefinedProperties;
		private MetaCollectionTypeBuilder __tmp79;
		internal MetaPropertyBuilder MetaProperty_RedefiningProperties;
	
		internal MetaBuilderInstance()
		{
			this.Model = new global::MetaDslx.Core.Immutable.MutableModel();
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
			MetaFactory factory = new MetaFactory(this.Model, global::MetaDslx.Core.Immutable.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.RootScope();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaModel();
			_MetaModel = __tmp4;
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
			__tmp15 = factory.MetaAnnotation();
			RootScope = factory.MetaClass();
			__tmp16 = factory.MetaAnnotation();
			__tmp17 = factory.MetaCollectionType();
			RootScope_BuiltInEntries = factory.MetaProperty();
			__tmp18 = factory.MetaAnnotation();
			__tmp19 = factory.MetaCollectionType();
			RootScope_Entries = factory.MetaProperty();
			MetaAnnotatedElement = factory.MetaClass();
			__tmp20 = factory.MetaCollectionType();
			MetaAnnotatedElement_Annotations = factory.MetaProperty();
			MetaDocumentedElement = factory.MetaClass();
			MetaDocumentedElement_Documentation = factory.MetaProperty();
			__tmp21 = factory.MetaCollectionType();
			__tmp22 = factory.MetaOperation();
			MetaNamedElement = factory.MetaClass();
			__tmp23 = factory.MetaAnnotation();
			MetaNamedElement_Name = factory.MetaProperty();
			MetaTypedElement = factory.MetaClass();
			__tmp24 = factory.MetaAnnotation();
			MetaTypedElement_Type = factory.MetaProperty();
			__tmp25 = factory.MetaAnnotation();
			MetaType = factory.MetaClass();
			MetaAnnotation = factory.MetaClass();
			__tmp26 = factory.MetaAnnotation();
			MetaNamespace = factory.MetaClass();
			MetaNamespace_Parent = factory.MetaProperty();
			__tmp27 = factory.MetaAnnotation();
			__tmp28 = factory.MetaCollectionType();
			MetaNamespace_Usings = factory.MetaProperty();
			MetaNamespace_MetaModel = factory.MetaProperty();
			__tmp29 = factory.MetaAnnotation();
			__tmp30 = factory.MetaCollectionType();
			MetaNamespace_Namespaces = factory.MetaProperty();
			__tmp31 = factory.MetaAnnotation();
			__tmp32 = factory.MetaCollectionType();
			MetaNamespace_Declarations = factory.MetaProperty();
			MetaDeclaration = factory.MetaClass();
			MetaDeclaration_Namespace = factory.MetaProperty();
			MetaDeclaration_MetaModel = factory.MetaProperty();
			MetaModel = factory.MetaClass();
			MetaModel_Uri = factory.MetaProperty();
			MetaModel_Namespace = factory.MetaProperty();
			MetaCollectionKind = factory.MetaEnum();
			__tmp33 = factory.MetaEnumLiteral();
			__tmp34 = factory.MetaEnumLiteral();
			__tmp35 = factory.MetaEnumLiteral();
			__tmp36 = factory.MetaEnumLiteral();
			MetaCollectionType = factory.MetaClass();
			MetaCollectionType_Kind = factory.MetaProperty();
			MetaCollectionType_InnerType = factory.MetaProperty();
			MetaNullableType = factory.MetaClass();
			MetaNullableType_InnerType = factory.MetaProperty();
			MetaPrimitiveType = factory.MetaClass();
			__tmp37 = factory.MetaAnnotation();
			MetaEnum = factory.MetaClass();
			__tmp38 = factory.MetaAnnotation();
			__tmp39 = factory.MetaCollectionType();
			MetaEnum_EnumLiterals = factory.MetaProperty();
			__tmp40 = factory.MetaAnnotation();
			__tmp41 = factory.MetaCollectionType();
			MetaEnum_Operations = factory.MetaProperty();
			MetaEnumLiteral = factory.MetaClass();
			MetaEnumLiteral_Enum = factory.MetaProperty();
			MetaConstant = factory.MetaClass();
			__tmp42 = factory.MetaAnnotation();
			MetaClass = factory.MetaClass();
			MetaClass_IsAbstract = factory.MetaProperty();
			__tmp43 = factory.MetaAnnotation();
			__tmp44 = factory.MetaCollectionType();
			MetaClass_SuperClasses = factory.MetaProperty();
			__tmp45 = factory.MetaAnnotation();
			__tmp46 = factory.MetaCollectionType();
			MetaClass_Properties = factory.MetaProperty();
			__tmp47 = factory.MetaAnnotation();
			__tmp48 = factory.MetaCollectionType();
			MetaClass_Operations = factory.MetaProperty();
			MetaClass_Constructor = factory.MetaProperty();
			__tmp49 = factory.MetaCollectionType();
			__tmp50 = factory.MetaOperation();
			__tmp51 = factory.MetaParameter();
			__tmp52 = factory.MetaCollectionType();
			__tmp53 = factory.MetaOperation();
			__tmp54 = factory.MetaParameter();
			__tmp55 = factory.MetaCollectionType();
			__tmp56 = factory.MetaOperation();
			__tmp57 = factory.MetaParameter();
			__tmp58 = factory.MetaCollectionType();
			__tmp59 = factory.MetaOperation();
			__tmp60 = factory.MetaCollectionType();
			__tmp61 = factory.MetaOperation();
			__tmp62 = factory.MetaCollectionType();
			__tmp63 = factory.MetaOperation();
			__tmp64 = factory.MetaCollectionType();
			__tmp65 = factory.MetaOperation();
			MetaFunctionType = factory.MetaClass();
			__tmp66 = factory.MetaCollectionType();
			MetaFunctionType_ParameterTypes = factory.MetaProperty();
			MetaFunctionType_ReturnType = factory.MetaProperty();
			MetaFunction = factory.MetaClass();
			__tmp67 = factory.MetaAnnotation();
			MetaFunction_Type = factory.MetaProperty();
			__tmp68 = factory.MetaCollectionType();
			MetaFunction_Parameters = factory.MetaProperty();
			MetaFunction_ReturnType = factory.MetaProperty();
			MetaOperation = factory.MetaClass();
			MetaOperation_Parent = factory.MetaProperty();
			MetaConstructor = factory.MetaClass();
			MetaConstructor_Parent = factory.MetaProperty();
			MetaParameter = factory.MetaClass();
			MetaParameter_Function = factory.MetaProperty();
			MetaPropertyKind = factory.MetaEnum();
			__tmp69 = factory.MetaEnumLiteral();
			__tmp70 = factory.MetaEnumLiteral();
			__tmp71 = factory.MetaEnumLiteral();
			__tmp72 = factory.MetaEnumLiteral();
			__tmp73 = factory.MetaEnumLiteral();
			__tmp74 = factory.MetaEnumLiteral();
			MetaProperty = factory.MetaClass();
			MetaProperty_Kind = factory.MetaProperty();
			MetaProperty_Class = factory.MetaProperty();
			__tmp75 = factory.MetaCollectionType();
			MetaProperty_OppositeProperties = factory.MetaProperty();
			__tmp76 = factory.MetaCollectionType();
			MetaProperty_SubsettedProperties = factory.MetaProperty();
			__tmp77 = factory.MetaCollectionType();
			MetaProperty_SubsettingProperties = factory.MetaProperty();
			__tmp78 = factory.MetaCollectionType();
			MetaProperty_RedefinedProperties = factory.MetaProperty();
			__tmp79 = factory.MetaCollectionType();
			MetaProperty_RedefiningProperties = factory.MetaProperty();
	
			__tmp1.BuiltInEntries.AddLazy(() => Object);
			__tmp1.BuiltInEntries.AddLazy(() => String);
			__tmp1.BuiltInEntries.AddLazy(() => Int);
			__tmp1.BuiltInEntries.AddLazy(() => Long);
			__tmp1.BuiltInEntries.AddLazy(() => Float);
			__tmp1.BuiltInEntries.AddLazy(() => Double);
			__tmp1.BuiltInEntries.AddLazy(() => Byte);
			__tmp1.BuiltInEntries.AddLazy(() => Bool);
			__tmp1.BuiltInEntries.AddLazy(() => Void);
			__tmp1.BuiltInEntries.AddLazy(() => Symbol);
			__tmp1.Entries.AddLazy(() => __tmp2);
			__tmp2.Name = "MetaDslx";
			__tmp2.Documentation = null;
			// __tmp2.Parent = null;
			// __tmp2.MetaModel = null;
			__tmp2.Namespaces.AddLazy(() => __tmp3);
			__tmp3.Name = "Core";
			__tmp3.Documentation = null;
			__tmp3.ParentLazy = () => __tmp2;
			__tmp3.MetaModelLazy = () => __tmp4;
			__tmp3.Declarations.AddLazy(() => __tmp5);
			__tmp3.Declarations.AddLazy(() => __tmp6);
			__tmp3.Declarations.AddLazy(() => __tmp7);
			__tmp3.Declarations.AddLazy(() => __tmp8);
			__tmp3.Declarations.AddLazy(() => __tmp9);
			__tmp3.Declarations.AddLazy(() => __tmp10);
			__tmp3.Declarations.AddLazy(() => __tmp11);
			__tmp3.Declarations.AddLazy(() => __tmp12);
			__tmp3.Declarations.AddLazy(() => __tmp13);
			__tmp3.Declarations.AddLazy(() => __tmp14);
			__tmp3.Declarations.AddLazy(() => RootScope);
			__tmp3.Declarations.AddLazy(() => MetaAnnotatedElement);
			__tmp3.Declarations.AddLazy(() => MetaDocumentedElement);
			__tmp3.Declarations.AddLazy(() => MetaNamedElement);
			__tmp3.Declarations.AddLazy(() => MetaTypedElement);
			__tmp3.Declarations.AddLazy(() => MetaType);
			__tmp3.Declarations.AddLazy(() => MetaAnnotation);
			__tmp3.Declarations.AddLazy(() => MetaNamespace);
			__tmp3.Declarations.AddLazy(() => MetaDeclaration);
			__tmp3.Declarations.AddLazy(() => MetaModel);
			__tmp3.Declarations.AddLazy(() => MetaCollectionKind);
			__tmp3.Declarations.AddLazy(() => MetaCollectionType);
			__tmp3.Declarations.AddLazy(() => MetaNullableType);
			__tmp3.Declarations.AddLazy(() => MetaPrimitiveType);
			__tmp3.Declarations.AddLazy(() => MetaEnum);
			__tmp3.Declarations.AddLazy(() => MetaEnumLiteral);
			__tmp3.Declarations.AddLazy(() => MetaConstant);
			__tmp3.Declarations.AddLazy(() => MetaClass);
			__tmp3.Declarations.AddLazy(() => MetaFunctionType);
			__tmp3.Declarations.AddLazy(() => MetaFunction);
			__tmp3.Declarations.AddLazy(() => MetaOperation);
			__tmp3.Declarations.AddLazy(() => MetaConstructor);
			__tmp3.Declarations.AddLazy(() => MetaParameter);
			__tmp3.Declarations.AddLazy(() => MetaPropertyKind);
			__tmp3.Declarations.AddLazy(() => MetaProperty);
			__tmp4.Name = "Meta";
			__tmp4.Documentation = "Represents the MetaModel.";
			__tmp4.Uri = "http://metadslx.core/1.0";
			__tmp4.NamespaceLazy = () => __tmp3;
			__tmp5.MetaModelLazy = () => __tmp4;
			__tmp5.NamespaceLazy = () => __tmp3;
			__tmp5.Documentation = null;
			__tmp5.Name = "Object";
			__tmp5.TypeLazy = () => MetaPrimitiveType;
			__tmp6.MetaModelLazy = () => __tmp4;
			__tmp6.NamespaceLazy = () => __tmp3;
			__tmp6.Documentation = null;
			__tmp6.Name = "String";
			__tmp6.TypeLazy = () => MetaPrimitiveType;
			__tmp7.MetaModelLazy = () => __tmp4;
			__tmp7.NamespaceLazy = () => __tmp3;
			__tmp7.Documentation = null;
			__tmp7.Name = "Int";
			__tmp7.TypeLazy = () => MetaPrimitiveType;
			__tmp8.MetaModelLazy = () => __tmp4;
			__tmp8.NamespaceLazy = () => __tmp3;
			__tmp8.Documentation = null;
			__tmp8.Name = "Long";
			__tmp8.TypeLazy = () => MetaPrimitiveType;
			__tmp9.MetaModelLazy = () => __tmp4;
			__tmp9.NamespaceLazy = () => __tmp3;
			__tmp9.Documentation = null;
			__tmp9.Name = "Float";
			__tmp9.TypeLazy = () => MetaPrimitiveType;
			__tmp10.MetaModelLazy = () => __tmp4;
			__tmp10.NamespaceLazy = () => __tmp3;
			__tmp10.Documentation = null;
			__tmp10.Name = "Double";
			__tmp10.TypeLazy = () => MetaPrimitiveType;
			__tmp11.MetaModelLazy = () => __tmp4;
			__tmp11.NamespaceLazy = () => __tmp3;
			__tmp11.Documentation = null;
			__tmp11.Name = "Byte";
			__tmp11.TypeLazy = () => MetaPrimitiveType;
			__tmp12.MetaModelLazy = () => __tmp4;
			__tmp12.NamespaceLazy = () => __tmp3;
			__tmp12.Documentation = null;
			__tmp12.Name = "Bool";
			__tmp12.TypeLazy = () => MetaPrimitiveType;
			__tmp13.MetaModelLazy = () => __tmp4;
			__tmp13.NamespaceLazy = () => __tmp3;
			__tmp13.Documentation = null;
			__tmp13.Name = "Void";
			__tmp13.TypeLazy = () => MetaPrimitiveType;
			__tmp14.MetaModelLazy = () => __tmp4;
			__tmp14.NamespaceLazy = () => __tmp3;
			__tmp14.Documentation = null;
			__tmp14.Name = "Symbol";
			__tmp14.TypeLazy = () => MetaPrimitiveType;
			__tmp15.Name = "Scope";
			__tmp15.Documentation = null;
			RootScope.MetaModelLazy = () => __tmp4;
			RootScope.NamespaceLazy = () => __tmp3;
			RootScope.Documentation = null;
			RootScope.Name = "RootScope";
			RootScope.Annotations.AddLazy(() => __tmp15);
			// RootScope.IsAbstract = null;
			RootScope.Properties.AddLazy(() => RootScope_BuiltInEntries);
			RootScope.Properties.AddLazy(() => RootScope_Entries);
			// RootScope.Constructor = null;
			__tmp16.Name = "ScopeEntry";
			__tmp16.Documentation = null;
			__tmp17.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp17.InnerTypeLazy = () => Object;
			RootScope_BuiltInEntries.Annotations.AddLazy(() => __tmp16);
			RootScope_BuiltInEntries.TypeLazy = () => __tmp17;
			RootScope_BuiltInEntries.Name = "BuiltInEntries";
			RootScope_BuiltInEntries.Documentation = null;
			// RootScope_BuiltInEntries.Kind = null;
			RootScope_BuiltInEntries.ClassLazy = () => RootScope;
			__tmp18.Name = "ScopeEntry";
			__tmp18.Documentation = null;
			__tmp19.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp19.InnerTypeLazy = () => Object;
			RootScope_Entries.Annotations.AddLazy(() => __tmp18);
			RootScope_Entries.TypeLazy = () => __tmp19;
			RootScope_Entries.Name = "Entries";
			RootScope_Entries.Documentation = null;
			RootScope_Entries.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			RootScope_Entries.ClassLazy = () => RootScope;
			MetaAnnotatedElement.MetaModelLazy = () => __tmp4;
			MetaAnnotatedElement.NamespaceLazy = () => __tmp3;
			MetaAnnotatedElement.Documentation = "Represents an annotated element.";
			MetaAnnotatedElement.Name = "MetaAnnotatedElement";
			MetaAnnotatedElement.IsAbstract = true;
			MetaAnnotatedElement.Properties.AddLazy(() => MetaAnnotatedElement_Annotations);
			// MetaAnnotatedElement.Constructor = null;
			__tmp20.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp20.InnerTypeLazy = () => MetaAnnotation;
			MetaAnnotatedElement_Annotations.TypeLazy = () => __tmp20;
			MetaAnnotatedElement_Annotations.Name = "Annotations";
			MetaAnnotatedElement_Annotations.Documentation = "List of annotations";
			MetaAnnotatedElement_Annotations.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaAnnotatedElement_Annotations.ClassLazy = () => MetaAnnotatedElement;
			MetaDocumentedElement.MetaModelLazy = () => __tmp4;
			MetaDocumentedElement.NamespaceLazy = () => __tmp3;
			MetaDocumentedElement.Documentation = null;
			MetaDocumentedElement.Name = "MetaDocumentedElement";
			MetaDocumentedElement.IsAbstract = true;
			MetaDocumentedElement.Properties.AddLazy(() => MetaDocumentedElement_Documentation);
			MetaDocumentedElement.Operations.AddLazy(() => __tmp22);
			// MetaDocumentedElement.Constructor = null;
			MetaDocumentedElement_Documentation.TypeLazy = () => String;
			MetaDocumentedElement_Documentation.Name = "Documentation";
			MetaDocumentedElement_Documentation.Documentation = null;
			// MetaDocumentedElement_Documentation.Kind = null;
			MetaDocumentedElement_Documentation.ClassLazy = () => MetaDocumentedElement;
			__tmp21.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp21.InnerTypeLazy = () => String;
			__tmp22.ReturnTypeLazy = () => __tmp21;
			// TODO: __tmp22.Type
			// TODO: __tmp22.Type
			__tmp22.Documentation = null;
			__tmp22.Name = "GetDocumentationLines";
			__tmp22.ParentLazy = () => MetaDocumentedElement;
			MetaNamedElement.MetaModelLazy = () => __tmp4;
			MetaNamedElement.NamespaceLazy = () => __tmp3;
			MetaNamedElement.Documentation = null;
			MetaNamedElement.Name = "MetaNamedElement";
			MetaNamedElement.IsAbstract = true;
			MetaNamedElement.SuperClasses.AddLazy(() => MetaDocumentedElement);
			MetaNamedElement.Properties.AddLazy(() => MetaNamedElement_Name);
			// MetaNamedElement.Constructor = null;
			__tmp23.Name = "Name";
			__tmp23.Documentation = null;
			MetaNamedElement_Name.Annotations.AddLazy(() => __tmp23);
			MetaNamedElement_Name.TypeLazy = () => String;
			MetaNamedElement_Name.Name = "Name";
			MetaNamedElement_Name.Documentation = null;
			// MetaNamedElement_Name.Kind = null;
			MetaNamedElement_Name.ClassLazy = () => MetaNamedElement;
			MetaTypedElement.MetaModelLazy = () => __tmp4;
			MetaTypedElement.NamespaceLazy = () => __tmp3;
			MetaTypedElement.Documentation = null;
			MetaTypedElement.Name = "MetaTypedElement";
			MetaTypedElement.IsAbstract = true;
			MetaTypedElement.Properties.AddLazy(() => MetaTypedElement_Type);
			// MetaTypedElement.Constructor = null;
			__tmp24.Name = "Type";
			__tmp24.Documentation = null;
			MetaTypedElement_Type.Annotations.AddLazy(() => __tmp24);
			MetaTypedElement_Type.TypeLazy = () => MetaType;
			MetaTypedElement_Type.Name = "Type";
			MetaTypedElement_Type.Documentation = null;
			// MetaTypedElement_Type.Kind = null;
			MetaTypedElement_Type.ClassLazy = () => MetaTypedElement;
			MetaTypedElement_Type.RedefiningProperties.AddLazy(() => MetaEnumLiteral_Enum);
			MetaTypedElement_Type.RedefiningProperties.AddLazy(() => MetaFunction_Type);
			__tmp25.Name = "Type";
			__tmp25.Documentation = null;
			MetaType.MetaModelLazy = () => __tmp4;
			MetaType.NamespaceLazy = () => __tmp3;
			MetaType.Documentation = null;
			MetaType.Name = "MetaType";
			MetaType.Annotations.AddLazy(() => __tmp25);
			MetaType.IsAbstract = true;
			// MetaType.Constructor = null;
			MetaAnnotation.MetaModelLazy = () => __tmp4;
			MetaAnnotation.NamespaceLazy = () => __tmp3;
			MetaAnnotation.Documentation = null;
			MetaAnnotation.Name = "MetaAnnotation";
			// MetaAnnotation.IsAbstract = null;
			MetaAnnotation.SuperClasses.AddLazy(() => MetaNamedElement);
			// MetaAnnotation.Constructor = null;
			__tmp26.Name = "Scope";
			__tmp26.Documentation = null;
			MetaNamespace.MetaModelLazy = () => __tmp4;
			MetaNamespace.NamespaceLazy = () => __tmp3;
			MetaNamespace.Documentation = null;
			MetaNamespace.Name = "MetaNamespace";
			MetaNamespace.Annotations.AddLazy(() => __tmp26);
			// MetaNamespace.IsAbstract = null;
			MetaNamespace.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaNamespace.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Parent);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Usings);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_MetaModel);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Namespaces);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_Declarations);
			// MetaNamespace.Constructor = null;
			MetaNamespace_Parent.TypeLazy = () => MetaNamespace;
			MetaNamespace_Parent.Name = "Parent";
			MetaNamespace_Parent.Documentation = null;
			// MetaNamespace_Parent.Kind = null;
			MetaNamespace_Parent.ClassLazy = () => MetaNamespace;
			MetaNamespace_Parent.OppositeProperties.AddLazy(() => MetaNamespace_Namespaces);
			__tmp27.Name = "ImportedScope";
			__tmp27.Documentation = null;
			__tmp28.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp28.InnerTypeLazy = () => MetaNamespace;
			MetaNamespace_Usings.Annotations.AddLazy(() => __tmp27);
			MetaNamespace_Usings.TypeLazy = () => __tmp28;
			MetaNamespace_Usings.Name = "Usings";
			MetaNamespace_Usings.Documentation = null;
			// MetaNamespace_Usings.Kind = null;
			MetaNamespace_Usings.ClassLazy = () => MetaNamespace;
			MetaNamespace_MetaModel.TypeLazy = () => MetaModel;
			MetaNamespace_MetaModel.Name = "MetaModel";
			MetaNamespace_MetaModel.Documentation = null;
			MetaNamespace_MetaModel.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaNamespace_MetaModel.ClassLazy = () => MetaNamespace;
			MetaNamespace_MetaModel.OppositeProperties.AddLazy(() => MetaModel_Namespace);
			__tmp29.Name = "ScopeEntry";
			__tmp29.Documentation = null;
			__tmp30.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp30.InnerTypeLazy = () => MetaNamespace;
			MetaNamespace_Namespaces.Annotations.AddLazy(() => __tmp29);
			MetaNamespace_Namespaces.TypeLazy = () => __tmp30;
			MetaNamespace_Namespaces.Name = "Namespaces";
			MetaNamespace_Namespaces.Documentation = null;
			MetaNamespace_Namespaces.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaNamespace_Namespaces.ClassLazy = () => MetaNamespace;
			MetaNamespace_Namespaces.OppositeProperties.AddLazy(() => MetaNamespace_Parent);
			__tmp31.Name = "ScopeEntry";
			__tmp31.Documentation = null;
			__tmp32.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp32.InnerTypeLazy = () => MetaDeclaration;
			MetaNamespace_Declarations.Annotations.AddLazy(() => __tmp31);
			MetaNamespace_Declarations.TypeLazy = () => __tmp32;
			MetaNamespace_Declarations.Name = "Declarations";
			MetaNamespace_Declarations.Documentation = null;
			MetaNamespace_Declarations.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaNamespace_Declarations.ClassLazy = () => MetaNamespace;
			MetaNamespace_Declarations.OppositeProperties.AddLazy(() => MetaDeclaration_Namespace);
			MetaDeclaration.MetaModelLazy = () => __tmp4;
			MetaDeclaration.NamespaceLazy = () => __tmp3;
			MetaDeclaration.Documentation = null;
			MetaDeclaration.Name = "MetaDeclaration";
			MetaDeclaration.IsAbstract = true;
			MetaDeclaration.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_Namespace);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_MetaModel);
			// MetaDeclaration.Constructor = null;
			MetaDeclaration_Namespace.TypeLazy = () => MetaNamespace;
			MetaDeclaration_Namespace.Name = "Namespace";
			MetaDeclaration_Namespace.Documentation = null;
			// MetaDeclaration_Namespace.Kind = null;
			MetaDeclaration_Namespace.ClassLazy = () => MetaDeclaration;
			MetaDeclaration_Namespace.OppositeProperties.AddLazy(() => MetaNamespace_Declarations);
			MetaDeclaration_MetaModel.TypeLazy = () => MetaModel;
			MetaDeclaration_MetaModel.Name = "MetaModel";
			MetaDeclaration_MetaModel.Documentation = null;
			MetaDeclaration_MetaModel.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Derived;
			MetaDeclaration_MetaModel.ClassLazy = () => MetaDeclaration;
			MetaModel.MetaModelLazy = () => __tmp4;
			MetaModel.NamespaceLazy = () => __tmp3;
			MetaModel.Documentation = null;
			MetaModel.Name = "MetaModel";
			// MetaModel.IsAbstract = null;
			MetaModel.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaModel.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaModel.Properties.AddLazy(() => MetaModel_Uri);
			MetaModel.Properties.AddLazy(() => MetaModel_Namespace);
			// MetaModel.Constructor = null;
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
			MetaCollectionKind.MetaModelLazy = () => __tmp4;
			MetaCollectionKind.NamespaceLazy = () => __tmp3;
			MetaCollectionKind.Documentation = null;
			MetaCollectionKind.Name = "MetaCollectionKind";
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp33);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp34);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp35);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp36);
			__tmp33.TypeLazy = () => MetaCollectionKind;
			__tmp33.Name = "List";
			__tmp33.Documentation = null;
			__tmp33.EnumLazy = () => MetaCollectionKind;
			__tmp34.TypeLazy = () => MetaCollectionKind;
			__tmp34.Name = "Set";
			__tmp34.Documentation = null;
			__tmp34.EnumLazy = () => MetaCollectionKind;
			__tmp35.TypeLazy = () => MetaCollectionKind;
			__tmp35.Name = "MultiList";
			__tmp35.Documentation = null;
			__tmp35.EnumLazy = () => MetaCollectionKind;
			__tmp36.TypeLazy = () => MetaCollectionKind;
			__tmp36.Name = "MultiSet";
			__tmp36.Documentation = null;
			__tmp36.EnumLazy = () => MetaCollectionKind;
			MetaCollectionType.MetaModelLazy = () => __tmp4;
			MetaCollectionType.NamespaceLazy = () => __tmp3;
			MetaCollectionType.Documentation = null;
			MetaCollectionType.Name = "MetaCollectionType";
			// MetaCollectionType.IsAbstract = null;
			MetaCollectionType.SuperClasses.AddLazy(() => MetaType);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_Kind);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_InnerType);
			// MetaCollectionType.Constructor = null;
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
			MetaNullableType.MetaModelLazy = () => __tmp4;
			MetaNullableType.NamespaceLazy = () => __tmp3;
			MetaNullableType.Documentation = null;
			MetaNullableType.Name = "MetaNullableType";
			// MetaNullableType.IsAbstract = null;
			MetaNullableType.SuperClasses.AddLazy(() => MetaType);
			MetaNullableType.Properties.AddLazy(() => MetaNullableType_InnerType);
			// MetaNullableType.Constructor = null;
			MetaNullableType_InnerType.TypeLazy = () => MetaType;
			MetaNullableType_InnerType.Name = "InnerType";
			MetaNullableType_InnerType.Documentation = null;
			// MetaNullableType_InnerType.Kind = null;
			MetaNullableType_InnerType.ClassLazy = () => MetaNullableType;
			MetaPrimitiveType.MetaModelLazy = () => __tmp4;
			MetaPrimitiveType.NamespaceLazy = () => __tmp3;
			MetaPrimitiveType.Documentation = null;
			MetaPrimitiveType.Name = "MetaPrimitiveType";
			// MetaPrimitiveType.IsAbstract = null;
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaType);
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaNamedElement);
			// MetaPrimitiveType.Constructor = null;
			__tmp37.Name = "Scope";
			__tmp37.Documentation = null;
			MetaEnum.MetaModelLazy = () => __tmp4;
			MetaEnum.NamespaceLazy = () => __tmp3;
			MetaEnum.Documentation = null;
			MetaEnum.Name = "MetaEnum";
			MetaEnum.Annotations.AddLazy(() => __tmp37);
			// MetaEnum.IsAbstract = null;
			MetaEnum.SuperClasses.AddLazy(() => MetaType);
			MetaEnum.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaEnum.Properties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnum.Properties.AddLazy(() => MetaEnum_Operations);
			// MetaEnum.Constructor = null;
			__tmp38.Name = "ScopeEntry";
			__tmp38.Documentation = null;
			__tmp39.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp39.InnerTypeLazy = () => MetaEnumLiteral;
			MetaEnum_EnumLiterals.Annotations.AddLazy(() => __tmp38);
			MetaEnum_EnumLiterals.TypeLazy = () => __tmp39;
			MetaEnum_EnumLiterals.Name = "EnumLiterals";
			MetaEnum_EnumLiterals.Documentation = null;
			MetaEnum_EnumLiterals.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaEnum_EnumLiterals.ClassLazy = () => MetaEnum;
			MetaEnum_EnumLiterals.OppositeProperties.AddLazy(() => MetaEnumLiteral_Enum);
			__tmp40.Name = "ScopeEntry";
			__tmp40.Documentation = null;
			__tmp41.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp41.InnerTypeLazy = () => MetaOperation;
			MetaEnum_Operations.Annotations.AddLazy(() => __tmp40);
			MetaEnum_Operations.TypeLazy = () => __tmp41;
			MetaEnum_Operations.Name = "Operations";
			MetaEnum_Operations.Documentation = null;
			MetaEnum_Operations.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaEnum_Operations.ClassLazy = () => MetaEnum;
			MetaEnum_Operations.OppositeProperties.AddLazy(() => MetaOperation_Parent);
			MetaEnumLiteral.MetaModelLazy = () => __tmp4;
			MetaEnumLiteral.NamespaceLazy = () => __tmp3;
			MetaEnumLiteral.Documentation = null;
			MetaEnumLiteral.Name = "MetaEnumLiteral";
			// MetaEnumLiteral.IsAbstract = null;
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaEnumLiteral.Properties.AddLazy(() => MetaEnumLiteral_Enum);
			// MetaEnumLiteral.Constructor = null;
			MetaEnumLiteral_Enum.TypeLazy = () => MetaEnum;
			MetaEnumLiteral_Enum.Name = "Enum";
			MetaEnumLiteral_Enum.Documentation = null;
			// MetaEnumLiteral_Enum.Kind = null;
			MetaEnumLiteral_Enum.ClassLazy = () => MetaEnumLiteral;
			MetaEnumLiteral_Enum.OppositeProperties.AddLazy(() => MetaEnum_EnumLiterals);
			MetaEnumLiteral_Enum.RedefinedProperties.AddLazy(() => MetaTypedElement_Type);
			MetaConstant.MetaModelLazy = () => __tmp4;
			MetaConstant.NamespaceLazy = () => __tmp3;
			MetaConstant.Documentation = null;
			MetaConstant.Name = "MetaConstant";
			// MetaConstant.IsAbstract = null;
			MetaConstant.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaConstant.SuperClasses.AddLazy(() => MetaDeclaration);
			// MetaConstant.Constructor = null;
			__tmp42.Name = "Scope";
			__tmp42.Documentation = null;
			MetaClass.MetaModelLazy = () => __tmp4;
			MetaClass.NamespaceLazy = () => __tmp3;
			MetaClass.Documentation = null;
			MetaClass.Name = "MetaClass";
			MetaClass.Annotations.AddLazy(() => __tmp42);
			// MetaClass.IsAbstract = null;
			MetaClass.SuperClasses.AddLazy(() => MetaType);
			MetaClass.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaClass.Properties.AddLazy(() => MetaClass_IsAbstract);
			MetaClass.Properties.AddLazy(() => MetaClass_SuperClasses);
			MetaClass.Properties.AddLazy(() => MetaClass_Properties);
			MetaClass.Properties.AddLazy(() => MetaClass_Operations);
			MetaClass.Properties.AddLazy(() => MetaClass_Constructor);
			MetaClass.Operations.AddLazy(() => __tmp50);
			MetaClass.Operations.AddLazy(() => __tmp53);
			MetaClass.Operations.AddLazy(() => __tmp56);
			MetaClass.Operations.AddLazy(() => __tmp59);
			MetaClass.Operations.AddLazy(() => __tmp61);
			MetaClass.Operations.AddLazy(() => __tmp63);
			MetaClass.Operations.AddLazy(() => __tmp65);
			// MetaClass.Constructor = null;
			MetaClass_IsAbstract.TypeLazy = () => Bool;
			MetaClass_IsAbstract.Name = "IsAbstract";
			MetaClass_IsAbstract.Documentation = null;
			// MetaClass_IsAbstract.Kind = null;
			MetaClass_IsAbstract.ClassLazy = () => MetaClass;
			__tmp43.Name = "InheritedScope";
			__tmp43.Documentation = null;
			__tmp44.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp44.InnerTypeLazy = () => MetaClass;
			MetaClass_SuperClasses.Annotations.AddLazy(() => __tmp43);
			MetaClass_SuperClasses.TypeLazy = () => __tmp44;
			MetaClass_SuperClasses.Name = "SuperClasses";
			MetaClass_SuperClasses.Documentation = null;
			// MetaClass_SuperClasses.Kind = null;
			MetaClass_SuperClasses.ClassLazy = () => MetaClass;
			__tmp45.Name = "ScopeEntry";
			__tmp45.Documentation = null;
			__tmp46.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp46.InnerTypeLazy = () => MetaProperty;
			MetaClass_Properties.Annotations.AddLazy(() => __tmp45);
			MetaClass_Properties.TypeLazy = () => __tmp46;
			MetaClass_Properties.Name = "Properties";
			MetaClass_Properties.Documentation = null;
			MetaClass_Properties.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaClass_Properties.ClassLazy = () => MetaClass;
			MetaClass_Properties.OppositeProperties.AddLazy(() => MetaProperty_Class);
			__tmp47.Name = "ScopeEntry";
			__tmp47.Documentation = null;
			__tmp48.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp48.InnerTypeLazy = () => MetaOperation;
			MetaClass_Operations.Annotations.AddLazy(() => __tmp47);
			MetaClass_Operations.TypeLazy = () => __tmp48;
			MetaClass_Operations.Name = "Operations";
			MetaClass_Operations.Documentation = null;
			MetaClass_Operations.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaClass_Operations.ClassLazy = () => MetaClass;
			MetaClass_Operations.OppositeProperties.AddLazy(() => MetaOperation_Parent);
			MetaClass_Constructor.TypeLazy = () => MetaConstructor;
			MetaClass_Constructor.Name = "Constructor";
			MetaClass_Constructor.Documentation = null;
			MetaClass_Constructor.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaClass_Constructor.ClassLazy = () => MetaClass;
			MetaClass_Constructor.OppositeProperties.AddLazy(() => MetaConstructor_Parent);
			__tmp49.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp49.InnerTypeLazy = () => MetaClass;
			__tmp50.ReturnTypeLazy = () => __tmp49;
			__tmp50.Parameters.AddLazy(() => __tmp51);
			// TODO: __tmp50.Type
			// TODO: __tmp50.Type
			__tmp50.Documentation = null;
			__tmp50.Name = "GetAllSuperClasses";
			__tmp50.ParentLazy = () => MetaClass;
			__tmp51.TypeLazy = () => Bool;
			__tmp51.Name = "includeSelf";
			__tmp51.Documentation = null;
			__tmp51.FunctionLazy = () => __tmp50;
			__tmp52.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp52.InnerTypeLazy = () => MetaProperty;
			__tmp53.ReturnTypeLazy = () => __tmp52;
			__tmp53.Parameters.AddLazy(() => __tmp54);
			// TODO: __tmp53.Type
			// TODO: __tmp53.Type
			__tmp53.Documentation = null;
			__tmp53.Name = "GetAllSuperProperties";
			__tmp53.ParentLazy = () => MetaClass;
			__tmp54.TypeLazy = () => Bool;
			__tmp54.Name = "includeSelf";
			__tmp54.Documentation = null;
			__tmp54.FunctionLazy = () => __tmp53;
			__tmp55.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp55.InnerTypeLazy = () => MetaOperation;
			__tmp56.ReturnTypeLazy = () => __tmp55;
			__tmp56.Parameters.AddLazy(() => __tmp57);
			// TODO: __tmp56.Type
			// TODO: __tmp56.Type
			__tmp56.Documentation = null;
			__tmp56.Name = "GetAllSuperOperations";
			__tmp56.ParentLazy = () => MetaClass;
			__tmp57.TypeLazy = () => Bool;
			__tmp57.Name = "includeSelf";
			__tmp57.Documentation = null;
			__tmp57.FunctionLazy = () => __tmp56;
			__tmp58.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp58.InnerTypeLazy = () => MetaProperty;
			__tmp59.ReturnTypeLazy = () => __tmp58;
			// TODO: __tmp59.Type
			// TODO: __tmp59.Type
			__tmp59.Documentation = null;
			__tmp59.Name = "GetAllProperties";
			__tmp59.ParentLazy = () => MetaClass;
			__tmp60.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp60.InnerTypeLazy = () => MetaOperation;
			__tmp61.ReturnTypeLazy = () => __tmp60;
			// TODO: __tmp61.Type
			// TODO: __tmp61.Type
			__tmp61.Documentation = null;
			__tmp61.Name = "GetAllOperations";
			__tmp61.ParentLazy = () => MetaClass;
			__tmp62.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp62.InnerTypeLazy = () => MetaProperty;
			__tmp63.ReturnTypeLazy = () => __tmp62;
			// TODO: __tmp63.Type
			// TODO: __tmp63.Type
			__tmp63.Documentation = null;
			__tmp63.Name = "GetAllFinalProperties";
			__tmp63.ParentLazy = () => MetaClass;
			__tmp64.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp64.InnerTypeLazy = () => MetaOperation;
			__tmp65.ReturnTypeLazy = () => __tmp64;
			// TODO: __tmp65.Type
			// TODO: __tmp65.Type
			__tmp65.Documentation = null;
			__tmp65.Name = "GetAllFinalOperations";
			__tmp65.ParentLazy = () => MetaClass;
			MetaFunctionType.MetaModelLazy = () => __tmp4;
			MetaFunctionType.NamespaceLazy = () => __tmp3;
			MetaFunctionType.Documentation = null;
			MetaFunctionType.Name = "MetaFunctionType";
			// MetaFunctionType.IsAbstract = null;
			MetaFunctionType.SuperClasses.AddLazy(() => MetaType);
			MetaFunctionType.Properties.AddLazy(() => MetaFunctionType_ParameterTypes);
			MetaFunctionType.Properties.AddLazy(() => MetaFunctionType_ReturnType);
			// MetaFunctionType.Constructor = null;
			__tmp66.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.MultiList;
			__tmp66.InnerTypeLazy = () => MetaType;
			MetaFunctionType_ParameterTypes.TypeLazy = () => __tmp66;
			MetaFunctionType_ParameterTypes.Name = "ParameterTypes";
			MetaFunctionType_ParameterTypes.Documentation = null;
			// MetaFunctionType_ParameterTypes.Kind = null;
			MetaFunctionType_ParameterTypes.ClassLazy = () => MetaFunctionType;
			MetaFunctionType_ReturnType.TypeLazy = () => MetaType;
			MetaFunctionType_ReturnType.Name = "ReturnType";
			MetaFunctionType_ReturnType.Documentation = null;
			// MetaFunctionType_ReturnType.Kind = null;
			MetaFunctionType_ReturnType.ClassLazy = () => MetaFunctionType;
			MetaFunction.MetaModelLazy = () => __tmp4;
			MetaFunction.NamespaceLazy = () => __tmp3;
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
			__tmp67.Name = "Type";
			__tmp67.Documentation = null;
			MetaFunction_Type.Annotations.AddLazy(() => __tmp67);
			MetaFunction_Type.TypeLazy = () => MetaFunctionType;
			MetaFunction_Type.Name = "Type";
			MetaFunction_Type.Documentation = null;
			MetaFunction_Type.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Derived;
			MetaFunction_Type.ClassLazy = () => MetaFunction;
			MetaFunction_Type.RedefinedProperties.AddLazy(() => MetaTypedElement_Type);
			__tmp68.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp68.InnerTypeLazy = () => MetaParameter;
			MetaFunction_Parameters.TypeLazy = () => __tmp68;
			MetaFunction_Parameters.Name = "Parameters";
			MetaFunction_Parameters.Documentation = null;
			MetaFunction_Parameters.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaFunction_Parameters.ClassLazy = () => MetaFunction;
			MetaFunction_Parameters.OppositeProperties.AddLazy(() => MetaParameter_Function);
			MetaFunction_ReturnType.TypeLazy = () => MetaType;
			MetaFunction_ReturnType.Name = "ReturnType";
			MetaFunction_ReturnType.Documentation = null;
			// MetaFunction_ReturnType.Kind = null;
			MetaFunction_ReturnType.ClassLazy = () => MetaFunction;
			MetaOperation.MetaModelLazy = () => __tmp4;
			MetaOperation.NamespaceLazy = () => __tmp3;
			MetaOperation.Documentation = null;
			MetaOperation.Name = "MetaOperation";
			// MetaOperation.IsAbstract = null;
			MetaOperation.SuperClasses.AddLazy(() => MetaFunction);
			MetaOperation.Properties.AddLazy(() => MetaOperation_Parent);
			// MetaOperation.Constructor = null;
			MetaOperation_Parent.TypeLazy = () => MetaType;
			MetaOperation_Parent.Name = "Parent";
			MetaOperation_Parent.Documentation = null;
			// MetaOperation_Parent.Kind = null;
			MetaOperation_Parent.ClassLazy = () => MetaOperation;
			MetaOperation_Parent.OppositeProperties.AddLazy(() => MetaClass_Operations);
			MetaOperation_Parent.OppositeProperties.AddLazy(() => MetaEnum_Operations);
			MetaConstructor.MetaModelLazy = () => __tmp4;
			MetaConstructor.NamespaceLazy = () => __tmp3;
			MetaConstructor.Documentation = null;
			MetaConstructor.Name = "MetaConstructor";
			// MetaConstructor.IsAbstract = null;
			MetaConstructor.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaConstructor.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaConstructor.Properties.AddLazy(() => MetaConstructor_Parent);
			// MetaConstructor.Constructor = null;
			MetaConstructor_Parent.TypeLazy = () => MetaClass;
			MetaConstructor_Parent.Name = "Parent";
			MetaConstructor_Parent.Documentation = null;
			// MetaConstructor_Parent.Kind = null;
			MetaConstructor_Parent.ClassLazy = () => MetaConstructor;
			MetaConstructor_Parent.OppositeProperties.AddLazy(() => MetaClass_Constructor);
			MetaParameter.MetaModelLazy = () => __tmp4;
			MetaParameter.NamespaceLazy = () => __tmp3;
			MetaParameter.Documentation = null;
			MetaParameter.Name = "MetaParameter";
			// MetaParameter.IsAbstract = null;
			MetaParameter.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaParameter.Properties.AddLazy(() => MetaParameter_Function);
			// MetaParameter.Constructor = null;
			MetaParameter_Function.TypeLazy = () => MetaFunction;
			MetaParameter_Function.Name = "Function";
			MetaParameter_Function.Documentation = null;
			// MetaParameter_Function.Kind = null;
			MetaParameter_Function.ClassLazy = () => MetaParameter;
			MetaParameter_Function.OppositeProperties.AddLazy(() => MetaFunction_Parameters);
			MetaPropertyKind.MetaModelLazy = () => __tmp4;
			MetaPropertyKind.NamespaceLazy = () => __tmp3;
			MetaPropertyKind.Documentation = null;
			MetaPropertyKind.Name = "MetaPropertyKind";
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp69);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp70);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp71);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp72);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp73);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp74);
			__tmp69.TypeLazy = () => MetaPropertyKind;
			__tmp69.Name = "Normal";
			__tmp69.Documentation = null;
			__tmp69.EnumLazy = () => MetaPropertyKind;
			__tmp70.TypeLazy = () => MetaPropertyKind;
			__tmp70.Name = "Readonly";
			__tmp70.Documentation = null;
			__tmp70.EnumLazy = () => MetaPropertyKind;
			__tmp71.TypeLazy = () => MetaPropertyKind;
			__tmp71.Name = "Lazy";
			__tmp71.Documentation = null;
			__tmp71.EnumLazy = () => MetaPropertyKind;
			__tmp72.TypeLazy = () => MetaPropertyKind;
			__tmp72.Name = "Derived";
			__tmp72.Documentation = null;
			__tmp72.EnumLazy = () => MetaPropertyKind;
			__tmp73.TypeLazy = () => MetaPropertyKind;
			__tmp73.Name = "DerivedUnion";
			__tmp73.Documentation = null;
			__tmp73.EnumLazy = () => MetaPropertyKind;
			__tmp74.TypeLazy = () => MetaPropertyKind;
			__tmp74.Name = "Containment";
			__tmp74.Documentation = null;
			__tmp74.EnumLazy = () => MetaPropertyKind;
			MetaProperty.MetaModelLazy = () => __tmp4;
			MetaProperty.NamespaceLazy = () => __tmp3;
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
			__tmp75.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp75.InnerTypeLazy = () => MetaProperty;
			MetaProperty_OppositeProperties.TypeLazy = () => __tmp75;
			MetaProperty_OppositeProperties.Name = "OppositeProperties";
			MetaProperty_OppositeProperties.Documentation = null;
			// MetaProperty_OppositeProperties.Kind = null;
			MetaProperty_OppositeProperties.ClassLazy = () => MetaProperty;
			MetaProperty_OppositeProperties.OppositeProperties.AddLazy(() => MetaProperty_OppositeProperties);
			__tmp76.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp76.InnerTypeLazy = () => MetaProperty;
			MetaProperty_SubsettedProperties.TypeLazy = () => __tmp76;
			MetaProperty_SubsettedProperties.Name = "SubsettedProperties";
			MetaProperty_SubsettedProperties.Documentation = null;
			// MetaProperty_SubsettedProperties.Kind = null;
			MetaProperty_SubsettedProperties.ClassLazy = () => MetaProperty;
			MetaProperty_SubsettedProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettingProperties);
			__tmp77.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp77.InnerTypeLazy = () => MetaProperty;
			MetaProperty_SubsettingProperties.TypeLazy = () => __tmp77;
			MetaProperty_SubsettingProperties.Name = "SubsettingProperties";
			MetaProperty_SubsettingProperties.Documentation = null;
			// MetaProperty_SubsettingProperties.Kind = null;
			MetaProperty_SubsettingProperties.ClassLazy = () => MetaProperty;
			MetaProperty_SubsettingProperties.OppositeProperties.AddLazy(() => MetaProperty_SubsettedProperties);
			__tmp78.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp78.InnerTypeLazy = () => MetaProperty;
			MetaProperty_RedefinedProperties.TypeLazy = () => __tmp78;
			MetaProperty_RedefinedProperties.Name = "RedefinedProperties";
			MetaProperty_RedefinedProperties.Documentation = null;
			// MetaProperty_RedefinedProperties.Kind = null;
			MetaProperty_RedefinedProperties.ClassLazy = () => MetaProperty;
			MetaProperty_RedefinedProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefiningProperties);
			__tmp79.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp79.InnerTypeLazy = () => MetaProperty;
			MetaProperty_RedefiningProperties.TypeLazy = () => __tmp79;
			MetaProperty_RedefiningProperties.Name = "RedefiningProperties";
			MetaProperty_RedefiningProperties.Documentation = null;
			// MetaProperty_RedefiningProperties.Kind = null;
			MetaProperty_RedefiningProperties.ClassLazy = () => MetaProperty;
			MetaProperty_RedefiningProperties.OppositeProperties.AddLazy(() => MetaProperty_RedefinedProperties);
	
			foreach (MutableSymbolBase symbol in this.Model.Symbols)
			{
				symbol.MMakeCreated();
			}
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.Core.Immutable.Internal.MetaImplementation to provide custom
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
		/// Implements the constructor: RootScope()
		/// </summary>
		public virtual void RootScope(RootScopeBuilder _this)
		{
			this.CallRootScopeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of RootScope
		/// </summary>
		protected virtual void CallRootScopeSuperConstructors(RootScopeBuilder _this)
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
		public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement_GetDocumentationLines(MetaDocumentedElement _this)
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
		///     <li>MetaNamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>MetaDocumentedElement</li>
		///     <li>MetaNamedElement</li>
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
			this.MetaNamedElement(_this);
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
		public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperProperties()
		/// </summary>
		public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> MetaClass_GetAllSuperProperties(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllSuperOperations()
		/// </summary>
		public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> MetaClass_GetAllSuperOperations(MetaClass _this, bool includeSelf)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllProperties()
		/// </summary>
		public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> MetaClass_GetAllProperties(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllOperations()
		/// </summary>
		public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> MetaClass_GetAllOperations(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllFinalProperties()
		/// </summary>
		public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<MetaProperty> MetaClass_GetAllFinalProperties(MetaClass _this)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: MetaClass.GetAllFinalOperations()
		/// </summary>
		public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<MetaOperation> MetaClass_GetAllFinalOperations(MetaClass _this)
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
		// which is a subclass of global::MetaDslx.Core.Immutable.Internal.MetaImplementationBase:
		private static MetaImplementation implementation = new MetaImplementation();
	
		public static MetaImplementation Implementation
		{
			get { return implementation; }
		}
	}
}

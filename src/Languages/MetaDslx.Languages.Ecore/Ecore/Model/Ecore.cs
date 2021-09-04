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

namespace MetaDslx.Languages.Ecore.Model
{
	using global::MetaDslx.Languages.Ecore.Model.Internal;

	internal class EcoreMetaModel : global::MetaDslx.Modeling.IMetaModel
	{
		internal EcoreMetaModel()
		{
		}
	
		public global::MetaDslx.Modeling.ModelId Id => EcoreInstance.MModel.Id;
		public string Name => "Ecore";
		public global::MetaDslx.Modeling.ModelVersion Version => EcoreInstance.MModel.Version;
		public global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> Objects => EcoreInstance.MModel.Objects;
		public string Uri => "http://www.eclipse.org/emf/2002/Ecore";
		public string Prefix => "";
		public global::MetaDslx.Modeling.IModelGroup ModelGroup => EcoreInstance.MModel.ModelGroup;
		public string Namespace => "MetaDslx.Languages.Ecore.Model";
	
		public global::MetaDslx.Modeling.IModelFactory CreateFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
		{
			return new EcoreFactory(model, flags);
		}
	
	    public override string ToString()
	    {
	        return $"{Name} ({Version})";
	    }
	}

	public class EcoreInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return EcoreInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Modeling.IMetaModel MMetaModel;
		public static readonly global::MetaDslx.Modeling.ImmutableModel MModel;
	
		public static readonly EDataType EJavaObject;
		public static readonly EDataType EJavaClass;
		public static readonly EDataType EBoolean;
		public static readonly EDataType EString;
		public static readonly EDataType EByte;
		public static readonly EDataType EByteArray;
		public static readonly EDataType EChar;
		public static readonly EDataType EShort;
		public static readonly EDataType EInt;
		public static readonly EDataType ELong;
		public static readonly EDataType EFloat;
		public static readonly EDataType EDouble;
		public static readonly EDataType EByteObject;
		public static readonly EDataType ECharObject;
		public static readonly EDataType EShortObject;
		public static readonly EDataType EIntObject;
		public static readonly EDataType ELongObject;
		public static readonly EDataType EFloatObject;
		public static readonly EDataType EDoubleObject;
		public static readonly EDataType EDate;
		public static readonly EDataType EBigInteger;
		public static readonly EDataType EBigDecimal;
		public static readonly EDataType EResource;
		public static readonly EDataType EResourceSet;
		public static readonly EDataType EFeatureMap;
		public static readonly EDataType EFeatureMapEntry;
		public static readonly EDataType EEList;
		public static readonly EDataType EEnumerator;
		public static readonly EDataType ETreeIterator;
	
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EObject;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EModelElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EModelElement_EAnnotations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EFactory;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EFactory_EPackage;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ENamedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ENamedElement_Name;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EAnnotation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_EModelElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_Source;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_Details;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_Contents;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_References;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EStringToStringMapEntry;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStringToStringMapEntry_Key;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStringToStringMapEntry_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EPackage;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_NsURI;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_NsPrefix;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_ESuperPackage;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_ESubPackages;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_EClassifiers;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_EFactoryInstance;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EClassifier;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_InstanceClassName;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_EPackage;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_ETypeParameters;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_InstanceClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_DefaultValue;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_Abstract;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_Interface;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_ESuperTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllSuperTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EStructuralFeatures;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllStructuralFeatures;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EOperations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllOperation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EReferences;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllReferences;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllContainments;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAttributes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllAttributes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EIDAttribute;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EGenericSuperTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllGenericSuperTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EDataType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EDataType_Serializable;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EDataType_DotNetName;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EEnum;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnum_ELiterals;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EEnumLiteral;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnumLiteral_EEnum;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnumLiteral_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnumLiteral_Instance;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ETypedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_EType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_Ordered;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_Unique;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_LowerBound;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_UpperBound;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_Many;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_Required;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_EGenericType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EStructuralFeature;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_EContainingClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_EType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Changeable;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Volatile;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Transient;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_DefaultValueLiteral;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_DefaultValue;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Unsettable;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Derived;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EAttribute;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAttribute_ID;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAttribute_EAttributeType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EReference;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_Containment;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_Container;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_ResolveProxies;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_EOpposite;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_EReferenceType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EOperation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EContainingClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EParameters;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EExceptions;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_ETypeParameters;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EGenericExceptions;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EParameter;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EParameter_EOperation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EGenericType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_EClassifier;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_ERawType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_ETypeParameter;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_ELowerBound;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_EUpperBound;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_ETypeArguments;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ETypeParameter;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypeParameter_EGenericTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypeParameter_EBounds;
	
		static EcoreInstance()
		{
			EcoreBuilderInstance.instance.Create();
			EcoreBuilderInstance.instance.EvaluateLazyValues();
			MMetaModel = new EcoreMetaModel();
			MModel = EcoreBuilderInstance.instance.MModel.ToImmutable();
	
			EJavaObject = EcoreBuilderInstance.instance.EJavaObject.ToImmutable(MModel);
			EJavaClass = EcoreBuilderInstance.instance.EJavaClass.ToImmutable(MModel);
			EBoolean = EcoreBuilderInstance.instance.EBoolean.ToImmutable(MModel);
			EString = EcoreBuilderInstance.instance.EString.ToImmutable(MModel);
			EByte = EcoreBuilderInstance.instance.EByte.ToImmutable(MModel);
			EByteArray = EcoreBuilderInstance.instance.EByteArray.ToImmutable(MModel);
			EChar = EcoreBuilderInstance.instance.EChar.ToImmutable(MModel);
			EShort = EcoreBuilderInstance.instance.EShort.ToImmutable(MModel);
			EInt = EcoreBuilderInstance.instance.EInt.ToImmutable(MModel);
			ELong = EcoreBuilderInstance.instance.ELong.ToImmutable(MModel);
			EFloat = EcoreBuilderInstance.instance.EFloat.ToImmutable(MModel);
			EDouble = EcoreBuilderInstance.instance.EDouble.ToImmutable(MModel);
			EByteObject = EcoreBuilderInstance.instance.EByteObject.ToImmutable(MModel);
			ECharObject = EcoreBuilderInstance.instance.ECharObject.ToImmutable(MModel);
			EShortObject = EcoreBuilderInstance.instance.EShortObject.ToImmutable(MModel);
			EIntObject = EcoreBuilderInstance.instance.EIntObject.ToImmutable(MModel);
			ELongObject = EcoreBuilderInstance.instance.ELongObject.ToImmutable(MModel);
			EFloatObject = EcoreBuilderInstance.instance.EFloatObject.ToImmutable(MModel);
			EDoubleObject = EcoreBuilderInstance.instance.EDoubleObject.ToImmutable(MModel);
			EDate = EcoreBuilderInstance.instance.EDate.ToImmutable(MModel);
			EBigInteger = EcoreBuilderInstance.instance.EBigInteger.ToImmutable(MModel);
			EBigDecimal = EcoreBuilderInstance.instance.EBigDecimal.ToImmutable(MModel);
			EResource = EcoreBuilderInstance.instance.EResource.ToImmutable(MModel);
			EResourceSet = EcoreBuilderInstance.instance.EResourceSet.ToImmutable(MModel);
			EFeatureMap = EcoreBuilderInstance.instance.EFeatureMap.ToImmutable(MModel);
			EFeatureMapEntry = EcoreBuilderInstance.instance.EFeatureMapEntry.ToImmutable(MModel);
			EEList = EcoreBuilderInstance.instance.EEList.ToImmutable(MModel);
			EEnumerator = EcoreBuilderInstance.instance.EEnumerator.ToImmutable(MModel);
			ETreeIterator = EcoreBuilderInstance.instance.ETreeIterator.ToImmutable(MModel);
	
			EObject = EcoreBuilderInstance.instance.EObject.ToImmutable(MModel);
			EModelElement = EcoreBuilderInstance.instance.EModelElement.ToImmutable(MModel);
			EModelElement_EAnnotations = EcoreBuilderInstance.instance.EModelElement_EAnnotations.ToImmutable(MModel);
			EFactory = EcoreBuilderInstance.instance.EFactory.ToImmutable(MModel);
			EFactory_EPackage = EcoreBuilderInstance.instance.EFactory_EPackage.ToImmutable(MModel);
			ENamedElement = EcoreBuilderInstance.instance.ENamedElement.ToImmutable(MModel);
			ENamedElement_Name = EcoreBuilderInstance.instance.ENamedElement_Name.ToImmutable(MModel);
			EAnnotation = EcoreBuilderInstance.instance.EAnnotation.ToImmutable(MModel);
			EAnnotation_EModelElement = EcoreBuilderInstance.instance.EAnnotation_EModelElement.ToImmutable(MModel);
			EAnnotation_Source = EcoreBuilderInstance.instance.EAnnotation_Source.ToImmutable(MModel);
			EAnnotation_Details = EcoreBuilderInstance.instance.EAnnotation_Details.ToImmutable(MModel);
			EAnnotation_Contents = EcoreBuilderInstance.instance.EAnnotation_Contents.ToImmutable(MModel);
			EAnnotation_References = EcoreBuilderInstance.instance.EAnnotation_References.ToImmutable(MModel);
			EStringToStringMapEntry = EcoreBuilderInstance.instance.EStringToStringMapEntry.ToImmutable(MModel);
			EStringToStringMapEntry_Key = EcoreBuilderInstance.instance.EStringToStringMapEntry_Key.ToImmutable(MModel);
			EStringToStringMapEntry_Value = EcoreBuilderInstance.instance.EStringToStringMapEntry_Value.ToImmutable(MModel);
			EPackage = EcoreBuilderInstance.instance.EPackage.ToImmutable(MModel);
			EPackage_NsURI = EcoreBuilderInstance.instance.EPackage_NsURI.ToImmutable(MModel);
			EPackage_NsPrefix = EcoreBuilderInstance.instance.EPackage_NsPrefix.ToImmutable(MModel);
			EPackage_ESuperPackage = EcoreBuilderInstance.instance.EPackage_ESuperPackage.ToImmutable(MModel);
			EPackage_ESubPackages = EcoreBuilderInstance.instance.EPackage_ESubPackages.ToImmutable(MModel);
			EPackage_EClassifiers = EcoreBuilderInstance.instance.EPackage_EClassifiers.ToImmutable(MModel);
			EPackage_EFactoryInstance = EcoreBuilderInstance.instance.EPackage_EFactoryInstance.ToImmutable(MModel);
			EClassifier = EcoreBuilderInstance.instance.EClassifier.ToImmutable(MModel);
			EClassifier_InstanceClassName = EcoreBuilderInstance.instance.EClassifier_InstanceClassName.ToImmutable(MModel);
			EClassifier_EPackage = EcoreBuilderInstance.instance.EClassifier_EPackage.ToImmutable(MModel);
			EClassifier_ETypeParameters = EcoreBuilderInstance.instance.EClassifier_ETypeParameters.ToImmutable(MModel);
			EClassifier_InstanceClass = EcoreBuilderInstance.instance.EClassifier_InstanceClass.ToImmutable(MModel);
			EClassifier_DefaultValue = EcoreBuilderInstance.instance.EClassifier_DefaultValue.ToImmutable(MModel);
			EClass = EcoreBuilderInstance.instance.EClass.ToImmutable(MModel);
			EClass_Abstract = EcoreBuilderInstance.instance.EClass_Abstract.ToImmutable(MModel);
			EClass_Interface = EcoreBuilderInstance.instance.EClass_Interface.ToImmutable(MModel);
			EClass_ESuperTypes = EcoreBuilderInstance.instance.EClass_ESuperTypes.ToImmutable(MModel);
			EClass_EAllSuperTypes = EcoreBuilderInstance.instance.EClass_EAllSuperTypes.ToImmutable(MModel);
			EClass_EStructuralFeatures = EcoreBuilderInstance.instance.EClass_EStructuralFeatures.ToImmutable(MModel);
			EClass_EAllStructuralFeatures = EcoreBuilderInstance.instance.EClass_EAllStructuralFeatures.ToImmutable(MModel);
			EClass_EOperations = EcoreBuilderInstance.instance.EClass_EOperations.ToImmutable(MModel);
			EClass_EAllOperation = EcoreBuilderInstance.instance.EClass_EAllOperation.ToImmutable(MModel);
			EClass_EReferences = EcoreBuilderInstance.instance.EClass_EReferences.ToImmutable(MModel);
			EClass_EAllReferences = EcoreBuilderInstance.instance.EClass_EAllReferences.ToImmutable(MModel);
			EClass_EAllContainments = EcoreBuilderInstance.instance.EClass_EAllContainments.ToImmutable(MModel);
			EClass_EAttributes = EcoreBuilderInstance.instance.EClass_EAttributes.ToImmutable(MModel);
			EClass_EAllAttributes = EcoreBuilderInstance.instance.EClass_EAllAttributes.ToImmutable(MModel);
			EClass_EIDAttribute = EcoreBuilderInstance.instance.EClass_EIDAttribute.ToImmutable(MModel);
			EClass_EGenericSuperTypes = EcoreBuilderInstance.instance.EClass_EGenericSuperTypes.ToImmutable(MModel);
			EClass_EAllGenericSuperTypes = EcoreBuilderInstance.instance.EClass_EAllGenericSuperTypes.ToImmutable(MModel);
			EDataType = EcoreBuilderInstance.instance.EDataType.ToImmutable(MModel);
			EDataType_Serializable = EcoreBuilderInstance.instance.EDataType_Serializable.ToImmutable(MModel);
			EDataType_DotNetName = EcoreBuilderInstance.instance.EDataType_DotNetName.ToImmutable(MModel);
			EEnum = EcoreBuilderInstance.instance.EEnum.ToImmutable(MModel);
			EEnum_ELiterals = EcoreBuilderInstance.instance.EEnum_ELiterals.ToImmutable(MModel);
			EEnumLiteral = EcoreBuilderInstance.instance.EEnumLiteral.ToImmutable(MModel);
			EEnumLiteral_EEnum = EcoreBuilderInstance.instance.EEnumLiteral_EEnum.ToImmutable(MModel);
			EEnumLiteral_Value = EcoreBuilderInstance.instance.EEnumLiteral_Value.ToImmutable(MModel);
			EEnumLiteral_Instance = EcoreBuilderInstance.instance.EEnumLiteral_Instance.ToImmutable(MModel);
			ETypedElement = EcoreBuilderInstance.instance.ETypedElement.ToImmutable(MModel);
			ETypedElement_EType = EcoreBuilderInstance.instance.ETypedElement_EType.ToImmutable(MModel);
			ETypedElement_Ordered = EcoreBuilderInstance.instance.ETypedElement_Ordered.ToImmutable(MModel);
			ETypedElement_Unique = EcoreBuilderInstance.instance.ETypedElement_Unique.ToImmutable(MModel);
			ETypedElement_LowerBound = EcoreBuilderInstance.instance.ETypedElement_LowerBound.ToImmutable(MModel);
			ETypedElement_UpperBound = EcoreBuilderInstance.instance.ETypedElement_UpperBound.ToImmutable(MModel);
			ETypedElement_Many = EcoreBuilderInstance.instance.ETypedElement_Many.ToImmutable(MModel);
			ETypedElement_Required = EcoreBuilderInstance.instance.ETypedElement_Required.ToImmutable(MModel);
			ETypedElement_EGenericType = EcoreBuilderInstance.instance.ETypedElement_EGenericType.ToImmutable(MModel);
			EStructuralFeature = EcoreBuilderInstance.instance.EStructuralFeature.ToImmutable(MModel);
			EStructuralFeature_EContainingClass = EcoreBuilderInstance.instance.EStructuralFeature_EContainingClass.ToImmutable(MModel);
			EStructuralFeature_EType = EcoreBuilderInstance.instance.EStructuralFeature_EType.ToImmutable(MModel);
			EStructuralFeature_Changeable = EcoreBuilderInstance.instance.EStructuralFeature_Changeable.ToImmutable(MModel);
			EStructuralFeature_Volatile = EcoreBuilderInstance.instance.EStructuralFeature_Volatile.ToImmutable(MModel);
			EStructuralFeature_Transient = EcoreBuilderInstance.instance.EStructuralFeature_Transient.ToImmutable(MModel);
			EStructuralFeature_DefaultValueLiteral = EcoreBuilderInstance.instance.EStructuralFeature_DefaultValueLiteral.ToImmutable(MModel);
			EStructuralFeature_DefaultValue = EcoreBuilderInstance.instance.EStructuralFeature_DefaultValue.ToImmutable(MModel);
			EStructuralFeature_Unsettable = EcoreBuilderInstance.instance.EStructuralFeature_Unsettable.ToImmutable(MModel);
			EStructuralFeature_Derived = EcoreBuilderInstance.instance.EStructuralFeature_Derived.ToImmutable(MModel);
			EAttribute = EcoreBuilderInstance.instance.EAttribute.ToImmutable(MModel);
			EAttribute_ID = EcoreBuilderInstance.instance.EAttribute_ID.ToImmutable(MModel);
			EAttribute_EAttributeType = EcoreBuilderInstance.instance.EAttribute_EAttributeType.ToImmutable(MModel);
			EReference = EcoreBuilderInstance.instance.EReference.ToImmutable(MModel);
			EReference_Containment = EcoreBuilderInstance.instance.EReference_Containment.ToImmutable(MModel);
			EReference_Container = EcoreBuilderInstance.instance.EReference_Container.ToImmutable(MModel);
			EReference_ResolveProxies = EcoreBuilderInstance.instance.EReference_ResolveProxies.ToImmutable(MModel);
			EReference_EOpposite = EcoreBuilderInstance.instance.EReference_EOpposite.ToImmutable(MModel);
			EReference_EReferenceType = EcoreBuilderInstance.instance.EReference_EReferenceType.ToImmutable(MModel);
			EOperation = EcoreBuilderInstance.instance.EOperation.ToImmutable(MModel);
			EOperation_EContainingClass = EcoreBuilderInstance.instance.EOperation_EContainingClass.ToImmutable(MModel);
			EOperation_EType = EcoreBuilderInstance.instance.EOperation_EType.ToImmutable(MModel);
			EOperation_EParameters = EcoreBuilderInstance.instance.EOperation_EParameters.ToImmutable(MModel);
			EOperation_EExceptions = EcoreBuilderInstance.instance.EOperation_EExceptions.ToImmutable(MModel);
			EOperation_ETypeParameters = EcoreBuilderInstance.instance.EOperation_ETypeParameters.ToImmutable(MModel);
			EOperation_EGenericExceptions = EcoreBuilderInstance.instance.EOperation_EGenericExceptions.ToImmutable(MModel);
			EParameter = EcoreBuilderInstance.instance.EParameter.ToImmutable(MModel);
			EParameter_EOperation = EcoreBuilderInstance.instance.EParameter_EOperation.ToImmutable(MModel);
			EGenericType = EcoreBuilderInstance.instance.EGenericType.ToImmutable(MModel);
			EGenericType_EClassifier = EcoreBuilderInstance.instance.EGenericType_EClassifier.ToImmutable(MModel);
			EGenericType_ERawType = EcoreBuilderInstance.instance.EGenericType_ERawType.ToImmutable(MModel);
			EGenericType_ETypeParameter = EcoreBuilderInstance.instance.EGenericType_ETypeParameter.ToImmutable(MModel);
			EGenericType_ELowerBound = EcoreBuilderInstance.instance.EGenericType_ELowerBound.ToImmutable(MModel);
			EGenericType_EUpperBound = EcoreBuilderInstance.instance.EGenericType_EUpperBound.ToImmutable(MModel);
			EGenericType_ETypeArguments = EcoreBuilderInstance.instance.EGenericType_ETypeArguments.ToImmutable(MModel);
			ETypeParameter = EcoreBuilderInstance.instance.ETypeParameter.ToImmutable(MModel);
			ETypeParameter_EGenericTypes = EcoreBuilderInstance.instance.ETypeParameter_EGenericTypes.ToImmutable(MModel);
			ETypeParameter_EBounds = EcoreBuilderInstance.instance.ETypeParameter_EBounds.ToImmutable(MModel);
	
			EcoreInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class EcoreFactory : global::MetaDslx.Modeling.ModelFactoryBase
	{
		public EcoreFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
			: base(model, flags)
		{
			EcoreDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel;
	
		public override global::MetaDslx.Modeling.MutableObject Create(string type)
		{
			switch (type)
			{
				case "EObject": return this.EObject();
				case "EFactory": return this.EFactory();
				case "EAnnotation": return this.EAnnotation();
				case "EStringToStringMapEntry": return this.EStringToStringMapEntry();
				case "EPackage": return this.EPackage();
				case "EClassifier": return this.EClassifier();
				case "EClass": return this.EClass();
				case "EDataType": return this.EDataType();
				case "EEnum": return this.EEnum();
				case "EEnumLiteral": return this.EEnumLiteral();
				case "ETypedElement": return this.ETypedElement();
				case "EStructuralFeature": return this.EStructuralFeature();
				case "EAttribute": return this.EAttribute();
				case "EReference": return this.EReference();
				case "EOperation": return this.EOperation();
				case "EParameter": return this.EParameter();
				case "EGenericType": return this.EGenericType();
				case "ETypeParameter": return this.ETypeParameter();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of EObject.
		/// </summary>
		public EObjectBuilder EObject()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EObjectId());
			return (EObjectBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EFactory.
		/// </summary>
		public EFactoryBuilder EFactory()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EFactoryId());
			return (EFactoryBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EAnnotation.
		/// </summary>
		public EAnnotationBuilder EAnnotation()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EAnnotationId());
			return (EAnnotationBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EStringToStringMapEntry.
		/// </summary>
		public EStringToStringMapEntryBuilder EStringToStringMapEntry()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EStringToStringMapEntryId());
			return (EStringToStringMapEntryBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EPackage.
		/// </summary>
		public EPackageBuilder EPackage()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EPackageId());
			return (EPackageBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EClassifier.
		/// </summary>
		public EClassifierBuilder EClassifier()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EClassifierId());
			return (EClassifierBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EClass.
		/// </summary>
		public EClassBuilder EClass()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EClassId());
			return (EClassBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EDataType.
		/// </summary>
		public EDataTypeBuilder EDataType()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EDataTypeId());
			return (EDataTypeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EEnum.
		/// </summary>
		public EEnumBuilder EEnum()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EEnumId());
			return (EEnumBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EEnumLiteral.
		/// </summary>
		public EEnumLiteralBuilder EEnumLiteral()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EEnumLiteralId());
			return (EEnumLiteralBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ETypedElement.
		/// </summary>
		public ETypedElementBuilder ETypedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ETypedElementId());
			return (ETypedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EStructuralFeature.
		/// </summary>
		public EStructuralFeatureBuilder EStructuralFeature()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EStructuralFeatureId());
			return (EStructuralFeatureBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EAttribute.
		/// </summary>
		public EAttributeBuilder EAttribute()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EAttributeId());
			return (EAttributeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EReference.
		/// </summary>
		public EReferenceBuilder EReference()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EReferenceId());
			return (EReferenceBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EOperation.
		/// </summary>
		public EOperationBuilder EOperation()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EOperationId());
			return (EOperationBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EParameter.
		/// </summary>
		public EParameterBuilder EParameter()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EParameterId());
			return (EParameterBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EGenericType.
		/// </summary>
		public EGenericTypeBuilder EGenericType()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EGenericTypeId());
			return (EGenericTypeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ETypeParameter.
		/// </summary>
		public ETypeParameterBuilder ETypeParameter()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ETypeParameterId());
			return (ETypeParameterBuilder)obj;
		}
	}

	
	public interface EObject : global::MetaDslx.Modeling.ImmutableObject
	{
	
		EClass EClass();
		bool EIsProxy();
		MetaDslx.Modeling.IModel EResource();
		EObject EContainer();
		EStructuralFeature EContainingFeature();
		EReference EContainmentFeature();
		System.Collections.Generic.IReadOnlyList<object> EContents();
		System.Collections.IEnumerator EAllContents();
		System.Collections.Generic.IReadOnlyList<object> ECrossReferences();
		object EGet(EStructuralFeature feature);
		object EGet(EStructuralFeature feature, bool resolve);
		object ESet(EStructuralFeature feature, object newValue);
		bool EIsSet(EStructuralFeature feature);
		void EUnset(EStructuralFeature feature);
	
		/// <summary>
		/// Convert the <see cref="EObject"/> object to a builder <see cref="EObjectBuilder"/> object.
		/// </summary>
		new EObjectBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EObject"/> object to a builder <see cref="EObjectBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EObjectBuilder : global::MetaDslx.Modeling.MutableObject
	{
	
		EClassBuilder EClass();
		bool EIsProxy();
		MetaDslx.Modeling.IModel EResource();
		EObjectBuilder EContainer();
		EStructuralFeatureBuilder EContainingFeature();
		EReferenceBuilder EContainmentFeature();
		System.Collections.Generic.IReadOnlyList<object> EContents();
		System.Collections.IEnumerator EAllContents();
		System.Collections.Generic.IReadOnlyList<object> ECrossReferences();
		object EGet(EStructuralFeatureBuilder feature);
		object EGet(EStructuralFeatureBuilder feature, bool resolve);
		object ESet(EStructuralFeatureBuilder feature, object newValue);
		bool EIsSet(EStructuralFeatureBuilder feature);
		void EUnset(EStructuralFeatureBuilder feature);
	
		/// <summary>
		/// Convert the <see cref="EObjectBuilder"/> object to an immutable <see cref="EObject"/> object.
		/// </summary>
		new EObject ToImmutable();
		/// <summary>
		/// Convert the <see cref="EObjectBuilder"/> object to an immutable <see cref="EObject"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EModelElement : EObject
	{
		global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations { get; }
	
		EAnnotation GetEAnnotation(String source);
	
		/// <summary>
		/// Convert the <see cref="EModelElement"/> object to a builder <see cref="EModelElementBuilder"/> object.
		/// </summary>
		new EModelElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EModelElement"/> object to a builder <see cref="EModelElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EModelElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EModelElementBuilder : EObjectBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations { get; }
	
		EAnnotationBuilder GetEAnnotation(String source);
	
		/// <summary>
		/// Convert the <see cref="EModelElementBuilder"/> object to an immutable <see cref="EModelElement"/> object.
		/// </summary>
		new EModelElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="EModelElementBuilder"/> object to an immutable <see cref="EModelElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EModelElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EFactory : EModelElement
	{
		EPackage EPackage { get; }
	
		EObject Create(EClass eClass);
		EObject CreateFromString(EDataType eDataType, String literalValue);
		String ConvertToString(EDataType eDataType, object instanceValue);
	
		/// <summary>
		/// Convert the <see cref="EFactory"/> object to a builder <see cref="EFactoryBuilder"/> object.
		/// </summary>
		new EFactoryBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EFactory"/> object to a builder <see cref="EFactoryBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EFactoryBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EFactoryBuilder : EModelElementBuilder
	{
		EPackageBuilder EPackage { get; set; }
		void SetEPackageLazy(global::System.Func<EPackageBuilder> lazy);
		void SetEPackageLazy(global::System.Func<EFactoryBuilder, EPackageBuilder> lazy);
		void SetEPackageLazy(global::System.Func<EFactory, EPackage> immutableLazy, global::System.Func<EFactoryBuilder, EPackageBuilder> mutableLazy);
	
		EObjectBuilder Create(EClassBuilder eClass);
		EObjectBuilder CreateFromString(EDataTypeBuilder eDataType, String literalValue);
		String ConvertToString(EDataTypeBuilder eDataType, object instanceValue);
	
		/// <summary>
		/// Convert the <see cref="EFactoryBuilder"/> object to an immutable <see cref="EFactory"/> object.
		/// </summary>
		new EFactory ToImmutable();
		/// <summary>
		/// Convert the <see cref="EFactoryBuilder"/> object to an immutable <see cref="EFactory"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EFactory ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ENamedElement : EModelElement
	{
		String Name { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ENamedElement"/> object to a builder <see cref="ENamedElementBuilder"/> object.
		/// </summary>
		new ENamedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ENamedElement"/> object to a builder <see cref="ENamedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ENamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ENamedElementBuilder : EModelElementBuilder
	{
		String Name { get; set; }
		void SetNameLazy(global::System.Func<String> lazy);
		void SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy);
		void SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="ENamedElementBuilder"/> object to an immutable <see cref="ENamedElement"/> object.
		/// </summary>
		new ENamedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ENamedElementBuilder"/> object to an immutable <see cref="ENamedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ENamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EAnnotation : EModelElement
	{
		EModelElement EModelElement { get; }
		String Source { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EStringToStringMapEntry> Details { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EObject> Contents { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EObject> References { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EAnnotation"/> object to a builder <see cref="EAnnotationBuilder"/> object.
		/// </summary>
		new EAnnotationBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EAnnotation"/> object to a builder <see cref="EAnnotationBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EAnnotationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EAnnotationBuilder : EModelElementBuilder
	{
		EModelElementBuilder EModelElement { get; set; }
		void SetEModelElementLazy(global::System.Func<EModelElementBuilder> lazy);
		void SetEModelElementLazy(global::System.Func<EAnnotationBuilder, EModelElementBuilder> lazy);
		void SetEModelElementLazy(global::System.Func<EAnnotation, EModelElement> immutableLazy, global::System.Func<EAnnotationBuilder, EModelElementBuilder> mutableLazy);
		String Source { get; set; }
		void SetSourceLazy(global::System.Func<String> lazy);
		void SetSourceLazy(global::System.Func<EAnnotationBuilder, String> lazy);
		void SetSourceLazy(global::System.Func<EAnnotation, String> immutableLazy, global::System.Func<EAnnotationBuilder, String> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EStringToStringMapEntryBuilder> Details { get; }
		global::MetaDslx.Modeling.MutableModelList<EObjectBuilder> Contents { get; }
		global::MetaDslx.Modeling.MutableModelList<EObjectBuilder> References { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EAnnotationBuilder"/> object to an immutable <see cref="EAnnotation"/> object.
		/// </summary>
		new EAnnotation ToImmutable();
		/// <summary>
		/// Convert the <see cref="EAnnotationBuilder"/> object to an immutable <see cref="EAnnotation"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EAnnotation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EStringToStringMapEntry : global::MetaDslx.Modeling.ImmutableObject
	{
		String Key { get; }
		String Value { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EStringToStringMapEntry"/> object to a builder <see cref="EStringToStringMapEntryBuilder"/> object.
		/// </summary>
		new EStringToStringMapEntryBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EStringToStringMapEntry"/> object to a builder <see cref="EStringToStringMapEntryBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EStringToStringMapEntryBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EStringToStringMapEntryBuilder : global::MetaDslx.Modeling.MutableObject
	{
		String Key { get; set; }
		void SetKeyLazy(global::System.Func<String> lazy);
		void SetKeyLazy(global::System.Func<EStringToStringMapEntryBuilder, String> lazy);
		void SetKeyLazy(global::System.Func<EStringToStringMapEntry, String> immutableLazy, global::System.Func<EStringToStringMapEntryBuilder, String> mutableLazy);
		String Value { get; set; }
		void SetValueLazy(global::System.Func<String> lazy);
		void SetValueLazy(global::System.Func<EStringToStringMapEntryBuilder, String> lazy);
		void SetValueLazy(global::System.Func<EStringToStringMapEntry, String> immutableLazy, global::System.Func<EStringToStringMapEntryBuilder, String> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="EStringToStringMapEntryBuilder"/> object to an immutable <see cref="EStringToStringMapEntry"/> object.
		/// </summary>
		new EStringToStringMapEntry ToImmutable();
		/// <summary>
		/// Convert the <see cref="EStringToStringMapEntryBuilder"/> object to an immutable <see cref="EStringToStringMapEntry"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EStringToStringMapEntry ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EPackage : ENamedElement
	{
		String NsURI { get; }
		String NsPrefix { get; }
		EPackage ESuperPackage { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EPackage> ESubPackages { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EClassifier> EClassifiers { get; }
		EFactory EFactoryInstance { get; }
	
		EClassifier GetEClassifier(String name);
	
		/// <summary>
		/// Convert the <see cref="EPackage"/> object to a builder <see cref="EPackageBuilder"/> object.
		/// </summary>
		new EPackageBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EPackage"/> object to a builder <see cref="EPackageBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EPackageBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EPackageBuilder : ENamedElementBuilder
	{
		String NsURI { get; set; }
		void SetNsURILazy(global::System.Func<String> lazy);
		void SetNsURILazy(global::System.Func<EPackageBuilder, String> lazy);
		void SetNsURILazy(global::System.Func<EPackage, String> immutableLazy, global::System.Func<EPackageBuilder, String> mutableLazy);
		String NsPrefix { get; set; }
		void SetNsPrefixLazy(global::System.Func<String> lazy);
		void SetNsPrefixLazy(global::System.Func<EPackageBuilder, String> lazy);
		void SetNsPrefixLazy(global::System.Func<EPackage, String> immutableLazy, global::System.Func<EPackageBuilder, String> mutableLazy);
		EPackageBuilder ESuperPackage { get; set; }
		void SetESuperPackageLazy(global::System.Func<EPackageBuilder> lazy);
		void SetESuperPackageLazy(global::System.Func<EPackageBuilder, EPackageBuilder> lazy);
		void SetESuperPackageLazy(global::System.Func<EPackage, EPackage> immutableLazy, global::System.Func<EPackageBuilder, EPackageBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EPackageBuilder> ESubPackages { get; }
		global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> EClassifiers { get; }
		EFactoryBuilder EFactoryInstance { get; set; }
		void SetEFactoryInstanceLazy(global::System.Func<EFactoryBuilder> lazy);
		void SetEFactoryInstanceLazy(global::System.Func<EPackageBuilder, EFactoryBuilder> lazy);
		void SetEFactoryInstanceLazy(global::System.Func<EPackage, EFactory> immutableLazy, global::System.Func<EPackageBuilder, EFactoryBuilder> mutableLazy);
	
		EClassifierBuilder GetEClassifier(String name);
	
		/// <summary>
		/// Convert the <see cref="EPackageBuilder"/> object to an immutable <see cref="EPackage"/> object.
		/// </summary>
		new EPackage ToImmutable();
		/// <summary>
		/// Convert the <see cref="EPackageBuilder"/> object to an immutable <see cref="EPackage"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EPackage ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EClassifier : ENamedElement
	{
		String InstanceClassName { get; }
		EPackage EPackage { get; }
		global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters { get; }
		System.Type InstanceClass { get; }
		object DefaultValue { get; }
	
		/// <summary>
		/// Returns whether the object is an instance of this classifier.
		/// </summary>
		bool IsInstance(object @object);
		int GetClassifierID();
	
		/// <summary>
		/// Convert the <see cref="EClassifier"/> object to a builder <see cref="EClassifierBuilder"/> object.
		/// </summary>
		new EClassifierBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EClassifier"/> object to a builder <see cref="EClassifierBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EClassifierBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EClassifierBuilder : ENamedElementBuilder
	{
		String InstanceClassName { get; set; }
		void SetInstanceClassNameLazy(global::System.Func<String> lazy);
		void SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, String> lazy);
		void SetInstanceClassNameLazy(global::System.Func<EClassifier, String> immutableLazy, global::System.Func<EClassifierBuilder, String> mutableLazy);
		EPackageBuilder EPackage { get; set; }
		void SetEPackageLazy(global::System.Func<EPackageBuilder> lazy);
		void SetEPackageLazy(global::System.Func<EClassifierBuilder, EPackageBuilder> lazy);
		void SetEPackageLazy(global::System.Func<EClassifier, EPackage> immutableLazy, global::System.Func<EClassifierBuilder, EPackageBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters { get; }
		System.Type InstanceClass { get; set; }
		void SetInstanceClassLazy(global::System.Func<System.Type> lazy);
		void SetInstanceClassLazy(global::System.Func<EClassifierBuilder, System.Type> lazy);
		void SetInstanceClassLazy(global::System.Func<EClassifier, System.Type> immutableLazy, global::System.Func<EClassifierBuilder, System.Type> mutableLazy);
		object DefaultValue { get; set; }
		void SetDefaultValueLazy(global::System.Func<object> lazy);
		void SetDefaultValueLazy(global::System.Func<EClassifierBuilder, object> lazy);
		void SetDefaultValueLazy(global::System.Func<EClassifier, object> immutableLazy, global::System.Func<EClassifierBuilder, object> mutableLazy);
	
		/// <summary>
		/// Returns whether the object is an instance of this classifier.
		/// </summary>
		bool IsInstance(object @object);
		int GetClassifierID();
	
		/// <summary>
		/// Convert the <see cref="EClassifierBuilder"/> object to an immutable <see cref="EClassifier"/> object.
		/// </summary>
		new EClassifier ToImmutable();
		/// <summary>
		/// Convert the <see cref="EClassifierBuilder"/> object to an immutable <see cref="EClassifier"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EClassifier ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EClass : EClassifier
	{
		bool Abstract { get; }
		bool Interface { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EClass> ESuperTypes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EClass> EAllSuperTypes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> EStructuralFeatures { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> EAllStructuralFeatures { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EOperation> EOperations { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EOperation> EAllOperation { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EReference> EReferences { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EReference> EAllReferences { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EReference> EAllContainments { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EAttributes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EAllAttributes { get; }
		EAttribute EIDAttribute { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericSuperTypes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EAllGenericSuperTypes { get; }
	
		bool IsSuperTypeOf(EClass someClass);
		EStructuralFeature GetStructuralFeature(int featureID);
		EStructuralFeature GetStructuralFeature(String featureName);
	
		/// <summary>
		/// Convert the <see cref="EClass"/> object to a builder <see cref="EClassBuilder"/> object.
		/// </summary>
		new EClassBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EClass"/> object to a builder <see cref="EClassBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EClassBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EClassBuilder : EClassifierBuilder
	{
		bool Abstract { get; set; }
		void SetAbstractLazy(global::System.Func<bool> lazy);
		void SetAbstractLazy(global::System.Func<EClassBuilder, bool> lazy);
		void SetAbstractLazy(global::System.Func<EClass, bool> immutableLazy, global::System.Func<EClassBuilder, bool> mutableLazy);
		bool Interface { get; set; }
		void SetInterfaceLazy(global::System.Func<bool> lazy);
		void SetInterfaceLazy(global::System.Func<EClassBuilder, bool> lazy);
		void SetInterfaceLazy(global::System.Func<EClass, bool> immutableLazy, global::System.Func<EClassBuilder, bool> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EClassBuilder> ESuperTypes { get; }
		global::MetaDslx.Modeling.MutableModelList<EClassBuilder> EAllSuperTypes { get; }
		global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> EStructuralFeatures { get; }
		global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> EAllStructuralFeatures { get; }
		global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> EOperations { get; }
		global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> EAllOperation { get; }
		global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EReferences { get; }
		global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EAllReferences { get; }
		global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EAllContainments { get; }
		global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EAttributes { get; }
		global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EAllAttributes { get; }
		EAttributeBuilder EIDAttribute { get; }
		void SetEIDAttributeLazy(global::System.Func<EAttributeBuilder> lazy);
		void SetEIDAttributeLazy(global::System.Func<EClassBuilder, EAttributeBuilder> lazy);
		void SetEIDAttributeLazy(global::System.Func<EClass, EAttribute> immutableLazy, global::System.Func<EClassBuilder, EAttributeBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericSuperTypes { get; }
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EAllGenericSuperTypes { get; }
	
		bool IsSuperTypeOf(EClassBuilder someClass);
		EStructuralFeatureBuilder GetStructuralFeature(int featureID);
		EStructuralFeatureBuilder GetStructuralFeature(String featureName);
	
		/// <summary>
		/// Convert the <see cref="EClassBuilder"/> object to an immutable <see cref="EClass"/> object.
		/// </summary>
		new EClass ToImmutable();
		/// <summary>
		/// Convert the <see cref="EClassBuilder"/> object to an immutable <see cref="EClass"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EClass ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EDataType : EClassifier
	{
		bool Serializable { get; }
		String DotNetName { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EDataType"/> object to a builder <see cref="EDataTypeBuilder"/> object.
		/// </summary>
		new EDataTypeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EDataType"/> object to a builder <see cref="EDataTypeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EDataTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EDataTypeBuilder : EClassifierBuilder
	{
		bool Serializable { get; set; }
		void SetSerializableLazy(global::System.Func<bool> lazy);
		void SetSerializableLazy(global::System.Func<EDataTypeBuilder, bool> lazy);
		void SetSerializableLazy(global::System.Func<EDataType, bool> immutableLazy, global::System.Func<EDataTypeBuilder, bool> mutableLazy);
		String DotNetName { get; set; }
		void SetDotNetNameLazy(global::System.Func<String> lazy);
		void SetDotNetNameLazy(global::System.Func<EDataTypeBuilder, String> lazy);
		void SetDotNetNameLazy(global::System.Func<EDataType, String> immutableLazy, global::System.Func<EDataTypeBuilder, String> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="EDataTypeBuilder"/> object to an immutable <see cref="EDataType"/> object.
		/// </summary>
		new EDataType ToImmutable();
		/// <summary>
		/// Convert the <see cref="EDataTypeBuilder"/> object to an immutable <see cref="EDataType"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EDataType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EEnum : EDataType
	{
		global::MetaDslx.Modeling.ImmutableModelList<EEnumLiteral> ELiterals { get; }
	
		EEnumLiteral GetEEnumLiteral(String name);
		EEnumLiteral GetEEnumLiteral(int value);
	
		/// <summary>
		/// Convert the <see cref="EEnum"/> object to a builder <see cref="EEnumBuilder"/> object.
		/// </summary>
		new EEnumBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EEnum"/> object to a builder <see cref="EEnumBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EEnumBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EEnumBuilder : EDataTypeBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<EEnumLiteralBuilder> ELiterals { get; }
	
		EEnumLiteralBuilder GetEEnumLiteral(String name);
		EEnumLiteralBuilder GetEEnumLiteral(int value);
	
		/// <summary>
		/// Convert the <see cref="EEnumBuilder"/> object to an immutable <see cref="EEnum"/> object.
		/// </summary>
		new EEnum ToImmutable();
		/// <summary>
		/// Convert the <see cref="EEnumBuilder"/> object to an immutable <see cref="EEnum"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EEnum ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EEnumLiteral : ENamedElement
	{
		EEnum EEnum { get; }
		int Value { get; }
		System.Collections.IEnumerator Instance { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EEnumLiteral"/> object to a builder <see cref="EEnumLiteralBuilder"/> object.
		/// </summary>
		new EEnumLiteralBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EEnumLiteral"/> object to a builder <see cref="EEnumLiteralBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EEnumLiteralBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EEnumLiteralBuilder : ENamedElementBuilder
	{
		EEnumBuilder EEnum { get; set; }
		void SetEEnumLazy(global::System.Func<EEnumBuilder> lazy);
		void SetEEnumLazy(global::System.Func<EEnumLiteralBuilder, EEnumBuilder> lazy);
		void SetEEnumLazy(global::System.Func<EEnumLiteral, EEnum> immutableLazy, global::System.Func<EEnumLiteralBuilder, EEnumBuilder> mutableLazy);
		int Value { get; set; }
		void SetValueLazy(global::System.Func<int> lazy);
		void SetValueLazy(global::System.Func<EEnumLiteralBuilder, int> lazy);
		void SetValueLazy(global::System.Func<EEnumLiteral, int> immutableLazy, global::System.Func<EEnumLiteralBuilder, int> mutableLazy);
		System.Collections.IEnumerator Instance { get; set; }
		void SetInstanceLazy(global::System.Func<System.Collections.IEnumerator> lazy);
		void SetInstanceLazy(global::System.Func<EEnumLiteralBuilder, System.Collections.IEnumerator> lazy);
		void SetInstanceLazy(global::System.Func<EEnumLiteral, System.Collections.IEnumerator> immutableLazy, global::System.Func<EEnumLiteralBuilder, System.Collections.IEnumerator> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="EEnumLiteralBuilder"/> object to an immutable <see cref="EEnumLiteral"/> object.
		/// </summary>
		new EEnumLiteral ToImmutable();
		/// <summary>
		/// Convert the <see cref="EEnumLiteralBuilder"/> object to an immutable <see cref="EEnumLiteral"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EEnumLiteral ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ETypedElement : ENamedElement
	{
		EClassifier EType { get; }
		bool Ordered { get; }
		bool Unique { get; }
		int LowerBound { get; }
		int UpperBound { get; }
		bool Many { get; }
		bool Required { get; }
		EGenericType EGenericType { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ETypedElement"/> object to a builder <see cref="ETypedElementBuilder"/> object.
		/// </summary>
		new ETypedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ETypedElement"/> object to a builder <see cref="ETypedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ETypedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ETypedElementBuilder : ENamedElementBuilder
	{
		EClassifierBuilder EType { get; set; }
		void SetETypeLazy(global::System.Func<EClassifierBuilder> lazy);
		void SetETypeLazy(global::System.Func<ETypedElementBuilder, EClassifierBuilder> lazy);
		void SetETypeLazy(global::System.Func<ETypedElement, EClassifier> immutableLazy, global::System.Func<ETypedElementBuilder, EClassifierBuilder> mutableLazy);
		bool Ordered { get; set; }
		void SetOrderedLazy(global::System.Func<bool> lazy);
		void SetOrderedLazy(global::System.Func<ETypedElementBuilder, bool> lazy);
		void SetOrderedLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy);
		bool Unique { get; set; }
		void SetUniqueLazy(global::System.Func<bool> lazy);
		void SetUniqueLazy(global::System.Func<ETypedElementBuilder, bool> lazy);
		void SetUniqueLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy);
		int LowerBound { get; set; }
		void SetLowerBoundLazy(global::System.Func<int> lazy);
		void SetLowerBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy);
		void SetLowerBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy);
		int UpperBound { get; set; }
		void SetUpperBoundLazy(global::System.Func<int> lazy);
		void SetUpperBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy);
		void SetUpperBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy);
		bool Many { get; }
		void SetManyLazy(global::System.Func<bool> lazy);
		void SetManyLazy(global::System.Func<ETypedElementBuilder, bool> lazy);
		void SetManyLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy);
		bool Required { get; }
		void SetRequiredLazy(global::System.Func<bool> lazy);
		void SetRequiredLazy(global::System.Func<ETypedElementBuilder, bool> lazy);
		void SetRequiredLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy);
		EGenericTypeBuilder EGenericType { get; set; }
		void SetEGenericTypeLazy(global::System.Func<EGenericTypeBuilder> lazy);
		void SetEGenericTypeLazy(global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> lazy);
		void SetEGenericTypeLazy(global::System.Func<ETypedElement, EGenericType> immutableLazy, global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="ETypedElementBuilder"/> object to an immutable <see cref="ETypedElement"/> object.
		/// </summary>
		new ETypedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ETypedElementBuilder"/> object to an immutable <see cref="ETypedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ETypedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EStructuralFeature : ETypedElement
	{
		EClass EContainingClass { get; }
		new EClassifier EType { get; }
		bool Changeable { get; }
		bool Volatile { get; }
		bool Transient { get; }
		String DefaultValueLiteral { get; }
		object DefaultValue { get; }
		bool Unsettable { get; }
		bool Derived { get; }
	
		int GetFeatureID();
		System.Type GetContainerClass();
	
		/// <summary>
		/// Convert the <see cref="EStructuralFeature"/> object to a builder <see cref="EStructuralFeatureBuilder"/> object.
		/// </summary>
		new EStructuralFeatureBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EStructuralFeature"/> object to a builder <see cref="EStructuralFeatureBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EStructuralFeatureBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EStructuralFeatureBuilder : ETypedElementBuilder
	{
		EClassBuilder EContainingClass { get; set; }
		void SetEContainingClassLazy(global::System.Func<EClassBuilder> lazy);
		void SetEContainingClassLazy(global::System.Func<EStructuralFeatureBuilder, EClassBuilder> lazy);
		void SetEContainingClassLazy(global::System.Func<EStructuralFeature, EClass> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassBuilder> mutableLazy);
		new EClassifierBuilder EType { get; set; }
		new void SetETypeLazy(global::System.Func<EClassifierBuilder> lazy);
		new void SetETypeLazy(global::System.Func<EStructuralFeatureBuilder, EClassifierBuilder> lazy);
		new void SetETypeLazy(global::System.Func<EStructuralFeature, EClassifier> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassifierBuilder> mutableLazy);
		bool Changeable { get; set; }
		void SetChangeableLazy(global::System.Func<bool> lazy);
		void SetChangeableLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy);
		void SetChangeableLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy);
		bool Volatile { get; set; }
		void SetVolatileLazy(global::System.Func<bool> lazy);
		void SetVolatileLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy);
		void SetVolatileLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy);
		bool Transient { get; set; }
		void SetTransientLazy(global::System.Func<bool> lazy);
		void SetTransientLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy);
		void SetTransientLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy);
		String DefaultValueLiteral { get; set; }
		void SetDefaultValueLiteralLazy(global::System.Func<String> lazy);
		void SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeatureBuilder, String> lazy);
		void SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeature, String> immutableLazy, global::System.Func<EStructuralFeatureBuilder, String> mutableLazy);
		object DefaultValue { get; set; }
		void SetDefaultValueLazy(global::System.Func<object> lazy);
		void SetDefaultValueLazy(global::System.Func<EStructuralFeatureBuilder, object> lazy);
		void SetDefaultValueLazy(global::System.Func<EStructuralFeature, object> immutableLazy, global::System.Func<EStructuralFeatureBuilder, object> mutableLazy);
		bool Unsettable { get; set; }
		void SetUnsettableLazy(global::System.Func<bool> lazy);
		void SetUnsettableLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy);
		void SetUnsettableLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy);
		bool Derived { get; set; }
		void SetDerivedLazy(global::System.Func<bool> lazy);
		void SetDerivedLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy);
		void SetDerivedLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy);
	
		int GetFeatureID();
		System.Type GetContainerClass();
	
		/// <summary>
		/// Convert the <see cref="EStructuralFeatureBuilder"/> object to an immutable <see cref="EStructuralFeature"/> object.
		/// </summary>
		new EStructuralFeature ToImmutable();
		/// <summary>
		/// Convert the <see cref="EStructuralFeatureBuilder"/> object to an immutable <see cref="EStructuralFeature"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EStructuralFeature ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EAttribute : EStructuralFeature
	{
		bool ID { get; }
		EDataType EAttributeType { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EAttribute"/> object to a builder <see cref="EAttributeBuilder"/> object.
		/// </summary>
		new EAttributeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EAttribute"/> object to a builder <see cref="EAttributeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EAttributeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EAttributeBuilder : EStructuralFeatureBuilder
	{
		bool ID { get; set; }
		void SetIDLazy(global::System.Func<bool> lazy);
		void SetIDLazy(global::System.Func<EAttributeBuilder, bool> lazy);
		void SetIDLazy(global::System.Func<EAttribute, bool> immutableLazy, global::System.Func<EAttributeBuilder, bool> mutableLazy);
		EDataTypeBuilder EAttributeType { get; }
		void SetEAttributeTypeLazy(global::System.Func<EDataTypeBuilder> lazy);
		void SetEAttributeTypeLazy(global::System.Func<EAttributeBuilder, EDataTypeBuilder> lazy);
		void SetEAttributeTypeLazy(global::System.Func<EAttribute, EDataType> immutableLazy, global::System.Func<EAttributeBuilder, EDataTypeBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="EAttributeBuilder"/> object to an immutable <see cref="EAttribute"/> object.
		/// </summary>
		new EAttribute ToImmutable();
		/// <summary>
		/// Convert the <see cref="EAttributeBuilder"/> object to an immutable <see cref="EAttribute"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EAttribute ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EReference : EStructuralFeature
	{
		bool Containment { get; }
		bool Container { get; }
		bool ResolveProxies { get; }
		EReference EOpposite { get; }
		EClass EReferenceType { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EReference"/> object to a builder <see cref="EReferenceBuilder"/> object.
		/// </summary>
		new EReferenceBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EReference"/> object to a builder <see cref="EReferenceBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EReferenceBuilder : EStructuralFeatureBuilder
	{
		bool Containment { get; set; }
		void SetContainmentLazy(global::System.Func<bool> lazy);
		void SetContainmentLazy(global::System.Func<EReferenceBuilder, bool> lazy);
		void SetContainmentLazy(global::System.Func<EReference, bool> immutableLazy, global::System.Func<EReferenceBuilder, bool> mutableLazy);
		bool Container { get; }
		void SetContainerLazy(global::System.Func<bool> lazy);
		void SetContainerLazy(global::System.Func<EReferenceBuilder, bool> lazy);
		void SetContainerLazy(global::System.Func<EReference, bool> immutableLazy, global::System.Func<EReferenceBuilder, bool> mutableLazy);
		bool ResolveProxies { get; set; }
		void SetResolveProxiesLazy(global::System.Func<bool> lazy);
		void SetResolveProxiesLazy(global::System.Func<EReferenceBuilder, bool> lazy);
		void SetResolveProxiesLazy(global::System.Func<EReference, bool> immutableLazy, global::System.Func<EReferenceBuilder, bool> mutableLazy);
		EReferenceBuilder EOpposite { get; set; }
		void SetEOppositeLazy(global::System.Func<EReferenceBuilder> lazy);
		void SetEOppositeLazy(global::System.Func<EReferenceBuilder, EReferenceBuilder> lazy);
		void SetEOppositeLazy(global::System.Func<EReference, EReference> immutableLazy, global::System.Func<EReferenceBuilder, EReferenceBuilder> mutableLazy);
		EClassBuilder EReferenceType { get; set; }
		void SetEReferenceTypeLazy(global::System.Func<EClassBuilder> lazy);
		void SetEReferenceTypeLazy(global::System.Func<EReferenceBuilder, EClassBuilder> lazy);
		void SetEReferenceTypeLazy(global::System.Func<EReference, EClass> immutableLazy, global::System.Func<EReferenceBuilder, EClassBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="EReferenceBuilder"/> object to an immutable <see cref="EReference"/> object.
		/// </summary>
		new EReference ToImmutable();
		/// <summary>
		/// Convert the <see cref="EReferenceBuilder"/> object to an immutable <see cref="EReference"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EReference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EOperation : ETypedElement
	{
		EClass EContainingClass { get; }
		new EClassifier EType { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EParameter> EParameters { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EClassifier> EExceptions { get; }
		global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericExceptions { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EOperation"/> object to a builder <see cref="EOperationBuilder"/> object.
		/// </summary>
		new EOperationBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EOperation"/> object to a builder <see cref="EOperationBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EOperationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EOperationBuilder : ETypedElementBuilder
	{
		EClassBuilder EContainingClass { get; set; }
		void SetEContainingClassLazy(global::System.Func<EClassBuilder> lazy);
		void SetEContainingClassLazy(global::System.Func<EOperationBuilder, EClassBuilder> lazy);
		void SetEContainingClassLazy(global::System.Func<EOperation, EClass> immutableLazy, global::System.Func<EOperationBuilder, EClassBuilder> mutableLazy);
		new EClassifierBuilder EType { get; set; }
		new void SetETypeLazy(global::System.Func<EClassifierBuilder> lazy);
		new void SetETypeLazy(global::System.Func<EOperationBuilder, EClassifierBuilder> lazy);
		new void SetETypeLazy(global::System.Func<EOperation, EClassifier> immutableLazy, global::System.Func<EOperationBuilder, EClassifierBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EParameterBuilder> EParameters { get; }
		global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> EExceptions { get; }
		global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters { get; }
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericExceptions { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EOperationBuilder"/> object to an immutable <see cref="EOperation"/> object.
		/// </summary>
		new EOperation ToImmutable();
		/// <summary>
		/// Convert the <see cref="EOperationBuilder"/> object to an immutable <see cref="EOperation"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EOperation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EParameter : ETypedElement
	{
		EOperation EOperation { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EParameter"/> object to a builder <see cref="EParameterBuilder"/> object.
		/// </summary>
		new EParameterBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EParameter"/> object to a builder <see cref="EParameterBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EParameterBuilder : ETypedElementBuilder
	{
		EOperationBuilder EOperation { get; set; }
		void SetEOperationLazy(global::System.Func<EOperationBuilder> lazy);
		void SetEOperationLazy(global::System.Func<EParameterBuilder, EOperationBuilder> lazy);
		void SetEOperationLazy(global::System.Func<EParameter, EOperation> immutableLazy, global::System.Func<EParameterBuilder, EOperationBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="EParameterBuilder"/> object to an immutable <see cref="EParameter"/> object.
		/// </summary>
		new EParameter ToImmutable();
		/// <summary>
		/// Convert the <see cref="EParameterBuilder"/> object to an immutable <see cref="EParameter"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EGenericType : global::MetaDslx.Modeling.ImmutableObject
	{
		EClassifier EClassifier { get; }
		EClassifier ERawType { get; }
		ETypeParameter ETypeParameter { get; }
		EGenericType ELowerBound { get; }
		EGenericType EUpperBound { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> ETypeArguments { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EGenericType"/> object to a builder <see cref="EGenericTypeBuilder"/> object.
		/// </summary>
		new EGenericTypeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EGenericType"/> object to a builder <see cref="EGenericTypeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EGenericTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EGenericTypeBuilder : global::MetaDslx.Modeling.MutableObject
	{
		EClassifierBuilder EClassifier { get; set; }
		void SetEClassifierLazy(global::System.Func<EClassifierBuilder> lazy);
		void SetEClassifierLazy(global::System.Func<EGenericTypeBuilder, EClassifierBuilder> lazy);
		void SetEClassifierLazy(global::System.Func<EGenericType, EClassifier> immutableLazy, global::System.Func<EGenericTypeBuilder, EClassifierBuilder> mutableLazy);
		EClassifierBuilder ERawType { get; set; }
		void SetERawTypeLazy(global::System.Func<EClassifierBuilder> lazy);
		void SetERawTypeLazy(global::System.Func<EGenericTypeBuilder, EClassifierBuilder> lazy);
		void SetERawTypeLazy(global::System.Func<EGenericType, EClassifier> immutableLazy, global::System.Func<EGenericTypeBuilder, EClassifierBuilder> mutableLazy);
		ETypeParameterBuilder ETypeParameter { get; set; }
		void SetETypeParameterLazy(global::System.Func<ETypeParameterBuilder> lazy);
		void SetETypeParameterLazy(global::System.Func<EGenericTypeBuilder, ETypeParameterBuilder> lazy);
		void SetETypeParameterLazy(global::System.Func<EGenericType, ETypeParameter> immutableLazy, global::System.Func<EGenericTypeBuilder, ETypeParameterBuilder> mutableLazy);
		EGenericTypeBuilder ELowerBound { get; set; }
		void SetELowerBoundLazy(global::System.Func<EGenericTypeBuilder> lazy);
		void SetELowerBoundLazy(global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> lazy);
		void SetELowerBoundLazy(global::System.Func<EGenericType, EGenericType> immutableLazy, global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> mutableLazy);
		EGenericTypeBuilder EUpperBound { get; set; }
		void SetEUpperBoundLazy(global::System.Func<EGenericTypeBuilder> lazy);
		void SetEUpperBoundLazy(global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> lazy);
		void SetEUpperBoundLazy(global::System.Func<EGenericType, EGenericType> immutableLazy, global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> ETypeArguments { get; }
	
	
		/// <summary>
		/// Convert the <see cref="EGenericTypeBuilder"/> object to an immutable <see cref="EGenericType"/> object.
		/// </summary>
		new EGenericType ToImmutable();
		/// <summary>
		/// Convert the <see cref="EGenericTypeBuilder"/> object to an immutable <see cref="EGenericType"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EGenericType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ETypeParameter : ENamedElement
	{
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericTypes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EBounds { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ETypeParameter"/> object to a builder <see cref="ETypeParameterBuilder"/> object.
		/// </summary>
		new ETypeParameterBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ETypeParameter"/> object to a builder <see cref="ETypeParameterBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ETypeParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ETypeParameterBuilder : ENamedElementBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericTypes { get; }
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EBounds { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ETypeParameterBuilder"/> object to an immutable <see cref="ETypeParameter"/> object.
		/// </summary>
		new ETypeParameter ToImmutable();
		/// <summary>
		/// Convert the <see cref="ETypeParameterBuilder"/> object to an immutable <see cref="ETypeParameter"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ETypeParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}

	public static class EcoreDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static EcoreDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty>();
			EObject.Initialize();
			EModelElement.Initialize();
			EFactory.Initialize();
			ENamedElement.Initialize();
			EAnnotation.Initialize();
			EStringToStringMapEntry.Initialize();
			EPackage.Initialize();
			EClassifier.Initialize();
			EClass.Initialize();
			EDataType.Initialize();
			EEnum.Initialize();
			EEnumLiteral.Initialize();
			ETypedElement.Initialize();
			EStructuralFeature.Initialize();
			EAttribute.Initialize();
			EReference.Initialize();
			EOperation.Initialize();
			EParameter.Initialize();
			EGenericType.Initialize();
			ETypeParameter.Initialize();
			properties.Add(EcoreDescriptor.EModelElement.EAnnotationsProperty);
			properties.Add(EcoreDescriptor.EFactory.EPackageProperty);
			properties.Add(EcoreDescriptor.ENamedElement.NameProperty);
			properties.Add(EcoreDescriptor.EAnnotation.EModelElementProperty);
			properties.Add(EcoreDescriptor.EAnnotation.SourceProperty);
			properties.Add(EcoreDescriptor.EAnnotation.DetailsProperty);
			properties.Add(EcoreDescriptor.EAnnotation.ContentsProperty);
			properties.Add(EcoreDescriptor.EAnnotation.ReferencesProperty);
			properties.Add(EcoreDescriptor.EStringToStringMapEntry.KeyProperty);
			properties.Add(EcoreDescriptor.EStringToStringMapEntry.ValueProperty);
			properties.Add(EcoreDescriptor.EPackage.NsURIProperty);
			properties.Add(EcoreDescriptor.EPackage.NsPrefixProperty);
			properties.Add(EcoreDescriptor.EPackage.ESuperPackageProperty);
			properties.Add(EcoreDescriptor.EPackage.ESubPackagesProperty);
			properties.Add(EcoreDescriptor.EPackage.EClassifiersProperty);
			properties.Add(EcoreDescriptor.EPackage.EFactoryInstanceProperty);
			properties.Add(EcoreDescriptor.EClassifier.InstanceClassNameProperty);
			properties.Add(EcoreDescriptor.EClassifier.EPackageProperty);
			properties.Add(EcoreDescriptor.EClassifier.ETypeParametersProperty);
			properties.Add(EcoreDescriptor.EClassifier.InstanceClassProperty);
			properties.Add(EcoreDescriptor.EClassifier.DefaultValueProperty);
			properties.Add(EcoreDescriptor.EClass.AbstractProperty);
			properties.Add(EcoreDescriptor.EClass.InterfaceProperty);
			properties.Add(EcoreDescriptor.EClass.ESuperTypesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllSuperTypesProperty);
			properties.Add(EcoreDescriptor.EClass.EStructuralFeaturesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllStructuralFeaturesProperty);
			properties.Add(EcoreDescriptor.EClass.EOperationsProperty);
			properties.Add(EcoreDescriptor.EClass.EAllOperationProperty);
			properties.Add(EcoreDescriptor.EClass.EReferencesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllReferencesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllContainmentsProperty);
			properties.Add(EcoreDescriptor.EClass.EAttributesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllAttributesProperty);
			properties.Add(EcoreDescriptor.EClass.EIDAttributeProperty);
			properties.Add(EcoreDescriptor.EClass.EGenericSuperTypesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllGenericSuperTypesProperty);
			properties.Add(EcoreDescriptor.EDataType.SerializableProperty);
			properties.Add(EcoreDescriptor.EDataType.DotNetNameProperty);
			properties.Add(EcoreDescriptor.EEnum.ELiteralsProperty);
			properties.Add(EcoreDescriptor.EEnumLiteral.EEnumProperty);
			properties.Add(EcoreDescriptor.EEnumLiteral.ValueProperty);
			properties.Add(EcoreDescriptor.EEnumLiteral.InstanceProperty);
			properties.Add(EcoreDescriptor.ETypedElement.ETypeProperty);
			properties.Add(EcoreDescriptor.ETypedElement.OrderedProperty);
			properties.Add(EcoreDescriptor.ETypedElement.UniqueProperty);
			properties.Add(EcoreDescriptor.ETypedElement.LowerBoundProperty);
			properties.Add(EcoreDescriptor.ETypedElement.UpperBoundProperty);
			properties.Add(EcoreDescriptor.ETypedElement.ManyProperty);
			properties.Add(EcoreDescriptor.ETypedElement.RequiredProperty);
			properties.Add(EcoreDescriptor.ETypedElement.EGenericTypeProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.EContainingClassProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.ETypeProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.ChangeableProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.VolatileProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.TransientProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.DefaultValueProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.UnsettableProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.DerivedProperty);
			properties.Add(EcoreDescriptor.EAttribute.IDProperty);
			properties.Add(EcoreDescriptor.EAttribute.EAttributeTypeProperty);
			properties.Add(EcoreDescriptor.EReference.ContainmentProperty);
			properties.Add(EcoreDescriptor.EReference.ContainerProperty);
			properties.Add(EcoreDescriptor.EReference.ResolveProxiesProperty);
			properties.Add(EcoreDescriptor.EReference.EOppositeProperty);
			properties.Add(EcoreDescriptor.EReference.EReferenceTypeProperty);
			properties.Add(EcoreDescriptor.EOperation.EContainingClassProperty);
			properties.Add(EcoreDescriptor.EOperation.ETypeProperty);
			properties.Add(EcoreDescriptor.EOperation.EParametersProperty);
			properties.Add(EcoreDescriptor.EOperation.EExceptionsProperty);
			properties.Add(EcoreDescriptor.EOperation.ETypeParametersProperty);
			properties.Add(EcoreDescriptor.EOperation.EGenericExceptionsProperty);
			properties.Add(EcoreDescriptor.EParameter.EOperationProperty);
			properties.Add(EcoreDescriptor.EGenericType.EClassifierProperty);
			properties.Add(EcoreDescriptor.EGenericType.ERawTypeProperty);
			properties.Add(EcoreDescriptor.EGenericType.ETypeParameterProperty);
			properties.Add(EcoreDescriptor.EGenericType.ELowerBoundProperty);
			properties.Add(EcoreDescriptor.EGenericType.EUpperBoundProperty);
			properties.Add(EcoreDescriptor.EGenericType.ETypeArgumentsProperty);
			properties.Add(EcoreDescriptor.ETypeParameter.EGenericTypesProperty);
			properties.Add(EcoreDescriptor.ETypeParameter.EBoundsProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string MUri = "http://www.eclipse.org/emf/2002/Ecore";
		public const string MPrefix = "";
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.Symbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EObjectId), typeof(global::MetaDslx.Languages.Ecore.Model.EObject), typeof(global::MetaDslx.Languages.Ecore.Model.EObjectBuilder))]
		public static class EObject
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EObject()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EObject));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EObject; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EModelElementId), typeof(global::MetaDslx.Languages.Ecore.Model.EModelElement), typeof(global::MetaDslx.Languages.Ecore.Model.EModelElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EObject) })]
		public static class EModelElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EModelElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EModelElement));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EModelElement; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EAnnotation), "EModelElement")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAnnotationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EModelElement), name: "EAnnotations",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAnnotation),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAnnotationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EModelElement_EAnnotations,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EFactoryId), typeof(global::MetaDslx.Languages.Ecore.Model.EFactory), typeof(global::MetaDslx.Languages.Ecore.Model.EFactoryBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EModelElement) })]
		public static class EFactory
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EFactory()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EFactory));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EFactory; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty EPackageProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EFactory), name: "EPackage",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackage),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EFactory_EPackage,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.ENamedElementId), typeof(global::MetaDslx.Languages.Ecore.Model.ENamedElement), typeof(global::MetaDslx.Languages.Ecore.Model.ENamedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EModelElement) })]
		public static class ENamedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ENamedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ENamedElement));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ENamedElement; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Name")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ENamedElement), name: "Name",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ENamedElement_Name,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EAnnotationId), typeof(global::MetaDslx.Languages.Ecore.Model.EAnnotation), typeof(global::MetaDslx.Languages.Ecore.Model.EAnnotationBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EModelElement) })]
		public static class EAnnotation
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EAnnotation()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EAnnotation));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAnnotation; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EModelElement), "EAnnotations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EModelElementProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAnnotation), name: "EModelElement",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EModelElement),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EModelElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAnnotation_EModelElement,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SourceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAnnotation), name: "Source",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAnnotation_Source,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty DetailsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAnnotation), name: "Details",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EStringToStringMapEntry),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EStringToStringMapEntryBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAnnotation_Details,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ContentsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAnnotation), name: "Contents",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EObject),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EObjectBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAnnotation_Contents,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ReferencesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAnnotation), name: "References",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EObject),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EObjectBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAnnotation_References,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EStringToStringMapEntryId), typeof(global::MetaDslx.Languages.Ecore.Model.EStringToStringMapEntry), typeof(global::MetaDslx.Languages.Ecore.Model.EStringToStringMapEntryBuilder))]
		public static class EStringToStringMapEntry
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EStringToStringMapEntry()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EStringToStringMapEntry));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStringToStringMapEntry; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KeyProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStringToStringMapEntry), name: "Key",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStringToStringMapEntry_Key,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStringToStringMapEntry), name: "Value",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStringToStringMapEntry_Value,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamespaceSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EPackageId), typeof(global::MetaDslx.Languages.Ecore.Model.EPackage), typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.ENamedElement) })]
		public static class EPackage
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EPackage()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EPackage));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty NsURIProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "NsURI",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_NsURI,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty NsPrefixProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "NsPrefix",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_NsPrefix,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EPackage), "ESubPackages")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ESuperPackageProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "ESuperPackage",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackage),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_ESuperPackage,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EPackage), "ESuperPackage")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ESubPackagesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "ESubPackages",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackage),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_ESubPackages,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EClassifier), "EPackage")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EClassifiersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "EClassifiers",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_EClassifiers,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty EFactoryInstanceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "EFactoryInstance",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EFactory),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EFactoryBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_EFactoryInstance,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EClassifierId), typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier), typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.ENamedElement) })]
		public static class EClassifier
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EClassifier()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EClassifier));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InstanceClassNameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "InstanceClassName",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_InstanceClassName,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EPackage), "EClassifiers")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EPackageProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "EPackage",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackage),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_EPackage,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("TypeParameters")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeParametersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "ETypeParameters",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameter),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameterBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_ETypeParameters,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InstanceClassProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "InstanceClass",
			        immutableType: typeof(System.Type),
			        mutableType: typeof(System.Type),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_InstanceClass,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DefaultValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "DefaultValue",
			        immutableType: typeof(object),
			        mutableType: typeof(object),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_DefaultValue,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.ClassTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EClassId), typeof(global::MetaDslx.Languages.Ecore.Model.EClass), typeof(global::MetaDslx.Languages.Ecore.Model.EClassBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EClassifier) })]
		public static class EClass
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EClass()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EClass));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("IsAbstract")]
			public static readonly global::MetaDslx.Modeling.ModelProperty AbstractProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "Abstract",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_Abstract,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InterfaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "Interface",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_Interface,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("BaseTypes")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ESuperTypesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "ESuperTypes",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClass),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_ESuperTypes,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllSuperTypesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllSuperTypes",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClass),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllSuperTypes,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EStructuralFeature), "EContainingClass")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EStructuralFeaturesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EStructuralFeatures",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EStructuralFeature),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EStructuralFeatureBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EStructuralFeatures,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllStructuralFeaturesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllStructuralFeatures",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EStructuralFeature),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EStructuralFeatureBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllStructuralFeatures,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EOperation), "EContainingClass")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EOperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EOperations",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EOperation),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EOperations,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllOperationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllOperation",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EOperation),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllOperation,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EReferencesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EReferences",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EReference),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EReferenceBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EReferences,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllReferencesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllReferences",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EReference),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EReferenceBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllReferences,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllContainmentsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllContainments",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EReference),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EReferenceBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllContainments,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAttributesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAttributes",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttribute),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttributeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAttributes,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllAttributesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllAttributes",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttribute),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttributeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllAttributes,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EIDAttributeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EIDAttribute",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttribute),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttributeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EIDAttribute,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EGenericSuperTypesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EGenericSuperTypes",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EGenericSuperTypes,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllGenericSuperTypesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllGenericSuperTypes",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllGenericSuperTypes,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EDataTypeId), typeof(global::MetaDslx.Languages.Ecore.Model.EDataType), typeof(global::MetaDslx.Languages.Ecore.Model.EDataTypeBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EClassifier) })]
		public static class EDataType
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EDataType()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EDataType));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EDataType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SerializableProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EDataType), name: "Serializable",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EDataType_Serializable,
					defaultValue: true);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DotNetNameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EDataType), name: "DotNetName",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EDataType_DotNetName,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.EnumTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EEnumId), typeof(global::MetaDslx.Languages.Ecore.Model.EEnum), typeof(global::MetaDslx.Languages.Ecore.Model.EEnumBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EDataType) })]
		public static class EEnum
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EEnum()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EEnum));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnum; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EEnumLiteral), "EEnum")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ELiteralsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EEnum), name: "ELiterals",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EEnumLiteral),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EEnumLiteralBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnum_ELiterals,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.EnumLiteralSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EEnumLiteralId), typeof(global::MetaDslx.Languages.Ecore.Model.EEnumLiteral), typeof(global::MetaDslx.Languages.Ecore.Model.EEnumLiteralBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.ENamedElement) })]
		public static class EEnumLiteral
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EEnumLiteral()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EEnumLiteral));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnumLiteral; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EEnum), "ELiterals")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EEnumProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EEnumLiteral), name: "EEnum",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EEnum),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EEnumBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnumLiteral_EEnum,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EEnumLiteral), name: "Value",
			        immutableType: typeof(int),
			        mutableType: typeof(int),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnumLiteral_Value,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InstanceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EEnumLiteral), name: "Instance",
			        immutableType: typeof(System.Collections.IEnumerator),
			        mutableType: typeof(System.Collections.IEnumerator),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnumLiteral_Instance,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.ETypedElementId), typeof(global::MetaDslx.Languages.Ecore.Model.ETypedElement), typeof(global::MetaDslx.Languages.Ecore.Model.ETypedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.ENamedElement) })]
		public static class ETypedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ETypedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ETypedElement));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "EType",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_EType,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty OrderedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "Ordered",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_Ordered,
					defaultValue: true);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty UniqueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "Unique",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_Unique,
					defaultValue: true);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LowerBoundProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "LowerBound",
			        immutableType: typeof(int),
			        mutableType: typeof(int),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_LowerBound,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty UpperBoundProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "UpperBound",
			        immutableType: typeof(int),
			        mutableType: typeof(int),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_UpperBound,
					defaultValue: 1);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ManyProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "Many",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_Many,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty RequiredProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "Required",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_Required,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EGenericTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "EGenericType",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_EGenericType,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.PropertySymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EStructuralFeatureId), typeof(global::MetaDslx.Languages.Ecore.Model.EStructuralFeature), typeof(global::MetaDslx.Languages.Ecore.Model.EStructuralFeatureBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.ETypedElement) })]
		public static class EStructuralFeature
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EStructuralFeature()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EStructuralFeature));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EClass), "EStructuralFeatures")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EContainingClassProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "EContainingClass",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClass),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_EContainingClass,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Type")]
			[global::MetaDslx.Modeling.SubsetsAttribute(typeof(EcoreDescriptor.ETypedElement), "EType")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "EType",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_EType,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ChangeableProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "Changeable",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_Changeable,
					defaultValue: true);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty VolatileProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "Volatile",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_Volatile,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty TransientProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "Transient",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_Transient,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DefaultValueLiteralProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "DefaultValueLiteral",
			        immutableType: typeof(String),
			        mutableType: typeof(String),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_DefaultValueLiteral,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DefaultValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "DefaultValue",
			        immutableType: typeof(object),
			        mutableType: typeof(object),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_DefaultValue,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty UnsettableProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "Unsettable",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_Unsettable,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DerivedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "Derived",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_Derived,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EAttributeId), typeof(global::MetaDslx.Languages.Ecore.Model.EAttribute), typeof(global::MetaDslx.Languages.Ecore.Model.EAttributeBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EStructuralFeature) })]
		public static class EAttribute
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EAttribute()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EAttribute));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAttribute; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IDProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAttribute), name: "ID",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAttribute_ID,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EAttributeTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAttribute), name: "EAttributeType",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EDataType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EDataTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAttribute_EAttributeType,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EReferenceId), typeof(global::MetaDslx.Languages.Ecore.Model.EReference), typeof(global::MetaDslx.Languages.Ecore.Model.EReferenceBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.EStructuralFeature) })]
		public static class EReference
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EReference()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EReference));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EReference; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ContainmentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EReference), name: "Containment",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EReference_Containment,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ContainerProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EReference), name: "Container",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EReference_Container,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ResolveProxiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EReference), name: "ResolveProxies",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EReference_ResolveProxies,
					defaultValue: true);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty EOppositeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EReference), name: "EOpposite",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EReference),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EReferenceBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EReference_EOpposite,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty EReferenceTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EReference), name: "EReferenceType",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClass),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EReference_EReferenceType,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.MethodSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EOperationId), typeof(global::MetaDslx.Languages.Ecore.Model.EOperation), typeof(global::MetaDslx.Languages.Ecore.Model.EOperationBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.ETypedElement) })]
		public static class EOperation
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EOperation()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EOperation));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EOperation; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EClass), "EOperations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EContainingClassProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EOperation), name: "EContainingClass",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClass),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EOperation_EContainingClass,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("ReturnType")]
			[global::MetaDslx.Modeling.RedefinesAttribute(typeof(EcoreDescriptor.ETypedElement), "EType")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EOperation), name: "EType",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EOperation_EType,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Parameters")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EParameter), "EOperation")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EParametersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EOperation), name: "EParameters",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EParameter),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EParameterBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EOperation_EParameters,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EExceptionsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EOperation), name: "EExceptions",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EOperation_EExceptions,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("TypeParameters")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeParametersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EOperation), name: "ETypeParameters",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameter),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameterBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EOperation_ETypeParameters,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EGenericExceptionsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EOperation), name: "EGenericExceptions",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EOperation_EGenericExceptions,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.ParameterSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EParameterId), typeof(global::MetaDslx.Languages.Ecore.Model.EParameter), typeof(global::MetaDslx.Languages.Ecore.Model.EParameterBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.ETypedElement) })]
		public static class EParameter
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EParameter()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EParameter));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EParameter; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EOperation), "EParameters")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EOperationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EParameter), name: "EOperation",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EOperation),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EParameter_EOperation,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EGenericTypeId), typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType), typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder))]
		public static class EGenericType
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EGenericType()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EGenericType));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty EClassifierProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "EClassifier",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_EClassifier,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ERawTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "ERawType",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_ERawType,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.ETypeParameter), "EGenericTypes")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeParameterProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "ETypeParameter",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameter),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameterBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_ETypeParameter,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ELowerBoundProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "ELowerBound",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_ELowerBound,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EUpperBoundProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "EUpperBound",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_EUpperBound,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("TypeArguments")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeArgumentsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "ETypeArguments",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_ETypeArguments,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.ETypeParameterId), typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameter), typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameterBuilder), BaseDescriptors = new global::System.Type[] { typeof(EcoreDescriptor.ENamedElement) })]
		public static class ETypeParameter
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ETypeParameter()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ETypeParameter));
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
				get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypeParameter; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EGenericType), "ETypeParameter")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EGenericTypesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypeParameter), name: "EGenericTypes",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypeParameter_EGenericTypes,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EBoundsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypeParameter), name: "EBounds",
			        immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
			        mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypeParameter_EBounds,
					defaultValue: null);
		}
	}
}

namespace MetaDslx.Languages.Ecore.Model.Internal
{
	
	internal class EObjectId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EObject.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EObjectImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EObjectBuilderImpl(this, model, creating);
		}
	}
	
	internal class EObjectImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EObject
	{
	
		internal EObjectImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EObject; }
		}
	
		public new EObjectBuilder ToMutable()
		{
			return (EObjectBuilder)base.ToMutable();
		}
	
		public new EObjectBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EObjectBuilder)base.ToMutable(model);
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	}
	
	internal class EObjectBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EObjectBuilder
	{
	
		internal EObjectBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EObject(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EObject; }
		}
	
		public new EObject ToImmutable()
		{
			return (EObject)base.ToImmutable();
		}
	
		public new EObject ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EObject)base.ToImmutable(model);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	}
	
	internal class EModelElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EModelElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EModelElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class EModelElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EModelElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
	
		internal EModelElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EModelElement; }
		}
	
		public new EModelElementBuilder ToMutable()
		{
			return (EModelElementBuilder)base.ToMutable();
		}
	
		public new EModelElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EModelElementBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EModelElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EModelElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal EModelElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EModelElement(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EModelElement; }
		}
	
		public new EModelElement ToImmutable()
		{
			return (EModelElement)base.ToImmutable();
		}
	
		public new EModelElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EModelElement)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EFactoryId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EFactory.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EFactoryImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EFactoryBuilderImpl(this, model, creating);
		}
	}
	
	internal class EFactoryImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EFactory
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
	
		internal EFactoryImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EFactory; }
		}
	
		public new EFactoryBuilder ToMutable()
		{
			return (EFactoryBuilder)base.ToMutable();
		}
	
		public new EFactoryBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EFactoryBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public EPackage EPackage
		{
		    get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EFactory.EPackageProperty, ref ePackage0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		EObject EFactory.Create(EClass eClass)
		{
		    return EcoreImplementationProvider.Implementation.EFactory_Create(this, eClass);
		}
	
		
		EObject EFactory.CreateFromString(EDataType eDataType, String literalValue)
		{
		    return EcoreImplementationProvider.Implementation.EFactory_CreateFromString(this, eDataType, literalValue);
		}
	
		
		String EFactory.ConvertToString(EDataType eDataType, object instanceValue)
		{
		    return EcoreImplementationProvider.Implementation.EFactory_ConvertToString(this, eDataType, instanceValue);
		}
	}
	
	internal class EFactoryBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EFactoryBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal EFactoryBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EFactory(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EFactory; }
		}
	
		public new EFactory ToImmutable()
		{
			return (EFactory)base.ToImmutable();
		}
	
		public new EFactory ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EFactory)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public EPackageBuilder EPackage
		{
			get { return this.GetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EFactory.EPackageProperty); }
			set { this.SetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EFactory.EPackageProperty, value); }
		}
		
		void EFactoryBuilder.SetEPackageLazy(global::System.Func<EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EFactory.EPackageProperty, lazy);
		}
		
		void EFactoryBuilder.SetEPackageLazy(global::System.Func<EFactoryBuilder, EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EFactory.EPackageProperty, lazy);
		}
		
		void EFactoryBuilder.SetEPackageLazy(global::System.Func<EFactory, EPackage> immutableLazy, global::System.Func<EFactoryBuilder, EPackageBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EFactory.EPackageProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		EObjectBuilder EFactoryBuilder.Create(EClassBuilder eClass)
		{
		    return EcoreImplementationProvider.Implementation.EFactory_Create(this, eClass);
		}
	
		
		EObjectBuilder EFactoryBuilder.CreateFromString(EDataTypeBuilder eDataType, String literalValue)
		{
		    return EcoreImplementationProvider.Implementation.EFactory_CreateFromString(this, eDataType, literalValue);
		}
	
		
		String EFactoryBuilder.ConvertToString(EDataTypeBuilder eDataType, object instanceValue)
		{
		    return EcoreImplementationProvider.Implementation.EFactory_ConvertToString(this, eDataType, instanceValue);
		}
	}
	
	internal class ENamedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ENamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ENamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ENamedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ENamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
	
		internal ENamedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.ENamedElement; }
		}
	
		public new ENamedElementBuilder ToMutable()
		{
			return (ENamedElementBuilder)base.ToMutable();
		}
	
		public new ENamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ENamedElementBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class ENamedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ENamedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal ENamedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.ENamedElement(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.ENamedElement; }
		}
	
		public new ENamedElement ToImmutable()
		{
			return (ENamedElement)base.ToImmutable();
		}
	
		public new ENamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ENamedElement)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EAnnotationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EAnnotationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EAnnotationBuilderImpl(this, model, creating);
		}
	}
	
	internal class EAnnotationImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EAnnotation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EModelElement eModelElement0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String source0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EStringToStringMapEntry> details0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EObject> contents0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EObject> references0;
	
		internal EAnnotationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EAnnotation; }
		}
	
		public new EAnnotationBuilder ToMutable()
		{
			return (EAnnotationBuilder)base.ToMutable();
		}
	
		public new EAnnotationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EAnnotationBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public EModelElement EModelElement
		{
		    get { return this.GetReference<EModelElement>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.EModelElementProperty, ref eModelElement0); }
		}
	
		
		public String Source
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.SourceProperty, ref source0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EStringToStringMapEntry> Details
		{
		    get { return this.GetList<EStringToStringMapEntry>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.DetailsProperty, ref details0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EObject> Contents
		{
		    get { return this.GetList<EObject>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.ContentsProperty, ref contents0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EObject> References
		{
		    get { return this.GetList<EObject>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.ReferencesProperty, ref references0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EAnnotationBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EAnnotationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<EStringToStringMapEntryBuilder> details0;
		private global::MetaDslx.Modeling.MutableModelList<EObjectBuilder> contents0;
		private global::MetaDslx.Modeling.MutableModelList<EObjectBuilder> references0;
	
		internal EAnnotationBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EAnnotation(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EAnnotation; }
		}
	
		public new EAnnotation ToImmutable()
		{
			return (EAnnotation)base.ToImmutable();
		}
	
		public new EAnnotation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EAnnotation)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public EModelElementBuilder EModelElement
		{
			get { return this.GetReference<EModelElementBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.EModelElementProperty); }
			set { this.SetReference<EModelElementBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.EModelElementProperty, value); }
		}
		
		void EAnnotationBuilder.SetEModelElementLazy(global::System.Func<EModelElementBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.EModelElementProperty, lazy);
		}
		
		void EAnnotationBuilder.SetEModelElementLazy(global::System.Func<EAnnotationBuilder, EModelElementBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.EModelElementProperty, lazy);
		}
		
		void EAnnotationBuilder.SetEModelElementLazy(global::System.Func<EAnnotation, EModelElement> immutableLazy, global::System.Func<EAnnotationBuilder, EModelElementBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.EModelElementProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Source
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.SourceProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.SourceProperty, value); }
		}
		
		void EAnnotationBuilder.SetSourceLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.SourceProperty, lazy);
		}
		
		void EAnnotationBuilder.SetSourceLazy(global::System.Func<EAnnotationBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.SourceProperty, lazy);
		}
		
		void EAnnotationBuilder.SetSourceLazy(global::System.Func<EAnnotation, String> immutableLazy, global::System.Func<EAnnotationBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.SourceProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EStringToStringMapEntryBuilder> Details
		{
			get { return this.GetList<EStringToStringMapEntryBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.DetailsProperty, ref details0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EObjectBuilder> Contents
		{
			get { return this.GetList<EObjectBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.ContentsProperty, ref contents0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EObjectBuilder> References
		{
			get { return this.GetList<EObjectBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.ReferencesProperty, ref references0); }
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EStringToStringMapEntryId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EStringToStringMapEntryImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EStringToStringMapEntryBuilderImpl(this, model, creating);
		}
	}
	
	internal class EStringToStringMapEntryImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EStringToStringMapEntry
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String key0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String value0;
	
		internal EStringToStringMapEntryImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EStringToStringMapEntry; }
		}
	
		public new EStringToStringMapEntryBuilder ToMutable()
		{
			return (EStringToStringMapEntryBuilder)base.ToMutable();
		}
	
		public new EStringToStringMapEntryBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EStringToStringMapEntryBuilder)base.ToMutable(model);
		}
	
		
		public String Key
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.KeyProperty, ref key0); }
		}
	
		
		public String Value
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.ValueProperty, ref value0); }
		}
	}
	
	internal class EStringToStringMapEntryBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EStringToStringMapEntryBuilder
	{
	
		internal EStringToStringMapEntryBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EStringToStringMapEntry(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EStringToStringMapEntry; }
		}
	
		public new EStringToStringMapEntry ToImmutable()
		{
			return (EStringToStringMapEntry)base.ToImmutable();
		}
	
		public new EStringToStringMapEntry ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EStringToStringMapEntry)base.ToImmutable(model);
		}
	
		
		public String Key
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.KeyProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.KeyProperty, value); }
		}
		
		void EStringToStringMapEntryBuilder.SetKeyLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.KeyProperty, lazy);
		}
		
		void EStringToStringMapEntryBuilder.SetKeyLazy(global::System.Func<EStringToStringMapEntryBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.KeyProperty, lazy);
		}
		
		void EStringToStringMapEntryBuilder.SetKeyLazy(global::System.Func<EStringToStringMapEntry, String> immutableLazy, global::System.Func<EStringToStringMapEntryBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.KeyProperty, immutableLazy, mutableLazy);
		}
	
		
		public String Value
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.ValueProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.ValueProperty, value); }
		}
		
		void EStringToStringMapEntryBuilder.SetValueLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.ValueProperty, lazy);
		}
		
		void EStringToStringMapEntryBuilder.SetValueLazy(global::System.Func<EStringToStringMapEntryBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.ValueProperty, lazy);
		}
		
		void EStringToStringMapEntryBuilder.SetValueLazy(global::System.Func<EStringToStringMapEntry, String> immutableLazy, global::System.Func<EStringToStringMapEntryBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.ValueProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class EPackageId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EPackageImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EPackageBuilderImpl(this, model, creating);
		}
	}
	
	internal class EPackageImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EPackage
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String nsURI0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String nsPrefix0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage eSuperPackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EPackage> eSubPackages0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EClassifier> eClassifiers0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EFactory eFactoryInstance0;
	
		internal EPackageImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EPackage; }
		}
	
		public new EPackageBuilder ToMutable()
		{
			return (EPackageBuilder)base.ToMutable();
		}
	
		public new EPackageBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EPackageBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public String NsURI
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsURIProperty, ref nsURI0); }
		}
	
		
		public String NsPrefix
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsPrefixProperty, ref nsPrefix0); }
		}
	
		
		public EPackage ESuperPackage
		{
		    get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.ESuperPackageProperty, ref eSuperPackage0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EPackage> ESubPackages
		{
		    get { return this.GetList<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.ESubPackagesProperty, ref eSubPackages0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EClassifier> EClassifiers
		{
		    get { return this.GetList<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.EClassifiersProperty, ref eClassifiers0); }
		}
	
		
		public EFactory EFactoryInstance
		{
		    get { return this.GetReference<EFactory>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.EFactoryInstanceProperty, ref eFactoryInstance0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		EClassifier EPackage.GetEClassifier(String name)
		{
		    return EcoreImplementationProvider.Implementation.EPackage_GetEClassifier(this, name);
		}
	}
	
	internal class EPackageBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EPackageBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<EPackageBuilder> eSubPackages0;
		private global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> eClassifiers0;
	
		internal EPackageBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EPackage(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EPackage; }
		}
	
		public new EPackage ToImmutable()
		{
			return (EPackage)base.ToImmutable();
		}
	
		public new EPackage ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EPackage)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public String NsURI
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsURIProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsURIProperty, value); }
		}
		
		void EPackageBuilder.SetNsURILazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsURIProperty, lazy);
		}
		
		void EPackageBuilder.SetNsURILazy(global::System.Func<EPackageBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsURIProperty, lazy);
		}
		
		void EPackageBuilder.SetNsURILazy(global::System.Func<EPackage, String> immutableLazy, global::System.Func<EPackageBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsURIProperty, immutableLazy, mutableLazy);
		}
	
		
		public String NsPrefix
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsPrefixProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsPrefixProperty, value); }
		}
		
		void EPackageBuilder.SetNsPrefixLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsPrefixProperty, lazy);
		}
		
		void EPackageBuilder.SetNsPrefixLazy(global::System.Func<EPackageBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsPrefixProperty, lazy);
		}
		
		void EPackageBuilder.SetNsPrefixLazy(global::System.Func<EPackage, String> immutableLazy, global::System.Func<EPackageBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsPrefixProperty, immutableLazy, mutableLazy);
		}
	
		
		public EPackageBuilder ESuperPackage
		{
			get { return this.GetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.ESuperPackageProperty); }
			set { this.SetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.ESuperPackageProperty, value); }
		}
		
		void EPackageBuilder.SetESuperPackageLazy(global::System.Func<EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.ESuperPackageProperty, lazy);
		}
		
		void EPackageBuilder.SetESuperPackageLazy(global::System.Func<EPackageBuilder, EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.ESuperPackageProperty, lazy);
		}
		
		void EPackageBuilder.SetESuperPackageLazy(global::System.Func<EPackage, EPackage> immutableLazy, global::System.Func<EPackageBuilder, EPackageBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.ESuperPackageProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EPackageBuilder> ESubPackages
		{
			get { return this.GetList<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.ESubPackagesProperty, ref eSubPackages0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> EClassifiers
		{
			get { return this.GetList<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.EClassifiersProperty, ref eClassifiers0); }
		}
	
		
		public EFactoryBuilder EFactoryInstance
		{
			get { return this.GetReference<EFactoryBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.EFactoryInstanceProperty); }
			set { this.SetReference<EFactoryBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.EFactoryInstanceProperty, value); }
		}
		
		void EPackageBuilder.SetEFactoryInstanceLazy(global::System.Func<EFactoryBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.EFactoryInstanceProperty, lazy);
		}
		
		void EPackageBuilder.SetEFactoryInstanceLazy(global::System.Func<EPackageBuilder, EFactoryBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.EFactoryInstanceProperty, lazy);
		}
		
		void EPackageBuilder.SetEFactoryInstanceLazy(global::System.Func<EPackage, EFactory> immutableLazy, global::System.Func<EPackageBuilder, EFactoryBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.EFactoryInstanceProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		EClassifierBuilder EPackageBuilder.GetEClassifier(String name)
		{
		    return EcoreImplementationProvider.Implementation.EPackage_GetEClassifier(this, name);
		}
	}
	
	internal class EClassifierId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EClassifierImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EClassifierBuilderImpl(this, model, creating);
		}
	}
	
	internal class EClassifierImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EClassifier
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String instanceClassName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type instanceClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
	
		internal EClassifierImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EClassifier; }
		}
	
		public new EClassifierBuilder ToMutable()
		{
			return (EClassifierBuilder)base.ToMutable();
		}
	
		public new EClassifierBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EClassifierBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public String InstanceClassName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, ref instanceClassName0); }
		}
	
		
		public EPackage EPackage
		{
		    get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, ref ePackage0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
		    get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public System.Type InstanceClass
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, ref instanceClass0); }
		}
	
		
		public object DefaultValue
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		bool EClassifier.IsInstance(object @object)
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_IsInstance(this, @object);
		}
	
		
		int EClassifier.GetClassifierID()
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_GetClassifierID(this);
		}
	}
	
	internal class EClassifierBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EClassifierBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> eTypeParameters0;
	
		internal EClassifierBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EClassifier(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EClassifier; }
		}
	
		public new EClassifier ToImmutable()
		{
			return (EClassifier)base.ToImmutable();
		}
	
		public new EClassifier ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EClassifier)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public String InstanceClassName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, value); }
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifier, String> immutableLazy, global::System.Func<EClassifierBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public EPackageBuilder EPackage
		{
			get { return this.GetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty); }
			set { this.SetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, value); }
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, lazy);
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EClassifierBuilder, EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, lazy);
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EClassifier, EPackage> immutableLazy, global::System.Func<EClassifierBuilder, EPackageBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters
		{
			get { return this.GetList<ETypeParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, value); }
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<EClassifierBuilder, System.Type> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<EClassifier, System.Type> immutableLazy, global::System.Func<EClassifierBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, value); }
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, lazy);
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<EClassifierBuilder, object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, lazy);
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<EClassifier, object> immutableLazy, global::System.Func<EClassifierBuilder, object> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		bool EClassifierBuilder.IsInstance(object @object)
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_IsInstance(this, @object);
		}
	
		
		int EClassifierBuilder.GetClassifierID()
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_GetClassifierID(this);
		}
	}
	
	internal class EClassId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EClassImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EClassBuilderImpl(this, model, creating);
		}
	}
	
	internal class EClassImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EClass
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String instanceClassName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type instanceClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool abstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EClass> eSuperTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EClass> eAllSuperTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> eStructuralFeatures0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> eAllStructuralFeatures0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EOperation> eOperations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EOperation> eAllOperation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EReference> eReferences0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EReference> eAllReferences0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EReference> eAllContainments0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAttribute> eAttributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAttribute> eAllAttributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EAttribute eIDAttribute0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eGenericSuperTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eAllGenericSuperTypes0;
	
		internal EClassImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EClass; }
		}
	
		public new EClassBuilder ToMutable()
		{
			return (EClassBuilder)base.ToMutable();
		}
	
		public new EClassBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EClassBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EClassifierBuilder EClassifier.ToMutable()
		{
			return this.ToMutable();
		}
	
		EClassifierBuilder EClassifier.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public String InstanceClassName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, ref instanceClassName0); }
		}
	
		
		public EPackage EPackage
		{
		    get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, ref ePackage0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
		    get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public System.Type InstanceClass
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, ref instanceClass0); }
		}
	
		
		public object DefaultValue
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		public bool Abstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.AbstractProperty, ref abstract0); }
		}
	
		
		public bool Interface
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.InterfaceProperty, ref interface0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EClass> ESuperTypes
		{
		    get { return this.GetList<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.ESuperTypesProperty, ref eSuperTypes0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EClass> EAllSuperTypes
		{
		    get { return this.GetList<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllSuperTypesProperty, ref eAllSuperTypes0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> EStructuralFeatures
		{
		    get { return this.GetList<EStructuralFeature>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EStructuralFeaturesProperty, ref eStructuralFeatures0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> EAllStructuralFeatures
		{
		    get { return this.GetList<EStructuralFeature>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllStructuralFeaturesProperty, ref eAllStructuralFeatures0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EOperation> EOperations
		{
		    get { return this.GetList<EOperation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EOperationsProperty, ref eOperations0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EOperation> EAllOperation
		{
		    get { return this.GetList<EOperation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllOperationProperty, ref eAllOperation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EReference> EReferences
		{
		    get { return this.GetList<EReference>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EReferencesProperty, ref eReferences0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EReference> EAllReferences
		{
		    get { return this.GetList<EReference>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllReferencesProperty, ref eAllReferences0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EReference> EAllContainments
		{
		    get { return this.GetList<EReference>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllContainmentsProperty, ref eAllContainments0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EAttributes
		{
		    get { return this.GetList<EAttribute>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAttributesProperty, ref eAttributes0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EAllAttributes
		{
		    get { return this.GetList<EAttribute>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllAttributesProperty, ref eAllAttributes0); }
		}
	
		
		public EAttribute EIDAttribute
		{
		    get { return this.GetReference<EAttribute>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EIDAttributeProperty, ref eIDAttribute0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericSuperTypes
		{
		    get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EGenericSuperTypesProperty, ref eGenericSuperTypes0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EAllGenericSuperTypes
		{
		    get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllGenericSuperTypesProperty, ref eAllGenericSuperTypes0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		bool EClassifier.IsInstance(object @object)
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_IsInstance(this, @object);
		}
	
		
		int EClassifier.GetClassifierID()
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_GetClassifierID(this);
		}
	
		
		bool EClass.IsSuperTypeOf(EClass someClass)
		{
		    return EcoreImplementationProvider.Implementation.EClass_IsSuperTypeOf(this, someClass);
		}
	
		
		EStructuralFeature EClass.GetStructuralFeature(int featureID)
		{
		    return EcoreImplementationProvider.Implementation.EClass_GetStructuralFeature(this, featureID);
		}
	
		
		EStructuralFeature EClass.GetStructuralFeature(String featureName)
		{
		    return EcoreImplementationProvider.Implementation.EClass_GetStructuralFeature(this, featureName);
		}
	}
	
	internal class EClassBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EClassBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> eTypeParameters0;
		private global::MetaDslx.Modeling.MutableModelList<EClassBuilder> eSuperTypes0;
		private global::MetaDslx.Modeling.MutableModelList<EClassBuilder> eAllSuperTypes0;
		private global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> eStructuralFeatures0;
		private global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> eAllStructuralFeatures0;
		private global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> eOperations0;
		private global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> eAllOperation0;
		private global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> eReferences0;
		private global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> eAllReferences0;
		private global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> eAllContainments0;
		private global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> eAttributes0;
		private global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> eAllAttributes0;
		private global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> eGenericSuperTypes0;
		private global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> eAllGenericSuperTypes0;
	
		internal EClassBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EClass(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EClass; }
		}
	
		public new EClass ToImmutable()
		{
			return (EClass)base.ToImmutable();
		}
	
		public new EClass ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EClass)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EClassifier EClassifierBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EClassifier EClassifierBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public String InstanceClassName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, value); }
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifier, String> immutableLazy, global::System.Func<EClassifierBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public EPackageBuilder EPackage
		{
			get { return this.GetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty); }
			set { this.SetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, value); }
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, lazy);
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EClassifierBuilder, EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, lazy);
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EClassifier, EPackage> immutableLazy, global::System.Func<EClassifierBuilder, EPackageBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters
		{
			get { return this.GetList<ETypeParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, value); }
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<EClassifierBuilder, System.Type> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<EClassifier, System.Type> immutableLazy, global::System.Func<EClassifierBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, value); }
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, lazy);
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<EClassifierBuilder, object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, lazy);
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<EClassifier, object> immutableLazy, global::System.Func<EClassifierBuilder, object> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Abstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.AbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.AbstractProperty, value); }
		}
		
		void EClassBuilder.SetAbstractLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EClass.AbstractProperty, lazy);
		}
		
		void EClassBuilder.SetAbstractLazy(global::System.Func<EClassBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EClass.AbstractProperty, lazy);
		}
		
		void EClassBuilder.SetAbstractLazy(global::System.Func<EClass, bool> immutableLazy, global::System.Func<EClassBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EClass.AbstractProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Interface
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.InterfaceProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.InterfaceProperty, value); }
		}
		
		void EClassBuilder.SetInterfaceLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EClass.InterfaceProperty, lazy);
		}
		
		void EClassBuilder.SetInterfaceLazy(global::System.Func<EClassBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EClass.InterfaceProperty, lazy);
		}
		
		void EClassBuilder.SetInterfaceLazy(global::System.Func<EClass, bool> immutableLazy, global::System.Func<EClassBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EClass.InterfaceProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EClassBuilder> ESuperTypes
		{
			get { return this.GetList<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.ESuperTypesProperty, ref eSuperTypes0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EClassBuilder> EAllSuperTypes
		{
			get { return this.GetList<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllSuperTypesProperty, ref eAllSuperTypes0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> EStructuralFeatures
		{
			get { return this.GetList<EStructuralFeatureBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EStructuralFeaturesProperty, ref eStructuralFeatures0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> EAllStructuralFeatures
		{
			get { return this.GetList<EStructuralFeatureBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllStructuralFeaturesProperty, ref eAllStructuralFeatures0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> EOperations
		{
			get { return this.GetList<EOperationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EOperationsProperty, ref eOperations0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> EAllOperation
		{
			get { return this.GetList<EOperationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllOperationProperty, ref eAllOperation0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EReferences
		{
			get { return this.GetList<EReferenceBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EReferencesProperty, ref eReferences0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EAllReferences
		{
			get { return this.GetList<EReferenceBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllReferencesProperty, ref eAllReferences0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EAllContainments
		{
			get { return this.GetList<EReferenceBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllContainmentsProperty, ref eAllContainments0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EAttributes
		{
			get { return this.GetList<EAttributeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAttributesProperty, ref eAttributes0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EAllAttributes
		{
			get { return this.GetList<EAttributeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllAttributesProperty, ref eAllAttributes0); }
		}
	
		
		public EAttributeBuilder EIDAttribute
		{
			get { return this.GetReference<EAttributeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EIDAttributeProperty); }
		}
		
		void EClassBuilder.SetEIDAttributeLazy(global::System.Func<EAttributeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClass.EIDAttributeProperty, lazy);
		}
		
		void EClassBuilder.SetEIDAttributeLazy(global::System.Func<EClassBuilder, EAttributeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClass.EIDAttributeProperty, lazy);
		}
		
		void EClassBuilder.SetEIDAttributeLazy(global::System.Func<EClass, EAttribute> immutableLazy, global::System.Func<EClassBuilder, EAttributeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClass.EIDAttributeProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericSuperTypes
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EGenericSuperTypesProperty, ref eGenericSuperTypes0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EAllGenericSuperTypes
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllGenericSuperTypesProperty, ref eAllGenericSuperTypes0); }
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		bool EClassifierBuilder.IsInstance(object @object)
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_IsInstance(this, @object);
		}
	
		
		int EClassifierBuilder.GetClassifierID()
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_GetClassifierID(this);
		}
	
		
		bool EClassBuilder.IsSuperTypeOf(EClassBuilder someClass)
		{
		    return EcoreImplementationProvider.Implementation.EClass_IsSuperTypeOf(this, someClass);
		}
	
		
		EStructuralFeatureBuilder EClassBuilder.GetStructuralFeature(int featureID)
		{
		    return EcoreImplementationProvider.Implementation.EClass_GetStructuralFeature(this, featureID);
		}
	
		
		EStructuralFeatureBuilder EClassBuilder.GetStructuralFeature(String featureName)
		{
		    return EcoreImplementationProvider.Implementation.EClass_GetStructuralFeature(this, featureName);
		}
	}
	
	internal class EDataTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EDataTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EDataTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class EDataTypeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EDataType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String instanceClassName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type instanceClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool serializable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String dotNetName0;
	
		internal EDataTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EDataType; }
		}
	
		public new EDataTypeBuilder ToMutable()
		{
			return (EDataTypeBuilder)base.ToMutable();
		}
	
		public new EDataTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EDataTypeBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EClassifierBuilder EClassifier.ToMutable()
		{
			return this.ToMutable();
		}
	
		EClassifierBuilder EClassifier.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public String InstanceClassName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, ref instanceClassName0); }
		}
	
		
		public EPackage EPackage
		{
		    get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, ref ePackage0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
		    get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public System.Type InstanceClass
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, ref instanceClass0); }
		}
	
		
		public object DefaultValue
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		public bool Serializable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.SerializableProperty, ref serializable0); }
		}
	
		
		public String DotNetName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.DotNetNameProperty, ref dotNetName0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		bool EClassifier.IsInstance(object @object)
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_IsInstance(this, @object);
		}
	
		
		int EClassifier.GetClassifierID()
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_GetClassifierID(this);
		}
	}
	
	internal class EDataTypeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EDataTypeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> eTypeParameters0;
	
		internal EDataTypeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EDataType(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EDataType; }
		}
	
		public new EDataType ToImmutable()
		{
			return (EDataType)base.ToImmutable();
		}
	
		public new EDataType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EDataType)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EClassifier EClassifierBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EClassifier EClassifierBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public String InstanceClassName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, value); }
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifier, String> immutableLazy, global::System.Func<EClassifierBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public EPackageBuilder EPackage
		{
			get { return this.GetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty); }
			set { this.SetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, value); }
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, lazy);
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EClassifierBuilder, EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, lazy);
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EClassifier, EPackage> immutableLazy, global::System.Func<EClassifierBuilder, EPackageBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters
		{
			get { return this.GetList<ETypeParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, value); }
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<EClassifierBuilder, System.Type> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<EClassifier, System.Type> immutableLazy, global::System.Func<EClassifierBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, value); }
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, lazy);
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<EClassifierBuilder, object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, lazy);
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<EClassifier, object> immutableLazy, global::System.Func<EClassifierBuilder, object> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Serializable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.SerializableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.SerializableProperty, value); }
		}
		
		void EDataTypeBuilder.SetSerializableLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EDataType.SerializableProperty, lazy);
		}
		
		void EDataTypeBuilder.SetSerializableLazy(global::System.Func<EDataTypeBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EDataType.SerializableProperty, lazy);
		}
		
		void EDataTypeBuilder.SetSerializableLazy(global::System.Func<EDataType, bool> immutableLazy, global::System.Func<EDataTypeBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EDataType.SerializableProperty, immutableLazy, mutableLazy);
		}
	
		
		public String DotNetName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.DotNetNameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.DotNetNameProperty, value); }
		}
		
		void EDataTypeBuilder.SetDotNetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EDataType.DotNetNameProperty, lazy);
		}
		
		void EDataTypeBuilder.SetDotNetNameLazy(global::System.Func<EDataTypeBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EDataType.DotNetNameProperty, lazy);
		}
		
		void EDataTypeBuilder.SetDotNetNameLazy(global::System.Func<EDataType, String> immutableLazy, global::System.Func<EDataTypeBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EDataType.DotNetNameProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		bool EClassifierBuilder.IsInstance(object @object)
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_IsInstance(this, @object);
		}
	
		
		int EClassifierBuilder.GetClassifierID()
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_GetClassifierID(this);
		}
	}
	
	internal class EEnumId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnum.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EEnumImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EEnumBuilderImpl(this, model, creating);
		}
	}
	
	internal class EEnumImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EEnum
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String instanceClassName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type instanceClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool serializable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String dotNetName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EEnumLiteral> eLiterals0;
	
		internal EEnumImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EEnum; }
		}
	
		public new EEnumBuilder ToMutable()
		{
			return (EEnumBuilder)base.ToMutable();
		}
	
		public new EEnumBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EEnumBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EClassifierBuilder EClassifier.ToMutable()
		{
			return this.ToMutable();
		}
	
		EClassifierBuilder EClassifier.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EDataTypeBuilder EDataType.ToMutable()
		{
			return this.ToMutable();
		}
	
		EDataTypeBuilder EDataType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public String InstanceClassName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, ref instanceClassName0); }
		}
	
		
		public EPackage EPackage
		{
		    get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, ref ePackage0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
		    get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public System.Type InstanceClass
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, ref instanceClass0); }
		}
	
		
		public object DefaultValue
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		public bool Serializable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.SerializableProperty, ref serializable0); }
		}
	
		
		public String DotNetName
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.DotNetNameProperty, ref dotNetName0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EEnumLiteral> ELiterals
		{
		    get { return this.GetList<EEnumLiteral>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnum.ELiteralsProperty, ref eLiterals0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		bool EClassifier.IsInstance(object @object)
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_IsInstance(this, @object);
		}
	
		
		int EClassifier.GetClassifierID()
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_GetClassifierID(this);
		}
	
		
		EEnumLiteral EEnum.GetEEnumLiteral(String name)
		{
		    return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteral(this, name);
		}
	
		
		EEnumLiteral EEnum.GetEEnumLiteral(int value)
		{
		    return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteral(this, value);
		}
	}
	
	internal class EEnumBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EEnumBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> eTypeParameters0;
		private global::MetaDslx.Modeling.MutableModelList<EEnumLiteralBuilder> eLiterals0;
	
		internal EEnumBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EEnum(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EEnum; }
		}
	
		public new EEnum ToImmutable()
		{
			return (EEnum)base.ToImmutable();
		}
	
		public new EEnum ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EEnum)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EClassifier EClassifierBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EClassifier EClassifierBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EDataType EDataTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EDataType EDataTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public String InstanceClassName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, value); }
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifier, String> immutableLazy, global::System.Func<EClassifierBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public EPackageBuilder EPackage
		{
			get { return this.GetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty); }
			set { this.SetReference<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, value); }
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, lazy);
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EClassifierBuilder, EPackageBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, lazy);
		}
		
		void EClassifierBuilder.SetEPackageLazy(global::System.Func<EClassifier, EPackage> immutableLazy, global::System.Func<EClassifierBuilder, EPackageBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.EPackageProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters
		{
			get { return this.GetList<ETypeParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, value); }
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<EClassifierBuilder, System.Type> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, lazy);
		}
		
		void EClassifierBuilder.SetInstanceClassLazy(global::System.Func<EClassifier, System.Type> immutableLazy, global::System.Func<EClassifierBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, value); }
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, lazy);
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<EClassifierBuilder, object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, lazy);
		}
		
		void EClassifierBuilder.SetDefaultValueLazy(global::System.Func<EClassifier, object> immutableLazy, global::System.Func<EClassifierBuilder, object> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Serializable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.SerializableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.SerializableProperty, value); }
		}
		
		void EDataTypeBuilder.SetSerializableLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EDataType.SerializableProperty, lazy);
		}
		
		void EDataTypeBuilder.SetSerializableLazy(global::System.Func<EDataTypeBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EDataType.SerializableProperty, lazy);
		}
		
		void EDataTypeBuilder.SetSerializableLazy(global::System.Func<EDataType, bool> immutableLazy, global::System.Func<EDataTypeBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EDataType.SerializableProperty, immutableLazy, mutableLazy);
		}
	
		
		public String DotNetName
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.DotNetNameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.DotNetNameProperty, value); }
		}
		
		void EDataTypeBuilder.SetDotNetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EDataType.DotNetNameProperty, lazy);
		}
		
		void EDataTypeBuilder.SetDotNetNameLazy(global::System.Func<EDataTypeBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EDataType.DotNetNameProperty, lazy);
		}
		
		void EDataTypeBuilder.SetDotNetNameLazy(global::System.Func<EDataType, String> immutableLazy, global::System.Func<EDataTypeBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EDataType.DotNetNameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EEnumLiteralBuilder> ELiterals
		{
			get { return this.GetList<EEnumLiteralBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnum.ELiteralsProperty, ref eLiterals0); }
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		bool EClassifierBuilder.IsInstance(object @object)
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_IsInstance(this, @object);
		}
	
		
		int EClassifierBuilder.GetClassifierID()
		{
		    return EcoreImplementationProvider.Implementation.EClassifier_GetClassifierID(this);
		}
	
		
		EEnumLiteralBuilder EEnumBuilder.GetEEnumLiteral(String name)
		{
		    return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteral(this, name);
		}
	
		
		EEnumLiteralBuilder EEnumBuilder.GetEEnumLiteral(int value)
		{
		    return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteral(this, value);
		}
	}
	
	internal class EEnumLiteralId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EEnumLiteralImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EEnumLiteralBuilderImpl(this, model, creating);
		}
	}
	
	internal class EEnumLiteralImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EEnumLiteral
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EEnum eEnum0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int value0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Collections.IEnumerator instance0;
	
		internal EEnumLiteralImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EEnumLiteral; }
		}
	
		public new EEnumLiteralBuilder ToMutable()
		{
			return (EEnumLiteralBuilder)base.ToMutable();
		}
	
		public new EEnumLiteralBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EEnumLiteralBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public EEnum EEnum
		{
		    get { return this.GetReference<EEnum>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.EEnumProperty, ref eEnum0); }
		}
	
		
		public int Value
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.ValueProperty, ref value0); }
		}
	
		
		public System.Collections.IEnumerator Instance
		{
		    get { return this.GetReference<System.Collections.IEnumerator>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.InstanceProperty, ref instance0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EEnumLiteralBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EEnumLiteralBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal EEnumLiteralBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EEnumLiteral(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EEnumLiteral; }
		}
	
		public new EEnumLiteral ToImmutable()
		{
			return (EEnumLiteral)base.ToImmutable();
		}
	
		public new EEnumLiteral ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EEnumLiteral)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public EEnumBuilder EEnum
		{
			get { return this.GetReference<EEnumBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.EEnumProperty); }
			set { this.SetReference<EEnumBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.EEnumProperty, value); }
		}
		
		void EEnumLiteralBuilder.SetEEnumLazy(global::System.Func<EEnumBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.EEnumProperty, lazy);
		}
		
		void EEnumLiteralBuilder.SetEEnumLazy(global::System.Func<EEnumLiteralBuilder, EEnumBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.EEnumProperty, lazy);
		}
		
		void EEnumLiteralBuilder.SetEEnumLazy(global::System.Func<EEnumLiteral, EEnum> immutableLazy, global::System.Func<EEnumLiteralBuilder, EEnumBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.EEnumProperty, immutableLazy, mutableLazy);
		}
	
		
		public int Value
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.ValueProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.ValueProperty, value); }
		}
		
		void EEnumLiteralBuilder.SetValueLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EEnumLiteral.ValueProperty, lazy);
		}
		
		void EEnumLiteralBuilder.SetValueLazy(global::System.Func<EEnumLiteralBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EEnumLiteral.ValueProperty, lazy);
		}
		
		void EEnumLiteralBuilder.SetValueLazy(global::System.Func<EEnumLiteral, int> immutableLazy, global::System.Func<EEnumLiteralBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EEnumLiteral.ValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public System.Collections.IEnumerator Instance
		{
			get { return this.GetReference<System.Collections.IEnumerator>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.InstanceProperty); }
			set { this.SetReference<System.Collections.IEnumerator>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.InstanceProperty, value); }
		}
		
		void EEnumLiteralBuilder.SetInstanceLazy(global::System.Func<System.Collections.IEnumerator> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.InstanceProperty, lazy);
		}
		
		void EEnumLiteralBuilder.SetInstanceLazy(global::System.Func<EEnumLiteralBuilder, System.Collections.IEnumerator> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.InstanceProperty, lazy);
		}
		
		void EEnumLiteralBuilder.SetInstanceLazy(global::System.Func<EEnumLiteral, System.Collections.IEnumerator> immutableLazy, global::System.Func<EEnumLiteralBuilder, System.Collections.IEnumerator> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.InstanceProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class ETypedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ETypedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ETypedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ETypedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ETypedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ordered0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unique0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int lowerBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int upperBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool many0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool required0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
	
		internal ETypedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.ETypedElement; }
		}
	
		public new ETypedElementBuilder ToMutable()
		{
			return (ETypedElementBuilder)base.ToMutable();
		}
	
		public new ETypedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ETypedElementBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public EClassifier EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}
	
		
		public bool Ordered
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, ref ordered0); }
		}
	
		
		public bool Unique
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, ref unique0); }
		}
	
		
		public int LowerBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, ref lowerBound0); }
		}
	
		
		public int UpperBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, ref upperBound0); }
		}
	
		
		public bool Many
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty, ref many0); }
		}
	
		
		public bool Required
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty, ref required0); }
		}
	
		
		public EGenericType EGenericType
		{
		    get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class ETypedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ETypedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal ETypedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.ETypedElement(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.ETypedElement; }
		}
	
		public new ETypedElement ToImmutable()
		{
			return (ETypedElement)base.ToImmutable();
		}
	
		public new ETypedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ETypedElement)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassifierBuilder EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElementBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElement, EClassifier> immutableLazy, global::System.Func<ETypedElementBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Ordered
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, value); }
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unique
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, value); }
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, immutableLazy, mutableLazy);
		}
	
		
		public int LowerBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public int UpperBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Many
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty); }
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Required
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty); }
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, immutableLazy, mutableLazy);
		}
	
		
		public EGenericTypeBuilder EGenericType
		{
			get { return this.GetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty); }
			set { this.SetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElement, EGenericType> immutableLazy, global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EStructuralFeatureId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EStructuralFeatureImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EStructuralFeatureBuilderImpl(this, model, creating);
		}
	}
	
	internal class EStructuralFeatureImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EStructuralFeature
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ordered0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unique0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int lowerBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int upperBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool many0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool required0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eContainingClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool changeable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool volatile0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool transient0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String defaultValueLiteral0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unsettable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool derived0;
	
		internal EStructuralFeatureImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EStructuralFeature; }
		}
	
		public new EStructuralFeatureBuilder ToMutable()
		{
			return (EStructuralFeatureBuilder)base.ToMutable();
		}
	
		public new EStructuralFeatureBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EStructuralFeatureBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ETypedElementBuilder ETypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ETypedElementBuilder ETypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		EClassifier ETypedElement.EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}
	
		
		public bool Ordered
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, ref ordered0); }
		}
	
		
		public bool Unique
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, ref unique0); }
		}
	
		
		public int LowerBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, ref lowerBound0); }
		}
	
		
		public int UpperBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, ref upperBound0); }
		}
	
		
		public bool Many
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty, ref many0); }
		}
	
		
		public bool Required
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty, ref required0); }
		}
	
		
		public EGenericType EGenericType
		{
		    get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}
	
		
		public EClass EContainingClass
		{
		    get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, ref eContainingClass0); }
		}
	
		
		public EClassifier EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty, ref eType1); }
		}
	
		
		public bool Changeable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty, ref changeable0); }
		}
	
		
		public bool Volatile
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty, ref volatile0); }
		}
	
		
		public bool Transient
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty, ref transient0); }
		}
	
		
		public String DefaultValueLiteral
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, ref defaultValueLiteral0); }
		}
	
		
		public object DefaultValue
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		public bool Unsettable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty, ref unsettable0); }
		}
	
		
		public bool Derived
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty, ref derived0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		int EStructuralFeature.GetFeatureID()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetFeatureID(this);
		}
	
		
		System.Type EStructuralFeature.GetContainerClass()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetContainerClass(this);
		}
	}
	
	internal class EStructuralFeatureBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EStructuralFeatureBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal EStructuralFeatureBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EStructuralFeature(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EStructuralFeature; }
		}
	
		public new EStructuralFeature ToImmutable()
		{
			return (EStructuralFeature)base.ToImmutable();
		}
	
		public new EStructuralFeature ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EStructuralFeature)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		EClassifierBuilder ETypedElementBuilder.EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElementBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElement, EClassifier> immutableLazy, global::System.Func<ETypedElementBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Ordered
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, value); }
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unique
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, value); }
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, immutableLazy, mutableLazy);
		}
	
		
		public int LowerBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public int UpperBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Many
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty); }
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Required
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty); }
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, immutableLazy, mutableLazy);
		}
	
		
		public EGenericTypeBuilder EGenericType
		{
			get { return this.GetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty); }
			set { this.SetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElement, EGenericType> immutableLazy, global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassBuilder EContainingClass
		{
			get { return this.GetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty); }
			set { this.SetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EStructuralFeatureBuilder, EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EStructuralFeature, EClass> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassifierBuilder EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EStructuralFeatureBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EStructuralFeature, EClassifier> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Changeable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Volatile
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Transient
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, immutableLazy, mutableLazy);
		}
	
		
		public String DefaultValueLiteral
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeatureBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeature, String> immutableLazy, global::System.Func<EStructuralFeatureBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, immutableLazy, mutableLazy);
		}
	
		
		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<EStructuralFeatureBuilder, object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<EStructuralFeature, object> immutableLazy, global::System.Func<EStructuralFeatureBuilder, object> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unsettable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Derived
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		int EStructuralFeatureBuilder.GetFeatureID()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetFeatureID(this);
		}
	
		
		System.Type EStructuralFeatureBuilder.GetContainerClass()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetContainerClass(this);
		}
	}
	
	internal class EAttributeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAttribute.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EAttributeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EAttributeBuilderImpl(this, model, creating);
		}
	}
	
	internal class EAttributeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EAttribute
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ordered0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unique0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int lowerBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int upperBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool many0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool required0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eContainingClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool changeable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool volatile0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool transient0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String defaultValueLiteral0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unsettable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool derived0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool iD0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EDataType eAttributeType0;
	
		internal EAttributeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EAttribute; }
		}
	
		public new EAttributeBuilder ToMutable()
		{
			return (EAttributeBuilder)base.ToMutable();
		}
	
		public new EAttributeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EAttributeBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ETypedElementBuilder ETypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ETypedElementBuilder ETypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EStructuralFeatureBuilder EStructuralFeature.ToMutable()
		{
			return this.ToMutable();
		}
	
		EStructuralFeatureBuilder EStructuralFeature.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		EClassifier ETypedElement.EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}
	
		
		public bool Ordered
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, ref ordered0); }
		}
	
		
		public bool Unique
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, ref unique0); }
		}
	
		
		public int LowerBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, ref lowerBound0); }
		}
	
		
		public int UpperBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, ref upperBound0); }
		}
	
		
		public bool Many
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty, ref many0); }
		}
	
		
		public bool Required
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty, ref required0); }
		}
	
		
		public EGenericType EGenericType
		{
		    get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}
	
		
		public EClass EContainingClass
		{
		    get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, ref eContainingClass0); }
		}
	
		
		public EClassifier EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty, ref eType1); }
		}
	
		
		public bool Changeable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty, ref changeable0); }
		}
	
		
		public bool Volatile
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty, ref volatile0); }
		}
	
		
		public bool Transient
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty, ref transient0); }
		}
	
		
		public String DefaultValueLiteral
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, ref defaultValueLiteral0); }
		}
	
		
		public object DefaultValue
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		public bool Unsettable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty, ref unsettable0); }
		}
	
		
		public bool Derived
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty, ref derived0); }
		}
	
		
		public bool ID
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAttribute.IDProperty, ref iD0); }
		}
	
		
		public EDataType EAttributeType
		{
		    get { return this.GetReference<EDataType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAttribute.EAttributeTypeProperty, ref eAttributeType0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		int EStructuralFeature.GetFeatureID()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetFeatureID(this);
		}
	
		
		System.Type EStructuralFeature.GetContainerClass()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetContainerClass(this);
		}
	}
	
	internal class EAttributeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EAttributeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal EAttributeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EAttribute(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EAttribute; }
		}
	
		public new EAttribute ToImmutable()
		{
			return (EAttribute)base.ToImmutable();
		}
	
		public new EAttribute ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EAttribute)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EStructuralFeature EStructuralFeatureBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EStructuralFeature EStructuralFeatureBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		EClassifierBuilder ETypedElementBuilder.EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElementBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElement, EClassifier> immutableLazy, global::System.Func<ETypedElementBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Ordered
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, value); }
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unique
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, value); }
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, immutableLazy, mutableLazy);
		}
	
		
		public int LowerBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public int UpperBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Many
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty); }
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Required
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty); }
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, immutableLazy, mutableLazy);
		}
	
		
		public EGenericTypeBuilder EGenericType
		{
			get { return this.GetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty); }
			set { this.SetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElement, EGenericType> immutableLazy, global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassBuilder EContainingClass
		{
			get { return this.GetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty); }
			set { this.SetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EStructuralFeatureBuilder, EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EStructuralFeature, EClass> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassifierBuilder EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EStructuralFeatureBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EStructuralFeature, EClassifier> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Changeable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Volatile
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Transient
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, immutableLazy, mutableLazy);
		}
	
		
		public String DefaultValueLiteral
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeatureBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeature, String> immutableLazy, global::System.Func<EStructuralFeatureBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, immutableLazy, mutableLazy);
		}
	
		
		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<EStructuralFeatureBuilder, object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<EStructuralFeature, object> immutableLazy, global::System.Func<EStructuralFeatureBuilder, object> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unsettable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Derived
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool ID
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAttribute.IDProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAttribute.IDProperty, value); }
		}
		
		void EAttributeBuilder.SetIDLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EAttribute.IDProperty, lazy);
		}
		
		void EAttributeBuilder.SetIDLazy(global::System.Func<EAttributeBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EAttribute.IDProperty, lazy);
		}
		
		void EAttributeBuilder.SetIDLazy(global::System.Func<EAttribute, bool> immutableLazy, global::System.Func<EAttributeBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EAttribute.IDProperty, immutableLazy, mutableLazy);
		}
	
		
		public EDataTypeBuilder EAttributeType
		{
			get { return this.GetReference<EDataTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAttribute.EAttributeTypeProperty); }
		}
		
		void EAttributeBuilder.SetEAttributeTypeLazy(global::System.Func<EDataTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAttribute.EAttributeTypeProperty, lazy);
		}
		
		void EAttributeBuilder.SetEAttributeTypeLazy(global::System.Func<EAttributeBuilder, EDataTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAttribute.EAttributeTypeProperty, lazy);
		}
		
		void EAttributeBuilder.SetEAttributeTypeLazy(global::System.Func<EAttribute, EDataType> immutableLazy, global::System.Func<EAttributeBuilder, EDataTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAttribute.EAttributeTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		int EStructuralFeatureBuilder.GetFeatureID()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetFeatureID(this);
		}
	
		
		System.Type EStructuralFeatureBuilder.GetContainerClass()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetContainerClass(this);
		}
	}
	
	internal class EReferenceId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EReferenceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EReferenceBuilderImpl(this, model, creating);
		}
	}
	
	internal class EReferenceImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EReference
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ordered0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unique0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int lowerBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int upperBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool many0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool required0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eContainingClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool changeable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool volatile0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool transient0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String defaultValueLiteral0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unsettable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool derived0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool containment0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool container0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool resolveProxies0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EReference eOpposite0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eReferenceType0;
	
		internal EReferenceImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EReference; }
		}
	
		public new EReferenceBuilder ToMutable()
		{
			return (EReferenceBuilder)base.ToMutable();
		}
	
		public new EReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EReferenceBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ETypedElementBuilder ETypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ETypedElementBuilder ETypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EStructuralFeatureBuilder EStructuralFeature.ToMutable()
		{
			return this.ToMutable();
		}
	
		EStructuralFeatureBuilder EStructuralFeature.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		EClassifier ETypedElement.EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}
	
		
		public bool Ordered
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, ref ordered0); }
		}
	
		
		public bool Unique
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, ref unique0); }
		}
	
		
		public int LowerBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, ref lowerBound0); }
		}
	
		
		public int UpperBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, ref upperBound0); }
		}
	
		
		public bool Many
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty, ref many0); }
		}
	
		
		public bool Required
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty, ref required0); }
		}
	
		
		public EGenericType EGenericType
		{
		    get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}
	
		
		public EClass EContainingClass
		{
		    get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, ref eContainingClass0); }
		}
	
		
		public EClassifier EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty, ref eType1); }
		}
	
		
		public bool Changeable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty, ref changeable0); }
		}
	
		
		public bool Volatile
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty, ref volatile0); }
		}
	
		
		public bool Transient
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty, ref transient0); }
		}
	
		
		public String DefaultValueLiteral
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, ref defaultValueLiteral0); }
		}
	
		
		public object DefaultValue
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty, ref defaultValue0); }
		}
	
		
		public bool Unsettable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty, ref unsettable0); }
		}
	
		
		public bool Derived
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty, ref derived0); }
		}
	
		
		public bool Containment
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.ContainmentProperty, ref containment0); }
		}
	
		
		public bool Container
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.ContainerProperty, ref container0); }
		}
	
		
		public bool ResolveProxies
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.ResolveProxiesProperty, ref resolveProxies0); }
		}
	
		
		public EReference EOpposite
		{
		    get { return this.GetReference<EReference>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.EOppositeProperty, ref eOpposite0); }
		}
	
		
		public EClass EReferenceType
		{
		    get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.EReferenceTypeProperty, ref eReferenceType0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		int EStructuralFeature.GetFeatureID()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetFeatureID(this);
		}
	
		
		System.Type EStructuralFeature.GetContainerClass()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetContainerClass(this);
		}
	}
	
	internal class EReferenceBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EReferenceBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal EReferenceBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EReference(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EReference; }
		}
	
		public new EReference ToImmutable()
		{
			return (EReference)base.ToImmutable();
		}
	
		public new EReference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EReference)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EStructuralFeature EStructuralFeatureBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EStructuralFeature EStructuralFeatureBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		EClassifierBuilder ETypedElementBuilder.EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElementBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElement, EClassifier> immutableLazy, global::System.Func<ETypedElementBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Ordered
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, value); }
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unique
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, value); }
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, immutableLazy, mutableLazy);
		}
	
		
		public int LowerBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public int UpperBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Many
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty); }
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Required
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty); }
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, immutableLazy, mutableLazy);
		}
	
		
		public EGenericTypeBuilder EGenericType
		{
			get { return this.GetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty); }
			set { this.SetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElement, EGenericType> immutableLazy, global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassBuilder EContainingClass
		{
			get { return this.GetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty); }
			set { this.SetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EStructuralFeatureBuilder, EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetEContainingClassLazy(global::System.Func<EStructuralFeature, EClass> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.EContainingClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassifierBuilder EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ETypeProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EStructuralFeatureBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetETypeLazy(global::System.Func<EStructuralFeature, EClassifier> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Changeable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.ChangeableProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetChangeableLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.ChangeableProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Volatile
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.VolatileProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetVolatileLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.VolatileProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Transient
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.TransientProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetTransientLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.TransientProperty, immutableLazy, mutableLazy);
		}
	
		
		public String DefaultValueLiteral
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeatureBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeature, String> immutableLazy, global::System.Func<EStructuralFeatureBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, immutableLazy, mutableLazy);
		}
	
		
		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<EStructuralFeatureBuilder, object> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDefaultValueLazy(global::System.Func<EStructuralFeature, object> immutableLazy, global::System.Func<EStructuralFeatureBuilder, object> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unsettable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.UnsettableProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetUnsettableLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.UnsettableProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Derived
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DerivedProperty, value); }
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<EStructuralFeatureBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, lazy);
		}
		
		void EStructuralFeatureBuilder.SetDerivedLazy(global::System.Func<EStructuralFeature, bool> immutableLazy, global::System.Func<EStructuralFeatureBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EStructuralFeature.DerivedProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Containment
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.ContainmentProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.ContainmentProperty, value); }
		}
		
		void EReferenceBuilder.SetContainmentLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ContainmentProperty, lazy);
		}
		
		void EReferenceBuilder.SetContainmentLazy(global::System.Func<EReferenceBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ContainmentProperty, lazy);
		}
		
		void EReferenceBuilder.SetContainmentLazy(global::System.Func<EReference, bool> immutableLazy, global::System.Func<EReferenceBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ContainmentProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Container
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.ContainerProperty); }
		}
		
		void EReferenceBuilder.SetContainerLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ContainerProperty, lazy);
		}
		
		void EReferenceBuilder.SetContainerLazy(global::System.Func<EReferenceBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ContainerProperty, lazy);
		}
		
		void EReferenceBuilder.SetContainerLazy(global::System.Func<EReference, bool> immutableLazy, global::System.Func<EReferenceBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ContainerProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool ResolveProxies
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.ResolveProxiesProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.ResolveProxiesProperty, value); }
		}
		
		void EReferenceBuilder.SetResolveProxiesLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ResolveProxiesProperty, lazy);
		}
		
		void EReferenceBuilder.SetResolveProxiesLazy(global::System.Func<EReferenceBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ResolveProxiesProperty, lazy);
		}
		
		void EReferenceBuilder.SetResolveProxiesLazy(global::System.Func<EReference, bool> immutableLazy, global::System.Func<EReferenceBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.EReference.ResolveProxiesProperty, immutableLazy, mutableLazy);
		}
	
		
		public EReferenceBuilder EOpposite
		{
			get { return this.GetReference<EReferenceBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.EOppositeProperty); }
			set { this.SetReference<EReferenceBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.EOppositeProperty, value); }
		}
		
		void EReferenceBuilder.SetEOppositeLazy(global::System.Func<EReferenceBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EReference.EOppositeProperty, lazy);
		}
		
		void EReferenceBuilder.SetEOppositeLazy(global::System.Func<EReferenceBuilder, EReferenceBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EReference.EOppositeProperty, lazy);
		}
		
		void EReferenceBuilder.SetEOppositeLazy(global::System.Func<EReference, EReference> immutableLazy, global::System.Func<EReferenceBuilder, EReferenceBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EReference.EOppositeProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassBuilder EReferenceType
		{
			get { return this.GetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.EReferenceTypeProperty); }
			set { this.SetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.EReferenceTypeProperty, value); }
		}
		
		void EReferenceBuilder.SetEReferenceTypeLazy(global::System.Func<EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EReference.EReferenceTypeProperty, lazy);
		}
		
		void EReferenceBuilder.SetEReferenceTypeLazy(global::System.Func<EReferenceBuilder, EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EReference.EReferenceTypeProperty, lazy);
		}
		
		void EReferenceBuilder.SetEReferenceTypeLazy(global::System.Func<EReference, EClass> immutableLazy, global::System.Func<EReferenceBuilder, EClassBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EReference.EReferenceTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	
		
		int EStructuralFeatureBuilder.GetFeatureID()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetFeatureID(this);
		}
	
		
		System.Type EStructuralFeatureBuilder.GetContainerClass()
		{
		    return EcoreImplementationProvider.Implementation.EStructuralFeature_GetContainerClass(this);
		}
	}
	
	internal class EOperationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EOperationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EOperationBuilderImpl(this, model, creating);
		}
	}
	
	internal class EOperationImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EOperation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ordered0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unique0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int lowerBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int upperBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool many0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool required0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eContainingClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EParameter> eParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EClassifier> eExceptions0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eGenericExceptions0;
	
		internal EOperationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EOperation; }
		}
	
		public new EOperationBuilder ToMutable()
		{
			return (EOperationBuilder)base.ToMutable();
		}
	
		public new EOperationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EOperationBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ETypedElementBuilder ETypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ETypedElementBuilder ETypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		EClassifier ETypedElement.EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}
	
		
		public bool Ordered
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, ref ordered0); }
		}
	
		
		public bool Unique
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, ref unique0); }
		}
	
		
		public int LowerBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, ref lowerBound0); }
		}
	
		
		public int UpperBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, ref upperBound0); }
		}
	
		
		public bool Many
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty, ref many0); }
		}
	
		
		public bool Required
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty, ref required0); }
		}
	
		
		public EGenericType EGenericType
		{
		    get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}
	
		
		public EClass EContainingClass
		{
		    get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EContainingClassProperty, ref eContainingClass0); }
		}
	
		
		public EClassifier EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.ETypeProperty, ref eType1); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EParameter> EParameters
		{
		    get { return this.GetList<EParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EParametersProperty, ref eParameters0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EClassifier> EExceptions
		{
		    get { return this.GetList<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EExceptionsProperty, ref eExceptions0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
		    get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericExceptions
		{
		    get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EGenericExceptionsProperty, ref eGenericExceptions0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EOperationBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EOperationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<EParameterBuilder> eParameters0;
		private global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> eExceptions0;
		private global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> eTypeParameters0;
		private global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> eGenericExceptions0;
	
		internal EOperationBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EOperation(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EOperation; }
		}
	
		public new EOperation ToImmutable()
		{
			return (EOperation)base.ToImmutable();
		}
	
		public new EOperation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EOperation)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		EClassifierBuilder ETypedElementBuilder.EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElementBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElement, EClassifier> immutableLazy, global::System.Func<ETypedElementBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Ordered
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, value); }
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unique
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, value); }
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, immutableLazy, mutableLazy);
		}
	
		
		public int LowerBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public int UpperBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Many
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty); }
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Required
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty); }
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, immutableLazy, mutableLazy);
		}
	
		
		public EGenericTypeBuilder EGenericType
		{
			get { return this.GetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty); }
			set { this.SetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElement, EGenericType> immutableLazy, global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassBuilder EContainingClass
		{
			get { return this.GetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EContainingClassProperty); }
			set { this.SetReference<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EContainingClassProperty, value); }
		}
		
		void EOperationBuilder.SetEContainingClassLazy(global::System.Func<EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EOperation.EContainingClassProperty, lazy);
		}
		
		void EOperationBuilder.SetEContainingClassLazy(global::System.Func<EOperationBuilder, EClassBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EOperation.EContainingClassProperty, lazy);
		}
		
		void EOperationBuilder.SetEContainingClassLazy(global::System.Func<EOperation, EClass> immutableLazy, global::System.Func<EOperationBuilder, EClassBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EOperation.EContainingClassProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassifierBuilder EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.ETypeProperty, value); }
		}
		
		void EOperationBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EOperation.ETypeProperty, lazy);
		}
		
		void EOperationBuilder.SetETypeLazy(global::System.Func<EOperationBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EOperation.ETypeProperty, lazy);
		}
		
		void EOperationBuilder.SetETypeLazy(global::System.Func<EOperation, EClassifier> immutableLazy, global::System.Func<EOperationBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EOperation.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EParameterBuilder> EParameters
		{
			get { return this.GetList<EParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EParametersProperty, ref eParameters0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> EExceptions
		{
			get { return this.GetList<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EExceptionsProperty, ref eExceptions0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters
		{
			get { return this.GetList<ETypeParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.ETypeParametersProperty, ref eTypeParameters0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericExceptions
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EGenericExceptionsProperty, ref eGenericExceptions0); }
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EParameterId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EParameter.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class EParameterImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ordered0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unique0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int lowerBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int upperBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool many0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool required0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EOperation eOperation0;
	
		internal EParameterImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EParameter; }
		}
	
		public new EParameterBuilder ToMutable()
		{
			return (EParameterBuilder)base.ToMutable();
		}
	
		public new EParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EParameterBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ETypedElementBuilder ETypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ETypedElementBuilder ETypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public EClassifier EType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}
	
		
		public bool Ordered
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, ref ordered0); }
		}
	
		
		public bool Unique
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, ref unique0); }
		}
	
		
		public int LowerBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, ref lowerBound0); }
		}
	
		
		public int UpperBound
		{
		    get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, ref upperBound0); }
		}
	
		
		public bool Many
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty, ref many0); }
		}
	
		
		public bool Required
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty, ref required0); }
		}
	
		
		public EGenericType EGenericType
		{
		    get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}
	
		
		public EOperation EOperation
		{
		    get { return this.GetReference<EOperation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EParameter.EOperationProperty, ref eOperation0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EParameterBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EParameterBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
	
		internal EParameterBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EParameter(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EParameter; }
		}
	
		public new EParameter ToImmutable()
		{
			return (EParameter)base.ToImmutable();
		}
	
		public new EParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EParameter)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ETypedElement ETypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassifierBuilder EType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElementBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetETypeLazy(global::System.Func<ETypedElement, EClassifier> immutableLazy, global::System.Func<ETypedElementBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.ETypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Ordered
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.OrderedProperty, value); }
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, lazy);
		}
		
		void ETypedElementBuilder.SetOrderedLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.OrderedProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Unique
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UniqueProperty, value); }
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUniqueLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UniqueProperty, immutableLazy, mutableLazy);
		}
	
		
		public int LowerBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.LowerBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetLowerBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.LowerBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public int UpperBound
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty); }
			set { this.SetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.UpperBoundProperty, value); }
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElementBuilder, int> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, lazy);
		}
		
		void ETypedElementBuilder.SetUpperBoundLazy(global::System.Func<ETypedElement, int> immutableLazy, global::System.Func<ETypedElementBuilder, int> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.UpperBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Many
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ManyProperty); }
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, lazy);
		}
		
		void ETypedElementBuilder.SetManyLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.ManyProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool Required
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.RequiredProperty); }
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, lazy);
		}
		
		void ETypedElementBuilder.SetRequiredLazy(global::System.Func<ETypedElement, bool> immutableLazy, global::System.Func<ETypedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(EcoreDescriptor.ETypedElement.RequiredProperty, immutableLazy, mutableLazy);
		}
	
		
		public EGenericTypeBuilder EGenericType
		{
			get { return this.GetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty); }
			set { this.SetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, value); }
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, lazy);
		}
		
		void ETypedElementBuilder.SetEGenericTypeLazy(global::System.Func<ETypedElement, EGenericType> immutableLazy, global::System.Func<ETypedElementBuilder, EGenericTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ETypedElement.EGenericTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public EOperationBuilder EOperation
		{
			get { return this.GetReference<EOperationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EParameter.EOperationProperty); }
			set { this.SetReference<EOperationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EParameter.EOperationProperty, value); }
		}
		
		void EParameterBuilder.SetEOperationLazy(global::System.Func<EOperationBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EParameter.EOperationProperty, lazy);
		}
		
		void EParameterBuilder.SetEOperationLazy(global::System.Func<EParameterBuilder, EOperationBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EParameter.EOperationProperty, lazy);
		}
		
		void EParameterBuilder.SetEOperationLazy(global::System.Func<EParameter, EOperation> immutableLazy, global::System.Func<EParameterBuilder, EOperationBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EParameter.EOperationProperty, immutableLazy, mutableLazy);
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class EGenericTypeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EGenericTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EGenericTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class EGenericTypeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EGenericType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eClassifier0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eRawType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ETypeParameter eTypeParameter0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eLowerBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eUpperBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eTypeArguments0;
	
		internal EGenericTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EGenericType; }
		}
	
		public new EGenericTypeBuilder ToMutable()
		{
			return (EGenericTypeBuilder)base.ToMutable();
		}
	
		public new EGenericTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EGenericTypeBuilder)base.ToMutable(model);
		}
	
		
		public EClassifier EClassifier
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.EClassifierProperty, ref eClassifier0); }
		}
	
		
		public EClassifier ERawType
		{
		    get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ERawTypeProperty, ref eRawType0); }
		}
	
		
		public ETypeParameter ETypeParameter
		{
		    get { return this.GetReference<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ETypeParameterProperty, ref eTypeParameter0); }
		}
	
		
		public EGenericType ELowerBound
		{
		    get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ELowerBoundProperty, ref eLowerBound0); }
		}
	
		
		public EGenericType EUpperBound
		{
		    get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.EUpperBoundProperty, ref eUpperBound0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> ETypeArguments
		{
		    get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ETypeArgumentsProperty, ref eTypeArguments0); }
		}
	}
	
	internal class EGenericTypeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EGenericTypeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> eTypeArguments0;
	
		internal EGenericTypeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EGenericType(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.EGenericType; }
		}
	
		public new EGenericType ToImmutable()
		{
			return (EGenericType)base.ToImmutable();
		}
	
		public new EGenericType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EGenericType)base.ToImmutable(model);
		}
	
		
		public EClassifierBuilder EClassifier
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.EClassifierProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.EClassifierProperty, value); }
		}
		
		void EGenericTypeBuilder.SetEClassifierLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.EClassifierProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetEClassifierLazy(global::System.Func<EGenericTypeBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.EClassifierProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetEClassifierLazy(global::System.Func<EGenericType, EClassifier> immutableLazy, global::System.Func<EGenericTypeBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.EClassifierProperty, immutableLazy, mutableLazy);
		}
	
		
		public EClassifierBuilder ERawType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ERawTypeProperty); }
			set { this.SetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ERawTypeProperty, value); }
		}
		
		void EGenericTypeBuilder.SetERawTypeLazy(global::System.Func<EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ERawTypeProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetERawTypeLazy(global::System.Func<EGenericTypeBuilder, EClassifierBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ERawTypeProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetERawTypeLazy(global::System.Func<EGenericType, EClassifier> immutableLazy, global::System.Func<EGenericTypeBuilder, EClassifierBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ERawTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public ETypeParameterBuilder ETypeParameter
		{
			get { return this.GetReference<ETypeParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ETypeParameterProperty); }
			set { this.SetReference<ETypeParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ETypeParameterProperty, value); }
		}
		
		void EGenericTypeBuilder.SetETypeParameterLazy(global::System.Func<ETypeParameterBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ETypeParameterProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetETypeParameterLazy(global::System.Func<EGenericTypeBuilder, ETypeParameterBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ETypeParameterProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetETypeParameterLazy(global::System.Func<EGenericType, ETypeParameter> immutableLazy, global::System.Func<EGenericTypeBuilder, ETypeParameterBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ETypeParameterProperty, immutableLazy, mutableLazy);
		}
	
		
		public EGenericTypeBuilder ELowerBound
		{
			get { return this.GetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ELowerBoundProperty); }
			set { this.SetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ELowerBoundProperty, value); }
		}
		
		void EGenericTypeBuilder.SetELowerBoundLazy(global::System.Func<EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ELowerBoundProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetELowerBoundLazy(global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ELowerBoundProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetELowerBoundLazy(global::System.Func<EGenericType, EGenericType> immutableLazy, global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.ELowerBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public EGenericTypeBuilder EUpperBound
		{
			get { return this.GetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.EUpperBoundProperty); }
			set { this.SetReference<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.EUpperBoundProperty, value); }
		}
		
		void EGenericTypeBuilder.SetEUpperBoundLazy(global::System.Func<EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.EUpperBoundProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetEUpperBoundLazy(global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.EUpperBoundProperty, lazy);
		}
		
		void EGenericTypeBuilder.SetEUpperBoundLazy(global::System.Func<EGenericType, EGenericType> immutableLazy, global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EGenericType.EUpperBoundProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> ETypeArguments
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ETypeArgumentsProperty, ref eTypeArguments0); }
		}
	}
	
	internal class ETypeParameterId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypeParameter.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ETypeParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ETypeParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class ETypeParameterImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ETypeParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> eAnnotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private String name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eGenericTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eBounds0;
	
		internal ETypeParameterImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.ETypeParameter; }
		}
	
		public new ETypeParameterBuilder ToMutable()
		{
			return (ETypeParameterBuilder)base.ToMutable();
		}
	
		public new ETypeParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ETypeParameterBuilder)base.ToMutable(model);
		}
	
		EObjectBuilder EObject.ToMutable()
		{
			return this.ToMutable();
		}
	
		EObjectBuilder EObject.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EModelElementBuilder EModelElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EModelElementBuilder EModelElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ENamedElementBuilder ENamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ENamedElementBuilder ENamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
		    get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
		    get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericTypes
		{
		    get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypeParameter.EGenericTypesProperty, ref eGenericTypes0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EBounds
		{
		    get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypeParameter.EBoundsProperty, ref eBounds0); }
		}
	
		
		EClass EObject.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObject.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObject.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObject EObject.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeature EObject.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReference EObject.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObject.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObject.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObject.EGet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObject.EGet(EStructuralFeature feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObject.ESet(EStructuralFeature feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObject.EIsSet(EStructuralFeature feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObject.EUnset(EStructuralFeature feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotation EModelElement.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}
	
	internal class ETypeParameterBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ETypeParameterBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> eGenericTypes0;
		private global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> eBounds0;
	
		internal ETypeParameterBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.ETypeParameter(this);
		}
	
		public override global::MetaDslx.Modeling.IMetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
		{
			get { return EcoreInstance.ETypeParameter; }
		}
	
		public new ETypeParameter ToImmutable()
		{
			return (ETypeParameter)base.ToImmutable();
		}
	
		public new ETypeParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ETypeParameter)base.ToImmutable(model);
		}
	
		EObject EObjectBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EObject EObjectBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EModelElement EModelElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EModelElement EModelElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ENamedElement ENamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}
	
		
		public String Name
		{
			get { return this.GetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<String>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, String> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}
		
		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, String> immutableLazy, global::System.Func<ENamedElementBuilder, String> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericTypes
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypeParameter.EGenericTypesProperty, ref eGenericTypes0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EBounds
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypeParameter.EBoundsProperty, ref eBounds0); }
		}
	
		
		EClassBuilder EObjectBuilder.EClass()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EClass(this);
		}
	
		
		bool EObjectBuilder.EIsProxy()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsProxy(this);
		}
	
		
		MetaDslx.Modeling.IModel EObjectBuilder.EResource()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EResource(this);
		}
	
		
		EObjectBuilder EObjectBuilder.EContainer()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainer(this);
		}
	
		
		EStructuralFeatureBuilder EObjectBuilder.EContainingFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainingFeature(this);
		}
	
		
		EReferenceBuilder EObjectBuilder.EContainmentFeature()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContainmentFeature(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.EContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}
	
		
		System.Collections.IEnumerator EObjectBuilder.EAllContents()
		{
		    return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}
	
		
		System.Collections.Generic.IReadOnlyList<object> EObjectBuilder.ECrossReferences()
		{
		    return EcoreImplementationProvider.Implementation.EObject_ECrossReferences(this);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature);
		}
	
		
		object EObjectBuilder.EGet(EStructuralFeatureBuilder feature, bool resolve)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EGet(this, feature, resolve);
		}
	
		
		object EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
		    return EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}
	
		
		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
		    return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}
	
		
		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
		EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}
	
		
		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(String source)
		{
		    return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}

	internal class EcoreBuilderInstance
	{
		internal static EcoreBuilderInstance instance = new EcoreBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Modeling.MutableModel MModel;
		internal global::MetaDslx.Modeling.MutableModelGroup MModelGroup;
	
		internal EDataTypeBuilder EJavaObject = null;
		internal EDataTypeBuilder EJavaClass = null;
		internal EDataTypeBuilder EBoolean = null;
		internal EDataTypeBuilder EString = null;
		internal EDataTypeBuilder EByte = null;
		internal EDataTypeBuilder EByteArray = null;
		internal EDataTypeBuilder EChar = null;
		internal EDataTypeBuilder EShort = null;
		internal EDataTypeBuilder EInt = null;
		internal EDataTypeBuilder ELong = null;
		internal EDataTypeBuilder EFloat = null;
		internal EDataTypeBuilder EDouble = null;
		internal EDataTypeBuilder EByteObject = null;
		internal EDataTypeBuilder ECharObject = null;
		internal EDataTypeBuilder EShortObject = null;
		internal EDataTypeBuilder EIntObject = null;
		internal EDataTypeBuilder ELongObject = null;
		internal EDataTypeBuilder EFloatObject = null;
		internal EDataTypeBuilder EDoubleObject = null;
		internal EDataTypeBuilder EDate = null;
		internal EDataTypeBuilder EBigInteger = null;
		internal EDataTypeBuilder EBigDecimal = null;
		internal EDataTypeBuilder EResource = null;
		internal EDataTypeBuilder EResourceSet = null;
		internal EDataTypeBuilder EFeatureMap = null;
		internal EDataTypeBuilder EFeatureMapEntry = null;
		internal EDataTypeBuilder EEList = null;
		internal EDataTypeBuilder EEnumerator = null;
		internal EDataTypeBuilder ETreeIterator = null;
	
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp2;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp4;
		private global::MetaDslx.Languages.Meta.Model.MetaModelBuilder __tmp5;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp6;
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
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp22;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp23;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp24;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp25;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp26;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp27;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp28;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp29;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp30;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp31;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp32;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp33;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp34;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EObject;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp35;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp36;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp37;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp38;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp39;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp40;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp41;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp42;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp43;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp44;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp49;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp45;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp50;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp51;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp46;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp52;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp53;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp47;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp54;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp48;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp55;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EModelElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EModelElement_EAnnotations;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp56;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp58;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EFactory;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EFactory_EPackage;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp59;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp62;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp60;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp63;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp64;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp61;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp65;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp66;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ENamedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ENamedElement_Name;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EAnnotation;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_EModelElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_Source;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_Details;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_Contents;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_References;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EStringToStringMapEntry;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStringToStringMapEntry_Key;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStringToStringMapEntry_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EPackage;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_NsURI;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_NsPrefix;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_ESuperPackage;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_ESubPackages;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_EClassifiers;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_EFactoryInstance;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp70;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp73;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EClassifier;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_InstanceClassName;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_EPackage;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_ETypeParameters;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_InstanceClass;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_DefaultValue;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp74;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp77;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp75;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EClass;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_Abstract;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_Interface;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_ESuperTypes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllSuperTypes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EStructuralFeatures;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllStructuralFeatures;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EOperations;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllOperation;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EReferences;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllReferences;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllContainments;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAttributes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllAttributes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EIDAttribute;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EGenericSuperTypes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllGenericSuperTypes;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp78;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp94;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp79;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp95;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp80;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp96;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EDataType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EDataType_Serializable;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EDataType_DotNetName;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EEnum;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnum_ELiterals;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp97;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp100;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp98;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp101;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EEnumLiteral;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnumLiteral_EEnum;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnumLiteral_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnumLiteral_Instance;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ETypedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_EType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_Ordered;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_Unique;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_LowerBound;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_UpperBound;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_Many;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_Required;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_EGenericType;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EStructuralFeature;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_EContainingClass;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_EType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Changeable;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Volatile;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Transient;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_DefaultValueLiteral;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_DefaultValue;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Unsettable;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Derived;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp102;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp103;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EAttribute;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAttribute_ID;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAttribute_EAttributeType;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EReference;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_Containment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_Container;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_ResolveProxies;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_EOpposite;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_EReferenceType;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EOperation;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EContainingClass;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EParameters;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EExceptions;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_ETypeParameters;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EGenericExceptions;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EParameter;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EParameter_EOperation;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EGenericType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_EClassifier;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_ERawType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_ETypeParameter;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_ELowerBound;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_EUpperBound;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_ETypeArguments;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ETypeParameter;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypeParameter_EGenericTypes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypeParameter_EBounds;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp57;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp67;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp68;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp69;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp71;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp72;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp76;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp81;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp82;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp83;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp84;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp85;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp86;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp87;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp88;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp89;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp90;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp91;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp92;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp93;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp99;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp104;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp105;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp106;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp107;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp108;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp109;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp110;
	
		internal EcoreBuilderInstance()
		{
			this.MModelGroup = new global::MetaDslx.Modeling.MutableModelGroup();
			this.MModelGroup.AddReference(global::MetaDslx.Languages.Meta.Model.MetaInstance.MModel.ToMutable(true));
			this.MModel = this.MModelGroup.CreateModel("Ecore");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			this.CreateInstances();
			EcoreImplementationProvider.Implementation.EcoreBuilderInstance(this);
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
			EcoreFactory constantFactory = new EcoreFactory(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);
	
			EJavaObject = constantFactory.EDataType();
			EJavaObject.MName = "EJavaObject";
			EJavaObject.DotNetName = "System.Object";
			EJavaClass = constantFactory.EDataType();
			EJavaClass.MName = "EJavaClass";
			EJavaClass.DotNetName = "System.Type";
			EBoolean = constantFactory.EDataType();
			EBoolean.MName = "EBoolean";
			EBoolean.DotNetName = "System.Boolean";
			EString = constantFactory.EDataType();
			EString.MName = "EString";
			EString.DotNetName = "System.String";
			EByte = constantFactory.EDataType();
			EByte.MName = "EByte";
			EByte.DotNetName = "System.Byte";
			EByteArray = constantFactory.EDataType();
			EByteArray.MName = "EByteArray";
			EByteArray.DotNetName = "byte[]";
			EChar = constantFactory.EDataType();
			EChar.MName = "EChar";
			EChar.DotNetName = "System.Char";
			EShort = constantFactory.EDataType();
			EShort.MName = "EShort";
			EShort.DotNetName = "System.Int16";
			EInt = constantFactory.EDataType();
			EInt.MName = "EInt";
			EInt.DotNetName = "System.Int32";
			ELong = constantFactory.EDataType();
			ELong.MName = "ELong";
			ELong.DotNetName = "System.Int64";
			EFloat = constantFactory.EDataType();
			EFloat.MName = "EFloat";
			EFloat.DotNetName = "System.Single";
			EDouble = constantFactory.EDataType();
			EDouble.MName = "EDouble";
			EDouble.DotNetName = "System.Double";
			EByteObject = constantFactory.EDataType();
			EByteObject.MName = "EByteObject";
			EByteObject.DotNetName = "byte?";
			ECharObject = constantFactory.EDataType();
			ECharObject.MName = "ECharObject";
			ECharObject.DotNetName = "char?";
			EShortObject = constantFactory.EDataType();
			EShortObject.MName = "EShortObject";
			EShortObject.DotNetName = "short?";
			EIntObject = constantFactory.EDataType();
			EIntObject.MName = "EIntObject";
			EIntObject.DotNetName = "int?";
			ELongObject = constantFactory.EDataType();
			ELongObject.MName = "ELongObject";
			ELongObject.DotNetName = "long?";
			EFloatObject = constantFactory.EDataType();
			EFloatObject.MName = "EFloatObject";
			EFloatObject.DotNetName = "float?";
			EDoubleObject = constantFactory.EDataType();
			EDoubleObject.MName = "EDoubleObject";
			EDoubleObject.DotNetName = "double?";
			EDate = constantFactory.EDataType();
			EDate.MName = "EDate";
			EDate.DotNetName = "System.DateTime";
			EBigInteger = constantFactory.EDataType();
			EBigInteger.MName = "EBigInteger";
			EBigInteger.DotNetName = "System.Numerics.BigInteger";
			EBigDecimal = constantFactory.EDataType();
			EBigDecimal.MName = "EBigDecimal";
			EBigDecimal.DotNetName = "System.Decimal";
			EResource = constantFactory.EDataType();
			EResource.MName = "EResource";
			EResource.DotNetName = "MetaDslx.Modeling.IModel";
			EResourceSet = constantFactory.EDataType();
			EResourceSet.MName = "EResourceSet";
			EResourceSet.DotNetName = "MetaDslx.Modeling.IModelGroup";
			EFeatureMap = constantFactory.EDataType();
			EFeatureMap.MName = "EFeatureMap";
			EFeatureMap.DotNetName = "System.Collections.Generic.Dictionary<EStructuralFeature,object>";
			EFeatureMapEntry = constantFactory.EDataType();
			EFeatureMapEntry.MName = "EFeatureMapEntry";
			EFeatureMapEntry.DotNetName = "System.Collections.Generic.KeyValuePair<EStructuralFeature,object>";
			EEList = constantFactory.EDataType();
			EEList.MName = "EEList";
			EEList.DotNetName = "System.Collections.Generic.IReadOnlyList<object>";
			EEnumerator = constantFactory.EDataType();
			EEnumerator.MName = "EEnumerator";
			EEnumerator.DotNetName = "System.Collections.IEnumerator";
			ETreeIterator = constantFactory.EDataType();
			ETreeIterator.MName = "ETreeIterator";
			ETreeIterator.DotNetName = "System.Collections.IEnumerator";
	
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
			__tmp17 = factory.MetaConstant();
			__tmp18 = factory.MetaConstant();
			__tmp19 = factory.MetaConstant();
			__tmp20 = factory.MetaConstant();
			__tmp21 = factory.MetaConstant();
			__tmp22 = factory.MetaConstant();
			__tmp23 = factory.MetaConstant();
			__tmp24 = factory.MetaConstant();
			__tmp25 = factory.MetaConstant();
			__tmp26 = factory.MetaConstant();
			__tmp27 = factory.MetaConstant();
			__tmp28 = factory.MetaConstant();
			__tmp29 = factory.MetaConstant();
			__tmp30 = factory.MetaConstant();
			__tmp31 = factory.MetaConstant();
			__tmp32 = factory.MetaConstant();
			__tmp33 = factory.MetaConstant();
			__tmp34 = factory.MetaConstant();
			EObject = factory.MetaClass();
			__tmp35 = factory.MetaOperation();
			__tmp36 = factory.MetaOperation();
			__tmp37 = factory.MetaOperation();
			__tmp38 = factory.MetaOperation();
			__tmp39 = factory.MetaOperation();
			__tmp40 = factory.MetaOperation();
			__tmp41 = factory.MetaOperation();
			__tmp42 = factory.MetaOperation();
			__tmp43 = factory.MetaOperation();
			__tmp44 = factory.MetaOperation();
			__tmp49 = factory.MetaParameter();
			__tmp45 = factory.MetaOperation();
			__tmp50 = factory.MetaParameter();
			__tmp51 = factory.MetaParameter();
			__tmp46 = factory.MetaOperation();
			__tmp52 = factory.MetaParameter();
			__tmp53 = factory.MetaParameter();
			__tmp47 = factory.MetaOperation();
			__tmp54 = factory.MetaParameter();
			__tmp48 = factory.MetaOperation();
			__tmp55 = factory.MetaParameter();
			EModelElement = factory.MetaClass();
			EModelElement_EAnnotations = factory.MetaProperty();
			__tmp56 = factory.MetaOperation();
			__tmp58 = factory.MetaParameter();
			EFactory = factory.MetaClass();
			EFactory_EPackage = factory.MetaProperty();
			__tmp59 = factory.MetaOperation();
			__tmp62 = factory.MetaParameter();
			__tmp60 = factory.MetaOperation();
			__tmp63 = factory.MetaParameter();
			__tmp64 = factory.MetaParameter();
			__tmp61 = factory.MetaOperation();
			__tmp65 = factory.MetaParameter();
			__tmp66 = factory.MetaParameter();
			ENamedElement = factory.MetaClass();
			ENamedElement_Name = factory.MetaProperty();
			EAnnotation = factory.MetaClass();
			EAnnotation_EModelElement = factory.MetaProperty();
			EAnnotation_Source = factory.MetaProperty();
			EAnnotation_Details = factory.MetaProperty();
			EAnnotation_Contents = factory.MetaProperty();
			EAnnotation_References = factory.MetaProperty();
			EStringToStringMapEntry = factory.MetaClass();
			EStringToStringMapEntry_Key = factory.MetaProperty();
			EStringToStringMapEntry_Value = factory.MetaProperty();
			EPackage = factory.MetaClass();
			EPackage_NsURI = factory.MetaProperty();
			EPackage_NsPrefix = factory.MetaProperty();
			EPackage_ESuperPackage = factory.MetaProperty();
			EPackage_ESubPackages = factory.MetaProperty();
			EPackage_EClassifiers = factory.MetaProperty();
			EPackage_EFactoryInstance = factory.MetaProperty();
			__tmp70 = factory.MetaOperation();
			__tmp73 = factory.MetaParameter();
			EClassifier = factory.MetaClass();
			EClassifier_InstanceClassName = factory.MetaProperty();
			EClassifier_EPackage = factory.MetaProperty();
			EClassifier_ETypeParameters = factory.MetaProperty();
			EClassifier_InstanceClass = factory.MetaProperty();
			EClassifier_DefaultValue = factory.MetaProperty();
			__tmp74 = factory.MetaOperation();
			__tmp77 = factory.MetaParameter();
			__tmp75 = factory.MetaOperation();
			EClass = factory.MetaClass();
			EClass_Abstract = factory.MetaProperty();
			EClass_Interface = factory.MetaProperty();
			EClass_ESuperTypes = factory.MetaProperty();
			EClass_EAllSuperTypes = factory.MetaProperty();
			EClass_EStructuralFeatures = factory.MetaProperty();
			EClass_EAllStructuralFeatures = factory.MetaProperty();
			EClass_EOperations = factory.MetaProperty();
			EClass_EAllOperation = factory.MetaProperty();
			EClass_EReferences = factory.MetaProperty();
			EClass_EAllReferences = factory.MetaProperty();
			EClass_EAllContainments = factory.MetaProperty();
			EClass_EAttributes = factory.MetaProperty();
			EClass_EAllAttributes = factory.MetaProperty();
			EClass_EIDAttribute = factory.MetaProperty();
			EClass_EGenericSuperTypes = factory.MetaProperty();
			EClass_EAllGenericSuperTypes = factory.MetaProperty();
			__tmp78 = factory.MetaOperation();
			__tmp94 = factory.MetaParameter();
			__tmp79 = factory.MetaOperation();
			__tmp95 = factory.MetaParameter();
			__tmp80 = factory.MetaOperation();
			__tmp96 = factory.MetaParameter();
			EDataType = factory.MetaClass();
			EDataType_Serializable = factory.MetaProperty();
			EDataType_DotNetName = factory.MetaProperty();
			EEnum = factory.MetaClass();
			EEnum_ELiterals = factory.MetaProperty();
			__tmp97 = factory.MetaOperation();
			__tmp100 = factory.MetaParameter();
			__tmp98 = factory.MetaOperation();
			__tmp101 = factory.MetaParameter();
			EEnumLiteral = factory.MetaClass();
			EEnumLiteral_EEnum = factory.MetaProperty();
			EEnumLiteral_Value = factory.MetaProperty();
			EEnumLiteral_Instance = factory.MetaProperty();
			ETypedElement = factory.MetaClass();
			ETypedElement_EType = factory.MetaProperty();
			ETypedElement_Ordered = factory.MetaProperty();
			ETypedElement_Unique = factory.MetaProperty();
			ETypedElement_LowerBound = factory.MetaProperty();
			ETypedElement_UpperBound = factory.MetaProperty();
			ETypedElement_Many = factory.MetaProperty();
			ETypedElement_Required = factory.MetaProperty();
			ETypedElement_EGenericType = factory.MetaProperty();
			EStructuralFeature = factory.MetaClass();
			EStructuralFeature_EContainingClass = factory.MetaProperty();
			EStructuralFeature_EType = factory.MetaProperty();
			EStructuralFeature_Changeable = factory.MetaProperty();
			EStructuralFeature_Volatile = factory.MetaProperty();
			EStructuralFeature_Transient = factory.MetaProperty();
			EStructuralFeature_DefaultValueLiteral = factory.MetaProperty();
			EStructuralFeature_DefaultValue = factory.MetaProperty();
			EStructuralFeature_Unsettable = factory.MetaProperty();
			EStructuralFeature_Derived = factory.MetaProperty();
			__tmp102 = factory.MetaOperation();
			__tmp103 = factory.MetaOperation();
			EAttribute = factory.MetaClass();
			EAttribute_ID = factory.MetaProperty();
			EAttribute_EAttributeType = factory.MetaProperty();
			EReference = factory.MetaClass();
			EReference_Containment = factory.MetaProperty();
			EReference_Container = factory.MetaProperty();
			EReference_ResolveProxies = factory.MetaProperty();
			EReference_EOpposite = factory.MetaProperty();
			EReference_EReferenceType = factory.MetaProperty();
			EOperation = factory.MetaClass();
			EOperation_EContainingClass = factory.MetaProperty();
			EOperation_EType = factory.MetaProperty();
			EOperation_EParameters = factory.MetaProperty();
			EOperation_EExceptions = factory.MetaProperty();
			EOperation_ETypeParameters = factory.MetaProperty();
			EOperation_EGenericExceptions = factory.MetaProperty();
			EParameter = factory.MetaClass();
			EParameter_EOperation = factory.MetaProperty();
			EGenericType = factory.MetaClass();
			EGenericType_EClassifier = factory.MetaProperty();
			EGenericType_ERawType = factory.MetaProperty();
			EGenericType_ETypeParameter = factory.MetaProperty();
			EGenericType_ELowerBound = factory.MetaProperty();
			EGenericType_EUpperBound = factory.MetaProperty();
			EGenericType_ETypeArguments = factory.MetaProperty();
			ETypeParameter = factory.MetaClass();
			ETypeParameter_EGenericTypes = factory.MetaProperty();
			ETypeParameter_EBounds = factory.MetaProperty();
			__tmp57 = factory.MetaCollectionType();
			__tmp67 = factory.MetaCollectionType();
			__tmp68 = factory.MetaCollectionType();
			__tmp69 = factory.MetaCollectionType();
			__tmp71 = factory.MetaCollectionType();
			__tmp72 = factory.MetaCollectionType();
			__tmp76 = factory.MetaCollectionType();
			__tmp81 = factory.MetaCollectionType();
			__tmp82 = factory.MetaCollectionType();
			__tmp83 = factory.MetaCollectionType();
			__tmp84 = factory.MetaCollectionType();
			__tmp85 = factory.MetaCollectionType();
			__tmp86 = factory.MetaCollectionType();
			__tmp87 = factory.MetaCollectionType();
			__tmp88 = factory.MetaCollectionType();
			__tmp89 = factory.MetaCollectionType();
			__tmp90 = factory.MetaCollectionType();
			__tmp91 = factory.MetaCollectionType();
			__tmp92 = factory.MetaCollectionType();
			__tmp93 = factory.MetaCollectionType();
			__tmp99 = factory.MetaCollectionType();
			__tmp104 = factory.MetaCollectionType();
			__tmp105 = factory.MetaCollectionType();
			__tmp106 = factory.MetaCollectionType();
			__tmp107 = factory.MetaCollectionType();
			__tmp108 = factory.MetaCollectionType();
			__tmp109 = factory.MetaCollectionType();
			__tmp110 = factory.MetaCollectionType();
	
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
			__tmp3.Name = "Ecore";
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
			__tmp4.Declarations.AddLazy(() => __tmp17);
			__tmp4.Declarations.AddLazy(() => __tmp18);
			__tmp4.Declarations.AddLazy(() => __tmp19);
			__tmp4.Declarations.AddLazy(() => __tmp20);
			__tmp4.Declarations.AddLazy(() => __tmp21);
			__tmp4.Declarations.AddLazy(() => __tmp22);
			__tmp4.Declarations.AddLazy(() => __tmp23);
			__tmp4.Declarations.AddLazy(() => __tmp24);
			__tmp4.Declarations.AddLazy(() => __tmp25);
			__tmp4.Declarations.AddLazy(() => __tmp26);
			__tmp4.Declarations.AddLazy(() => __tmp27);
			__tmp4.Declarations.AddLazy(() => __tmp28);
			__tmp4.Declarations.AddLazy(() => __tmp29);
			__tmp4.Declarations.AddLazy(() => __tmp30);
			__tmp4.Declarations.AddLazy(() => __tmp31);
			__tmp4.Declarations.AddLazy(() => __tmp32);
			__tmp4.Declarations.AddLazy(() => __tmp33);
			__tmp4.Declarations.AddLazy(() => __tmp34);
			__tmp4.Declarations.AddLazy(() => EObject);
			__tmp4.Declarations.AddLazy(() => EModelElement);
			__tmp4.Declarations.AddLazy(() => EFactory);
			__tmp4.Declarations.AddLazy(() => ENamedElement);
			__tmp4.Declarations.AddLazy(() => EAnnotation);
			__tmp4.Declarations.AddLazy(() => EStringToStringMapEntry);
			__tmp4.Declarations.AddLazy(() => EPackage);
			__tmp4.Declarations.AddLazy(() => EClassifier);
			__tmp4.Declarations.AddLazy(() => EClass);
			__tmp4.Declarations.AddLazy(() => EDataType);
			__tmp4.Declarations.AddLazy(() => EEnum);
			__tmp4.Declarations.AddLazy(() => EEnumLiteral);
			__tmp4.Declarations.AddLazy(() => ETypedElement);
			__tmp4.Declarations.AddLazy(() => EStructuralFeature);
			__tmp4.Declarations.AddLazy(() => EAttribute);
			__tmp4.Declarations.AddLazy(() => EReference);
			__tmp4.Declarations.AddLazy(() => EOperation);
			__tmp4.Declarations.AddLazy(() => EParameter);
			__tmp4.Declarations.AddLazy(() => EGenericType);
			__tmp4.Declarations.AddLazy(() => ETypeParameter);
			__tmp5.Documentation = null;
			__tmp5.Name = "Ecore";
			__tmp5.Uri = "http://www.eclipse.org/emf/2002/Ecore";
			__tmp5.Prefix = null;
			__tmp5.SetNamespaceLazy(() => __tmp4);
			__tmp6.SetTypeLazy(() => EDataType);
			__tmp6.Documentation = null;
			__tmp6.Name = "EJavaObject";
			__tmp6.SetNamespaceLazy(() => __tmp4);
			__tmp6.DotNetName = "System.Object";
			__tmp6.SetValueLazy(() => EJavaObject);
			__tmp7.SetTypeLazy(() => EDataType);
			__tmp7.Documentation = null;
			__tmp7.Name = "EJavaClass";
			__tmp7.SetNamespaceLazy(() => __tmp4);
			__tmp7.DotNetName = "System.Type";
			__tmp7.SetValueLazy(() => EJavaClass);
			__tmp8.SetTypeLazy(() => EDataType);
			__tmp8.Documentation = null;
			__tmp8.Name = "EBoolean";
			__tmp8.SetNamespaceLazy(() => __tmp4);
			__tmp8.DotNetName = "System.Boolean";
			__tmp8.SetValueLazy(() => EBoolean);
			__tmp9.SetTypeLazy(() => EDataType);
			__tmp9.Documentation = null;
			__tmp9.Name = "EString";
			__tmp9.SetNamespaceLazy(() => __tmp4);
			__tmp9.DotNetName = "System.String";
			__tmp9.SetValueLazy(() => EString);
			__tmp10.SetTypeLazy(() => EDataType);
			__tmp10.Documentation = null;
			__tmp10.Name = "EByte";
			__tmp10.SetNamespaceLazy(() => __tmp4);
			__tmp10.DotNetName = "System.Byte";
			__tmp10.SetValueLazy(() => EByte);
			__tmp11.SetTypeLazy(() => EDataType);
			__tmp11.Documentation = null;
			__tmp11.Name = "EByteArray";
			__tmp11.SetNamespaceLazy(() => __tmp4);
			__tmp11.DotNetName = "byte[]";
			__tmp11.SetValueLazy(() => EByteArray);
			__tmp12.SetTypeLazy(() => EDataType);
			__tmp12.Documentation = null;
			__tmp12.Name = "EChar";
			__tmp12.SetNamespaceLazy(() => __tmp4);
			__tmp12.DotNetName = "System.Char";
			__tmp12.SetValueLazy(() => EChar);
			__tmp13.SetTypeLazy(() => EDataType);
			__tmp13.Documentation = null;
			__tmp13.Name = "EShort";
			__tmp13.SetNamespaceLazy(() => __tmp4);
			__tmp13.DotNetName = "System.Int16";
			__tmp13.SetValueLazy(() => EShort);
			__tmp14.SetTypeLazy(() => EDataType);
			__tmp14.Documentation = null;
			__tmp14.Name = "EInt";
			__tmp14.SetNamespaceLazy(() => __tmp4);
			__tmp14.DotNetName = "System.Int32";
			__tmp14.SetValueLazy(() => EInt);
			__tmp15.SetTypeLazy(() => EDataType);
			__tmp15.Documentation = null;
			__tmp15.Name = "ELong";
			__tmp15.SetNamespaceLazy(() => __tmp4);
			__tmp15.DotNetName = "System.Int64";
			__tmp15.SetValueLazy(() => ELong);
			__tmp16.SetTypeLazy(() => EDataType);
			__tmp16.Documentation = null;
			__tmp16.Name = "EFloat";
			__tmp16.SetNamespaceLazy(() => __tmp4);
			__tmp16.DotNetName = "System.Single";
			__tmp16.SetValueLazy(() => EFloat);
			__tmp17.SetTypeLazy(() => EDataType);
			__tmp17.Documentation = null;
			__tmp17.Name = "EDouble";
			__tmp17.SetNamespaceLazy(() => __tmp4);
			__tmp17.DotNetName = "System.Double";
			__tmp17.SetValueLazy(() => EDouble);
			__tmp18.SetTypeLazy(() => EDataType);
			__tmp18.Documentation = null;
			__tmp18.Name = "EByteObject";
			__tmp18.SetNamespaceLazy(() => __tmp4);
			__tmp18.DotNetName = "byte?";
			__tmp18.SetValueLazy(() => EByteObject);
			__tmp19.SetTypeLazy(() => EDataType);
			__tmp19.Documentation = null;
			__tmp19.Name = "ECharObject";
			__tmp19.SetNamespaceLazy(() => __tmp4);
			__tmp19.DotNetName = "char?";
			__tmp19.SetValueLazy(() => ECharObject);
			__tmp20.SetTypeLazy(() => EDataType);
			__tmp20.Documentation = null;
			__tmp20.Name = "EShortObject";
			__tmp20.SetNamespaceLazy(() => __tmp4);
			__tmp20.DotNetName = "short?";
			__tmp20.SetValueLazy(() => EShortObject);
			__tmp21.SetTypeLazy(() => EDataType);
			__tmp21.Documentation = null;
			__tmp21.Name = "EIntObject";
			__tmp21.SetNamespaceLazy(() => __tmp4);
			__tmp21.DotNetName = "int?";
			__tmp21.SetValueLazy(() => EIntObject);
			__tmp22.SetTypeLazy(() => EDataType);
			__tmp22.Documentation = null;
			__tmp22.Name = "ELongObject";
			__tmp22.SetNamespaceLazy(() => __tmp4);
			__tmp22.DotNetName = "long?";
			__tmp22.SetValueLazy(() => ELongObject);
			__tmp23.SetTypeLazy(() => EDataType);
			__tmp23.Documentation = null;
			__tmp23.Name = "EFloatObject";
			__tmp23.SetNamespaceLazy(() => __tmp4);
			__tmp23.DotNetName = "float?";
			__tmp23.SetValueLazy(() => EFloatObject);
			__tmp24.SetTypeLazy(() => EDataType);
			__tmp24.Documentation = null;
			__tmp24.Name = "EDoubleObject";
			__tmp24.SetNamespaceLazy(() => __tmp4);
			__tmp24.DotNetName = "double?";
			__tmp24.SetValueLazy(() => EDoubleObject);
			__tmp25.SetTypeLazy(() => EDataType);
			__tmp25.Documentation = null;
			__tmp25.Name = "EDate";
			__tmp25.SetNamespaceLazy(() => __tmp4);
			__tmp25.DotNetName = "System.DateTime";
			__tmp25.SetValueLazy(() => EDate);
			__tmp26.SetTypeLazy(() => EDataType);
			__tmp26.Documentation = null;
			__tmp26.Name = "EBigInteger";
			__tmp26.SetNamespaceLazy(() => __tmp4);
			__tmp26.DotNetName = "System.Numerics.BigInteger";
			__tmp26.SetValueLazy(() => EBigInteger);
			__tmp27.SetTypeLazy(() => EDataType);
			__tmp27.Documentation = null;
			__tmp27.Name = "EBigDecimal";
			__tmp27.SetNamespaceLazy(() => __tmp4);
			__tmp27.DotNetName = "System.Decimal";
			__tmp27.SetValueLazy(() => EBigDecimal);
			__tmp28.SetTypeLazy(() => EDataType);
			__tmp28.Documentation = null;
			__tmp28.Name = "EResource";
			__tmp28.SetNamespaceLazy(() => __tmp4);
			__tmp28.DotNetName = "MetaDslx.Modeling.IModel";
			__tmp28.SetValueLazy(() => EResource);
			__tmp29.SetTypeLazy(() => EDataType);
			__tmp29.Documentation = null;
			__tmp29.Name = "EResourceSet";
			__tmp29.SetNamespaceLazy(() => __tmp4);
			__tmp29.DotNetName = "MetaDslx.Modeling.IModelGroup";
			__tmp29.SetValueLazy(() => EResourceSet);
			__tmp30.SetTypeLazy(() => EDataType);
			__tmp30.Documentation = null;
			__tmp30.Name = "EFeatureMap";
			__tmp30.SetNamespaceLazy(() => __tmp4);
			__tmp30.DotNetName = "System.Collections.Generic.Dictionary<EStructuralFeature,object>";
			__tmp30.SetValueLazy(() => EFeatureMap);
			__tmp31.SetTypeLazy(() => EDataType);
			__tmp31.Documentation = null;
			__tmp31.Name = "EFeatureMapEntry";
			__tmp31.SetNamespaceLazy(() => __tmp4);
			__tmp31.DotNetName = "System.Collections.Generic.KeyValuePair<EStructuralFeature,object>";
			__tmp31.SetValueLazy(() => EFeatureMapEntry);
			__tmp32.SetTypeLazy(() => EDataType);
			__tmp32.Documentation = null;
			__tmp32.Name = "EEList";
			__tmp32.SetNamespaceLazy(() => __tmp4);
			__tmp32.DotNetName = "System.Collections.Generic.IReadOnlyList<object>";
			__tmp32.SetValueLazy(() => EEList);
			__tmp33.SetTypeLazy(() => EDataType);
			__tmp33.Documentation = null;
			__tmp33.Name = "EEnumerator";
			__tmp33.SetNamespaceLazy(() => __tmp4);
			__tmp33.DotNetName = "System.Collections.IEnumerator";
			__tmp33.SetValueLazy(() => EEnumerator);
			__tmp34.SetTypeLazy(() => EDataType);
			__tmp34.Documentation = null;
			__tmp34.Name = "ETreeIterator";
			__tmp34.SetNamespaceLazy(() => __tmp4);
			__tmp34.DotNetName = "System.Collections.IEnumerator";
			__tmp34.SetValueLazy(() => ETreeIterator);
			EObject.Documentation = null;
			EObject.Name = "EObject";
			EObject.SetNamespaceLazy(() => __tmp4);
			EObject.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.Symbol);
			EObject.IsAbstract = false;
			EObject.Operations.AddLazy(() => __tmp35);
			EObject.Operations.AddLazy(() => __tmp36);
			EObject.Operations.AddLazy(() => __tmp37);
			EObject.Operations.AddLazy(() => __tmp38);
			EObject.Operations.AddLazy(() => __tmp39);
			EObject.Operations.AddLazy(() => __tmp40);
			EObject.Operations.AddLazy(() => __tmp41);
			EObject.Operations.AddLazy(() => __tmp42);
			EObject.Operations.AddLazy(() => __tmp43);
			EObject.Operations.AddLazy(() => __tmp44);
			EObject.Operations.AddLazy(() => __tmp45);
			EObject.Operations.AddLazy(() => __tmp46);
			EObject.Operations.AddLazy(() => __tmp47);
			EObject.Operations.AddLazy(() => __tmp48);
			__tmp35.Documentation = null;
			__tmp35.Name = "EClass";
			__tmp35.SetClassLazy(() => EObject);
			// __tmp35.Enum = null;
			__tmp35.IsBuilder = false;
			__tmp35.IsReadonly = false;
			__tmp35.SetReturnTypeLazy(() => EClass);
			__tmp36.Documentation = null;
			__tmp36.Name = "EIsProxy";
			__tmp36.SetClassLazy(() => EObject);
			// __tmp36.Enum = null;
			__tmp36.IsBuilder = false;
			__tmp36.IsReadonly = false;
			__tmp36.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp37.Documentation = null;
			__tmp37.Name = "EResource";
			__tmp37.SetClassLazy(() => EObject);
			// __tmp37.Enum = null;
			__tmp37.IsBuilder = false;
			__tmp37.IsReadonly = false;
			__tmp37.SetReturnTypeLazy(() => __tmp28);
			__tmp38.Documentation = null;
			__tmp38.Name = "EContainer";
			__tmp38.SetClassLazy(() => EObject);
			// __tmp38.Enum = null;
			__tmp38.IsBuilder = false;
			__tmp38.IsReadonly = false;
			__tmp38.SetReturnTypeLazy(() => EObject);
			__tmp39.Documentation = null;
			__tmp39.Name = "EContainingFeature";
			__tmp39.SetClassLazy(() => EObject);
			// __tmp39.Enum = null;
			__tmp39.IsBuilder = false;
			__tmp39.IsReadonly = false;
			__tmp39.SetReturnTypeLazy(() => EStructuralFeature);
			__tmp40.Documentation = null;
			__tmp40.Name = "EContainmentFeature";
			__tmp40.SetClassLazy(() => EObject);
			// __tmp40.Enum = null;
			__tmp40.IsBuilder = false;
			__tmp40.IsReadonly = false;
			__tmp40.SetReturnTypeLazy(() => EReference);
			__tmp41.Documentation = null;
			__tmp41.Name = "EContents";
			__tmp41.SetClassLazy(() => EObject);
			// __tmp41.Enum = null;
			__tmp41.IsBuilder = false;
			__tmp41.IsReadonly = false;
			__tmp41.SetReturnTypeLazy(() => __tmp32);
			__tmp42.Documentation = null;
			__tmp42.Name = "EAllContents";
			__tmp42.SetClassLazy(() => EObject);
			// __tmp42.Enum = null;
			__tmp42.IsBuilder = false;
			__tmp42.IsReadonly = false;
			__tmp42.SetReturnTypeLazy(() => __tmp34);
			__tmp43.Documentation = null;
			__tmp43.Name = "ECrossReferences";
			__tmp43.SetClassLazy(() => EObject);
			// __tmp43.Enum = null;
			__tmp43.IsBuilder = false;
			__tmp43.IsReadonly = false;
			__tmp43.SetReturnTypeLazy(() => __tmp32);
			__tmp44.Documentation = null;
			__tmp44.Name = "EGet";
			__tmp44.SetClassLazy(() => EObject);
			// __tmp44.Enum = null;
			__tmp44.IsBuilder = false;
			__tmp44.IsReadonly = false;
			__tmp44.Parameters.AddLazy(() => __tmp49);
			__tmp44.SetReturnTypeLazy(() => __tmp6);
			__tmp49.SetTypeLazy(() => EStructuralFeature);
			__tmp49.Documentation = null;
			__tmp49.Name = "feature";
			__tmp49.SetOperationLazy(() => __tmp44);
			__tmp45.Documentation = null;
			__tmp45.Name = "EGet";
			__tmp45.SetClassLazy(() => EObject);
			// __tmp45.Enum = null;
			__tmp45.IsBuilder = false;
			__tmp45.IsReadonly = false;
			__tmp45.Parameters.AddLazy(() => __tmp50);
			__tmp45.Parameters.AddLazy(() => __tmp51);
			__tmp45.SetReturnTypeLazy(() => __tmp6);
			__tmp50.SetTypeLazy(() => EStructuralFeature);
			__tmp50.Documentation = null;
			__tmp50.Name = "feature";
			__tmp50.SetOperationLazy(() => __tmp45);
			__tmp51.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp51.Documentation = null;
			__tmp51.Name = "resolve";
			__tmp51.SetOperationLazy(() => __tmp45);
			__tmp46.Documentation = null;
			__tmp46.Name = "ESet";
			__tmp46.SetClassLazy(() => EObject);
			// __tmp46.Enum = null;
			__tmp46.IsBuilder = false;
			__tmp46.IsReadonly = false;
			__tmp46.Parameters.AddLazy(() => __tmp52);
			__tmp46.Parameters.AddLazy(() => __tmp53);
			__tmp46.SetReturnTypeLazy(() => __tmp6);
			__tmp52.SetTypeLazy(() => EStructuralFeature);
			__tmp52.Documentation = null;
			__tmp52.Name = "feature";
			__tmp52.SetOperationLazy(() => __tmp46);
			__tmp53.SetTypeLazy(() => __tmp6);
			__tmp53.Documentation = null;
			__tmp53.Name = "newValue";
			__tmp53.SetOperationLazy(() => __tmp46);
			__tmp47.Documentation = null;
			__tmp47.Name = "EIsSet";
			__tmp47.SetClassLazy(() => EObject);
			// __tmp47.Enum = null;
			__tmp47.IsBuilder = false;
			__tmp47.IsReadonly = false;
			__tmp47.Parameters.AddLazy(() => __tmp54);
			__tmp47.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp54.SetTypeLazy(() => EStructuralFeature);
			__tmp54.Documentation = null;
			__tmp54.Name = "feature";
			__tmp54.SetOperationLazy(() => __tmp47);
			__tmp48.Documentation = null;
			__tmp48.Name = "EUnset";
			__tmp48.SetClassLazy(() => EObject);
			// __tmp48.Enum = null;
			__tmp48.IsBuilder = false;
			__tmp48.IsReadonly = false;
			__tmp48.Parameters.AddLazy(() => __tmp55);
			__tmp48.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Void.ToMutable());
			__tmp55.SetTypeLazy(() => EStructuralFeature);
			__tmp55.Documentation = null;
			__tmp55.Name = "feature";
			__tmp55.SetOperationLazy(() => __tmp48);
			EModelElement.Documentation = null;
			EModelElement.Name = "EModelElement";
			EModelElement.SetNamespaceLazy(() => __tmp4);
			EModelElement.SymbolType = null;
			EModelElement.IsAbstract = true;
			EModelElement.SuperClasses.AddLazy(() => EObject);
			EModelElement.Properties.AddLazy(() => EModelElement_EAnnotations);
			EModelElement.Operations.AddLazy(() => __tmp56);
			EModelElement_EAnnotations.SetTypeLazy(() => __tmp57);
			EModelElement_EAnnotations.Documentation = null;
			EModelElement_EAnnotations.Name = "EAnnotations";
			EModelElement_EAnnotations.SymbolProperty = null;
			EModelElement_EAnnotations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EModelElement_EAnnotations.SetClassLazy(() => EModelElement);
			EModelElement_EAnnotations.DefaultValue = null;
			EModelElement_EAnnotations.IsContainment = true;
			EModelElement_EAnnotations.OppositeProperties.AddLazy(() => EAnnotation_EModelElement);
			__tmp56.Documentation = null;
			__tmp56.Name = "GetEAnnotation";
			__tmp56.SetClassLazy(() => EModelElement);
			// __tmp56.Enum = null;
			__tmp56.IsBuilder = false;
			__tmp56.IsReadonly = true;
			__tmp56.Parameters.AddLazy(() => __tmp58);
			__tmp56.SetReturnTypeLazy(() => EAnnotation);
			__tmp58.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			__tmp58.Documentation = null;
			__tmp58.Name = "source";
			__tmp58.SetOperationLazy(() => __tmp56);
			EFactory.Documentation = null;
			EFactory.Name = "EFactory";
			EFactory.SetNamespaceLazy(() => __tmp4);
			EFactory.SymbolType = null;
			EFactory.IsAbstract = false;
			EFactory.SuperClasses.AddLazy(() => EModelElement);
			EFactory.Properties.AddLazy(() => EFactory_EPackage);
			EFactory.Operations.AddLazy(() => __tmp59);
			EFactory.Operations.AddLazy(() => __tmp60);
			EFactory.Operations.AddLazy(() => __tmp61);
			EFactory_EPackage.SetTypeLazy(() => EPackage);
			EFactory_EPackage.Documentation = null;
			EFactory_EPackage.Name = "EPackage";
			EFactory_EPackage.SymbolProperty = null;
			EFactory_EPackage.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EFactory_EPackage.SetClassLazy(() => EFactory);
			EFactory_EPackage.DefaultValue = null;
			EFactory_EPackage.IsContainment = false;
			__tmp59.Documentation = null;
			__tmp59.Name = "Create";
			__tmp59.SetClassLazy(() => EFactory);
			// __tmp59.Enum = null;
			__tmp59.IsBuilder = false;
			__tmp59.IsReadonly = false;
			__tmp59.Parameters.AddLazy(() => __tmp62);
			__tmp59.SetReturnTypeLazy(() => EObject);
			__tmp62.SetTypeLazy(() => EClass);
			__tmp62.Documentation = null;
			__tmp62.Name = "eClass";
			__tmp62.SetOperationLazy(() => __tmp59);
			__tmp60.Documentation = null;
			__tmp60.Name = "CreateFromString";
			__tmp60.SetClassLazy(() => EFactory);
			// __tmp60.Enum = null;
			__tmp60.IsBuilder = false;
			__tmp60.IsReadonly = false;
			__tmp60.Parameters.AddLazy(() => __tmp63);
			__tmp60.Parameters.AddLazy(() => __tmp64);
			__tmp60.SetReturnTypeLazy(() => EObject);
			__tmp63.SetTypeLazy(() => EDataType);
			__tmp63.Documentation = null;
			__tmp63.Name = "eDataType";
			__tmp63.SetOperationLazy(() => __tmp60);
			__tmp64.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			__tmp64.Documentation = null;
			__tmp64.Name = "literalValue";
			__tmp64.SetOperationLazy(() => __tmp60);
			__tmp61.Documentation = null;
			__tmp61.Name = "ConvertToString";
			__tmp61.SetClassLazy(() => EFactory);
			// __tmp61.Enum = null;
			__tmp61.IsBuilder = false;
			__tmp61.IsReadonly = false;
			__tmp61.Parameters.AddLazy(() => __tmp65);
			__tmp61.Parameters.AddLazy(() => __tmp66);
			__tmp61.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			__tmp65.SetTypeLazy(() => EDataType);
			__tmp65.Documentation = null;
			__tmp65.Name = "eDataType";
			__tmp65.SetOperationLazy(() => __tmp61);
			__tmp66.SetTypeLazy(() => __tmp6);
			__tmp66.Documentation = null;
			__tmp66.Name = "instanceValue";
			__tmp66.SetOperationLazy(() => __tmp61);
			ENamedElement.Documentation = null;
			ENamedElement.Name = "ENamedElement";
			ENamedElement.SetNamespaceLazy(() => __tmp4);
			ENamedElement.SymbolType = null;
			ENamedElement.IsAbstract = true;
			ENamedElement.SuperClasses.AddLazy(() => EModelElement);
			ENamedElement.Properties.AddLazy(() => ENamedElement_Name);
			ENamedElement_Name.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			ENamedElement_Name.Documentation = null;
			ENamedElement_Name.Name = "Name";
			ENamedElement_Name.SymbolProperty = "Name";
			ENamedElement_Name.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ENamedElement_Name.SetClassLazy(() => ENamedElement);
			ENamedElement_Name.DefaultValue = null;
			ENamedElement_Name.IsContainment = false;
			EAnnotation.Documentation = null;
			EAnnotation.Name = "EAnnotation";
			EAnnotation.SetNamespaceLazy(() => __tmp4);
			EAnnotation.SymbolType = null;
			EAnnotation.IsAbstract = false;
			EAnnotation.SuperClasses.AddLazy(() => EModelElement);
			EAnnotation.Properties.AddLazy(() => EAnnotation_EModelElement);
			EAnnotation.Properties.AddLazy(() => EAnnotation_Source);
			EAnnotation.Properties.AddLazy(() => EAnnotation_Details);
			EAnnotation.Properties.AddLazy(() => EAnnotation_Contents);
			EAnnotation.Properties.AddLazy(() => EAnnotation_References);
			EAnnotation_EModelElement.SetTypeLazy(() => EModelElement);
			EAnnotation_EModelElement.Documentation = null;
			EAnnotation_EModelElement.Name = "EModelElement";
			EAnnotation_EModelElement.SymbolProperty = null;
			EAnnotation_EModelElement.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_EModelElement.SetClassLazy(() => EAnnotation);
			EAnnotation_EModelElement.DefaultValue = null;
			EAnnotation_EModelElement.IsContainment = false;
			EAnnotation_EModelElement.OppositeProperties.AddLazy(() => EModelElement_EAnnotations);
			EAnnotation_Source.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EAnnotation_Source.Documentation = null;
			EAnnotation_Source.Name = "Source";
			EAnnotation_Source.SymbolProperty = null;
			EAnnotation_Source.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_Source.SetClassLazy(() => EAnnotation);
			EAnnotation_Source.DefaultValue = null;
			EAnnotation_Source.IsContainment = false;
			EAnnotation_Details.SetTypeLazy(() => __tmp67);
			EAnnotation_Details.Documentation = null;
			EAnnotation_Details.Name = "Details";
			EAnnotation_Details.SymbolProperty = null;
			EAnnotation_Details.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_Details.SetClassLazy(() => EAnnotation);
			EAnnotation_Details.DefaultValue = null;
			EAnnotation_Details.IsContainment = true;
			EAnnotation_Contents.SetTypeLazy(() => __tmp68);
			EAnnotation_Contents.Documentation = null;
			EAnnotation_Contents.Name = "Contents";
			EAnnotation_Contents.SymbolProperty = null;
			EAnnotation_Contents.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_Contents.SetClassLazy(() => EAnnotation);
			EAnnotation_Contents.DefaultValue = null;
			EAnnotation_Contents.IsContainment = true;
			EAnnotation_References.SetTypeLazy(() => __tmp69);
			EAnnotation_References.Documentation = null;
			EAnnotation_References.Name = "References";
			EAnnotation_References.SymbolProperty = null;
			EAnnotation_References.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_References.SetClassLazy(() => EAnnotation);
			EAnnotation_References.DefaultValue = null;
			EAnnotation_References.IsContainment = false;
			EStringToStringMapEntry.Documentation = null;
			EStringToStringMapEntry.Name = "EStringToStringMapEntry";
			EStringToStringMapEntry.SetNamespaceLazy(() => __tmp4);
			EStringToStringMapEntry.SymbolType = null;
			EStringToStringMapEntry.IsAbstract = false;
			EStringToStringMapEntry.Properties.AddLazy(() => EStringToStringMapEntry_Key);
			EStringToStringMapEntry.Properties.AddLazy(() => EStringToStringMapEntry_Value);
			EStringToStringMapEntry_Key.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EStringToStringMapEntry_Key.Documentation = null;
			EStringToStringMapEntry_Key.Name = "Key";
			EStringToStringMapEntry_Key.SymbolProperty = null;
			EStringToStringMapEntry_Key.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStringToStringMapEntry_Key.SetClassLazy(() => EStringToStringMapEntry);
			EStringToStringMapEntry_Key.DefaultValue = null;
			EStringToStringMapEntry_Key.IsContainment = false;
			EStringToStringMapEntry_Value.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EStringToStringMapEntry_Value.Documentation = null;
			EStringToStringMapEntry_Value.Name = "Value";
			EStringToStringMapEntry_Value.SymbolProperty = null;
			EStringToStringMapEntry_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStringToStringMapEntry_Value.SetClassLazy(() => EStringToStringMapEntry);
			EStringToStringMapEntry_Value.DefaultValue = null;
			EStringToStringMapEntry_Value.IsContainment = false;
			EPackage.Documentation = null;
			EPackage.Name = "EPackage";
			EPackage.SetNamespaceLazy(() => __tmp4);
			EPackage.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamespaceSymbol);
			EPackage.IsAbstract = false;
			EPackage.SuperClasses.AddLazy(() => ENamedElement);
			EPackage.Properties.AddLazy(() => EPackage_NsURI);
			EPackage.Properties.AddLazy(() => EPackage_NsPrefix);
			EPackage.Properties.AddLazy(() => EPackage_ESuperPackage);
			EPackage.Properties.AddLazy(() => EPackage_ESubPackages);
			EPackage.Properties.AddLazy(() => EPackage_EClassifiers);
			EPackage.Properties.AddLazy(() => EPackage_EFactoryInstance);
			EPackage.Operations.AddLazy(() => __tmp70);
			EPackage_NsURI.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EPackage_NsURI.Documentation = null;
			EPackage_NsURI.Name = "NsURI";
			EPackage_NsURI.SymbolProperty = null;
			EPackage_NsURI.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_NsURI.SetClassLazy(() => EPackage);
			EPackage_NsURI.DefaultValue = null;
			EPackage_NsURI.IsContainment = false;
			EPackage_NsPrefix.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EPackage_NsPrefix.Documentation = null;
			EPackage_NsPrefix.Name = "NsPrefix";
			EPackage_NsPrefix.SymbolProperty = null;
			EPackage_NsPrefix.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_NsPrefix.SetClassLazy(() => EPackage);
			EPackage_NsPrefix.DefaultValue = null;
			EPackage_NsPrefix.IsContainment = false;
			EPackage_ESuperPackage.SetTypeLazy(() => EPackage);
			EPackage_ESuperPackage.Documentation = null;
			EPackage_ESuperPackage.Name = "ESuperPackage";
			EPackage_ESuperPackage.SymbolProperty = null;
			EPackage_ESuperPackage.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_ESuperPackage.SetClassLazy(() => EPackage);
			EPackage_ESuperPackage.DefaultValue = null;
			EPackage_ESuperPackage.IsContainment = false;
			EPackage_ESuperPackage.OppositeProperties.AddLazy(() => EPackage_ESubPackages);
			EPackage_ESubPackages.SetTypeLazy(() => __tmp71);
			EPackage_ESubPackages.Documentation = null;
			EPackage_ESubPackages.Name = "ESubPackages";
			EPackage_ESubPackages.SymbolProperty = "Members";
			EPackage_ESubPackages.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_ESubPackages.SetClassLazy(() => EPackage);
			EPackage_ESubPackages.DefaultValue = null;
			EPackage_ESubPackages.IsContainment = true;
			EPackage_ESubPackages.OppositeProperties.AddLazy(() => EPackage_ESuperPackage);
			EPackage_EClassifiers.SetTypeLazy(() => __tmp72);
			EPackage_EClassifiers.Documentation = null;
			EPackage_EClassifiers.Name = "EClassifiers";
			EPackage_EClassifiers.SymbolProperty = "Members";
			EPackage_EClassifiers.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_EClassifiers.SetClassLazy(() => EPackage);
			EPackage_EClassifiers.DefaultValue = null;
			EPackage_EClassifiers.IsContainment = true;
			EPackage_EClassifiers.OppositeProperties.AddLazy(() => EClassifier_EPackage);
			EPackage_EFactoryInstance.SetTypeLazy(() => EFactory);
			EPackage_EFactoryInstance.Documentation = null;
			EPackage_EFactoryInstance.Name = "EFactoryInstance";
			EPackage_EFactoryInstance.SymbolProperty = null;
			EPackage_EFactoryInstance.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_EFactoryInstance.SetClassLazy(() => EPackage);
			EPackage_EFactoryInstance.DefaultValue = null;
			EPackage_EFactoryInstance.IsContainment = false;
			__tmp70.Documentation = null;
			__tmp70.Name = "GetEClassifier";
			__tmp70.SetClassLazy(() => EPackage);
			// __tmp70.Enum = null;
			__tmp70.IsBuilder = false;
			__tmp70.IsReadonly = false;
			__tmp70.Parameters.AddLazy(() => __tmp73);
			__tmp70.SetReturnTypeLazy(() => EClassifier);
			__tmp73.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			__tmp73.Documentation = null;
			__tmp73.Name = "name";
			__tmp73.SetOperationLazy(() => __tmp70);
			EClassifier.Documentation = null;
			EClassifier.Name = "EClassifier";
			EClassifier.SetNamespaceLazy(() => __tmp4);
			EClassifier.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			EClassifier.IsAbstract = false;
			EClassifier.SuperClasses.AddLazy(() => ENamedElement);
			EClassifier.Properties.AddLazy(() => EClassifier_InstanceClassName);
			EClassifier.Properties.AddLazy(() => EClassifier_EPackage);
			EClassifier.Properties.AddLazy(() => EClassifier_ETypeParameters);
			EClassifier.Properties.AddLazy(() => EClassifier_InstanceClass);
			EClassifier.Properties.AddLazy(() => EClassifier_DefaultValue);
			EClassifier.Operations.AddLazy(() => __tmp74);
			EClassifier.Operations.AddLazy(() => __tmp75);
			EClassifier_InstanceClassName.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EClassifier_InstanceClassName.Documentation = null;
			EClassifier_InstanceClassName.Name = "InstanceClassName";
			EClassifier_InstanceClassName.SymbolProperty = null;
			EClassifier_InstanceClassName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_InstanceClassName.SetClassLazy(() => EClassifier);
			EClassifier_InstanceClassName.DefaultValue = null;
			EClassifier_InstanceClassName.IsContainment = false;
			EClassifier_EPackage.SetTypeLazy(() => EPackage);
			EClassifier_EPackage.Documentation = null;
			EClassifier_EPackage.Name = "EPackage";
			EClassifier_EPackage.SymbolProperty = null;
			EClassifier_EPackage.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_EPackage.SetClassLazy(() => EClassifier);
			EClassifier_EPackage.DefaultValue = null;
			EClassifier_EPackage.IsContainment = false;
			EClassifier_EPackage.OppositeProperties.AddLazy(() => EPackage_EClassifiers);
			EClassifier_ETypeParameters.SetTypeLazy(() => __tmp76);
			EClassifier_ETypeParameters.Documentation = null;
			EClassifier_ETypeParameters.Name = "ETypeParameters";
			EClassifier_ETypeParameters.SymbolProperty = "TypeParameters";
			EClassifier_ETypeParameters.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_ETypeParameters.SetClassLazy(() => EClassifier);
			EClassifier_ETypeParameters.DefaultValue = null;
			EClassifier_ETypeParameters.IsContainment = true;
			EClassifier_InstanceClass.SetTypeLazy(() => __tmp7);
			EClassifier_InstanceClass.Documentation = null;
			EClassifier_InstanceClass.Name = "InstanceClass";
			EClassifier_InstanceClass.SymbolProperty = null;
			EClassifier_InstanceClass.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_InstanceClass.SetClassLazy(() => EClassifier);
			EClassifier_InstanceClass.DefaultValue = null;
			EClassifier_InstanceClass.IsContainment = false;
			EClassifier_DefaultValue.SetTypeLazy(() => __tmp6);
			EClassifier_DefaultValue.Documentation = null;
			EClassifier_DefaultValue.Name = "DefaultValue";
			EClassifier_DefaultValue.SymbolProperty = null;
			EClassifier_DefaultValue.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_DefaultValue.SetClassLazy(() => EClassifier);
			EClassifier_DefaultValue.DefaultValue = null;
			EClassifier_DefaultValue.IsContainment = false;
			__tmp74.Documentation = " <summary>\r\n Returns whether the object is an instance of this classifier.\r\n </summary>\r\n";
			__tmp74.Name = "IsInstance";
			__tmp74.SetClassLazy(() => EClassifier);
			// __tmp74.Enum = null;
			__tmp74.IsBuilder = false;
			__tmp74.IsReadonly = false;
			__tmp74.Parameters.AddLazy(() => __tmp77);
			__tmp74.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp77.SetTypeLazy(() => __tmp6);
			__tmp77.Documentation = null;
			__tmp77.Name = "@object";
			__tmp77.SetOperationLazy(() => __tmp74);
			__tmp75.Documentation = null;
			__tmp75.Name = "GetClassifierID";
			__tmp75.SetClassLazy(() => EClassifier);
			// __tmp75.Enum = null;
			__tmp75.IsBuilder = false;
			__tmp75.IsReadonly = false;
			__tmp75.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Int.ToMutable());
			EClass.Documentation = null;
			EClass.Name = "EClass";
			EClass.SetNamespaceLazy(() => __tmp4);
			EClass.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.ClassTypeSymbol);
			EClass.IsAbstract = false;
			EClass.SuperClasses.AddLazy(() => EClassifier);
			EClass.Properties.AddLazy(() => EClass_Abstract);
			EClass.Properties.AddLazy(() => EClass_Interface);
			EClass.Properties.AddLazy(() => EClass_ESuperTypes);
			EClass.Properties.AddLazy(() => EClass_EAllSuperTypes);
			EClass.Properties.AddLazy(() => EClass_EStructuralFeatures);
			EClass.Properties.AddLazy(() => EClass_EAllStructuralFeatures);
			EClass.Properties.AddLazy(() => EClass_EOperations);
			EClass.Properties.AddLazy(() => EClass_EAllOperation);
			EClass.Properties.AddLazy(() => EClass_EReferences);
			EClass.Properties.AddLazy(() => EClass_EAllReferences);
			EClass.Properties.AddLazy(() => EClass_EAllContainments);
			EClass.Properties.AddLazy(() => EClass_EAttributes);
			EClass.Properties.AddLazy(() => EClass_EAllAttributes);
			EClass.Properties.AddLazy(() => EClass_EIDAttribute);
			EClass.Properties.AddLazy(() => EClass_EGenericSuperTypes);
			EClass.Properties.AddLazy(() => EClass_EAllGenericSuperTypes);
			EClass.Operations.AddLazy(() => __tmp78);
			EClass.Operations.AddLazy(() => __tmp79);
			EClass.Operations.AddLazy(() => __tmp80);
			EClass_Abstract.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EClass_Abstract.Documentation = null;
			EClass_Abstract.Name = "Abstract";
			EClass_Abstract.SymbolProperty = "IsAbstract";
			EClass_Abstract.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_Abstract.SetClassLazy(() => EClass);
			EClass_Abstract.DefaultValue = null;
			EClass_Abstract.IsContainment = false;
			EClass_Interface.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EClass_Interface.Documentation = null;
			EClass_Interface.Name = "Interface";
			EClass_Interface.SymbolProperty = null;
			EClass_Interface.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_Interface.SetClassLazy(() => EClass);
			EClass_Interface.DefaultValue = null;
			EClass_Interface.IsContainment = false;
			EClass_ESuperTypes.SetTypeLazy(() => __tmp81);
			EClass_ESuperTypes.Documentation = null;
			EClass_ESuperTypes.Name = "ESuperTypes";
			EClass_ESuperTypes.SymbolProperty = "BaseTypes";
			EClass_ESuperTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_ESuperTypes.SetClassLazy(() => EClass);
			EClass_ESuperTypes.DefaultValue = null;
			EClass_ESuperTypes.IsContainment = false;
			EClass_EAllSuperTypes.SetTypeLazy(() => __tmp82);
			EClass_EAllSuperTypes.Documentation = null;
			EClass_EAllSuperTypes.Name = "EAllSuperTypes";
			EClass_EAllSuperTypes.SymbolProperty = null;
			EClass_EAllSuperTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllSuperTypes.SetClassLazy(() => EClass);
			EClass_EAllSuperTypes.DefaultValue = null;
			EClass_EAllSuperTypes.IsContainment = false;
			EClass_EStructuralFeatures.SetTypeLazy(() => __tmp83);
			EClass_EStructuralFeatures.Documentation = null;
			EClass_EStructuralFeatures.Name = "EStructuralFeatures";
			EClass_EStructuralFeatures.SymbolProperty = "Members";
			EClass_EStructuralFeatures.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_EStructuralFeatures.SetClassLazy(() => EClass);
			EClass_EStructuralFeatures.DefaultValue = null;
			EClass_EStructuralFeatures.IsContainment = true;
			EClass_EStructuralFeatures.OppositeProperties.AddLazy(() => EStructuralFeature_EContainingClass);
			EClass_EAllStructuralFeatures.SetTypeLazy(() => __tmp84);
			EClass_EAllStructuralFeatures.Documentation = null;
			EClass_EAllStructuralFeatures.Name = "EAllStructuralFeatures";
			EClass_EAllStructuralFeatures.SymbolProperty = null;
			EClass_EAllStructuralFeatures.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllStructuralFeatures.SetClassLazy(() => EClass);
			EClass_EAllStructuralFeatures.DefaultValue = null;
			EClass_EAllStructuralFeatures.IsContainment = false;
			EClass_EOperations.SetTypeLazy(() => __tmp85);
			EClass_EOperations.Documentation = null;
			EClass_EOperations.Name = "EOperations";
			EClass_EOperations.SymbolProperty = "Members";
			EClass_EOperations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_EOperations.SetClassLazy(() => EClass);
			EClass_EOperations.DefaultValue = null;
			EClass_EOperations.IsContainment = true;
			EClass_EOperations.OppositeProperties.AddLazy(() => EOperation_EContainingClass);
			EClass_EAllOperation.SetTypeLazy(() => __tmp86);
			EClass_EAllOperation.Documentation = null;
			EClass_EAllOperation.Name = "EAllOperation";
			EClass_EAllOperation.SymbolProperty = null;
			EClass_EAllOperation.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllOperation.SetClassLazy(() => EClass);
			EClass_EAllOperation.DefaultValue = null;
			EClass_EAllOperation.IsContainment = false;
			EClass_EReferences.SetTypeLazy(() => __tmp87);
			EClass_EReferences.Documentation = null;
			EClass_EReferences.Name = "EReferences";
			EClass_EReferences.SymbolProperty = null;
			EClass_EReferences.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EReferences.SetClassLazy(() => EClass);
			EClass_EReferences.DefaultValue = null;
			EClass_EReferences.IsContainment = false;
			EClass_EAllReferences.SetTypeLazy(() => __tmp88);
			EClass_EAllReferences.Documentation = null;
			EClass_EAllReferences.Name = "EAllReferences";
			EClass_EAllReferences.SymbolProperty = null;
			EClass_EAllReferences.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllReferences.SetClassLazy(() => EClass);
			EClass_EAllReferences.DefaultValue = null;
			EClass_EAllReferences.IsContainment = false;
			EClass_EAllContainments.SetTypeLazy(() => __tmp89);
			EClass_EAllContainments.Documentation = null;
			EClass_EAllContainments.Name = "EAllContainments";
			EClass_EAllContainments.SymbolProperty = null;
			EClass_EAllContainments.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllContainments.SetClassLazy(() => EClass);
			EClass_EAllContainments.DefaultValue = null;
			EClass_EAllContainments.IsContainment = false;
			EClass_EAttributes.SetTypeLazy(() => __tmp90);
			EClass_EAttributes.Documentation = null;
			EClass_EAttributes.Name = "EAttributes";
			EClass_EAttributes.SymbolProperty = null;
			EClass_EAttributes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAttributes.SetClassLazy(() => EClass);
			EClass_EAttributes.DefaultValue = null;
			EClass_EAttributes.IsContainment = false;
			EClass_EAllAttributes.SetTypeLazy(() => __tmp91);
			EClass_EAllAttributes.Documentation = null;
			EClass_EAllAttributes.Name = "EAllAttributes";
			EClass_EAllAttributes.SymbolProperty = null;
			EClass_EAllAttributes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllAttributes.SetClassLazy(() => EClass);
			EClass_EAllAttributes.DefaultValue = null;
			EClass_EAllAttributes.IsContainment = false;
			EClass_EIDAttribute.SetTypeLazy(() => EAttribute);
			EClass_EIDAttribute.Documentation = null;
			EClass_EIDAttribute.Name = "EIDAttribute";
			EClass_EIDAttribute.SymbolProperty = null;
			EClass_EIDAttribute.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EIDAttribute.SetClassLazy(() => EClass);
			EClass_EIDAttribute.DefaultValue = null;
			EClass_EIDAttribute.IsContainment = false;
			EClass_EGenericSuperTypes.SetTypeLazy(() => __tmp92);
			EClass_EGenericSuperTypes.Documentation = null;
			EClass_EGenericSuperTypes.Name = "EGenericSuperTypes";
			EClass_EGenericSuperTypes.SymbolProperty = null;
			EClass_EGenericSuperTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_EGenericSuperTypes.SetClassLazy(() => EClass);
			EClass_EGenericSuperTypes.DefaultValue = null;
			EClass_EGenericSuperTypes.IsContainment = true;
			EClass_EAllGenericSuperTypes.SetTypeLazy(() => __tmp93);
			EClass_EAllGenericSuperTypes.Documentation = null;
			EClass_EAllGenericSuperTypes.Name = "EAllGenericSuperTypes";
			EClass_EAllGenericSuperTypes.SymbolProperty = null;
			EClass_EAllGenericSuperTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllGenericSuperTypes.SetClassLazy(() => EClass);
			EClass_EAllGenericSuperTypes.DefaultValue = null;
			EClass_EAllGenericSuperTypes.IsContainment = false;
			__tmp78.Documentation = null;
			__tmp78.Name = "IsSuperTypeOf";
			__tmp78.SetClassLazy(() => EClass);
			// __tmp78.Enum = null;
			__tmp78.IsBuilder = false;
			__tmp78.IsReadonly = false;
			__tmp78.Parameters.AddLazy(() => __tmp94);
			__tmp78.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			__tmp94.SetTypeLazy(() => EClass);
			__tmp94.Documentation = null;
			__tmp94.Name = "someClass";
			__tmp94.SetOperationLazy(() => __tmp78);
			__tmp79.Documentation = null;
			__tmp79.Name = "GetStructuralFeature";
			__tmp79.SetClassLazy(() => EClass);
			// __tmp79.Enum = null;
			__tmp79.IsBuilder = false;
			__tmp79.IsReadonly = false;
			__tmp79.Parameters.AddLazy(() => __tmp95);
			__tmp79.SetReturnTypeLazy(() => EStructuralFeature);
			__tmp95.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Int.ToMutable());
			__tmp95.Documentation = null;
			__tmp95.Name = "featureID";
			__tmp95.SetOperationLazy(() => __tmp79);
			__tmp80.Documentation = null;
			__tmp80.Name = "GetStructuralFeature";
			__tmp80.SetClassLazy(() => EClass);
			// __tmp80.Enum = null;
			__tmp80.IsBuilder = false;
			__tmp80.IsReadonly = false;
			__tmp80.Parameters.AddLazy(() => __tmp96);
			__tmp80.SetReturnTypeLazy(() => EStructuralFeature);
			__tmp96.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			__tmp96.Documentation = null;
			__tmp96.Name = "featureName";
			__tmp96.SetOperationLazy(() => __tmp80);
			EDataType.Documentation = null;
			EDataType.Name = "EDataType";
			EDataType.SetNamespaceLazy(() => __tmp4);
			EDataType.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			EDataType.IsAbstract = false;
			EDataType.SuperClasses.AddLazy(() => EClassifier);
			EDataType.Properties.AddLazy(() => EDataType_Serializable);
			EDataType.Properties.AddLazy(() => EDataType_DotNetName);
			EDataType_Serializable.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EDataType_Serializable.Documentation = null;
			EDataType_Serializable.Name = "Serializable";
			EDataType_Serializable.SymbolProperty = null;
			EDataType_Serializable.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EDataType_Serializable.SetClassLazy(() => EDataType);
			EDataType_Serializable.DefaultValue = "true";
			EDataType_Serializable.IsContainment = false;
			EDataType_DotNetName.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EDataType_DotNetName.Documentation = null;
			EDataType_DotNetName.Name = "DotNetName";
			EDataType_DotNetName.SymbolProperty = null;
			EDataType_DotNetName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EDataType_DotNetName.SetClassLazy(() => EDataType);
			EDataType_DotNetName.DefaultValue = null;
			EDataType_DotNetName.IsContainment = false;
			EEnum.Documentation = null;
			EEnum.Name = "EEnum";
			EEnum.SetNamespaceLazy(() => __tmp4);
			EEnum.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.EnumTypeSymbol);
			EEnum.IsAbstract = false;
			EEnum.SuperClasses.AddLazy(() => EDataType);
			EEnum.Properties.AddLazy(() => EEnum_ELiterals);
			EEnum.Operations.AddLazy(() => __tmp97);
			EEnum.Operations.AddLazy(() => __tmp98);
			EEnum_ELiterals.SetTypeLazy(() => __tmp99);
			EEnum_ELiterals.Documentation = null;
			EEnum_ELiterals.Name = "ELiterals";
			EEnum_ELiterals.SymbolProperty = "Members";
			EEnum_ELiterals.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnum_ELiterals.SetClassLazy(() => EEnum);
			EEnum_ELiterals.DefaultValue = null;
			EEnum_ELiterals.IsContainment = true;
			EEnum_ELiterals.OppositeProperties.AddLazy(() => EEnumLiteral_EEnum);
			__tmp97.Documentation = null;
			__tmp97.Name = "GetEEnumLiteral";
			__tmp97.SetClassLazy(() => EEnum);
			// __tmp97.Enum = null;
			__tmp97.IsBuilder = false;
			__tmp97.IsReadonly = false;
			__tmp97.Parameters.AddLazy(() => __tmp100);
			__tmp97.SetReturnTypeLazy(() => EEnumLiteral);
			__tmp100.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			__tmp100.Documentation = null;
			__tmp100.Name = "name";
			__tmp100.SetOperationLazy(() => __tmp97);
			__tmp98.Documentation = null;
			__tmp98.Name = "GetEEnumLiteral";
			__tmp98.SetClassLazy(() => EEnum);
			// __tmp98.Enum = null;
			__tmp98.IsBuilder = false;
			__tmp98.IsReadonly = false;
			__tmp98.Parameters.AddLazy(() => __tmp101);
			__tmp98.SetReturnTypeLazy(() => EEnumLiteral);
			__tmp101.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Int.ToMutable());
			__tmp101.Documentation = null;
			__tmp101.Name = "value";
			__tmp101.SetOperationLazy(() => __tmp98);
			EEnumLiteral.Documentation = null;
			EEnumLiteral.Name = "EEnumLiteral";
			EEnumLiteral.SetNamespaceLazy(() => __tmp4);
			EEnumLiteral.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.EnumLiteralSymbol);
			EEnumLiteral.IsAbstract = false;
			EEnumLiteral.SuperClasses.AddLazy(() => ENamedElement);
			EEnumLiteral.Properties.AddLazy(() => EEnumLiteral_EEnum);
			EEnumLiteral.Properties.AddLazy(() => EEnumLiteral_Value);
			EEnumLiteral.Properties.AddLazy(() => EEnumLiteral_Instance);
			EEnumLiteral_EEnum.SetTypeLazy(() => EEnum);
			EEnumLiteral_EEnum.Documentation = null;
			EEnumLiteral_EEnum.Name = "EEnum";
			EEnumLiteral_EEnum.SymbolProperty = null;
			EEnumLiteral_EEnum.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnumLiteral_EEnum.SetClassLazy(() => EEnumLiteral);
			EEnumLiteral_EEnum.DefaultValue = null;
			EEnumLiteral_EEnum.IsContainment = false;
			EEnumLiteral_EEnum.OppositeProperties.AddLazy(() => EEnum_ELiterals);
			EEnumLiteral_Value.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Int.ToMutable());
			EEnumLiteral_Value.Documentation = null;
			EEnumLiteral_Value.Name = "Value";
			EEnumLiteral_Value.SymbolProperty = null;
			EEnumLiteral_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnumLiteral_Value.SetClassLazy(() => EEnumLiteral);
			EEnumLiteral_Value.DefaultValue = null;
			EEnumLiteral_Value.IsContainment = false;
			EEnumLiteral_Instance.SetTypeLazy(() => __tmp33);
			EEnumLiteral_Instance.Documentation = null;
			EEnumLiteral_Instance.Name = "Instance";
			EEnumLiteral_Instance.SymbolProperty = null;
			EEnumLiteral_Instance.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnumLiteral_Instance.SetClassLazy(() => EEnumLiteral);
			EEnumLiteral_Instance.DefaultValue = null;
			EEnumLiteral_Instance.IsContainment = false;
			ETypedElement.Documentation = null;
			ETypedElement.Name = "ETypedElement";
			ETypedElement.SetNamespaceLazy(() => __tmp4);
			ETypedElement.SymbolType = null;
			ETypedElement.IsAbstract = false;
			ETypedElement.SuperClasses.AddLazy(() => ENamedElement);
			ETypedElement.Properties.AddLazy(() => ETypedElement_EType);
			ETypedElement.Properties.AddLazy(() => ETypedElement_Ordered);
			ETypedElement.Properties.AddLazy(() => ETypedElement_Unique);
			ETypedElement.Properties.AddLazy(() => ETypedElement_LowerBound);
			ETypedElement.Properties.AddLazy(() => ETypedElement_UpperBound);
			ETypedElement.Properties.AddLazy(() => ETypedElement_Many);
			ETypedElement.Properties.AddLazy(() => ETypedElement_Required);
			ETypedElement.Properties.AddLazy(() => ETypedElement_EGenericType);
			ETypedElement_EType.SetTypeLazy(() => EClassifier);
			ETypedElement_EType.Documentation = null;
			ETypedElement_EType.Name = "EType";
			ETypedElement_EType.SymbolProperty = null;
			ETypedElement_EType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_EType.SetClassLazy(() => ETypedElement);
			ETypedElement_EType.DefaultValue = null;
			ETypedElement_EType.IsContainment = false;
			ETypedElement_EType.SubsettingProperties.AddLazy(() => EStructuralFeature_EType);
			ETypedElement_EType.RedefiningProperties.AddLazy(() => EOperation_EType);
			ETypedElement_Ordered.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			ETypedElement_Ordered.Documentation = null;
			ETypedElement_Ordered.Name = "Ordered";
			ETypedElement_Ordered.SymbolProperty = null;
			ETypedElement_Ordered.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_Ordered.SetClassLazy(() => ETypedElement);
			ETypedElement_Ordered.DefaultValue = "true";
			ETypedElement_Ordered.IsContainment = false;
			ETypedElement_Unique.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			ETypedElement_Unique.Documentation = null;
			ETypedElement_Unique.Name = "Unique";
			ETypedElement_Unique.SymbolProperty = null;
			ETypedElement_Unique.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_Unique.SetClassLazy(() => ETypedElement);
			ETypedElement_Unique.DefaultValue = "true";
			ETypedElement_Unique.IsContainment = false;
			ETypedElement_LowerBound.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Int.ToMutable());
			ETypedElement_LowerBound.Documentation = null;
			ETypedElement_LowerBound.Name = "LowerBound";
			ETypedElement_LowerBound.SymbolProperty = null;
			ETypedElement_LowerBound.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_LowerBound.SetClassLazy(() => ETypedElement);
			ETypedElement_LowerBound.DefaultValue = null;
			ETypedElement_LowerBound.IsContainment = false;
			ETypedElement_UpperBound.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Int.ToMutable());
			ETypedElement_UpperBound.Documentation = null;
			ETypedElement_UpperBound.Name = "UpperBound";
			ETypedElement_UpperBound.SymbolProperty = null;
			ETypedElement_UpperBound.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_UpperBound.SetClassLazy(() => ETypedElement);
			ETypedElement_UpperBound.DefaultValue = "1";
			ETypedElement_UpperBound.IsContainment = false;
			ETypedElement_Many.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			ETypedElement_Many.Documentation = null;
			ETypedElement_Many.Name = "Many";
			ETypedElement_Many.SymbolProperty = null;
			ETypedElement_Many.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			ETypedElement_Many.SetClassLazy(() => ETypedElement);
			ETypedElement_Many.DefaultValue = null;
			ETypedElement_Many.IsContainment = false;
			ETypedElement_Required.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			ETypedElement_Required.Documentation = null;
			ETypedElement_Required.Name = "Required";
			ETypedElement_Required.SymbolProperty = null;
			ETypedElement_Required.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			ETypedElement_Required.SetClassLazy(() => ETypedElement);
			ETypedElement_Required.DefaultValue = null;
			ETypedElement_Required.IsContainment = false;
			ETypedElement_EGenericType.SetTypeLazy(() => EGenericType);
			ETypedElement_EGenericType.Documentation = null;
			ETypedElement_EGenericType.Name = "EGenericType";
			ETypedElement_EGenericType.SymbolProperty = null;
			ETypedElement_EGenericType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_EGenericType.SetClassLazy(() => ETypedElement);
			ETypedElement_EGenericType.DefaultValue = null;
			ETypedElement_EGenericType.IsContainment = true;
			EStructuralFeature.Documentation = null;
			EStructuralFeature.Name = "EStructuralFeature";
			EStructuralFeature.SetNamespaceLazy(() => __tmp4);
			EStructuralFeature.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.PropertySymbol);
			EStructuralFeature.IsAbstract = false;
			EStructuralFeature.SuperClasses.AddLazy(() => ETypedElement);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_EContainingClass);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_EType);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Changeable);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Volatile);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Transient);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_DefaultValueLiteral);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_DefaultValue);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Unsettable);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Derived);
			EStructuralFeature.Operations.AddLazy(() => __tmp102);
			EStructuralFeature.Operations.AddLazy(() => __tmp103);
			EStructuralFeature_EContainingClass.SetTypeLazy(() => EClass);
			EStructuralFeature_EContainingClass.Documentation = null;
			EStructuralFeature_EContainingClass.Name = "EContainingClass";
			EStructuralFeature_EContainingClass.SymbolProperty = null;
			EStructuralFeature_EContainingClass.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_EContainingClass.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_EContainingClass.DefaultValue = null;
			EStructuralFeature_EContainingClass.IsContainment = false;
			EStructuralFeature_EContainingClass.OppositeProperties.AddLazy(() => EClass_EStructuralFeatures);
			EStructuralFeature_EType.SetTypeLazy(() => EClassifier);
			EStructuralFeature_EType.Documentation = null;
			EStructuralFeature_EType.Name = "EType";
			EStructuralFeature_EType.SymbolProperty = "Type";
			EStructuralFeature_EType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_EType.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_EType.DefaultValue = null;
			EStructuralFeature_EType.IsContainment = false;
			EStructuralFeature_EType.SubsettedProperties.AddLazy(() => ETypedElement_EType);
			EStructuralFeature_Changeable.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EStructuralFeature_Changeable.Documentation = null;
			EStructuralFeature_Changeable.Name = "Changeable";
			EStructuralFeature_Changeable.SymbolProperty = null;
			EStructuralFeature_Changeable.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Changeable.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Changeable.DefaultValue = "true";
			EStructuralFeature_Changeable.IsContainment = false;
			EStructuralFeature_Volatile.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EStructuralFeature_Volatile.Documentation = null;
			EStructuralFeature_Volatile.Name = "Volatile";
			EStructuralFeature_Volatile.SymbolProperty = null;
			EStructuralFeature_Volatile.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Volatile.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Volatile.DefaultValue = null;
			EStructuralFeature_Volatile.IsContainment = false;
			EStructuralFeature_Transient.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EStructuralFeature_Transient.Documentation = null;
			EStructuralFeature_Transient.Name = "Transient";
			EStructuralFeature_Transient.SymbolProperty = null;
			EStructuralFeature_Transient.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Transient.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Transient.DefaultValue = null;
			EStructuralFeature_Transient.IsContainment = false;
			EStructuralFeature_DefaultValueLiteral.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EStructuralFeature_DefaultValueLiteral.Documentation = null;
			EStructuralFeature_DefaultValueLiteral.Name = "DefaultValueLiteral";
			EStructuralFeature_DefaultValueLiteral.SymbolProperty = null;
			EStructuralFeature_DefaultValueLiteral.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_DefaultValueLiteral.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_DefaultValueLiteral.DefaultValue = null;
			EStructuralFeature_DefaultValueLiteral.IsContainment = false;
			EStructuralFeature_DefaultValue.SetTypeLazy(() => __tmp6);
			EStructuralFeature_DefaultValue.Documentation = null;
			EStructuralFeature_DefaultValue.Name = "DefaultValue";
			EStructuralFeature_DefaultValue.SymbolProperty = null;
			EStructuralFeature_DefaultValue.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_DefaultValue.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_DefaultValue.DefaultValue = null;
			EStructuralFeature_DefaultValue.IsContainment = false;
			EStructuralFeature_Unsettable.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EStructuralFeature_Unsettable.Documentation = null;
			EStructuralFeature_Unsettable.Name = "Unsettable";
			EStructuralFeature_Unsettable.SymbolProperty = null;
			EStructuralFeature_Unsettable.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Unsettable.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Unsettable.DefaultValue = null;
			EStructuralFeature_Unsettable.IsContainment = false;
			EStructuralFeature_Derived.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EStructuralFeature_Derived.Documentation = null;
			EStructuralFeature_Derived.Name = "Derived";
			EStructuralFeature_Derived.SymbolProperty = null;
			EStructuralFeature_Derived.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Derived.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Derived.DefaultValue = null;
			EStructuralFeature_Derived.IsContainment = false;
			__tmp102.Documentation = null;
			__tmp102.Name = "GetFeatureID";
			__tmp102.SetClassLazy(() => EStructuralFeature);
			// __tmp102.Enum = null;
			__tmp102.IsBuilder = false;
			__tmp102.IsReadonly = false;
			__tmp102.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Int.ToMutable());
			__tmp103.Documentation = null;
			__tmp103.Name = "GetContainerClass";
			__tmp103.SetClassLazy(() => EStructuralFeature);
			// __tmp103.Enum = null;
			__tmp103.IsBuilder = false;
			__tmp103.IsReadonly = false;
			__tmp103.SetReturnTypeLazy(() => __tmp7);
			EAttribute.Documentation = null;
			EAttribute.Name = "EAttribute";
			EAttribute.SetNamespaceLazy(() => __tmp4);
			EAttribute.SymbolType = null;
			EAttribute.IsAbstract = false;
			EAttribute.SuperClasses.AddLazy(() => EStructuralFeature);
			EAttribute.Properties.AddLazy(() => EAttribute_ID);
			EAttribute.Properties.AddLazy(() => EAttribute_EAttributeType);
			EAttribute_ID.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EAttribute_ID.Documentation = null;
			EAttribute_ID.Name = "ID";
			EAttribute_ID.SymbolProperty = null;
			EAttribute_ID.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAttribute_ID.SetClassLazy(() => EAttribute);
			EAttribute_ID.DefaultValue = null;
			EAttribute_ID.IsContainment = false;
			EAttribute_EAttributeType.SetTypeLazy(() => EDataType);
			EAttribute_EAttributeType.Documentation = null;
			EAttribute_EAttributeType.Name = "EAttributeType";
			EAttribute_EAttributeType.SymbolProperty = null;
			EAttribute_EAttributeType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EAttribute_EAttributeType.SetClassLazy(() => EAttribute);
			EAttribute_EAttributeType.DefaultValue = null;
			EAttribute_EAttributeType.IsContainment = false;
			EReference.Documentation = null;
			EReference.Name = "EReference";
			EReference.SetNamespaceLazy(() => __tmp4);
			EReference.SymbolType = null;
			EReference.IsAbstract = false;
			EReference.SuperClasses.AddLazy(() => EStructuralFeature);
			EReference.Properties.AddLazy(() => EReference_Containment);
			EReference.Properties.AddLazy(() => EReference_Container);
			EReference.Properties.AddLazy(() => EReference_ResolveProxies);
			EReference.Properties.AddLazy(() => EReference_EOpposite);
			EReference.Properties.AddLazy(() => EReference_EReferenceType);
			EReference_Containment.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EReference_Containment.Documentation = null;
			EReference_Containment.Name = "Containment";
			EReference_Containment.SymbolProperty = null;
			EReference_Containment.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EReference_Containment.SetClassLazy(() => EReference);
			EReference_Containment.DefaultValue = null;
			EReference_Containment.IsContainment = false;
			EReference_Container.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EReference_Container.Documentation = null;
			EReference_Container.Name = "Container";
			EReference_Container.SymbolProperty = null;
			EReference_Container.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EReference_Container.SetClassLazy(() => EReference);
			EReference_Container.DefaultValue = null;
			EReference_Container.IsContainment = false;
			EReference_ResolveProxies.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			EReference_ResolveProxies.Documentation = null;
			EReference_ResolveProxies.Name = "ResolveProxies";
			EReference_ResolveProxies.SymbolProperty = null;
			EReference_ResolveProxies.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EReference_ResolveProxies.SetClassLazy(() => EReference);
			EReference_ResolveProxies.DefaultValue = "true";
			EReference_ResolveProxies.IsContainment = false;
			EReference_EOpposite.SetTypeLazy(() => EReference);
			EReference_EOpposite.Documentation = null;
			EReference_EOpposite.Name = "EOpposite";
			EReference_EOpposite.SymbolProperty = null;
			EReference_EOpposite.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EReference_EOpposite.SetClassLazy(() => EReference);
			EReference_EOpposite.DefaultValue = null;
			EReference_EOpposite.IsContainment = false;
			EReference_EReferenceType.SetTypeLazy(() => EClass);
			EReference_EReferenceType.Documentation = null;
			EReference_EReferenceType.Name = "EReferenceType";
			EReference_EReferenceType.SymbolProperty = null;
			EReference_EReferenceType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EReference_EReferenceType.SetClassLazy(() => EReference);
			EReference_EReferenceType.DefaultValue = null;
			EReference_EReferenceType.IsContainment = false;
			EOperation.Documentation = null;
			EOperation.Name = "EOperation";
			EOperation.SetNamespaceLazy(() => __tmp4);
			EOperation.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.MethodSymbol);
			EOperation.IsAbstract = false;
			EOperation.SuperClasses.AddLazy(() => ETypedElement);
			EOperation.Properties.AddLazy(() => EOperation_EContainingClass);
			EOperation.Properties.AddLazy(() => EOperation_EType);
			EOperation.Properties.AddLazy(() => EOperation_EParameters);
			EOperation.Properties.AddLazy(() => EOperation_EExceptions);
			EOperation.Properties.AddLazy(() => EOperation_ETypeParameters);
			EOperation.Properties.AddLazy(() => EOperation_EGenericExceptions);
			EOperation_EContainingClass.SetTypeLazy(() => EClass);
			EOperation_EContainingClass.Documentation = null;
			EOperation_EContainingClass.Name = "EContainingClass";
			EOperation_EContainingClass.SymbolProperty = null;
			EOperation_EContainingClass.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EContainingClass.SetClassLazy(() => EOperation);
			EOperation_EContainingClass.DefaultValue = null;
			EOperation_EContainingClass.IsContainment = false;
			EOperation_EContainingClass.OppositeProperties.AddLazy(() => EClass_EOperations);
			EOperation_EType.SetTypeLazy(() => EClassifier);
			EOperation_EType.Documentation = null;
			EOperation_EType.Name = "EType";
			EOperation_EType.SymbolProperty = "ReturnType";
			EOperation_EType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EType.SetClassLazy(() => EOperation);
			EOperation_EType.DefaultValue = null;
			EOperation_EType.IsContainment = false;
			EOperation_EType.RedefinedProperties.AddLazy(() => ETypedElement_EType);
			EOperation_EParameters.SetTypeLazy(() => __tmp104);
			EOperation_EParameters.Documentation = null;
			EOperation_EParameters.Name = "EParameters";
			EOperation_EParameters.SymbolProperty = "Parameters";
			EOperation_EParameters.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EParameters.SetClassLazy(() => EOperation);
			EOperation_EParameters.DefaultValue = null;
			EOperation_EParameters.IsContainment = true;
			EOperation_EParameters.OppositeProperties.AddLazy(() => EParameter_EOperation);
			EOperation_EExceptions.SetTypeLazy(() => __tmp105);
			EOperation_EExceptions.Documentation = null;
			EOperation_EExceptions.Name = "EExceptions";
			EOperation_EExceptions.SymbolProperty = null;
			EOperation_EExceptions.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EExceptions.SetClassLazy(() => EOperation);
			EOperation_EExceptions.DefaultValue = null;
			EOperation_EExceptions.IsContainment = false;
			EOperation_ETypeParameters.SetTypeLazy(() => __tmp106);
			EOperation_ETypeParameters.Documentation = null;
			EOperation_ETypeParameters.Name = "ETypeParameters";
			EOperation_ETypeParameters.SymbolProperty = "TypeParameters";
			EOperation_ETypeParameters.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_ETypeParameters.SetClassLazy(() => EOperation);
			EOperation_ETypeParameters.DefaultValue = null;
			EOperation_ETypeParameters.IsContainment = true;
			EOperation_EGenericExceptions.SetTypeLazy(() => __tmp107);
			EOperation_EGenericExceptions.Documentation = null;
			EOperation_EGenericExceptions.Name = "EGenericExceptions";
			EOperation_EGenericExceptions.SymbolProperty = null;
			EOperation_EGenericExceptions.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EGenericExceptions.SetClassLazy(() => EOperation);
			EOperation_EGenericExceptions.DefaultValue = null;
			EOperation_EGenericExceptions.IsContainment = true;
			EParameter.Documentation = null;
			EParameter.Name = "EParameter";
			EParameter.SetNamespaceLazy(() => __tmp4);
			EParameter.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.ParameterSymbol);
			EParameter.IsAbstract = false;
			EParameter.SuperClasses.AddLazy(() => ETypedElement);
			EParameter.Properties.AddLazy(() => EParameter_EOperation);
			EParameter_EOperation.SetTypeLazy(() => EOperation);
			EParameter_EOperation.Documentation = null;
			EParameter_EOperation.Name = "EOperation";
			EParameter_EOperation.SymbolProperty = null;
			EParameter_EOperation.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EParameter_EOperation.SetClassLazy(() => EParameter);
			EParameter_EOperation.DefaultValue = null;
			EParameter_EOperation.IsContainment = false;
			EParameter_EOperation.OppositeProperties.AddLazy(() => EOperation_EParameters);
			EGenericType.Documentation = null;
			EGenericType.Name = "EGenericType";
			EGenericType.SetNamespaceLazy(() => __tmp4);
			EGenericType.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			EGenericType.IsAbstract = false;
			EGenericType.Properties.AddLazy(() => EGenericType_EClassifier);
			EGenericType.Properties.AddLazy(() => EGenericType_ERawType);
			EGenericType.Properties.AddLazy(() => EGenericType_ETypeParameter);
			EGenericType.Properties.AddLazy(() => EGenericType_ELowerBound);
			EGenericType.Properties.AddLazy(() => EGenericType_EUpperBound);
			EGenericType.Properties.AddLazy(() => EGenericType_ETypeArguments);
			EGenericType_EClassifier.SetTypeLazy(() => EClassifier);
			EGenericType_EClassifier.Documentation = null;
			EGenericType_EClassifier.Name = "EClassifier";
			EGenericType_EClassifier.SymbolProperty = null;
			EGenericType_EClassifier.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_EClassifier.SetClassLazy(() => EGenericType);
			EGenericType_EClassifier.DefaultValue = null;
			EGenericType_EClassifier.IsContainment = false;
			EGenericType_ERawType.SetTypeLazy(() => EClassifier);
			EGenericType_ERawType.Documentation = null;
			EGenericType_ERawType.Name = "ERawType";
			EGenericType_ERawType.SymbolProperty = null;
			EGenericType_ERawType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_ERawType.SetClassLazy(() => EGenericType);
			EGenericType_ERawType.DefaultValue = null;
			EGenericType_ERawType.IsContainment = false;
			EGenericType_ETypeParameter.SetTypeLazy(() => ETypeParameter);
			EGenericType_ETypeParameter.Documentation = null;
			EGenericType_ETypeParameter.Name = "ETypeParameter";
			EGenericType_ETypeParameter.SymbolProperty = null;
			EGenericType_ETypeParameter.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_ETypeParameter.SetClassLazy(() => EGenericType);
			EGenericType_ETypeParameter.DefaultValue = null;
			EGenericType_ETypeParameter.IsContainment = false;
			EGenericType_ETypeParameter.OppositeProperties.AddLazy(() => ETypeParameter_EGenericTypes);
			EGenericType_ELowerBound.SetTypeLazy(() => EGenericType);
			EGenericType_ELowerBound.Documentation = null;
			EGenericType_ELowerBound.Name = "ELowerBound";
			EGenericType_ELowerBound.SymbolProperty = null;
			EGenericType_ELowerBound.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_ELowerBound.SetClassLazy(() => EGenericType);
			EGenericType_ELowerBound.DefaultValue = null;
			EGenericType_ELowerBound.IsContainment = true;
			EGenericType_EUpperBound.SetTypeLazy(() => EGenericType);
			EGenericType_EUpperBound.Documentation = null;
			EGenericType_EUpperBound.Name = "EUpperBound";
			EGenericType_EUpperBound.SymbolProperty = null;
			EGenericType_EUpperBound.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_EUpperBound.SetClassLazy(() => EGenericType);
			EGenericType_EUpperBound.DefaultValue = null;
			EGenericType_EUpperBound.IsContainment = true;
			EGenericType_ETypeArguments.SetTypeLazy(() => __tmp108);
			EGenericType_ETypeArguments.Documentation = null;
			EGenericType_ETypeArguments.Name = "ETypeArguments";
			EGenericType_ETypeArguments.SymbolProperty = "TypeArguments";
			EGenericType_ETypeArguments.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_ETypeArguments.SetClassLazy(() => EGenericType);
			EGenericType_ETypeArguments.DefaultValue = null;
			EGenericType_ETypeArguments.IsContainment = true;
			ETypeParameter.Documentation = null;
			ETypeParameter.Name = "ETypeParameter";
			ETypeParameter.SetNamespaceLazy(() => __tmp4);
			ETypeParameter.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol);
			ETypeParameter.IsAbstract = false;
			ETypeParameter.SuperClasses.AddLazy(() => ENamedElement);
			ETypeParameter.Properties.AddLazy(() => ETypeParameter_EGenericTypes);
			ETypeParameter.Properties.AddLazy(() => ETypeParameter_EBounds);
			ETypeParameter_EGenericTypes.SetTypeLazy(() => __tmp109);
			ETypeParameter_EGenericTypes.Documentation = null;
			ETypeParameter_EGenericTypes.Name = "EGenericTypes";
			ETypeParameter_EGenericTypes.SymbolProperty = null;
			ETypeParameter_EGenericTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypeParameter_EGenericTypes.SetClassLazy(() => ETypeParameter);
			ETypeParameter_EGenericTypes.DefaultValue = null;
			ETypeParameter_EGenericTypes.IsContainment = false;
			ETypeParameter_EGenericTypes.OppositeProperties.AddLazy(() => EGenericType_ETypeParameter);
			ETypeParameter_EBounds.SetTypeLazy(() => __tmp110);
			ETypeParameter_EBounds.Documentation = null;
			ETypeParameter_EBounds.Name = "EBounds";
			ETypeParameter_EBounds.SymbolProperty = null;
			ETypeParameter_EBounds.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypeParameter_EBounds.SetClassLazy(() => ETypeParameter);
			ETypeParameter_EBounds.DefaultValue = null;
			ETypeParameter_EBounds.IsContainment = true;
			__tmp57.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp57.SetInnerTypeLazy(() => EAnnotation);
			__tmp67.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp67.SetInnerTypeLazy(() => EStringToStringMapEntry);
			__tmp68.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp68.SetInnerTypeLazy(() => EObject);
			__tmp69.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp69.SetInnerTypeLazy(() => EObject);
			__tmp71.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp71.SetInnerTypeLazy(() => EPackage);
			__tmp72.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp72.SetInnerTypeLazy(() => EClassifier);
			__tmp76.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp76.SetInnerTypeLazy(() => ETypeParameter);
			__tmp81.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp81.SetInnerTypeLazy(() => EClass);
			__tmp82.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp82.SetInnerTypeLazy(() => EClass);
			__tmp83.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp83.SetInnerTypeLazy(() => EStructuralFeature);
			__tmp84.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp84.SetInnerTypeLazy(() => EStructuralFeature);
			__tmp85.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp85.SetInnerTypeLazy(() => EOperation);
			__tmp86.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp86.SetInnerTypeLazy(() => EOperation);
			__tmp87.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp87.SetInnerTypeLazy(() => EReference);
			__tmp88.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp88.SetInnerTypeLazy(() => EReference);
			__tmp89.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp89.SetInnerTypeLazy(() => EReference);
			__tmp90.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp90.SetInnerTypeLazy(() => EAttribute);
			__tmp91.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp91.SetInnerTypeLazy(() => EAttribute);
			__tmp92.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp92.SetInnerTypeLazy(() => EGenericType);
			__tmp93.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp93.SetInnerTypeLazy(() => EGenericType);
			__tmp99.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp99.SetInnerTypeLazy(() => EEnumLiteral);
			__tmp104.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp104.SetInnerTypeLazy(() => EParameter);
			__tmp105.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp105.SetInnerTypeLazy(() => EClassifier);
			__tmp106.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp106.SetInnerTypeLazy(() => ETypeParameter);
			__tmp107.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp107.SetInnerTypeLazy(() => EGenericType);
			__tmp108.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp108.SetInnerTypeLazy(() => EGenericType);
			__tmp109.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp109.SetInnerTypeLazy(() => EGenericType);
			__tmp110.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp110.SetInnerTypeLazy(() => EGenericType);
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.Languages.Ecore.Model.EcoreImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class EcoreImplementationBase
	{
		/// <summary>
		/// Implements the constructor: EcoreBuilderInstance()
		/// </summary>
		internal virtual void EcoreBuilderInstance(EcoreBuilderInstance _this)
		{
		}
	
		/// <summary>
		/// Implements the constructor: EObject()
		/// </summary>
		public virtual void EObject(EObjectBuilder _this)
		{
			this.CallEObjectSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EObject
		/// </summary>
		protected virtual void CallEObjectSuperConstructors(EObjectBuilder _this)
		{
		}
	
	
	
		/// <summary>
		/// Implements the operation: EObject.EClass()
		/// </summary>
		public virtual EClass EObject_EClass(EObject _this)
		{
			return this.EObject_EClass(_this.ToMutable()).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EClass()
		/// </summary>
		public abstract EClassBuilder EObject_EClass(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.EIsProxy()
		/// </summary>
		public virtual bool EObject_EIsProxy(EObject _this)
		{
			return this.EObject_EIsProxy(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EIsProxy()
		/// </summary>
		public abstract bool EObject_EIsProxy(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.EResource()
		/// </summary>
		public virtual MetaDslx.Modeling.IModel EObject_EResource(EObject _this)
		{
			return this.EObject_EResource(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EResource()
		/// </summary>
		public abstract MetaDslx.Modeling.IModel EObject_EResource(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.EContainer()
		/// </summary>
		public virtual EObject EObject_EContainer(EObject _this)
		{
			return this.EObject_EContainer(_this.ToMutable()).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EContainer()
		/// </summary>
		public abstract EObjectBuilder EObject_EContainer(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.EContainingFeature()
		/// </summary>
		public virtual EStructuralFeature EObject_EContainingFeature(EObject _this)
		{
			return this.EObject_EContainingFeature(_this.ToMutable()).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EContainingFeature()
		/// </summary>
		public abstract EStructuralFeatureBuilder EObject_EContainingFeature(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.EContainmentFeature()
		/// </summary>
		public virtual EReference EObject_EContainmentFeature(EObject _this)
		{
			return this.EObject_EContainmentFeature(_this.ToMutable()).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EContainmentFeature()
		/// </summary>
		public abstract EReferenceBuilder EObject_EContainmentFeature(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.EContents()
		/// </summary>
		public virtual System.Collections.Generic.IReadOnlyList<object> EObject_EContents(EObject _this)
		{
			return this.EObject_EContents(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EContents()
		/// </summary>
		public abstract System.Collections.Generic.IReadOnlyList<object> EObject_EContents(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.EAllContents()
		/// </summary>
		public virtual System.Collections.IEnumerator EObject_EAllContents(EObject _this)
		{
			return this.EObject_EAllContents(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EAllContents()
		/// </summary>
		public abstract System.Collections.IEnumerator EObject_EAllContents(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.ECrossReferences()
		/// </summary>
		public virtual System.Collections.Generic.IReadOnlyList<object> EObject_ECrossReferences(EObject _this)
		{
			return this.EObject_ECrossReferences(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.ECrossReferences()
		/// </summary>
		public abstract System.Collections.Generic.IReadOnlyList<object> EObject_ECrossReferences(EObjectBuilder _this);
	
		/// <summary>
		/// Implements the operation: EObject.EGet()
		/// </summary>
		public virtual object EObject_EGet(EObject _this, EStructuralFeature feature)
		{
			return this.EObject_EGet(_this.ToMutable(), feature.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EGet()
		/// </summary>
		public abstract object EObject_EGet(EObjectBuilder _this, EStructuralFeatureBuilder feature);
	
		/// <summary>
		/// Implements the operation: EObject.EGet()
		/// </summary>
		public virtual object EObject_EGet(EObject _this, EStructuralFeature feature, bool resolve)
		{
			return this.EObject_EGet(_this.ToMutable(), feature.ToMutable(), resolve);
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EGet()
		/// </summary>
		public abstract object EObject_EGet(EObjectBuilder _this, EStructuralFeatureBuilder feature, bool resolve);
	
		/// <summary>
		/// Implements the operation: EObject.ESet()
		/// </summary>
		public virtual object EObject_ESet(EObject _this, EStructuralFeature feature, object newValue)
		{
			return this.EObject_ESet(_this.ToMutable(), feature.ToMutable(), newValue);
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.ESet()
		/// </summary>
		public abstract object EObject_ESet(EObjectBuilder _this, EStructuralFeatureBuilder feature, object newValue);
	
		/// <summary>
		/// Implements the operation: EObject.EIsSet()
		/// </summary>
		public virtual bool EObject_EIsSet(EObject _this, EStructuralFeature feature)
		{
			return this.EObject_EIsSet(_this.ToMutable(), feature.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EIsSet()
		/// </summary>
		public abstract bool EObject_EIsSet(EObjectBuilder _this, EStructuralFeatureBuilder feature);
	
		/// <summary>
		/// Implements the operation: EObject.EUnset()
		/// </summary>
		public virtual void EObject_EUnset(EObject _this, EStructuralFeature feature)
		{
	this.EObject_EUnset(_this.ToMutable(), feature.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EObjectBuilder.EUnset()
		/// </summary>
		public abstract void EObject_EUnset(EObjectBuilder _this, EStructuralFeatureBuilder feature);
	
	
		/// <summary>
		/// Implements the constructor: EModelElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EObject</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		/// </ul>
		public virtual void EModelElement(EModelElementBuilder _this)
		{
			this.CallEModelElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EModelElement
		/// </summary>
		protected virtual void CallEModelElementSuperConstructors(EModelElementBuilder _this)
		{
			this.EObject(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: EModelElement.GetEAnnotation()
		/// </summary>
		public virtual EAnnotation EModelElement_GetEAnnotation(EModelElement _this, String source)
		{
			return this.EModelElement_GetEAnnotation(_this.ToMutable(), source).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EModelElementBuilder.GetEAnnotation()
		/// </summary>
		public abstract EAnnotationBuilder EModelElement_GetEAnnotation(EModelElementBuilder _this, String source);
	
	
		/// <summary>
		/// Implements the constructor: EFactory()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EModelElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		/// </ul>
		public virtual void EFactory(EFactoryBuilder _this)
		{
			this.CallEFactorySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EFactory
		/// </summary>
		protected virtual void CallEFactorySuperConstructors(EFactoryBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: EFactory.Create()
		/// </summary>
		public virtual EObject EFactory_Create(EFactory _this, EClass eClass)
		{
			return this.EFactory_Create(_this.ToMutable(), eClass.ToMutable()).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EFactoryBuilder.Create()
		/// </summary>
		public abstract EObjectBuilder EFactory_Create(EFactoryBuilder _this, EClassBuilder eClass);
	
		/// <summary>
		/// Implements the operation: EFactory.CreateFromString()
		/// </summary>
		public virtual EObject EFactory_CreateFromString(EFactory _this, EDataType eDataType, String literalValue)
		{
			return this.EFactory_CreateFromString(_this.ToMutable(), eDataType.ToMutable(), literalValue).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EFactoryBuilder.CreateFromString()
		/// </summary>
		public abstract EObjectBuilder EFactory_CreateFromString(EFactoryBuilder _this, EDataTypeBuilder eDataType, String literalValue);
	
		/// <summary>
		/// Implements the operation: EFactory.ConvertToString()
		/// </summary>
		public virtual String EFactory_ConvertToString(EFactory _this, EDataType eDataType, object instanceValue)
		{
			return this.EFactory_ConvertToString(_this.ToMutable(), eDataType.ToMutable(), instanceValue);
		}
	
		/// <summary>
		/// Implements the operation: EFactoryBuilder.ConvertToString()
		/// </summary>
		public abstract String EFactory_ConvertToString(EFactoryBuilder _this, EDataTypeBuilder eDataType, object instanceValue);
	
	
		/// <summary>
		/// Implements the constructor: ENamedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EModelElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		/// </ul>
		public virtual void ENamedElement(ENamedElementBuilder _this)
		{
			this.CallENamedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ENamedElement
		/// </summary>
		protected virtual void CallENamedElementSuperConstructors(ENamedElementBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: EAnnotation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EModelElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		/// </ul>
		public virtual void EAnnotation(EAnnotationBuilder _this)
		{
			this.CallEAnnotationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EAnnotation
		/// </summary>
		protected virtual void CallEAnnotationSuperConstructors(EAnnotationBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: EStringToStringMapEntry()
		/// </summary>
		public virtual void EStringToStringMapEntry(EStringToStringMapEntryBuilder _this)
		{
			this.CallEStringToStringMapEntrySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EStringToStringMapEntry
		/// </summary>
		protected virtual void CallEStringToStringMapEntrySuperConstructors(EStringToStringMapEntryBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: EPackage()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		/// </ul>
		public virtual void EPackage(EPackageBuilder _this)
		{
			this.CallEPackageSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EPackage
		/// </summary>
		protected virtual void CallEPackageSuperConstructors(EPackageBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: EPackage.GetEClassifier()
		/// </summary>
		public virtual EClassifier EPackage_GetEClassifier(EPackage _this, String name)
		{
			return this.EPackage_GetEClassifier(_this.ToMutable(), name).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EPackageBuilder.GetEClassifier()
		/// </summary>
		public abstract EClassifierBuilder EPackage_GetEClassifier(EPackageBuilder _this, String name);
	
	
		/// <summary>
		/// Implements the constructor: EClassifier()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		/// </ul>
		public virtual void EClassifier(EClassifierBuilder _this)
		{
			this.CallEClassifierSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EClassifier
		/// </summary>
		protected virtual void CallEClassifierSuperConstructors(EClassifierBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: EClassifier.IsInstance()
		/// </summary>
		public virtual bool EClassifier_IsInstance(EClassifier _this, object @object)
		{
			return this.EClassifier_IsInstance(_this.ToMutable(), @object);
		}
	
		/// <summary>
		/// Implements the operation: EClassifierBuilder.IsInstance()
		/// </summary>
		public abstract bool EClassifier_IsInstance(EClassifierBuilder _this, object @object);
	
		/// <summary>
		/// Implements the operation: EClassifier.GetClassifierID()
		/// </summary>
		public virtual int EClassifier_GetClassifierID(EClassifier _this)
		{
			return this.EClassifier_GetClassifierID(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EClassifierBuilder.GetClassifierID()
		/// </summary>
		public abstract int EClassifier_GetClassifierID(EClassifierBuilder _this);
	
	
		/// <summary>
		/// Implements the constructor: EClass()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EClassifier</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>EClassifier</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>EAllSuperTypes</li>
		///     <li>EAllStructuralFeatures</li>
		///     <li>EAllOperation</li>
		///     <li>EReferences</li>
		///     <li>EAllReferences</li>
		///     <li>EAllContainments</li>
		///     <li>EAttributes</li>
		///     <li>EAllAttributes</li>
		///     <li>EIDAttribute</li>
		///     <li>EAllGenericSuperTypes</li>
		/// </ul>
		public virtual void EClass(EClassBuilder _this)
		{
			this.CallEClassSuperConstructors(_this);
			_this.EAllGenericSuperTypes.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllGenericSuperTypes);
			_this.SetEIDAttributeLazy(this.EClass_ComputeProperty_EIDAttribute);
			_this.EAllAttributes.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllAttributes);
			_this.EAttributes.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAttributes);
			_this.EAllContainments.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllContainments);
			_this.EAllReferences.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllReferences);
			_this.EReferences.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EReferences);
			_this.EAllOperation.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllOperation);
			_this.EAllStructuralFeatures.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllStructuralFeatures);
			_this.EAllSuperTypes.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllSuperTypes);
		}
	
		/// <summary>
		/// Calls the super constructors of EClass
		/// </summary>
		protected virtual void CallEClassSuperConstructors(EClassBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.EClassifier(_this);
		}
	
		/// <summary>
		/// Computes the value of the property: EClass.EAllSuperTypes
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EClassBuilder> EClass_ComputeProperty_EAllSuperTypes(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllStructuralFeatures
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EStructuralFeatureBuilder> EClass_ComputeProperty_EAllStructuralFeatures(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllOperation
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EOperationBuilder> EClass_ComputeProperty_EAllOperation(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EReferences
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EReferences(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllReferences
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EAllReferences(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllContainments
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EAllContainments(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAttributes
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EAttributeBuilder> EClass_ComputeProperty_EAttributes(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllAttributes
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EAttributeBuilder> EClass_ComputeProperty_EAllAttributes(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EIDAttribute
		/// </summary	
		public abstract EAttributeBuilder EClass_ComputeProperty_EIDAttribute(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllGenericSuperTypes
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EGenericTypeBuilder> EClass_ComputeProperty_EAllGenericSuperTypes(EClassBuilder _this);
	
	
		/// <summary>
		/// Implements the operation: EClass.IsSuperTypeOf()
		/// </summary>
		public virtual bool EClass_IsSuperTypeOf(EClass _this, EClass someClass)
		{
			return this.EClass_IsSuperTypeOf(_this.ToMutable(), someClass.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EClassBuilder.IsSuperTypeOf()
		/// </summary>
		public abstract bool EClass_IsSuperTypeOf(EClassBuilder _this, EClassBuilder someClass);
	
		/// <summary>
		/// Implements the operation: EClass.GetStructuralFeature()
		/// </summary>
		public virtual EStructuralFeature EClass_GetStructuralFeature(EClass _this, int featureID)
		{
			return this.EClass_GetStructuralFeature(_this.ToMutable(), featureID).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EClassBuilder.GetStructuralFeature()
		/// </summary>
		public abstract EStructuralFeatureBuilder EClass_GetStructuralFeature(EClassBuilder _this, int featureID);
	
		/// <summary>
		/// Implements the operation: EClass.GetStructuralFeature()
		/// </summary>
		public virtual EStructuralFeature EClass_GetStructuralFeature(EClass _this, String featureName)
		{
			return this.EClass_GetStructuralFeature(_this.ToMutable(), featureName).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EClassBuilder.GetStructuralFeature()
		/// </summary>
		public abstract EStructuralFeatureBuilder EClass_GetStructuralFeature(EClassBuilder _this, String featureName);
	
	
		/// <summary>
		/// Implements the constructor: EDataType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EClassifier</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>EClassifier</li>
		/// </ul>
		public virtual void EDataType(EDataTypeBuilder _this)
		{
			this.CallEDataTypeSuperConstructors(_this);
			_this.SetSerializableLazy(() => true);
		}
	
		/// <summary>
		/// Calls the super constructors of EDataType
		/// </summary>
		protected virtual void CallEDataTypeSuperConstructors(EDataTypeBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.EClassifier(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: EEnum()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EDataType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>EClassifier</li>
		///     <li>EDataType</li>
		/// </ul>
		public virtual void EEnum(EEnumBuilder _this)
		{
			this.CallEEnumSuperConstructors(_this);
			_this.SetSerializableLazy(() => true);
		}
	
		/// <summary>
		/// Calls the super constructors of EEnum
		/// </summary>
		protected virtual void CallEEnumSuperConstructors(EEnumBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.EClassifier(_this);
			this.EDataType(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: EEnum.GetEEnumLiteral()
		/// </summary>
		public virtual EEnumLiteral EEnum_GetEEnumLiteral(EEnum _this, String name)
		{
			return this.EEnum_GetEEnumLiteral(_this.ToMutable(), name).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EEnumBuilder.GetEEnumLiteral()
		/// </summary>
		public abstract EEnumLiteralBuilder EEnum_GetEEnumLiteral(EEnumBuilder _this, String name);
	
		/// <summary>
		/// Implements the operation: EEnum.GetEEnumLiteral()
		/// </summary>
		public virtual EEnumLiteral EEnum_GetEEnumLiteral(EEnum _this, int value)
		{
			return this.EEnum_GetEEnumLiteral(_this.ToMutable(), value).ToImmutable();
		}
	
		/// <summary>
		/// Implements the operation: EEnumBuilder.GetEEnumLiteral()
		/// </summary>
		public abstract EEnumLiteralBuilder EEnum_GetEEnumLiteral(EEnumBuilder _this, int value);
	
	
		/// <summary>
		/// Implements the constructor: EEnumLiteral()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		/// </ul>
		public virtual void EEnumLiteral(EEnumLiteralBuilder _this)
		{
			this.CallEEnumLiteralSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EEnumLiteral
		/// </summary>
		protected virtual void CallEEnumLiteralSuperConstructors(EEnumLiteralBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ETypedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>Many</li>
		///     <li>Required</li>
		/// </ul>
		public virtual void ETypedElement(ETypedElementBuilder _this)
		{
			this.CallETypedElementSuperConstructors(_this);
			_this.SetRequiredLazy(this.ETypedElement_ComputeProperty_Required);
			_this.SetManyLazy(this.ETypedElement_ComputeProperty_Many);
			_this.SetUpperBoundLazy(() => 1);
			_this.SetUniqueLazy(() => true);
			_this.SetOrderedLazy(() => true);
		}
	
		/// <summary>
		/// Calls the super constructors of ETypedElement
		/// </summary>
		protected virtual void CallETypedElementSuperConstructors(ETypedElementBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
		}
	
		/// <summary>
		/// Computes the value of the property: ETypedElement.Many
		/// </summary	
		public abstract bool ETypedElement_ComputeProperty_Many(ETypedElementBuilder _this);
		/// <summary>
		/// Computes the value of the property: ETypedElement.Required
		/// </summary	
		public abstract bool ETypedElement_ComputeProperty_Required(ETypedElementBuilder _this);
	
	
	
		/// <summary>
		/// Implements the constructor: EStructuralFeature()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ETypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>ETypedElement</li>
		/// </ul>
		public virtual void EStructuralFeature(EStructuralFeatureBuilder _this)
		{
			this.CallEStructuralFeatureSuperConstructors(_this);
			_this.SetChangeableLazy(() => true);
			_this.SetRequiredLazy(this.ETypedElement_ComputeProperty_Required);
			_this.SetManyLazy(this.ETypedElement_ComputeProperty_Many);
			_this.SetUpperBoundLazy(() => 1);
			_this.SetUniqueLazy(() => true);
			_this.SetOrderedLazy(() => true);
		}
	
		/// <summary>
		/// Calls the super constructors of EStructuralFeature
		/// </summary>
		protected virtual void CallEStructuralFeatureSuperConstructors(EStructuralFeatureBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.ETypedElement(_this);
		}
	
	
	
		/// <summary>
		/// Implements the operation: EStructuralFeature.GetFeatureID()
		/// </summary>
		public virtual int EStructuralFeature_GetFeatureID(EStructuralFeature _this)
		{
			return this.EStructuralFeature_GetFeatureID(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EStructuralFeatureBuilder.GetFeatureID()
		/// </summary>
		public abstract int EStructuralFeature_GetFeatureID(EStructuralFeatureBuilder _this);
	
		/// <summary>
		/// Implements the operation: EStructuralFeature.GetContainerClass()
		/// </summary>
		public virtual System.Type EStructuralFeature_GetContainerClass(EStructuralFeature _this)
		{
			return this.EStructuralFeature_GetContainerClass(_this.ToMutable());
		}
	
		/// <summary>
		/// Implements the operation: EStructuralFeatureBuilder.GetContainerClass()
		/// </summary>
		public abstract System.Type EStructuralFeature_GetContainerClass(EStructuralFeatureBuilder _this);
	
	
		/// <summary>
		/// Implements the constructor: EAttribute()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EStructuralFeature</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>ETypedElement</li>
		///     <li>EStructuralFeature</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>EAttributeType</li>
		/// </ul>
		public virtual void EAttribute(EAttributeBuilder _this)
		{
			this.CallEAttributeSuperConstructors(_this);
			_this.SetEAttributeTypeLazy(this.EAttribute_ComputeProperty_EAttributeType);
			_this.SetChangeableLazy(() => true);
			_this.SetRequiredLazy(this.ETypedElement_ComputeProperty_Required);
			_this.SetManyLazy(this.ETypedElement_ComputeProperty_Many);
			_this.SetUpperBoundLazy(() => 1);
			_this.SetUniqueLazy(() => true);
			_this.SetOrderedLazy(() => true);
		}
	
		/// <summary>
		/// Calls the super constructors of EAttribute
		/// </summary>
		protected virtual void CallEAttributeSuperConstructors(EAttributeBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.ETypedElement(_this);
			this.EStructuralFeature(_this);
		}
	
		/// <summary>
		/// Computes the value of the property: EAttribute.EAttributeType
		/// </summary	
		public abstract EDataTypeBuilder EAttribute_ComputeProperty_EAttributeType(EAttributeBuilder _this);
	
	
	
		/// <summary>
		/// Implements the constructor: EReference()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EStructuralFeature</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>ETypedElement</li>
		///     <li>EStructuralFeature</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>Container</li>
		/// </ul>
		public virtual void EReference(EReferenceBuilder _this)
		{
			this.CallEReferenceSuperConstructors(_this);
			_this.SetResolveProxiesLazy(() => true);
			_this.SetContainerLazy(this.EReference_ComputeProperty_Container);
			_this.SetChangeableLazy(() => true);
			_this.SetRequiredLazy(this.ETypedElement_ComputeProperty_Required);
			_this.SetManyLazy(this.ETypedElement_ComputeProperty_Many);
			_this.SetUpperBoundLazy(() => 1);
			_this.SetUniqueLazy(() => true);
			_this.SetOrderedLazy(() => true);
		}
	
		/// <summary>
		/// Calls the super constructors of EReference
		/// </summary>
		protected virtual void CallEReferenceSuperConstructors(EReferenceBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.ETypedElement(_this);
			this.EStructuralFeature(_this);
		}
	
		/// <summary>
		/// Computes the value of the property: EReference.Container
		/// </summary	
		public abstract bool EReference_ComputeProperty_Container(EReferenceBuilder _this);
	
	
	
		/// <summary>
		/// Implements the constructor: EOperation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ETypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>ETypedElement</li>
		/// </ul>
		public virtual void EOperation(EOperationBuilder _this)
		{
			this.CallEOperationSuperConstructors(_this);
			_this.SetRequiredLazy(this.ETypedElement_ComputeProperty_Required);
			_this.SetManyLazy(this.ETypedElement_ComputeProperty_Many);
			_this.SetUpperBoundLazy(() => 1);
			_this.SetUniqueLazy(() => true);
			_this.SetOrderedLazy(() => true);
		}
	
		/// <summary>
		/// Calls the super constructors of EOperation
		/// </summary>
		protected virtual void CallEOperationSuperConstructors(EOperationBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.ETypedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: EParameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ETypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>ETypedElement</li>
		/// </ul>
		public virtual void EParameter(EParameterBuilder _this)
		{
			this.CallEParameterSuperConstructors(_this);
			_this.SetRequiredLazy(this.ETypedElement_ComputeProperty_Required);
			_this.SetManyLazy(this.ETypedElement_ComputeProperty_Many);
			_this.SetUpperBoundLazy(() => 1);
			_this.SetUniqueLazy(() => true);
			_this.SetOrderedLazy(() => true);
		}
	
		/// <summary>
		/// Calls the super constructors of EParameter
		/// </summary>
		protected virtual void CallEParameterSuperConstructors(EParameterBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.ETypedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: EGenericType()
		/// </summary>
		public virtual void EGenericType(EGenericTypeBuilder _this)
		{
			this.CallEGenericTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EGenericType
		/// </summary>
		protected virtual void CallEGenericTypeSuperConstructors(EGenericTypeBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ETypeParameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EObject</li>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		/// </ul>
		public virtual void ETypeParameter(ETypeParameterBuilder _this)
		{
			this.CallETypeParameterSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ETypeParameter
		/// </summary>
		protected virtual void CallETypeParameterSuperConstructors(ETypeParameterBuilder _this)
		{
			this.EObject(_this);
			this.EModelElement(_this);
			this.ENamedElement(_this);
		}
	
	
	
	}

	internal class EcoreImplementationProvider
	{
		// If there is a compile error at this line, create a new class called EcoreImplementation
		// which is a subclass of global::MetaDslx.Languages.Ecore.Model.EcoreImplementationBase:
		private static EcoreImplementation implementation = new EcoreImplementation();
	
		public static EcoreImplementation Implementation
		{
			get { return implementation; }
		}
	}
}


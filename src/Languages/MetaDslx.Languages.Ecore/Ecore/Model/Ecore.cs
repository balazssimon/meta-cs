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

	public class EcoreMetadata : global::MetaDslx.Modeling.ModelMetadata
	{
		public EcoreMetadata(string name, global::MetaDslx.Modeling.ModelVersion version, string uri, string prefix, string namespaceName)
			: base(name, version, uri, prefix, namespaceName)
		{
		}

		protected override global::MetaDslx.Modeling.ModelMetadata Create(string name, global::MetaDslx.Modeling.ModelVersion version, string uri, string prefix, string namespaceName)
		{
			return new EcoreMetadata(name, version, uri, prefix, namespaceName);
		}

		public override global::MetaDslx.Modeling.IModelFactory CreateFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
		{
			return new EcoreFactory(model, flags);
		}
	}

	public class EcoreInstance
	{
		private static bool initialized;

		public static bool IsInitialized
		{
			get { return EcoreInstance.initialized; }
		}

		public static readonly global::MetaDslx.Languages.Ecore.Model.EcoreMetadata MMetadata;
		public static readonly global::MetaDslx.Modeling.ImmutableModel MModel;

		public static readonly EDataType EBigDecimal;
		public static readonly EDataType EBigInteger;
		public static readonly EDataType EBoolean;
		public static readonly EDataType EBooleanObject;
		public static readonly EDataType EByte;
		public static readonly EDataType EByteArray;
		public static readonly EDataType EByteObject;
		public static readonly EDataType EChar;
		public static readonly EDataType ECharacterObject;
		public static readonly EDataType EDate;
		public static readonly EDataType EDiagnosticChain;
		public static readonly EDataType EDouble;
		public static readonly EDataType EDoubleObject;
		public static readonly EDataType EEList;
		public static readonly EDataType EEnumerator;
		public static readonly EDataType EFeatureMap;
		public static readonly EDataType EFeatureMapEntry;
		public static readonly EDataType EFloat;
		public static readonly EDataType EFloatObject;
		public static readonly EDataType EInt;
		public static readonly EDataType EIntegerObject;
		public static readonly EDataType EJavaClass;
		public static readonly EDataType EJavaObject;
		public static readonly EDataType ELong;
		public static readonly EDataType ELongObject;
		public static readonly EDataType EMap;
		public static readonly EDataType EResource;
		public static readonly EDataType EResourceSet;
		public static readonly EDataType EShort;
		public static readonly EDataType EShortObject;
		public static readonly EDataType EString;
		public static readonly EDataType ETreeIterator;
		public static readonly EDataType EInvocationTargetException;

		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EAttribute;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAttribute_ID;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAttribute_EAttributeType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EAnnotation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_Source;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_Details;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_EModelElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_Contents;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EAnnotation_References;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_Abstract;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_Interface;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_ESuperTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EOperations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllAttributes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllReferences;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EReferences;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAttributes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllContainments;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllOperations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllStructuralFeatures;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllSuperTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EIDAttribute;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EStructuralFeatures;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EGenericSuperTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClass_EAllGenericSuperTypes;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EClassifier;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_DotNetName;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_InstanceClassName;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_InstanceClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_DefaultValue;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_InstanceTypeName;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_EPackage;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EClassifier_ETypeParameters;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EDataType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EDataType_Serializable;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EEnum;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnum_ELiterals;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EEnumLiteral;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnumLiteral_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnumLiteral_Instance;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnumLiteral_Literal;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EEnumLiteral_EEnum;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EFactory;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EFactory_EPackage;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EModelElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EModelElement_EAnnotations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ENamedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ENamedElement_Name;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EObject;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EOperation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EContainingClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_ETypeParameters;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EParameters;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EExceptions;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EOperation_EGenericExceptions;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EPackage;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_NsURI;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_NsPrefix;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_EFactoryInstance;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_EClassifiers;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_ESubpackages;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EPackage_ESuperPackage;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EParameter;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EParameter_EOperation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EReference;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_Containment;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_Container;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_ResolveProxies;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_EOpposite;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_EReferenceType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EReference_EKeys;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EStructuralFeature;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Changeable;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Volatile;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Transient;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_DefaultValueLiteral;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_DefaultValue;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Unsettable;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_Derived;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStructuralFeature_EContainingClass;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ETypedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_Ordered;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_Unique;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_LowerBound;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_UpperBound;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_Many;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_Required;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_EType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypedElement_EGenericType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EStringToStringMapEntry;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStringToStringMapEntry_Key;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EStringToStringMapEntry_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EGenericType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_EUpperBound;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_ETypeArguments;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_ERawType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_ELowerBound;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_ETypeParameter;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty EGenericType_EClassifier;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ETypeParameter;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ETypeParameter_EBounds;

		static EcoreInstance()
		{
			EcoreBuilderInstance.instance.Create();
			EcoreBuilderInstance.instance.EvaluateLazyValues();
			MMetadata = EcoreBuilderInstance.instance.MMetadata;
			MModel = EcoreBuilderInstance.instance.MModel.ToImmutable();

			EBigDecimal = EcoreBuilderInstance.instance.EBigDecimal.ToImmutable(MModel);
			EBigInteger = EcoreBuilderInstance.instance.EBigInteger.ToImmutable(MModel);
			EBoolean = EcoreBuilderInstance.instance.EBoolean.ToImmutable(MModel);
			EBooleanObject = EcoreBuilderInstance.instance.EBooleanObject.ToImmutable(MModel);
			EByte = EcoreBuilderInstance.instance.EByte.ToImmutable(MModel);
			EByteArray = EcoreBuilderInstance.instance.EByteArray.ToImmutable(MModel);
			EByteObject = EcoreBuilderInstance.instance.EByteObject.ToImmutable(MModel);
			EChar = EcoreBuilderInstance.instance.EChar.ToImmutable(MModel);
			ECharacterObject = EcoreBuilderInstance.instance.ECharacterObject.ToImmutable(MModel);
			EDate = EcoreBuilderInstance.instance.EDate.ToImmutable(MModel);
			EDiagnosticChain = EcoreBuilderInstance.instance.EDiagnosticChain.ToImmutable(MModel);
			EDouble = EcoreBuilderInstance.instance.EDouble.ToImmutable(MModel);
			EDoubleObject = EcoreBuilderInstance.instance.EDoubleObject.ToImmutable(MModel);
			EEList = EcoreBuilderInstance.instance.EEList.ToImmutable(MModel);
			EEnumerator = EcoreBuilderInstance.instance.EEnumerator.ToImmutable(MModel);
			EFeatureMap = EcoreBuilderInstance.instance.EFeatureMap.ToImmutable(MModel);
			EFeatureMapEntry = EcoreBuilderInstance.instance.EFeatureMapEntry.ToImmutable(MModel);
			EFloat = EcoreBuilderInstance.instance.EFloat.ToImmutable(MModel);
			EFloatObject = EcoreBuilderInstance.instance.EFloatObject.ToImmutable(MModel);
			EInt = EcoreBuilderInstance.instance.EInt.ToImmutable(MModel);
			EIntegerObject = EcoreBuilderInstance.instance.EIntegerObject.ToImmutable(MModel);
			EJavaClass = EcoreBuilderInstance.instance.EJavaClass.ToImmutable(MModel);
			EJavaObject = EcoreBuilderInstance.instance.EJavaObject.ToImmutable(MModel);
			ELong = EcoreBuilderInstance.instance.ELong.ToImmutable(MModel);
			ELongObject = EcoreBuilderInstance.instance.ELongObject.ToImmutable(MModel);
			EMap = EcoreBuilderInstance.instance.EMap.ToImmutable(MModel);
			EResource = EcoreBuilderInstance.instance.EResource.ToImmutable(MModel);
			EResourceSet = EcoreBuilderInstance.instance.EResourceSet.ToImmutable(MModel);
			EShort = EcoreBuilderInstance.instance.EShort.ToImmutable(MModel);
			EShortObject = EcoreBuilderInstance.instance.EShortObject.ToImmutable(MModel);
			EString = EcoreBuilderInstance.instance.EString.ToImmutable(MModel);
			ETreeIterator = EcoreBuilderInstance.instance.ETreeIterator.ToImmutable(MModel);
			EInvocationTargetException = EcoreBuilderInstance.instance.EInvocationTargetException.ToImmutable(MModel);

			EAttribute = EcoreBuilderInstance.instance.EAttribute.ToImmutable(MModel);
			EAttribute_ID = EcoreBuilderInstance.instance.EAttribute_ID.ToImmutable(MModel);
			EAttribute_EAttributeType = EcoreBuilderInstance.instance.EAttribute_EAttributeType.ToImmutable(MModel);
			EAnnotation = EcoreBuilderInstance.instance.EAnnotation.ToImmutable(MModel);
			EAnnotation_Source = EcoreBuilderInstance.instance.EAnnotation_Source.ToImmutable(MModel);
			EAnnotation_Details = EcoreBuilderInstance.instance.EAnnotation_Details.ToImmutable(MModel);
			EAnnotation_EModelElement = EcoreBuilderInstance.instance.EAnnotation_EModelElement.ToImmutable(MModel);
			EAnnotation_Contents = EcoreBuilderInstance.instance.EAnnotation_Contents.ToImmutable(MModel);
			EAnnotation_References = EcoreBuilderInstance.instance.EAnnotation_References.ToImmutable(MModel);
			EClass = EcoreBuilderInstance.instance.EClass.ToImmutable(MModel);
			EClass_Abstract = EcoreBuilderInstance.instance.EClass_Abstract.ToImmutable(MModel);
			EClass_Interface = EcoreBuilderInstance.instance.EClass_Interface.ToImmutable(MModel);
			EClass_ESuperTypes = EcoreBuilderInstance.instance.EClass_ESuperTypes.ToImmutable(MModel);
			EClass_EOperations = EcoreBuilderInstance.instance.EClass_EOperations.ToImmutable(MModel);
			EClass_EAllAttributes = EcoreBuilderInstance.instance.EClass_EAllAttributes.ToImmutable(MModel);
			EClass_EAllReferences = EcoreBuilderInstance.instance.EClass_EAllReferences.ToImmutable(MModel);
			EClass_EReferences = EcoreBuilderInstance.instance.EClass_EReferences.ToImmutable(MModel);
			EClass_EAttributes = EcoreBuilderInstance.instance.EClass_EAttributes.ToImmutable(MModel);
			EClass_EAllContainments = EcoreBuilderInstance.instance.EClass_EAllContainments.ToImmutable(MModel);
			EClass_EAllOperations = EcoreBuilderInstance.instance.EClass_EAllOperations.ToImmutable(MModel);
			EClass_EAllStructuralFeatures = EcoreBuilderInstance.instance.EClass_EAllStructuralFeatures.ToImmutable(MModel);
			EClass_EAllSuperTypes = EcoreBuilderInstance.instance.EClass_EAllSuperTypes.ToImmutable(MModel);
			EClass_EIDAttribute = EcoreBuilderInstance.instance.EClass_EIDAttribute.ToImmutable(MModel);
			EClass_EStructuralFeatures = EcoreBuilderInstance.instance.EClass_EStructuralFeatures.ToImmutable(MModel);
			EClass_EGenericSuperTypes = EcoreBuilderInstance.instance.EClass_EGenericSuperTypes.ToImmutable(MModel);
			EClass_EAllGenericSuperTypes = EcoreBuilderInstance.instance.EClass_EAllGenericSuperTypes.ToImmutable(MModel);
			EClassifier = EcoreBuilderInstance.instance.EClassifier.ToImmutable(MModel);
			EClassifier_DotNetName = EcoreBuilderInstance.instance.EClassifier_DotNetName.ToImmutable(MModel);
			EClassifier_InstanceClassName = EcoreBuilderInstance.instance.EClassifier_InstanceClassName.ToImmutable(MModel);
			EClassifier_InstanceClass = EcoreBuilderInstance.instance.EClassifier_InstanceClass.ToImmutable(MModel);
			EClassifier_DefaultValue = EcoreBuilderInstance.instance.EClassifier_DefaultValue.ToImmutable(MModel);
			EClassifier_InstanceTypeName = EcoreBuilderInstance.instance.EClassifier_InstanceTypeName.ToImmutable(MModel);
			EClassifier_EPackage = EcoreBuilderInstance.instance.EClassifier_EPackage.ToImmutable(MModel);
			EClassifier_ETypeParameters = EcoreBuilderInstance.instance.EClassifier_ETypeParameters.ToImmutable(MModel);
			EDataType = EcoreBuilderInstance.instance.EDataType.ToImmutable(MModel);
			EDataType_Serializable = EcoreBuilderInstance.instance.EDataType_Serializable.ToImmutable(MModel);
			EEnum = EcoreBuilderInstance.instance.EEnum.ToImmutable(MModel);
			EEnum_ELiterals = EcoreBuilderInstance.instance.EEnum_ELiterals.ToImmutable(MModel);
			EEnumLiteral = EcoreBuilderInstance.instance.EEnumLiteral.ToImmutable(MModel);
			EEnumLiteral_Value = EcoreBuilderInstance.instance.EEnumLiteral_Value.ToImmutable(MModel);
			EEnumLiteral_Instance = EcoreBuilderInstance.instance.EEnumLiteral_Instance.ToImmutable(MModel);
			EEnumLiteral_Literal = EcoreBuilderInstance.instance.EEnumLiteral_Literal.ToImmutable(MModel);
			EEnumLiteral_EEnum = EcoreBuilderInstance.instance.EEnumLiteral_EEnum.ToImmutable(MModel);
			EFactory = EcoreBuilderInstance.instance.EFactory.ToImmutable(MModel);
			EFactory_EPackage = EcoreBuilderInstance.instance.EFactory_EPackage.ToImmutable(MModel);
			EModelElement = EcoreBuilderInstance.instance.EModelElement.ToImmutable(MModel);
			EModelElement_EAnnotations = EcoreBuilderInstance.instance.EModelElement_EAnnotations.ToImmutable(MModel);
			ENamedElement = EcoreBuilderInstance.instance.ENamedElement.ToImmutable(MModel);
			ENamedElement_Name = EcoreBuilderInstance.instance.ENamedElement_Name.ToImmutable(MModel);
			EObject = EcoreBuilderInstance.instance.EObject.ToImmutable(MModel);
			EOperation = EcoreBuilderInstance.instance.EOperation.ToImmutable(MModel);
			EOperation_EContainingClass = EcoreBuilderInstance.instance.EOperation_EContainingClass.ToImmutable(MModel);
			EOperation_ETypeParameters = EcoreBuilderInstance.instance.EOperation_ETypeParameters.ToImmutable(MModel);
			EOperation_EParameters = EcoreBuilderInstance.instance.EOperation_EParameters.ToImmutable(MModel);
			EOperation_EExceptions = EcoreBuilderInstance.instance.EOperation_EExceptions.ToImmutable(MModel);
			EOperation_EGenericExceptions = EcoreBuilderInstance.instance.EOperation_EGenericExceptions.ToImmutable(MModel);
			EPackage = EcoreBuilderInstance.instance.EPackage.ToImmutable(MModel);
			EPackage_NsURI = EcoreBuilderInstance.instance.EPackage_NsURI.ToImmutable(MModel);
			EPackage_NsPrefix = EcoreBuilderInstance.instance.EPackage_NsPrefix.ToImmutable(MModel);
			EPackage_EFactoryInstance = EcoreBuilderInstance.instance.EPackage_EFactoryInstance.ToImmutable(MModel);
			EPackage_EClassifiers = EcoreBuilderInstance.instance.EPackage_EClassifiers.ToImmutable(MModel);
			EPackage_ESubpackages = EcoreBuilderInstance.instance.EPackage_ESubpackages.ToImmutable(MModel);
			EPackage_ESuperPackage = EcoreBuilderInstance.instance.EPackage_ESuperPackage.ToImmutable(MModel);
			EParameter = EcoreBuilderInstance.instance.EParameter.ToImmutable(MModel);
			EParameter_EOperation = EcoreBuilderInstance.instance.EParameter_EOperation.ToImmutable(MModel);
			EReference = EcoreBuilderInstance.instance.EReference.ToImmutable(MModel);
			EReference_Containment = EcoreBuilderInstance.instance.EReference_Containment.ToImmutable(MModel);
			EReference_Container = EcoreBuilderInstance.instance.EReference_Container.ToImmutable(MModel);
			EReference_ResolveProxies = EcoreBuilderInstance.instance.EReference_ResolveProxies.ToImmutable(MModel);
			EReference_EOpposite = EcoreBuilderInstance.instance.EReference_EOpposite.ToImmutable(MModel);
			EReference_EReferenceType = EcoreBuilderInstance.instance.EReference_EReferenceType.ToImmutable(MModel);
			EReference_EKeys = EcoreBuilderInstance.instance.EReference_EKeys.ToImmutable(MModel);
			EStructuralFeature = EcoreBuilderInstance.instance.EStructuralFeature.ToImmutable(MModel);
			EStructuralFeature_Changeable = EcoreBuilderInstance.instance.EStructuralFeature_Changeable.ToImmutable(MModel);
			EStructuralFeature_Volatile = EcoreBuilderInstance.instance.EStructuralFeature_Volatile.ToImmutable(MModel);
			EStructuralFeature_Transient = EcoreBuilderInstance.instance.EStructuralFeature_Transient.ToImmutable(MModel);
			EStructuralFeature_DefaultValueLiteral = EcoreBuilderInstance.instance.EStructuralFeature_DefaultValueLiteral.ToImmutable(MModel);
			EStructuralFeature_DefaultValue = EcoreBuilderInstance.instance.EStructuralFeature_DefaultValue.ToImmutable(MModel);
			EStructuralFeature_Unsettable = EcoreBuilderInstance.instance.EStructuralFeature_Unsettable.ToImmutable(MModel);
			EStructuralFeature_Derived = EcoreBuilderInstance.instance.EStructuralFeature_Derived.ToImmutable(MModel);
			EStructuralFeature_EContainingClass = EcoreBuilderInstance.instance.EStructuralFeature_EContainingClass.ToImmutable(MModel);
			ETypedElement = EcoreBuilderInstance.instance.ETypedElement.ToImmutable(MModel);
			ETypedElement_Ordered = EcoreBuilderInstance.instance.ETypedElement_Ordered.ToImmutable(MModel);
			ETypedElement_Unique = EcoreBuilderInstance.instance.ETypedElement_Unique.ToImmutable(MModel);
			ETypedElement_LowerBound = EcoreBuilderInstance.instance.ETypedElement_LowerBound.ToImmutable(MModel);
			ETypedElement_UpperBound = EcoreBuilderInstance.instance.ETypedElement_UpperBound.ToImmutable(MModel);
			ETypedElement_Many = EcoreBuilderInstance.instance.ETypedElement_Many.ToImmutable(MModel);
			ETypedElement_Required = EcoreBuilderInstance.instance.ETypedElement_Required.ToImmutable(MModel);
			ETypedElement_EType = EcoreBuilderInstance.instance.ETypedElement_EType.ToImmutable(MModel);
			ETypedElement_EGenericType = EcoreBuilderInstance.instance.ETypedElement_EGenericType.ToImmutable(MModel);
			EStringToStringMapEntry = EcoreBuilderInstance.instance.EStringToStringMapEntry.ToImmutable(MModel);
			EStringToStringMapEntry_Key = EcoreBuilderInstance.instance.EStringToStringMapEntry_Key.ToImmutable(MModel);
			EStringToStringMapEntry_Value = EcoreBuilderInstance.instance.EStringToStringMapEntry_Value.ToImmutable(MModel);
			EGenericType = EcoreBuilderInstance.instance.EGenericType.ToImmutable(MModel);
			EGenericType_EUpperBound = EcoreBuilderInstance.instance.EGenericType_EUpperBound.ToImmutable(MModel);
			EGenericType_ETypeArguments = EcoreBuilderInstance.instance.EGenericType_ETypeArguments.ToImmutable(MModel);
			EGenericType_ERawType = EcoreBuilderInstance.instance.EGenericType_ERawType.ToImmutable(MModel);
			EGenericType_ELowerBound = EcoreBuilderInstance.instance.EGenericType_ELowerBound.ToImmutable(MModel);
			EGenericType_ETypeParameter = EcoreBuilderInstance.instance.EGenericType_ETypeParameter.ToImmutable(MModel);
			EGenericType_EClassifier = EcoreBuilderInstance.instance.EGenericType_EClassifier.ToImmutable(MModel);
			ETypeParameter = EcoreBuilderInstance.instance.ETypeParameter.ToImmutable(MModel);
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Modeling.MutableObject Create(string type)
		{
			switch (type)
			{
				case "EAttribute": return this.EAttribute();
				case "EAnnotation": return this.EAnnotation();
				case "EClass": return this.EClass();
				case "EDataType": return this.EDataType();
				case "EEnum": return this.EEnum();
				case "EEnumLiteral": return this.EEnumLiteral();
				case "EFactory": return this.EFactory();
				case "EObject": return this.EObject();
				case "EOperation": return this.EOperation();
				case "EPackage": return this.EPackage();
				case "EParameter": return this.EParameter();
				case "EReference": return this.EReference();
				case "EStringToStringMapEntry": return this.EStringToStringMapEntry();
				case "EGenericType": return this.EGenericType();
				case "ETypeParameter": return this.ETypeParameter();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));
			}
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
		/// Creates a new instance of EAnnotation.
		/// </summary>
		public EAnnotationBuilder EAnnotation()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EAnnotationId());
			return (EAnnotationBuilder)obj;
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
		/// Creates a new instance of EFactory.
		/// </summary>
		public EFactoryBuilder EFactory()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EFactoryId());
			return (EFactoryBuilder)obj;
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
		/// Creates a new instance of EOperation.
		/// </summary>
		public EOperationBuilder EOperation()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EOperationId());
			return (EOperationBuilder)obj;
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
		/// Creates a new instance of EParameter.
		/// </summary>
		public EParameterBuilder EParameter()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EParameterId());
			return (EParameterBuilder)obj;
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
		/// Creates a new instance of EStringToStringMapEntry.
		/// </summary>
		public EStringToStringMapEntryBuilder EStringToStringMapEntry()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EStringToStringMapEntryId());
			return (EStringToStringMapEntryBuilder)obj;
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

	public interface EAnnotation : EModelElement
	{
		string Source { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EStringToStringMapEntry> Details { get; }
		EModelElement EModelElement { get; }
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
		string Source { get; set; }
		void SetSourceLazy(global::System.Func<string> lazy);
		void SetSourceLazy(global::System.Func<EAnnotationBuilder, string> lazy);
		void SetSourceLazy(global::System.Func<EAnnotation, string> immutableLazy, global::System.Func<EAnnotationBuilder, string> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EStringToStringMapEntryBuilder> Details { get; }
		EModelElementBuilder EModelElement { get; set; }
		void SetEModelElementLazy(global::System.Func<EModelElementBuilder> lazy);
		void SetEModelElementLazy(global::System.Func<EAnnotationBuilder, EModelElementBuilder> lazy);
		void SetEModelElementLazy(global::System.Func<EAnnotation, EModelElement> immutableLazy, global::System.Func<EAnnotationBuilder, EModelElementBuilder> mutableLazy);
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

	public interface EClass : EClassifier
	{
		bool Abstract { get; }
		bool Interface { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EClass> ESuperTypes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EOperation> EOperations { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EAllAttributes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EReference> EAllReferences { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EReference> EReferences { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EAttributes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EReference> EAllContainments { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EOperation> EAllOperations { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> EAllStructuralFeatures { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EClass> EAllSuperTypes { get; }
		EAttribute EIDAttribute { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> EStructuralFeatures { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericSuperTypes { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EAllGenericSuperTypes { get; }

		bool IsSuperTypeOf(EClass someClass);
		int GetFeatureCount();
		EStructuralFeature GetEStructuralFeature(int featureID);
		int GetFeatureID(EStructuralFeature feature);
		EStructuralFeature GetEStructuralFeature(string featureName);
		int GetOperationCount();
		EOperation GetEOperation(int operationID);
		int GetOperationID(EOperation operation);
		EOperation GetOverride(EOperation operation);
		EGenericType GetFeatureType(EStructuralFeature feature);

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
		global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> EOperations { get; }
		global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EAllAttributes { get; }
		global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EAllReferences { get; }
		global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EReferences { get; }
		global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EAttributes { get; }
		global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EAllContainments { get; }
		global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> EAllOperations { get; }
		global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> EAllStructuralFeatures { get; }
		global::MetaDslx.Modeling.MutableModelList<EClassBuilder> EAllSuperTypes { get; }
		EAttributeBuilder EIDAttribute { get; }
		void SetEIDAttributeLazy(global::System.Func<EAttributeBuilder> lazy);
		void SetEIDAttributeLazy(global::System.Func<EClassBuilder, EAttributeBuilder> lazy);
		void SetEIDAttributeLazy(global::System.Func<EClass, EAttribute> immutableLazy, global::System.Func<EClassBuilder, EAttributeBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> EStructuralFeatures { get; }
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericSuperTypes { get; }
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EAllGenericSuperTypes { get; }

		bool IsSuperTypeOf(EClassBuilder someClass);
		int GetFeatureCount();
		EStructuralFeatureBuilder GetEStructuralFeature(int featureID);
		int GetFeatureID(EStructuralFeatureBuilder feature);
		EStructuralFeatureBuilder GetEStructuralFeature(string featureName);
		int GetOperationCount();
		EOperationBuilder GetEOperation(int operationID);
		int GetOperationID(EOperationBuilder operation);
		EOperationBuilder GetOverride(EOperationBuilder operation);
		EGenericTypeBuilder GetFeatureType(EStructuralFeatureBuilder feature);

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

	public interface EClassifier : ENamedElement
	{
		string DotNetName { get; }
		string InstanceClassName { get; }
		System.Type InstanceClass { get; }
		object DefaultValue { get; }
		string InstanceTypeName { get; }
		EPackage EPackage { get; }
		global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters { get; }

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
		string DotNetName { get; set; }
		void SetDotNetNameLazy(global::System.Func<string> lazy);
		void SetDotNetNameLazy(global::System.Func<EClassifierBuilder, string> lazy);
		void SetDotNetNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy);
		string InstanceClassName { get; set; }
		void SetInstanceClassNameLazy(global::System.Func<string> lazy);
		void SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, string> lazy);
		void SetInstanceClassNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy);
		System.Type InstanceClass { get; }
		void SetInstanceClassLazy(global::System.Func<System.Type> lazy);
		void SetInstanceClassLazy(global::System.Func<EClassifierBuilder, System.Type> lazy);
		void SetInstanceClassLazy(global::System.Func<EClassifier, System.Type> immutableLazy, global::System.Func<EClassifierBuilder, System.Type> mutableLazy);
		object DefaultValue { get; }
		void SetDefaultValueLazy(global::System.Func<object> lazy);
		void SetDefaultValueLazy(global::System.Func<EClassifierBuilder, object> lazy);
		void SetDefaultValueLazy(global::System.Func<EClassifier, object> immutableLazy, global::System.Func<EClassifierBuilder, object> mutableLazy);
		string InstanceTypeName { get; set; }
		void SetInstanceTypeNameLazy(global::System.Func<string> lazy);
		void SetInstanceTypeNameLazy(global::System.Func<EClassifierBuilder, string> lazy);
		void SetInstanceTypeNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy);
		EPackageBuilder EPackage { get; set; }
		void SetEPackageLazy(global::System.Func<EPackageBuilder> lazy);
		void SetEPackageLazy(global::System.Func<EClassifierBuilder, EPackageBuilder> lazy);
		void SetEPackageLazy(global::System.Func<EClassifier, EPackage> immutableLazy, global::System.Func<EClassifierBuilder, EPackageBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters { get; }

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

	public interface EDataType : EClassifier
	{
		bool Serializable { get; }


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

		EEnumLiteral GetEEnumLiteral(string name);
		EEnumLiteral GetEEnumLiteral(int value);
		EEnumLiteral GetEEnumLiteralByLiteral(string literal);

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

		EEnumLiteralBuilder GetEEnumLiteral(string name);
		EEnumLiteralBuilder GetEEnumLiteral(int value);
		EEnumLiteralBuilder GetEEnumLiteralByLiteral(string literal);

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
		int Value { get; }
		System.Collections.IEnumerable Instance { get; }
		string Literal { get; }
		EEnum EEnum { get; }


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
		int Value { get; set; }
		void SetValueLazy(global::System.Func<int> lazy);
		void SetValueLazy(global::System.Func<EEnumLiteralBuilder, int> lazy);
		void SetValueLazy(global::System.Func<EEnumLiteral, int> immutableLazy, global::System.Func<EEnumLiteralBuilder, int> mutableLazy);
		System.Collections.IEnumerable Instance { get; set; }
		void SetInstanceLazy(global::System.Func<System.Collections.IEnumerable> lazy);
		void SetInstanceLazy(global::System.Func<EEnumLiteralBuilder, System.Collections.IEnumerable> lazy);
		void SetInstanceLazy(global::System.Func<EEnumLiteral, System.Collections.IEnumerable> immutableLazy, global::System.Func<EEnumLiteralBuilder, System.Collections.IEnumerable> mutableLazy);
		string Literal { get; set; }
		void SetLiteralLazy(global::System.Func<string> lazy);
		void SetLiteralLazy(global::System.Func<EEnumLiteralBuilder, string> lazy);
		void SetLiteralLazy(global::System.Func<EEnumLiteral, string> immutableLazy, global::System.Func<EEnumLiteralBuilder, string> mutableLazy);
		EEnumBuilder EEnum { get; set; }
		void SetEEnumLazy(global::System.Func<EEnumBuilder> lazy);
		void SetEEnumLazy(global::System.Func<EEnumLiteralBuilder, EEnumBuilder> lazy);
		void SetEEnumLazy(global::System.Func<EEnumLiteral, EEnum> immutableLazy, global::System.Func<EEnumLiteralBuilder, EEnumBuilder> mutableLazy);


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

	public interface EFactory : EModelElement
	{
		EPackage EPackage { get; }

		EObject Create(EClass eClass);
		object CreateFromString(EDataType eDataType, string literalValue);
		string ConvertToString(EDataType eDataType, object instanceValue);

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
		object CreateFromString(EDataTypeBuilder eDataType, string literalValue);
		string ConvertToString(EDataTypeBuilder eDataType, object instanceValue);

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

	public interface EModelElement : global::MetaDslx.Modeling.ImmutableObject
	{
		global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations { get; }

		EAnnotation GetEAnnotation(string source);

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

	public interface EModelElementBuilder : global::MetaDslx.Modeling.MutableObject
	{
		global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations { get; }

		EAnnotationBuilder GetEAnnotation(string source);

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

	public interface ENamedElement : EModelElement
	{
		string Name { get; }


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
		string Name { get; set; }
		void SetNameLazy(global::System.Func<string> lazy);
		void SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy);
		void SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy);


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

	public interface EObject : global::MetaDslx.Modeling.ImmutableObject
	{

		EClass EClass();
		bool EIsProxy();
		MetaDslx.Modeling.IModel EResource();
		EObject EContainer();
		EStructuralFeature EContainingFeature();
		EReference EContainmentFeature();
		global::System.Collections.Generic.IReadOnlyList<EObject> EContents();
		System.Collections.IEnumerable EAllContents();
		global::System.Collections.Generic.IReadOnlyList<EObject> ECrossReferences();
		object EGet(EStructuralFeature feature);
		object EGet(EStructuralFeature feature, bool resolve);
		void ESet(EStructuralFeature feature, object newValue);
		bool EIsSet(EStructuralFeature feature);
		void EUnset(EStructuralFeature feature);
		object EInvoke(EOperation operation, global::System.Collections.Generic.IReadOnlyList<object> arguments);

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
		global::System.Collections.Generic.IReadOnlyList<EObjectBuilder> EContents();
		System.Collections.IEnumerable EAllContents();
		global::System.Collections.Generic.IReadOnlyList<EObjectBuilder> ECrossReferences();
		object EGet(EStructuralFeatureBuilder feature);
		object EGet(EStructuralFeatureBuilder feature, bool resolve);
		void ESet(EStructuralFeatureBuilder feature, object newValue);
		bool EIsSet(EStructuralFeatureBuilder feature);
		void EUnset(EStructuralFeatureBuilder feature);
		object EInvoke(EOperationBuilder operation, global::System.Collections.Generic.IReadOnlyList<object> arguments);

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

	public interface EOperation : ETypedElement
	{
		EClass EContainingClass { get; }
		global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EParameter> EParameters { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EClassifier> EExceptions { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericExceptions { get; }

		int GetOperationID();
		bool IsOverrideOf(EOperation someOperation);

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
		global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters { get; }
		global::MetaDslx.Modeling.MutableModelList<EParameterBuilder> EParameters { get; }
		global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> EExceptions { get; }
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericExceptions { get; }

		int GetOperationID();
		bool IsOverrideOf(EOperationBuilder someOperation);

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

	public interface EPackage : ENamedElement
	{
		string NsURI { get; }
		string NsPrefix { get; }
		EFactory EFactoryInstance { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EClassifier> EClassifiers { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EPackage> ESubpackages { get; }
		EPackage ESuperPackage { get; }

		EClassifier GetEClassifier(string name);

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
		string NsURI { get; set; }
		void SetNsURILazy(global::System.Func<string> lazy);
		void SetNsURILazy(global::System.Func<EPackageBuilder, string> lazy);
		void SetNsURILazy(global::System.Func<EPackage, string> immutableLazy, global::System.Func<EPackageBuilder, string> mutableLazy);
		string NsPrefix { get; set; }
		void SetNsPrefixLazy(global::System.Func<string> lazy);
		void SetNsPrefixLazy(global::System.Func<EPackageBuilder, string> lazy);
		void SetNsPrefixLazy(global::System.Func<EPackage, string> immutableLazy, global::System.Func<EPackageBuilder, string> mutableLazy);
		EFactoryBuilder EFactoryInstance { get; set; }
		void SetEFactoryInstanceLazy(global::System.Func<EFactoryBuilder> lazy);
		void SetEFactoryInstanceLazy(global::System.Func<EPackageBuilder, EFactoryBuilder> lazy);
		void SetEFactoryInstanceLazy(global::System.Func<EPackage, EFactory> immutableLazy, global::System.Func<EPackageBuilder, EFactoryBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> EClassifiers { get; }
		global::MetaDslx.Modeling.MutableModelList<EPackageBuilder> ESubpackages { get; }
		EPackageBuilder ESuperPackage { get; set; }
		void SetESuperPackageLazy(global::System.Func<EPackageBuilder> lazy);
		void SetESuperPackageLazy(global::System.Func<EPackageBuilder, EPackageBuilder> lazy);
		void SetESuperPackageLazy(global::System.Func<EPackage, EPackage> immutableLazy, global::System.Func<EPackageBuilder, EPackageBuilder> mutableLazy);

		EClassifierBuilder GetEClassifier(string name);

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

	public interface EReference : EStructuralFeature
	{
		bool Containment { get; }
		bool Container { get; }
		bool ResolveProxies { get; }
		EReference EOpposite { get; }
		EClass EReferenceType { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EKeys { get; }


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
		EClassBuilder EReferenceType { get; }
		void SetEReferenceTypeLazy(global::System.Func<EClassBuilder> lazy);
		void SetEReferenceTypeLazy(global::System.Func<EReferenceBuilder, EClassBuilder> lazy);
		void SetEReferenceTypeLazy(global::System.Func<EReference, EClass> immutableLazy, global::System.Func<EReferenceBuilder, EClassBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EKeys { get; }


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

	public interface EStructuralFeature : ETypedElement
	{
		bool Changeable { get; }
		bool Volatile { get; }
		bool Transient { get; }
		string DefaultValueLiteral { get; }
		object DefaultValue { get; }
		bool Unsettable { get; }
		bool Derived { get; }
		EClass EContainingClass { get; }

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
		string DefaultValueLiteral { get; set; }
		void SetDefaultValueLiteralLazy(global::System.Func<string> lazy);
		void SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeatureBuilder, string> lazy);
		void SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeature, string> immutableLazy, global::System.Func<EStructuralFeatureBuilder, string> mutableLazy);
		object DefaultValue { get; }
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
		EClassBuilder EContainingClass { get; set; }
		void SetEContainingClassLazy(global::System.Func<EClassBuilder> lazy);
		void SetEContainingClassLazy(global::System.Func<EStructuralFeatureBuilder, EClassBuilder> lazy);
		void SetEContainingClassLazy(global::System.Func<EStructuralFeature, EClass> immutableLazy, global::System.Func<EStructuralFeatureBuilder, EClassBuilder> mutableLazy);

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

	public interface ETypedElement : ENamedElement
	{
		bool Ordered { get; }
		bool Unique { get; }
		int LowerBound { get; }
		int UpperBound { get; }
		bool Many { get; }
		bool Required { get; }
		EClassifier EType { get; }
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
		EClassifierBuilder EType { get; set; }
		void SetETypeLazy(global::System.Func<EClassifierBuilder> lazy);
		void SetETypeLazy(global::System.Func<ETypedElementBuilder, EClassifierBuilder> lazy);
		void SetETypeLazy(global::System.Func<ETypedElement, EClassifier> immutableLazy, global::System.Func<ETypedElementBuilder, EClassifierBuilder> mutableLazy);
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

	public interface EStringToStringMapEntry : global::MetaDslx.Modeling.ImmutableObject
	{
		string Key { get; }
		string Value { get; }


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
		string Key { get; set; }
		void SetKeyLazy(global::System.Func<string> lazy);
		void SetKeyLazy(global::System.Func<EStringToStringMapEntryBuilder, string> lazy);
		void SetKeyLazy(global::System.Func<EStringToStringMapEntry, string> immutableLazy, global::System.Func<EStringToStringMapEntryBuilder, string> mutableLazy);
		string Value { get; set; }
		void SetValueLazy(global::System.Func<string> lazy);
		void SetValueLazy(global::System.Func<EStringToStringMapEntryBuilder, string> lazy);
		void SetValueLazy(global::System.Func<EStringToStringMapEntry, string> immutableLazy, global::System.Func<EStringToStringMapEntryBuilder, string> mutableLazy);


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

	public interface EGenericType : global::MetaDslx.Modeling.ImmutableObject
	{
		EGenericType EUpperBound { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EGenericType> ETypeArguments { get; }
		EClassifier ERawType { get; }
		EGenericType ELowerBound { get; }
		ETypeParameter ETypeParameter { get; }
		EClassifier EClassifier { get; }

		bool IsInstance(object @object);

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
		EGenericTypeBuilder EUpperBound { get; set; }
		void SetEUpperBoundLazy(global::System.Func<EGenericTypeBuilder> lazy);
		void SetEUpperBoundLazy(global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> lazy);
		void SetEUpperBoundLazy(global::System.Func<EGenericType, EGenericType> immutableLazy, global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> ETypeArguments { get; }
		EClassifierBuilder ERawType { get; }
		void SetERawTypeLazy(global::System.Func<EClassifierBuilder> lazy);
		void SetERawTypeLazy(global::System.Func<EGenericTypeBuilder, EClassifierBuilder> lazy);
		void SetERawTypeLazy(global::System.Func<EGenericType, EClassifier> immutableLazy, global::System.Func<EGenericTypeBuilder, EClassifierBuilder> mutableLazy);
		EGenericTypeBuilder ELowerBound { get; set; }
		void SetELowerBoundLazy(global::System.Func<EGenericTypeBuilder> lazy);
		void SetELowerBoundLazy(global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> lazy);
		void SetELowerBoundLazy(global::System.Func<EGenericType, EGenericType> immutableLazy, global::System.Func<EGenericTypeBuilder, EGenericTypeBuilder> mutableLazy);
		ETypeParameterBuilder ETypeParameter { get; set; }
		void SetETypeParameterLazy(global::System.Func<ETypeParameterBuilder> lazy);
		void SetETypeParameterLazy(global::System.Func<EGenericTypeBuilder, ETypeParameterBuilder> lazy);
		void SetETypeParameterLazy(global::System.Func<EGenericType, ETypeParameter> immutableLazy, global::System.Func<EGenericTypeBuilder, ETypeParameterBuilder> mutableLazy);
		EClassifierBuilder EClassifier { get; set; }
		void SetEClassifierLazy(global::System.Func<EClassifierBuilder> lazy);
		void SetEClassifierLazy(global::System.Func<EGenericTypeBuilder, EClassifierBuilder> lazy);
		void SetEClassifierLazy(global::System.Func<EGenericType, EClassifier> immutableLazy, global::System.Func<EGenericTypeBuilder, EClassifierBuilder> mutableLazy);

		bool IsInstance(object @object);

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
			EAttribute.Initialize();
			EAnnotation.Initialize();
			EClass.Initialize();
			EClassifier.Initialize();
			EDataType.Initialize();
			EEnum.Initialize();
			EEnumLiteral.Initialize();
			EFactory.Initialize();
			EModelElement.Initialize();
			ENamedElement.Initialize();
			EObject.Initialize();
			EOperation.Initialize();
			EPackage.Initialize();
			EParameter.Initialize();
			EReference.Initialize();
			EStructuralFeature.Initialize();
			ETypedElement.Initialize();
			EStringToStringMapEntry.Initialize();
			EGenericType.Initialize();
			ETypeParameter.Initialize();
			properties.Add(EcoreDescriptor.EAttribute.IDProperty);
			properties.Add(EcoreDescriptor.EAttribute.EAttributeTypeProperty);
			properties.Add(EcoreDescriptor.EAnnotation.SourceProperty);
			properties.Add(EcoreDescriptor.EAnnotation.DetailsProperty);
			properties.Add(EcoreDescriptor.EAnnotation.EModelElementProperty);
			properties.Add(EcoreDescriptor.EAnnotation.ContentsProperty);
			properties.Add(EcoreDescriptor.EAnnotation.ReferencesProperty);
			properties.Add(EcoreDescriptor.EClass.AbstractProperty);
			properties.Add(EcoreDescriptor.EClass.InterfaceProperty);
			properties.Add(EcoreDescriptor.EClass.ESuperTypesProperty);
			properties.Add(EcoreDescriptor.EClass.EOperationsProperty);
			properties.Add(EcoreDescriptor.EClass.EAllAttributesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllReferencesProperty);
			properties.Add(EcoreDescriptor.EClass.EReferencesProperty);
			properties.Add(EcoreDescriptor.EClass.EAttributesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllContainmentsProperty);
			properties.Add(EcoreDescriptor.EClass.EAllOperationsProperty);
			properties.Add(EcoreDescriptor.EClass.EAllStructuralFeaturesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllSuperTypesProperty);
			properties.Add(EcoreDescriptor.EClass.EIDAttributeProperty);
			properties.Add(EcoreDescriptor.EClass.EStructuralFeaturesProperty);
			properties.Add(EcoreDescriptor.EClass.EGenericSuperTypesProperty);
			properties.Add(EcoreDescriptor.EClass.EAllGenericSuperTypesProperty);
			properties.Add(EcoreDescriptor.EClassifier.DotNetNameProperty);
			properties.Add(EcoreDescriptor.EClassifier.InstanceClassNameProperty);
			properties.Add(EcoreDescriptor.EClassifier.InstanceClassProperty);
			properties.Add(EcoreDescriptor.EClassifier.DefaultValueProperty);
			properties.Add(EcoreDescriptor.EClassifier.InstanceTypeNameProperty);
			properties.Add(EcoreDescriptor.EClassifier.EPackageProperty);
			properties.Add(EcoreDescriptor.EClassifier.ETypeParametersProperty);
			properties.Add(EcoreDescriptor.EDataType.SerializableProperty);
			properties.Add(EcoreDescriptor.EEnum.ELiteralsProperty);
			properties.Add(EcoreDescriptor.EEnumLiteral.ValueProperty);
			properties.Add(EcoreDescriptor.EEnumLiteral.InstanceProperty);
			properties.Add(EcoreDescriptor.EEnumLiteral.LiteralProperty);
			properties.Add(EcoreDescriptor.EEnumLiteral.EEnumProperty);
			properties.Add(EcoreDescriptor.EFactory.EPackageProperty);
			properties.Add(EcoreDescriptor.EModelElement.EAnnotationsProperty);
			properties.Add(EcoreDescriptor.ENamedElement.NameProperty);
			properties.Add(EcoreDescriptor.EOperation.EContainingClassProperty);
			properties.Add(EcoreDescriptor.EOperation.ETypeParametersProperty);
			properties.Add(EcoreDescriptor.EOperation.EParametersProperty);
			properties.Add(EcoreDescriptor.EOperation.EExceptionsProperty);
			properties.Add(EcoreDescriptor.EOperation.EGenericExceptionsProperty);
			properties.Add(EcoreDescriptor.EPackage.NsURIProperty);
			properties.Add(EcoreDescriptor.EPackage.NsPrefixProperty);
			properties.Add(EcoreDescriptor.EPackage.EFactoryInstanceProperty);
			properties.Add(EcoreDescriptor.EPackage.EClassifiersProperty);
			properties.Add(EcoreDescriptor.EPackage.ESubpackagesProperty);
			properties.Add(EcoreDescriptor.EPackage.ESuperPackageProperty);
			properties.Add(EcoreDescriptor.EParameter.EOperationProperty);
			properties.Add(EcoreDescriptor.EReference.ContainmentProperty);
			properties.Add(EcoreDescriptor.EReference.ContainerProperty);
			properties.Add(EcoreDescriptor.EReference.ResolveProxiesProperty);
			properties.Add(EcoreDescriptor.EReference.EOppositeProperty);
			properties.Add(EcoreDescriptor.EReference.EReferenceTypeProperty);
			properties.Add(EcoreDescriptor.EReference.EKeysProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.ChangeableProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.VolatileProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.TransientProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.DefaultValueProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.UnsettableProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.DerivedProperty);
			properties.Add(EcoreDescriptor.EStructuralFeature.EContainingClassProperty);
			properties.Add(EcoreDescriptor.ETypedElement.OrderedProperty);
			properties.Add(EcoreDescriptor.ETypedElement.UniqueProperty);
			properties.Add(EcoreDescriptor.ETypedElement.LowerBoundProperty);
			properties.Add(EcoreDescriptor.ETypedElement.UpperBoundProperty);
			properties.Add(EcoreDescriptor.ETypedElement.ManyProperty);
			properties.Add(EcoreDescriptor.ETypedElement.RequiredProperty);
			properties.Add(EcoreDescriptor.ETypedElement.ETypeProperty);
			properties.Add(EcoreDescriptor.ETypedElement.EGenericTypeProperty);
			properties.Add(EcoreDescriptor.EStringToStringMapEntry.KeyProperty);
			properties.Add(EcoreDescriptor.EStringToStringMapEntry.ValueProperty);
			properties.Add(EcoreDescriptor.EGenericType.EUpperBoundProperty);
			properties.Add(EcoreDescriptor.EGenericType.ETypeArgumentsProperty);
			properties.Add(EcoreDescriptor.EGenericType.ERawTypeProperty);
			properties.Add(EcoreDescriptor.EGenericType.ELowerBoundProperty);
			properties.Add(EcoreDescriptor.EGenericType.ETypeParameterProperty);
			properties.Add(EcoreDescriptor.EGenericType.EClassifierProperty);
			properties.Add(EcoreDescriptor.ETypeParameter.EBoundsProperty);
		}

		public static void Initialize()
		{
		}

		public const string MUri = "http://www.eclipse.org/emf/2002/Ecore";
		public const string MPrefix = "ecore";

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

			public static readonly global::MetaDslx.Modeling.ModelProperty SourceProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAnnotation), name: "Source",
					immutableType: typeof(string),
					mutableType: typeof(string),
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

			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EModelElement), "EAnnotations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EModelElementProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EAnnotation), name: "EModelElement",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EModelElement),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EModelElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EAnnotation_EModelElement,
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
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllAttributesProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllAttributes",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttribute),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttributeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllAttributes,
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
			public static readonly global::MetaDslx.Modeling.ModelProperty EAllOperationsProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EAllOperations",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EOperation),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EOperationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EAllOperations,
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
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EStructuralFeature), "EContainingClass")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EStructuralFeaturesProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClass), name: "EStructuralFeatures",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EStructuralFeature),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EStructuralFeatureBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClass_EStructuralFeatures,
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

			public static readonly global::MetaDslx.Modeling.ModelProperty DotNetNameProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "DotNetName",
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_DotNetName,
					defaultValue: null);

			public static readonly global::MetaDslx.Modeling.ModelProperty InstanceClassNameProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "InstanceClassName",
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_InstanceClassName,
					defaultValue: null);

			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty InstanceClassProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "InstanceClass",
					immutableType: typeof(System.Type),
					mutableType: typeof(System.Type),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_InstanceClass,
					defaultValue: null);

			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty DefaultValueProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "DefaultValue",
					immutableType: typeof(object),
					mutableType: typeof(object),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_DefaultValue,
					defaultValue: null);

			public static readonly global::MetaDslx.Modeling.ModelProperty InstanceTypeNameProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "InstanceTypeName",
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_InstanceTypeName,
					defaultValue: null);

			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EPackage), "EClassifiers")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EPackageProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "EPackage",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackage),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_EPackage,
					defaultValue: null);

			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeParametersProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EClassifier), name: "ETypeParameters",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameter),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameterBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EClassifier_ETypeParameters,
					defaultValue: null);
		}

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
		}

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

			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EEnumLiteral), name: "Value",
					immutableType: typeof(int),
					mutableType: typeof(int),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnumLiteral_Value,
					defaultValue: null);

			public static readonly global::MetaDslx.Modeling.ModelProperty InstanceProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EEnumLiteral), name: "Instance",
					immutableType: typeof(System.Collections.IEnumerable),
					mutableType: typeof(System.Collections.IEnumerable),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnumLiteral_Instance,
					defaultValue: null);

			public static readonly global::MetaDslx.Modeling.ModelProperty LiteralProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EEnumLiteral), name: "Literal",
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnumLiteral_Literal,
					defaultValue: null);

			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EEnum), "ELiterals")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EEnumProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EEnumLiteral), name: "EEnum",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EEnum),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EEnumBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EEnumLiteral_EEnum,
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

			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EPackage), "EFactoryInstance")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EPackageProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EFactory), name: "EPackage",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackage),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EFactory_EPackage,
					defaultValue: null);
		}

		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Ecore.Model.Internal.EModelElementId), typeof(global::MetaDslx.Languages.Ecore.Model.EModelElement), typeof(global::MetaDslx.Languages.Ecore.Model.EModelElementBuilder))]
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

		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol))]
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
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ENamedElement_Name,
					defaultValue: null);
		}

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
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_NsURI,
					defaultValue: null);

			public static readonly global::MetaDslx.Modeling.ModelProperty NsPrefixProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "NsPrefix",
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_NsPrefix,
					defaultValue: null);

			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EFactory), "EPackage")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EFactoryInstanceProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "EFactoryInstance",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EFactory),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EFactoryBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_EFactoryInstance,
					defaultValue: null);

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

			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EPackage), "ESuperPackage")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ESubpackagesProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "ESubpackages",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackage),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_ESubpackages,
					defaultValue: null);

			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EPackage), "ESubpackages")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ESuperPackageProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EPackage), name: "ESuperPackage",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackage),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EPackageBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EPackage_ESuperPackage,
					defaultValue: null);
		}

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

			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EReferenceTypeProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EReference), name: "EReferenceType",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClass),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EReference_EReferenceType,
					defaultValue: null);

			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EKeysProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EReference), name: "EKeys",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttribute),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EAttributeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EReference_EKeys,
					defaultValue: null);
		}

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
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_DefaultValueLiteral,
					defaultValue: null);

			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
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

			[global::MetaDslx.Modeling.OppositeAttribute(typeof(EcoreDescriptor.EClass), "EStructuralFeatures")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EContainingClassProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStructuralFeature), name: "EContainingClass",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClass),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStructuralFeature_EContainingClass,
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

			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "EType",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_EType,
					defaultValue: null);

			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EGenericTypeProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ETypedElement), name: "EGenericType",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.ETypedElement_EGenericType,
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
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStringToStringMapEntry_Key,
					defaultValue: null);

			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EStringToStringMapEntry), name: "Value",
					immutableType: typeof(string),
					mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EStringToStringMapEntry_Value,
					defaultValue: null);
		}

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

			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EUpperBoundProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "EUpperBound",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_EUpperBound,
					defaultValue: null);

			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeArgumentsProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "ETypeArguments",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_ETypeArguments,
					defaultValue: null);

			[global::MetaDslx.Modeling.ReadonlyAttribute]
			[global::MetaDslx.Modeling.DerivedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ERawTypeProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "ERawType",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_ERawType,
					defaultValue: null);

			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ELowerBoundProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "ELowerBound",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericType),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EGenericTypeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_ELowerBound,
					defaultValue: null);

			public static readonly global::MetaDslx.Modeling.ModelProperty ETypeParameterProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "ETypeParameter",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameter),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.ETypeParameterBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_ETypeParameter,
					defaultValue: null);

			public static readonly global::MetaDslx.Modeling.ModelProperty EClassifierProperty =
				global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(EGenericType), name: "EClassifier",
					immutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifier),
					mutableType: typeof(global::MetaDslx.Languages.Ecore.Model.EClassifierBuilder),
					metaProperty: () => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.EGenericType_EClassifier,
					defaultValue: null);
		}

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
		private string name0;
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
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool changeable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool volatile0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool transient0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string defaultValueLiteral0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unsettable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool derived0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eContainingClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool iD0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EDataType eAttributeType0;

		internal EAttributeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EAttribute;

		public new EAttributeBuilder ToMutable()
		{
			return (EAttributeBuilder)base.ToMutable();
		}

		public new EAttributeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EAttributeBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
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


		public EClassifier EType
		{
			get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}


		public EGenericType EGenericType
		{
			get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
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


		public string DefaultValueLiteral
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, ref defaultValueLiteral0); }
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


		public EClass EContainingClass
		{
			get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, ref eContainingClass0); }
		}


		public bool ID
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAttribute.IDProperty, ref iD0); }
		}


		public EDataType EAttributeType
		{
			get { return this.GetReference<EDataType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAttribute.EAttributeTypeProperty, ref eAttributeType0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EAttribute;

		public new EAttribute ToImmutable()
		{
			return (EAttribute)base.ToImmutable();
		}

		public new EAttribute ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EAttribute)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
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


		public string DefaultValueLiteral
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, value); }
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeatureBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeature, string> immutableLazy, global::System.Func<EStructuralFeatureBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, immutableLazy, mutableLazy);
		}


		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty); }
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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
		private string source0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EStringToStringMapEntry> details0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EModelElement eModelElement0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EObject> contents0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EObject> references0;

		internal EAnnotationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EAnnotation;

		public new EAnnotationBuilder ToMutable()
		{
			return (EAnnotationBuilder)base.ToMutable();
		}

		public new EAnnotationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EAnnotationBuilder)base.ToMutable(model);
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


		public string Source
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.SourceProperty, ref source0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EStringToStringMapEntry> Details
		{
			get { return this.GetList<EStringToStringMapEntry>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.DetailsProperty, ref details0); }
		}


		public EModelElement EModelElement
		{
			get { return this.GetReference<EModelElement>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.EModelElementProperty, ref eModelElement0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EObject> Contents
		{
			get { return this.GetList<EObject>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.ContentsProperty, ref contents0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EObject> References
		{
			get { return this.GetList<EObject>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.ReferencesProperty, ref references0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EAnnotation;

		public new EAnnotation ToImmutable()
		{
			return (EAnnotation)base.ToImmutable();
		}

		public new EAnnotation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EAnnotation)base.ToImmutable(model);
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


		public string Source
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.SourceProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.SourceProperty, value); }
		}

		void EAnnotationBuilder.SetSourceLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.SourceProperty, lazy);
		}

		void EAnnotationBuilder.SetSourceLazy(global::System.Func<EAnnotationBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.SourceProperty, lazy);
		}

		void EAnnotationBuilder.SetSourceLazy(global::System.Func<EAnnotation, string> immutableLazy, global::System.Func<EAnnotationBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EAnnotation.SourceProperty, immutableLazy, mutableLazy);
		}


		public global::MetaDslx.Modeling.MutableModelList<EStringToStringMapEntryBuilder> Details
		{
			get { return this.GetList<EStringToStringMapEntryBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.DetailsProperty, ref details0); }
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


		public global::MetaDslx.Modeling.MutableModelList<EObjectBuilder> Contents
		{
			get { return this.GetList<EObjectBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.ContentsProperty, ref contents0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EObjectBuilder> References
		{
			get { return this.GetList<EObjectBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EAnnotation.ReferencesProperty, ref references0); }
		}


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string dotNetName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string instanceClassName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type instanceClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string instanceTypeName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool abstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EClass> eSuperTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EOperation> eOperations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAttribute> eAllAttributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EReference> eAllReferences0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EReference> eReferences0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAttribute> eAttributes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EReference> eAllContainments0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EOperation> eAllOperations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> eAllStructuralFeatures0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EClass> eAllSuperTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EAttribute eIDAttribute0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> eStructuralFeatures0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eGenericSuperTypes0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eAllGenericSuperTypes0;

		internal EClassImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EClass;

		public new EClassBuilder ToMutable()
		{
			return (EClassBuilder)base.ToMutable();
		}

		public new EClassBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EClassBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}


		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty, ref dotNetName0); }
		}


		public string InstanceClassName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, ref instanceClassName0); }
		}


		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, ref instanceClass0); }
		}


		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, ref defaultValue0); }
		}


		public string InstanceTypeName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty, ref instanceTypeName0); }
		}


		public EPackage EPackage
		{
			get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, ref ePackage0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
			get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
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


		public global::MetaDslx.Modeling.ImmutableModelList<EOperation> EOperations
		{
			get { return this.GetList<EOperation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EOperationsProperty, ref eOperations0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EAllAttributes
		{
			get { return this.GetList<EAttribute>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllAttributesProperty, ref eAllAttributes0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EReference> EAllReferences
		{
			get { return this.GetList<EReference>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllReferencesProperty, ref eAllReferences0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EReference> EReferences
		{
			get { return this.GetList<EReference>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EReferencesProperty, ref eReferences0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EAttributes
		{
			get { return this.GetList<EAttribute>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAttributesProperty, ref eAttributes0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EReference> EAllContainments
		{
			get { return this.GetList<EReference>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllContainmentsProperty, ref eAllContainments0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EOperation> EAllOperations
		{
			get { return this.GetList<EOperation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllOperationsProperty, ref eAllOperations0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> EAllStructuralFeatures
		{
			get { return this.GetList<EStructuralFeature>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllStructuralFeaturesProperty, ref eAllStructuralFeatures0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EClass> EAllSuperTypes
		{
			get { return this.GetList<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllSuperTypesProperty, ref eAllSuperTypes0); }
		}


		public EAttribute EIDAttribute
		{
			get { return this.GetReference<EAttribute>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EIDAttributeProperty, ref eIDAttribute0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EStructuralFeature> EStructuralFeatures
		{
			get { return this.GetList<EStructuralFeature>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EStructuralFeaturesProperty, ref eStructuralFeatures0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericSuperTypes
		{
			get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EGenericSuperTypesProperty, ref eGenericSuperTypes0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EAllGenericSuperTypes
		{
			get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllGenericSuperTypesProperty, ref eAllGenericSuperTypes0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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


		int EClass.GetFeatureCount()
		{
			return EcoreImplementationProvider.Implementation.EClass_GetFeatureCount(this);
		}


		EStructuralFeature EClass.GetEStructuralFeature(int featureID)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetEStructuralFeature(this, featureID);
		}


		int EClass.GetFeatureID(EStructuralFeature feature)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetFeatureID(this, feature);
		}


		EStructuralFeature EClass.GetEStructuralFeature(string featureName)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetEStructuralFeature(this, featureName);
		}


		int EClass.GetOperationCount()
		{
			return EcoreImplementationProvider.Implementation.EClass_GetOperationCount(this);
		}


		EOperation EClass.GetEOperation(int operationID)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetEOperation(this, operationID);
		}


		int EClass.GetOperationID(EOperation operation)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetOperationID(this, operation);
		}


		EOperation EClass.GetOverride(EOperation operation)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetOverride(this, operation);
		}


		EGenericType EClass.GetFeatureType(EStructuralFeature feature)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetFeatureType(this, feature);
		}
	}

	internal class EClassBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EClassBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> eTypeParameters0;
		private global::MetaDslx.Modeling.MutableModelList<EClassBuilder> eSuperTypes0;
		private global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> eOperations0;
		private global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> eAllAttributes0;
		private global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> eAllReferences0;
		private global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> eReferences0;
		private global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> eAttributes0;
		private global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> eAllContainments0;
		private global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> eAllOperations0;
		private global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> eAllStructuralFeatures0;
		private global::MetaDslx.Modeling.MutableModelList<EClassBuilder> eAllSuperTypes0;
		private global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> eStructuralFeatures0;
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EClass;

		public new EClass ToImmutable()
		{
			return (EClass)base.ToImmutable();
		}

		public new EClass ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EClass)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}


		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty, value); }
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, lazy);
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, lazy);
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, immutableLazy, mutableLazy);
		}


		public string InstanceClassName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, value); }
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, immutableLazy, mutableLazy);
		}


		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty); }
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


		public string InstanceTypeName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty, value); }
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, immutableLazy, mutableLazy);
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


		public global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> EOperations
		{
			get { return this.GetList<EOperationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EOperationsProperty, ref eOperations0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EAllAttributes
		{
			get { return this.GetList<EAttributeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllAttributesProperty, ref eAllAttributes0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EAllReferences
		{
			get { return this.GetList<EReferenceBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllReferencesProperty, ref eAllReferences0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EReferences
		{
			get { return this.GetList<EReferenceBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EReferencesProperty, ref eReferences0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EAttributes
		{
			get { return this.GetList<EAttributeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAttributesProperty, ref eAttributes0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EReferenceBuilder> EAllContainments
		{
			get { return this.GetList<EReferenceBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllContainmentsProperty, ref eAllContainments0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EOperationBuilder> EAllOperations
		{
			get { return this.GetList<EOperationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllOperationsProperty, ref eAllOperations0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> EAllStructuralFeatures
		{
			get { return this.GetList<EStructuralFeatureBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllStructuralFeaturesProperty, ref eAllStructuralFeatures0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EClassBuilder> EAllSuperTypes
		{
			get { return this.GetList<EClassBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllSuperTypesProperty, ref eAllSuperTypes0); }
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


		public global::MetaDslx.Modeling.MutableModelList<EStructuralFeatureBuilder> EStructuralFeatures
		{
			get { return this.GetList<EStructuralFeatureBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EStructuralFeaturesProperty, ref eStructuralFeatures0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericSuperTypes
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EGenericSuperTypesProperty, ref eGenericSuperTypes0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EAllGenericSuperTypes
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClass.EAllGenericSuperTypesProperty, ref eAllGenericSuperTypes0); }
		}


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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


		int EClassBuilder.GetFeatureCount()
		{
			return EcoreImplementationProvider.Implementation.EClass_GetFeatureCount(this);
		}


		EStructuralFeatureBuilder EClassBuilder.GetEStructuralFeature(int featureID)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetEStructuralFeature(this, featureID);
		}


		int EClassBuilder.GetFeatureID(EStructuralFeatureBuilder feature)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetFeatureID(this, feature);
		}


		EStructuralFeatureBuilder EClassBuilder.GetEStructuralFeature(string featureName)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetEStructuralFeature(this, featureName);
		}


		int EClassBuilder.GetOperationCount()
		{
			return EcoreImplementationProvider.Implementation.EClass_GetOperationCount(this);
		}


		EOperationBuilder EClassBuilder.GetEOperation(int operationID)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetEOperation(this, operationID);
		}


		int EClassBuilder.GetOperationID(EOperationBuilder operation)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetOperationID(this, operation);
		}


		EOperationBuilder EClassBuilder.GetOverride(EOperationBuilder operation)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetOverride(this, operation);
		}


		EGenericTypeBuilder EClassBuilder.GetFeatureType(EStructuralFeatureBuilder feature)
		{
			return EcoreImplementationProvider.Implementation.EClass_GetFeatureType(this, feature);
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string dotNetName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string instanceClassName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type instanceClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string instanceTypeName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;

		internal EClassifierImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EClassifier;

		public new EClassifierBuilder ToMutable()
		{
			return (EClassifierBuilder)base.ToMutable();
		}

		public new EClassifierBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EClassifierBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}


		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty, ref dotNetName0); }
		}


		public string InstanceClassName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, ref instanceClassName0); }
		}


		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, ref instanceClass0); }
		}


		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, ref defaultValue0); }
		}


		public string InstanceTypeName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty, ref instanceTypeName0); }
		}


		public EPackage EPackage
		{
			get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, ref ePackage0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
			get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EClassifier;

		public new EClassifier ToImmutable()
		{
			return (EClassifier)base.ToImmutable();
		}

		public new EClassifier ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EClassifier)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}


		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty, value); }
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, lazy);
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, lazy);
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, immutableLazy, mutableLazy);
		}


		public string InstanceClassName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, value); }
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, immutableLazy, mutableLazy);
		}


		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty); }
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


		public string InstanceTypeName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty, value); }
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, immutableLazy, mutableLazy);
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string dotNetName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string instanceClassName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type instanceClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string instanceTypeName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool serializable0;

		internal EDataTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EDataType;

		public new EDataTypeBuilder ToMutable()
		{
			return (EDataTypeBuilder)base.ToMutable();
		}

		public new EDataTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EDataTypeBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}


		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty, ref dotNetName0); }
		}


		public string InstanceClassName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, ref instanceClassName0); }
		}


		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, ref instanceClass0); }
		}


		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, ref defaultValue0); }
		}


		public string InstanceTypeName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty, ref instanceTypeName0); }
		}


		public EPackage EPackage
		{
			get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, ref ePackage0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
			get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}


		public bool Serializable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.SerializableProperty, ref serializable0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EDataType;

		public new EDataType ToImmutable()
		{
			return (EDataType)base.ToImmutable();
		}

		public new EDataType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EDataType)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}


		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty, value); }
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, lazy);
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, lazy);
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, immutableLazy, mutableLazy);
		}


		public string InstanceClassName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, value); }
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, immutableLazy, mutableLazy);
		}


		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty); }
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


		public string InstanceTypeName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty, value); }
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, immutableLazy, mutableLazy);
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string dotNetName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string instanceClassName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type instanceClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string instanceTypeName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage ePackage0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool serializable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EEnumLiteral> eLiterals0;

		internal EEnumImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EEnum;

		public new EEnumBuilder ToMutable()
		{
			return (EEnumBuilder)base.ToMutable();
		}

		public new EEnumBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EEnumBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}


		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty, ref dotNetName0); }
		}


		public string InstanceClassName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, ref instanceClassName0); }
		}


		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty, ref instanceClass0); }
		}


		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DefaultValueProperty, ref defaultValue0); }
		}


		public string InstanceTypeName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty, ref instanceTypeName0); }
		}


		public EPackage EPackage
		{
			get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.EPackageProperty, ref ePackage0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
			get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.ETypeParametersProperty, ref eTypeParameters0); }
		}


		public bool Serializable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EDataType.SerializableProperty, ref serializable0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EEnumLiteral> ELiterals
		{
			get { return this.GetList<EEnumLiteral>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnum.ELiteralsProperty, ref eLiterals0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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


		EEnumLiteral EEnum.GetEEnumLiteral(string name)
		{
			return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteral(this, name);
		}


		EEnumLiteral EEnum.GetEEnumLiteral(int value)
		{
			return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteral(this, value);
		}


		EEnumLiteral EEnum.GetEEnumLiteralByLiteral(string literal)
		{
			return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteralByLiteral(this, literal);
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EEnum;

		public new EEnum ToImmutable()
		{
			return (EEnum)base.ToImmutable();
		}

		public new EEnum ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EEnum)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}


		public string DotNetName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.DotNetNameProperty, value); }
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, lazy);
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, lazy);
		}

		void EClassifierBuilder.SetDotNetNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.DotNetNameProperty, immutableLazy, mutableLazy);
		}


		public string InstanceClassName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassNameProperty, value); }
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceClassNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceClassNameProperty, immutableLazy, mutableLazy);
		}


		public System.Type InstanceClass
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceClassProperty); }
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


		public string InstanceTypeName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EClassifier.InstanceTypeNameProperty, value); }
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<EClassifierBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, lazy);
		}

		void EClassifierBuilder.SetInstanceTypeNameLazy(global::System.Func<EClassifier, string> immutableLazy, global::System.Func<EClassifierBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EClassifier.InstanceTypeNameProperty, immutableLazy, mutableLazy);
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


		public global::MetaDslx.Modeling.MutableModelList<EEnumLiteralBuilder> ELiterals
		{
			get { return this.GetList<EEnumLiteralBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnum.ELiteralsProperty, ref eLiterals0); }
		}


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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


		EEnumLiteralBuilder EEnumBuilder.GetEEnumLiteral(string name)
		{
			return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteral(this, name);
		}


		EEnumLiteralBuilder EEnumBuilder.GetEEnumLiteral(int value)
		{
			return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteral(this, value);
		}


		EEnumLiteralBuilder EEnumBuilder.GetEEnumLiteralByLiteral(string literal)
		{
			return EcoreImplementationProvider.Implementation.EEnum_GetEEnumLiteralByLiteral(this, literal);
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int value0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Collections.IEnumerable instance0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string literal0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EEnum eEnum0;

		internal EEnumLiteralImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EEnumLiteral;

		public new EEnumLiteralBuilder ToMutable()
		{
			return (EEnumLiteralBuilder)base.ToMutable();
		}

		public new EEnumLiteralBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EEnumLiteralBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}


		public int Value
		{
			get { return this.GetValue<int>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.ValueProperty, ref value0); }
		}


		public System.Collections.IEnumerable Instance
		{
			get { return this.GetReference<System.Collections.IEnumerable>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.InstanceProperty, ref instance0); }
		}


		public string Literal
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.LiteralProperty, ref literal0); }
		}


		public EEnum EEnum
		{
			get { return this.GetReference<EEnum>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.EEnumProperty, ref eEnum0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EEnumLiteral;

		public new EEnumLiteral ToImmutable()
		{
			return (EEnumLiteral)base.ToImmutable();
		}

		public new EEnumLiteral ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EEnumLiteral)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
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


		public System.Collections.IEnumerable Instance
		{
			get { return this.GetReference<System.Collections.IEnumerable>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.InstanceProperty); }
			set { this.SetReference<System.Collections.IEnumerable>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.InstanceProperty, value); }
		}

		void EEnumLiteralBuilder.SetInstanceLazy(global::System.Func<System.Collections.IEnumerable> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.InstanceProperty, lazy);
		}

		void EEnumLiteralBuilder.SetInstanceLazy(global::System.Func<EEnumLiteralBuilder, System.Collections.IEnumerable> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.InstanceProperty, lazy);
		}

		void EEnumLiteralBuilder.SetInstanceLazy(global::System.Func<EEnumLiteral, System.Collections.IEnumerable> immutableLazy, global::System.Func<EEnumLiteralBuilder, System.Collections.IEnumerable> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.InstanceProperty, immutableLazy, mutableLazy);
		}


		public string Literal
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.LiteralProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EEnumLiteral.LiteralProperty, value); }
		}

		void EEnumLiteralBuilder.SetLiteralLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.LiteralProperty, lazy);
		}

		void EEnumLiteralBuilder.SetLiteralLazy(global::System.Func<EEnumLiteralBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.LiteralProperty, lazy);
		}

		void EEnumLiteralBuilder.SetLiteralLazy(global::System.Func<EEnumLiteral, string> immutableLazy, global::System.Func<EEnumLiteralBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EEnumLiteral.LiteralProperty, immutableLazy, mutableLazy);
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EFactory;

		public new EFactoryBuilder ToMutable()
		{
			return (EFactoryBuilder)base.ToMutable();
		}

		public new EFactoryBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EFactoryBuilder)base.ToMutable(model);
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


		EAnnotation EModelElement.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}


		EObject EFactory.Create(EClass eClass)
		{
			return EcoreImplementationProvider.Implementation.EFactory_Create(this, eClass);
		}


		object EFactory.CreateFromString(EDataType eDataType, string literalValue)
		{
			return EcoreImplementationProvider.Implementation.EFactory_CreateFromString(this, eDataType, literalValue);
		}


		string EFactory.ConvertToString(EDataType eDataType, object instanceValue)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EFactory;

		public new EFactory ToImmutable()
		{
			return (EFactory)base.ToImmutable();
		}

		public new EFactory ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EFactory)base.ToImmutable(model);
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}


		EObjectBuilder EFactoryBuilder.Create(EClassBuilder eClass)
		{
			return EcoreImplementationProvider.Implementation.EFactory_Create(this, eClass);
		}


		object EFactoryBuilder.CreateFromString(EDataTypeBuilder eDataType, string literalValue)
		{
			return EcoreImplementationProvider.Implementation.EFactory_CreateFromString(this, eDataType, literalValue);
		}


		string EFactoryBuilder.ConvertToString(EDataTypeBuilder eDataType, object instanceValue)
		{
			return EcoreImplementationProvider.Implementation.EFactory_ConvertToString(this, eDataType, instanceValue);
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EModelElement;

		public new EModelElementBuilder ToMutable()
		{
			return (EModelElementBuilder)base.ToMutable();
		}

		public new EModelElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EModelElementBuilder)base.ToMutable(model);
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EAnnotation> EAnnotations
		{
			get { return this.GetList<EAnnotation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EModelElement;

		public new EModelElement ToImmutable()
		{
			return (EModelElement)base.ToImmutable();
		}

		public new EModelElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EModelElement)base.ToImmutable(model);
		}


		public global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> EAnnotations
		{
			get { return this.GetList<EAnnotationBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EModelElement.EAnnotationsProperty, ref eAnnotations0); }
		}


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
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
		private string name0;

		internal ENamedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.ENamedElement;

		public new ENamedElementBuilder ToMutable()
		{
			return (ENamedElementBuilder)base.ToMutable();
		}

		public new ENamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ENamedElementBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.ENamedElement;

		public new ENamedElement ToImmutable()
		{
			return (ENamedElement)base.ToImmutable();
		}

		public new ENamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ENamedElement)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}

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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EObject;

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


		global::System.Collections.Generic.IReadOnlyList<EObject> EObject.EContents()
		{
			return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}


		System.Collections.IEnumerable EObject.EAllContents()
		{
			return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}


		global::System.Collections.Generic.IReadOnlyList<EObject> EObject.ECrossReferences()
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


		void EObject.ESet(EStructuralFeature feature, object newValue)
		{
			EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}


		bool EObject.EIsSet(EStructuralFeature feature)
		{
			return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}


		void EObject.EUnset(EStructuralFeature feature)
		{
			EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}


		object EObject.EInvoke(EOperation operation, global::System.Collections.Generic.IReadOnlyList<object> arguments)
		{
			return EcoreImplementationProvider.Implementation.EObject_EInvoke(this, operation, arguments);
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EObject;

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


		global::System.Collections.Generic.IReadOnlyList<EObjectBuilder> EObjectBuilder.EContents()
		{
			return EcoreImplementationProvider.Implementation.EObject_EContents(this);
		}


		System.Collections.IEnumerable EObjectBuilder.EAllContents()
		{
			return EcoreImplementationProvider.Implementation.EObject_EAllContents(this);
		}


		global::System.Collections.Generic.IReadOnlyList<EObjectBuilder> EObjectBuilder.ECrossReferences()
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


		void EObjectBuilder.ESet(EStructuralFeatureBuilder feature, object newValue)
		{
			EcoreImplementationProvider.Implementation.EObject_ESet(this, feature, newValue);
		}


		bool EObjectBuilder.EIsSet(EStructuralFeatureBuilder feature)
		{
			return EcoreImplementationProvider.Implementation.EObject_EIsSet(this, feature);
		}


		void EObjectBuilder.EUnset(EStructuralFeatureBuilder feature)
		{
			EcoreImplementationProvider.Implementation.EObject_EUnset(this, feature);
		}


		object EObjectBuilder.EInvoke(EOperationBuilder operation, global::System.Collections.Generic.IReadOnlyList<object> arguments)
		{
			return EcoreImplementationProvider.Implementation.EObject_EInvoke(this, operation, arguments);
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
		private string name0;
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
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eContainingClass0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> eTypeParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EParameter> eParameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EClassifier> eExceptions0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eGenericExceptions0;

		internal EOperationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EOperation;

		public new EOperationBuilder ToMutable()
		{
			return (EOperationBuilder)base.ToMutable();
		}

		public new EOperationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EOperationBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
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


		public EClassifier EType
		{
			get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}


		public EGenericType EGenericType
		{
			get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}


		public EClass EContainingClass
		{
			get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EContainingClassProperty, ref eContainingClass0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<ETypeParameter> ETypeParameters
		{
			get { return this.GetList<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.ETypeParametersProperty, ref eTypeParameters0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EParameter> EParameters
		{
			get { return this.GetList<EParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EParametersProperty, ref eParameters0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EClassifier> EExceptions
		{
			get { return this.GetList<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EExceptionsProperty, ref eExceptions0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EGenericExceptions
		{
			get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EGenericExceptionsProperty, ref eGenericExceptions0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}


		int EOperation.GetOperationID()
		{
			return EcoreImplementationProvider.Implementation.EOperation_GetOperationID(this);
		}


		bool EOperation.IsOverrideOf(EOperation someOperation)
		{
			return EcoreImplementationProvider.Implementation.EOperation_IsOverrideOf(this, someOperation);
		}
	}

	internal class EOperationBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EOperationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> eTypeParameters0;
		private global::MetaDslx.Modeling.MutableModelList<EParameterBuilder> eParameters0;
		private global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> eExceptions0;
		private global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> eGenericExceptions0;

		internal EOperationBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}

		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EOperation(this);
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EOperation;

		public new EOperation ToImmutable()
		{
			return (EOperation)base.ToImmutable();
		}

		public new EOperation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EOperation)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
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


		public global::MetaDslx.Modeling.MutableModelList<ETypeParameterBuilder> ETypeParameters
		{
			get { return this.GetList<ETypeParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.ETypeParametersProperty, ref eTypeParameters0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EParameterBuilder> EParameters
		{
			get { return this.GetList<EParameterBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EParametersProperty, ref eParameters0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> EExceptions
		{
			get { return this.GetList<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EExceptionsProperty, ref eExceptions0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EGenericExceptions
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EOperation.EGenericExceptionsProperty, ref eGenericExceptions0); }
		}


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}


		int EOperationBuilder.GetOperationID()
		{
			return EcoreImplementationProvider.Implementation.EOperation_GetOperationID(this);
		}


		bool EOperationBuilder.IsOverrideOf(EOperationBuilder someOperation)
		{
			return EcoreImplementationProvider.Implementation.EOperation_IsOverrideOf(this, someOperation);
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string nsURI0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string nsPrefix0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EFactory eFactoryInstance0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EClassifier> eClassifiers0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EPackage> eSubpackages0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EPackage eSuperPackage0;

		internal EPackageImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EPackage;

		public new EPackageBuilder ToMutable()
		{
			return (EPackageBuilder)base.ToMutable();
		}

		public new EPackageBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EPackageBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}


		public string NsURI
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsURIProperty, ref nsURI0); }
		}


		public string NsPrefix
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsPrefixProperty, ref nsPrefix0); }
		}


		public EFactory EFactoryInstance
		{
			get { return this.GetReference<EFactory>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.EFactoryInstanceProperty, ref eFactoryInstance0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EClassifier> EClassifiers
		{
			get { return this.GetList<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.EClassifiersProperty, ref eClassifiers0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EPackage> ESubpackages
		{
			get { return this.GetList<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.ESubpackagesProperty, ref eSubpackages0); }
		}


		public EPackage ESuperPackage
		{
			get { return this.GetReference<EPackage>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.ESuperPackageProperty, ref eSuperPackage0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}


		EClassifier EPackage.GetEClassifier(string name)
		{
			return EcoreImplementationProvider.Implementation.EPackage_GetEClassifier(this, name);
		}
	}

	internal class EPackageBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EPackageBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> eClassifiers0;
		private global::MetaDslx.Modeling.MutableModelList<EPackageBuilder> eSubpackages0;

		internal EPackageBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}

		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EPackage(this);
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EPackage;

		public new EPackage ToImmutable()
		{
			return (EPackage)base.ToImmutable();
		}

		public new EPackage ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EPackage)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}


		public string NsURI
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsURIProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsURIProperty, value); }
		}

		void EPackageBuilder.SetNsURILazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsURIProperty, lazy);
		}

		void EPackageBuilder.SetNsURILazy(global::System.Func<EPackageBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsURIProperty, lazy);
		}

		void EPackageBuilder.SetNsURILazy(global::System.Func<EPackage, string> immutableLazy, global::System.Func<EPackageBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsURIProperty, immutableLazy, mutableLazy);
		}


		public string NsPrefix
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsPrefixProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.NsPrefixProperty, value); }
		}

		void EPackageBuilder.SetNsPrefixLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsPrefixProperty, lazy);
		}

		void EPackageBuilder.SetNsPrefixLazy(global::System.Func<EPackageBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsPrefixProperty, lazy);
		}

		void EPackageBuilder.SetNsPrefixLazy(global::System.Func<EPackage, string> immutableLazy, global::System.Func<EPackageBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EPackage.NsPrefixProperty, immutableLazy, mutableLazy);
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


		public global::MetaDslx.Modeling.MutableModelList<EClassifierBuilder> EClassifiers
		{
			get { return this.GetList<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.EClassifiersProperty, ref eClassifiers0); }
		}


		public global::MetaDslx.Modeling.MutableModelList<EPackageBuilder> ESubpackages
		{
			get { return this.GetList<EPackageBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EPackage.ESubpackagesProperty, ref eSubpackages0); }
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}


		EClassifierBuilder EPackageBuilder.GetEClassifier(string name)
		{
			return EcoreImplementationProvider.Implementation.EPackage_GetEClassifier(this, name);
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
		private string name0;
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
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EOperation eOperation0;

		internal EParameterImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EParameter;

		public new EParameterBuilder ToMutable()
		{
			return (EParameterBuilder)base.ToMutable();
		}

		public new EParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EParameterBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
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


		public EClassifier EType
		{
			get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}


		public EGenericType EGenericType
		{
			get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}


		public EOperation EOperation
		{
			get { return this.GetReference<EOperation>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EParameter.EOperationProperty, ref eOperation0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EParameter;

		public new EParameter ToImmutable()
		{
			return (EParameter)base.ToImmutable();
		}

		public new EParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EParameter)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
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
		private string name0;
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
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool changeable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool volatile0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool transient0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string defaultValueLiteral0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unsettable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool derived0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eContainingClass0;
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EAttribute> eKeys0;

		internal EReferenceImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EReference;

		public new EReferenceBuilder ToMutable()
		{
			return (EReferenceBuilder)base.ToMutable();
		}

		public new EReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EReferenceBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
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


		public EClassifier EType
		{
			get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}


		public EGenericType EGenericType
		{
			get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
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


		public string DefaultValueLiteral
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, ref defaultValueLiteral0); }
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


		public EClass EContainingClass
		{
			get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, ref eContainingClass0); }
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


		public global::MetaDslx.Modeling.ImmutableModelList<EAttribute> EKeys
		{
			get { return this.GetList<EAttribute>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.EKeysProperty, ref eKeys0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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
		private global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> eKeys0;

		internal EReferenceBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}

		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.EReference(this);
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EReference;

		public new EReference ToImmutable()
		{
			return (EReference)base.ToImmutable();
		}

		public new EReference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EReference)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
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


		public string DefaultValueLiteral
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, value); }
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeatureBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeature, string> immutableLazy, global::System.Func<EStructuralFeatureBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, immutableLazy, mutableLazy);
		}


		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty); }
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


		public global::MetaDslx.Modeling.MutableModelList<EAttributeBuilder> EKeys
		{
			get { return this.GetList<EAttributeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EReference.EKeysProperty, ref eKeys0); }
		}


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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
		private string name0;
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
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool changeable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool volatile0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool transient0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string defaultValueLiteral0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object defaultValue0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool unsettable0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool derived0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClass eContainingClass0;

		internal EStructuralFeatureImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EStructuralFeature;

		public new EStructuralFeatureBuilder ToMutable()
		{
			return (EStructuralFeatureBuilder)base.ToMutable();
		}

		public new EStructuralFeatureBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EStructuralFeatureBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
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


		public EClassifier EType
		{
			get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}


		public EGenericType EGenericType
		{
			get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
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


		public string DefaultValueLiteral
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, ref defaultValueLiteral0); }
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


		public EClass EContainingClass
		{
			get { return this.GetReference<EClass>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.EContainingClassProperty, ref eContainingClass0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EStructuralFeature;

		public new EStructuralFeature ToImmutable()
		{
			return (EStructuralFeature)base.ToImmutable();
		}

		public new EStructuralFeature ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EStructuralFeature)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
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


		public string DefaultValueLiteral
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, value); }
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeatureBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, lazy);
		}

		void EStructuralFeatureBuilder.SetDefaultValueLiteralLazy(global::System.Func<EStructuralFeature, string> immutableLazy, global::System.Func<EStructuralFeatureBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStructuralFeature.DefaultValueLiteralProperty, immutableLazy, mutableLazy);
		}


		public object DefaultValue
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStructuralFeature.DefaultValueProperty); }
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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
		private string name0;
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
		private EClassifier eType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eGenericType0;

		internal ETypedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.ETypedElement;

		public new ETypedElementBuilder ToMutable()
		{
			return (ETypedElementBuilder)base.ToMutable();
		}

		public new ETypedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ETypedElementBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
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


		public EClassifier EType
		{
			get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.ETypeProperty, ref eType0); }
		}


		public EGenericType EGenericType
		{
			get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypedElement.EGenericTypeProperty, ref eGenericType0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.ETypedElement;

		public new ETypedElement ToImmutable()
		{
			return (ETypedElement)base.ToImmutable();
		}

		public new ETypedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ETypedElement)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
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


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
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
		private string key0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string value0;

		internal EStringToStringMapEntryImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EStringToStringMapEntry;

		public new EStringToStringMapEntryBuilder ToMutable()
		{
			return (EStringToStringMapEntryBuilder)base.ToMutable();
		}

		public new EStringToStringMapEntryBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EStringToStringMapEntryBuilder)base.ToMutable(model);
		}


		public string Key
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.KeyProperty, ref key0); }
		}


		public string Value
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.ValueProperty, ref value0); }
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EStringToStringMapEntry;

		public new EStringToStringMapEntry ToImmutable()
		{
			return (EStringToStringMapEntry)base.ToImmutable();
		}

		public new EStringToStringMapEntry ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EStringToStringMapEntry)base.ToImmutable(model);
		}


		public string Key
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.KeyProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.KeyProperty, value); }
		}

		void EStringToStringMapEntryBuilder.SetKeyLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.KeyProperty, lazy);
		}

		void EStringToStringMapEntryBuilder.SetKeyLazy(global::System.Func<EStringToStringMapEntryBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.KeyProperty, lazy);
		}

		void EStringToStringMapEntryBuilder.SetKeyLazy(global::System.Func<EStringToStringMapEntry, string> immutableLazy, global::System.Func<EStringToStringMapEntryBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.KeyProperty, immutableLazy, mutableLazy);
		}


		public string Value
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.ValueProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EStringToStringMapEntry.ValueProperty, value); }
		}

		void EStringToStringMapEntryBuilder.SetValueLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.ValueProperty, lazy);
		}

		void EStringToStringMapEntryBuilder.SetValueLazy(global::System.Func<EStringToStringMapEntryBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.ValueProperty, lazy);
		}

		void EStringToStringMapEntryBuilder.SetValueLazy(global::System.Func<EStringToStringMapEntry, string> immutableLazy, global::System.Func<EStringToStringMapEntryBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.EStringToStringMapEntry.ValueProperty, immutableLazy, mutableLazy);
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
		private EGenericType eUpperBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eTypeArguments0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eRawType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EGenericType eLowerBound0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ETypeParameter eTypeParameter0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EClassifier eClassifier0;

		internal EGenericTypeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EGenericType;

		public new EGenericTypeBuilder ToMutable()
		{
			return (EGenericTypeBuilder)base.ToMutable();
		}

		public new EGenericTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EGenericTypeBuilder)base.ToMutable(model);
		}


		public EGenericType EUpperBound
		{
			get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.EUpperBoundProperty, ref eUpperBound0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> ETypeArguments
		{
			get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ETypeArgumentsProperty, ref eTypeArguments0); }
		}


		public EClassifier ERawType
		{
			get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ERawTypeProperty, ref eRawType0); }
		}


		public EGenericType ELowerBound
		{
			get { return this.GetReference<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ELowerBoundProperty, ref eLowerBound0); }
		}


		public ETypeParameter ETypeParameter
		{
			get { return this.GetReference<ETypeParameter>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ETypeParameterProperty, ref eTypeParameter0); }
		}


		public EClassifier EClassifier
		{
			get { return this.GetReference<EClassifier>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.EClassifierProperty, ref eClassifier0); }
		}


		bool EGenericType.IsInstance(object @object)
		{
			return EcoreImplementationProvider.Implementation.EGenericType_IsInstance(this, @object);
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

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.EGenericType;

		public new EGenericType ToImmutable()
		{
			return (EGenericType)base.ToImmutable();
		}

		public new EGenericType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EGenericType)base.ToImmutable(model);
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


		public EClassifierBuilder ERawType
		{
			get { return this.GetReference<EClassifierBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.EGenericType.ERawTypeProperty); }
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


		bool EGenericTypeBuilder.IsInstance(object @object)
		{
			return EcoreImplementationProvider.Implementation.EGenericType_IsInstance(this, @object);
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EGenericType> eBounds0;

		internal ETypeParameterImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.ETypeParameter;

		public new ETypeParameterBuilder ToMutable()
		{
			return (ETypeParameterBuilder)base.ToMutable();
		}

		public new ETypeParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ETypeParameterBuilder)base.ToMutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, ref name0); }
		}


		public global::MetaDslx.Modeling.ImmutableModelList<EGenericType> EBounds
		{
			get { return this.GetList<EGenericType>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypeParameter.EBoundsProperty, ref eBounds0); }
		}


		EAnnotation EModelElement.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}

	internal class ETypeParameterBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ETypeParameterBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<EAnnotationBuilder> eAnnotations0;
		private global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> eBounds0;

		internal ETypeParameterBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}

		protected override void MInit()
		{
			EcoreImplementationProvider.Implementation.ETypeParameter(this);
		}

		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Ecore.Model.EcoreInstance.MMetadata;

		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => EcoreInstance.ETypeParameter;

		public new ETypeParameter ToImmutable()
		{
			return (ETypeParameter)base.ToImmutable();
		}

		public new ETypeParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ETypeParameter)base.ToImmutable(model);
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


		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ENamedElement.NameProperty, value); }
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, lazy);
		}

		void ENamedElementBuilder.SetNameLazy(global::System.Func<ENamedElement, string> immutableLazy, global::System.Func<ENamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(EcoreDescriptor.ENamedElement.NameProperty, immutableLazy, mutableLazy);
		}


		public global::MetaDslx.Modeling.MutableModelList<EGenericTypeBuilder> EBounds
		{
			get { return this.GetList<EGenericTypeBuilder>(global::MetaDslx.Languages.Ecore.Model.EcoreDescriptor.ETypeParameter.EBoundsProperty, ref eBounds0); }
		}


		EAnnotationBuilder EModelElementBuilder.GetEAnnotation(string source)
		{
			return EcoreImplementationProvider.Implementation.EModelElement_GetEAnnotation(this, source);
		}
	}

	internal class EcoreBuilderInstance
	{
		internal static EcoreBuilderInstance instance = new EcoreBuilderInstance();

		private bool creating;
		private bool created;
		internal global::MetaDslx.Languages.Ecore.Model.EcoreMetadata MMetadata;
		internal global::MetaDslx.Modeling.MutableModel MModel;
		internal global::MetaDslx.Modeling.MutableModelGroup MModelGroup;

		internal EDataTypeBuilder EBigDecimal = null;
		internal EDataTypeBuilder EBigInteger = null;
		internal EDataTypeBuilder EBoolean = null;
		internal EDataTypeBuilder EBooleanObject = null;
		internal EDataTypeBuilder EByte = null;
		internal EDataTypeBuilder EByteArray = null;
		internal EDataTypeBuilder EByteObject = null;
		internal EDataTypeBuilder EChar = null;
		internal EDataTypeBuilder ECharacterObject = null;
		internal EDataTypeBuilder EDate = null;
		internal EDataTypeBuilder EDiagnosticChain = null;
		internal EDataTypeBuilder EDouble = null;
		internal EDataTypeBuilder EDoubleObject = null;
		internal EDataTypeBuilder EEList = null;
		internal EDataTypeBuilder EEnumerator = null;
		internal EDataTypeBuilder EFeatureMap = null;
		internal EDataTypeBuilder EFeatureMapEntry = null;
		internal EDataTypeBuilder EFloat = null;
		internal EDataTypeBuilder EFloatObject = null;
		internal EDataTypeBuilder EInt = null;
		internal EDataTypeBuilder EIntegerObject = null;
		internal EDataTypeBuilder EJavaClass = null;
		internal EDataTypeBuilder EJavaObject = null;
		internal EDataTypeBuilder ELong = null;
		internal EDataTypeBuilder ELongObject = null;
		internal EDataTypeBuilder EMap = null;
		internal EDataTypeBuilder EResource = null;
		internal EDataTypeBuilder EResourceSet = null;
		internal EDataTypeBuilder EShort = null;
		internal EDataTypeBuilder EShortObject = null;
		internal EDataTypeBuilder EString = null;
		internal EDataTypeBuilder ETreeIterator = null;
		internal EDataTypeBuilder EInvocationTargetException = null;

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
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp35;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp36;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp37;
		private global::MetaDslx.Languages.Meta.Model.MetaConstantBuilder __tmp38;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EAttribute;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAttribute_ID;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAttribute_EAttributeType;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EAnnotation;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_Source;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_Details;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_EModelElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_Contents;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EAnnotation_References;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EClass;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_Abstract;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_Interface;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_ESuperTypes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EOperations;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllAttributes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllReferences;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EReferences;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAttributes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllContainments;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllOperations;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllStructuralFeatures;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllSuperTypes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EIDAttribute;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EStructuralFeatures;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EGenericSuperTypes;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClass_EAllGenericSuperTypes;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp42;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp65;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp43;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp44;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp66;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp45;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp67;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp46;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp68;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp47;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp48;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp69;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp49;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp70;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp50;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp71;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp51;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp72;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EClassifier;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_DotNetName;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_InstanceClassName;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_InstanceClass;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_DefaultValue;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_InstanceTypeName;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_EPackage;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EClassifier_ETypeParameters;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp73;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp76;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp74;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EDataType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EDataType_Serializable;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EEnum;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnum_ELiterals;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp77;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp81;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp78;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp82;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp79;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp83;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EEnumLiteral;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnumLiteral_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnumLiteral_Instance;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnumLiteral_Literal;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EEnumLiteral_EEnum;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EFactory;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EFactory_EPackage;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp84;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp87;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp85;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp88;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp89;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp86;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp90;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp91;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EModelElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EModelElement_EAnnotations;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp92;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp94;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ENamedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ENamedElement_Name;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EObject;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp95;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp96;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp97;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp98;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp99;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp100;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp101;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp102;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp103;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp104;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp112;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp105;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp113;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp114;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp106;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp115;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp116;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp107;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp117;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp108;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp118;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp109;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp119;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp120;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EOperation;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EContainingClass;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_ETypeParameters;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EParameters;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EExceptions;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EOperation_EGenericExceptions;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp122;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp123;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp128;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EPackage;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_NsURI;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_NsPrefix;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_EFactoryInstance;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_EClassifiers;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_ESubpackages;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EPackage_ESuperPackage;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp129;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp132;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EParameter;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EParameter_EOperation;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EReference;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_Containment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_Container;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_ResolveProxies;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_EOpposite;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_EReferenceType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EReference_EKeys;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EStructuralFeature;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Changeable;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Volatile;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Transient;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_DefaultValueLiteral;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_DefaultValue;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Unsettable;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_Derived;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStructuralFeature_EContainingClass;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp134;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp135;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ETypedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_Ordered;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_Unique;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_LowerBound;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_UpperBound;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_Many;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_Required;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_EType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypedElement_EGenericType;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EStringToStringMapEntry;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStringToStringMapEntry_Key;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EStringToStringMapEntry_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EGenericType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_EUpperBound;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_ETypeArguments;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_ERawType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_ELowerBound;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_ETypeParameter;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder EGenericType_EClassifier;
		private global::MetaDslx.Languages.Meta.Model.MetaOperationBuilder __tmp136;
		private global::MetaDslx.Languages.Meta.Model.MetaParameterBuilder __tmp138;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ETypeParameter;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ETypeParameter_EBounds;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp39;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp40;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp41;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp52;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp53;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp54;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp55;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp56;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp57;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp58;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp59;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp60;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp61;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp62;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp63;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp64;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp75;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp80;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp93;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp110;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp111;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp121;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp124;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp125;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp126;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp127;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp130;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp131;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp133;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp137;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp139;

		internal EcoreBuilderInstance()
		{
			this.MMetadata = new EcoreMetadata(name: "Ecore", version: new global::MetaDslx.Modeling.ModelVersion(0, 0), uri: "http://www.eclipse.org/emf/2002/Ecore", prefix: "ecore", namespaceName: "MetaDslx.Languages.Ecore.Model");
			this.MModelGroup = new global::MetaDslx.Modeling.MutableModelGroup();
			this.MModelGroup.AddReference(MetaDslx.Languages.Meta.Model.MetaInstance.MModel);
			this.MModel = this.MModelGroup.CreateModel(this.MMetadata);
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

			EBigDecimal = constantFactory.EDataType();
			EBigDecimal.MName = "EBigDecimal";
			EBigDecimal.DotNetName = "System.Decimal";
			EBigInteger = constantFactory.EDataType();
			EBigInteger.MName = "EBigInteger";
			EBigInteger.DotNetName = "System.Numerics.BigInteger";
			EBoolean = constantFactory.EDataType();
			EBoolean.MName = "EBoolean";
			EBoolean.DotNetName = "System.Boolean";
			EBooleanObject = constantFactory.EDataType();
			EBooleanObject.MName = "EBooleanObject";
			EBooleanObject.DotNetName = "bool?";
			EByte = constantFactory.EDataType();
			EByte.MName = "EByte";
			EByte.DotNetName = "System.Byte";
			EByteArray = constantFactory.EDataType();
			EByteArray.MName = "EByteArray";
			EByteArray.DotNetName = "byte[]";
			EByteObject = constantFactory.EDataType();
			EByteObject.MName = "EByteObject";
			EByteObject.DotNetName = "byte?";
			EChar = constantFactory.EDataType();
			EChar.MName = "EChar";
			EChar.DotNetName = "System.Char";
			ECharacterObject = constantFactory.EDataType();
			ECharacterObject.MName = "ECharacterObject";
			ECharacterObject.DotNetName = "char?";
			EDate = constantFactory.EDataType();
			EDate.MName = "EDate";
			EDate.DotNetName = "System.DateTime";
			EDiagnosticChain = constantFactory.EDataType();
			EDouble = constantFactory.EDataType();
			EDouble.MName = "EDouble";
			EDouble.DotNetName = "System.Double";
			EDoubleObject = constantFactory.EDataType();
			EDoubleObject.MName = "EDoubleObject";
			EDoubleObject.DotNetName = "double?";
			EEList = constantFactory.EDataType();
			EEList.MName = "EEList";
			EEList.DotNetName = "System.Collections.Generic.IList`1";
			EEnumerator = constantFactory.EDataType();
			EEnumerator.MName = "EEnumerator";
			EEnumerator.DotNetName = "System.Collections.IEnumerable";
			EFeatureMap = constantFactory.EDataType();
			EFeatureMap.MName = "EFeatureMap";
			EFeatureMap.DotNetName = "System.Collections.Generic.IDictionary<EStructuralFeature,object>";
			EFeatureMapEntry = constantFactory.EDataType();
			EFeatureMapEntry.MName = "EFeatureMapEntry";
			EFeatureMapEntry.DotNetName = "System.Collections.Generic.KeyValuePair<EStructuralFeature,object>";
			EFloat = constantFactory.EDataType();
			EFloat.MName = "EFloat";
			EFloat.DotNetName = "System.Single";
			EFloatObject = constantFactory.EDataType();
			EFloatObject.MName = "EFloatObject";
			EFloatObject.DotNetName = "float?";
			EInt = constantFactory.EDataType();
			EInt.MName = "EInt";
			EInt.DotNetName = "System.Int32";
			EIntegerObject = constantFactory.EDataType();
			EIntegerObject.MName = "EIntegerObject";
			EIntegerObject.DotNetName = "int?";
			EJavaClass = constantFactory.EDataType();
			EJavaClass.MName = "EJavaClass";
			EJavaClass.DotNetName = "System.Type";
			EJavaObject = constantFactory.EDataType();
			EJavaObject.MName = "EJavaObject";
			EJavaObject.DotNetName = "System.Object";
			ELong = constantFactory.EDataType();
			ELong.MName = "ELong";
			ELong.DotNetName = "System.Int64";
			ELongObject = constantFactory.EDataType();
			ELongObject.MName = "ELongObject";
			ELongObject.DotNetName = "long?";
			EMap = constantFactory.EDataType();
			EMap.MName = "EMap";
			EMap.DotNetName = "System.Collections.Generic.IDictionary`2";
			EResource = constantFactory.EDataType();
			EResource.MName = "EResource";
			EResource.DotNetName = "MetaDslx.Modeling.IModel";
			EResourceSet = constantFactory.EDataType();
			EResourceSet.MName = "EResourceSet";
			EResourceSet.DotNetName = "MetaDslx.Modeling.IModelGroup";
			EShort = constantFactory.EDataType();
			EShort.MName = "EShort";
			EShort.DotNetName = "System.Int16";
			EShortObject = constantFactory.EDataType();
			EShortObject.MName = "EShortObject";
			EShortObject.DotNetName = "short?";
			EString = constantFactory.EDataType();
			EString.MName = "EString";
			EString.DotNetName = "System.String";
			ETreeIterator = constantFactory.EDataType();
			ETreeIterator.MName = "ETreeIterator";
			ETreeIterator.DotNetName = "System.Collections.IEnumerable";
			EInvocationTargetException = constantFactory.EDataType();

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
			__tmp35 = factory.MetaConstant();
			__tmp36 = factory.MetaConstant();
			__tmp37 = factory.MetaConstant();
			__tmp38 = factory.MetaConstant();
			EAttribute = factory.MetaClass();
			EAttribute_ID = factory.MetaProperty();
			EAttribute_EAttributeType = factory.MetaProperty();
			EAnnotation = factory.MetaClass();
			EAnnotation_Source = factory.MetaProperty();
			EAnnotation_Details = factory.MetaProperty();
			EAnnotation_EModelElement = factory.MetaProperty();
			EAnnotation_Contents = factory.MetaProperty();
			EAnnotation_References = factory.MetaProperty();
			EClass = factory.MetaClass();
			EClass_Abstract = factory.MetaProperty();
			EClass_Interface = factory.MetaProperty();
			EClass_ESuperTypes = factory.MetaProperty();
			EClass_EOperations = factory.MetaProperty();
			EClass_EAllAttributes = factory.MetaProperty();
			EClass_EAllReferences = factory.MetaProperty();
			EClass_EReferences = factory.MetaProperty();
			EClass_EAttributes = factory.MetaProperty();
			EClass_EAllContainments = factory.MetaProperty();
			EClass_EAllOperations = factory.MetaProperty();
			EClass_EAllStructuralFeatures = factory.MetaProperty();
			EClass_EAllSuperTypes = factory.MetaProperty();
			EClass_EIDAttribute = factory.MetaProperty();
			EClass_EStructuralFeatures = factory.MetaProperty();
			EClass_EGenericSuperTypes = factory.MetaProperty();
			EClass_EAllGenericSuperTypes = factory.MetaProperty();
			__tmp42 = factory.MetaOperation();
			__tmp65 = factory.MetaParameter();
			__tmp43 = factory.MetaOperation();
			__tmp44 = factory.MetaOperation();
			__tmp66 = factory.MetaParameter();
			__tmp45 = factory.MetaOperation();
			__tmp67 = factory.MetaParameter();
			__tmp46 = factory.MetaOperation();
			__tmp68 = factory.MetaParameter();
			__tmp47 = factory.MetaOperation();
			__tmp48 = factory.MetaOperation();
			__tmp69 = factory.MetaParameter();
			__tmp49 = factory.MetaOperation();
			__tmp70 = factory.MetaParameter();
			__tmp50 = factory.MetaOperation();
			__tmp71 = factory.MetaParameter();
			__tmp51 = factory.MetaOperation();
			__tmp72 = factory.MetaParameter();
			EClassifier = factory.MetaClass();
			EClassifier_DotNetName = factory.MetaProperty();
			EClassifier_InstanceClassName = factory.MetaProperty();
			EClassifier_InstanceClass = factory.MetaProperty();
			EClassifier_DefaultValue = factory.MetaProperty();
			EClassifier_InstanceTypeName = factory.MetaProperty();
			EClassifier_EPackage = factory.MetaProperty();
			EClassifier_ETypeParameters = factory.MetaProperty();
			__tmp73 = factory.MetaOperation();
			__tmp76 = factory.MetaParameter();
			__tmp74 = factory.MetaOperation();
			EDataType = factory.MetaClass();
			EDataType_Serializable = factory.MetaProperty();
			EEnum = factory.MetaClass();
			EEnum_ELiterals = factory.MetaProperty();
			__tmp77 = factory.MetaOperation();
			__tmp81 = factory.MetaParameter();
			__tmp78 = factory.MetaOperation();
			__tmp82 = factory.MetaParameter();
			__tmp79 = factory.MetaOperation();
			__tmp83 = factory.MetaParameter();
			EEnumLiteral = factory.MetaClass();
			EEnumLiteral_Value = factory.MetaProperty();
			EEnumLiteral_Instance = factory.MetaProperty();
			EEnumLiteral_Literal = factory.MetaProperty();
			EEnumLiteral_EEnum = factory.MetaProperty();
			EFactory = factory.MetaClass();
			EFactory_EPackage = factory.MetaProperty();
			__tmp84 = factory.MetaOperation();
			__tmp87 = factory.MetaParameter();
			__tmp85 = factory.MetaOperation();
			__tmp88 = factory.MetaParameter();
			__tmp89 = factory.MetaParameter();
			__tmp86 = factory.MetaOperation();
			__tmp90 = factory.MetaParameter();
			__tmp91 = factory.MetaParameter();
			EModelElement = factory.MetaClass();
			EModelElement_EAnnotations = factory.MetaProperty();
			__tmp92 = factory.MetaOperation();
			__tmp94 = factory.MetaParameter();
			ENamedElement = factory.MetaClass();
			ENamedElement_Name = factory.MetaProperty();
			EObject = factory.MetaClass();
			__tmp95 = factory.MetaOperation();
			__tmp96 = factory.MetaOperation();
			__tmp97 = factory.MetaOperation();
			__tmp98 = factory.MetaOperation();
			__tmp99 = factory.MetaOperation();
			__tmp100 = factory.MetaOperation();
			__tmp101 = factory.MetaOperation();
			__tmp102 = factory.MetaOperation();
			__tmp103 = factory.MetaOperation();
			__tmp104 = factory.MetaOperation();
			__tmp112 = factory.MetaParameter();
			__tmp105 = factory.MetaOperation();
			__tmp113 = factory.MetaParameter();
			__tmp114 = factory.MetaParameter();
			__tmp106 = factory.MetaOperation();
			__tmp115 = factory.MetaParameter();
			__tmp116 = factory.MetaParameter();
			__tmp107 = factory.MetaOperation();
			__tmp117 = factory.MetaParameter();
			__tmp108 = factory.MetaOperation();
			__tmp118 = factory.MetaParameter();
			__tmp109 = factory.MetaOperation();
			__tmp119 = factory.MetaParameter();
			__tmp120 = factory.MetaParameter();
			EOperation = factory.MetaClass();
			EOperation_EContainingClass = factory.MetaProperty();
			EOperation_ETypeParameters = factory.MetaProperty();
			EOperation_EParameters = factory.MetaProperty();
			EOperation_EExceptions = factory.MetaProperty();
			EOperation_EGenericExceptions = factory.MetaProperty();
			__tmp122 = factory.MetaOperation();
			__tmp123 = factory.MetaOperation();
			__tmp128 = factory.MetaParameter();
			EPackage = factory.MetaClass();
			EPackage_NsURI = factory.MetaProperty();
			EPackage_NsPrefix = factory.MetaProperty();
			EPackage_EFactoryInstance = factory.MetaProperty();
			EPackage_EClassifiers = factory.MetaProperty();
			EPackage_ESubpackages = factory.MetaProperty();
			EPackage_ESuperPackage = factory.MetaProperty();
			__tmp129 = factory.MetaOperation();
			__tmp132 = factory.MetaParameter();
			EParameter = factory.MetaClass();
			EParameter_EOperation = factory.MetaProperty();
			EReference = factory.MetaClass();
			EReference_Containment = factory.MetaProperty();
			EReference_Container = factory.MetaProperty();
			EReference_ResolveProxies = factory.MetaProperty();
			EReference_EOpposite = factory.MetaProperty();
			EReference_EReferenceType = factory.MetaProperty();
			EReference_EKeys = factory.MetaProperty();
			EStructuralFeature = factory.MetaClass();
			EStructuralFeature_Changeable = factory.MetaProperty();
			EStructuralFeature_Volatile = factory.MetaProperty();
			EStructuralFeature_Transient = factory.MetaProperty();
			EStructuralFeature_DefaultValueLiteral = factory.MetaProperty();
			EStructuralFeature_DefaultValue = factory.MetaProperty();
			EStructuralFeature_Unsettable = factory.MetaProperty();
			EStructuralFeature_Derived = factory.MetaProperty();
			EStructuralFeature_EContainingClass = factory.MetaProperty();
			__tmp134 = factory.MetaOperation();
			__tmp135 = factory.MetaOperation();
			ETypedElement = factory.MetaClass();
			ETypedElement_Ordered = factory.MetaProperty();
			ETypedElement_Unique = factory.MetaProperty();
			ETypedElement_LowerBound = factory.MetaProperty();
			ETypedElement_UpperBound = factory.MetaProperty();
			ETypedElement_Many = factory.MetaProperty();
			ETypedElement_Required = factory.MetaProperty();
			ETypedElement_EType = factory.MetaProperty();
			ETypedElement_EGenericType = factory.MetaProperty();
			EStringToStringMapEntry = factory.MetaClass();
			EStringToStringMapEntry_Key = factory.MetaProperty();
			EStringToStringMapEntry_Value = factory.MetaProperty();
			EGenericType = factory.MetaClass();
			EGenericType_EUpperBound = factory.MetaProperty();
			EGenericType_ETypeArguments = factory.MetaProperty();
			EGenericType_ERawType = factory.MetaProperty();
			EGenericType_ELowerBound = factory.MetaProperty();
			EGenericType_ETypeParameter = factory.MetaProperty();
			EGenericType_EClassifier = factory.MetaProperty();
			__tmp136 = factory.MetaOperation();
			__tmp138 = factory.MetaParameter();
			ETypeParameter = factory.MetaClass();
			ETypeParameter_EBounds = factory.MetaProperty();
			__tmp39 = factory.MetaCollectionType();
			__tmp40 = factory.MetaCollectionType();
			__tmp41 = factory.MetaCollectionType();
			__tmp52 = factory.MetaCollectionType();
			__tmp53 = factory.MetaCollectionType();
			__tmp54 = factory.MetaCollectionType();
			__tmp55 = factory.MetaCollectionType();
			__tmp56 = factory.MetaCollectionType();
			__tmp57 = factory.MetaCollectionType();
			__tmp58 = factory.MetaCollectionType();
			__tmp59 = factory.MetaCollectionType();
			__tmp60 = factory.MetaCollectionType();
			__tmp61 = factory.MetaCollectionType();
			__tmp62 = factory.MetaCollectionType();
			__tmp63 = factory.MetaCollectionType();
			__tmp64 = factory.MetaCollectionType();
			__tmp75 = factory.MetaCollectionType();
			__tmp80 = factory.MetaCollectionType();
			__tmp93 = factory.MetaCollectionType();
			__tmp110 = factory.MetaCollectionType();
			__tmp111 = factory.MetaCollectionType();
			__tmp121 = factory.MetaCollectionType();
			__tmp124 = factory.MetaCollectionType();
			__tmp125 = factory.MetaCollectionType();
			__tmp126 = factory.MetaCollectionType();
			__tmp127 = factory.MetaCollectionType();
			__tmp130 = factory.MetaCollectionType();
			__tmp131 = factory.MetaCollectionType();
			__tmp133 = factory.MetaCollectionType();
			__tmp137 = factory.MetaCollectionType();
			__tmp139 = factory.MetaCollectionType();

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
			__tmp4.Declarations.AddLazy(() => __tmp35);
			__tmp4.Declarations.AddLazy(() => __tmp36);
			__tmp4.Declarations.AddLazy(() => __tmp37);
			__tmp4.Declarations.AddLazy(() => __tmp38);
			__tmp4.Declarations.AddLazy(() => EAttribute);
			__tmp4.Declarations.AddLazy(() => EAnnotation);
			__tmp4.Declarations.AddLazy(() => EClass);
			__tmp4.Declarations.AddLazy(() => EClassifier);
			__tmp4.Declarations.AddLazy(() => EDataType);
			__tmp4.Declarations.AddLazy(() => EEnum);
			__tmp4.Declarations.AddLazy(() => EEnumLiteral);
			__tmp4.Declarations.AddLazy(() => EFactory);
			__tmp4.Declarations.AddLazy(() => EModelElement);
			__tmp4.Declarations.AddLazy(() => ENamedElement);
			__tmp4.Declarations.AddLazy(() => EObject);
			__tmp4.Declarations.AddLazy(() => EOperation);
			__tmp4.Declarations.AddLazy(() => EPackage);
			__tmp4.Declarations.AddLazy(() => EParameter);
			__tmp4.Declarations.AddLazy(() => EReference);
			__tmp4.Declarations.AddLazy(() => EStructuralFeature);
			__tmp4.Declarations.AddLazy(() => ETypedElement);
			__tmp4.Declarations.AddLazy(() => EStringToStringMapEntry);
			__tmp4.Declarations.AddLazy(() => EGenericType);
			__tmp4.Declarations.AddLazy(() => ETypeParameter);
			__tmp5.Documentation = null;
			__tmp5.Name = "Ecore";
			__tmp5.MajorVersion = 0;
			__tmp5.MinorVersion = 0;
			__tmp5.Uri = "http://www.eclipse.org/emf/2002/Ecore";
			__tmp5.Prefix = "ecore";
			__tmp5.SetNamespaceLazy(() => __tmp4);
			__tmp6.SetTypeLazy(() => EDataType);
			__tmp6.Documentation = null;
			__tmp6.Name = "EBigDecimal";
			__tmp6.SetNamespaceLazy(() => __tmp4);
			__tmp6.DotNetName = "System.Decimal";
			__tmp6.SetValueLazy(() => EBigDecimal);
			__tmp7.SetTypeLazy(() => EDataType);
			__tmp7.Documentation = null;
			__tmp7.Name = "EBigInteger";
			__tmp7.SetNamespaceLazy(() => __tmp4);
			__tmp7.DotNetName = "System.Numerics.BigInteger";
			__tmp7.SetValueLazy(() => EBigInteger);
			__tmp8.SetTypeLazy(() => EDataType);
			__tmp8.Documentation = null;
			__tmp8.Name = "EBoolean";
			__tmp8.SetNamespaceLazy(() => __tmp4);
			__tmp8.DotNetName = "System.Boolean";
			__tmp8.SetValueLazy(() => EBoolean);
			__tmp9.SetTypeLazy(() => EDataType);
			__tmp9.Documentation = null;
			__tmp9.Name = "EBooleanObject";
			__tmp9.SetNamespaceLazy(() => __tmp4);
			__tmp9.DotNetName = "bool?";
			__tmp9.SetValueLazy(() => EBooleanObject);
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
			__tmp12.Name = "EByteObject";
			__tmp12.SetNamespaceLazy(() => __tmp4);
			__tmp12.DotNetName = "byte?";
			__tmp12.SetValueLazy(() => EByteObject);
			__tmp13.SetTypeLazy(() => EDataType);
			__tmp13.Documentation = null;
			__tmp13.Name = "EChar";
			__tmp13.SetNamespaceLazy(() => __tmp4);
			__tmp13.DotNetName = "System.Char";
			__tmp13.SetValueLazy(() => EChar);
			__tmp14.SetTypeLazy(() => EDataType);
			__tmp14.Documentation = null;
			__tmp14.Name = "ECharacterObject";
			__tmp14.SetNamespaceLazy(() => __tmp4);
			__tmp14.DotNetName = "char?";
			__tmp14.SetValueLazy(() => ECharacterObject);
			__tmp15.SetTypeLazy(() => EDataType);
			__tmp15.Documentation = null;
			__tmp15.Name = "EDate";
			__tmp15.SetNamespaceLazy(() => __tmp4);
			__tmp15.DotNetName = "System.DateTime";
			__tmp15.SetValueLazy(() => EDate);
			__tmp16.SetTypeLazy(() => EDataType);
			__tmp16.Documentation = null;
			__tmp16.Name = "EDiagnosticChain";
			__tmp16.SetNamespaceLazy(() => __tmp4);
			__tmp16.DotNetName = null;
			__tmp16.SetValueLazy(() => EDiagnosticChain);
			__tmp17.SetTypeLazy(() => EDataType);
			__tmp17.Documentation = null;
			__tmp17.Name = "EDouble";
			__tmp17.SetNamespaceLazy(() => __tmp4);
			__tmp17.DotNetName = "System.Double";
			__tmp17.SetValueLazy(() => EDouble);
			__tmp18.SetTypeLazy(() => EDataType);
			__tmp18.Documentation = null;
			__tmp18.Name = "EDoubleObject";
			__tmp18.SetNamespaceLazy(() => __tmp4);
			__tmp18.DotNetName = "double?";
			__tmp18.SetValueLazy(() => EDoubleObject);
			__tmp19.SetTypeLazy(() => EDataType);
			__tmp19.Documentation = null;
			__tmp19.Name = "EEList";
			__tmp19.SetNamespaceLazy(() => __tmp4);
			__tmp19.DotNetName = "System.Collections.Generic.IList`1";
			__tmp19.SetValueLazy(() => EEList);
			__tmp20.SetTypeLazy(() => EDataType);
			__tmp20.Documentation = null;
			__tmp20.Name = "EEnumerator";
			__tmp20.SetNamespaceLazy(() => __tmp4);
			__tmp20.DotNetName = "System.Collections.IEnumerable";
			__tmp20.SetValueLazy(() => EEnumerator);
			__tmp21.SetTypeLazy(() => EDataType);
			__tmp21.Documentation = null;
			__tmp21.Name = "EFeatureMap";
			__tmp21.SetNamespaceLazy(() => __tmp4);
			__tmp21.DotNetName = "System.Collections.Generic.IDictionary<EStructuralFeature,object>";
			__tmp21.SetValueLazy(() => EFeatureMap);
			__tmp22.SetTypeLazy(() => EDataType);
			__tmp22.Documentation = null;
			__tmp22.Name = "EFeatureMapEntry";
			__tmp22.SetNamespaceLazy(() => __tmp4);
			__tmp22.DotNetName = "System.Collections.Generic.KeyValuePair<EStructuralFeature,object>";
			__tmp22.SetValueLazy(() => EFeatureMapEntry);
			__tmp23.SetTypeLazy(() => EDataType);
			__tmp23.Documentation = null;
			__tmp23.Name = "EFloat";
			__tmp23.SetNamespaceLazy(() => __tmp4);
			__tmp23.DotNetName = "System.Single";
			__tmp23.SetValueLazy(() => EFloat);
			__tmp24.SetTypeLazy(() => EDataType);
			__tmp24.Documentation = null;
			__tmp24.Name = "EFloatObject";
			__tmp24.SetNamespaceLazy(() => __tmp4);
			__tmp24.DotNetName = "float?";
			__tmp24.SetValueLazy(() => EFloatObject);
			__tmp25.SetTypeLazy(() => EDataType);
			__tmp25.Documentation = null;
			__tmp25.Name = "EInt";
			__tmp25.SetNamespaceLazy(() => __tmp4);
			__tmp25.DotNetName = "System.Int32";
			__tmp25.SetValueLazy(() => EInt);
			__tmp26.SetTypeLazy(() => EDataType);
			__tmp26.Documentation = null;
			__tmp26.Name = "EIntegerObject";
			__tmp26.SetNamespaceLazy(() => __tmp4);
			__tmp26.DotNetName = "int?";
			__tmp26.SetValueLazy(() => EIntegerObject);
			__tmp27.SetTypeLazy(() => EDataType);
			__tmp27.Documentation = null;
			__tmp27.Name = "EJavaClass";
			__tmp27.SetNamespaceLazy(() => __tmp4);
			__tmp27.DotNetName = "System.Type";
			__tmp27.SetValueLazy(() => EJavaClass);
			__tmp28.SetTypeLazy(() => EDataType);
			__tmp28.Documentation = null;
			__tmp28.Name = "EJavaObject";
			__tmp28.SetNamespaceLazy(() => __tmp4);
			__tmp28.DotNetName = "System.Object";
			__tmp28.SetValueLazy(() => EJavaObject);
			__tmp29.SetTypeLazy(() => EDataType);
			__tmp29.Documentation = null;
			__tmp29.Name = "ELong";
			__tmp29.SetNamespaceLazy(() => __tmp4);
			__tmp29.DotNetName = "System.Int64";
			__tmp29.SetValueLazy(() => ELong);
			__tmp30.SetTypeLazy(() => EDataType);
			__tmp30.Documentation = null;
			__tmp30.Name = "ELongObject";
			__tmp30.SetNamespaceLazy(() => __tmp4);
			__tmp30.DotNetName = "long?";
			__tmp30.SetValueLazy(() => ELongObject);
			__tmp31.SetTypeLazy(() => EDataType);
			__tmp31.Documentation = null;
			__tmp31.Name = "EMap";
			__tmp31.SetNamespaceLazy(() => __tmp4);
			__tmp31.DotNetName = "System.Collections.Generic.IDictionary`2";
			__tmp31.SetValueLazy(() => EMap);
			__tmp32.SetTypeLazy(() => EDataType);
			__tmp32.Documentation = null;
			__tmp32.Name = "EResource";
			__tmp32.SetNamespaceLazy(() => __tmp4);
			__tmp32.DotNetName = "MetaDslx.Modeling.IModel";
			__tmp32.SetValueLazy(() => EResource);
			__tmp33.SetTypeLazy(() => EDataType);
			__tmp33.Documentation = null;
			__tmp33.Name = "EResourceSet";
			__tmp33.SetNamespaceLazy(() => __tmp4);
			__tmp33.DotNetName = "MetaDslx.Modeling.IModelGroup";
			__tmp33.SetValueLazy(() => EResourceSet);
			__tmp34.SetTypeLazy(() => EDataType);
			__tmp34.Documentation = null;
			__tmp34.Name = "EShort";
			__tmp34.SetNamespaceLazy(() => __tmp4);
			__tmp34.DotNetName = "System.Int16";
			__tmp34.SetValueLazy(() => EShort);
			__tmp35.SetTypeLazy(() => EDataType);
			__tmp35.Documentation = null;
			__tmp35.Name = "EShortObject";
			__tmp35.SetNamespaceLazy(() => __tmp4);
			__tmp35.DotNetName = "short?";
			__tmp35.SetValueLazy(() => EShortObject);
			__tmp36.SetTypeLazy(() => EDataType);
			__tmp36.Documentation = null;
			__tmp36.Name = "EString";
			__tmp36.SetNamespaceLazy(() => __tmp4);
			__tmp36.DotNetName = "System.String";
			__tmp36.SetValueLazy(() => EString);
			__tmp37.SetTypeLazy(() => EDataType);
			__tmp37.Documentation = null;
			__tmp37.Name = "ETreeIterator";
			__tmp37.SetNamespaceLazy(() => __tmp4);
			__tmp37.DotNetName = "System.Collections.IEnumerable";
			__tmp37.SetValueLazy(() => ETreeIterator);
			__tmp38.SetTypeLazy(() => EDataType);
			__tmp38.Documentation = null;
			__tmp38.Name = "EInvocationTargetException";
			__tmp38.SetNamespaceLazy(() => __tmp4);
			__tmp38.DotNetName = null;
			__tmp38.SetValueLazy(() => EInvocationTargetException);
			EAttribute.Documentation = null;
			EAttribute.Name = "EAttribute";
			EAttribute.SetNamespaceLazy(() => __tmp4);
			EAttribute.SymbolType = null;
			EAttribute.IsAbstract = false;
			EAttribute.SuperClasses.AddLazy(() => EStructuralFeature);
			EAttribute.Properties.AddLazy(() => EAttribute_ID);
			EAttribute.Properties.AddLazy(() => EAttribute_EAttributeType);
			EAttribute_ID.SetTypeLazy(() => __tmp8);
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
			EAnnotation.Documentation = null;
			EAnnotation.Name = "EAnnotation";
			EAnnotation.SetNamespaceLazy(() => __tmp4);
			EAnnotation.SymbolType = null;
			EAnnotation.IsAbstract = false;
			EAnnotation.SuperClasses.AddLazy(() => EModelElement);
			EAnnotation.Properties.AddLazy(() => EAnnotation_Source);
			EAnnotation.Properties.AddLazy(() => EAnnotation_Details);
			EAnnotation.Properties.AddLazy(() => EAnnotation_EModelElement);
			EAnnotation.Properties.AddLazy(() => EAnnotation_Contents);
			EAnnotation.Properties.AddLazy(() => EAnnotation_References);
			EAnnotation_Source.SetTypeLazy(() => __tmp36);
			EAnnotation_Source.Documentation = null;
			EAnnotation_Source.Name = "Source";
			EAnnotation_Source.SymbolProperty = null;
			EAnnotation_Source.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_Source.SetClassLazy(() => EAnnotation);
			EAnnotation_Source.DefaultValue = null;
			EAnnotation_Source.IsContainment = false;
			EAnnotation_Details.SetTypeLazy(() => __tmp39);
			EAnnotation_Details.Documentation = null;
			EAnnotation_Details.Name = "Details";
			EAnnotation_Details.SymbolProperty = null;
			EAnnotation_Details.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_Details.SetClassLazy(() => EAnnotation);
			EAnnotation_Details.DefaultValue = null;
			EAnnotation_Details.IsContainment = true;
			EAnnotation_EModelElement.SetTypeLazy(() => EModelElement);
			EAnnotation_EModelElement.Documentation = null;
			EAnnotation_EModelElement.Name = "EModelElement";
			EAnnotation_EModelElement.SymbolProperty = null;
			EAnnotation_EModelElement.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_EModelElement.SetClassLazy(() => EAnnotation);
			EAnnotation_EModelElement.DefaultValue = null;
			EAnnotation_EModelElement.IsContainment = false;
			EAnnotation_EModelElement.OppositeProperties.AddLazy(() => EModelElement_EAnnotations);
			EAnnotation_Contents.SetTypeLazy(() => __tmp40);
			EAnnotation_Contents.Documentation = null;
			EAnnotation_Contents.Name = "Contents";
			EAnnotation_Contents.SymbolProperty = null;
			EAnnotation_Contents.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_Contents.SetClassLazy(() => EAnnotation);
			EAnnotation_Contents.DefaultValue = null;
			EAnnotation_Contents.IsContainment = true;
			EAnnotation_References.SetTypeLazy(() => __tmp41);
			EAnnotation_References.Documentation = null;
			EAnnotation_References.Name = "References";
			EAnnotation_References.SymbolProperty = null;
			EAnnotation_References.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EAnnotation_References.SetClassLazy(() => EAnnotation);
			EAnnotation_References.DefaultValue = null;
			EAnnotation_References.IsContainment = false;
			EClass.Documentation = null;
			EClass.Name = "EClass";
			EClass.SetNamespaceLazy(() => __tmp4);
			EClass.SymbolType = null;
			EClass.IsAbstract = false;
			EClass.SuperClasses.AddLazy(() => EClassifier);
			EClass.Properties.AddLazy(() => EClass_Abstract);
			EClass.Properties.AddLazy(() => EClass_Interface);
			EClass.Properties.AddLazy(() => EClass_ESuperTypes);
			EClass.Properties.AddLazy(() => EClass_EOperations);
			EClass.Properties.AddLazy(() => EClass_EAllAttributes);
			EClass.Properties.AddLazy(() => EClass_EAllReferences);
			EClass.Properties.AddLazy(() => EClass_EReferences);
			EClass.Properties.AddLazy(() => EClass_EAttributes);
			EClass.Properties.AddLazy(() => EClass_EAllContainments);
			EClass.Properties.AddLazy(() => EClass_EAllOperations);
			EClass.Properties.AddLazy(() => EClass_EAllStructuralFeatures);
			EClass.Properties.AddLazy(() => EClass_EAllSuperTypes);
			EClass.Properties.AddLazy(() => EClass_EIDAttribute);
			EClass.Properties.AddLazy(() => EClass_EStructuralFeatures);
			EClass.Properties.AddLazy(() => EClass_EGenericSuperTypes);
			EClass.Properties.AddLazy(() => EClass_EAllGenericSuperTypes);
			EClass.Operations.AddLazy(() => __tmp42);
			EClass.Operations.AddLazy(() => __tmp43);
			EClass.Operations.AddLazy(() => __tmp44);
			EClass.Operations.AddLazy(() => __tmp45);
			EClass.Operations.AddLazy(() => __tmp46);
			EClass.Operations.AddLazy(() => __tmp47);
			EClass.Operations.AddLazy(() => __tmp48);
			EClass.Operations.AddLazy(() => __tmp49);
			EClass.Operations.AddLazy(() => __tmp50);
			EClass.Operations.AddLazy(() => __tmp51);
			EClass_Abstract.SetTypeLazy(() => __tmp8);
			EClass_Abstract.Documentation = null;
			EClass_Abstract.Name = "Abstract";
			EClass_Abstract.SymbolProperty = null;
			EClass_Abstract.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_Abstract.SetClassLazy(() => EClass);
			EClass_Abstract.DefaultValue = null;
			EClass_Abstract.IsContainment = false;
			EClass_Interface.SetTypeLazy(() => __tmp8);
			EClass_Interface.Documentation = null;
			EClass_Interface.Name = "Interface";
			EClass_Interface.SymbolProperty = null;
			EClass_Interface.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_Interface.SetClassLazy(() => EClass);
			EClass_Interface.DefaultValue = null;
			EClass_Interface.IsContainment = false;
			EClass_ESuperTypes.SetTypeLazy(() => __tmp52);
			EClass_ESuperTypes.Documentation = null;
			EClass_ESuperTypes.Name = "ESuperTypes";
			EClass_ESuperTypes.SymbolProperty = null;
			EClass_ESuperTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_ESuperTypes.SetClassLazy(() => EClass);
			EClass_ESuperTypes.DefaultValue = null;
			EClass_ESuperTypes.IsContainment = false;
			EClass_EOperations.SetTypeLazy(() => __tmp53);
			EClass_EOperations.Documentation = null;
			EClass_EOperations.Name = "EOperations";
			EClass_EOperations.SymbolProperty = null;
			EClass_EOperations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_EOperations.SetClassLazy(() => EClass);
			EClass_EOperations.DefaultValue = null;
			EClass_EOperations.IsContainment = true;
			EClass_EOperations.OppositeProperties.AddLazy(() => EOperation_EContainingClass);
			EClass_EAllAttributes.SetTypeLazy(() => __tmp54);
			EClass_EAllAttributes.Documentation = null;
			EClass_EAllAttributes.Name = "EAllAttributes";
			EClass_EAllAttributes.SymbolProperty = null;
			EClass_EAllAttributes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllAttributes.SetClassLazy(() => EClass);
			EClass_EAllAttributes.DefaultValue = null;
			EClass_EAllAttributes.IsContainment = false;
			EClass_EAllReferences.SetTypeLazy(() => __tmp55);
			EClass_EAllReferences.Documentation = null;
			EClass_EAllReferences.Name = "EAllReferences";
			EClass_EAllReferences.SymbolProperty = null;
			EClass_EAllReferences.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllReferences.SetClassLazy(() => EClass);
			EClass_EAllReferences.DefaultValue = null;
			EClass_EAllReferences.IsContainment = false;
			EClass_EReferences.SetTypeLazy(() => __tmp56);
			EClass_EReferences.Documentation = null;
			EClass_EReferences.Name = "EReferences";
			EClass_EReferences.SymbolProperty = null;
			EClass_EReferences.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EReferences.SetClassLazy(() => EClass);
			EClass_EReferences.DefaultValue = null;
			EClass_EReferences.IsContainment = false;
			EClass_EAttributes.SetTypeLazy(() => __tmp57);
			EClass_EAttributes.Documentation = null;
			EClass_EAttributes.Name = "EAttributes";
			EClass_EAttributes.SymbolProperty = null;
			EClass_EAttributes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAttributes.SetClassLazy(() => EClass);
			EClass_EAttributes.DefaultValue = null;
			EClass_EAttributes.IsContainment = false;
			EClass_EAllContainments.SetTypeLazy(() => __tmp58);
			EClass_EAllContainments.Documentation = null;
			EClass_EAllContainments.Name = "EAllContainments";
			EClass_EAllContainments.SymbolProperty = null;
			EClass_EAllContainments.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllContainments.SetClassLazy(() => EClass);
			EClass_EAllContainments.DefaultValue = null;
			EClass_EAllContainments.IsContainment = false;
			EClass_EAllOperations.SetTypeLazy(() => __tmp59);
			EClass_EAllOperations.Documentation = null;
			EClass_EAllOperations.Name = "EAllOperations";
			EClass_EAllOperations.SymbolProperty = null;
			EClass_EAllOperations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllOperations.SetClassLazy(() => EClass);
			EClass_EAllOperations.DefaultValue = null;
			EClass_EAllOperations.IsContainment = false;
			EClass_EAllStructuralFeatures.SetTypeLazy(() => __tmp60);
			EClass_EAllStructuralFeatures.Documentation = null;
			EClass_EAllStructuralFeatures.Name = "EAllStructuralFeatures";
			EClass_EAllStructuralFeatures.SymbolProperty = null;
			EClass_EAllStructuralFeatures.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllStructuralFeatures.SetClassLazy(() => EClass);
			EClass_EAllStructuralFeatures.DefaultValue = null;
			EClass_EAllStructuralFeatures.IsContainment = false;
			EClass_EAllSuperTypes.SetTypeLazy(() => __tmp61);
			EClass_EAllSuperTypes.Documentation = null;
			EClass_EAllSuperTypes.Name = "EAllSuperTypes";
			EClass_EAllSuperTypes.SymbolProperty = null;
			EClass_EAllSuperTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllSuperTypes.SetClassLazy(() => EClass);
			EClass_EAllSuperTypes.DefaultValue = null;
			EClass_EAllSuperTypes.IsContainment = false;
			EClass_EIDAttribute.SetTypeLazy(() => EAttribute);
			EClass_EIDAttribute.Documentation = null;
			EClass_EIDAttribute.Name = "EIDAttribute";
			EClass_EIDAttribute.SymbolProperty = null;
			EClass_EIDAttribute.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EIDAttribute.SetClassLazy(() => EClass);
			EClass_EIDAttribute.DefaultValue = null;
			EClass_EIDAttribute.IsContainment = false;
			EClass_EStructuralFeatures.SetTypeLazy(() => __tmp62);
			EClass_EStructuralFeatures.Documentation = null;
			EClass_EStructuralFeatures.Name = "EStructuralFeatures";
			EClass_EStructuralFeatures.SymbolProperty = null;
			EClass_EStructuralFeatures.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_EStructuralFeatures.SetClassLazy(() => EClass);
			EClass_EStructuralFeatures.DefaultValue = null;
			EClass_EStructuralFeatures.IsContainment = true;
			EClass_EStructuralFeatures.OppositeProperties.AddLazy(() => EStructuralFeature_EContainingClass);
			EClass_EGenericSuperTypes.SetTypeLazy(() => __tmp63);
			EClass_EGenericSuperTypes.Documentation = null;
			EClass_EGenericSuperTypes.Name = "EGenericSuperTypes";
			EClass_EGenericSuperTypes.SymbolProperty = null;
			EClass_EGenericSuperTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClass_EGenericSuperTypes.SetClassLazy(() => EClass);
			EClass_EGenericSuperTypes.DefaultValue = null;
			EClass_EGenericSuperTypes.IsContainment = true;
			EClass_EAllGenericSuperTypes.SetTypeLazy(() => __tmp64);
			EClass_EAllGenericSuperTypes.Documentation = null;
			EClass_EAllGenericSuperTypes.Name = "EAllGenericSuperTypes";
			EClass_EAllGenericSuperTypes.SymbolProperty = null;
			EClass_EAllGenericSuperTypes.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClass_EAllGenericSuperTypes.SetClassLazy(() => EClass);
			EClass_EAllGenericSuperTypes.DefaultValue = null;
			EClass_EAllGenericSuperTypes.IsContainment = false;
			__tmp42.Documentation = null;
			__tmp42.Name = "IsSuperTypeOf";
			__tmp42.SetClassLazy(() => EClass);
			// __tmp42.Enum = null;
			__tmp42.IsBuilder = false;
			__tmp42.IsReadonly = false;
			__tmp42.Parameters.AddLazy(() => __tmp65);
			__tmp42.SetReturnTypeLazy(() => __tmp8);
			__tmp65.SetTypeLazy(() => EClass);
			__tmp65.Documentation = null;
			__tmp65.Name = "someClass";
			__tmp65.SetOperationLazy(() => __tmp42);
			__tmp43.Documentation = null;
			__tmp43.Name = "GetFeatureCount";
			__tmp43.SetClassLazy(() => EClass);
			// __tmp43.Enum = null;
			__tmp43.IsBuilder = false;
			__tmp43.IsReadonly = false;
			__tmp43.SetReturnTypeLazy(() => __tmp25);
			__tmp44.Documentation = null;
			__tmp44.Name = "GetEStructuralFeature";
			__tmp44.SetClassLazy(() => EClass);
			// __tmp44.Enum = null;
			__tmp44.IsBuilder = false;
			__tmp44.IsReadonly = false;
			__tmp44.Parameters.AddLazy(() => __tmp66);
			__tmp44.SetReturnTypeLazy(() => EStructuralFeature);
			__tmp66.SetTypeLazy(() => __tmp25);
			__tmp66.Documentation = null;
			__tmp66.Name = "featureID";
			__tmp66.SetOperationLazy(() => __tmp44);
			__tmp45.Documentation = null;
			__tmp45.Name = "GetFeatureID";
			__tmp45.SetClassLazy(() => EClass);
			// __tmp45.Enum = null;
			__tmp45.IsBuilder = false;
			__tmp45.IsReadonly = false;
			__tmp45.Parameters.AddLazy(() => __tmp67);
			__tmp45.SetReturnTypeLazy(() => __tmp25);
			__tmp67.SetTypeLazy(() => EStructuralFeature);
			__tmp67.Documentation = null;
			__tmp67.Name = "feature";
			__tmp67.SetOperationLazy(() => __tmp45);
			__tmp46.Documentation = null;
			__tmp46.Name = "GetEStructuralFeature";
			__tmp46.SetClassLazy(() => EClass);
			// __tmp46.Enum = null;
			__tmp46.IsBuilder = false;
			__tmp46.IsReadonly = false;
			__tmp46.Parameters.AddLazy(() => __tmp68);
			__tmp46.SetReturnTypeLazy(() => EStructuralFeature);
			__tmp68.SetTypeLazy(() => __tmp36);
			__tmp68.Documentation = null;
			__tmp68.Name = "featureName";
			__tmp68.SetOperationLazy(() => __tmp46);
			__tmp47.Documentation = null;
			__tmp47.Name = "GetOperationCount";
			__tmp47.SetClassLazy(() => EClass);
			// __tmp47.Enum = null;
			__tmp47.IsBuilder = false;
			__tmp47.IsReadonly = false;
			__tmp47.SetReturnTypeLazy(() => __tmp25);
			__tmp48.Documentation = null;
			__tmp48.Name = "GetEOperation";
			__tmp48.SetClassLazy(() => EClass);
			// __tmp48.Enum = null;
			__tmp48.IsBuilder = false;
			__tmp48.IsReadonly = false;
			__tmp48.Parameters.AddLazy(() => __tmp69);
			__tmp48.SetReturnTypeLazy(() => EOperation);
			__tmp69.SetTypeLazy(() => __tmp25);
			__tmp69.Documentation = null;
			__tmp69.Name = "operationID";
			__tmp69.SetOperationLazy(() => __tmp48);
			__tmp49.Documentation = null;
			__tmp49.Name = "GetOperationID";
			__tmp49.SetClassLazy(() => EClass);
			// __tmp49.Enum = null;
			__tmp49.IsBuilder = false;
			__tmp49.IsReadonly = false;
			__tmp49.Parameters.AddLazy(() => __tmp70);
			__tmp49.SetReturnTypeLazy(() => __tmp25);
			__tmp70.SetTypeLazy(() => EOperation);
			__tmp70.Documentation = null;
			__tmp70.Name = "operation";
			__tmp70.SetOperationLazy(() => __tmp49);
			__tmp50.Documentation = null;
			__tmp50.Name = "GetOverride";
			__tmp50.SetClassLazy(() => EClass);
			// __tmp50.Enum = null;
			__tmp50.IsBuilder = false;
			__tmp50.IsReadonly = false;
			__tmp50.Parameters.AddLazy(() => __tmp71);
			__tmp50.SetReturnTypeLazy(() => EOperation);
			__tmp71.SetTypeLazy(() => EOperation);
			__tmp71.Documentation = null;
			__tmp71.Name = "operation";
			__tmp71.SetOperationLazy(() => __tmp50);
			__tmp51.Documentation = null;
			__tmp51.Name = "GetFeatureType";
			__tmp51.SetClassLazy(() => EClass);
			// __tmp51.Enum = null;
			__tmp51.IsBuilder = false;
			__tmp51.IsReadonly = false;
			__tmp51.Parameters.AddLazy(() => __tmp72);
			__tmp51.SetReturnTypeLazy(() => EGenericType);
			__tmp72.SetTypeLazy(() => EStructuralFeature);
			__tmp72.Documentation = null;
			__tmp72.Name = "feature";
			__tmp72.SetOperationLazy(() => __tmp51);
			EClassifier.Documentation = null;
			EClassifier.Name = "EClassifier";
			EClassifier.SetNamespaceLazy(() => __tmp4);
			EClassifier.SymbolType = null;
			EClassifier.IsAbstract = true;
			EClassifier.SuperClasses.AddLazy(() => ENamedElement);
			EClassifier.Properties.AddLazy(() => EClassifier_DotNetName);
			EClassifier.Properties.AddLazy(() => EClassifier_InstanceClassName);
			EClassifier.Properties.AddLazy(() => EClassifier_InstanceClass);
			EClassifier.Properties.AddLazy(() => EClassifier_DefaultValue);
			EClassifier.Properties.AddLazy(() => EClassifier_InstanceTypeName);
			EClassifier.Properties.AddLazy(() => EClassifier_EPackage);
			EClassifier.Properties.AddLazy(() => EClassifier_ETypeParameters);
			EClassifier.Operations.AddLazy(() => __tmp73);
			EClassifier.Operations.AddLazy(() => __tmp74);
			EClassifier_DotNetName.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			EClassifier_DotNetName.Documentation = null;
			EClassifier_DotNetName.Name = "DotNetName";
			EClassifier_DotNetName.SymbolProperty = null;
			EClassifier_DotNetName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_DotNetName.SetClassLazy(() => EClassifier);
			EClassifier_DotNetName.DefaultValue = null;
			EClassifier_DotNetName.IsContainment = false;
			EClassifier_InstanceClassName.SetTypeLazy(() => __tmp36);
			EClassifier_InstanceClassName.Documentation = null;
			EClassifier_InstanceClassName.Name = "InstanceClassName";
			EClassifier_InstanceClassName.SymbolProperty = null;
			EClassifier_InstanceClassName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_InstanceClassName.SetClassLazy(() => EClassifier);
			EClassifier_InstanceClassName.DefaultValue = null;
			EClassifier_InstanceClassName.IsContainment = false;
			EClassifier_InstanceClass.SetTypeLazy(() => __tmp27);
			EClassifier_InstanceClass.Documentation = null;
			EClassifier_InstanceClass.Name = "InstanceClass";
			EClassifier_InstanceClass.SymbolProperty = null;
			EClassifier_InstanceClass.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClassifier_InstanceClass.SetClassLazy(() => EClassifier);
			EClassifier_InstanceClass.DefaultValue = null;
			EClassifier_InstanceClass.IsContainment = false;
			EClassifier_DefaultValue.SetTypeLazy(() => __tmp28);
			EClassifier_DefaultValue.Documentation = null;
			EClassifier_DefaultValue.Name = "DefaultValue";
			EClassifier_DefaultValue.SymbolProperty = null;
			EClassifier_DefaultValue.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EClassifier_DefaultValue.SetClassLazy(() => EClassifier);
			EClassifier_DefaultValue.DefaultValue = null;
			EClassifier_DefaultValue.IsContainment = false;
			EClassifier_InstanceTypeName.SetTypeLazy(() => __tmp36);
			EClassifier_InstanceTypeName.Documentation = null;
			EClassifier_InstanceTypeName.Name = "InstanceTypeName";
			EClassifier_InstanceTypeName.SymbolProperty = null;
			EClassifier_InstanceTypeName.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_InstanceTypeName.SetClassLazy(() => EClassifier);
			EClassifier_InstanceTypeName.DefaultValue = null;
			EClassifier_InstanceTypeName.IsContainment = false;
			EClassifier_EPackage.SetTypeLazy(() => EPackage);
			EClassifier_EPackage.Documentation = null;
			EClassifier_EPackage.Name = "EPackage";
			EClassifier_EPackage.SymbolProperty = null;
			EClassifier_EPackage.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_EPackage.SetClassLazy(() => EClassifier);
			EClassifier_EPackage.DefaultValue = null;
			EClassifier_EPackage.IsContainment = false;
			EClassifier_EPackage.OppositeProperties.AddLazy(() => EPackage_EClassifiers);
			EClassifier_ETypeParameters.SetTypeLazy(() => __tmp75);
			EClassifier_ETypeParameters.Documentation = null;
			EClassifier_ETypeParameters.Name = "ETypeParameters";
			EClassifier_ETypeParameters.SymbolProperty = null;
			EClassifier_ETypeParameters.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EClassifier_ETypeParameters.SetClassLazy(() => EClassifier);
			EClassifier_ETypeParameters.DefaultValue = null;
			EClassifier_ETypeParameters.IsContainment = true;
			__tmp73.Documentation = null;
			__tmp73.Name = "IsInstance";
			__tmp73.SetClassLazy(() => EClassifier);
			// __tmp73.Enum = null;
			__tmp73.IsBuilder = false;
			__tmp73.IsReadonly = false;
			__tmp73.Parameters.AddLazy(() => __tmp76);
			__tmp73.SetReturnTypeLazy(() => __tmp8);
			__tmp76.SetTypeLazy(() => __tmp28);
			__tmp76.Documentation = null;
			__tmp76.Name = "@object";
			__tmp76.SetOperationLazy(() => __tmp73);
			__tmp74.Documentation = null;
			__tmp74.Name = "GetClassifierID";
			__tmp74.SetClassLazy(() => EClassifier);
			// __tmp74.Enum = null;
			__tmp74.IsBuilder = false;
			__tmp74.IsReadonly = false;
			__tmp74.SetReturnTypeLazy(() => __tmp25);
			EDataType.Documentation = null;
			EDataType.Name = "EDataType";
			EDataType.SetNamespaceLazy(() => __tmp4);
			EDataType.SymbolType = null;
			EDataType.IsAbstract = false;
			EDataType.SuperClasses.AddLazy(() => EClassifier);
			EDataType.Properties.AddLazy(() => EDataType_Serializable);
			EDataType_Serializable.SetTypeLazy(() => __tmp8);
			EDataType_Serializable.Documentation = null;
			EDataType_Serializable.Name = "Serializable";
			EDataType_Serializable.SymbolProperty = null;
			EDataType_Serializable.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EDataType_Serializable.SetClassLazy(() => EDataType);
			EDataType_Serializable.DefaultValue = "true";
			EDataType_Serializable.IsContainment = false;
			EEnum.Documentation = null;
			EEnum.Name = "EEnum";
			EEnum.SetNamespaceLazy(() => __tmp4);
			EEnum.SymbolType = null;
			EEnum.IsAbstract = false;
			EEnum.SuperClasses.AddLazy(() => EDataType);
			EEnum.Properties.AddLazy(() => EEnum_ELiterals);
			EEnum.Operations.AddLazy(() => __tmp77);
			EEnum.Operations.AddLazy(() => __tmp78);
			EEnum.Operations.AddLazy(() => __tmp79);
			EEnum_ELiterals.SetTypeLazy(() => __tmp80);
			EEnum_ELiterals.Documentation = null;
			EEnum_ELiterals.Name = "ELiterals";
			EEnum_ELiterals.SymbolProperty = null;
			EEnum_ELiterals.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnum_ELiterals.SetClassLazy(() => EEnum);
			EEnum_ELiterals.DefaultValue = null;
			EEnum_ELiterals.IsContainment = true;
			EEnum_ELiterals.OppositeProperties.AddLazy(() => EEnumLiteral_EEnum);
			__tmp77.Documentation = null;
			__tmp77.Name = "GetEEnumLiteral";
			__tmp77.SetClassLazy(() => EEnum);
			// __tmp77.Enum = null;
			__tmp77.IsBuilder = false;
			__tmp77.IsReadonly = false;
			__tmp77.Parameters.AddLazy(() => __tmp81);
			__tmp77.SetReturnTypeLazy(() => EEnumLiteral);
			__tmp81.SetTypeLazy(() => __tmp36);
			__tmp81.Documentation = null;
			__tmp81.Name = "name";
			__tmp81.SetOperationLazy(() => __tmp77);
			__tmp78.Documentation = null;
			__tmp78.Name = "GetEEnumLiteral";
			__tmp78.SetClassLazy(() => EEnum);
			// __tmp78.Enum = null;
			__tmp78.IsBuilder = false;
			__tmp78.IsReadonly = false;
			__tmp78.Parameters.AddLazy(() => __tmp82);
			__tmp78.SetReturnTypeLazy(() => EEnumLiteral);
			__tmp82.SetTypeLazy(() => __tmp25);
			__tmp82.Documentation = null;
			__tmp82.Name = "value";
			__tmp82.SetOperationLazy(() => __tmp78);
			__tmp79.Documentation = null;
			__tmp79.Name = "GetEEnumLiteralByLiteral";
			__tmp79.SetClassLazy(() => EEnum);
			// __tmp79.Enum = null;
			__tmp79.IsBuilder = false;
			__tmp79.IsReadonly = false;
			__tmp79.Parameters.AddLazy(() => __tmp83);
			__tmp79.SetReturnTypeLazy(() => EEnumLiteral);
			__tmp83.SetTypeLazy(() => __tmp36);
			__tmp83.Documentation = null;
			__tmp83.Name = "literal";
			__tmp83.SetOperationLazy(() => __tmp79);
			EEnumLiteral.Documentation = null;
			EEnumLiteral.Name = "EEnumLiteral";
			EEnumLiteral.SetNamespaceLazy(() => __tmp4);
			EEnumLiteral.SymbolType = null;
			EEnumLiteral.IsAbstract = false;
			EEnumLiteral.SuperClasses.AddLazy(() => ENamedElement);
			EEnumLiteral.Properties.AddLazy(() => EEnumLiteral_Value);
			EEnumLiteral.Properties.AddLazy(() => EEnumLiteral_Instance);
			EEnumLiteral.Properties.AddLazy(() => EEnumLiteral_Literal);
			EEnumLiteral.Properties.AddLazy(() => EEnumLiteral_EEnum);
			EEnumLiteral_Value.SetTypeLazy(() => __tmp25);
			EEnumLiteral_Value.Documentation = null;
			EEnumLiteral_Value.Name = "Value";
			EEnumLiteral_Value.SymbolProperty = null;
			EEnumLiteral_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnumLiteral_Value.SetClassLazy(() => EEnumLiteral);
			EEnumLiteral_Value.DefaultValue = null;
			EEnumLiteral_Value.IsContainment = false;
			EEnumLiteral_Instance.SetTypeLazy(() => __tmp20);
			EEnumLiteral_Instance.Documentation = null;
			EEnumLiteral_Instance.Name = "Instance";
			EEnumLiteral_Instance.SymbolProperty = null;
			EEnumLiteral_Instance.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnumLiteral_Instance.SetClassLazy(() => EEnumLiteral);
			EEnumLiteral_Instance.DefaultValue = null;
			EEnumLiteral_Instance.IsContainment = false;
			EEnumLiteral_Literal.SetTypeLazy(() => __tmp36);
			EEnumLiteral_Literal.Documentation = null;
			EEnumLiteral_Literal.Name = "Literal";
			EEnumLiteral_Literal.SymbolProperty = null;
			EEnumLiteral_Literal.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnumLiteral_Literal.SetClassLazy(() => EEnumLiteral);
			EEnumLiteral_Literal.DefaultValue = null;
			EEnumLiteral_Literal.IsContainment = false;
			EEnumLiteral_EEnum.SetTypeLazy(() => EEnum);
			EEnumLiteral_EEnum.Documentation = null;
			EEnumLiteral_EEnum.Name = "EEnum";
			EEnumLiteral_EEnum.SymbolProperty = null;
			EEnumLiteral_EEnum.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EEnumLiteral_EEnum.SetClassLazy(() => EEnumLiteral);
			EEnumLiteral_EEnum.DefaultValue = null;
			EEnumLiteral_EEnum.IsContainment = false;
			EEnumLiteral_EEnum.OppositeProperties.AddLazy(() => EEnum_ELiterals);
			EFactory.Documentation = null;
			EFactory.Name = "EFactory";
			EFactory.SetNamespaceLazy(() => __tmp4);
			EFactory.SymbolType = null;
			EFactory.IsAbstract = false;
			EFactory.SuperClasses.AddLazy(() => EModelElement);
			EFactory.Properties.AddLazy(() => EFactory_EPackage);
			EFactory.Operations.AddLazy(() => __tmp84);
			EFactory.Operations.AddLazy(() => __tmp85);
			EFactory.Operations.AddLazy(() => __tmp86);
			EFactory_EPackage.SetTypeLazy(() => EPackage);
			EFactory_EPackage.Documentation = null;
			EFactory_EPackage.Name = "EPackage";
			EFactory_EPackage.SymbolProperty = null;
			EFactory_EPackage.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EFactory_EPackage.SetClassLazy(() => EFactory);
			EFactory_EPackage.DefaultValue = null;
			EFactory_EPackage.IsContainment = false;
			EFactory_EPackage.OppositeProperties.AddLazy(() => EPackage_EFactoryInstance);
			__tmp84.Documentation = null;
			__tmp84.Name = "Create";
			__tmp84.SetClassLazy(() => EFactory);
			// __tmp84.Enum = null;
			__tmp84.IsBuilder = false;
			__tmp84.IsReadonly = false;
			__tmp84.Parameters.AddLazy(() => __tmp87);
			__tmp84.SetReturnTypeLazy(() => EObject);
			__tmp87.SetTypeLazy(() => EClass);
			__tmp87.Documentation = null;
			__tmp87.Name = "eClass";
			__tmp87.SetOperationLazy(() => __tmp84);
			__tmp85.Documentation = null;
			__tmp85.Name = "CreateFromString";
			__tmp85.SetClassLazy(() => EFactory);
			// __tmp85.Enum = null;
			__tmp85.IsBuilder = false;
			__tmp85.IsReadonly = false;
			__tmp85.Parameters.AddLazy(() => __tmp88);
			__tmp85.Parameters.AddLazy(() => __tmp89);
			__tmp85.SetReturnTypeLazy(() => __tmp28);
			__tmp88.SetTypeLazy(() => EDataType);
			__tmp88.Documentation = null;
			__tmp88.Name = "eDataType";
			__tmp88.SetOperationLazy(() => __tmp85);
			__tmp89.SetTypeLazy(() => __tmp36);
			__tmp89.Documentation = null;
			__tmp89.Name = "literalValue";
			__tmp89.SetOperationLazy(() => __tmp85);
			__tmp86.Documentation = null;
			__tmp86.Name = "ConvertToString";
			__tmp86.SetClassLazy(() => EFactory);
			// __tmp86.Enum = null;
			__tmp86.IsBuilder = false;
			__tmp86.IsReadonly = false;
			__tmp86.Parameters.AddLazy(() => __tmp90);
			__tmp86.Parameters.AddLazy(() => __tmp91);
			__tmp86.SetReturnTypeLazy(() => __tmp36);
			__tmp90.SetTypeLazy(() => EDataType);
			__tmp90.Documentation = null;
			__tmp90.Name = "eDataType";
			__tmp90.SetOperationLazy(() => __tmp86);
			__tmp91.SetTypeLazy(() => __tmp28);
			__tmp91.Documentation = null;
			__tmp91.Name = "instanceValue";
			__tmp91.SetOperationLazy(() => __tmp86);
			EModelElement.Documentation = null;
			EModelElement.Name = "EModelElement";
			EModelElement.SetNamespaceLazy(() => __tmp4);
			EModelElement.SymbolType = null;
			EModelElement.IsAbstract = true;
			EModelElement.Properties.AddLazy(() => EModelElement_EAnnotations);
			EModelElement.Operations.AddLazy(() => __tmp92);
			EModelElement_EAnnotations.SetTypeLazy(() => __tmp93);
			EModelElement_EAnnotations.Documentation = null;
			EModelElement_EAnnotations.Name = "EAnnotations";
			EModelElement_EAnnotations.SymbolProperty = null;
			EModelElement_EAnnotations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EModelElement_EAnnotations.SetClassLazy(() => EModelElement);
			EModelElement_EAnnotations.DefaultValue = null;
			EModelElement_EAnnotations.IsContainment = true;
			EModelElement_EAnnotations.OppositeProperties.AddLazy(() => EAnnotation_EModelElement);
			__tmp92.Documentation = null;
			__tmp92.Name = "GetEAnnotation";
			__tmp92.SetClassLazy(() => EModelElement);
			// __tmp92.Enum = null;
			__tmp92.IsBuilder = false;
			__tmp92.IsReadonly = false;
			__tmp92.Parameters.AddLazy(() => __tmp94);
			__tmp92.SetReturnTypeLazy(() => EAnnotation);
			__tmp94.SetTypeLazy(() => __tmp36);
			__tmp94.Documentation = null;
			__tmp94.Name = "source";
			__tmp94.SetOperationLazy(() => __tmp92);
			ENamedElement.Documentation = null;
			ENamedElement.Name = "ENamedElement";
			ENamedElement.SetNamespaceLazy(() => __tmp4);
			ENamedElement.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol);
			ENamedElement.IsAbstract = true;
			ENamedElement.SuperClasses.AddLazy(() => EModelElement);
			ENamedElement.Properties.AddLazy(() => ENamedElement_Name);
			ENamedElement_Name.SetTypeLazy(() => __tmp36);
			ENamedElement_Name.Documentation = null;
			ENamedElement_Name.Name = "Name";
			ENamedElement_Name.SymbolProperty = "Name";
			ENamedElement_Name.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ENamedElement_Name.SetClassLazy(() => ENamedElement);
			ENamedElement_Name.DefaultValue = null;
			ENamedElement_Name.IsContainment = false;
			EObject.Documentation = null;
			EObject.Name = "EObject";
			EObject.SetNamespaceLazy(() => __tmp4);
			EObject.SymbolType = null;
			EObject.IsAbstract = false;
			EObject.Operations.AddLazy(() => __tmp95);
			EObject.Operations.AddLazy(() => __tmp96);
			EObject.Operations.AddLazy(() => __tmp97);
			EObject.Operations.AddLazy(() => __tmp98);
			EObject.Operations.AddLazy(() => __tmp99);
			EObject.Operations.AddLazy(() => __tmp100);
			EObject.Operations.AddLazy(() => __tmp101);
			EObject.Operations.AddLazy(() => __tmp102);
			EObject.Operations.AddLazy(() => __tmp103);
			EObject.Operations.AddLazy(() => __tmp104);
			EObject.Operations.AddLazy(() => __tmp105);
			EObject.Operations.AddLazy(() => __tmp106);
			EObject.Operations.AddLazy(() => __tmp107);
			EObject.Operations.AddLazy(() => __tmp108);
			EObject.Operations.AddLazy(() => __tmp109);
			__tmp95.Documentation = null;
			__tmp95.Name = "EClass";
			__tmp95.SetClassLazy(() => EObject);
			// __tmp95.Enum = null;
			__tmp95.IsBuilder = false;
			__tmp95.IsReadonly = false;
			__tmp95.SetReturnTypeLazy(() => EClass);
			__tmp96.Documentation = null;
			__tmp96.Name = "EIsProxy";
			__tmp96.SetClassLazy(() => EObject);
			// __tmp96.Enum = null;
			__tmp96.IsBuilder = false;
			__tmp96.IsReadonly = false;
			__tmp96.SetReturnTypeLazy(() => __tmp8);
			__tmp97.Documentation = null;
			__tmp97.Name = "EResource";
			__tmp97.SetClassLazy(() => EObject);
			// __tmp97.Enum = null;
			__tmp97.IsBuilder = false;
			__tmp97.IsReadonly = false;
			__tmp97.SetReturnTypeLazy(() => __tmp32);
			__tmp98.Documentation = null;
			__tmp98.Name = "EContainer";
			__tmp98.SetClassLazy(() => EObject);
			// __tmp98.Enum = null;
			__tmp98.IsBuilder = false;
			__tmp98.IsReadonly = false;
			__tmp98.SetReturnTypeLazy(() => EObject);
			__tmp99.Documentation = null;
			__tmp99.Name = "EContainingFeature";
			__tmp99.SetClassLazy(() => EObject);
			// __tmp99.Enum = null;
			__tmp99.IsBuilder = false;
			__tmp99.IsReadonly = false;
			__tmp99.SetReturnTypeLazy(() => EStructuralFeature);
			__tmp100.Documentation = null;
			__tmp100.Name = "EContainmentFeature";
			__tmp100.SetClassLazy(() => EObject);
			// __tmp100.Enum = null;
			__tmp100.IsBuilder = false;
			__tmp100.IsReadonly = false;
			__tmp100.SetReturnTypeLazy(() => EReference);
			__tmp101.Documentation = null;
			__tmp101.Name = "EContents";
			__tmp101.SetClassLazy(() => EObject);
			// __tmp101.Enum = null;
			__tmp101.IsBuilder = false;
			__tmp101.IsReadonly = false;
			__tmp101.SetReturnTypeLazy(() => __tmp110);
			__tmp102.Documentation = null;
			__tmp102.Name = "EAllContents";
			__tmp102.SetClassLazy(() => EObject);
			// __tmp102.Enum = null;
			__tmp102.IsBuilder = false;
			__tmp102.IsReadonly = false;
			__tmp102.SetReturnTypeLazy(() => __tmp37);
			__tmp103.Documentation = null;
			__tmp103.Name = "ECrossReferences";
			__tmp103.SetClassLazy(() => EObject);
			// __tmp103.Enum = null;
			__tmp103.IsBuilder = false;
			__tmp103.IsReadonly = false;
			__tmp103.SetReturnTypeLazy(() => __tmp111);
			__tmp104.Documentation = null;
			__tmp104.Name = "EGet";
			__tmp104.SetClassLazy(() => EObject);
			// __tmp104.Enum = null;
			__tmp104.IsBuilder = false;
			__tmp104.IsReadonly = false;
			__tmp104.Parameters.AddLazy(() => __tmp112);
			__tmp104.SetReturnTypeLazy(() => __tmp28);
			__tmp112.SetTypeLazy(() => EStructuralFeature);
			__tmp112.Documentation = null;
			__tmp112.Name = "feature";
			__tmp112.SetOperationLazy(() => __tmp104);
			__tmp105.Documentation = null;
			__tmp105.Name = "EGet";
			__tmp105.SetClassLazy(() => EObject);
			// __tmp105.Enum = null;
			__tmp105.IsBuilder = false;
			__tmp105.IsReadonly = false;
			__tmp105.Parameters.AddLazy(() => __tmp113);
			__tmp105.Parameters.AddLazy(() => __tmp114);
			__tmp105.SetReturnTypeLazy(() => __tmp28);
			__tmp113.SetTypeLazy(() => EStructuralFeature);
			__tmp113.Documentation = null;
			__tmp113.Name = "feature";
			__tmp113.SetOperationLazy(() => __tmp105);
			__tmp114.SetTypeLazy(() => __tmp8);
			__tmp114.Documentation = null;
			__tmp114.Name = "resolve";
			__tmp114.SetOperationLazy(() => __tmp105);
			__tmp106.Documentation = null;
			__tmp106.Name = "ESet";
			__tmp106.SetClassLazy(() => EObject);
			// __tmp106.Enum = null;
			__tmp106.IsBuilder = false;
			__tmp106.IsReadonly = false;
			__tmp106.Parameters.AddLazy(() => __tmp115);
			__tmp106.Parameters.AddLazy(() => __tmp116);
			__tmp106.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Void.ToMutable());
			__tmp115.SetTypeLazy(() => EStructuralFeature);
			__tmp115.Documentation = null;
			__tmp115.Name = "feature";
			__tmp115.SetOperationLazy(() => __tmp106);
			__tmp116.SetTypeLazy(() => __tmp28);
			__tmp116.Documentation = null;
			__tmp116.Name = "newValue";
			__tmp116.SetOperationLazy(() => __tmp106);
			__tmp107.Documentation = null;
			__tmp107.Name = "EIsSet";
			__tmp107.SetClassLazy(() => EObject);
			// __tmp107.Enum = null;
			__tmp107.IsBuilder = false;
			__tmp107.IsReadonly = false;
			__tmp107.Parameters.AddLazy(() => __tmp117);
			__tmp107.SetReturnTypeLazy(() => __tmp8);
			__tmp117.SetTypeLazy(() => EStructuralFeature);
			__tmp117.Documentation = null;
			__tmp117.Name = "feature";
			__tmp117.SetOperationLazy(() => __tmp107);
			__tmp108.Documentation = null;
			__tmp108.Name = "EUnset";
			__tmp108.SetClassLazy(() => EObject);
			// __tmp108.Enum = null;
			__tmp108.IsBuilder = false;
			__tmp108.IsReadonly = false;
			__tmp108.Parameters.AddLazy(() => __tmp118);
			__tmp108.SetReturnTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Void.ToMutable());
			__tmp118.SetTypeLazy(() => EStructuralFeature);
			__tmp118.Documentation = null;
			__tmp118.Name = "feature";
			__tmp118.SetOperationLazy(() => __tmp108);
			__tmp109.Documentation = null;
			__tmp109.Name = "EInvoke";
			__tmp109.SetClassLazy(() => EObject);
			// __tmp109.Enum = null;
			__tmp109.IsBuilder = false;
			__tmp109.IsReadonly = false;
			__tmp109.Parameters.AddLazy(() => __tmp119);
			__tmp109.Parameters.AddLazy(() => __tmp120);
			__tmp109.SetReturnTypeLazy(() => __tmp28);
			__tmp119.SetTypeLazy(() => EOperation);
			__tmp119.Documentation = null;
			__tmp119.Name = "operation";
			__tmp119.SetOperationLazy(() => __tmp109);
			__tmp120.SetTypeLazy(() => __tmp121);
			__tmp120.Documentation = null;
			__tmp120.Name = "arguments";
			__tmp120.SetOperationLazy(() => __tmp109);
			EOperation.Documentation = null;
			EOperation.Name = "EOperation";
			EOperation.SetNamespaceLazy(() => __tmp4);
			EOperation.SymbolType = null;
			EOperation.IsAbstract = false;
			EOperation.SuperClasses.AddLazy(() => ETypedElement);
			EOperation.Properties.AddLazy(() => EOperation_EContainingClass);
			EOperation.Properties.AddLazy(() => EOperation_ETypeParameters);
			EOperation.Properties.AddLazy(() => EOperation_EParameters);
			EOperation.Properties.AddLazy(() => EOperation_EExceptions);
			EOperation.Properties.AddLazy(() => EOperation_EGenericExceptions);
			EOperation.Operations.AddLazy(() => __tmp122);
			EOperation.Operations.AddLazy(() => __tmp123);
			EOperation_EContainingClass.SetTypeLazy(() => EClass);
			EOperation_EContainingClass.Documentation = null;
			EOperation_EContainingClass.Name = "EContainingClass";
			EOperation_EContainingClass.SymbolProperty = null;
			EOperation_EContainingClass.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EContainingClass.SetClassLazy(() => EOperation);
			EOperation_EContainingClass.DefaultValue = null;
			EOperation_EContainingClass.IsContainment = false;
			EOperation_EContainingClass.OppositeProperties.AddLazy(() => EClass_EOperations);
			EOperation_ETypeParameters.SetTypeLazy(() => __tmp124);
			EOperation_ETypeParameters.Documentation = null;
			EOperation_ETypeParameters.Name = "ETypeParameters";
			EOperation_ETypeParameters.SymbolProperty = null;
			EOperation_ETypeParameters.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_ETypeParameters.SetClassLazy(() => EOperation);
			EOperation_ETypeParameters.DefaultValue = null;
			EOperation_ETypeParameters.IsContainment = true;
			EOperation_EParameters.SetTypeLazy(() => __tmp125);
			EOperation_EParameters.Documentation = null;
			EOperation_EParameters.Name = "EParameters";
			EOperation_EParameters.SymbolProperty = null;
			EOperation_EParameters.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EParameters.SetClassLazy(() => EOperation);
			EOperation_EParameters.DefaultValue = null;
			EOperation_EParameters.IsContainment = true;
			EOperation_EParameters.OppositeProperties.AddLazy(() => EParameter_EOperation);
			EOperation_EExceptions.SetTypeLazy(() => __tmp126);
			EOperation_EExceptions.Documentation = null;
			EOperation_EExceptions.Name = "EExceptions";
			EOperation_EExceptions.SymbolProperty = null;
			EOperation_EExceptions.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EExceptions.SetClassLazy(() => EOperation);
			EOperation_EExceptions.DefaultValue = null;
			EOperation_EExceptions.IsContainment = false;
			EOperation_EGenericExceptions.SetTypeLazy(() => __tmp127);
			EOperation_EGenericExceptions.Documentation = null;
			EOperation_EGenericExceptions.Name = "EGenericExceptions";
			EOperation_EGenericExceptions.SymbolProperty = null;
			EOperation_EGenericExceptions.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EOperation_EGenericExceptions.SetClassLazy(() => EOperation);
			EOperation_EGenericExceptions.DefaultValue = null;
			EOperation_EGenericExceptions.IsContainment = true;
			__tmp122.Documentation = null;
			__tmp122.Name = "GetOperationID";
			__tmp122.SetClassLazy(() => EOperation);
			// __tmp122.Enum = null;
			__tmp122.IsBuilder = false;
			__tmp122.IsReadonly = false;
			__tmp122.SetReturnTypeLazy(() => __tmp25);
			__tmp123.Documentation = null;
			__tmp123.Name = "IsOverrideOf";
			__tmp123.SetClassLazy(() => EOperation);
			// __tmp123.Enum = null;
			__tmp123.IsBuilder = false;
			__tmp123.IsReadonly = false;
			__tmp123.Parameters.AddLazy(() => __tmp128);
			__tmp123.SetReturnTypeLazy(() => __tmp8);
			__tmp128.SetTypeLazy(() => EOperation);
			__tmp128.Documentation = null;
			__tmp128.Name = "someOperation";
			__tmp128.SetOperationLazy(() => __tmp123);
			EPackage.Documentation = null;
			EPackage.Name = "EPackage";
			EPackage.SetNamespaceLazy(() => __tmp4);
			EPackage.SymbolType = null;
			EPackage.IsAbstract = false;
			EPackage.SuperClasses.AddLazy(() => ENamedElement);
			EPackage.Properties.AddLazy(() => EPackage_NsURI);
			EPackage.Properties.AddLazy(() => EPackage_NsPrefix);
			EPackage.Properties.AddLazy(() => EPackage_EFactoryInstance);
			EPackage.Properties.AddLazy(() => EPackage_EClassifiers);
			EPackage.Properties.AddLazy(() => EPackage_ESubpackages);
			EPackage.Properties.AddLazy(() => EPackage_ESuperPackage);
			EPackage.Operations.AddLazy(() => __tmp129);
			EPackage_NsURI.SetTypeLazy(() => __tmp36);
			EPackage_NsURI.Documentation = null;
			EPackage_NsURI.Name = "NsURI";
			EPackage_NsURI.SymbolProperty = null;
			EPackage_NsURI.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_NsURI.SetClassLazy(() => EPackage);
			EPackage_NsURI.DefaultValue = null;
			EPackage_NsURI.IsContainment = false;
			EPackage_NsPrefix.SetTypeLazy(() => __tmp36);
			EPackage_NsPrefix.Documentation = null;
			EPackage_NsPrefix.Name = "NsPrefix";
			EPackage_NsPrefix.SymbolProperty = null;
			EPackage_NsPrefix.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_NsPrefix.SetClassLazy(() => EPackage);
			EPackage_NsPrefix.DefaultValue = null;
			EPackage_NsPrefix.IsContainment = false;
			EPackage_EFactoryInstance.SetTypeLazy(() => EFactory);
			EPackage_EFactoryInstance.Documentation = null;
			EPackage_EFactoryInstance.Name = "EFactoryInstance";
			EPackage_EFactoryInstance.SymbolProperty = null;
			EPackage_EFactoryInstance.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_EFactoryInstance.SetClassLazy(() => EPackage);
			EPackage_EFactoryInstance.DefaultValue = null;
			EPackage_EFactoryInstance.IsContainment = false;
			EPackage_EFactoryInstance.OppositeProperties.AddLazy(() => EFactory_EPackage);
			EPackage_EClassifiers.SetTypeLazy(() => __tmp130);
			EPackage_EClassifiers.Documentation = null;
			EPackage_EClassifiers.Name = "EClassifiers";
			EPackage_EClassifiers.SymbolProperty = null;
			EPackage_EClassifiers.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_EClassifiers.SetClassLazy(() => EPackage);
			EPackage_EClassifiers.DefaultValue = null;
			EPackage_EClassifiers.IsContainment = true;
			EPackage_EClassifiers.OppositeProperties.AddLazy(() => EClassifier_EPackage);
			EPackage_ESubpackages.SetTypeLazy(() => __tmp131);
			EPackage_ESubpackages.Documentation = null;
			EPackage_ESubpackages.Name = "ESubpackages";
			EPackage_ESubpackages.SymbolProperty = null;
			EPackage_ESubpackages.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_ESubpackages.SetClassLazy(() => EPackage);
			EPackage_ESubpackages.DefaultValue = null;
			EPackage_ESubpackages.IsContainment = true;
			EPackage_ESubpackages.OppositeProperties.AddLazy(() => EPackage_ESuperPackage);
			EPackage_ESuperPackage.SetTypeLazy(() => EPackage);
			EPackage_ESuperPackage.Documentation = null;
			EPackage_ESuperPackage.Name = "ESuperPackage";
			EPackage_ESuperPackage.SymbolProperty = null;
			EPackage_ESuperPackage.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EPackage_ESuperPackage.SetClassLazy(() => EPackage);
			EPackage_ESuperPackage.DefaultValue = null;
			EPackage_ESuperPackage.IsContainment = false;
			EPackage_ESuperPackage.OppositeProperties.AddLazy(() => EPackage_ESubpackages);
			__tmp129.Documentation = null;
			__tmp129.Name = "GetEClassifier";
			__tmp129.SetClassLazy(() => EPackage);
			// __tmp129.Enum = null;
			__tmp129.IsBuilder = false;
			__tmp129.IsReadonly = false;
			__tmp129.Parameters.AddLazy(() => __tmp132);
			__tmp129.SetReturnTypeLazy(() => EClassifier);
			__tmp132.SetTypeLazy(() => __tmp36);
			__tmp132.Documentation = null;
			__tmp132.Name = "name";
			__tmp132.SetOperationLazy(() => __tmp129);
			EParameter.Documentation = null;
			EParameter.Name = "EParameter";
			EParameter.SetNamespaceLazy(() => __tmp4);
			EParameter.SymbolType = null;
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
			EReference.Properties.AddLazy(() => EReference_EKeys);
			EReference_Containment.SetTypeLazy(() => __tmp8);
			EReference_Containment.Documentation = null;
			EReference_Containment.Name = "Containment";
			EReference_Containment.SymbolProperty = null;
			EReference_Containment.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EReference_Containment.SetClassLazy(() => EReference);
			EReference_Containment.DefaultValue = null;
			EReference_Containment.IsContainment = false;
			EReference_Container.SetTypeLazy(() => __tmp8);
			EReference_Container.Documentation = null;
			EReference_Container.Name = "Container";
			EReference_Container.SymbolProperty = null;
			EReference_Container.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EReference_Container.SetClassLazy(() => EReference);
			EReference_Container.DefaultValue = null;
			EReference_Container.IsContainment = false;
			EReference_ResolveProxies.SetTypeLazy(() => __tmp8);
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
			EReference_EReferenceType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EReference_EReferenceType.SetClassLazy(() => EReference);
			EReference_EReferenceType.DefaultValue = null;
			EReference_EReferenceType.IsContainment = false;
			EReference_EKeys.SetTypeLazy(() => __tmp133);
			EReference_EKeys.Documentation = null;
			EReference_EKeys.Name = "EKeys";
			EReference_EKeys.SymbolProperty = null;
			EReference_EKeys.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EReference_EKeys.SetClassLazy(() => EReference);
			EReference_EKeys.DefaultValue = null;
			EReference_EKeys.IsContainment = false;
			EStructuralFeature.Documentation = null;
			EStructuralFeature.Name = "EStructuralFeature";
			EStructuralFeature.SetNamespaceLazy(() => __tmp4);
			EStructuralFeature.SymbolType = null;
			EStructuralFeature.IsAbstract = true;
			EStructuralFeature.SuperClasses.AddLazy(() => ETypedElement);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Changeable);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Volatile);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Transient);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_DefaultValueLiteral);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_DefaultValue);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Unsettable);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_Derived);
			EStructuralFeature.Properties.AddLazy(() => EStructuralFeature_EContainingClass);
			EStructuralFeature.Operations.AddLazy(() => __tmp134);
			EStructuralFeature.Operations.AddLazy(() => __tmp135);
			EStructuralFeature_Changeable.SetTypeLazy(() => __tmp8);
			EStructuralFeature_Changeable.Documentation = null;
			EStructuralFeature_Changeable.Name = "Changeable";
			EStructuralFeature_Changeable.SymbolProperty = null;
			EStructuralFeature_Changeable.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Changeable.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Changeable.DefaultValue = "true";
			EStructuralFeature_Changeable.IsContainment = false;
			EStructuralFeature_Volatile.SetTypeLazy(() => __tmp8);
			EStructuralFeature_Volatile.Documentation = null;
			EStructuralFeature_Volatile.Name = "Volatile";
			EStructuralFeature_Volatile.SymbolProperty = null;
			EStructuralFeature_Volatile.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Volatile.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Volatile.DefaultValue = null;
			EStructuralFeature_Volatile.IsContainment = false;
			EStructuralFeature_Transient.SetTypeLazy(() => __tmp8);
			EStructuralFeature_Transient.Documentation = null;
			EStructuralFeature_Transient.Name = "Transient";
			EStructuralFeature_Transient.SymbolProperty = null;
			EStructuralFeature_Transient.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Transient.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Transient.DefaultValue = null;
			EStructuralFeature_Transient.IsContainment = false;
			EStructuralFeature_DefaultValueLiteral.SetTypeLazy(() => __tmp36);
			EStructuralFeature_DefaultValueLiteral.Documentation = null;
			EStructuralFeature_DefaultValueLiteral.Name = "DefaultValueLiteral";
			EStructuralFeature_DefaultValueLiteral.SymbolProperty = null;
			EStructuralFeature_DefaultValueLiteral.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_DefaultValueLiteral.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_DefaultValueLiteral.DefaultValue = null;
			EStructuralFeature_DefaultValueLiteral.IsContainment = false;
			EStructuralFeature_DefaultValue.SetTypeLazy(() => __tmp28);
			EStructuralFeature_DefaultValue.Documentation = null;
			EStructuralFeature_DefaultValue.Name = "DefaultValue";
			EStructuralFeature_DefaultValue.SymbolProperty = null;
			EStructuralFeature_DefaultValue.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EStructuralFeature_DefaultValue.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_DefaultValue.DefaultValue = null;
			EStructuralFeature_DefaultValue.IsContainment = false;
			EStructuralFeature_Unsettable.SetTypeLazy(() => __tmp8);
			EStructuralFeature_Unsettable.Documentation = null;
			EStructuralFeature_Unsettable.Name = "Unsettable";
			EStructuralFeature_Unsettable.SymbolProperty = null;
			EStructuralFeature_Unsettable.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Unsettable.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Unsettable.DefaultValue = null;
			EStructuralFeature_Unsettable.IsContainment = false;
			EStructuralFeature_Derived.SetTypeLazy(() => __tmp8);
			EStructuralFeature_Derived.Documentation = null;
			EStructuralFeature_Derived.Name = "Derived";
			EStructuralFeature_Derived.SymbolProperty = null;
			EStructuralFeature_Derived.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_Derived.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_Derived.DefaultValue = null;
			EStructuralFeature_Derived.IsContainment = false;
			EStructuralFeature_EContainingClass.SetTypeLazy(() => EClass);
			EStructuralFeature_EContainingClass.Documentation = null;
			EStructuralFeature_EContainingClass.Name = "EContainingClass";
			EStructuralFeature_EContainingClass.SymbolProperty = null;
			EStructuralFeature_EContainingClass.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStructuralFeature_EContainingClass.SetClassLazy(() => EStructuralFeature);
			EStructuralFeature_EContainingClass.DefaultValue = null;
			EStructuralFeature_EContainingClass.IsContainment = false;
			EStructuralFeature_EContainingClass.OppositeProperties.AddLazy(() => EClass_EStructuralFeatures);
			__tmp134.Documentation = null;
			__tmp134.Name = "GetFeatureID";
			__tmp134.SetClassLazy(() => EStructuralFeature);
			// __tmp134.Enum = null;
			__tmp134.IsBuilder = false;
			__tmp134.IsReadonly = false;
			__tmp134.SetReturnTypeLazy(() => __tmp25);
			__tmp135.Documentation = null;
			__tmp135.Name = "GetContainerClass";
			__tmp135.SetClassLazy(() => EStructuralFeature);
			// __tmp135.Enum = null;
			__tmp135.IsBuilder = false;
			__tmp135.IsReadonly = false;
			__tmp135.SetReturnTypeLazy(() => __tmp27);
			ETypedElement.Documentation = null;
			ETypedElement.Name = "ETypedElement";
			ETypedElement.SetNamespaceLazy(() => __tmp4);
			ETypedElement.SymbolType = null;
			ETypedElement.IsAbstract = true;
			ETypedElement.SuperClasses.AddLazy(() => ENamedElement);
			ETypedElement.Properties.AddLazy(() => ETypedElement_Ordered);
			ETypedElement.Properties.AddLazy(() => ETypedElement_Unique);
			ETypedElement.Properties.AddLazy(() => ETypedElement_LowerBound);
			ETypedElement.Properties.AddLazy(() => ETypedElement_UpperBound);
			ETypedElement.Properties.AddLazy(() => ETypedElement_Many);
			ETypedElement.Properties.AddLazy(() => ETypedElement_Required);
			ETypedElement.Properties.AddLazy(() => ETypedElement_EType);
			ETypedElement.Properties.AddLazy(() => ETypedElement_EGenericType);
			ETypedElement_Ordered.SetTypeLazy(() => __tmp8);
			ETypedElement_Ordered.Documentation = null;
			ETypedElement_Ordered.Name = "Ordered";
			ETypedElement_Ordered.SymbolProperty = null;
			ETypedElement_Ordered.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_Ordered.SetClassLazy(() => ETypedElement);
			ETypedElement_Ordered.DefaultValue = "true";
			ETypedElement_Ordered.IsContainment = false;
			ETypedElement_Unique.SetTypeLazy(() => __tmp8);
			ETypedElement_Unique.Documentation = null;
			ETypedElement_Unique.Name = "Unique";
			ETypedElement_Unique.SymbolProperty = null;
			ETypedElement_Unique.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_Unique.SetClassLazy(() => ETypedElement);
			ETypedElement_Unique.DefaultValue = "true";
			ETypedElement_Unique.IsContainment = false;
			ETypedElement_LowerBound.SetTypeLazy(() => __tmp25);
			ETypedElement_LowerBound.Documentation = null;
			ETypedElement_LowerBound.Name = "LowerBound";
			ETypedElement_LowerBound.SymbolProperty = null;
			ETypedElement_LowerBound.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_LowerBound.SetClassLazy(() => ETypedElement);
			ETypedElement_LowerBound.DefaultValue = null;
			ETypedElement_LowerBound.IsContainment = false;
			ETypedElement_UpperBound.SetTypeLazy(() => __tmp25);
			ETypedElement_UpperBound.Documentation = null;
			ETypedElement_UpperBound.Name = "UpperBound";
			ETypedElement_UpperBound.SymbolProperty = null;
			ETypedElement_UpperBound.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_UpperBound.SetClassLazy(() => ETypedElement);
			ETypedElement_UpperBound.DefaultValue = "1";
			ETypedElement_UpperBound.IsContainment = false;
			ETypedElement_Many.SetTypeLazy(() => __tmp8);
			ETypedElement_Many.Documentation = null;
			ETypedElement_Many.Name = "Many";
			ETypedElement_Many.SymbolProperty = null;
			ETypedElement_Many.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			ETypedElement_Many.SetClassLazy(() => ETypedElement);
			ETypedElement_Many.DefaultValue = null;
			ETypedElement_Many.IsContainment = false;
			ETypedElement_Required.SetTypeLazy(() => __tmp8);
			ETypedElement_Required.Documentation = null;
			ETypedElement_Required.Name = "Required";
			ETypedElement_Required.SymbolProperty = null;
			ETypedElement_Required.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			ETypedElement_Required.SetClassLazy(() => ETypedElement);
			ETypedElement_Required.DefaultValue = null;
			ETypedElement_Required.IsContainment = false;
			ETypedElement_EType.SetTypeLazy(() => EClassifier);
			ETypedElement_EType.Documentation = null;
			ETypedElement_EType.Name = "EType";
			ETypedElement_EType.SymbolProperty = null;
			ETypedElement_EType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_EType.SetClassLazy(() => ETypedElement);
			ETypedElement_EType.DefaultValue = null;
			ETypedElement_EType.IsContainment = false;
			ETypedElement_EGenericType.SetTypeLazy(() => EGenericType);
			ETypedElement_EGenericType.Documentation = null;
			ETypedElement_EGenericType.Name = "EGenericType";
			ETypedElement_EGenericType.SymbolProperty = null;
			ETypedElement_EGenericType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypedElement_EGenericType.SetClassLazy(() => ETypedElement);
			ETypedElement_EGenericType.DefaultValue = null;
			ETypedElement_EGenericType.IsContainment = true;
			EStringToStringMapEntry.Documentation = null;
			EStringToStringMapEntry.Name = "EStringToStringMapEntry";
			EStringToStringMapEntry.SetNamespaceLazy(() => __tmp4);
			EStringToStringMapEntry.SymbolType = null;
			EStringToStringMapEntry.IsAbstract = false;
			EStringToStringMapEntry.Properties.AddLazy(() => EStringToStringMapEntry_Key);
			EStringToStringMapEntry.Properties.AddLazy(() => EStringToStringMapEntry_Value);
			EStringToStringMapEntry_Key.SetTypeLazy(() => __tmp36);
			EStringToStringMapEntry_Key.Documentation = null;
			EStringToStringMapEntry_Key.Name = "Key";
			EStringToStringMapEntry_Key.SymbolProperty = null;
			EStringToStringMapEntry_Key.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStringToStringMapEntry_Key.SetClassLazy(() => EStringToStringMapEntry);
			EStringToStringMapEntry_Key.DefaultValue = null;
			EStringToStringMapEntry_Key.IsContainment = false;
			EStringToStringMapEntry_Value.SetTypeLazy(() => __tmp36);
			EStringToStringMapEntry_Value.Documentation = null;
			EStringToStringMapEntry_Value.Name = "Value";
			EStringToStringMapEntry_Value.SymbolProperty = null;
			EStringToStringMapEntry_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EStringToStringMapEntry_Value.SetClassLazy(() => EStringToStringMapEntry);
			EStringToStringMapEntry_Value.DefaultValue = null;
			EStringToStringMapEntry_Value.IsContainment = false;
			EGenericType.Documentation = null;
			EGenericType.Name = "EGenericType";
			EGenericType.SetNamespaceLazy(() => __tmp4);
			EGenericType.SymbolType = null;
			EGenericType.IsAbstract = false;
			EGenericType.Properties.AddLazy(() => EGenericType_EUpperBound);
			EGenericType.Properties.AddLazy(() => EGenericType_ETypeArguments);
			EGenericType.Properties.AddLazy(() => EGenericType_ERawType);
			EGenericType.Properties.AddLazy(() => EGenericType_ELowerBound);
			EGenericType.Properties.AddLazy(() => EGenericType_ETypeParameter);
			EGenericType.Properties.AddLazy(() => EGenericType_EClassifier);
			EGenericType.Operations.AddLazy(() => __tmp136);
			EGenericType_EUpperBound.SetTypeLazy(() => EGenericType);
			EGenericType_EUpperBound.Documentation = null;
			EGenericType_EUpperBound.Name = "EUpperBound";
			EGenericType_EUpperBound.SymbolProperty = null;
			EGenericType_EUpperBound.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_EUpperBound.SetClassLazy(() => EGenericType);
			EGenericType_EUpperBound.DefaultValue = null;
			EGenericType_EUpperBound.IsContainment = true;
			EGenericType_ETypeArguments.SetTypeLazy(() => __tmp137);
			EGenericType_ETypeArguments.Documentation = null;
			EGenericType_ETypeArguments.Name = "ETypeArguments";
			EGenericType_ETypeArguments.SymbolProperty = null;
			EGenericType_ETypeArguments.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_ETypeArguments.SetClassLazy(() => EGenericType);
			EGenericType_ETypeArguments.DefaultValue = null;
			EGenericType_ETypeArguments.IsContainment = true;
			EGenericType_ERawType.SetTypeLazy(() => EClassifier);
			EGenericType_ERawType.Documentation = null;
			EGenericType_ERawType.Name = "ERawType";
			EGenericType_ERawType.SymbolProperty = null;
			EGenericType_ERawType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Derived;
			EGenericType_ERawType.SetClassLazy(() => EGenericType);
			EGenericType_ERawType.DefaultValue = null;
			EGenericType_ERawType.IsContainment = false;
			EGenericType_ELowerBound.SetTypeLazy(() => EGenericType);
			EGenericType_ELowerBound.Documentation = null;
			EGenericType_ELowerBound.Name = "ELowerBound";
			EGenericType_ELowerBound.SymbolProperty = null;
			EGenericType_ELowerBound.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_ELowerBound.SetClassLazy(() => EGenericType);
			EGenericType_ELowerBound.DefaultValue = null;
			EGenericType_ELowerBound.IsContainment = true;
			EGenericType_ETypeParameter.SetTypeLazy(() => ETypeParameter);
			EGenericType_ETypeParameter.Documentation = null;
			EGenericType_ETypeParameter.Name = "ETypeParameter";
			EGenericType_ETypeParameter.SymbolProperty = null;
			EGenericType_ETypeParameter.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_ETypeParameter.SetClassLazy(() => EGenericType);
			EGenericType_ETypeParameter.DefaultValue = null;
			EGenericType_ETypeParameter.IsContainment = false;
			EGenericType_EClassifier.SetTypeLazy(() => EClassifier);
			EGenericType_EClassifier.Documentation = null;
			EGenericType_EClassifier.Name = "EClassifier";
			EGenericType_EClassifier.SymbolProperty = null;
			EGenericType_EClassifier.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			EGenericType_EClassifier.SetClassLazy(() => EGenericType);
			EGenericType_EClassifier.DefaultValue = null;
			EGenericType_EClassifier.IsContainment = false;
			__tmp136.Documentation = null;
			__tmp136.Name = "IsInstance";
			__tmp136.SetClassLazy(() => EGenericType);
			// __tmp136.Enum = null;
			__tmp136.IsBuilder = false;
			__tmp136.IsReadonly = false;
			__tmp136.Parameters.AddLazy(() => __tmp138);
			__tmp136.SetReturnTypeLazy(() => __tmp8);
			__tmp138.SetTypeLazy(() => __tmp28);
			__tmp138.Documentation = null;
			__tmp138.Name = "@object";
			__tmp138.SetOperationLazy(() => __tmp136);
			ETypeParameter.Documentation = null;
			ETypeParameter.Name = "ETypeParameter";
			ETypeParameter.SetNamespaceLazy(() => __tmp4);
			ETypeParameter.SymbolType = null;
			ETypeParameter.IsAbstract = false;
			ETypeParameter.SuperClasses.AddLazy(() => ENamedElement);
			ETypeParameter.Properties.AddLazy(() => ETypeParameter_EBounds);
			ETypeParameter_EBounds.SetTypeLazy(() => __tmp139);
			ETypeParameter_EBounds.Documentation = null;
			ETypeParameter_EBounds.Name = "EBounds";
			ETypeParameter_EBounds.SymbolProperty = null;
			ETypeParameter_EBounds.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ETypeParameter_EBounds.SetClassLazy(() => ETypeParameter);
			ETypeParameter_EBounds.DefaultValue = null;
			ETypeParameter_EBounds.IsContainment = true;
			__tmp39.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp39.SetInnerTypeLazy(() => EStringToStringMapEntry);
			__tmp40.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp40.SetInnerTypeLazy(() => EObject);
			__tmp41.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp41.SetInnerTypeLazy(() => EObject);
			__tmp52.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp52.SetInnerTypeLazy(() => EClass);
			__tmp53.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp53.SetInnerTypeLazy(() => EOperation);
			__tmp54.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp54.SetInnerTypeLazy(() => EAttribute);
			__tmp55.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp55.SetInnerTypeLazy(() => EReference);
			__tmp56.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp56.SetInnerTypeLazy(() => EReference);
			__tmp57.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp57.SetInnerTypeLazy(() => EAttribute);
			__tmp58.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp58.SetInnerTypeLazy(() => EReference);
			__tmp59.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp59.SetInnerTypeLazy(() => EOperation);
			__tmp60.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp60.SetInnerTypeLazy(() => EStructuralFeature);
			__tmp61.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp61.SetInnerTypeLazy(() => EClass);
			__tmp62.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp62.SetInnerTypeLazy(() => EStructuralFeature);
			__tmp63.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp63.SetInnerTypeLazy(() => EGenericType);
			__tmp64.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp64.SetInnerTypeLazy(() => EGenericType);
			__tmp75.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp75.SetInnerTypeLazy(() => ETypeParameter);
			__tmp80.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp80.SetInnerTypeLazy(() => EEnumLiteral);
			__tmp93.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp93.SetInnerTypeLazy(() => EAnnotation);
			__tmp110.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp110.SetInnerTypeLazy(() => EObject);
			__tmp111.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp111.SetInnerTypeLazy(() => EObject);
			__tmp121.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp121.SetInnerTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Object.ToMutable());
			__tmp124.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp124.SetInnerTypeLazy(() => ETypeParameter);
			__tmp125.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp125.SetInnerTypeLazy(() => EParameter);
			__tmp126.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp126.SetInnerTypeLazy(() => EClassifier);
			__tmp127.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp127.SetInnerTypeLazy(() => EGenericType);
			__tmp130.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp130.SetInnerTypeLazy(() => EClassifier);
			__tmp131.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp131.SetInnerTypeLazy(() => EPackage);
			__tmp133.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp133.SetInnerTypeLazy(() => EAttribute);
			__tmp137.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp137.SetInnerTypeLazy(() => EGenericType);
			__tmp139.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp139.SetInnerTypeLazy(() => EGenericType);
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
		/// Implements the constructor: EAttribute()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EStructuralFeature</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			_this.SetDefaultValueLazy(this.EStructuralFeature_ComputeProperty_DefaultValue);
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
		/// Implements the constructor: EAnnotation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EModelElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.EModelElement(_this);
		}




		/// <summary>
		/// Implements the constructor: EClass()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EClassifier</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>EClassifier</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>EAllAttributes</li>
		///     <li>EAllReferences</li>
		///     <li>EReferences</li>
		///     <li>EAttributes</li>
		///     <li>EAllContainments</li>
		///     <li>EAllOperations</li>
		///     <li>EAllStructuralFeatures</li>
		///     <li>EAllSuperTypes</li>
		///     <li>EIDAttribute</li>
		///     <li>EAllGenericSuperTypes</li>
		/// </ul>
		public virtual void EClass(EClassBuilder _this)
		{
			this.CallEClassSuperConstructors(_this);
			_this.EAllGenericSuperTypes.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllGenericSuperTypes);
			_this.SetEIDAttributeLazy(this.EClass_ComputeProperty_EIDAttribute);
			_this.EAllSuperTypes.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllSuperTypes);
			_this.EAllStructuralFeatures.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllStructuralFeatures);
			_this.EAllOperations.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllOperations);
			_this.EAllContainments.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllContainments);
			_this.EAttributes.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAttributes);
			_this.EReferences.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EReferences);
			_this.EAllReferences.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllReferences);
			_this.EAllAttributes.AddRangeLazy<EClassBuilder>(this.EClass_ComputeProperty_EAllAttributes);
			_this.SetDefaultValueLazy(this.EClassifier_ComputeProperty_DefaultValue);
			_this.SetInstanceClassLazy(this.EClassifier_ComputeProperty_InstanceClass);
		}

		/// <summary>
		/// Calls the super constructors of EClass
		/// </summary>
		protected virtual void CallEClassSuperConstructors(EClassBuilder _this)
		{
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.EClassifier(_this);
		}

		/// <summary>
		/// Computes the value of the property: EClass.EAllAttributes
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EAttributeBuilder> EClass_ComputeProperty_EAllAttributes(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllReferences
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EAllReferences(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EReferences
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EReferences(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAttributes
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EAttributeBuilder> EClass_ComputeProperty_EAttributes(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllContainments
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EAllContainments(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllOperations
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EOperationBuilder> EClass_ComputeProperty_EAllOperations(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllStructuralFeatures
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EStructuralFeatureBuilder> EClass_ComputeProperty_EAllStructuralFeatures(EClassBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClass.EAllSuperTypes
		/// </summary	
		public abstract global::System.Collections.Generic.IReadOnlyList<EClassBuilder> EClass_ComputeProperty_EAllSuperTypes(EClassBuilder _this);
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
		/// Implements the operation: EClass.GetFeatureCount()
		/// </summary>
		public virtual int EClass_GetFeatureCount(EClass _this)
		{
			return this.EClass_GetFeatureCount(_this.ToMutable());
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetFeatureCount()
		/// </summary>
		public abstract int EClass_GetFeatureCount(EClassBuilder _this);

		/// <summary>
		/// Implements the operation: EClass.GetEStructuralFeature()
		/// </summary>
		public virtual EStructuralFeature EClass_GetEStructuralFeature(EClass _this, int featureID)
		{
			return this.EClass_GetEStructuralFeature(_this.ToMutable(), featureID).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetEStructuralFeature()
		/// </summary>
		public abstract EStructuralFeatureBuilder EClass_GetEStructuralFeature(EClassBuilder _this, int featureID);

		/// <summary>
		/// Implements the operation: EClass.GetFeatureID()
		/// </summary>
		public virtual int EClass_GetFeatureID(EClass _this, EStructuralFeature feature)
		{
			return this.EClass_GetFeatureID(_this.ToMutable(), feature.ToMutable());
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetFeatureID()
		/// </summary>
		public abstract int EClass_GetFeatureID(EClassBuilder _this, EStructuralFeatureBuilder feature);

		/// <summary>
		/// Implements the operation: EClass.GetEStructuralFeature()
		/// </summary>
		public virtual EStructuralFeature EClass_GetEStructuralFeature(EClass _this, string featureName)
		{
			return this.EClass_GetEStructuralFeature(_this.ToMutable(), featureName).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetEStructuralFeature()
		/// </summary>
		public abstract EStructuralFeatureBuilder EClass_GetEStructuralFeature(EClassBuilder _this, string featureName);

		/// <summary>
		/// Implements the operation: EClass.GetOperationCount()
		/// </summary>
		public virtual int EClass_GetOperationCount(EClass _this)
		{
			return this.EClass_GetOperationCount(_this.ToMutable());
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetOperationCount()
		/// </summary>
		public abstract int EClass_GetOperationCount(EClassBuilder _this);

		/// <summary>
		/// Implements the operation: EClass.GetEOperation()
		/// </summary>
		public virtual EOperation EClass_GetEOperation(EClass _this, int operationID)
		{
			return this.EClass_GetEOperation(_this.ToMutable(), operationID).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetEOperation()
		/// </summary>
		public abstract EOperationBuilder EClass_GetEOperation(EClassBuilder _this, int operationID);

		/// <summary>
		/// Implements the operation: EClass.GetOperationID()
		/// </summary>
		public virtual int EClass_GetOperationID(EClass _this, EOperation operation)
		{
			return this.EClass_GetOperationID(_this.ToMutable(), operation.ToMutable());
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetOperationID()
		/// </summary>
		public abstract int EClass_GetOperationID(EClassBuilder _this, EOperationBuilder operation);

		/// <summary>
		/// Implements the operation: EClass.GetOverride()
		/// </summary>
		public virtual EOperation EClass_GetOverride(EClass _this, EOperation operation)
		{
			return this.EClass_GetOverride(_this.ToMutable(), operation.ToMutable()).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetOverride()
		/// </summary>
		public abstract EOperationBuilder EClass_GetOverride(EClassBuilder _this, EOperationBuilder operation);

		/// <summary>
		/// Implements the operation: EClass.GetFeatureType()
		/// </summary>
		public virtual EGenericType EClass_GetFeatureType(EClass _this, EStructuralFeature feature)
		{
			return this.EClass_GetFeatureType(_this.ToMutable(), feature.ToMutable()).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EClassBuilder.GetFeatureType()
		/// </summary>
		public abstract EGenericTypeBuilder EClass_GetFeatureType(EClassBuilder _this, EStructuralFeatureBuilder feature);


		/// <summary>
		/// Implements the constructor: EClassifier()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>InstanceClass</li>
		///     <li>DefaultValue</li>
		/// </ul>
		public virtual void EClassifier(EClassifierBuilder _this)
		{
			this.CallEClassifierSuperConstructors(_this);
			_this.SetDefaultValueLazy(this.EClassifier_ComputeProperty_DefaultValue);
			_this.SetInstanceClassLazy(this.EClassifier_ComputeProperty_InstanceClass);
		}

		/// <summary>
		/// Calls the super constructors of EClassifier
		/// </summary>
		protected virtual void CallEClassifierSuperConstructors(EClassifierBuilder _this)
		{
			this.EModelElement(_this);
			this.ENamedElement(_this);
		}

		/// <summary>
		/// Computes the value of the property: EClassifier.InstanceClass
		/// </summary	
		public abstract System.Type EClassifier_ComputeProperty_InstanceClass(EClassifierBuilder _this);
		/// <summary>
		/// Computes the value of the property: EClassifier.DefaultValue
		/// </summary	
		public abstract object EClassifier_ComputeProperty_DefaultValue(EClassifierBuilder _this);


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
		/// Implements the constructor: EDataType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EClassifier</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>EClassifier</li>
		/// </ul>
		public virtual void EDataType(EDataTypeBuilder _this)
		{
			this.CallEDataTypeSuperConstructors(_this);
			_this.SetSerializableLazy(() => true);
			_this.SetDefaultValueLazy(this.EClassifier_ComputeProperty_DefaultValue);
			_this.SetInstanceClassLazy(this.EClassifier_ComputeProperty_InstanceClass);
		}

		/// <summary>
		/// Calls the super constructors of EDataType
		/// </summary>
		protected virtual void CallEDataTypeSuperConstructors(EDataTypeBuilder _this)
		{
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
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>EClassifier</li>
		///     <li>EDataType</li>
		/// </ul>
		public virtual void EEnum(EEnumBuilder _this)
		{
			this.CallEEnumSuperConstructors(_this);
			_this.SetSerializableLazy(() => true);
			_this.SetDefaultValueLazy(this.EClassifier_ComputeProperty_DefaultValue);
			_this.SetInstanceClassLazy(this.EClassifier_ComputeProperty_InstanceClass);
		}

		/// <summary>
		/// Calls the super constructors of EEnum
		/// </summary>
		protected virtual void CallEEnumSuperConstructors(EEnumBuilder _this)
		{
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.EClassifier(_this);
			this.EDataType(_this);
		}



		/// <summary>
		/// Implements the operation: EEnum.GetEEnumLiteral()
		/// </summary>
		public virtual EEnumLiteral EEnum_GetEEnumLiteral(EEnum _this, string name)
		{
			return this.EEnum_GetEEnumLiteral(_this.ToMutable(), name).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EEnumBuilder.GetEEnumLiteral()
		/// </summary>
		public abstract EEnumLiteralBuilder EEnum_GetEEnumLiteral(EEnumBuilder _this, string name);

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
		/// Implements the operation: EEnum.GetEEnumLiteralByLiteral()
		/// </summary>
		public virtual EEnumLiteral EEnum_GetEEnumLiteralByLiteral(EEnum _this, string literal)
		{
			return this.EEnum_GetEEnumLiteralByLiteral(_this.ToMutable(), literal).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EEnumBuilder.GetEEnumLiteralByLiteral()
		/// </summary>
		public abstract EEnumLiteralBuilder EEnum_GetEEnumLiteralByLiteral(EEnumBuilder _this, string literal);


		/// <summary>
		/// Implements the constructor: EEnumLiteral()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.EModelElement(_this);
			this.ENamedElement(_this);
		}




		/// <summary>
		/// Implements the constructor: EFactory()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EModelElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
		public virtual object EFactory_CreateFromString(EFactory _this, EDataType eDataType, string literalValue)
		{
			return this.EFactory_CreateFromString(_this.ToMutable(), eDataType.ToMutable(), literalValue);
		}

		/// <summary>
		/// Implements the operation: EFactoryBuilder.CreateFromString()
		/// </summary>
		public abstract object EFactory_CreateFromString(EFactoryBuilder _this, EDataTypeBuilder eDataType, string literalValue);

		/// <summary>
		/// Implements the operation: EFactory.ConvertToString()
		/// </summary>
		public virtual string EFactory_ConvertToString(EFactory _this, EDataType eDataType, object instanceValue)
		{
			return this.EFactory_ConvertToString(_this.ToMutable(), eDataType.ToMutable(), instanceValue);
		}

		/// <summary>
		/// Implements the operation: EFactoryBuilder.ConvertToString()
		/// </summary>
		public abstract string EFactory_ConvertToString(EFactoryBuilder _this, EDataTypeBuilder eDataType, object instanceValue);


		/// <summary>
		/// Implements the constructor: EModelElement()
		/// </summary>
		public virtual void EModelElement(EModelElementBuilder _this)
		{
			this.CallEModelElementSuperConstructors(_this);
		}

		/// <summary>
		/// Calls the super constructors of EModelElement
		/// </summary>
		protected virtual void CallEModelElementSuperConstructors(EModelElementBuilder _this)
		{
		}



		/// <summary>
		/// Implements the operation: EModelElement.GetEAnnotation()
		/// </summary>
		public virtual EAnnotation EModelElement_GetEAnnotation(EModelElement _this, string source)
		{
			return this.EModelElement_GetEAnnotation(_this.ToMutable(), source).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EModelElementBuilder.GetEAnnotation()
		/// </summary>
		public abstract EAnnotationBuilder EModelElement_GetEAnnotation(EModelElementBuilder _this, string source);


		/// <summary>
		/// Implements the constructor: ENamedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EModelElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.EModelElement(_this);
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
		public virtual global::System.Collections.Generic.IReadOnlyList<EObject> EObject_EContents(EObject _this)
		{
			return this.EObject_EContents(_this.ToMutable()).Select(obj => obj.ToImmutable()).ToList();
		}

		/// <summary>
		/// Implements the operation: EObjectBuilder.EContents()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<EObjectBuilder> EObject_EContents(EObjectBuilder _this);

		/// <summary>
		/// Implements the operation: EObject.EAllContents()
		/// </summary>
		public virtual System.Collections.IEnumerable EObject_EAllContents(EObject _this)
		{
			return this.EObject_EAllContents(_this.ToMutable());
		}

		/// <summary>
		/// Implements the operation: EObjectBuilder.EAllContents()
		/// </summary>
		public abstract System.Collections.IEnumerable EObject_EAllContents(EObjectBuilder _this);

		/// <summary>
		/// Implements the operation: EObject.ECrossReferences()
		/// </summary>
		public virtual global::System.Collections.Generic.IReadOnlyList<EObject> EObject_ECrossReferences(EObject _this)
		{
			return this.EObject_ECrossReferences(_this.ToMutable()).Select(obj => obj.ToImmutable()).ToList();
		}

		/// <summary>
		/// Implements the operation: EObjectBuilder.ECrossReferences()
		/// </summary>
		public abstract global::System.Collections.Generic.IReadOnlyList<EObjectBuilder> EObject_ECrossReferences(EObjectBuilder _this);

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
		public virtual void EObject_ESet(EObject _this, EStructuralFeature feature, object newValue)
		{
			this.EObject_ESet(_this.ToMutable(), feature.ToMutable(), newValue);
		}

		/// <summary>
		/// Implements the operation: EObjectBuilder.ESet()
		/// </summary>
		public abstract void EObject_ESet(EObjectBuilder _this, EStructuralFeatureBuilder feature, object newValue);

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
		/// Implements the operation: EObject.EInvoke()
		/// </summary>
		public virtual object EObject_EInvoke(EObject _this, EOperation operation, global::System.Collections.Generic.IReadOnlyList<object> arguments)
		{
			return this.EObject_EInvoke(_this.ToMutable(), operation.ToMutable(), arguments);
		}

		/// <summary>
		/// Implements the operation: EObjectBuilder.EInvoke()
		/// </summary>
		public abstract object EObject_EInvoke(EObjectBuilder _this, EOperationBuilder operation, global::System.Collections.Generic.IReadOnlyList<object> arguments);


		/// <summary>
		/// Implements the constructor: EOperation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ETypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.ETypedElement(_this);
		}



		/// <summary>
		/// Implements the operation: EOperation.GetOperationID()
		/// </summary>
		public virtual int EOperation_GetOperationID(EOperation _this)
		{
			return this.EOperation_GetOperationID(_this.ToMutable());
		}

		/// <summary>
		/// Implements the operation: EOperationBuilder.GetOperationID()
		/// </summary>
		public abstract int EOperation_GetOperationID(EOperationBuilder _this);

		/// <summary>
		/// Implements the operation: EOperation.IsOverrideOf()
		/// </summary>
		public virtual bool EOperation_IsOverrideOf(EOperation _this, EOperation someOperation)
		{
			return this.EOperation_IsOverrideOf(_this.ToMutable(), someOperation.ToMutable());
		}

		/// <summary>
		/// Implements the operation: EOperationBuilder.IsOverrideOf()
		/// </summary>
		public abstract bool EOperation_IsOverrideOf(EOperationBuilder _this, EOperationBuilder someOperation);


		/// <summary>
		/// Implements the constructor: EPackage()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.EModelElement(_this);
			this.ENamedElement(_this);
		}



		/// <summary>
		/// Implements the operation: EPackage.GetEClassifier()
		/// </summary>
		public virtual EClassifier EPackage_GetEClassifier(EPackage _this, string name)
		{
			return this.EPackage_GetEClassifier(_this.ToMutable(), name).ToImmutable();
		}

		/// <summary>
		/// Implements the operation: EPackageBuilder.GetEClassifier()
		/// </summary>
		public abstract EClassifierBuilder EPackage_GetEClassifier(EPackageBuilder _this, string name);


		/// <summary>
		/// Implements the constructor: EParameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ETypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.ETypedElement(_this);
		}




		/// <summary>
		/// Implements the constructor: EReference()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EStructuralFeature</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>ETypedElement</li>
		///     <li>EStructuralFeature</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>Container</li>
		///     <li>EReferenceType</li>
		/// </ul>
		public virtual void EReference(EReferenceBuilder _this)
		{
			this.CallEReferenceSuperConstructors(_this);
			_this.SetEReferenceTypeLazy(this.EReference_ComputeProperty_EReferenceType);
			_this.SetResolveProxiesLazy(() => true);
			_this.SetContainerLazy(this.EReference_ComputeProperty_Container);
			_this.SetDefaultValueLazy(this.EStructuralFeature_ComputeProperty_DefaultValue);
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
		/// Computes the value of the property: EReference.EReferenceType
		/// </summary	
		public abstract EClassBuilder EReference_ComputeProperty_EReferenceType(EReferenceBuilder _this);



		/// <summary>
		/// Implements the constructor: EStructuralFeature()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ETypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>EModelElement</li>
		///     <li>ENamedElement</li>
		///     <li>ETypedElement</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>DefaultValue</li>
		/// </ul>
		public virtual void EStructuralFeature(EStructuralFeatureBuilder _this)
		{
			this.CallEStructuralFeatureSuperConstructors(_this);
			_this.SetDefaultValueLazy(this.EStructuralFeature_ComputeProperty_DefaultValue);
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
			this.EModelElement(_this);
			this.ENamedElement(_this);
			this.ETypedElement(_this);
		}

		/// <summary>
		/// Computes the value of the property: EStructuralFeature.DefaultValue
		/// </summary	
		public abstract object EStructuralFeature_ComputeProperty_DefaultValue(EStructuralFeatureBuilder _this);


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
		/// Implements the constructor: ETypedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
		/// Implements the constructor: EGenericType()
		/// </summary>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>ERawType</li>
		/// </ul>
		public virtual void EGenericType(EGenericTypeBuilder _this)
		{
			this.CallEGenericTypeSuperConstructors(_this);
			_this.SetERawTypeLazy(this.EGenericType_ComputeProperty_ERawType);
		}

		/// <summary>
		/// Calls the super constructors of EGenericType
		/// </summary>
		protected virtual void CallEGenericTypeSuperConstructors(EGenericTypeBuilder _this)
		{
		}

		/// <summary>
		/// Computes the value of the property: EGenericType.ERawType
		/// </summary	
		public abstract EClassifierBuilder EGenericType_ComputeProperty_ERawType(EGenericTypeBuilder _this);


		/// <summary>
		/// Implements the operation: EGenericType.IsInstance()
		/// </summary>
		public virtual bool EGenericType_IsInstance(EGenericType _this, object @object)
		{
			return this.EGenericType_IsInstance(_this.ToMutable(), @object);
		}

		/// <summary>
		/// Implements the operation: EGenericTypeBuilder.IsInstance()
		/// </summary>
		public abstract bool EGenericType_IsInstance(EGenericTypeBuilder _this, object @object);


		/// <summary>
		/// Implements the constructor: ETypeParameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ENamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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

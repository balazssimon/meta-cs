namespace MetaDslx.Languages.Ecore.Model
{
	metamodel Ecore(Uri="http://www.eclipse.org/emf/2002/Ecore"); 

	/// EJavaObject is a type representing the object type. In Java it is java.lang.Object. In .NET it is System.Object.
	const EDataType EJavaObject;
	/// EJavaClass is a type representing the type concept. In Java it is java.lang.Class. In .NET it is System.Type.
	const EDataType EJavaClass;
	/// EBoolean is used for logical expressions, consisting of the predefined values true and false.

	const EDataType EBoolean;
	/// EString is a sequence of characters in some suitable character set used to display information 
	/// about the model. Character sets may include non-Roman alphabets and characters.
	const EDataType EString;
	/// EByte is a primitive type representing byte values.

	const EDataType EByte;
	/// EByteArray is a primitive type representing a byte array.
	const EDataType EByteArray;
	/// EChar is a primitive type representing character values.
	const EDataType EChar;
	/// EShort is a primitive type representing short integer values.
	const EDataType EShort;
	/// EInt is a primitive type representing integer values.
	const EDataType EInt;
	/// ELong is a primitive type representing long integer values.
	const EDataType ELong;
	/// EFloat is a primitive type representing the mathematical concept of real.
	const EDataType EFloat;
	/// EDouble is a primitive type representing the mathematical concept of real.
	const EDataType EDouble;

	/// EByteObject is a reference type representing byte values.
	const EDataType EByteObject;
	/// ECharObject is a reference type representing character values.
	const EDataType ECharObject;
	/// EShortObject is a reference type representing short integer values.
	const EDataType EShortObject;
	/// EIntObject is a reference type representing integer values.
	const EDataType EIntObject;
	/// ELongObject is a reference type representing long integer values.
	const EDataType ELongObject;
	/// EFloatObject is a reference type representing the mathematical concept of real.
	const EDataType EFloatObject;
	/// EDoubleObject is a reference type representing the mathematical concept of real.
	const EDataType EDoubleObject;

	/// EDate is a reference type representing a date.
	const EDataType EDate;
	/// EBigInteger is a reference type representing an unlimited integer value.
	const EDataType EBigInteger;
	/// EBigDecimal is a reference type representing an unlimited decimal value.
	const EDataType EBigDecimal;

	/// EResource is a reference type representing a model. In Ecore it is org.eclipse.emf.ecore.resource.Resource. In MetaDslx it is MetaDslx.Modeling.IModel.
	const EDataType EResource;
	/// EResourceSet is a reference type representing a model group. In Ecore it is org.eclipse.emf.ecore.resource.ResourceSet. In MetaDslx it is MetaDslx.Modeling.IModelGroup.
	const EDataType EResourceSet;

	/// EFeatureMap is a reference type representing a feature map.
	const EDataType EFeatureMap;
	/// EFeatureMapEntry is a reference type representing a feature map entry.
	const EDataType EFeatureMapEntry;

	/// EEList is a reference type representing an ecore EList.
	const EDataType EEList;
	/// EEnumerator is a reference type representing an enumerator.
	const EDataType EEnumerator;
	/// ETreeIterator is a reference type representing a tree iterator.
	const EDataType ETreeIterator;


	class EObject
	{
		EClass EClass();
		bool EIsProxy();
		EResource EResource();
		EObject EContainer();
		EStructuralFeature EContainingFeature();
		EReference EContainmentFeature();
		// EEList EContents();
		// ETreeIterator EAllContents();
		// EEList ECrossReferences();
		// EJavaObject EGet(EStructuralFeature feature);
		// EJavaObject EGet(EStructuralFeature feature, bool resolve);
		// EJavaObject ESet(EStructuralFeature feature, EJavaObject newValue);
		bool EIsSet(EStructuralFeature feature);
		void EUnset(EStructuralFeature feature);
	}

	abstract class EModelElement : EObject
	{
		containment list<EAnnotation> Annotations;
		readonly EAnnotation GetEAnnotation(string source);
	}

	class EFactory : EModelElement
	{
		EPackage EPackage;
		EObject Create(EClass eClass);
		EObject CreateFromString(EDataType eDataType, string literalValue);
		// string ConvertToString(EDataType eDataType, EJavaObject instanceValue); // TODO
	}

	abstract class ENamedElement : EModelElement
	{
		[Name]
		string Name;
	}

	class EAnnotation : EModelElement
	{
		EModelElement EModelElement;
		string Source;
		containment list<EStringToStringMapEntry> Details;
		containment list<EObject> Contents;
		list<EObject> References;
	}

	class EStringToStringMapEntry
	{
		string Key;
		string Value;
	}

	class EPackage : ENamedElement
	{
		string NsURI;
		string NsPrefix;
		EPackage ESuperPackage;
		containment list<EPackage> ESubPackages;
		containment list<EClassifier> EClassifiers;
		EFactory EFactoryInstance;
		EClassifier GetEClassifier(string name);
	}

	[Type]
	class EClassifier : ENamedElement
	{
		string InstanceClassName;
		EPackage EPackage;
		containment list<ETypeParameter> ETypeParameters;

		// EJavaClass InstanceClass; // TODO
		// EJavaObject DefaultValue; // TODO
		// bool IsInstance(EJavaObject @object); // TODO
		int GetClassifierID();
	}

	class EClass : EClassifier
	{
		bool Abstract;
		bool Interface;
		list<EClass> ESuperTypes;
		derived list<EClass> EAllSuperTypes;
		containment list<EStructuralFeature> EStructuralFeatures;
		derived list<EStructuralFeature> EAllStructuralFeatures;
		containment list<EOperation> EOperations;
		derived list<EOperation> EAllOperation;
		derived list<EReference> EReferences;
		derived list<EReference> EAllReferences;
		derived list<EReference> EAllContainments;
		derived list<EAttribute> EAttributes;
		derived list<EAttribute> EAllAttributes;
		derived EAttribute EIDAttribute;
		containment list<EGenericType> EGenericSuperTypes;
		derived list<EGenericType> EAllGenericSuperTypes;

		bool IsSuperTypeOf(EClass someClass);
		EStructuralFeature GetStructuralFeature(int featureID);
		EStructuralFeature GetStructuralFeature(string featureName);
	}

	class EDataType : EClassifier
	{
		bool Serializable = "true";
	}

	class EEnum : EDataType
	{
		containment list<EEnumLiteral> ELiterals;
		EEnumLiteral GetEEnumLiteral(string name);
		EEnumLiteral GetEEnumLiteral(int value);
	}

	class EEnumLiteral : ENamedElement
	{
		EEnum EEnum;
		int Value;
		// EEnumerator Instance; // TODO
	}

	class ETypedElement : ENamedElement
	{
		[Type]
		EClassifier EType;
		bool Ordered = "true";
		bool Unique = "true";
		int LowerBound;
		int UpperBound = "1";
		bool Many;
		bool Required;
		containment EGenericType EGenericType;
	}

	class EStructuralFeature : ETypedElement
	{
		EClass EContainingClass;
		bool Changeable = "true";
		bool Volatile;
		bool Transient;
		string DefaultValueLiteral;
		// EJavaObject DefaultValue;
		bool Unsettable;
		bool Derived;
		int GetFeatureID();
		// EJavaClass GetContainerClass();
	}

	class EAttribute : EStructuralFeature
	{
		bool ID;
		EDataType EAttributeType;
	}

	class EReference : EStructuralFeature
	{
		bool Containment;
		bool Container;
		bool ResolveProxies = "true";
		EReference EOpposite;
		derived EClass EReferenceType;
	}

	class EOperation : ETypedElement
	{
		EClass EContainingClass;
		containment list<EParameter> EParameters;
		list<EClassifier> EExceptions;
		containment list<ETypeParameter> ETypeParameters;
		containment list<EGenericType> EGenericExceptions;
	}

	class EParameter : ETypedElement
	{
		EOperation EOperation;
	}

	class EGenericType
	{
		EClassifier EClassifier;
		EClassifier ERawType;
		ETypeParameter ETypeParameter;
		containment EGenericType ELowerBound;
		containment EGenericType EUpperBound;
		containment list<EGenericType> ETypeArguments;
	}

	class ETypeParameter : ENamedElement
	{
		list<EGenericType> EGenericTypes;
		containment list<EGenericType> EBounds;
	}

	association EModelElement.Annotations with EAnnotation.EModelElement;
	association EPackage.ESuperPackage with EPackage.ESubPackages;
	association EPackage.EClassifiers with EClassifier.EPackage;
	association EEnum.ELiterals with EEnumLiteral.EEnum;
	association EClass.EStructuralFeatures with EStructuralFeature.EContainingClass;
	association EOperation.EParameters with EParameter.EOperation;
	association EClass.EOperations with EOperation.EContainingClass;
	association EGenericType.ETypeParameter with ETypeParameter.EGenericTypes;
}

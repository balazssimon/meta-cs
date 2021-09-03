namespace MetaDslx.Languages.Ecore.Model
{
	using MetaDslx.CodeAnalysis.Symbols;

	metamodel Ecore(Uri="http://www.eclipse.org/emf/2002/Ecore"); 

	/// EJavaObject is a type representing the object type. In Java it is java.lang.Object. In .NET it is System.Object.
	const EDataType EJavaObject = "System.Object";
	/// EJavaClass is a type representing the type concept. In Java it is java.lang.Class. In .NET it is System.Type.
	const EDataType EJavaClass = "System.Type";
	/// EBoolean is used for logical expressions, consisting of the predefined values true and false.

	const EDataType EBoolean = "System.Boolean";
	/// EString is a sequence of characters in some suitable character set used to display information 
	/// about the model. Character sets may include non-Roman alphabets and characters.
	const EDataType EString = "System.String";
	/// EByte is a primitive type representing byte values.

	const EDataType EByte = "System.Byte";
	/// EByteArray is a primitive type representing a byte array.
	const EDataType EByteArray = "byte[]";
	/// EChar is a primitive type representing character values.
	const EDataType EChar = "System.Char";
	/// EShort is a primitive type representing short integer values.
	const EDataType EShort = "System.Int16";
	/// EInt is a primitive type representing integer values.
	const EDataType EInt = "System.Int32";
	/// ELong is a primitive type representing long integer values.
	const EDataType ELong = "System.Int64";
	/// EFloat is a primitive type representing the mathematical concept of real.
	const EDataType EFloat = "System.Single";
	/// EDouble is a primitive type representing the mathematical concept of real.
	const EDataType EDouble = "System.Double";

	/// EByteObject is a reference type representing byte values.
	const EDataType EByteObject = "byte?";
	/// ECharObject is a reference type representing character values.
	const EDataType ECharObject = "char?";
	/// EShortObject is a reference type representing short integer values.
	const EDataType EShortObject = "short?";
	/// EIntObject is a reference type representing integer values.
	const EDataType EIntObject = "int?";
	/// ELongObject is a reference type representing long integer values.
	const EDataType ELongObject = "long?";
	/// EFloatObject is a reference type representing the mathematical concept of real.
	const EDataType EFloatObject = "float?";
	/// EDoubleObject is a reference type representing the mathematical concept of real.
	const EDataType EDoubleObject = "double?";

	/// EDate is a reference type representing a date.
	const EDataType EDate = "System.DateTime";
	/// EBigInteger is a reference type representing an unlimited integer value.
	const EDataType EBigInteger = "System.Numerics.BigInteger";
	/// EBigDecimal is a reference type representing an unlimited decimal value.
	const EDataType EBigDecimal = "System.Decimal";

	/// EResource is a reference type representing a model. In Ecore it is org.eclipse.emf.ecore.resource.Resource. In MetaDslx it is MetaDslx.Modeling.IModel.
	const EDataType EResource = "MetaDslx.Modeling.IModel";
	/// EResourceSet is a reference type representing a model group. In Ecore it is org.eclipse.emf.ecore.resource.ResourceSet. In MetaDslx it is MetaDslx.Modeling.IModelGroup.
	const EDataType EResourceSet = "MetaDslx.Modeling.IModelGroup";

	/// EFeatureMap is a reference type representing a feature map.
	const EDataType EFeatureMap = "System.Collections.Generic.Dictionary<EStructuralFeature,object>";
	/// EFeatureMapEntry is a reference type representing a feature map entry.
	const EDataType EFeatureMapEntry = "System.Collections.Generic.KeyValuePair<EStructuralFeature,object>";

	/// EEList is a reference type representing an ecore EList.
	const EDataType EEList = "System.Collections.Generic.IReadOnlyList<object>";
	/// EEnumerator is a reference type representing an enumerator.
	const EDataType EEnumerator = "System.Collections.IEnumerator";
	/// ETreeIterator is a reference type representing a tree iterator.
	const EDataType ETreeIterator = "System.Collections.IEnumerator";

	[symbol: Symbol]
	class EObject
	{
		EClass EClass();
		bool EIsProxy();
		EResource EResource();
		EObject EContainer();
		EStructuralFeature EContainingFeature();
		EReference EContainmentFeature();
		EEList EContents();
		ETreeIterator EAllContents();
		EEList ECrossReferences();
		EJavaObject EGet(EStructuralFeature feature);
		EJavaObject EGet(EStructuralFeature feature, bool resolve);
		EJavaObject ESet(EStructuralFeature feature, EJavaObject newValue);
		bool EIsSet(EStructuralFeature feature);
		void EUnset(EStructuralFeature feature);
	}

	abstract class EModelElement : EObject
	{
		containment list<EAnnotation> EAnnotations;
		readonly EAnnotation GetEAnnotation(string source);
	}

	class EFactory : EModelElement
	{
		EPackage EPackage;
		EObject Create(EClass eClass);
		EObject CreateFromString(EDataType eDataType, string literalValue);
		string ConvertToString(EDataType eDataType, EJavaObject instanceValue);
	}

	abstract class ENamedElement : EModelElement
	{
		[property: Name]
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

	[symbol: Namespace]
	class EPackage : ENamedElement
	{
		string NsURI;
		string NsPrefix;
		EPackage ESuperPackage;
		[property: Members]
		containment list<EPackage> ESubPackages;
		[property: Members]
		containment list<EClassifier> EClassifiers;
		EFactory EFactoryInstance;
		EClassifier GetEClassifier(string name);
	}

	[symbol: NamedType]
	class EClassifier : ENamedElement
	{
		string InstanceClassName;
		EPackage EPackage;
		[property: TypeParameters]
		containment list<ETypeParameter> ETypeParameters;

		EJavaClass InstanceClass;
		EJavaObject DefaultValue;
		/// <summary>
		/// Returns whether the object is an instance of this classifier.
		/// </summary>
		bool IsInstance(EJavaObject @object);
		int GetClassifierID();
	}

	[type: Class]
	class EClass : EClassifier
	{
		[property: IsAbstract]
		bool Abstract;
		bool Interface;
		[property: BaseTypes]
		list<EClass> ESuperTypes;
		derived list<EClass> EAllSuperTypes;
		[property: Members]
		containment list<EStructuralFeature> EStructuralFeatures;
		derived list<EStructuralFeature> EAllStructuralFeatures;
		[property: Members]
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

	[type: Named]
	class EDataType : EClassifier
	{
		bool Serializable = "true";
		string DotNetName; // TODO:MetaDslx remove???
	}

	[type: Enum]
	class EEnum : EDataType
	{
		[property: Members]
		containment list<EEnumLiteral> ELiterals;
		EEnumLiteral GetEEnumLiteral(string name);
		EEnumLiteral GetEEnumLiteral(int value);
	}

	[symbol: EnumLiteral]
	class EEnumLiteral : ENamedElement
	{
		EEnum EEnum;
		int Value;
		EEnumerator Instance;
	}

	class ETypedElement : ENamedElement
	{
		EClassifier EType;
		bool Ordered = "true";
		bool Unique = "true";
		int LowerBound;
		int UpperBound = "1";
		derived bool Many;
		derived bool Required;
		containment EGenericType EGenericType;
	}

	[symbol: Property]
	class EStructuralFeature : ETypedElement
	{
		EClass EContainingClass;
		[property: Type]
		EClassifier EType redefines ETypedElement.EType;
		bool Changeable = "true";
		bool Volatile;
		bool Transient;
		string DefaultValueLiteral;
		EJavaObject DefaultValue;
		bool Unsettable;
		bool Derived;
		int GetFeatureID();
		EJavaClass GetContainerClass();
	}

	class EAttribute : EStructuralFeature
	{
		bool ID;
		derived EDataType EAttributeType;
	}

	class EReference : EStructuralFeature
	{
		bool Containment;
		derived bool Container;
		bool ResolveProxies = "true";
		EReference EOpposite;
		EClass EReferenceType redefines EStructuralFeature.EType; // TODO: match with EType
	}

	[symbol: Method]
	class EOperation : ETypedElement
	{
		EClass EContainingClass;
		[property: ReturnType]
		EClassifier EType redefines ETypedElement.EType;
		[property: Parameters]
		containment list<EParameter> EParameters;
		list<EClassifier> EExceptions;
		[property: TypeParameters]
		containment list<ETypeParameter> ETypeParameters;
		containment list<EGenericType> EGenericExceptions;
	}

	[symbol: Parameter]
	class EParameter : ETypedElement
	{
		EOperation EOperation;
	}

	[type: Named]
	class EGenericType
	{
		EClassifier EClassifier;
		EClassifier ERawType;
		ETypeParameter ETypeParameter;
		containment EGenericType ELowerBound;
		containment EGenericType EUpperBound;
		[property: TypeArguments]
		containment list<EGenericType> ETypeArguments;
	}

	[symbol: TypeParameter]
	class ETypeParameter : ENamedElement
	{
		list<EGenericType> EGenericTypes;
		containment list<EGenericType> EBounds;
	}

	association EModelElement.EAnnotations with EAnnotation.EModelElement;
	association EPackage.ESuperPackage with EPackage.ESubPackages;
	association EPackage.EClassifiers with EClassifier.EPackage;
	association EEnum.ELiterals with EEnumLiteral.EEnum;
	association EClass.EStructuralFeatures with EStructuralFeature.EContainingClass;
	association EOperation.EParameters with EParameter.EOperation;
	association EClass.EOperations with EOperation.EContainingClass;
	association EGenericType.ETypeParameter with ETypeParameter.EGenericTypes;
}

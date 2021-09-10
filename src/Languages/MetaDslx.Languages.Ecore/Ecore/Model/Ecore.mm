﻿namespace MetaDslx.Languages.Ecore.Model
{
    using MetaDslx.CodeAnalysis.Symbols;

    metamodel Ecore(Uri="http://www.eclipse.org/emf/2002/Ecore",Prefix="ecore"); 

    const EDataType EBigDecimal;
    const EDataType EBigInteger;
    const EDataType EBoolean;
    const EDataType EBooleanObject;
    const EDataType EByte;
    const EDataType EByteArray;
    const EDataType EByteObject;
    const EDataType EChar;
    const EDataType ECharacterObject;
    const EDataType EDate;
    const EDataType EDiagnosticChain;
    const EDataType EDouble;
    const EDataType EDoubleObject;
    const EDataType EEList;
    const EDataType EEnumerator;
    const EDataType EFeatureMap;
    const EDataType EFeatureMapEntry;
    const EDataType EFloat;
    const EDataType EFloatObject;
    const EDataType EInt;
    const EDataType EIntegerObject;
    const EDataType EJavaClass;
    const EDataType EJavaObject;
    const EDataType ELong;
    const EDataType ELongObject;
    const EDataType EMap;
    const EDataType EResource;
    const EDataType EResourceSet;
    const EDataType EShort;
    const EDataType EShortObject;
    const EDataType EString;
    const EDataType ETreeIterator;
    const EDataType EInvocationTargetException;

    class EAttribute : EStructuralFeature
    {
    	EBoolean ID;
    	derived EDataType EAttributeType;
    }

    class EAnnotation : EModelElement
    {
    	EString Source;
    	containment list<EStringToStringMapEntry> Details;
    	EModelElement EModelElement;
    	containment list<EObject> Contents;
    	list<EObject> References;
    }

    class EClass : EClassifier
    {
    	EBoolean Abstract;
    	EBoolean Interface;
    	list<EClass> ESuperTypes;
    	containment list<EOperation> EOperations;
    	derived list<EAttribute> EAllAttributes;
    	derived list<EReference> EAllReferences;
    	derived list<EReference> EReferences;
    	derived list<EAttribute> EAttributes;
    	derived list<EReference> EAllContainments;
    	derived list<EOperation> EAllOperations;
    	derived list<EStructuralFeature> EAllStructuralFeatures;
    	derived list<EClass> EAllSuperTypes;
    	derived EAttribute EIDAttribute;
    	containment list<EStructuralFeature> EStructuralFeatures;
    	containment list<EGenericType> EGenericSuperTypes;
    	derived list<EGenericType> EAllGenericSuperTypes;
    	EBoolean IsSuperTypeOf(EClass someClass);
    	EInt GetFeatureCount();
    	EStructuralFeature GetEStructuralFeature(EInt featureID);
    	EInt GetFeatureID(EStructuralFeature feature);
    	EStructuralFeature GetEStructuralFeature(EString featureName);
    	EInt GetOperationCount();
    	EOperation GetEOperation(EInt operationID);
    	EInt GetOperationID(EOperation operation);
    	EOperation GetOverride(EOperation operation);
    	EGenericType GetFeatureType(EStructuralFeature feature);
    }

    abstract class EClassifier : ENamedElement
    {
        string DotNetName; // TODO:MetaDslx: replace with InstanceClassName
    	EString InstanceClassName;
    	derived EJavaClass InstanceClass;
    	derived EJavaObject DefaultValue;
    	EString InstanceTypeName;
    	EPackage EPackage;
    	containment list<ETypeParameter> ETypeParameters;
    	EBoolean IsInstance(EJavaObject @object);
    	EInt GetClassifierID();
    }

    class EDataType : EClassifier
    {
    	EBoolean Serializable = "true";
    }

    class EEnum : EDataType
    {
    	containment list<EEnumLiteral> ELiterals;
    	EEnumLiteral GetEEnumLiteral(EString name);
    	EEnumLiteral GetEEnumLiteral(EInt value);
    	EEnumLiteral GetEEnumLiteralByLiteral(EString literal);
    }

    class EEnumLiteral : ENamedElement
    {
    	EInt Value;
    	EEnumerator Instance;
    	EString Literal;
    	EEnum EEnum;
    }

    class EFactory : EModelElement
    {
    	EPackage EPackage;
    	EObject Create(EClass eClass);
    	EJavaObject CreateFromString(EDataType eDataType, EString literalValue);
    	EString ConvertToString(EDataType eDataType, EJavaObject instanceValue);
    }

    abstract class EModelElement
    {
    	containment list<EAnnotation> EAnnotations;
    	EAnnotation GetEAnnotation(EString source);
    }

    [symbol: DeclaredSymbol]
    abstract class ENamedElement : EModelElement
    {
        [property: Name]
    	EString Name;
    }

    class EObject
    {
    	EClass EClass();
    	EBoolean EIsProxy();
    	EResource EResource();
    	EObject EContainer();
    	EStructuralFeature EContainingFeature();
    	EReference EContainmentFeature();
    	list<EObject> EContents();
    	enumerable<EObject> EAllContents();
    	list<EObject> ECrossReferences();
    	EJavaObject EGet(EStructuralFeature feature);
    	EJavaObject EGet(EStructuralFeature feature, EBoolean resolve);
    	void ESet(EStructuralFeature feature, EJavaObject newValue);
    	EBoolean EIsSet(EStructuralFeature feature);
    	void EUnset(EStructuralFeature feature);
    	EJavaObject EInvoke(EOperation operation, list<object> arguments);
    }

    class EOperation : ETypedElement
    {
    	EClass EContainingClass;
    	containment list<ETypeParameter> ETypeParameters;
    	containment list<EParameter> EParameters;
    	list<EClassifier> EExceptions;
    	containment list<EGenericType> EGenericExceptions;
    	EInt GetOperationID();
    	EBoolean IsOverrideOf(EOperation someOperation);
    }

    class EPackage : ENamedElement
    {
    	EString NsURI;
    	EString NsPrefix;
    	EFactory EFactoryInstance;
    	containment list<EClassifier> EClassifiers;
    	containment list<EPackage> ESubpackages;
    	EPackage ESuperPackage;
    	EClassifier GetEClassifier(EString name);
    }

    class EParameter : ETypedElement
    {
    	EOperation EOperation;
    }

    class EReference : EStructuralFeature
    {
    	EBoolean Containment;
    	derived EBoolean Container;
    	EBoolean ResolveProxies = "true";
    	EReference EOpposite;
    	derived EClass EReferenceType;
    	list<EAttribute> EKeys;
    }

    abstract class EStructuralFeature : ETypedElement
    {
    	EBoolean Changeable = "true";
    	EBoolean Volatile;
    	EBoolean Transient;
    	EString DefaultValueLiteral;
    	derived EJavaObject DefaultValue;
    	EBoolean Unsettable;
    	EBoolean Derived;
    	EClass EContainingClass;
    	EInt GetFeatureID();
    	EJavaClass GetContainerClass();
    }

    abstract class ETypedElement : ENamedElement
    {
    	EBoolean Ordered = "true";
    	EBoolean Unique = "true";
    	EInt LowerBound;
    	EInt UpperBound = "1";
    	derived EBoolean Many;
    	derived EBoolean Required;
    	EClassifier EType;
    	containment EGenericType EGenericType;
    }

    class EStringToStringMapEntry
    {
    	EString Key;
    	EString Value;
    }

    class EGenericType
    {
    	containment EGenericType EUpperBound;
    	containment list<EGenericType> ETypeArguments;
    	derived EClassifier ERawType;
    	containment EGenericType ELowerBound;
    	ETypeParameter ETypeParameter;
    	EClassifier EClassifier;
    	EBoolean IsInstance(EJavaObject @object);
    }

    class ETypeParameter : ENamedElement
    {
    	containment list<EGenericType> EBounds;
    }

    association EAnnotation.EModelElement with EModelElement.EAnnotations;
    association EClass.EOperations with EOperation.EContainingClass;
    association EClass.EStructuralFeatures with EStructuralFeature.EContainingClass;
    association EClassifier.EPackage with EPackage.EClassifiers;
    association EEnum.ELiterals with EEnumLiteral.EEnum;
    association EFactory.EPackage with EPackage.EFactoryInstance;
    association EOperation.EParameters with EParameter.EOperation;
    association EPackage.ESubpackages with EPackage.ESuperPackage;
}
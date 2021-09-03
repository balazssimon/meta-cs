namespace MetaDslx.Languages.Xcore.Model
{
	using MetaDslx.CodeAnalysis.Symbols;
	//using MetaDslx.Languages.Ecore.Model;

	metamodel Xcore(Uri="http://www.eclipse.org/emf/2011/Xcore"); 

	// TODO: import
	class EObject {}
	class JvmTypeReference {}
	class XBlockExpression {}
	class GenBase {}
	class GenFeature {}

	class XAnnotation : XModelElement
	{
		XAnnotationDirective Source;
		containment list<XStringToStringMapEntry> Details;
		XModelElement ModelElement; // transient
	}

	class XAnnotationDirective : XNamedElement
	{
		string SourceURI;
	}

	class XAttribute : XStructuralFeature
	{
		string DefaultValueLiteral;
		bool ID;
	}

	class XClass : XClassifier
	{
		bool Abstract;
		bool Interface;
		containment list<XMember> Members;
		containment list<XGenericType> SuperTypes;
	}

	class XClassifier : XNamedElement
	{
		containment JvmTypeReference InstanceType;
		XPackage Package;
		containment list<XTypeParameter> TypeParameters;
	}

	class XDataType : XClassifier
	{
		bool Serializable;
		containment XBlockExpression CreateBody;
		containment XBlockExpression ConvertBody;
	}

	class XEnum : XDataType
	{
		containment list<XEnumLiteral> Literals;
	}

	class XEnumLiteral : XNamedElement
	{
		int Value;
		string Literal;
		XEnum Enum;
	}

	class XGenericType
	{
		containment XGenericType UpperBound;
		containment XGenericType LowerBound;
		containment list<XGenericType> TypeArguments;
		GenBase Type;
	}

	class XImportDirective : XModelElement
	{
		string ImportedNamespace;
		EObject ImportedObject;
	}

	abstract class XMember : XTypedElement
	{
		XClass ContainingClass;
	}

	abstract class XModelElement
	{
		containment list<XAnnotation> Annotations;
	}

	abstract class XNamedElement : XModelElement
	{
	}

	class XOperation : XMember
	{
		containment list<XTypeParameter> TypeParameters;
		containment list<XParameter> Parameters;
		containment list<XGenericType> Exceptions;
		containment XBlockExpression Body;
	}

	class XPackage : XNamedElement
	{
		containment list<XImportDirective> ImportDirectives;
		containment list<XAnnotationDirective> AnnotationDirectives;
		containment list<XClassifier> Classifiers;
	}

	class XParameter : XTypedElement
	{
		XOperation Operation;
	}

	class XReference : XStructuralFeature
	{
		bool Container;
		bool Containment;
		bool ResolveProxies;
		bool Local;
		GenFeature Opposite;
		list<GenFeature> Keys;
	}

	class XStringToStringMapEntry
	{
		string Key;
		string Value;
	}

	abstract class XStructuralFeature : XMember
	{
		bool Readonly;
		bool Volatile;
		bool Transient;
		bool Unsettable;
		bool Derived;
		containment XBlockExpression GetBody;
		containment XBlockExpression SetBody;
		containment XBlockExpression IsSetBody;
		containment XBlockExpression UnsetBody;
	}

	abstract class XTypedElement : XNamedElement
	{
		bool Unordered;
		bool Unique;
		containment XGenericType Type;
		XMultiplicity Multiplicity;
	}

	class XTypeParameter : XNamedElement
	{
		containment list<XGenericType> Bounds;
	}

	class XMultiplicity 
	{
		int LowerBound;
		int UpperBound;
	}
}

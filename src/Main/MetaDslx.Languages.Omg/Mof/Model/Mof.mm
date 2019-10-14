namespace MetaDslx.Languages.Mof.Model
{
	metamodel Mof(Uri="http://www.omg.org/spec/MOF/20131001"); 

	// Boolean is used for logical expressions, consisting of the predefined values true and false.
	const PrimitiveType Boolean;
	// Integer is a primitive type representing integer values.
	const PrimitiveType Integer;
	// Real is a primitive type representing the mathematical concept of real.
	const PrimitiveType Real;
	// String is a sequence of characters in some suitable character set used to display information 
	// about the model. Character sets may include non-Roman alphabets and characters.
	const PrimitiveType String;
	// UnlimitedNatural is a primitive type representing unlimited natural values.
	const PrimitiveType UnlimitedNatural;

	abstract class Element
	{
		containment list<Element> OwnedElement; // ???
		list<Tag> Tag;
		containment list<Comment> OwnedComment;
		list<Comment> Comment;
	}

	class Comment
	{
		Element OwningElement;
		list<Element> AnnotatedElement;
		list<string> Body;
	}

	association Comment.OwningElement with Element.OwnedComment;
	association Comment.AnnotatedElement with Element.Comment;

	class Tag
	{
		[Name]
		string Name;
		string Value;
		list<Element> Element;
	}

	association Element.Tag with Tag.Element;

	abstract class NamedElement : Element
	{
		[Name]
		string Name;
		derived string QualifiedName;
		VisibilityKind Visibility;
	}

	abstract class PackageableElement : NamedElement
	{
		Package OwningPackage;
		list<PackageMerge> PackageMerge;
	}

	enum VisibilityKind
	{
		Public
	}

	[Type]
	abstract class Type : PackageableElement
	{
		Package Package redefines PackageableElement.OwningPackage;
		// list<TypedElement> TypedElement;
	}

	abstract class TypedElement : NamedElement
	{
		[Type]
		Type Type;
	}

	// association TypedElement.Type with Type.TypedElement;

	abstract class Namespace : NamedElement
	{
	}

	abstract class Classifier : Type, Namespace
	{
		bool IsAbstract;
		list<Generalization> Generalization;
	}

	class Package : Namespace, PackageableElement
	{
		Package NestingPackage redefines PackageableElement.OwningPackage;
		containment list<PackageableElement> PackagedElement;
		containment list<Type> OwnedType subsets PackagedElement;
		containment list<Package> NestedPackage subsets PackagedElement;
	}

	association Package.PackagedElement with PackageableElement.OwningPackage;
	association Package.OwnedType with Type.Package;
	association Package.NestedPackage with Package.NestingPackage;

	class DataType : Classifier
	{
	}

	class PrimitiveType : DataType
	{
	}

	class Enumeration : DataType
	{
		containment list<EnumerationLiteral> OwnedLiteral;
	}

	class EnumerationLiteral : InstanceSpecification
	{
		Enumeration Enumeration;
	}

	association EnumerationLiteral.Enumeration with Enumeration.OwnedLiteral;

	class Class : Classifier
	{
		derived list<Class> SuperClass;
		containment list<Property> OwnedAttribute;
		containment list<Operation> OwnedOperation;
	}

	abstract class Feature
	{
	}

	abstract class MultiplicityElement
	{
		bool IsOrdered;
		bool IsUnique;
		derived long Lower;
		derived long Upper;
	}

	abstract class StructuralFeature : Feature, TypedElement, MultiplicityElement
	{
		bool IsReadOnly;
	}

	class Property : StructuralFeature
	{
		Class Class;
		bool IsID;
		bool IsDerived;
		bool IsDerivedUnion;
		AggregationKind Aggregation;
		list<Association> Association;
		list<Association> OwningAssociation subsets Association;
		derived Property Opposite;
		derived string Default;
		derived bool IsComposite;
	}

	association Property.Class with Class.OwnedAttribute;

	enum AggregationKind
	{
		None,
		Shared,
		Composite
	}

	abstract class Relationship
	{
	}

	class Association : Classifier, Relationship
	{
		containment list<Property> OwnedEnd subsets MemberEnd;
		list<Property> MemberEnd;
		list<Property> NavigableOwnedEnd subsets OwnedEnd;
	}

	association Association.OwnedEnd with Property.OwningAssociation;
	association Association.MemberEnd with Property.Association;

	class Operation
	{
		Class Class;
		derived bool IsOrdered;
		derived bool IsUnique;
		derived long Lower;
		derived long Upper;
		containment list<Parameter> OwnedParameter;
		list<Type> RaisedException;
	}

	association Operation.Class with Class.OwnedOperation;

	class Parameter : TypedElement, MultiplicityElement
	{
		Operation Operation;
		ParameterDirectionKind Direction;
	}

	association Operation.OwnedParameter with Parameter.Operation;

	enum ParameterDirectionKind
	{
		In,
		Return
	}

	class Generalization
	{
		Classifier General;
		Classifier Specific;
	}

	association Classifier.Generalization with Generalization.General;
	association Classifier.Generalization with Generalization.Specific;

	abstract class ValueSpecification
	{
	}

	class InstanceValue : ValueSpecification
	{
		InstanceSpecification Instance;
	}

	class DataValue : ValueSpecification, ElementInstance
	{
		DataType Classifier; // redefines Classifier;
	}

	class PrimitiveDataValue : DataValue
	{
		PrimitiveType Classifier; // redefines Classifier;
	}

	class InstanceSpecification : PackageableElement
	{
		containment list<Slot> Slot subsets Element.OwnedElement;
	}

	class Instance : InstanceSpecification
	{
	}

	class ObjectInstance : Instance
	{
	}

	class ElementInstance : Instance
	{
		containment list<StructureSlot> Slot redefines Element.OwnedElement;
	}

	class AssociationInstance : ObjectInstance
	{
		Association Classifier; // redefines Classifier;
		containment Slot FirstSlot subsets InstanceSpecification.Slot;
		containment Slot SecondSlot subsets InstanceSpecification.Slot;
	}

	class ClassInstance : ObjectInstance, ElementInstance
	{
		Class Classifier; // redefines Classifier;
	}

	class Slot
	{
		InstanceSpecification OwningInstance;
		containment list<ValueSpecification> Value subsets Element.OwnedElement;
	}

	class LinkSlot : Slot
	{
		AssociationInstance OwningInstance; // redefines OwningInstance;
	}

	association LinkSlot.OwningInstance with AssociationInstance.FirstSlot;
	association LinkSlot.OwningInstance with AssociationInstance.SecondSlot;

	class StructureSlot
	{
		ElementInstance OwningInstance redefines Slot.OwningInstance;
	}

	association StructureSlot.OwningInstance with ElementInstance.Slot;

	class Extent
	{
	}

	class ExtentImplementation // ExtentImpl
	{
		containment list<IdentifierEntry> Entry;
	}

	class IdentifierEntry
	{
		string Identifier;
		ObjectInstance Object;
	}

	class PackageMerge
	{
		Package MergedPackage;
	}
}

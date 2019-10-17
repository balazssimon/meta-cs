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
		Element Owner;
		containment list<Element> OwnedElement;
		list<Tag> Tag;
		containment list<Comment> OwnedComment;
		list<Comment> Comment;
		list<Relationship> Relationship;
	}

	association Element.Owner with Element.OwnedElement;

	class Comment
	{
		Element OwningElement redefines Element.Owner;
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
		Namespace Namespace;
		derived Namespace MemberNamespace;
	}

	abstract class PackageableElement : NamedElement
	{
		Package OwningPackage;
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
		containment list<Constraint> OwnedRule;
		containment list<NamedElement> OwnedMember;
		derived list<NamedElement> Member;
		containment list<PackageImport> PackageImport;
	}

	association Namespace.OwnedMember with NamedElement.Namespace;
	association Namespace.Member with NamedElement.MemberNamespace;

	abstract class Classifier : Type, Namespace
	{
		bool IsAbstract;
		containment list<Generalization> Generalization;
	}

	class Package : Namespace, PackageableElement
	{
		string URI;
		Package NestingPackage redefines PackageableElement.OwningPackage;
		containment list<PackageableElement> PackagedElement subsets Namespace.OwnedMember;
		containment list<Type> OwnedType subsets PackagedElement;
		containment list<Package> NestedPackage subsets PackagedElement;
		containment list<PackageMerge> PackageMerge;
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
		containment list<Property> OwnedAttribute subsets Element.OwnedElement;
		containment list<Operation> OwnedOperation subsets Element.OwnedElement;
	}

	abstract class Feature
	{
	}

	abstract class MultiplicityElement : Element
	{
		bool IsOrdered;
		bool IsUnique = "true";
		ValueSpecification LowerValue subsets Element.OwnedElement;
		ValueSpecification UpperValue subsets Element.OwnedElement;
		derived long Lower;
		derived long Upper;
	}

	abstract class StructuralFeature : Feature, TypedElement, MultiplicityElement
	{
		bool IsReadOnly;
	}

	class Property : StructuralFeature
	{
		Class Class subsets Element.Owner;
		ValueSpecification DefaultValue subsets Element.OwnedElement;
		bool IsID;
		bool IsDerived;
		bool IsDerivedUnion;
		AggregationKind Aggregation;
		list<Association> Association;
		list<Association> OwningAssociation subsets Association;
		list<Property> RedefinedProperty;
		list<Property> SubsettedProperty;
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

	abstract class Relationship : Element
	{
		derived list<Element> RelatedElement;
	}

	association Relationship.RelatedElement with Element.Relationship;

	abstract class DirectedRelationship : Relationship
	{
		list<Element> Source subsets Relationship.RelatedElement;
		list<Element> Target subsets Relationship.RelatedElement;
	}

	class Association : Classifier, Relationship
	{
		bool IsDerived;
		containment list<Property> OwnedEnd subsets MemberEnd, Namespace.OwnedMember;
		list<Property> MemberEnd;
		list<Property> NavigableOwnedEnd subsets OwnedEnd;
	}

	association Association.OwnedEnd with Property.OwningAssociation;
	association Association.MemberEnd with Property.Association;

	abstract class BehavioralFeature : Feature, Namespace
	{
		bool IsReadOnly;
	}

	class Operation : BehavioralFeature
	{
		Class Class subsets Element.Owner;
		bool IsAbstract;
		bool IsQuery;
		derived bool IsOrdered;
		derived bool IsUnique;
		derived long Lower;
		derived long Upper;
		containment list<Parameter> OwnedParameter;
		list<Type> RaisedException;
		list<Operation> RedefinedOperation;
		containment list<Constraint> Precondition;
		containment list<Constraint> Postcondition;
		containment list<Constraint> BodyCondition;
	}

	association Operation.Class with Class.OwnedOperation;

	class Parameter : TypedElement, MultiplicityElement
	{
		bool IsStream;
		Operation Operation;
		ParameterDirectionKind Direction;
	}

	association Operation.OwnedParameter with Parameter.Operation;

	enum ParameterDirectionKind
	{
		In,
		Return
	}

	class Generalization : DirectedRelationship
	{
		Classifier General subsets DirectedRelationship.Target;
		Classifier Specific subsets DirectedRelationship.Source, Element.Owner;
	}

	//association Classifier.Generalization with Generalization.General;
	association Classifier.Generalization with Generalization.Specific;

	abstract class ValueSpecification : TypedElement, PackageableElement
	{
		Constraint OwningConstraint subsets Element.Owner;
		MultiplicityElement OwningLower subsets Element.Owner;
		MultiplicityElement OwningUpper subsets Element.Owner;
		Property OwningProperty subsets Element.Owner;
	}

	association ValueSpecification.OwningLower with MultiplicityElement.LowerValue;
	association ValueSpecification.OwningUpper with MultiplicityElement.UpperValue;
	association ValueSpecification.OwningProperty with Property.DefaultValue;

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

	class PackageMerge : DirectedRelationship
	{
		Package MergedPackage subsets DirectedRelationship.Target;
		Package ReceivingPackage subsets DirectedRelationship.Source, Element.Owner;
	}

	association PackageMerge.ReceivingPackage with Package.PackageMerge;

	class PackageImport : DirectedRelationship
	{
		Package ImportedPackage subsets DirectedRelationship.Target;
		Namespace ImportingNamespace subsets DirectedRelationship.Source, Element.Owner;
	}

	association PackageImport.ImportingNamespace with Namespace.PackageImport;

	class LiteralSpecification : ValueSpecification
	{
	}
	
	class LiteralNull : LiteralSpecification
	{
	}

	class LiteralBoolean : LiteralSpecification
	{
		bool Value;
	}

	class LiteralString : LiteralSpecification
	{
		string Value;
	}

	class LiteralInteger : LiteralSpecification
	{
		int Value;
	}

	class LiteralReal : LiteralSpecification
	{
		double Value;
	}

	class LiteralUnlimitedNatural : LiteralSpecification
	{
		long Value;
	}

	class Constraint : PackageableElement
	{
		Namespace Context;
		list<Element> ConstrainedElement;
		containment ValueSpecification Specification;
		Operation PreContext subsets Context;
		Operation PostContext subsets Context;
		Operation BodyContext subsets Context;
	}
	
	association Constraint.Context with Namespace.OwnedRule;
	association Constraint.Specification with ValueSpecification.OwningConstraint;
	association Constraint.PreContext with Operation.Precondition;
	association Constraint.PostContext with Operation.Postcondition;
	association Constraint.BodyContext with Operation.BodyCondition;

	class OpaqueExpression : ValueSpecification
	{
		string Body;
		string Language;
	}
}

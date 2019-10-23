namespace MetaDslx.Languages.Uml.Model
{
    metamodel Uml(Uri="http://www.omg.org/spec/UML"); 

    /// <summary>
    /// Boolean is used for logical expressions, consisting of the predefined values true and false.
    /// </summary>
    const PrimitiveType Boolean;
    /// <summary>
    /// Integer is a primitive type representing integer values.
    /// </summary>
    const PrimitiveType Integer;
    /// <summary>
    /// Real is a primitive type representing the mathematical concept of real.
    /// </summary>
    const PrimitiveType Real;
    /// <summary>
    /// String is a sequence of characters in some suitable character set used to display information about the model. Character sets may include non-Roman alphabets and characters.
    /// </summary>
    const PrimitiveType String;
    /// <summary>
    /// UnlimitedNatural is a primitive type representing unlimited natural values.
    /// </summary>
    const PrimitiveType UnlimitedNatural;

    /// <summary>
    /// ObjectNodeOrderingKind is an enumeration indicating queuing order for offering the tokens held by an ObjectNode.
    /// </summary>
    enum ObjectNodeOrderingKind
    {
        /// <summary>
        /// Indicates that tokens are unordered.
        /// </summary>
        Unordered,
        /// <summary>
        /// Indicates that tokens are ordered.
        /// </summary>
        Ordered,
        /// <summary>
        /// Indicates that tokens are queued in a last in, first out manner.
        /// </summary>
        LIFO,
        /// <summary>
        /// Indicates that tokens are queued in a first in, first out manner.
        /// </summary>
        FIFO
    }

    /// <summary>
    /// ConnectorKind is an enumeration that defines whether a Connector is an assembly or a delegation.
    /// </summary>
    enum ConnectorKind
    {
        /// <summary>
        /// Indicates that the Connector is an assembly Connector.
        /// </summary>
        Assembly,
        /// <summary>
        /// Indicates that the Connector is a delegation Connector.
        /// </summary>
        Delegation
    }

    /// <summary>
    /// PseudostateKind is an Enumeration type that is used to differentiate various kinds of Pseudostates.
    /// </summary>
    enum PseudostateKind
    {
        Initial,
        DeepHistory,
        ShallowHistory,
        Join,
        Fork,
        Junction,
        Choice,
        EntryPoint,
        ExitPoint,
        Terminate
    }

    /// <summary>
    /// TransitionKind is an Enumeration type used to differentiate the various kinds of Transitions.
    /// </summary>
    enum TransitionKind
    {
        /// <summary>
        /// Implies that the Transition, if triggered, occurs without exiting or entering the source State (i.e., it does not cause a state change). This means that the entry or exit condition of the source State will not be invoked. An internal Transition can be taken even if the SateMachine is in one or more Regions nested within the associated State.
        /// </summary>
        Internal,
        /// <summary>
        /// Implies that the Transition, if triggered, will not exit the composite (source) State, but it will exit and re-enter any state within the composite State that is in the current state configuration.
        /// </summary>
        Local,
        /// <summary>
        /// Implies that the Transition, if triggered, will exit the composite (source) State.
        /// </summary>
        External
    }

    /// <summary>
    /// InteractionOperatorKind is an enumeration designating the different kinds of operators of CombinedFragments. The InteractionOperand defines the type of operator of a CombinedFragment.
    /// </summary>
    enum InteractionOperatorKind
    {
        /// <summary>
        /// The InteractionOperatorKind seq designates that the CombinedFragment represents a weak sequencing between the behaviors of the operands.
        /// </summary>
        Seq,
        /// <summary>
        /// The InteractionOperatorKind alt designates that the CombinedFragment represents a choice of behavior. At most one of the operands will be chosen. The chosen operand must have an explicit or implicit guard expression that evaluates to true at this point in the interaction. An implicit true guard is implied if the operand has no guard.
        /// </summary>
        Alt,
        /// <summary>
        /// The InteractionOperatorKind opt designates that the CombinedFragment represents a choice of behavior where either the (sole) operand happens or nothing happens. An option is semantically equivalent to an alternative CombinedFragment where there is one operand with non-empty content and the second operand is empty.
        /// </summary>
        Opt,
        /// <summary>
        /// The InteractionOperatorKind break designates that the CombinedFragment represents a breaking scenario in the sense that the operand is a scenario that is performed instead of the remainder of the enclosing InteractionFragment. A break operator with a guard is chosen when the guard is true and the rest of the enclosing Interaction Fragment is ignored. When the guard of the break operand is false, the break operand is ignored and the rest of the enclosing InteractionFragment is chosen. The choice between a break operand without a guard and the rest of the enclosing InteractionFragment is done non-deterministically.
        /// </summary>
        Break,
        /// <summary>
        /// The InteractionOperatorKind par designates that the CombinedFragment represents a parallel merge between the behaviors of the operands. The OccurrenceSpecifications of the different operands can be interleaved in any way as long as the ordering imposed by each operand as such is preserved.
        /// </summary>
        Par,
        /// <summary>
        /// The InteractionOperatorKind strict designates that the CombinedFragment represents a strict sequencing between the behaviors of the operands. The semantics of strict sequencing defines a strict ordering of the operands on the first level within the CombinedFragment with interactionOperator strict. Therefore OccurrenceSpecifications within contained CombinedFragment will not directly be compared with other OccurrenceSpecifications of the enclosing CombinedFragment.
        /// </summary>
        Strict,
        /// <summary>
        /// The InteractionOperatorKind loop designates that the CombinedFragment represents a loop. The loop operand will be repeated a number of times.
        /// </summary>
        Loop,
        /// <summary>
        /// The InteractionOperatorKind critical designates that the CombinedFragment represents a critical region. A critical region means that the traces of the region cannot be interleaved by other OccurrenceSpecifications (on those Lifelines covered by the region). This means that the region is treated atomically by the enclosing fragment when determining the set of valid traces. Even though enclosing CombinedFragments may imply that some OccurrenceSpecifications may interleave into the region, such as with par-operator, this is prevented by defining a region.
        /// </summary>
        Critical,
        /// <summary>
        /// The InteractionOperatorKind neg designates that the CombinedFragment represents traces that are defined to be invalid.
        /// </summary>
        Neg,
        /// <summary>
        /// The InteractionOperatorKind assert designates that the CombinedFragment represents an assertion. The sequences of the operand of the assertion are the only valid continuations. All other continuations result in an invalid trace.
        /// </summary>
        Assert,
        /// <summary>
        /// The InteractionOperatorKind ignore designates that there are some message types that are not shown within this combined fragment. These message types can be considered insignificant and are implicitly ignored if they appear in a corresponding execution. Alternatively, one can understand ignore to mean that the message types that are ignored can appear anywhere in the traces.
        /// </summary>
        Ignore,
        /// <summary>
        /// The InteractionOperatorKind consider designates which messages should be considered within this combined fragment. This is equivalent to defining every other message to be ignored.
        /// </summary>
        Consider
    }

    /// <summary>
    /// This is an enumerated type that identifies the type of Message.
    /// </summary>
    enum MessageKind
    {
        /// <summary>
        /// sendEvent and receiveEvent are present
        /// </summary>
        Complete,
        /// <summary>
        /// sendEvent present and receiveEvent absent
        /// </summary>
        Lost,
        /// <summary>
        /// sendEvent absent and receiveEvent present
        /// </summary>
        Found,
        /// <summary>
        /// sendEvent and receiveEvent absent (should not appear)
        /// </summary>
        Unknown
    }

    /// <summary>
    /// This is an enumerated type that identifies the type of communication action that was used to generate the Message.
    /// </summary>
    enum MessageSort
    {
        /// <summary>
        /// The message was generated by a synchronous call to an operation.
        /// </summary>
        SynchCall,
        /// <summary>
        /// The message was generated by an asynchronous call to an operation; i.e., a CallAction with isSynchronous = false.
        /// </summary>
        AsynchCall,
        /// <summary>
        /// The message was generated by an asynchronous send action.
        /// </summary>
        AsynchSignal,
        /// <summary>
        /// The message designating the creation of another lifeline object.
        /// </summary>
        CreateMessage,
        /// <summary>
        /// The message designating the termination of another lifeline.
        /// </summary>
        DeleteMessage,
        /// <summary>
        /// The message is a reply message to an operation call.
        /// </summary>
        Reply
    }

    /// <summary>
    /// VisibilityKind is an enumeration type that defines literals to determine the visibility of Elements in a model.
    /// </summary>
    enum VisibilityKind
    {
        /// <summary>
        /// A Named Element with public visibility is visible to all elements that can access the contents of the Namespace that owns it.
        /// </summary>
        Public,
        /// <summary>
        /// A NamedElement with private visibility is only visible inside the Namespace that owns it.
        /// </summary>
        Private,
        /// <summary>
        /// A NamedElement with protected visibility is visible to Elements that have a generalization relationship to the Namespace that owns it.
        /// </summary>
        Protected,
        /// <summary>
        /// A NamedElement with package visibility is visible to all Elements within the nearest enclosing Package (given that other owning Elements have proper visibility). Outside the nearest enclosing Package, a NamedElement marked as having package visibility is not visible.  Only NamedElements that are not owned by Packages can be marked as having package visibility. 
        /// </summary>
        Package
    }

    /// <summary>
    /// AggregationKind is an Enumeration for specifying the kind of aggregation of a Property.
    /// </summary>
    enum AggregationKind
    {
        /// <summary>
        /// Indicates that the Property has no aggregation.
        /// </summary>
        None,
        /// <summary>
        /// Indicates that the Property has shared aggregation.
        /// </summary>
        Shared,
        /// <summary>
        /// Indicates that the Property is aggregated compositely, i.e., the composite object has responsibility for the existence and storage of the composed objects (parts).
        /// </summary>
        Composite
    }

    /// <summary>
    /// CallConcurrencyKind is an Enumeration used to specify the semantics of concurrent calls to a BehavioralFeature.
    /// </summary>
    enum CallConcurrencyKind
    {
        /// <summary>
        /// No concurrency management mechanism is associated with the BehavioralFeature and, therefore, concurrency conflicts may occur. Instances that invoke a BehavioralFeature need to coordinate so that only one invocation to a target on any BehavioralFeature occurs at once.
        /// </summary>
        Sequential,
        /// <summary>
        /// Multiple invocations of a BehavioralFeature that overlap in time may occur to one instance, but only one is allowed to commence. The others are blocked until the performance of the currently executing BehavioralFeature is complete. It is the responsibility of the system designer to ensure that deadlocks do not occur due to simultaneous blocking.
        /// </summary>
        Guarded,
        /// <summary>
        /// Multiple invocations of a BehavioralFeature that overlap in time may occur to one instance and all of them may proceed concurrently.
        /// </summary>
        Concurrent
    }

    /// <summary>
    /// ParameterDirectionKind is an Enumeration that defines literals used to specify direction of parameters.
    /// </summary>
    enum ParameterDirectionKind
    {
        /// <summary>
        /// Indicates that Parameter values are passed in by the caller. 
        /// </summary>
        In,
        /// <summary>
        /// Indicates that Parameter values are passed in by the caller and (possibly different) values passed out to the caller.
        /// </summary>
        Inout,
        /// <summary>
        /// Indicates that Parameter values are passed out to the caller.
        /// </summary>
        Out,
        /// <summary>
        /// Indicates that Parameter values are passed as return values back to the caller.
        /// </summary>
        Return
    }

    /// <summary>
    /// ParameterEffectKind is an Enumeration that indicates the effect of a Behavior on values passed in or out of its parameters.
    /// </summary>
    enum ParameterEffectKind
    {
        /// <summary>
        /// Indicates that the behavior creates values.
        /// </summary>
        Create,
        /// <summary>
        /// Indicates objects that are values of the parameter have values of their properties, or links in which they participate, or their classifiers retrieved during executions of the behavior.
        /// </summary>
        Read,
        /// <summary>
        /// Indicates objects that are values of the parameter have values of their properties, or links in which they participate, or their classification changed during executions of the behavior.
        /// </summary>
        Update,
        /// <summary>
        /// Indicates objects that are values of the parameter do not exist after executions of the behavior are finished.
        /// </summary>
        Delete
    }

    /// <summary>
    /// ExpansionKind is an enumeration type used to specify how an ExpansionRegion executes its contents.
    /// </summary>
    enum ExpansionKind
    {
        /// <summary>
        /// The content of the ExpansionRegion is executed concurrently for the elements of the input collections.
        /// </summary>
        Parallel,
        /// <summary>
        /// The content of the ExpansionRegion is executed iteratively for the elements of the input collections, in the order of the input elements, if the collections are ordered.
        /// </summary>
        Iterative,
        /// <summary>
        /// A stream of input collection elements flows into a single execution of the content of the ExpansionRegion, in the order of the collection elements if the input collections are ordered.
        /// </summary>
        Stream
    }

    /// <summary>
    /// An Activity is the specification of parameterized Behavior as the coordinated sequencing of subordinate units.
    /// </summary>
    class Activity : Behavior
    {
    	/// <summary>
    	/// ActivityEdges expressing flow between the nodes of the Activity.
    	/// </summary>
    	containment set<ActivityEdge> Edge subsets Element.OwnedElement;
    	/// <summary>
    	/// Top-level ActivityGroups in the Activity.
    	/// </summary>
    	containment set<ActivityGroup> Group subsets Element.OwnedElement;
    	/// <summary>
    	/// If true, this Activity must not make any changes to objects. The default is false (an Activity may make nonlocal changes). (This is an assertion, not an executable property. It may be used by an execution engine to optimize model execution. If the assertion is violated by the Activity, then the model is ill-formed.) 
    	/// </summary>
    	bool IsReadOnly = "false";
    	/// <summary>
    	/// If true, all invocations of the Activity are handled by the same execution.
    	/// </summary>
    	bool IsSingleExecution = "false";
    	/// <summary>
    	/// ActivityNodes coordinated by the Activity.
    	/// </summary>
    	containment set<ActivityNode> Node subsets Element.OwnedElement;
    	/// <summary>
    	/// Top-level ActivityPartitions in the Activity.
    	/// </summary>
    	set<ActivityPartition> Partition subsets Activity.Group;
    	/// <summary>
    	/// Top-level StructuredActivityNodes in the Activity.
    	/// </summary>
    	containment set<StructuredActivityNode> StructuredNode subsets Activity.Group, Activity.Node;
    	/// <summary>
    	/// Top-level Variables defined by the Activity.
    	/// </summary>
    	containment set<Variable> Variable subsets Namespace.OwnedMember;
    }

    /// <summary>
    /// An ActivityEdge is an abstract class for directed connections between two ActivityNodes.
    /// </summary>
    abstract class ActivityEdge : RedefinableElement
    {
    	/// <summary>
    	/// The Activity containing the ActivityEdge, if it is directly owned by an Activity.
    	/// </summary>
    	Activity Activity subsets Element.Owner;
    	/// <summary>
    	/// A ValueSpecification that is evaluated to determine if a token can traverse the ActivityEdge. If an ActivityEdge has no guard, then there is no restriction on tokens traversing the edge.
    	/// </summary>
    	containment ValueSpecification Guard subsets Element.OwnedElement;
    	/// <summary>
    	/// ActivityGroups containing the ActivityEdge.
    	/// </summary>
    	union set<ActivityGroup> InGroup;
    	/// <summary>
    	/// ActivityPartitions containing the ActivityEdge.
    	/// </summary>
    	set<ActivityPartition> InPartition subsets ActivityEdge.InGroup;
    	/// <summary>
    	/// The StructuredActivityNode containing the ActivityEdge, if it is owned by a StructuredActivityNode.
    	/// </summary>
    	StructuredActivityNode InStructuredNode subsets ActivityEdge.InGroup, Element.Owner;
    	/// <summary>
    	/// The InterruptibleActivityRegion for which this ActivityEdge is an interruptingEdge.
    	/// </summary>
    	InterruptibleActivityRegion Interrupts;
    	/// <summary>
    	/// ActivityEdges from a generalization of the Activity containing this ActivityEdge that are redefined by this ActivityEdge.
    	/// </summary>
    	set<ActivityEdge> RedefinedEdge subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// The ActivityNode from which tokens are taken when they traverse the ActivityEdge.
    	/// </summary>
    	ActivityNode Source;
    	/// <summary>
    	/// The ActivityNode to which tokens are put when they traverse the ActivityEdge.
    	/// </summary>
    	ActivityNode Target;
    	/// <summary>
    	/// The minimum number of tokens that must traverse the ActivityEdge at the same time. If no weight is specified, this is equivalent to specifying a constant value of 1.
    	/// </summary>
    	containment ValueSpecification Weight subsets Element.OwnedElement;
    	// spec:
    	//     result = (redefiningElement.oclIsKindOf(ActivityEdge))
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// An ActivityFinalNode is a FinalNode that terminates the execution of its owning Activity or StructuredActivityNode.
    /// </summary>
    class ActivityFinalNode : FinalNode
    {
    }

    /// <summary>
    /// ActivityGroup is an abstract class for defining sets of ActivityNodes and ActivityEdges in an Activity.
    /// </summary>
    abstract class ActivityGroup : NamedElement
    {
    	/// <summary>
    	/// ActivityEdges immediately contained in the ActivityGroup.
    	/// </summary>
    	union set<ActivityEdge> ContainedEdge;
    	/// <summary>
    	/// ActivityNodes immediately contained in the ActivityGroup.
    	/// </summary>
    	union set<ActivityNode> ContainedNode;
    	/// <summary>
    	/// The Activity containing the ActivityGroup, if it is directly owned by an Activity.
    	/// </summary>
    	Activity InActivity subsets Element.Owner;
    	/// <summary>
    	/// Other ActivityGroups immediately contained in this ActivityGroup.
    	/// </summary>
    	containment union set<ActivityGroup> Subgroup subsets Element.OwnedElement;
    	/// <summary>
    	/// The ActivityGroup immediately containing this ActivityGroup, if it is directly owned by another ActivityGroup.
    	/// </summary>
    	ActivityGroup SuperGroup subsets Element.Owner;
    	/// <summary>
    	/// The Activity that directly or indirectly contains this ActivityGroup.
    	/// </summary>
    	// spec:
    	//     result = (if superGroup<>null then superGroup.containingActivity()
    	//     else inActivity
    	//     endif)
    	readonly Activity ContainingActivity();
    }

    /// <summary>
    /// ActivityNode is an abstract class for points in the flow of an Activity connected by ActivityEdges.
    /// </summary>
    abstract class ActivityNode : RedefinableElement
    {
    	/// <summary>
    	/// The Activity containing the ActivityNode, if it is directly owned by an Activity.
    	/// </summary>
    	Activity Activity subsets Element.Owner;
    	/// <summary>
    	/// ActivityGroups containing the ActivityNode.
    	/// </summary>
    	union set<ActivityGroup> InGroup;
    	/// <summary>
    	/// InterruptibleActivityRegions containing the ActivityNode.
    	/// </summary>
    	set<InterruptibleActivityRegion> InInterruptibleRegion subsets ActivityNode.InGroup;
    	/// <summary>
    	/// ActivityPartitions containing the ActivityNode.
    	/// </summary>
    	set<ActivityPartition> InPartition subsets ActivityNode.InGroup;
    	/// <summary>
    	/// The StructuredActivityNode containing the ActvityNode, if it is directly owned by a StructuredActivityNode.
    	/// </summary>
    	StructuredActivityNode InStructuredNode subsets ActivityNode.InGroup, Element.Owner;
    	/// <summary>
    	/// ActivityEdges that have the ActivityNode as their target.
    	/// </summary>
    	set<ActivityEdge> Incoming;
    	/// <summary>
    	/// ActivityEdges that have the ActivityNode as their source.
    	/// </summary>
    	set<ActivityEdge> Outgoing;
    	/// <summary>
    	/// ActivityNodes from a generalization of the Activity containining this ActivityNode that are redefined by this ActivityNode.
    	/// </summary>
    	set<ActivityNode> RedefinedNode subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// The Activity that directly or indirectly contains this ActivityNode.
    	/// </summary>
    	// spec:
    	//     result = (if inStructuredNode<>null then inStructuredNode.containingActivity()
    	//     else activity
    	//     endif)
    	readonly Activity ContainingActivity();
    	// spec:
    	//     result = (redefiningElement.oclIsKindOf(ActivityNode))
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// An ActivityParameterNode is an ObjectNode for accepting values from the input Parameters or providing values to the output Parameters of an Activity.
    /// </summary>
    class ActivityParameterNode : ObjectNode
    {
    	/// <summary>
    	/// The Parameter for which the ActivityParameterNode will be accepting or providing values.
    	/// </summary>
    	Parameter Parameter;
    }

    /// <summary>
    /// An ActivityPartition is a kind of ActivityGroup for identifying ActivityNodes that have some characteristic in common.
    /// </summary>
    class ActivityPartition : ActivityGroup
    {
    	/// <summary>
    	/// ActivityEdges immediately contained in the ActivityPartition.
    	/// </summary>
    	set<ActivityEdge> Edge subsets ActivityGroup.ContainedEdge;
    	/// <summary>
    	/// Indicates whether the ActivityPartition groups other ActivityPartitions along a dimension.
    	/// </summary>
    	bool IsDimension = "false";
    	/// <summary>
    	/// Indicates whether the ActivityPartition represents an entity to which the partitioning structure does not apply.
    	/// </summary>
    	bool IsExternal = "false";
    	/// <summary>
    	/// ActivityNodes immediately contained in the ActivityPartition.
    	/// </summary>
    	set<ActivityNode> Node subsets ActivityGroup.ContainedNode;
    	/// <summary>
    	/// An Element represented by the functionality modeled within the ActivityPartition.
    	/// </summary>
    	Element Represents;
    	/// <summary>
    	/// Other ActivityPartitions immediately contained in this ActivityPartition (as its subgroups).
    	/// </summary>
    	containment set<ActivityPartition> Subpartition subsets ActivityGroup.Subgroup;
    	/// <summary>
    	/// Other ActivityPartitions immediately containing this ActivityPartition (as its superGroups).
    	/// </summary>
    	ActivityPartition SuperPartition subsets ActivityGroup.SuperGroup;
    }

    /// <summary>
    /// A CentralBufferNode is an ObjectNode for managing flows from multiple sources and targets.
    /// </summary>
    class CentralBufferNode : ObjectNode
    {
    }

    /// <summary>
    /// A ControlFlow is an ActivityEdge traversed by control tokens or object tokens of control type, which are use to control the execution of ExecutableNodes.
    /// </summary>
    class ControlFlow : ActivityEdge
    {
    }

    /// <summary>
    /// A ControlNode is an abstract ActivityNode that coordinates flows in an Activity.
    /// </summary>
    abstract class ControlNode : ActivityNode
    {
    }

    /// <summary>
    /// A DataStoreNode is a CentralBufferNode for persistent data.
    /// </summary>
    class DataStoreNode : CentralBufferNode
    {
    }

    /// <summary>
    /// A DecisionNode is a ControlNode that chooses between outgoing ActivityEdges for the routing of tokens.
    /// </summary>
    class DecisionNode : ControlNode
    {
    	/// <summary>
    	/// A Behavior that is executed to provide an input to guard ValueSpecifications on ActivityEdges outgoing from the DecisionNode.
    	/// </summary>
    	Behavior DecisionInput;
    	/// <summary>
    	/// An additional ActivityEdge incoming to the DecisionNode that provides a decision input value for the guards ValueSpecifications on ActivityEdges outgoing from the DecisionNode.
    	/// </summary>
    	ObjectFlow DecisionInputFlow;
    }

    /// <summary>
    /// An ExceptionHandler is an Element that specifies a handlerBody ExecutableNode to execute in case the specified exception occurs during the execution of the protected ExecutableNode.
    /// </summary>
    class ExceptionHandler : Element
    {
    	/// <summary>
    	/// An ObjectNode within the handlerBody. When the ExceptionHandler catches an exception, the exception token is placed on this ObjectNode, causing the handlerBody to execute.
    	/// </summary>
    	ObjectNode ExceptionInput;
    	/// <summary>
    	/// The Classifiers whose instances the ExceptionHandler catches as exceptions. If an exception occurs whose type is any exceptionType, the ExceptionHandler catches the exception and executes the handlerBody.
    	/// </summary>
    	set<Classifier> ExceptionType;
    	/// <summary>
    	/// An ExecutableNode that is executed if the ExceptionHandler catches an exception.
    	/// </summary>
    	ExecutableNode HandlerBody;
    	/// <summary>
    	/// The ExecutableNode protected by the ExceptionHandler. If an exception propagates out of the protectedNode and has a type matching one of the exceptionTypes, then it is caught by this ExceptionHandler.
    	/// </summary>
    	ExecutableNode ProtectedNode subsets Element.Owner;
    }

    /// <summary>
    /// An ExecutableNode is an abstract class for ActivityNodes whose execution may be controlled using ControlFlows and to which ExceptionHandlers may be attached.
    /// </summary>
    abstract class ExecutableNode : ActivityNode
    {
    	/// <summary>
    	/// A set of ExceptionHandlers that are examined if an exception propagates out of the ExceptionNode.
    	/// </summary>
    	containment set<ExceptionHandler> Handler subsets Element.OwnedElement;
    }

    /// <summary>
    /// A FinalNode is an abstract ControlNode at which a flow in an Activity stops.
    /// </summary>
    abstract class FinalNode : ControlNode
    {
    }

    /// <summary>
    /// A FlowFinalNode is a FinalNode that terminates a flow by consuming the tokens offered to it.
    /// </summary>
    class FlowFinalNode : FinalNode
    {
    }

    /// <summary>
    /// A ForkNode is a ControlNode that splits a flow into multiple concurrent flows.
    /// </summary>
    class ForkNode : ControlNode
    {
    }

    /// <summary>
    /// An InitialNode is a ControlNode that offers a single control token when initially enabled.
    /// </summary>
    class InitialNode : ControlNode
    {
    }

    /// <summary>
    /// An InterruptibleActivityRegion is an ActivityGroup that supports the termination of tokens flowing in the portions of an activity within it.
    /// </summary>
    class InterruptibleActivityRegion : ActivityGroup
    {
    	/// <summary>
    	/// The ActivityEdges leaving the InterruptibleActivityRegion on which a traversing token will result in the termination of other tokens flowing in the InterruptibleActivityRegion.
    	/// </summary>
    	set<ActivityEdge> InterruptingEdge;
    	/// <summary>
    	/// ActivityNodes immediately contained in the InterruptibleActivityRegion.
    	/// </summary>
    	set<ActivityNode> Node subsets ActivityGroup.ContainedNode;
    }

    /// <summary>
    /// A JoinNode is a ControlNode that synchronizes multiple flows.
    /// </summary>
    class JoinNode : ControlNode
    {
    	/// <summary>
    	/// Indicates whether incoming tokens having objects with the same identity are combined into one by the JoinNode.
    	/// </summary>
    	bool IsCombineDuplicate = "true";
    	/// <summary>
    	/// A ValueSpecification giving the condition under which the JoinNode will offer a token on its outgoing ActivityEdge. If no joinSpec is specified, then the JoinNode will offer an outgoing token if tokens are offered on all of its incoming ActivityEdges (an &quot;and&quot; condition).
    	/// </summary>
    	containment ValueSpecification JoinSpec subsets Element.OwnedElement;
    }

    /// <summary>
    /// A merge node is a control node that brings together multiple alternate flows. It is not used to synchronize concurrent flows but to accept one among several alternate flows.
    /// </summary>
    class MergeNode : ControlNode
    {
    }

    /// <summary>
    /// An ObjectFlow is an ActivityEdge that is traversed by object tokens that may hold values. Object flows also support multicast/receive, token selection from object nodes, and transformation of tokens.
    /// </summary>
    class ObjectFlow : ActivityEdge
    {
    	/// <summary>
    	/// Indicates whether the objects in the ObjectFlow are passed by multicasting.
    	/// </summary>
    	bool IsMulticast = "false";
    	/// <summary>
    	/// Indicates whether the objects in the ObjectFlow are gathered from respondents to multicasting.
    	/// </summary>
    	bool IsMultireceive = "false";
    	/// <summary>
    	/// A Behavior used to select tokens from a source ObjectNode.
    	/// </summary>
    	Behavior Selection;
    	/// <summary>
    	/// A Behavior used to change or replace object tokens flowing along the ObjectFlow.
    	/// </summary>
    	Behavior Transformation;
    }

    /// <summary>
    /// An ObjectNode is an abstract ActivityNode that may hold tokens within the object flow in an Activity. ObjectNodes also support token selection, limitation on the number of tokens held, specification of the state required for tokens being held, and carrying control values.
    /// </summary>
    abstract class ObjectNode : TypedElement, ActivityNode
    {
    	/// <summary>
    	/// The States required to be associated with the values held by tokens on this ObjectNode.
    	/// </summary>
    	set<State> InState;
    	/// <summary>
    	/// Indicates whether the type of the ObjectNode is to be treated as representing control values that may traverse ControlFlows.
    	/// </summary>
    	bool IsControlType = "false";
    	/// <summary>
    	/// Indicates how the tokens held by the ObjectNode are ordered for selection to traverse ActivityEdges outgoing from the ObjectNode.
    	/// </summary>
    	ObjectNodeOrderingKind Ordering = "ObjectNodeOrderingKind.FIFO";
    	/// <summary>
    	/// A Behavior used to select tokens to be offered on outgoing ActivityEdges.
    	/// </summary>
    	Behavior Selection;
    	/// <summary>
    	/// The maximum number of tokens that may be held by this ObjectNode. Tokens cannot flow into the ObjectNode if the upperBound is reached. If no upperBound is specified, then there is no limit on how many tokens the ObjectNode can hold.
    	/// </summary>
    	containment ValueSpecification UpperBound subsets Element.OwnedElement;
    }

    /// <summary>
    /// A Variable is a ConnectableElement that may store values during the execution of an Activity. Reading and writing the values of a Variable provides an alternative means for passing data than the use of ObjectFlows. A Variable may be owned directly by an Activity, in which case it is accessible from anywhere within that activity, or it may be owned by a StructuredActivityNode, in which case it is only accessible within that node.
    /// </summary>
    class Variable : ConnectableElement, MultiplicityElement
    {
    	/// <summary>
    	/// An Activity that owns the Variable.
    	/// </summary>
    	Activity ActivityScope subsets NamedElement.Namespace;
    	/// <summary>
    	/// A StructuredActivityNode that owns the Variable.
    	/// </summary>
    	StructuredActivityNode Scope subsets NamedElement.Namespace;
    	/// <summary>
    	/// A Variable is accessible by Actions within its scope (the Activity or StructuredActivityNode that owns it).
    	/// </summary>
    	// spec:
    	//     result = (if scope<>null then scope.allOwnedNodes()->includes(a)
    	//     else a.containingActivity()=activityScope
    	//     endif)
    	readonly bool IsAccessibleBy(Action a);
    }

    /// <summary>
    /// A Duration is a ValueSpecification that specifies the temporal distance between two time instants.
    /// </summary>
    class Duration : ValueSpecification
    {
    	/// <summary>
    	/// A ValueSpecification that evaluates to the value of the Duration.
    	/// </summary>
    	containment ValueSpecification Expr subsets Element.OwnedElement;
    	/// <summary>
    	/// Refers to the Observations that are involved in the computation of the Duration value
    	/// </summary>
    	set<Observation> Observation;
    }

    /// <summary>
    /// A DurationConstraint is a Constraint that refers to a DurationInterval.
    /// </summary>
    class DurationConstraint : IntervalConstraint
    {
    	/// <summary>
    	/// The value of firstEvent[i] is related to constrainedElement[i] (where i is 1 or 2). If firstEvent[i] is true, then the corresponding observation event is the first time instant the execution enters constrainedElement[i]. If firstEvent[i] is false, then the corresponding observation event is the last time instant the execution is within constrainedElement[i].
    	/// </summary>
    	set<bool> FirstEvent;
    	/// <summary>
    	/// The DurationInterval constraining the duration.
    	/// </summary>
    	containment DurationInterval Specification redefines IntervalConstraint.Specification;
    }

    /// <summary>
    /// A DurationInterval defines the range between two Durations.
    /// </summary>
    class DurationInterval : Interval
    {
    	/// <summary>
    	/// Refers to the Duration denoting the maximum value of the range.
    	/// </summary>
    	Duration Max redefines Interval.Max;
    	/// <summary>
    	/// Refers to the Duration denoting the minimum value of the range.
    	/// </summary>
    	Duration Min redefines Interval.Min;
    }

    /// <summary>
    /// A DurationObservation is a reference to a duration during an execution. It points out the NamedElement(s) in the model to observe and whether the observations are when this NamedElement is entered or when it is exited.
    /// </summary>
    class DurationObservation : Observation
    {
    	/// <summary>
    	/// The DurationObservation is determined as the duration between the entering or exiting of a single event Element during execution, or the entering/exiting of one event Element and the entering/exiting of a second.
    	/// </summary>
    	list<NamedElement> Event;
    	/// <summary>
    	/// The value of firstEvent[i] is related to event[i] (where i is 1 or 2). If firstEvent[i] is true, then the corresponding observation event is the first time instant the execution enters event[i]. If firstEvent[i] is false, then the corresponding observation event is the time instant the execution exits event[i].
    	/// </summary>
    	set<bool> FirstEvent;
    }

    /// <summary>
    /// An Expression represents a node in an expression tree, which may be non-terminal or terminal. It defines a symbol, and has a possibly empty sequence of operands that are ValueSpecifications. It denotes a (possibly empty) set of values when evaluated in a context.
    /// </summary>
    class Expression : ValueSpecification
    {
    	/// <summary>
    	/// Specifies a sequence of operand ValueSpecifications.
    	/// </summary>
    	containment list<ValueSpecification> Operand subsets Element.OwnedElement;
    	/// <summary>
    	/// The symbol associated with this node in the expression tree.
    	/// </summary>
    	string Symbol;
    }

    /// <summary>
    /// An Interval defines the range between two ValueSpecifications.
    /// </summary>
    class Interval : ValueSpecification
    {
    	/// <summary>
    	/// Refers to the ValueSpecification denoting the maximum value of the range.
    	/// </summary>
    	ValueSpecification Max;
    	/// <summary>
    	/// Refers to the ValueSpecification denoting the minimum value of the range.
    	/// </summary>
    	ValueSpecification Min;
    }

    /// <summary>
    /// An IntervalConstraint is a Constraint that is specified by an Interval.
    /// </summary>
    class IntervalConstraint : Constraint
    {
    	/// <summary>
    	/// The Interval that specifies the condition of the IntervalConstraint.
    	/// </summary>
    	containment Interval Specification redefines Constraint.Specification;
    }

    /// <summary>
    /// A LiteralBoolean is a specification of a Boolean value.
    /// </summary>
    class LiteralBoolean : LiteralSpecification
    {
    	/// <summary>
    	/// The specified Boolean value.
    	/// </summary>
    	bool Value = "false";
    	/// <summary>
    	/// The query booleanValue() gives the value.
    	/// </summary>
    	// spec:
    	//     result = (value)
    	readonly bool BooleanValue();
    	/// <summary>
    	/// The query isComputable() is redefined to be true.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsComputable();
    }

    /// <summary>
    /// A LiteralInteger is a specification of an Integer value.
    /// </summary>
    class LiteralInteger : LiteralSpecification
    {
    	/// <summary>
    	/// The specified Integer value.
    	/// </summary>
    	int Value = "0";
    	/// <summary>
    	/// The query integerValue() gives the value.
    	/// </summary>
    	// spec:
    	//     result = (value)
    	readonly int IntegerValue();
    	/// <summary>
    	/// The query isComputable() is redefined to be true.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsComputable();
    }

    /// <summary>
    /// A LiteralNull specifies the lack of a value.
    /// </summary>
    class LiteralNull : LiteralSpecification
    {
    	/// <summary>
    	/// The query isComputable() is redefined to be true.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsComputable();
    	/// <summary>
    	/// The query isNull() returns true.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsNull();
    }

    /// <summary>
    /// A LiteralReal is a specification of a Real value.
    /// </summary>
    class LiteralReal : LiteralSpecification
    {
    	/// <summary>
    	/// The specified Real value.
    	/// </summary>
    	double Value;
    	/// <summary>
    	/// The query isComputable() is redefined to be true.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsComputable();
    	/// <summary>
    	/// The query realValue() gives the value.
    	/// </summary>
    	// spec:
    	//     result = (value)
    	readonly double RealValue();
    }

    /// <summary>
    /// A LiteralSpecification identifies a literal constant being modeled.
    /// </summary>
    abstract class LiteralSpecification : ValueSpecification
    {
    }

    /// <summary>
    /// A LiteralString is a specification of a String value.
    /// </summary>
    class LiteralString : LiteralSpecification
    {
    	/// <summary>
    	/// The specified String value.
    	/// </summary>
    	string Value;
    	/// <summary>
    	/// The query isComputable() is redefined to be true.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsComputable();
    	/// <summary>
    	/// The query stringValue() gives the value.
    	/// </summary>
    	// spec:
    	//     result = (value)
    	readonly string StringValue();
    }

    /// <summary>
    /// A LiteralUnlimitedNatural is a specification of an UnlimitedNatural number.
    /// </summary>
    class LiteralUnlimitedNatural : LiteralSpecification
    {
    	/// <summary>
    	/// The specified UnlimitedNatural value.
    	/// </summary>
    	long Value = "0";
    	/// <summary>
    	/// The query isComputable() is redefined to be true.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsComputable();
    	/// <summary>
    	/// The query unlimitedValue() gives the value.
    	/// </summary>
    	// spec:
    	//     result = (value)
    	readonly long UnlimitedValue();
    }

    /// <summary>
    /// Observation specifies a value determined by observing an event or events that occur relative to other model Elements.
    /// </summary>
    abstract class Observation : PackageableElement
    {
    }

    /// <summary>
    /// An OpaqueExpression is a ValueSpecification that specifies the computation of a collection of values either in terms of a UML Behavior or based on a textual statement in a language other than UML
    /// </summary>
    class OpaqueExpression : ValueSpecification
    {
    	/// <summary>
    	/// Specifies the behavior of the OpaqueExpression as a UML Behavior.
    	/// </summary>
    	Behavior Behavior;
    	/// <summary>
    	/// A textual definition of the behavior of the OpaqueExpression, possibly in multiple languages.
    	/// </summary>
    	multi_list<string> Body;
    	/// <summary>
    	/// Specifies the languages used to express the textual bodies of the OpaqueExpression.  Languages are matched to body Strings by order. The interpretation of the body depends on the languages. If the languages are unspecified, they may be implicit from the expression body or the context.
    	/// </summary>
    	list<string> Language;
    	/// <summary>
    	/// If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required return Parameter of that Behavior. When the Behavior completes execution, the values on this Parameter give the result of evaluating the OpaqueExpression.
    	/// </summary>
    	// spec:
    	//     result = (if behavior = null then
    	//     	null
    	//     else
    	//     	behavior.ownedParameter->first()
    	//     endif)
    	derived Parameter Result;
    	/// <summary>
    	/// The query isIntegral() tells whether an expression is intended to produce an Integer.
    	/// </summary>
    	// spec:
    	//     result = (false)
    	readonly bool IsIntegral();
    	/// <summary>
    	/// The query isNonNegative() tells whether an integer expression has a non-negative value.
    	/// </summary>
    	// pre:
    	//     self.isIntegral()
    	// spec:
    	//     result = (false)
    	readonly bool IsNonNegative();
    	/// <summary>
    	/// The query isPositive() tells whether an integer expression has a positive value.
    	/// </summary>
    	// spec:
    	//     result = (false)
    	// pre:
    	//     self.isIntegral()
    	readonly bool IsPositive();
    	/// <summary>
    	/// The query value() gives an integer value for an expression intended to produce one.
    	/// </summary>
    	// pre:
    	//     self.isIntegral()
    	// spec:
    	//     result = (0)
    	readonly int Value();
    }

    /// <summary>
    /// A StringExpression is an Expression that specifies a String value that is derived by concatenating a sequence of operands with String values or a sequence of subExpressions, some of which might be template parameters.
    /// </summary>
    class StringExpression : TemplateableElement, Expression
    {
    	/// <summary>
    	/// The StringExpression of which this StringExpression is a subExpression.
    	/// </summary>
    	StringExpression OwningExpression subsets Element.Owner;
    	/// <summary>
    	/// The StringExpressions that constitute this StringExpression.
    	/// </summary>
    	containment list<StringExpression> SubExpression subsets Element.OwnedElement;
    	/// <summary>
    	/// The query stringValue() returns the String resulting from concatenating, in order, all the component String values of all the operands or subExpressions that are part of the StringExpression.
    	/// </summary>
    	// spec:
    	//     result = (if subExpression->notEmpty()
    	//     then subExpression->iterate(se; stringValue: String = '' | stringValue.concat(se.stringValue()))
    	//     else operand->iterate(op; stringValue: String = '' | stringValue.concat(op.stringValue()))
    	//     endif)
    	readonly string StringValue();
    }

    /// <summary>
    /// A TimeConstraint is a Constraint that refers to a TimeInterval.
    /// </summary>
    class TimeConstraint : IntervalConstraint
    {
    	/// <summary>
    	/// The value of firstEvent is related to the constrainedElement. If firstEvent is true, then the corresponding observation event is the first time instant the execution enters the constrainedElement. If firstEvent is false, then the corresponding observation event is the last time instant the execution is within the constrainedElement.
    	/// </summary>
    	bool FirstEvent = "true";
    	/// <summary>
    	/// TheTimeInterval constraining the duration.
    	/// </summary>
    	containment TimeInterval Specification redefines IntervalConstraint.Specification;
    }

    /// <summary>
    /// A TimeExpression is a ValueSpecification that represents a time value.
    /// </summary>
    class TimeExpression : ValueSpecification
    {
    	/// <summary>
    	/// A ValueSpecification that evaluates to the value of the TimeExpression.
    	/// </summary>
    	containment ValueSpecification Expr subsets Element.OwnedElement;
    	/// <summary>
    	/// Refers to the Observations that are involved in the computation of the TimeExpression value.
    	/// </summary>
    	set<Observation> Observation;
    }

    /// <summary>
    /// A TimeInterval defines the range between two TimeExpressions.
    /// </summary>
    class TimeInterval : Interval
    {
    	/// <summary>
    	/// Refers to the TimeExpression denoting the maximum value of the range.
    	/// </summary>
    	TimeExpression Max redefines Interval.Max;
    	/// <summary>
    	/// Refers to the TimeExpression denoting the minimum value of the range.
    	/// </summary>
    	TimeExpression Min redefines Interval.Min;
    }

    /// <summary>
    /// A TimeObservation is a reference to a time instant during an execution. It points out the NamedElement in the model to observe and whether the observation is when this NamedElement is entered or when it is exited.
    /// </summary>
    class TimeObservation : Observation
    {
    	/// <summary>
    	/// The TimeObservation is determined by the entering or exiting of the event Element during execution.
    	/// </summary>
    	NamedElement Event;
    	/// <summary>
    	/// The value of firstEvent is related to the event. If firstEvent is true, then the corresponding observation event is the first time instant the execution enters the event Element. If firstEvent is false, then the corresponding observation event is the time instant the execution exits the event Element.
    	/// </summary>
    	bool FirstEvent = "true";
    }

    /// <summary>
    /// A ValueSpecification is the specification of a (possibly empty) set of values. A ValueSpecification is a ParameterableElement that may be exposed as a formal TemplateParameter and provided as the actual parameter in the binding of a template.
    /// </summary>
    abstract class ValueSpecification : TypedElement, PackageableElement
    {
    	/// <summary>
    	/// The query booleanValue() gives a single Boolean value when one can be computed.
    	/// </summary>
    	// spec:
    	//     result = (null)
    	readonly bool BooleanValue();
    	/// <summary>
    	/// The query integerValue() gives a single Integer value when one can be computed.
    	/// </summary>
    	// spec:
    	//     result = (null)
    	readonly int IntegerValue();
    	/// <summary>
    	/// The query isCompatibleWith() determines if this ValueSpecification is compatible with the specified ParameterableElement. This ValueSpecification is compatible with ParameterableElement p if the kind of this ValueSpecification is the same as or a subtype of the kind of p. Further, if p is a TypedElement, then the type of this ValueSpecification must be conformant with the type of p.
    	/// </summary>
    	// spec:
    	//     result = (self.oclIsKindOf(p.oclType()) and (p.oclIsKindOf(TypedElement) implies 
    	//     self.type.conformsTo(p.oclAsType(TypedElement).type)))
    	readonly bool IsCompatibleWith(ParameterableElement p);
    	/// <summary>
    	/// The query isComputable() determines whether a value specification can be computed in a model. This operation cannot be fully defined in OCL. A conforming implementation is expected to deliver true for this operation for all ValueSpecifications that it can compute, and to compute all of those for which the operation is true. A conforming implementation is expected to be able to compute at least the value of all LiteralSpecifications.
    	/// </summary>
    	// spec:
    	//     result = (false)
    	readonly bool IsComputable();
    	/// <summary>
    	/// The query isNull() returns true when it can be computed that the value is null.
    	/// </summary>
    	// spec:
    	//     result = (false)
    	readonly bool IsNull();
    	/// <summary>
    	/// The query realValue() gives a single Real value when one can be computed.
    	/// </summary>
    	// spec:
    	//     result = (null)
    	readonly double RealValue();
    	/// <summary>
    	/// The query stringValue() gives a single String value when one can be computed.
    	/// </summary>
    	// spec:
    	//     result = (null)
    	readonly string StringValue();
    	/// <summary>
    	/// The query unlimitedValue() gives a single UnlimitedNatural value when one can be computed.
    	/// </summary>
    	// spec:
    	//     result = (null)
    	readonly long UnlimitedValue();
    }

    /// <summary>
    /// An Actor specifies a role played by a user or any other system that interacts with the subject.
    /// </summary>
    class Actor : BehavioredClassifier
    {
    }

    /// <summary>
    /// A relationship from an extending UseCase to an extended UseCase that specifies how and when the behavior defined in the extending UseCase can be inserted into the behavior defined in the extended UseCase.
    /// </summary>
    class Extend : NamedElement, DirectedRelationship
    {
    	/// <summary>
    	/// References the condition that must hold when the first ExtensionPoint is reached for the extension to take place. If no constraint is associated with the Extend relationship, the extension is unconditional.
    	/// </summary>
    	containment Constraint Condition subsets Element.OwnedElement;
    	/// <summary>
    	/// The UseCase that is being extended.
    	/// </summary>
    	UseCase ExtendedCase subsets DirectedRelationship.Target;
    	/// <summary>
    	/// The UseCase that represents the extension and owns the Extend relationship.
    	/// </summary>
    	UseCase Extension subsets DirectedRelationship.Source, NamedElement.Namespace;
    	/// <summary>
    	/// An ordered list of ExtensionPoints belonging to the extended UseCase, specifying where the respective behavioral fragments of the extending UseCase are to be inserted. The first fragment in the extending UseCase is associated with the first extension point in the list, the second fragment with the second point, and so on. Note that, in most practical cases, the extending UseCase has just a single behavior fragment, so that the list of ExtensionPoints is trivial.
    	/// </summary>
    	list<ExtensionPoint> ExtensionLocation;
    }

    /// <summary>
    /// An ExtensionPoint identifies a point in the behavior of a UseCase where that behavior can be extended by the behavior of some other (extending) UseCase, as specified by an Extend relationship.
    /// </summary>
    class ExtensionPoint : RedefinableElement
    {
    	/// <summary>
    	/// The UseCase that owns this ExtensionPoint.
    	/// </summary>
    	UseCase UseCase subsets NamedElement.Namespace;
    }

    /// <summary>
    /// An Include relationship specifies that a UseCase contains the behavior defined in another UseCase.
    /// </summary>
    class Include : DirectedRelationship, NamedElement
    {
    	/// <summary>
    	/// The UseCase that is to be included.
    	/// </summary>
    	UseCase Addition subsets DirectedRelationship.Target;
    	/// <summary>
    	/// The UseCase which includes the addition and owns the Include relationship.
    	/// </summary>
    	UseCase IncludingCase subsets DirectedRelationship.Source, NamedElement.Namespace;
    }

    /// <summary>
    /// A UseCase specifies a set of actions performed by its subjects, which yields an observable result that is of value for one or more Actors or other stakeholders of each subject.
    /// </summary>
    class UseCase : BehavioredClassifier
    {
    	/// <summary>
    	/// The Extend relationships owned by this UseCase.
    	/// </summary>
    	containment set<Extend> Extend subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The ExtensionPoints owned by this UseCase.
    	/// </summary>
    	containment set<ExtensionPoint> ExtensionPoint subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The Include relationships owned by this UseCase.
    	/// </summary>
    	containment set<Include> Include subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The subjects to which this UseCase applies. Each subject or its parts realize all the UseCases that apply to it.
    	/// </summary>
    	set<Classifier> Subject;
    	/// <summary>
    	/// The query allIncludedUseCases() returns the transitive closure of all UseCases (directly or indirectly) included by this UseCase.
    	/// </summary>
    	// spec:
    	//     result = (self.include.addition->union(self.include.addition->collect(uc | uc.allIncludedUseCases()))->asSet())
    	readonly set<UseCase> AllIncludedUseCases();
    }

    /// <summary>
    /// A link is a tuple of values that refer to typed objects.  An Association classifies a set of links, each of which is an instance of the Association.  Each value in the link refers to an instance of the type of the corresponding end of the Association.
    /// </summary>
    class Association : Relationship, Classifier
    {
    	/// <summary>
    	/// The Classifiers that are used as types of the ends of the Association.
    	/// </summary>
    	// spec:
    	//     result = (memberEnd->collect(type)->asSet())
    	derived set<Type> EndType subsets Relationship.RelatedElement;
    	/// <summary>
    	/// Specifies whether the Association is derived from other model elements such as other Associations.
    	/// </summary>
    	bool IsDerived = "false";
    	/// <summary>
    	/// Each end represents participation of instances of the Classifier connected to the end in links of the Association.
    	/// </summary>
    	list<Property> MemberEnd subsets Namespace.Member;
    	/// <summary>
    	/// The navigable ends that are owned by the Association itself.
    	/// </summary>
    	set<Property> NavigableOwnedEnd subsets Association.OwnedEnd;
    	/// <summary>
    	/// The ends that are owned by the Association itself.
    	/// </summary>
    	containment list<Property> OwnedEnd subsets Association.MemberEnd, Classifier.Feature, Namespace.OwnedMember;
    }

    /// <summary>
    /// A model element that has both Association and Class properties. An AssociationClass can be seen as an Association that also has Class properties, or as a Class that also has Association properties. It not only connects a set of Classifiers but also defines a set of Features that belong to the Association itself and not to any of the associated Classifiers.
    /// </summary>
    class AssociationClass : Class, Association
    {
    }

    /// <summary>
    /// A Class classifies a set of objects and specifies the features that characterize the structure and behavior of those objects.  A Class may have an internal structure and Ports.
    /// </summary>
    class Class : BehavioredClassifier, EncapsulatedClassifier
    {
    	/// <summary>
    	/// This property is used when the Class is acting as a metaclass. It references the Extensions that specify additional properties of the metaclass. The property is derived from the Extensions whose memberEnds are typed by the Class.
    	/// </summary>
    	// spec:
    	//     result = (Extension.allInstances()->select(ext | 
    	//       let endTypes : Sequence(Classifier) = ext.memberEnd->collect(type.oclAsType(Classifier)) in
    	//       endTypes->includes(self) or endTypes.allParents()->includes(self) ))
    	derived set<Extension> Extension;
    	/// <summary>
    	/// If true, the Class does not provide a complete declaration and cannot be instantiated. An abstract Class is typically used as a target of Associations or Generalizations.
    	/// </summary>
    	bool IsAbstract = "false" redefines Classifier.IsAbstract;
    	/// <summary>
    	/// Determines whether an object specified by this Class is active or not. If true, then the owning Class is referred to as an active Class. If false, then such a Class is referred to as a passive Class.
    	/// </summary>
    	bool IsActive = "false";
    	/// <summary>
    	/// The Classifiers owned by the Class that are not ownedBehaviors.
    	/// </summary>
    	containment list<Classifier> NestedClassifier subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The attributes (i.e., the Properties) owned by the Class.
    	/// </summary>
    	containment list<Property> OwnedAttribute redefines StructuredClassifier.OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    	/// <summary>
    	/// The Operations owned by the Class.
    	/// </summary>
    	containment list<Operation> OwnedOperation subsets Classifier.Feature, Namespace.OwnedMember;
    	/// <summary>
    	/// The Receptions owned by the Class.
    	/// </summary>
    	containment set<Reception> OwnedReception subsets Classifier.Feature, Namespace.OwnedMember;
    	/// <summary>
    	/// The superclasses of a Class, derived from its Generalizations.
    	/// </summary>
    	// spec:
    	//     result = (self.general()->select(oclIsKindOf(Class))->collect(oclAsType(Class))->asSet())
    	derived set<Class> SuperClass redefines Classifier.General;
    }

    /// <summary>
    /// A Collaboration describes a structure of collaborating elements (roles), each performing a specialized function, which collectively accomplish some desired functionality. 
    /// </summary>
    class Collaboration : StructuredClassifier, BehavioredClassifier
    {
    	/// <summary>
    	/// Represents the participants in the Collaboration.
    	/// </summary>
    	set<ConnectableElement> CollaborationRole subsets StructuredClassifier.Role;
    }

    /// <summary>
    /// A CollaborationUse is used to specify the application of a pattern specified by a Collaboration to a specific situation.
    /// </summary>
    class CollaborationUse : NamedElement
    {
    	/// <summary>
    	/// A mapping between features of the Collaboration and features of the owning Classifier. This mapping indicates which ConnectableElement of the Classifier plays which role(s) in the Collaboration. A ConnectableElement may be bound to multiple roles in the same CollaborationUse (that is, it may play multiple roles).
    	/// </summary>
    	containment set<Dependency> RoleBinding subsets Element.OwnedElement;
    	/// <summary>
    	/// The Collaboration which is used in this CollaborationUse. The Collaboration defines the cooperation between its roles which are mapped to ConnectableElements relating to the Classifier owning the CollaborationUse.
    	/// </summary>
    	Collaboration Type;
    }

    /// <summary>
    /// A Component represents a modular part of a system that encapsulates its contents and whose manifestation is replaceable within its environment.  
    /// </summary>
    class Component : Class
    {
    	/// <summary>
    	/// If true, the Component is defined at design-time, but at run-time (or execution-time) an object specified by the Component does not exist, that is, the Component is instantiated indirectly, through the instantiation of its realizing Classifiers or parts.
    	/// </summary>
    	bool IsIndirectlyInstantiated = "true";
    	/// <summary>
    	/// The set of PackageableElements that a Component owns. In the namespace of a Component, all model elements that are involved in or related to its definition may be owned or imported explicitly. These may include e.g., Classes, Interfaces, Components, Packages, UseCases, Dependencies (e.g., mappings), and Artifacts.
    	/// </summary>
    	containment set<PackageableElement> PackagedElement subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The Interfaces that the Component exposes to its environment. These Interfaces may be Realized by the Component or any of its realizingClassifiers, or they may be the Interfaces that are provided by its public Ports.
    	/// </summary>
    	// spec:
    	//     result = (let 	ris : Set(Interface) = allRealizedInterfaces(),
    	//             realizingClassifiers : Set(Classifier) =  self.realization.realizingClassifier->union(self.allParents()->collect(realization.realizingClassifier))->asSet(),
    	//             allRealizingClassifiers : Set(Classifier) = realizingClassifiers->union(realizingClassifiers.allParents())->asSet(),
    	//             realizingClassifierInterfaces : Set(Interface) = allRealizingClassifiers->iterate(c; rci : Set(Interface) = Set{} | rci->union(c.allRealizedInterfaces())),
    	//             ports : Set(Port) = self.ownedPort->union(allParents()->collect(ownedPort))->asSet(),
    	//             providedByPorts : Set(Interface) = ports.provided->asSet()
    	//     in     ris->union(realizingClassifierInterfaces) ->union(providedByPorts)->asSet())
    	derived set<Interface> Provided;
    	/// <summary>
    	/// The set of Realizations owned by the Component. Realizations reference the Classifiers of which the Component is an abstraction; i.e., that realize its behavior.
    	/// </summary>
    	containment set<ComponentRealization> Realization subsets Element.OwnedElement;
    	/// <summary>
    	/// The Interfaces that the Component requires from other Components in its environment in order to be able to offer its full set of provided functionality. These Interfaces may be used by the Component or any of its realizingClassifiers, or they may be the Interfaces that are required by its public Ports.
    	/// </summary>
    	// spec:
    	//     result = (let 	uis : Set(Interface) = allUsedInterfaces(),
    	//             realizingClassifiers : Set(Classifier) = self.realization.realizingClassifier->union(self.allParents()->collect(realization.realizingClassifier))->asSet(),
    	//             allRealizingClassifiers : Set(Classifier) = realizingClassifiers->union(realizingClassifiers.allParents())->asSet(),
    	//             realizingClassifierInterfaces : Set(Interface) = allRealizingClassifiers->iterate(c; rci : Set(Interface) = Set{} | rci->union(c.allUsedInterfaces())),
    	//             ports : Set(Port) = self.ownedPort->union(allParents()->collect(ownedPort))->asSet(),
    	//             usedByPorts : Set(Interface) = ports.required->asSet()
    	//     in	    uis->union(realizingClassifierInterfaces)->union(usedByPorts)->asSet()
    	//     )
    	derived set<Interface> Required;
    }

    /// <summary>
    /// Realization is specialized to (optionally) define the Classifiers that realize the contract offered by a Component in terms of its provided and required Interfaces. The Component forms an abstraction from these various Classifiers.
    /// </summary>
    class ComponentRealization : Realization
    {
    	/// <summary>
    	/// The Component that owns this ComponentRealization and which is implemented by its realizing Classifiers.
    	/// </summary>
    	Component Abstraction subsets Dependency.Supplier, Element.Owner;
    	/// <summary>
    	/// The Classifiers that are involved in the implementation of the Component that owns this Realization.
    	/// </summary>
    	set<Classifier> RealizingClassifier subsets Dependency.Client;
    }

    /// <summary>
    /// ConnectableElement is an abstract metaclass representing a set of instances that play roles of a StructuredClassifier. ConnectableElements may be joined by attached Connectors and specify configurations of linked instances to be created within an instance of the containing StructuredClassifier.
    /// </summary>
    abstract class ConnectableElement : TypedElement, ParameterableElement
    {
    	/// <summary>
    	/// A set of ConnectorEnds that attach to this ConnectableElement.
    	/// </summary>
    	// spec:
    	//     result = (ConnectorEnd.allInstances()->select(role = self))
    	derived set<ConnectorEnd> End;
    	/// <summary>
    	/// The ConnectableElementTemplateParameter for this ConnectableElement parameter.
    	/// </summary>
    	ConnectableElementTemplateParameter TemplateParameter redefines ParameterableElement.TemplateParameter;
    }

    /// <summary>
    /// A ConnectableElementTemplateParameter exposes a ConnectableElement as a formal parameter for a template.
    /// </summary>
    class ConnectableElementTemplateParameter : TemplateParameter
    {
    	/// <summary>
    	/// The ConnectableElement for this ConnectableElementTemplateParameter.
    	/// </summary>
    	ConnectableElement ParameteredElement redefines TemplateParameter.ParameteredElement;
    }

    /// <summary>
    /// A Connector specifies links that enables communication between two or more instances. In contrast to Associations, which specify links between any instance of the associated Classifiers, Connectors specify links between instances playing the connected parts only.
    /// </summary>
    class Connector : Feature
    {
    	/// <summary>
    	/// The set of Behaviors that specify the valid interaction patterns across the Connector.
    	/// </summary>
    	set<Behavior> Contract;
    	/// <summary>
    	/// A Connector has at least two ConnectorEnds, each representing the participation of instances of the Classifiers typing the ConnectableElements attached to the end. The set of ConnectorEnds is ordered.
    	/// </summary>
    	containment list<ConnectorEnd> End subsets Element.OwnedElement;
    	/// <summary>
    	/// Indicates the kind of Connector. This is derived: a Connector with one or more ends connected to a Port which is not on a Part and which is not a behavior port is a delegation; otherwise it is an assembly.
    	/// </summary>
    	// spec:
    	//     result = (if end->exists(
    	//     		role.oclIsKindOf(Port) 
    	//     		and partWithPort->isEmpty()
    	//     		and not role.oclAsType(Port).isBehavior)
    	//     then ConnectorKind::delegation 
    	//     else ConnectorKind::assembly 
    	//     endif)
    	derived ConnectorKind Kind;
    	/// <summary>
    	/// A Connector may be redefined when its containing Classifier is specialized. The redefining Connector may have a type that specializes the type of the redefined Connector. The types of the ConnectorEnds of the redefining Connector may specialize the types of the ConnectorEnds of the redefined Connector. The properties of the ConnectorEnds of the redefining Connector may be replaced.
    	/// </summary>
    	set<Connector> RedefinedConnector subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// An optional Association that classifies links corresponding to this Connector.
    	/// </summary>
    	Association Type;
    }

    /// <summary>
    /// A ConnectorEnd is an endpoint of a Connector, which attaches the Connector to a ConnectableElement.
    /// </summary>
    class ConnectorEnd : MultiplicityElement
    {
		/// <summary>
		/// The Connector of which the ConnectorEnd is the endpoint.
		/// </summary>
		Connector Connector subsets Element.Owner;
		/// <summary>
    	/// A derived property referencing the corresponding end on the Association which types the Connector owing this ConnectorEnd, if any. It is derived by selecting the end at the same place in the ordering of Association ends as this ConnectorEnd.
    	/// </summary>
    	// spec:
    	//     result = (if connector.type = null 
    	//     then
    	//       null 
    	//     else
    	//       let index : Integer = connector.end->indexOf(self) in
    	//         connector.type.memberEnd->at(index)
    	//     endif)
    	derived Property DefiningEnd;
    	/// <summary>
    	/// Indicates the role of the internal structure of a Classifier with the Port to which the ConnectorEnd is attached.
    	/// </summary>
    	Property PartWithPort;
    	/// <summary>
    	/// The ConnectableElement attached at this ConnectorEnd. When an instance of the containing Classifier is created, a link may (depending on the multiplicities) be created to an instance of the Classifier that types this ConnectableElement.
    	/// </summary>
    	ConnectableElement Role;
    }

    /// <summary>
    /// An EncapsulatedClassifier may own Ports to specify typed interaction points.
    /// </summary>
    abstract class EncapsulatedClassifier : StructuredClassifier
    {
    	/// <summary>
    	/// The Ports owned by the EncapsulatedClassifier.
    	/// </summary>
    	// spec:
    	//     result = (ownedAttribute->select(oclIsKindOf(Port))->collect(oclAsType(Port))->asOrderedSet())
    	containment derived set<Port> OwnedPort subsets StructuredClassifier.OwnedAttribute;
    }

    /// <summary>
    /// A Port is a property of an EncapsulatedClassifier that specifies a distinct interaction point between that EncapsulatedClassifier and its environment or between the (behavior of the) EncapsulatedClassifier and its internal parts. Ports are connected to Properties of the EncapsulatedClassifier by Connectors through which requests can be made to invoke BehavioralFeatures. A Port may specify the services an EncapsulatedClassifier provides (offers) to its environment as well as the services that an EncapsulatedClassifier expects (requires) of its environment.  A Port may have an associated ProtocolStateMachine.
    /// </summary>
    class Port : Property
    {
    	/// <summary>
    	/// Specifies whether requests arriving at this Port are sent to the classifier behavior of this EncapsulatedClassifier. Such a Port is referred to as a behavior Port. Any invocation of a BehavioralFeature targeted at a behavior Port will be handled by the instance of the owning EncapsulatedClassifier itself, rather than by any instances that it may contain.
    	/// </summary>
    	bool IsBehavior = "false";
    	/// <summary>
    	/// Specifies the way that the provided and required Interfaces are derived from the Port’s Type.
    	/// </summary>
    	bool IsConjugated = "false";
    	/// <summary>
    	/// If true, indicates that this Port is used to provide the published functionality of an EncapsulatedClassifier.  If false, this Port is used to implement the EncapsulatedClassifier but is not part of the essential externally-visible functionality of the EncapsulatedClassifier and can, therefore, be altered or deleted along with the internal implementation of the EncapsulatedClassifier and other properties that are considered part of its implementation.
    	/// </summary>
    	bool IsService = "true";
    	/// <summary>
    	/// An optional ProtocolStateMachine which describes valid interactions at this interaction point.
    	/// </summary>
    	ProtocolStateMachine Protocol;
    	/// <summary>
    	/// The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCclassifier offers to its environment via this Port, and which it will handle either directly or by forwarding it to a part of its internal structure. This association is derived according to the value of isConjugated. If isConjugated is false, provided is derived as the union of the sets of Interfaces realized by the type of the port and its supertypes, or directly from the type of the Port if the Port is typed by an Interface. If isConjugated is true, it is derived as the union of the sets of Interfaces used by the type of the Port and its supertypes.
    	/// </summary>
    	// spec:
    	//     result = (if isConjugated then basicRequired() else basicProvided() endif)
    	derived set<Interface> Provided;
    	/// <summary>
    	/// A Port may be redefined when its containing EncapsulatedClassifier is specialized. The redefining Port may have additional Interfaces to those that are associated with the redefined Port or it may replace an Interface by one of its subtypes.
    	/// </summary>
    	set<Port> RedefinedPort subsets Property.RedefinedProperty;
    	/// <summary>
    	/// The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCassifier expects its environment to handle via this port. This association is derived according to the value of isConjugated. If isConjugated is false, required is derived as the union of the sets of Interfaces used by the type of the Port and its supertypes. If isConjugated is true, it is derived as the union of the sets of Interfaces realized by the type of the Port and its supertypes, or directly from the type of the Port if the Port is typed by an Interface.
    	/// </summary>
    	// spec:
    	//     result = (if isConjugated then basicProvided() else basicRequired() endif)
    	derived set<Interface> Required;
    	/// <summary>
    	/// The union of the sets of Interfaces realized by the type of the Port and its supertypes, or directly the type of the Port if the Port is typed by an Interface.
    	/// </summary>
    	// spec:
    	//     result = (if type.oclIsKindOf(Interface) 
    	//     then type.oclAsType(Interface)->asSet() 
    	//     else type.oclAsType(Classifier).allRealizedInterfaces() 
    	//     endif)
    	readonly set<Interface> BasicProvided();
    	/// <summary>
    	/// The union of the sets of Interfaces used by the type of the Port and its supertypes.
    	/// </summary>
    	// spec:
    	//     result = ( type.oclAsType(Classifier).allUsedInterfaces() )
    	readonly set<Interface> BasicRequired();
    }

    /// <summary>
    /// StructuredClassifiers may contain an internal structure of connected elements each of which plays a role in the overall Behavior modeled by the StructuredClassifier.
    /// </summary>
    abstract class StructuredClassifier : Classifier
    {
    	/// <summary>
    	/// The Properties owned by the StructuredClassifier.
    	/// </summary>
    	containment list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember, StructuredClassifier.Role;
    	/// <summary>
    	/// The connectors owned by the StructuredClassifier.
    	/// </summary>
    	containment set<Connector> OwnedConnector subsets Classifier.Feature, Namespace.OwnedMember;
    	/// <summary>
    	/// The Properties specifying instances that the StructuredClassifier owns by composition. This collection is derived, selecting those owned Properties where isComposite is true.
    	/// </summary>
    	// spec:
    	//     result = (ownedAttribute->select(isComposite))
    	derived set<Property> Part;
    	/// <summary>
    	/// The roles that instances may play in this StructuredClassifier.
    	/// </summary>
    	union set<ConnectableElement> Role subsets Namespace.Member;
    	/// <summary>
    	/// All features of type ConnectableElement, equivalent to all direct and inherited roles.
    	/// </summary>
    	// spec:
    	//     result = (allFeatures()->select(oclIsKindOf(ConnectableElement))->collect(oclAsType(ConnectableElement))->asSet())
    	readonly set<ConnectableElement> AllRoles();
    }

    /// <summary>
    /// A ConnectionPointReference represents a usage (as part of a submachine State) of an entry/exit point Pseudostate defined in the StateMachine referenced by the submachine State.
    /// </summary>
    class ConnectionPointReference : Vertex
    {
    	/// <summary>
    	/// The entryPoint Pseudostates corresponding to this connection point.
    	/// </summary>
    	set<Pseudostate> Entry;
    	/// <summary>
    	/// The exitPoints kind Pseudostates corresponding to this connection point.
    	/// </summary>
    	set<Pseudostate> Exit;
    	/// <summary>
    	/// The State in which the ConnectionPointReference is defined.
    	/// </summary>
    	State State subsets NamedElement.Namespace;
    	/// <summary>
    	/// The query isConsistentWith() specifies a ConnectionPointReference can only be redefined by a ConnectionPointReference.
    	/// </summary>
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	// spec:
    	//     result = redefiningElement.oclIsKindOf(ConnectionPointReference)
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// A special kind of State, which, when entered, signifies that the enclosing Region has completed. If the enclosing Region is directly contained in a StateMachine and all other Regions in that StateMachine also are completed, then it means that the entire StateMachine behavior is completed.
    /// </summary>
    class FinalState : State
    {
    	/// <summary>
    	/// The query isConsistentWith() specifies a FinalState can only be redefined by a FinalState.
    	/// </summary>
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	// spec:
    	//     result = redefiningElement.oclIsKindOf(FinalState)
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// A ProtocolStateMachine can be redefined into a more specific ProtocolStateMachine or into behavioral StateMachine. ProtocolConformance declares that the specific ProtocolStateMachine specifies a protocol that conforms to the general ProtocolStateMachine or that the specific behavioral StateMachine abides by the protocol of the general ProtocolStateMachine.
    /// </summary>
    class ProtocolConformance : DirectedRelationship
    {
    	/// <summary>
    	/// Specifies the ProtocolStateMachine to which the specific ProtocolStateMachine conforms.
    	/// </summary>
    	ProtocolStateMachine GeneralMachine subsets DirectedRelationship.Target;
    	/// <summary>
    	/// Specifies the ProtocolStateMachine which conforms to the general ProtocolStateMachine.
    	/// </summary>
    	ProtocolStateMachine SpecificMachine subsets DirectedRelationship.Source, Element.Owner;
    }

    /// <summary>
    /// A ProtocolStateMachine is always defined in the context of a Classifier. It specifies which BehavioralFeatures of the Classifier can be called in which State and under which conditions, thus specifying the allowed invocation sequences on the Classifier&apos;s BehavioralFeatures. A ProtocolStateMachine specifies the possible and permitted Transitions on the instances of its context Classifier, together with the BehavioralFeatures that carry the Transitions. In this manner, an instance lifecycle can be specified for a Classifier, by defining the order in which the BehavioralFeatures can be activated and the States through which an instance progresses during its existence.
    /// </summary>
    class ProtocolStateMachine : StateMachine
    {
    	/// <summary>
    	/// Conformance between ProtocolStateMachine 
    	/// </summary>
    	containment set<ProtocolConformance> Conformance subsets Element.OwnedElement;
    }

    /// <summary>
    /// A ProtocolTransition specifies a legal Transition for an Operation. Transitions of ProtocolStateMachines have the following information: a pre-condition (guard), a Trigger, and a post-condition. Every ProtocolTransition is associated with at most one BehavioralFeature belonging to the context Classifier of the ProtocolStateMachine.
    /// </summary>
    class ProtocolTransition : Transition
    {
    	/// <summary>
    	/// Specifies the post condition of the Transition which is the Condition that should be obtained once the Transition is triggered. This post condition is part of the post condition of the Operation connected to the Transition.
    	/// </summary>
    	containment Constraint PostCondition subsets Namespace.OwnedRule;
    	/// <summary>
    	/// Specifies the precondition of the Transition. It specifies the Condition that should be verified before triggering the Transition. This guard condition added to the source State will be evaluated as part of the precondition of the Operation referred by the Transition if any.
    	/// </summary>
    	containment Constraint PreCondition subsets Transition.Guard;
    	/// <summary>
    	/// This association refers to the associated Operation. It is derived from the Operation of the CallEvent Trigger when applicable.
    	/// </summary>
    	// spec:
    	//     result = (trigger->collect(event)->select(oclIsKindOf(CallEvent))->collect(oclAsType(CallEvent).operation)->asSet())
    	derived set<Operation> Referred;
    }

    /// <summary>
    /// A Pseudostate is an abstraction that encompasses different types of transient Vertices in the StateMachine graph. A StateMachine instance never comes to rest in a Pseudostate, instead, it will exit and enter the Pseudostate within a single run-to-completion step.
    /// </summary>
    class Pseudostate : Vertex
    {
    	/// <summary>
    	/// Determines the precise type of the Pseudostate and can be one of: entryPoint, exitPoint, initial, deepHistory, shallowHistory, join, fork, junction, terminate or choice.
    	/// </summary>
    	PseudostateKind Kind = "PseudostateKind.Initial";
    	/// <summary>
    	/// The State that owns this Pseudostate and in which it appears.
    	/// </summary>
    	State State subsets NamedElement.Namespace;
    	/// <summary>
    	/// The StateMachine in which this Pseudostate is defined. This only applies to Pseudostates of the kind entryPoint or exitPoint.
    	/// </summary>
    	StateMachine StateMachine subsets NamedElement.Namespace;
    	/// <summary>
    	/// The query isConsistentWith() specifies a Pseudostate can only be redefined by a Pseudostate of the same kind.
    	/// </summary>
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	// spec:
    	//     result = (redefiningElement.oclIsKindOf(Pseudostate) and
    	//     redefiningElement.oclAsType(Pseudostate).kind = kind)
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// A Region is a top-level part of a StateMachine or a composite State, that serves as a container for the Vertices and Transitions of the StateMachine. A StateMachine or composite State may contain multiple Regions representing behaviors that may occur in parallel.
    /// </summary>
    class Region : Namespace, RedefinableElement
    {
    	/// <summary>
    	/// The region of which this region is an extension.
    	/// </summary>
    	Region ExtendedRegion subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// References the Classifier in which context this element may be redefined.
    	/// </summary>
    	// spec:
    	//     result = containingStateMachine()
    	derived Classifier RedefinitionContext redefines RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// The State that owns the Region. If a Region is owned by a State, then it cannot also be owned by a StateMachine.
    	/// </summary>
    	State State subsets NamedElement.Namespace;
    	/// <summary>
    	/// The StateMachine that owns the Region. If a Region is owned by a StateMachine, then it cannot also be owned by a State.
    	/// </summary>
    	StateMachine StateMachine subsets NamedElement.Namespace;
    	/// <summary>
    	/// The set of Vertices that are owned by this Region.
    	/// </summary>
    	containment set<Vertex> Subvertex subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The set of Transitions owned by the Region.
    	/// </summary>
    	containment set<Transition> Transition subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The operation belongsToPSM () checks if the Region belongs to a ProtocolStateMachine.
    	/// </summary>
    	// spec:
    	//     result = (if  stateMachine <> null 
    	//     then
    	//       stateMachine.oclIsKindOf(ProtocolStateMachine)
    	//     else 
    	//       state <> null  implies  state.container.belongsToPSM()
    	//     endif )
    	readonly bool BelongsToPSM();
    	/// <summary>
    	/// The operation containingStateMachine() returns the StateMachine in which this Region is defined.
    	/// </summary>
    	// spec:
    	//     result = (if stateMachine = null 
    	//     then
    	//       state.containingStateMachine()
    	//     else
    	//       stateMachine
    	//     endif)
    	readonly StateMachine ContainingStateMachine();
    	/// <summary>
    	/// The query isConsistentWith specifies that a Region can be redefined by any Region for which the redefinition context is valid (see the isRedefinitionContextValid operation). Note that consistency requirements for the redefinition of Vertices and Transitions within a redefining Region are specified by the isConsistentWith and isRedefinitionContextValid operations for Vertex (and its subclasses) and Transition.
    	/// </summary>
    	// spec:
    	//     result = true
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    	/// <summary>
    	/// The query isRedefinitionContextValid() specifies whether the redefinition contexts of a Region are properly related to the redefinition contexts of the specified Region to allow this element to redefine the other. The containing StateMachine or State of a redefining Region must Redefine the containing StateMachine or State of the redefined Region.
    	/// </summary>
    	// spec:
    	//     result = (if redefinedElement.oclIsKindOf(Region) then
    	//       let redefinedRegion : Region = redefinedElement.oclAsType(Region) in
    	//         if stateMachine->isEmpty() then
    	//         -- the Region is owned by a State
    	//           (state.redefinedState->notEmpty() and state.redefinedState.region->includes(redefinedRegion))
    	//         else -- the region is owned by a StateMachine
    	//           (stateMachine.extendedStateMachine->notEmpty() and
    	//             stateMachine.extendedStateMachine->exists(sm : StateMachine |
    	//               sm.region->includes(redefinedRegion)))
    	//         endif
    	//     else
    	//       false
    	//     endif)
    	readonly bool IsRedefinitionContextValid(RedefinableElement redefinedElement);
    }

    /// <summary>
    /// A State models a situation during which some (usually implicit) invariant condition holds.
    /// </summary>
    class State : Namespace, Vertex
    {
    	/// <summary>
    	/// The entry and exit connection points used in conjunction with this (submachine) State, i.e., as targets and sources, respectively, in the Region with the submachine State. A connection point reference references the corresponding definition of a connection point Pseudostate in the StateMachine referenced by the submachine State.
    	/// </summary>
    	containment set<ConnectionPointReference> Connection subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The entry and exit Pseudostates of a composite State. These can only be entry or exit Pseudostates, and they must have different names. They can only be defined for composite States.
    	/// </summary>
    	containment set<Pseudostate> ConnectionPoint subsets Namespace.OwnedMember;
    	/// <summary>
    	/// A list of Triggers that are candidates to be retained by the StateMachine if they trigger no Transitions out of the State (not consumed). A deferred Trigger is retained until the StateMachine reaches a State configuration where it is no longer deferred.
    	/// </summary>
    	containment set<Trigger> DeferrableTrigger subsets Element.OwnedElement;
    	/// <summary>
    	/// An optional Behavior that is executed while being in the State. The execution starts when this State is entered, and ceases either by itself when done, or when the State is exited, whichever comes first.
    	/// </summary>
    	containment Behavior DoActivity subsets Element.OwnedElement;
    	/// <summary>
    	/// An optional Behavior that is executed whenever this State is entered regardless of the Transition taken to reach the State. If defined, entry Behaviors are always executed to completion prior to any internal Behavior or Transitions performed within the State.
    	/// </summary>
    	containment Behavior Entry subsets Element.OwnedElement;
    	/// <summary>
    	/// An optional Behavior that is executed whenever this State is exited regardless of which Transition was taken out of the State. If defined, exit Behaviors are always executed to completion only after all internal and transition Behaviors have completed execution.
    	/// </summary>
    	containment Behavior Exit subsets Element.OwnedElement;
    	/// <summary>
    	/// A state with isComposite=true is said to be a composite State. A composite State is a State that contains at least one Region.
    	/// </summary>
    	// spec:
    	//     result = (region->notEmpty())
    	derived bool IsComposite;
    	/// <summary>
    	/// A State with isOrthogonal=true is said to be an orthogonal composite State An orthogonal composite State contains two or more Regions.
    	/// </summary>
    	// spec:
    	//     result = (region->size () > 1)
    	derived bool IsOrthogonal;
    	/// <summary>
    	/// A State with isSimple=true is said to be a simple State A simple State does not have any Regions and it does not refer to any submachine StateMachine.
    	/// </summary>
    	// spec:
    	//     result = ((region->isEmpty()) and not isSubmachineState())
    	derived bool IsSimple;
    	/// <summary>
    	/// A State with isSubmachineState=true is said to be a submachine State Such a State refers to another StateMachine(submachine).
    	/// </summary>
    	// spec:
    	//     result = (submachine <> null)
    	derived bool IsSubmachineState;
    	/// <summary>
    	/// The Regions owned directly by the State.
    	/// </summary>
    	containment set<Region> Region subsets Namespace.OwnedMember;
    	/// <summary>
    	/// Specifies conditions that are always true when this State is the current State. In ProtocolStateMachines state invariants are additional conditions to the preconditions of the outgoing Transitions, and to the postcondition of the incoming Transitions.
    	/// </summary>
    	containment Constraint StateInvariant subsets Namespace.OwnedRule;
    	/// <summary>
    	/// The StateMachine that is to be inserted in place of the (submachine) State.
    	/// </summary>
    	StateMachine Submachine;
    	/// <summary>
    	/// The query containingStateMachine() returns the StateMachine that contains the State either directly or transitively.
    	/// </summary>
    	// spec:
    	//     result = (container.containingStateMachine())
    	readonly StateMachine ContainingStateMachine();
    	/// <summary>
    	/// The query isConsistentWith specifies that a non-final State can only be redefined by a non-final State (this is overridden by FinalState to allow a FinalState to be redefined by a FinalState) and, if the redefined State is a submachine State, then the redefining State must be a submachine state whose submachine is a redefinition of the submachine of the redefined State. Note that consistency requirements for the redefinition of Regions and connectionPoint Pseudostates within a composite State and connection ConnectionPoints of a submachine State are specified by the isConsistentWith and isRedefinitionContextValid operations for Region and Vertex (and its subclasses, Pseudostate and ConnectionPointReference).
    	/// </summary>
    	// spec:
    	//     result = (redefiningElement.oclIsTypeOf(State) and 
    	//       let redefiningState : State = redefiningElement.oclAsType(State) in
    	//         submachine <> null implies (redefiningState.submachine <> null and
    	//           redefiningState.submachine.extendedStateMachine->includes(submachine)))
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// StateMachines can be used to express event-driven behaviors of parts of a system. Behavior is modeled as a traversal of a graph of Vertices interconnected by one or more joined Transition arcs that are triggered by the dispatching of successive Event occurrences. During this traversal, the StateMachine may execute a sequence of Behaviors associated with various elements of the StateMachine.
    /// </summary>
    class StateMachine : Behavior
    {
    	/// <summary>
    	/// The connection points defined for this StateMachine. They represent the interface of the StateMachine when used as part of submachine State
    	/// </summary>
    	containment set<Pseudostate> ConnectionPoint subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The StateMachines of which this is an extension.
    	/// </summary>
    	set<StateMachine> ExtendedStateMachine redefines Behavior.RedefinedBehavior;
    	/// <summary>
    	/// The Regions owned directly by the StateMachine.
    	/// </summary>
    	containment set<Region> Region subsets Namespace.OwnedMember;
    	/// <summary>
    	/// References the submachine(s) in case of a submachine State. Multiple machines are referenced in case of a concurrent State.
    	/// </summary>
    	set<State> SubmachineState;
    	/// <summary>
    	/// The operation LCA(s1,s2) returns the Region that is the least common ancestor of Vertices s1 and s2, based on the StateMachine containment hierarchy.
    	/// </summary>
    	// spec:
    	//     result = (if ancestor(s1, s2) then 
    	//         s2.container
    	//     else
    	//     	if ancestor(s2, s1) then
    	//     	    s1.container 
    	//     	else 
    	//     	    LCA(s1.container.state, s2.container.state)
    	//     	endif
    	//     endif)
    	readonly Region LCA(Vertex s1, Vertex s2);
    	/// <summary>
    	/// The query ancestor(s1, s2) checks whether Vertex s2 is an ancestor of Vertex s1.
    	/// </summary>
    	// spec:
    	//     result = (if (s2 = s1) then 
    	//     	true 
    	//     else 
    	//     	if s1.container.stateMachine->notEmpty() then 
    	//     	    true
    	//     	else 
    	//     	    if s2.container.stateMachine->notEmpty() then 
    	//     	        false
    	//     	    else
    	//     	        ancestor(s1, s2.container.state)
    	//     	     endif
    	//     	 endif
    	//     endif  )
    	readonly bool Ancestor(Vertex s1, Vertex s2);
    	/// <summary>
    	/// The query isConsistentWith specifies that a StateMachine can be redefined by any other StateMachine for which the redefinition context is valid (see the isRedefinitionContextValid operation). Note that consistency requirements for the redefinition of Regions and connectionPoint Pseudostates owned by a StateMachine are specified by the isConsistentWith and isRedefinitionContextValid operations for Region and Vertex (and its subclass Pseudostate).
    	/// </summary>
    	// spec:
    	//     result = true
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    	/// <summary>
    	/// The query isRedefinitionContextValid specifies whether the redefinition context of a StateMachine is properly related to the redefinition contexts of a StateMachine it redefines. The requirement is that the context BehavioredClassifier of a redefining StateMachine must specialize the context Classifier of the redefined StateMachine. If the redefining StateMachine does not have a context BehavioredClassifier, then then the redefining StateMachine also must not have a context BehavioredClassifier but must, instead, specialize the redefining StateMachine.
    	/// </summary>
    	// spec:
    	//     result = (redefinedElement.oclIsKindOf(StateMachine) and
    	//       let parentContext : BehavioredClassifier =
    	//         redefinedElement.oclAsType(StateMachine).context in
    	//       if context = null then
    	//         parentContext = null and self.allParents()→includes(redefinedElement)
    	//       else
    	//         parentContext <> null and context.allParents()->includes(parentContext)
    	//       endif)
    	readonly bool IsRedefinitionContextValid(RedefinableElement redefinedElement);
    	/// <summary>
    	/// This utility funciton is like the LCA, except that it returns the nearest composite State that contains both input Vertices.
    	/// </summary>
    	// spec:
    	//     result = (if v2.oclIsTypeOf(State) and ancestor(v1, v2) then
    	//     	v2.oclAsType(State)
    	//     else if v1.oclIsTypeOf(State) and ancestor(v2, v1) then
    	//     	v1.oclAsType(State)
    	//     else if (v1.container.state->isEmpty() or v2.container.state->isEmpty()) then 
    	//     	null.oclAsType(State)
    	//     else LCAState(v1.container.state, v2.container.state)
    	//     endif endif endif)
    	readonly State LCAState(Vertex v1, Vertex v2);
    }

    /// <summary>
    /// A Transition represents an arc between exactly one source Vertex and exactly one Target vertex (the source and targets may be the same Vertex). It may form part of a compound transition, which takes the StateMachine from one steady State configuration to another, representing the full response of the StateMachine to an occurrence of an Event that triggered it.
    /// </summary>
    class Transition : Namespace, RedefinableElement
    {
    	/// <summary>
    	/// Designates the Region that owns this Transition.
    	/// </summary>
    	Region Container subsets NamedElement.Namespace;
    	/// <summary>
    	/// Specifies an optional behavior to be performed when the Transition fires.
    	/// </summary>
    	containment Behavior Effect subsets Element.OwnedElement;
    	/// <summary>
    	/// A guard is a Constraint that provides a fine-grained control over the firing of the Transition. The guard is evaluated when an Event occurrence is dispatched by the StateMachine. If the guard is true at that time, the Transition may be enabled, otherwise, it is disabled. Guards should be pure expressions without side effects. Guard expressions with side effects are ill formed.
    	/// </summary>
    	containment Constraint Guard subsets Namespace.OwnedRule;
    	/// <summary>
    	/// Indicates the precise type of the Transition.
    	/// </summary>
    	TransitionKind Kind = "TransitionKind.External";
    	/// <summary>
    	/// The Transition that is redefined by this Transition.
    	/// </summary>
    	Transition RedefinedTransition subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// References the Classifier in which context this element may be redefined.
    	/// </summary>
    	// spec:
    	//     result = containingStateMachine()
    	derived Classifier RedefinitionContext redefines RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// Designates the originating Vertex (State or Pseudostate) of the Transition.
    	/// </summary>
    	Vertex Source;
    	/// <summary>
    	/// Designates the target Vertex that is reached when the Transition is taken.
    	/// </summary>
    	Vertex Target;
    	/// <summary>
    	/// Specifies the Triggers that may fire the transition.
    	/// </summary>
    	containment set<Trigger> Trigger subsets Element.OwnedElement;
    	/// <summary>
    	/// The query containingStateMachine() returns the StateMachine that contains the Transition either directly or transitively.
    	/// </summary>
    	// spec:
    	//     result = (container.containingStateMachine())
    	readonly StateMachine ContainingStateMachine();
    	/// <summary>
    	/// The query isConsistentWith specifies that a redefining Transition is consistent with a redefined Transition provided that the source Vertex of the redefining Transition redefines the source Vertex of the redefined Transition.
    	/// </summary>
    	// spec:
    	//     result = (redefiningElement.oclIsKindOf(Transition) and
    	//       redefiningElement.oclAsType(Transition).source.redefinedTransition = source)
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// A Vertex is an abstraction of a node in a StateMachine graph. It can be the source or destination of any number of Transitions.
    /// </summary>
    abstract class Vertex : NamedElement, RedefinableElement
    {
    	/// <summary>
    	/// The Region that contains this Vertex.
    	/// </summary>
    	Region Container subsets NamedElement.Namespace;
    	/// <summary>
    	/// Specifies the Transitions entering this Vertex.
    	/// </summary>
    	// spec:
    	//     result = (Transition.allInstances()->select(target=self))
    	derived set<Transition> Incoming;
    	/// <summary>
    	/// Specifies the Transitions departing from this Vertex.
    	/// </summary>
    	// spec:
    	//     result = (Transition.allInstances()->select(source=self))
    	derived set<Transition> Outgoing;
    	/// <summary>
    	/// References the Classifier in which context this element may be redefined.
    	/// </summary>
    	// spec:
    	//     result = containingStateMachine()
    	derived Classifier RedefinitionContext redefines RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// The Vertex of which this Vertex is a redefinition.
    	/// </summary>
    	Vertex RedefinedVertex subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// The operation containingStateMachine() returns the StateMachine in which this Vertex is defined.
    	/// </summary>
    	// spec:
    	//     result = (if container <> null
    	//     then
    	//     -- the container is a region
    	//        container.containingStateMachine()
    	//     else 
    	//        if (self.oclIsKindOf(Pseudostate)) and ((self.oclAsType(Pseudostate).kind = PseudostateKind::entryPoint) or (self.oclAsType(Pseudostate).kind = PseudostateKind::exitPoint)) then
    	//           self.oclAsType(Pseudostate).stateMachine
    	//        else 
    	//           if (self.oclIsKindOf(ConnectionPointReference)) then
    	//               self.oclAsType(ConnectionPointReference).state.containingStateMachine() -- no other valid cases possible
    	//           else 
    	//               null
    	//           endif
    	//        endif
    	//     endif
    	//     )
    	readonly StateMachine ContainingStateMachine();
    	/// <summary>
    	/// This utility operation returns true if the Vertex is contained in the State s (input argument).
    	/// </summary>
    	// spec:
    	//     result = (if not s.isComposite() or container->isEmpty() then
    	//     	false
    	//     else
    	//     	if container.state = s then 
    	//     		true
    	//     	else
    	//     		container.state.isContainedInState(s)
    	//     	endif
    	//     endif)
    	readonly bool IsContainedInState(State s);
    	/// <summary>
    	/// This utility query returns true if the Vertex is contained in the Region r (input argument).
    	/// </summary>
    	// spec:
    	//     result = (if (container = r) then
    	//     	true
    	//     else
    	//     	if (r.state->isEmpty()) then
    	//     		false
    	//     	else
    	//     		container.state.isContainedInRegion(r)
    	//     	endif
    	//     endif)
    	readonly bool IsContainedInRegion(Region r);
    	/// <summary>
    	/// The query isRedefinitionContextValid specifies that the redefinition context of a redefining Vertex is properly related to the redefinition context of the redefined Vertex if the owner of the redefining Vertex is a redefinition of the owner of the redefined Vertex. Note that the owner of a Vertex may be a Region, a StateMachine (for a connectionPoint Pseudostate), or a State (for a connectionPoint Pseudostate or a connection ConnectionPointReference), all of which are RedefinableElements.
    	/// </summary>
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	// spec:
    	//     result = (redefinedElement.oclIsKindOf(Vertex) and
    	//       owner.oclAsType(RedefinableElement).redefinedElement->includes(redefinedElement.owner))
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// A BehavioredClassifier may have InterfaceRealizations, and owns a set of Behaviors one of which may specify the behavior of the BehavioredClassifier itself.
    /// </summary>
    abstract class BehavioredClassifier : Classifier
    {
    	/// <summary>
    	/// A Behavior that specifies the behavior of the BehavioredClassifier itself.
    	/// </summary>
    	Behavior ClassifierBehavior subsets BehavioredClassifier.OwnedBehavior;
    	/// <summary>
    	/// The set of InterfaceRealizations owned by the BehavioredClassifier. Interface realizations reference the Interfaces of which the BehavioredClassifier is an implementation.
    	/// </summary>
    	containment set<InterfaceRealization> InterfaceRealization subsets Element.OwnedElement, NamedElement.ClientDependency;
    	/// <summary>
    	/// Behaviors owned by a BehavioredClassifier.
    	/// </summary>
    	containment set<Behavior> OwnedBehavior subsets Namespace.OwnedMember;
    }

    /// <summary>
    /// A DataType is a type whose instances are identified only by their value.
    /// </summary>
    class DataType : Classifier
    {
    	/// <summary>
    	/// The attributes owned by the DataType.
    	/// </summary>
    	containment list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    	/// <summary>
    	/// The Operations owned by the DataType.
    	/// </summary>
    	containment list<Operation> OwnedOperation subsets Classifier.Feature, Namespace.OwnedMember;
    }

    /// <summary>
    /// An Enumeration is a DataType whose values are enumerated in the model as EnumerationLiterals.
    /// </summary>
    class Enumeration : DataType
    {
    	/// <summary>
    	/// The ordered set of literals owned by this Enumeration.
    	/// </summary>
    	containment list<EnumerationLiteral> OwnedLiteral subsets Namespace.OwnedMember;
    }

    /// <summary>
    /// An EnumerationLiteral is a user-defined data value for an Enumeration.
    /// </summary>
    class EnumerationLiteral : InstanceSpecification
    {
    	/// <summary>
    	/// The classifier of this EnumerationLiteral derived to be equal to its Enumeration.
    	/// </summary>
    	// spec:
    	//     result = (enumeration)
    	derived Enumeration Classifier redefines InstanceSpecification.Classifier;
    	/// <summary>
    	/// The Enumeration that this EnumerationLiteral is a member of.
    	/// </summary>
    	Enumeration Enumeration subsets NamedElement.Namespace;
    }

    /// <summary>
    /// Interfaces declare coherent services that are implemented by BehavioredClassifiers that implement the Interfaces via InterfaceRealizations.
    /// </summary>
    class Interface : Classifier
    {
    	/// <summary>
    	/// References all the Classifiers that are defined (nested) within the Interface.
    	/// </summary>
    	containment list<Classifier> NestedClassifier subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The attributes (i.e., the Properties) owned by the Interface.
    	/// </summary>
    	containment list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    	/// <summary>
    	/// The Operations owned by the Interface.
    	/// </summary>
    	containment list<Operation> OwnedOperation subsets Classifier.Feature, Namespace.OwnedMember;
    	/// <summary>
    	/// Receptions that objects providing this Interface are willing to accept.
    	/// </summary>
    	containment set<Reception> OwnedReception subsets Classifier.Feature, Namespace.OwnedMember;
    	/// <summary>
    	/// References a ProtocolStateMachine specifying the legal sequences of the invocation of the BehavioralFeatures described in the Interface.
    	/// </summary>
    	containment ProtocolStateMachine Protocol subsets Namespace.OwnedMember;
    	/// <summary>
    	/// References all the Interfaces redefined by this Interface.
    	/// </summary>
    	set<Interface> RedefinedInterface subsets Classifier.RedefinedClassifier;
    }

    /// <summary>
    /// An InterfaceRealization is a specialized realization relationship between a BehavioredClassifier and an Interface. This relationship signifies that the realizing BehavioredClassifier conforms to the contract specified by the Interface.
    /// </summary>
    class InterfaceRealization : Realization
    {
    	/// <summary>
    	/// References the Interface specifying the conformance contract.
    	/// </summary>
    	Interface Contract subsets Dependency.Supplier;
    	/// <summary>
    	/// References the BehavioredClassifier that owns this InterfaceRealization, i.e., the BehavioredClassifier that realizes the Interface to which it refers.
    	/// </summary>
    	BehavioredClassifier ImplementingClassifier subsets Dependency.Client, Element.Owner;
    }

    /// <summary>
    /// A PrimitiveType defines a predefined DataType, without any substructure. A PrimitiveType may have an algebra and operations defined outside of UML, for example, mathematically.
    /// </summary>
    class PrimitiveType : DataType
    {
    }

    /// <summary>
    /// A Reception is a declaration stating that a Classifier is prepared to react to the receipt of a Signal.
    /// </summary>
    class Reception : BehavioralFeature
    {
    	/// <summary>
    	/// The Signal that this Reception handles.
    	/// </summary>
    	Signal Signal;
    }

    /// <summary>
    /// A Signal is a specification of a kind of communication between objects in which a reaction is asynchronously triggered in the receiver without a reply.
    /// </summary>
    class Signal : Classifier
    {
    	/// <summary>
    	/// The attributes owned by the Signal.
    	/// </summary>
    	containment list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    }

    /// <summary>
    /// An extension is used to indicate that the properties of a metaclass are extended through a stereotype, and gives the ability to flexibly add (and later remove) stereotypes to classes.
    /// </summary>
    class Extension : Association
    {
    	/// <summary>
    	/// Indicates whether an instance of the extending stereotype must be created when an instance of the extended class is created. The attribute value is derived from the value of the lower property of the ExtensionEnd referenced by Extension::ownedEnd; a lower value of 1 means that isRequired is true, but otherwise it is false. Since the default value of ExtensionEnd::lower is 0, the default value of isRequired is false.
    	/// </summary>
    	// spec:
    	//     result = (ownedEnd.lowerBound() = 1)
    	derived bool IsRequired;
    	/// <summary>
    	/// References the Class that is extended through an Extension. The property is derived from the type of the memberEnd that is not the ownedEnd.
    	/// </summary>
    	// spec:
    	//     result = (metaclassEnd().type.oclAsType(Class))
    	derived Class Metaclass;
    	/// <summary>
    	/// References the end of the extension that is typed by a Stereotype.
    	/// </summary>
    	containment ExtensionEnd OwnedEnd redefines Association.OwnedEnd;
    	/// <summary>
    	/// The query metaclassEnd() returns the Property that is typed by a metaclass (as opposed to a stereotype).
    	/// </summary>
    	// spec:
    	//     result = (memberEnd->reject(p | ownedEnd->includes(p.oclAsType(ExtensionEnd)))->any(true))
    	readonly Property MetaclassEnd();
    }

    /// <summary>
    /// An extension end is used to tie an extension to a stereotype when extending a metaclass.
    /// The default multiplicity of an extension end is 0..1.
    /// </summary>
    class ExtensionEnd : Property
    {
    	/// <summary>
    	/// This redefinition changes the default multiplicity of association ends, since model elements are usually extended by 0 or 1 instance of the extension stereotype.
    	/// </summary>
    	derived int Lower redefines MultiplicityElement.Lower;
    	/// <summary>
    	/// References the type of the ExtensionEnd. Note that this association restricts the possible types of an ExtensionEnd to only be Stereotypes.
    	/// </summary>
    	Stereotype Type redefines TypedElement.Type;
    	/// <summary>
    	/// The query lowerBound() returns the lower bound of the multiplicity as an Integer. This is a redefinition of the default lower bound, which normally, for MultiplicityElements, evaluates to 1 if empty.
    	/// </summary>
    	// spec:
    	//     result = (if lowerValue=null then 0 else lowerValue.integerValue() endif)
    	readonly int LowerBound();
    }

    /// <summary>
    /// Physical definition of a graphical image.
    /// </summary>
    class Image : Element
    {
    	/// <summary>
    	/// This contains the serialization of the image according to the format. The value could represent a bitmap, image such as a GIF file, or drawing &apos;instructions&apos; using a standard such as Scalable Vector Graphic (SVG) (which is XML based).
    	/// </summary>
    	string Content;
    	/// <summary>
    	/// This indicates the format of the content, which is how the string content should be interpreted. The following values are reserved: SVG, GIF, PNG, JPG, WMF, EMF, BMP. In addition the prefix &apos;MIME: &apos; is also reserved. This option can be used as an alternative to express the reserved values above, for example &quot;SVG&quot; could instead be expressed as &quot;MIME: image/svg+xml&quot;.
    	/// </summary>
    	string Format;
    	/// <summary>
    	/// This contains a location that can be used by a tool to locate the image as an alternative to embedding it in the stereotype.
    	/// </summary>
    	string Location;
    }

    /// <summary>
    /// A model captures a view of a physical system. It is an abstraction of the physical system, with a certain purpose. This purpose determines what is to be included in the model and what is irrelevant. Thus the model completely describes those aspects of the physical system that are relevant to the purpose of the model, at the appropriate level of detail.
    /// </summary>
    class Model : Package
    {
    	/// <summary>
    	/// The name of the viewpoint that is expressed by a model (this name may refer to a profile definition).
    	/// </summary>
    	string Viewpoint;
    }

    /// <summary>
    /// A package can have one or more profile applications to indicate which profiles have been applied. Because a profile is a package, it is possible to apply a profile not only to packages, but also to profiles.
    /// Package specializes TemplateableElement and PackageableElement specializes ParameterableElement to specify that a package can be used as a template and a PackageableElement as a template parameter.
    /// A package is used to group elements, and provides a namespace for the grouped elements.
    /// </summary>
    class Package : PackageableElement, TemplateableElement, Namespace
    {
    	/// <summary>
    	/// Provides an identifier for the package that can be used for many purposes. A URI is the universally unique identification of the package following the IETF URI specification, RFC 2396 http://www.ietf.org/rfc/rfc2396.txt and it must comply with those syntax rules.
    	/// </summary>
    	string URI;
    	/// <summary>
    	/// References the packaged elements that are Packages.
    	/// </summary>
    	// spec:
    	//     result = (packagedElement->select(oclIsKindOf(Package))->collect(oclAsType(Package))->asSet())
    	containment derived set<Package> NestedPackage subsets Package.PackagedElement;
    	/// <summary>
    	/// References the Package that owns this Package.
    	/// </summary>
    	Package NestingPackage;
    	/// <summary>
    	/// References the Stereotypes that are owned by the Package.
    	/// </summary>
    	// spec:
    	//     result = (packagedElement->select(oclIsKindOf(Stereotype))->collect(oclAsType(Stereotype))->asSet())
    	containment derived set<Stereotype> OwnedStereotype subsets Package.PackagedElement;
    	/// <summary>
    	/// References the packaged elements that are Types.
    	/// </summary>
    	// spec:
    	//     result = (packagedElement->select(oclIsKindOf(Type))->collect(oclAsType(Type))->asSet())
    	containment derived set<Type> OwnedType subsets Package.PackagedElement;
    	/// <summary>
    	/// References the PackageMerges that are owned by this Package.
    	/// </summary>
    	containment set<PackageMerge> PackageMerge subsets Element.OwnedElement;
    	/// <summary>
    	/// Specifies the packageable elements that are owned by this Package.
    	/// </summary>
    	containment set<PackageableElement> PackagedElement subsets Namespace.OwnedMember;
    	/// <summary>
    	/// References the ProfileApplications that indicate which profiles have been applied to the Package.
    	/// </summary>
    	containment set<ProfileApplication> ProfileApplication subsets Element.OwnedElement;
    	/// <summary>
    	/// The query allApplicableStereotypes() returns all the directly or indirectly owned stereotypes, including stereotypes contained in sub-profiles.
    	/// </summary>
    	// spec:
    	//     result = (let ownedPackages : Bag(Package) = ownedMember->select(oclIsKindOf(Package))->collect(oclAsType(Package)) in
    	//      ownedStereotype->union(ownedPackages.allApplicableStereotypes())->flatten()->asSet()
    	//     )
    	readonly set<Stereotype> AllApplicableStereotypes();
    	/// <summary>
    	/// The query containingProfile() returns the closest profile directly or indirectly containing this package (or this package itself, if it is a profile).
    	/// </summary>
    	// spec:
    	//     result = (if self.oclIsKindOf(Profile) then 
    	//     	self.oclAsType(Profile)
    	//     else
    	//     	self.namespace.oclAsType(Package).containingProfile()
    	//     endif)
    	readonly Profile ContainingProfile();
    	/// <summary>
    	/// The query makesVisible() defines whether a Package makes an element visible outside itself. Elements with no visibility and elements with public visibility are made visible.
    	/// </summary>
    	// pre:
    	//     member->includes(el)
    	// spec:
    	//     result = (ownedMember->includes(el) or
    	//     (elementImport->select(ei|ei.importedElement = VisibilityKind::public)->collect(importedElement.oclAsType(NamedElement))->includes(el)) or
    	//     (packageImport->select(visibility = VisibilityKind::public)->collect(importedPackage.member->includes(el))->notEmpty()))
    	readonly bool MakesVisible(NamedElement el);
    	/// <summary>
    	/// The query mustBeOwned() indicates whether elements of this type must have an owner.
    	/// </summary>
    	// spec:
    	//     result = (false)
    	readonly bool MustBeOwned();
    	/// <summary>
    	/// The query visibleMembers() defines which members of a Package can be accessed outside it.
    	/// </summary>
    	// spec:
    	//     result = (member->select( m | m.oclIsKindOf(PackageableElement) and self.makesVisible(m))->collect(oclAsType(PackageableElement))->asSet())
    	readonly set<PackageableElement> VisibleMembers();
    }

    /// <summary>
    /// A package merge defines how the contents of one package are extended by the contents of another package.
    /// </summary>
    class PackageMerge : DirectedRelationship
    {
    	/// <summary>
    	/// References the Package that is to be merged with the receiving package of the PackageMerge.
    	/// </summary>
    	Package MergedPackage subsets DirectedRelationship.Target;
    	/// <summary>
    	/// References the Package that is being extended with the contents of the merged package of the PackageMerge.
    	/// </summary>
    	Package ReceivingPackage subsets DirectedRelationship.Source, Element.Owner;
    }

    /// <summary>
    /// A profile defines limited extensions to a reference metamodel with the purpose of adapting the metamodel to a specific platform or domain.
    /// </summary>
    class Profile : Package
    {
    	/// <summary>
    	/// References a metaclass that may be extended.
    	/// </summary>
    	containment set<ElementImport> MetaclassReference subsets Namespace.ElementImport;
    	/// <summary>
    	/// References a package containing (directly or indirectly) metaclasses that may be extended.
    	/// </summary>
    	containment set<PackageImport> MetamodelReference subsets Namespace.PackageImport;
    }

    /// <summary>
    /// A profile application is used to show which profiles have been applied to a package.
    /// </summary>
    class ProfileApplication : DirectedRelationship
    {
    	/// <summary>
    	/// References the Profiles that are applied to a Package through this ProfileApplication.
    	/// </summary>
    	Profile AppliedProfile subsets DirectedRelationship.Target;
    	/// <summary>
    	/// The package that owns the profile application.
    	/// </summary>
    	Package ApplyingPackage subsets DirectedRelationship.Source, Element.Owner;
    	/// <summary>
    	/// Specifies that the Profile filtering rules for the metaclasses of the referenced metamodel shall be strictly applied.
    	/// </summary>
    	bool IsStrict = "false";
    }

    /// <summary>
    /// A stereotype defines how an existing metaclass may be extended, and enables the use of platform or domain specific terminology or notation in place of, or in addition to, the ones used for the extended metaclass.
    /// </summary>
    class Stereotype : Class
    {
    	/// <summary>
    	/// Stereotype can change the graphical appearance of the extended model element by using attached icons. When this association is not null, it references the location of the icon content to be displayed within diagrams presenting the extended model elements.
    	/// </summary>
    	containment set<Image> Icon subsets Element.OwnedElement;
    	/// <summary>
    	/// The profile that directly or indirectly contains this stereotype.
    	/// </summary>
    	// spec:
    	//     result = (self.containingProfile())
    	derived Profile Profile;
    	/// <summary>
    	/// The query containingProfile returns the closest profile directly or indirectly containing this stereotype.
    	/// </summary>
    	// spec:
    	//     result = (self.namespace.oclAsType(Package).containingProfile())
    	readonly Profile ContainingProfile();
    }

    /// <summary>
    /// An ActionExecutionSpecification is a kind of ExecutionSpecification representing the execution of an Action.
    /// </summary>
    class ActionExecutionSpecification : ExecutionSpecification
    {
    	/// <summary>
    	/// Action whose execution is occurring.
    	/// </summary>
    	Action Action;
    }

    /// <summary>
    /// A BehaviorExecutionSpecification is a kind of ExecutionSpecification representing the execution of a Behavior.
    /// </summary>
    class BehaviorExecutionSpecification : ExecutionSpecification
    {
    	/// <summary>
    	/// Behavior whose execution is occurring.
    	/// </summary>
    	Behavior Behavior;
    }

    /// <summary>
    /// A CombinedFragment defines an expression of InteractionFragments. A CombinedFragment is defined by an interaction operator and corresponding InteractionOperands. Through the use of CombinedFragments the user will be able to describe a number of traces in a compact and concise manner.
    /// </summary>
    class CombinedFragment : InteractionFragment
    {
    	/// <summary>
    	/// Specifies the gates that form the interface between this CombinedFragment and its surroundings
    	/// </summary>
    	containment set<Gate> CfragmentGate subsets Element.OwnedElement;
    	/// <summary>
    	/// Specifies the operation which defines the semantics of this combination of InteractionFragments.
    	/// </summary>
    	InteractionOperatorKind InteractionOperator = "InteractionOperatorKind.Seq";
    	/// <summary>
    	/// The set of operands of the combined fragment.
    	/// </summary>
    	containment list<InteractionOperand> Operand subsets Element.OwnedElement;
    }

    /// <summary>
    /// A ConsiderIgnoreFragment is a kind of CombinedFragment that is used for the consider and ignore cases, which require lists of pertinent Messages to be specified.
    /// </summary>
    class ConsiderIgnoreFragment : CombinedFragment
    {
    	/// <summary>
    	/// The set of messages that apply to this fragment.
    	/// </summary>
    	set<NamedElement> Message;
    }

    /// <summary>
    /// A Continuation is a syntactic way to define continuations of different branches of an alternative CombinedFragment. Continuations are intuitively similar to labels representing intermediate points in a flow of control.
    /// </summary>
    class Continuation : InteractionFragment
    {
    	/// <summary>
    	/// True: when the Continuation is at the end of the enclosing InteractionFragment and False when it is in the beginning.
    	/// </summary>
    	bool Setting = "true";
    }

    /// <summary>
    /// A DestructionOccurenceSpecification models the destruction of an object.
    /// </summary>
    class DestructionOccurrenceSpecification : MessageOccurrenceSpecification
    {
    }

    /// <summary>
    /// An ExecutionOccurrenceSpecification represents moments in time at which Actions or Behaviors start or finish.
    /// </summary>
    class ExecutionOccurrenceSpecification : OccurrenceSpecification
    {
    	/// <summary>
    	/// References the execution specification describing the execution that is started or finished at this execution event.
    	/// </summary>
    	ExecutionSpecification Execution;
    }

    /// <summary>
    /// An ExecutionSpecification is a specification of the execution of a unit of Behavior or Action within the Lifeline. The duration of an ExecutionSpecification is represented by two OccurrenceSpecifications, the start OccurrenceSpecification and the finish OccurrenceSpecification.
    /// </summary>
    abstract class ExecutionSpecification : InteractionFragment
    {
    	/// <summary>
    	/// References the OccurrenceSpecification that designates the finish of the Action or Behavior.
    	/// </summary>
    	OccurrenceSpecification Finish;
    	/// <summary>
    	/// References the OccurrenceSpecification that designates the start of the Action or Behavior.
    	/// </summary>
    	OccurrenceSpecification Start;
    }

    /// <summary>
    /// A Gate is a MessageEnd which serves as a connection point for relating a Message which has a MessageEnd (sendEvent / receiveEvent) outside an InteractionFragment with another Message which has a MessageEnd (receiveEvent / sendEvent)  inside that InteractionFragment.
    /// </summary>
    class Gate : MessageEnd
    {
	    	/// <summary>
    	/// The CombinedFragment to which the Gate is attached to.
    	/// </summary>
		CombinedFragment CombinedFragment subsets Element.Owner;
    	/// <summary>
    	/// The InteractionUse of which the Gate is an actual gate.
    	/// </summary>
		InteractionUse InteractionUse subsets Element.Owner;
		/// <summary>
    	/// The Interaction that owns the Gate.
    	/// </summary>
		Interaction Interaction subsets NamedElement.Namespace;
    	/// <summary>
    	/// This query returns true if this Gate is attached to the boundary of a CombinedFragment, and its other end (if present)  is outside of the same CombinedFragment.
    	/// </summary>
    	// spec:
    	//     result = (self.oppositeEnd()-> notEmpty() and combinedFragment->notEmpty() implies
    	//     let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
    	//     if oppEnd.oclIsKindOf(MessageOccurrenceSpecification) 
    	//     then let oppMOS : MessageOccurrenceSpecification = oppEnd.oclAsType(MessageOccurrenceSpecification)
    	//     in  self.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	//          union(self.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet()) =
    	//          oppMOS.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	//          union(oppMOS.enclosingOperand.oclAsType(InteractionFragment)->asSet())
    	//     else let oppGate : Gate = oppEnd.oclAsType(Gate) 
    	//     in self.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	//          union(self.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet()) =
    	//          oppGate.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	//          union(oppGate.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet())
    	//     endif)
    	readonly bool IsOutsideCF();
    	/// <summary>
    	/// This query returns true if this Gate is attached to the boundary of a CombinedFragment, and its other end (if present) is inside of an InteractionOperator of the same CombinedFragment.
    	/// </summary>
    	// spec:
    	//     result = (self.oppositeEnd()-> notEmpty() and combinedFragment->notEmpty() implies
    	//     let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
    	//     if oppEnd.oclIsKindOf(MessageOccurrenceSpecification)
    	//     then let oppMOS : MessageOccurrenceSpecification
    	//     = oppEnd.oclAsType(MessageOccurrenceSpecification)
    	//     in combinedFragment = oppMOS.enclosingOperand.combinedFragment
    	//     else let oppGate : Gate = oppEnd.oclAsType(Gate)
    	//     in combinedFragment = oppGate.combinedFragment.enclosingOperand.combinedFragment
    	//     endif)
    	readonly bool IsInsideCF();
    	/// <summary>
    	/// This query returns true value if this Gate is an actualGate of an InteractionUse.
    	/// </summary>
    	// spec:
    	//     result = (interactionUse->notEmpty())
    	readonly bool IsActual();
    	/// <summary>
    	/// This query returns true if this Gate is a formalGate of an Interaction.
    	/// </summary>
    	/// <para>
    	/// &lt;p&gt;interaction-&amp;gt;notEmpty()&lt;/p&gt;
    	/// </para>
    	// spec:
    	//     result = (interaction->notEmpty())
    	readonly bool IsFormal();
    	/// <summary>
    	/// This query returns the name of the gate, either the explicit name (.name) or the constructed name (&apos;out_&quot; or &apos;in_&apos; concatenated in front of .message.name) if the explicit name is not present.
    	/// </summary>
    	// spec:
    	//     result = (if name->notEmpty() then name->asOrderedSet()->first()
    	//     else  if isActual() or isOutsideCF() 
    	//       then if isSend() 
    	//         then 'out_'.concat(self.message.name->asOrderedSet()->first())
    	//         else 'in_'.concat(self.message.name->asOrderedSet()->first())
    	//         endif
    	//       else if isSend()
    	//         then 'in_'.concat(self.message.name->asOrderedSet()->first())
    	//         else 'out_'.concat(self.message.name->asOrderedSet()->first())
    	//         endif
    	//       endif
    	//     endif)
    	readonly string GetName();
    	/// <summary>
    	/// This query returns true if the name of this Gate matches the name of the in parameter Gate, and the messages for the two Gates correspond. The Message for one Gate (say A) corresponds to the Message for another Gate (say B) if (A and B have the same name value) and (if A is a sendEvent then B is a receiveEvent) and (if A is a receiveEvent then B is a sendEvent) and (A and B have the same messageSort value) and (A and B have the same signature value).
    	/// </summary>
    	// spec:
    	//     result = (self.getName() = gateToMatch.getName() and 
    	//     self.message.messageSort = gateToMatch.message.messageSort and
    	//     self.message.name = gateToMatch.message.name and
    	//     self.message.sendEvent->includes(self) implies gateToMatch.message.receiveEvent->includes(gateToMatch)  and
    	//     self.message.receiveEvent->includes(self) implies gateToMatch.message.sendEvent->includes(gateToMatch) and
    	//     self.message.signature = gateToMatch.message.signature)
    	readonly bool Matches(Gate gateToMatch);
    	/// <summary>
    	/// The query isDistinguishableFrom() specifies that two Gates may coexist in the same Namespace, without an explicit name property. The association end formalGate subsets ownedElement, and since the Gate name attribute
    	/// is optional, it is allowed to have two formal gates without an explicit name, but having derived names which are distinct.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsDistinguishableFrom(NamedElement n, Namespace ns);
    	/// <summary>
    	/// If the Gate is an inside Combined Fragment Gate, this operation returns the InteractionOperand that the opposite end of this Gate is included within.
    	/// </summary>
    	// spec:
    	//     result = (if isInsideCF() then
    	//       let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
    	//         if oppEnd.oclIsKindOf(MessageOccurrenceSpecification)
    	//         then let oppMOS : MessageOccurrenceSpecification = oppEnd.oclAsType(MessageOccurrenceSpecification)
    	//             in oppMOS.enclosingOperand->asOrderedSet()->first()
    	//         else let oppGate : Gate = oppEnd.oclAsType(Gate)
    	//             in oppGate.combinedFragment.enclosingOperand->asOrderedSet()->first()
    	//         endif
    	//       else null
    	//     endif)
    	readonly InteractionOperand GetOperand();
    }

    /// <summary>
    /// A GeneralOrdering represents a binary relation between two OccurrenceSpecifications, to describe that one OccurrenceSpecification must occur before the other in a valid trace. This mechanism provides the ability to define partial orders of OccurrenceSpecifications that may otherwise not have a specified order.
    /// </summary>
    class GeneralOrdering : NamedElement
    {
    	/// <summary>
    	/// The OccurrenceSpecification referenced comes after the OccurrenceSpecification referenced by before.
    	/// </summary>
    	OccurrenceSpecification After;
    	/// <summary>
    	/// The OccurrenceSpecification referenced comes before the OccurrenceSpecification referenced by after.
    	/// </summary>
    	OccurrenceSpecification Before;
    }

    /// <summary>
    /// An Interaction is a unit of Behavior that focuses on the observable exchange of information between connectable elements.
    /// </summary>
    class Interaction : InteractionFragment, Behavior
    {
    	/// <summary>
    	/// Actions owned by the Interaction.
    	/// </summary>
    	containment set<Action> Action subsets Element.OwnedElement;
    	/// <summary>
    	/// Specifies the gates that form the message interface between this Interaction and any InteractionUses which reference it.
    	/// </summary>
    	containment set<Gate> FormalGate subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The ordered set of fragments in the Interaction.
    	/// </summary>
    	containment list<InteractionFragment> Fragment subsets Namespace.OwnedMember;
    	/// <summary>
    	/// Specifies the participants in this Interaction.
    	/// </summary>
    	containment set<Lifeline> Lifeline subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The Messages contained in this Interaction.
    	/// </summary>
    	containment set<Message> Message subsets Namespace.OwnedMember;
    }

    /// <summary>
    /// An InteractionConstraint is a Boolean expression that guards an operand in a CombinedFragment.
    /// </summary>
    class InteractionConstraint : Constraint
    {
    	/// <summary>
    	/// The maximum number of iterations of a loop
    	/// </summary>
    	containment ValueSpecification Maxint subsets Element.OwnedElement;
    	/// <summary>
    	/// The minimum number of iterations of a loop
    	/// </summary>
    	containment ValueSpecification Minint subsets Element.OwnedElement;
    }

    /// <summary>
    /// InteractionFragment is an abstract notion of the most general interaction unit. An InteractionFragment is a piece of an Interaction. Each InteractionFragment is conceptually like an Interaction by itself.
    /// </summary>
    abstract class InteractionFragment : NamedElement
    {
    	/// <summary>
    	/// References the Lifelines that the InteractionFragment involves.
    	/// </summary>
    	set<Lifeline> Covered;
    	/// <summary>
    	/// The Interaction enclosing this InteractionFragment.
    	/// </summary>
    	Interaction EnclosingInteraction subsets NamedElement.Namespace;
    	/// <summary>
    	/// The operand enclosing this InteractionFragment (they may nest recursively).
    	/// </summary>
    	InteractionOperand EnclosingOperand subsets NamedElement.Namespace;
    	/// <summary>
    	/// The general ordering relationships contained in this fragment.
    	/// </summary>
    	containment set<GeneralOrdering> GeneralOrdering subsets Element.OwnedElement;
    }

    /// <summary>
    /// An InteractionOperand is contained in a CombinedFragment. An InteractionOperand represents one operand of the expression given by the enclosing CombinedFragment.
    /// </summary>
    class InteractionOperand : InteractionFragment, Namespace
    {
	    /// <summary>
    	/// The CombinedFragment that contains the InteractionOperand.
    	/// </summary>
		CombinedFragment CombinedFragment subsets Element.Owner;
    	/// <summary>
    	/// The fragments of the operand.
    	/// </summary>
    	containment list<InteractionFragment> Fragment subsets Namespace.OwnedMember;
    	/// <summary>
    	/// Constraint of the operand.
    	/// </summary>
    	containment InteractionConstraint Guard subsets Element.OwnedElement;
    }

    /// <summary>
    /// An InteractionUse refers to an Interaction. The InteractionUse is a shorthand for copying the contents of the referenced Interaction where the InteractionUse is. To be accurate the copying must take into account substituting parameters with arguments and connect the formal Gates with the actual ones.
    /// </summary>
    class InteractionUse : InteractionFragment
    {
    	/// <summary>
    	/// The actual gates of the InteractionUse.
    	/// </summary>
    	containment set<Gate> ActualGate subsets Element.OwnedElement;
    	/// <summary>
    	/// The actual arguments of the Interaction.
    	/// </summary>
    	containment list<ValueSpecification> Argument subsets Element.OwnedElement;
    	/// <summary>
    	/// Refers to the Interaction that defines its meaning.
    	/// </summary>
    	Interaction RefersTo;
    	/// <summary>
    	/// The value of the executed Interaction.
    	/// </summary>
    	containment ValueSpecification ReturnValue subsets Element.OwnedElement;
    	/// <summary>
    	/// The recipient of the return value.
    	/// </summary>
    	Property ReturnValueRecipient;
    }

    /// <summary>
    /// A Lifeline represents an individual participant in the Interaction. While parts and structural features may have multiplicity greater than 1, Lifelines represent only one interacting entity.
    /// </summary>
    class Lifeline : NamedElement
    {
    	/// <summary>
    	/// References the InteractionFragments in which this Lifeline takes part.
    	/// </summary>
    	set<InteractionFragment> CoveredBy;
    	/// <summary>
    	/// References the Interaction that represents the decomposition.
    	/// </summary>
    	PartDecomposition DecomposedAs;
    	/// <summary>
    	/// References the Interaction enclosing this Lifeline.
    	/// </summary>
    	Interaction Interaction subsets NamedElement.Namespace;
    	/// <summary>
    	/// References the ConnectableElement within the classifier that contains the enclosing interaction.
    	/// </summary>
    	ConnectableElement Represents;
    	/// <summary>
    	/// If the referenced ConnectableElement is multivalued, then this specifies the specific individual part within that set.
    	/// </summary>
    	containment ValueSpecification Selector subsets Element.OwnedElement;
    }

    /// <summary>
    /// A Message defines a particular communication between Lifelines of an Interaction.
    /// </summary>
    class Message : NamedElement
    {
    	/// <summary>
    	/// The arguments of the Message.
    	/// </summary>
    	containment list<ValueSpecification> Argument subsets Element.OwnedElement;
    	/// <summary>
    	/// The Connector on which this Message is sent.
    	/// </summary>
    	Connector Connector;
    	/// <summary>
    	/// The enclosing Interaction owning the Message.
    	/// </summary>
    	Interaction Interaction subsets NamedElement.Namespace;
    	/// <summary>
    	/// The kind of the Message (complete, lost, found, or unknown).
    	/// </summary>
    	// spec:
    	//     result = (messageKind)
    	MessageKind MessageKind;
    	/// <summary>
    	/// The sort of communication reflected by the Message.
    	/// </summary>
    	MessageSort MessageSort = "MessageSort.SynchCall";
    	/// <summary>
    	/// References the Receiving of the Message.
    	/// </summary>
    	MessageEnd ReceiveEvent;
    	/// <summary>
    	/// References the Sending of the Message.
    	/// </summary>
    	MessageEnd SendEvent;
    	/// <summary>
    	/// The signature of the Message is the specification of its content. It refers either an Operation or a Signal.
    	/// </summary>
    	NamedElement Signature;
    	/// <summary>
    	/// The query isDistinguishableFrom() specifies that any two Messages may coexist in the same Namespace, regardless of their names.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool IsDistinguishableFrom(NamedElement n, Namespace ns);
    }

    /// <summary>
    /// MessageEnd is an abstract specialization of NamedElement that represents what can occur at the end of a Message.
    /// </summary>
    abstract class MessageEnd : NamedElement
    {
    	/// <summary>
    	/// References a Message.
    	/// </summary>
    	Message Message;
    	/// <summary>
    	/// This query returns a set including the MessageEnd (if exists) at the opposite end of the Message for this MessageEnd.
    	/// </summary>
    	// spec:
    	//     result = (message->asSet().messageEnd->asSet()->excluding(self))
    	// pre:
    	//     message->notEmpty()
    	readonly set<MessageEnd> OppositeEnd();
    	/// <summary>
    	/// This query returns value true if this MessageEnd is a sendEvent.
    	/// </summary>
    	// pre:
    	//     message->notEmpty()
    	// spec:
    	//     result = (message.sendEvent->asSet()->includes(self))
    	readonly bool IsSend();
    	/// <summary>
    	/// This query returns value true if this MessageEnd is a receiveEvent.
    	/// </summary>
    	/// <para>
    	/// &lt;p&gt;message-&amp;gt;notEmpty()&lt;/p&gt;
    	/// </para>
    	// pre:
    	//     message->notEmpty()
    	// spec:
    	//     result = (message.receiveEvent->asSet()->includes(self))
    	readonly bool IsReceive();
    	/// <summary>
    	/// This query returns a set including the enclosing InteractionFragment this MessageEnd is enclosed within.
    	/// </summary>
    	// spec:
    	//     result = (if self->select(oclIsKindOf(Gate))->notEmpty() 
    	//     then -- it is a Gate
    	//     let endGate : Gate = 
    	//       self->select(oclIsKindOf(Gate)).oclAsType(Gate)->asOrderedSet()->first()
    	//       in
    	//       if endGate.isOutsideCF() 
    	//       then endGate.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	//          union(endGate.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet())
    	//       else if endGate.isInsideCF() 
    	//         then endGate.combinedFragment.oclAsType(InteractionFragment)->asSet()
    	//         else if endGate.isFormal() 
    	//           then endGate.interaction.oclAsType(InteractionFragment)->asSet()
    	//           else if endGate.isActual() 
    	//             then endGate.interactionUse.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	//          union(endGate.interactionUse.enclosingOperand.oclAsType(InteractionFragment)->asSet())
    	//             else null
    	//             endif
    	//           endif
    	//         endif
    	//       endif
    	//     else -- it is a MessageOccurrenceSpecification
    	//     let endMOS : MessageOccurrenceSpecification  = 
    	//       self->select(oclIsKindOf(MessageOccurrenceSpecification)).oclAsType(MessageOccurrenceSpecification)->asOrderedSet()->first() 
    	//       in
    	//       if endMOS.enclosingInteraction->notEmpty() 
    	//       then endMOS.enclosingInteraction.oclAsType(InteractionFragment)->asSet()
    	//       else endMOS.enclosingOperand.oclAsType(InteractionFragment)->asSet()
    	//       endif
    	//     endif)
    	readonly set<InteractionFragment> EnclosingFragment();
    }

    /// <summary>
    /// A MessageOccurrenceSpecification specifies the occurrence of Message events, such as sending and receiving of Signals or invoking or receiving of Operation calls. A MessageOccurrenceSpecification is a kind of MessageEnd. Messages are generated either by synchronous Operation calls or asynchronous Signal sends. They are received by the execution of corresponding AcceptEventActions.
    /// </summary>
    class MessageOccurrenceSpecification : MessageEnd, OccurrenceSpecification
    {
    }

    /// <summary>
    /// An OccurrenceSpecification is the basic semantic unit of Interactions. The sequences of occurrences specified by them are the meanings of Interactions.
    /// </summary>
    class OccurrenceSpecification : InteractionFragment
    {
    	/// <summary>
    	/// References the Lifeline on which the OccurrenceSpecification appears.
    	/// </summary>
    	Lifeline Covered redefines InteractionFragment.Covered;
    	/// <summary>
    	/// References the GeneralOrderings that specify EventOcurrences that must occur after this OccurrenceSpecification.
    	/// </summary>
    	set<GeneralOrdering> ToAfter;
    	/// <summary>
    	/// References the GeneralOrderings that specify EventOcurrences that must occur before this OccurrenceSpecification.
    	/// </summary>
    	set<GeneralOrdering> ToBefore;
    }

    /// <summary>
    /// A PartDecomposition is a description of the internal Interactions of one Lifeline relative to an Interaction.
    /// </summary>
    class PartDecomposition : InteractionUse
    {
    }

    /// <summary>
    /// A StateInvariant is a runtime constraint on the participants of the Interaction. It may be used to specify a variety of different kinds of Constraints, such as values of Attributes or Variables, internal or external States, and so on. A StateInvariant is an InteractionFragment and it is placed on a Lifeline.
    /// </summary>
    class StateInvariant : InteractionFragment
    {
    	/// <summary>
    	/// References the Lifeline on which the StateInvariant appears.
    	/// </summary>
    	Lifeline Covered redefines InteractionFragment.Covered;
    	/// <summary>
    	/// A Constraint that should hold at runtime for this StateInvariant.
    	/// </summary>
    	containment Constraint Invariant subsets Element.OwnedElement;
    }

    /// <summary>
    /// InformationFlows describe circulation of information through a system in a general manner. They do not specify the nature of the information, mechanisms by which it is conveyed, sequences of exchange or any control conditions. During more detailed modeling, representation and realization links may be added to specify which model elements implement an InformationFlow and to show how information is conveyed.  InformationFlows require some kind of “information channel” for unidirectional transmission of information items from sources to targets.  They specify the information channel’s realizations, if any, and identify the information that flows along them.  Information moving along the information channel may be represented by abstract InformationItems and by concrete Classifiers.
    /// </summary>
    class InformationFlow : DirectedRelationship, PackageableElement
    {
    	/// <summary>
    	/// Specifies the information items that may circulate on this information flow.
    	/// </summary>
    	set<Classifier> Conveyed;
    	/// <summary>
    	/// Defines from which source the conveyed InformationItems are initiated.
    	/// </summary>
    	set<NamedElement> InformationSource subsets DirectedRelationship.Source;
    	/// <summary>
    	/// Defines to which target the conveyed InformationItems are directed.
    	/// </summary>
    	set<NamedElement> InformationTarget subsets DirectedRelationship.Target;
    	/// <summary>
    	/// Determines which Relationship will realize the specified flow.
    	/// </summary>
    	set<Relationship> Realization;
    	/// <summary>
    	/// Determines which ActivityEdges will realize the specified flow.
    	/// </summary>
    	set<ActivityEdge> RealizingActivityEdge;
    	/// <summary>
    	/// Determines which Connectors will realize the specified flow.
    	/// </summary>
    	set<Connector> RealizingConnector;
    	/// <summary>
    	/// Determines which Messages will realize the specified flow.
    	/// </summary>
    	set<Message> RealizingMessage;
    }

    /// <summary>
    /// InformationItems represent many kinds of information that can flow from sources to targets in very abstract ways.  They represent the kinds of information that may move within a system, but do not elaborate details of the transferred information.  Details of transferred information are the province of other Classifiers that may ultimately define InformationItems.  Consequently, InformationItems cannot be instantiated and do not themselves have features, generalizations, or associations. An important use of InformationItems is to represent information during early design stages, possibly before the detailed modeling decisions that will ultimately define them have been made. Another purpose of InformationItems is to abstract portions of complex models in less precise, but perhaps more general and communicable, ways. 
    /// </summary>
    class InformationItem : Classifier
    {
    	/// <summary>
    	/// Determines the classifiers that will specify the structure and nature of the information. An information item represents all its represented classifiers.
    	/// </summary>
    	set<Classifier> Represented;
    }

    /// <summary>
    /// An artifact is the specification of a physical piece of information that is used or produced by a software development process, or by deployment and operation of a system. Examples of artifacts include model files, source files, scripts, and binary executable files, a table in a database system, a development deliverable, or a word-processing document, a mail message.
    /// An artifact is the source of a deployment to a node.
    /// </summary>
    class Artifact : Classifier, DeployedArtifact
    {
    	/// <summary>
    	/// A concrete name that is used to refer to the Artifact in a physical context. Example: file system name, universal resource locator.
    	/// </summary>
    	string FileName;
    	/// <summary>
    	/// The set of model elements that are manifested in the Artifact. That is, these model elements are utilized in the construction (or generation) of the artifact.
    	/// </summary>
    	containment set<Manifestation> Manifestation subsets Element.OwnedElement, NamedElement.ClientDependency;
    	/// <summary>
    	/// The Artifacts that are defined (nested) within the Artifact. The association is a specialization of the ownedMember association from Namespace to NamedElement.
    	/// </summary>
    	containment set<Artifact> NestedArtifact subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The attributes or association ends defined for the Artifact. The association is a specialization of the ownedMember association.
    	/// </summary>
    	containment list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    	/// <summary>
    	/// The Operations defined for the Artifact. The association is a specialization of the ownedMember association.
    	/// </summary>
    	containment list<Operation> OwnedOperation subsets Classifier.Feature, Namespace.OwnedMember;
    }

    /// <summary>
    /// A communication path is an association between two deployment targets, through which they are able to exchange signals and messages.
    /// </summary>
    class CommunicationPath : Association
    {
    }

    /// <summary>
    /// A deployed artifact is an artifact or artifact instance that has been deployed to a deployment target.
    /// </summary>
    abstract class DeployedArtifact : NamedElement
    {
    }

    /// <summary>
    /// A deployment is the allocation of an artifact or artifact instance to a deployment target.
    /// A component deployment is the deployment of one or more artifacts or artifact instances to a deployment target, optionally parameterized by a deployment specification. Examples are executables and configuration files.
    /// </summary>
    class Deployment : Dependency
    {
    	/// <summary>
    	/// The specification of properties that parameterize the deployment and execution of one or more Artifacts.
    	/// </summary>
    	containment set<DeploymentSpecification> Configuration subsets Element.OwnedElement;
    	/// <summary>
    	/// The Artifacts that are deployed onto a Node. This association specializes the supplier association.
    	/// </summary>
    	set<DeployedArtifact> DeployedArtifact subsets Dependency.Supplier;
    	/// <summary>
    	/// The DeployedTarget which is the target of a Deployment.
    	/// </summary>
    	DeploymentTarget Location subsets Dependency.Client, Element.Owner;
    }

    /// <summary>
    /// A deployment specification specifies a set of properties that determine execution parameters of a component artifact that is deployed on a node. A deployment specification can be aimed at a specific type of container. An artifact that reifies or implements deployment specification properties is a deployment descriptor.
    /// </summary>
    class DeploymentSpecification : Artifact
    {
    	/// <summary>
    	/// The deployment with which the DeploymentSpecification is associated.
    	/// </summary>
    	Deployment Deployment subsets Element.Owner;
    	/// <summary>
    	/// The location where an Artifact is deployed onto a Node. This is typically a &apos;directory&apos; or &apos;memory address.&apos;
    	/// </summary>
    	string DeploymentLocation;
    	/// <summary>
    	/// The location where a component Artifact executes. This may be a local or remote location.
    	/// </summary>
    	string ExecutionLocation;
    }

    /// <summary>
    /// A deployment target is the location for a deployed artifact.
    /// </summary>
    abstract class DeploymentTarget : NamedElement
    {
    	/// <summary>
    	/// The set of elements that are manifested in an Artifact that is involved in Deployment to a DeploymentTarget.
    	/// </summary>
    	// spec:
    	//     result = (deployment.deployedArtifact->select(oclIsKindOf(Artifact))->collect(oclAsType(Artifact).manifestation)->collect(utilizedElement)->asSet())
    	derived set<PackageableElement> DeployedElement;
    	/// <summary>
    	/// The set of Deployments for a DeploymentTarget.
    	/// </summary>
    	containment set<Deployment> Deployment subsets Element.OwnedElement, NamedElement.ClientDependency;
    }

    /// <summary>
    /// A device is a physical computational resource with processing capability upon which artifacts may be deployed for execution. Devices may be complex (i.e., they may consist of other devices).
    /// </summary>
    class Device : Node
    {
    }

    /// <summary>
    /// An execution environment is a node that offers an execution environment for specific types of components that are deployed on it in the form of executable artifacts.
    /// </summary>
    class ExecutionEnvironment : Node
    {
    }

    /// <summary>
    /// A manifestation is the concrete physical rendering of one or more model elements by an artifact.
    /// </summary>
    class Manifestation : Abstraction
    {
    	/// <summary>
    	/// The model element that is utilized in the manifestation in an Artifact.
    	/// </summary>
    	PackageableElement UtilizedElement subsets Dependency.Supplier;
    }

    /// <summary>
    /// A Node is computational resource upon which artifacts may be deployed for execution. Nodes can be interconnected through communication paths to define network structures.
    /// </summary>
    class Node : Class, DeploymentTarget
    {
    	/// <summary>
    	/// The Nodes that are defined (nested) within the Node.
    	/// </summary>
    	containment set<Node> NestedNode subsets Namespace.OwnedMember;
    }

    /// <summary>
    /// An Abstraction is a Relationship that relates two Elements or sets of Elements that represent the same concept at different levels of abstraction or from different viewpoints.
    /// </summary>
    class Abstraction : Dependency
    {
    	/// <summary>
    	/// An OpaqueExpression that states the abstraction relationship between the supplier(s) and the client(s). In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, it is usually informal and bidirectional. The mapping expression is optional and may be omitted if the precise relationship between the Elements is not specified.
    	/// </summary>
    	containment OpaqueExpression Mapping subsets Element.OwnedElement;
    }

    /// <summary>
    /// A Comment is a textual annotation that can be attached to a set of Elements.
    /// </summary>
    class Comment : Element
    {
    	/// <summary>
    	/// References the Element(s) being commented.
    	/// </summary>
    	set<Element> AnnotatedElement;
    	/// <summary>
    	/// Specifies a string that is the comment.
    	/// </summary>
    	string Body;
    }

    /// <summary>
    /// A Constraint is a condition or restriction expressed in natural language text or in a machine readable language for the purpose of declaring some of the semantics of an Element or set of Elements.
    /// </summary>
    class Constraint : PackageableElement
    {
    	/// <summary>
    	/// The ordered set of Elements referenced by this Constraint.
    	/// </summary>
    	list<Element> ConstrainedElement;
    	/// <summary>
    	/// Specifies the Namespace that owns the Constraint.
    	/// </summary>
    	Namespace Context subsets NamedElement.Namespace;
    	/// <summary>
    	/// A condition that must be true when evaluated in order for the Constraint to be satisfied.
    	/// </summary>
    	containment ValueSpecification Specification subsets Element.OwnedElement;
    }

    /// <summary>
    /// A Dependency is a Relationship that signifies that a single model Element or a set of model Elements requires other model Elements for their specification or implementation. This means that the complete semantics of the client Element(s) are either semantically or structurally dependent on the definition of the supplier Element(s).
    /// </summary>
    class Dependency : DirectedRelationship, PackageableElement
    {
    	/// <summary>
    	/// The Element(s) dependent on the supplier Element(s). In some cases (such as a trace Abstraction) the assignment of direction (that is, the designation of the client Element) is at the discretion of the modeler and is a stipulation.
    	/// </summary>
    	set<NamedElement> Client subsets DirectedRelationship.Source;
    	/// <summary>
    	/// The Element(s) on which the client Element(s) depend in some respect. The modeler may stipulate a sense of Dependency direction suitable for their domain.
    	/// </summary>
    	set<NamedElement> Supplier subsets DirectedRelationship.Target;
    }

    /// <summary>
    /// A DirectedRelationship represents a relationship between a collection of source model Elements and a collection of target model Elements.
    /// </summary>
    abstract class DirectedRelationship : Relationship
    {
    	/// <summary>
    	/// Specifies the source Element(s) of the DirectedRelationship.
    	/// </summary>
    	union set<Element> Source subsets Relationship.RelatedElement;
    	/// <summary>
    	/// Specifies the target Element(s) of the DirectedRelationship.
    	/// </summary>
    	union set<Element> Target subsets Relationship.RelatedElement;
    }

    /// <summary>
    /// An Element is a constituent of a model. As such, it has the capability of owning other Elements.
    /// </summary>
    abstract class Element
    {
    	/// <summary>
    	/// The Comments owned by this Element.
    	/// </summary>
    	containment set<Comment> OwnedComment subsets Element.OwnedElement;
    	/// <summary>
    	/// The Elements owned by this Element.
    	/// </summary>
    	containment union set<Element> OwnedElement;
    	/// <summary>
    	/// The Element that owns this Element.
    	/// </summary>
    	Element Owner;
    	/// <summary>
    	/// The query allOwnedElements() gives all of the direct and indirect ownedElements of an Element.
    	/// </summary>
    	// spec:
    	//     result = (ownedElement->union(ownedElement->collect(e | e.allOwnedElements()))->asSet())
    	readonly set<Element> AllOwnedElements();
    	/// <summary>
    	/// The query mustBeOwned() indicates whether Elements of this type must have an owner. Subclasses of Element that do not require an owner must override this operation.
    	/// </summary>
    	// spec:
    	//     result = (true)
    	readonly bool MustBeOwned();
    }

    /// <summary>
    /// An ElementImport identifies a NamedElement in a Namespace other than the one that owns that NamedElement and allows the NamedElement to be referenced using an unqualified name in the Namespace owning the ElementImport.
    /// </summary>
    class ElementImport : DirectedRelationship
    {
    	/// <summary>
    	/// Specifies the name that should be added to the importing Namespace in lieu of the name of the imported PackagableElement. The alias must not clash with any other member in the importing Namespace. By default, no alias is used.
    	/// </summary>
    	string Alias;
    	/// <summary>
    	/// Specifies the PackageableElement whose name is to be added to a Namespace.
    	/// </summary>
    	PackageableElement ImportedElement subsets DirectedRelationship.Target;
    	/// <summary>
    	/// Specifies the Namespace that imports a PackageableElement from another Namespace.
    	/// </summary>
    	Namespace ImportingNamespace subsets DirectedRelationship.Source, Element.Owner;
    	/// <summary>
    	/// Specifies the visibility of the imported PackageableElement within the importingNamespace, i.e., whether the  importedElement will in turn be visible to other Namespaces. If the ElementImport is public, the importedElement will be visible outside the importingNamespace while, if the ElementImport is private, it will not.
    	/// </summary>
    	VisibilityKind Visibility = "VisibilityKind.Public";
    	/// <summary>
    	/// The query getName() returns the name under which the imported PackageableElement will be known in the importing namespace.
    	/// </summary>
    	// spec:
    	//     result = (if alias->notEmpty() then
    	//       alias
    	//     else
    	//       importedElement.name
    	//     endif)
    	readonly string GetName();
    }

    /// <summary>
    /// A multiplicity is a definition of an inclusive interval of non-negative integers beginning with a lower bound and ending with a (possibly infinite) upper bound. A MultiplicityElement embeds this information to specify the allowable cardinalities for an instantiation of the Element.
    /// </summary>
    abstract class MultiplicityElement : Element
    {
    	/// <summary>
    	/// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation of this MultiplicityElement are sequentially ordered.
    	/// </summary>
    	bool IsOrdered = "false";
    	/// <summary>
    	/// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation of this MultiplicityElement are unique.
    	/// </summary>
    	bool IsUnique = "true";
    	/// <summary>
    	/// The lower bound of the multiplicity interval.
    	/// </summary>
    	// spec:
    	//     result = (lowerBound())
    	derived int Lower;
    	/// <summary>
    	/// The specification of the lower bound for this multiplicity.
    	/// </summary>
    	containment ValueSpecification LowerValue subsets Element.OwnedElement;
    	/// <summary>
    	/// The upper bound of the multiplicity interval.
    	/// </summary>
    	// spec:
    	//     result = (upperBound())
    	derived long Upper;
    	/// <summary>
    	/// The specification of the upper bound for this multiplicity.
    	/// </summary>
    	containment ValueSpecification UpperValue subsets Element.OwnedElement;
    	/// <summary>
    	/// The operation compatibleWith takes another multiplicity as input. It returns true if the other multiplicity is wider than, or the same as, self.
    	/// </summary>
    	// spec:
    	//     result = ((other.lowerBound() <= self.lowerBound()) and ((other.upperBound() = *) or (self.upperBound() <= other.upperBound())))
    	readonly bool CompatibleWith(MultiplicityElement other);
    	/// <summary>
    	/// The query includesMultiplicity() checks whether this multiplicity includes all the cardinalities allowed by the specified multiplicity.
    	/// </summary>
    	// pre:
    	//     self.upperBound()->notEmpty() and self.lowerBound()->notEmpty() and M.upperBound()->notEmpty() and M.lowerBound()->notEmpty()
    	// spec:
    	//     result = ((self.lowerBound() <= M.lowerBound()) and (self.upperBound() >= M.upperBound()))
    	readonly bool IncludesMultiplicity(MultiplicityElement M);
    	/// <summary>
    	/// The operation is determines if the upper and lower bound of the ranges are the ones given.
    	/// </summary>
    	// spec:
    	//     result = (lowerbound = self.lowerBound() and upperbound = self.upperBound())
    	readonly bool Is(int lowerbound, long upperbound);
    	/// <summary>
    	/// The query isMultivalued() checks whether this multiplicity has an upper bound greater than one.
    	/// </summary>
    	// pre:
    	//     upperBound()->notEmpty()
    	// spec:
    	//     result = (upperBound() > 1)
    	readonly bool IsMultivalued();
    	/// <summary>
    	/// The query lowerBound() returns the lower bound of the multiplicity as an integer, which is the integerValue of lowerValue, if this is given, and 1 otherwise.
    	/// </summary>
    	// spec:
    	//     result = (if (lowerValue=null or lowerValue.integerValue()=null) then 1 else lowerValue.integerValue() endif)
    	readonly int LowerBound();
    	/// <summary>
    	/// The query upperBound() returns the upper bound of the multiplicity for a bounded multiplicity as an unlimited natural, which is the unlimitedNaturalValue of upperValue, if given, and 1, otherwise.
    	/// </summary>
    	// spec:
    	//     result = (if (upperValue=null or upperValue.unlimitedValue()=null) then 1 else upperValue.unlimitedValue() endif)
    	readonly long UpperBound();
    }

    /// <summary>
    /// A NamedElement is an Element in a model that may have a name. The name may be given directly and/or via the use of a StringExpression.
    /// </summary>
    abstract class NamedElement : Element
    {
    	/// <summary>
    	/// Indicates the Dependencies that reference this NamedElement as a client.
    	/// </summary>
    	// spec:
    	//     result = (Dependency.allInstances()->select(d | d.client->includes(self)))
    	derived set<Dependency> ClientDependency;
    	/// <summary>
    	/// The name of the NamedElement.
    	/// </summary>
		[Name]
    	string Name;
    	/// <summary>
    	/// The StringExpression used to define the name of this NamedElement.
    	/// </summary>
    	containment StringExpression NameExpression subsets Element.OwnedElement;
    	/// <summary>
    	/// Specifies the Namespace that owns the NamedElement.
    	/// </summary>
    	Namespace Namespace subsets Element.Owner;
    	/// <summary>
    	/// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is constructed from the names of the containing Namespaces starting at the root of the hierarchy and ending with the name of the NamedElement itself.
    	/// </summary>
    	// spec:
    	//     result = (if self.name <> null and self.allNamespaces()->select( ns | ns.name=null )->isEmpty()
    	//     then 
    	//         self.allNamespaces()->iterate( ns : Namespace; agg: String = self.name | ns.name.concat(self.separator()).concat(agg))
    	//     else
    	//        null
    	//     endif)
    	derived string QualifiedName;
    	/// <summary>
    	/// Determines whether and how the NamedElement is visible outside its owning Namespace.
    	/// </summary>
    	VisibilityKind Visibility;
    	/// <summary>
    	/// The query allNamespaces() gives the sequence of Namespaces in which the NamedElement is nested, working outwards.
    	/// </summary>
    	// spec:
    	//     result = (if owner.oclIsKindOf(TemplateParameter) and
    	//       owner.oclAsType(TemplateParameter).signature.template.oclIsKindOf(Namespace) then
    	//         let enclosingNamespace : Namespace =
    	//           owner.oclAsType(TemplateParameter).signature.template.oclAsType(Namespace) in
    	//             enclosingNamespace.allNamespaces()->prepend(enclosingNamespace)
    	//     else
    	//       if namespace->isEmpty()
    	//         then OrderedSet{}
    	//       else
    	//         namespace.allNamespaces()->prepend(namespace)
    	//       endif
    	//     endif)
    	readonly list<Namespace> AllNamespaces();
    	/// <summary>
    	/// The query allOwningPackages() returns the set of all the enclosing Namespaces of this NamedElement, working outwards, that are Packages, up to but not including the first such Namespace that is not a Package.
    	/// </summary>
    	// spec:
    	//     result = (if namespace.oclIsKindOf(Package)
    	//     then
    	//       let owningPackage : Package = namespace.oclAsType(Package) in
    	//         owningPackage->union(owningPackage.allOwningPackages())
    	//     else
    	//       null
    	//     endif)
    	readonly set<Package> AllOwningPackages();
    	/// <summary>
    	/// The query isDistinguishableFrom() determines whether two NamedElements may logically co-exist within a Namespace. By default, two named elements are distinguishable if (a) they have types neither of which is a kind of the other or (b) they have different names.
    	/// </summary>
    	// spec:
    	//     result = ((self.oclIsKindOf(n.oclType()) or n.oclIsKindOf(self.oclType())) implies
    	//         ns.getNamesOfMember(self)->intersection(ns.getNamesOfMember(n))->isEmpty()
    	//     )
    	readonly bool IsDistinguishableFrom(NamedElement n, Namespace ns);
    	/// <summary>
    	/// The query separator() gives the string that is used to separate names when constructing a qualifiedName.
    	/// </summary>
    	// spec:
    	//     result = ('::')
    	readonly string Separator();
    }

    /// <summary>
    /// A Namespace is an Element in a model that owns and/or imports a set of NamedElements that can be identified by name.
    /// </summary>
	[Scope]
    abstract class Namespace : NamedElement
    {
    	/// <summary>
    	/// References the ElementImports owned by the Namespace.
    	/// </summary>
    	containment set<ElementImport> ElementImport subsets Element.OwnedElement;
    	/// <summary>
    	/// References the PackageableElements that are members of this Namespace as a result of either PackageImports or ElementImports.
    	/// </summary>
    	// spec:
    	//     result = (self.importMembers(elementImport.importedElement->asSet()->union(packageImport.importedPackage->collect(p | p.visibleMembers()))->asSet()))
    	derived set<PackageableElement> ImportedMember subsets Namespace.Member;
    	/// <summary>
    	/// A collection of NamedElements identifiable within the Namespace, either by being owned or by being introduced by importing or inheritance.
    	/// </summary>
    	union set<NamedElement> Member;
    	/// <summary>
    	/// A collection of NamedElements owned by the Namespace.
    	/// </summary>
    	containment union set<NamedElement> OwnedMember subsets Element.OwnedElement, Namespace.Member;
    	/// <summary>
    	/// Specifies a set of Constraints owned by this Namespace.
    	/// </summary>
    	containment set<Constraint> OwnedRule subsets Namespace.OwnedMember;
    	/// <summary>
    	/// References the PackageImports owned by the Namespace.
    	/// </summary>
    	containment set<PackageImport> PackageImport subsets Element.OwnedElement;
    	/// <summary>
    	/// The query excludeCollisions() excludes from a set of PackageableElements any that would not be distinguishable from each other in this Namespace.
    	/// </summary>
    	// spec:
    	//     result = (imps->reject(imp1  | imps->exists(imp2 | not imp1.isDistinguishableFrom(imp2, self))))
    	readonly set<PackageableElement> ExcludeCollisions(set<PackageableElement> imps);
    	/// <summary>
    	/// The query getNamesOfMember() gives a set of all of the names that a member would have in a Namespace, taking importing into account. In general a member can have multiple names in a Namespace if it is imported more than once with different aliases.
    	/// </summary>
    	// spec:
    	//     result = (if self.ownedMember ->includes(element)
    	//     then Set{element.name}
    	//     else let elementImports : Set(ElementImport) = self.elementImport->select(ei | ei.importedElement = element) in
    	//       if elementImports->notEmpty()
    	//       then
    	//          elementImports->collect(el | el.getName())->asSet()
    	//       else 
    	//          self.packageImport->select(pi | pi.importedPackage.visibleMembers().oclAsType(NamedElement)->includes(element))-> collect(pi | pi.importedPackage.getNamesOfMember(element))->asSet()
    	//       endif
    	//     endif)
    	readonly set<string> GetNamesOfMember(NamedElement element);
    	/// <summary>
    	/// The query importMembers() defines which of a set of PackageableElements are actually imported into the Namespace. This excludes hidden ones, i.e., those which have names that conflict with names of ownedMembers, and it also excludes PackageableElements that would have the indistinguishable names when imported.
    	/// </summary>
    	// spec:
    	//     result = (self.excludeCollisions(imps)->select(imp | self.ownedMember->forAll(mem | imp.isDistinguishableFrom(mem, self))))
    	readonly set<PackageableElement> ImportMembers(set<PackageableElement> imps);
    	/// <summary>
    	/// The Boolean query membersAreDistinguishable() determines whether all of the Namespace&apos;s members are distinguishable within it.
    	/// </summary>
    	// spec:
    	//     result = (member->forAll( memb |
    	//        member->excluding(memb)->forAll(other |
    	//            memb.isDistinguishableFrom(other, self))))
    	readonly bool MembersAreDistinguishable();
    }

    /// <summary>
    /// A PackageableElement is a NamedElement that may be owned directly by a Package. A PackageableElement is also able to serve as the parameteredElement of a TemplateParameter.
    /// </summary>
    abstract class PackageableElement : ParameterableElement, NamedElement
    {
    	/// <summary>
    	/// A PackageableElement must have a visibility specified if it is owned by a Namespace. The default visibility is public.
    	/// </summary>
    	VisibilityKind Visibility = "VisibilityKind.Public" redefines NamedElement.Visibility;
    }

    /// <summary>
    /// A PackageImport is a Relationship that imports all the non-private members of a Package into the Namespace owning the PackageImport, so that those Elements may be referred to by their unqualified names in the importingNamespace.
    /// </summary>
    class PackageImport : DirectedRelationship
    {
    	/// <summary>
    	/// Specifies the Package whose members are imported into a Namespace.
    	/// </summary>
    	Package ImportedPackage subsets DirectedRelationship.Target;
    	/// <summary>
    	/// Specifies the Namespace that imports the members from a Package.
    	/// </summary>
    	Namespace ImportingNamespace subsets DirectedRelationship.Source, Element.Owner;
    	/// <summary>
    	/// Specifies the visibility of the imported PackageableElements within the importingNamespace, i.e., whether imported Elements will in turn be visible to other Namespaces. If the PackageImport is public, the imported Elements will be visible outside the importingNamespace, while, if the PackageImport is private, they will not.
    	/// </summary>
    	VisibilityKind Visibility = "VisibilityKind.Public";
    }

    /// <summary>
    /// A ParameterableElement is an Element that can be exposed as a formal TemplateParameter for a template, or specified as an actual parameter in a binding of a template.
    /// </summary>
    abstract class ParameterableElement : Element
    {
    	/// <summary>
    	/// The formal TemplateParameter that owns this ParameterableElement.
    	/// </summary>
    	TemplateParameter OwningTemplateParameter subsets Element.Owner, ParameterableElement.TemplateParameter;
    	/// <summary>
    	/// The TemplateParameter that exposes this ParameterableElement as a formal parameter.
    	/// </summary>
    	TemplateParameter TemplateParameter;
    	/// <summary>
    	/// The query isCompatibleWith() determines if this ParameterableElement is compatible with the specified ParameterableElement. By default, this ParameterableElement is compatible with another ParameterableElement p if the kind of this ParameterableElement is the same as or a subtype of the kind of p. Subclasses of ParameterableElement should override this operation to specify different compatibility constraints.
    	/// </summary>
    	// spec:
    	//     result = (self.oclIsKindOf(p.oclType()))
    	readonly bool IsCompatibleWith(ParameterableElement p);
    	/// <summary>
    	/// The query isTemplateParameter() determines if this ParameterableElement is exposed as a formal TemplateParameter.
    	/// </summary>
    	// spec:
    	//     result = (templateParameter->notEmpty())
    	readonly bool IsTemplateParameter();
    }

    /// <summary>
    /// Realization is a specialized Abstraction relationship between two sets of model Elements, one representing a specification (the supplier) and the other represents an implementation of the latter (the client). Realization can be used to model stepwise refinement, optimizations, transformations, templates, model synthesis, framework composition, etc.
    /// </summary>
    class Realization : Abstraction
    {
    }

    /// <summary>
    /// Relationship is an abstract concept that specifies some kind of relationship between Elements.
    /// </summary>
    abstract class Relationship : Element
    {
    	/// <summary>
    	/// Specifies the elements related by the Relationship.
    	/// </summary>
    	union set<Element> RelatedElement;
    }

    /// <summary>
    /// A TemplateableElement is an Element that can optionally be defined as a template and bound to other templates.
    /// </summary>
    abstract class TemplateableElement : Element
    {
    	/// <summary>
    	/// The optional TemplateSignature specifying the formal TemplateParameters for this TemplateableElement. If a TemplateableElement has a TemplateSignature, then it is a template.
    	/// </summary>
    	containment TemplateSignature OwnedTemplateSignature subsets Element.OwnedElement;
    	/// <summary>
    	/// The optional TemplateBindings from this TemplateableElement to one or more templates.
    	/// </summary>
    	containment set<TemplateBinding> TemplateBinding subsets Element.OwnedElement;
    	/// <summary>
    	/// The query isTemplate() returns whether this TemplateableElement is actually a template.
    	/// </summary>
    	// spec:
    	//     result = (ownedTemplateSignature <> null)
    	readonly bool IsTemplate();
    	/// <summary>
    	/// The query parameterableElements() returns the set of ParameterableElements that may be used as the parameteredElements for a TemplateParameter of this TemplateableElement. By default, this set includes all the ownedElements. Subclasses may override this operation if they choose to restrict the set of ParameterableElements.
    	/// </summary>
    	// spec:
    	//     result = (self.allOwnedElements()->select(oclIsKindOf(ParameterableElement)).oclAsType(ParameterableElement)->asSet())
    	readonly set<ParameterableElement> ParameterableElements();
    }

    /// <summary>
    /// A TemplateBinding is a DirectedRelationship between a TemplateableElement and a template. A TemplateBinding specifies the TemplateParameterSubstitutions of actual parameters for the formal parameters of the template.
    /// </summary>
    class TemplateBinding : DirectedRelationship
    {
    	/// <summary>
    	/// The TemplateableElement that is bound by this TemplateBinding.
    	/// </summary>
    	TemplateableElement BoundElement subsets DirectedRelationship.Source, Element.Owner;
    	/// <summary>
    	/// The TemplateParameterSubstitutions owned by this TemplateBinding.
    	/// </summary>
    	containment set<TemplateParameterSubstitution> ParameterSubstitution subsets Element.OwnedElement;
    	/// <summary>
    	/// The TemplateSignature for the template that is the target of this TemplateBinding.
    	/// </summary>
    	TemplateSignature Signature subsets DirectedRelationship.Target;
    }

    /// <summary>
    /// A TemplateParameter exposes a ParameterableElement as a formal parameter of a template.
    /// </summary>
    class TemplateParameter : Element
    {
    	/// <summary>
    	/// The ParameterableElement that is the default for this formal TemplateParameter.
    	/// </summary>
    	ParameterableElement Default;
    	/// <summary>
    	/// The ParameterableElement that is owned by this TemplateParameter for the purpose of providing a default.
    	/// </summary>
    	containment ParameterableElement OwnedDefault subsets Element.OwnedElement, TemplateParameter.Default;
    	/// <summary>
    	/// The ParameterableElement that is owned by this TemplateParameter for the purpose of exposing it as the parameteredElement.
    	/// </summary>
    	containment ParameterableElement OwnedParameteredElement subsets Element.OwnedElement, TemplateParameter.ParameteredElement;
    	/// <summary>
    	/// The ParameterableElement exposed by this TemplateParameter.
    	/// </summary>
    	ParameterableElement ParameteredElement;
    	/// <summary>
    	/// The TemplateSignature that owns this TemplateParameter.
    	/// </summary>
    	TemplateSignature Signature subsets Element.Owner;
    }

    /// <summary>
    /// A TemplateParameterSubstitution relates the actual parameter to a formal TemplateParameter as part of a template binding.
    /// </summary>
    class TemplateParameterSubstitution : Element
    {
    	/// <summary>
    	/// The ParameterableElement that is the actual parameter for this TemplateParameterSubstitution.
    	/// </summary>
    	ParameterableElement Actual;
    	/// <summary>
    	/// The formal TemplateParameter that is associated with this TemplateParameterSubstitution.
    	/// </summary>
    	TemplateParameter Formal;
    	/// <summary>
    	/// The ParameterableElement that is owned by this TemplateParameterSubstitution as its actual parameter.
    	/// </summary>
    	containment ParameterableElement OwnedActual subsets Element.OwnedElement, TemplateParameterSubstitution.Actual;
    	/// <summary>
    	/// The TemplateBinding that owns this TemplateParameterSubstitution.
    	/// </summary>
    	TemplateBinding TemplateBinding subsets Element.Owner;
    }

    /// <summary>
    /// A Template Signature bundles the set of formal TemplateParameters for a template.
    /// </summary>
    class TemplateSignature : Element
    {
    	/// <summary>
    	/// The formal parameters that are owned by this TemplateSignature.
    	/// </summary>
    	containment list<TemplateParameter> OwnedParameter subsets Element.OwnedElement, TemplateSignature.Parameter;
    	/// <summary>
    	/// The ordered set of all formal TemplateParameters for this TemplateSignature.
    	/// </summary>
    	list<TemplateParameter> Parameter;
    	/// <summary>
    	/// The TemplateableElement that owns this TemplateSignature.
    	/// </summary>
    	TemplateableElement Template subsets Element.Owner;
    }

    /// <summary>
    /// A Type constrains the values represented by a TypedElement.
    /// </summary>
	[Type]
    abstract class Type : PackageableElement
    {
    	/// <summary>
    	/// Specifies the owning Package of this Type, if any.
    	/// </summary>
    	Package Package;
    	/// <summary>
    	/// The query conformsTo() gives true for a Type that conforms to another. By default, two Types do not conform to each other. This query is intended to be redefined for specific conformance situations.
    	/// </summary>
    	// spec:
    	//     result = (false)
    	readonly bool ConformsTo(Type other);
    }

    /// <summary>
    /// A TypedElement is a NamedElement that may have a Type specified for it.
    /// </summary>
    abstract class TypedElement : NamedElement
    {
    	/// <summary>
    	/// The type of the TypedElement.
    	/// </summary>
		[Type]
    	Type Type;
    }

    /// <summary>
    /// A Usage is a Dependency in which the client Element requires the supplier Element (or set of Elements) for its full implementation or operation.
    /// </summary>
    class Usage : Dependency
    {
    }

    /// <summary>
    /// A trigger for an AnyReceiveEvent is triggered by the receipt of any message that is not explicitly handled by any related trigger.
    /// </summary>
    class AnyReceiveEvent : MessageEvent
    {
    }

    /// <summary>
    /// Behavior is a specification of how its context BehavioredClassifier changes state over time. This specification may be either a definition of possible behavior execution or emergent behavior, or a selective illustration of an interesting subset of possible executions. The latter form is typically used for capturing examples, such as a trace of a particular execution.
    /// </summary>
    abstract class Behavior : Class
    {
    	/// <summary>
    	/// The BehavioredClassifier that is the context for the execution of the Behavior. A Behavior that is directly owned as a nestedClassifier does not have a context. Otherwise, to determine the context of a Behavior, find the first BehavioredClassifier reached by following the chain of owner relationships from the Behavior, if any. If there is such a BehavioredClassifier, then it is the context, unless it is itself a Behavior with a non-empty context, in which case that is also the context for the original Behavior. For example, following this algorithm, the context of an entry Behavior in a StateMachine is the BehavioredClassifier that owns the StateMachine. The features of the context BehavioredClassifier as well as the Elements visible to the context Classifier are visible to the Behavior.
    	/// </summary>
    	// spec:
    	//     result = (if nestingClass <> null then
    	//         null
    	//     else
    	//         let b:BehavioredClassifier = self.behavioredClassifier(self.owner) in
    	//         if b.oclIsKindOf(Behavior) and b.oclAsType(Behavior)._'context' <> null then 
    	//             b.oclAsType(Behavior)._'context'
    	//         else 
    	//             b 
    	//         endif
    	//     endif
    	//             )
    	derived BehavioredClassifier Context subsets RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// Tells whether the Behavior can be invoked while it is still executing from a previous invocation.
    	/// </summary>
    	bool IsReentrant = "true";
    	/// <summary>
    	/// References a list of Parameters to the Behavior which describes the order and type of arguments that can be given when the Behavior is invoked and of the values which will be returned when the Behavior completes its execution.
    	/// </summary>
    	containment list<Parameter> OwnedParameter subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The ParameterSets owned by this Behavior.
    	/// </summary>
    	containment set<ParameterSet> OwnedParameterSet subsets Namespace.OwnedMember;
    	/// <summary>
    	/// An optional set of Constraints specifying what is fulfilled after the execution of the Behavior is completed, if its precondition was fulfilled before its invocation.
    	/// </summary>
    	containment set<Constraint> Postcondition subsets Namespace.OwnedRule;
    	/// <summary>
    	/// An optional set of Constraints specifying what must be fulfilled before the Behavior is invoked.
    	/// </summary>
    	containment set<Constraint> Precondition subsets Namespace.OwnedRule;
    	/// <summary>
    	/// Designates a BehavioralFeature that the Behavior implements. The BehavioralFeature must be owned by the BehavioredClassifier that owns the Behavior or be inherited by it. The Parameters of the BehavioralFeature and the implementing Behavior must match. A Behavior does not need to have a specification, in which case it either is the classifierBehavior of a BehavioredClassifier or it can only be invoked by another Behavior of the Classifier.
    	/// </summary>
    	BehavioralFeature Specification;
    	/// <summary>
    	/// References the Behavior that this Behavior redefines. A subtype of Behavior may redefine any other subtype of Behavior. If the Behavior implements a BehavioralFeature, it replaces the redefined Behavior. If the Behavior is a classifierBehavior, it extends the redefined Behavior.
    	/// </summary>
    	set<Behavior> RedefinedBehavior subsets Classifier.RedefinedClassifier;
    	/// <summary>
    	/// The first BehavioredClassifier reached by following the chain of owner relationships from the Behavior, if any.
    	/// </summary>
    	// spec:
    	//     if from.oclIsKindOf(BehavioredClassifier) then
    	//         from.oclAsType(BehavioredClassifier)
    	//     else if from.owner = null then
    	//         null
    	//     else
    	//         self.behavioredClassifier(from.owner)
    	//     endif
    	//     endif
    	//         
    	readonly BehavioredClassifier BehavioredClassifier(Element from);
    	/// <summary>
    	/// The in and inout ownedParameters of the Behavior.
    	/// </summary>
    	// spec:
    	//     result = (ownedParameter->select(direction=ParameterDirectionKind::_'in' or direction=ParameterDirectionKind::inout))
    	readonly list<Parameter> InputParameters();
    	/// <summary>
    	/// The out, inout and return ownedParameters.
    	/// </summary>
    	// spec:
    	//     result = (ownedParameter->select(direction=ParameterDirectionKind::out or direction=ParameterDirectionKind::inout or direction=ParameterDirectionKind::return))
    	readonly list<Parameter> OutputParameters();
    }

    /// <summary>
    /// A CallEvent models the receipt by an object of a message invoking a call of an Operation.
    /// </summary>
    class CallEvent : MessageEvent
    {
    	/// <summary>
    	/// Designates the Operation whose invocation raised the CalEvent.
    	/// </summary>
    	Operation Operation;
    }

    /// <summary>
    /// A ChangeEvent models a change in the system configuration that makes a condition true.
    /// </summary>
    class ChangeEvent : Event
    {
    	/// <summary>
    	/// A Boolean-valued ValueSpecification that will result in a ChangeEvent whenever its value changes from false to true.
    	/// </summary>
    	containment ValueSpecification ChangeExpression subsets Element.OwnedElement;
    }

    /// <summary>
    /// An Event is the specification of some occurrence that may potentially trigger effects by an object.
    /// </summary>
    abstract class Event : PackageableElement
    {
    }

    /// <summary>
    /// A FunctionBehavior is an OpaqueBehavior that does not access or modify any objects or other external data.
    /// </summary>
    class FunctionBehavior : OpaqueBehavior
    {
    	/// <summary>
    	/// The hasAllDataTypeAttributes query tests whether the types of the attributes of the given DataType are all DataTypes, and similarly for all those DataTypes.
    	/// </summary>
    	// spec:
    	//     result = (d.ownedAttribute->forAll(a |
    	//         a.type.oclIsKindOf(DataType) and
    	//           hasAllDataTypeAttributes(a.type.oclAsType(DataType))))
    	readonly bool HasAllDataTypeAttributes(DataType d);
    }

    /// <summary>
    /// A MessageEvent specifies the receipt by an object of either an Operation call or a Signal instance.
    /// </summary>
    abstract class MessageEvent : Event
    {
    }

    /// <summary>
    /// An OpaqueBehavior is a Behavior whose specification is given in a textual language other than UML.
    /// </summary>
    class OpaqueBehavior : Behavior
    {
    	/// <summary>
    	/// Specifies the behavior in one or more languages.
    	/// </summary>
    	multi_list<string> Body;
    	/// <summary>
    	/// Languages the body strings use in the same order as the body strings.
    	/// </summary>
    	list<string> Language;
    }

    /// <summary>
    /// A SignalEvent represents the receipt of an asynchronous Signal instance.
    /// </summary>
    class SignalEvent : MessageEvent
    {
    	/// <summary>
    	/// The specific Signal that is associated with this SignalEvent.
    	/// </summary>
    	Signal Signal;
    }

    /// <summary>
    /// A TimeEvent is an Event that occurs at a specific point in time.
    /// </summary>
    class TimeEvent : Event
    {
    	/// <summary>
    	/// Specifies whether the TimeEvent is specified as an absolute or relative time.
    	/// </summary>
    	bool IsRelative = "false";
    	/// <summary>
    	/// Specifies the time of the TimeEvent.
    	/// </summary>
    	containment TimeExpression When subsets Element.OwnedElement;
    }

    /// <summary>
    /// A Trigger specifies a specific point  at which an Event occurrence may trigger an effect in a Behavior. A Trigger may be qualified by the Port on which the Event occurred.
    /// </summary>
    class Trigger : NamedElement
    {
    	/// <summary>
    	/// The Event that detected by the Trigger.
    	/// </summary>
    	Event Event;
    	/// <summary>
    	/// A optional Port of through which the given effect is detected.
    	/// </summary>
    	set<Port> Port;
    }

    /// <summary>
    /// A substitution is a relationship between two classifiers signifying that the substituting classifier complies with the contract specified by the contract classifier. This implies that instances of the substituting classifier are runtime substitutable where instances of the contract classifier are expected.
    /// </summary>
    class Substitution : Realization
    {
    	/// <summary>
    	/// The contract with which the substituting classifier complies.
    	/// </summary>
    	Classifier Contract subsets Dependency.Supplier;
    	/// <summary>
    	/// Instances of the substituting classifier are runtime substitutable where instances of the contract classifier are expected.
    	/// </summary>
    	Classifier SubstitutingClassifier subsets Dependency.Client, Element.Owner;
    }

    /// <summary>
    /// A BehavioralFeature is a feature of a Classifier that specifies an aspect of the behavior of its instances.  A BehavioralFeature is implemented (realized) by a Behavior. A BehavioralFeature specifies that a Classifier will respond to a designated request by invoking its implementing method.
    /// </summary>
    abstract class BehavioralFeature : Feature, Namespace
    {
    	/// <summary>
    	/// Specifies the semantics of concurrent calls to the same passive instance (i.e., an instance originating from a Class with isActive being false). Active instances control access to their own BehavioralFeatures.
    	/// </summary>
    	CallConcurrencyKind Concurrency = "CallConcurrencyKind.Sequential";
    	/// <summary>
    	/// If true, then the BehavioralFeature does not have an implementation, and one must be supplied by a more specific Classifier. If false, the BehavioralFeature must have an implementation in the Classifier or one must be inherited.
    	/// </summary>
    	bool IsAbstract = "false";
    	/// <summary>
    	/// A Behavior that implements the BehavioralFeature. There may be at most one Behavior for a particular pairing of a Classifier (as owner of the Behavior) and a BehavioralFeature (as specification of the Behavior).
    	/// </summary>
    	set<Behavior> Method;
    	/// <summary>
    	/// The ordered set of formal Parameters of this BehavioralFeature.
    	/// </summary>
    	containment list<Parameter> OwnedParameter subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The ParameterSets owned by this BehavioralFeature.
    	/// </summary>
    	containment set<ParameterSet> OwnedParameterSet subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The Types representing exceptions that may be raised during an invocation of this BehavioralFeature.
    	/// </summary>
    	set<Type> RaisedException;
    	/// <summary>
    	/// The query isDistinguishableFrom() determines whether two BehavioralFeatures may coexist in the same Namespace. It specifies that they must have different signatures.
    	/// </summary>
    	// spec:
    	//     result = ((n.oclIsKindOf(BehavioralFeature) and ns.getNamesOfMember(self)->intersection(ns.getNamesOfMember(n))->notEmpty()) implies
    	//       Set{self}->including(n.oclAsType(BehavioralFeature))->isUnique(ownedParameter->collect(p|
    	//       Tuple { name=p.name, type=p.type,effect=p.effect,direction=p.direction,isException=p.isException,
    	//                   isStream=p.isStream,isOrdered=p.isOrdered,isUnique=p.isUnique,lower=p.lower, upper=p.upper }))
    	//       )
    	readonly bool IsDistinguishableFrom(NamedElement n, Namespace ns);
    	/// <summary>
    	/// The ownedParameters with direction in and inout.
    	/// </summary>
    	// spec:
    	//     result = (ownedParameter->select(direction=ParameterDirectionKind::_'in' or direction=ParameterDirectionKind::inout))
    	readonly list<Parameter> InputParameters();
    	/// <summary>
    	/// The ownedParameters with direction out, inout, or return.
    	/// </summary>
    	// spec:
    	//     result = (ownedParameter->select(direction=ParameterDirectionKind::out or direction=ParameterDirectionKind::inout or direction=ParameterDirectionKind::return))
    	readonly list<Parameter> OutputParameters();
    }

    /// <summary>
    /// A Classifier represents a classification of instances according to their Features.
    /// </summary>
    abstract class Classifier : Namespace, Type, TemplateableElement, RedefinableElement
    {
	    /// <summary>
    	/// The Class owning the Classifier.
    	/// </summary>
		Class NestingClass subsets NamedElement.Namespace;
    	/// <summary>
    	/// All of the Properties that are direct (i.e., not inherited or imported) attributes of the Classifier.
    	/// </summary>
    	union list<Property> Attribute subsets Classifier.Feature;
    	/// <summary>
    	/// The CollaborationUses owned by the Classifier.
    	/// </summary>
    	containment set<CollaborationUse> CollaborationUse subsets Element.OwnedElement;
    	/// <summary>
    	/// Specifies each Feature directly defined in the classifier. Note that there may be members of the Classifier that are of the type Feature but are not included, e.g., inherited features.
    	/// </summary>
    	union set<Feature> Feature subsets Namespace.Member;
    	/// <summary>
    	/// The generalizing Classifiers for this Classifier.
    	/// </summary>
    	// spec:
    	//     result = (parents())
    	derived set<Classifier> General;
    	/// <summary>
    	/// The Generalization relationships for this Classifier. These Generalizations navigate to more general Classifiers in the generalization hierarchy.
    	/// </summary>
    	containment set<Generalization> Generalization subsets Element.OwnedElement;
    	/// <summary>
    	/// All elements inherited by this Classifier from its general Classifiers.
    	/// </summary>
    	// spec:
    	//     result = (inherit(parents()->collect(inheritableMembers(self))->asSet()))
    	derived set<NamedElement> InheritedMember subsets Namespace.Member;
    	/// <summary>
    	/// If true, the Classifier can only be instantiated by instantiating one of its specializations. An abstract Classifier is intended to be used by other Classifiers e.g., as the target of Associations or Generalizations.
    	/// </summary>
    	bool IsAbstract = "false";
    	/// <summary>
    	/// If true, the Classifier cannot be specialized.
    	/// </summary>
    	bool IsFinalSpecialization = "false";
    	/// <summary>
    	/// The optional RedefinableTemplateSignature specifying the formal template parameters.
    	/// </summary>
    	containment RedefinableTemplateSignature OwnedTemplateSignature redefines TemplateableElement.OwnedTemplateSignature;
    	/// <summary>
    	/// The UseCases owned by this classifier.
    	/// </summary>
    	containment set<UseCase> OwnedUseCase subsets Namespace.OwnedMember;
    	/// <summary>
    	/// The GeneralizationSet of which this Classifier is a power type.
    	/// </summary>
    	set<GeneralizationSet> PowertypeExtent;
    	/// <summary>
    	/// The Classifiers redefined by this Classifier.
    	/// </summary>
    	set<Classifier> RedefinedClassifier subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// A CollaborationUse which indicates the Collaboration that represents this Classifier.
    	/// </summary>
    	CollaborationUse Representation subsets Classifier.CollaborationUse;
    	/// <summary>
    	/// The Substitutions owned by this Classifier.
    	/// </summary>
    	containment set<Substitution> Substitution subsets Element.OwnedElement, NamedElement.ClientDependency;
    	/// <summary>
    	/// TheClassifierTemplateParameter that exposes this element as a formal parameter.
    	/// </summary>
    	ClassifierTemplateParameter TemplateParameter redefines ParameterableElement.TemplateParameter;
    	/// <summary>
    	/// The set of UseCases for which this Classifier is the subject.
    	/// </summary>
    	set<UseCase> UseCase;
    	/// <summary>
    	/// The query allFeatures() gives all of the Features in the namespace of the Classifier. In general, through mechanisms such as inheritance, this will be a larger set than feature.
    	/// </summary>
    	// spec:
    	//     result = (member->select(oclIsKindOf(Feature))->collect(oclAsType(Feature))->asSet())
    	readonly set<Feature> AllFeatures();
    	/// <summary>
    	/// The query allParents() gives all of the direct and indirect ancestors of a generalized Classifier.
    	/// </summary>
    	// spec:
    	//     result = (parents()->union(parents()->collect(allParents())->asSet()))
    	readonly set<Classifier> AllParents();
    	/// <summary>
    	/// The query conformsTo() gives true for a Classifier that defines a type that conforms to another. This is used, for example, in the specification of signature conformance for operations.
    	/// </summary>
    	// spec:
    	//     result = (if other.oclIsKindOf(Classifier) then
    	//       let otherClassifier : Classifier = other.oclAsType(Classifier) in
    	//         self = otherClassifier or allParents()->includes(otherClassifier)
    	//     else
    	//       false
    	//     endif)
    	readonly bool ConformsTo(Type other);
    	/// <summary>
    	/// The query hasVisibilityOf() determines whether a NamedElement is visible in the classifier. Non-private members are visible. It is only called when the argument is something owned by a parent.
    	/// </summary>
    	// pre:
    	//     allParents()->including(self)->collect(member)->includes(n)
    	// spec:
    	//     result = (n.visibility <> VisibilityKind::private)
    	readonly bool HasVisibilityOf(NamedElement n);
    	/// <summary>
    	/// The query inherit() defines how to inherit a set of elements passed as its argument.  It excludes redefined elements from the result.
    	/// </summary>
    	// spec:
    	//     result = (inhs->reject(inh |
    	//       inh.oclIsKindOf(RedefinableElement) and
    	//       ownedMember->select(oclIsKindOf(RedefinableElement))->
    	//         select(redefinedElement->includes(inh.oclAsType(RedefinableElement)))
    	//            ->notEmpty()))
    	readonly set<NamedElement> Inherit(set<NamedElement> inhs);
    	/// <summary>
    	/// The query inheritableMembers() gives all of the members of a Classifier that may be inherited in one of its descendants, subject to whatever visibility restrictions apply.
    	/// </summary>
    	// pre:
    	//     c.allParents()->includes(self)
    	// spec:
    	//     result = (member->select(m | c.hasVisibilityOf(m)))
    	readonly set<NamedElement> InheritableMembers(Classifier c);
    	/// <summary>
    	/// The query isTemplate() returns whether this Classifier is actually a template.
    	/// </summary>
    	// spec:
    	//     result = (ownedTemplateSignature <> null or general->exists(g | g.isTemplate()))
    	readonly bool IsTemplate();
    	/// <summary>
    	/// The query maySpecializeType() determines whether this classifier may have a generalization relationship to classifiers of the specified type. By default a classifier may specialize classifiers of the same or a more general type. It is intended to be redefined by classifiers that have different specialization constraints.
    	/// </summary>
    	// spec:
    	//     result = (self.oclIsKindOf(c.oclType()))
    	readonly bool MaySpecializeType(Classifier c);
    	/// <summary>
    	/// The query parents() gives all of the immediate ancestors of a generalized Classifier.
    	/// </summary>
    	// spec:
    	//     result = (generalization.general->asSet())
    	readonly set<Classifier> Parents();
    	/// <summary>
    	/// The Interfaces directly realized by this Classifier
    	/// </summary>
    	// spec:
    	//     result = ((clientDependency->
    	//       select(oclIsKindOf(Realization) and supplier->forAll(oclIsKindOf(Interface))))->
    	//           collect(supplier.oclAsType(Interface))->asSet())
    	readonly set<Interface> DirectlyRealizedInterfaces();
    	/// <summary>
    	/// The Interfaces directly used by this Classifier
    	/// </summary>
    	// spec:
    	//     result = ((supplierDependency->
    	//       select(oclIsKindOf(Usage) and client->forAll(oclIsKindOf(Interface))))->
    	//         collect(client.oclAsType(Interface))->asSet())
    	readonly set<Interface> DirectlyUsedInterfaces();
    	/// <summary>
    	/// The Interfaces realized by this Classifier and all of its generalizations
    	/// </summary>
    	// spec:
    	//     result = (directlyRealizedInterfaces()->union(self.allParents()->collect(directlyRealizedInterfaces()))->asSet())
    	readonly set<Interface> AllRealizedInterfaces();
    	/// <summary>
    	/// The Interfaces used by this Classifier and all of its generalizations
    	/// </summary>
    	// spec:
    	//     result = (directlyUsedInterfaces()->union(self.allParents()->collect(directlyUsedInterfaces()))->asSet())
    	readonly set<Interface> AllUsedInterfaces();
    	// spec:
    	//     result = (substitution.contract->includes(contract))
    	readonly bool IsSubstitutableFor(Classifier contract);
    	/// <summary>
    	/// The query allAttributes gives an ordered set of all owned and inherited attributes of the Classifier. All owned attributes appear before any inherited attributes, and the attributes inherited from any more specific parent Classifier appear before those of any more general parent Classifier. However, if the Classifier has multiple immediate parents, then the relative ordering of the sets of attributes from those parents is not defined.
    	/// </summary>
    	// spec:
    	//     result = (attribute->asSequence()->union(parents()->asSequence().allAttributes())->select(p | member->includes(p))->asOrderedSet())
    	readonly list<Property> AllAttributes();
    	/// <summary>
    	/// All StructuralFeatures related to the Classifier that may have Slots, including direct attributes, inherited attributes, private attributes in generalizations, and memberEnds of Associations, but excluding redefined StructuralFeatures.
    	/// </summary>
    	// spec:
    	//     result = (member->select(oclIsKindOf(StructuralFeature))->
    	//       collect(oclAsType(StructuralFeature))->
    	//        union(self.inherit(self.allParents()->collect(p | p.attribute)->asSet())->
    	//          collect(oclAsType(StructuralFeature)))->asSet())
    	readonly set<StructuralFeature> AllSlottableFeatures();
    }

    /// <summary>
    /// A ClassifierTemplateParameter exposes a Classifier as a formal template parameter.
    /// </summary>
    class ClassifierTemplateParameter : TemplateParameter
    {
    	/// <summary>
    	/// Constrains the required relationship between an actual parameter and the parameteredElement for this formal parameter.
    	/// </summary>
    	bool AllowSubstitutable = "true";
    	/// <summary>
    	/// The classifiers that constrain the argument that can be used for the parameter. If the allowSubstitutable attribute is true, then any Classifier that is compatible with this constraining Classifier can be substituted; otherwise, it must be either this Classifier or one of its specializations. If this property is empty, there are no constraints on the Classifier that can be used as an argument.
    	/// </summary>
    	set<Classifier> ConstrainingClassifier;
    	/// <summary>
    	/// The Classifier exposed by this ClassifierTemplateParameter.
    	/// </summary>
    	Classifier ParameteredElement redefines TemplateParameter.ParameteredElement;
    }

    /// <summary>
    /// A Feature declares a behavioral or structural characteristic of Classifiers.
    /// </summary>
    abstract class Feature : RedefinableElement
    {
    	/// <summary>
    	/// The Classifiers that have this Feature as a feature.
    	/// </summary>
    	Classifier FeaturingClassifier;
    	/// <summary>
    	/// Specifies whether this Feature characterizes individual instances classified by the Classifier (false) or the Classifier itself (true).
    	/// </summary>
    	bool IsStatic = "false";
    }

    /// <summary>
    /// A Generalization is a taxonomic relationship between a more general Classifier and a more specific Classifier. Each instance of the specific Classifier is also an instance of the general Classifier. The specific Classifier inherits the features of the more general Classifier. A Generalization is owned by the specific Classifier.
    /// </summary>
    class Generalization : DirectedRelationship
    {
    	/// <summary>
    	/// The general classifier in the Generalization relationship.
    	/// </summary>
    	Classifier General subsets DirectedRelationship.Target;
    	/// <summary>
    	/// Represents a set of instances of Generalization.  A Generalization may appear in many GeneralizationSets.
    	/// </summary>
    	set<GeneralizationSet> GeneralizationSet;
    	/// <summary>
    	/// Indicates whether the specific Classifier can be used wherever the general Classifier can be used. If true, the execution traces of the specific Classifier shall be a superset of the execution traces of the general Classifier. If false, there is no such constraint on execution traces. If unset, the modeler has not stated whether there is such a constraint or not.
    	/// </summary>
    	bool IsSubstitutable = "true";
    	/// <summary>
    	/// The specializing Classifier in the Generalization relationship.
    	/// </summary>
    	Classifier Specific subsets DirectedRelationship.Source, Element.Owner;
    }

    /// <summary>
    /// A GeneralizationSet is a PackageableElement whose instances represent sets of Generalization relationships.
    /// </summary>
    class GeneralizationSet : PackageableElement
    {
    	/// <summary>
    	/// Designates the instances of Generalization that are members of this GeneralizationSet.
    	/// </summary>
    	set<Generalization> Generalization;
    	/// <summary>
    	/// Indicates (via the associated Generalizations) whether or not the set of specific Classifiers are covering for a particular general classifier. When isCovering is true, every instance of a particular general Classifier is also an instance of at least one of its specific Classifiers for the GeneralizationSet. When isCovering is false, there are one or more instances of the particular general Classifier that are not instances of at least one of its specific Classifiers defined for the GeneralizationSet.
    	/// </summary>
    	bool IsCovering = "false";
    	/// <summary>
    	/// Indicates whether or not the set of specific Classifiers in a Generalization relationship have instance in common. If isDisjoint is true, the specific Classifiers for a particular GeneralizationSet have no members in common; that is, their intersection is empty. If isDisjoint is false, the specific Classifiers in a particular GeneralizationSet have one or more members in common; that is, their intersection is not empty.
    	/// </summary>
    	bool IsDisjoint = "false";
    	/// <summary>
    	/// Designates the Classifier that is defined as the power type for the associated GeneralizationSet, if there is one.
    	/// </summary>
    	Classifier Powertype;
    }

    /// <summary>
    /// An InstanceSpecification is a model element that represents an instance in a modeled system. An InstanceSpecification can act as a DeploymentTarget in a Deployment relationship, in the case that it represents an instance of a Node. It can also act as a DeployedArtifact, if it represents an instance of an Artifact.
    /// </summary>
    class InstanceSpecification : DeploymentTarget, PackageableElement, DeployedArtifact
    {
    	/// <summary>
    	/// The Classifier or Classifiers of the represented instance. If multiple Classifiers are specified, the instance is classified by all of them.
    	/// </summary>
    	set<Classifier> Classifier;
    	/// <summary>
    	/// A Slot giving the value or values of a StructuralFeature of the instance. An InstanceSpecification can have one Slot per StructuralFeature of its Classifiers, including inherited features. It is not necessary to model a Slot for every StructuralFeature, in which case the InstanceSpecification is a partial description.
    	/// </summary>
    	containment set<Slot> Slot subsets Element.OwnedElement;
    	/// <summary>
    	/// A specification of how to compute, derive, or construct the instance.
    	/// </summary>
    	containment ValueSpecification Specification subsets Element.OwnedElement;
    }

    /// <summary>
    /// An InstanceValue is a ValueSpecification that identifies an instance.
    /// </summary>
    class InstanceValue : ValueSpecification
    {
    	/// <summary>
    	/// The InstanceSpecification that represents the specified value.
    	/// </summary>
    	InstanceSpecification Instance;
    }

    /// <summary>
    /// An Operation is a BehavioralFeature of a Classifier that specifies the name, type, parameters, and constraints for invoking an associated Behavior. An Operation may invoke both the execution of method behaviors as well as other behavioral responses. Operation specializes TemplateableElement in order to support specification of template operations and bound operations. Operation specializes ParameterableElement to specify that an operation can be exposed as a formal template parameter, and provided as an actual parameter in a binding of a template.
    /// </summary>
    class Operation : TemplateableElement, ParameterableElement, BehavioralFeature
    {
    	/// <summary>
    	/// An optional Constraint on the result values of an invocation of this Operation.
    	/// </summary>
    	containment Constraint BodyCondition subsets Namespace.OwnedRule;
    	/// <summary>
    	/// The Class that owns this operation, if any.
    	/// </summary>
    	Class Class subsets Feature.FeaturingClassifier, NamedElement.Namespace, RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// The DataType that owns this Operation, if any.
    	/// </summary>
    	DataType Datatype subsets Feature.FeaturingClassifier, NamedElement.Namespace, RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// The Interface that owns this Operation, if any.
    	/// </summary>
    	Interface Interface subsets Feature.FeaturingClassifier, NamedElement.Namespace, RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// Specifies whether the return parameter is ordered or not, if present.  This information is derived from the return result for this Operation.
    	/// </summary>
    	// spec:
    	//     result = (if returnResult()->notEmpty() then returnResult()-> exists(isOrdered) else false endif)
    	derived bool IsOrdered;
    	/// <summary>
    	/// Specifies whether an execution of the BehavioralFeature leaves the state of the system unchanged (isQuery=true) or whether side effects may occur (isQuery=false).
    	/// </summary>
    	bool IsQuery = "false";
    	/// <summary>
    	/// Specifies whether the return parameter is unique or not, if present. This information is derived from the return result for this Operation.
    	/// </summary>
    	// spec:
    	//     result = (if returnResult()->notEmpty() then returnResult()->exists(isUnique) else true endif)
    	derived bool IsUnique;
    	/// <summary>
    	/// Specifies the lower multiplicity of the return parameter, if present. This information is derived from the return result for this Operation.
    	/// </summary>
    	// spec:
    	//     result = (if returnResult()->notEmpty() then returnResult()->any(true).lower else null endif)
    	derived int Lower;
    	/// <summary>
    	/// The parameters owned by this Operation.
    	/// </summary>
    	containment list<Parameter> OwnedParameter redefines BehavioralFeature.OwnedParameter;
    	/// <summary>
    	/// An optional set of Constraints specifying the state of the system when the Operation is completed.
    	/// </summary>
    	containment set<Constraint> Postcondition subsets Namespace.OwnedRule;
    	/// <summary>
    	/// An optional set of Constraints on the state of the system when the Operation is invoked.
    	/// </summary>
    	containment set<Constraint> Precondition subsets Namespace.OwnedRule;
    	/// <summary>
    	/// The Types representing exceptions that may be raised during an invocation of this operation.
    	/// </summary>
    	set<Type> RaisedException redefines BehavioralFeature.RaisedException;
    	/// <summary>
    	/// The Operations that are redefined by this Operation.
    	/// </summary>
    	set<Operation> RedefinedOperation subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// The OperationTemplateParameter that exposes this element as a formal parameter.
    	/// </summary>
    	OperationTemplateParameter TemplateParameter redefines ParameterableElement.TemplateParameter;
    	/// <summary>
    	/// The return type of the operation, if present. This information is derived from the return result for this Operation.
    	/// </summary>
    	// spec:
    	//     result = (if returnResult()->notEmpty() then returnResult()->any(true).type else null endif)
    	derived Type Type;
    	/// <summary>
    	/// The upper multiplicity of the return parameter, if present. This information is derived from the return result for this Operation.
    	/// </summary>
    	// spec:
    	//     result = (if returnResult()->notEmpty() then returnResult()->any(true).upper else null endif)
    	derived long Upper;
    	/// <summary>
    	/// The query isConsistentWith() specifies, for any two Operations in a context in which redefinition is possible, whether redefinition would be consistent. A redefining operation is consistent with a redefined operation if
    	/// it has the same number of owned parameters, and for each parameter the following holds:
    	/// - Direction, ordering and uniqueness are the same.
    	/// - The corresponding types are covariant, contravariant or invariant.
    	/// - The multiplicities are compatible, depending on the parameter direction.
    	/// </summary>
    	// spec:
    	//     result = (redefiningElement.oclIsKindOf(Operation) and
    	//     let op : Operation = redefiningElement.oclAsType(Operation) in
    	//     	self.ownedParameter->size() = op.ownedParameter->size() and
    	//     	Sequence{1..self.ownedParameter->size()}->
    	//     		forAll(i |  
    	//     		  let redefiningParam : Parameter = op.ownedParameter->at(i),
    	//                    redefinedParam : Parameter = self.ownedParameter->at(i) in
    	//                      (redefiningParam.isUnique = redefinedParam.isUnique) and
    	//                      (redefiningParam.isOrdered = redefinedParam. isOrdered) and
    	//                      (redefiningParam.direction = redefinedParam.direction) and
    	//                      (redefiningParam.type.conformsTo(redefinedParam.type) or
    	//                          redefinedParam.type.conformsTo(redefiningParam.type)) and
    	//                      (redefiningParam.direction = ParameterDirectionKind::inout implies
    	//                              (redefinedParam.compatibleWith(redefiningParam) and
    	//                              redefiningParam.compatibleWith(redefinedParam))) and
    	//                      (redefiningParam.direction = ParameterDirectionKind::_'in' implies
    	//                              redefinedParam.compatibleWith(redefiningParam)) and
    	//                      ((redefiningParam.direction = ParameterDirectionKind::out or
    	//                           redefiningParam.direction = ParameterDirectionKind::return) implies
    	//                              redefiningParam.compatibleWith(redefinedParam))
    	//     		))
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    	/// <summary>
    	/// The query returnResult() returns the set containing the return parameter of the Operation if one exists, otherwise, it returns an empty set
    	/// </summary>
    	// spec:
    	//     result = (ownedParameter->select (direction = ParameterDirectionKind::return))
    	readonly set<Parameter> ReturnResult();
    }

    /// <summary>
    /// An OperationTemplateParameter exposes an Operation as a formal parameter for a template.
    /// </summary>
    class OperationTemplateParameter : TemplateParameter
    {
    	/// <summary>
    	/// The Operation exposed by this OperationTemplateParameter.
    	/// </summary>
    	Operation ParameteredElement redefines TemplateParameter.ParameteredElement;
    }

    /// <summary>
    /// A Parameter is a specification of an argument used to pass information into or out of an invocation of a BehavioralFeature.  Parameters can be treated as ConnectableElements within Collaborations.
    /// </summary>
    class Parameter : MultiplicityElement, ConnectableElement
    {
    	/// <summary>
    	/// A String that represents a value to be used when no argument is supplied for the Parameter.
    	/// </summary>
    	// spec:
    	//     result = (if self.type = String then defaultValue.stringValue() else null endif)
    	derived string Default;
    	/// <summary>
    	/// Specifies a ValueSpecification that represents a value to be used when no argument is supplied for the Parameter.
    	/// </summary>
    	containment ValueSpecification DefaultValue subsets Element.OwnedElement;
    	/// <summary>
    	/// Indicates whether a parameter is being sent into or out of a behavioral element.
    	/// </summary>
    	ParameterDirectionKind Direction = "ParameterDirectionKind.In";
    	/// <summary>
    	/// Specifies the effect that executions of the owner of the Parameter have on objects passed in or out of the parameter.
    	/// </summary>
    	ParameterEffectKind Effect;
    	/// <summary>
    	/// Tells whether an output parameter may emit a value to the exclusion of the other outputs.
    	/// </summary>
    	bool IsException = "false";
    	/// <summary>
    	/// Tells whether an input parameter may accept values while its behavior is executing, or whether an output parameter may post values while the behavior is executing.
    	/// </summary>
    	bool IsStream = "false";
    	/// <summary>
    	/// The Operation owning this parameter.
    	/// </summary>
    	Operation Operation;
    	/// <summary>
    	/// The ParameterSets containing the parameter. See ParameterSet.
    	/// </summary>
    	set<ParameterSet> ParameterSet;
    }

    /// <summary>
    /// A ParameterSet designates alternative sets of inputs or outputs that a Behavior may use.
    /// </summary>
    class ParameterSet : NamedElement
    {
    	/// <summary>
    	/// A constraint that should be satisfied for the owner of the Parameters in an input ParameterSet to start execution using the values provided for those Parameters, or the owner of the Parameters in an output ParameterSet to end execution providing the values for those Parameters, if all preconditions and conditions on input ParameterSets were satisfied.
    	/// </summary>
    	containment set<Constraint> Condition subsets Element.OwnedElement;
    	/// <summary>
    	/// Parameters in the ParameterSet.
    	/// </summary>
    	set<Parameter> Parameter;
    }

    /// <summary>
    /// A Property is a StructuralFeature. A Property related by ownedAttribute to a Classifier (other than an association) represents an attribute and might also represent an association end. It relates an instance of the Classifier to a value or set of values of the type of the attribute. A Property related by memberEnd to an Association represents an end of the Association. The type of the Property is the type of the end of the Association. A Property has the capability of being a DeploymentTarget in a Deployment relationship. This enables modeling the deployment to hierarchical nodes that have Properties functioning as internal parts.  Property specializes ParameterableElement to specify that a Property can be exposed as a formal template parameter, and provided as an actual parameter in a binding of a template.
    /// </summary>
    class Property : ConnectableElement, DeploymentTarget, StructuralFeature
    {
    	/// <summary>
    	/// Specifies the kind of aggregation that applies to the Property.
    	/// </summary>
    	AggregationKind Aggregation = "AggregationKind.None";
    	/// <summary>
    	/// The Association of which this Property is a member, if any.
    	/// </summary>
    	Association Association;
    	/// <summary>
    	/// Designates the optional association end that owns a qualifier attribute.
    	/// </summary>
    	Property AssociationEnd subsets Element.Owner;
    	/// <summary>
    	/// The Class that owns this Property, if any.
    	/// </summary>
    	Class Class subsets NamedElement.Namespace;
    	/// <summary>
    	/// The DataType that owns this Property, if any.
    	/// </summary>
    	DataType Datatype subsets NamedElement.Namespace;
    	/// <summary>
    	/// A ValueSpecification that is evaluated to give a default value for the Property when an instance of the owning Classifier is instantiated.
    	/// </summary>
    	containment ValueSpecification DefaultValue subsets Element.OwnedElement;
    	/// <summary>
    	/// The Interface that owns this Property, if any.
    	/// </summary>
    	Interface Interface subsets NamedElement.Namespace;
    	/// <summary>
    	/// If isComposite is true, the object containing the attribute is a container for the object or value contained in the attribute. This is a derived value, indicating whether the aggregation of the Property is composite or not.
    	/// </summary>
    	// spec:
    	//     result = (aggregation = AggregationKind::composite)
    	derived bool IsComposite;
    	/// <summary>
    	/// Specifies whether the Property is derived, i.e., whether its value or values can be computed from other information.
    	/// </summary>
    	bool IsDerived = "false";
    	/// <summary>
    	/// Specifies whether the property is derived as the union of all of the Properties that are constrained to subset it.
    	/// </summary>
    	bool IsDerivedUnion = "false";
    	/// <summary>
    	/// True indicates this property can be used to uniquely identify an instance of the containing Class.
    	/// </summary>
    	bool IsID = "false";
    	/// <summary>
    	/// In the case where the Property is one end of a binary association this gives the other end.
    	/// </summary>
    	// spec:
    	//     result = (if association <> null and association.memberEnd->size() = 2
    	//     then
    	//         association.memberEnd->any(e | e <> self)
    	//     else
    	//         null
    	//     endif)
    	derived Property Opposite;
    	/// <summary>
    	/// The owning association of this property, if any.
    	/// </summary>
    	Association OwningAssociation subsets Feature.FeaturingClassifier, NamedElement.Namespace, Property.Association, RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// An optional list of ordered qualifier attributes for the end.
    	/// </summary>
    	containment list<Property> Qualifier subsets Element.OwnedElement;
    	/// <summary>
    	/// The properties that are redefined by this property, if any.
    	/// </summary>
    	set<Property> RedefinedProperty subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// The properties of which this Property is constrained to be a subset, if any.
    	/// </summary>
    	set<Property> SubsettedProperty;
    	/// <summary>
    	/// The query isAttribute() is true if the Property is defined as an attribute of some Classifier.
    	/// </summary>
    	// spec:
    	//     result = (not classifier->isEmpty())
    	readonly bool IsAttribute();
    	/// <summary>
    	/// The query isCompatibleWith() determines if this Property is compatible with the specified ParameterableElement. This Property is compatible with ParameterableElement p if the kind of this Property is thesame as or a subtype of the kind of p. Further, if p is a TypedElement, then the type of this Property must be conformant with the type of p.
    	/// </summary>
    	// spec:
    	//     result = (self.oclIsKindOf(p.oclType()) and (p.oclIsKindOf(TypeElement) implies
    	//     self.type.conformsTo(p.oclAsType(TypedElement).type)))
    	readonly bool IsCompatibleWith(ParameterableElement p);
    	/// <summary>
    	/// The query isConsistentWith() specifies, for any two Properties in a context in which redefinition is possible, whether redefinition would be logically consistent. A redefining Property is consistent with a redefined Property if the type of the redefining Property conforms to the type of the redefined Property, and the multiplicity of the redefining Property (if specified) is contained in the multiplicity of the redefined Property.
    	/// </summary>
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	// spec:
    	//     result = (redefiningElement.oclIsKindOf(Property) and 
    	//       let prop : Property = redefiningElement.oclAsType(Property) in 
    	//       (prop.type.conformsTo(self.type) and 
    	//       ((prop.lowerBound()->notEmpty() and self.lowerBound()->notEmpty()) implies prop.lowerBound() >= self.lowerBound()) and 
    	//       ((prop.upperBound()->notEmpty() and self.upperBound()->notEmpty()) implies prop.lowerBound() <= self.lowerBound()) and 
    	//       (self.isComposite implies prop.isComposite)))
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    	/// <summary>
    	/// The query isNavigable() indicates whether it is possible to navigate across the property.
    	/// </summary>
    	// spec:
    	//     result = (not classifier->isEmpty() or association.navigableOwnedEnd->includes(self))
    	readonly bool IsNavigable();
    	/// <summary>
    	/// The query subsettingContext() gives the context for subsetting a Property. It consists, in the case of an attribute, of the corresponding Classifier, and in the case of an association end, all of the Classifiers at the other ends.
    	/// </summary>
    	// spec:
    	//     result = (if association <> null
    	//     then association.memberEnd->excluding(self)->collect(type)->asSet()
    	//     else 
    	//       if classifier<>null
    	//       then classifier->asSet()
    	//       else Set{} 
    	//       endif
    	//     endif)
    	readonly set<Type> SubsettingContext();
    }

    /// <summary>
    /// A RedefinableElement is an element that, when defined in the context of a Classifier, can be redefined more specifically or differently in the context of another Classifier that specializes (directly or indirectly) the context Classifier.
    /// </summary>
    abstract class RedefinableElement : NamedElement
    {
    	/// <summary>
    	/// Indicates whether it is possible to further redefine a RedefinableElement. If the value is true, then it is not possible to further redefine the RedefinableElement.
    	/// </summary>
    	bool IsLeaf = "false";
    	/// <summary>
    	/// The RedefinableElement that is being redefined by this element.
    	/// </summary>
    	union set<RedefinableElement> RedefinedElement;
    	/// <summary>
    	/// The contexts that this element may be redefined from.
    	/// </summary>
    	union set<Classifier> RedefinitionContext;
    	/// <summary>
    	/// The query isConsistentWith() specifies, for any two RedefinableElements in a context in which redefinition is possible, whether redefinition would be logically consistent. By default, this is false; this operation must be overridden for subclasses of RedefinableElement to define the consistency conditions.
    	/// </summary>
    	// spec:
    	//     result = (false)
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    	/// <summary>
    	/// The query isRedefinitionContextValid() specifies whether the redefinition contexts of this RedefinableElement are properly related to the redefinition contexts of the specified RedefinableElement to allow this element to redefine the other. By default at least one of the redefinition contexts of this element must be a specialization of at least one of the redefinition contexts of the specified element.
    	/// </summary>
    	// spec:
    	//     result = (redefinitionContext->exists(c | c.allParents()->includesAll(redefinedElement.redefinitionContext)))
    	readonly bool IsRedefinitionContextValid(RedefinableElement redefinedElement);
    }

    /// <summary>
    /// A RedefinableTemplateSignature supports the addition of formal template parameters in a specialization of a template classifier.
    /// </summary>
    class RedefinableTemplateSignature : RedefinableElement, TemplateSignature
    {
    	/// <summary>
    	/// The Classifier that owns this RedefinableTemplateSignature.
    	/// </summary>
    	Classifier Classifier redefines TemplateSignature.Template subsets RedefinableElement.RedefinitionContext;
    	/// <summary>
    	/// The signatures extended by this RedefinableTemplateSignature.
    	/// </summary>
    	set<RedefinableTemplateSignature> ExtendedSignature subsets RedefinableElement.RedefinedElement;
    	/// <summary>
    	/// The formal template parameters of the extended signatures.
    	/// </summary>
    	// spec:
    	//     result = (if extendedSignature->isEmpty() then Set{} else extendedSignature.parameter->asSet() endif)
    	derived set<TemplateParameter> InheritedParameter subsets TemplateSignature.Parameter;
    	/// <summary>
    	/// The query isConsistentWith() specifies, for any two RedefinableTemplateSignatures in a context in which redefinition is possible, whether redefinition would be logically consistent. A redefining template signature is always consistent with a redefined template signature, as redefinition only adds new formal parameters.
    	/// </summary>
    	// spec:
    	//     result = (redefiningElement.oclIsKindOf(RedefinableTemplateSignature))
    	// pre:
    	//     redefiningElement.isRedefinitionContextValid(self)
    	readonly bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /// <summary>
    /// A Slot designates that an entity modeled by an InstanceSpecification has a value or values for a specific StructuralFeature.
    /// </summary>
    class Slot : Element
    {
    	/// <summary>
    	/// The StructuralFeature that specifies the values that may be held by the Slot.
    	/// </summary>
    	StructuralFeature DefiningFeature;
    	/// <summary>
    	/// The InstanceSpecification that owns this Slot.
    	/// </summary>
    	InstanceSpecification OwningInstance subsets Element.Owner;
    	/// <summary>
    	/// The value or values held by the Slot.
    	/// </summary>
    	containment list<ValueSpecification> Value subsets Element.OwnedElement;
    }

    /// <summary>
    /// A StructuralFeature is a typed feature of a Classifier that specifies the structure of instances of the Classifier.
    /// </summary>
    abstract class StructuralFeature : MultiplicityElement, TypedElement, Feature
    {
    	/// <summary>
    	/// If isReadOnly is true, the StructuralFeature may not be written to after initialization.
    	/// </summary>
    	bool IsReadOnly = "false";
    }

    /// <summary>
    /// A ValueSpecificationAction is an Action that evaluates a ValueSpecification and provides a result.
    /// </summary>
    class ValueSpecificationAction : Action
    {
    	/// <summary>
    	/// The OutputPin on which the result value is placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    	/// <summary>
    	/// The ValueSpecification to be evaluated.
    	/// </summary>
    	containment ValueSpecification Value subsets Element.OwnedElement;
    }

    /// <summary>
    /// VariableAction is an abstract class for Actions that operate on a specified Variable.
    /// </summary>
    abstract class VariableAction : Action
    {
    	/// <summary>
    	/// The Variable to be read or written.
    	/// </summary>
    	Variable Variable;
    }

    /// <summary>
    /// WriteLinkAction is an abstract class for LinkActions that create and destroy links.
    /// </summary>
    abstract class WriteLinkAction : LinkAction
    {
    }

    /// <summary>
    /// WriteStructuralFeatureAction is an abstract class for StructuralFeatureActions that change StructuralFeature values.
    /// </summary>
    abstract class WriteStructuralFeatureAction : StructuralFeatureAction
    {
    	/// <summary>
    	/// The OutputPin on which is put the input object as modified by the WriteStructuralFeatureAction.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    	/// <summary>
    	/// The InputPin that provides the value to be added or removed from the StructuralFeature.
    	/// </summary>
    	containment InputPin Value subsets Action.Input;
    }

    /// <summary>
    /// WriteVariableAction is an abstract class for VariableActions that change Variable values.
    /// </summary>
    abstract class WriteVariableAction : VariableAction
    {
    	/// <summary>
    	/// The InputPin that gives the value to be added or removed from the Variable.
    	/// </summary>
    	containment InputPin Value subsets Action.Input;
    }

    /// <summary>
    /// An AcceptCallAction is an AcceptEventAction that handles the receipt of a synchronous call request. In addition to the values from the Operation input parameters, the Action produces an output that is needed later to supply the information to the ReplyAction necessary to return control to the caller. An AcceptCallAction is for synchronous calls. If it is used to handle an asynchronous call, execution of the subsequent ReplyAction will complete immediately with no effect.
    /// </summary>
    class AcceptCallAction : AcceptEventAction
    {
    	/// <summary>
    	/// An OutputPin where a value is placed containing sufficient information to perform a subsequent ReplyAction and return control to the caller. The contents of this value are opaque. It can be passed and copied but it cannot be manipulated by the model.
    	/// </summary>
    	containment OutputPin ReturnInformation subsets Action.Output;
    }

    /// <summary>
    /// An AcceptEventAction is an Action that waits for the occurrence of one or more specific Events.
    /// </summary>
    class AcceptEventAction : Action
    {
    	/// <summary>
    	/// Indicates whether there is a single OutputPin for a SignalEvent occurrence, or multiple OutputPins for attribute values of the instance of the Signal associated with a SignalEvent occurrence.
    	/// </summary>
    	bool IsUnmarshall = "false";
    	/// <summary>
    	/// OutputPins holding the values received from an Event occurrence.
    	/// </summary>
    	containment list<OutputPin> Result subsets Action.Output;
    	/// <summary>
    	/// The Triggers specifying the Events of which the AcceptEventAction waits for occurrences.
    	/// </summary>
    	containment set<Trigger> Trigger subsets Element.OwnedElement;
    }

    /// <summary>
    /// An Action is the fundamental unit of executable functionality. The execution of an Action represents some transformation or processing in the modeled system. Actions provide the ExecutableNodes within Activities and may also be used within Interactions.
    /// </summary>
    abstract class Action : ExecutableNode
    {
		/// <summary>
    	/// The Interaction that owns the Action.
    	/// </summary>
		Interaction Interaction subsets NamedElement.Namespace;
    	/// <summary>
    	/// The context Classifier of the Behavior that contains this Action, or the Behavior itself if it has no context.
    	/// </summary>
    	// spec:
    	//     result = (let behavior: Behavior = self.containingBehavior() in
    	//     if behavior=null then null
    	//     else if behavior._'context' = null then behavior
    	//     else behavior._'context'
    	//     endif
    	//     endif)
    	derived Classifier Context;
    	/// <summary>
    	/// The ordered set of InputPins representing the inputs to the Action.
    	/// </summary>
    	containment union list<InputPin> Input subsets Element.OwnedElement;
    	/// <summary>
    	/// If true, the Action can begin a new, concurrent execution, even if there is already another execution of the Action ongoing. If false, the Action cannot begin a new execution until any previous execution has completed.
    	/// </summary>
    	bool IsLocallyReentrant = "false";
    	/// <summary>
    	/// A Constraint that must be satisfied when execution of the Action is completed.
    	/// </summary>
    	containment set<Constraint> LocalPostcondition subsets Element.OwnedElement;
    	/// <summary>
    	/// A Constraint that must be satisfied when execution of the Action is started.
    	/// </summary>
    	containment set<Constraint> LocalPrecondition subsets Element.OwnedElement;
    	/// <summary>
    	/// The ordered set of OutputPins representing outputs from the Action.
    	/// </summary>
    	containment union list<OutputPin> Output subsets Element.OwnedElement;
    	/// <summary>
    	/// Return this Action and all Actions contained directly or indirectly in it. By default only the Action itself is returned, but the operation is overridden for StructuredActivityNodes.
    	/// </summary>
    	// spec:
    	//     result = (self->asSet())
    	readonly set<Action> AllActions();
    	/// <summary>
    	/// Returns all the ActivityNodes directly or indirectly owned by this Action. This includes at least all the Pins of the Action.
    	/// </summary>
    	// spec:
    	//     result = (input.oclAsType(Pin)->asSet()->union(output->asSet()))
    	readonly set<ActivityNode> AllOwnedNodes();
    	// spec:
    	//     result = (if inStructuredNode<>null then inStructuredNode.containingBehavior() 
    	//     else if activity<>null then activity
    	//     else interaction 
    	//     endif
    	//     endif
    	//     )
    	readonly Behavior ContainingBehavior();
    }

    /// <summary>
    /// An ActionInputPin is a kind of InputPin that executes an Action to determine the values to input to another Action.
    /// </summary>
    class ActionInputPin : InputPin
    {
    	/// <summary>
    	/// The Action used to provide the values of the ActionInputPin.
    	/// </summary>
    	containment Action FromAction subsets Element.OwnedElement;
    }

    /// <summary>
    /// An AddStructuralFeatureValueAction is a WriteStructuralFeatureAction for adding values to a StructuralFeature.
    /// </summary>
    class AddStructuralFeatureValueAction : WriteStructuralFeatureAction
    {
    	/// <summary>
    	/// The InputPin that gives the position at which to insert the value in an ordered StructuralFeature. The type of the insertAt InputPin is UnlimitedNatural, but the value cannot be zero. It is omitted for unordered StructuralFeatures.
    	/// </summary>
    	containment InputPin InsertAt subsets Action.Input;
    	/// <summary>
    	/// Specifies whether existing values of the StructuralFeature should be removed before adding the new value.
    	/// </summary>
    	bool IsReplaceAll = "false";
    }

    /// <summary>
    /// An AddVariableValueAction is a WriteVariableAction for adding values to a Variable.
    /// </summary>
    class AddVariableValueAction : WriteVariableAction
    {
    	/// <summary>
    	/// The InputPin that gives the position at which to insert a new value or move an existing value in ordered Variables. The type of the insertAt InputPin is UnlimitedNatural, but the value cannot be zero. It is omitted for unordered Variables.
    	/// </summary>
    	containment InputPin InsertAt subsets Action.Input;
    	/// <summary>
    	/// Specifies whether existing values of the Variable should be removed before adding the new value.
    	/// </summary>
    	bool IsReplaceAll = "false";
    }

    /// <summary>
    /// A BroadcastSignalAction is an InvocationAction that transmits a Signal instance to all the potential target objects in the system. Values from the argument InputPins are used to provide values for the attributes of the Signal. The requestor continues execution immediately after the Signal instances are sent out and cannot receive reply values.
    /// </summary>
    class BroadcastSignalAction : InvocationAction
    {
    	/// <summary>
    	/// The Signal whose instances are to be sent.
    	/// </summary>
    	Signal Signal;
    }

    /// <summary>
    /// CallAction is an abstract class for Actions that invoke a Behavior with given argument values and (if the invocation is synchronous) receive reply values.
    /// </summary>
    abstract class CallAction : InvocationAction
    {
    	/// <summary>
    	/// If true, the call is synchronous and the caller waits for completion of the invoked Behavior. If false, the call is asynchronous and the caller proceeds immediately and cannot receive return values.
    	/// </summary>
    	bool IsSynchronous = "true";
    	/// <summary>
    	/// The OutputPins on which the reply values from the invocation are placed (if the call is synchronous).
    	/// </summary>
    	containment list<OutputPin> Result subsets Action.Output;
    	/// <summary>
    	/// Return the in and inout ownedParameters of the Behavior or Operation being called. (This operation is abstract and should be overridden by subclasses of CallAction.)
    	/// </summary>
    	readonly list<Parameter> InputParameters();
    	/// <summary>
    	/// Return the inout, out and return ownedParameters of the Behavior or Operation being called. (This operation is abstract and should be overridden by subclasses of CallAction.)
    	/// </summary>
    	readonly list<Parameter> OutputParameters();
    }

    /// <summary>
    /// A CallBehaviorAction is a CallAction that invokes a Behavior directly. The argument values of the CallBehaviorAction are passed on the input Parameters of the invoked Behavior. If the call is synchronous, the execution of the CallBehaviorAction waits until the execution of the invoked Behavior completes and the values of output Parameters of the Behavior are placed on the result OutputPins. If the call is asynchronous, the CallBehaviorAction completes immediately and no results values can be provided.
    /// </summary>
    class CallBehaviorAction : CallAction
    {
    	/// <summary>
    	/// The Behavior being invoked.
    	/// </summary>
    	Behavior Behavior;
    	/// <summary>
    	/// Return the inout, out and return ownedParameters of the Behavior being called.
    	/// </summary>
    	// spec:
    	//     result = (behavior.outputParameters())
    	readonly list<Parameter> OutputParameters();
    	/// <summary>
    	/// Return the in and inout ownedParameters of the Behavior being called.
    	/// </summary>
    	// spec:
    	//     result = (behavior.inputParameters())
    	readonly list<Parameter> InputParameters();
    }

    /// <summary>
    /// A CallOperationAction is a CallAction that transmits an Operation call request to the target object, where it may cause the invocation of associated Behavior. The argument values of the CallOperationAction are passed on the input Parameters of the Operation. If call is synchronous, the execution of the CallOperationAction waits until the execution of the invoked Operation completes and the values of output Parameters of the Operation are placed on the result OutputPins. If the call is asynchronous, the CallOperationAction completes immediately and no results values can be provided.
    /// </summary>
    class CallOperationAction : CallAction
    {
    	/// <summary>
    	/// The Operation being invoked.
    	/// </summary>
    	Operation Operation;
    	/// <summary>
    	/// The InputPin that provides the target object to which the Operation call request is sent.
    	/// </summary>
    	containment InputPin Target subsets Action.Input;
    	/// <summary>
    	/// Return the inout, out and return ownedParameters of the Operation being called.
    	/// </summary>
    	// spec:
    	//     result = (operation.outputParameters())
    	readonly list<Parameter> OutputParameters();
    	/// <summary>
    	/// Return the in and inout ownedParameters of the Operation being called.
    	/// </summary>
    	// spec:
    	//     result = (operation.inputParameters())
    	readonly list<Parameter> InputParameters();
    }

    /// <summary>
    /// A Clause is an Element that represents a single branch of a ConditionalNode, including a test and a body section. The body section is executed only if (but not necessarily if) the test section evaluates to true.
    /// </summary>
    class Clause : Element
    {
    	/// <summary>
    	/// The set of ExecutableNodes that are executed if the test evaluates to true and the Clause is chosen over other Clauses within the ConditionalNode that also have tests that evaluate to true.
    	/// </summary>
    	set<ExecutableNode> Body;
    	/// <summary>
    	/// The OutputPins on Actions within the body section whose values are moved to the result OutputPins of the containing ConditionalNode after execution of the body.
    	/// </summary>
    	list<OutputPin> BodyOutput;
    	/// <summary>
    	/// An OutputPin on an Action in the test section whose Boolean value determines the result of the test.
    	/// </summary>
    	OutputPin Decider;
    	/// <summary>
    	/// A set of Clauses whose tests must all evaluate to false before this Clause can evaluate its test.
    	/// </summary>
    	set<Clause> PredecessorClause;
    	/// <summary>
    	/// A set of Clauses that may not evaluate their tests unless the test for this Clause evaluates to false.
    	/// </summary>
    	set<Clause> SuccessorClause;
    	/// <summary>
    	/// The set of ExecutableNodes that are executed in order to provide a test result for the Clause.
    	/// </summary>
    	set<ExecutableNode> Test;
    }

    /// <summary>
    /// A ClearAssociationAction is an Action that destroys all links of an Association in which a particular object participates.
    /// </summary>
    class ClearAssociationAction : Action
    {
    	/// <summary>
    	/// The Association to be cleared.
    	/// </summary>
    	Association Association;
    	/// <summary>
    	/// The InputPin that gives the object whose participation in the Association is to be cleared.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    }

    /// <summary>
    /// A ClearStructuralFeatureAction is a StructuralFeatureAction that removes all values of a StructuralFeature.
    /// </summary>
    class ClearStructuralFeatureAction : StructuralFeatureAction
    {
    	/// <summary>
    	/// The OutputPin on which is put the input object as modified by the ClearStructuralFeatureAction.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A ClearVariableAction is a VariableAction that removes all values of a Variable.
    /// </summary>
    class ClearVariableAction : VariableAction
    {
    }

    /// <summary>
    /// A ConditionalNode is a StructuredActivityNode that chooses one among some number of alternative collections of ExecutableNodes to execute.
    /// </summary>
    class ConditionalNode : StructuredActivityNode
    {
    	/// <summary>
    	/// The set of Clauses composing the ConditionalNode.
    	/// </summary>
    	containment set<Clause> Clause subsets Element.OwnedElement;
    	/// <summary>
    	/// If true, the modeler asserts that the test for at least one Clause of the ConditionalNode will succeed.
    	/// </summary>
    	bool IsAssured = "false";
    	/// <summary>
    	/// If true, the modeler asserts that the test for at most one Clause of the ConditionalNode will succeed.
    	/// </summary>
    	bool IsDeterminate = "false";
    	/// <summary>
    	/// The OutputPins that onto which are moved values from the bodyOutputs of the Clause selected for execution.
    	/// </summary>
    	containment list<OutputPin> Result redefines StructuredActivityNode.StructuredNodeOutput;
    	/// <summary>
    	/// Return only this ConditionalNode. This prevents Actions within the ConditionalNode from having their OutputPins used as bodyOutputs or decider Pins in containing LoopNodes or ConditionalNodes.
    	/// </summary>
    	// spec:
    	//     result = (self->asSet())
    	readonly set<Action> AllActions();
    }

    /// <summary>
    /// A CreateLinkAction is a WriteLinkAction for creating links.
    /// </summary>
    class CreateLinkAction : WriteLinkAction
    {
    	/// <summary>
    	/// The LinkEndData that specifies the values to be placed on the Association ends for the new link.
    	/// </summary>
    	containment set<LinkEndCreationData> EndData redefines LinkAction.EndData;
    }

    /// <summary>
    /// A CreateLinkObjectAction is a CreateLinkAction for creating link objects (AssociationClasse instances).
    /// </summary>
    class CreateLinkObjectAction : CreateLinkAction
    {
    	/// <summary>
    	/// The output pin on which the newly created link object is placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A CreateObjectAction is an Action that creates an instance of the specified Classifier.
    /// </summary>
    class CreateObjectAction : Action
    {
    	/// <summary>
    	/// The Classifier to be instantiated.
    	/// </summary>
    	Classifier Classifier;
    	/// <summary>
    	/// The OutputPin on which the newly created object is placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A DestroyLinkAction is a WriteLinkAction that destroys links (including link objects).
    /// </summary>
    class DestroyLinkAction : WriteLinkAction
    {
    	/// <summary>
    	/// The LinkEndData that the values of the Association ends for the links to be destroyed.
    	/// </summary>
    	containment set<LinkEndDestructionData> EndData redefines LinkAction.EndData;
    }

    /// <summary>
    /// A DestroyObjectAction is an Action that destroys objects.
    /// </summary>
    class DestroyObjectAction : Action
    {
    	/// <summary>
    	/// Specifies whether links in which the object participates are destroyed along with the object.
    	/// </summary>
    	bool IsDestroyLinks = "false";
    	/// <summary>
    	/// Specifies whether objects owned by the object (via composition) are destroyed along with the object.
    	/// </summary>
    	bool IsDestroyOwnedObjects = "false";
    	/// <summary>
    	/// The InputPin providing the object to be destroyed.
    	/// </summary>
    	containment InputPin Target subsets Action.Input;
    }

    /// <summary>
    /// An ExpansionNode is an ObjectNode used to indicate a collection input or output for an ExpansionRegion. A collection input of an ExpansionRegion contains a collection that is broken into its individual elements inside the region, whose content is executed once per element. A collection output of an ExpansionRegion combines individual elements produced by the execution of the region into a collection for use outside the region.
    /// </summary>
    class ExpansionNode : ObjectNode
    {
    	/// <summary>
    	/// The ExpansionRegion for which the ExpansionNode is an input.
    	/// </summary>
    	ExpansionRegion RegionAsInput;
    	/// <summary>
    	/// The ExpansionRegion for which the ExpansionNode is an output.
    	/// </summary>
    	ExpansionRegion RegionAsOutput;
    }

    /// <summary>
    /// An ExpansionRegion is a StructuredActivityNode that executes its content multiple times corresponding to elements of input collection(s).
    /// </summary>
    class ExpansionRegion : StructuredActivityNode
    {
    	/// <summary>
    	/// The ExpansionNodes that hold the input collections for the ExpansionRegion.
    	/// </summary>
    	set<ExpansionNode> InputElement;
    	/// <summary>
    	/// The mode in which the ExpansionRegion executes its contents. If parallel, executions are concurrent. If iterative, executions are sequential. If stream, a stream of values flows into a single execution.
    	/// </summary>
    	ExpansionKind Mode = "ExpansionKind.Iterative";
    	/// <summary>
    	/// The ExpansionNodes that form the output collections of the ExpansionRegion.
    	/// </summary>
    	set<ExpansionNode> OutputElement;
    }

    /// <summary>
    /// An InputPin is a Pin that holds input values to be consumed by an Action.
    /// </summary>
    class InputPin : Pin
    {
    }

    /// <summary>
    /// InvocationAction is an abstract class for the various actions that request Behavior invocation.
    /// </summary>
    abstract class InvocationAction : Action
    {
    	/// <summary>
    	/// The InputPins that provide the argument values passed in the invocation request.
    	/// </summary>
    	containment list<InputPin> Argument subsets Action.Input;
    	/// <summary>
    	/// For CallOperationActions, SendSignalActions, and SendObjectActions, an optional Port of the target object through which the invocation request is sent.
    	/// </summary>
    	Port OnPort;
    }

    /// <summary>
    /// LinkAction is an abstract class for all Actions that identify the links to be acted on using LinkEndData.
    /// </summary>
    abstract class LinkAction : Action
    {
    	/// <summary>
    	/// The LinkEndData identifying the values on the ends of the links acting on by this LinkAction.
    	/// </summary>
    	containment set<LinkEndData> EndData subsets Element.OwnedElement;
    	/// <summary>
    	/// InputPins used by the LinkEndData of the LinkAction.
    	/// </summary>
    	containment set<InputPin> InputValue subsets Action.Input;
    	/// <summary>
    	/// Returns the Association acted on by this LinkAction.
    	/// </summary>
    	// spec:
    	//     result = (endData->asSequence()->first().end.association)
    	readonly Association Association();
    }

    /// <summary>
    /// LinkEndCreationData is LinkEndData used to provide values for one end of a link to be created by a CreateLinkAction.
    /// </summary>
    class LinkEndCreationData : LinkEndData
    {
    	/// <summary>
    	/// For ordered Association ends, the InputPin that provides the position where the new link should be inserted or where an existing link should be moved to. The type of the insertAt InputPin is UnlimitedNatural, but the input cannot be zero. It is omitted for Association ends that are not ordered.
    	/// </summary>
    	InputPin InsertAt;
    	/// <summary>
    	/// Specifies whether the existing links emanating from the object on this end should be destroyed before creating a new link.
    	/// </summary>
    	bool IsReplaceAll = "false";
    	/// <summary>
    	/// Adds the insertAt InputPin (if any) to the set of all Pins.
    	/// </summary>
    	// spec:
    	//     result = (self.LinkEndData::allPins()->including(insertAt))
    	readonly multi_set<InputPin> AllPins();
    }

    /// <summary>
    /// LinkEndData is an Element that identifies on end of a link to be read or written by a LinkAction. As a link (that is not a link object) cannot be passed as a runtime value to or from an Action, it is instead identified by its end objects and qualifier values, if any. A LinkEndData instance provides these values for a single Association end.
    /// </summary>
    class LinkEndData : Element
    {
    	/// <summary>
    	/// The Association end for which this LinkEndData specifies values.
    	/// </summary>
    	Property End;
    	/// <summary>
    	/// A set of QualifierValues used to provide values for the qualifiers of the end.
    	/// </summary>
    	containment set<QualifierValue> Qualifier subsets Element.OwnedElement;
    	/// <summary>
    	/// The InputPin that provides the specified value for the given end. This InputPin is omitted if the LinkEndData specifies the &quot;open&quot; end for a ReadLinkAction.
    	/// </summary>
    	InputPin Value;
    	/// <summary>
    	/// Returns all the InputPins referenced by this LinkEndData. By default this includes the value and qualifier InputPins, but subclasses may override the operation to add other InputPins.
    	/// </summary>
    	// spec:
    	//     result = (value->asBag()->union(qualifier.value))
    	readonly multi_set<InputPin> AllPins();
    }

    /// <summary>
    /// LinkEndDestructionData is LinkEndData used to provide values for one end of a link to be destroyed by a DestroyLinkAction.
    /// </summary>
    class LinkEndDestructionData : LinkEndData
    {
    	/// <summary>
    	/// The InputPin that provides the position of an existing link to be destroyed in an ordered, nonunique Association end. The type of the destroyAt InputPin is UnlimitedNatural, but the value cannot be zero or unlimited.
    	/// </summary>
    	InputPin DestroyAt;
    	/// <summary>
    	/// Specifies whether to destroy duplicates of the value in nonunique Association ends.
    	/// </summary>
    	bool IsDestroyDuplicates = "false";
    	/// <summary>
    	/// Adds the destroyAt InputPin (if any) to the set of all Pins.
    	/// </summary>
    	// spec:
    	//     result = (self.LinkEndData::allPins()->including(destroyAt))
    	readonly multi_set<InputPin> AllPins();
    }

    /// <summary>
    /// A LoopNode is a StructuredActivityNode that represents an iterative loop with setup, test, and body sections.
    /// </summary>
    class LoopNode : StructuredActivityNode
    {
    	/// <summary>
    	/// The OutputPins on Actions within the bodyPart, the values of which are moved to the loopVariable OutputPins after the completion of each execution of the bodyPart, before the next iteration of the loop begins or before the loop exits.
    	/// </summary>
    	list<OutputPin> BodyOutput;
    	/// <summary>
    	/// The set of ExecutableNodes that perform the repetitive computations of the loop. The bodyPart is executed as long as the test section produces a true value.
    	/// </summary>
    	set<ExecutableNode> BodyPart;
    	/// <summary>
    	/// An OutputPin on an Action in the test section whose Boolean value determines whether to continue executing the loop bodyPart.
    	/// </summary>
    	OutputPin Decider;
    	/// <summary>
    	/// If true, the test is performed before the first execution of the bodyPart. If false, the bodyPart is executed once before the test is performed.
    	/// </summary>
    	bool IsTestedFirst = "false";
    	/// <summary>
    	/// A list of OutputPins that hold the values of the loop variables during an execution of the loop. When the test fails, the values are moved to the result OutputPins of the loop.
    	/// </summary>
    	containment list<OutputPin> LoopVariable subsets Element.OwnedElement;
    	/// <summary>
    	/// A list of InputPins whose values are moved into the loopVariable Pins before the first iteration of the loop.
    	/// </summary>
    	containment list<InputPin> LoopVariableInput redefines StructuredActivityNode.StructuredNodeInput;
    	/// <summary>
    	/// A list of OutputPins that receive the loopVariable values after the last iteration of the loop and constitute the output of the LoopNode.
    	/// </summary>
    	containment list<OutputPin> Result redefines StructuredActivityNode.StructuredNodeOutput;
    	/// <summary>
    	/// The set of ExecutableNodes executed before the first iteration of the loop, in order to initialize values or perform other setup computations.
    	/// </summary>
    	set<ExecutableNode> SetupPart;
    	/// <summary>
    	/// The set of ExecutableNodes executed in order to provide the test result for the loop.
    	/// </summary>
    	set<ExecutableNode> Test;
    	/// <summary>
    	/// Return only this LoopNode. This prevents Actions within the LoopNode from having their OutputPins used as bodyOutputs or decider Pins in containing LoopNodes or ConditionalNodes.
    	/// </summary>
    	// spec:
    	//     result = (self->asSet())
    	readonly set<Action> AllActions();
    	/// <summary>
    	/// Return the loopVariable OutputPins in addition to other source nodes for the LoopNode as a StructuredActivityNode.
    	/// </summary>
    	// spec:
    	//     result = (self.StructuredActivityNode::sourceNodes()->union(loopVariable))
    	readonly set<ActivityNode> SourceNodes();
    }

    /// <summary>
    /// An OpaqueAction is an Action whose functionality is not specified within UML.
    /// </summary>
    class OpaqueAction : Action
    {
    	/// <summary>
    	/// Provides a textual specification of the functionality of the Action, in one or more languages other than UML.
    	/// </summary>
    	multi_list<string> Body;
    	/// <summary>
    	/// The InputPins providing inputs to the OpaqueAction.
    	/// </summary>
    	containment set<InputPin> InputValue subsets Action.Input;
    	/// <summary>
    	/// If provided, a specification of the language used for each of the body Strings.
    	/// </summary>
    	list<string> Language;
    	/// <summary>
    	/// The OutputPins on which the OpaqueAction provides outputs.
    	/// </summary>
    	containment set<OutputPin> OutputValue subsets Action.Output;
    }

    /// <summary>
    /// An OutputPin is a Pin that holds output values produced by an Action.
    /// </summary>
    class OutputPin : Pin
    {
    }

    /// <summary>
    /// A Pin is an ObjectNode and MultiplicityElement that provides input values to an Action or accepts output values from an Action.
    /// </summary>
    abstract class Pin : ObjectNode, MultiplicityElement
    {
    	/// <summary>
    	/// Indicates whether the Pin provides data to the Action or just controls how the Action executes.
    	/// </summary>
    	bool IsControl = "false";
    }

    /// <summary>
    /// A QualifierValue is an Element that is used as part of LinkEndData to provide the value for a single qualifier of the end given by the LinkEndData.
    /// </summary>
    class QualifierValue : Element
    {
    	/// <summary>
    	/// The qualifier Property for which the value is to be specified.
    	/// </summary>
    	Property Qualifier;
    	/// <summary>
    	/// The InputPin from which the specified value for the qualifier is taken.
    	/// </summary>
    	InputPin Value;
    }

    /// <summary>
    /// A RaiseExceptionAction is an Action that causes an exception to occur. The input value becomes the exception object.
    /// </summary>
    class RaiseExceptionAction : Action
    {
    	/// <summary>
    	/// An InputPin whose value becomes the exception object.
    	/// </summary>
    	containment InputPin Exception subsets Action.Input;
    }

    /// <summary>
    /// A ReadExtentAction is an Action that retrieves the current instances of a Classifier.
    /// </summary>
    class ReadExtentAction : Action
    {
    	/// <summary>
    	/// The Classifier whose instances are to be retrieved.
    	/// </summary>
    	Classifier Classifier;
    	/// <summary>
    	/// The OutputPin on which the Classifier instances are placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A ReadIsClassifiedObjectAction is an Action that determines whether an object is classified by a given Classifier.
    /// </summary>
    class ReadIsClassifiedObjectAction : Action
    {
    	/// <summary>
    	/// The Classifier against which the classification of the input object is tested.
    	/// </summary>
    	Classifier Classifier;
    	/// <summary>
    	/// Indicates whether the input object must be directly classified by the given Classifier or whether it may also be an instance of a specialization of the given Classifier.
    	/// </summary>
    	bool IsDirect = "false";
    	/// <summary>
    	/// The InputPin that holds the object whose classification is to be tested.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    	/// <summary>
    	/// The OutputPin that holds the Boolean result of the test.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A ReadLinkAction is a LinkAction that navigates across an Association to retrieve the objects on one end.
    /// </summary>
    class ReadLinkAction : LinkAction
    {
    	/// <summary>
    	/// The OutputPin on which the objects retrieved from the &quot;open&quot; end of those links whose values on other ends are given by the endData.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    	/// <summary>
    	/// Returns the ends corresponding to endData with no value InputPin. (A well-formed ReadLinkAction is constrained to have only one of these.)
    	/// </summary>
    	// spec:
    	//     result = (endData->select(value=null).end->asOrderedSet())
    	readonly list<Property> OpenEnd();
    }

    /// <summary>
    /// A ReadLinkObjectEndAction is an Action that retrieves an end object from a link object.
    /// </summary>
    class ReadLinkObjectEndAction : Action
    {
    	/// <summary>
    	/// The Association end to be read.
    	/// </summary>
    	Property End;
    	/// <summary>
    	/// The input pin from which the link object is obtained.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    	/// <summary>
    	/// The OutputPin where the result value is placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A ReadLinkObjectEndQualifierAction is an Action that retrieves a qualifier end value from a link object.
    /// </summary>
    class ReadLinkObjectEndQualifierAction : Action
    {
    	/// <summary>
    	/// The InputPin from which the link object is obtained.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    	/// <summary>
    	/// The qualifier Property to be read.
    	/// </summary>
    	Property Qualifier;
    	/// <summary>
    	/// The OutputPin where the result value is placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A ReadSelfAction is an Action that retrieves the context object of the Behavior execution within which the ReadSelfAction execution is taking place.
    /// </summary>
    class ReadSelfAction : Action
    {
    	/// <summary>
    	/// The OutputPin on which the context object is placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A ReadStructuralFeatureAction is a StructuralFeatureAction that retrieves the values of a StructuralFeature.
    /// </summary>
    class ReadStructuralFeatureAction : StructuralFeatureAction
    {
    	/// <summary>
    	/// The OutputPin on which the result values are placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A ReadVariableAction is a VariableAction that retrieves the values of a Variable.
    /// </summary>
    class ReadVariableAction : VariableAction
    {
    	/// <summary>
    	/// The OutputPin on which the result values are placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A ReclassifyObjectAction is an Action that changes the Classifiers that classify an object.
    /// </summary>
    class ReclassifyObjectAction : Action
    {
    	/// <summary>
    	/// Specifies whether existing Classifiers should be removed before adding the new Classifiers.
    	/// </summary>
    	bool IsReplaceAll = "false";
    	/// <summary>
    	/// A set of Classifiers to be added to the Classifiers of the given object.
    	/// </summary>
    	set<Classifier> NewClassifier;
    	/// <summary>
    	/// The InputPin that holds the object to be reclassified.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    	/// <summary>
    	/// A set of Classifiers to be removed from the Classifiers of the given object.
    	/// </summary>
    	set<Classifier> OldClassifier;
    }

    /// <summary>
    /// A ReduceAction is an Action that reduces a collection to a single value by repeatedly combining the elements of the collection using a reducer Behavior.
    /// </summary>
    class ReduceAction : Action
    {
    	/// <summary>
    	/// The InputPin that provides the collection to be reduced.
    	/// </summary>
    	containment InputPin Collection subsets Action.Input;
    	/// <summary>
    	/// Indicates whether the order of the input collection should determine the order in which the reducer Behavior is applied to its elements.
    	/// </summary>
    	bool IsOrdered = "false";
    	/// <summary>
    	/// A Behavior that is repreatedly applied to two elements of the input collection to produce a value that is of the same type as elements of the collection.
    	/// </summary>
    	Behavior Reducer;
    	/// <summary>
    	/// The output pin on which the result value is placed.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    }

    /// <summary>
    /// A RemoveStructuralFeatureValueAction is a WriteStructuralFeatureAction that removes values from a StructuralFeature.
    /// </summary>
    class RemoveStructuralFeatureValueAction : WriteStructuralFeatureAction
    {
    	/// <summary>
    	/// Specifies whether to remove duplicates of the value in nonunique StructuralFeatures.
    	/// </summary>
    	bool IsRemoveDuplicates = "false";
    	/// <summary>
    	/// An InputPin that provides the position of an existing value to remove in ordered, nonunique structural features. The type of the removeAt InputPin is UnlimitedNatural, but the value cannot be zero or unlimited.
    	/// </summary>
    	containment InputPin RemoveAt subsets Action.Input;
    }

    /// <summary>
    /// A RemoveVariableValueAction is a WriteVariableAction that removes values from a Variables.
    /// </summary>
    class RemoveVariableValueAction : WriteVariableAction
    {
    	/// <summary>
    	/// Specifies whether to remove duplicates of the value in nonunique Variables.
    	/// </summary>
    	bool IsRemoveDuplicates = "false";
    	/// <summary>
    	/// An InputPin that provides the position of an existing value to remove in ordered, nonunique Variables. The type of the removeAt InputPin is UnlimitedNatural, but the value cannot be zero or unlimited.
    	/// </summary>
    	containment InputPin RemoveAt subsets Action.Input;
    }

    /// <summary>
    /// A ReplyAction is an Action that accepts a set of reply values and a value containing return information produced by a previous AcceptCallAction. The ReplyAction returns the values to the caller of the previous call, completing execution of the call.
    /// </summary>
    class ReplyAction : Action
    {
    	/// <summary>
    	/// The Trigger specifying the Operation whose call is being replied to.
    	/// </summary>
    	Trigger ReplyToCall;
    	/// <summary>
    	/// A list of InputPins providing the values for the output (inout, out, and return) Parameters of the Operation. These values are returned to the caller.
    	/// </summary>
    	containment list<InputPin> ReplyValue subsets Action.Input;
    	/// <summary>
    	/// An InputPin that holds the return information value produced by an earlier AcceptCallAction.
    	/// </summary>
    	containment InputPin ReturnInformation subsets Action.Input;
    }

    /// <summary>
    /// A SendObjectAction is an InvocationAction that transmits an input object to the target object, which is handled as a request message by the target object. The requestor continues execution immediately after the object is sent out and cannot receive reply values.
    /// </summary>
    class SendObjectAction : InvocationAction
    {
    	/// <summary>
    	/// The request object, which is transmitted to the target object. The object may be copied in transmission, so identity might not be preserved.
    	/// </summary>
    	containment InputPin Request redefines InvocationAction.Argument;
    	/// <summary>
    	/// The target object to which the object is sent.
    	/// </summary>
    	containment InputPin Target subsets Action.Input;
    }

    /// <summary>
    /// A SendSignalAction is an InvocationAction that creates a Signal instance and transmits it to the target object. Values from the argument InputPins are used to provide values for the attributes of the Signal. The requestor continues execution immediately after the Signal instance is sent out and cannot receive reply values.
    /// </summary>
    class SendSignalAction : InvocationAction
    {
    	/// <summary>
    	/// The Signal whose instance is transmitted to the target.
    	/// </summary>
    	Signal Signal;
    	/// <summary>
    	/// The InputPin that provides the target object to which the Signal instance is sent.
    	/// </summary>
    	containment InputPin Target subsets Action.Input;
    }

    /// <summary>
    /// A SequenceNode is a StructuredActivityNode that executes a sequence of ExecutableNodes in order.
    /// </summary>
    class SequenceNode : StructuredActivityNode
    {
    	/// <summary>
    	/// The ordered set of ExecutableNodes to be sequenced.
    	/// </summary>
    	containment list<ExecutableNode> ExecutableNode redefines StructuredActivityNode.Node;
    }

    /// <summary>
    /// A StartClassifierBehaviorAction is an Action that starts the classifierBehavior of the input object.
    /// </summary>
    class StartClassifierBehaviorAction : Action
    {
    	/// <summary>
    	/// The InputPin that holds the object whose classifierBehavior is to be started.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    }

    /// <summary>
    /// A StartObjectBehaviorAction is an InvocationAction that starts the execution either of a directly instantiated Behavior or of the classifierBehavior of an object. Argument values may be supplied for the input Parameters of the Behavior. If the Behavior is invoked synchronously, then output values may be obtained for output Parameters.
    /// </summary>
    class StartObjectBehaviorAction : CallAction
    {
    	/// <summary>
    	/// An InputPin that holds the object that is either a Behavior to be started or has a classifierBehavior to be started.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    	/// <summary>
    	/// Return the inout, out and return ownedParameters of the Behavior being called.
    	/// </summary>
    	// spec:
    	//     result = (self.behavior().outputParameters())
    	readonly list<Parameter> OutputParameters();
    	/// <summary>
    	/// Return the in and inout ownedParameters of the Behavior being called.
    	/// </summary>
    	// spec:
    	//     result = (self.behavior().inputParameters())
    	readonly list<Parameter> InputParameters();
    	/// <summary>
    	/// If the type of the object InputPin is a Behavior, then that Behavior. Otherwise, if the type of the object InputPin is a BehavioredClassifier, then the classifierBehavior of that BehavioredClassifier.
    	/// </summary>
    	// spec:
    	//     result = (if object.type.oclIsKindOf(Behavior) then
    	//       object.type.oclAsType(Behavior)
    	//     else if object.type.oclIsKindOf(BehavioredClassifier) then
    	//       object.type.oclAsType(BehavioredClassifier).classifierBehavior
    	//     else
    	//       null
    	//     endif
    	//     endif)
    	readonly Behavior Behavior();
    }

    /// <summary>
    /// StructuralFeatureAction is an abstract class for all Actions that operate on StructuralFeatures.
    /// </summary>
    abstract class StructuralFeatureAction : Action
    {
    	/// <summary>
    	/// The InputPin from which the object whose StructuralFeature is to be read or written is obtained.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    	/// <summary>
    	/// The StructuralFeature to be read or written.
    	/// </summary>
    	StructuralFeature StructuralFeature;
    }

    /// <summary>
    /// A StructuredActivityNode is an Action that is also an ActivityGroup and whose behavior is specified by the ActivityNodes and ActivityEdges it so contains. Unlike other kinds of ActivityGroup, a StructuredActivityNode owns the ActivityNodes and ActivityEdges it contains, and so a node or edge can only be directly contained in one StructuredActivityNode, though StructuredActivityNodes may be nested.
    /// </summary>
    class StructuredActivityNode : Namespace, ActivityGroup, Action
    {
    	/// <summary>
    	/// The Activity immediately containing the StructuredActivityNode, if it is not contained in another StructuredActivityNode.
    	/// </summary>
    	Activity Activity redefines ActivityGroup.InActivity, ActivityNode.Activity;
    	/// <summary>
    	/// The ActivityEdges immediately contained in the StructuredActivityNode.
    	/// </summary>
    	containment set<ActivityEdge> Edge subsets ActivityGroup.ContainedEdge, Element.OwnedElement;
    	/// <summary>
    	/// If true, then any object used by an Action within the StructuredActivityNode cannot be accessed by any Action outside the node until the StructuredActivityNode as a whole completes. Any concurrent Actions that would result in accessing such objects are required to have their execution deferred until the completion of the StructuredActivityNode.
    	/// </summary>
    	bool MustIsolate = "false";
    	/// <summary>
    	/// The ActivityNodes immediately contained in the StructuredActivityNode.
    	/// </summary>
    	containment set<ActivityNode> Node subsets ActivityGroup.ContainedNode, Element.OwnedElement;
    	/// <summary>
    	/// The InputPins owned by the StructuredActivityNode.
    	/// </summary>
    	containment set<InputPin> StructuredNodeInput subsets Action.Input;
    	/// <summary>
    	/// The OutputPins owned by the StructuredActivityNode.
    	/// </summary>
    	containment set<OutputPin> StructuredNodeOutput subsets Action.Output;
    	/// <summary>
    	/// The Variables defined in the scope of the StructuredActivityNode.
    	/// </summary>
    	containment set<Variable> Variable subsets Namespace.OwnedMember;
    	/// <summary>
    	/// Returns this StructuredActivityNode and all Actions contained in it.
    	/// </summary>
    	// spec:
    	//     result = (node->select(oclIsKindOf(Action)).oclAsType(Action).allActions()->including(self)->asSet())
    	readonly set<Action> AllActions();
    	/// <summary>
    	/// Returns all the ActivityNodes contained directly or indirectly within this StructuredActivityNode, in addition to the Pins of the StructuredActivityNode.
    	/// </summary>
    	// spec:
    	//     result = (self.Action::allOwnedNodes()->union(node)->union(node->select(oclIsKindOf(Action)).oclAsType(Action).allOwnedNodes())->asSet())
    	readonly set<ActivityNode> AllOwnedNodes();
    	/// <summary>
    	/// Return those ActivityNodes contained immediately within the StructuredActivityNode that may act as sources of edges owned by the StructuredActivityNode.
    	/// </summary>
    	// spec:
    	//     result = (node->union(input.oclAsType(ActivityNode)->asSet())->
    	//       union(node->select(oclIsKindOf(Action)).oclAsType(Action).output)->asSet())
    	readonly set<ActivityNode> SourceNodes();
    	/// <summary>
    	/// Return those ActivityNodes contained immediately within the StructuredActivityNode that may act as targets of edges owned by the StructuredActivityNode.
    	/// </summary>
    	// spec:
    	//     result = (node->union(output.oclAsType(ActivityNode)->asSet())->
    	//       union(node->select(oclIsKindOf(Action)).oclAsType(Action).input)->asSet())
    	readonly set<ActivityNode> TargetNodes();
    	/// <summary>
    	/// The Activity that directly or indirectly contains this StructuredActivityNode (considered as an Action).
    	/// </summary>
    	// spec:
    	//     result = (self.Action::containingActivity())
    	readonly Activity ContainingActivity();
    }

    /// <summary>
    /// A TestIdentityAction is an Action that tests if two values are identical objects.
    /// </summary>
    class TestIdentityAction : Action
    {
    	/// <summary>
    	/// The InputPin on which the first input object is placed.
    	/// </summary>
    	containment InputPin First subsets Action.Input;
    	/// <summary>
    	/// The OutputPin whose Boolean value indicates whether the two input objects are identical.
    	/// </summary>
    	containment OutputPin Result subsets Action.Output;
    	/// <summary>
    	/// The OutputPin on which the second input object is placed.
    	/// </summary>
    	containment InputPin Second subsets Action.Input;
    }

    /// <summary>
    /// An UnmarshallAction is an Action that retrieves the values of the StructuralFeatures of an object and places them on OutputPins. 
    /// </summary>
    class UnmarshallAction : Action
    {
    	/// <summary>
    	/// The InputPin that gives the object to be unmarshalled.
    	/// </summary>
    	containment InputPin Object subsets Action.Input;
    	/// <summary>
    	/// The OutputPins on which are placed the values of the StructuralFeatures of the input object.
    	/// </summary>
    	containment list<OutputPin> Result subsets Action.Output;
    	/// <summary>
    	/// The type of the object to be unmarshalled.
    	/// </summary>
    	Classifier UnmarshallType;
    }

    /// <summary>
    /// A ValuePin is an InputPin that provides a value by evaluating a ValueSpecification.
    /// </summary>
    class ValuePin : InputPin
    {
    	/// <summary>
    	/// The ValueSpecification that is evaluated to obtain the value that the ValuePin will provide.
    	/// </summary>
    	containment ValueSpecification Value subsets Element.OwnedElement;
    }

    // association ObjectNode.Selection with Behavior.ObjectNode;
    // association ObjectNode.InState with State.ObjectNode;
    // association ObjectNode.UpperBound with ValueSpecification.ObjectNode;
    // association ObjectFlow.Transformation with Behavior.ObjectFlow;
    // association ObjectFlow.Selection with Behavior.ObjectFlow;
    // association JoinNode.JoinSpec with ValueSpecification.JoinNode;
    association ActivityEdge.Interrupts with InterruptibleActivityRegion.InterruptingEdge;
    association ExceptionHandler.ProtectedNode with ExecutableNode.Handler;
    // association ExceptionHandler.HandlerBody with ExecutableNode.ExceptionHandler;
    // association ExceptionHandler.ExceptionType with Classifier.ExceptionHandler;
    // association ExceptionHandler.ExceptionInput with ObjectNode.ExceptionHandler;
    // association DecisionNode.DecisionInput with Behavior.DecisionNode;
    // association DecisionNode.DecisionInputFlow with ObjectFlow.DecisionNode;
    // association ActivityPartition.Represents with Element.ActivityPartition;
    association ActivityPartition.Subpartition with ActivityPartition.SuperPartition;
    association ActivityEdge.InPartition with ActivityPartition.Edge;
    // association ActivityParameterNode.Parameter with Parameter.ActivityParameterNode;
    association ActivityNode.InInterruptibleRegion with InterruptibleActivityRegion.Node;
    association ActivityNode.InPartition with ActivityPartition.Node;
    association ActivityEdge.Target with ActivityNode.Incoming;
    association ActivityEdge.Source with ActivityNode.Outgoing;
    // association ActivityNode.RedefinedNode with ActivityNode.ActivityNode;
    association ActivityEdge.InGroup with ActivityGroup.ContainedEdge;
    association ActivityGroup.ContainedNode with ActivityNode.InGroup;
    association ActivityGroup.Subgroup with ActivityGroup.SuperGroup;
    // association ActivityEdge.RedefinedEdge with ActivityEdge.ActivityEdge;
    // association ActivityEdge.Weight with ValueSpecification.ActivityEdge;
    // association ActivityEdge.Guard with ValueSpecification.ActivityEdge;
    association Activity.StructuredNode with StructuredActivityNode.Activity;
    association Activity.Group with ActivityGroup.InActivity;
    association Activity.Node with ActivityNode.Activity;
    association Activity.Variable with Variable.ActivityScope;
    association Activity.Edge with ActivityEdge.Activity;
    // association Activity.Partition with ActivityPartition.Activity;
    // association TimeObservation.Event with NamedElement.TimeObservation;
    // association TimeInterval.Max with TimeExpression.TimeInterval;
    // association TimeInterval.Min with TimeExpression.TimeInterval;
    // association TimeExpression.Expr with ValueSpecification.TimeExpression;
    // association TimeExpression.Observation with Observation.TimeExpression;
    // association TimeConstraint.Specification with TimeInterval.TimeConstraint;
    association StringExpression.OwningExpression with StringExpression.SubExpression;
    // association OpaqueExpression.Result with Parameter.OpaqueExpression;
    // association OpaqueExpression.Behavior with Behavior.OpaqueExpression;
    // association IntervalConstraint.Specification with Interval.IntervalConstraint;
    // association Interval.Max with ValueSpecification.Interval;
    // association Interval.Min with ValueSpecification.Interval;
    // association Expression.Operand with ValueSpecification.Expression;
    // association DurationObservation.Event with NamedElement.DurationObservation;
    // association DurationInterval.Max with Duration.DurationInterval;
    // association DurationInterval.Min with Duration.DurationInterval;
    // association DurationConstraint.Specification with DurationInterval.DurationConstraint;
    // association Duration.Expr with ValueSpecification.Duration;
    // association Duration.Observation with Observation.Duration;
    association ExtensionPoint.UseCase with UseCase.ExtensionPoint;
    association Include.IncludingCase with UseCase.Include;
    association UseCase.Subject with Classifier.UseCase;
    association Extend.Extension with UseCase.Extend;
    // association Include.Addition with UseCase.Include;
    // association Extend.ExtensionLocation with ExtensionPoint.Extension;
    // association Extend.Condition with Constraint.Extend;
    // association Extend.ExtendedCase with UseCase.Extend;
    // association StructuredClassifier.Part with Property.StructuredClassifier;
    // association StructuredClassifier.OwnedConnector with Connector.StructuredClassifier;
    // association StructuredClassifier.OwnedAttribute with Property.StructuredClassifier;
    // association StructuredClassifier.Role with ConnectableElement.StructuredClassifier;
    // association Port.Protocol with ProtocolStateMachine.Port;
    // association Port.Required with Interface.Port;
    // association Port.RedefinedPort with Port.Port;
    // association Port.Provided with Interface.Port;
    // association EncapsulatedClassifier.OwnedPort with Port.EncapsulatedClassifier;
    // association ConnectorEnd.PartWithPort with Property.ConnectorEnd;
    // association ConnectorEnd.DefiningEnd with Property.ConnectorEnd;
    // association Connector.End with ConnectorEnd.Connector;
    // association Connector.RedefinedConnector with Connector.Connector;
    // association Connector.Contract with Behavior.Connector;
    // association Connector.Type with Association.Connector;
    association ConnectableElement.TemplateParameter with ConnectableElementTemplateParameter.ParameteredElement;
    association ConnectableElement.End with ConnectorEnd.Role;
    // association ComponentRealization.RealizingClassifier with Classifier.ComponentRealization;
    // association Component.Required with Interface.Component;
    // association Component.PackagedElement with PackageableElement.Component;
    association Component.Realization with ComponentRealization.Abstraction;
    // association Component.Provided with Interface.Component;
    // association CollaborationUse.Type with Collaboration.CollaborationUse;
    // association CollaborationUse.RoleBinding with Dependency.CollaborationUse;
    // association Collaboration.CollaborationRole with ConnectableElement.Collaboration;
    association Class.OwnedOperation with Operation.Class;
    // association Class.SuperClass with Class.Class;
    association Class.Extension with Extension.Metaclass;
    association Class.OwnedAttribute with Property.Class;
    // association Class.NestedClassifier with Classifier.NestingClass;
    // association Class.OwnedReception with Reception.Class;
    association Association.MemberEnd with Property.Association;
    // association Association.EndType with Type.Association;
    association Association.OwnedEnd with Property.OwningAssociation;
    // association Association.NavigableOwnedEnd with Property.Association;
    association Transition.Target with Vertex.Incoming;
    association Transition.Source with Vertex.Outgoing;
    // association Transition.Trigger with Trigger.Transition;
    // association Transition.Guard with Constraint.Transition;
    // association Transition.RedefinedTransition with Transition.Transition;
    // association Transition.RedefinitionContext with Classifier.Transition;
    // association Transition.Effect with Behavior.Transition;
    association State.Submachine with StateMachine.SubmachineState;
    association Pseudostate.StateMachine with StateMachine.ConnectionPoint;
    association Region.StateMachine with StateMachine.Region;
    // association StateMachine.ExtendedStateMachine with StateMachine.StateMachine;
    // association Vertex.RedefinitionContext with Classifier.Vertex;
    association Region.State with State.Region;
    // association State.StateInvariant with Constraint.OwningState;
    // association Vertex.RedefinedVertex with Vertex.Vertex;
    // association State.DeferrableTrigger with Trigger.State;
    association ConnectionPointReference.State with State.Connection;
    // association State.Entry with Behavior.State;
    association Pseudostate.State with State.ConnectionPoint;
    // association State.DoActivity with Behavior.State;
    // association State.Exit with Behavior.State;
    // association Region.ExtendedRegion with Region.Region;
    association Region.Subvertex with Vertex.Container;
    // association Region.RedefinitionContext with Classifier.Region;
    association Region.Transition with Transition.Container;
    // association ProtocolTransition.Referred with Operation.ProtocolTransition;
    // association ProtocolTransition.PreCondition with Constraint.ProtocolTransition;
    // association ProtocolTransition.PostCondition with Constraint.OwningTransition;
    association ProtocolConformance.SpecificMachine with ProtocolStateMachine.Conformance;
    // association ProtocolConformance.GeneralMachine with ProtocolStateMachine.ProtocolConformance;
    // association ConnectionPointReference.Entry with Pseudostate.ConnectionPointReference;
    // association ConnectionPointReference.Exit with Pseudostate.ConnectionPointReference;
    // association Signal.OwnedAttribute with Property.OwningSignal;
    // association Reception.Signal with Signal.Reception;
    // association InterfaceRealization.Contract with Interface.InterfaceRealization;
    // association Interface.Protocol with ProtocolStateMachine.Interface;
    // association Interface.OwnedReception with Reception.Interface;
    // association Interface.RedefinedInterface with Interface.Interface;
    // association Interface.NestedClassifier with Classifier.Interface;
    association Interface.OwnedOperation with Operation.Interface;
    association Interface.OwnedAttribute with Property.Interface;
    // association EnumerationLiteral.Classifier with Enumeration.EnumerationLiteral;
    association Enumeration.OwnedLiteral with EnumerationLiteral.Enumeration;
    association DataType.OwnedAttribute with Property.Datatype;
    association DataType.OwnedOperation with Operation.Datatype;
    // association BehavioredClassifier.OwnedBehavior with Behavior.BehavioredClassifier;
    // association BehavioredClassifier.ClassifierBehavior with Behavior.BehavioredClassifier;
    association BehavioredClassifier.InterfaceRealization with InterfaceRealization.ImplementingClassifier;
    // association Stereotype.Profile with Profile.Stereotype;
    // association Stereotype.Icon with Image.Stereotype;
    // association ProfileApplication.AppliedProfile with Profile.ProfileApplication;
    // association Profile.MetaclassReference with ElementImport.Profile;
    // association Profile.MetamodelReference with PackageImport.Profile;
    // association PackageMerge.MergedPackage with Package.PackageMerge;
    // association Package.PackagedElement with PackageableElement.OwningPackage;
    association Package.PackageMerge with PackageMerge.ReceivingPackage;
    association Package.NestedPackage with Package.NestingPackage;
    association Package.ProfileApplication with ProfileApplication.ApplyingPackage;
    association Package.OwnedType with Type.Package;
    // association Package.OwnedStereotype with Stereotype.OwningPackage;
    // association ExtensionEnd.Type with Stereotype.ExtensionEnd;
    // association Extension.OwnedEnd with ExtensionEnd.Extension;
    // association StateInvariant.Invariant with Constraint.StateInvariant;
    // association StateInvariant.Covered with Lifeline.StateInvariant;
    // association OccurrenceSpecification.Covered with Lifeline.Events;
    association GeneralOrdering.After with OccurrenceSpecification.ToBefore;
    // association MessageEnd.Message with Message.MessageEnd;
    // association Message.Signature with NamedElement.Message;
    // association Message.Connector with Connector.Message;
    // association Message.ReceiveEvent with MessageEnd.EndMessage;
    // association Message.SendEvent with MessageEnd.EndMessage;
    // association Message.Argument with ValueSpecification.Message;
    // association Lifeline.Selector with ValueSpecification.Lifeline;
    // association Lifeline.DecomposedAs with PartDecomposition.Lifeline;
    /// <summary>
    /// If a Part has multiplicity, multiple lifelines might be used to show it.
    /// </summary>
    // association Lifeline.Represents with ConnectableElement.Lifeline;
    // association InteractionUse.ReturnValueRecipient with Property.InteractionUse;
    // association InteractionUse.RefersTo with Interaction.InteractionUse;
    // association InteractionUse.ReturnValue with ValueSpecification.InteractionUse;
    // association InteractionUse.Argument with ValueSpecification.InteractionUse;
    // association InteractionUse.ActualGate with Gate.InteractionUse;
    association InteractionFragment.EnclosingOperand with InteractionOperand.Fragment;
    // association InteractionOperand.Guard with InteractionConstraint.InteractionOperand;
    // association InteractionFragment.GeneralOrdering with GeneralOrdering.InteractionFragment;
    /// <summary>
    /// This association shows the lifelines that make up an interaction. A lifeline may be part of more than one interaction use.
    /// </summary>
    association InteractionFragment.Covered with Lifeline.CoveredBy;
    // association InteractionConstraint.Minint with ValueSpecification.InteractionConstraint;
    // association InteractionConstraint.Maxint with ValueSpecification.InteractionConstraint;
    // association Interaction.Action with Action.Interaction;
    // association Interaction.FormalGate with Gate.Interaction;
    association Interaction.Lifeline with Lifeline.Interaction;
    association Interaction.Fragment with InteractionFragment.EnclosingInteraction;
    association Interaction.Message with Message.Interaction;
    association GeneralOrdering.Before with OccurrenceSpecification.ToAfter;
    /// <summary>
    /// The event shows the time point at which the action completes execution.
    /// </summary>
    // association ExecutionSpecification.Finish with OccurrenceSpecification.ExecutionSpecification;
    /// <summary>
    /// The event shows the time point at which the action begins execution.
    /// </summary>
    // association ExecutionSpecification.Start with OccurrenceSpecification.ExecutionSpecification;
    // association ExecutionOccurrenceSpecification.Execution with ExecutionSpecification.ExecutionOccurrenceSpecification;
    // association ConsiderIgnoreFragment.Message with NamedElement.ConsiderIgnoreFragment;
    // association CombinedFragment.CfragmentGate with Gate.CombinedFragment;
    // association CombinedFragment.Operand with InteractionOperand.CombinedFragment;
    // association BehaviorExecutionSpecification.Behavior with Behavior.BehaviorExecutionSpecification;
    // association ActionExecutionSpecification.Action with Action.ActionExecutionSpecification;
    // association InformationItem.Represented with Classifier.Representation;
    // association InformationFlow.Conveyed with Classifier.ConveyingFlow;
    // association InformationFlow.RealizingActivityEdge with ActivityEdge.InformationFlow;
    // association InformationFlow.RealizingMessage with Message.InformationFlow;
    // association InformationFlow.InformationSource with NamedElement.InformationFlow;
    // association InformationFlow.Realization with Relationship.Abstraction;
    // association InformationFlow.RealizingConnector with Connector.InformationFlow;
    // association InformationFlow.InformationTarget with NamedElement.InformationFlow;
    // association Node.NestedNode with Node.Node;
    // association Manifestation.UtilizedElement with PackageableElement.Manifestation;
    // association DeploymentTarget.DeployedElement with PackageableElement.DeploymentTarget;
    association Deployment.Location with DeploymentTarget.Deployment;
    // association Deployment.DeployedArtifact with DeployedArtifact.DeploymentForArtifact;
    association Deployment.Configuration with DeploymentSpecification.Deployment;
    // association Artifact.OwnedAttribute with Property.Artifact;
    // association Artifact.OwnedOperation with Operation.Artifact;
    // association Artifact.NestedArtifact with Artifact.Artifact;
    // association Artifact.Manifestation with Manifestation.Artifact;
    // association TypedElement.Type with Type.TypedElement;
    association TemplateParameter.Signature with TemplateSignature.OwnedParameter;
    // association TemplateSignature.Parameter with TemplateParameter.TemplateSignature;
    // association TemplateParameterSubstitution.Actual with ParameterableElement.TemplateParameterSubstitution;
    // association TemplateParameterSubstitution.OwnedActual with ParameterableElement.OwningTemplateParameterSubstitution;
    // association TemplateParameterSubstitution.Formal with TemplateParameter.TemplateParameterSubstitution;
    // association TemplateParameter.OwnedDefault with ParameterableElement.TemplateParameter;
    association ParameterableElement.OwningTemplateParameter with TemplateParameter.OwnedParameteredElement;
    // association TemplateParameter.Default with ParameterableElement.TemplateParameter;
    association ParameterableElement.TemplateParameter with TemplateParameter.ParameteredElement;
    // association TemplateBinding.Signature with TemplateSignature.TemplateBinding;
    association TemplateBinding.ParameterSubstitution with TemplateParameterSubstitution.TemplateBinding;
    association TemplateableElement.TemplateBinding with TemplateBinding.BoundElement;
    association TemplateableElement.OwnedTemplateSignature with TemplateSignature.Template;
    // association Relationship.RelatedElement with Element.Relationship;
    // association PackageImport.ImportedPackage with Package.PackageImport;
    association ElementImport.ImportingNamespace with Namespace.ElementImport;
    association NamedElement.Namespace with Namespace.OwnedMember;
    association Constraint.Context with Namespace.OwnedRule;
    association Namespace.PackageImport with PackageImport.ImportingNamespace;
    // association Namespace.Member with NamedElement.MemberNamespace;
    // association Namespace.ImportedMember with PackageableElement.Namespace;
    // association NamedElement.NameExpression with StringExpression.NamedElement;
    association Dependency.Client with NamedElement.ClientDependency;
    // association MultiplicityElement.LowerValue with ValueSpecification.OwningLower;
    // association MultiplicityElement.UpperValue with ValueSpecification.OwningUpper;
    // association ElementImport.ImportedElement with PackageableElement.Import;
    association Element.OwnedElement with Element.Owner;
    // association Element.OwnedComment with Comment.OwningElement;
    // association DirectedRelationship.Source with Element.DirectedRelationship;
    // association DirectedRelationship.Target with Element.DirectedRelationship;
    // association Dependency.Supplier with NamedElement.SupplierDependency;
    // association Constraint.ConstrainedElement with Element.Constraint;
    // association Constraint.Specification with ValueSpecification.OwningConstraint;
    // association Comment.AnnotatedElement with Element.Comment;
    // association Abstraction.Mapping with OpaqueExpression.Abstraction;
    // association Trigger.Event with Event.Trigger;
    // association Trigger.Port with Port.Trigger;
    // association TimeEvent.When with TimeExpression.TimeEvent;
    // association SignalEvent.Signal with Signal.SignalEvent;
    // association ChangeEvent.ChangeExpression with ValueSpecification.ChangeEvent;
    // association CallEvent.Operation with Operation.CallEvent;
    // association Behavior.OwnedParameterSet with ParameterSet.Behavior;
    // association Behavior.Context with BehavioredClassifier.Behavior;
    // association Behavior.Precondition with Constraint.Behavior;
    // association Behavior.Postcondition with Constraint.Behavior;
    // association Behavior.RedefinedBehavior with Behavior.Behavior;
    // association Behavior.OwnedParameter with Parameter.Behavior;
    // association Slot.DefiningFeature with StructuralFeature.Slot;
    // association Slot.Value with ValueSpecification.OwningSlot;
    // association RedefinableTemplateSignature.ExtendedSignature with RedefinableTemplateSignature.RedefinableTemplateSignature;
    // association RedefinableTemplateSignature.InheritedParameter with TemplateParameter.RedefinableTemplateSignature;
    // association RedefinableElement.RedefinitionContext with Classifier.RedefinableElement;
    // association RedefinableElement.RedefinedElement with RedefinableElement.RedefinableElement;
    association Property.AssociationEnd with Property.Qualifier;
    // association Property.RedefinedProperty with Property.Property;
    // association Property.DefaultValue with ValueSpecification.OwningProperty;
    // association Property.Opposite with Property.Property;
    // association Property.SubsettedProperty with Property.Property;
    // association ParameterSet.Condition with Constraint.ParameterSet;
    association Parameter.ParameterSet with ParameterSet.Parameter;
    // association Parameter.DefaultValue with ValueSpecification.OwningParameter;
    // association Operation.Type with Type.Operation;
    association Operation.TemplateParameter with OperationTemplateParameter.ParameteredElement;
    // association Operation.BodyCondition with Constraint.BodyContext;
    // association Operation.Postcondition with Constraint.PostContext;
    // association Operation.RedefinedOperation with Operation.Operation;
    // association Operation.RaisedException with Type.Operation;
    // association Operation.Precondition with Constraint.PreContext;
    association Operation.OwnedParameter with Parameter.Operation;
    // association InstanceValue.Instance with InstanceSpecification.InstanceValue;
    // association InstanceSpecification.Classifier with Classifier.InstanceSpecification;
    association InstanceSpecification.Slot with Slot.OwningInstance;
    // association InstanceSpecification.Specification with ValueSpecification.OwningInstanceSpec;
    association Generalization.GeneralizationSet with GeneralizationSet.Generalization;
    // association Generalization.General with Classifier.Generalization;
    // association ClassifierTemplateParameter.ConstrainingClassifier with Classifier.ClassifierTemplateParameter;
    association Classifier.TemplateParameter with ClassifierTemplateParameter.ParameteredElement;
    association Classifier.PowertypeExtent with GeneralizationSet.Powertype;
    association Classifier.Generalization with Generalization.Specific;
    // association Classifier.General with Classifier.Classifier;
    association Classifier.Feature with Feature.FeaturingClassifier;
    association Substitution.SubstitutingClassifier with Classifier.Substitution;
    // association Classifier.Representation with CollaborationUse.Classifier;
    association Classifier.OwnedTemplateSignature with RedefinableTemplateSignature.Classifier;
    // association Classifier.InheritedMember with NamedElement.InheritingClassifier;
    // association Classifier.RedefinedClassifier with Classifier.Classifier;
    // association Classifier.CollaborationUse with CollaborationUse.Classifier;
    // association Classifier.Attribute with Property.Classifier;
    // association Classifier.OwnedUseCase with UseCase.Classifier;
    // association BehavioralFeature.OwnedParameter with Parameter.OwnerFormalParam;
    // association BehavioralFeature.RaisedException with Type.BehavioralFeature;
    // association BehavioralFeature.OwnedParameterSet with ParameterSet.BehavioralFeature;
    association Behavior.Specification with BehavioralFeature.Method;
    // association Substitution.Contract with Classifier.Substitution;
    // association ValuePin.Value with ValueSpecification.ValuePin;
    // association UnmarshallAction.Result with OutputPin.UnmarshallAction;
    // association UnmarshallAction.UnmarshallType with Classifier.UnmarshallAction;
    // association UnmarshallAction.Object with InputPin.UnmarshallAction;
    // association TestIdentityAction.First with InputPin.TestIdentityAction;
    // association TestIdentityAction.Second with InputPin.TestIdentityAction;
    // association TestIdentityAction.Result with OutputPin.TestIdentityAction;
    // association StructuredActivityNode.StructuredNodeOutput with OutputPin.StructuredActivityNode;
    // association StructuredActivityNode.StructuredNodeInput with InputPin.StructuredActivityNode;
    association ActivityEdge.InStructuredNode with StructuredActivityNode.Edge;
    association ActivityNode.InStructuredNode with StructuredActivityNode.Node;
    association Variable.Scope with StructuredActivityNode.Variable;
    // association StructuralFeatureAction.Object with InputPin.StructuralFeatureAction;
    // association StructuralFeatureAction.StructuralFeature with StructuralFeature.StructuralFeatureAction;
    // association StartObjectBehaviorAction.Object with InputPin.StartObjectBehaviorAction;
    // association StartClassifierBehaviorAction.Object with InputPin.StartClassifierBehaviorAction;
    // association SequenceNode.ExecutableNode with ExecutableNode.SequenceNode;
    // association SendSignalAction.Signal with Signal.SendSignalAction;
    // association SendSignalAction.Target with InputPin.SendSignalAction;
    // association SendObjectAction.Request with InputPin.SendObjectAction;
    // association SendObjectAction.Target with InputPin.SendObjectAction;
    // association ReplyAction.ReturnInformation with InputPin.ReplyAction;
    // association ReplyAction.ReplyToCall with Trigger.ReplyAction;
    // association ReplyAction.ReplyValue with InputPin.ReplyAction;
    // association RemoveVariableValueAction.RemoveAt with InputPin.RemoveVariableValueAction;
    // association RemoveStructuralFeatureValueAction.RemoveAt with InputPin.RemoveStructuralFeatureValueAction;
    // association ReduceAction.Collection with InputPin.ReduceAction;
    // association ReduceAction.Reducer with Behavior.ReduceAction;
    // association ReduceAction.Result with OutputPin.ReduceAction;
    // association ReclassifyObjectAction.Object with InputPin.ReclassifyObjectAction;
    // association ReclassifyObjectAction.NewClassifier with Classifier.ReclassifyObjectAction;
    // association ReclassifyObjectAction.OldClassifier with Classifier.ReclassifyObjectAction;
    // association ReadVariableAction.Result with OutputPin.ReadVariableAction;
    // association ReadStructuralFeatureAction.Result with OutputPin.ReadStructuralFeatureAction;
    // association ReadSelfAction.Result with OutputPin.ReadSelfAction;
    // association ReadLinkObjectEndQualifierAction.Qualifier with Property.ReadLinkObjectEndQualifierAction;
    // association ReadLinkObjectEndQualifierAction.Object with InputPin.ReadLinkObjectEndQualifierAction;
    // association ReadLinkObjectEndQualifierAction.Result with OutputPin.ReadLinkObjectEndQualifierAction;
    // association ReadLinkObjectEndAction.Object with InputPin.ReadLinkObjectEndAction;
    // association ReadLinkObjectEndAction.End with Property.ReadLinkObjectEndAction;
    // association ReadLinkObjectEndAction.Result with OutputPin.ReadLinkObjectEndAction;
    // association ReadLinkAction.Result with OutputPin.ReadLinkAction;
    // association ReadIsClassifiedObjectAction.Classifier with Classifier.ReadIsClassifiedObjectAction;
    // association ReadIsClassifiedObjectAction.Result with OutputPin.ReadIsClassifiedObjectAction;
    // association ReadIsClassifiedObjectAction.Object with InputPin.ReadIsClassifiedObjectAction;
    // association ReadExtentAction.Result with OutputPin.ReadExtentAction;
    // association ReadExtentAction.Classifier with Classifier.ReadExtentAction;
    // association RaiseExceptionAction.Exception with InputPin.RaiseExceptionAction;
    // association QualifierValue.Qualifier with Property.QualifierValue;
    // association QualifierValue.Value with InputPin.QualifierValue;
    // association OpaqueAction.OutputValue with OutputPin.OpaqueAction;
    // association OpaqueAction.InputValue with InputPin.OpaqueAction;
    // association LoopNode.SetupPart with ExecutableNode.LoopNode;
    // association LoopNode.BodyPart with ExecutableNode.LoopNode;
    // association LoopNode.LoopVariable with OutputPin.LoopNode;
    // association LoopNode.Result with OutputPin.LoopNode;
    // association LoopNode.BodyOutput with OutputPin.LoopNode;
    // association LoopNode.LoopVariableInput with InputPin.LoopNode;
    // association LoopNode.Test with ExecutableNode.LoopNode;
    // association LoopNode.Decider with OutputPin.LoopNode;
    // association LinkEndDestructionData.DestroyAt with InputPin.LinkEndDestructionData;
    // association LinkEndData.Value with InputPin.LinkEndData;
    // association LinkEndData.End with Property.LinkEndData;
    // association LinkEndData.Qualifier with QualifierValue.LinkEndData;
    // association LinkEndCreationData.InsertAt with InputPin.LinkEndCreationData;
    // association LinkAction.InputValue with InputPin.LinkAction;
    // association LinkAction.EndData with LinkEndData.LinkAction;
    // association InvocationAction.Argument with InputPin.InvocationAction;
    // association InvocationAction.OnPort with Port.InvocationAction;
    association ExpansionNode.RegionAsInput with ExpansionRegion.InputElement;
    association ExpansionNode.RegionAsOutput with ExpansionRegion.OutputElement;
    // association DestroyObjectAction.Target with InputPin.DestroyObjectAction;
    // association DestroyLinkAction.EndData with LinkEndDestructionData.DestroyLinkAction;
    // association CreateObjectAction.Classifier with Classifier.CreateObjectAction;
    // association CreateObjectAction.Result with OutputPin.CreateObjectAction;
    // association CreateLinkObjectAction.Result with OutputPin.CreateLinkObjectAction;
    // association CreateLinkAction.EndData with LinkEndCreationData.CreateLinkAction;
    // association ConditionalNode.Clause with Clause.ConditionalNode;
    // association ConditionalNode.Result with OutputPin.ConditionalNode;
    // association ClearStructuralFeatureAction.Result with OutputPin.ClearStructuralFeatureAction;
    // association ClearAssociationAction.Object with InputPin.ClearAssociationAction;
    // association ClearAssociationAction.Association with Association.ClearAssociationAction;
    // association Clause.Decider with OutputPin.Clause;
    // association Clause.BodyOutput with OutputPin.Clause;
    // association Clause.Test with ExecutableNode.Clause;
    // association Clause.Body with ExecutableNode.Clause;
    association Clause.PredecessorClause with Clause.SuccessorClause;
    // association CallOperationAction.Target with InputPin.CallOperationAction;
    // association CallOperationAction.Operation with Operation.CallOperationAction;
    // association CallBehaviorAction.Behavior with Behavior.CallBehaviorAction;
    // association CallAction.Result with OutputPin.CallAction;
    // association BroadcastSignalAction.Signal with Signal.BroadcastSignalAction;
    // association AddVariableValueAction.InsertAt with InputPin.AddVariableValueAction;
    // association AddStructuralFeatureValueAction.InsertAt with InputPin.AddStructuralFeatureValueAction;
    // association ActionInputPin.FromAction with Action.ActionInputPin;
    // association Action.Output with OutputPin.Action;
    // association Action.Context with Classifier.Action;
    // association Action.Input with InputPin.Action;
    // association Action.LocalPrecondition with Constraint.Action;
    // association Action.LocalPostcondition with Constraint.Action;
    // association AcceptEventAction.Trigger with Trigger.AcceptEventAction;
    // association AcceptEventAction.Result with OutputPin.AcceptEventAction;
    // association AcceptCallAction.ReturnInformation with OutputPin.AcceptCallAction;
    // association WriteVariableAction.Value with InputPin.WriteVariableAction;
    // association WriteStructuralFeatureAction.Result with OutputPin.WriteStructuralFeatureAction;
    // association WriteStructuralFeatureAction.Value with InputPin.WriteStructuralFeatureAction;
    // association VariableAction.Variable with Variable.VariableAction;
    // association ValueSpecificationAction.Result with OutputPin.ValueSpecificationAction;
    // association ValueSpecificationAction.Value with ValueSpecification.ValueSpecificationAction;

	// MetaDslx:
	association Connector.End with ConnectorEnd.Connector;
	association Interaction.Action with Action.Interaction;
	association CombinedFragment.CfragmentGate with Gate.CombinedFragment;
	association CombinedFragment.Operand with InteractionOperand.CombinedFragment;
	association InteractionUse.ActualGate with Gate.InteractionUse;
	association Interaction.FormalGate with Gate.Interaction;
	association Class.NestedClassifier with Classifier.NestingClass;
}

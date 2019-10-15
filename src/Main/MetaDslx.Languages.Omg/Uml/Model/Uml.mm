namespace MetaDslx.Languages.Uml.Model
{
    metamodel Uml(Uri="http://www.omg.org/spec/UML/20161101"); 


    /*
    ObjectNodeOrderingKind is an enumeration indicating queuing order for offering the tokens held by an ObjectNode.
    */
    enum ObjectNodeOrderingKind
    {
        /*
        Indicates that tokens are unordered.
        */
        Unordered,
        /*
        Indicates that tokens are ordered.
        */
        Ordered,
        /*
        Indicates that tokens are queued in a last in, first out manner.
        */
        LIFO,
        /*
        Indicates that tokens are queued in a first in, first out manner.
        */
        FIFO
    }

    /*
    ConnectorKind is an enumeration that defines whether a Connector is an assembly or a delegation.
    */
    enum ConnectorKind
    {
        /*
        Indicates that the Connector is an assembly Connector.
        */
        Assembly,
        /*
        Indicates that the Connector is a delegation Connector.
        */
        Delegation
    }

    /*
    PseudostateKind is an Enumeration type that is used to differentiate various kinds of Pseudostates.
    */
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

    /*
    TransitionKind is an Enumeration type used to differentiate the various kinds of Transitions.
    */
    enum TransitionKind
    {
        /*
        Implies that the Transition, if triggered, occurs without exiting or entering the source State (i.e., it does not cause a state change). This means that the entry or exit condition of the source State will not be invoked. An internal Transition can be taken even if the SateMachine is in one or more Regions nested within the associated State.
        */
        Internal,
        /*
        Implies that the Transition, if triggered, will not exit the composite (source) State, but it will exit and re-enter any state within the composite State that is in the current state configuration.
        */
        Local,
        /*
        Implies that the Transition, if triggered, will exit the composite (source) State.
        */
        External
    }

    /*
    InteractionOperatorKind is an enumeration designating the different kinds of operators of CombinedFragments. The InteractionOperand defines the type of operator of a CombinedFragment.
    */
    enum InteractionOperatorKind
    {
        /*
        The InteractionOperatorKind seq designates that the CombinedFragment represents a weak sequencing between the behaviors of the operands.
        */
        Seq,
        /*
        The InteractionOperatorKind alt designates that the CombinedFragment represents a choice of behavior. At most one of the operands will be chosen. The chosen operand must have an explicit or implicit guard expression that evaluates to true at this point in the interaction. An implicit true guard is implied if the operand has no guard.
        */
        Alt,
        /*
        The InteractionOperatorKind opt designates that the CombinedFragment represents a choice of behavior where either the (sole) operand happens or nothing happens. An option is semantically equivalent to an alternative CombinedFragment where there is one operand with non-empty content and the second operand is empty.
        */
        Opt,
        /*
        The InteractionOperatorKind break designates that the CombinedFragment represents a breaking scenario in the sense that the operand is a scenario that is performed instead of the remainder of the enclosing InteractionFragment. A break operator with a guard is chosen when the guard is true and the rest of the enclosing Interaction Fragment is ignored. When the guard of the break operand is false, the break operand is ignored and the rest of the enclosing InteractionFragment is chosen. The choice between a break operand without a guard and the rest of the enclosing InteractionFragment is done non-deterministically.
        */
        Break,
        /*
        The InteractionOperatorKind par designates that the CombinedFragment represents a parallel merge between the behaviors of the operands. The OccurrenceSpecifications of the different operands can be interleaved in any way as long as the ordering imposed by each operand as such is preserved.
        */
        Par,
        /*
        The InteractionOperatorKind strict designates that the CombinedFragment represents a strict sequencing between the behaviors of the operands. The semantics of strict sequencing defines a strict ordering of the operands on the first level within the CombinedFragment with interactionOperator strict. Therefore OccurrenceSpecifications within contained CombinedFragment will not directly be compared with other OccurrenceSpecifications of the enclosing CombinedFragment.
        */
        Strict,
        /*
        The InteractionOperatorKind loop designates that the CombinedFragment represents a loop. The loop operand will be repeated a number of times.
        */
        Loop,
        /*
        The InteractionOperatorKind critical designates that the CombinedFragment represents a critical region. A critical region means that the traces of the region cannot be interleaved by other OccurrenceSpecifications (on those Lifelines covered by the region). This means that the region is treated atomically by the enclosing fragment when determining the set of valid traces. Even though enclosing CombinedFragments may imply that some OccurrenceSpecifications may interleave into the region, such as with par-operator, this is prevented by defining a region.
        */
        Critical,
        /*
        The InteractionOperatorKind neg designates that the CombinedFragment represents traces that are defined to be invalid.
        */
        Neg,
        /*
        The InteractionOperatorKind assert designates that the CombinedFragment represents an assertion. The sequences of the operand of the assertion are the only valid continuations. All other continuations result in an invalid trace.
        */
        Assert,
        /*
        The InteractionOperatorKind ignore designates that there are some message types that are not shown within this combined fragment. These message types can be considered insignificant and are implicitly ignored if they appear in a corresponding execution. Alternatively, one can understand ignore to mean that the message types that are ignored can appear anywhere in the traces.
        */
        Ignore,
        /*
        The InteractionOperatorKind consider designates which messages should be considered within this combined fragment. This is equivalent to defining every other message to be ignored.
        */
        Consider
    }

    /*
    This is an enumerated type that identifies the type of Message.
    */
    enum MessageKind
    {
        /*
        sendEvent and receiveEvent are present
        */
        Complete,
        /*
        sendEvent present and receiveEvent absent
        */
        Lost,
        /*
        sendEvent absent and receiveEvent present
        */
        Found,
        /*
        sendEvent and receiveEvent absent (should not appear)
        */
        Unknown
    }

    /*
    This is an enumerated type that identifies the type of communication action that was used to generate the Message.
    */
    enum MessageSort
    {
        /*
        The message was generated by a synchronous call to an operation.
        */
        SynchCall,
        /*
        The message was generated by an asynchronous call to an operation; i.e., a CallAction with isSynchronous = false.
        */
        AsynchCall,
        /*
        The message was generated by an asynchronous send action.
        */
        AsynchSignal,
        /*
        The message designating the creation of another lifeline object.
        */
        CreateMessage,
        /*
        The message designating the termination of another lifeline.
        */
        DeleteMessage,
        /*
        The message is a reply message to an operation call.
        */
        Reply
    }

    /*
    VisibilityKind is an enumeration type that defines literals to determine the visibility of Elements in a model.
    */
    enum VisibilityKind
    {
        /*
        A Named Element with public visibility is visible to all elements that can access the contents of the Namespace that owns it.
        */
        Public,
        /*
        A NamedElement with private visibility is only visible inside the Namespace that owns it.
        */
        Private,
        /*
        A NamedElement with protected visibility is visible to Elements that have a generalization relationship to the Namespace that owns it.
        */
        Protected,
        /*
        A NamedElement with package visibility is visible to all Elements within the nearest enclosing Package (given that other owning Elements have proper visibility). Outside the nearest enclosing Package, a NamedElement marked as having package visibility is not visible.  Only NamedElements that are not owned by Packages can be marked as having package visibility. 
        */
        Package
    }

    /*
    AggregationKind is an Enumeration for specifying the kind of aggregation of a Property.
    */
    enum AggregationKind
    {
        /*
        Indicates that the Property has no aggregation.
        */
        None,
        /*
        Indicates that the Property has shared aggregation.
        */
        Shared,
        /*
        Indicates that the Property is aggregated compositely, i.e., the composite object has responsibility for the existence and storage of the composed objects (parts).
        */
        Composite
    }

    /*
    CallConcurrencyKind is an Enumeration used to specify the semantics of concurrent calls to a BehavioralFeature.
    */
    enum CallConcurrencyKind
    {
        /*
        No concurrency management mechanism is associated with the BehavioralFeature and, therefore, concurrency conflicts may occur. Instances that invoke a BehavioralFeature need to coordinate so that only one invocation to a target on any BehavioralFeature occurs at once.
        */
        Sequential,
        /*
        Multiple invocations of a BehavioralFeature that overlap in time may occur to one instance, but only one is allowed to commence. The others are blocked until the performance of the currently executing BehavioralFeature is complete. It is the responsibility of the system designer to ensure that deadlocks do not occur due to simultaneous blocking.
        */
        Guarded,
        /*
        Multiple invocations of a BehavioralFeature that overlap in time may occur to one instance and all of them may proceed concurrently.
        */
        Concurrent
    }

    /*
    ParameterDirectionKind is an Enumeration that defines literals used to specify direction of parameters.
    */
    enum ParameterDirectionKind
    {
        /*
        Indicates that Parameter values are passed in by the caller. 
        */
        In,
        /*
        Indicates that Parameter values are passed in by the caller and (possibly different) values passed out to the caller.
        */
        Inout,
        /*
        Indicates that Parameter values are passed out to the caller.
        */
        Out,
        /*
        Indicates that Parameter values are passed as return values back to the caller.
        */
        Return
    }

    /*
    ParameterEffectKind is an Enumeration that indicates the effect of a Behavior on values passed in or out of its parameters.
    */
    enum ParameterEffectKind
    {
        /*
        Indicates that the behavior creates values.
        */
        Create,
        /*
        Indicates objects that are values of the parameter have values of their properties, or links in which they participate, or their classifiers retrieved during executions of the behavior.
        */
        Read,
        /*
        Indicates objects that are values of the parameter have values of their properties, or links in which they participate, or their classification changed during executions of the behavior.
        */
        Update,
        /*
        Indicates objects that are values of the parameter do not exist after executions of the behavior are finished.
        */
        Delete
    }

    /*
    ExpansionKind is an enumeration type used to specify how an ExpansionRegion executes its contents.
    */
    enum ExpansionKind
    {
        /*
        The content of the ExpansionRegion is executed concurrently for the elements of the input collections.
        */
        Parallel,
        /*
        The content of the ExpansionRegion is executed iteratively for the elements of the input collections, in the order of the input elements, if the collections are ordered.
        */
        Iterative,
        /*
        A stream of input collection elements flows into a single execution of the content of the ExpansionRegion, in the order of the collection elements if the input collections are ordered.
        */
        Stream
    }

    /*
    An Activity is the specification of parameterized Behavior as the coordinated sequencing of subordinate units.
    */
    class Activity : Behavior
    {
    	/*
    	ActivityEdges expressing flow between the nodes of the Activity.
    	*/
    	set<ActivityEdge> Edge subsets Element.OwnedElement;
    	/*
    	Top-level ActivityGroups in the Activity.
    	*/
    	set<ActivityGroup> Group subsets Element.OwnedElement;
    	/*
    	If true, this Activity must not make any changes to objects. The default is false (an Activity may make nonlocal changes). (This is an assertion, not an executable property. It may be used by an execution engine to optimize model execution. If the assertion is violated by the Activity, then the model is ill-formed.) 
    	*/
    	bool IsReadOnly;
    	/*
    	If true, all invocations of the Activity are handled by the same execution.
    	*/
    	bool IsSingleExecution;
    	/*
    	ActivityNodes coordinated by the Activity.
    	*/
    	set<ActivityNode> Node subsets Element.OwnedElement;
    	/*
    	Top-level ActivityPartitions in the Activity.
    	*/
    	set<ActivityPartition> Partition subsets Activity.Group;
    	/*
    	Top-level StructuredActivityNodes in the Activity.
    	*/
    	set<StructuredActivityNode> StructuredNode subsets Activity.Group, Activity.Node;
    	/*
    	Top-level Variables defined by the Activity.
    	*/
    	set<Variable> Variable subsets Namespace.OwnedMember;
    }

    /*
    An ActivityEdge is an abstract class for directed connections between two ActivityNodes.
    */
    abstract class ActivityEdge : RedefinableElement
    {
    	/*
    	The Activity containing the ActivityEdge, if it is directly owned by an Activity.
    	*/
    	Activity Activity subsets Element.Owner;
    	/*
    	A ValueSpecification that is evaluated to determine if a token can traverse the ActivityEdge. If an ActivityEdge has no guard, then there is no restriction on tokens traversing the edge.
    	*/
    	ValueSpecification Guard subsets Element.OwnedElement;
    	/*
    	ActivityGroups containing the ActivityEdge.
    	*/
    	union set<ActivityGroup> InGroup;
    	/*
    	ActivityPartitions containing the ActivityEdge.
    	*/
    	set<ActivityPartition> InPartition subsets ActivityEdge.InGroup;
    	/*
    	The StructuredActivityNode containing the ActivityEdge, if it is owned by a StructuredActivityNode.
    	*/
    	StructuredActivityNode InStructuredNode subsets ActivityEdge.InGroup, Element.Owner;
    	/*
    	The InterruptibleActivityRegion for which this ActivityEdge is an interruptingEdge.
    	*/
    	InterruptibleActivityRegion Interrupts;
    	/*
    	ActivityEdges from a generalization of the Activity containing this ActivityEdge that are redefined by this ActivityEdge.
    	*/
    	set<ActivityEdge> RedefinedEdge subsets RedefinableElement.RedefinedElement;
    	/*
    	The ActivityNode from which tokens are taken when they traverse the ActivityEdge.
    	*/
    	ActivityNode Source;
    	/*
    	The ActivityNode to which tokens are put when they traverse the ActivityEdge.
    	*/
    	ActivityNode Target;
    	/*
    	The minimum number of tokens that must traverse the ActivityEdge at the same time. If no weight is specified, this is equivalent to specifying a constant value of 1.
    	*/
    	ValueSpecification Weight subsets Element.OwnedElement;
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    An ActivityFinalNode is a FinalNode that terminates the execution of its owning Activity or StructuredActivityNode.
    */
    class ActivityFinalNode : FinalNode
    {
    }

    /*
    ActivityGroup is an abstract class for defining sets of ActivityNodes and ActivityEdges in an Activity.
    */
    abstract class ActivityGroup : NamedElement
    {
    	/*
    	ActivityEdges immediately contained in the ActivityGroup.
    	*/
    	union set<ActivityEdge> ContainedEdge;
    	/*
    	ActivityNodes immediately contained in the ActivityGroup.
    	*/
    	union set<ActivityNode> ContainedNode;
    	/*
    	The Activity containing the ActivityGroup, if it is directly owned by an Activity.
    	*/
    	Activity InActivity subsets Element.Owner;
    	/*
    	Other ActivityGroups immediately contained in this ActivityGroup.
    	*/
    	union set<ActivityGroup> Subgroup subsets Element.OwnedElement;
    	/*
    	The ActivityGroup immediately containing this ActivityGroup, if it is directly owned by another ActivityGroup.
    	*/
    	union ActivityGroup SuperGroup subsets Element.Owner;
    	/*
    	The Activity that directly or indirectly contains this ActivityGroup.
    	
    	spec:
    	    result = (if superGroup<>null then superGroup.containingActivity()
    	    else inActivity
    	    endif)
    	*/
    	Activity ContainingActivity();
    }

    /*
    ActivityNode is an abstract class for points in the flow of an Activity connected by ActivityEdges.
    */
    abstract class ActivityNode : RedefinableElement
    {
    	/*
    	The Activity containing the ActivityNode, if it is directly owned by an Activity.
    	*/
    	Activity Activity subsets Element.Owner;
    	/*
    	ActivityGroups containing the ActivityNode.
    	*/
    	union set<ActivityGroup> InGroup;
    	/*
    	InterruptibleActivityRegions containing the ActivityNode.
    	*/
    	set<InterruptibleActivityRegion> InInterruptibleRegion subsets ActivityNode.InGroup;
    	/*
    	ActivityPartitions containing the ActivityNode.
    	*/
    	set<ActivityPartition> InPartition subsets ActivityNode.InGroup;
    	/*
    	The StructuredActivityNode containing the ActvityNode, if it is directly owned by a StructuredActivityNode.
    	*/
    	StructuredActivityNode InStructuredNode subsets ActivityNode.InGroup, Element.Owner;
    	/*
    	ActivityEdges that have the ActivityNode as their target.
    	*/
    	set<ActivityEdge> Incoming;
    	/*
    	ActivityEdges that have the ActivityNode as their source.
    	*/
    	set<ActivityEdge> Outgoing;
    	/*
    	ActivityNodes from a generalization of the Activity containining this ActivityNode that are redefined by this ActivityNode.
    	*/
    	set<ActivityNode> RedefinedNode subsets RedefinableElement.RedefinedElement;
    	/*
    	The Activity that directly or indirectly contains this ActivityNode.
    	
    	spec:
    	    result = (if inStructuredNode<>null then inStructuredNode.containingActivity()
    	    else activity
    	    endif)
    	*/
    	Activity ContainingActivity();
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    An ActivityParameterNode is an ObjectNode for accepting values from the input Parameters or providing values to the output Parameters of an Activity.
    */
    class ActivityParameterNode : ObjectNode
    {
    	/*
    	The Parameter for which the ActivityParameterNode will be accepting or providing values.
    	*/
    	Parameter Parameter;
    }

    /*
    An ActivityPartition is a kind of ActivityGroup for identifying ActivityNodes that have some characteristic in common.
    */
    class ActivityPartition : ActivityGroup
    {
    	/*
    	ActivityEdges immediately contained in the ActivityPartition.
    	*/
    	set<ActivityEdge> Edge subsets ActivityGroup.ContainedEdge;
    	/*
    	Indicates whether the ActivityPartition groups other ActivityPartitions along a dimension.
    	*/
    	bool IsDimension;
    	/*
    	Indicates whether the ActivityPartition represents an entity to which the partitioning structure does not apply.
    	*/
    	bool IsExternal;
    	/*
    	ActivityNodes immediately contained in the ActivityPartition.
    	*/
    	set<ActivityNode> Node subsets ActivityGroup.ContainedNode;
    	/*
    	An Element represented by the functionality modeled within the ActivityPartition.
    	*/
    	Element Represents;
    	/*
    	Other ActivityPartitions immediately contained in this ActivityPartition (as its subgroups).
    	*/
    	set<ActivityPartition> Subpartition subsets ActivityGroup.Subgroup;
    	/*
    	Other ActivityPartitions immediately containing this ActivityPartition (as its superGroups).
    	*/
    	ActivityPartition SuperPartition subsets ActivityGroup.SuperGroup;
    }

    /*
    A CentralBufferNode is an ObjectNode for managing flows from multiple sources and targets.
    */
    class CentralBufferNode : ObjectNode
    {
    }

    /*
    A ControlFlow is an ActivityEdge traversed by control tokens or object tokens of control type, which are use to control the execution of ExecutableNodes.
    */
    class ControlFlow : ActivityEdge
    {
    }

    /*
    A ControlNode is an abstract ActivityNode that coordinates flows in an Activity.
    */
    abstract class ControlNode : ActivityNode
    {
    }

    /*
    A DataStoreNode is a CentralBufferNode for persistent data.
    */
    class DataStoreNode : CentralBufferNode
    {
    }

    /*
    A DecisionNode is a ControlNode that chooses between outgoing ActivityEdges for the routing of tokens.
    */
    class DecisionNode : ControlNode
    {
    	/*
    	A Behavior that is executed to provide an input to guard ValueSpecifications on ActivityEdges outgoing from the DecisionNode.
    	*/
    	Behavior DecisionInput;
    	/*
    	An additional ActivityEdge incoming to the DecisionNode that provides a decision input value for the guards ValueSpecifications on ActivityEdges outgoing from the DecisionNode.
    	*/
    	ObjectFlow DecisionInputFlow;
    }

    /*
    An ExceptionHandler is an Element that specifies a handlerBody ExecutableNode to execute in case the specified exception occurs during the execution of the protected ExecutableNode.
    */
    class ExceptionHandler : Element
    {
    	/*
    	An ObjectNode within the handlerBody. When the ExceptionHandler catches an exception, the exception token is placed on this ObjectNode, causing the handlerBody to execute.
    	*/
    	ObjectNode ExceptionInput;
    	/*
    	The Classifiers whose instances the ExceptionHandler catches as exceptions. If an exception occurs whose type is any exceptionType, the ExceptionHandler catches the exception and executes the handlerBody.
    	*/
    	set<Classifier> ExceptionType;
    	/*
    	An ExecutableNode that is executed if the ExceptionHandler catches an exception.
    	*/
    	ExecutableNode HandlerBody;
    	/*
    	The ExecutableNode protected by the ExceptionHandler. If an exception propagates out of the protectedNode and has a type matching one of the exceptionTypes, then it is caught by this ExceptionHandler.
    	*/
    	ExecutableNode ProtectedNode subsets Element.Owner;
    }

    /*
    An ExecutableNode is an abstract class for ActivityNodes whose execution may be controlled using ControlFlows and to which ExceptionHandlers may be attached.
    */
    abstract class ExecutableNode : ActivityNode
    {
    	/*
    	A set of ExceptionHandlers that are examined if an exception propagates out of the ExceptionNode.
    	*/
    	set<ExceptionHandler> Handler subsets Element.OwnedElement;
    }

    /*
    A FinalNode is an abstract ControlNode at which a flow in an Activity stops.
    */
    abstract class FinalNode : ControlNode
    {
    }

    /*
    A FlowFinalNode is a FinalNode that terminates a flow by consuming the tokens offered to it.
    */
    class FlowFinalNode : FinalNode
    {
    }

    /*
    A ForkNode is a ControlNode that splits a flow into multiple concurrent flows.
    */
    class ForkNode : ControlNode
    {
    }

    /*
    An InitialNode is a ControlNode that offers a single control token when initially enabled.
    */
    class InitialNode : ControlNode
    {
    }

    /*
    An InterruptibleActivityRegion is an ActivityGroup that supports the termination of tokens flowing in the portions of an activity within it.
    */
    class InterruptibleActivityRegion : ActivityGroup
    {
    	/*
    	The ActivityEdges leaving the InterruptibleActivityRegion on which a traversing token will result in the termination of other tokens flowing in the InterruptibleActivityRegion.
    	*/
    	set<ActivityEdge> InterruptingEdge;
    	/*
    	ActivityNodes immediately contained in the InterruptibleActivityRegion.
    	*/
    	set<ActivityNode> Node subsets ActivityGroup.ContainedNode;
    }

    /*
    A JoinNode is a ControlNode that synchronizes multiple flows.
    */
    class JoinNode : ControlNode
    {
    	/*
    	Indicates whether incoming tokens having objects with the same identity are combined into one by the JoinNode.
    	*/
    	bool IsCombineDuplicate;
    	/*
    	A ValueSpecification giving the condition under which the JoinNode will offer a token on its outgoing ActivityEdge. If no joinSpec is specified, then the JoinNode will offer an outgoing token if tokens are offered on all of its incoming ActivityEdges (an "and" condition).
    	*/
    	ValueSpecification JoinSpec subsets Element.OwnedElement;
    }

    /*
    A merge node is a control node that brings together multiple alternate flows. It is not used to synchronize concurrent flows but to accept one among several alternate flows.
    */
    class MergeNode : ControlNode
    {
    }

    /*
    An ObjectFlow is an ActivityEdge that is traversed by object tokens that may hold values. Object flows also support multicast/receive, token selection from object nodes, and transformation of tokens.
    */
    class ObjectFlow : ActivityEdge
    {
    	/*
    	Indicates whether the objects in the ObjectFlow are passed by multicasting.
    	*/
    	bool IsMulticast;
    	/*
    	Indicates whether the objects in the ObjectFlow are gathered from respondents to multicasting.
    	*/
    	bool IsMultireceive;
    	/*
    	A Behavior used to select tokens from a source ObjectNode.
    	*/
    	Behavior Selection;
    	/*
    	A Behavior used to change or replace object tokens flowing along the ObjectFlow.
    	*/
    	Behavior Transformation;
    }

    /*
    An ObjectNode is an abstract ActivityNode that may hold tokens within the object flow in an Activity. ObjectNodes also support token selection, limitation on the number of tokens held, specification of the state required for tokens being held, and carrying control values.
    */
    abstract class ObjectNode : TypedElement, ActivityNode
    {
    	/*
    	The States required to be associated with the values held by tokens on this ObjectNode.
    	*/
    	set<State> InState;
    	/*
    	Indicates whether the type of the ObjectNode is to be treated as representing control values that may traverse ControlFlows.
    	*/
    	bool IsControlType;
    	/*
    	Indicates how the tokens held by the ObjectNode are ordered for selection to traverse ActivityEdges outgoing from the ObjectNode.
    	*/
    	ObjectNodeOrderingKind Ordering;
    	/*
    	A Behavior used to select tokens to be offered on outgoing ActivityEdges.
    	*/
    	Behavior Selection;
    	/*
    	The maximum number of tokens that may be held by this ObjectNode. Tokens cannot flow into the ObjectNode if the upperBound is reached. If no upperBound is specified, then there is no limit on how many tokens the ObjectNode can hold.
    	*/
    	ValueSpecification UpperBound subsets Element.OwnedElement;
    }

    /*
    A Variable is a ConnectableElement that may store values during the execution of an Activity. Reading and writing the values of a Variable provides an alternative means for passing data than the use of ObjectFlows. A Variable may be owned directly by an Activity, in which case it is accessible from anywhere within that activity, or it may be owned by a StructuredActivityNode, in which case it is only accessible within that node.
    */
    class Variable : ConnectableElement, MultiplicityElement
    {
    	/*
    	An Activity that owns the Variable.
    	*/
    	Activity ActivityScope subsets NamedElement.Namespace;
    	/*
    	A StructuredActivityNode that owns the Variable.
    	*/
    	StructuredActivityNode Scope subsets NamedElement.Namespace;
    	/*
    	A Variable is accessible by Actions within its scope (the Activity or StructuredActivityNode that owns it).
    	
    	spec:
    	    result = (if scope<>null then scope.allOwnedNodes()->includes(a)
    	    else a.containingActivity()=activityScope
    	    endif)
    	*/
    	bool IsAccessibleBy(Action a);
    }

    /*
    A Duration is a ValueSpecification that specifies the temporal distance between two time instants.
    */
    class Duration : ValueSpecification
    {
    	/*
    	A ValueSpecification that evaluates to the value of the Duration.
    	*/
    	ValueSpecification Expr subsets Element.OwnedElement;
    	/*
    	Refers to the Observations that are involved in the computation of the Duration value
    	*/
    	set<Observation> Observation;
    }

    /*
    A DurationConstraint is a Constraint that refers to a DurationInterval.
    */
    class DurationConstraint : IntervalConstraint
    {
    	/*
    	The value of firstEvent[i] is related to constrainedElement[i] (where i is 1 or 2). If firstEvent[i] is true, then the corresponding observation event is the first time instant the execution enters constrainedElement[i]. If firstEvent[i] is false, then the corresponding observation event is the last time instant the execution is within constrainedElement[i].
    	*/
    	set<bool> FirstEvent;
    	/*
    	The DurationInterval constraining the duration.
    	*/
    	DurationInterval Specification redefines IntervalConstraint.Specification;
    }

    /*
    A DurationInterval defines the range between two Durations.
    */
    class DurationInterval : Interval
    {
    	/*
    	Refers to the Duration denoting the maximum value of the range.
    	*/
    	Duration Max redefines Interval.Max;
    	/*
    	Refers to the Duration denoting the minimum value of the range.
    	*/
    	Duration Min redefines Interval.Min;
    }

    /*
    A DurationObservation is a reference to a duration during an execution. It points out the NamedElement(s) in the model to observe and whether the observations are when this NamedElement is entered or when it is exited.
    */
    class DurationObservation : Observation
    {
    	/*
    	The DurationObservation is determined as the duration between the entering or exiting of a single event Element during execution, or the entering/exiting of one event Element and the entering/exiting of a second.
    	*/
    	list<NamedElement> Event;
    	/*
    	The value of firstEvent[i] is related to event[i] (where i is 1 or 2). If firstEvent[i] is true, then the corresponding observation event is the first time instant the execution enters event[i]. If firstEvent[i] is false, then the corresponding observation event is the time instant the execution exits event[i].
    	*/
    	set<bool> FirstEvent;
    }

    /*
    An Expression represents a node in an expression tree, which may be non-terminal or terminal. It defines a symbol, and has a possibly empty sequence of operands that are ValueSpecifications. It denotes a (possibly empty) set of values when evaluated in a context.
    */
    class Expression : ValueSpecification
    {
    	/*
    	Specifies a sequence of operand ValueSpecifications.
    	*/
    	list<ValueSpecification> Operand subsets Element.OwnedElement;
    	/*
    	The symbol associated with this node in the expression tree.
    	*/
    	string Symbol;
    }

    /*
    An Interval defines the range between two ValueSpecifications.
    */
    class Interval : ValueSpecification
    {
    	/*
    	Refers to the ValueSpecification denoting the maximum value of the range.
    	*/
    	ValueSpecification Max;
    	/*
    	Refers to the ValueSpecification denoting the minimum value of the range.
    	*/
    	ValueSpecification Min;
    }

    /*
    An IntervalConstraint is a Constraint that is specified by an Interval.
    */
    class IntervalConstraint : Constraint
    {
    	/*
    	The Interval that specifies the condition of the IntervalConstraint.
    	*/
    	Interval Specification redefines Constraint.Specification;
    }

    /*
    A LiteralBoolean is a specification of a Boolean value.
    */
    class LiteralBoolean : LiteralSpecification
    {
    	/*
    	The specified Boolean value.
    	*/
    	bool Value;
    	/*
    	The query booleanValue() gives the value.
    	
    	spec:
    	    result = (value)
    	*/
    	bool BooleanValue();
    	/*
    	The query isComputable() is redefined to be true.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsComputable();
    }

    /*
    A LiteralInteger is a specification of an Integer value.
    */
    class LiteralInteger : LiteralSpecification
    {
    	/*
    	The specified Integer value.
    	*/
    	int Value;
    	/*
    	The query integerValue() gives the value.
    	
    	spec:
    	    result = (value)
    	*/
    	int IntegerValue();
    	/*
    	The query isComputable() is redefined to be true.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsComputable();
    }

    /*
    A LiteralNull specifies the lack of a value.
    */
    class LiteralNull : LiteralSpecification
    {
    	/*
    	The query isComputable() is redefined to be true.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsComputable();
    	/*
    	The query isNull() returns true.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsNull();
    }

    /*
    A LiteralReal is a specification of a Real value.
    */
    class LiteralReal : LiteralSpecification
    {
    	/*
    	The specified Real value.
    	*/
    	double Value;
    	/*
    	The query isComputable() is redefined to be true.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsComputable();
    	/*
    	The query realValue() gives the value.
    	
    	spec:
    	    result = (value)
    	*/
    	double RealValue();
    }

    /*
    A LiteralSpecification identifies a literal constant being modeled.
    */
    abstract class LiteralSpecification : ValueSpecification
    {
    }

    /*
    A LiteralString is a specification of a String value.
    */
    class LiteralString : LiteralSpecification
    {
    	/*
    	The specified String value.
    	*/
    	string Value;
    	/*
    	The query isComputable() is redefined to be true.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsComputable();
    	/*
    	The query stringValue() gives the value.
    	
    	spec:
    	    result = (value)
    	*/
    	string StringValue();
    }

    /*
    A LiteralUnlimitedNatural is a specification of an UnlimitedNatural number.
    */
    class LiteralUnlimitedNatural : LiteralSpecification
    {
    	/*
    	The specified UnlimitedNatural value.
    	*/
    	long Value;
    	/*
    	The query isComputable() is redefined to be true.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsComputable();
    	/*
    	The query unlimitedValue() gives the value.
    	
    	spec:
    	    result = (value)
    	*/
    	long UnlimitedValue();
    }

    /*
    Observation specifies a value determined by observing an event or events that occur relative to other model Elements.
    */
    abstract class Observation : PackageableElement
    {
    }

    /*
    An OpaqueExpression is a ValueSpecification that specifies the computation of a collection of values either in terms of a UML Behavior or based on a textual statement in a language other than UML
    */
    class OpaqueExpression : ValueSpecification
    {
    	/*
    	Specifies the behavior of the OpaqueExpression as a UML Behavior.
    	*/
    	Behavior Behavior;
    	/*
    	A textual definition of the behavior of the OpaqueExpression, possibly in multiple languages.
    	*/
    	multi_list<string> Body;
    	/*
    	Specifies the languages used to express the textual bodies of the OpaqueExpression.  Languages are matched to body Strings by order. The interpretation of the body depends on the languages. If the languages are unspecified, they may be implicit from the expression body or the context.
    	*/
    	list<string> Language;
    	/*
    	If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required return Parameter of that Behavior. When the Behavior completes execution, the values on this Parameter give the result of evaluating the OpaqueExpression.
    	
    	spec:
    	    result = (if behavior = null then
    	    	null
    	    else
    	    	behavior.ownedParameter->first()
    	    endif)
    	*/
    	derived Parameter Result;
    	/*
    	The query isIntegral() tells whether an expression is intended to produce an Integer.
    	
    	spec:
    	    result = (false)
    	*/
    	bool IsIntegral();
    	/*
    	The query isNonNegative() tells whether an integer expression has a non-negative value.
    	
    	pre:
    	    self.isIntegral()
    	spec:
    	    result = (false)
    	*/
    	bool IsNonNegative();
    	/*
    	The query isPositive() tells whether an integer expression has a positive value.
    	
    	spec:
    	    result = (false)
    	pre:
    	    self.isIntegral()
    	*/
    	bool IsPositive();
    	/*
    	The query value() gives an integer value for an expression intended to produce one.
    	
    	pre:
    	    self.isIntegral()
    	spec:
    	    result = (0)
    	*/
    	int Value();
    }

    /*
    A StringExpression is an Expression that specifies a String value that is derived by concatenating a sequence of operands with String values or a sequence of subExpressions, some of which might be template parameters.
    */
    class StringExpression : TemplateableElement, Expression
    {
    	/*
    	The StringExpression of which this StringExpression is a subExpression.
    	*/
    	StringExpression OwningExpression subsets Element.Owner;
    	/*
    	The StringExpressions that constitute this StringExpression.
    	*/
    	list<StringExpression> SubExpression subsets Element.OwnedElement;
    	/*
    	The query stringValue() returns the String resulting from concatenating, in order, all the component String values of all the operands or subExpressions that are part of the StringExpression.
    	
    	spec:
    	    result = (if subExpression->notEmpty()
    	    then subExpression->iterate(se; stringValue: String = '' | stringValue.concat(se.stringValue()))
    	    else operand->iterate(op; stringValue: String = '' | stringValue.concat(op.stringValue()))
    	    endif)
    	*/
    	string StringValue();
    }

    /*
    A TimeConstraint is a Constraint that refers to a TimeInterval.
    */
    class TimeConstraint : IntervalConstraint
    {
    	/*
    	The value of firstEvent is related to the constrainedElement. If firstEvent is true, then the corresponding observation event is the first time instant the execution enters the constrainedElement. If firstEvent is false, then the corresponding observation event is the last time instant the execution is within the constrainedElement.
    	*/
    	bool FirstEvent;
    	/*
    	TheTimeInterval constraining the duration.
    	*/
    	TimeInterval Specification redefines IntervalConstraint.Specification;
    }

    /*
    A TimeExpression is a ValueSpecification that represents a time value.
    */
    class TimeExpression : ValueSpecification
    {
    	/*
    	A ValueSpecification that evaluates to the value of the TimeExpression.
    	*/
    	ValueSpecification Expr subsets Element.OwnedElement;
    	/*
    	Refers to the Observations that are involved in the computation of the TimeExpression value.
    	*/
    	set<Observation> Observation;
    }

    /*
    A TimeInterval defines the range between two TimeExpressions.
    */
    class TimeInterval : Interval
    {
    	/*
    	Refers to the TimeExpression denoting the maximum value of the range.
    	*/
    	TimeExpression Max redefines Interval.Max;
    	/*
    	Refers to the TimeExpression denoting the minimum value of the range.
    	*/
    	TimeExpression Min redefines Interval.Min;
    }

    /*
    A TimeObservation is a reference to a time instant during an execution. It points out the NamedElement in the model to observe and whether the observation is when this NamedElement is entered or when it is exited.
    */
    class TimeObservation : Observation
    {
    	/*
    	The TimeObservation is determined by the entering or exiting of the event Element during execution.
    	*/
    	NamedElement Event;
    	/*
    	The value of firstEvent is related to the event. If firstEvent is true, then the corresponding observation event is the first time instant the execution enters the event Element. If firstEvent is false, then the corresponding observation event is the time instant the execution exits the event Element.
    	*/
    	bool FirstEvent;
    }

    /*
    A ValueSpecification is the specification of a (possibly empty) set of values. A ValueSpecification is a ParameterableElement that may be exposed as a formal TemplateParameter and provided as the actual parameter in the binding of a template.
    */
    abstract class ValueSpecification : TypedElement, PackageableElement
    {
    	/*
    	The query booleanValue() gives a single Boolean value when one can be computed.
    	
    	spec:
    	    result = (null)
    	*/
    	bool BooleanValue();
    	/*
    	The query integerValue() gives a single Integer value when one can be computed.
    	
    	spec:
    	    result = (null)
    	*/
    	int IntegerValue();
    	/*
    	The query isCompatibleWith() determines if this ValueSpecification is compatible with the specified ParameterableElement. This ValueSpecification is compatible with ParameterableElement p if the kind of this ValueSpecification is the same as or a subtype of the kind of p. Further, if p is a TypedElement, then the type of this ValueSpecification must be conformant with the type of p.
    	
    	spec:
    	    result = (self.oclIsKindOf(p.oclType()) and (p.oclIsKindOf(TypedElement) implies 
    	    self.type.conformsTo(p.oclAsType(TypedElement).type)))
    	*/
    	bool IsCompatibleWith(ParameterableElement p);
    	/*
    	The query isComputable() determines whether a value specification can be computed in a model. This operation cannot be fully defined in OCL. A conforming implementation is expected to deliver true for this operation for all ValueSpecifications that it can compute, and to compute all of those for which the operation is true. A conforming implementation is expected to be able to compute at least the value of all LiteralSpecifications.
    	
    	spec:
    	    result = (false)
    	*/
    	bool IsComputable();
    	/*
    	The query isNull() returns true when it can be computed that the value is null.
    	
    	spec:
    	    result = (false)
    	*/
    	bool IsNull();
    	/*
    	The query realValue() gives a single Real value when one can be computed.
    	
    	spec:
    	    result = (null)
    	*/
    	double RealValue();
    	/*
    	The query stringValue() gives a single String value when one can be computed.
    	
    	spec:
    	    result = (null)
    	*/
    	string StringValue();
    	/*
    	The query unlimitedValue() gives a single UnlimitedNatural value when one can be computed.
    	
    	spec:
    	    result = (null)
    	*/
    	long UnlimitedValue();
    }

    /*
    An Actor specifies a role played by a user or any other system that interacts with the subject.
    */
    class Actor : BehavioredClassifier
    {
    }

    /*
    A relationship from an extending UseCase to an extended UseCase that specifies how and when the behavior defined in the extending UseCase can be inserted into the behavior defined in the extended UseCase.
    */
    class Extend : NamedElement, DirectedRelationship
    {
    	/*
    	References the condition that must hold when the first ExtensionPoint is reached for the extension to take place. If no constraint is associated with the Extend relationship, the extension is unconditional.
    	*/
    	Constraint Condition subsets Element.OwnedElement;
    	/*
    	The UseCase that is being extended.
    	*/
    	UseCase ExtendedCase subsets DirectedRelationship.Target;
    	/*
    	The UseCase that represents the extension and owns the Extend relationship.
    	*/
    	UseCase Extension subsets DirectedRelationship.Source, NamedElement.Namespace;
    	/*
    	An ordered list of ExtensionPoints belonging to the extended UseCase, specifying where the respective behavioral fragments of the extending UseCase are to be inserted. The first fragment in the extending UseCase is associated with the first extension point in the list, the second fragment with the second point, and so on. Note that, in most practical cases, the extending UseCase has just a single behavior fragment, so that the list of ExtensionPoints is trivial.
    	*/
    	list<ExtensionPoint> ExtensionLocation;
    }

    /*
    An ExtensionPoint identifies a point in the behavior of a UseCase where that behavior can be extended by the behavior of some other (extending) UseCase, as specified by an Extend relationship.
    */
    class ExtensionPoint : RedefinableElement
    {
    	/*
    	The UseCase that owns this ExtensionPoint.
    	*/
    	UseCase UseCase subsets NamedElement.Namespace;
    }

    /*
    An Include relationship specifies that a UseCase contains the behavior defined in another UseCase.
    */
    class Include : DirectedRelationship, NamedElement
    {
    	/*
    	The UseCase that is to be included.
    	*/
    	UseCase Addition subsets DirectedRelationship.Target;
    	/*
    	The UseCase which includes the addition and owns the Include relationship.
    	*/
    	UseCase IncludingCase subsets DirectedRelationship.Source, NamedElement.Namespace;
    }

    /*
    A UseCase specifies a set of actions performed by its subjects, which yields an observable result that is of value for one or more Actors or other stakeholders of each subject.
    */
    class UseCase : BehavioredClassifier
    {
    	/*
    	The Extend relationships owned by this UseCase.
    	*/
    	set<Extend> Extend subsets Namespace.OwnedMember;
    	/*
    	The ExtensionPoints owned by this UseCase.
    	*/
    	set<ExtensionPoint> ExtensionPoint subsets Namespace.OwnedMember;
    	/*
    	The Include relationships owned by this UseCase.
    	*/
    	set<Include> Include subsets Namespace.OwnedMember;
    	/*
    	The subjects to which this UseCase applies. Each subject or its parts realize all the UseCases that apply to it.
    	*/
    	set<Classifier> Subject;
    	/*
    	The query allIncludedUseCases() returns the transitive closure of all UseCases (directly or indirectly) included by this UseCase.
    	
    	spec:
    	    result = (self.include.addition->union(self.include.addition->collect(uc | uc.allIncludedUseCases()))->asSet())
    	*/
    	set<UseCase> AllIncludedUseCases();
    }

    /*
    A link is a tuple of values that refer to typed objects.  An Association classifies a set of links, each of which is an instance of the Association.  Each value in the link refers to an instance of the type of the corresponding end of the Association.
    */
    class Association : Relationship, Classifier
    {
    	/*
    	The Classifiers that are used as types of the ends of the Association.
    	
    	spec:
    	    result = (memberEnd->collect(type)->asSet())
    	*/
    	derived set<Type> EndType subsets Relationship.RelatedElement;
    	/*
    	Specifies whether the Association is derived from other model elements such as other Associations.
    	*/
    	bool IsDerived;
    	/*
    	Each end represents participation of instances of the Classifier connected to the end in links of the Association.
    	*/
    	list<Property> MemberEnd subsets Namespace.Member;
    	/*
    	The navigable ends that are owned by the Association itself.
    	*/
    	set<Property> NavigableOwnedEnd subsets Association.OwnedEnd;
    	/*
    	The ends that are owned by the Association itself.
    	*/
    	list<Property> OwnedEnd subsets Association.MemberEnd, Classifier.Feature, Namespace.OwnedMember;
    }

    /*
    A model element that has both Association and Class properties. An AssociationClass can be seen as an Association that also has Class properties, or as a Class that also has Association properties. It not only connects a set of Classifiers but also defines a set of Features that belong to the Association itself and not to any of the associated Classifiers.
    */
    class AssociationClass : Class, Association
    {
    }

    /*
    A Class classifies a set of objects and specifies the features that characterize the structure and behavior of those objects.  A Class may have an internal structure and Ports.
    */
    class Class : BehavioredClassifier, EncapsulatedClassifier
    {
    	/*
    	This property is used when the Class is acting as a metaclass. It references the Extensions that specify additional properties of the metaclass. The property is derived from the Extensions whose memberEnds are typed by the Class.
    	
    	spec:
    	    result = (Extension.allInstances()->select(ext | 
    	      let endTypes : Sequence(Classifier) = ext.memberEnd->collect(type.oclAsType(Classifier)) in
    	      endTypes->includes(self) or endTypes.allParents()->includes(self) ))
    	*/
    	derived set<Extension> Extension;
    	/*
    	If true, the Class does not provide a complete declaration and cannot be instantiated. An abstract Class is typically used as a target of Associations or Generalizations.
    	*/
    	bool IsAbstract redefines Classifier.IsAbstract;
    	/*
    	Determines whether an object specified by this Class is active or not. If true, then the owning Class is referred to as an active Class. If false, then such a Class is referred to as a passive Class.
    	*/
    	bool IsActive;
    	/*
    	The Classifiers owned by the Class that are not ownedBehaviors.
    	*/
    	list<Classifier> NestedClassifier subsets Namespace.OwnedMember;
    	/*
    	The attributes (i.e., the Properties) owned by the Class.
    	*/
    	list<Property> OwnedAttribute redefines StructuredClassifier.OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    	/*
    	The Operations owned by the Class.
    	*/
    	list<Operation> OwnedOperation subsets Classifier.Feature, Namespace.OwnedMember;
    	/*
    	The Receptions owned by the Class.
    	*/
    	set<Reception> OwnedReception subsets Classifier.Feature, Namespace.OwnedMember;
    	/*
    	The superclasses of a Class, derived from its Generalizations.
    	
    	spec:
    	    result = (self.general()->select(oclIsKindOf(Class))->collect(oclAsType(Class))->asSet())
    	*/
    	derived set<Class> SuperClass redefines Classifier.General;
    }

    /*
    A Collaboration describes a structure of collaborating elements (roles), each performing a specialized function, which collectively accomplish some desired functionality. 
    */
    class Collaboration : StructuredClassifier, BehavioredClassifier
    {
    	/*
    	Represents the participants in the Collaboration.
    	*/
    	set<ConnectableElement> CollaborationRole subsets StructuredClassifier.Role;
    }

    /*
    A CollaborationUse is used to specify the application of a pattern specified by a Collaboration to a specific situation.
    */
    class CollaborationUse : NamedElement
    {
    	/*
    	A mapping between features of the Collaboration and features of the owning Classifier. This mapping indicates which ConnectableElement of the Classifier plays which role(s) in the Collaboration. A ConnectableElement may be bound to multiple roles in the same CollaborationUse (that is, it may play multiple roles).
    	*/
    	set<Dependency> RoleBinding subsets Element.OwnedElement;
    	/*
    	The Collaboration which is used in this CollaborationUse. The Collaboration defines the cooperation between its roles which are mapped to ConnectableElements relating to the Classifier owning the CollaborationUse.
    	*/
    	Collaboration Type;
    }

    /*
    A Component represents a modular part of a system that encapsulates its contents and whose manifestation is replaceable within its environment.  
    */
    class Component : Class
    {
    	/*
    	If true, the Component is defined at design-time, but at run-time (or execution-time) an object specified by the Component does not exist, that is, the Component is instantiated indirectly, through the instantiation of its realizing Classifiers or parts.
    	*/
    	bool IsIndirectlyInstantiated;
    	/*
    	The set of PackageableElements that a Component owns. In the namespace of a Component, all model elements that are involved in or related to its definition may be owned or imported explicitly. These may include e.g., Classes, Interfaces, Components, Packages, UseCases, Dependencies (e.g., mappings), and Artifacts.
    	*/
    	set<PackageableElement> PackagedElement subsets Namespace.OwnedMember;
    	/*
    	The Interfaces that the Component exposes to its environment. These Interfaces may be Realized by the Component or any of its realizingClassifiers, or they may be the Interfaces that are provided by its public Ports.
    	
    	spec:
    	    result = (let 	ris : Set(Interface) = allRealizedInterfaces(),
    	            realizingClassifiers : Set(Classifier) =  self.realization.realizingClassifier->union(self.allParents()->collect(realization.realizingClassifier))->asSet(),
    	            allRealizingClassifiers : Set(Classifier) = realizingClassifiers->union(realizingClassifiers.allParents())->asSet(),
    	            realizingClassifierInterfaces : Set(Interface) = allRealizingClassifiers->iterate(c; rci : Set(Interface) = Set{} | rci->union(c.allRealizedInterfaces())),
    	            ports : Set(Port) = self.ownedPort->union(allParents()->collect(ownedPort))->asSet(),
    	            providedByPorts : Set(Interface) = ports.provided->asSet()
    	    in     ris->union(realizingClassifierInterfaces) ->union(providedByPorts)->asSet())
    	*/
    	derived set<Interface> Provided;
    	/*
    	The set of Realizations owned by the Component. Realizations reference the Classifiers of which the Component is an abstraction; i.e., that realize its behavior.
    	*/
    	set<ComponentRealization> Realization subsets Element.OwnedElement;
    	/*
    	The Interfaces that the Component requires from other Components in its environment in order to be able to offer its full set of provided functionality. These Interfaces may be used by the Component or any of its realizingClassifiers, or they may be the Interfaces that are required by its public Ports.
    	
    	spec:
    	    result = (let 	uis : Set(Interface) = allUsedInterfaces(),
    	            realizingClassifiers : Set(Classifier) = self.realization.realizingClassifier->union(self.allParents()->collect(realization.realizingClassifier))->asSet(),
    	            allRealizingClassifiers : Set(Classifier) = realizingClassifiers->union(realizingClassifiers.allParents())->asSet(),
    	            realizingClassifierInterfaces : Set(Interface) = allRealizingClassifiers->iterate(c; rci : Set(Interface) = Set{} | rci->union(c.allUsedInterfaces())),
    	            ports : Set(Port) = self.ownedPort->union(allParents()->collect(ownedPort))->asSet(),
    	            usedByPorts : Set(Interface) = ports.required->asSet()
    	    in	    uis->union(realizingClassifierInterfaces)->union(usedByPorts)->asSet()
    	    )
    	*/
    	derived set<Interface> Required;
    }

    /*
    Realization is specialized to (optionally) define the Classifiers that realize the contract offered by a Component in terms of its provided and required Interfaces. The Component forms an abstraction from these various Classifiers.
    */
    class ComponentRealization : Realization
    {
    	/*
    	The Component that owns this ComponentRealization and which is implemented by its realizing Classifiers.
    	*/
    	Component Abstraction subsets Dependency.Supplier, Element.Owner;
    	/*
    	The Classifiers that are involved in the implementation of the Component that owns this Realization.
    	*/
    	set<Classifier> RealizingClassifier subsets Dependency.Client;
    }

    /*
    ConnectableElement is an abstract metaclass representing a set of instances that play roles of a StructuredClassifier. ConnectableElements may be joined by attached Connectors and specify configurations of linked instances to be created within an instance of the containing StructuredClassifier.
    */
    abstract class ConnectableElement : TypedElement, ParameterableElement
    {
    	/*
    	A set of ConnectorEnds that attach to this ConnectableElement.
    	
    	spec:
    	    result = (ConnectorEnd.allInstances()->select(role = self))
    	*/
    	derived set<ConnectorEnd> End;
    	/*
    	The ConnectableElementTemplateParameter for this ConnectableElement parameter.
    	*/
    	ConnectableElementTemplateParameter TemplateParameter redefines ParameterableElement.TemplateParameter;
    }

    /*
    A ConnectableElementTemplateParameter exposes a ConnectableElement as a formal parameter for a template.
    */
    class ConnectableElementTemplateParameter : TemplateParameter
    {
    	/*
    	The ConnectableElement for this ConnectableElementTemplateParameter.
    	*/
    	ConnectableElement ParameteredElement redefines TemplateParameter.ParameteredElement;
    }

    /*
    A Connector specifies links that enables communication between two or more instances. In contrast to Associations, which specify links between any instance of the associated Classifiers, Connectors specify links between instances playing the connected parts only.
    */
    class Connector : Feature
    {
    	/*
    	The set of Behaviors that specify the valid interaction patterns across the Connector.
    	*/
    	set<Behavior> Contract;
    	/*
    	A Connector has at least two ConnectorEnds, each representing the participation of instances of the Classifiers typing the ConnectableElements attached to the end. The set of ConnectorEnds is ordered.
    	*/
    	list<ConnectorEnd> End subsets Element.OwnedElement;
    	/*
    	Indicates the kind of Connector. This is derived: a Connector with one or more ends connected to a Port which is not on a Part and which is not a behavior port is a delegation; otherwise it is an assembly.
    	
    	spec:
    	    result = (if end->exists(
    	    		role.oclIsKindOf(Port) 
    	    		and partWithPort->isEmpty()
    	    		and not role.oclAsType(Port).isBehavior)
    	    then ConnectorKind::delegation 
    	    else ConnectorKind::assembly 
    	    endif)
    	*/
    	derived ConnectorKind Kind;
    	/*
    	A Connector may be redefined when its containing Classifier is specialized. The redefining Connector may have a type that specializes the type of the redefined Connector. The types of the ConnectorEnds of the redefining Connector may specialize the types of the ConnectorEnds of the redefined Connector. The properties of the ConnectorEnds of the redefining Connector may be replaced.
    	*/
    	set<Connector> RedefinedConnector subsets RedefinableElement.RedefinedElement;
    	/*
    	An optional Association that classifies links corresponding to this Connector.
    	*/
    	Association Type;
    }

    /*
    A ConnectorEnd is an endpoint of a Connector, which attaches the Connector to a ConnectableElement.
    */
    class ConnectorEnd : MultiplicityElement
    {
    	/*
    	A derived property referencing the corresponding end on the Association which types the Connector owing this ConnectorEnd, if any. It is derived by selecting the end at the same place in the ordering of Association ends as this ConnectorEnd.
    	
    	spec:
    	    result = (if connector.type = null 
    	    then
    	      null 
    	    else
    	      let index : Integer = connector.end->indexOf(self) in
    	        connector.type.memberEnd->at(index)
    	    endif)
    	*/
    	derived Property DefiningEnd;
    	/*
    	Indicates the role of the internal structure of a Classifier with the Port to which the ConnectorEnd is attached.
    	*/
    	Property PartWithPort;
    	/*
    	The ConnectableElement attached at this ConnectorEnd. When an instance of the containing Classifier is created, a link may (depending on the multiplicities) be created to an instance of the Classifier that types this ConnectableElement.
    	*/
    	ConnectableElement Role;
    }

    /*
    An EncapsulatedClassifier may own Ports to specify typed interaction points.
    */
    abstract class EncapsulatedClassifier : StructuredClassifier
    {
    	/*
    	The Ports owned by the EncapsulatedClassifier.
    	
    	spec:
    	    result = (ownedAttribute->select(oclIsKindOf(Port))->collect(oclAsType(Port))->asOrderedSet())
    	*/
    	derived set<Port> OwnedPort subsets StructuredClassifier.OwnedAttribute;
    }

    /*
    A Port is a property of an EncapsulatedClassifier that specifies a distinct interaction point between that EncapsulatedClassifier and its environment or between the (behavior of the) EncapsulatedClassifier and its internal parts. Ports are connected to Properties of the EncapsulatedClassifier by Connectors through which requests can be made to invoke BehavioralFeatures. A Port may specify the services an EncapsulatedClassifier provides (offers) to its environment as well as the services that an EncapsulatedClassifier expects (requires) of its environment.  A Port may have an associated ProtocolStateMachine.
    */
    class Port : Property
    {
    	/*
    	Specifies whether requests arriving at this Port are sent to the classifier behavior of this EncapsulatedClassifier. Such a Port is referred to as a behavior Port. Any invocation of a BehavioralFeature targeted at a behavior Port will be handled by the instance of the owning EncapsulatedClassifier itself, rather than by any instances that it may contain.
    	*/
    	bool IsBehavior;
    	/*
    	Specifies the way that the provided and required Interfaces are derived from the Port’s Type.
    	*/
    	bool IsConjugated;
    	/*
    	If true, indicates that this Port is used to provide the published functionality of an EncapsulatedClassifier.  If false, this Port is used to implement the EncapsulatedClassifier but is not part of the essential externally-visible functionality of the EncapsulatedClassifier and can, therefore, be altered or deleted along with the internal implementation of the EncapsulatedClassifier and other properties that are considered part of its implementation.
    	*/
    	bool IsService;
    	/*
    	An optional ProtocolStateMachine which describes valid interactions at this interaction point.
    	*/
    	ProtocolStateMachine Protocol;
    	/*
    	The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCclassifier offers to its environment via this Port, and which it will handle either directly or by forwarding it to a part of its internal structure. This association is derived according to the value of isConjugated. If isConjugated is false, provided is derived as the union of the sets of Interfaces realized by the type of the port and its supertypes, or directly from the type of the Port if the Port is typed by an Interface. If isConjugated is true, it is derived as the union of the sets of Interfaces used by the type of the Port and its supertypes.
    	
    	spec:
    	    result = (if isConjugated then basicRequired() else basicProvided() endif)
    	*/
    	derived set<Interface> Provided;
    	/*
    	A Port may be redefined when its containing EncapsulatedClassifier is specialized. The redefining Port may have additional Interfaces to those that are associated with the redefined Port or it may replace an Interface by one of its subtypes.
    	*/
    	set<Port> RedefinedPort subsets Property.RedefinedProperty;
    	/*
    	The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCassifier expects its environment to handle via this port. This association is derived according to the value of isConjugated. If isConjugated is false, required is derived as the union of the sets of Interfaces used by the type of the Port and its supertypes. If isConjugated is true, it is derived as the union of the sets of Interfaces realized by the type of the Port and its supertypes, or directly from the type of the Port if the Port is typed by an Interface.
    	
    	spec:
    	    result = (if isConjugated then basicProvided() else basicRequired() endif)
    	*/
    	derived set<Interface> Required;
    	/*
    	The union of the sets of Interfaces realized by the type of the Port and its supertypes, or directly the type of the Port if the Port is typed by an Interface.
    	
    	spec:
    	    result = (if type.oclIsKindOf(Interface) 
    	    then type.oclAsType(Interface)->asSet() 
    	    else type.oclAsType(Classifier).allRealizedInterfaces() 
    	    endif)
    	*/
    	set<Interface> BasicProvided();
    	/*
    	The union of the sets of Interfaces used by the type of the Port and its supertypes.
    	
    	spec:
    	    result = ( type.oclAsType(Classifier).allUsedInterfaces() )
    	*/
    	set<Interface> BasicRequired();
    }

    /*
    StructuredClassifiers may contain an internal structure of connected elements each of which plays a role in the overall Behavior modeled by the StructuredClassifier.
    */
    abstract class StructuredClassifier : Classifier
    {
    	/*
    	The Properties owned by the StructuredClassifier.
    	*/
    	list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember, StructuredClassifier.Role;
    	/*
    	The connectors owned by the StructuredClassifier.
    	*/
    	set<Connector> OwnedConnector subsets Classifier.Feature, Namespace.OwnedMember;
    	/*
    	The Properties specifying instances that the StructuredClassifier owns by composition. This collection is derived, selecting those owned Properties where isComposite is true.
    	
    	spec:
    	    result = (ownedAttribute->select(isComposite))
    	*/
    	derived set<Property> Part;
    	/*
    	The roles that instances may play in this StructuredClassifier.
    	*/
    	union set<ConnectableElement> Role subsets Namespace.Member;
    	/*
    	All features of type ConnectableElement, equivalent to all direct and inherited roles.
    	
    	spec:
    	    result = (allFeatures()->select(oclIsKindOf(ConnectableElement))->collect(oclAsType(ConnectableElement))->asSet())
    	*/
    	set<ConnectableElement> AllRoles();
    }

    /*
    A ConnectionPointReference represents a usage (as part of a submachine State) of an entry/exit point Pseudostate defined in the StateMachine referenced by the submachine State.
    */
    class ConnectionPointReference : Vertex
    {
    	/*
    	The entryPoint Pseudostates corresponding to this connection point.
    	*/
    	set<Pseudostate> Entry;
    	/*
    	The exitPoints kind Pseudostates corresponding to this connection point.
    	*/
    	set<Pseudostate> Exit;
    	/*
    	The State in which the ConnectionPointReference is defined.
    	*/
    	State State subsets NamedElement.Namespace;
    	/*
    	The query isConsistentWith() specifies a ConnectionPointReference can only be redefined by a ConnectionPointReference.
    	
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	spec:
    	    result = redefiningElement.oclIsKindOf(ConnectionPointReference)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    A special kind of State, which, when entered, signifies that the enclosing Region has completed. If the enclosing Region is directly contained in a StateMachine and all other Regions in that StateMachine also are completed, then it means that the entire StateMachine behavior is completed.
    */
    class FinalState : State
    {
    	/*
    	The query isConsistentWith() specifies a FinalState can only be redefined by a FinalState.
    	
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	spec:
    	    result = redefiningElement.oclIsKindOf(FinalState)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    A ProtocolStateMachine can be redefined into a more specific ProtocolStateMachine or into behavioral StateMachine. ProtocolConformance declares that the specific ProtocolStateMachine specifies a protocol that conforms to the general ProtocolStateMachine or that the specific behavioral StateMachine abides by the protocol of the general ProtocolStateMachine.
    */
    class ProtocolConformance : DirectedRelationship
    {
    	/*
    	Specifies the ProtocolStateMachine to which the specific ProtocolStateMachine conforms.
    	*/
    	ProtocolStateMachine GeneralMachine subsets DirectedRelationship.Target;
    	/*
    	Specifies the ProtocolStateMachine which conforms to the general ProtocolStateMachine.
    	*/
    	ProtocolStateMachine SpecificMachine subsets DirectedRelationship.Source, Element.Owner;
    }

    /*
    A ProtocolStateMachine is always defined in the context of a Classifier. It specifies which BehavioralFeatures of the Classifier can be called in which State and under which conditions, thus specifying the allowed invocation sequences on the Classifier's BehavioralFeatures. A ProtocolStateMachine specifies the possible and permitted Transitions on the instances of its context Classifier, together with the BehavioralFeatures that carry the Transitions. In this manner, an instance lifecycle can be specified for a Classifier, by defining the order in which the BehavioralFeatures can be activated and the States through which an instance progresses during its existence.
    */
    class ProtocolStateMachine : StateMachine
    {
    	/*
    	Conformance between ProtocolStateMachine 
    	*/
    	set<ProtocolConformance> Conformance subsets Element.OwnedElement;
    }

    /*
    A ProtocolTransition specifies a legal Transition for an Operation. Transitions of ProtocolStateMachines have the following information: a pre-condition (guard), a Trigger, and a post-condition. Every ProtocolTransition is associated with at most one BehavioralFeature belonging to the context Classifier of the ProtocolStateMachine.
    */
    class ProtocolTransition : Transition
    {
    	/*
    	Specifies the post condition of the Transition which is the Condition that should be obtained once the Transition is triggered. This post condition is part of the post condition of the Operation connected to the Transition.
    	*/
    	Constraint PostCondition subsets Namespace.OwnedRule;
    	/*
    	Specifies the precondition of the Transition. It specifies the Condition that should be verified before triggering the Transition. This guard condition added to the source State will be evaluated as part of the precondition of the Operation referred by the Transition if any.
    	*/
    	Constraint PreCondition subsets Transition.Guard;
    	/*
    	This association refers to the associated Operation. It is derived from the Operation of the CallEvent Trigger when applicable.
    	
    	spec:
    	    result = (trigger->collect(event)->select(oclIsKindOf(CallEvent))->collect(oclAsType(CallEvent).operation)->asSet())
    	*/
    	derived set<Operation> Referred;
    }

    /*
    A Pseudostate is an abstraction that encompasses different types of transient Vertices in the StateMachine graph. A StateMachine instance never comes to rest in a Pseudostate, instead, it will exit and enter the Pseudostate within a single run-to-completion step.
    */
    class Pseudostate : Vertex
    {
    	/*
    	Determines the precise type of the Pseudostate and can be one of: entryPoint, exitPoint, initial, deepHistory, shallowHistory, join, fork, junction, terminate or choice.
    	*/
    	PseudostateKind Kind;
    	/*
    	The State that owns this Pseudostate and in which it appears.
    	*/
    	State State subsets NamedElement.Namespace;
    	/*
    	The StateMachine in which this Pseudostate is defined. This only applies to Pseudostates of the kind entryPoint or exitPoint.
    	*/
    	StateMachine StateMachine subsets NamedElement.Namespace;
    	/*
    	The query isConsistentWith() specifies a Pseudostate can only be redefined by a Pseudostate of the same kind.
    	
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	spec:
    	    result = (redefiningElement.oclIsKindOf(Pseudostate) and
    	    redefiningElement.oclAsType(Pseudostate).kind = kind)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    A Region is a top-level part of a StateMachine or a composite State, that serves as a container for the Vertices and Transitions of the StateMachine. A StateMachine or composite State may contain multiple Regions representing behaviors that may occur in parallel.
    */
    class Region : Namespace, RedefinableElement
    {
    	/*
    	The region of which this region is an extension.
    	*/
    	Region ExtendedRegion subsets RedefinableElement.RedefinedElement;
    	/*
    	References the Classifier in which context this element may be redefined.
    	
    	spec:
    	    result = containingStateMachine()
    	*/
    	derived Classifier RedefinitionContext redefines RedefinableElement.RedefinitionContext;
    	/*
    	The State that owns the Region. If a Region is owned by a State, then it cannot also be owned by a StateMachine.
    	*/
    	State State subsets NamedElement.Namespace;
    	/*
    	The StateMachine that owns the Region. If a Region is owned by a StateMachine, then it cannot also be owned by a State.
    	*/
    	StateMachine StateMachine subsets NamedElement.Namespace;
    	/*
    	The set of Vertices that are owned by this Region.
    	*/
    	set<Vertex> Subvertex subsets Namespace.OwnedMember;
    	/*
    	The set of Transitions owned by the Region.
    	*/
    	set<Transition> Transition subsets Namespace.OwnedMember;
    	/*
    	The operation belongsToPSM () checks if the Region belongs to a ProtocolStateMachine.
    	
    	spec:
    	    result = (if  stateMachine <> null 
    	    then
    	      stateMachine.oclIsKindOf(ProtocolStateMachine)
    	    else 
    	      state <> null  implies  state.container.belongsToPSM()
    	    endif )
    	*/
    	bool BelongsToPSM();
    	/*
    	The operation containingStateMachine() returns the StateMachine in which this Region is defined.
    	
    	spec:
    	    result = (if stateMachine = null 
    	    then
    	      state.containingStateMachine()
    	    else
    	      stateMachine
    	    endif)
    	*/
    	StateMachine ContainingStateMachine();
    	/*
    	The query isConsistentWith specifies that a Region can be redefined by any Region for which the redefinition context is valid (see the isRedefinitionContextValid operation). Note that consistency requirements for the redefinition of Vertices and Transitions within a redefining Region are specified by the isConsistentWith and isRedefinitionContextValid operations for Vertex (and its subclasses) and Transition.
    	
    	spec:
    	    result = true
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    	/*
    	The query isRedefinitionContextValid() specifies whether the redefinition contexts of a Region are properly related to the redefinition contexts of the specified Region to allow this element to redefine the other. The containing StateMachine or State of a redefining Region must Redefine the containing StateMachine or State of the redefined Region.
    	
    	spec:
    	    result = (if redefinedElement.oclIsKindOf(Region) then
    	      let redefinedRegion : Region = redefinedElement.oclAsType(Region) in
    	        if stateMachine->isEmpty() then
    	        -- the Region is owned by a State
    	          (state.redefinedState->notEmpty() and state.redefinedState.region->includes(redefinedRegion))
    	        else -- the region is owned by a StateMachine
    	          (stateMachine.extendedStateMachine->notEmpty() and
    	            stateMachine.extendedStateMachine->exists(sm : StateMachine |
    	              sm.region->includes(redefinedRegion)))
    	        endif
    	    else
    	      false
    	    endif)
    	*/
    	bool IsRedefinitionContextValid(RedefinableElement redefinedElement);
    }

    /*
    A State models a situation during which some (usually implicit) invariant condition holds.
    */
    class State : Namespace, Vertex
    {
    	/*
    	The entry and exit connection points used in conjunction with this (submachine) State, i.e., as targets and sources, respectively, in the Region with the submachine State. A connection point reference references the corresponding definition of a connection point Pseudostate in the StateMachine referenced by the submachine State.
    	*/
    	set<ConnectionPointReference> Connection subsets Namespace.OwnedMember;
    	/*
    	The entry and exit Pseudostates of a composite State. These can only be entry or exit Pseudostates, and they must have different names. They can only be defined for composite States.
    	*/
    	set<Pseudostate> ConnectionPoint subsets Namespace.OwnedMember;
    	/*
    	A list of Triggers that are candidates to be retained by the StateMachine if they trigger no Transitions out of the State (not consumed). A deferred Trigger is retained until the StateMachine reaches a State configuration where it is no longer deferred.
    	*/
    	set<Trigger> DeferrableTrigger subsets Element.OwnedElement;
    	/*
    	An optional Behavior that is executed while being in the State. The execution starts when this State is entered, and ceases either by itself when done, or when the State is exited, whichever comes first.
    	*/
    	Behavior DoActivity subsets Element.OwnedElement;
    	/*
    	An optional Behavior that is executed whenever this State is entered regardless of the Transition taken to reach the State. If defined, entry Behaviors are always executed to completion prior to any internal Behavior or Transitions performed within the State.
    	*/
    	Behavior Entry subsets Element.OwnedElement;
    	/*
    	An optional Behavior that is executed whenever this State is exited regardless of which Transition was taken out of the State. If defined, exit Behaviors are always executed to completion only after all internal and transition Behaviors have completed execution.
    	*/
    	Behavior Exit subsets Element.OwnedElement;
    	/*
    	A state with isComposite=true is said to be a composite State. A composite State is a State that contains at least one Region.
    	
    	spec:
    	    result = (region->notEmpty())
    	*/
    	derived bool IsComposite;
    	/*
    	A State with isOrthogonal=true is said to be an orthogonal composite State An orthogonal composite State contains two or more Regions.
    	
    	spec:
    	    result = (region->size () > 1)
    	*/
    	derived bool IsOrthogonal;
    	/*
    	A State with isSimple=true is said to be a simple State A simple State does not have any Regions and it does not refer to any submachine StateMachine.
    	
    	spec:
    	    result = ((region->isEmpty()) and not isSubmachineState())
    	*/
    	derived bool IsSimple;
    	/*
    	A State with isSubmachineState=true is said to be a submachine State Such a State refers to another StateMachine(submachine).
    	
    	spec:
    	    result = (submachine <> null)
    	*/
    	derived bool IsSubmachineState;
    	/*
    	The Regions owned directly by the State.
    	*/
    	set<Region> Region subsets Namespace.OwnedMember;
    	/*
    	Specifies conditions that are always true when this State is the current State. In ProtocolStateMachines state invariants are additional conditions to the preconditions of the outgoing Transitions, and to the postcondition of the incoming Transitions.
    	*/
    	Constraint StateInvariant subsets Namespace.OwnedRule;
    	/*
    	The StateMachine that is to be inserted in place of the (submachine) State.
    	*/
    	StateMachine Submachine;
    	/*
    	The query containingStateMachine() returns the StateMachine that contains the State either directly or transitively.
    	
    	spec:
    	    result = (container.containingStateMachine())
    	*/
    	StateMachine ContainingStateMachine();
    	/*
    	The query isConsistentWith specifies that a non-final State can only be redefined by a non-final State (this is overridden by FinalState to allow a FinalState to be redefined by a FinalState) and, if the redefined State is a submachine State, then the redefining State must be a submachine state whose submachine is a redefinition of the submachine of the redefined State. Note that consistency requirements for the redefinition of Regions and connectionPoint Pseudostates within a composite State and connection ConnectionPoints of a submachine State are specified by the isConsistentWith and isRedefinitionContextValid operations for Region and Vertex (and its subclasses, Pseudostate and ConnectionPointReference).
    	
    	spec:
    	    result = (redefiningElement.oclIsTypeOf(State) and 
    	      let redefiningState : State = redefiningElement.oclAsType(State) in
    	        submachine <> null implies (redefiningState.submachine <> null and
    	          redefiningState.submachine.extendedStateMachine->includes(submachine)))
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    StateMachines can be used to express event-driven behaviors of parts of a system. Behavior is modeled as a traversal of a graph of Vertices interconnected by one or more joined Transition arcs that are triggered by the dispatching of successive Event occurrences. During this traversal, the StateMachine may execute a sequence of Behaviors associated with various elements of the StateMachine.
    */
    class StateMachine : Behavior
    {
    	/*
    	The connection points defined for this StateMachine. They represent the interface of the StateMachine when used as part of submachine State
    	*/
    	set<Pseudostate> ConnectionPoint subsets Namespace.OwnedMember;
    	/*
    	The StateMachines of which this is an extension.
    	*/
    	set<StateMachine> ExtendedStateMachine redefines Behavior.RedefinedBehavior;
    	/*
    	The Regions owned directly by the StateMachine.
    	*/
    	set<Region> Region subsets Namespace.OwnedMember;
    	/*
    	References the submachine(s) in case of a submachine State. Multiple machines are referenced in case of a concurrent State.
    	*/
    	set<State> SubmachineState;
    	/*
    	The operation LCA(s1,s2) returns the Region that is the least common ancestor of Vertices s1 and s2, based on the StateMachine containment hierarchy.
    	
    	spec:
    	    result = (if ancestor(s1, s2) then 
    	        s2.container
    	    else
    	    	if ancestor(s2, s1) then
    	    	    s1.container 
    	    	else 
    	    	    LCA(s1.container.state, s2.container.state)
    	    	endif
    	    endif)
    	*/
    	Region LCA(Vertex s1, Vertex s2);
    	/*
    	The query ancestor(s1, s2) checks whether Vertex s2 is an ancestor of Vertex s1.
    	
    	spec:
    	    result = (if (s2 = s1) then 
    	    	true 
    	    else 
    	    	if s1.container.stateMachine->notEmpty() then 
    	    	    true
    	    	else 
    	    	    if s2.container.stateMachine->notEmpty() then 
    	    	        false
    	    	    else
    	    	        ancestor(s1, s2.container.state)
    	    	     endif
    	    	 endif
    	    endif  )
    	*/
    	bool Ancestor(Vertex s1, Vertex s2);
    	/*
    	The query isConsistentWith specifies that a StateMachine can be redefined by any other StateMachine for which the redefinition context is valid (see the isRedefinitionContextValid operation). Note that consistency requirements for the redefinition of Regions and connectionPoint Pseudostates owned by a StateMachine are specified by the isConsistentWith and isRedefinitionContextValid operations for Region and Vertex (and its subclass Pseudostate).
    	
    	spec:
    	    result = true
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    	/*
    	The query isRedefinitionContextValid specifies whether the redefinition context of a StateMachine is properly related to the redefinition contexts of a StateMachine it redefines. The requirement is that the context BehavioredClassifier of a redefining StateMachine must specialize the context Classifier of the redefined StateMachine. If the redefining StateMachine does not have a context BehavioredClassifier, then then the redefining StateMachine also must not have a context BehavioredClassifier but must, instead, specialize the redefining StateMachine.
    	
    	spec:
    	    result = (redefinedElement.oclIsKindOf(StateMachine) and
    	      let parentContext : BehavioredClassifier =
    	        redefinedElement.oclAsType(StateMachine).context in
    	      if context = null then
    	        parentContext = null and self.allParents()→includes(redefinedElement)
    	      else
    	        parentContext <> null and context.allParents()->includes(parentContext)
    	      endif)
    	*/
    	bool IsRedefinitionContextValid(RedefinableElement redefinedElement);
    	/*
    	This utility funciton is like the LCA, except that it returns the nearest composite State that contains both input Vertices.
    	
    	spec:
    	    result = (if v2.oclIsTypeOf(State) and ancestor(v1, v2) then
    	    	v2.oclAsType(State)
    	    else if v1.oclIsTypeOf(State) and ancestor(v2, v1) then
    	    	v1.oclAsType(State)
    	    else if (v1.container.state->isEmpty() or v2.container.state->isEmpty()) then 
    	    	null.oclAsType(State)
    	    else LCAState(v1.container.state, v2.container.state)
    	    endif endif endif)
    	*/
    	State LCAState(Vertex v1, Vertex v2);
    }

    /*
    A Transition represents an arc between exactly one source Vertex and exactly one Target vertex (the source and targets may be the same Vertex). It may form part of a compound transition, which takes the StateMachine from one steady State configuration to another, representing the full response of the StateMachine to an occurrence of an Event that triggered it.
    */
    class Transition : Namespace, RedefinableElement
    {
    	/*
    	Designates the Region that owns this Transition.
    	*/
    	Region Container subsets NamedElement.Namespace;
    	/*
    	Specifies an optional behavior to be performed when the Transition fires.
    	*/
    	Behavior Effect subsets Element.OwnedElement;
    	/*
    	A guard is a Constraint that provides a fine-grained control over the firing of the Transition. The guard is evaluated when an Event occurrence is dispatched by the StateMachine. If the guard is true at that time, the Transition may be enabled, otherwise, it is disabled. Guards should be pure expressions without side effects. Guard expressions with side effects are ill formed.
    	*/
    	Constraint Guard subsets Namespace.OwnedRule;
    	/*
    	Indicates the precise type of the Transition.
    	*/
    	TransitionKind Kind;
    	/*
    	The Transition that is redefined by this Transition.
    	*/
    	Transition RedefinedTransition subsets RedefinableElement.RedefinedElement;
    	/*
    	References the Classifier in which context this element may be redefined.
    	
    	spec:
    	    result = containingStateMachine()
    	*/
    	derived Classifier RedefinitionContext redefines RedefinableElement.RedefinitionContext;
    	/*
    	Designates the originating Vertex (State or Pseudostate) of the Transition.
    	*/
    	Vertex Source;
    	/*
    	Designates the target Vertex that is reached when the Transition is taken.
    	*/
    	Vertex Target;
    	/*
    	Specifies the Triggers that may fire the transition.
    	*/
    	set<Trigger> Trigger subsets Element.OwnedElement;
    	/*
    	The query containingStateMachine() returns the StateMachine that contains the Transition either directly or transitively.
    	
    	spec:
    	    result = (container.containingStateMachine())
    	*/
    	StateMachine ContainingStateMachine();
    	/*
    	The query isConsistentWith specifies that a redefining Transition is consistent with a redefined Transition provided that the source Vertex of the redefining Transition redefines the source Vertex of the redefined Transition.
    	
    	spec:
    	    result = (redefiningElement.oclIsKindOf(Transition) and
    	      redefiningElement.oclAsType(Transition).source.redefinedTransition = source)
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    A Vertex is an abstraction of a node in a StateMachine graph. It can be the source or destination of any number of Transitions.
    */
    abstract class Vertex : NamedElement, RedefinableElement
    {
    	/*
    	The Region that contains this Vertex.
    	*/
    	Region Container subsets NamedElement.Namespace;
    	/*
    	Specifies the Transitions entering this Vertex.
    	
    	spec:
    	    result = (Transition.allInstances()->select(target=self))
    	*/
    	derived set<Transition> Incoming;
    	/*
    	Specifies the Transitions departing from this Vertex.
    	
    	spec:
    	    result = (Transition.allInstances()->select(source=self))
    	*/
    	derived set<Transition> Outgoing;
    	/*
    	References the Classifier in which context this element may be redefined.
    	
    	spec:
    	    result = containingStateMachine()
    	*/
    	derived Classifier RedefinitionContext redefines RedefinableElement.RedefinitionContext;
    	/*
    	The Vertex of which this Vertex is a redefinition.
    	*/
    	Vertex RedefinedVertex subsets RedefinableElement.RedefinedElement;
    	/*
    	The operation containingStateMachine() returns the StateMachine in which this Vertex is defined.
    	
    	spec:
    	    result = (if container <> null
    	    then
    	    -- the container is a region
    	       container.containingStateMachine()
    	    else 
    	       if (self.oclIsKindOf(Pseudostate)) and ((self.oclAsType(Pseudostate).kind = PseudostateKind::entryPoint) or (self.oclAsType(Pseudostate).kind = PseudostateKind::exitPoint)) then
    	          self.oclAsType(Pseudostate).stateMachine
    	       else 
    	          if (self.oclIsKindOf(ConnectionPointReference)) then
    	              self.oclAsType(ConnectionPointReference).state.containingStateMachine() -- no other valid cases possible
    	          else 
    	              null
    	          endif
    	       endif
    	    endif
    	    
    	    )
    	*/
    	StateMachine ContainingStateMachine();
    	/*
    	This utility operation returns true if the Vertex is contained in the State s (input argument).
    	
    	spec:
    	    result = (if not s.isComposite() or container->isEmpty() then
    	    	false
    	    else
    	    	if container.state = s then 
    	    		true
    	    	else
    	    		container.state.isContainedInState(s)
    	    	endif
    	    endif)
    	*/
    	bool IsContainedInState(State s);
    	/*
    	This utility query returns true if the Vertex is contained in the Region r (input argument).
    	
    	spec:
    	    result = (if (container = r) then
    	    	true
    	    else
    	    	if (r.state->isEmpty()) then
    	    		false
    	    	else
    	    		container.state.isContainedInRegion(r)
    	    	endif
    	    endif)
    	*/
    	bool IsContainedInRegion(Region r);
    	/*
    	The query isRedefinitionContextValid specifies that the redefinition context of a redefining Vertex is properly related to the redefinition context of the redefined Vertex if the owner of the redefining Vertex is a redefinition of the owner of the redefined Vertex. Note that the owner of a Vertex may be a Region, a StateMachine (for a connectionPoint Pseudostate), or a State (for a connectionPoint Pseudostate or a connection ConnectionPointReference), all of which are RedefinableElements.
    	
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	spec:
    	    result = (redefinedElement.oclIsKindOf(Vertex) and
    	      owner.oclAsType(RedefinableElement).redefinedElement->includes(redefinedElement.owner))
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    A BehavioredClassifier may have InterfaceRealizations, and owns a set of Behaviors one of which may specify the behavior of the BehavioredClassifier itself.
    */
    abstract class BehavioredClassifier : Classifier
    {
    	/*
    	A Behavior that specifies the behavior of the BehavioredClassifier itself.
    	*/
    	Behavior ClassifierBehavior subsets BehavioredClassifier.OwnedBehavior;
    	/*
    	The set of InterfaceRealizations owned by the BehavioredClassifier. Interface realizations reference the Interfaces of which the BehavioredClassifier is an implementation.
    	*/
    	set<InterfaceRealization> InterfaceRealization subsets Element.OwnedElement, NamedElement.ClientDependency;
    	/*
    	Behaviors owned by a BehavioredClassifier.
    	*/
    	set<Behavior> OwnedBehavior subsets Namespace.OwnedMember;
    }

    /*
    A DataType is a type whose instances are identified only by their value.
    */
    class DataType : Classifier
    {
    	/*
    	The attributes owned by the DataType.
    	*/
    	list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    	/*
    	The Operations owned by the DataType.
    	*/
    	list<Operation> OwnedOperation subsets Classifier.Feature, Namespace.OwnedMember;
    }

    /*
    An Enumeration is a DataType whose values are enumerated in the model as EnumerationLiterals.
    */
    class Enumeration : DataType
    {
    	/*
    	The ordered set of literals owned by this Enumeration.
    	*/
    	list<EnumerationLiteral> OwnedLiteral subsets Namespace.OwnedMember;
    }

    /*
    An EnumerationLiteral is a user-defined data value for an Enumeration.
    */
    class EnumerationLiteral : InstanceSpecification
    {
    	/*
    	The classifier of this EnumerationLiteral derived to be equal to its Enumeration.
    	
    	spec:
    	    result = (enumeration)
    	*/
    	derived Enumeration Classifier redefines InstanceSpecification.Classifier;
    	/*
    	The Enumeration that this EnumerationLiteral is a member of.
    	*/
    	Enumeration Enumeration subsets NamedElement.Namespace;
    }

    /*
    Interfaces declare coherent services that are implemented by BehavioredClassifiers that implement the Interfaces via InterfaceRealizations.
    */
    class Interface : Classifier
    {
    	/*
    	References all the Classifiers that are defined (nested) within the Interface.
    	*/
    	list<Classifier> NestedClassifier subsets Namespace.OwnedMember;
    	/*
    	The attributes (i.e., the Properties) owned by the Interface.
    	*/
    	list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    	/*
    	The Operations owned by the Interface.
    	*/
    	list<Operation> OwnedOperation subsets Classifier.Feature, Namespace.OwnedMember;
    	/*
    	Receptions that objects providing this Interface are willing to accept.
    	*/
    	set<Reception> OwnedReception subsets Classifier.Feature, Namespace.OwnedMember;
    	/*
    	References a ProtocolStateMachine specifying the legal sequences of the invocation of the BehavioralFeatures described in the Interface.
    	*/
    	ProtocolStateMachine Protocol subsets Namespace.OwnedMember;
    	/*
    	References all the Interfaces redefined by this Interface.
    	*/
    	set<Interface> RedefinedInterface subsets Classifier.RedefinedClassifier;
    }

    /*
    An InterfaceRealization is a specialized realization relationship between a BehavioredClassifier and an Interface. This relationship signifies that the realizing BehavioredClassifier conforms to the contract specified by the Interface.
    */
    class InterfaceRealization : Realization
    {
    	/*
    	References the Interface specifying the conformance contract.
    	*/
    	Interface Contract subsets Dependency.Supplier;
    	/*
    	References the BehavioredClassifier that owns this InterfaceRealization, i.e., the BehavioredClassifier that realizes the Interface to which it refers.
    	*/
    	BehavioredClassifier ImplementingClassifier subsets Dependency.Client, Element.Owner;
    }

    /*
    A PrimitiveType defines a predefined DataType, without any substructure. A PrimitiveType may have an algebra and operations defined outside of UML, for example, mathematically.
    */
    class PrimitiveType : DataType
    {
    }

    /*
    A Reception is a declaration stating that a Classifier is prepared to react to the receipt of a Signal.
    */
    class Reception : BehavioralFeature
    {
    	/*
    	The Signal that this Reception handles.
    	*/
    	Signal Signal;
    }

    /*
    A Signal is a specification of a kind of communication between objects in which a reaction is asynchronously triggered in the receiver without a reply.
    */
    class Signal : Classifier
    {
    	/*
    	The attributes owned by the Signal.
    	*/
    	list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    }

    /*
    An extension is used to indicate that the properties of a metaclass are extended through a stereotype, and gives the ability to flexibly add (and later remove) stereotypes to classes.
    */
    class Extension : Association
    {
    	/*
    	Indicates whether an instance of the extending stereotype must be created when an instance of the extended class is created. The attribute value is derived from the value of the lower property of the ExtensionEnd referenced by Extension::ownedEnd; a lower value of 1 means that isRequired is true, but otherwise it is false. Since the default value of ExtensionEnd::lower is 0, the default value of isRequired is false.
    	
    	spec:
    	    result = (ownedEnd.lowerBound() = 1)
    	*/
    	derived bool IsRequired;
    	/*
    	References the Class that is extended through an Extension. The property is derived from the type of the memberEnd that is not the ownedEnd.
    	
    	spec:
    	    result = (metaclassEnd().type.oclAsType(Class))
    	*/
    	derived Class Metaclass;
    	/*
    	References the end of the extension that is typed by a Stereotype.
    	*/
    	ExtensionEnd OwnedEnd redefines Association.OwnedEnd;
    	/*
    	The query metaclassEnd() returns the Property that is typed by a metaclass (as opposed to a stereotype).
    	
    	spec:
    	    result = (memberEnd->reject(p | ownedEnd->includes(p.oclAsType(ExtensionEnd)))->any(true))
    	*/
    	Property MetaclassEnd();
    }

    /*
    An extension end is used to tie an extension to a stereotype when extending a metaclass.
    The default multiplicity of an extension end is 0..1.
    */
    class ExtensionEnd : Property
    {
    	/*
    	This redefinition changes the default multiplicity of association ends, since model elements are usually extended by 0 or 1 instance of the extension stereotype.
    	*/
    	derived int Lower redefines MultiplicityElement.Lower;
    	/*
    	References the type of the ExtensionEnd. Note that this association restricts the possible types of an ExtensionEnd to only be Stereotypes.
    	*/
    	Stereotype Type redefines TypedElement.Type;
    	/*
    	The query lowerBound() returns the lower bound of the multiplicity as an Integer. This is a redefinition of the default lower bound, which normally, for MultiplicityElements, evaluates to 1 if empty.
    	
    	spec:
    	    result = (if lowerValue=null then 0 else lowerValue.integerValue() endif)
    	*/
    	int LowerBound();
    }

    /*
    Physical definition of a graphical image.
    */
    class Image : Element
    {
    	/*
    	This contains the serialization of the image according to the format. The value could represent a bitmap, image such as a GIF file, or drawing 'instructions' using a standard such as Scalable Vector Graphic (SVG) (which is XML based).
    	*/
    	string Content;
    	/*
    	This indicates the format of the content, which is how the string content should be interpreted. The following values are reserved: SVG, GIF, PNG, JPG, WMF, EMF, BMP. In addition the prefix 'MIME: ' is also reserved. This option can be used as an alternative to express the reserved values above, for example "SVG" could instead be expressed as "MIME: image/svg+xml".
    	*/
    	string Format;
    	/*
    	This contains a location that can be used by a tool to locate the image as an alternative to embedding it in the stereotype.
    	*/
    	string Location;
    }

    /*
    A model captures a view of a physical system. It is an abstraction of the physical system, with a certain purpose. This purpose determines what is to be included in the model and what is irrelevant. Thus the model completely describes those aspects of the physical system that are relevant to the purpose of the model, at the appropriate level of detail.
    */
    class Model : Package
    {
    	/*
    	The name of the viewpoint that is expressed by a model (this name may refer to a profile definition).
    	*/
    	string Viewpoint;
    }

    /*
    A package can have one or more profile applications to indicate which profiles have been applied. Because a profile is a package, it is possible to apply a profile not only to packages, but also to profiles.
    Package specializes TemplateableElement and PackageableElement specializes ParameterableElement to specify that a package can be used as a template and a PackageableElement as a template parameter.
    A package is used to group elements, and provides a namespace for the grouped elements.
    */
    class Package : PackageableElement, TemplateableElement, Namespace
    {
    	/*
    	Provides an identifier for the package that can be used for many purposes. A URI is the universally unique identification of the package following the IETF URI specification, RFC 2396 http://www.ietf.org/rfc/rfc2396.txt and it must comply with those syntax rules.
    	*/
    	string URI;
    	/*
    	References the packaged elements that are Packages.
    	
    	spec:
    	    result = (packagedElement->select(oclIsKindOf(Package))->collect(oclAsType(Package))->asSet())
    	*/
    	derived set<Package> NestedPackage subsets Package.PackagedElement;
    	/*
    	References the Package that owns this Package.
    	*/
    	Package NestingPackage;
    	/*
    	References the Stereotypes that are owned by the Package.
    	
    	spec:
    	    result = (packagedElement->select(oclIsKindOf(Stereotype))->collect(oclAsType(Stereotype))->asSet())
    	*/
    	derived set<Stereotype> OwnedStereotype subsets Package.PackagedElement;
    	/*
    	References the packaged elements that are Types.
    	
    	spec:
    	    result = (packagedElement->select(oclIsKindOf(Type))->collect(oclAsType(Type))->asSet())
    	*/
    	derived set<Type> OwnedType subsets Package.PackagedElement;
    	/*
    	References the PackageMerges that are owned by this Package.
    	*/
    	set<PackageMerge> PackageMerge subsets Element.OwnedElement;
    	/*
    	Specifies the packageable elements that are owned by this Package.
    	*/
    	set<PackageableElement> PackagedElement subsets Namespace.OwnedMember;
    	/*
    	References the ProfileApplications that indicate which profiles have been applied to the Package.
    	*/
    	set<ProfileApplication> ProfileApplication subsets Element.OwnedElement;
    	/*
    	The query allApplicableStereotypes() returns all the directly or indirectly owned stereotypes, including stereotypes contained in sub-profiles.
    	
    	spec:
    	    result = (let ownedPackages : Bag(Package) = ownedMember->select(oclIsKindOf(Package))->collect(oclAsType(Package)) in
    	     ownedStereotype->union(ownedPackages.allApplicableStereotypes())->flatten()->asSet()
    	    )
    	*/
    	set<Stereotype> AllApplicableStereotypes();
    	/*
    	The query containingProfile() returns the closest profile directly or indirectly containing this package (or this package itself, if it is a profile).
    	
    	spec:
    	    result = (if self.oclIsKindOf(Profile) then 
    	    	self.oclAsType(Profile)
    	    else
    	    	self.namespace.oclAsType(Package).containingProfile()
    	    endif)
    	*/
    	Profile ContainingProfile();
    	/*
    	The query makesVisible() defines whether a Package makes an element visible outside itself. Elements with no visibility and elements with public visibility are made visible.
    	
    	pre:
    	    member->includes(el)
    	spec:
    	    result = (ownedMember->includes(el) or
    	    (elementImport->select(ei|ei.importedElement = VisibilityKind::public)->collect(importedElement.oclAsType(NamedElement))->includes(el)) or
    	    (packageImport->select(visibility = VisibilityKind::public)->collect(importedPackage.member->includes(el))->notEmpty()))
    	*/
    	bool MakesVisible(NamedElement el);
    	/*
    	The query mustBeOwned() indicates whether elements of this type must have an owner.
    	
    	spec:
    	    result = (false)
    	*/
    	bool MustBeOwned();
    	/*
    	The query visibleMembers() defines which members of a Package can be accessed outside it.
    	
    	spec:
    	    result = (member->select( m | m.oclIsKindOf(PackageableElement) and self.makesVisible(m))->collect(oclAsType(PackageableElement))->asSet())
    	*/
    	set<PackageableElement> VisibleMembers();
    }

    /*
    A package merge defines how the contents of one package are extended by the contents of another package.
    */
    class PackageMerge : DirectedRelationship
    {
    	/*
    	References the Package that is to be merged with the receiving package of the PackageMerge.
    	*/
    	Package MergedPackage subsets DirectedRelationship.Target;
    	/*
    	References the Package that is being extended with the contents of the merged package of the PackageMerge.
    	*/
    	Package ReceivingPackage subsets DirectedRelationship.Source, Element.Owner;
    }

    /*
    A profile defines limited extensions to a reference metamodel with the purpose of adapting the metamodel to a specific platform or domain.
    */
    class Profile : Package
    {
    	/*
    	References a metaclass that may be extended.
    	*/
    	set<ElementImport> MetaclassReference subsets Namespace.ElementImport;
    	/*
    	References a package containing (directly or indirectly) metaclasses that may be extended.
    	*/
    	set<PackageImport> MetamodelReference subsets Namespace.PackageImport;
    }

    /*
    A profile application is used to show which profiles have been applied to a package.
    */
    class ProfileApplication : DirectedRelationship
    {
    	/*
    	References the Profiles that are applied to a Package through this ProfileApplication.
    	*/
    	Profile AppliedProfile subsets DirectedRelationship.Target;
    	/*
    	The package that owns the profile application.
    	*/
    	Package ApplyingPackage subsets DirectedRelationship.Source, Element.Owner;
    	/*
    	Specifies that the Profile filtering rules for the metaclasses of the referenced metamodel shall be strictly applied.
    	*/
    	bool IsStrict;
    }

    /*
    A stereotype defines how an existing metaclass may be extended, and enables the use of platform or domain specific terminology or notation in place of, or in addition to, the ones used for the extended metaclass.
    */
    class Stereotype : Class
    {
    	/*
    	Stereotype can change the graphical appearance of the extended model element by using attached icons. When this association is not null, it references the location of the icon content to be displayed within diagrams presenting the extended model elements.
    	*/
    	set<Image> Icon subsets Element.OwnedElement;
    	/*
    	The profile that directly or indirectly contains this stereotype.
    	
    	spec:
    	    result = (self.containingProfile())
    	*/
    	derived Profile Profile;
    	/*
    	The query containingProfile returns the closest profile directly or indirectly containing this stereotype.
    	
    	spec:
    	    result = (self.namespace.oclAsType(Package).containingProfile())
    	*/
    	Profile ContainingProfile();
    }

    /*
    An ActionExecutionSpecification is a kind of ExecutionSpecification representing the execution of an Action.
    */
    class ActionExecutionSpecification : ExecutionSpecification
    {
    	/*
    	Action whose execution is occurring.
    	*/
    	Action Action;
    }

    /*
    A BehaviorExecutionSpecification is a kind of ExecutionSpecification representing the execution of a Behavior.
    */
    class BehaviorExecutionSpecification : ExecutionSpecification
    {
    	/*
    	Behavior whose execution is occurring.
    	*/
    	Behavior Behavior;
    }

    /*
    A CombinedFragment defines an expression of InteractionFragments. A CombinedFragment is defined by an interaction operator and corresponding InteractionOperands. Through the use of CombinedFragments the user will be able to describe a number of traces in a compact and concise manner.
    */
    class CombinedFragment : InteractionFragment
    {
    	/*
    	Specifies the gates that form the interface between this CombinedFragment and its surroundings
    	*/
    	set<Gate> CfragmentGate subsets Element.OwnedElement;
    	/*
    	Specifies the operation which defines the semantics of this combination of InteractionFragments.
    	*/
    	InteractionOperatorKind InteractionOperator;
    	/*
    	The set of operands of the combined fragment.
    	*/
    	list<InteractionOperand> Operand subsets Element.OwnedElement;
    }

    /*
    A ConsiderIgnoreFragment is a kind of CombinedFragment that is used for the consider and ignore cases, which require lists of pertinent Messages to be specified.
    */
    class ConsiderIgnoreFragment : CombinedFragment
    {
    	/*
    	The set of messages that apply to this fragment.
    	*/
    	set<NamedElement> Message;
    }

    /*
    A Continuation is a syntactic way to define continuations of different branches of an alternative CombinedFragment. Continuations are intuitively similar to labels representing intermediate points in a flow of control.
    */
    class Continuation : InteractionFragment
    {
    	/*
    	True: when the Continuation is at the end of the enclosing InteractionFragment and False when it is in the beginning.
    	*/
    	bool Setting;
    }

    /*
    A DestructionOccurenceSpecification models the destruction of an object.
    */
    class DestructionOccurrenceSpecification : MessageOccurrenceSpecification
    {
    }

    /*
    An ExecutionOccurrenceSpecification represents moments in time at which Actions or Behaviors start or finish.
    */
    class ExecutionOccurrenceSpecification : OccurrenceSpecification
    {
    	/*
    	References the execution specification describing the execution that is started or finished at this execution event.
    	*/
    	ExecutionSpecification Execution;
    }

    /*
    An ExecutionSpecification is a specification of the execution of a unit of Behavior or Action within the Lifeline. The duration of an ExecutionSpecification is represented by two OccurrenceSpecifications, the start OccurrenceSpecification and the finish OccurrenceSpecification.
    */
    abstract class ExecutionSpecification : InteractionFragment
    {
    	/*
    	References the OccurrenceSpecification that designates the finish of the Action or Behavior.
    	*/
    	OccurrenceSpecification Finish;
    	/*
    	References the OccurrenceSpecification that designates the start of the Action or Behavior.
    	*/
    	OccurrenceSpecification Start;
    }

    /*
    A Gate is a MessageEnd which serves as a connection point for relating a Message which has a MessageEnd (sendEvent / receiveEvent) outside an InteractionFragment with another Message which has a MessageEnd (receiveEvent / sendEvent)  inside that InteractionFragment.
    */
    class Gate : MessageEnd
    {
    	/*
    	This query returns true if this Gate is attached to the boundary of a CombinedFragment, and its other end (if present)  is outside of the same CombinedFragment.
    	
    	spec:
    	    result = (self.oppositeEnd()-> notEmpty() and combinedFragment->notEmpty() implies
    	    let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
    	    if oppEnd.oclIsKindOf(MessageOccurrenceSpecification) 
    	    then let oppMOS : MessageOccurrenceSpecification = oppEnd.oclAsType(MessageOccurrenceSpecification)
    	    in  self.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	         union(self.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet()) =
    	         oppMOS.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	         union(oppMOS.enclosingOperand.oclAsType(InteractionFragment)->asSet())
    	    else let oppGate : Gate = oppEnd.oclAsType(Gate) 
    	    in self.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	         union(self.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet()) =
    	         oppGate.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	         union(oppGate.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet())
    	    endif)
    	*/
    	bool IsOutsideCF();
    	/*
    	This query returns true if this Gate is attached to the boundary of a CombinedFragment, and its other end (if present) is inside of an InteractionOperator of the same CombinedFragment.
    	
    	spec:
    	    result = (self.oppositeEnd()-> notEmpty() and combinedFragment->notEmpty() implies
    	    let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
    	    if oppEnd.oclIsKindOf(MessageOccurrenceSpecification)
    	    then let oppMOS : MessageOccurrenceSpecification
    	    = oppEnd.oclAsType(MessageOccurrenceSpecification)
    	    in combinedFragment = oppMOS.enclosingOperand.combinedFragment
    	    else let oppGate : Gate = oppEnd.oclAsType(Gate)
    	    in combinedFragment = oppGate.combinedFragment.enclosingOperand.combinedFragment
    	    endif)
    	*/
    	bool IsInsideCF();
    	/*
    	This query returns true value if this Gate is an actualGate of an InteractionUse.
    	
    	spec:
    	    result = (interactionUse->notEmpty())
    	*/
    	bool IsActual();
    	/*
    	This query returns true if this Gate is a formalGate of an Interaction.
    	
    	<p>interaction-&gt;notEmpty()</p>
    	spec:
    	    result = (interaction->notEmpty())
    	*/
    	bool IsFormal();
    	/*
    	This query returns the name of the gate, either the explicit name (.name) or the constructed name ('out_" or 'in_' concatenated in front of .message.name) if the explicit name is not present.
    	
    	spec:
    	    result = (if name->notEmpty() then name->asOrderedSet()->first()
    	    else  if isActual() or isOutsideCF() 
    	      then if isSend() 
    	        then 'out_'.concat(self.message.name->asOrderedSet()->first())
    	        else 'in_'.concat(self.message.name->asOrderedSet()->first())
    	        endif
    	      else if isSend()
    	        then 'in_'.concat(self.message.name->asOrderedSet()->first())
    	        else 'out_'.concat(self.message.name->asOrderedSet()->first())
    	        endif
    	      endif
    	    endif)
    	*/
    	string GetName();
    	/*
    	This query returns true if the name of this Gate matches the name of the in parameter Gate, and the messages for the two Gates correspond. The Message for one Gate (say A) corresponds to the Message for another Gate (say B) if (A and B have the same name value) and (if A is a sendEvent then B is a receiveEvent) and (if A is a receiveEvent then B is a sendEvent) and (A and B have the same messageSort value) and (A and B have the same signature value).
    	
    	spec:
    	    result = (self.getName() = gateToMatch.getName() and 
    	    self.message.messageSort = gateToMatch.message.messageSort and
    	    self.message.name = gateToMatch.message.name and
    	    self.message.sendEvent->includes(self) implies gateToMatch.message.receiveEvent->includes(gateToMatch)  and
    	    self.message.receiveEvent->includes(self) implies gateToMatch.message.sendEvent->includes(gateToMatch) and
    	    self.message.signature = gateToMatch.message.signature)
    	*/
    	bool Matches(Gate gateToMatch);
    	/*
    	The query isDistinguishableFrom() specifies that two Gates may coexist in the same Namespace, without an explicit name property. The association end formalGate subsets ownedElement, and since the Gate name attribute
    	is optional, it is allowed to have two formal gates without an explicit name, but having derived names which are distinct.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsDistinguishableFrom(NamedElement n, Namespace ns);
    	/*
    	If the Gate is an inside Combined Fragment Gate, this operation returns the InteractionOperand that the opposite end of this Gate is included within.
    	
    	spec:
    	    result = (if isInsideCF() then
    	      let oppEnd : MessageEnd = self.oppositeEnd()->asOrderedSet()->first() in
    	        if oppEnd.oclIsKindOf(MessageOccurrenceSpecification)
    	        then let oppMOS : MessageOccurrenceSpecification = oppEnd.oclAsType(MessageOccurrenceSpecification)
    	            in oppMOS.enclosingOperand->asOrderedSet()->first()
    	        else let oppGate : Gate = oppEnd.oclAsType(Gate)
    	            in oppGate.combinedFragment.enclosingOperand->asOrderedSet()->first()
    	        endif
    	      else null
    	    endif)
    	*/
    	InteractionOperand GetOperand();
    }

    /*
    A GeneralOrdering represents a binary relation between two OccurrenceSpecifications, to describe that one OccurrenceSpecification must occur before the other in a valid trace. This mechanism provides the ability to define partial orders of OccurrenceSpecifications that may otherwise not have a specified order.
    */
    class GeneralOrdering : NamedElement
    {
    	/*
    	The OccurrenceSpecification referenced comes after the OccurrenceSpecification referenced by before.
    	*/
    	OccurrenceSpecification After;
    	/*
    	The OccurrenceSpecification referenced comes before the OccurrenceSpecification referenced by after.
    	*/
    	OccurrenceSpecification Before;
    }

    /*
    An Interaction is a unit of Behavior that focuses on the observable exchange of information between connectable elements.
    */
    class Interaction : InteractionFragment, Behavior
    {
    	/*
    	Actions owned by the Interaction.
    	*/
    	set<Action> Action subsets Element.OwnedElement;
    	/*
    	Specifies the gates that form the message interface between this Interaction and any InteractionUses which reference it.
    	*/
    	set<Gate> FormalGate subsets Namespace.OwnedMember;
    	/*
    	The ordered set of fragments in the Interaction.
    	*/
    	list<InteractionFragment> Fragment subsets Namespace.OwnedMember;
    	/*
    	Specifies the participants in this Interaction.
    	*/
    	set<Lifeline> Lifeline subsets Namespace.OwnedMember;
    	/*
    	The Messages contained in this Interaction.
    	*/
    	set<Message> Message subsets Namespace.OwnedMember;
    }

    /*
    An InteractionConstraint is a Boolean expression that guards an operand in a CombinedFragment.
    */
    class InteractionConstraint : Constraint
    {
    	/*
    	The maximum number of iterations of a loop
    	*/
    	ValueSpecification Maxint subsets Element.OwnedElement;
    	/*
    	The minimum number of iterations of a loop
    	*/
    	ValueSpecification Minint subsets Element.OwnedElement;
    }

    /*
    InteractionFragment is an abstract notion of the most general interaction unit. An InteractionFragment is a piece of an Interaction. Each InteractionFragment is conceptually like an Interaction by itself.
    */
    abstract class InteractionFragment : NamedElement
    {
    	/*
    	References the Lifelines that the InteractionFragment involves.
    	*/
    	set<Lifeline> Covered;
    	/*
    	The Interaction enclosing this InteractionFragment.
    	*/
    	Interaction EnclosingInteraction subsets NamedElement.Namespace;
    	/*
    	The operand enclosing this InteractionFragment (they may nest recursively).
    	*/
    	InteractionOperand EnclosingOperand subsets NamedElement.Namespace;
    	/*
    	The general ordering relationships contained in this fragment.
    	*/
    	set<GeneralOrdering> GeneralOrdering subsets Element.OwnedElement;
    }

    /*
    An InteractionOperand is contained in a CombinedFragment. An InteractionOperand represents one operand of the expression given by the enclosing CombinedFragment.
    */
    class InteractionOperand : InteractionFragment, Namespace
    {
    	/*
    	The fragments of the operand.
    	*/
    	list<InteractionFragment> Fragment subsets Namespace.OwnedMember;
    	/*
    	Constraint of the operand.
    	*/
    	InteractionConstraint Guard subsets Element.OwnedElement;
    }

    /*
    An InteractionUse refers to an Interaction. The InteractionUse is a shorthand for copying the contents of the referenced Interaction where the InteractionUse is. To be accurate the copying must take into account substituting parameters with arguments and connect the formal Gates with the actual ones.
    */
    class InteractionUse : InteractionFragment
    {
    	/*
    	The actual gates of the InteractionUse.
    	*/
    	set<Gate> ActualGate subsets Element.OwnedElement;
    	/*
    	The actual arguments of the Interaction.
    	*/
    	list<ValueSpecification> Argument subsets Element.OwnedElement;
    	/*
    	Refers to the Interaction that defines its meaning.
    	*/
    	Interaction RefersTo;
    	/*
    	The value of the executed Interaction.
    	*/
    	ValueSpecification ReturnValue subsets Element.OwnedElement;
    	/*
    	The recipient of the return value.
    	*/
    	Property ReturnValueRecipient;
    }

    /*
    A Lifeline represents an individual participant in the Interaction. While parts and structural features may have multiplicity greater than 1, Lifelines represent only one interacting entity.
    */
    class Lifeline : NamedElement
    {
    	/*
    	References the InteractionFragments in which this Lifeline takes part.
    	*/
    	set<InteractionFragment> CoveredBy;
    	/*
    	References the Interaction that represents the decomposition.
    	*/
    	PartDecomposition DecomposedAs;
    	/*
    	References the Interaction enclosing this Lifeline.
    	*/
    	Interaction Interaction subsets NamedElement.Namespace;
    	/*
    	References the ConnectableElement within the classifier that contains the enclosing interaction.
    	*/
    	ConnectableElement Represents;
    	/*
    	If the referenced ConnectableElement is multivalued, then this specifies the specific individual part within that set.
    	*/
    	ValueSpecification Selector subsets Element.OwnedElement;
    }

    /*
    A Message defines a particular communication between Lifelines of an Interaction.
    */
    class Message : NamedElement
    {
    	/*
    	The arguments of the Message.
    	*/
    	list<ValueSpecification> Argument subsets Element.OwnedElement;
    	/*
    	The Connector on which this Message is sent.
    	*/
    	Connector Connector;
    	/*
    	The enclosing Interaction owning the Message.
    	*/
    	Interaction Interaction subsets NamedElement.Namespace;
    	/*
    	The derived kind of the Message (complete, lost, found, or unknown).
    	
    	spec:
    	    result = (messageKind)
    	*/
    	derived MessageKind MessageKind;
    	/*
    	The sort of communication reflected by the Message.
    	*/
    	MessageSort MessageSort;
    	/*
    	References the Receiving of the Message.
    	*/
    	MessageEnd ReceiveEvent;
    	/*
    	References the Sending of the Message.
    	*/
    	MessageEnd SendEvent;
    	/*
    	The signature of the Message is the specification of its content. It refers either an Operation or a Signal.
    	*/
    	NamedElement Signature;
    	/*
    	The query isDistinguishableFrom() specifies that any two Messages may coexist in the same Namespace, regardless of their names.
    	
    	spec:
    	    result = (true)
    	*/
    	bool IsDistinguishableFrom(NamedElement n, Namespace ns);
    }

    /*
    MessageEnd is an abstract specialization of NamedElement that represents what can occur at the end of a Message.
    */
    abstract class MessageEnd : NamedElement
    {
    	/*
    	References a Message.
    	*/
    	Message Message;
    	/*
    	This query returns a set including the MessageEnd (if exists) at the opposite end of the Message for this MessageEnd.
    	
    	spec:
    	    result = (message->asSet().messageEnd->asSet()->excluding(self))
    	pre:
    	    message->notEmpty()
    	*/
    	set<MessageEnd> OppositeEnd();
    	/*
    	This query returns value true if this MessageEnd is a sendEvent.
    	
    	pre:
    	    message->notEmpty()
    	spec:
    	    result = (message.sendEvent->asSet()->includes(self))
    	*/
    	bool IsSend();
    	/*
    	This query returns value true if this MessageEnd is a receiveEvent.
    	
    	<p>message-&gt;notEmpty()</p>
    	pre:
    	    message->notEmpty()
    	spec:
    	    result = (message.receiveEvent->asSet()->includes(self))
    	*/
    	bool IsReceive();
    	/*
    	This query returns a set including the enclosing InteractionFragment this MessageEnd is enclosed within.
    	
    	spec:
    	    result = (if self->select(oclIsKindOf(Gate))->notEmpty() 
    	    then -- it is a Gate
    	    let endGate : Gate = 
    	      self->select(oclIsKindOf(Gate)).oclAsType(Gate)->asOrderedSet()->first()
    	      in
    	      if endGate.isOutsideCF() 
    	      then endGate.combinedFragment.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	         union(endGate.combinedFragment.enclosingOperand.oclAsType(InteractionFragment)->asSet())
    	      else if endGate.isInsideCF() 
    	        then endGate.combinedFragment.oclAsType(InteractionFragment)->asSet()
    	        else if endGate.isFormal() 
    	          then endGate.interaction.oclAsType(InteractionFragment)->asSet()
    	          else if endGate.isActual() 
    	            then endGate.interactionUse.enclosingInteraction.oclAsType(InteractionFragment)->asSet()->
    	         union(endGate.interactionUse.enclosingOperand.oclAsType(InteractionFragment)->asSet())
    	            else null
    	            endif
    	          endif
    	        endif
    	      endif
    	    else -- it is a MessageOccurrenceSpecification
    	    let endMOS : MessageOccurrenceSpecification  = 
    	      self->select(oclIsKindOf(MessageOccurrenceSpecification)).oclAsType(MessageOccurrenceSpecification)->asOrderedSet()->first() 
    	      in
    	      if endMOS.enclosingInteraction->notEmpty() 
    	      then endMOS.enclosingInteraction.oclAsType(InteractionFragment)->asSet()
    	      else endMOS.enclosingOperand.oclAsType(InteractionFragment)->asSet()
    	      endif
    	    endif)
    	*/
    	set<InteractionFragment> EnclosingFragment();
    }

    /*
    A MessageOccurrenceSpecification specifies the occurrence of Message events, such as sending and receiving of Signals or invoking or receiving of Operation calls. A MessageOccurrenceSpecification is a kind of MessageEnd. Messages are generated either by synchronous Operation calls or asynchronous Signal sends. They are received by the execution of corresponding AcceptEventActions.
    */
    class MessageOccurrenceSpecification : MessageEnd, OccurrenceSpecification
    {
    }

    /*
    An OccurrenceSpecification is the basic semantic unit of Interactions. The sequences of occurrences specified by them are the meanings of Interactions.
    */
    class OccurrenceSpecification : InteractionFragment
    {
    	/*
    	References the Lifeline on which the OccurrenceSpecification appears.
    	*/
    	Lifeline Covered redefines InteractionFragment.Covered;
    	/*
    	References the GeneralOrderings that specify EventOcurrences that must occur after this OccurrenceSpecification.
    	*/
    	set<GeneralOrdering> ToAfter;
    	/*
    	References the GeneralOrderings that specify EventOcurrences that must occur before this OccurrenceSpecification.
    	*/
    	set<GeneralOrdering> ToBefore;
    }

    /*
    A PartDecomposition is a description of the internal Interactions of one Lifeline relative to an Interaction.
    */
    class PartDecomposition : InteractionUse
    {
    }

    /*
    A StateInvariant is a runtime constraint on the participants of the Interaction. It may be used to specify a variety of different kinds of Constraints, such as values of Attributes or Variables, internal or external States, and so on. A StateInvariant is an InteractionFragment and it is placed on a Lifeline.
    */
    class StateInvariant : InteractionFragment
    {
    	/*
    	References the Lifeline on which the StateInvariant appears.
    	*/
    	Lifeline Covered redefines InteractionFragment.Covered;
    	/*
    	A Constraint that should hold at runtime for this StateInvariant.
    	*/
    	Constraint Invariant subsets Element.OwnedElement;
    }

    /*
    InformationFlows describe circulation of information through a system in a general manner. They do not specify the nature of the information, mechanisms by which it is conveyed, sequences of exchange or any control conditions. During more detailed modeling, representation and realization links may be added to specify which model elements implement an InformationFlow and to show how information is conveyed.  InformationFlows require some kind of “information channel” for unidirectional transmission of information items from sources to targets.  They specify the information channel’s realizations, if any, and identify the information that flows along them.  Information moving along the information channel may be represented by abstract InformationItems and by concrete Classifiers.
    */
    class InformationFlow : DirectedRelationship, PackageableElement
    {
    	/*
    	Specifies the information items that may circulate on this information flow.
    	*/
    	set<Classifier> Conveyed;
    	/*
    	Defines from which source the conveyed InformationItems are initiated.
    	*/
    	set<NamedElement> InformationSource subsets DirectedRelationship.Source;
    	/*
    	Defines to which target the conveyed InformationItems are directed.
    	*/
    	set<NamedElement> InformationTarget subsets DirectedRelationship.Target;
    	/*
    	Determines which Relationship will realize the specified flow.
    	*/
    	set<Relationship> Realization;
    	/*
    	Determines which ActivityEdges will realize the specified flow.
    	*/
    	set<ActivityEdge> RealizingActivityEdge;
    	/*
    	Determines which Connectors will realize the specified flow.
    	*/
    	set<Connector> RealizingConnector;
    	/*
    	Determines which Messages will realize the specified flow.
    	*/
    	set<Message> RealizingMessage;
    }

    /*
    InformationItems represent many kinds of information that can flow from sources to targets in very abstract ways.  They represent the kinds of information that may move within a system, but do not elaborate details of the transferred information.  Details of transferred information are the province of other Classifiers that may ultimately define InformationItems.  Consequently, InformationItems cannot be instantiated and do not themselves have features, generalizations, or associations. An important use of InformationItems is to represent information during early design stages, possibly before the detailed modeling decisions that will ultimately define them have been made. Another purpose of InformationItems is to abstract portions of complex models in less precise, but perhaps more general and communicable, ways. 
    */
    class InformationItem : Classifier
    {
    	/*
    	Determines the classifiers that will specify the structure and nature of the information. An information item represents all its represented classifiers.
    	*/
    	set<Classifier> Represented;
    }

    /*
    An artifact is the specification of a physical piece of information that is used or produced by a software development process, or by deployment and operation of a system. Examples of artifacts include model files, source files, scripts, and binary executable files, a table in a database system, a development deliverable, or a word-processing document, a mail message.
    An artifact is the source of a deployment to a node.
    */
    class Artifact : Classifier, DeployedArtifact
    {
    	/*
    	A concrete name that is used to refer to the Artifact in a physical context. Example: file system name, universal resource locator.
    	*/
    	string FileName;
    	/*
    	The set of model elements that are manifested in the Artifact. That is, these model elements are utilized in the construction (or generation) of the artifact.
    	*/
    	set<Manifestation> Manifestation subsets Element.OwnedElement, NamedElement.ClientDependency;
    	/*
    	The Artifacts that are defined (nested) within the Artifact. The association is a specialization of the ownedMember association from Namespace to NamedElement.
    	*/
    	set<Artifact> NestedArtifact subsets Namespace.OwnedMember;
    	/*
    	The attributes or association ends defined for the Artifact. The association is a specialization of the ownedMember association.
    	*/
    	list<Property> OwnedAttribute subsets Classifier.Attribute, Namespace.OwnedMember;
    	/*
    	The Operations defined for the Artifact. The association is a specialization of the ownedMember association.
    	*/
    	list<Operation> OwnedOperation subsets Classifier.Feature, Namespace.OwnedMember;
    }

    /*
    A communication path is an association between two deployment targets, through which they are able to exchange signals and messages.
    */
    class CommunicationPath : Association
    {
    }

    /*
    A deployed artifact is an artifact or artifact instance that has been deployed to a deployment target.
    */
    abstract class DeployedArtifact : NamedElement
    {
    }

    /*
    A deployment is the allocation of an artifact or artifact instance to a deployment target.
    A component deployment is the deployment of one or more artifacts or artifact instances to a deployment target, optionally parameterized by a deployment specification. Examples are executables and configuration files.
    */
    class Deployment : Dependency
    {
    	/*
    	The specification of properties that parameterize the deployment and execution of one or more Artifacts.
    	*/
    	set<DeploymentSpecification> Configuration subsets Element.OwnedElement;
    	/*
    	The Artifacts that are deployed onto a Node. This association specializes the supplier association.
    	*/
    	set<DeployedArtifact> DeployedArtifact subsets Dependency.Supplier;
    	/*
    	The DeployedTarget which is the target of a Deployment.
    	*/
    	DeploymentTarget Location subsets Dependency.Client, Element.Owner;
    }

    /*
    A deployment specification specifies a set of properties that determine execution parameters of a component artifact that is deployed on a node. A deployment specification can be aimed at a specific type of container. An artifact that reifies or implements deployment specification properties is a deployment descriptor.
    */
    class DeploymentSpecification : Artifact
    {
    	/*
    	The deployment with which the DeploymentSpecification is associated.
    	*/
    	Deployment Deployment subsets Element.Owner;
    	/*
    	The location where an Artifact is deployed onto a Node. This is typically a 'directory' or 'memory address.'
    	*/
    	string DeploymentLocation;
    	/*
    	The location where a component Artifact executes. This may be a local or remote location.
    	*/
    	string ExecutionLocation;
    }

    /*
    A deployment target is the location for a deployed artifact.
    */
    abstract class DeploymentTarget : NamedElement
    {
    	/*
    	The set of elements that are manifested in an Artifact that is involved in Deployment to a DeploymentTarget.
    	
    	spec:
    	    result = (deployment.deployedArtifact->select(oclIsKindOf(Artifact))->collect(oclAsType(Artifact).manifestation)->collect(utilizedElement)->asSet())
    	*/
    	derived set<PackageableElement> DeployedElement;
    	/*
    	The set of Deployments for a DeploymentTarget.
    	*/
    	set<Deployment> Deployment subsets Element.OwnedElement, NamedElement.ClientDependency;
    }

    /*
    A device is a physical computational resource with processing capability upon which artifacts may be deployed for execution. Devices may be complex (i.e., they may consist of other devices).
    */
    class Device : Node
    {
    }

    /*
    An execution environment is a node that offers an execution environment for specific types of components that are deployed on it in the form of executable artifacts.
    */
    class ExecutionEnvironment : Node
    {
    }

    /*
    A manifestation is the concrete physical rendering of one or more model elements by an artifact.
    */
    class Manifestation : Abstraction
    {
    	/*
    	The model element that is utilized in the manifestation in an Artifact.
    	*/
    	PackageableElement UtilizedElement subsets Dependency.Supplier;
    }

    /*
    A Node is computational resource upon which artifacts may be deployed for execution. Nodes can be interconnected through communication paths to define network structures.
    */
    class Node : Class, DeploymentTarget
    {
    	/*
    	The Nodes that are defined (nested) within the Node.
    	*/
    	set<Node> NestedNode subsets Namespace.OwnedMember;
    }

    /*
    An Abstraction is a Relationship that relates two Elements or sets of Elements that represent the same concept at different levels of abstraction or from different viewpoints.
    */
    class Abstraction : Dependency
    {
    	/*
    	An OpaqueExpression that states the abstraction relationship between the supplier(s) and the client(s). In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, it is usually informal and bidirectional. The mapping expression is optional and may be omitted if the precise relationship between the Elements is not specified.
    	*/
    	OpaqueExpression Mapping subsets Element.OwnedElement;
    }

    /*
    A Comment is a textual annotation that can be attached to a set of Elements.
    */
    class Comment : Element
    {
    	/*
    	References the Element(s) being commented.
    	*/
    	set<Element> AnnotatedElement;
    	/*
    	Specifies a string that is the comment.
    	*/
    	string Body;
    }

    /*
    A Constraint is a condition or restriction expressed in natural language text or in a machine readable language for the purpose of declaring some of the semantics of an Element or set of Elements.
    */
    class Constraint : PackageableElement
    {
    	/*
    	The ordered set of Elements referenced by this Constraint.
    	*/
    	list<Element> ConstrainedElement;
    	/*
    	Specifies the Namespace that owns the Constraint.
    	*/
    	Namespace Context subsets NamedElement.Namespace;
    	/*
    	A condition that must be true when evaluated in order for the Constraint to be satisfied.
    	*/
    	ValueSpecification Specification subsets Element.OwnedElement;
    }

    /*
    A Dependency is a Relationship that signifies that a single model Element or a set of model Elements requires other model Elements for their specification or implementation. This means that the complete semantics of the client Element(s) are either semantically or structurally dependent on the definition of the supplier Element(s).
    */
    class Dependency : DirectedRelationship, PackageableElement
    {
    	/*
    	The Element(s) dependent on the supplier Element(s). In some cases (such as a trace Abstraction) the assignment of direction (that is, the designation of the client Element) is at the discretion of the modeler and is a stipulation.
    	*/
    	set<NamedElement> Client subsets DirectedRelationship.Source;
    	/*
    	The Element(s) on which the client Element(s) depend in some respect. The modeler may stipulate a sense of Dependency direction suitable for their domain.
    	*/
    	set<NamedElement> Supplier subsets DirectedRelationship.Target;
    }

    /*
    A DirectedRelationship represents a relationship between a collection of source model Elements and a collection of target model Elements.
    */
    abstract class DirectedRelationship : Relationship
    {
    	/*
    	Specifies the source Element(s) of the DirectedRelationship.
    	*/
    	union set<Element> Source subsets Relationship.RelatedElement;
    	/*
    	Specifies the target Element(s) of the DirectedRelationship.
    	*/
    	union set<Element> Target subsets Relationship.RelatedElement;
    }

    /*
    An Element is a constituent of a model. As such, it has the capability of owning other Elements.
    */
    abstract class Element
    {
    	/*
    	The Comments owned by this Element.
    	*/
    	set<Comment> OwnedComment subsets Element.OwnedElement;
    	/*
    	The Elements owned by this Element.
    	*/
    	union set<Element> OwnedElement;
    	/*
    	The Element that owns this Element.
    	*/
    	union Element Owner;
    	/*
    	The query allOwnedElements() gives all of the direct and indirect ownedElements of an Element.
    	
    	spec:
    	    result = (ownedElement->union(ownedElement->collect(e | e.allOwnedElements()))->asSet())
    	*/
    	set<Element> AllOwnedElements();
    	/*
    	The query mustBeOwned() indicates whether Elements of this type must have an owner. Subclasses of Element that do not require an owner must override this operation.
    	
    	spec:
    	    result = (true)
    	*/
    	bool MustBeOwned();
    }

    /*
    An ElementImport identifies a NamedElement in a Namespace other than the one that owns that NamedElement and allows the NamedElement to be referenced using an unqualified name in the Namespace owning the ElementImport.
    */
    class ElementImport : DirectedRelationship
    {
    	/*
    	Specifies the name that should be added to the importing Namespace in lieu of the name of the imported PackagableElement. The alias must not clash with any other member in the importing Namespace. By default, no alias is used.
    	*/
    	string Alias;
    	/*
    	Specifies the PackageableElement whose name is to be added to a Namespace.
    	*/
    	PackageableElement ImportedElement subsets DirectedRelationship.Target;
    	/*
    	Specifies the Namespace that imports a PackageableElement from another Namespace.
    	*/
    	Namespace ImportingNamespace subsets DirectedRelationship.Source, Element.Owner;
    	/*
    	Specifies the visibility of the imported PackageableElement within the importingNamespace, i.e., whether the  importedElement will in turn be visible to other Namespaces. If the ElementImport is public, the importedElement will be visible outside the importingNamespace while, if the ElementImport is private, it will not.
    	*/
    	VisibilityKind Visibility;
    	/*
    	The query getName() returns the name under which the imported PackageableElement will be known in the importing namespace.
    	
    	spec:
    	    result = (if alias->notEmpty() then
    	      alias
    	    else
    	      importedElement.name
    	    endif)
    	*/
    	string GetName();
    }

    /*
    A multiplicity is a definition of an inclusive interval of non-negative integers beginning with a lower bound and ending with a (possibly infinite) upper bound. A MultiplicityElement embeds this information to specify the allowable cardinalities for an instantiation of the Element.
    */
    abstract class MultiplicityElement : Element
    {
    	/*
    	For a multivalued multiplicity, this attribute specifies whether the values in an instantiation of this MultiplicityElement are sequentially ordered.
    	*/
    	bool IsOrdered;
    	/*
    	For a multivalued multiplicity, this attributes specifies whether the values in an instantiation of this MultiplicityElement are unique.
    	*/
    	bool IsUnique;
    	/*
    	The lower bound of the multiplicity interval.
    	
    	spec:
    	    result = (lowerBound())
    	*/
    	derived int Lower;
    	/*
    	The specification of the lower bound for this multiplicity.
    	*/
    	ValueSpecification LowerValue subsets Element.OwnedElement;
    	/*
    	The upper bound of the multiplicity interval.
    	
    	spec:
    	    result = (upperBound())
    	*/
    	derived long Upper;
    	/*
    	The specification of the upper bound for this multiplicity.
    	*/
    	ValueSpecification UpperValue subsets Element.OwnedElement;
    	/*
    	The operation compatibleWith takes another multiplicity as input. It returns true if the other multiplicity is wider than, or the same as, self.
    	
    	spec:
    	    result = ((other.lowerBound() <= self.lowerBound()) and ((other.upperBound() = *) or (self.upperBound() <= other.upperBound())))
    	*/
    	bool CompatibleWith(MultiplicityElement other);
    	/*
    	The query includesMultiplicity() checks whether this multiplicity includes all the cardinalities allowed by the specified multiplicity.
    	
    	pre:
    	    self.upperBound()->notEmpty() and self.lowerBound()->notEmpty() and M.upperBound()->notEmpty() and M.lowerBound()->notEmpty()
    	spec:
    	    result = ((self.lowerBound() <= M.lowerBound()) and (self.upperBound() >= M.upperBound()))
    	*/
    	bool IncludesMultiplicity(MultiplicityElement M);
    	/*
    	The operation is determines if the upper and lower bound of the ranges are the ones given.
    	
    	spec:
    	    result = (lowerbound = self.lowerBound() and upperbound = self.upperBound())
    	*/
    	bool Is(int lowerbound, long upperbound);
    	/*
    	The query isMultivalued() checks whether this multiplicity has an upper bound greater than one.
    	
    	pre:
    	    upperBound()->notEmpty()
    	spec:
    	    result = (upperBound() > 1)
    	*/
    	bool IsMultivalued();
    	/*
    	The query lowerBound() returns the lower bound of the multiplicity as an integer, which is the integerValue of lowerValue, if this is given, and 1 otherwise.
    	
    	spec:
    	    result = (if (lowerValue=null or lowerValue.integerValue()=null) then 1 else lowerValue.integerValue() endif)
    	*/
    	int LowerBound();
    	/*
    	The query upperBound() returns the upper bound of the multiplicity for a bounded multiplicity as an unlimited natural, which is the unlimitedNaturalValue of upperValue, if given, and 1, otherwise.
    	
    	spec:
    	    result = (if (upperValue=null or upperValue.unlimitedValue()=null) then 1 else upperValue.unlimitedValue() endif)
    	*/
    	long UpperBound();
    }

    /*
    A NamedElement is an Element in a model that may have a name. The name may be given directly and/or via the use of a StringExpression.
    */
    abstract class NamedElement : Element
    {
    	/*
    	Indicates the Dependencies that reference this NamedElement as a client.
    	
    	spec:
    	    result = (Dependency.allInstances()->select(d | d.client->includes(self)))
    	*/
    	derived set<Dependency> ClientDependency;
    	/*
    	The name of the NamedElement.
    	*/
    	string Name;
    	/*
    	The StringExpression used to define the name of this NamedElement.
    	*/
    	StringExpression NameExpression subsets Element.OwnedElement;
    	/*
    	Specifies the Namespace that owns the NamedElement.
    	*/
    	union Namespace Namespace subsets Element.Owner;
    	/*
    	A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is constructed from the names of the containing Namespaces starting at the root of the hierarchy and ending with the name of the NamedElement itself.
    	
    	spec:
    	    result = (if self.name <> null and self.allNamespaces()->select( ns | ns.name=null )->isEmpty()
    	    then 
    	        self.allNamespaces()->iterate( ns : Namespace; agg: String = self.name | ns.name.concat(self.separator()).concat(agg))
    	    else
    	       null
    	    endif)
    	*/
    	derived string QualifiedName;
    	/*
    	Determines whether and how the NamedElement is visible outside its owning Namespace.
    	*/
    	VisibilityKind Visibility;
    	/*
    	The query allNamespaces() gives the sequence of Namespaces in which the NamedElement is nested, working outwards.
    	
    	spec:
    	    result = (if owner.oclIsKindOf(TemplateParameter) and
    	      owner.oclAsType(TemplateParameter).signature.template.oclIsKindOf(Namespace) then
    	        let enclosingNamespace : Namespace =
    	          owner.oclAsType(TemplateParameter).signature.template.oclAsType(Namespace) in
    	            enclosingNamespace.allNamespaces()->prepend(enclosingNamespace)
    	    else
    	      if namespace->isEmpty()
    	        then OrderedSet{}
    	      else
    	        namespace.allNamespaces()->prepend(namespace)
    	      endif
    	    endif)
    	*/
    	list<Namespace> AllNamespaces();
    	/*
    	The query allOwningPackages() returns the set of all the enclosing Namespaces of this NamedElement, working outwards, that are Packages, up to but not including the first such Namespace that is not a Package.
    	
    	spec:
    	    result = (if namespace.oclIsKindOf(Package)
    	    then
    	      let owningPackage : Package = namespace.oclAsType(Package) in
    	        owningPackage->union(owningPackage.allOwningPackages())
    	    else
    	      null
    	    endif)
    	*/
    	set<Package> AllOwningPackages();
    	/*
    	The query isDistinguishableFrom() determines whether two NamedElements may logically co-exist within a Namespace. By default, two named elements are distinguishable if (a) they have types neither of which is a kind of the other or (b) they have different names.
    	
    	spec:
    	    result = ((self.oclIsKindOf(n.oclType()) or n.oclIsKindOf(self.oclType())) implies
    	        ns.getNamesOfMember(self)->intersection(ns.getNamesOfMember(n))->isEmpty()
    	    )
    	*/
    	bool IsDistinguishableFrom(NamedElement n, Namespace ns);
    	/*
    	The query separator() gives the string that is used to separate names when constructing a qualifiedName.
    	
    	spec:
    	    result = ('::')
    	*/
    	string Separator();
    }

    /*
    A Namespace is an Element in a model that owns and/or imports a set of NamedElements that can be identified by name.
    */
    abstract class Namespace : NamedElement
    {
    	/*
    	References the ElementImports owned by the Namespace.
    	*/
    	set<ElementImport> ElementImport subsets Element.OwnedElement;
    	/*
    	References the PackageableElements that are members of this Namespace as a result of either PackageImports or ElementImports.
    	
    	spec:
    	    result = (self.importMembers(elementImport.importedElement->asSet()->union(packageImport.importedPackage->collect(p | p.visibleMembers()))->asSet()))
    	*/
    	derived set<PackageableElement> ImportedMember subsets Namespace.Member;
    	/*
    	A collection of NamedElements identifiable within the Namespace, either by being owned or by being introduced by importing or inheritance.
    	*/
    	union set<NamedElement> Member;
    	/*
    	A collection of NamedElements owned by the Namespace.
    	*/
    	union set<NamedElement> OwnedMember subsets Element.OwnedElement, Namespace.Member;
    	/*
    	Specifies a set of Constraints owned by this Namespace.
    	*/
    	set<Constraint> OwnedRule subsets Namespace.OwnedMember;
    	/*
    	References the PackageImports owned by the Namespace.
    	*/
    	set<PackageImport> PackageImport subsets Element.OwnedElement;
    	/*
    	The query excludeCollisions() excludes from a set of PackageableElements any that would not be distinguishable from each other in this Namespace.
    	
    	spec:
    	    result = (imps->reject(imp1  | imps->exists(imp2 | not imp1.isDistinguishableFrom(imp2, self))))
    	*/
    	set<PackageableElement> ExcludeCollisions(set<PackageableElement> imps);
    	/*
    	The query getNamesOfMember() gives a set of all of the names that a member would have in a Namespace, taking importing into account. In general a member can have multiple names in a Namespace if it is imported more than once with different aliases.
    	
    	spec:
    	    result = (if self.ownedMember ->includes(element)
    	    then Set{element.name}
    	    else let elementImports : Set(ElementImport) = self.elementImport->select(ei | ei.importedElement = element) in
    	      if elementImports->notEmpty()
    	      then
    	         elementImports->collect(el | el.getName())->asSet()
    	      else 
    	         self.packageImport->select(pi | pi.importedPackage.visibleMembers().oclAsType(NamedElement)->includes(element))-> collect(pi | pi.importedPackage.getNamesOfMember(element))->asSet()
    	      endif
    	    endif)
    	*/
    	set<string> GetNamesOfMember(NamedElement element);
    	/*
    	The query importMembers() defines which of a set of PackageableElements are actually imported into the Namespace. This excludes hidden ones, i.e., those which have names that conflict with names of ownedMembers, and it also excludes PackageableElements that would have the indistinguishable names when imported.
    	
    	spec:
    	    result = (self.excludeCollisions(imps)->select(imp | self.ownedMember->forAll(mem | imp.isDistinguishableFrom(mem, self))))
    	*/
    	set<PackageableElement> ImportMembers(set<PackageableElement> imps);
    	/*
    	The Boolean query membersAreDistinguishable() determines whether all of the Namespace's members are distinguishable within it.
    	
    	spec:
    	    result = (member->forAll( memb |
    	       member->excluding(memb)->forAll(other |
    	           memb.isDistinguishableFrom(other, self))))
    	*/
    	bool MembersAreDistinguishable();
    }

    /*
    A PackageableElement is a NamedElement that may be owned directly by a Package. A PackageableElement is also able to serve as the parameteredElement of a TemplateParameter.
    */
    abstract class PackageableElement : ParameterableElement, NamedElement
    {
    	/*
    	A PackageableElement must have a visibility specified if it is owned by a Namespace. The default visibility is public.
    	*/
    	VisibilityKind Visibility redefines NamedElement.Visibility;
    }

    /*
    A PackageImport is a Relationship that imports all the non-private members of a Package into the Namespace owning the PackageImport, so that those Elements may be referred to by their unqualified names in the importingNamespace.
    */
    class PackageImport : DirectedRelationship
    {
    	/*
    	Specifies the Package whose members are imported into a Namespace.
    	*/
    	Package ImportedPackage subsets DirectedRelationship.Target;
    	/*
    	Specifies the Namespace that imports the members from a Package.
    	*/
    	Namespace ImportingNamespace subsets DirectedRelationship.Source, Element.Owner;
    	/*
    	Specifies the visibility of the imported PackageableElements within the importingNamespace, i.e., whether imported Elements will in turn be visible to other Namespaces. If the PackageImport is public, the imported Elements will be visible outside the importingNamespace, while, if the PackageImport is private, they will not.
    	*/
    	VisibilityKind Visibility;
    }

    /*
    A ParameterableElement is an Element that can be exposed as a formal TemplateParameter for a template, or specified as an actual parameter in a binding of a template.
    */
    abstract class ParameterableElement : Element
    {
    	/*
    	The formal TemplateParameter that owns this ParameterableElement.
    	*/
    	TemplateParameter OwningTemplateParameter subsets Element.Owner, ParameterableElement.TemplateParameter;
    	/*
    	The TemplateParameter that exposes this ParameterableElement as a formal parameter.
    	*/
    	TemplateParameter TemplateParameter;
    	/*
    	The query isCompatibleWith() determines if this ParameterableElement is compatible with the specified ParameterableElement. By default, this ParameterableElement is compatible with another ParameterableElement p if the kind of this ParameterableElement is the same as or a subtype of the kind of p. Subclasses of ParameterableElement should override this operation to specify different compatibility constraints.
    	
    	spec:
    	    result = (self.oclIsKindOf(p.oclType()))
    	*/
    	bool IsCompatibleWith(ParameterableElement p);
    	/*
    	The query isTemplateParameter() determines if this ParameterableElement is exposed as a formal TemplateParameter.
    	
    	spec:
    	    result = (templateParameter->notEmpty())
    	*/
    	bool IsTemplateParameter();
    }

    /*
    Realization is a specialized Abstraction relationship between two sets of model Elements, one representing a specification (the supplier) and the other represents an implementation of the latter (the client). Realization can be used to model stepwise refinement, optimizations, transformations, templates, model synthesis, framework composition, etc.
    */
    class Realization : Abstraction
    {
    }

    /*
    Relationship is an abstract concept that specifies some kind of relationship between Elements.
    */
    abstract class Relationship : Element
    {
    	/*
    	Specifies the elements related by the Relationship.
    	*/
    	union set<Element> RelatedElement;
    }

    /*
    A TemplateableElement is an Element that can optionally be defined as a template and bound to other templates.
    */
    abstract class TemplateableElement : Element
    {
    	/*
    	The optional TemplateSignature specifying the formal TemplateParameters for this TemplateableElement. If a TemplateableElement has a TemplateSignature, then it is a template.
    	*/
    	TemplateSignature OwnedTemplateSignature subsets Element.OwnedElement;
    	/*
    	The optional TemplateBindings from this TemplateableElement to one or more templates.
    	*/
    	set<TemplateBinding> TemplateBinding subsets Element.OwnedElement;
    	/*
    	The query isTemplate() returns whether this TemplateableElement is actually a template.
    	
    	spec:
    	    result = (ownedTemplateSignature <> null)
    	*/
    	bool IsTemplate();
    	/*
    	The query parameterableElements() returns the set of ParameterableElements that may be used as the parameteredElements for a TemplateParameter of this TemplateableElement. By default, this set includes all the ownedElements. Subclasses may override this operation if they choose to restrict the set of ParameterableElements.
    	
    	spec:
    	    result = (self.allOwnedElements()->select(oclIsKindOf(ParameterableElement)).oclAsType(ParameterableElement)->asSet())
    	*/
    	set<ParameterableElement> ParameterableElements();
    }

    /*
    A TemplateBinding is a DirectedRelationship between a TemplateableElement and a template. A TemplateBinding specifies the TemplateParameterSubstitutions of actual parameters for the formal parameters of the template.
    */
    class TemplateBinding : DirectedRelationship
    {
    	/*
    	The TemplateableElement that is bound by this TemplateBinding.
    	*/
    	TemplateableElement BoundElement subsets DirectedRelationship.Source, Element.Owner;
    	/*
    	The TemplateParameterSubstitutions owned by this TemplateBinding.
    	*/
    	set<TemplateParameterSubstitution> ParameterSubstitution subsets Element.OwnedElement;
    	/*
    	The TemplateSignature for the template that is the target of this TemplateBinding.
    	*/
    	TemplateSignature Signature subsets DirectedRelationship.Target;
    }

    /*
    A TemplateParameter exposes a ParameterableElement as a formal parameter of a template.
    */
    class TemplateParameter : Element
    {
    	/*
    	The ParameterableElement that is the default for this formal TemplateParameter.
    	*/
    	ParameterableElement Default;
    	/*
    	The ParameterableElement that is owned by this TemplateParameter for the purpose of providing a default.
    	*/
    	ParameterableElement OwnedDefault subsets Element.OwnedElement, TemplateParameter.Default;
    	/*
    	The ParameterableElement that is owned by this TemplateParameter for the purpose of exposing it as the parameteredElement.
    	*/
    	ParameterableElement OwnedParameteredElement subsets Element.OwnedElement, TemplateParameter.ParameteredElement;
    	/*
    	The ParameterableElement exposed by this TemplateParameter.
    	*/
    	ParameterableElement ParameteredElement;
    	/*
    	The TemplateSignature that owns this TemplateParameter.
    	*/
    	TemplateSignature Signature subsets Element.Owner;
    }

    /*
    A TemplateParameterSubstitution relates the actual parameter to a formal TemplateParameter as part of a template binding.
    */
    class TemplateParameterSubstitution : Element
    {
    	/*
    	The ParameterableElement that is the actual parameter for this TemplateParameterSubstitution.
    	*/
    	ParameterableElement Actual;
    	/*
    	The formal TemplateParameter that is associated with this TemplateParameterSubstitution.
    	*/
    	TemplateParameter Formal;
    	/*
    	The ParameterableElement that is owned by this TemplateParameterSubstitution as its actual parameter.
    	*/
    	ParameterableElement OwnedActual subsets Element.OwnedElement, TemplateParameterSubstitution.Actual;
    	/*
    	The TemplateBinding that owns this TemplateParameterSubstitution.
    	*/
    	TemplateBinding TemplateBinding subsets Element.Owner;
    }

    /*
    A Template Signature bundles the set of formal TemplateParameters for a template.
    */
    class TemplateSignature : Element
    {
    	/*
    	The formal parameters that are owned by this TemplateSignature.
    	*/
    	list<TemplateParameter> OwnedParameter subsets Element.OwnedElement, TemplateSignature.Parameter;
    	/*
    	The ordered set of all formal TemplateParameters for this TemplateSignature.
    	*/
    	list<TemplateParameter> Parameter;
    	/*
    	The TemplateableElement that owns this TemplateSignature.
    	*/
    	TemplateableElement Template subsets Element.Owner;
    }

    /*
    A Type constrains the values represented by a TypedElement.
    */
    abstract class Type : PackageableElement
    {
    	/*
    	Specifies the owning Package of this Type, if any.
    	*/
    	Package Package;
    	/*
    	The query conformsTo() gives true for a Type that conforms to another. By default, two Types do not conform to each other. This query is intended to be redefined for specific conformance situations.
    	
    	spec:
    	    result = (false)
    	*/
    	bool ConformsTo(Type other);
    }

    /*
    A TypedElement is a NamedElement that may have a Type specified for it.
    */
    abstract class TypedElement : NamedElement
    {
    	/*
    	The type of the TypedElement.
    	*/
    	Type Type;
    }

    /*
    A Usage is a Dependency in which the client Element requires the supplier Element (or set of Elements) for its full implementation or operation.
    */
    class Usage : Dependency
    {
    }

    /*
    A trigger for an AnyReceiveEvent is triggered by the receipt of any message that is not explicitly handled by any related trigger.
    */
    class AnyReceiveEvent : MessageEvent
    {
    }

    /*
    Behavior is a specification of how its context BehavioredClassifier changes state over time. This specification may be either a definition of possible behavior execution or emergent behavior, or a selective illustration of an interesting subset of possible executions. The latter form is typically used for capturing examples, such as a trace of a particular execution.
    */
    abstract class Behavior : Class
    {
    	/*
    	The BehavioredClassifier that is the context for the execution of the Behavior. A Behavior that is directly owned as a nestedClassifier does not have a context. Otherwise, to determine the context of a Behavior, find the first BehavioredClassifier reached by following the chain of owner relationships from the Behavior, if any. If there is such a BehavioredClassifier, then it is the context, unless it is itself a Behavior with a non-empty context, in which case that is also the context for the original Behavior. For example, following this algorithm, the context of an entry Behavior in a StateMachine is the BehavioredClassifier that owns the StateMachine. The features of the context BehavioredClassifier as well as the Elements visible to the context Classifier are visible to the Behavior.
    	
    	spec:
    	    result = (if nestingClass <> null then
    	        null
    	    else
    	        let b:BehavioredClassifier = self.behavioredClassifier(self.owner) in
    	        if b.oclIsKindOf(Behavior) and b.oclAsType(Behavior)._'context' <> null then 
    	            b.oclAsType(Behavior)._'context'
    	        else 
    	            b 
    	        endif
    	    endif
    	            )
    	*/
    	derived BehavioredClassifier Context subsets RedefinableElement.RedefinitionContext;
    	/*
    	Tells whether the Behavior can be invoked while it is still executing from a previous invocation.
    	*/
    	bool IsReentrant;
    	/*
    	References a list of Parameters to the Behavior which describes the order and type of arguments that can be given when the Behavior is invoked and of the values which will be returned when the Behavior completes its execution.
    	*/
    	list<Parameter> OwnedParameter subsets Namespace.OwnedMember;
    	/*
    	The ParameterSets owned by this Behavior.
    	*/
    	set<ParameterSet> OwnedParameterSet subsets Namespace.OwnedMember;
    	/*
    	An optional set of Constraints specifying what is fulfilled after the execution of the Behavior is completed, if its precondition was fulfilled before its invocation.
    	*/
    	set<Constraint> Postcondition subsets Namespace.OwnedRule;
    	/*
    	An optional set of Constraints specifying what must be fulfilled before the Behavior is invoked.
    	*/
    	set<Constraint> Precondition subsets Namespace.OwnedRule;
    	/*
    	Designates a BehavioralFeature that the Behavior implements. The BehavioralFeature must be owned by the BehavioredClassifier that owns the Behavior or be inherited by it. The Parameters of the BehavioralFeature and the implementing Behavior must match. A Behavior does not need to have a specification, in which case it either is the classifierBehavior of a BehavioredClassifier or it can only be invoked by another Behavior of the Classifier.
    	*/
    	BehavioralFeature Specification;
    	/*
    	References the Behavior that this Behavior redefines. A subtype of Behavior may redefine any other subtype of Behavior. If the Behavior implements a BehavioralFeature, it replaces the redefined Behavior. If the Behavior is a classifierBehavior, it extends the redefined Behavior.
    	*/
    	set<Behavior> RedefinedBehavior subsets Classifier.RedefinedClassifier;
    	/*
    	The first BehavioredClassifier reached by following the chain of owner relationships from the Behavior, if any.
    	
    	spec:
    	    if from.oclIsKindOf(BehavioredClassifier) then
    	        from.oclAsType(BehavioredClassifier)
    	    else if from.owner = null then
    	        null
    	    else
    	        self.behavioredClassifier(from.owner)
    	    endif
    	    endif
    	        
    	*/
    	BehavioredClassifier BehavioredClassifier(Element from);
    	/*
    	The in and inout ownedParameters of the Behavior.
    	
    	spec:
    	    result = (ownedParameter->select(direction=ParameterDirectionKind::_'in' or direction=ParameterDirectionKind::inout))
    	*/
    	list<Parameter> InputParameters();
    	/*
    	The out, inout and return ownedParameters.
    	
    	spec:
    	    result = (ownedParameter->select(direction=ParameterDirectionKind::out or direction=ParameterDirectionKind::inout or direction=ParameterDirectionKind::return))
    	*/
    	list<Parameter> OutputParameters();
    }

    /*
    A CallEvent models the receipt by an object of a message invoking a call of an Operation.
    */
    class CallEvent : MessageEvent
    {
    	/*
    	Designates the Operation whose invocation raised the CalEvent.
    	*/
    	Operation Operation;
    }

    /*
    A ChangeEvent models a change in the system configuration that makes a condition true.
    */
    class ChangeEvent : Event
    {
    	/*
    	A Boolean-valued ValueSpecification that will result in a ChangeEvent whenever its value changes from false to true.
    	*/
    	ValueSpecification ChangeExpression subsets Element.OwnedElement;
    }

    /*
    An Event is the specification of some occurrence that may potentially trigger effects by an object.
    */
    abstract class Event : PackageableElement
    {
    }

    /*
    A FunctionBehavior is an OpaqueBehavior that does not access or modify any objects or other external data.
    */
    class FunctionBehavior : OpaqueBehavior
    {
    	/*
    	The hasAllDataTypeAttributes query tests whether the types of the attributes of the given DataType are all DataTypes, and similarly for all those DataTypes.
    	
    	spec:
    	    result = (d.ownedAttribute->forAll(a |
    	        a.type.oclIsKindOf(DataType) and
    	          hasAllDataTypeAttributes(a.type.oclAsType(DataType))))
    	*/
    	bool HasAllDataTypeAttributes(DataType d);
    }

    /*
    A MessageEvent specifies the receipt by an object of either an Operation call or a Signal instance.
    */
    abstract class MessageEvent : Event
    {
    }

    /*
    An OpaqueBehavior is a Behavior whose specification is given in a textual language other than UML.
    */
    class OpaqueBehavior : Behavior
    {
    	/*
    	Specifies the behavior in one or more languages.
    	*/
    	multi_list<string> Body;
    	/*
    	Languages the body strings use in the same order as the body strings.
    	*/
    	list<string> Language;
    }

    /*
    A SignalEvent represents the receipt of an asynchronous Signal instance.
    */
    class SignalEvent : MessageEvent
    {
    	/*
    	The specific Signal that is associated with this SignalEvent.
    	*/
    	Signal Signal;
    }

    /*
    A TimeEvent is an Event that occurs at a specific point in time.
    */
    class TimeEvent : Event
    {
    	/*
    	Specifies whether the TimeEvent is specified as an absolute or relative time.
    	*/
    	bool IsRelative;
    	/*
    	Specifies the time of the TimeEvent.
    	*/
    	TimeExpression When subsets Element.OwnedElement;
    }

    /*
    A Trigger specifies a specific point  at which an Event occurrence may trigger an effect in a Behavior. A Trigger may be qualified by the Port on which the Event occurred.
    */
    class Trigger : NamedElement
    {
    	/*
    	The Event that detected by the Trigger.
    	*/
    	Event Event;
    	/*
    	A optional Port of through which the given effect is detected.
    	*/
    	set<Port> Port;
    }

    /*
    A substitution is a relationship between two classifiers signifying that the substituting classifier complies with the contract specified by the contract classifier. This implies that instances of the substituting classifier are runtime substitutable where instances of the contract classifier are expected.
    */
    class Substitution : Realization
    {
    	/*
    	The contract with which the substituting classifier complies.
    	*/
    	Classifier Contract subsets Dependency.Supplier;
    	/*
    	Instances of the substituting classifier are runtime substitutable where instances of the contract classifier are expected.
    	*/
    	Classifier SubstitutingClassifier subsets Dependency.Client, Element.Owner;
    }

    /*
    A BehavioralFeature is a feature of a Classifier that specifies an aspect of the behavior of its instances.  A BehavioralFeature is implemented (realized) by a Behavior. A BehavioralFeature specifies that a Classifier will respond to a designated request by invoking its implementing method.
    */
    abstract class BehavioralFeature : Feature, Namespace
    {
    	/*
    	Specifies the semantics of concurrent calls to the same passive instance (i.e., an instance originating from a Class with isActive being false). Active instances control access to their own BehavioralFeatures.
    	*/
    	CallConcurrencyKind Concurrency;
    	/*
    	If true, then the BehavioralFeature does not have an implementation, and one must be supplied by a more specific Classifier. If false, the BehavioralFeature must have an implementation in the Classifier or one must be inherited.
    	*/
    	bool IsAbstract;
    	/*
    	A Behavior that implements the BehavioralFeature. There may be at most one Behavior for a particular pairing of a Classifier (as owner of the Behavior) and a BehavioralFeature (as specification of the Behavior).
    	*/
    	set<Behavior> Method;
    	/*
    	The ordered set of formal Parameters of this BehavioralFeature.
    	*/
    	list<Parameter> OwnedParameter subsets Namespace.OwnedMember;
    	/*
    	The ParameterSets owned by this BehavioralFeature.
    	*/
    	set<ParameterSet> OwnedParameterSet subsets Namespace.OwnedMember;
    	/*
    	The Types representing exceptions that may be raised during an invocation of this BehavioralFeature.
    	*/
    	set<Type> RaisedException;
    	/*
    	The query isDistinguishableFrom() determines whether two BehavioralFeatures may coexist in the same Namespace. It specifies that they must have different signatures.
    	
    	spec:
    	    result = ((n.oclIsKindOf(BehavioralFeature) and ns.getNamesOfMember(self)->intersection(ns.getNamesOfMember(n))->notEmpty()) implies
    	      Set{self}->including(n.oclAsType(BehavioralFeature))->isUnique(ownedParameter->collect(p|
    	      Tuple { name=p.name, type=p.type,effect=p.effect,direction=p.direction,isException=p.isException,
    	                  isStream=p.isStream,isOrdered=p.isOrdered,isUnique=p.isUnique,lower=p.lower, upper=p.upper }))
    	      )
    	*/
    	bool IsDistinguishableFrom(NamedElement n, Namespace ns);
    	/*
    	The ownedParameters with direction in and inout.
    	
    	spec:
    	    result = (ownedParameter->select(direction=ParameterDirectionKind::_'in' or direction=ParameterDirectionKind::inout))
    	*/
    	list<Parameter> InputParameters();
    	/*
    	The ownedParameters with direction out, inout, or return.
    	
    	spec:
    	    result = (ownedParameter->select(direction=ParameterDirectionKind::out or direction=ParameterDirectionKind::inout or direction=ParameterDirectionKind::return))
    	*/
    	list<Parameter> OutputParameters();
    }

    /*
    A Classifier represents a classification of instances according to their Features.
    */
    abstract class Classifier : Namespace, Type, TemplateableElement, RedefinableElement
    {
    	/*
    	All of the Properties that are direct (i.e., not inherited or imported) attributes of the Classifier.
    	*/
    	union list<Property> Attribute subsets Classifier.Feature;
    	/*
    	The CollaborationUses owned by the Classifier.
    	*/
    	set<CollaborationUse> CollaborationUse subsets Element.OwnedElement;
    	/*
    	Specifies each Feature directly defined in the classifier. Note that there may be members of the Classifier that are of the type Feature but are not included, e.g., inherited features.
    	*/
    	union set<Feature> Feature subsets Namespace.Member;
    	/*
    	The generalizing Classifiers for this Classifier.
    	
    	spec:
    	    result = (parents())
    	*/
    	derived set<Classifier> General;
    	/*
    	The Generalization relationships for this Classifier. These Generalizations navigate to more general Classifiers in the generalization hierarchy.
    	*/
    	set<Generalization> Generalization subsets Element.OwnedElement;
    	/*
    	All elements inherited by this Classifier from its general Classifiers.
    	
    	spec:
    	    result = (inherit(parents()->collect(inheritableMembers(self))->asSet()))
    	*/
    	derived set<NamedElement> InheritedMember subsets Namespace.Member;
    	/*
    	If true, the Classifier can only be instantiated by instantiating one of its specializations. An abstract Classifier is intended to be used by other Classifiers e.g., as the target of Associations or Generalizations.
    	*/
    	bool IsAbstract;
    	/*
    	If true, the Classifier cannot be specialized.
    	*/
    	bool IsFinalSpecialization;
    	/*
    	The optional RedefinableTemplateSignature specifying the formal template parameters.
    	*/
    	RedefinableTemplateSignature OwnedTemplateSignature redefines TemplateableElement.OwnedTemplateSignature;
    	/*
    	The UseCases owned by this classifier.
    	*/
    	set<UseCase> OwnedUseCase subsets Namespace.OwnedMember;
    	/*
    	The GeneralizationSet of which this Classifier is a power type.
    	*/
    	set<GeneralizationSet> PowertypeExtent;
    	/*
    	The Classifiers redefined by this Classifier.
    	*/
    	set<Classifier> RedefinedClassifier subsets RedefinableElement.RedefinedElement;
    	/*
    	A CollaborationUse which indicates the Collaboration that represents this Classifier.
    	*/
    	CollaborationUse Representation subsets Classifier.CollaborationUse;
    	/*
    	The Substitutions owned by this Classifier.
    	*/
    	set<Substitution> Substitution subsets Element.OwnedElement, NamedElement.ClientDependency;
    	/*
    	TheClassifierTemplateParameter that exposes this element as a formal parameter.
    	*/
    	ClassifierTemplateParameter TemplateParameter redefines ParameterableElement.TemplateParameter;
    	/*
    	The set of UseCases for which this Classifier is the subject.
    	*/
    	set<UseCase> UseCase;
    	/*
    	The query allFeatures() gives all of the Features in the namespace of the Classifier. In general, through mechanisms such as inheritance, this will be a larger set than feature.
    	
    	spec:
    	    result = (member->select(oclIsKindOf(Feature))->collect(oclAsType(Feature))->asSet())
    	*/
    	set<Feature> AllFeatures();
    	/*
    	The query allParents() gives all of the direct and indirect ancestors of a generalized Classifier.
    	
    	spec:
    	    result = (parents()->union(parents()->collect(allParents())->asSet()))
    	*/
    	set<Classifier> AllParents();
    	/*
    	The query conformsTo() gives true for a Classifier that defines a type that conforms to another. This is used, for example, in the specification of signature conformance for operations.
    	
    	spec:
    	    result = (if other.oclIsKindOf(Classifier) then
    	      let otherClassifier : Classifier = other.oclAsType(Classifier) in
    	        self = otherClassifier or allParents()->includes(otherClassifier)
    	    else
    	      false
    	    endif)
    	*/
    	bool ConformsTo(Type other);
    	/*
    	The query hasVisibilityOf() determines whether a NamedElement is visible in the classifier. Non-private members are visible. It is only called when the argument is something owned by a parent.
    	
    	pre:
    	    allParents()->including(self)->collect(member)->includes(n)
    	spec:
    	    result = (n.visibility <> VisibilityKind::private)
    	*/
    	bool HasVisibilityOf(NamedElement n);
    	/*
    	The query inherit() defines how to inherit a set of elements passed as its argument.  It excludes redefined elements from the result.
    	
    	spec:
    	    result = (inhs->reject(inh |
    	      inh.oclIsKindOf(RedefinableElement) and
    	      ownedMember->select(oclIsKindOf(RedefinableElement))->
    	        select(redefinedElement->includes(inh.oclAsType(RedefinableElement)))
    	           ->notEmpty()))
    	*/
    	set<NamedElement> Inherit(set<NamedElement> inhs);
    	/*
    	The query inheritableMembers() gives all of the members of a Classifier that may be inherited in one of its descendants, subject to whatever visibility restrictions apply.
    	
    	pre:
    	    c.allParents()->includes(self)
    	spec:
    	    result = (member->select(m | c.hasVisibilityOf(m)))
    	*/
    	set<NamedElement> InheritableMembers(Classifier c);
    	/*
    	The query isTemplate() returns whether this Classifier is actually a template.
    	
    	spec:
    	    result = (ownedTemplateSignature <> null or general->exists(g | g.isTemplate()))
    	*/
    	bool IsTemplate();
    	/*
    	The query maySpecializeType() determines whether this classifier may have a generalization relationship to classifiers of the specified type. By default a classifier may specialize classifiers of the same or a more general type. It is intended to be redefined by classifiers that have different specialization constraints.
    	
    	spec:
    	    result = (self.oclIsKindOf(c.oclType()))
    	*/
    	bool MaySpecializeType(Classifier c);
    	/*
    	The query parents() gives all of the immediate ancestors of a generalized Classifier.
    	
    	spec:
    	    result = (generalization.general->asSet())
    	*/
    	set<Classifier> Parents();
    	/*
    	The Interfaces directly realized by this Classifier
    	
    	spec:
    	    result = ((clientDependency->
    	      select(oclIsKindOf(Realization) and supplier->forAll(oclIsKindOf(Interface))))->
    	          collect(supplier.oclAsType(Interface))->asSet())
    	*/
    	set<Interface> DirectlyRealizedInterfaces();
    	/*
    	The Interfaces directly used by this Classifier
    	
    	spec:
    	    result = ((supplierDependency->
    	      select(oclIsKindOf(Usage) and client->forAll(oclIsKindOf(Interface))))->
    	        collect(client.oclAsType(Interface))->asSet())
    	*/
    	set<Interface> DirectlyUsedInterfaces();
    	/*
    	The Interfaces realized by this Classifier and all of its generalizations
    	
    	spec:
    	    result = (directlyRealizedInterfaces()->union(self.allParents()->collect(directlyRealizedInterfaces()))->asSet())
    	*/
    	set<Interface> AllRealizedInterfaces();
    	/*
    	The Interfaces used by this Classifier and all of its generalizations
    	
    	spec:
    	    result = (directlyUsedInterfaces()->union(self.allParents()->collect(directlyUsedInterfaces()))->asSet())
    	*/
    	set<Interface> AllUsedInterfaces();
    	bool IsSubstitutableFor(Classifier contract);
    	/*
    	The query allAttributes gives an ordered set of all owned and inherited attributes of the Classifier. All owned attributes appear before any inherited attributes, and the attributes inherited from any more specific parent Classifier appear before those of any more general parent Classifier. However, if the Classifier has multiple immediate parents, then the relative ordering of the sets of attributes from those parents is not defined.
    	
    	spec:
    	    result = (attribute->asSequence()->union(parents()->asSequence().allAttributes())->select(p | member->includes(p))->asOrderedSet())
    	*/
    	list<Property> AllAttributes();
    	/*
    	All StructuralFeatures related to the Classifier that may have Slots, including direct attributes, inherited attributes, private attributes in generalizations, and memberEnds of Associations, but excluding redefined StructuralFeatures.
    	
    	spec:
    	    result = (member->select(oclIsKindOf(StructuralFeature))->
    	      collect(oclAsType(StructuralFeature))->
    	       union(self.inherit(self.allParents()->collect(p | p.attribute)->asSet())->
    	         collect(oclAsType(StructuralFeature)))->asSet())
    	*/
    	set<StructuralFeature> AllSlottableFeatures();
    }

    /*
    A ClassifierTemplateParameter exposes a Classifier as a formal template parameter.
    */
    class ClassifierTemplateParameter : TemplateParameter
    {
    	/*
    	Constrains the required relationship between an actual parameter and the parameteredElement for this formal parameter.
    	*/
    	bool AllowSubstitutable;
    	/*
    	The classifiers that constrain the argument that can be used for the parameter. If the allowSubstitutable attribute is true, then any Classifier that is compatible with this constraining Classifier can be substituted; otherwise, it must be either this Classifier or one of its specializations. If this property is empty, there are no constraints on the Classifier that can be used as an argument.
    	*/
    	set<Classifier> ConstrainingClassifier;
    	/*
    	The Classifier exposed by this ClassifierTemplateParameter.
    	*/
    	Classifier ParameteredElement redefines TemplateParameter.ParameteredElement;
    }

    /*
    A Feature declares a behavioral or structural characteristic of Classifiers.
    */
    abstract class Feature : RedefinableElement
    {
    	/*
    	The Classifiers that have this Feature as a feature.
    	*/
    	union Classifier FeaturingClassifier;
    	/*
    	Specifies whether this Feature characterizes individual instances classified by the Classifier (false) or the Classifier itself (true).
    	*/
    	bool IsStatic;
    }

    /*
    A Generalization is a taxonomic relationship between a more general Classifier and a more specific Classifier. Each instance of the specific Classifier is also an instance of the general Classifier. The specific Classifier inherits the features of the more general Classifier. A Generalization is owned by the specific Classifier.
    */
    class Generalization : DirectedRelationship
    {
    	/*
    	The general classifier in the Generalization relationship.
    	*/
    	Classifier General subsets DirectedRelationship.Target;
    	/*
    	Represents a set of instances of Generalization.  A Generalization may appear in many GeneralizationSets.
    	*/
    	set<GeneralizationSet> GeneralizationSet;
    	/*
    	Indicates whether the specific Classifier can be used wherever the general Classifier can be used. If true, the execution traces of the specific Classifier shall be a superset of the execution traces of the general Classifier. If false, there is no such constraint on execution traces. If unset, the modeler has not stated whether there is such a constraint or not.
    	*/
    	bool IsSubstitutable;
    	/*
    	The specializing Classifier in the Generalization relationship.
    	*/
    	Classifier Specific subsets DirectedRelationship.Source, Element.Owner;
    }

    /*
    A GeneralizationSet is a PackageableElement whose instances represent sets of Generalization relationships.
    */
    class GeneralizationSet : PackageableElement
    {
    	/*
    	Designates the instances of Generalization that are members of this GeneralizationSet.
    	*/
    	set<Generalization> Generalization;
    	/*
    	Indicates (via the associated Generalizations) whether or not the set of specific Classifiers are covering for a particular general classifier. When isCovering is true, every instance of a particular general Classifier is also an instance of at least one of its specific Classifiers for the GeneralizationSet. When isCovering is false, there are one or more instances of the particular general Classifier that are not instances of at least one of its specific Classifiers defined for the GeneralizationSet.
    	*/
    	bool IsCovering;
    	/*
    	Indicates whether or not the set of specific Classifiers in a Generalization relationship have instance in common. If isDisjoint is true, the specific Classifiers for a particular GeneralizationSet have no members in common; that is, their intersection is empty. If isDisjoint is false, the specific Classifiers in a particular GeneralizationSet have one or more members in common; that is, their intersection is not empty.
    	*/
    	bool IsDisjoint;
    	/*
    	Designates the Classifier that is defined as the power type for the associated GeneralizationSet, if there is one.
    	*/
    	Classifier Powertype;
    }

    /*
    An InstanceSpecification is a model element that represents an instance in a modeled system. An InstanceSpecification can act as a DeploymentTarget in a Deployment relationship, in the case that it represents an instance of a Node. It can also act as a DeployedArtifact, if it represents an instance of an Artifact.
    */
    class InstanceSpecification : DeploymentTarget, PackageableElement, DeployedArtifact
    {
    	/*
    	The Classifier or Classifiers of the represented instance. If multiple Classifiers are specified, the instance is classified by all of them.
    	*/
    	set<Classifier> Classifier;
    	/*
    	A Slot giving the value or values of a StructuralFeature of the instance. An InstanceSpecification can have one Slot per StructuralFeature of its Classifiers, including inherited features. It is not necessary to model a Slot for every StructuralFeature, in which case the InstanceSpecification is a partial description.
    	*/
    	set<Slot> Slot subsets Element.OwnedElement;
    	/*
    	A specification of how to compute, derive, or construct the instance.
    	*/
    	ValueSpecification Specification subsets Element.OwnedElement;
    }

    /*
    An InstanceValue is a ValueSpecification that identifies an instance.
    */
    class InstanceValue : ValueSpecification
    {
    	/*
    	The InstanceSpecification that represents the specified value.
    	*/
    	InstanceSpecification Instance;
    }

    /*
    An Operation is a BehavioralFeature of a Classifier that specifies the name, type, parameters, and constraints for invoking an associated Behavior. An Operation may invoke both the execution of method behaviors as well as other behavioral responses. Operation specializes TemplateableElement in order to support specification of template operations and bound operations. Operation specializes ParameterableElement to specify that an operation can be exposed as a formal template parameter, and provided as an actual parameter in a binding of a template.
    */
    class Operation : TemplateableElement, ParameterableElement, BehavioralFeature
    {
    	/*
    	An optional Constraint on the result values of an invocation of this Operation.
    	*/
    	Constraint BodyCondition subsets Namespace.OwnedRule;
    	/*
    	The Class that owns this operation, if any.
    	*/
    	Class Class subsets Feature.FeaturingClassifier, NamedElement.Namespace, RedefinableElement.RedefinitionContext;
    	/*
    	The DataType that owns this Operation, if any.
    	*/
    	DataType Datatype subsets Feature.FeaturingClassifier, NamedElement.Namespace, RedefinableElement.RedefinitionContext;
    	/*
    	The Interface that owns this Operation, if any.
    	*/
    	Interface Interface subsets Feature.FeaturingClassifier, NamedElement.Namespace, RedefinableElement.RedefinitionContext;
    	/*
    	Specifies whether the return parameter is ordered or not, if present.  This information is derived from the return result for this Operation.
    	
    	spec:
    	    result = (if returnResult()->notEmpty() then returnResult()-> exists(isOrdered) else false endif)
    	*/
    	derived bool IsOrdered;
    	/*
    	Specifies whether an execution of the BehavioralFeature leaves the state of the system unchanged (isQuery=true) or whether side effects may occur (isQuery=false).
    	*/
    	bool IsQuery;
    	/*
    	Specifies whether the return parameter is unique or not, if present. This information is derived from the return result for this Operation.
    	
    	spec:
    	    result = (if returnResult()->notEmpty() then returnResult()->exists(isUnique) else true endif)
    	*/
    	derived bool IsUnique;
    	/*
    	Specifies the lower multiplicity of the return parameter, if present. This information is derived from the return result for this Operation.
    	
    	spec:
    	    result = (if returnResult()->notEmpty() then returnResult()->any(true).lower else null endif)
    	*/
    	derived int Lower;
    	/*
    	The parameters owned by this Operation.
    	*/
    	list<Parameter> OwnedParameter redefines BehavioralFeature.OwnedParameter;
    	/*
    	An optional set of Constraints specifying the state of the system when the Operation is completed.
    	*/
    	set<Constraint> Postcondition subsets Namespace.OwnedRule;
    	/*
    	An optional set of Constraints on the state of the system when the Operation is invoked.
    	*/
    	set<Constraint> Precondition subsets Namespace.OwnedRule;
    	/*
    	The Types representing exceptions that may be raised during an invocation of this operation.
    	*/
    	set<Type> RaisedException redefines BehavioralFeature.RaisedException;
    	/*
    	The Operations that are redefined by this Operation.
    	*/
    	set<Operation> RedefinedOperation subsets RedefinableElement.RedefinedElement;
    	/*
    	The OperationTemplateParameter that exposes this element as a formal parameter.
    	*/
    	OperationTemplateParameter TemplateParameter redefines ParameterableElement.TemplateParameter;
    	/*
    	The return type of the operation, if present. This information is derived from the return result for this Operation.
    	
    	spec:
    	    result = (if returnResult()->notEmpty() then returnResult()->any(true).type else null endif)
    	*/
    	derived Type Type;
    	/*
    	The upper multiplicity of the return parameter, if present. This information is derived from the return result for this Operation.
    	
    	spec:
    	    result = (if returnResult()->notEmpty() then returnResult()->any(true).upper else null endif)
    	*/
    	derived long Upper;
    	/*
    	The query isConsistentWith() specifies, for any two Operations in a context in which redefinition is possible, whether redefinition would be consistent. A redefining operation is consistent with a redefined operation if
    	it has the same number of owned parameters, and for each parameter the following holds:
    	
    	- Direction, ordering and uniqueness are the same.
    	- The corresponding types are covariant, contravariant or invariant.
    	- The multiplicities are compatible, depending on the parameter direction.
    	
    	spec:
    	    result = (redefiningElement.oclIsKindOf(Operation) and
    	    let op : Operation = redefiningElement.oclAsType(Operation) in
    	    	self.ownedParameter->size() = op.ownedParameter->size() and
    	    	Sequence{1..self.ownedParameter->size()}->
    	    		forAll(i |  
    	    		  let redefiningParam : Parameter = op.ownedParameter->at(i),
    	                   redefinedParam : Parameter = self.ownedParameter->at(i) in
    	                     (redefiningParam.isUnique = redefinedParam.isUnique) and
    	                     (redefiningParam.isOrdered = redefinedParam. isOrdered) and
    	                     (redefiningParam.direction = redefinedParam.direction) and
    	                     (redefiningParam.type.conformsTo(redefinedParam.type) or
    	                         redefinedParam.type.conformsTo(redefiningParam.type)) and
    	                     (redefiningParam.direction = ParameterDirectionKind::inout implies
    	                             (redefinedParam.compatibleWith(redefiningParam) and
    	                             redefiningParam.compatibleWith(redefinedParam))) and
    	                     (redefiningParam.direction = ParameterDirectionKind::_'in' implies
    	                             redefinedParam.compatibleWith(redefiningParam)) and
    	                     ((redefiningParam.direction = ParameterDirectionKind::out or
    	                          redefiningParam.direction = ParameterDirectionKind::return) implies
    	                             redefiningParam.compatibleWith(redefinedParam))
    	    		))
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    	/*
    	The query returnResult() returns the set containing the return parameter of the Operation if one exists, otherwise, it returns an empty set
    	
    	spec:
    	    result = (ownedParameter->select (direction = ParameterDirectionKind::return))
    	*/
    	set<Parameter> ReturnResult();
    }

    /*
    An OperationTemplateParameter exposes an Operation as a formal parameter for a template.
    */
    class OperationTemplateParameter : TemplateParameter
    {
    	/*
    	The Operation exposed by this OperationTemplateParameter.
    	*/
    	Operation ParameteredElement redefines TemplateParameter.ParameteredElement;
    }

    /*
    A Parameter is a specification of an argument used to pass information into or out of an invocation of a BehavioralFeature.  Parameters can be treated as ConnectableElements within Collaborations.
    */
    class Parameter : MultiplicityElement, ConnectableElement
    {
    	/*
    	A String that represents a value to be used when no argument is supplied for the Parameter.
    	
    	spec:
    	    result = (if self.type = String then defaultValue.stringValue() else null endif)
    	*/
    	derived string Default;
    	/*
    	Specifies a ValueSpecification that represents a value to be used when no argument is supplied for the Parameter.
    	*/
    	ValueSpecification DefaultValue subsets Element.OwnedElement;
    	/*
    	Indicates whether a parameter is being sent into or out of a behavioral element.
    	*/
    	ParameterDirectionKind Direction;
    	/*
    	Specifies the effect that executions of the owner of the Parameter have on objects passed in or out of the parameter.
    	*/
    	ParameterEffectKind Effect;
    	/*
    	Tells whether an output parameter may emit a value to the exclusion of the other outputs.
    	*/
    	bool IsException;
    	/*
    	Tells whether an input parameter may accept values while its behavior is executing, or whether an output parameter may post values while the behavior is executing.
    	*/
    	bool IsStream;
    	/*
    	The Operation owning this parameter.
    	*/
    	Operation Operation;
    	/*
    	The ParameterSets containing the parameter. See ParameterSet.
    	*/
    	set<ParameterSet> ParameterSet;
    }

    /*
    A ParameterSet designates alternative sets of inputs or outputs that a Behavior may use.
    */
    class ParameterSet : NamedElement
    {
    	/*
    	A constraint that should be satisfied for the owner of the Parameters in an input ParameterSet to start execution using the values provided for those Parameters, or the owner of the Parameters in an output ParameterSet to end execution providing the values for those Parameters, if all preconditions and conditions on input ParameterSets were satisfied.
    	*/
    	set<Constraint> Condition subsets Element.OwnedElement;
    	/*
    	Parameters in the ParameterSet.
    	*/
    	set<Parameter> Parameter;
    }

    /*
    A Property is a StructuralFeature. A Property related by ownedAttribute to a Classifier (other than an association) represents an attribute and might also represent an association end. It relates an instance of the Classifier to a value or set of values of the type of the attribute. A Property related by memberEnd to an Association represents an end of the Association. The type of the Property is the type of the end of the Association. A Property has the capability of being a DeploymentTarget in a Deployment relationship. This enables modeling the deployment to hierarchical nodes that have Properties functioning as internal parts.  Property specializes ParameterableElement to specify that a Property can be exposed as a formal template parameter, and provided as an actual parameter in a binding of a template.
    */
    class Property : ConnectableElement, DeploymentTarget, StructuralFeature
    {
    	/*
    	Specifies the kind of aggregation that applies to the Property.
    	*/
    	AggregationKind Aggregation;
    	/*
    	The Association of which this Property is a member, if any.
    	*/
    	Association Association;
    	/*
    	Designates the optional association end that owns a qualifier attribute.
    	*/
    	Property AssociationEnd subsets Element.Owner;
    	/*
    	The Class that owns this Property, if any.
    	*/
    	Class Class subsets NamedElement.Namespace;
    	/*
    	The DataType that owns this Property, if any.
    	*/
    	DataType Datatype subsets NamedElement.Namespace;
    	/*
    	A ValueSpecification that is evaluated to give a default value for the Property when an instance of the owning Classifier is instantiated.
    	*/
    	ValueSpecification DefaultValue subsets Element.OwnedElement;
    	/*
    	The Interface that owns this Property, if any.
    	*/
    	Interface Interface subsets NamedElement.Namespace;
    	/*
    	If isComposite is true, the object containing the attribute is a container for the object or value contained in the attribute. This is a derived value, indicating whether the aggregation of the Property is composite or not.
    	
    	spec:
    	    result = (aggregation = AggregationKind::composite)
    	*/
    	derived bool IsComposite;
    	/*
    	Specifies whether the Property is derived, i.e., whether its value or values can be computed from other information.
    	*/
    	bool IsDerived;
    	/*
    	Specifies whether the property is derived as the union of all of the Properties that are constrained to subset it.
    	*/
    	bool IsDerivedUnion;
    	/*
    	True indicates this property can be used to uniquely identify an instance of the containing Class.
    	*/
    	bool IsID;
    	/*
    	In the case where the Property is one end of a binary association this gives the other end.
    	
    	spec:
    	    result = (if association <> null and association.memberEnd->size() = 2
    	    then
    	        association.memberEnd->any(e | e <> self)
    	    else
    	        null
    	    endif)
    	*/
    	derived Property Opposite;
    	/*
    	The owning association of this property, if any.
    	*/
    	Association OwningAssociation subsets Feature.FeaturingClassifier, NamedElement.Namespace, Property.Association, RedefinableElement.RedefinitionContext;
    	/*
    	An optional list of ordered qualifier attributes for the end.
    	*/
    	list<Property> Qualifier subsets Element.OwnedElement;
    	/*
    	The properties that are redefined by this property, if any.
    	*/
    	set<Property> RedefinedProperty subsets RedefinableElement.RedefinedElement;
    	/*
    	The properties of which this Property is constrained to be a subset, if any.
    	*/
    	set<Property> SubsettedProperty;
    	/*
    	The query isAttribute() is true if the Property is defined as an attribute of some Classifier.
    	
    	spec:
    	    result = (not classifier->isEmpty())
    	*/
    	bool IsAttribute();
    	/*
    	The query isCompatibleWith() determines if this Property is compatible with the specified ParameterableElement. This Property is compatible with ParameterableElement p if the kind of this Property is thesame as or a subtype of the kind of p. Further, if p is a TypedElement, then the type of this Property must be conformant with the type of p.
    	
    	spec:
    	    result = (self.oclIsKindOf(p.oclType()) and (p.oclIsKindOf(TypeElement) implies
    	    self.type.conformsTo(p.oclAsType(TypedElement).type)))
    	*/
    	bool IsCompatibleWith(ParameterableElement p);
    	/*
    	The query isConsistentWith() specifies, for any two Properties in a context in which redefinition is possible, whether redefinition would be logically consistent. A redefining Property is consistent with a redefined Property if the type of the redefining Property conforms to the type of the redefined Property, and the multiplicity of the redefining Property (if specified) is contained in the multiplicity of the redefined Property.
    	
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	spec:
    	    result = (redefiningElement.oclIsKindOf(Property) and 
    	      let prop : Property = redefiningElement.oclAsType(Property) in 
    	      (prop.type.conformsTo(self.type) and 
    	      ((prop.lowerBound()->notEmpty() and self.lowerBound()->notEmpty()) implies prop.lowerBound() >= self.lowerBound()) and 
    	      ((prop.upperBound()->notEmpty() and self.upperBound()->notEmpty()) implies prop.lowerBound() <= self.lowerBound()) and 
    	      (self.isComposite implies prop.isComposite)))
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    	/*
    	The query isNavigable() indicates whether it is possible to navigate across the property.
    	
    	spec:
    	    result = (not classifier->isEmpty() or association.navigableOwnedEnd->includes(self))
    	*/
    	bool IsNavigable();
    	/*
    	The query subsettingContext() gives the context for subsetting a Property. It consists, in the case of an attribute, of the corresponding Classifier, and in the case of an association end, all of the Classifiers at the other ends.
    	
    	spec:
    	    result = (if association <> null
    	    then association.memberEnd->excluding(self)->collect(type)->asSet()
    	    else 
    	      if classifier<>null
    	      then classifier->asSet()
    	      else Set{} 
    	      endif
    	    endif)
    	*/
    	set<Type> SubsettingContext();
    }

    /*
    A RedefinableElement is an element that, when defined in the context of a Classifier, can be redefined more specifically or differently in the context of another Classifier that specializes (directly or indirectly) the context Classifier.
    */
    abstract class RedefinableElement : NamedElement
    {
    	/*
    	Indicates whether it is possible to further redefine a RedefinableElement. If the value is true, then it is not possible to further redefine the RedefinableElement.
    	*/
    	bool IsLeaf;
    	/*
    	The RedefinableElement that is being redefined by this element.
    	*/
    	union set<RedefinableElement> RedefinedElement;
    	/*
    	The contexts that this element may be redefined from.
    	*/
    	union set<Classifier> RedefinitionContext;
    	/*
    	The query isConsistentWith() specifies, for any two RedefinableElements in a context in which redefinition is possible, whether redefinition would be logically consistent. By default, this is false; this operation must be overridden for subclasses of RedefinableElement to define the consistency conditions.
    	
    	spec:
    	    result = (false)
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    	/*
    	The query isRedefinitionContextValid() specifies whether the redefinition contexts of this RedefinableElement are properly related to the redefinition contexts of the specified RedefinableElement to allow this element to redefine the other. By default at least one of the redefinition contexts of this element must be a specialization of at least one of the redefinition contexts of the specified element.
    	
    	spec:
    	    result = (redefinitionContext->exists(c | c.allParents()->includesAll(redefinedElement.redefinitionContext)))
    	*/
    	bool IsRedefinitionContextValid(RedefinableElement redefinedElement);
    }

    /*
    A RedefinableTemplateSignature supports the addition of formal template parameters in a specialization of a template classifier.
    */
    class RedefinableTemplateSignature : RedefinableElement, TemplateSignature
    {
    	/*
    	The Classifier that owns this RedefinableTemplateSignature.
    	*/
    	Classifier Classifier redefines TemplateSignature.Template subsets RedefinableElement.RedefinitionContext;
    	/*
    	The signatures extended by this RedefinableTemplateSignature.
    	*/
    	set<RedefinableTemplateSignature> ExtendedSignature subsets RedefinableElement.RedefinedElement;
    	/*
    	The formal template parameters of the extended signatures.
    	
    	spec:
    	    result = (if extendedSignature->isEmpty() then Set{} else extendedSignature.parameter->asSet() endif)
    	*/
    	derived set<TemplateParameter> InheritedParameter subsets TemplateSignature.Parameter;
    	/*
    	The query isConsistentWith() specifies, for any two RedefinableTemplateSignatures in a context in which redefinition is possible, whether redefinition would be logically consistent. A redefining template signature is always consistent with a redefined template signature, as redefinition only adds new formal parameters.
    	
    	spec:
    	    result = (redefiningElement.oclIsKindOf(RedefinableTemplateSignature))
    	pre:
    	    redefiningElement.isRedefinitionContextValid(self)
    	*/
    	bool IsConsistentWith(RedefinableElement redefiningElement);
    }

    /*
    A Slot designates that an entity modeled by an InstanceSpecification has a value or values for a specific StructuralFeature.
    */
    class Slot : Element
    {
    	/*
    	The StructuralFeature that specifies the values that may be held by the Slot.
    	*/
    	StructuralFeature DefiningFeature;
    	/*
    	The InstanceSpecification that owns this Slot.
    	*/
    	InstanceSpecification OwningInstance subsets Element.Owner;
    	/*
    	The value or values held by the Slot.
    	*/
    	list<ValueSpecification> Value subsets Element.OwnedElement;
    }

    /*
    A StructuralFeature is a typed feature of a Classifier that specifies the structure of instances of the Classifier.
    */
    abstract class StructuralFeature : MultiplicityElement, TypedElement, Feature
    {
    	/*
    	If isReadOnly is true, the StructuralFeature may not be written to after initialization.
    	*/
    	bool IsReadOnly;
    }

    /*
    A ValueSpecificationAction is an Action that evaluates a ValueSpecification and provides a result.
    */
    class ValueSpecificationAction : Action
    {
    	/*
    	The OutputPin on which the result value is placed.
    	*/
    	OutputPin Result subsets Action.Output;
    	/*
    	The ValueSpecification to be evaluated.
    	*/
    	ValueSpecification Value subsets Element.OwnedElement;
    }

    /*
    VariableAction is an abstract class for Actions that operate on a specified Variable.
    */
    abstract class VariableAction : Action
    {
    	/*
    	The Variable to be read or written.
    	*/
    	Variable Variable;
    }

    /*
    WriteLinkAction is an abstract class for LinkActions that create and destroy links.
    */
    abstract class WriteLinkAction : LinkAction
    {
    }

    /*
    WriteStructuralFeatureAction is an abstract class for StructuralFeatureActions that change StructuralFeature values.
    */
    abstract class WriteStructuralFeatureAction : StructuralFeatureAction
    {
    	/*
    	The OutputPin on which is put the input object as modified by the WriteStructuralFeatureAction.
    	*/
    	OutputPin Result subsets Action.Output;
    	/*
    	The InputPin that provides the value to be added or removed from the StructuralFeature.
    	*/
    	InputPin Value subsets Action.Input;
    }

    /*
    WriteVariableAction is an abstract class for VariableActions that change Variable values.
    */
    abstract class WriteVariableAction : VariableAction
    {
    	/*
    	The InputPin that gives the value to be added or removed from the Variable.
    	*/
    	InputPin Value subsets Action.Input;
    }

    /*
    An AcceptCallAction is an AcceptEventAction that handles the receipt of a synchronous call request. In addition to the values from the Operation input parameters, the Action produces an output that is needed later to supply the information to the ReplyAction necessary to return control to the caller. An AcceptCallAction is for synchronous calls. If it is used to handle an asynchronous call, execution of the subsequent ReplyAction will complete immediately with no effect.
    */
    class AcceptCallAction : AcceptEventAction
    {
    	/*
    	An OutputPin where a value is placed containing sufficient information to perform a subsequent ReplyAction and return control to the caller. The contents of this value are opaque. It can be passed and copied but it cannot be manipulated by the model.
    	*/
    	OutputPin ReturnInformation subsets Action.Output;
    }

    /*
    An AcceptEventAction is an Action that waits for the occurrence of one or more specific Events.
    */
    class AcceptEventAction : Action
    {
    	/*
    	Indicates whether there is a single OutputPin for a SignalEvent occurrence, or multiple OutputPins for attribute values of the instance of the Signal associated with a SignalEvent occurrence.
    	*/
    	bool IsUnmarshall;
    	/*
    	OutputPins holding the values received from an Event occurrence.
    	*/
    	list<OutputPin> Result subsets Action.Output;
    	/*
    	The Triggers specifying the Events of which the AcceptEventAction waits for occurrences.
    	*/
    	set<Trigger> Trigger subsets Element.OwnedElement;
    }

    /*
    An Action is the fundamental unit of executable functionality. The execution of an Action represents some transformation or processing in the modeled system. Actions provide the ExecutableNodes within Activities and may also be used within Interactions.
    */
    abstract class Action : ExecutableNode
    {
    	/*
    	The context Classifier of the Behavior that contains this Action, or the Behavior itself if it has no context.
    	
    	spec:
    	    result = (let behavior: Behavior = self.containingBehavior() in
    	    if behavior=null then null
    	    else if behavior._'context' = null then behavior
    	    else behavior._'context'
    	    endif
    	    endif)
    	*/
    	derived Classifier Context;
    	/*
    	The ordered set of InputPins representing the inputs to the Action.
    	*/
    	union list<InputPin> Input subsets Element.OwnedElement;
    	/*
    	If true, the Action can begin a new, concurrent execution, even if there is already another execution of the Action ongoing. If false, the Action cannot begin a new execution until any previous execution has completed.
    	*/
    	bool IsLocallyReentrant;
    	/*
    	A Constraint that must be satisfied when execution of the Action is completed.
    	*/
    	set<Constraint> LocalPostcondition subsets Element.OwnedElement;
    	/*
    	A Constraint that must be satisfied when execution of the Action is started.
    	*/
    	set<Constraint> LocalPrecondition subsets Element.OwnedElement;
    	/*
    	The ordered set of OutputPins representing outputs from the Action.
    	*/
    	union list<OutputPin> Output subsets Element.OwnedElement;
    	/*
    	Return this Action and all Actions contained directly or indirectly in it. By default only the Action itself is returned, but the operation is overridden for StructuredActivityNodes.
    	
    	spec:
    	    result = (self->asSet())
    	*/
    	set<Action> AllActions();
    	/*
    	Returns all the ActivityNodes directly or indirectly owned by this Action. This includes at least all the Pins of the Action.
    	
    	spec:
    	    result = (input.oclAsType(Pin)->asSet()->union(output->asSet()))
    	*/
    	set<ActivityNode> AllOwnedNodes();
    	Behavior ContainingBehavior();
    }

    /*
    An ActionInputPin is a kind of InputPin that executes an Action to determine the values to input to another Action.
    */
    class ActionInputPin : InputPin
    {
    	/*
    	The Action used to provide the values of the ActionInputPin.
    	*/
    	Action FromAction subsets Element.OwnedElement;
    }

    /*
    An AddStructuralFeatureValueAction is a WriteStructuralFeatureAction for adding values to a StructuralFeature.
    */
    class AddStructuralFeatureValueAction : WriteStructuralFeatureAction
    {
    	/*
    	The InputPin that gives the position at which to insert the value in an ordered StructuralFeature. The type of the insertAt InputPin is UnlimitedNatural, but the value cannot be zero. It is omitted for unordered StructuralFeatures.
    	*/
    	InputPin InsertAt subsets Action.Input;
    	/*
    	Specifies whether existing values of the StructuralFeature should be removed before adding the new value.
    	*/
    	bool IsReplaceAll;
    }

    /*
    An AddVariableValueAction is a WriteVariableAction for adding values to a Variable.
    */
    class AddVariableValueAction : WriteVariableAction
    {
    	/*
    	The InputPin that gives the position at which to insert a new value or move an existing value in ordered Variables. The type of the insertAt InputPin is UnlimitedNatural, but the value cannot be zero. It is omitted for unordered Variables.
    	*/
    	InputPin InsertAt subsets Action.Input;
    	/*
    	Specifies whether existing values of the Variable should be removed before adding the new value.
    	*/
    	bool IsReplaceAll;
    }

    /*
    A BroadcastSignalAction is an InvocationAction that transmits a Signal instance to all the potential target objects in the system. Values from the argument InputPins are used to provide values for the attributes of the Signal. The requestor continues execution immediately after the Signal instances are sent out and cannot receive reply values.
    */
    class BroadcastSignalAction : InvocationAction
    {
    	/*
    	The Signal whose instances are to be sent.
    	*/
    	Signal Signal;
    }

    /*
    CallAction is an abstract class for Actions that invoke a Behavior with given argument values and (if the invocation is synchronous) receive reply values.
    */
    abstract class CallAction : InvocationAction
    {
    	/*
    	If true, the call is synchronous and the caller waits for completion of the invoked Behavior. If false, the call is asynchronous and the caller proceeds immediately and cannot receive return values.
    	*/
    	bool IsSynchronous;
    	/*
    	The OutputPins on which the reply values from the invocation are placed (if the call is synchronous).
    	*/
    	list<OutputPin> Result subsets Action.Output;
    	/*
    	Return the in and inout ownedParameters of the Behavior or Operation being called. (This operation is abstract and should be overridden by subclasses of CallAction.)
    	*/
    	list<Parameter> InputParameters();
    	/*
    	Return the inout, out and return ownedParameters of the Behavior or Operation being called. (This operation is abstract and should be overridden by subclasses of CallAction.)
    	*/
    	list<Parameter> OutputParameters();
    }

    /*
    A CallBehaviorAction is a CallAction that invokes a Behavior directly. The argument values of the CallBehaviorAction are passed on the input Parameters of the invoked Behavior. If the call is synchronous, the execution of the CallBehaviorAction waits until the execution of the invoked Behavior completes and the values of output Parameters of the Behavior are placed on the result OutputPins. If the call is asynchronous, the CallBehaviorAction completes immediately and no results values can be provided.
    */
    class CallBehaviorAction : CallAction
    {
    	/*
    	The Behavior being invoked.
    	*/
    	Behavior Behavior;
    	/*
    	Return the inout, out and return ownedParameters of the Behavior being called.
    	
    	spec:
    	    result = (behavior.outputParameters())
    	*/
    	list<Parameter> OutputParameters();
    	/*
    	Return the in and inout ownedParameters of the Behavior being called.
    	
    	spec:
    	    result = (behavior.inputParameters())
    	*/
    	list<Parameter> InputParameters();
    }

    /*
    A CallOperationAction is a CallAction that transmits an Operation call request to the target object, where it may cause the invocation of associated Behavior. The argument values of the CallOperationAction are passed on the input Parameters of the Operation. If call is synchronous, the execution of the CallOperationAction waits until the execution of the invoked Operation completes and the values of output Parameters of the Operation are placed on the result OutputPins. If the call is asynchronous, the CallOperationAction completes immediately and no results values can be provided.
    */
    class CallOperationAction : CallAction
    {
    	/*
    	The Operation being invoked.
    	*/
    	Operation Operation;
    	/*
    	The InputPin that provides the target object to which the Operation call request is sent.
    	*/
    	InputPin Target subsets Action.Input;
    	/*
    	Return the inout, out and return ownedParameters of the Operation being called.
    	
    	spec:
    	    result = (operation.outputParameters())
    	*/
    	list<Parameter> OutputParameters();
    	/*
    	Return the in and inout ownedParameters of the Operation being called.
    	
    	spec:
    	    result = (operation.inputParameters())
    	*/
    	list<Parameter> InputParameters();
    }

    /*
    A Clause is an Element that represents a single branch of a ConditionalNode, including a test and a body section. The body section is executed only if (but not necessarily if) the test section evaluates to true.
    */
    class Clause : Element
    {
    	/*
    	The set of ExecutableNodes that are executed if the test evaluates to true and the Clause is chosen over other Clauses within the ConditionalNode that also have tests that evaluate to true.
    	*/
    	set<ExecutableNode> Body;
    	/*
    	The OutputPins on Actions within the body section whose values are moved to the result OutputPins of the containing ConditionalNode after execution of the body.
    	*/
    	list<OutputPin> BodyOutput;
    	/*
    	An OutputPin on an Action in the test section whose Boolean value determines the result of the test.
    	*/
    	OutputPin Decider;
    	/*
    	A set of Clauses whose tests must all evaluate to false before this Clause can evaluate its test.
    	*/
    	set<Clause> PredecessorClause;
    	/*
    	A set of Clauses that may not evaluate their tests unless the test for this Clause evaluates to false.
    	*/
    	set<Clause> SuccessorClause;
    	/*
    	The set of ExecutableNodes that are executed in order to provide a test result for the Clause.
    	*/
    	set<ExecutableNode> Test;
    }

    /*
    A ClearAssociationAction is an Action that destroys all links of an Association in which a particular object participates.
    */
    class ClearAssociationAction : Action
    {
    	/*
    	The Association to be cleared.
    	*/
    	Association Association;
    	/*
    	The InputPin that gives the object whose participation in the Association is to be cleared.
    	*/
    	InputPin Object subsets Action.Input;
    }

    /*
    A ClearStructuralFeatureAction is a StructuralFeatureAction that removes all values of a StructuralFeature.
    */
    class ClearStructuralFeatureAction : StructuralFeatureAction
    {
    	/*
    	The OutputPin on which is put the input object as modified by the ClearStructuralFeatureAction.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A ClearVariableAction is a VariableAction that removes all values of a Variable.
    */
    class ClearVariableAction : VariableAction
    {
    }

    /*
    A ConditionalNode is a StructuredActivityNode that chooses one among some number of alternative collections of ExecutableNodes to execute.
    */
    class ConditionalNode : StructuredActivityNode
    {
    	/*
    	The set of Clauses composing the ConditionalNode.
    	*/
    	set<Clause> Clause subsets Element.OwnedElement;
    	/*
    	If true, the modeler asserts that the test for at least one Clause of the ConditionalNode will succeed.
    	*/
    	bool IsAssured;
    	/*
    	If true, the modeler asserts that the test for at most one Clause of the ConditionalNode will succeed.
    	*/
    	bool IsDeterminate;
    	/*
    	The OutputPins that onto which are moved values from the bodyOutputs of the Clause selected for execution.
    	*/
    	list<OutputPin> Result redefines StructuredActivityNode.StructuredNodeOutput;
    	/*
    	Return only this ConditionalNode. This prevents Actions within the ConditionalNode from having their OutputPins used as bodyOutputs or decider Pins in containing LoopNodes or ConditionalNodes.
    	
    	spec:
    	    result = (self->asSet())
    	*/
    	set<Action> AllActions();
    }

    /*
    A CreateLinkAction is a WriteLinkAction for creating links.
    */
    class CreateLinkAction : WriteLinkAction
    {
    	/*
    	The LinkEndData that specifies the values to be placed on the Association ends for the new link.
    	*/
    	set<LinkEndCreationData> EndData redefines LinkAction.EndData;
    }

    /*
    A CreateLinkObjectAction is a CreateLinkAction for creating link objects (AssociationClasse instances).
    */
    class CreateLinkObjectAction : CreateLinkAction
    {
    	/*
    	The output pin on which the newly created link object is placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A CreateObjectAction is an Action that creates an instance of the specified Classifier.
    */
    class CreateObjectAction : Action
    {
    	/*
    	The Classifier to be instantiated.
    	*/
    	Classifier Classifier;
    	/*
    	The OutputPin on which the newly created object is placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A DestroyLinkAction is a WriteLinkAction that destroys links (including link objects).
    */
    class DestroyLinkAction : WriteLinkAction
    {
    	/*
    	The LinkEndData that the values of the Association ends for the links to be destroyed.
    	*/
    	set<LinkEndDestructionData> EndData redefines LinkAction.EndData;
    }

    /*
    A DestroyObjectAction is an Action that destroys objects.
    */
    class DestroyObjectAction : Action
    {
    	/*
    	Specifies whether links in which the object participates are destroyed along with the object.
    	*/
    	bool IsDestroyLinks;
    	/*
    	Specifies whether objects owned by the object (via composition) are destroyed along with the object.
    	*/
    	bool IsDestroyOwnedObjects;
    	/*
    	The InputPin providing the object to be destroyed.
    	*/
    	InputPin Target subsets Action.Input;
    }

    /*
    An ExpansionNode is an ObjectNode used to indicate a collection input or output for an ExpansionRegion. A collection input of an ExpansionRegion contains a collection that is broken into its individual elements inside the region, whose content is executed once per element. A collection output of an ExpansionRegion combines individual elements produced by the execution of the region into a collection for use outside the region.
    */
    class ExpansionNode : ObjectNode
    {
    	/*
    	The ExpansionRegion for which the ExpansionNode is an input.
    	*/
    	ExpansionRegion RegionAsInput;
    	/*
    	The ExpansionRegion for which the ExpansionNode is an output.
    	*/
    	ExpansionRegion RegionAsOutput;
    }

    /*
    An ExpansionRegion is a StructuredActivityNode that executes its content multiple times corresponding to elements of input collection(s).
    */
    class ExpansionRegion : StructuredActivityNode
    {
    	/*
    	The ExpansionNodes that hold the input collections for the ExpansionRegion.
    	*/
    	set<ExpansionNode> InputElement;
    	/*
    	The mode in which the ExpansionRegion executes its contents. If parallel, executions are concurrent. If iterative, executions are sequential. If stream, a stream of values flows into a single execution.
    	*/
    	ExpansionKind Mode;
    	/*
    	The ExpansionNodes that form the output collections of the ExpansionRegion.
    	*/
    	set<ExpansionNode> OutputElement;
    }

    /*
    An InputPin is a Pin that holds input values to be consumed by an Action.
    */
    class InputPin : Pin
    {
    }

    /*
    InvocationAction is an abstract class for the various actions that request Behavior invocation.
    */
    abstract class InvocationAction : Action
    {
    	/*
    	The InputPins that provide the argument values passed in the invocation request.
    	*/
    	list<InputPin> Argument subsets Action.Input;
    	/*
    	For CallOperationActions, SendSignalActions, and SendObjectActions, an optional Port of the target object through which the invocation request is sent.
    	*/
    	Port OnPort;
    }

    /*
    LinkAction is an abstract class for all Actions that identify the links to be acted on using LinkEndData.
    */
    abstract class LinkAction : Action
    {
    	/*
    	The LinkEndData identifying the values on the ends of the links acting on by this LinkAction.
    	*/
    	set<LinkEndData> EndData subsets Element.OwnedElement;
    	/*
    	InputPins used by the LinkEndData of the LinkAction.
    	*/
    	set<InputPin> InputValue subsets Action.Input;
    	/*
    	Returns the Association acted on by this LinkAction.
    	
    	spec:
    	    result = (endData->asSequence()->first().end.association)
    	*/
    	Association Association();
    }

    /*
    LinkEndCreationData is LinkEndData used to provide values for one end of a link to be created by a CreateLinkAction.
    */
    class LinkEndCreationData : LinkEndData
    {
    	/*
    	For ordered Association ends, the InputPin that provides the position where the new link should be inserted or where an existing link should be moved to. The type of the insertAt InputPin is UnlimitedNatural, but the input cannot be zero. It is omitted for Association ends that are not ordered.
    	*/
    	InputPin InsertAt;
    	/*
    	Specifies whether the existing links emanating from the object on this end should be destroyed before creating a new link.
    	*/
    	bool IsReplaceAll;
    	/*
    	Adds the insertAt InputPin (if any) to the set of all Pins.
    	
    	spec:
    	    result = (self.LinkEndData::allPins()->including(insertAt))
    	*/
    	multi_set<InputPin> AllPins();
    }

    /*
    LinkEndData is an Element that identifies on end of a link to be read or written by a LinkAction. As a link (that is not a link object) cannot be passed as a runtime value to or from an Action, it is instead identified by its end objects and qualifier values, if any. A LinkEndData instance provides these values for a single Association end.
    */
    class LinkEndData : Element
    {
    	/*
    	The Association end for which this LinkEndData specifies values.
    	*/
    	Property End;
    	/*
    	A set of QualifierValues used to provide values for the qualifiers of the end.
    	*/
    	set<QualifierValue> Qualifier subsets Element.OwnedElement;
    	/*
    	The InputPin that provides the specified value for the given end. This InputPin is omitted if the LinkEndData specifies the "open" end for a ReadLinkAction.
    	*/
    	InputPin Value;
    	/*
    	Returns all the InputPins referenced by this LinkEndData. By default this includes the value and qualifier InputPins, but subclasses may override the operation to add other InputPins.
    	
    	spec:
    	    result = (value->asBag()->union(qualifier.value))
    	*/
    	multi_set<InputPin> AllPins();
    }

    /*
    LinkEndDestructionData is LinkEndData used to provide values for one end of a link to be destroyed by a DestroyLinkAction.
    */
    class LinkEndDestructionData : LinkEndData
    {
    	/*
    	The InputPin that provides the position of an existing link to be destroyed in an ordered, nonunique Association end. The type of the destroyAt InputPin is UnlimitedNatural, but the value cannot be zero or unlimited.
    	*/
    	InputPin DestroyAt;
    	/*
    	Specifies whether to destroy duplicates of the value in nonunique Association ends.
    	*/
    	bool IsDestroyDuplicates;
    	/*
    	Adds the destroyAt InputPin (if any) to the set of all Pins.
    	
    	spec:
    	    result = (self.LinkEndData::allPins()->including(destroyAt))
    	*/
    	multi_set<InputPin> AllPins();
    }

    /*
    A LoopNode is a StructuredActivityNode that represents an iterative loop with setup, test, and body sections.
    */
    class LoopNode : StructuredActivityNode
    {
    	/*
    	The OutputPins on Actions within the bodyPart, the values of which are moved to the loopVariable OutputPins after the completion of each execution of the bodyPart, before the next iteration of the loop begins or before the loop exits.
    	*/
    	list<OutputPin> BodyOutput;
    	/*
    	The set of ExecutableNodes that perform the repetitive computations of the loop. The bodyPart is executed as long as the test section produces a true value.
    	*/
    	set<ExecutableNode> BodyPart;
    	/*
    	An OutputPin on an Action in the test section whose Boolean value determines whether to continue executing the loop bodyPart.
    	*/
    	OutputPin Decider;
    	/*
    	If true, the test is performed before the first execution of the bodyPart. If false, the bodyPart is executed once before the test is performed.
    	*/
    	bool IsTestedFirst;
    	/*
    	A list of OutputPins that hold the values of the loop variables during an execution of the loop. When the test fails, the values are moved to the result OutputPins of the loop.
    	*/
    	list<OutputPin> LoopVariable subsets Element.OwnedElement;
    	/*
    	A list of InputPins whose values are moved into the loopVariable Pins before the first iteration of the loop.
    	*/
    	list<InputPin> LoopVariableInput redefines StructuredActivityNode.StructuredNodeInput;
    	/*
    	A list of OutputPins that receive the loopVariable values after the last iteration of the loop and constitute the output of the LoopNode.
    	*/
    	list<OutputPin> Result redefines StructuredActivityNode.StructuredNodeOutput;
    	/*
    	The set of ExecutableNodes executed before the first iteration of the loop, in order to initialize values or perform other setup computations.
    	*/
    	set<ExecutableNode> SetupPart;
    	/*
    	The set of ExecutableNodes executed in order to provide the test result for the loop.
    	*/
    	set<ExecutableNode> Test;
    	/*
    	Return only this LoopNode. This prevents Actions within the LoopNode from having their OutputPins used as bodyOutputs or decider Pins in containing LoopNodes or ConditionalNodes.
    	
    	spec:
    	    result = (self->asSet())
    	*/
    	set<Action> AllActions();
    	/*
    	Return the loopVariable OutputPins in addition to other source nodes for the LoopNode as a StructuredActivityNode.
    	
    	spec:
    	    result = (self.StructuredActivityNode::sourceNodes()->union(loopVariable))
    	*/
    	set<ActivityNode> SourceNodes();
    }

    /*
    An OpaqueAction is an Action whose functionality is not specified within UML.
    */
    class OpaqueAction : Action
    {
    	/*
    	Provides a textual specification of the functionality of the Action, in one or more languages other than UML.
    	*/
    	multi_list<string> Body;
    	/*
    	The InputPins providing inputs to the OpaqueAction.
    	*/
    	set<InputPin> InputValue subsets Action.Input;
    	/*
    	If provided, a specification of the language used for each of the body Strings.
    	*/
    	list<string> Language;
    	/*
    	The OutputPins on which the OpaqueAction provides outputs.
    	*/
    	set<OutputPin> OutputValue subsets Action.Output;
    }

    /*
    An OutputPin is a Pin that holds output values produced by an Action.
    */
    class OutputPin : Pin
    {
    }

    /*
    A Pin is an ObjectNode and MultiplicityElement that provides input values to an Action or accepts output values from an Action.
    */
    abstract class Pin : ObjectNode, MultiplicityElement
    {
    	/*
    	Indicates whether the Pin provides data to the Action or just controls how the Action executes.
    	*/
    	bool IsControl;
    }

    /*
    A QualifierValue is an Element that is used as part of LinkEndData to provide the value for a single qualifier of the end given by the LinkEndData.
    */
    class QualifierValue : Element
    {
    	/*
    	The qualifier Property for which the value is to be specified.
    	*/
    	Property Qualifier;
    	/*
    	The InputPin from which the specified value for the qualifier is taken.
    	*/
    	InputPin Value;
    }

    /*
    A RaiseExceptionAction is an Action that causes an exception to occur. The input value becomes the exception object.
    */
    class RaiseExceptionAction : Action
    {
    	/*
    	An InputPin whose value becomes the exception object.
    	*/
    	InputPin Exception subsets Action.Input;
    }

    /*
    A ReadExtentAction is an Action that retrieves the current instances of a Classifier.
    */
    class ReadExtentAction : Action
    {
    	/*
    	The Classifier whose instances are to be retrieved.
    	*/
    	Classifier Classifier;
    	/*
    	The OutputPin on which the Classifier instances are placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A ReadIsClassifiedObjectAction is an Action that determines whether an object is classified by a given Classifier.
    */
    class ReadIsClassifiedObjectAction : Action
    {
    	/*
    	The Classifier against which the classification of the input object is tested.
    	*/
    	Classifier Classifier;
    	/*
    	Indicates whether the input object must be directly classified by the given Classifier or whether it may also be an instance of a specialization of the given Classifier.
    	*/
    	bool IsDirect;
    	/*
    	The InputPin that holds the object whose classification is to be tested.
    	*/
    	InputPin Object subsets Action.Input;
    	/*
    	The OutputPin that holds the Boolean result of the test.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A ReadLinkAction is a LinkAction that navigates across an Association to retrieve the objects on one end.
    */
    class ReadLinkAction : LinkAction
    {
    	/*
    	The OutputPin on which the objects retrieved from the "open" end of those links whose values on other ends are given by the endData.
    	*/
    	OutputPin Result subsets Action.Output;
    	/*
    	Returns the ends corresponding to endData with no value InputPin. (A well-formed ReadLinkAction is constrained to have only one of these.)
    	
    	spec:
    	    result = (endData->select(value=null).end->asOrderedSet())
    	*/
    	list<Property> OpenEnd();
    }

    /*
    A ReadLinkObjectEndAction is an Action that retrieves an end object from a link object.
    */
    class ReadLinkObjectEndAction : Action
    {
    	/*
    	The Association end to be read.
    	*/
    	Property End;
    	/*
    	The input pin from which the link object is obtained.
    	*/
    	InputPin Object subsets Action.Input;
    	/*
    	The OutputPin where the result value is placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A ReadLinkObjectEndQualifierAction is an Action that retrieves a qualifier end value from a link object.
    */
    class ReadLinkObjectEndQualifierAction : Action
    {
    	/*
    	The InputPin from which the link object is obtained.
    	*/
    	InputPin Object subsets Action.Input;
    	/*
    	The qualifier Property to be read.
    	*/
    	Property Qualifier;
    	/*
    	The OutputPin where the result value is placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A ReadSelfAction is an Action that retrieves the context object of the Behavior execution within which the ReadSelfAction execution is taking place.
    */
    class ReadSelfAction : Action
    {
    	/*
    	The OutputPin on which the context object is placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A ReadStructuralFeatureAction is a StructuralFeatureAction that retrieves the values of a StructuralFeature.
    */
    class ReadStructuralFeatureAction : StructuralFeatureAction
    {
    	/*
    	The OutputPin on which the result values are placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A ReadVariableAction is a VariableAction that retrieves the values of a Variable.
    */
    class ReadVariableAction : VariableAction
    {
    	/*
    	The OutputPin on which the result values are placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A ReclassifyObjectAction is an Action that changes the Classifiers that classify an object.
    */
    class ReclassifyObjectAction : Action
    {
    	/*
    	Specifies whether existing Classifiers should be removed before adding the new Classifiers.
    	*/
    	bool IsReplaceAll;
    	/*
    	A set of Classifiers to be added to the Classifiers of the given object.
    	*/
    	set<Classifier> NewClassifier;
    	/*
    	The InputPin that holds the object to be reclassified.
    	*/
    	InputPin Object subsets Action.Input;
    	/*
    	A set of Classifiers to be removed from the Classifiers of the given object.
    	*/
    	set<Classifier> OldClassifier;
    }

    /*
    A ReduceAction is an Action that reduces a collection to a single value by repeatedly combining the elements of the collection using a reducer Behavior.
    */
    class ReduceAction : Action
    {
    	/*
    	The InputPin that provides the collection to be reduced.
    	*/
    	InputPin Collection subsets Action.Input;
    	/*
    	Indicates whether the order of the input collection should determine the order in which the reducer Behavior is applied to its elements.
    	*/
    	bool IsOrdered;
    	/*
    	A Behavior that is repreatedly applied to two elements of the input collection to produce a value that is of the same type as elements of the collection.
    	*/
    	Behavior Reducer;
    	/*
    	The output pin on which the result value is placed.
    	*/
    	OutputPin Result subsets Action.Output;
    }

    /*
    A RemoveStructuralFeatureValueAction is a WriteStructuralFeatureAction that removes values from a StructuralFeature.
    */
    class RemoveStructuralFeatureValueAction : WriteStructuralFeatureAction
    {
    	/*
    	Specifies whether to remove duplicates of the value in nonunique StructuralFeatures.
    	*/
    	bool IsRemoveDuplicates;
    	/*
    	An InputPin that provides the position of an existing value to remove in ordered, nonunique structural features. The type of the removeAt InputPin is UnlimitedNatural, but the value cannot be zero or unlimited.
    	*/
    	InputPin RemoveAt subsets Action.Input;
    }

    /*
    A RemoveVariableValueAction is a WriteVariableAction that removes values from a Variables.
    */
    class RemoveVariableValueAction : WriteVariableAction
    {
    	/*
    	Specifies whether to remove duplicates of the value in nonunique Variables.
    	*/
    	bool IsRemoveDuplicates;
    	/*
    	An InputPin that provides the position of an existing value to remove in ordered, nonunique Variables. The type of the removeAt InputPin is UnlimitedNatural, but the value cannot be zero or unlimited.
    	*/
    	InputPin RemoveAt subsets Action.Input;
    }

    /*
    A ReplyAction is an Action that accepts a set of reply values and a value containing return information produced by a previous AcceptCallAction. The ReplyAction returns the values to the caller of the previous call, completing execution of the call.
    */
    class ReplyAction : Action
    {
    	/*
    	The Trigger specifying the Operation whose call is being replied to.
    	*/
    	Trigger ReplyToCall;
    	/*
    	A list of InputPins providing the values for the output (inout, out, and return) Parameters of the Operation. These values are returned to the caller.
    	*/
    	list<InputPin> ReplyValue subsets Action.Input;
    	/*
    	An InputPin that holds the return information value produced by an earlier AcceptCallAction.
    	*/
    	InputPin ReturnInformation subsets Action.Input;
    }

    /*
    A SendObjectAction is an InvocationAction that transmits an input object to the target object, which is handled as a request message by the target object. The requestor continues execution immediately after the object is sent out and cannot receive reply values.
    */
    class SendObjectAction : InvocationAction
    {
    	/*
    	The request object, which is transmitted to the target object. The object may be copied in transmission, so identity might not be preserved.
    	*/
    	InputPin Request redefines InvocationAction.Argument;
    	/*
    	The target object to which the object is sent.
    	*/
    	InputPin Target subsets Action.Input;
    }

    /*
    A SendSignalAction is an InvocationAction that creates a Signal instance and transmits it to the target object. Values from the argument InputPins are used to provide values for the attributes of the Signal. The requestor continues execution immediately after the Signal instance is sent out and cannot receive reply values.
    */
    class SendSignalAction : InvocationAction
    {
    	/*
    	The Signal whose instance is transmitted to the target.
    	*/
    	Signal Signal;
    	/*
    	The InputPin that provides the target object to which the Signal instance is sent.
    	*/
    	InputPin Target subsets Action.Input;
    }

    /*
    A SequenceNode is a StructuredActivityNode that executes a sequence of ExecutableNodes in order.
    */
    class SequenceNode : StructuredActivityNode
    {
    	/*
    	The ordered set of ExecutableNodes to be sequenced.
    	*/
    	list<ExecutableNode> ExecutableNode redefines StructuredActivityNode.Node;
    }

    /*
    A StartClassifierBehaviorAction is an Action that starts the classifierBehavior of the input object.
    */
    class StartClassifierBehaviorAction : Action
    {
    	/*
    	The InputPin that holds the object whose classifierBehavior is to be started.
    	*/
    	InputPin Object subsets Action.Input;
    }

    /*
    A StartObjectBehaviorAction is an InvocationAction that starts the execution either of a directly instantiated Behavior or of the classifierBehavior of an object. Argument values may be supplied for the input Parameters of the Behavior. If the Behavior is invoked synchronously, then output values may be obtained for output Parameters.
    */
    class StartObjectBehaviorAction : CallAction
    {
    	/*
    	An InputPin that holds the object that is either a Behavior to be started or has a classifierBehavior to be started.
    	*/
    	InputPin Object subsets Action.Input;
    	/*
    	Return the inout, out and return ownedParameters of the Behavior being called.
    	
    	spec:
    	    result = (self.behavior().outputParameters())
    	*/
    	list<Parameter> OutputParameters();
    	/*
    	Return the in and inout ownedParameters of the Behavior being called.
    	
    	spec:
    	    result = (self.behavior().inputParameters())
    	*/
    	list<Parameter> InputParameters();
    	/*
    	If the type of the object InputPin is a Behavior, then that Behavior. Otherwise, if the type of the object InputPin is a BehavioredClassifier, then the classifierBehavior of that BehavioredClassifier.
    	
    	spec:
    	    result = (if object.type.oclIsKindOf(Behavior) then
    	      object.type.oclAsType(Behavior)
    	    else if object.type.oclIsKindOf(BehavioredClassifier) then
    	      object.type.oclAsType(BehavioredClassifier).classifierBehavior
    	    else
    	      null
    	    endif
    	    endif)
    	*/
    	Behavior Behavior();
    }

    /*
    StructuralFeatureAction is an abstract class for all Actions that operate on StructuralFeatures.
    */
    abstract class StructuralFeatureAction : Action
    {
    	/*
    	The InputPin from which the object whose StructuralFeature is to be read or written is obtained.
    	*/
    	InputPin Object subsets Action.Input;
    	/*
    	The StructuralFeature to be read or written.
    	*/
    	StructuralFeature StructuralFeature;
    }

    /*
    A StructuredActivityNode is an Action that is also an ActivityGroup and whose behavior is specified by the ActivityNodes and ActivityEdges it so contains. Unlike other kinds of ActivityGroup, a StructuredActivityNode owns the ActivityNodes and ActivityEdges it contains, and so a node or edge can only be directly contained in one StructuredActivityNode, though StructuredActivityNodes may be nested.
    */
    class StructuredActivityNode : Namespace, ActivityGroup, Action
    {
    	/*
    	The Activity immediately containing the StructuredActivityNode, if it is not contained in another StructuredActivityNode.
    	*/
    	Activity Activity redefines ActivityGroup.InActivity, ActivityNode.Activity;
    	/*
    	The ActivityEdges immediately contained in the StructuredActivityNode.
    	*/
    	set<ActivityEdge> Edge subsets ActivityGroup.ContainedEdge, Element.OwnedElement;
    	/*
    	If true, then any object used by an Action within the StructuredActivityNode cannot be accessed by any Action outside the node until the StructuredActivityNode as a whole completes. Any concurrent Actions that would result in accessing such objects are required to have their execution deferred until the completion of the StructuredActivityNode.
    	*/
    	bool MustIsolate;
    	/*
    	The ActivityNodes immediately contained in the StructuredActivityNode.
    	*/
    	set<ActivityNode> Node subsets ActivityGroup.ContainedNode, Element.OwnedElement;
    	/*
    	The InputPins owned by the StructuredActivityNode.
    	*/
    	set<InputPin> StructuredNodeInput subsets Action.Input;
    	/*
    	The OutputPins owned by the StructuredActivityNode.
    	*/
    	set<OutputPin> StructuredNodeOutput subsets Action.Output;
    	/*
    	The Variables defined in the scope of the StructuredActivityNode.
    	*/
    	set<Variable> Variable subsets Namespace.OwnedMember;
    	/*
    	Returns this StructuredActivityNode and all Actions contained in it.
    	
    	spec:
    	    result = (node->select(oclIsKindOf(Action)).oclAsType(Action).allActions()->including(self)->asSet())
    	*/
    	set<Action> AllActions();
    	/*
    	Returns all the ActivityNodes contained directly or indirectly within this StructuredActivityNode, in addition to the Pins of the StructuredActivityNode.
    	
    	spec:
    	    result = (self.Action::allOwnedNodes()->union(node)->union(node->select(oclIsKindOf(Action)).oclAsType(Action).allOwnedNodes())->asSet())
    	*/
    	set<ActivityNode> AllOwnedNodes();
    	/*
    	Return those ActivityNodes contained immediately within the StructuredActivityNode that may act as sources of edges owned by the StructuredActivityNode.
    	
    	spec:
    	    result = (node->union(input.oclAsType(ActivityNode)->asSet())->
    	      union(node->select(oclIsKindOf(Action)).oclAsType(Action).output)->asSet())
    	*/
    	set<ActivityNode> SourceNodes();
    	/*
    	Return those ActivityNodes contained immediately within the StructuredActivityNode that may act as targets of edges owned by the StructuredActivityNode.
    	
    	spec:
    	    result = (node->union(output.oclAsType(ActivityNode)->asSet())->
    	      union(node->select(oclIsKindOf(Action)).oclAsType(Action).input)->asSet())
    	*/
    	set<ActivityNode> TargetNodes();
    	/*
    	The Activity that directly or indirectly contains this StructuredActivityNode (considered as an Action).
    	
    	spec:
    	    result = (self.Action::containingActivity())
    	*/
    	Activity ContainingActivity();
    }

    /*
    A TestIdentityAction is an Action that tests if two values are identical objects.
    */
    class TestIdentityAction : Action
    {
    	/*
    	The InputPin on which the first input object is placed.
    	*/
    	InputPin First subsets Action.Input;
    	/*
    	The OutputPin whose Boolean value indicates whether the two input objects are identical.
    	*/
    	OutputPin Result subsets Action.Output;
    	/*
    	The OutputPin on which the second input object is placed.
    	*/
    	InputPin Second subsets Action.Input;
    }

    /*
    An UnmarshallAction is an Action that retrieves the values of the StructuralFeatures of an object and places them on OutputPins. 
    */
    class UnmarshallAction : Action
    {
    	/*
    	The InputPin that gives the object to be unmarshalled.
    	*/
    	InputPin Object subsets Action.Input;
    	/*
    	The OutputPins on which are placed the values of the StructuralFeatures of the input object.
    	*/
    	list<OutputPin> Result subsets Action.Output;
    	/*
    	The type of the object to be unmarshalled.
    	*/
    	Classifier UnmarshallType;
    }

    /*
    A ValuePin is an InputPin that provides a value by evaluating a ValueSpecification.
    */
    class ValuePin : InputPin
    {
    	/*
    	The ValueSpecification that is evaluated to obtain the value that the ValuePin will provide.
    	*/
    	ValueSpecification Value subsets Element.OwnedElement;
    }

    association ActivityEdge.Interrupts with InterruptibleActivityRegion.InterruptingEdge;
    association ExceptionHandler.ProtectedNode with ExecutableNode.Handler;
    association ActivityPartition.Subpartition with ActivityPartition.SuperPartition;
    association ActivityEdge.InPartition with ActivityPartition.Edge;
    association ActivityNode.InInterruptibleRegion with InterruptibleActivityRegion.Node;
    association ActivityNode.InPartition with ActivityPartition.Node;
    association ActivityEdge.Target with ActivityNode.Incoming;
    association ActivityEdge.Source with ActivityNode.Outgoing;
    association ActivityEdge.InGroup with ActivityGroup.ContainedEdge;
    association ActivityGroup.ContainedNode with ActivityNode.InGroup;
    association ActivityGroup.Subgroup with ActivityGroup.SuperGroup;
    association Activity.StructuredNode with StructuredActivityNode.Activity;
    association Activity.Group with ActivityGroup.InActivity;
    association Activity.Node with ActivityNode.Activity;
    association Activity.Variable with Variable.ActivityScope;
    association Activity.Edge with ActivityEdge.Activity;
    association StringExpression.OwningExpression with StringExpression.SubExpression;
    association ExtensionPoint.UseCase with UseCase.ExtensionPoint;
    association Include.IncludingCase with UseCase.Include;
    association UseCase.Subject with Classifier.UseCase;
    association Extend.Extension with UseCase.Extend;
    association ConnectableElement.TemplateParameter with ConnectableElementTemplateParameter.ParameteredElement;
    association ConnectableElement.End with ConnectorEnd.Role;
    association Component.Realization with ComponentRealization.Abstraction;
    association Class.OwnedOperation with Operation.Class;
    association Class.Extension with Extension.Metaclass;
    association Class.OwnedAttribute with Property.Class;
    association Association.MemberEnd with Property.Association;
    association Association.OwnedEnd with Property.OwningAssociation;
    association Transition.Target with Vertex.Incoming;
    association Transition.Source with Vertex.Outgoing;
    association State.Submachine with StateMachine.SubmachineState;
    association Pseudostate.StateMachine with StateMachine.ConnectionPoint;
    association Region.StateMachine with StateMachine.Region;
    association Region.State with State.Region;
    association ConnectionPointReference.State with State.Connection;
    association Pseudostate.State with State.ConnectionPoint;
    association Region.Subvertex with Vertex.Container;
    association Region.Transition with Transition.Container;
    association ProtocolConformance.SpecificMachine with ProtocolStateMachine.Conformance;
    association Interface.OwnedOperation with Operation.Interface;
    association Interface.OwnedAttribute with Property.Interface;
    association Enumeration.OwnedLiteral with EnumerationLiteral.Enumeration;
    association DataType.OwnedAttribute with Property.Datatype;
    association DataType.OwnedOperation with Operation.Datatype;
    association BehavioredClassifier.InterfaceRealization with InterfaceRealization.ImplementingClassifier;
    association Package.PackageMerge with PackageMerge.ReceivingPackage;
    association Package.NestedPackage with Package.NestingPackage;
    association Package.ProfileApplication with ProfileApplication.ApplyingPackage;
    association Package.OwnedType with Type.Package;
    association GeneralOrdering.After with OccurrenceSpecification.ToBefore;
    association InteractionFragment.EnclosingOperand with InteractionOperand.Fragment;
    /*
    This association shows the lifelines that make up an interaction. A lifeline may be part of more than one interaction use.
    */
    association InteractionFragment.Covered with Lifeline.CoveredBy;
    association Interaction.Lifeline with Lifeline.Interaction;
    association Interaction.Fragment with InteractionFragment.EnclosingInteraction;
    association Interaction.Message with Message.Interaction;
    association GeneralOrdering.Before with OccurrenceSpecification.ToAfter;
    association Deployment.Location with DeploymentTarget.Deployment;
    association Deployment.Configuration with DeploymentSpecification.Deployment;
    association TemplateParameter.Signature with TemplateSignature.OwnedParameter;
    association ParameterableElement.OwningTemplateParameter with TemplateParameter.OwnedParameteredElement;
    association ParameterableElement.TemplateParameter with TemplateParameter.ParameteredElement;
    association TemplateBinding.ParameterSubstitution with TemplateParameterSubstitution.TemplateBinding;
    association TemplateableElement.TemplateBinding with TemplateBinding.BoundElement;
    association TemplateableElement.OwnedTemplateSignature with TemplateSignature.Template;
    association ElementImport.ImportingNamespace with Namespace.ElementImport;
    association NamedElement.Namespace with Namespace.OwnedMember;
    association Constraint.Context with Namespace.OwnedRule;
    association Namespace.PackageImport with PackageImport.ImportingNamespace;
    association Dependency.Client with NamedElement.ClientDependency;
    association Element.OwnedElement with Element.Owner;
    association Property.AssociationEnd with Property.Qualifier;
    association Parameter.ParameterSet with ParameterSet.Parameter;
    association Operation.TemplateParameter with OperationTemplateParameter.ParameteredElement;
    association Operation.OwnedParameter with Parameter.Operation;
    association InstanceSpecification.Slot with Slot.OwningInstance;
    association Generalization.GeneralizationSet with GeneralizationSet.Generalization;
    association Classifier.TemplateParameter with ClassifierTemplateParameter.ParameteredElement;
    association Classifier.PowertypeExtent with GeneralizationSet.Powertype;
    association Classifier.Generalization with Generalization.Specific;
    association Classifier.Feature with Feature.FeaturingClassifier;
    association Substitution.SubstitutingClassifier with Classifier.Substitution;
    association Classifier.OwnedTemplateSignature with RedefinableTemplateSignature.Classifier;
    association Behavior.Specification with BehavioralFeature.Method;
    association ActivityEdge.InStructuredNode with StructuredActivityNode.Edge;
    association ActivityNode.InStructuredNode with StructuredActivityNode.Node;
    association Variable.Scope with StructuredActivityNode.Variable;
    association ExpansionNode.RegionAsInput with ExpansionRegion.InputElement;
    association ExpansionNode.RegionAsOutput with ExpansionRegion.OutputElement;
    association Clause.PredecessorClause with Clause.SuccessorClause;
}

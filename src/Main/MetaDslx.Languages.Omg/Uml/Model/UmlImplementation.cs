using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MetaDslx.Modeling;

namespace MetaDslx.Languages.Uml.Model.Internal
{
    internal static class IEnumerableExtensions
    {
        public static HashSet<T> ToSet<T>(this IEnumerable<T> items)
        {
            return new HashSet<T>(items);
        }
    }

    class UmlImplementation : UmlImplementationBase
    {
        internal override void UmlBuilderInstance(UmlBuilderInstance _this)
        {
            UmlFactory f = new UmlFactory(_this.MModel);
            _this.Boolean = f.PrimitiveType();
            _this.Boolean.Name = "Boolean";
            _this.String = f.PrimitiveType();
            _this.String.Name = "String";
            _this.Integer = f.PrimitiveType();
            _this.Integer.Name = "Integer";
            _this.Real = f.PrimitiveType();
            _this.Real.Name = "Real";
            _this.UnlimitedNatural = f.PrimitiveType();
            _this.UnlimitedNatural.Name = "UnlimitedNatural";
        }

        // Return this Action and all Actions contained directly or indirectly in it. By default only the Action itself is returned, but the operation is overridden for StructuredActivityNodes.
        // spec:
        //     result = (self->asSet())
        public override IReadOnlyCollection<ActionBuilder> Action_AllActions(ActionBuilder _this)
        {
            return ImmutableArray.Create(_this);
        }

        // Returns all the ActivityNodes directly or indirectly owned by this Action. This includes at least all the Pins of the Action.
        // spec:
        //     result = (input.oclAsType(Pin)->asSet()->union(output->asSet()))
        public override IReadOnlyCollection<ActivityNodeBuilder> Action_AllOwnedNodes(ActionBuilder _this)
        {
            var result = _this.Input.OfType<PinBuilder>().ToSet();
            result.UnionWith(_this.Output);
            return result;
        }

        // The context Classifier of the Behavior that contains this Action, or the Behavior itself if it has no context.
        // spec:
        //     result = (let behavior: Behavior = self.containingBehavior() in
        //     if behavior=null then null
        //     else if behavior._'context' = null then behavior
        //     else behavior._'context'
        //     endif
        //     endif)
        public override ClassifierBuilder Action_ComputeProperty_Context(ActionBuilder _this)
        {
            var behavior = _this.ContainingBehavior();
            return behavior?.Context ?? behavior;
        }

        // spec:
        //     result = (if inStructuredNode<>null then inStructuredNode.containingBehavior() 
        //     else if activity<>null then activity
        //     else interaction 
        //     endif
        //     endif
        //     )
        public override BehaviorBuilder Action_ContainingBehavior(ActionBuilder _this)
        {
            if (_this.InStructuredNode != null) return _this.InStructuredNode.ContainingBehavior();
            else if (_this.Activity != null) return _this.Activity;
            else return _this.Interaction;
        }

        // spec:
        //     result = (redefiningElement.oclIsKindOf(ActivityEdge))
        public override bool ActivityEdge_IsConsistentWith(ActivityEdgeBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            return redefiningElement is ActivityEdgeBuilder;
        }

        // The Activity that directly or indirectly contains this ActivityGroup.
        // spec:
        //     result = (if superGroup<>null then superGroup.containingActivity()
        //     else inActivity
        //     endif)
        public override ActivityBuilder ActivityGroup_ContainingActivity(ActivityGroupBuilder _this)
        {
            if (_this.SuperGroup != null) return _this.SuperGroup.ContainingActivity();
            else return _this.InActivity;
        }

        // The Activity that directly or indirectly contains this ActivityNode.
        // spec:
        //     result = (if inStructuredNode<>null then inStructuredNode.containingActivity()
        //     else activity
        //     endif)
        public override ActivityBuilder ActivityNode_ContainingActivity(ActivityNodeBuilder _this)
        {
            if (_this.InStructuredNode != null) return _this.InStructuredNode.ContainingActivity();
            else return _this.Activity;
        }

        // spec:
        //     result = (redefiningElement.oclIsKindOf(ActivityNode))
        public override bool ActivityNode_IsConsistentWith(ActivityNodeBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            return redefiningElement is ActivityNodeBuilder;
        }

        // The Classifiers that are used as types of the ends of the Association.
        // spec:
        //     result = (memberEnd->collect(type)->asSet())
        public override IReadOnlyCollection<TypeBuilder> Association_ComputeProperty_EndType(AssociationBuilder _this)
        {
            return _this.MemberEnd.Select(me => me.Type).ToSet();
        }

        // The ownedParameters with direction in and inout.
        // spec:
        //     result = (ownedParameter->select(direction=ParameterDirectionKind::_'in' or direction=ParameterDirectionKind::inout))
        public override IReadOnlyList<ParameterBuilder> BehavioralFeature_InputParameters(BehavioralFeatureBuilder _this)
        {
            return _this.OwnedParameter.Where(p => p.Direction == ParameterDirectionKind.In || p.Direction == ParameterDirectionKind.Inout).ToList();
        }

        // The query isDistinguishableFrom() determines whether two BehavioralFeatures may coexist in the same Namespace. It specifies that they must have different signatures.
        // spec:
        //     result = ((n.oclIsKindOf(BehavioralFeature) and ns.getNamesOfMember(self)->intersection(ns.getNamesOfMember(n))->notEmpty()) implies
        //       Set{self}->including(n.oclAsType(BehavioralFeature))->isUnique(ownedParameter->collect(p|
        //       Tuple { name=p.name, type=p.type,effect=p.effect,direction=p.direction,isException=p.isException,
        //                   isStream=p.isStream,isOrdered=p.isOrdered,isUnique=p.isUnique,lower=p.lower, upper=p.upper }))
        //       )
        public override bool BehavioralFeature_IsDistinguishableFrom(BehavioralFeatureBuilder _this, NamedElementBuilder n, NamespaceBuilder ns)
        {
            if (n is BehavioralFeatureBuilder nBehavior && ns.GetNamesOfMember(_this).Any(m => ns.GetNamesOfMember(n).Contains(m)))
            {
                if (_this.OwnedParameter.Count != nBehavior.OwnedParameter.Count) return true;
                for (int i = 0; i < _this.OwnedParameter.Count; i++)
                {
                    var thisParam = _this.OwnedParameter[i];
                    var otherParam = nBehavior.OwnedParameter[i];
                    if (thisParam.Name != otherParam.Name) return true;
                    if (thisParam.Type != otherParam.Type) return true;
                    if (thisParam.Effect != otherParam.Effect) return true;
                    if (thisParam.Direction != otherParam.Direction) return true;
                    if (thisParam.IsException != otherParam.IsException) return true;
                    if (thisParam.IsStream != otherParam.IsStream) return true;
                    if (thisParam.IsOrdered != otherParam.IsOrdered) return true;
                    if (thisParam.IsUnique != otherParam.IsUnique) return true;
                    if (thisParam.Lower != otherParam.Lower) return true;
                    if (thisParam.Upper != otherParam.Upper) return true;
                }
                return false;
            }
            return true;
        }

        // The ownedParameters with direction out, inout, or return.
        // spec:
        //     result = (ownedParameter->select(direction=ParameterDirectionKind::out or direction=ParameterDirectionKind::inout or direction=ParameterDirectionKind::return))
        public override IReadOnlyList<ParameterBuilder> BehavioralFeature_OutputParameters(BehavioralFeatureBuilder _this)
        {
            return _this.OwnedParameter.Where(p => p.Direction == ParameterDirectionKind.Out || p.Direction == ParameterDirectionKind.Inout || p.Direction == ParameterDirectionKind.Return).ToList();
        }

        // The first BehavioredClassifier reached by following the chain of owner relationships from the Behavior, if any.
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
        public override BehavioredClassifierBuilder Behavior_BehavioredClassifier(BehaviorBuilder _this, ElementBuilder from)
        {
            if (from is BehavioredClassifierBuilder behavioredClassifier) return behavioredClassifier;
            else if (from.Owner == null) return null;
            else return _this.BehavioredClassifier(from.Owner);
        }

        // The BehavioredClassifier that is the context for the execution of the Behavior. A Behavior that is directly owned as a nestedClassifier does not have a context. Otherwise, to determine the context of a Behavior, find the first BehavioredClassifier reached by following the chain of owner relationships from the Behavior, if any. If there is such a BehavioredClassifier, then it is the context, unless it is itself a Behavior with a non-empty context, in which case that is also the context for the original Behavior. For example, following this algorithm, the context of an entry Behavior in a StateMachine is the BehavioredClassifier that owns the StateMachine. The features of the context BehavioredClassifier as well as the Elements visible to the context Classifier are visible to the Behavior.
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
        public override BehavioredClassifierBuilder Behavior_ComputeProperty_Context(BehaviorBuilder _this)
        {
            if (_this.NestingClass != null) return null; 
            var b = _this.BehavioredClassifier(_this.Owner);
            if (b is BehaviorBuilder behavior && behavior.Context != null) return behavior.Context;
            else return b;
        }

        // The in and inout ownedParameters of the Behavior.
        // spec:
        //     result = (ownedParameter->select(direction=ParameterDirectionKind::_'in' or direction=ParameterDirectionKind::inout))
        public override IReadOnlyList<ParameterBuilder> Behavior_InputParameters(BehaviorBuilder _this)
        {
            return _this.OwnedParameter.Where(p => p.Direction == ParameterDirectionKind.In || p.Direction == ParameterDirectionKind.Inout).ToList();
        }

        // The out, inout and return ownedParameters.
        // spec:
        //     result = (ownedParameter->select(direction=ParameterDirectionKind::out or direction=ParameterDirectionKind::inout or direction=ParameterDirectionKind::return))
        public override IReadOnlyList<ParameterBuilder> Behavior_OutputParameters(BehaviorBuilder _this)
        {
            return _this.OwnedParameter.Where(p => p.Direction == ParameterDirectionKind.Out || p.Direction == ParameterDirectionKind.Inout || p.Direction == ParameterDirectionKind.Return).ToList();
        }

        // Return the in and inout ownedParameters of the Behavior or Operation being called. (This operation is abstract and should be overridden by subclasses of CallAction.)
        public override IReadOnlyList<ParameterBuilder> CallAction_InputParameters(CallActionBuilder _this)
        {
            Debug.Assert(false, "abstract method");
            return ImmutableArray<ParameterBuilder>.Empty;
        }

        // Return the inout, out and return ownedParameters of the Behavior or Operation being called. (This operation is abstract and should be overridden by subclasses of CallAction.)
        public override IReadOnlyList<ParameterBuilder> CallAction_OutputParameters(CallActionBuilder _this)
        {
            Debug.Assert(false, "abstract method");
            return ImmutableArray<ParameterBuilder>.Empty;
        }

        // Return the in and inout ownedParameters of the Behavior being called.
        // spec:
        //     result = (behavior.inputParameters())
        public override IReadOnlyList<ParameterBuilder> CallBehaviorAction_InputParameters(CallBehaviorActionBuilder _this)
        {
            return _this.Behavior.InputParameters();
        }

        // Return the inout, out and return ownedParameters of the Behavior being called.
        // spec:
        //     result = (behavior.outputParameters())
        public override IReadOnlyList<ParameterBuilder> CallBehaviorAction_OutputParameters(CallBehaviorActionBuilder _this)
        {
            return _this.Behavior.OutputParameters();
        }

        // Return the in and inout ownedParameters of the Operation being called.
        // spec:
        //     result = (operation.inputParameters())
        public override IReadOnlyList<ParameterBuilder> CallOperationAction_InputParameters(CallOperationActionBuilder _this)
        {
            return _this.Operation.InputParameters();
        }

        // Return the inout, out and return ownedParameters of the Operation being called.
        // spec:
        //     result = (operation.outputParameters())
        public override IReadOnlyList<ParameterBuilder> CallOperationAction_OutputParameters(CallOperationActionBuilder _this)
        {
            return _this.Operation.OutputParameters();
        }

        // The query allAttributes gives an ordered set of all owned and inherited attributes of the Classifier. All owned attributes appear before any inherited attributes, and the attributes inherited from any more specific parent Classifier appear before those of any more general parent Classifier. However, if the Classifier has multiple immediate parents, then the relative ordering of the sets of attributes from those parents is not defined.
        // spec:
        //     result = (attribute->asSequence()->union(parents()->asSequence().allAttributes())->select(p | member->includes(p))->asOrderedSet())
        public override IReadOnlyList<PropertyBuilder> Classifier_AllAttributes(ClassifierBuilder _this)
        {
            var result = new List<PropertyBuilder>(_this.Attribute);
            foreach (var parent in _this.Parents())
            {
                foreach (var attr in parent.AllAttributes())
                {
                    if (!result.Contains(attr)) result.Add(attr);
                }
            }
            return result.Where(p => _this.Member.Contains(p)).ToList();
        }

        // The query allFeatures() gives all of the Features in the namespace of the Classifier. In general, through mechanisms such as inheritance, this will be a larger set than feature.
        // spec:
        //     result = (member->select(oclIsKindOf(Feature))->collect(oclAsType(Feature))->asSet())
        public override IReadOnlyCollection<FeatureBuilder> Classifier_AllFeatures(ClassifierBuilder _this)
        {
            return _this.Member.OfType<FeatureBuilder>().ToSet();
        }

        // The query allParents() gives all of the direct and indirect ancestors of a generalized Classifier.
        // spec:
        //     result = (parents()->union(parents()->collect(allParents())->asSet()))
        public override IReadOnlyCollection<ClassifierBuilder> Classifier_AllParents(ClassifierBuilder _this)
        {
            var parents = _this.Parents();
            var result = new HashSet<ClassifierBuilder>(parents);
            foreach (var p in parents)
            {
                result.UnionWith(p.AllParents());
            }
            return result;
        }

        // The Interfaces realized by this Classifier and all of its generalizations
        // spec:
        //     result = (directlyRealizedInterfaces()->union(self.allParents()->collect(directlyRealizedInterfaces()))->asSet())
        public override IReadOnlyCollection<InterfaceBuilder> Classifier_AllRealizedInterfaces(ClassifierBuilder _this)
        {
            var result = new HashSet<InterfaceBuilder>(_this.DirectlyRealizedInterfaces());
            foreach (var p in _this.AllParents())
            {
                result.UnionWith(p.DirectlyRealizedInterfaces());
            }
            return result;
        }

        // All StructuralFeatures related to the Classifier that may have Slots, including direct attributes, inherited attributes, private attributes in generalizations, and memberEnds of Associations, but excluding redefined StructuralFeatures.
        // spec:
        //     result = (member->select(oclIsKindOf(StructuralFeature))->
        //       collect(oclAsType(StructuralFeature))->
        //        union(self.inherit(self.allParents()->collect(p | p.attribute)->asSet())->
        //          collect(oclAsType(StructuralFeature)))->asSet())
        public override IReadOnlyCollection<StructuralFeatureBuilder> Classifier_AllSlottableFeatures(ClassifierBuilder _this)
        {
            var result = new HashSet<StructuralFeatureBuilder>(_this.Member.OfType<StructuralFeatureBuilder>());
            foreach (var parent in _this.AllParents())
            {
                result.UnionWith(parent.Attribute);
            }
            return result;
        }

        // The Interfaces used by this Classifier and all of its generalizations
        // spec:
        //     result = (directlyUsedInterfaces()->union(self.allParents()->collect(directlyUsedInterfaces()))->asSet())
        public override IReadOnlyCollection<InterfaceBuilder> Classifier_AllUsedInterfaces(ClassifierBuilder _this)
        {
            var result = new HashSet<InterfaceBuilder>(_this.DirectlyUsedInterfaces());
            foreach (var p in _this.AllParents())
            {
                result.UnionWith(p.DirectlyUsedInterfaces());
            }
            return result;
        }

        // The generalizing Classifiers for this Classifier.
        // spec:
        //     result = (parents())
        public override IReadOnlyCollection<ClassifierBuilder> Classifier_ComputeProperty_General(ClassifierBuilder _this)
        {
            return _this.Parents();
        }

        // All elements inherited by this Classifier from its general Classifiers.
        // spec:
        //     result = (inherit(parents()->collect(inheritableMembers(self))->asSet()))
        public override IReadOnlyCollection<NamedElementBuilder> Classifier_ComputeProperty_InheritedMember(ClassifierBuilder _this)
        {
            return _this.Inherit(_this.Parents().SelectMany(p => p.InheritableMembers(_this)).ToSet()).ToSet();
        }

        // The query conformsTo() gives true for a Classifier that defines a type that conforms to another. This is used, for example, in the specification of signature conformance for operations.
        // spec:
        //     result = (if other.oclIsKindOf(Classifier) then
        //       let otherClassifier : Classifier = other.oclAsType(Classifier) in
        //         self = otherClassifier or allParents()->includes(otherClassifier)
        //     else
        //       false
        //     endif)
        public override bool Classifier_ConformsTo(ClassifierBuilder _this, TypeBuilder other)
        {
            return other is ClassifierBuilder otherClassifier && (_this == otherClassifier || _this.AllParents().Contains(otherClassifier));
        }

        // The Interfaces directly realized by this Classifier
        // spec:
        //     result = ((clientDependency->
        //       select(oclIsKindOf(Realization) and supplier->forAll(oclIsKindOf(Interface))))->
        //           collect(supplier.oclAsType(Interface))->asSet())
        public override IReadOnlyCollection<InterfaceBuilder> Classifier_DirectlyRealizedInterfaces(ClassifierBuilder _this)
        {
            return _this.ClientDependency.Where(dep => dep is RealizationBuilder && dep.Supplier.All(sup => sup is InterfaceBuilder)).SelectMany(dep => dep.Supplier.OfType<InterfaceBuilder>()).ToSet();
        }

        // The Interfaces directly used by this Classifier
        // spec:
        //     result = ((supplierDependency->
        //       select(oclIsKindOf(Usage) and client->forAll(oclIsKindOf(Interface))))->
        //         collect(client.oclAsType(Interface))->asSet())
        public override IReadOnlyCollection<InterfaceBuilder> Classifier_DirectlyUsedInterfaces(ClassifierBuilder _this)
        {
            return _this.ClientDependency.Where(dep => dep is UsageBuilder && dep.Client.All(sup => sup is InterfaceBuilder)).SelectMany(dep => dep.Client.OfType<InterfaceBuilder>()).ToSet();
        }

        // The query hasVisibilityOf() determines whether a NamedElement is visible in the classifier. Non-private members are visible. It is only called when the argument is something owned by a parent.
        // pre:
        //     allParents()->including(self)->collect(member)->includes(n)
        // spec:
        //     result = (n.visibility <> VisibilityKind::private)
        public override bool Classifier_HasVisibilityOf(ClassifierBuilder _this, NamedElementBuilder n)
        {
            Debug.Assert(_this.Member.Contains(n) || _this.AllParents().Any(p => p.Member.Contains(n)));
            return n.Visibility != VisibilityKind.Private;
        }

        // The query inherit() defines how to inherit a set of elements passed as its argument.  It excludes redefined elements from the result.
        // spec:
        //     result = (inhs->reject(inh |
        //       inh.oclIsKindOf(RedefinableElement) and
        //       ownedMember->select(oclIsKindOf(RedefinableElement))->
        //         select(redefinedElement->includes(inh.oclAsType(RedefinableElement)))
        //            ->notEmpty()))
        public override IReadOnlyCollection<NamedElementBuilder> Classifier_Inherit(ClassifierBuilder _this, IReadOnlyCollection<NamedElementBuilder> inhs)
        {
            return inhs.Where(inh => !(inh is RedefinableElementBuilder re && !_this.OwnedMember.OfType<RedefinableElementBuilder>().Where(m => m.RedefinedElement.Contains(re)).Any())).ToSet();
        }

        // The query inheritableMembers() gives all of the members of a Classifier that may be inherited in one of its descendants, subject to whatever visibility restrictions apply.
        // pre:
        //     c.allParents()->includes(self)
        // spec:
        //     result = (member->select(m | c.hasVisibilityOf(m)))
        public override IReadOnlyCollection<NamedElementBuilder> Classifier_InheritableMembers(ClassifierBuilder _this, ClassifierBuilder c)
        {
            Debug.Assert(c.AllParents().Contains(_this));
            return _this.Member.Where(m => c.HasVisibilityOf(m)).ToSet();
        }

        // spec:
        //     result = (substitution.contract->includes(contract))
        public override bool Classifier_IsSubstitutableFor(ClassifierBuilder _this, ClassifierBuilder contract)
        {
            return _this.Substitution.Any(sub => sub.Contract == contract);
        }

        // The query isTemplate() returns whether this Classifier is actually a template.
        // spec:
        //     result = (ownedTemplateSignature <> null or general->exists(g | g.isTemplate()))
        public override bool Classifier_IsTemplate(ClassifierBuilder _this)
        {
            return _this.OwnedTemplateSignature != null || _this.General.Any(g => g.IsTemplate());
        }

        // The query maySpecializeType() determines whether this classifier may have a generalization relationship to classifiers of the specified type. By default a classifier may specialize classifiers of the same or a more general type. It is intended to be redefined by classifiers that have different specialization constraints.
        // spec:
        //     result = (self.oclIsKindOf(c.oclType()))
        public override bool Classifier_MaySpecializeType(ClassifierBuilder _this, ClassifierBuilder c)
        {
            return c.GetType().IsAssignableFrom(_this.GetType());
        }

        // The query parents() gives all of the immediate ancestors of a generalized Classifier.
        // spec:
        //     result = (generalization.general->asSet())
        public override IReadOnlyCollection<ClassifierBuilder> Classifier_Parents(ClassifierBuilder _this)
        {
            return _this.Generalization.Select(g => g.General).ToSet();
        }

        // This property is used when the Class is acting as a metaclass. It references the Extensions that specify additional properties of the metaclass. The property is derived from the Extensions whose memberEnds are typed by the Class.
        // spec:
        //     result = (Extension.allInstances()->select(ext | 
        //       let endTypes : Sequence(Classifier) = ext.memberEnd->collect(type.oclAsType(Classifier)) in
        //       endTypes->includes(self) or endTypes.allParents()->includes(self) ))
        public override IReadOnlyCollection<ExtensionBuilder> Class_ComputeProperty_Extension(ClassBuilder _this)
        {
            var result = new HashSet<ExtensionBuilder>();
            foreach (var ext in _this.MModel.Objects.OfType<ExtensionBuilder>())
            {
                var endTypes = ext.MemberEnd.Select(me => me.Type as ClassifierBuilder);
                if (endTypes.Contains(_this) || endTypes.Any(et => et.AllParents().Contains(_this)))
                {
                    result.Add(ext);
                }
            }
            return result;
        }

        // The superclasses of a Class, derived from its Generalizations.
        // spec:
        //     result = (self.general()->select(oclIsKindOf(Class))->collect(oclAsType(Class))->asSet())
        public override IReadOnlyCollection<ClassBuilder> Class_ComputeProperty_SuperClass(ClassBuilder _this)
        {
            return _this.General.Where(cls => cls is ClassBuilder).Cast<ClassBuilder>().ToSet();
        }

        // The Interfaces that the Component exposes to its environment. These Interfaces may be Realized by the Component or any of its realizingClassifiers, or they may be the Interfaces that are provided by its public Ports.
        // spec:
        //     result = (let 	ris : Set(Interface) = allRealizedInterfaces(),
        //             realizingClassifiers : Set(Classifier) =  self.realization.realizingClassifier->union(self.allParents()->collect(realization.realizingClassifier))->asSet(),
        //             allRealizingClassifiers : Set(Classifier) = realizingClassifiers->union(realizingClassifiers.allParents())->asSet(),
        //             realizingClassifierInterfaces : Set(Interface) = allRealizingClassifiers->iterate(c; rci : Set(Interface) = Set{} | rci->union(c.allRealizedInterfaces())),
        //             ports : Set(Port) = self.ownedPort->union(allParents()->collect(ownedPort))->asSet(),
        //             providedByPorts : Set(Interface) = ports.provided->asSet()
        //     in     ris->union(realizingClassifierInterfaces) ->union(providedByPorts)->asSet())
        public override IReadOnlyCollection<InterfaceBuilder> Component_ComputeProperty_Provided(ComponentBuilder _this)
        {
            var ris = _this.AllRealizedInterfaces();
            var realizingClassifiers = _this.Realization.SelectMany(r => r.RealizingClassifier).ToSet();
            realizingClassifiers.UnionWith(_this.AllParents().OfType<ComponentBuilder>().SelectMany(p => p.Realization.SelectMany(r => r.RealizingClassifier)));
            var allRealizingClassifiers = realizingClassifiers;
            allRealizingClassifiers.UnionWith(realizingClassifiers.SelectMany(rc => rc.AllParents()));
            var realizingClassifierInterfaces = allRealizingClassifiers.SelectMany(arc => arc.AllRealizedInterfaces());
            var ports = _this.AllParents().OfType<ComponentBuilder>().SelectMany(p => p.OwnedPort).ToSet();
            ports.UnionWith(_this.OwnedPort);
            var providedByPorts = ports.SelectMany(p => p.Provided);
            var result = ris.ToSet();
            result.UnionWith(realizingClassifierInterfaces);
            result.UnionWith(providedByPorts);
            return result;
        }

        // The Interfaces that the Component requires from other Components in its environment in order to be able to offer its full set of provided functionality. These Interfaces may be used by the Component or any of its realizingClassifiers, or they may be the Interfaces that are required by its public Ports.
        // spec:
        //     result = (let 	uis : Set(Interface) = allUsedInterfaces(),
        //             realizingClassifiers : Set(Classifier) = self.realization.realizingClassifier->union(self.allParents()->collect(realization.realizingClassifier))->asSet(),
        //             allRealizingClassifiers : Set(Classifier) = realizingClassifiers->union(realizingClassifiers.allParents())->asSet(),
        //             realizingClassifierInterfaces : Set(Interface) = allRealizingClassifiers->iterate(c; rci : Set(Interface) = Set{} | rci->union(c.allUsedInterfaces())),
        //             ports : Set(Port) = self.ownedPort->union(allParents()->collect(ownedPort))->asSet(),
        //             usedByPorts : Set(Interface) = ports.required->asSet()
        //     in	    uis->union(realizingClassifierInterfaces)->union(usedByPorts)->asSet()
        //     )
        public override IReadOnlyCollection<InterfaceBuilder> Component_ComputeProperty_Required(ComponentBuilder _this)
        {
            var uis = _this.AllUsedInterfaces();
            var realizingClassifiers = _this.Realization.SelectMany(r => r.RealizingClassifier).ToSet();
            realizingClassifiers.UnionWith(_this.AllParents().OfType<ComponentBuilder>().SelectMany(p => p.Realization.SelectMany(r => r.RealizingClassifier)));
            var allRealizingClassifiers = realizingClassifiers.ToSet();
            allRealizingClassifiers.UnionWith(realizingClassifiers.SelectMany(rc => rc.AllParents()));
            var realizingClassifierInterfaces = allRealizingClassifiers.SelectMany(arc => arc.AllUsedInterfaces()).ToSet();
            var ports = _this.AllParents().OfType<ComponentBuilder>().SelectMany(p => p.OwnedPort).ToSet();
            ports.UnionWith(_this.OwnedPort);
            var requiredByPorts = ports.SelectMany(p => p.Required);
            var result = new HashSet<InterfaceBuilder>(uis);
            result.UnionWith(realizingClassifierInterfaces);
            result.UnionWith(requiredByPorts);
            return result;
        }

        // Return only this ConditionalNode. This prevents Actions within the ConditionalNode from having their OutputPins used as bodyOutputs or decider Pins in containing LoopNodes or ConditionalNodes.
        // spec:
        //     result = (self->asSet())
        public override IReadOnlyCollection<ActionBuilder> ConditionalNode_AllActions(ConditionalNodeBuilder _this)
        {
            return ImmutableArray.Create(_this);
        }

        // A set of ConnectorEnds that attach to this ConnectableElement.
        // spec:
        //     result = (ConnectorEnd.allInstances()->select(role = self))
        public override IReadOnlyCollection<ConnectorEndBuilder> ConnectableElement_ComputeProperty_End(ConnectableElementBuilder _this)
        {
            return _this.MModel.Objects.OfType<ConnectorEndBuilder>().Where(ce => ce.Role == _this).ToSet();
        }

        // The query isConsistentWith() specifies a ConnectionPointReference can only be redefined by a ConnectionPointReference.
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        // spec:
        //     result = redefiningElement.oclIsKindOf(ConnectionPointReference)
        public override bool ConnectionPointReference_IsConsistentWith(ConnectionPointReferenceBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            return redefiningElement is ConnectionPointReferenceBuilder;
        }

        // A derived property referencing the corresponding end on the Association which types the Connector owing this ConnectorEnd, if any. It is derived by selecting the end at the same place in the ordering of Association ends as this ConnectorEnd.
        // spec:
        //     result = (if connector.type = null 
        //     then
        //       null 
        //     else
        //       let index : Integer = connector.end->indexOf(self) in
        //         connector.type.memberEnd->at(index)
        //     endif)
        public override PropertyBuilder ConnectorEnd_ComputeProperty_DefiningEnd(ConnectorEndBuilder _this)
        {
            if (_this.Connector.Type == null) return null;
            int index = _this.Connector.End.IndexOf(_this);
            return _this.Connector.Type.MemberEnd[index];
        }

        // Indicates the kind of Connector. This is derived: a Connector with one or more ends connected to a Port which is not on a Part and which is not a behavior port is a delegation; otherwise it is an assembly.
        // spec:
        //     result = (if end->exists(
        //     		role.oclIsKindOf(Port) 
        //     		and partWithPort->isEmpty()
        //     		and not role.oclAsType(Port).isBehavior)
        //     then ConnectorKind::delegation 
        //     else ConnectorKind::assembly 
        //     endif)
        public override ConnectorKind Connector_ComputeProperty_Kind(ConnectorBuilder _this)
        {
            if (_this.End.Any(e => e.Role is PortBuilder && e.PartWithPort == null && !((PortBuilder)e.Role).IsBehavior)) return ConnectorKind.Delegation;
            else return ConnectorKind.Assembly;
        }

        // The set of elements that are manifested in an Artifact that is involved in Deployment to a DeploymentTarget.
        // spec:
        //     result = (deployment.deployedArtifact->select(oclIsKindOf(Artifact))->collect(oclAsType(Artifact).manifestation)->collect(utilizedElement)->asSet())
        public override IReadOnlyCollection<PackageableElementBuilder> DeploymentTarget_ComputeProperty_DeployedElement(DeploymentTargetBuilder _this)
        {
            return _this.Deployment.SelectMany(d => d.DeployedArtifact).OfType<ArtifactBuilder>().SelectMany(a => a.Manifestation).Select(m => m.UtilizedElement).ToSet();
        }

        // The query getName() returns the name under which the imported PackageableElement will be known in the importing namespace.
        // spec:
        //     result = (if alias->notEmpty() then
        //       alias
        //     else
        //       importedElement.name
        //     endif)
        public override string ElementImport_GetName(ElementImportBuilder _this)
        {
            return _this.Alias ?? _this.ImportedElement.Name;
        }

        // The query allOwnedElements() gives all of the direct and indirect ownedElements of an Element.
        // spec:
        //     result = (ownedElement->union(ownedElement->collect(e | e.allOwnedElements()))->asSet())
        public override IReadOnlyCollection<ElementBuilder> Element_AllOwnedElements(ElementBuilder _this)
        {
            var result = new HashSet<ElementBuilder>(_this.OwnedElement);
            foreach (var e in _this.OwnedElement)
            {
                result.UnionWith(e.AllOwnedElements());
            }
            return result;
        }

        // The query mustBeOwned() indicates whether Elements of this type must have an owner. Subclasses of Element that do not require an owner must override this operation.
        // spec:
        //     result = (true)
        public override bool Element_MustBeOwned(ElementBuilder _this)
        {
            return true;
        }

        // The Ports owned by the EncapsulatedClassifier.
        // spec:
        //     result = (ownedAttribute->select(oclIsKindOf(Port))->collect(oclAsType(Port))->asOrderedSet())
        public override IReadOnlyCollection<PortBuilder> EncapsulatedClassifier_ComputeProperty_OwnedPort(EncapsulatedClassifierBuilder _this)
        {
            return _this.OwnedAttribute.OfType<PortBuilder>().Distinct().ToList();
        }

        // The classifier of this EnumerationLiteral derived to be equal to its Enumeration.
        // spec:
        //     result = (enumeration)
        public override EnumerationBuilder EnumerationLiteral_ComputeProperty_Classifier(EnumerationLiteralBuilder _this)
        {
            return _this.Enumeration;
        }

        // This redefinition changes the default multiplicity of association ends, since model elements are usually extended by 0 or 1 instance of the extension stereotype.
        public override int ExtensionEnd_ComputeProperty_Lower(ExtensionEndBuilder _this)
        {
            return 0;
        }

        // The query lowerBound() returns the lower bound of the multiplicity as an Integer. This is a redefinition of the default lower bound, which normally, for MultiplicityElements, evaluates to 1 if empty.
        // spec:
        //     result = (if lowerValue=null then 0 else lowerValue.integerValue() endif)
        public override int ExtensionEnd_LowerBound(ExtensionEndBuilder _this)
        {
            return _this.LowerValue?.IntegerValue() ?? 0;
        }

        // Indicates whether an instance of the extending stereotype must be created when an instance of the extended class is created. The attribute value is derived from the value of the lower property of the ExtensionEnd referenced by Extension::ownedEnd; a lower value of 1 means that isRequired is true, but otherwise it is false. Since the default value of ExtensionEnd::lower is 0, the default value of isRequired is false.
        // spec:
        //     result = (ownedEnd.lowerBound() = 1)
        public override bool Extension_ComputeProperty_IsRequired(ExtensionBuilder _this)
        {
            return _this.OwnedEnd.LowerBound() == 1;
        }

        // References the Class that is extended through an Extension. The property is derived from the type of the memberEnd that is not the ownedEnd.
        // spec:
        //     result = (metaclassEnd().type.oclAsType(Class))
        public override ClassBuilder Extension_ComputeProperty_Metaclass(ExtensionBuilder _this)
        {
            return _this.MetaclassEnd().Type as ClassBuilder;
        }

        // The query metaclassEnd() returns the Property that is typed by a metaclass (as opposed to a stereotype).
        // spec:
        //     result = (memberEnd->reject(p | ownedEnd->includes(p.oclAsType(ExtensionEnd)))->any(true))
        public override PropertyBuilder Extension_MetaclassEnd(ExtensionBuilder _this)
        {
            var assoc = _this as AssociationBuilder;
            return _this.MemberEnd.Where(p => !assoc.OwnedEnd.Contains((ExtensionEndBuilder)p)).FirstOrDefault();
        }

        // The query isConsistentWith() specifies a FinalState can only be redefined by a FinalState.
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        // spec:
        //     result = redefiningElement.oclIsKindOf(FinalState)
        public override bool FinalState_IsConsistentWith(FinalStateBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            return redefiningElement is FinalStateBuilder;
        }

        // The hasAllDataTypeAttributes query tests whether the types of the attributes of the given DataType are all DataTypes, and similarly for all those DataTypes.
        // spec:
        //     result = (d.ownedAttribute->forAll(a |
        //         a.type.oclIsKindOf(DataType) and
        //           hasAllDataTypeAttributes(a.type.oclAsType(DataType))))
        public override bool FunctionBehavior_HasAllDataTypeAttributes(FunctionBehaviorBuilder _this, DataTypeBuilder d)
        {
            return d.OwnedAttribute.All(a => a.Type is DataTypeBuilder dataType && _this.HasAllDataTypeAttributes(dataType));
        }

        // This query returns the name of the gate, either the explicit name (.name) or the constructed name ('out_" or 'in_' concatenated in front of .message.name) if the explicit name is not present.
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
        public override string Gate_GetName(GateBuilder _this)
        {
            if (_this.Name != null) return _this.Name;
            else if (_this.IsActual() || _this.IsOutsideCF())
            {
                if (_this.IsSend()) return "out_" + _this.Message.Name;
                else return "in_" + _this.Message.Name;
            }
            else
            {
                if (_this.IsSend()) return "in_" + _this.Message.Name;
                else return "out_" + _this.Message.Name;
            }
        }

        // If the Gate is an inside Combined Fragment Gate, this operation returns the InteractionOperand that the opposite end of this Gate is included within.
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
        public override InteractionOperandBuilder Gate_GetOperand(GateBuilder _this)
        {
            if (_this.IsInsideCF())
            {
                var oppEnd = _this.OppositeEnd().First();
                if (oppEnd is MessageOccurrenceSpecificationBuilder oppMOS)
                {
                    return oppMOS.EnclosingOperand;
                }
                else
                {
                    var oppGate = oppEnd as GateBuilder;
                    return oppGate.CombinedFragment.EnclosingOperand;
                }
            }
            return null;
        }

        // This query returns true value if this Gate is an actualGate of an InteractionUse.
        // spec:
        //     result = (interactionUse->notEmpty())
        public override bool Gate_IsActual(GateBuilder _this)
        {
            return _this.InteractionUse != null;
        }

        // The query isDistinguishableFrom() specifies that two Gates may coexist in the same Namespace, without an explicit name property. The association end formalGate subsets ownedElement, and since the Gate name attribute
        // is optional, it is allowed to have two formal gates without an explicit name, but having derived names which are distinct.
        // spec:
        //     result = (true)
        public override bool Gate_IsDistinguishableFrom(GateBuilder _this, NamedElementBuilder n, NamespaceBuilder ns)
        {
            return true;
        }

        // This query returns true if this Gate is a formalGate of an Interaction.
        // <p>interaction-&gt;notEmpty()</p>
        // spec:
        //     result = (interaction->notEmpty())
        public override bool Gate_IsFormal(GateBuilder _this)
        {
            return _this.Interaction != null;
        }

        // This query returns true if this Gate is attached to the boundary of a CombinedFragment, and its other end (if present) is inside of an InteractionOperator of the same CombinedFragment.
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
        public override bool Gate_IsInsideCF(GateBuilder _this)
        {
            if (_this.OppositeEnd().Count == 0 || _this.CombinedFragment == null) return false;
            var oppEnd = _this.OppositeEnd().First();
            if (oppEnd is MessageOccurrenceSpecificationBuilder oppMOS)
            {
                return _this.CombinedFragment == oppMOS.EnclosingOperand.CombinedFragment;
            }
            else
            {
                var oppGate = oppEnd as GateBuilder;
                return _this.CombinedFragment == oppGate.CombinedFragment.EnclosingOperand.CombinedFragment;
            }
        }

        // This query returns true if this Gate is attached to the boundary of a CombinedFragment, and its other end (if present)  is outside of the same CombinedFragment.
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
        public override bool Gate_IsOutsideCF(GateBuilder _this)
        {
            if (_this.OppositeEnd().Count == 0 || _this.CombinedFragment == null) return false;
            var oppEnd = _this.OppositeEnd().First();
            if (oppEnd is MessageOccurrenceSpecificationBuilder oppMOS)
            {
                var thisInteraction = _this.CombinedFragment.EnclosingInteraction as InteractionFragmentBuilder;
                var thisOperand = _this.CombinedFragment.EnclosingOperand as InteractionFragmentBuilder;
                var oppInteraction = oppMOS.EnclosingInteraction as InteractionFragmentBuilder;
                var oppOperand = oppMOS.EnclosingOperand as InteractionFragmentBuilder;
                return (thisInteraction == oppInteraction && thisOperand == oppOperand) || (thisInteraction == oppOperand && thisOperand == oppInteraction);
            }
            else
            {
                var oppGate = oppEnd as GateBuilder;
                var thisInteraction = _this.CombinedFragment.EnclosingInteraction as InteractionFragmentBuilder;
                var thisOperand = _this.CombinedFragment.EnclosingOperand as InteractionFragmentBuilder;
                var oppInteraction = oppGate.CombinedFragment.EnclosingInteraction as InteractionFragmentBuilder;
                var oppOperand = oppGate.CombinedFragment.EnclosingOperand as InteractionFragmentBuilder;
                return (thisInteraction == oppInteraction && thisOperand == oppOperand) || (thisInteraction == oppOperand && thisOperand == oppInteraction);
            }
        }

        // This query returns true if the name of this Gate matches the name of the in parameter Gate, and the messages for the two Gates correspond. The Message for one Gate (say A) corresponds to the Message for another Gate (say B) if (A and B have the same name value) and (if A is a sendEvent then B is a receiveEvent) and (if A is a receiveEvent then B is a sendEvent) and (A and B have the same messageSort value) and (A and B have the same signature value).
        // spec:
        //     result = (self.getName() = gateToMatch.getName() and 
        //     self.message.messageSort = gateToMatch.message.messageSort and
        //     self.message.name = gateToMatch.message.name and
        //     self.message.sendEvent->includes(self) implies gateToMatch.message.receiveEvent->includes(gateToMatch)  and
        //     self.message.receiveEvent->includes(self) implies gateToMatch.message.sendEvent->includes(gateToMatch) and
        //     self.message.signature = gateToMatch.message.signature)
        public override bool Gate_Matches(GateBuilder _this, GateBuilder gateToMatch)
        {
            if (_this.GetName() != gateToMatch.GetName()) return false;
            var thisMessage = _this.Message;
            var gateMessage = gateToMatch.Message;
            if (thisMessage.MessageSort != gateMessage.MessageSort) return false;
            if (thisMessage.Name != gateMessage.Name) return false;
            if (thisMessage.SendEvent == _this && gateMessage.ReceiveEvent != gateToMatch) return false;
            if (thisMessage.ReceiveEvent == _this && gateMessage.SendEvent != gateToMatch) return false;
            if (thisMessage.Signature != gateMessage.Signature) return false;
            return true;
        }

        // Returns the Association acted on by this LinkAction.
        // spec:
        //     result = (endData->asSequence()->first().end.association)
        public override AssociationBuilder LinkAction_Association(LinkActionBuilder _this)
        {
            return _this.EndData.FirstOrDefault()?.End.Association;
        }

        // Adds the insertAt InputPin (if any) to the set of all Pins.
        // spec:
        //     result = (self.LinkEndData::allPins()->including(insertAt))
        public override IReadOnlyCollection<InputPinBuilder> LinkEndCreationData_AllPins(LinkEndCreationDataBuilder _this)
        {
            var result = this.LinkEndData_AllPins(_this).ToSet();
            result.Add(_this.InsertAt);
            return result;
        }

        // Returns all the InputPins referenced by this LinkEndData. By default this includes the value and qualifier InputPins, but subclasses may override the operation to add other InputPins.
        // spec:
        //     result = (value->asBag()->union(qualifier.value))
        public override IReadOnlyCollection<InputPinBuilder> LinkEndData_AllPins(LinkEndDataBuilder _this)
        {
            var result = _this.Qualifier.Select(q => q.Value).ToSet();
            result.Add(_this.Value);
            return result;
        }

        // Adds the destroyAt InputPin (if any) to the set of all Pins.
        // spec:
        //     result = (self.LinkEndData::allPins()->including(destroyAt))
        public override IReadOnlyCollection<InputPinBuilder> LinkEndDestructionData_AllPins(LinkEndDestructionDataBuilder _this)
        {
            var result = this.LinkEndData_AllPins(_this).ToSet();
            result.Add(_this.DestroyAt);
            return result;
        }

        // The query booleanValue() gives the value.
        // spec:
        //     result = (value)
        public override bool LiteralBoolean_BooleanValue(LiteralBooleanBuilder _this)
        {
            return _this.Value;
        }

        // The query isComputable() is redefined to be true.
        // spec:
        //     result = (true)
        public override bool LiteralBoolean_IsComputable(LiteralBooleanBuilder _this)
        {
            return true;
        }

        // The query integerValue() gives the value.
        // spec:
        //     result = (value)
        public override int LiteralInteger_IntegerValue(LiteralIntegerBuilder _this)
        {
            return _this.Value;
        }

        // The query isComputable() is redefined to be true.
        // spec:
        //     result = (true)
        public override bool LiteralInteger_IsComputable(LiteralIntegerBuilder _this)
        {
            return true;
        }

        // The query isComputable() is redefined to be true.
        // spec:
        //     result = (true)
        public override bool LiteralNull_IsComputable(LiteralNullBuilder _this)
        {
            return true;
        }

        // The query isNull() returns true.
        // spec:
        //     result = (true)
        public override bool LiteralNull_IsNull(LiteralNullBuilder _this)
        {
            return true;
        }

        // The query isComputable() is redefined to be true.
        // spec:
        //     result = (true)
        public override bool LiteralReal_IsComputable(LiteralRealBuilder _this)
        {
            return true;
        }

        // The query realValue() gives the value.
        // spec:
        //     result = (value)
        public override double LiteralReal_RealValue(LiteralRealBuilder _this)
        {
            return _this.Value;
        }

        // The query isComputable() is redefined to be true.
        // spec:
        //     result = (true)
        public override bool LiteralString_IsComputable(LiteralStringBuilder _this)
        {
            return true;
        }

        // The query stringValue() gives the value.
        // spec:
        //     result = (value)
        public override string LiteralString_StringValue(LiteralStringBuilder _this)
        {
            return _this.Value;
        }

        // The query isComputable() is redefined to be true.
        // spec:
        //     result = (true)
        public override bool LiteralUnlimitedNatural_IsComputable(LiteralUnlimitedNaturalBuilder _this)
        {
            return true;
        }

        // The query unlimitedValue() gives the value.
        // spec:
        //     result = (value)
        public override long LiteralUnlimitedNatural_UnlimitedValue(LiteralUnlimitedNaturalBuilder _this)
        {
            return _this.Value;
        }

        // Return only this LoopNode. This prevents Actions within the LoopNode from having their OutputPins used as bodyOutputs or decider Pins in containing LoopNodes or ConditionalNodes.
        // spec:
        //     result = (self->asSet())
        public override IReadOnlyCollection<ActionBuilder> LoopNode_AllActions(LoopNodeBuilder _this)
        {
            return ImmutableArray.Create(_this);
        }

        // Return the loopVariable OutputPins in addition to other source nodes for the LoopNode as a StructuredActivityNode.
        // spec:
        //     result = (self.StructuredActivityNode::sourceNodes()->union(loopVariable))
        public override IReadOnlyCollection<ActivityNodeBuilder> LoopNode_SourceNodes(LoopNodeBuilder _this)
        {
            var result = this.StructuredActivityNode_SourceNodes(_this).ToSet();
            result.UnionWith(_this.LoopVariable);
            return result;
        }

        // This query returns a set including the enclosing InteractionFragment this MessageEnd is enclosed within.
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
        public override IReadOnlyCollection<InteractionFragmentBuilder> MessageEnd_EnclosingFragment(MessageEndBuilder _this)
        {
            if (_this is GateBuilder endGate)
            {
                if (endGate.IsOutsideCF())
                {
                    var result = new HashSet<InteractionFragmentBuilder>();
                    result.Add(endGate.CombinedFragment.EnclosingInteraction);
                    result.Add(endGate.CombinedFragment.EnclosingOperand);
                    return result;
                }
                else if (endGate.IsInsideCF()) return ImmutableArray.Create(endGate.CombinedFragment);
                else if (endGate.IsFormal()) return ImmutableArray.Create(endGate.Interaction);
                else if (endGate.IsActual())
                {
                    var result = new HashSet<InteractionFragmentBuilder>();
                    result.Add(endGate.InteractionUse.EnclosingInteraction);
                    result.Add(endGate.InteractionUse.EnclosingOperand);
                    return result;
                }
                else return ImmutableArray<InteractionFragmentBuilder>.Empty;
            }
            else
            {
                var endMOS = _this as MessageOccurrenceSpecificationBuilder;
                if (endMOS.EnclosingInteraction != null) return ImmutableArray.Create(endMOS.EnclosingInteraction);
                else return ImmutableArray.Create(endMOS.EnclosingOperand);
            }
        }

        // This query returns value true if this MessageEnd is a receiveEvent.
        // <p>message-&gt;notEmpty()</p>
        // pre:
        //     message->notEmpty()
        // spec:
        //     result = (message.receiveEvent->asSet()->includes(self))
        public override bool MessageEnd_IsReceive(MessageEndBuilder _this)
        {
            Debug.Assert(_this.Message != null);
            return _this.Message.ReceiveEvent == _this;
        }

        // This query returns value true if this MessageEnd is a sendEvent.
        // pre:
        //     message->notEmpty()
        // spec:
        //     result = (message.sendEvent->asSet()->includes(self))
        public override bool MessageEnd_IsSend(MessageEndBuilder _this)
        {
            Debug.Assert(_this.Message != null);
            return _this.Message.SendEvent == _this;
        }

        // This query returns a set including the MessageEnd (if exists) at the opposite end of the Message for this MessageEnd.
        // spec:
        //     result = (message->asSet().messageEnd->asSet()->excluding(self))
        // pre:
        //     message->notEmpty()
        public override IReadOnlyCollection<MessageEndBuilder> MessageEnd_OppositeEnd(MessageEndBuilder _this)
        {
            Debug.Assert(_this.Message != null);
            var result = new HashSet<MessageEndBuilder>();
            if (_this.Message.ReceiveEvent == _this) result.Add(_this.Message.SendEvent);
            else result.Add(_this.Message.ReceiveEvent);
            return result;
        }

        // The query isDistinguishableFrom() specifies that any two Messages may coexist in the same Namespace, regardless of their names.
        // spec:
        //     result = (true)
        public override bool Message_IsDistinguishableFrom(MessageBuilder _this, NamedElementBuilder n, NamespaceBuilder ns)
        {
            return true;
        }

        // The operation compatibleWith takes another multiplicity as input. It returns true if the other multiplicity is wider than, or the same as, self.
        // spec:
        //     result = ((other.lowerBound() <= self.lowerBound()) and ((other.upperBound() = *) or (self.upperBound() <= other.upperBound())))
        public override bool MultiplicityElement_CompatibleWith(MultiplicityElementBuilder _this, MultiplicityElementBuilder other)
        {
            var upperBound = _this.UpperBound();
            var otherUpperBound = other.UpperBound();
            return other.LowerBound() <= _this.LowerBound() && (otherUpperBound < 0 || (upperBound >= 0 && upperBound <= otherUpperBound));
        }

        // The lower bound of the multiplicity interval.
        // spec:
        //     result = (lowerBound())
        public override int MultiplicityElement_ComputeProperty_Lower(MultiplicityElementBuilder _this)
        {
            return _this.LowerBound();
        }

        // The upper bound of the multiplicity interval.
        // spec:
        //     result = (upperBound())
        public override long MultiplicityElement_ComputeProperty_Upper(MultiplicityElementBuilder _this)
        {
            return _this.UpperBound();
        }

        // The query includesMultiplicity() checks whether this multiplicity includes all the cardinalities allowed by the specified multiplicity.
        // pre:
        //     self.upperBound()->notEmpty() and self.lowerBound()->notEmpty() and M.upperBound()->notEmpty() and M.lowerBound()->notEmpty()
        // spec:
        //     result = ((self.lowerBound() <= M.lowerBound()) and (self.upperBound() >= M.upperBound()))
        public override bool MultiplicityElement_IncludesMultiplicity(MultiplicityElementBuilder _this, MultiplicityElementBuilder M)
        {
            var upperBound = _this.UpperBound();
            var mUpperBound = M.UpperBound();
            return _this.LowerBound() <= M.LowerBound() && (upperBound < 0 || (mUpperBound >= 0 && mUpperBound <= upperBound));
        }

        // The operation is determines if the upper and lower bound of the ranges are the ones given.
        // spec:
        //     result = (lowerbound = self.lowerBound() and upperbound = self.upperBound())
        public override bool MultiplicityElement_Is(MultiplicityElementBuilder _this, int lowerbound, long upperbound)
        {
            return _this.LowerBound() == lowerbound && _this.UpperBound() == upperbound;
        }

        // The query isMultivalued() checks whether this multiplicity has an upper bound greater than one.
        // pre:
        //     upperBound()->notEmpty()
        // spec:
        //     result = (upperBound() > 1)
        public override bool MultiplicityElement_IsMultivalued(MultiplicityElementBuilder _this)
        {
            var upperBound = _this.UpperBound();
            return upperBound < 0 || upperBound > 1;
        }

        // The query lowerBound() returns the lower bound of the multiplicity as an integer, which is the integerValue of lowerValue, if this is given, and 1 otherwise.
        // spec:
        //     result = (if (lowerValue=null or lowerValue.integerValue()=null) then 1 else lowerValue.integerValue() endif)
        public override int MultiplicityElement_LowerBound(MultiplicityElementBuilder _this)
        {
            return _this.LowerValue?.IntegerValue() ?? 1;
        }

        // The query upperBound() returns the upper bound of the multiplicity for a bounded multiplicity as an unlimited natural, which is the unlimitedNaturalValue of upperValue, if given, and 1, otherwise.
        // spec:
        //     result = (if (upperValue=null or upperValue.unlimitedValue()=null) then 1 else upperValue.unlimitedValue() endif)
        public override long MultiplicityElement_UpperBound(MultiplicityElementBuilder _this)
        {
            return _this.UpperValue?.UnlimitedValue() ?? 1;
        }

        // The query allNamespaces() gives the sequence of Namespaces in which the NamedElement is nested, working outwards.
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
        public override IReadOnlyList<NamespaceBuilder> NamedElement_AllNamespaces(NamedElementBuilder _this)
        {
            if (_this.Owner is TemplateParameterBuilder templateParameter && templateParameter.Signature.Template is NamespaceBuilder enclosingNamespace)
            {
                var result = new List<NamespaceBuilder>(enclosingNamespace.AllNamespaces());
                result.Insert(0, enclosingNamespace);
                return result;
            }
            else if (_this.Namespace != null)
            {
                var result = new List<NamespaceBuilder>(_this.Namespace.AllNamespaces());
                result.Insert(0, _this.Namespace);
                return result;
            }
            else
            {
                return ImmutableArray<NamespaceBuilder>.Empty;
            }
        }

        // The query allOwningPackages() returns the set of all the enclosing Namespaces of this NamedElement, working outwards, that are Packages, up to but not including the first such Namespace that is not a Package.
        // spec:
        //     result = (if namespace.oclIsKindOf(Package)
        //     then
        //       let owningPackage : Package = namespace.oclAsType(Package) in
        //         owningPackage->union(owningPackage.allOwningPackages())
        //     else
        //       null
        //     endif)
        public override IReadOnlyCollection<PackageBuilder> NamedElement_AllOwningPackages(NamedElementBuilder _this)
        {
            if (_this.Namespace is PackageBuilder owningPackage)
            {
                var result = owningPackage.AllOwningPackages().ToSet();
                result.Add(owningPackage);
                return result;
            }
            return ImmutableArray<PackageBuilder>.Empty;
        }

        // Indicates the Dependencies that reference this NamedElement as a client.
        // spec:
        //     result = (Dependency.allInstances()->select(d | d.client->includes(self)))
        public override IReadOnlyCollection<DependencyBuilder> NamedElement_ComputeProperty_ClientDependency(NamedElementBuilder _this)
        {
            return _this.MModel.Objects.OfType<DependencyBuilder>().Where(d => d.Client.Contains(_this)).ToSet();
        }

        // A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is constructed from the names of the containing Namespaces starting at the root of the hierarchy and ending with the name of the NamedElement itself.
        // spec:
        //     result = (if self.name <> null and self.allNamespaces()->select( ns | ns.name=null )->isEmpty()
        //     then 
        //         self.allNamespaces()->iterate( ns : Namespace; agg: String = self.name | ns.name.concat(self.separator()).concat(agg))
        //     else
        //        null
        //     endif)
        public override string NamedElement_ComputeProperty_QualifiedName(NamedElementBuilder _this)
        {
            if (_this.Name == null) return null;
            string result = _this.Name;
            foreach (var ns in _this.AllNamespaces())
            {
                if (ns.Name == null) return null;
                result = ns.Name + _this.Separator() + result;
            }
            return result;
        }

        // The query isDistinguishableFrom() determines whether two NamedElements may logically co-exist within a Namespace. By default, two named elements are distinguishable if (a) they have types neither of which is a kind of the other or (b) they have different names.
        // spec:
        //     result = ((self.oclIsKindOf(n.oclType()) or n.oclIsKindOf(self.oclType())) implies
        //         ns.getNamesOfMember(self)->intersection(ns.getNamesOfMember(n))->isEmpty()
        //     )
        public override bool NamedElement_IsDistinguishableFrom(NamedElementBuilder _this, NamedElementBuilder n, NamespaceBuilder ns)
        {
            return !_this.GetType().IsAssignableFrom(n.GetType()) && !n.GetType().IsAssignableFrom(_this.GetType()) || !ns.GetNamesOfMember(_this).Any(m => ns.GetNamesOfMember(n).Contains(m));
        }

        // The query separator() gives the string that is used to separate names when constructing a qualifiedName.
        // spec:
        //     result = ('::')
        public override string NamedElement_Separator(NamedElementBuilder _this)
        {
            return "::";
        }

        // References the PackageableElements that are members of this Namespace as a result of either PackageImports or ElementImports.
        // spec:
        //     result = (self.importMembers(elementImport.importedElement->asSet()->union(packageImport.importedPackage->collect(p | p.visibleMembers()))->asSet()))
        public override IReadOnlyCollection<PackageableElementBuilder> Namespace_ComputeProperty_ImportedMember(NamespaceBuilder _this)
        {
            var result = _this.ElementImport.Select(ei => ei.ImportedElement).ToSet();
            foreach (var pi in _this.PackageImport)
            {
                result.UnionWith(pi.ImportedPackage.VisibleMembers());
            }
            return result;
        }

        // The query excludeCollisions() excludes from a set of PackageableElements any that would not be distinguishable from each other in this Namespace.
        // spec:
        //     result = (imps->reject(imp1  | imps->exists(imp2 | not imp1.isDistinguishableFrom(imp2, self))))
        public override IReadOnlyCollection<PackageableElementBuilder> Namespace_ExcludeCollisions(NamespaceBuilder _this, IReadOnlyCollection<PackageableElementBuilder> imps)
        {
            return imps.Where(imp1 => !imps.Any(imp2 => !imp1.IsDistinguishableFrom(imp2, _this))).ToSet();
        }

        // The query getNamesOfMember() gives a set of all of the names that a member would have in a Namespace, taking importing into account. In general a member can have multiple names in a Namespace if it is imported more than once with different aliases.
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
        public override IReadOnlyCollection<string> Namespace_GetNamesOfMember(NamespaceBuilder _this, NamedElementBuilder element)
        {
            if (_this.OwnedMember.Contains(element))
            {
                return ImmutableArray.Create(element.Name);
            }
            else
            {
                var elementImports = _this.ElementImport.Where(ei => ei.ImportedElement == element).Select(ei => ei.ImportedElement);
                if (elementImports.Any()) return elementImports.Select(el => el.Name).ToSet();
                else return _this.PackageImport.Where(pi => pi.ImportedPackage.VisibleMembers().OfType<NamedElementBuilder>().Contains(element)).SelectMany(pi => pi.ImportedPackage.GetNamesOfMember(element)).ToSet();
            }
        }

        // The query importMembers() defines which of a set of PackageableElements are actually imported into the Namespace. This excludes hidden ones, i.e., those which have names that conflict with names of ownedMembers, and it also excludes PackageableElements that would have the indistinguishable names when imported.
        // spec:
        //     result = (self.excludeCollisions(imps)->select(imp | self.ownedMember->forAll(mem | imp.isDistinguishableFrom(mem, self))))
        public override IReadOnlyCollection<PackageableElementBuilder> Namespace_ImportMembers(NamespaceBuilder _this, IReadOnlyCollection<PackageableElementBuilder> imps)
        {
            return _this.ExcludeCollisions(imps).Where(imp => _this.OwnedMember.All(mem => imp.IsDistinguishableFrom(mem, _this))).ToSet();
        }

        // The Boolean query membersAreDistinguishable() determines whether all of the Namespace's members are distinguishable within it.
        // spec:
        //     result = (member->forAll( memb |
        //        member->excluding(memb)->forAll(other |
        //            memb.isDistinguishableFrom(other, self))))
        public override bool Namespace_MembersAreDistinguishable(NamespaceBuilder _this)
        {
            return _this.Member.All(memb => _this.Member.Where(m => m != memb).All(other => memb.IsDistinguishableFrom(other, _this)));
        }

        // If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required return Parameter of that Behavior. When the Behavior completes execution, the values on this Parameter give the result of evaluating the OpaqueExpression.
        // spec:
        //     result = (if behavior = null then
        //     	null
        //     else
        //     	behavior.ownedParameter->first()
        //     endif)
        public override ParameterBuilder OpaqueExpression_ComputeProperty_Result(OpaqueExpressionBuilder _this)
        {
            return _this.Behavior?.OwnedParameter.FirstOrDefault();
        }

        // The query isIntegral() tells whether an expression is intended to produce an Integer.
        // spec:
        //     result = (false)
        public override bool OpaqueExpression_IsIntegral(OpaqueExpressionBuilder _this)
        {
            return false;
        }

        // The query isNonNegative() tells whether an integer expression has a non-negative value.
        // pre:
        //     self.isIntegral()
        // spec:
        //     result = (false)
        public override bool OpaqueExpression_IsNonNegative(OpaqueExpressionBuilder _this)
        {
            return false;
        }

        // The query isPositive() tells whether an integer expression has a positive value.
        // spec:
        //     result = (false)
        // pre:
        //     self.isIntegral()
        public override bool OpaqueExpression_IsPositive(OpaqueExpressionBuilder _this)
        {
            return false;
        }

        // The query value() gives an integer value for an expression intended to produce one.
        // pre:
        //     self.isIntegral()
        // spec:
        //     result = (0)
        public override int OpaqueExpression_Value(OpaqueExpressionBuilder _this)
        {
            return 0;
        }

        // Specifies whether the return parameter is ordered or not, if present.  This information is derived from the return result for this Operation.
        // spec:
        //     result = (if returnResult()->notEmpty() then returnResult()-> exists(isOrdered) else false endif)
        public override bool Operation_ComputeProperty_IsOrdered(OperationBuilder _this)
        {
            return _this.ReturnResult().Any(res => res.IsOrdered);
        }

        // Specifies whether the return parameter is unique or not, if present. This information is derived from the return result for this Operation.
        // spec:
        //     result = (if returnResult()->notEmpty() then returnResult()->exists(isUnique) else true endif)
        public override bool Operation_ComputeProperty_IsUnique(OperationBuilder _this)
        {
            return _this.ReturnResult().Any(res => res.IsUnique);
        }

        // Specifies the lower multiplicity of the return parameter, if present. This information is derived from the return result for this Operation.
        // spec:
        //     result = (if returnResult()->notEmpty() then returnResult()->any(true).lower else null endif)
        public override int Operation_ComputeProperty_Lower(OperationBuilder _this)
        {
            return _this.ReturnResult().FirstOrDefault()?.Lower ?? 0;
        }

        // The return type of the operation, if present. This information is derived from the return result for this Operation.
        // spec:
        //     result = (if returnResult()->notEmpty() then returnResult()->any(true).type else null endif)
        public override TypeBuilder Operation_ComputeProperty_Type(OperationBuilder _this)
        {
            return _this.ReturnResult().FirstOrDefault()?.Type;
        }

        // The upper multiplicity of the return parameter, if present. This information is derived from the return result for this Operation.
        // spec:
        //     result = (if returnResult()->notEmpty() then returnResult()->any(true).upper else null endif)
        public override long Operation_ComputeProperty_Upper(OperationBuilder _this)
        {
            return _this.ReturnResult().FirstOrDefault()?.Upper ?? 0;
        }

        // The query isConsistentWith() specifies, for any two Operations in a context in which redefinition is possible, whether redefinition would be consistent. 
        // A redefining operation is consistent with a redefined operation if it has the same number of owned parameters, and for each parameter the following holds:
        // - Direction, ordering and uniqueness are the same.
        // - The corresponding types are covariant, contravariant or invariant.
        // - The multiplicities are compatible, depending on the parameter direction.
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
        public override bool Operation_IsConsistentWith(OperationBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            Debug.Assert(redefiningElement.IsRedefinitionContextValid(_this));
            var op = redefiningElement as OperationBuilder;
            if (op == null) return false;
            if (op.OwnedParameter.Count != _this.OwnedParameter.Count) return false;
            for (int i = 0; i < _this.OwnedParameter.Count; i++)
            {
                var redefiningParam = op.OwnedParameter[i];
                var redefinedParam = _this.OwnedParameter[i];
                if (redefiningParam.IsUnique != redefinedParam.IsUnique) return false;
                if (redefiningParam.IsOrdered != redefinedParam.IsOrdered) return false;
                if (redefiningParam.Direction != redefinedParam.Direction) return false;
                if (!redefiningParam.Type.ConformsTo(redefinedParam.Type) && !redefinedParam.Type.ConformsTo(redefiningParam.Type)) return false;
                if (redefiningParam.Direction != ParameterDirectionKind.Inout || redefinedParam.CompatibleWith(redefiningParam) && redefiningParam.CompatibleWith(redefinedParam)) return false;
                if (redefiningParam.Direction != ParameterDirectionKind.In || redefinedParam.CompatibleWith(redefiningParam)) return false;
                if (redefiningParam.Direction != ParameterDirectionKind.Out && redefiningParam.Direction != ParameterDirectionKind.Return || redefiningParam.CompatibleWith(redefinedParam)) return false;
            }
            return true;
        }

        // The query returnResult() returns the set containing the return parameter of the Operation if one exists, otherwise, it returns an empty set
        // spec:
        //     result = (ownedParameter->select (direction = ParameterDirectionKind::return))
        public override IReadOnlyCollection<ParameterBuilder> Operation_ReturnResult(OperationBuilder _this)
        {
            return _this.OwnedParameter.Where(p => p.Direction == ParameterDirectionKind.Return).ToSet();
        }

        // The query allApplicableStereotypes() returns all the directly or indirectly owned stereotypes, including stereotypes contained in sub-profiles.
        // spec:
        //     result = (let ownedPackages : Bag(Package) = ownedMember->select(oclIsKindOf(Package))->collect(oclAsType(Package)) in
        //      ownedStereotype->union(ownedPackages.allApplicableStereotypes())->flatten()->asSet()
        //     )
        public override IReadOnlyCollection<StereotypeBuilder> Package_AllApplicableStereotypes(PackageBuilder _this)
        {
            var ownedPackages = _this.OwnedMember.OfType<PackageBuilder>();
            var result = _this.OwnedStereotype.ToSet();
            result.UnionWith(ownedPackages.SelectMany(p => p.AllApplicableStereotypes()));
            return result;
        }

        // References the packaged elements that are Packages.
        // spec:
        //     result = (packagedElement->select(oclIsKindOf(Package))->collect(oclAsType(Package))->asSet())
        public override IReadOnlyCollection<PackageBuilder> Package_ComputeProperty_NestedPackage(PackageBuilder _this)
        {
            return _this.PackagedElement.OfType<PackageBuilder>().ToSet();
        }

        // References the Stereotypes that are owned by the Package.
        // spec:
        //     result = (packagedElement->select(oclIsKindOf(Stereotype))->collect(oclAsType(Stereotype))->asSet())
        public override IReadOnlyCollection<StereotypeBuilder> Package_ComputeProperty_OwnedStereotype(PackageBuilder _this)
        {
            return _this.PackagedElement.OfType<StereotypeBuilder>().ToSet();
        }

        // References the packaged elements that are Types.
        // spec:
        //     result = (packagedElement->select(oclIsKindOf(Type))->collect(oclAsType(Type))->asSet())
        public override IReadOnlyCollection<TypeBuilder> Package_ComputeProperty_OwnedType(PackageBuilder _this)
        {
            return _this.PackagedElement.OfType<TypeBuilder>().ToSet();
        }

        // The query containingProfile() returns the closest profile directly or indirectly containing this package (or this package itself, if it is a profile).
        // spec:
        //     result = (if self.oclIsKindOf(Profile) then 
        //     	self.oclAsType(Profile)
        //     else
        //     	self.namespace.oclAsType(Package).containingProfile()
        //     endif)
        public override ProfileBuilder Package_ContainingProfile(PackageBuilder _this)
        {
            if (_this is ProfileBuilder profile) return profile;
            else return (_this.Namespace as PackageBuilder)?.ContainingProfile();
        }

        // The query makesVisible() defines whether a Package makes an element visible outside itself. Elements with no visibility and elements with public visibility are made visible.
        // pre:
        //     member->includes(el)
        // spec:
        //     result = (ownedMember->includes(el) or
        //     (elementImport->select(ei|ei.importedElement = VisibilityKind::public)->collect(importedElement.oclAsType(NamedElement))->includes(el)) or
        //     (packageImport->select(visibility = VisibilityKind::public)->collect(importedPackage.member->includes(el))->notEmpty()))
        public override bool Package_MakesVisible(PackageBuilder _this, NamedElementBuilder el)
        {
            Debug.Assert(_this.Member.Contains(el));
            return _this.OwnedMember.Contains(el) || 
                _this.ElementImport.Any(ei => ei.ImportedElement.Visibility == VisibilityKind.Public && ei.ImportedElement == el) ||
                _this.PackageImport.Any(pi => pi.Visibility == VisibilityKind.Public && pi.ImportedPackage.Member.Contains(el));
               
        }

        // The query mustBeOwned() indicates whether elements of this type must have an owner.
        // spec:
        //     result = (false)
        public override bool Package_MustBeOwned(PackageBuilder _this)
        {
            return false;
        }

        // The query visibleMembers() defines which members of a Package can be accessed outside it.
        // spec:
        //     result = (member->select( m | m.oclIsKindOf(PackageableElement) and self.makesVisible(m))->collect(oclAsType(PackageableElement))->asSet())
        public override IReadOnlyCollection<PackageableElementBuilder> Package_VisibleMembers(PackageBuilder _this)
        {
            return _this.Member.Where(m => m is PackageableElementBuilder && _this.MakesVisible(m)).Cast<PackageableElementBuilder>().ToSet();
        }

        // The query isCompatibleWith() determines if this ParameterableElement is compatible with the specified ParameterableElement. By default, this ParameterableElement is compatible with another ParameterableElement p if the kind of this ParameterableElement is the same as or a subtype of the kind of p. Subclasses of ParameterableElement should override this operation to specify different compatibility constraints.
        // spec:
        //     result = (self.oclIsKindOf(p.oclType()))
        public override bool ParameterableElement_IsCompatibleWith(ParameterableElementBuilder _this, ParameterableElementBuilder p)
        {
            return p.GetType().IsAssignableFrom(_this.GetType());
        }

        // The query isTemplateParameter() determines if this ParameterableElement is exposed as a formal TemplateParameter.
        // spec:
        //     result = (templateParameter->notEmpty())
        public override bool ParameterableElement_IsTemplateParameter(ParameterableElementBuilder _this)
        {
            return _this.TemplateParameter != null;
        }

        // A String that represents a value to be used when no argument is supplied for the Parameter.
        // spec:
        //     result = (if self.type = String then defaultValue.stringValue() else null endif)
        public override string Parameter_ComputeProperty_Default(ParameterBuilder _this)
        {
            return _this.Type == UmlInstance.String ? _this.DefaultValue?.StringValue() : null;
        }

        // The union of the sets of Interfaces realized by the type of the Port and its supertypes, or directly the type of the Port if the Port is typed by an Interface.
        // spec:
        //     result = (if type.oclIsKindOf(Interface) 
        //     then type.oclAsType(Interface)->asSet() 
        //     else type.oclAsType(Classifier).allRealizedInterfaces() 
        //     endif)
        public override IReadOnlyCollection<InterfaceBuilder> Port_BasicProvided(PortBuilder _this)
        {
            return _this.Type is InterfaceBuilder intf ? ImmutableArray.Create(intf) : (_this.Type as ClassifierBuilder)?.AllRealizedInterfaces() ?? ImmutableArray<InterfaceBuilder>.Empty;
        }

        // The union of the sets of Interfaces used by the type of the Port and its supertypes.
        // spec:
        //     result = ( type.oclAsType(Classifier).allUsedInterfaces() )
        public override IReadOnlyCollection<InterfaceBuilder> Port_BasicRequired(PortBuilder _this)
        {
            return ((ClassifierBuilder)_this.Type).AllUsedInterfaces();
        }

        // The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCclassifier offers to its environment via this Port, and which it will handle either directly or by forwarding it to a part of its internal structure. This association is derived according to the value of isConjugated. If isConjugated is false, provided is derived as the union of the sets of Interfaces realized by the type of the port and its supertypes, or directly from the type of the Port if the Port is typed by an Interface. If isConjugated is true, it is derived as the union of the sets of Interfaces used by the type of the Port and its supertypes.
        // spec:
        //     result = (if isConjugated then basicRequired() else basicProvided() endif)
        public override IReadOnlyCollection<InterfaceBuilder> Port_ComputeProperty_Provided(PortBuilder _this)
        {
            return _this.IsConjugated ? _this.BasicRequired() : _this.BasicProvided();
        }

        // The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCassifier expects its environment to handle via this port. This association is derived according to the value of isConjugated. If isConjugated is false, required is derived as the union of the sets of Interfaces used by the type of the Port and its supertypes. If isConjugated is true, it is derived as the union of the sets of Interfaces realized by the type of the Port and its supertypes, or directly from the type of the Port if the Port is typed by an Interface.
        // spec:
        //     result = (if isConjugated then basicProvided() else basicRequired() endif)
        public override IReadOnlyCollection<InterfaceBuilder> Port_ComputeProperty_Required(PortBuilder _this)
        {
            return _this.IsConjugated ? _this.BasicRequired() : _this.BasicProvided();
        }

        // If isComposite is true, the object containing the attribute is a container for the object or value contained in the attribute. This is a derived value, indicating whether the aggregation of the Property is composite or not.
        // spec:
        //     result = (aggregation = AggregationKind::composite)
        public override bool Property_ComputeProperty_IsComposite(PropertyBuilder _this)
        {
            return _this.Aggregation == AggregationKind.Composite;
        }

        // In the case where the Property is one end of a binary association this gives the other end.
        // spec:
        //     result = (if association <> null and association.memberEnd->size() = 2
        //     then
        //         association.memberEnd->any(e | e <> self)
        //     else
        //         null
        //     endif)
        public override PropertyBuilder Property_ComputeProperty_Opposite(PropertyBuilder _this)
        {
            if (_this.Association?.MemberEnd.Count == 2)
            {
                if (_this.Association.MemberEnd[0] == _this) return _this.Association.MemberEnd[1];
                if (_this.Association.MemberEnd[1] == _this) return _this.Association.MemberEnd[0];
            }
            return null;
        }

        // The query isAttribute() is true if the Property is defined as an attribute of some Classifier.
        // spec:
        //     result = (not classifier->isEmpty())
        public override bool Property_IsAttribute(PropertyBuilder _this)
        {
            return _this.Class != null;
        }

        // The query isCompatibleWith() determines if this Property is compatible with the specified ParameterableElement. This Property is compatible with ParameterableElement p if 
        // the kind of this Property is thesame as or a subtype of the kind of p. Further, if p is a TypedElement, then the type of this Property must be conformant with the type of p.
        // spec:
        //     result = (self.oclIsKindOf(p.oclType()) and (p.oclIsKindOf(TypeElement) implies
        //     self.type.conformsTo(p.oclAsType(TypedElement).type)))
        public override bool Property_IsCompatibleWith(PropertyBuilder _this, ParameterableElementBuilder p)
        {
            return p.GetType().IsAssignableFrom(_this.GetType()) && (!(p is TypedElementBuilder te) || _this.Type.ConformsTo(te.Type));
        }

        // The query isConsistentWith() specifies, for any two Properties in a context in which redefinition is possible, whether redefinition would be logically consistent. 
        // A redefining Property is consistent with a redefined Property if the type of the redefining Property conforms to the type of the redefined Property, and the 
        // multiplicity of the redefining Property (if specified) is contained in the multiplicity of the redefined Property.
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        // spec:
        //     result = (redefiningElement.oclIsKindOf(Property) and 
        //       let prop : Property = redefiningElement.oclAsType(Property) in 
        //       (prop.type.conformsTo(self.type) and 
        //       ((prop.lowerBound()->notEmpty() and self.lowerBound()->notEmpty()) implies prop.lowerBound() >= self.lowerBound()) and 
        //       ((prop.upperBound()->notEmpty() and self.upperBound()->notEmpty()) implies prop.lowerBound() <= self.lowerBound()) and 
        //       (self.isComposite implies prop.isComposite)))
        public override bool Property_IsConsistentWith(PropertyBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            Debug.Assert(redefiningElement.IsRedefinitionContextValid(_this));
            var prop = redefiningElement as PropertyBuilder;
            if (prop == null) return false;
            var thisUpper = _this.UpperBound();
            var propUpper = prop.UpperBound();
            return prop.Type.ConformsTo(_this.Type) && prop.LowerBound() >= _this.LowerBound() && (thisUpper < 0 || propUpper <= thisUpper) && (!_this.IsComposite || prop.IsComposite);
        }

        // The query isNavigable() indicates whether it is possible to navigate across the property.
        // spec:
        //     result = (not classifier->isEmpty() or association.navigableOwnedEnd->includes(self))
        public override bool Property_IsNavigable(PropertyBuilder _this)
        {
            return _this.Class != null || _this.Association.NavigableOwnedEnd.Contains(_this);
        }

        // The query subsettingContext() gives the context for subsetting a Property. It consists, in the case of an attribute, of the corresponding Classifier, and in the case of an association end, all of the Classifiers at the other ends.
        // spec:
        //     result = (if association <> null
        //     then association.memberEnd->excluding(self)->collect(type)->asSet()
        //     else 
        //       if classifier<>null
        //       then classifier->asSet()
        //       else Set{} 
        //       endif
        //     endif)
        public override IReadOnlyCollection<TypeBuilder> Property_SubsettingContext(PropertyBuilder _this)
        {
            if (_this.Association != null) return _this.Association.MemberEnd.Where(me => me != _this).Select(me => me.Type).ToSet();
            else if (_this.Class != null) return ImmutableArray.Create(_this.Class);
            else return ImmutableArray<TypeBuilder>.Empty;
        }

        // This association refers to the associated Operation. It is derived from the Operation of the CallEvent Trigger when applicable.
        // spec:
        //     result = (trigger->collect(event)->select(oclIsKindOf(CallEvent))->collect(oclAsType(CallEvent).operation)->asSet())
        public override IReadOnlyCollection<OperationBuilder> ProtocolTransition_ComputeProperty_Referred(ProtocolTransitionBuilder _this)
        {
            return _this.Trigger.Select(t => t.Event).OfType<CallEventBuilder>().Select(e => e.Operation).ToSet();
        }

        // The query isConsistentWith() specifies a Pseudostate can only be redefined by a Pseudostate of the same kind.
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        // spec:
        //     result = (redefiningElement.oclIsKindOf(Pseudostate) and
        //     redefiningElement.oclAsType(Pseudostate).kind = kind)
        public override bool Pseudostate_IsConsistentWith(PseudostateBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            Debug.Assert(redefiningElement.IsRedefinitionContextValid(_this));
            return redefiningElement is PseudostateBuilder && ((PseudostateBuilder)redefiningElement).Kind == _this.Kind;
        }

        // Returns the ends corresponding to endData with no value InputPin. (A well-formed ReadLinkAction is constrained to have only one of these.)
        // spec:
        //     result = (endData->select(value=null).end->asOrderedSet())
        public override IReadOnlyList<PropertyBuilder> ReadLinkAction_OpenEnd(ReadLinkActionBuilder _this)
        {
            return _this.EndData.Where(ed => ed.Value == null).Select(ed => ed.End).Distinct().ToList();
        }

        // The query isConsistentWith() specifies, for any two RedefinableElements in a context in which redefinition is possible, whether redefinition would be logically consistent. By default, this is false; this operation must be overridden for subclasses of RedefinableElement to define the consistency conditions.
        // spec:
        //     result = (false)
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        public override bool RedefinableElement_IsConsistentWith(RedefinableElementBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            Debug.Assert(redefiningElement.IsRedefinitionContextValid(_this));
            return false;
        }

        // The query isRedefinitionContextValid() specifies whether the redefinition contexts of this RedefinableElement are properly related to the redefinition contexts of the specified RedefinableElement to allow this element to redefine the other. By default at least one of the redefinition contexts of this element must be a specialization of at least one of the redefinition contexts of the specified element.
        // spec:
        //     result = (redefinitionContext->exists(c | c.allParents()->includesAll(redefinedElement.redefinitionContext)))
        public override bool RedefinableElement_IsRedefinitionContextValid(RedefinableElementBuilder _this, RedefinableElementBuilder redefinedElement)
        {
            foreach (var c in _this.RedefinitionContext)
            {
                var parents = c.AllParents();
                if (redefinedElement.RedefinitionContext.All(rc => parents.Contains(rc))) return true;
            }
            return false;
        }

        // The formal template parameters of the extended signatures.
        // spec:
        //     result = (if extendedSignature->isEmpty() then Set{} else extendedSignature.parameter->asSet() endif)
        public override IReadOnlyCollection<TemplateParameterBuilder> RedefinableTemplateSignature_ComputeProperty_InheritedParameter(RedefinableTemplateSignatureBuilder _this)
        {
            return _this.ExtendedSignature.SelectMany(es => es.Parameter).ToSet();
        }

        // The query isConsistentWith() specifies, for any two RedefinableTemplateSignatures in a context in which redefinition is possible, whether redefinition would be logically consistent. A redefining template signature is always consistent with a redefined template signature, as redefinition only adds new formal parameters.
        // spec:
        //     result = (redefiningElement.oclIsKindOf(RedefinableTemplateSignature))
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        public override bool RedefinableTemplateSignature_IsConsistentWith(RedefinableTemplateSignatureBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            Debug.Assert(redefiningElement.IsRedefinitionContextValid(_this));
            return redefiningElement is RedefinableTemplateSignatureBuilder;
        }

        // The operation belongsToPSM () checks if the Region belongs to a ProtocolStateMachine.
        // spec:
        //     result = (if  stateMachine <> null 
        //     then
        //       stateMachine.oclIsKindOf(ProtocolStateMachine)
        //     else 
        //       state <> null  implies  state.container.belongsToPSM()
        //     endif )
        public override bool Region_BelongsToPSM(RegionBuilder _this)
        {
            if (_this.StateMachine != null) return _this.StateMachine is ProtocolStateMachineBuilder;
            else return _this.State == null || _this.State.Container.BelongsToPSM();
        }

        // References the Classifier in which context this element may be redefined.
        // spec:
        //     result = containingStateMachine()
        public override ClassifierBuilder Region_ComputeProperty_RedefinitionContext(RegionBuilder _this)
        {
            return _this.ContainingStateMachine();
        }

        // The operation containingStateMachine() returns the StateMachine in which this Region is defined.
        // spec:
        //     result = (if stateMachine = null 
        //     then
        //       state.containingStateMachine()
        //     else
        //       stateMachine
        //     endif)
        public override StateMachineBuilder Region_ContainingStateMachine(RegionBuilder _this)
        {
            return _this.StateMachine ?? _this.State.ContainingStateMachine();
        }

        // The query isConsistentWith specifies that a Region can be redefined by any Region for which the redefinition context is valid (see the isRedefinitionContextValid operation). Note that consistency requirements for the redefinition of Vertices and Transitions within a redefining Region are specified by the isConsistentWith and isRedefinitionContextValid operations for Vertex (and its subclasses) and Transition.
        // spec:
        //     result = true
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        public override bool Region_IsConsistentWith(RegionBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            Debug.Assert(redefiningElement.IsRedefinitionContextValid(_this));
            return true;
        }

        // The query isRedefinitionContextValid() specifies whether the redefinition contexts of a Region are properly related to the redefinition contexts of the specified Region to allow this element to redefine the other. The containing StateMachine or State of a redefining Region must Redefine the containing StateMachine or State of the redefined Region.
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
        public override bool Region_IsRedefinitionContextValid(RegionBuilder _this, RedefinableElementBuilder redefinedElement)
        {
            if (redefinedElement is RegionBuilder redefinedRegion)
            {
                if (_this.StateMachine == null) return (_this.State.RedefinedVertex as StateBuilder)?.Region.Contains(redefinedRegion) ?? false;
                else return _this.StateMachine.ExtendedStateMachine.Count > 0 && _this.StateMachine.ExtendedStateMachine.Any(sm => sm.Region.Contains(redefinedRegion));
            }
            return false;
        }

        // If the type of the object InputPin is a Behavior, then that Behavior. Otherwise, if the type of the object InputPin is a BehavioredClassifier, then the classifierBehavior of that BehavioredClassifier.
        // spec:
        //     result = (if object.type.oclIsKindOf(Behavior) then
        //       object.type.oclAsType(Behavior)
        //     else if object.type.oclIsKindOf(BehavioredClassifier) then
        //       object.type.oclAsType(BehavioredClassifier).classifierBehavior
        //     else
        //       null
        //     endif
        //     endif)
        public override BehaviorBuilder StartObjectBehaviorAction_Behavior(StartObjectBehaviorActionBuilder _this)
        {
            if (_this.Object.Type is BehaviorBuilder behavior) return behavior;
            else if (_this.Object.Type is BehavioredClassifierBuilder bc) return bc.ClassifierBehavior;
            else return null;
        }

        // Return the in and inout ownedParameters of the Behavior being called.
        // spec:
        //     result = (self.behavior().inputParameters())
        public override IReadOnlyList<ParameterBuilder> StartObjectBehaviorAction_InputParameters(StartObjectBehaviorActionBuilder _this)
        {
            return _this.Behavior().InputParameters();
        }

        // Return the inout, out and return ownedParameters of the Behavior being called.
        // spec:
        //     result = (self.behavior().outputParameters())
        public override IReadOnlyList<ParameterBuilder> StartObjectBehaviorAction_OutputParameters(StartObjectBehaviorActionBuilder _this)
        {
            return _this.Behavior().OutputParameters();
        }

        // The query ancestor(s1, s2) checks whether Vertex s2 is an ancestor of Vertex s1.
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
        public override bool StateMachine_Ancestor(StateMachineBuilder _this, VertexBuilder s1, VertexBuilder s2)
        {
            if (s2 == s1) return true;
            else if (s1.Container.StateMachine != null) return true;
            else if (s2.Container.StateMachine != null) return false;
            else return _this.Ancestor(s1, s2.Container.State);
        }

        // The query isConsistentWith specifies that a StateMachine can be redefined by any other StateMachine for which the redefinition context is valid (see the isRedefinitionContextValid operation). 
        // Note that consistency requirements for the redefinition of Regions and connectionPoint Pseudostates owned by a StateMachine are specified by the isConsistentWith and isRedefinitionContextValid 
        // operations for Region and Vertex (and its subclass Pseudostate).
        // spec:
        //     result = true
        public override bool StateMachine_IsConsistentWith(StateMachineBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            return true;
        }

        // The query isRedefinitionContextValid specifies whether the redefinition context of a StateMachine is properly related to the redefinition contexts of a StateMachine it redefines. The requirement is that the context BehavioredClassifier of a redefining StateMachine must specialize the context Classifier of the redefined StateMachine. If the redefining StateMachine does not have a context BehavioredClassifier, then then the redefining StateMachine also must not have a context BehavioredClassifier but must, instead, specialize the redefining StateMachine.
        // spec:
        //     result = (redefinedElement.oclIsKindOf(StateMachine) and
        //       let parentContext : BehavioredClassifier =
        //         redefinedElement.oclAsType(StateMachine).context in
        //       if context = null then
        //         parentContext = null and self.allParents()->includes(redefinedElement)
        //       else
        //         parentContext <> null and context.allParents()->includes(parentContext)
        //       endif)
        public override bool StateMachine_IsRedefinitionContextValid(StateMachineBuilder _this, RedefinableElementBuilder redefinedElement)
        {
            if (redefinedElement is StateMachineBuilder redefinedStateMachine)
            {
                var parentContext = redefinedStateMachine.Context;
                if (_this.Context == null) return parentContext == null && _this.AllParents().Contains(redefinedElement);
                else return parentContext != null && _this.Context.AllParents().Contains(parentContext);
            }
            return false;
        }

        // The operation LCA(s1,s2) returns the Region that is the least common ancestor of Vertices s1 and s2, based on the StateMachine containment hierarchy.
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
        public override RegionBuilder StateMachine_LCA(StateMachineBuilder _this, VertexBuilder s1, VertexBuilder s2)
        {
            if (_this.Ancestor(s1, s2)) return s2.Container;
            else if (_this.Ancestor(s2, s1)) return s1.Container;
            else return _this.LCA(s1.Container.State, s2.Container.State);
        }

        // This utility funciton is like the LCA, except that it returns the nearest composite State that contains both input Vertices.
        // spec:
        //     result = (if v2.oclIsTypeOf(State) and ancestor(v1, v2) then
        //     	v2.oclAsType(State)
        //     else if v1.oclIsTypeOf(State) and ancestor(v2, v1) then
        //     	v1.oclAsType(State)
        //     else if (v1.container.state->isEmpty() or v2.container.state->isEmpty()) then 
        //     	null.oclAsType(State)
        //     else LCAState(v1.container.state, v2.container.state)
        //     endif endif endif)
        public override StateBuilder StateMachine_LCAState(StateMachineBuilder _this, VertexBuilder v1, VertexBuilder v2)
        {
            if (v2 is StateBuilder v2state && _this.Ancestor(v1, v2)) return v2state;
            else if (v1 is StateBuilder v1state && _this.Ancestor(v2, v1)) return v1state;
            else if (v1.Container.State == null || v2.Container.State == null) return null;
            else return _this.LCAState(v1.Container.State, v2.Container.State);
        }

        // A state with isComposite=true is said to be a composite State. A composite State is a State that contains at least one Region.
        // spec:
        //     result = (region->notEmpty())
        public override bool State_ComputeProperty_IsComposite(StateBuilder _this)
        {
            return _this.Region.Count > 0;
        }

        // A State with isOrthogonal=true is said to be an orthogonal composite State An orthogonal composite State contains two or more Regions.
        // spec:
        //     result = (region->size () > 1)
        public override bool State_ComputeProperty_IsOrthogonal(StateBuilder _this)
        {
            return _this.Region.Count > 1;
        }

        // A State with isSimple=true is said to be a simple State A simple State does not have any Regions and it does not refer to any submachine StateMachine.
        // spec:
        //     result = ((region->isEmpty()) and not isSubmachineState())
        public override bool State_ComputeProperty_IsSimple(StateBuilder _this)
        {
            return _this.Region.Count == 0 && !_this.IsSubmachineState;
        }

        // A State with isSubmachineState=true is said to be a submachine State Such a State refers to another StateMachine(submachine).
        // spec:
        //     result = (submachine <> null)
        public override bool State_ComputeProperty_IsSubmachineState(StateBuilder _this)
        {
            return _this.Submachine != null;
        }

        // The query containingStateMachine() returns the StateMachine that contains the State either directly or transitively.
        // spec:
        //     result = (container.containingStateMachine())
        public override StateMachineBuilder State_ContainingStateMachine(StateBuilder _this)
        {
            return _this.Container.ContainingStateMachine();
        }

        // The query isConsistentWith specifies that a non-final State can only be redefined by a non-final State (this is overridden by FinalState to allow a FinalState to be redefined by a FinalState) and, if the redefined State is a submachine State, then the redefining State must be a submachine state whose submachine is a redefinition of the submachine of the redefined State. Note that consistency requirements for the redefinition of Regions and connectionPoint Pseudostates within a composite State and connection ConnectionPoints of a submachine State are specified by the isConsistentWith and isRedefinitionContextValid operations for Region and Vertex (and its subclasses, Pseudostate and ConnectionPointReference).
        // spec:
        //     result = (redefiningElement.oclIsTypeOf(State) and 
        //       let redefiningState : State = redefiningElement.oclAsType(State) in
        //         submachine <> null implies (redefiningState.submachine <> null and
        //           redefiningState.submachine.extendedStateMachine->includes(submachine)))
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        public override bool State_IsConsistentWith(StateBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            Debug.Assert(redefiningElement.IsRedefinitionContextValid(_this));
            return redefiningElement is StateBuilder redefiningState && (_this.Submachine == null || (redefiningState.Submachine != null && redefiningState.Submachine.ExtendedStateMachine.Contains(_this.Submachine)));
        }

        // The profile that directly or indirectly contains this stereotype.
        // spec:
        //     result = (self.containingProfile())
        public override ProfileBuilder Stereotype_ComputeProperty_Profile(StereotypeBuilder _this)
        {
            return _this.ContainingProfile();
        }

        // The query containingProfile returns the closest profile directly or indirectly containing this stereotype.
        // spec:
        //     result = (self.namespace.oclAsType(Package).containingProfile())
        public override ProfileBuilder Stereotype_ContainingProfile(StereotypeBuilder _this)
        {
            return (_this.Namespace as PackageBuilder)?.ContainingProfile();
        }

        // The query stringValue() returns the String resulting from concatenating, in order, all the component String values of all the operands or subExpressions that are part of the StringExpression.
        // spec:
        //     result = (if subExpression->notEmpty()
        //     then subExpression->iterate(se; stringValue: String = '' | stringValue.concat(se.stringValue()))
        //     else operand->iterate(op; stringValue: String = '' | stringValue.concat(op.stringValue()))
        //     endif)
        public override string StringExpression_StringValue(StringExpressionBuilder _this)
        {
            StringBuilder sb = new StringBuilder();
            if (_this.SubExpression.Count > 0)
            {
                foreach (var se in _this.SubExpression)
                {
                    sb.Append(se);
                }
            }
            else
            {
                foreach (var op in _this.Operand)
                {
                    sb.Append(op);
                }
            }
            return sb.ToString();
        }

        // Returns this StructuredActivityNode and all Actions contained in it.
        // spec:
        //     result = (node->select(oclIsKindOf(Action)).oclAsType(Action).allActions()->including(self)->asSet())
        public override IReadOnlyCollection<ActionBuilder> StructuredActivityNode_AllActions(StructuredActivityNodeBuilder _this)
        {
            var result = _this.Node.OfType<ActionBuilder>().SelectMany(a => a.AllActions()).ToSet();
            result.Add(_this);
            return result;
        }

        // Returns all the ActivityNodes contained directly or indirectly within this StructuredActivityNode, in addition to the Pins of the StructuredActivityNode.
        // spec:
        //     result = (self.Action::allOwnedNodes()->union(node)->union(node->select(oclIsKindOf(Action)).oclAsType(Action).allOwnedNodes())->asSet())
        public override IReadOnlyCollection<ActivityNodeBuilder> StructuredActivityNode_AllOwnedNodes(StructuredActivityNodeBuilder _this)
        {
            var result = this.Action_AllOwnedNodes(_this).ToSet();
            result.UnionWith(_this.Node);
            result.UnionWith(_this.Node.OfType<ActionBuilder>().SelectMany(a => a.AllOwnedNodes()));
            return result;
        }

        // The Activity that directly or indirectly contains this StructuredActivityNode (considered as an Action).
        // spec:
        //     result = (self.Action::containingActivity())
        public override ActivityBuilder StructuredActivityNode_ContainingActivity(StructuredActivityNodeBuilder _this)
        {
            return this.ActivityGroup_ContainingActivity(_this); // TODO: UML bug?
        }

        // Return those ActivityNodes contained immediately within the StructuredActivityNode that may act as sources of edges owned by the StructuredActivityNode.
        // spec:
        //     result = (node->union(input.oclAsType(ActivityNode)->asSet())->
        //       union(node->select(oclIsKindOf(Action)).oclAsType(Action).output)->asSet())
        public override IReadOnlyCollection<ActivityNodeBuilder> StructuredActivityNode_SourceNodes(StructuredActivityNodeBuilder _this)
        {
            var result = _this.Node.ToSet();
            result.UnionWith(_this.Input.OfType<ActivityNodeBuilder>());
            result.UnionWith(_this.Node.OfType<ActionBuilder>().SelectMany(a => a.Output));
            return result;
        }

        // Return those ActivityNodes contained immediately within the StructuredActivityNode that may act as targets of edges owned by the StructuredActivityNode.
        // spec:
        //     result = (node->union(output.oclAsType(ActivityNode)->asSet())->
        //       union(node->select(oclIsKindOf(Action)).oclAsType(Action).input)->asSet())
        public override IReadOnlyCollection<ActivityNodeBuilder> StructuredActivityNode_TargetNodes(StructuredActivityNodeBuilder _this)
        {
            var result = _this.Node.ToSet();
            result.UnionWith(_this.Output.OfType<ActivityNodeBuilder>());
            result.UnionWith(_this.Node.OfType<ActionBuilder>().SelectMany(a => a.Input));
            return result;
        }

        // All features of type ConnectableElement, equivalent to all direct and inherited roles.
        // spec:
        //     result = (allFeatures()->select(oclIsKindOf(ConnectableElement))->collect(oclAsType(ConnectableElement))->asSet())
        public override IReadOnlyCollection<ConnectableElementBuilder> StructuredClassifier_AllRoles(StructuredClassifierBuilder _this)
        {
            return _this.AllFeatures().OfType<ConnectableElementBuilder>().ToSet();
        }

        // The Properties specifying instances that the StructuredClassifier owns by composition. This collection is derived, selecting those owned Properties where isComposite is true.
        // spec:
        //     result = (ownedAttribute->select(isComposite))
        public override IReadOnlyCollection<PropertyBuilder> StructuredClassifier_ComputeProperty_Part(StructuredClassifierBuilder _this)
        {
            return _this.OwnedAttribute.Where(attr => attr.IsComposite).ToSet();
        }

        // The query isTemplate() returns whether this TemplateableElement is actually a template.
        // spec:
        //     result = (ownedTemplateSignature <> null)
        public override bool TemplateableElement_IsTemplate(TemplateableElementBuilder _this)
        {
            return _this.OwnedTemplateSignature != null;
        }

        // The query parameterableElements() returns the set of ParameterableElements that may be used as the parameteredElements for a TemplateParameter of this TemplateableElement. By default, this set includes all the ownedElements. Subclasses may override this operation if they choose to restrict the set of ParameterableElements.
        // spec:
        //     result = (self.allOwnedElements()->select(oclIsKindOf(ParameterableElement)).oclAsType(ParameterableElement)->asSet())
        public override IReadOnlyCollection<ParameterableElementBuilder> TemplateableElement_ParameterableElements(TemplateableElementBuilder _this)
        {
            return _this.AllOwnedElements().OfType<ParameterableElementBuilder>().ToSet();
        }

        // References the Classifier in which context this element may be redefined.
        // spec:
        //     result = containingStateMachine()
        public override ClassifierBuilder Transition_ComputeProperty_RedefinitionContext(TransitionBuilder _this)
        {
            return _this.ContainingStateMachine();
        }

        // The query containingStateMachine() returns the StateMachine that contains the Transition either directly or transitively.
        // spec:
        //     result = (container.containingStateMachine())
        public override StateMachineBuilder Transition_ContainingStateMachine(TransitionBuilder _this)
        {
            return _this.Container.ContainingStateMachine();
        }

        // The query isConsistentWith specifies that a redefining Transition is consistent with a redefined Transition provided that the source Vertex of the redefining Transition redefines the source Vertex of the redefined Transition.
        // spec:
        //     result = (redefiningElement.oclIsKindOf(Transition) and
        //       redefiningElement.oclAsType(Transition).source.redefinedTransition = source)
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        public override bool Transition_IsConsistentWith(TransitionBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            return redefiningElement.IsRedefinitionContextValid(_this);
        }

        // The query conformsTo() gives true for a Type that conforms to another. By default, two Types do not conform to each other. This query is intended to be redefined for specific conformance situations.
        // spec:
        //     result = (false)
        public override bool Type_ConformsTo(TypeBuilder _this, TypeBuilder other)
        {
            return false;
        }

        // The query allIncludedUseCases() returns the transitive closure of all UseCases (directly or indirectly) included by this UseCase.
        // spec:
        //     result = (self.include.addition->union(self.include.addition->collect(uc | uc.allIncludedUseCases()))->asSet())
        public override IReadOnlyCollection<UseCaseBuilder> UseCase_AllIncludedUseCases(UseCaseBuilder _this)
        {
            var additions = _this.Include.Select(inc => inc.Addition);
            var result = additions.ToSet();
            foreach (var uc in additions)
            {
                result.UnionWith(uc.AllIncludedUseCases());
            }
            return result;
        }

        // The query booleanValue() gives a single Boolean value when one can be computed.
        // spec:
        //     result = (null)
        public override bool ValueSpecification_BooleanValue(ValueSpecificationBuilder _this)
        {
            return default;
        }

        // The query integerValue() gives a single Integer value when one can be computed.
        // spec:
        //     result = (null)
        public override int ValueSpecification_IntegerValue(ValueSpecificationBuilder _this)
        {
            return default;
        }

        // The query isCompatibleWith() determines if this ValueSpecification is compatible with the specified ParameterableElement. This ValueSpecification is compatible with ParameterableElement p if the kind of this ValueSpecification is the same as or a subtype of the kind of p. Further, if p is a TypedElement, then the type of this ValueSpecification must be conformant with the type of p.
        // spec:
        //     result = (self.oclIsKindOf(p.oclType()) and (p.oclIsKindOf(TypedElement) implies 
        //     self.type.conformsTo(p.oclAsType(TypedElement).type)))
        public override bool ValueSpecification_IsCompatibleWith(ValueSpecificationBuilder _this, ParameterableElementBuilder p)
        {
            return p.GetType().IsAssignableFrom(_this.GetType()) && (!(p is TypedElementBuilder) || _this.Type.ConformsTo(((TypedElementBuilder)p).Type));
        }

        // The query isComputable() determines whether a value specification can be computed in a model. This operation cannot be fully defined in OCL. A conforming implementation is expected to deliver true for this operation for all ValueSpecifications that it can compute, and to compute all of those for which the operation is true. A conforming implementation is expected to be able to compute at least the value of all LiteralSpecifications.
        // spec:
        //     result = (false)
        public override bool ValueSpecification_IsComputable(ValueSpecificationBuilder _this)
        {
            return default;
        }

        // The query isNull() returns true when it can be computed that the value is null.
        // spec:
        //     result = (false)
        public override bool ValueSpecification_IsNull(ValueSpecificationBuilder _this)
        {
            return default;
        }

        // The query realValue() gives a single Real value when one can be computed.
        // spec:
        //     result = (null)
        public override double ValueSpecification_RealValue(ValueSpecificationBuilder _this)
        {
            return default;
        }

        // The query stringValue() gives a single String value when one can be computed.
        // spec:
        //     result = (null)
        public override string ValueSpecification_StringValue(ValueSpecificationBuilder _this)
        {
            return default;
        }

        // The query unlimitedValue() gives a single UnlimitedNatural value when one can be computed.
        // spec:
        //     result = (null)
        public override long ValueSpecification_UnlimitedValue(ValueSpecificationBuilder _this)
        {
            return default;
        }

        // A Variable is accessible by Actions within its scope (the Activity or StructuredActivityNode that owns it).
        // spec:
        //     result = (if scope<>null then scope.allOwnedNodes()->includes(a)
        //     else a.containingActivity()=activityScope
        //     endif)
        public override bool Variable_IsAccessibleBy(VariableBuilder _this, ActionBuilder a)
        {
            if (_this.Scope != null) return _this.Scope.AllOwnedNodes().Contains(a);
            else return a.ContainingActivity() == _this.ActivityScope;
        }

        // Specifies the Transitions entering this Vertex.
        // spec:
        //     result = (Transition.allInstances()->select(target=self))
        public override IReadOnlyCollection<TransitionBuilder> Vertex_ComputeProperty_Incoming(VertexBuilder _this)
        {
            return _this.MModel.Objects.OfType<TransitionBuilder>().Where(t => t.Target == _this).ToSet();
        }

        // Specifies the Transitions departing from this Vertex.
        // spec:
        //     result = (Transition.allInstances()->select(source=self))
        public override IReadOnlyCollection<TransitionBuilder> Vertex_ComputeProperty_Outgoing(VertexBuilder _this)
        {
            return _this.MModel.Objects.OfType<TransitionBuilder>().Where(t => t.Source == _this).ToSet();
        }

        // References the Classifier in which context this element may be redefined.
        // spec:
        //     result = containingStateMachine()
        public override ClassifierBuilder Vertex_ComputeProperty_RedefinitionContext(VertexBuilder _this)
        {
            return _this.ContainingStateMachine();
        }

        // The operation containingStateMachine() returns the StateMachine in which this Vertex is defined.
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
        public override StateMachineBuilder Vertex_ContainingStateMachine(VertexBuilder _this)
        {
            if (_this.Container != null) return _this.Container.ContainingStateMachine();
            else if (_this is PseudostateBuilder pseudostate && (pseudostate.Kind == PseudostateKind.EntryPoint || pseudostate.Kind == PseudostateKind.ExitPoint)) return pseudostate.StateMachine;
            else if (_this is ConnectionPointReferenceBuilder connectionPointReference) return connectionPointReference.State.ContainingStateMachine();
            else return null;
        }

        // The query isRedefinitionContextValid specifies that the redefinition context of a redefining Vertex is properly related to the redefinition context of the redefined Vertex if the owner of the redefining Vertex is a redefinition of the owner of the redefined Vertex. Note that the owner of a Vertex may be a Region, a StateMachine (for a connectionPoint Pseudostate), or a State (for a connectionPoint Pseudostate or a connection ConnectionPointReference), all of which are RedefinableElements.
        // pre:
        //     redefiningElement.isRedefinitionContextValid(self)
        // spec:
        //     result = (redefinedElement.oclIsKindOf(Vertex) and
        //       owner.oclAsType(RedefinableElement).redefinedElement->includes(redefinedElement.owner))
        public override bool Vertex_IsConsistentWith(VertexBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            Debug.Assert(redefiningElement.IsRedefinitionContextValid(_this));
            return redefiningElement is VertexBuilder redefiningVertex && _this.Owner is RedefinableElementBuilder owner && owner.RedefinedElement.Contains(redefiningVertex.Owner);
        }

        // This utility query returns true if the Vertex is contained in the Region r (input argument).
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
        public override bool Vertex_IsContainedInRegion(VertexBuilder _this, RegionBuilder r)
        {
            if (_this.Container == r) return true;
            else if (r.State == null) return false;
            else return _this.Container.State.IsContainedInRegion(r);
        }

        // This utility operation returns true if the Vertex is contained in the State s (input argument).
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
        public override bool Vertex_IsContainedInState(VertexBuilder _this, StateBuilder s)
        {
            if (!s.IsComposite || _this.Container == null) return false;
            else if (_this.Container.State == s) return true;
            else return _this.Container.State.IsContainedInState(s);
        }
    }
}

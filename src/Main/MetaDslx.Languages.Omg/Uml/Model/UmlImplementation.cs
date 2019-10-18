using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MetaDslx.Modeling;

namespace MetaDslx.Languages.Uml.Model.Internal
{
    class UmlImplementation : UmlImplementationBase
    {
        public override IReadOnlyCollection<ActionBuilder> Action_AllActions(ActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ActivityNodeBuilder> Action_AllOwnedNodes(ActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override ClassifierBuilder Action_ComputeProperty_Context(ActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override BehaviorBuilder Action_ContainingBehavior(ActionBuilder _this)
        {
            throw new NotImplementedException();
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
            return new HashSet<TypeBuilder>(_this.MemberEnd.Select(me => me.Type));
        }

        public override IReadOnlyList<ParameterBuilder> BehavioralFeature_InputParameters(BehavioralFeatureBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool BehavioralFeature_IsDistinguishableFrom(BehavioralFeatureBuilder _this, NamedElementBuilder n, NamespaceBuilder ns)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<ParameterBuilder> BehavioralFeature_OutputParameters(BehavioralFeatureBuilder _this)
        {
            throw new NotImplementedException();
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
            // if (_this.NestingClass != null) return null; // TODO
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

        public override IReadOnlyList<ParameterBuilder> CallAction_InputParameters(CallActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<ParameterBuilder> CallAction_OutputParameters(CallActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<ParameterBuilder> CallBehaviorAction_InputParameters(CallBehaviorActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<ParameterBuilder> CallBehaviorAction_OutputParameters(CallBehaviorActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<ParameterBuilder> CallOperationAction_InputParameters(CallOperationActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<ParameterBuilder> CallOperationAction_OutputParameters(CallOperationActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<PropertyBuilder> Classifier_AllAttributes(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<FeatureBuilder> Classifier_AllFeatures(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ClassifierBuilder> Classifier_AllParents(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<InterfaceBuilder> Classifier_AllRealizedInterfaces(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<StructuralFeatureBuilder> Classifier_AllSlottableFeatures(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<InterfaceBuilder> Classifier_AllUsedInterfaces(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ClassifierBuilder> Classifier_ComputeProperty_General(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<NamedElementBuilder> Classifier_ComputeProperty_InheritedMember(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Classifier_ConformsTo(ClassifierBuilder _this, TypeBuilder other)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<InterfaceBuilder> Classifier_DirectlyRealizedInterfaces(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<InterfaceBuilder> Classifier_DirectlyUsedInterfaces(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Classifier_HasVisibilityOf(ClassifierBuilder _this, NamedElementBuilder n)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<NamedElementBuilder> Classifier_Inherit(ClassifierBuilder _this, IReadOnlyCollection<NamedElementBuilder> inhs)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<NamedElementBuilder> Classifier_InheritableMembers(ClassifierBuilder _this, ClassifierBuilder c)
        {
            throw new NotImplementedException();
        }

        public override bool Classifier_IsSubstitutableFor(ClassifierBuilder _this, ClassifierBuilder contract)
        {
            throw new NotImplementedException();
        }

        public override bool Classifier_IsTemplate(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Classifier_MaySpecializeType(ClassifierBuilder _this, ClassifierBuilder c)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ClassifierBuilder> Classifier_Parents(ClassifierBuilder _this)
        {
            throw new NotImplementedException();
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
            return new HashSet<ClassBuilder>(_this.General.Where(cls => cls is ClassBuilder).Cast<ClassBuilder>());
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
            var realizingClassifiers = new HashSet<ClassifierBuilder>(_this.Realization.SelectMany(r => r.RealizingClassifier));
            realizingClassifiers.UnionWith(_this.AllParents().OfType<ComponentBuilder>().SelectMany(p => p.Realization.SelectMany(r => r.RealizingClassifier)));
            var allRealizingClassifiers = new HashSet<ClassifierBuilder>(realizingClassifiers);
            allRealizingClassifiers.UnionWith(realizingClassifiers.SelectMany(rc => rc.AllParents()));
            var realizingClassifierInterfaces = new HashSet<InterfaceBuilder>(allRealizingClassifiers.SelectMany(arc => arc.AllRealizedInterfaces()));
            var ports = new HashSet<PortBuilder>(_this.AllParents().OfType<ComponentBuilder>().SelectMany(p => p.OwnedPort));
            ports.UnionWith(_this.OwnedPort);
            var providedByPorts = new HashSet<InterfaceBuilder>(ports.SelectMany(p => p.Provided));
            var result = new HashSet<InterfaceBuilder>(ris);
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
            var realizingClassifiers = new HashSet<ClassifierBuilder>(_this.Realization.SelectMany(r => r.RealizingClassifier));
            realizingClassifiers.UnionWith(_this.AllParents().OfType<ComponentBuilder>().SelectMany(p => p.Realization.SelectMany(r => r.RealizingClassifier)));
            var allRealizingClassifiers = new HashSet<ClassifierBuilder>(realizingClassifiers);
            allRealizingClassifiers.UnionWith(realizingClassifiers.SelectMany(rc => rc.AllParents()));
            var realizingClassifierInterfaces = new HashSet<InterfaceBuilder>(allRealizingClassifiers.SelectMany(arc => arc.AllUsedInterfaces()));
            var ports = new HashSet<PortBuilder>(_this.AllParents().OfType<ComponentBuilder>().SelectMany(p => p.OwnedPort));
            ports.UnionWith(_this.OwnedPort);
            var requiredByPorts = new HashSet<InterfaceBuilder>(ports.SelectMany(p => p.Required));
            var result = new HashSet<InterfaceBuilder>(uis);
            result.UnionWith(realizingClassifierInterfaces);
            result.UnionWith(requiredByPorts);
            return result;
        }

        public override IReadOnlyCollection<ActionBuilder> ConditionalNode_AllActions(ConditionalNodeBuilder _this)
        {
            throw new NotImplementedException();
        }

        // A set of ConnectorEnds that attach to this ConnectableElement.
        // spec:
        //     result = (ConnectorEnd.allInstances()->select(role = self))
        public override IReadOnlyCollection<ConnectorEndBuilder> ConnectableElement_ComputeProperty_End(ConnectableElementBuilder _this)
        {
            return new HashSet<ConnectorEndBuilder>(_this.MModel.Objects.OfType<ConnectorEndBuilder>().Where(ce => ce.Role == _this));
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
            return new HashSet<PackageableElementBuilder>(_this.Deployment.SelectMany(d => d.DeployedArtifact).OfType<ArtifactBuilder>().SelectMany(a => a.Manifestation).Select(m => m.UtilizedElement));
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

        public override bool FunctionBehavior_HasAllDataTypeAttributes(FunctionBehaviorBuilder _this, DataTypeBuilder d)
        {
            throw new NotImplementedException();
        }

        public override string Gate_GetName(GateBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override InteractionOperandBuilder Gate_GetOperand(GateBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Gate_IsActual(GateBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Gate_IsDistinguishableFrom(GateBuilder _this, NamedElementBuilder n, NamespaceBuilder ns)
        {
            throw new NotImplementedException();
        }

        public override bool Gate_IsFormal(GateBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Gate_IsInsideCF(GateBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Gate_IsOutsideCF(GateBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Gate_Matches(GateBuilder _this, GateBuilder gateToMatch)
        {
            throw new NotImplementedException();
        }

        public override AssociationBuilder LinkAction_Association(LinkActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<InputPinBuilder> LinkEndCreationData_AllPins(LinkEndCreationDataBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<InputPinBuilder> LinkEndData_AllPins(LinkEndDataBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<InputPinBuilder> LinkEndDestructionData_AllPins(LinkEndDestructionDataBuilder _this)
        {
            throw new NotImplementedException();
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

        public override IReadOnlyCollection<ActionBuilder> LoopNode_AllActions(LoopNodeBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ActivityNodeBuilder> LoopNode_SourceNodes(LoopNodeBuilder _this)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        // The derived kind of the Message (complete, lost, found, or unknown).
        // spec:
        //     result = (messageKind)
        public override MessageKind Message_ComputeProperty_MessageKind(MessageBuilder _this)
        {
            throw new NotImplementedException();
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
                var result = new HashSet<PackageBuilder>(owningPackage.AllOwningPackages());
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
            return new HashSet<DependencyBuilder>(_this.MModel.Objects.OfType<DependencyBuilder>().Where(d => d.Client.Contains(_this)));
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
            var result = new HashSet<PackageableElementBuilder>(_this.ElementImport.Select(ei => ei.ImportedElement));
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
            return new HashSet<PackageableElementBuilder>(imps.Where(imp1 => !imps.Any(imp2 => !imp1.IsDistinguishableFrom(imp2, _this))));
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
                if (elementImports.Any()) return new HashSet<string>(elementImports.Select(el => el.Name));
                else return new HashSet<string>(_this.PackageImport.Where(pi => pi.ImportedPackage.VisibleMembers().OfType<NamedElementBuilder>().Contains(element)).SelectMany(pi => pi.ImportedPackage.GetNamesOfMember(element)));
            }
        }

        // The query importMembers() defines which of a set of PackageableElements are actually imported into the Namespace. This excludes hidden ones, i.e., those which have names that conflict with names of ownedMembers, and it also excludes PackageableElements that would have the indistinguishable names when imported.
        // spec:
        //     result = (self.excludeCollisions(imps)->select(imp | self.ownedMember->forAll(mem | imp.isDistinguishableFrom(mem, self))))
        public override IReadOnlyCollection<PackageableElementBuilder> Namespace_ImportMembers(NamespaceBuilder _this, IReadOnlyCollection<PackageableElementBuilder> imps)
        {
            return new HashSet<PackageableElementBuilder>(_this.ExcludeCollisions(imps).Where(imp => _this.OwnedMember.All(mem => imp.IsDistinguishableFrom(mem, _this))));
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

        public override bool Operation_ComputeProperty_IsOrdered(OperationBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Operation_ComputeProperty_IsUnique(OperationBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override int Operation_ComputeProperty_Lower(OperationBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder Operation_ComputeProperty_Type(OperationBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override long Operation_ComputeProperty_Upper(OperationBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Operation_IsConsistentWith(OperationBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ParameterBuilder> Operation_ReturnResult(OperationBuilder _this)
        {
            throw new NotImplementedException();
        }

        // The query allApplicableStereotypes() returns all the directly or indirectly owned stereotypes, including stereotypes contained in sub-profiles.
        // spec:
        //     result = (let ownedPackages : Bag(Package) = ownedMember->select(oclIsKindOf(Package))->collect(oclAsType(Package)) in
        //      ownedStereotype->union(ownedPackages.allApplicableStereotypes())->flatten()->asSet()
        //     )
        public override IReadOnlyCollection<StereotypeBuilder> Package_AllApplicableStereotypes(PackageBuilder _this)
        {
            var ownedPackages = _this.OwnedMember.OfType<PackageBuilder>();
            var result = new HashSet<StereotypeBuilder>(_this.OwnedStereotype);
            result.UnionWith(ownedPackages.SelectMany(p => p.AllApplicableStereotypes()));
            return result;
        }

        // References the packaged elements that are Packages.
        // spec:
        //     result = (packagedElement->select(oclIsKindOf(Package))->collect(oclAsType(Package))->asSet())
        public override IReadOnlyCollection<PackageBuilder> Package_ComputeProperty_NestedPackage(PackageBuilder _this)
        {
            return new HashSet<PackageBuilder>(_this.PackagedElement.OfType<PackageBuilder>());
        }

        // References the Stereotypes that are owned by the Package.
        // spec:
        //     result = (packagedElement->select(oclIsKindOf(Stereotype))->collect(oclAsType(Stereotype))->asSet())
        public override IReadOnlyCollection<StereotypeBuilder> Package_ComputeProperty_OwnedStereotype(PackageBuilder _this)
        {
            return new HashSet<StereotypeBuilder>(_this.PackagedElement.OfType<StereotypeBuilder>());
        }

        // References the packaged elements that are Types.
        // spec:
        //     result = (packagedElement->select(oclIsKindOf(Type))->collect(oclAsType(Type))->asSet())
        public override IReadOnlyCollection<TypeBuilder> Package_ComputeProperty_OwnedType(PackageBuilder _this)
        {
            return new HashSet<TypeBuilder>(_this.PackagedElement.OfType<TypeBuilder>());
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
            return new HashSet<PackageableElementBuilder>(_this.Member.Where(m => m is PackageableElementBuilder && _this.MakesVisible(m)).Cast<PackageableElementBuilder>());
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

        public override string Parameter_ComputeProperty_Default(ParameterBuilder _this)
        {
            throw new NotImplementedException();
        }

        // The union of the sets of Interfaces realized by the type of the Port and its supertypes, or directly the type of the Port if the Port is typed by an Interface.
        // spec:
        //     result = (if type.oclIsKindOf(Interface) 
        //     then type.oclAsType(Interface)->asSet() 
        //     else type.oclAsType(Classifier).allRealizedInterfaces() 
        //     endif)
        public override IReadOnlyCollection<InterfaceBuilder> Port_BasicProvided(PortBuilder _this)
        {
            throw new NotImplementedException();
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

        public override bool Property_ComputeProperty_IsComposite(PropertyBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override PropertyBuilder Property_ComputeProperty_Opposite(PropertyBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Property_IsAttribute(PropertyBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool Property_IsCompatibleWith(PropertyBuilder _this, ParameterableElementBuilder p)
        {
            throw new NotImplementedException();
        }

        public override bool Property_IsConsistentWith(PropertyBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            throw new NotImplementedException();
        }

        public override bool Property_IsNavigable(PropertyBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<TypeBuilder> Property_SubsettingContext(PropertyBuilder _this)
        {
            throw new NotImplementedException();
        }

        // This association refers to the associated Operation. It is derived from the Operation of the CallEvent Trigger when applicable.
        // spec:
        //     result = (trigger->collect(event)->select(oclIsKindOf(CallEvent))->collect(oclAsType(CallEvent).operation)->asSet())
        public override IReadOnlyCollection<OperationBuilder> ProtocolTransition_ComputeProperty_Referred(ProtocolTransitionBuilder _this)
        {
            return new HashSet<OperationBuilder>(_this.Trigger.Select(t => t.Event).OfType<CallEventBuilder>().Select(e => e.Operation));
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

        public override IReadOnlyList<PropertyBuilder> ReadLinkAction_OpenEnd(ReadLinkActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool RedefinableElement_IsConsistentWith(RedefinableElementBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            throw new NotImplementedException();
        }

        public override bool RedefinableElement_IsRedefinitionContextValid(RedefinableElementBuilder _this, RedefinableElementBuilder redefinedElement)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<TemplateParameterBuilder> RedefinableTemplateSignature_ComputeProperty_InheritedParameter(RedefinableTemplateSignatureBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool RedefinableTemplateSignature_IsConsistentWith(RedefinableTemplateSignatureBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            throw new NotImplementedException();
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

        public override BehaviorBuilder StartObjectBehaviorAction_Behavior(StartObjectBehaviorActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<ParameterBuilder> StartObjectBehaviorAction_InputParameters(StartObjectBehaviorActionBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<ParameterBuilder> StartObjectBehaviorAction_OutputParameters(StartObjectBehaviorActionBuilder _this)
        {
            throw new NotImplementedException();
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

        public override bool StateMachine_IsConsistentWith(StateMachineBuilder _this, RedefinableElementBuilder redefiningElement)
        {
            throw new NotImplementedException();
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

        public override IReadOnlyCollection<ActionBuilder> StructuredActivityNode_AllActions(StructuredActivityNodeBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ActivityNodeBuilder> StructuredActivityNode_AllOwnedNodes(StructuredActivityNodeBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override ActivityBuilder StructuredActivityNode_ContainingActivity(StructuredActivityNodeBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ActivityNodeBuilder> StructuredActivityNode_SourceNodes(StructuredActivityNodeBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<ActivityNodeBuilder> StructuredActivityNode_TargetNodes(StructuredActivityNodeBuilder _this)
        {
            throw new NotImplementedException();
        }

        // All features of type ConnectableElement, equivalent to all direct and inherited roles.
        // spec:
        //     result = (allFeatures()->select(oclIsKindOf(ConnectableElement))->collect(oclAsType(ConnectableElement))->asSet())
        public override IReadOnlyCollection<ConnectableElementBuilder> StructuredClassifier_AllRoles(StructuredClassifierBuilder _this)
        {
            return new HashSet<ConnectableElementBuilder>(_this.AllFeatures().OfType<ConnectableElementBuilder>());
        }

        // The Properties specifying instances that the StructuredClassifier owns by composition. This collection is derived, selecting those owned Properties where isComposite is true.
        // spec:
        //     result = (ownedAttribute->select(isComposite))
        public override IReadOnlyCollection<PropertyBuilder> StructuredClassifier_ComputeProperty_Part(StructuredClassifierBuilder _this)
        {
            return new HashSet<PropertyBuilder>(_this.OwnedAttribute.Where(attr => attr.IsComposite));
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
            return new HashSet<ParameterableElementBuilder>(_this.AllOwnedElements().OfType<ParameterableElementBuilder>());
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
            var result = new HashSet<UseCaseBuilder>(additions);
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
            return new HashSet<TransitionBuilder>(_this.MModel.Objects.OfType<TransitionBuilder>().Where(t => t.Target == _this));
        }

        // Specifies the Transitions departing from this Vertex.
        // spec:
        //     result = (Transition.allInstances()->select(source=self))
        public override IReadOnlyCollection<TransitionBuilder> Vertex_ComputeProperty_Outgoing(VertexBuilder _this)
        {
            return new HashSet<TransitionBuilder>(_this.MModel.Objects.OfType<TransitionBuilder>().Where(t => t.Source == _this));
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

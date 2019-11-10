using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal sealed class ComplexSlot : Slot
    {
        private ModelPropertyFlags flags;
        private ModelProperty effectiveProperty;
        private ImmutableArray<ModelProperty> equivalentProperties;
        private ImmutableArray<Slot> supersetSlots;
        private ImmutableArray<Slot> subsetSlots;
        private ImmutableArray<Slot> subsettedSlots;
        private ImmutableArray<Slot> subsettingSlots;
        private ImmutableArray<Slot> derivedUnionSlots;
        private ImmutableArray<ModelProperty> oppositeProperties;

        internal ComplexSlot(ModelPropertyFlags flags, ModelProperty effectiveProperty)
        {
            this.flags = flags;
            this.effectiveProperty = effectiveProperty;
        }

        internal void UpdateSlots(ImmutableArray<ModelProperty> equivalentProperties, ImmutableArray<Slot> supersetSlots, ImmutableArray<Slot> subsetSlots,
            ImmutableArray<Slot> subsettedSlots, ImmutableArray<Slot> subsettingSlots, ImmutableArray<Slot> derivedUnionSlots, ImmutableArray<ModelProperty> oppositeProperties)
        {
            this.equivalentProperties = equivalentProperties;
            this.supersetSlots = supersetSlots;
            this.subsetSlots = subsetSlots;
            this.subsettedSlots = subsettedSlots;
            this.subsettingSlots = subsettingSlots;
            this.derivedUnionSlots = derivedUnionSlots;
            this.oppositeProperties = oppositeProperties;
        }

        public bool IsSimpleSlot => false;
        public ModelProperty EffectiveProperty => this.effectiveProperty;
        public string Name => this.effectiveProperty.Name;
        public ModelPropertyFlags Flags => this.flags;

        public ImmutableArray<ModelProperty> EquivalentProperties => this.equivalentProperties;
        public ImmutableArray<Slot> SupersetSlots => this.supersetSlots;
        public ImmutableArray<Slot> SubsetSlots => this.subsetSlots;
        public ImmutableArray<Slot> SubsettedSlots => this.subsettedSlots;
        public ImmutableArray<Slot> SubsettingSlots => this.subsettingSlots;
        public ImmutableArray<Slot> DerivedUnionSlots => this.derivedUnionSlots;
        public ImmutableArray<ModelProperty> OppositeProperties => this.oppositeProperties;

        public Type ImmutableType => this.effectiveProperty.ImmutableType;
        public Type MutableType => this.effectiveProperty.MutableType;

        public object DefaultValue => this.effectiveProperty.DefaultValue;

        public bool IsModelObject => this.flags.HasFlag(ModelPropertyFlags.ModelObject);
        public bool IsCollection => this.flags.HasFlag(ModelPropertyFlags.Collection);
        public bool IsReadonly => this.flags.HasFlag(ModelPropertyFlags.Readonly);
        public bool IsDerived => this.flags.HasFlag(ModelPropertyFlags.Derived);
        public bool IsDerivedUnion => this.flags.HasFlag(ModelPropertyFlags.DerivedUnion);
        public bool IsNonNull => this.flags.HasFlag(ModelPropertyFlags.NonNull);
        public bool IsUnique => !this.flags.HasFlag(ModelPropertyFlags.NonUnique);
        public bool IsOrdered => this.flags.HasFlag(ModelPropertyFlags.Ordered);
        public bool IsContainment => this.flags.HasFlag(ModelPropertyFlags.Containment);

        public bool IsAssignableFrom(Type type, out ModelProperty unassignableProperty)
        {
            foreach (var eqProp in this.equivalentProperties)
            {
                if (!eqProp.ImmutableType.IsAssignableFrom(type) && !eqProp.MutableType.IsAssignableFrom(type))
                {
                    unassignableProperty = eqProp;
                    return false;
                }
            }
            unassignableProperty = null;
            return true;
        }

        public override string ToString()
        {
            return this.effectiveProperty.ToString();
        }
    }


}

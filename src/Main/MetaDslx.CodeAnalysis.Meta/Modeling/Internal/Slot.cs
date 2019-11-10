using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal interface Slot
    {
        bool IsSimpleSlot { get; }
        ModelProperty EffectiveProperty { get; }
        string Name { get; }

        bool IsModelObject { get; }
        bool IsCollection { get; }
        bool IsReadonly { get; }
        bool IsDerived { get; }
        bool IsDerivedUnion { get; }
        bool IsContainment { get; }
        bool IsNonNull { get; }
        bool IsUnique { get; }
        object DefaultValue { get; }
        Type ImmutableType { get; }
        Type MutableType { get; }

        ImmutableArray<ModelProperty> EquivalentProperties { get; }
        ImmutableArray<Slot> SupersetSlots { get; }
        ImmutableArray<Slot> SubsetSlots { get; }
        ImmutableArray<Slot> SubsettedSlots { get; }
        ImmutableArray<Slot> SubsettingSlots { get; }
        ImmutableArray<Slot> DerivedUnionSlots { get; }
        ImmutableArray<ModelProperty> OppositeProperties { get; }

        bool IsAssignableFrom(Type type, out ModelProperty unassignableProperty);
    }

}

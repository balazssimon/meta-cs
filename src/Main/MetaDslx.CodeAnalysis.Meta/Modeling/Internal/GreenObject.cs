using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class GreenObject
    {
        internal static readonly GreenObject Empty = new GreenObject();
        internal static readonly object Unassigned = new object();

        private ObjectId parent;
        private ImmutableList<ObjectId> children;
        private ImmutableDictionary<Slot, object> slots;

        private GreenObject()
        {
            this.children = ImmutableList<ObjectId>.Empty;
            this.slots = ImmutableDictionary<Slot, object>.Empty;
        }

        private GreenObject(
            ObjectId parent,
            ImmutableList<ObjectId> children,
            ImmutableDictionary<Slot, object> slots)
        {
            this.parent = parent;
            this.children = children;
            this.slots = slots;
        }

        internal GreenObject Update(
            ObjectId parent,
            ImmutableList<ObjectId> children,
            ImmutableDictionary<Slot, object> slots)
        {
            if (this.parent != parent || this.children != children || this.slots != slots)
            {
                return new GreenObject(parent, children, slots);
            }
            return this;
        }

        internal static GreenObject CreateWithSlots(ImmutableArray<Slot> slots)
        {
            return GreenObject.Empty.Update(
                null,
                ImmutableList<ObjectId>.Empty,
                slots.ToImmutableDictionary(s => s, s => GreenObject.Unassigned));
        }

        internal ObjectId Parent { get { return this.parent; } }
        internal ImmutableList<ObjectId> Children { get { return this.children; } }
        internal ImmutableDictionary<Slot, object> Slots { get { return this.slots; } }
    }

}

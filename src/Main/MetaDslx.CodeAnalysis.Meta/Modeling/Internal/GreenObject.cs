using MetaDslx.CodeAnalysis;
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

        public static bool Equals(object left, object right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (left == null && right == null) return true;
            var leftValue = ExtractValue(left);
            var rightValue = ExtractValue(right);
            return object.Equals(leftValue, rightValue);
        }

        public static bool EqualsWithTag(object left, object right)
        {
            if (object.ReferenceEquals(left, right)) return true;
            if (left == null && right == null) return true;
            var leftValue = left;
            object leftTag = null;
            if (left is GreenValueWithTag taggedLeft)
            {
                leftValue = taggedLeft.Value;
                leftTag = taggedLeft.Tag;
            }
            var rightValue = right;
            object rightTag = null;
            if (right is GreenValueWithTag taggedRight)
            {
                rightValue = taggedRight.Value;
                rightTag = taggedRight.Tag;
            }
            return object.Equals(leftValue, rightValue) && object.Equals(leftTag, rightTag);
        }

        public static object ExtractValue(object obj)
        {
            if (obj is GreenValueWithTag taggedValue) return taggedValue.Value;
            else return obj;
        }

        public static object ExtractTag(object obj)
        {
            if (obj is GreenValueWithTag taggedValue) return taggedValue.Tag;
            else if (obj is LazyValue lazyValue) return lazyValue.Tag;
            else return null;
        }

        public static Location ExtractLocation(object tag)
        {
            if (tag is Location location) return location;
            else return Location.None;
        }
    }

}

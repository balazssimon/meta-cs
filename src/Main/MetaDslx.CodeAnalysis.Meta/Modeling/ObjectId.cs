using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public abstract class ObjectId
    {
        private readonly string id;
        public ObjectId()
        {
            this.id = Guid.NewGuid().ToString();
        }
        public string Id { get { return this.id; } }
        public abstract ModelObjectDescriptor Descriptor { get; }
        public abstract ImmutableObjectBase CreateImmutable(ImmutableModel model);
        public abstract MutableObjectBase CreateMutable(MutableModel model, bool creating);
        public string DisplayTypeName => this.Descriptor?.ImmutableType?.Name;

        public static bool operator ==(ObjectId left, ObjectId right)
        {
            if ((object)left == null) return (object)right == null;
            else return left.Equals(right);
        }

        public static bool operator !=(ObjectId left, ObjectId right)
        {
            if ((object)left == null) return (object)right != null;
            else return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (obj is ObjectId other)
            {
                return this.id == other.id && object.ReferenceEquals(this.Descriptor, other.Descriptor);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.id.GetHashCode(), this.Descriptor.GetHashCode());
        }

        public override string ToString()
        {
            return $"{this.DisplayTypeName} {{{this.id}}}";
        }
    }
}

using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal sealed class GreenLazyEvalEntry : IEquatable<GreenLazyEvalEntry>
    {
        private ObjectId objectId;
        private ModelProperty property;

        public GreenLazyEvalEntry(ObjectId objectId, ModelProperty property)
        {
            this.objectId = objectId;
            this.property = property;
        }

        public ObjectId ObjectId { get { return this.objectId; } }
        public ModelProperty Property { get { return this.property; } }

        public bool Equals(GreenLazyEvalEntry other)
        {
            if (other == null) return false;
            return this.objectId == other.objectId && this.property == other.property;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as GreenLazyEvalEntry);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.objectId.GetHashCode(), this.property.GetHashCode());
        }
    }

}

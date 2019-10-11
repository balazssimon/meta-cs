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
        private ImmutableDictionary<ModelProperty, object> properties;

        private GreenObject()
        {
            this.children = ImmutableList<ObjectId>.Empty;
            this.properties = ImmutableDictionary<ModelProperty, object>.Empty;
        }

        private GreenObject(
            ObjectId parent,
            ImmutableList<ObjectId> children,
            ImmutableDictionary<ModelProperty, object> properties)
        {
            this.parent = parent;
            this.children = children;
            this.properties = properties;
        }

        internal GreenObject Update(
            ObjectId parent,
            ImmutableList<ObjectId> children,
            ImmutableDictionary<ModelProperty, object> properties)
        {
            if (this.parent != parent || this.children != children || this.properties != properties)
            {
                return new GreenObject(parent, children, properties);
            }
            return this;
        }

        internal static GreenObject CreateWithProperties(ImmutableArray<ModelProperty> properties)
        {
            return GreenObject.Empty.Update(
                null,
                ImmutableList<ObjectId>.Empty,
                properties.ToImmutableDictionary(p => p, p => GreenObject.Unassigned));
        }

        internal ObjectId Parent { get { return this.parent; } }
        internal ImmutableList<ObjectId> Children { get { return this.children; } }
        internal ImmutableDictionary<ModelProperty, object> Properties { get { return this.properties; } }
    }

}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class GreenSymbol
    {
        internal static readonly GreenSymbol Empty = new GreenSymbol();
        internal static readonly object Unassigned = new Unassigned();

        private SymbolId parent;
        private ImmutableList<SymbolId> children;
        private ImmutableDictionary<ModelProperty, object> properties;

        private GreenSymbol()
        {
            this.children = ImmutableList<SymbolId>.Empty;
            this.properties = ImmutableDictionary<ModelProperty, object>.Empty;
        }

        private GreenSymbol(
            SymbolId parent,
            ImmutableList<SymbolId> children,
            ImmutableDictionary<ModelProperty, object> properties)
        {
            this.parent = parent;
            this.children = children;
            this.properties = properties;
        }

        internal GreenSymbol Update(
            SymbolId parent,
            ImmutableList<SymbolId> children,
            ImmutableDictionary<ModelProperty, object> properties)
        {
            if (this.parent != parent || this.children != children || this.properties != properties)
            {
                return new GreenSymbol(parent, children, properties);
            }
            return this;
        }

        internal static GreenSymbol CreateWithProperties(ImmutableArray<ModelProperty> properties)
        {
            return GreenSymbol.Empty.Update(
                null,
                ImmutableList<SymbolId>.Empty,
                properties.ToImmutableDictionary(p => p, p => GreenSymbol.Unassigned));
        }

        internal SymbolId Parent { get { return this.parent; } }
        internal ImmutableList<SymbolId> Children { get { return this.children; } }
        internal ImmutableDictionary<ModelProperty, object> Properties { get { return this.properties; } }
    }

}

using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal sealed class GreenLazyEvalEntry : IEquatable<GreenLazyEvalEntry>
    {
        private SymbolId symbol;
        private ModelProperty property;

        public GreenLazyEvalEntry(SymbolId symbol, ModelProperty property)
        {
            this.symbol = symbol;
            this.property = property;
        }

        public SymbolId Symbol { get { return this.symbol; } }
        public ModelProperty Property { get { return this.property; } }

        public bool Equals(GreenLazyEvalEntry other)
        {
            if (other == null) return false;
            return this.symbol == other.symbol && this.property == other.property;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as GreenLazyEvalEntry);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.symbol.GetHashCode(), this.property.GetHashCode());
        }
    }

}

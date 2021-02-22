using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class GreenValueWithTag : IEquatable<GreenValueWithTag>
    {
        private object value;
        private object tag;

        internal GreenValueWithTag(object value, object tag)
        {
            this.value = value;
            this.tag = tag;
        }

        public object Value => value;

        public object Tag => tag;

        public override bool Equals(object obj)
        {
            if (obj is GreenValueWithTag valueWithLocation)
            {
                return this.Equals(valueWithLocation);
            }
            return false;
        }

        public bool Equals(GreenValueWithTag other)
        {
            if (other == null) return false;
            return object.Equals(value, other.value) && object.Equals(tag, other.tag);
        }

    }
}

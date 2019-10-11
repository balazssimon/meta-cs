using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class SingleLazyValueWithLocation<T> : SingleLazyValue<T>
    {
        private Location location;

        internal SingleLazyValueWithLocation(Func<T> lazy, Location location)
            : base(lazy)
        {
            this.location = location;
        }

        internal override Location Location
        {
            get { return this.location; }
        }
    }

}

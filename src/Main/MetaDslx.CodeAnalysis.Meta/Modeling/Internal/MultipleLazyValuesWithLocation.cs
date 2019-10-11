using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValuesWithLocation<T> : MultipleLazyValues<T>
    {
        private Location location;

        internal MultipleLazyValuesWithLocation(Func<IEnumerable<T>> lazy, Location location)
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

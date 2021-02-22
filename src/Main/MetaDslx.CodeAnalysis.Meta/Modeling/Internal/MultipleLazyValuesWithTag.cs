using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValuesWithTag<T> : MultipleLazyValues<T>
    {
        private object tag;

        internal MultipleLazyValuesWithTag(Func<IEnumerable<T>> lazy, object tag)
            : base(lazy)
        {
            this.tag = tag;
        }

        internal override object Tag
        {
            get { return this.tag; }
        }
    }

}

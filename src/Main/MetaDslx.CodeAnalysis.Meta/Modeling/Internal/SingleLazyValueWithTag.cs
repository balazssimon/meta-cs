using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class SingleLazyValueWithTag<T> : SingleLazyValue<T>
    {
        private object tag;

        internal SingleLazyValueWithTag(Func<T> lazy, object tag)
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

using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class SingleLazyValue<T> : LazyValue
    {
        private Func<T> lazy;

        internal SingleLazyValue(Func<T> lazy)
        {
            this.lazy = lazy;
        }

        internal override object LazyConstructor => this.Lazy;

        internal Func<T> Lazy
        {
            get { return this.lazy; }
        }

        internal protected override object CreateRedValue()
        {
            return lazy();
        }

    }
}

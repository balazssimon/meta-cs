using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class SingleLazyValue : LazyValue
    {
        private Func<object> lazy;

        internal SingleLazyValue(Func<object> lazy)
        {
            this.lazy = lazy;
        }

        internal Func<object> Lazy
        {
            get { return this.lazy; }
        }

        internal protected override object CreateRedValue()
        {
            return lazy();
        }

    }
}

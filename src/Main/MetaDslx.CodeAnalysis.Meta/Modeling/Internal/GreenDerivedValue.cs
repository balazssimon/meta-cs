using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal sealed class GreenDerivedValue
    {
        private LazyValue lazy;

        internal GreenDerivedValue(LazyValue lazy)
        {
            this.lazy = lazy;
        }

        internal LazyValue Lazy
        {
            get { return this.lazy; }
        }

        internal object CreateRedValue()
        {
            return lazy.CreateRedValue();
        }
    }
}

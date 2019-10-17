using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal sealed class GreenDerivedValue
    {
        private LazyValue lazy;

        public GreenDerivedValue(LazyValue lazy)
        {
            this.lazy = lazy;
        }

        public LazyValue Lazy
        {
            get { return this.lazy; }
        }

        public object CreateRedValue(IModel model, ObjectId context)
        {
            return lazy.CreateRedValue(model, context);
        }
    }
}

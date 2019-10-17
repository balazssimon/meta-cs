using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class SingleLazyValue<T> : LazyValue<T>
    {
        private Func<T> lazy;

        internal SingleLazyValue(Func<T> lazy)
        {
            this.lazy = lazy;
        }

        internal override object LazyConstructor => this.lazy;

        internal protected override T CreateTypedRedValue(IModel model, ObjectId context)
        {
            return lazy();
        }

    }
}

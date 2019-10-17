using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValues<T> : LazyValue<T>
    {
        private Func<IEnumerable<T>> lazy;

        internal MultipleLazyValues(Func<IEnumerable<T>> lazy)
        {
            this.lazy = lazy;
        }

        internal override bool IsSingleValue => false;

        internal override object LazyConstructor => this.lazy;

        internal protected override T[] CreateTypedRedValues(IModel model, ObjectId context)
        {
            return lazy()?.ToArray() ?? EmptyArray<T>.Instance;
        }
    }
}

using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValues<T> : LazyValue
    {
        private Func<IEnumerable<T>> lazy;

        internal MultipleLazyValues(Func<IEnumerable<T>> lazy)
        {
            this.lazy = lazy;
        }

        internal override bool IsSingleValue
        {
            get { return false; }
        }

        internal override object LazyConstructor => this.Lazy;

        internal Func<IEnumerable<T>> Lazy
        {
            get { return this.lazy; }
        }

        internal protected override object[] CreateRedValues()
        {
            return lazy()?.Cast<object>().ToArray() ?? EmptyArray<object>.Instance;
        }
    }
}

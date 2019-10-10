using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValues : LazyValue
    {
        private Func<IEnumerable<object>> lazy;

        internal MultipleLazyValues(Func<IEnumerable<object>> lazy)
        {
            this.lazy = lazy;
        }

        internal override bool IsSingleValue
        {
            get { return false; }
        }

        internal Func<IEnumerable<object>> Lazy
        {
            get { return this.lazy; }
        }

        internal protected override object[] CreateRedValues()
        {
            return lazy()?.ToArray() ?? EmptyArray<object>.Instance;
        }
    }
}

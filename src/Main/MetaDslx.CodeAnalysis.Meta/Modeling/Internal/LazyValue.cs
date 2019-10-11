using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    public abstract class LazyValue
    {
        internal LazyValue()
        {

        }

        internal abstract object LazyConstructor { get; }

        internal virtual bool IsSingleValue
        {
            get { return true; }
        }

        internal virtual Location Location
        {
            get { return Location.None; }
        }

        internal protected virtual object CreateRedValue()
        {
            return null;
        }

        internal protected virtual object[] CreateRedValues()
        {
            return EmptyArray<object>.Instance;
        }

        internal object CreateGreenValue()
        {
            object value = this.CreateRedValue();
            if (value is MutableObjectBase)
            {
                return ((MutableObjectBase)value).MId;
            }
            else if (value is ImmutableObjectBase)
            {
                return ((ImmutableObjectBase)value).MId;
            }
            return value;
        }

        internal object[] CreateGreenValues()
        {
            var values = this.CreateRedValues();
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                if (value is MutableObjectBase)
                {
                    values[i] = ((MutableObjectBase)value).MId;
                }
                else if (value is ImmutableObjectBase)
                {
                    values[i] = ((ImmutableObjectBase)value).MId;
                }
            }
            return values;
        }

        public static LazyValue Create<T>(Func<T> lazy, Location location = null)
        {
            return object.ReferenceEquals(location, null) ? new SingleLazyValue<T>(lazy) : new SingleLazyValueWithLocation<T>(lazy, location);
        }

        public static LazyValue CreateMulti<T>(Func<IEnumerable<T>> lazy, Location location = null)
        {
            return object.ReferenceEquals(location, null) ? new MultipleLazyValues<T>(lazy) : new MultipleLazyValuesWithLocation<T>(lazy, location);
        }

        public static IEnumerable<LazyValue> CreateMulti<T>(IEnumerable<Func<T>> lazy, Location location = null)
        {
            return lazy.Select(l => Create(l, location));
        }
    }

}

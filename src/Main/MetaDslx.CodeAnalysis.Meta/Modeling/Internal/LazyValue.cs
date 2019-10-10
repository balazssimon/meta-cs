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

        internal virtual bool IsSingleValue
        {
            get { return true; }
        }

        internal virtual DiagnosticBag Diagnostics
        {
            get { return null; }
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
            if (value is MutableSymbolBase)
            {
                return ((MutableSymbolBase)value).MId;
            }
            else if (value is ImmutableSymbolBase)
            {
                return ((ImmutableSymbolBase)value).MId;
            }
            return value;
        }

        internal object[] CreateGreenValues()
        {
            var values = this.CreateRedValues();
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                if (value is MutableSymbolBase)
                {
                    values[i] = ((MutableSymbolBase)value).MId;
                }
                else if (value is ImmutableSymbolBase)
                {
                    values[i] = ((ImmutableSymbolBase)value).MId;
                }
            }
            return values;
        }

        public static LazyValue Create(Func<object> lazy)
        {
            return new SingleLazyValue(lazy);
        }

        public static LazyValue Create(Func<object> lazy, Location location, DiagnosticBag diagnostics)
        {
            return new SingleLazyValueWithLocation(lazy, location, diagnostics);
        }

        public static LazyValue CreateMultiple(Func<IEnumerable<object>> lazy)
        {
            return new MultipleLazyValues(lazy);
        }

        public static LazyValue CreateMultiple(Func<IEnumerable<object>> lazy, Location location, DiagnosticBag diagnostics)
        {
            return new MultipleLazyValuesWithLocation(lazy, location, diagnostics);
        }

        public static IEnumerable<LazyValue> CreateMultiple(IEnumerable<Func<object>> lazy)
        {
            return lazy.Select(l => Create(l));
        }

        public static IEnumerable<LazyValue> CreateMultiple(IEnumerable<Func<object>> lazy, Location location, DiagnosticBag diagnostics)
        {
            return lazy.Select(l => Create(l, location, diagnostics));
        }
    }

}

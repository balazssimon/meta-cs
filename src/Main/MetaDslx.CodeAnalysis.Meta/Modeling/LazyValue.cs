using MetaDslx.Modeling.Internal;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling
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

        internal virtual bool HasContext
        {
            get { return false; }
        }

        internal virtual Location Location
        {
            get { return Location.None; }
        }

        internal protected virtual object CreateRedValue(IModel model, ObjectId context)
        {
            return null;
        }

        internal protected virtual object[] CreateRedValues(IModel model, ObjectId context)
        {
            return EmptyArray<object>.Instance;
        }

        internal object CreateGreenValue(IModel model, ObjectId context)
        {
            object value = this.CreateRedValue(model, context);
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

        internal object[] CreateGreenValues(IModel model, ObjectId context)
        {
            var values = this.CreateRedValues(model, context);
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

        public static LazyValue<T> Create<T>(Func<T> lazy, Location location = null)
        {
            return object.ReferenceEquals(location, null) ? new SingleLazyValue<T>(lazy) : new SingleLazyValueWithLocation<T>(lazy, location);
        }

        public static LazyValue<T> CreateMulti<T>(Func<IEnumerable<T>> lazy, Location location = null)
        {
            return object.ReferenceEquals(location, null) ? new MultipleLazyValues<T>(lazy) : new MultipleLazyValuesWithLocation<T>(lazy, location);
        }

        public static IEnumerable<LazyValue<T>> CreateMulti<T>(IEnumerable<Func<T>> lazy, Location location = null)
        {
            return lazy.Select(l => Create(l, location));
        }

        public static LazyValue<T> Create<TContext, T>(Func<TContext, T> lazy, Location location = null)
            where TContext: IModelObject
        {
            return object.ReferenceEquals(location, null) ? new SingleLazyValueWithContext<TContext, T>(lazy) : new SingleLazyValueWithContextAndLocation<TContext, T>(lazy, location);
        }

        public static LazyValue<T> CreateMulti<TContext, T>(Func<TContext, IEnumerable<T>> lazy, Location location = null)
            where TContext : IModelObject
        {
            return object.ReferenceEquals(location, null) ? new MultipleLazyValuesWithContext<TContext, T>(lazy) : new MultipleLazyValuesWithContextAndLocation<TContext, T>(lazy, location);
        }

        public static IEnumerable<LazyValue<T>> CreateMulti<TContext, T>(IEnumerable<Func<TContext, T>> lazy, Location location = null)
            where TContext : IModelObject
        {
            return lazy.Select(l => Create(l, location));
        }

        public static LazyValue Create<TImmutableContext, TMutableContext, TImmutable, TMutable>(Func<TImmutableContext, TImmutable> immutableLazy, Func<TMutableContext, TMutable> mutableLazy, Location location = null)
            where TImmutableContext : ImmutableObject
            where TMutableContext : MutableObject
        {
            return object.ReferenceEquals(location, null) ? new SingleLazyValueWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>(immutableLazy, mutableLazy) : new SingleLazyValueWithContextAndLocation<TImmutableContext, TMutableContext, TImmutable, TMutable>(immutableLazy, mutableLazy, location);
        }

        public static LazyValue CreateMulti<TImmutableContext, TMutableContext, TImmutable, TMutable>(Func<TImmutableContext, IEnumerable<TImmutable>> immutableLazy, Func<TMutableContext, IEnumerable<TMutable>> mutableLazy, Location location = null)
            where TImmutableContext : ImmutableObject
            where TMutableContext : MutableObject
        {
            return object.ReferenceEquals(location, null) ? new MultipleLazyValuesWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>(immutableLazy, mutableLazy) : new MultipleLazyValuesWithContextAndLocation<TImmutableContext, TMutableContext, TImmutable, TMutable>(immutableLazy, mutableLazy, location);
        }
    }

    public abstract class LazyValue<T> : LazyValue
    {
        protected internal override object CreateRedValue(IModel model, ObjectId context)
        {
            return this.CreateTypedRedValue(model, context);
        }

        protected internal override object[] CreateRedValues(IModel model, ObjectId context)
        {
            return Array.ConvertAll(this.CreateTypedRedValues(model, context), item => (object)item); 
        }

        internal protected virtual T CreateTypedRedValue(IModel model, ObjectId context)
        {
            return default(T);
        }

        internal protected virtual T[] CreateTypedRedValues(IModel model, ObjectId context)
        {
            return EmptyArray<T>.Instance;
        }
    }
}

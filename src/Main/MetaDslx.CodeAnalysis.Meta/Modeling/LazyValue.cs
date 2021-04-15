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

        internal virtual object Tag
        {
            get { return null; }
        }

        internal Location GetLocation()
        {
            if (this.Tag is Location location) return location;
            else return Location.None;
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
            return MutableModel.ToGreenValue(value, this.Tag);
        }

        internal object[] CreateGreenValues(IModel model, ObjectId context)
        {
            var values = this.CreateRedValues(model, context);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = MutableModel.ToGreenValue(values[i], this.Tag);
            }
            return values;
        }

        public static LazyValue<T> Create<T>(Func<T> lazy, object tag = null)
        {
            return tag == null ? new SingleLazyValue<T>(lazy) : new SingleLazyValueWithTag<T>(lazy, tag);
        }

        public static LazyValue<T> CreateMulti<T>(Func<IEnumerable<T>> lazy, object tag = null)
        {
            return tag == null ? new MultipleLazyValues<T>(lazy) : new MultipleLazyValuesWithTag<T>(lazy, tag);
        }

        public static IEnumerable<LazyValue<T>> CreateMulti<T>(IEnumerable<Func<T>> lazy, object tag = null)
        {
            return lazy.Select(l => Create(l, tag));
        }

        public static LazyValue<T> Create<TContext, T>(Func<TContext, T> lazy, object tag = null)
            where TContext: IModelObject
        {
            return tag == null ? new SingleLazyValueWithContext<TContext, T>(lazy) : new SingleLazyValueWithContextAndTag<TContext, T>(lazy, tag);
        }

        public static LazyValue<T> CreateMulti<TContext, T>(Func<TContext, IEnumerable<T>> lazy, object tag = null)
            where TContext : IModelObject
        {
            return tag == null ? new MultipleLazyValuesWithContext<TContext, T>(lazy) : new MultipleLazyValuesWithContextAndTag<TContext, T>(lazy, tag);
        }

        public static IEnumerable<LazyValue<T>> CreateMulti<TContext, T>(IEnumerable<Func<TContext, T>> lazy, object tag = null)
            where TContext : IModelObject
        {
            return lazy.Select(l => Create(l, tag));
        }

        public static LazyValue Create<TImmutableContext, TMutableContext, TImmutable, TMutable>(Func<TImmutableContext, TImmutable> immutableLazy, Func<TMutableContext, TMutable> mutableLazy, object tag = null)
            where TImmutableContext : ImmutableObject
            where TMutableContext : MutableObject
        {
            return tag == null ? new SingleLazyValueWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>(immutableLazy, mutableLazy) : new SingleLazyValueWithContextAndTag<TImmutableContext, TMutableContext, TImmutable, TMutable>(immutableLazy, mutableLazy, tag);
        }

        public static LazyValue CreateMulti<TImmutableContext, TMutableContext, TImmutable, TMutable>(Func<TImmutableContext, IEnumerable<TImmutable>> immutableLazy, Func<TMutableContext, IEnumerable<TMutable>> mutableLazy, object tag = null)
            where TImmutableContext : ImmutableObject
            where TMutableContext : MutableObject
        {
            return tag == null ? new MultipleLazyValuesWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>(immutableLazy, mutableLazy) : new MultipleLazyValuesWithContextAndTag<TImmutableContext, TMutableContext, TImmutable, TMutable>(immutableLazy, mutableLazy, tag);
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

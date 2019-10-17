using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValuesWithContext<TContext, T> : LazyValueWithContext<TContext, T>
        where TContext : IModelObject
    {
        private Func<TContext, IEnumerable<T>> lazy;

        internal MultipleLazyValuesWithContext(Func<TContext, IEnumerable<T>> lazy)
        {
            this.lazy = lazy;
        }

        internal override bool IsSingleValue => false;

        internal override object LazyConstructor => this.lazy;

        internal protected override T[] CreateTypedRedValues(IModel model, ObjectId context)
        {
            return lazy(this.GetContext(model, context)).ToArray();
        }
    }

    internal class MultipleLazyValuesWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable> : LazyValueWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>
        where TImmutableContext : ImmutableObject
        where TMutableContext : MutableObject
    {
        private Func<TImmutableContext, IEnumerable<TImmutable>> immutableLazy;
        private Func<TMutableContext, IEnumerable<TMutable>> mutableLazy;

        internal MultipleLazyValuesWithContext(Func<TImmutableContext, IEnumerable<TImmutable>> immutableLazy, Func<TMutableContext, IEnumerable<TMutable>> mutableLazy)
        {
            this.immutableLazy = immutableLazy;
            this.mutableLazy = mutableLazy;
        }

        internal override bool IsSingleValue => false;

        internal override object LazyConstructor => this.mutableLazy;

        internal protected override object[] CreateRedValues(IModel model, ObjectId context)
        {
            if (model is MutableModel mutableM)
            {
                var redContext = mutableM.ResolveObject(context);
                return Array.ConvertAll(this.mutableLazy((TMutableContext)redContext).ToArray(), item => (object)item);
            }
            else if (model is ImmutableModel immutableM)
            {
                var redContext = immutableM.ResolveObject(context);
                return Array.ConvertAll(this.immutableLazy((TImmutableContext)redContext).ToArray(), item => (object)item);
            }
            Debug.Assert(false);
            return default;
        }
    }
}

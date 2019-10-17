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

    internal class MultipleLazyValuesWithContext<TImmutableContext, TMutableContext, T> : LazyValueWithContext<TImmutableContext, TMutableContext, T>
        where TImmutableContext : ImmutableObject
        where TMutableContext : MutableObject
    {
        private Func<TImmutableContext, IEnumerable<T>> immutableLazy;
        private Func<TMutableContext, IEnumerable<T>> mutableLazy;

        internal MultipleLazyValuesWithContext(Func<TImmutableContext, IEnumerable<T>> immutableLazy, Func<TMutableContext, IEnumerable<T>> mutableLazy)
        {
            this.immutableLazy = immutableLazy;
            this.mutableLazy = mutableLazy;
        }

        internal override bool IsSingleValue => false;

        internal override object LazyConstructor => this.mutableLazy;

        internal protected override T[] CreateTypedRedValues(IModel model, ObjectId context)
        {
            if (model is MutableModel mutableM)
            {
                var redContext = mutableM.ResolveObject(context);
                return this.mutableLazy((TMutableContext)redContext).ToArray();
            }
            else if (model is ImmutableModel immutableM)
            {
                var redContext = immutableM.ResolveObject(context);
                return this.immutableLazy((TImmutableContext)redContext).ToArray();
            }
            Debug.Assert(false);
            return default;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class SingleLazyValueWithContext<TContext, T> : LazyValueWithContext<TContext, T>
        where TContext: IModelObject
    {
        private Func<TContext, T> lazy;

        internal SingleLazyValueWithContext(Func<TContext, T> lazy)
        {
            this.lazy = lazy;
        }

        internal override object LazyConstructor => this.lazy;

        internal protected override T CreateTypedRedValue(IModel model, ObjectId context)
        {
            return lazy(this.GetContext(model, context));
        }
    }

    internal class SingleLazyValueWithContext<TImmutableContext, TMutableContext, T> : LazyValueWithContext<TImmutableContext, TMutableContext, T>
        where TImmutableContext : ImmutableObject
        where TMutableContext : MutableObject
    {
        private Func<TImmutableContext, T> immutableLazy;
        private Func<TMutableContext, T> mutableLazy;

        internal SingleLazyValueWithContext(Func<TImmutableContext, T> immutableLazy, Func<TMutableContext, T> mutableLazy)
        {
            this.immutableLazy = immutableLazy;
            this.mutableLazy = mutableLazy;
        }

        internal override object LazyConstructor => this.mutableLazy;

        internal protected override T CreateTypedRedValue(IModel model, ObjectId context)
        {
            if (model is MutableModel mutableM)
            {
                var redContext = mutableM.ResolveObject(context);
                return this.mutableLazy((TMutableContext)redContext);
            }
            else if (model is ImmutableModel immutableM)
            {
                var redContext = immutableM.ResolveObject(context);
                return this.immutableLazy((TImmutableContext)redContext);
            }
            Debug.Assert(false);
            return default;
        }
    }
}

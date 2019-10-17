using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal abstract class LazyValueWithContext<TContext, T> : LazyValue<T>
        where TContext: IModelObject
    {
        internal override bool HasContext => true;

        protected TContext GetContext(IModel model, ObjectId context)
        {
            if (typeof(MutableObject).IsAssignableFrom(typeof(TContext)))
            {
                if (model is MutableModel mutableM)
                {
                    return (TContext)mutableM.ResolveObject(context);
                }
                else if (model is ImmutableModel immutableM)
                {
                    return (TContext)immutableM.ResolveObject(context)?.ToMutable();
                }
            }
            else if (typeof(ImmutableObject).IsAssignableFrom(typeof(TContext)))
            {
                if (model is MutableModel mutableM)
                {
                    return (TContext)mutableM.ResolveObject(context)?.ToImmutable();
                }
                else if (model is ImmutableModel immutableM)
                {
                    return (TContext)immutableM.ResolveObject(context);
                }
            }
            Debug.Assert(false);
            return default;
        }
    }

    internal abstract class LazyValueWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable> : LazyValue
        where TImmutableContext : ImmutableObject
        where TMutableContext : MutableObject
    {

        internal override bool HasContext => true;

    }
}

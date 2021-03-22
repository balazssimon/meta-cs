using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValuesWithContextAndTag<TContext, T> : MultipleLazyValuesWithContext<TContext, T>
        where TContext : IModelObject
    {
        private object tag;

        internal MultipleLazyValuesWithContextAndTag(Func<TContext, IEnumerable<T>> lazy, object tag)
            : base(lazy)
        {
            this.tag = tag;
        }

        internal override object Tag
        {
            get { return this.tag; }
        }
    }

    internal class MultipleLazyValuesWithContextAndTag<TImmutableContext, TMutableContext, TImmutable, TMutable> : MultipleLazyValuesWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>
        where TImmutableContext : ImmutableObject
        where TMutableContext : MutableObject
    {
        private object tag;

        internal MultipleLazyValuesWithContextAndTag(Func<TImmutableContext, IEnumerable<TImmutable>> immutableLazy, Func<TMutableContext, IEnumerable<TMutable>> mutableLazy, object tag)
            : base(immutableLazy, mutableLazy)
        {
            this.tag = tag;
        }

        internal override object Tag
        {
            get { return this.tag; }
        }
    }
}

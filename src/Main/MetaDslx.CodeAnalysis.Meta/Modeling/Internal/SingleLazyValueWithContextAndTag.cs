using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class SingleLazyValueWithContextAndTag<TContext, T> : SingleLazyValueWithContext<TContext, T>
        where TContext: IModelObject
    {
        private object tag;

        internal SingleLazyValueWithContextAndTag(Func<TContext, T> lazy, object tag)
            : base(lazy)
        {
            this.tag = tag;
        }

        internal override object Tag
        {
            get { return this.tag; }
        }
    }

    internal class SingleLazyValueWithContextAndTag<TImmutableContext, TMutableContext, TImmutable, TMutable> : SingleLazyValueWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>
        where TImmutableContext : ImmutableObject
        where TMutableContext : MutableObject
    {
        private object tag;

        internal SingleLazyValueWithContextAndTag(Func<TImmutableContext, TImmutable> immutableLazy, Func<TMutableContext, TMutable> mutableLazy, object tag)
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

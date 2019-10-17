using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class SingleLazyValueWithContextAndLocation<TContext, T> : SingleLazyValueWithContext<TContext, T>
        where TContext: IModelObject
    {
        private Location location;

        internal SingleLazyValueWithContextAndLocation(Func<TContext, T> lazy, Location location)
            : base(lazy)
        {
            this.location = location;
        }

        internal override Location Location
        {
            get { return this.location; }
        }
    }

    internal class SingleLazyValueWithContextAndLocation<TImmutableContext, TMutableContext, TImmutable, TMutable> : SingleLazyValueWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>
        where TImmutableContext : ImmutableObject
        where TMutableContext : MutableObject
    {
        private Location location;

        internal SingleLazyValueWithContextAndLocation(Func<TImmutableContext, TImmutable> immutableLazy, Func<TMutableContext, TMutable> mutableLazy, Location location)
            : base(immutableLazy, mutableLazy)
        {
            this.location = location;
        }

        internal override Location Location
        {
            get { return this.location; }
        }
    }
}

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValuesWithContextAndLocation<TContext, T> : MultipleLazyValuesWithContext<TContext, T>
        where TContext : IModelObject
    {
        private Location location;

        internal MultipleLazyValuesWithContextAndLocation(Func<TContext, IEnumerable<T>> lazy, Location location)
            : base(lazy)
        {
            this.location = location;
        }

        internal override Location Location
        {
            get { return this.location; }
        }
    }

    internal class MultipleLazyValuesWithContextAndLocation<TImmutableContext, TMutableContext, TImmutable, TMutable> : MultipleLazyValuesWithContext<TImmutableContext, TMutableContext, TImmutable, TMutable>
        where TImmutableContext : ImmutableObject
        where TMutableContext : MutableObject
    {
        private Location location;

        internal MultipleLazyValuesWithContextAndLocation(Func<TImmutableContext, IEnumerable<TImmutable>> immutableLazy, Func<TMutableContext, IEnumerable<TMutable>> mutableLazy, Location location)
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

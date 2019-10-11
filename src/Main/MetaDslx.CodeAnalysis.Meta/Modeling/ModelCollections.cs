using MetaDslx.Modeling.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Modeling
{
    public interface IModelCollection<out T> : IReadOnlyCollection<T>
    {
    }

    public interface IImmutableModelCollection<out T> : IModelCollection<T>
    {

    }

    public interface IMutableModelCollection<T> : IModelCollection<T>, ICollection<T>
    {

    }


    // TODO: Dictionary, Qualified...
}

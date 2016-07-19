using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableModelPrototype
{
    public sealed class ImmutableModelSet<T> //: IReadOnlyCollection<T>
    {
        internal ImmutableModelSet(GreenList green, ImmutableModel model)
        {

        }
    }

    public sealed class ImmutableModelList<T> //: IReadOnlyList<T>
    {
        internal ImmutableModelList(GreenList green, ImmutableModel model)
        {

        }
    }

    public sealed class MutableModelSet<T> //: ICollection<T>
    {
        internal MutableModelSet(GreenList green, ImmutableModel model)
        {

        }
    }

    public sealed class MutableModelList<T> //: IList<T>
    {
        internal MutableModelList(GreenList green, ImmutableModel model)
        {

        }
    }

    // TODO: Dictionary, Qualified...
}

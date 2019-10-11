using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface ImmutableObject : IModelObject
    {
        new ImmutableModel MModel { get; }
        new ImmutableObject MParent { get; }
        new ImmutableModelList<ImmutableObject> MChildren { get; }

        new ImmutableObject MType { get; }

        MutableObject ToMutable();
        MutableObject ToMutable(MutableModel mutableModel);
    }
}

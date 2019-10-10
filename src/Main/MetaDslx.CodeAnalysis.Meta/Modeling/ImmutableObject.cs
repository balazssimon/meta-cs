using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface ImmutableSymbol : IMetaSymbol
    {
        new ImmutableModel MModel { get; }
        new ImmutableSymbol MParent { get; }
        new ImmutableModelList<ImmutableSymbol> MChildren { get; }

        new ImmutableSymbol MType { get; }

        MutableSymbol ToMutable();
        MutableSymbol ToMutable(MutableModel mutableModel);
    }
}

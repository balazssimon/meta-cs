using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface IModelFactory
    {
        IMetaModel MMetaModel { get; }

        MutableModel MModel { get; }

        MutableObject Create(Type type);

        MutableObject Create(string type);
    }
}

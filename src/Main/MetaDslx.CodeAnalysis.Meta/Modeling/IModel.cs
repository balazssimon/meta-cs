using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface IModel
    {
        ModelId Id { get; }
        string Name { get; }
        ModelVersion Version { get; }
        IEnumerable<IMetaSymbol> Symbols { get; }
    }
}

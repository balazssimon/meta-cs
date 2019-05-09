using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public interface IMetaMetadataSymbol
    {
        MetaSymbolMap MetaSymbolMap { get; }
    }
}

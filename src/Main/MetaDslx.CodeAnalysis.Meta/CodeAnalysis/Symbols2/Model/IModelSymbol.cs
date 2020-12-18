using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public interface IModelSymbol
    {
        ModelSymbolMap ModelSymbolMap { get; }
        ModelObjectDescriptor ModelSymbolInfo { get; }
        Language Language { get; }
        IModelObject ModelObject { get; }
    }


}

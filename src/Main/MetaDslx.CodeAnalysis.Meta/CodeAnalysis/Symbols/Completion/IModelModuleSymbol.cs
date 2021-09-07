using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IModelModuleSymbol
    {
        object Model { get; }
        ObjectFactory ObjectFactory { get; }
    }
}

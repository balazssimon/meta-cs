﻿using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public interface IModelSymbol
    {
        SymbolFactory SymbolFactory { get; }
        object ModelObject { get; }
        Type ModelObjectType { get; }
    }


}
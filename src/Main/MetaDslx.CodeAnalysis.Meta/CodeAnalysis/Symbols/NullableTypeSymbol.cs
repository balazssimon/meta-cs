using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract class NullableTypeSymbol : TypeSymbol
    {
        [SymbolProperty]
        public virtual TypeSymbol InnerType { get; }
    }
}

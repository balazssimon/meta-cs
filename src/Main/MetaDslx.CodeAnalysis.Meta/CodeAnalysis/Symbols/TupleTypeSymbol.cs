using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class TupleTypeSymbol : NamedTypeSymbol
    {
        public override bool IsValueType => true;
    }
}

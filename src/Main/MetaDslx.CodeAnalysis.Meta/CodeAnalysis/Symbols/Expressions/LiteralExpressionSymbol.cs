using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class LiteralExpressionSymbol : ExpressionSymbol
    {
        [SymbolProperty]
        public abstract object? Value { get; }
    }
}

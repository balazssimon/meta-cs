using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ConditionalExpressionSymbol : ExpressionSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol IfTrue { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol IfFalse { get; }
    }
}

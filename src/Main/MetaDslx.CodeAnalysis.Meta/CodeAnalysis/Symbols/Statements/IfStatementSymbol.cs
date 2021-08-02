using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class IfStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        [SymbolProperty]
        public abstract StatementSymbol IfTrue { get; }

        [SymbolProperty]
        public abstract StatementSymbol? IfFalse { get; }
    }
}

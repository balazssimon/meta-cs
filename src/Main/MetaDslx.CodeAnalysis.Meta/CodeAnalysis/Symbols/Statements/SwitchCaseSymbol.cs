using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class SwitchCaseSymbol : NonDeclaredSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Value { get; }

        [SymbolProperty]
        public abstract StatementSymbol Body { get; }
    }
}

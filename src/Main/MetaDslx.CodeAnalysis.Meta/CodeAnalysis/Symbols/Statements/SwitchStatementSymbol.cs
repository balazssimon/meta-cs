using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class SwitchStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Test { get; }

        [SymbolProperty]
        public abstract ImmutableArray<SwitchCaseSymbol> Cases { get; }

    }
}

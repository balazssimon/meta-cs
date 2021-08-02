using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class TryStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

        [SymbolProperty]
        public abstract ImmutableArray<CatchClauseSymbol> Catches { get; }

        [SymbolProperty]
        public abstract StatementSymbol? Finally { get; }

        [SymbolProperty]
        public abstract LabelSymbol? ExitLabel { get; }
    }
}

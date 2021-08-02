using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class BlockStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract ImmutableArray<StatementSymbol> Statements { get; }
    }
}

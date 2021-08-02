using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ForLoopStatementSymbol : LoopStatementSymbol
    {
        [SymbolProperty]
        public abstract ImmutableArray<StatementSymbol> Before { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        [SymbolProperty]
        public abstract ImmutableArray<StatementSymbol> AtLoopBottom { get; }
    }
}

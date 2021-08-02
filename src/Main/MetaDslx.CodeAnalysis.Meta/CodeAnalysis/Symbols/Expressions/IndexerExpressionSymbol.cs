using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class IndexerExpressionSymbol : ExpressionSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Target { get; }

        [SymbolProperty]
        public abstract ImmutableArray<ExpressionSymbol> Arguments { get; }
    }
}

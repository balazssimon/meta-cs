using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an indexer access.
    /// </summary>
    [Symbol]
    public abstract partial class IndexerAccessExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// The indexed operation.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Operation { get; }

        /// <summary>
        /// Arguments, excluding the instance argument.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<ArgumentSymbol> Arguments { get; }

        /// <summary>
        /// Method or function to be invoked.
        /// </summary>
        public virtual IndexerSymbol? Target { get; }
    }
}

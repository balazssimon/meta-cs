using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a try operation for exception handling code with a body, catch clauses and a finally handler.
    /// </summary>
    [Symbol]
    public abstract partial class TryStatementSymbol : StatementSymbol
    {
        /// <summary>
        /// Body of the try, over which the handlers are active.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

        /// <summary>
        /// Catch clauses of the try.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<CatchClauseSymbol> Catches { get; }

        /// <summary>
        /// Finally handler of the try.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol? Finally { get; }

        /// <summary>
        /// Exit label for the try.
        /// </summary>
        [SymbolProperty]
        public abstract LabelSymbol? ExitLabel { get; }
    }
}

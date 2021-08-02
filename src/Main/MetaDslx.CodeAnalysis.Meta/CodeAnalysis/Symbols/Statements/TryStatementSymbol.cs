using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class TryStatementSymbol : StatementSymbol
    {
        /// <summary>
        /// Body of the try, over which the handlers are active.
        /// </summary>
        public abstract StatementSymbol Body { get; }
        /// <summary>
        /// Catch clauses of the try.
        /// </summary>
        public abstract ImmutableArray<CatchClauseSymbol> Catches { get; }
        /// <summary>
        /// Finally handler of the try.
        /// </summary>
        public abstract StatementSymbol? Finally { get; }
        /// <summary>
        /// Exit label for the try. This will always be null for C#.
        /// </summary>
        public abstract LabelSymbol? ExitLabel { get; }
    }
}

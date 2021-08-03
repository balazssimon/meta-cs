using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a block containing a sequence of statements and local declarations.
    /// </summary>
    [Symbol]
    public abstract partial class BlockStatementSymbol : StatementSymbol
    {
        /// <summary>
        /// Statements contained within the block.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<StatementSymbol> Statements { get; }
        
        /// <summary>
        /// Local declarations contained within the block.
        /// </summary>
        public virtual ImmutableArray<LocalSymbol> Locals { get; }
    }
}

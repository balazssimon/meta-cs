using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a for each loop.
    /// </summary>
    [Symbol]
    public abstract partial class ForEachLoopStatementSymbol : LoopStatementSymbol
    {
        /// <summary>
        /// Refers to the operation for declaring a new local variable or reference an existing variable or an expression.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol LoopControlVariable { get; }

        /// <summary>
        /// Collection value over which the loop iterates.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Collection { get; }
    }
}

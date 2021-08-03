using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an await operation.
    /// </summary>
    [Symbol]
    public abstract partial class AwaitExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Awaited operation.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Operation { get; }
    }
}

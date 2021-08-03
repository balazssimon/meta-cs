using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a return from the method with an optional return value.
    /// </summary>
    [Symbol]
    public abstract partial class ReturnStatementSymbol : StatementSymbol
    {
        /// <summary>
        /// Value to be returned.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol ReturnedValue { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a textual literal numeric, string, etc.
    /// </summary>
    [Symbol]
    public abstract partial class LiteralExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// The value of the literal.
        /// </summary>
        [SymbolProperty]
        public abstract object? Value { get; }
        /// <summary>
        /// The type of the literal.
        /// </summary>
        [SymbolProperty]
        public override TypeSymbol? Type { get; }
    }
}

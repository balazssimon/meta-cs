using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a unary operator.
    /// </summary>
    [Symbol]
    public abstract partial class UnaryOperatorSymbol : OperatorSymbol
    {
        /// <summary>
        /// Kind of unary operator.
        /// </summary>
        [SymbolProperty]
        public abstract UnaryOperatorKind OperatorKind { get; }
    }
}

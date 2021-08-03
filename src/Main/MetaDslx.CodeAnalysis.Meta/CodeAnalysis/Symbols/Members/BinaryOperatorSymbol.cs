using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a binary operator.
    /// </summary>
    [Symbol]
    public abstract partial class BinaryOperatorSymbol : OperatorSymbol
    {
        /// <summary>
        /// Kind of binary operator.
        /// </summary>
        [SymbolProperty]
        public abstract BinaryOperatorKind OperatorKind { get; }
    }
}

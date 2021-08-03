using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an operation to compute the size of a given type.
    /// </summary>
    [Symbol]
    public abstract partial class SizeOfExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Type operand.
        /// </summary>
        [SymbolProperty]
        public abstract TypeSymbol TypeOperand { get; }
    }
}

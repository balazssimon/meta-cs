using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an operation that gets <see cref="System.Type" /> for the given <see cref="TypeOperand" />.
    /// </summary>
    [Symbol]
    public abstract partial class TypeOfExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Type operand.
        /// </summary>
        [SymbolProperty]
        public abstract TypeSymbol TypeOperand { get; }
    }
}

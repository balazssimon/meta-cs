using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a coalesce operation with two operands:
    /// (1) <see cref="Value" />, which is the first operand that is unconditionally evaluated and is the result of the operation if non null.
    /// (2) <see cref="WhenNull" />, which is the second operand that is conditionally evaluated and is the result of the operation if <see cref="Value" /> is null.
    /// </summary>
    [Symbol]
    public abstract partial class CoalesceExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Operation to be unconditionally evaluated.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Value { get; }

        /// <summary>
        /// Operation to be conditionally evaluated if <see cref="Value" /> evaluates to null/Nothing.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol WhenNull { get; }

        /// <summary>
        /// Conversion associated with <see cref="Value" /> when it is not null/Nothing.
        /// Identity if result type of the operation is the same as type of <see cref="Value" />.
        /// Otherwise, if type of <see cref="Value" /> is nullable, then conversion is applied to an
        /// unwrapped <see cref="Value" />, otherwise to the <see cref="Value" /> itself.
        /// </summary>
        public virtual Conversion ValueConversion { get; }
    }
}

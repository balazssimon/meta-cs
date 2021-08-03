using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a type conversion.
    /// </summary>
    [Symbol]
    public abstract partial class ConversionExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Value to be converted.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Operand { get; }

        /// <summary>
        /// The target type of the conversion.
        /// </summary>
        [SymbolProperty]
        public abstract TypeSymbol TargetType { get; }

        /// <summary>
        /// Operator method used by the operation, null if the operation does not use an operator method.
        /// </summary>
        public virtual ConversionOperatorSymbol? OperatorMethod { get; }

        /// <summary>
        /// Gets the underlying common conversion information.
        /// </summary>
        public virtual Conversion Conversion { get; }

        /// <summary>
        /// False if the conversion will fail with a <see cref="InvalidCastException" /> at runtime if the cast fails. This is true for C#'s
        /// <c>as</c> operator and for VB's <c>TryCast</c> operator.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsTryCast { get; }

        /// <summary>
        /// True if the conversion can fail at runtime with an overflow exception. This corresponds to C# checked and unchecked blocks.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsChecked { get; }

    }
}

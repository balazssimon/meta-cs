using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public enum BinaryOperatorKind
    {

    }

    /// <summary>
    /// Represents an operation with two operands and a binary operator that produces a result with a non-null type.
    /// </summary>
    [Symbol]
    public abstract partial class BinaryExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Kind of binary operation.
        /// </summary>
        [SymbolProperty]
        public abstract BinaryOperatorKind OperatorKind { get; }
        
        /// <summary>
        /// Left operand.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol LeftOperand { get; }

        /// <summary>
        /// Right operand.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol RightOperand { get; }

        /// <summary>
        /// <see langword="true" /> if this is a 'lifted' binary operator.  When there is an
        /// operator that is defined to work on a value type, 'lifted' operators are
        /// created to work on the <see cref="System.Nullable{T}" /> versions of those
        /// value types.
        /// </summary>
        public virtual bool IsLifted { get; }

        /// <summary>
        /// <see langword="true" /> if this is a 'checked' binary operator.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsChecked { get; }

        /// <summary>
        /// Operator method used by the operation, null if the operation does not use an operator method.
        /// </summary>
        public virtual BinaryOperatorSymbol? OperatorMethod { get; }
    }
}

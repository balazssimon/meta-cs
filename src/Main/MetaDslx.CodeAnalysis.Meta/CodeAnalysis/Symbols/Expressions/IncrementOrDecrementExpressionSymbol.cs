using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an <see cref="OperationKind.Increment" /> or <see cref="OperationKind.Decrement" /> operation.
    /// Note that this operation is different from an <see cref="IUnaryOperation" /> as it mutates the <see cref="Target" />,
    /// while unary operator expression does not mutate it's operand.
    /// </summary>
    [Symbol]
    public abstract partial class IncrementOrDecrementExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// <see langword="true" /> if this is a postfix expression. <see langword="false" /> if this is a prefix expression.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsPostfix { get; }

        /// <summary>
        /// <see langword="true" /> if this is a 'lifted' increment operator.  When there
        /// is an operator that is defined to work on a value type, 'lifted' operators are
        /// created to work on the <see cref="System.Nullable{T}" /> versions of those
        /// value types.
        /// </summary>
        public virtual bool IsLifted { get; }

        /// <summary>
        /// <see langword="true" /> if overflow checking is performed for the arithmetic operation.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsChecked { get; }

        /// <summary>
        /// Target of the assignment.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Target { get; }

        /// <summary>
        /// Operator method used by the operation, null if the operation does not use an operator method.
        /// </summary>
        public virtual BinaryOperatorSymbol? OperatorMethod { get; }

        public override TypeSymbol? Type => Target?.Type;
    }
}

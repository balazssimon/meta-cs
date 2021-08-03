using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a compound assignment that mutates the target with the result of a binary operation.
    /// </summary>
    [Symbol]
    public abstract partial class CompoundAssignmentExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Conversion applied to <see cref="IAssignmentOperation.Target" /> before the operation occurs.
        /// </summary>
        public virtual Conversion InConversion { get; }

        /// <summary>
        /// Conversion applied to the result of the binary operation, before it is assigned back to
        /// <see cref="AssignmentExpressionSymbol.Target" />.
        /// </summary>
        public virtual Conversion OutConversion { get; }

        /// <summary>
        /// Kind of binary operation.
        /// </summary>
        [SymbolProperty]
        public abstract BinaryOperatorKind OperatorKind { get; }

        /// <summary>
        /// <see langword="true" /> if this assignment contains a 'lifted' binary operation.
        /// </summary>
        public virtual bool IsLifted { get; }

        /// <summary>
        /// <see langword="true" /> if overflow checking is performed for the arithmetic operation.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsChecked { get; }

        /// <summary>
        /// Operator method used by the operation, null if the operation does not use an operator method.
        /// </summary>
        public virtual MethodSymbol? OperatorMethod { get; }
    }
}

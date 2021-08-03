using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a value assignment to a variable.
    /// </summary>
    [Symbol]
    public abstract partial class AssignmentExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Target of the assignment.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Target { get; }

        /// <summary>
        /// Value to be assigned to the target of the assignment.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Value { get; }
    }
}

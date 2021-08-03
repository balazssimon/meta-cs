using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a for to loop with loop control variable and initial, limit and step values for the control variable.
    /// </summary>
    [Symbol]
    public abstract partial class ForToLoopStatementSymbol : LoopStatementSymbol
    {
        /// <summary>
        /// Refers to the operation for declaring a new local variable or reference an existing variable or an expression.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol LoopControlVariable { get; }

        /// <summary>
        /// Expression for setting the initial value of the loop control variable.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol InitialValue { get; }

        /// <summary>
        /// Expression for the limit value of the loop control variable.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol LimitValue { get; }

        /// <summary>
        /// Expression for the step value of the loop control variable.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol StepValue { get; }
    }
}

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a while, do while or repeat until loop.
    /// </summary>
    [Symbol]
    public abstract partial class WhileLoopStatementSymbol : LoopStatementSymbol
    {
        /// <summary>
        /// Condition of the loop. This can only be null in error scenarios.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        /// <summary>
        /// True if the <see cref="Condition" /> is evaluated at start of each loop iteration.
        /// False if it is evaluated at the end of each loop iteration.
        /// </summary>
        [SymbolProperty]
        public abstract bool ConditionIsTop { get; }

        /// <summary>
        /// True if the loop has 'Until' loop semantics and the loop is executed while <see cref="Condition" /> is false.
        /// </summary
        [SymbolProperty]
        public abstract bool ConditionIsUntil { get; }

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            Condition?.CheckExpressionType(SpecialSymbol.System_Boolean, diagnostics);
        }
    }
}

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a conditional operation with:
    /// (1) <see cref="Condition" /> to be tested,
    /// (2) <see cref="WhenTrue" /> operation to be executed when <see cref="Condition" /> is true and
    /// (3) <see cref="WhenFalse" /> operation to be executed when the <see cref="Condition" /> is false.
    /// </summary>
    [Symbol]
    public abstract partial class ConditionalExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Condition to be tested.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        /// <summary>
        /// Operation to be executed if the <see cref="Condition" /> is true.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol WhenTrue { get; }

        /// <summary>
        /// Operation to be executed if the <see cref="Condition" /> is false.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? WhenFalse { get; }

        public override bool IsConstant => (Condition?.IsConstant ?? false) && (WhenTrue?.IsConstant ?? false) && (WhenFalse?.IsConstant ?? false);

        public override TypeSymbol? Type => WhenTrue?.Type;

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            Condition?.CheckExpressionType(SpecialSymbol.System_Boolean, diagnostics);
        }
    }
}

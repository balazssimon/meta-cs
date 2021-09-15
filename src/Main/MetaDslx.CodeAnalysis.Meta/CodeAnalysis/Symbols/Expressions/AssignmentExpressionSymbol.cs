using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        public abstract ExpressionSymbol? Target { get; }

        /// <summary>
        /// Value to be assigned to the target of the assignment.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Value { get; }

        public override bool IsConstant => Value?.IsConstant ?? false;

        public override TypeSymbol? Type => Target?.Type;

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            if (Target?.Type is not null && Value is not null)
            {
                Value?.CheckExpressionType(this.Target.Type, diagnostics);
            }
        }
    }
}

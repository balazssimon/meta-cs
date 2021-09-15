using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a case clause with a single value for comparison.
    /// </summary>
    [Symbol]
    public abstract partial class SingleValueCaseClauseSymbol : CaseClauseSymbol
    {
        /// <summary>
        /// Case value.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Value { get; }

        public override void CheckExpressionType(TypeSymbol? expectedType, DiagnosticBag diagnostics)
        {
            Value?.CheckExpressionType(expectedType, diagnostics);
        }

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            Value?.CheckExpressionIsConstant(diagnostics);
        }
    }
}

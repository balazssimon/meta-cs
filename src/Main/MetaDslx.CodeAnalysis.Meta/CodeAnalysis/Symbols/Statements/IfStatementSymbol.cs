using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class IfStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        [SymbolProperty]
        public abstract StatementSymbol IfTrue { get; }

        [SymbolProperty]
        public abstract StatementSymbol? IfFalse { get; }

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            Condition?.CheckExpressionType(SpecialSymbol.System_Boolean, diagnostics);
        }
    }
}

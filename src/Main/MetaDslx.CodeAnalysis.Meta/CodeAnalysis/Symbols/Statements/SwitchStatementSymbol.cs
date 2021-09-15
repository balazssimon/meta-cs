using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a switch statement with a value to be switched upon and switch cases.
    /// </summary>
    [Symbol]
    public abstract partial class SwitchStatementSymbol : StatementSymbol
    {
        /// <summary>
        /// Value to be switched upon.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Value { get; }

        /// <summary>
        /// Cases of the switch.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<SwitchCaseSymbol> Cases { get; }

        /// <summary>
        /// Exit label for the switch statement.
        /// </summary>
        public virtual LabelSymbol ExitLabel { get; }

        /// <summary>
        /// Locals declared within the switch operation with scope spanning across all <see cref="Cases" />.
        /// </summary>
        public virtual ImmutableArray<LocalSymbol> Locals { get; }

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            var valueType = Value?.Type;
            if (valueType is not null)
            {
                foreach (var switchCase in this.Cases)
                {
                    foreach (var clause in switchCase.Clauses)
                    {
                        clause.CheckExpressionType(valueType, diagnostics);
                    }
                }
            }
        }
    }
}

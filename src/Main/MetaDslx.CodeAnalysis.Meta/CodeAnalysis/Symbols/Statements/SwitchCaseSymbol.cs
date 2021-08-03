using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a switch case section with one or more case clauses to match and one or more operations to execute within the section.
    /// </summary>
    [Symbol]
    public abstract partial class SwitchCaseSymbol : NonDeclaredSymbol
    {
        /// <summary>
        /// Clauses of the case.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<CaseClauseSymbol> Clauses { get; }

        /// <summary>
        /// One or more statements to execute within the switch section.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

        /// <summary>
        /// Locals declared within the switch case section scoped to the section.
        /// </summary>
        public virtual ImmutableArray<LocalSymbol> Locals { get; }
    }
}

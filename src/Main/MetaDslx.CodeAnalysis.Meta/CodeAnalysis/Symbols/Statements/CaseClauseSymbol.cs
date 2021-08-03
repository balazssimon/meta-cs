using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a case clause.
    /// </summary>
    public abstract partial class CaseClauseSymbol : NonDeclaredSymbol
    {
        /// <summary>
        /// Label associated with the case clause, if any.
        /// </summary>
        [SymbolProperty]
        public abstract LabelSymbol? Label { get; }
    }
}

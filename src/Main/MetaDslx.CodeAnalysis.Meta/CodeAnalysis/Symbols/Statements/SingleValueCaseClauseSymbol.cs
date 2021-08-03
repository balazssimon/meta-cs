using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a case clause with a single value for comparison.
    /// </summary>
    [Symbol]
    public abstract class SingleValueCaseClauseSymbol
    {
        /// <summary>
        /// Case value.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Value { get; }
    }
}

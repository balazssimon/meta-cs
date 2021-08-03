using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a statement that drops the resulting value and the type of the underlying wrapped <see cref="Expression" />.
    /// </summary>
    [Symbol]
    public abstract partial class ExpressionStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol? Expression { get; }
    }
}

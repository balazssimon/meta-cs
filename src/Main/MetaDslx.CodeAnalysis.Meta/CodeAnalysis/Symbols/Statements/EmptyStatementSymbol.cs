using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an empty or no-op statement.
    /// </summary>
    [Symbol]
    public abstract partial class EmptyStatementSymbol : StatementSymbol
    {
    }
}

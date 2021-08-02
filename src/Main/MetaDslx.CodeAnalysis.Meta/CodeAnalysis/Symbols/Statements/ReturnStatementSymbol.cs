using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ReturnStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol ReturnedValue { get; }
    }
}

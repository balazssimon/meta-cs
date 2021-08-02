using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class JumpStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract LabelSymbol? Target { get; }
    }
}

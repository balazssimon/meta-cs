using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ForEachLoopStatementSymbol : LoopStatementSymbol
    {
        [SymbolProperty]
        public abstract LocalVariableSymbol LoopControlVariable { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol Collection { get; }
    }
}

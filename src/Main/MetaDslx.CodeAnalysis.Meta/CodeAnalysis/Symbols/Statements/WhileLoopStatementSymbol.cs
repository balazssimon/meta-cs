using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class WhileLoopStatementSymbol : LoopStatementSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        [SymbolProperty]
        public abstract bool ConditionIsTop { get; }

        [SymbolProperty]
        public abstract bool ConditionIsUntil { get; }
    }
}

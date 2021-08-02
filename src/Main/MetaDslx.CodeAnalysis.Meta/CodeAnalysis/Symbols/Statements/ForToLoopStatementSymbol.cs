using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ForToLoopStatementSymbol : LoopStatementSymbol
    {
        [SymbolProperty]
        public abstract LocalVariableSymbol LoopControlVariable { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol InitialValue { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol LimitValue { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol StepValue { get; }
    }
}

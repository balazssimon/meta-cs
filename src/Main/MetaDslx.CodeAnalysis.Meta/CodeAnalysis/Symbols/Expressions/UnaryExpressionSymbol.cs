using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class UnaryExpressionSymbol : ExpressionSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Operand { get; }

        public virtual OperatorSymbol? Operator => null;
    }
}

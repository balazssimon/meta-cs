using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class BinaryExpressionSymbol : ExpressionSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Left { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol Right { get; }

        public virtual OperatorSymbol? Operator => null;
    }
}

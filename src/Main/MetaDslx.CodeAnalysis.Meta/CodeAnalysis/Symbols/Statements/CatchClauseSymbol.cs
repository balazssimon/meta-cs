using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class CatchClauseSymbol : NonDeclaredSymbol
    {
        [SymbolProperty]
        public abstract LocalVariableSymbol ExceptionVariable { get; }

        [SymbolProperty]
        public abstract ExpressionSymbol? Condition { get; }
    }
}

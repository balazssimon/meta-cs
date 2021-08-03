using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None)]
    public abstract partial class ExpressionSymbol : NonDeclaredSymbol
    {
        public virtual TypeSymbol? Type => null;
        public virtual bool IsConstant => false;
        public virtual TypeSymbol? ExpectedType => null;
        public virtual bool IsConstantExpected => false;
    }
}

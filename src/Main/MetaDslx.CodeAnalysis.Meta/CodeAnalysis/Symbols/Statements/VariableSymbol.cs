using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class VariableSymbol : LocalSymbol
    {
        [SymbolProperty]
        public virtual bool IsConst => false;
        [SymbolProperty]
        public virtual TypeSymbol? Type => null;
        [SymbolProperty]
        public virtual ExpressionSymbol? DefaultValue => null;

        public bool HasConstantValue { get; }
        public object? ConstantValue { get; }
    }
}

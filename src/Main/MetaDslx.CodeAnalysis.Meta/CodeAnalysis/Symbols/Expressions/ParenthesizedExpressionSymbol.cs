﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ParenthesizedExpressionSymbol : ExpressionSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol Inner { get; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a parenthesized operation.
    /// </summary>
    [Symbol]
    public abstract partial class ParenthesizedExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Operand enclosed in parentheses.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Operand { get; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an operation that tests if a value is of a specific type.
    /// </summary>
    [Symbol]
    public abstract partial class IsTypeExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Value to test.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol ValueOperand { get; }

        /// <summary>
        /// Type for which to test.
        /// </summary>
        [SymbolProperty]
        public abstract TypeSymbol TypeOperand { get; }

        /// <summary>
        /// Flag indicating if this is an "is not" type expression.
        /// True for VB "TypeOf ... IsNot ..." expression.
        /// False, otherwise.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsNegated { get; }
    }
}

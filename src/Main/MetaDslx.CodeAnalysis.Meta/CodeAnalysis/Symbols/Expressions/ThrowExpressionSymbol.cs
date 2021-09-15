using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an operation to throw an exception.
    /// </summary>
    [Symbol]
    public abstract partial class ThrowExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Instance of an exception being thrown.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Exception { get; }

        public override void CheckExpressionIsConstant(DiagnosticBag diagnostics)
        {
        }

        public override void CheckExpressionType(TypeSymbol? expectedType, DiagnosticBag diagnostics)
        {
        }
    }
}

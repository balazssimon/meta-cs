using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a default value operation.
    /// </summary>
    [Symbol]
    public abstract partial class DefaultValueExpressionSymbol : ExpressionSymbol
    {
        public override bool IsConstant => true;

        public override void CheckExpressionType(TypeSymbol? expectedType, DiagnosticBag diagnostics)
        {
        }
    }
}

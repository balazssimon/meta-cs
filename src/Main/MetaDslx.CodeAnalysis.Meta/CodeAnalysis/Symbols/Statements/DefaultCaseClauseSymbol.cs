using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a default case clause.
    /// </summary>
    [Symbol]
    public abstract partial class DefaultCaseClauseSymbol : CaseClauseSymbol
    {
        public override void CheckExpressionType(TypeSymbol? expectedType, DiagnosticBag diagnostics)
        {
        }
    }
}

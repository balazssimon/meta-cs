using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// The unary postfix ! operator is the null-forgiving, or null-suppression, operator.
    /// The null-forgiving operator has no effect at run time. It only affects the compiler's 
    /// static flow analysis by changing the null state of the expression. At run time, 
    /// expression x! evaluates to the result of the underlying expression x.
    /// </summary>
    [Symbol]
    public partial class NullForgivingExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Expression for which no null warning should be generated.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Operand { get; }
    }
}

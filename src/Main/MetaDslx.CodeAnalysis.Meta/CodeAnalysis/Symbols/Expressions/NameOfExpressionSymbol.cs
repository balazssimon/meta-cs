using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an operation that gets a string value for the <see cref="Argument" /> name.
    /// </summary>
    [Symbol]
    public abstract partial class NameOfExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Argument to the name of operation.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Argument { get; }


        public override bool IsConstant => true;

        public override TypeSymbol? Type => (TypeSymbol?)this.DeclaringCompilation?.GetSpecialSymbol(SpecialSymbol.System_String);
    }
}

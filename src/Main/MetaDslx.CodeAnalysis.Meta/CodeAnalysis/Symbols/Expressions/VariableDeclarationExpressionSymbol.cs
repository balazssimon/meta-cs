using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a single variable declaration and initializer.
    /// </summary>
    [Symbol]
    public abstract partial class VariableDeclarationExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Symbol declared by this variable declaration
        /// </summary>
        [SymbolProperty]
        public abstract VariableSymbol Symbol { get; }

        /// <summary>
        /// Optional initializer of the variable.
        /// </summary>
        /// <remarks>
        /// If this variable is in an <see cref="VariableDeclarationGroupExpressionSymbol" />, the initializer may be located
        /// in the parent operation. It is only allowed to have initializer in one of these locations.
        /// </remarks>
        [SymbolProperty]
        public abstract ExpressionSymbol? Initializer { get; }
    }
}

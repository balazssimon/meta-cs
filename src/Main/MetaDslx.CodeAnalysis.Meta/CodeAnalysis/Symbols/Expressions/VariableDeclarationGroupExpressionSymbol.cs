using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a declarator that declares multiple individual variables.
    /// </summary>
    [Symbol]
    public abstract partial class VariableDeclarationGroupExpressionSymbol : NonDeclaredSymbol
    {
        /// <summary>
        /// Individual variable declarations declared by this multiple declaration.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<VariableDeclarationExpressionSymbol> Declarations { get; }

        /// <summary>
        /// Optional initializer of the variable.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Initializer { get; }
    }
}

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
    public abstract partial class VariableDeclarationExpressionSymbol : ExpressionSymbol
    {
        [SymbolProperty]
        public virtual bool IsConst => false;
        [SymbolProperty]
        public virtual TypeSymbol? DeclaredType => null;

        /// <summary>
        /// Variable symbols declared by this variable declaration.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<VariableSymbol> Variables { get; }

        /// <summary>
        /// Optional initializer of the variables.
        /// </summary>
        /// <remarks>
        /// The initializer may be located either in the <see cref="VariableSymbol"/> or here. It is only allowed to have initializer in one of these locations.
        /// </remarks>
        [SymbolProperty]
        public abstract ExpressionSymbol? Initializer { get; }
    }
}

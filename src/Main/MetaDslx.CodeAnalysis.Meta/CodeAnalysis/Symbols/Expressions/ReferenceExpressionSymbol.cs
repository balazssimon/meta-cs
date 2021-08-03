using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a non-member-access reference to a declared symbol.
    /// </summary>
    [Symbol]
    public abstract partial class ReferenceExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Referenced symbol.
        /// </summary>
        [SymbolProperty]
        public abstract DeclaredSymbol Reference { get; }

        /// <summary>
        /// Type arguments.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<TypeSymbol> TypeArguments { get; }

        /// <summary>
        /// True if this reference is also the declaration site of this variable. This is true in out variable declarations
        /// and in deconstruction operations where a new variable is being declared.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsDeclaration { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a tuple with one or more elements.
    /// </summary>
    [Symbol]
    public abstract partial class TupleExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Tuple elements.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<ArgumentSymbol> Arguments { get; }

        /// <summary>
        /// Natural type of the tuple, or null if tuple doesn't have a natural type.
        /// Natural type can be different from <see cref="ExpressionSymbol.Type" /> depending on the
        /// conversion context, in which the tuple is used.
        /// </summary>
        public virtual TypeSymbol? NaturalType { get; }
    }
}

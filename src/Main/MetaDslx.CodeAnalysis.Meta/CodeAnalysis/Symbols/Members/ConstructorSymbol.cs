using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ConstructorSymbol : BehavioralMemberSymbol
    {
        [SymbolProperty]
        public abstract ImmutableArray<ParameterSymbol> Parameters { get; }

        /// <summary>
        /// Call to the 'base' constructor or another constructor in 'this'.
        /// </summary>
        [SymbolProperty]
        public abstract InvocationExpressionSymbol NextConstructorInvocation { get; }

        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

    }
}

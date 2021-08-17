using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ConstructorSymbol : MethodLikeSymbol
    {
        /// <summary>
        /// Call to the 'base' constructor or another constructor in 'this'.
        /// </summary>
        [SymbolProperty]
        public abstract InvocationExpressionSymbol NextConstructorInvocation { get; }
    }
}

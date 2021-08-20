using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an indexer access.
    /// </summary>
    [Symbol]
    public abstract partial class IndexerAccessExpressionSymbol : ExpressionSymbol, IInvocationExpressionSymbol
    {
        /// <summary>
        /// The indexed operation.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Receiver { get; }

        /// <summary>
        /// Arguments of the invocation, excluding the instance argument. Arguments are in evaluation order.
        /// </summary>
        /// <remarks>
        /// If the invocation is in its expanded form, then params/ParamArray arguments would be collected into arrays.
        /// Default values are supplied for optional arguments missing in source.
        /// </remarks>
        [SymbolProperty]
        public abstract ImmutableArray<ArgumentSymbol> Arguments { get; }

        /// <summary>
        /// Method or function to be invoked.
        /// </summary>
        [SymbolProperty]
        public virtual IndexerSymbol? Target { get; }

        public bool IsMethodInvocation => false;

        public bool IsPropertyInvocation => true;
    }
}

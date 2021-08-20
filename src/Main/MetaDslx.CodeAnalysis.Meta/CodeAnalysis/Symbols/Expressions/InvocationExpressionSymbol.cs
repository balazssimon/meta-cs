using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an invocation of a method.
    /// </summary>
    [Symbol]
    public abstract partial class InvocationExpressionSymbol : ExpressionSymbol, IInvocationExpressionSymbol
    {
        /// <summary>
        /// The method or operation to be invoked.
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

        public bool IsMethodInvocation => true;

        public bool IsPropertyInvocation => false;
    }
}

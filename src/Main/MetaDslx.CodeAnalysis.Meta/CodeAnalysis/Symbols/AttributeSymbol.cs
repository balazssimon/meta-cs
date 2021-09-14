using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents some metadata assigned to symbols.
    /// </summary>
    [Symbol]
    public partial class AttributeSymbol : NonDeclaredSymbol
    {
        /// <summary>
        /// The type of the attribute to be created.
        /// </summary>
        [SymbolProperty]
        public abstract TypeSymbol AttributeType { get; }

        /// <summary>
        /// Arguments of the object creation, excluding the instance argument. Arguments are in evaluation order.
        /// </summary>
        /// <remarks>
        /// If the invocation is in its expanded form, then params/ParamArray arguments would be collected into arrays.
        /// Default values are supplied for optional arguments missing in source.
        /// </remarks>
        [SymbolProperty]
        public abstract ImmutableArray<ArgumentSymbol> Arguments { get; }

        /// <summary>
        /// Object member or collection initializers: <see cref="AssignmentExpressionSymbol"/> or <see cref="InvocationExpressionSymbol"/>.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<ExpressionSymbol> Initializers { get; }

        /// <summary>
        /// Constructor to be invoked on the created instance.
        /// </summary>
        public virtual ConstructorSymbol? Constructor { get; }

        public virtual AttributeData AttributeData { get; }
    }
}

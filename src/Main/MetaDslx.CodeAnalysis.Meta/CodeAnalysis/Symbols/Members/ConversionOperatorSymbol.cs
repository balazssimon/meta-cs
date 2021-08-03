using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a type conversion operator.
    /// </summary>
    [Symbol]
    public abstract partial class ConversionOperatorSymbol : OperatorSymbol
    {
        /// <summary>
        /// The target type of the conversion.
        /// </summary>
        [SymbolProperty]
        public abstract TypeSymbol TargetType { get; }

        /// <summary>
        /// Whether the type conversion is implicit, i.e. it does not need explicit type cast.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsImplicit { get; }
    }
}

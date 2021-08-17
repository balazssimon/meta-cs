using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a conversion operator.
    /// </summary>
    [Symbol]
    public abstract partial class ConversionOperatorSymbol : OperatorSymbol
    {
        public virtual TypeSymbol TargetType { get; }

        /// <summary>
        /// Whether the conversion is implicit, i.e. it does not need explicit type cast.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsImplicit { get; }
    }
}

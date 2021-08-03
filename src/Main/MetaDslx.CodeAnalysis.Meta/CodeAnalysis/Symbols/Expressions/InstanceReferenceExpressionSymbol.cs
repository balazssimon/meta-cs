using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public enum InstanceReferenceKind
    {
        This,
        Base
    }

    /// <summary>
    /// Represents an implicit/explicit reference to an instance (e.g., this or base).
    /// </summary>
    [Symbol]
    public abstract partial class InstanceReferenceExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// The kind of reference that is being made.
        /// </summary>
        [SymbolProperty]
        public abstract InstanceReferenceKind ReferenceKind { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an implicit/explicit reference to an instance (e.g., this or base).
    /// </summary>
    [Symbol]
    public abstract partial class InstanceReferenceExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Reference through a base type.
        /// </summary>
        [SymbolProperty]
        public virtual NamedTypeSymbol? AccessThroughBaseType { get; }

        public bool IsThis => this.AccessThroughBaseType is null;

        public bool IsBase => this.AccessThroughBaseType is not null;

        public override bool IsInstanceReceiver => true;
    }
}

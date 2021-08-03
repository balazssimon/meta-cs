using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a <see cref="Body" /> of operations that are executed while holding a lock onto the <see cref="LockedValue" />.
    /// </summary>
    [Symbol]
    public abstract partial class LockStatementSymbol : StatementSymbol
    {
        /// <summary>
        /// Expression producing a value to be locked.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol LockedValue { get; }

        /// <summary>
        /// Body of the lock, to be executed while holding the lock.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }
    }
}

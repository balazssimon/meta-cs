using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a jump operation like goto, break or continue.
    /// </summary>
    [Symbol]
    public abstract partial class JumpStatementSymbol : StatementSymbol
    {
        /// <summary>
        /// Kind of the jump.
        /// </summary>
        [SymbolProperty]
        public abstract JumpKind JumpKind { get; }

        /// <summary>
        /// Label that is the target of the jump.
        /// </summary>
        [SymbolProperty]
        public abstract LabelSymbol Target { get; }

    }
}

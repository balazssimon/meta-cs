using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a loop statement.
    /// </summary>
    public abstract partial class LoopStatementSymbol : StatementSymbol
    {
        /// <summary>
        /// Body of the loop.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

        /// <summary>
        /// Loop continue label.
        /// </summary>
        public virtual LabelSymbol ContinueLabel { get; }

        /// <summary>
        /// Loop exit/break label.
        /// </summary>
        public virtual LabelSymbol ExitLabel { get; }

        /// <summary>
        /// Declared locals.
        /// </summary>
        public virtual ImmutableArray<LocalSymbol> Locals { get; }
    }
}

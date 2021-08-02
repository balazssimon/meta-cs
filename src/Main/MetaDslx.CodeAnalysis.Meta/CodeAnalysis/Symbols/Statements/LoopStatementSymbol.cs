using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract partial class LoopStatementSymbol : StatementSymbol
    {
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

        /// <summary>
        /// Loop continue label.
        /// </summary>
        [SymbolProperty]
        public abstract LabelSymbol ContinueLabel { get; }

        /// <summary>
        /// Loop exit/break label.
        /// </summary>
        [SymbolProperty]
        public abstract LabelSymbol ExitLabel { get; }
    }
}

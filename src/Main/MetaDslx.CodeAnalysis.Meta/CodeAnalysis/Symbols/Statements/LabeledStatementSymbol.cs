﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a statement with a label.
    /// </summary>
    [Symbol]
    public abstract partial class LabeledStatementSymbol
    {
        /// <summary>
        /// Label that can be the target of branches.
        /// </summary>
        [SymbolProperty]
        public abstract LabelSymbol Label { get; }

        /// <summary>
        /// Statement that has been labeled.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol? Statement { get; }
    }
}
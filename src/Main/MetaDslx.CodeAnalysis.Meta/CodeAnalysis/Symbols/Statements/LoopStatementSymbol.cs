using Microsoft.CodeAnalysis.PooledObjects;
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
        [SymbolProperty]
        public virtual LabelSymbol? ContinueLabel { get; }

        /// <summary>
        /// Loop exit/break label.
        /// </summary>
        [SymbolProperty]
        public virtual LabelSymbol? ExitLabel { get; }

        protected override void AddDeclaredLocals(ArrayBuilder<LocalSymbol> result)
        {
            base.AddDeclaredLocals(result);
            if (this.ContinueLabel is not null) result.Add(this.ContinueLabel);
            if (this.ExitLabel is not null) result.Add(this.ExitLabel);
        }
    }
}

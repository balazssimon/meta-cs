using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a for loop.
    /// </summary>
    [Symbol]
    public abstract partial class ForLoopStatementSymbol : LoopStatementSymbol
    {
        /// <summary>
        /// List of statements to execute before entry to the loop. For C#, this comes from the first clause of the for statement.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<StatementSymbol> Before { get; }

        /// <summary>
        /// Condition of the loop. For C#, this comes from the second clause of the for statement.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        /// <summary>
        /// List of operations to execute at the bottom of the loop. For C#, this comes from the third clause of the for statement.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<StatementSymbol> AtLoopBottom { get; }

        /// <summary>
        /// Locals declared within the loop Condition and are in scope throughout the <see cref="Condition" />,
        /// <see cref="LoopStatementSymbol.Body" /> and <see cref="AtLoopBottom" />.
        /// They are considered to be declared per iteration.
        /// </summary>
        public virtual ImmutableArray<LocalSymbol> ConditionLocals { get; }
    }
}

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a catch clause.
    /// </summary>
    [Symbol]
    public abstract partial class CatchClauseSymbol : NonDeclaredSymbol
    {
        /// <summary>
        /// Optional source for exception. This could be any of the following operation:
        /// 1. Declaration for the local catch variable bound to the caught exception (C# and VB) OR
        /// 2. Null, indicating no declaration or expression (C# and VB)
        /// 3. Reference to an existing local or parameter (VB) OR
        /// 4. Other expression for error scenarios (VB)
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol ExceptionDeclarationOrExpression { get; }

        /// <summary>
        /// Filter operation to be executed to determine whether to handle the exception.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Filter { get; }

        /// <summary>
        /// Body of the exception handler.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol? Handler { get; }

        /// <summary>
        /// Type of the exception handled by the catch clause.
        /// </summary>
        public virtual TypeSymbol? ExceptionType { get; }

        /// <summary>
        /// Locals declared by the <see cref="ExceptionDeclarationOrExpression" /> and/or <see cref="Filter" /> clause.
        /// </summary>
        public virtual ImmutableArray<LocalSymbol> Locals { get; }

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            Filter?.CheckExpressionType(SpecialSymbol.System_Boolean, diagnostics);
        }
    }
}

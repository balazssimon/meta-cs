using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an anonymous function operation.
    /// </summary>
    [Symbol]
    public abstract partial class LambdaExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Return type of the anonymous function.
        /// </summary>
        [SymbolProperty]
        public abstract TypeSymbol ReturnType { get; }

        /// <summary>
        /// Parameters of the anonymous function.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<ParameterSymbol> Parameters { get; }

        /// <summary>
        /// Body of the anonymous function.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

        /// <summary>
        /// Symbol of the anonymous function.
        /// </summary>
        public virtual LambdaSymbol Symbol { get; }

        // TODO:MetaDslx
        public bool IsBound => true;

        public LambdaExpressionSymbol BindForReturnTypeInference(DelegateTypeSymbol type)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public TypeWithAnnotations GetInferredReturnType(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }
    }
}

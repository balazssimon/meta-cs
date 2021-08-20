using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an operation with one operand and a unary operator.
    /// </summary>
    [Symbol]
    public abstract partial class UnaryExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Kind of unary operation.
        /// </summary>
        [SymbolProperty]
        public abstract UnaryOperatorKind OperatorKind { get; }

        /// <summary>
        /// Operand.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Operand { get; }

        /// <summary>
        /// <see langword="true" /> if this is a 'lifted' unary operator.  When there is an
        /// operator that is defined to work on a value type, 'lifted' operators are
        /// created to work on the <see cref="System.Nullable{T}" /> versions of those
        /// value types.
        /// </summary>
        public virtual bool IsLifted { get; }

        /// <summary>
        /// <see langword="true" /> if overflow checking is performed for the arithmetic operation.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsChecked { get; }
        
        /// <summary>
        /// Operator method used by the operation, null if the operation does not use an operator method.
        /// </summary>
        public virtual UnaryOperatorSymbol? OperatorMethod { get; }


        [SymbolCompletionPart]
        protected abstract void BindOperator(DiagnosticBag diagnostics, CancellationToken cancellationToken);
    }

    namespace Completion
    {
        public partial class CompletionUnaryExpressionSymbol
        {
            private UnaryOperatorAnalysisResult _analysisResult;

            public override UnaryOperatorSymbol? OperatorMethod
            {
                get
                {
                    //ForceComplete(CompletionParts.FinishComputing_BindOperator);
                    return _analysisResult.Signature.Method as UnaryOperatorSymbol;
                }
            }

            protected override void BindOperator(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                var compilation = this.DeclaringCompilation;
                if (compilation is null) return;
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                var result = UnaryOperatorOverloadResolutionResult.GetInstance();
                compilation.OverloadResolution.UnaryOperatorOverloadResolution(this.OperatorKind, this.Operand, result, ref useSiteDiagnostics);
                if (result.SingleValid())
                {
                    _analysisResult = result.Best;
                }
                if (useSiteDiagnostics is not null)
                {
                    var location = this.Locations.FirstOrNone();
                    foreach (var diag in useSiteDiagnostics)
                    {
                        diagnostics.Add(diag.ToDiagnostic(location));
                    }
                }
                result.Free();
            }
        }
    }
}

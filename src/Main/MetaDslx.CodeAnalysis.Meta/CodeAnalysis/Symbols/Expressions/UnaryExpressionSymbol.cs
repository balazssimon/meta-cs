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
        private UnaryOperatorAnalysisResult _analysisResult;

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
        /// <see langword="true" /> if overflow checking is performed for the arithmetic operation.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsChecked { get; }

        /// <summary>
        /// Operator method used by the operation, null if the operation does not use an operator method.
        /// </summary>
        [SymbolProperty]
        public virtual UnaryOperatorSymbol? OperatorMethod { get; }

        /// <summary>
        /// <see langword="true" /> if this is a 'lifted' unary operator.  When there is an
        /// operator that is defined to work on a value type, 'lifted' operators are
        /// created to work on the <see cref="System.Nullable{T}" /> versions of those
        /// value types.
        /// </summary>
        [SymbolProperty]
        public virtual bool IsLifted { get; }

        /// <summary>
        /// The conversion to be applied to the operand before performing the operation.
        /// </summary>
        public virtual Conversion OperandConversion
        {
            get
            {
                //ForceComplete(CompletionParts.FinishBindOperator, null, default);
                return _analysisResult.Conversion;
            }
        }

        protected virtual void BindOperator(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var compilation = this.DeclaringCompilation;
            if (compilation is null) return;
            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            var result = UnaryOperatorOverloadResolutionResult.GetInstance();
            compilation.OverloadResolution.UnaryOperatorOverloadResolution(this.OperatorKind, this.Operand, result, ref useSiteDiagnostics);
            _analysisResult = result.Best;
            result.Free();
            if (useSiteDiagnostics is not null)
            {
                var location = this.Locations.FirstOrNone();
                foreach (var diag in useSiteDiagnostics)
                {
                    diagnostics.Add(diag.ToDiagnostic(location));
                }
            }
        }
    }

}

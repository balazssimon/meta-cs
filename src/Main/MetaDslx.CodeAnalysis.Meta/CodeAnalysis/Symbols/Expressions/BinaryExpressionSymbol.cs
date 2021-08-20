using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an operation with two operands and a binary operator that produces a result with a non-null type.
    /// </summary>
    [Symbol]
    public abstract partial class BinaryExpressionSymbol : ExpressionSymbol
    {
        private BinaryOperatorAnalysisResult _analysisResult;

        /// <summary>
        /// Kind of binary operation.
        /// </summary>
        [SymbolProperty]
        public abstract BinaryOperatorKind OperatorKind { get; }
        
        /// <summary>
        /// Left operand.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol LeftOperand { get; }

        /// <summary>
        /// Right operand.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol RightOperand { get; }

        /// <summary>
        /// <see langword="true" /> if this is a 'checked' binary operator.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsChecked { get; }

        /// <summary>
        /// Operator method used by the operation, null if the operation does not use an operator method.
        /// </summary>
        [SymbolProperty]
        public virtual BinaryOperatorSymbol? OperatorMethod { get; }

        /// <summary>
        /// <see langword="true" /> if this is a 'lifted' unary operator.  When there is an
        /// operator that is defined to work on a value type, 'lifted' operators are
        /// created to work on the <see cref="System.Nullable{T}" /> versions of those
        /// value types.
        /// </summary>
        [SymbolProperty]
        public virtual bool IsLifted { get; }

        /// <summary>
        /// The conversion to be applied to the left operand before performing the operation.
        /// </summary>
        public virtual Conversion LeftConversion
        {
            get
            {
                //ForceComplete(CompletionParts.FinishBindOperator, null, default);
                return _analysisResult.LeftConversion;
            }
        }

        /// <summary>
        /// The conversion to be applied to the right operand before performing the operation.
        /// </summary>
        public virtual Conversion RightConversion
        {
            get
            {
                //ForceComplete(CompletionParts.FinishBindOperator, null, default);
                return _analysisResult.RightConversion;
            }
        }

        protected virtual void BindOperator(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var compilation = this.DeclaringCompilation;
            if (compilation is null) return;
            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            var result = BinaryOperatorOverloadResolutionResult.GetInstance();
            compilation.OverloadResolution.BinaryOperatorOverloadResolution(this.OperatorKind, this.LeftOperand, this.RightOperand, result, ref useSiteDiagnostics);
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

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
        public abstract bool IsLifted { get; }

        /// <summary>
        /// The conversion to be applied to the left operand before performing the operation.
        /// </summary>
        public abstract Conversion LeftConversion { get; }

        /// <summary>
        /// The conversion to be applied to the right operand before performing the operation.
        /// </summary>
        public abstract Conversion RightConversion { get; }

    }


    namespace Completion
    {
        public partial class CompletionBinaryExpressionSymbol
        {
            private BinaryOperatorAnalysisResult _analysisResult;

            protected virtual BinaryOperatorSymbol? CompleteSymbolProperty_OperatorMethod(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                if (SymbolImplementation.AssignSymbolPropertyValue<BinaryOperatorSymbol>(this, nameof(OperatorMethod), diagnostics, cancellationToken, out var result))
                {
                    _analysisResult = BindMetadataOperator(result, diagnostics, cancellationToken);
                }
                else
                {
                    _analysisResult = BindSourceOperator(diagnostics, cancellationToken);
                }
                return _analysisResult.Signature.Method as BinaryOperatorSymbol;
            }

            public override bool IsLifted
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    return _analysisResult.Signature.IsLifted;
                }
            }

            public override Conversion LeftConversion
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    return _analysisResult.LeftConversion;
                }
            }

            public override Conversion RightConversion
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    return _analysisResult.LeftConversion;
                }
            }

            protected virtual BinaryOperatorAnalysisResult BindMetadataOperator(BinaryOperatorSymbol? result, DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                BinaryOperatorAnalysisResult analysisResult;
                var leftType = LeftOperand?.Type;
                var rightType = RightOperand?.Type;
                var isLifted = false;
                if (leftType is NullableTypeSymbol leftNullableType)
                {
                    isLifted = true;
                    leftType = leftNullableType.InnerType;
                }
                if (rightType is NullableTypeSymbol rightNullableType)
                {
                    isLifted = true;
                    rightType = rightNullableType.InnerType;
                }
                var returnType = result?.ReturnType;
                if (result is not null && result.Parameters.Length >= 2)
                {
                    var leftParamType = result.Parameters[0].Type;
                    var rightParamType = result.Parameters[1].Type;
                    HashSet<DiagnosticInfo>? useSiteDiagnostics = null;
                    if (this.DeclaringCompilation is not null)
                    {
                        var leftConversion = leftType is not null && leftParamType is not null ? this.DeclaringCompilation.Conversions.ClassifyConversionFromType(leftType, leftParamType, ref useSiteDiagnostics) : Conversions.NoConversion;
                        var rightConversion = rightType is not null && rightParamType is not null ? this.DeclaringCompilation.Conversions.ClassifyConversionFromType(rightType, rightParamType, ref useSiteDiagnostics) : Conversions.NoConversion;
                        if (this.AddSymbolDiagnostics(useSiteDiagnostics) || leftConversion == Conversions.NoConversion || rightConversion == Conversions.NoConversion)
                        {
                            analysisResult = BinaryOperatorAnalysisResult.Inapplicable(new BinaryOperatorSignature(OperatorKind, leftType, rightType, returnType, isLifted, result), leftConversion, rightConversion);
                        }
                        else
                        {
                            analysisResult = BinaryOperatorAnalysisResult.Applicable(new BinaryOperatorSignature(OperatorKind, leftType, rightType, returnType, isLifted, result), leftConversion, rightConversion);
                        }
                    }
                    else
                    {
                        analysisResult = BinaryOperatorAnalysisResult.Inapplicable(new BinaryOperatorSignature(OperatorKind, leftType, rightType, returnType, isLifted, result), Conversions.NoConversion, Conversions.NoConversion);
                    }
                }
                else
                {
                    analysisResult = BinaryOperatorAnalysisResult.Inapplicable(new BinaryOperatorSignature(OperatorKind, leftType, rightType, returnType, isLifted, result), Conversions.NoConversion, Conversions.NoConversion);
                }
                return analysisResult;
            }

            protected virtual BinaryOperatorAnalysisResult BindSourceOperator(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                var compilation = this.DeclaringCompilation;
                if (compilation is null) return default;
                HashSet<DiagnosticInfo>? useSiteDiagnostics = null;
                var result = BinaryOperatorOverloadResolutionResult.GetInstance();
                compilation.OverloadResolution.BinaryOperatorOverloadResolution(this.OperatorKind, this.LeftOperand, this.RightOperand, result, ref useSiteDiagnostics);
                var analysisResult = result.Best;
                if (result.Results.Count == 0 && (useSiteDiagnostics is null || useSiteDiagnostics.Count == 0))
                {
                    diagnostics.Add(InternalErrorCode.ERR_BadBinaryOps.ToDiagnostic(this.GetLocation(), this.OperatorKind.ToString(), this.LeftOperand?.Type?.ToString(), this.RightOperand?.Type?.ToString()));
                }
                result.Free();
                this.AddSymbolDiagnostics(useSiteDiagnostics);
                return analysisResult;
            }
        }
    }
}

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
        public virtual bool IsLifted { get; }

        /// <summary>
        /// The conversion to be applied to the operand before performing the operation.
        /// </summary>
        public virtual Conversion OperandConversion { get; }

    }

    namespace Completion
    {
        public partial class CompletionUnaryExpressionSymbol
        {
            private UnaryOperatorAnalysisResult _analysisResult;

            protected virtual UnaryOperatorSymbol? CompleteSymbolProperty_OperatorMethod(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                if (SymbolImplementation.AssignSymbolPropertyValue<UnaryOperatorSymbol>(this, nameof(OperatorMethod), diagnostics, cancellationToken, out var result))
                {
                    _analysisResult = BindMetadataOperator(result, diagnostics, cancellationToken);
                }
                else
                {
                    _analysisResult = BindSourceOperator(diagnostics, cancellationToken);
                }
                return _analysisResult.Signature.Method as UnaryOperatorSymbol;
            }

            public override bool IsLifted
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    return _analysisResult.Signature.IsLifted;
                }
            }

            public override Conversion OperandConversion
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    return _analysisResult.Conversion;
                }
            }

            protected UnaryOperatorAnalysisResult BindMetadataOperator(UnaryOperatorSymbol? result, DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                UnaryOperatorAnalysisResult analysisResult;
                var returnType = result?.ReturnType;
                var operandType = Operand?.Type;
                var isLifted = false;
                if (operandType is NullableTypeSymbol nullableType)
                {
                    isLifted = true;
                    operandType = nullableType.InnerType;
                }
                if (result is not null && result.Parameters.Length >= 1)
                {
                    var paramType = result.Parameters[0].Type;
                    HashSet<DiagnosticInfo>? useSiteDiagnostics = null;
                    if (this.DeclaringCompilation is not null)
                    {
                        var conversion = operandType is not null && paramType is not null ? this.DeclaringCompilation.Conversions.ClassifyConversionFromType(operandType, paramType, ref useSiteDiagnostics) : Conversions.NoConversion;
                        if (this.AddSymbolDiagnostics(useSiteDiagnostics) || conversion == Conversions.NoConversion)
                        {
                            analysisResult = UnaryOperatorAnalysisResult.Inapplicable(new UnaryOperatorSignature(OperatorKind, operandType, returnType, isLifted, result), conversion);
                        }
                        else
                        {
                            analysisResult = UnaryOperatorAnalysisResult.Applicable(new UnaryOperatorSignature(OperatorKind, operandType, returnType, isLifted, result), conversion);
                        }
                    }
                    else
                    {
                        analysisResult = UnaryOperatorAnalysisResult.Inapplicable(new UnaryOperatorSignature(OperatorKind, operandType, returnType, isLifted, result), Conversions.NoConversion);
                    }
                }
                else
                {
                    analysisResult = UnaryOperatorAnalysisResult.Inapplicable(new UnaryOperatorSignature(OperatorKind, operandType, returnType, isLifted, result), Conversions.NoConversion);
                }
                return analysisResult;
            }

            protected UnaryOperatorAnalysisResult BindSourceOperator(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                var compilation = this.DeclaringCompilation;
                if (compilation is null) return default;
                HashSet<DiagnosticInfo>? useSiteDiagnostics = null;
                var result = UnaryOperatorOverloadResolutionResult.GetInstance();
                compilation.OverloadResolution.UnaryOperatorOverloadResolution(this.OperatorKind, this.Operand, result, ref useSiteDiagnostics);
                var analysisResult = result.Best;
                if (result.Results.Count == 0 && (useSiteDiagnostics is null || useSiteDiagnostics.Count == 0))
                {
                    diagnostics.Add(InternalErrorCode.ERR_BadUnaryOp.ToDiagnostic(this.GetLocation(), this.OperatorKind.ToString(), this.Operand?.Type?.ToString()));
                }
                result.Free();
                this.AddSymbolDiagnostics(useSiteDiagnostics);
                return analysisResult;
            }
        }
    }
}

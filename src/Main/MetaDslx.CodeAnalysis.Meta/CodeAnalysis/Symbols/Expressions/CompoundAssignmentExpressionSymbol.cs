using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a compound assignment that mutates the target with the result of a binary operation.
    /// </summary>
    [Symbol]
    public abstract partial class CompoundAssignmentExpressionSymbol : AssignmentExpressionSymbol
    {
        /// <summary>
        /// Conversion applied to <see cref="AssignmentExpressionSymbol.Target" /> before the operation occurs.
        /// </summary>
        public virtual Conversion InConversion { get; }

        /// <summary>
        /// Conversion applied to the result of the binary operation, before it is assigned back to
        /// <see cref="AssignmentExpressionSymbol.Target" />.
        /// </summary>
        public virtual Conversion OutConversion { get; }

        /// <summary>
        /// Kind of binary operation.
        /// </summary>
        [SymbolProperty]
        public abstract BinaryOperatorKind OperatorKind { get; }

        /// <summary>
        /// <see langword="true" /> if this assignment contains a 'lifted' binary operation.
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
        [SymbolProperty]
        public virtual BinaryOperatorSymbol? OperatorMethod { get; }

        public override bool IsConstant => false;
    }

    namespace Completion
    {
        public partial class CompletionCompoundAssignmentExpressionSymbol
        {
            private BinaryOperatorAnalysisResult _analysisResult;
            private Conversion? _outConversion;

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

            public override Conversion InConversion
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    return _analysisResult.LeftConversion;
                }
            }

            public override Conversion OutConversion
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    if (_outConversion is null)
                    {
                        Conversion outConversion = Conversions.NoConversion;
                        var targetType = this.Target?.Type;
                        if (this.DeclaringCompilation is not null && targetType is not null)
                        {
                            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                            outConversion = this.DeclaringCompilation.Conversions.ClassifyConversionFromType(_analysisResult.Signature.ReturnType, targetType, ref useSiteDiagnostics);
                        }
                        Interlocked.CompareExchange(ref _outConversion, outConversion, null);
                    }
                    return _outConversion;
                }
            }

            public override TypeSymbol? Type
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    return _analysisResult.Signature.ReturnType;
                }
            }

            protected virtual BinaryOperatorAnalysisResult BindMetadataOperator(BinaryOperatorSymbol? result, DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                BinaryOperatorAnalysisResult analysisResult;
                var leftType = this.Target?.Type;
                var rightType = this.Value?.Type;
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
                var returnType = result?.Result?.Type;
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
                compilation.OverloadResolution.BinaryOperatorOverloadResolution(this.OperatorKind, this.Target, this.Value, result, ref useSiteDiagnostics);
                var analysisResult = result.Best;
                if (result.Results.Count == 0 && (useSiteDiagnostics is null || useSiteDiagnostics.Count == 0))
                {
                    diagnostics.Add(InternalErrorCode.ERR_BadBinaryOps.ToDiagnostic(this.GetLocation(), this.OperatorKind?.ToString() ?? string.Empty, this.Target?.Type?.ToString() ?? string.Empty, this.Value?.Type?.ToString() ?? string.Empty));
                }
                result.Free();
                this.AddSymbolDiagnostics(useSiteDiagnostics);
                return analysisResult;
            }
        }
    }
}

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
        [SymbolProperty]
        public virtual bool IsLifted { get; }

        /// <summary>
        /// The conversion to be applied to the operand before performing the operation.
        /// </summary>
        public abstract Conversion OperandConversion { get; }

        protected UnaryOperatorAnalysisResult BindOperator(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var compilation = this.DeclaringCompilation;
            if (compilation is null) return default;
            HashSet<DiagnosticInfo>? useSiteDiagnostics = null;
            var result = UnaryOperatorOverloadResolutionResult.GetInstance();
            compilation.OverloadResolution.UnaryOperatorOverloadResolution(this.OperatorKind, this.Operand, result, ref useSiteDiagnostics);
            var analysisResult = result.Best;
            result.Free();
            this.AddSymbolDiagnostics(useSiteDiagnostics);
            return analysisResult;
        }
    }

    namespace Source
    {
        public partial class SourceUnaryExpressionSymbol
        {
            private UnaryOperatorAnalysisResult _analysisResult;

            protected override UnaryOperatorSymbol? CompleteSymbolProperty_OperatorMethod(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                var result = SourceSymbolImplementation.AssignSymbolPropertyValue<UnaryOperatorSymbol>(this, nameof(OperatorMethod), diagnostics, cancellationToken);
                if (result is null)
                {
                    _analysisResult = BindOperator(diagnostics, cancellationToken);
                    result = _analysisResult.Signature.Method as UnaryOperatorSymbol;
                }
                else
                {
                    var returnType = result.ReturnType;
                    if (result.Parameters.Length > 0)
                    {
                        var operandType = Operand?.Type;
                        var paramType = result.Parameters[0].Type;
                        var isLifted = false;
                        HashSet<DiagnosticInfo>? useSiteDiagnostics = null;
                        if (operandType is NullableTypeSymbol nullableType)
                        {
                            isLifted = true;
                            operandType = nullableType.InnerType;
                        }
                        var conversion = operandType is not null && paramType is not null ? this.DeclaringCompilation.Conversions.ClassifyConversionFromType(operandType, paramType, ref useSiteDiagnostics) : Conversions.NoConversion;
                        if (this.AddSymbolDiagnostics(useSiteDiagnostics) || conversion == Conversions.NoConversion)
                        {
                            _analysisResult = UnaryOperatorAnalysisResult.Inapplicable(new UnaryOperatorSignature(OperatorKind, operandType, returnType, isLifted, result), conversion);
                        }
                        else
                        {
                            _analysisResult = UnaryOperatorAnalysisResult.Applicable(new UnaryOperatorSignature(OperatorKind, operandType, returnType, isLifted, result), conversion);
                        }
                    }
                }
                return result;
            }

            protected override bool CompleteSymbolProperty_IsLifted(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                var result = SourceSymbolImplementation.AssignSymbolPropertyValue<bool?>(this, nameof(IsLifted), diagnostics, cancellationToken);
                if (result is null)
                {
                    if (_analysisResult.IsValid) result = _analysisResult.Signature.IsLifted;
                }
                return result ?? false;
            }

            public override Conversion OperandConversion
            {
                get
                {
                    ForceComplete(CompletionParts.FinishComputingProperty_OperatorMethod, default, default);
                    return _analysisResult.Conversion;
                }
            }
        }
    }
}

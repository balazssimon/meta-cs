using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a conditional operation with:
    /// (1) <see cref="Condition" /> to be tested,
    /// (2) <see cref="WhenTrue" /> operation to be executed when <see cref="Condition" /> is true and
    /// (3) <see cref="WhenFalse" /> operation to be executed when the <see cref="Condition" /> is false.
    /// </summary>
    [Symbol]
    public abstract partial class ConditionalExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Condition to be tested.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Condition { get; }

        /// <summary>
        /// Operation to be executed if the <see cref="Condition" /> is true.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol WhenTrue { get; }

        /// <summary>
        /// Operation to be executed if the <see cref="Condition" /> is false.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? WhenFalse { get; }

        /// <summary>
        /// The conversion to be applied to the left operand before performing the operation.
        /// </summary>
        public abstract Conversion WhenTrueConversion { get; }

        /// <summary>
        /// The conversion to be applied to the right operand before performing the operation.
        /// </summary>
        public abstract Conversion WhenFalseConversion { get; }

        public override bool IsConstant => (Condition?.IsConstant ?? false) && (WhenTrue?.IsConstant ?? false) && (WhenFalse?.IsConstant ?? false);

        [SymbolCompletionPart]
        protected abstract void ComputeTypeAndConversions(DiagnosticBag diagnostics, CancellationToken cancellationToken);

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            Condition?.CheckExpressionType(SpecialSymbol.System_Boolean, diagnostics);
        }
    }

    namespace Completion
    {
        public partial class CompletionConditionalExpressionSymbol
        {
            private TypeSymbol? _type;
            private Conversion _whenTrueConversion;
            private Conversion _whenFalseConversion;

            public override Conversion WhenTrueConversion
            {
                get
                {
                    this.ForceComplete(CompletionParts.FinishComputeTypeAndConversions, default, default);
                    return _whenTrueConversion;
                }
            }

            public override Conversion WhenFalseConversion
            {
                get
                {
                    this.ForceComplete(CompletionParts.FinishComputeTypeAndConversions, default, default);
                    return _whenFalseConversion;
                }
            }

            public override TypeSymbol? Type
            {
                get
                {
                    this.ForceComplete(CompletionParts.FinishComputeTypeAndConversions, default, default);
                    return _type;
                }
            }

            protected override void ComputeTypeAndConversions(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                var compilation = this.DeclaringCompilation;
                var whenTrueType = this.WhenTrue?.Type;
                var whenFalseType = this.WhenFalse?.Type;
                if (whenTrueType is null || whenFalseType is null)
                {
                    _whenTrueConversion = Conversions.NoConversion;
                    _whenFalseConversion = Conversions.NoConversion;
                    _type = whenTrueType;
                    return;
                }
                if (compilation is null)
                {
                    _whenTrueConversion = Conversions.Identity;
                    _whenFalseConversion = Conversions.Identity;
                    _type = whenTrueType;
                    return;
                }
                HashSet<DiagnosticInfo>? useSiteDiagnostics = null;
                var falseToTrueConversion = compilation.Conversions.ClassifyImplicitConversionFromType(whenFalseType, whenTrueType, ref useSiteDiagnostics);
                var trueToFalseConversion = compilation.Conversions.ClassifyImplicitConversionFromType(whenTrueType, whenFalseType, ref useSiteDiagnostics);
                if (falseToTrueConversion != Conversions.NoConversion)
                {
                    _whenTrueConversion = Conversions.Identity;
                    _whenFalseConversion = falseToTrueConversion;
                    _type = whenTrueType;
                }
                else if (trueToFalseConversion != Conversions.NoConversion)
                {
                    _whenTrueConversion = trueToFalseConversion;
                    _whenFalseConversion = Conversions.Identity;
                    _type = whenFalseType;
                }
                else
                {
                    diagnostics.Add(InternalErrorCode.ERR_AmbigQM.ToDiagnostic(this.GetLocation(), whenTrueType?.ToString() ?? string.Empty, whenFalseType?.ToString() ?? string.Empty));
                }
            }
        }
    }

}

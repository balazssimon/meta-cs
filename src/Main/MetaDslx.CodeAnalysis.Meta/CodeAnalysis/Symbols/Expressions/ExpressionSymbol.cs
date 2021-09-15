using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None)]
    public abstract partial class ExpressionSymbol : NonDeclaredSymbol
    {
        private ThreeState _isConstant;
        private object? _constantValue;

        protected virtual Location GetLocation()
        {
            return this.Locations.FirstOrNone();
        }

        public virtual TypeSymbol? Type => null;

        public virtual bool IsConstant
        {
            get
            {
                if (_isConstant == ThreeState.Unknown)
                {
                    if (ComputeConstantValue(out var value))
                    {
                        Interlocked.CompareExchange(ref _constantValue, value, null);
                        _isConstant = ThreeState.True;
                    }
                    else
                    {
                        _isConstant = ThreeState.False;
                    }
                }
                return _isConstant == ThreeState.True;
            }
        }

        public virtual object? ConstantValue => IsConstant ? _constantValue : null;

        protected virtual bool ComputeConstantValue(out object? value)
        {
            value = null;
            return false;
        }

        public virtual void CheckExpressionIsConstant(DiagnosticBag diagnostics)
        {
            if (this.DeclaringCompilation is null) return;
            if (!IsConstant)
            {
                diagnostics.Add(InternalErrorCode.ERR_ConstantExpected.ToDiagnostic(this.GetLocation()));
            }
        }

        public virtual void CheckExpressionType(TypeSymbol? expectedType, DiagnosticBag diagnostics)
        {
            if (this.DeclaringCompilation is null) return;
            if (this.Type is null)
            {
                if (expectedType is not null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_ExpressionOfTypeExpected.ToDiagnostic(this.GetLocation(), expectedType));
                }
                else
                {
                    diagnostics.Add(ModelErrorCode.ERR_ExpressionOfTypeExpected.ToDiagnostic(this.GetLocation(), "<ERROR>"));
                }
                return;
            }
            var conversions = this.DeclaringCompilation.Conversions;
            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            var conversion = conversions.ClassifyImplicitConversionFromType(this.Type, expectedType, ref useSiteDiagnostics);
            if (useSiteDiagnostics is not null)
            {
                var location = this.GetLocation();
                foreach (var diag in useSiteDiagnostics)
                {
                    diagnostics.Add(diag.ToDiagnostic(location));
                }
            }
            else if (conversion == Conversions.NoConversion)
            {
                if (expectedType is not null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_ExpressionOfTypeExpected.ToDiagnostic(this.GetLocation(), expectedType));
                }
                else
                {
                    diagnostics.Add(ModelErrorCode.ERR_ExpressionOfTypeExpected.ToDiagnostic(this.GetLocation(), "<ERROR>"));
                }
            }
        }

        public virtual void CheckExpressionType(SpecialSymbol specialSymbol, DiagnosticBag diagnostics)
        {
            if (this.DeclaringCompilation is null) return;
            var expectedType = this.DeclaringCompilation.GetSpecialSymbol(specialSymbol) as TypeSymbol;
            this.CheckExpressionType(expectedType, diagnostics);
        }

        public virtual bool IsInferencePending => false;
        public virtual bool IsStaticReceiver => false;
        public virtual bool IsInstanceReceiver => false;
        public virtual bool IsImplicitReceiver => false;
    }
}

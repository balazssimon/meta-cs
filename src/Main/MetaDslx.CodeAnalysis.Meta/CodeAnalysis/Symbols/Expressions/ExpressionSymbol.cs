using MetaDslx.CodeAnalysis.Binding;
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

        public virtual void CheckExpressionConstaints(Conversions conversions, TypeSymbol expectedType, bool mustBeConstant, DiagnosticBag diagnostics)
        {
            if (mustBeConstant && !IsConstant)
            {
                diagnostics.Add(InternalErrorCode.ERR_ConstantExpected.ToDiagnostic(this.GetLocation()));
            }
            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            conversions.ClassifyImplicitConversionFromType(this.Type, expectedType, ref useSiteDiagnostics);
            if (useSiteDiagnostics is not null)
            {
                var location = this.GetLocation();
                foreach (var diag in useSiteDiagnostics)
                {
                    diagnostics.Add(diag.ToDiagnostic(location));
                }
            }
        }

        public virtual bool IsInferencePending => false;
        public virtual bool IsStaticReceiver => false;
        public virtual bool IsInstanceReceiver => false;
        public virtual bool IsImplicitReceiver => false;
    }
}

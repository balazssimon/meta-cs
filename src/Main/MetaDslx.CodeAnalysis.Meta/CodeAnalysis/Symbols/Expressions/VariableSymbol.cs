using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class VariableSymbol : LocalSymbol
    {
        private TypeSymbol? _type;

        [SymbolProperty]
        public virtual bool? IsDeclaredConst => false;
        [SymbolProperty]
        public virtual TypeSymbol? DeclaredType => null;
        [SymbolProperty]
        public virtual ExpressionSymbol? DeclaredInitializer => null;

        public bool HasConstantValue { get; }
        public object? ConstantValue { get; }

        public TypeWithAnnotations TypeWithAnnotations => null;

        public virtual TypeSymbol? Type
        {
            get
            {
                if (_type is null)
                {
                    var type = this.DeclaredType;
                    var container = this.ContainingSymbol;
                    if (this.DeclaredType is null)
                    {
                        if (container is IVariableTypeInferrer inferrer)
                        {
                            type = inferrer.VariableType;
                        }
                    }
                    if (type?.IsSpecialSymbol(SpecialSymbol.Var) ?? false)
                    {
                        if (this.Initializer is not null)
                        {
                            type = this.Initializer?.Type;
                        }
                        else if (container is IVariableTypeInferrer inferrer)
                        {
                            type = inferrer.VariableType;
                        }
                    }
                    Interlocked.CompareExchange(ref _type, type, null);
                }
                return _type;
            }
        }

        public virtual bool? IsConst
        {
            get
            {
                if (this.IsDeclaredConst is not null) return this.IsDeclaredConst;
                else if (this.ContainingSymbol is IVariableTypeInferrer inferrer) return inferrer.IsConstVariable;
                else return null;
            }
        }

        public virtual ExpressionSymbol? Initializer
        {
            get
            {
                if (this.DeclaredInitializer is not null) return this.DeclaredInitializer;
                else if (this.ContainingSymbol is IVariableTypeInferrer inferrer) return inferrer.VariableInitializer;
                else return null;
            }
        }

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            if (this.IsConst ?? false)
            {
                this.Initializer?.CheckExpressionIsConstant(diagnostics);
            }
            var type = this.Type;
            if (type is not null && !type.IsSpecialSymbol(SpecialSymbol.Var))
            {
                this.Initializer?.CheckExpressionType(this.Type, diagnostics);
            }
            else
            {
                diagnostics.Add(ModelErrorCode.ERR_CannotInferVarType.ToDiagnostic(this.Locations.FirstOrNone(), this.Name));
            }
        }
    }
}

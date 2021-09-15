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
        [SymbolProperty]
        public virtual bool? IsConst => false;
        [SymbolProperty]
        public virtual TypeSymbol? Type => null;
        [SymbolProperty]
        public virtual ExpressionSymbol? Initializer => null;

        public bool HasConstantValue { get; }
        public object? ConstantValue { get; }

        public TypeWithAnnotations TypeWithAnnotations => null;

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            if (this.IsConst ?? false)
            {
                this.Initializer?.CheckExpressionIsConstant(diagnostics);
            }
            if (this.Type is not null)
            {
                this.Initializer?.CheckExpressionType(this.Type, diagnostics);
            }
        }
    }
}

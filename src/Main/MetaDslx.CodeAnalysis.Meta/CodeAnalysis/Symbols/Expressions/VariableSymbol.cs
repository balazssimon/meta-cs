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
        public virtual bool? IsConst => false;
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
                    if (this.DeclaredType is null && this.ContainingSymbol is VariableDeclarationExpressionSymbol varDecl)
                    {
                        type = varDecl.DeclaredType;
                    }
                    if (type?.IsSpecialSymbol(SpecialSymbol.Var) ?? false)
                    {
                        type = this.Initializer?.Type;
                    }
                    Interlocked.CompareExchange(ref _type, type, null);
                }
                return _type;
            }
        }

        public virtual ExpressionSymbol? Initializer
        {
            get
            {
                if (this.DeclaredInitializer is not null) return this.DeclaredInitializer;
                else if (this.ContainingSymbol is VariableDeclarationExpressionSymbol varDecl) return varDecl.Initializer;
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
            if (this.Type is not null)
            {
                this.Initializer?.CheckExpressionType(this.Type, diagnostics);
            }
        }
    }
}

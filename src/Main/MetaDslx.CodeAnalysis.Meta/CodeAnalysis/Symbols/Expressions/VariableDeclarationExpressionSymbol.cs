using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a declarator that declares multiple individual variables.
    /// </summary>
    [Symbol]
    public abstract partial class VariableDeclarationExpressionSymbol : ExpressionSymbol, IVariableTypeInferrer
    {
        private TypeSymbol? _variableType;
        private int _isConstVariable = -1;
        private ExpressionSymbol? _variableInitializer;

        [SymbolProperty]
        public virtual bool? IsDeclaredConst => false;
        [SymbolProperty]
        public virtual TypeSymbol? DeclaredType => null;

        /// <summary>
        /// Variable symbols declared by this variable declaration.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<VariableSymbol> Variables { get; }

        /// <summary>
        /// Optional initializer of the variables.
        /// </summary>
        /// <remarks>
        /// The initializer may be located either in the <see cref="VariableSymbol"/> or here. It is only allowed to have initializer in one of these locations.
        /// </remarks>
        [SymbolProperty]
        public abstract ExpressionSymbol? DeclaredInitializer { get; }

        TypeSymbol? IVariableTypeInferrer.VariableType
        {
            get
            {
                if (_variableType is null)
                {
                    var type = this.DeclaredType;
                    var container = this.ContainingSymbol;
                    if (type?.IsSpecialSymbol(SpecialSymbol.Var) ?? false)
                    {
                        var initializer = ((IVariableTypeInferrer)this).VariableInitializer;
                        if (initializer is not null)
                        {
                            type = initializer?.Type;
                        }
                        else if (container is IVariableTypeInferrer inferrer)
                        {
                            type = inferrer.VariableType;
                        }
                    }
                    Interlocked.CompareExchange(ref _variableType, type, null);
                }
                return _variableType;
            }
        }

        bool? IVariableTypeInferrer.IsConstVariable
        {
            get
            {
                if (this.IsDeclaredConst is not null) return this.IsDeclaredConst;
                else if (this.ContainingSymbol is IVariableTypeInferrer inferrer) return inferrer.IsConstVariable;
                else return null;
            }
        }

        ExpressionSymbol? IVariableTypeInferrer.VariableInitializer
        {
            get
            {
                if (this.DeclaredInitializer is not null) return this.DeclaredInitializer;
                else if (this.ContainingSymbol is IVariableTypeInferrer inferrer) return inferrer.VariableInitializer;
                else return null;
            }
        }

        protected override void AddDeclaredLocals(ArrayBuilder<LocalSymbol> result)
        {
            base.AddDeclaredLocals(result);
            result.AddRange(this.Variables);
        }
    }
}

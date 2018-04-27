using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public interface ISymbolBoundNode
    {
        ISymbol Symbol { get; }
    }

    public class SymbolBoundNode : BoundNode, ISymbolBoundNode
    {
        private readonly Lazy<ISymbol> _symbol;

        public SymbolBoundNode(int kind, RedNode redNode, BoundTree boundTree, ImmutableArray<Binder> binders, bool hasErrors = false) 
            : base(kind, redNode, boundTree, binders, hasErrors)
        {
            _symbol = this.GetCurrentLazy((ISymbolBinder b) => b.GetSymbol());
        }

        public override bool HasAnyErrors
        {
            get
            {
                if (base.HasAnyErrors) return true;
                if (this.Symbol == null) return false;
                return this.Symbol == this.Compilation.ErrorSymbol || this.Symbol.MType == this.Compilation.ErrorSymbol;
            }
        }

        public ISymbol Symbol
        {
            get { return _symbol.Value; }
        }
    }
}

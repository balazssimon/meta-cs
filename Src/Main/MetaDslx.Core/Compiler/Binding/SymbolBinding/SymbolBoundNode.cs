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
        object Value { get; }
    }

    public class SymbolBoundNode : BoundNode, ISymbolBoundNode
    {
        private readonly Lazy<ISymbol> _symbol;
        private readonly Lazy<object> _value;

        public SymbolBoundNode(int kind, RedNode redNode, BoundTree boundTree, bool hasErrors = false) 
            : base(kind, redNode, boundTree, hasErrors)
        {
            _symbol = this.GetSingleValue<ISymbol>(r => this.Binder.GetSymbol(r));
            _value = this.GetSingleValue<object>(r => this.Binder.GetValue(r));
        }

        public override bool HasAnyErrors
        {
            get
            {
                if (base.HasAnyErrors) return true;
                if (_symbol == null) return false;
                if (_symbol.Value == this.Compilation.ErrorSymbol || _symbol.Value?.MType == this.Compilation.ErrorSymbol) return true;
                return false;
            }
        }

        public new ISymbolBinder Binder
        {
            get
            {
                return base.GetBinder<ISymbolBinder>();
            }
        }

        public ISymbol Symbol
        {
            get { return _symbol.Value; }
        }

        public object Value
        {
            get { return _value.Value; }
        }
    }
}

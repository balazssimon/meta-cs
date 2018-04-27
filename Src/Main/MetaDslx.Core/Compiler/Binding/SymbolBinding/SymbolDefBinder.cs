using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class SymbolDefBinder : SymbolBinder
    {
        private Type _symbolType;
        private ISymbol _symbol;

        public SymbolDefBinder(Binder next, Type symbolType) : base(next)
        {
            _symbolType = symbolType;
        }

        public override void Bind()
        {

        }

        public override Optional<ISymbol> GetSymbol()
        {
            if (_symbol != null) return new Optional<ISymbol>(_symbol);
            else return Optional<ISymbol>.None;
        }

        public override Optional<object> GetValue()
        {
            if (_symbol != null) return new Optional<object>(_symbol);
            else return Optional<object>.None;
        }

        public override bool AddNameBinder(ArrayBuilder<ISymbolBinder> result)
        {
            return true;
        }

        public override bool AddPropertyBinder(ArrayBuilder<ISymbolBinder> result)
        {
            return true;
        }

        public override bool AddValueBinder(ArrayBuilder<ISymbolBinder> result)
        {
            result.Add(this);
            return true;
        }

        public override bool AddIdentifierBinder(ArrayBuilder<ISymbolBinder> result)
        {
            return true;
        }
    }
}

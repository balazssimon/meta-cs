using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using System.Collections.Immutable;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface ISymbolCtrBinder : ISymbolDefBinder
    {

    }

    public sealed class SymbolCtrBinder : Binder, ISymbolCtrBinder
    {
        private readonly Type _symbolType;

        public SymbolCtrBinder(Binder next, RedNode node, Type symbolType)
            : base(next, node)
        {
            _symbolType = symbolType;
        }

        public Type SymbolType
        {
            get { return _symbolType; }
        }

        public IMetaSymbol Symbol
        {
            get
            {
                return null;
            }
        }

        public object Value
        {
            get
            {
                return this.Symbol;
            }
        }

        public ImmutableArray<IMetaSymbol> DefinedSymbols
        {
            get
            {
                return ImmutableArray<IMetaSymbol>.Empty;
            }
        }

        public ImmutableArray<IMetaSymbol> GetSymbols()
        {
            return ImmutableArray<IMetaSymbol>.Empty;
        }

        public ImmutableArray<object> GetValues()
        {
            return ImmutableArray<object>.Empty;
        }
    }
}

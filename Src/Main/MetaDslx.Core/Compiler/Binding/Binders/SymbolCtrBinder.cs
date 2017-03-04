using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using System.Collections.Immutable;
using System.Threading;
using MetaDslx.Compiler.Diagnostics;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface ISymbolCtrBinder : ISymbolDefBinder, IValueBinder
    {

    }

    public sealed class SymbolCtrBinder : Binder, ISymbolCtrBinder
    {
        private readonly Type _symbolType;
        private ISymbol _symbol;

        public SymbolCtrBinder(Binder next, RedNode node, Type symbolType)
            : base(next, node)
        {
            _symbolType = symbolType;
        }

        public Type SymbolType
        {
            get { return _symbolType; }
        }

        public ISymbol Symbol
        {
            get
            {
                if (_symbol == null)
                {
                    var symbol = this.Compilation.SymbolBuilder.BuildSymbol(null, this.Node, null, _symbolType);
                    Interlocked.CompareExchange(ref _symbol, symbol, null);
                }
                return _symbol;
            }
        }

        public object Value
        {
            get
            {
                return this.Symbol;
            }
        }

        public ImmutableArray<ISymbol> DefinedSymbols
        {
            get
            {
                if (this.Symbol != null) return ImmutableArray.Create(_symbol);
                else return ImmutableArray<ISymbol>.Empty;
            }
        }

        public ImmutableArray<ISymbol> GetSymbols()
        {
            return this.DefinedSymbols;
        }

        public ImmutableArray<object> GetValues()
        {
            return this.DefinedSymbols.CastArray<object>();
        }

        public ImmutableArray<Diagnostic> GetErrors()
        {
            return ImmutableArray<Diagnostic>.Empty;
        }
    }
}

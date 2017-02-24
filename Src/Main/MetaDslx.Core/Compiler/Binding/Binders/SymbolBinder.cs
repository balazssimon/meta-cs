using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface ISymbolBinder //: IValueBinder
    {
    }

    public interface ISymbolDefBinder : ISymbolBinder
    {
        ImmutableArray<IMetaSymbol> DefinedSymbols { get; }
    }

    public sealed class SymbolBinder : Binder, ISymbolDefBinder
    {
        private readonly Type _symbolType;
        private ImmutableArray<IMetaSymbol> _lazyDefinedSymbols;

        public SymbolBinder(Binder next, RedNode node, Type symbolType)
            : base(next, node)
        {
            _symbolType = symbolType;
        }

        public Type SymbolType
        {
            get { return _symbolType; }
        }

        public ImmutableArray<IMetaSymbol> DefinedSymbols
        {
            get
            {
                if (_lazyDefinedSymbols.IsDefault)
                {
                    ImmutableInterlocked.InterlockedExchange(ref _lazyDefinedSymbols, this.GetNameBinders().SelectMany(b => b.DefinedSymbols).Where(s => s != null).ToImmutableArray());
                }
                return _lazyDefinedSymbols;
            }
        }

        public object Value
        {
            get
            {
                return this.Symbol;
            }
        }

        public IMetaSymbol Symbol
        {
            get
            {
                return this.DefinedSymbols.FirstOrDefault();
            }
        }

        public ImmutableArray<INameBinder> GetNameBinders()
        {
            return this.FindDescendantBinders<INameBinder>(b => true, b => b is IPropertyBinder);
        }

        public ImmutableArray<object> GetValues()
        {
            return this.DefinedSymbols.CastArray<object>();
        }

        public ImmutableArray<IMetaSymbol> GetSymbols()
        {
            return this.DefinedSymbols;
        }
    }
}

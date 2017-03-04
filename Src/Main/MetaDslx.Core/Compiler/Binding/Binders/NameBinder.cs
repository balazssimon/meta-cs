using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
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
    public interface INameBinder //: IValueBinder
    {
        ImmutableArray<ISymbol> DefinedSymbols { get; }
    }

    public sealed class NameBinder : Binder, INameBinder
    {
        private ImmutableArray<ISymbol> _lazyDefinedSymbols;

        public NameBinder(Binder next, RedNode node) 
            : base(next, node)
        {
        }

        public ImmutableArray<ISymbol> DefinedSymbols
        {
            get
            {
                if (_lazyDefinedSymbols.IsDefault)
                {
                    var qualifierBinders = this.FindDescendantBinders<IQualifierBinder>();
                    ArrayBuilder<ISymbol> builder = ArrayBuilder<ISymbol>.GetInstance();
                    try
                    {
                        foreach (var qualifierBinder in qualifierBinders)
                        {
                            var symbol = qualifierBinder.Symbol;
                            if (symbol != null)
                            {
                                builder.Add(qualifierBinder.Symbol);
                            }
                        }
                    }
                    finally
                    {
                        ImmutableInterlocked.InterlockedExchange(ref _lazyDefinedSymbols, builder.ToImmutableAndFree());
                    }
                }
                return _lazyDefinedSymbols;
            }
        }

        public ISymbol Symbol
        {
            get
            {
                return this.DefinedSymbols.FirstOrDefault();
            }
        }

        public object Value
        {
            get
            {
                return this.Symbol;
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
    }
}

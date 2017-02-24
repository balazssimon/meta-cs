using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface ISymbolUseBinder : IValueBinder
    {
        ImmutableArray<IMetaSymbol> UsedSymbols { get; }
    }

    public sealed class SymbolUseBinder : Binder, ISymbolUseBinder
    {
        private readonly ImmutableArray<Type> _symbolTypes;
        private ImmutableArray<IMetaSymbol> _lazyUsedSymbols;
        private readonly BindingOptions _bindingOptions;

        public SymbolUseBinder(Binder next, RedNode node, ImmutableArray<Type> symbolTypes) 
            : base(next, node)
        {
            _symbolTypes = symbolTypes;
            if (_symbolTypes.Length > 0)
            {
                _bindingOptions = next.BindingOptions.WithSymbolTypes(symbolTypes);
            }
            else
            {
                _bindingOptions = next.BindingOptions;
            }
        }

        public ImmutableArray<Type> SymbolTypes
        {
            get { return _symbolTypes; }
        }

        public override BindingOptions BindingOptions
        {
            get
            {
                return _bindingOptions;
            }
        }

        public ImmutableArray<IMetaSymbol> UsedSymbols
        {
            get
            {
                if (_lazyUsedSymbols.IsDefault)
                {
                    var valueBinders = this.FindDescendantBinders<IValueBinder>();
                    var values = valueBinders.SelectMany(v => v.GetSymbols());
                    ImmutableInterlocked.InterlockedExchange(ref _lazyUsedSymbols, values.ToImmutableArray());
                }
                return _lazyUsedSymbols;
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
                return this.UsedSymbols.FirstOrDefault();
            }
        }

        public ImmutableArray<Diagnostic> GetErrors()
        {
            var valueBinders = this.FindDescendantBinders<IValueBinder>();
            var errors = valueBinders.SelectMany(v => v.GetErrors()).ToImmutableArray();
            return errors;
        }

        public ImmutableArray<object> GetValues()
        {
            return this.UsedSymbols.CastArray<object>();
        }

        public ImmutableArray<IMetaSymbol> GetSymbols()
        {
            return this.UsedSymbols;
        }
    }
}

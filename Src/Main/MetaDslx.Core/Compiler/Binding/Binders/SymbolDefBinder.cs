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
        Type SymbolType { get; }
        ImmutableArray<ISymbol> DefinedSymbols { get; }
    }

    public sealed class SymbolDefBinder : Binder, ISymbolDefBinder
    {
        private readonly Type _symbolType;
        private readonly Type _nestingSymbolType;
        private ImmutableArray<ISymbol> _lazyDefinedSymbols;
        private BindingOptions _lazyBindingOptions;
        private BindingOptions _lazyNestingBindingOptions;

        public SymbolDefBinder(Binder next, RedNode node, Type symbolType, Type nestingSymbolType)
            : base(next, node)
        {
            _symbolType = symbolType;
            _nestingSymbolType = nestingSymbolType;
        }

        public Type SymbolType
        {
            get { return _symbolType; }
        }

        public Type NestingSymbolType
        {
            get { return _nestingSymbolType; }
        }

        public override BindingOptions BindingOptions
        {
            get
            {
                if (_lazyBindingOptions == null)
                {
                    var options = BindingOptions.Default.WithSymbolTypes(ImmutableArray.Create(_symbolType));
                    Interlocked.CompareExchange(ref _lazyBindingOptions, options, null);
                }
                return _lazyBindingOptions;
            }
        }

        public override BindingOptions NestingBindingOptions
        {
            get
            {
                if (_lazyNestingBindingOptions == null)
                {
                    var options = BindingOptions.Default.WithSymbolTypes(ImmutableArray.Create(_nestingSymbolType));
                    Interlocked.CompareExchange(ref _lazyNestingBindingOptions, options, null);
                }
                return _lazyNestingBindingOptions;
            }
        }

        public ImmutableArray<ISymbol> DefinedSymbols
        {
            get
            {
                if (_lazyDefinedSymbols.IsDefault)
                {
                    ImmutableInterlocked.InterlockedExchange(ref _lazyDefinedSymbols, this.GetNameBinders().SelectMany(b => b.DefinedSymbols).Where(s => s != null).ToImmutableArray());
                    this.ExecuteCustomBinders();
                }
                return _lazyDefinedSymbols;
            }
        }

        private void ExecuteCustomBinders()
        {
            var customBinders = this.FindDescendantBinders<ICustomBinder>(cb => true, b => !(b is ISymbolDefBinder));
            foreach (var customBinder in customBinders)
            {
                customBinder.CustomBind();
            }
        }

        public object Value
        {
            get
            {
                return this.Symbol;
            }
        }

        public ISymbol Symbol
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

        public ImmutableArray<ISymbol> GetSymbols()
        {
            return this.DefinedSymbols;
        }
    }
}

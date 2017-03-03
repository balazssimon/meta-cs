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
    public interface ISymbolUseBinder : IValueBinder
    {
        ImmutableArray<ISymbol> UsedSymbols { get; }
    }

    public sealed class SymbolUseBinder : Binder, ISymbolUseBinder
    {
        private readonly ImmutableArray<Type> _symbolTypes;
        private readonly ImmutableArray<Type> _nestingSymbolTypes;
        private ImmutableArray<ISymbol> _lazyUsedSymbols;
        private BindingOptions _lazyBindingOptions;

        public SymbolUseBinder(Binder next, RedNode node, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes) 
            : base(next, node)
        {
            _symbolTypes = symbolTypes;
            _nestingSymbolTypes = nestingSymbolTypes;
        }

        public ImmutableArray<Type> SymbolTypes
        {
            get { return _symbolTypes; }
        }

        public ImmutableArray<Type> NestingSymbolTypes
        {
            get { return _nestingSymbolTypes; }
        }

        public override BindingOptions BindingOptions
        {
            get
            {
                if (_lazyBindingOptions == null)
                {
                    var options = BindingOptions.Default;
                    var parentSymbolUseBinder = this.FindAncestorBinder<ISymbolUseBinder>();
                    if (parentSymbolUseBinder != null) options = this.Next.BindingOptions;
                    if (_symbolTypes.Length > 0)
                    {
                        options = options.WithSymbolTypes(_symbolTypes);
                    }
                    Interlocked.CompareExchange(ref _lazyBindingOptions, options, null);
                }
                return _lazyBindingOptions;
            }
        }

        public override BindingOptions NestingBindingOptions
        {
            get
            {
                if (_lazyBindingOptions == null)
                {
                    var options = BindingOptions.Default;
                    var parentSymbolUseBinder = this.FindAncestorBinder<ISymbolUseBinder>();
                    if (parentSymbolUseBinder != null) options = this.Next.NestingBindingOptions;
                    if (_nestingSymbolTypes.Length > 0)
                    {
                        options = options.WithSymbolTypes(_nestingSymbolTypes);
                    }
                    Interlocked.CompareExchange(ref _lazyBindingOptions, options, null);
                }
                return _lazyBindingOptions;
            }
        }

        public ImmutableArray<ISymbol> UsedSymbols
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

        public ISymbol Symbol
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

        public ImmutableArray<ISymbol> GetSymbols()
        {
            return this.UsedSymbols;
        }
    }
}

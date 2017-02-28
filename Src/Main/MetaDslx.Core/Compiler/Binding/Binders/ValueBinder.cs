using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using MetaDslx.Core;
using MetaDslx.Compiler.Diagnostics;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IValueBinder
    {
        object Value { get; }
        ISymbol Symbol { get; }
        ImmutableArray<Diagnostic> GetErrors();
        ImmutableArray<object> GetValues();
        ImmutableArray<ISymbol> GetSymbols();
    }

    public class ValueBinder : Binder, IValueBinder
    {
        private readonly object _value;

        public ValueBinder(Binder next, RedNode node, object value) 
            : base(next, node)
        {
            _value = value;
        }

        public object Value
        {
            get { return _value; }
        }

        public ISymbol Symbol
        {
            get { return _value as ISymbol; }
        }

        public ImmutableArray<object> GetValues()
        {
            return ImmutableArray.Create(_value);
        }

        public ImmutableArray<ISymbol> GetSymbols()
        {
            if (_value is ISymbol) return ImmutableArray.Create((ISymbol)_value);
            else return ImmutableArray<ISymbol>.Empty;
        }

        public ImmutableArray<Diagnostic> GetErrors()
        {
            return ImmutableArray<Diagnostic>.Empty;
        }
    }
}

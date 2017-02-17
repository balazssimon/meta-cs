﻿using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IValueBinder
    {
        object Value { get; }
        IMetaSymbol Symbol { get; }
        ImmutableArray<object> GetValues();
        ImmutableArray<IMetaSymbol> GetSymbols();
    }

    public sealed class ValueBinder : Binder, IValueBinder
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

        public IMetaSymbol Symbol
        {
            get { return _value as IMetaSymbol; }
        }

        public ImmutableArray<object> GetValues()
        {
            return ImmutableArray.Create(_value);
        }

        public ImmutableArray<IMetaSymbol> GetSymbols()
        {
            if (_value is IMetaSymbol) return ImmutableArray.Create((IMetaSymbol)_value);
            else return ImmutableArray<IMetaSymbol>.Empty;
        }
    }
}

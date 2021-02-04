using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : ValueBinder
    {
        private readonly Type _type;
        private readonly Type _nestingType;
        private Symbol _definedSymbol;

        public SymbolDefBinder(SyntaxNodeOrToken syntax, Binder next, Type type, Type nestingType) 
            : base(syntax, next)
        {
            _type = type;
            _nestingType = nestingType;
            _definedSymbol = null;
        }

        public Symbol DefinedSymbol => throw new NotImplementedException();

        public IEnumerable<object> Values => throw new NotImplementedException();

        public override Symbol GetDefinedSymbol()
        {
            if (_definedSymbol == null)
            {
                var symbol = this.Bind(Syntax, default).Symbol;
                Interlocked.CompareExchange(ref _definedSymbol, symbol, null);
            }
            return _definedSymbol;
        }

    }
}

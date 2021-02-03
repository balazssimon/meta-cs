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
    public class SymbolDefBinder : Binder
    {
        private readonly Type _type;
        private readonly Type _nestingType;
        private Symbol _definedSymbol;
        private readonly SyntaxNodeOrToken _syntax;

        public SymbolDefBinder(Binder next, SyntaxNodeOrToken syntax, Type type, Type nestingType) 
            : base(next)
        {
            _type = type;
            _nestingType = nestingType;
            _syntax = syntax;
            _definedSymbol = null;
        }

        public override Symbol GetDefinedSymbol()
        {
            if (_definedSymbol == null)
            {
                var symbol = this.Bind(_syntax, default).Symbol;
                Interlocked.CompareExchange(ref _definedSymbol, symbol, null);
            }
            return _definedSymbol;
        }

        public override SymbolDefBinder FindSymbolDefBinder(SyntaxNodeOrToken syntax, Symbol symbol)
        {
            if (this.ContainingSymbol == symbol.ContainingSymbol && _syntax == syntax) return this;
            else return Next.FindSymbolDefBinder(syntax, symbol);
        }
    }
}

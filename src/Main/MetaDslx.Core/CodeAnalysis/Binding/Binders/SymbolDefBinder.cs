using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : Binder
    {
        private readonly Type _symbolType;
        private readonly Type _nestingSymbolType;
        private ImmutableArray<Symbol> _definedSymbols;
        private readonly LanguageSyntaxNode _syntax;

        public SymbolDefBinder(Binder next, LanguageSyntaxNode syntax, Type symbolType, Type nestingSymbolType) 
            : base(next)
        {
            _symbolType = symbolType;
            _nestingSymbolType = nestingSymbolType;
            _syntax = syntax;
        }

        public ImmutableArray<Symbol> DefinedSymbols
        {
            get
            {
                if (_definedSymbols.IsDefault)
                {
                    var boundNode = this.Compilation.GetBoundNodes(_syntax).OfType<BoundSymbolDef>().FirstOrDefault();
                    var symbols = boundNode?.Symbols ?? ImmutableArray<Symbol>.Empty;
                    ImmutableInterlocked.InterlockedInitialize(ref _definedSymbols, symbols);
                }
                return _definedSymbols;
            }
        }
    }
}

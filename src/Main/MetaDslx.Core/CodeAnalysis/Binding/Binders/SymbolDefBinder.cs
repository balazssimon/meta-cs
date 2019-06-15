using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : Binder
    {
        private readonly Type _symbolType;
        private readonly Type _nestingSymbolType;
        private Symbol _definedSymbol;
        private readonly LanguageSyntaxNode _syntax;

        public SymbolDefBinder(Binder next, LanguageSyntaxNode syntax, Type symbolType, Type nestingSymbolType) 
            : base(next)
        {
            _symbolType = symbolType;
            _nestingSymbolType = nestingSymbolType;
            _syntax = syntax;
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                if (_definedSymbol == null)
                {
                    var boundNode = this.Compilation.GetBoundNodes(_syntax).OfType<BoundSymbolDef>().FirstOrDefault();
                    if (boundNode != null)
                    {
                        Interlocked.CompareExchange(ref _definedSymbol, boundNode.Symbol, null);
                    }
                }
                return _definedSymbol;
            }
        }
    }
}

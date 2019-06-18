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

        public Symbol DefinedSymbol
        {
            get
            {
                if (_definedSymbol == null)
                {
                    var containingSymbol = this.Next.ContainingSymbol as NamespaceOrTypeSymbol;
                    var symbol = containingSymbol?.GetSourceMember(_syntax);
                    Interlocked.CompareExchange(ref _definedSymbol, symbol, null);
                }
                return _definedSymbol;
            }
        }

        public override Symbol ContainingSymbol => this.DefinedSymbol;
    }
}

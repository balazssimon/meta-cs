using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolCtrBinder : Binder
    {
        private readonly Type _symbolType;
        private Symbol _definedSymbol;
        private readonly LanguageSyntaxNode _syntax;

        public SymbolCtrBinder(Binder next, LanguageSyntaxNode syntax, Type symbolType)
            : base(next)
        {
            _symbolType = symbolType;
            _syntax = syntax;
        }

        public Symbol DefinedSymbol
        {
            get
            {
                if (_definedSymbol == null)
                {
                    var boundNode = this.Compilation.GetBoundNode<BoundSymbolCtr>(_syntax);
                    if (boundNode == null) return null;
                    Interlocked.CompareExchange(ref _definedSymbol, boundNode.ConstructedSymbol, null);
                }
                return _definedSymbol;
            }
        }

        public override NamespaceOrTypeSymbol GetEnclosingDeclarationSymbol(SyntaxNodeOrToken syntax)
        {
            return this.DefinedSymbol as NamespaceOrTypeSymbol;
        }

    }
}

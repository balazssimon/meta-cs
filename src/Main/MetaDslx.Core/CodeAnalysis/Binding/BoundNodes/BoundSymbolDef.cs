using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolDef : BoundSymbol
    {
        private Type _symbolType;
        private Symbol _lazySymbol;

        public BoundSymbolDef(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolType = symbolType;
        }

        public override Symbol Symbol
        {
            get
            {
                if (_lazySymbol == null)
                {
                    var binder = this.GetBinder();
                    var containerSymbol = binder?.GetContainerSymbol(this.Syntax);
                    var names = this.GetNames();
                    // Debug.Assert(names.Length == 1);
                    Symbol symbol = null;
                    if (names.Length == 1)
                    {
                        var qualifier = names[0].Identifiers;
                        foreach (var identifier in qualifier)
                        {
                            symbol = containerSymbol?.GetSourceMember(identifier.Syntax);
                            containerSymbol = symbol as NamespaceOrTypeSymbol;
                        }
                    }
                    Interlocked.CompareExchange(ref _lazySymbol, symbol, null);
                }
                return _lazySymbol;
            }
        }
    }
}

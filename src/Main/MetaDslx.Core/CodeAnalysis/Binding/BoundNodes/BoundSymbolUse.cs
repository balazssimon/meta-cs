using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolUse : BoundSymbol
    {
        private ImmutableArray<Type> _symbolTypes;
        private ImmutableArray<Type> _nestingSymbolTypes;
        private Symbol _lazySymbol;

        public BoundSymbolUse(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolTypes = symbolTypes;
            _nestingSymbolTypes = nestingSymbolTypes;
        }

        public override Symbol Symbol
        {
            get
            {
                if (_lazySymbol == null)
                {
                    var binder = this.GetEnclosingBinder();
                    // binder.LookupSymbolsSimpleName(...);
                    Symbol symbol = null;
                    Interlocked.CompareExchange(ref _lazySymbol, symbol, null);
                }
                return _lazySymbol;
            }
        }
    }
}

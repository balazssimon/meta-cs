using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolUse : BoundValues
    {
        private ImmutableArray<Type> _symbolTypes;
        private ImmutableArray<Type> _nestingSymbolTypes;
        private ImmutableArray<Symbol> _lazySymbols;

        public BoundSymbolUse(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolTypes = symbolTypes;
            _nestingSymbolTypes = nestingSymbolTypes;
        }

        public ImmutableArray<Symbol> Symbols
        {
            get
            {
                if (_lazySymbols == null)
                {
                    var binder = this.GetEnclosingBinder();
                    // binder.LookupSymbolsSimpleName(...);
                    ImmutableArray<Symbol> symbols = ImmutableArray<Symbol>.Empty;
                    ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, symbols);
                }
                return _lazySymbols;
            }
        }

        public override ImmutableArray<object> Values => StaticCast<object>.From(this.Symbols);
    }
}

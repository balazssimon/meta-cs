using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolDef : BoundSymbols
    {
        private Type _symbolType;
        private ImmutableArray<Symbol> _lazySymbols;

        public BoundSymbolDef(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolType = symbolType;
        }

        public override ImmutableArray<Symbol> Symbols
        {
            get
            {
                if (_lazySymbols.IsDefault)
                {
                    var names = this.GetChildNames();
                    var symbols = ArrayBuilder<Symbol>.GetInstance();
                    foreach (var name in names)
                    {
                        symbols.AddRange(name.Symbols);
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, symbols.ToImmutableAndFree());
                }
                return _lazySymbols;
            }
        }
    }
}

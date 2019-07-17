using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolCtr : BoundSymbols
    {
        private ModelSymbolInfo _symbolInfo;
        private Symbol _lazySymbol;

        public BoundSymbolCtr(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolInfo = ModelSymbolInfo.GetSymbolInfo(symbolType);
        }

        public ModelSymbolInfo SymbolInfo => _symbolInfo;

        public Symbol ConstructedSymbol
        {
            get
            {
                if (_lazySymbol == null)
                {
                    var properties = this.GetChildProperties();
                    var symbol = this.Compilation.CreateConstructedSymbol(this.Syntax.GetReference(), _symbolInfo, properties);
                    Interlocked.CompareExchange(ref _lazySymbol, symbol, null);
                }
                return _lazySymbol;
            }
        }

        public override ImmutableArray<Symbol> Symbols
        {
            get
            {
                return ImmutableArray.Create(this.ConstructedSymbol);
            }
        }

        protected override void ForceCompleteNode(CancellationToken cancellationToken)
        {
            this.SetPropertyValues((MutableSymbolBase)this.ConstructedSymbol.ModelObject, this.DiagnosticBag, cancellationToken);
        }

    }
}

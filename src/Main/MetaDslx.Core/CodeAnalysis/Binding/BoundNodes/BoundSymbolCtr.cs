using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
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
        private ImmutableArray<Symbol> _lazySymbols;

        public BoundSymbolCtr(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolInfo = ModelSymbolInfo.GetSymbolInfo(symbolType);
        }

        public ModelSymbolInfo SymbolInfo => _symbolInfo;

        public override ImmutableArray<Symbol> Symbols
        {
            get
            {
                if (_lazySymbols.IsDefault)
                {
                    var propertyValues = this.GetPropertyValues();
                    var symbol = this.Compilation.CreateConstructedSymbol(this.Syntax.GetReference(), _symbolInfo, propertyValues);
                    ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, ImmutableArray.Create(symbol));
                }
                return _lazySymbols;
            }
        }

    }
}

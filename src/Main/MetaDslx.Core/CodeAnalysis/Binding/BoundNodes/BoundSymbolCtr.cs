using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolCtr : BoundSymbol
    {
        private ModelSymbolInfo _symbolInfo;
        private Symbol _lazySymbol;

        public BoundSymbolCtr(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolInfo = ModelSymbolInfo.GetSymbolInfo(symbolType);
        }

        public ModelSymbolInfo SymbolInfo => _symbolInfo;

        public override Symbol Symbol
        {
            get
            {
                if (_lazySymbol == null)
                {
                    var propertyValues = this.GetPropertyValues();
                    Interlocked.CompareExchange(ref _lazySymbol, this.Compilation.CreateConstructedSymbol(this.Syntax.GetReference(), _symbolInfo, propertyValues), null);
                }
                return _lazySymbol;
            }
        }

    }
}

using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.BoundTree
{
    public class BoundSymbol : BoundNode
    {
        private readonly Symbol _symbol;

        protected BoundSymbol(BoundKind kind, LanguageSyntaxNode syntax, Symbol symbol, bool hasErrors = false)
            : base(kind, syntax)
        {
            _symbol = symbol;
        }

        public Symbol Symbol => _symbol;
    }
}

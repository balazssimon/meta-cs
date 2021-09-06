using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class BoundImport : BoundNode
    {
        private readonly DeclaredSymbol _symbol;

        public BoundImport(DeclaredSymbol symbol)
        {
            _symbol = symbol;
        }

        public DeclaredSymbol Symbol { get; }
    }
}

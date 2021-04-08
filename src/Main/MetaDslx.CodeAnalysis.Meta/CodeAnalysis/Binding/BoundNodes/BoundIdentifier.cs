using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundIdentifier : BoundSymbol
    {
        private DeclaredSymbol _symbol;
        private ImmutableArray<Diagnostic> _diagnostics;

        public BoundIdentifier(DeclaredSymbol symbol, ImmutableArray<Diagnostic> diagnostics)
        {
            _symbol = symbol;
            _diagnostics = diagnostics;
        }

        public DeclaredSymbol Symbol => _symbol;
        public override ImmutableArray<Diagnostic> Diagnostics => _diagnostics;

        public override ImmutableArray<Symbol> Symbols => _symbol != null ? ImmutableArray.Create((Symbol)_symbol) : ImmutableArray<Symbol>.Empty;

    }
}

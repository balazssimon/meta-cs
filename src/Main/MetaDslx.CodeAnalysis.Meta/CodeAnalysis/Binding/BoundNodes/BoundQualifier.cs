using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Linq;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundQualifier : BoundSymbol
    {
        private ImmutableArray<SyntaxNodeOrToken> _identifiers;
        private ImmutableArray<DeclaredSymbol> _identifierSymbols;
        private ImmutableArray<Diagnostic> _diagnostics;

        public BoundQualifier(ImmutableArray<SyntaxNodeOrToken> identifiers, ImmutableArray<DeclaredSymbol> identifierSymbols, ImmutableArray<Diagnostic> diagnostics)
        {
            _identifiers = identifiers;
            _identifierSymbols = identifierSymbols;
            _diagnostics = diagnostics;
        }

        public ImmutableArray<SyntaxNodeOrToken> Identifiers => _identifiers;
        public ImmutableArray<DeclaredSymbol> IdentifierSymbols => _identifierSymbols;
        public override ImmutableArray<Diagnostic> Diagnostics => _diagnostics;

        public override ImmutableArray<Symbol> Symbols => _identifierSymbols.Length > 0 ? ImmutableArray.Create((Symbol)_identifierSymbols[_identifierSymbols.Length - 1]) : ImmutableArray<Symbol>.Empty;
    }
}

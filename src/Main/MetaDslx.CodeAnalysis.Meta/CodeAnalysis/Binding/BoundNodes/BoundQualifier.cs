using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
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

        public BoundQualifier(ImmutableArray<SyntaxNodeOrToken> identifiers, ImmutableArray<DeclaredSymbol> identifierSymbols)
        {
            _identifiers = identifiers;
            _identifierSymbols = identifierSymbols;
        }

        public ImmutableArray<SyntaxNodeOrToken> Identifiers => _identifiers;
        public ImmutableArray<DeclaredSymbol> IdentifierSymbols => _identifierSymbols;

        public override ImmutableArray<Symbol> Symbols => _identifierSymbols.Length > 0 ? ImmutableArray.Create((Symbol)_identifierSymbols[_identifierSymbols.Length - 1]) : ImmutableArray<Symbol>.Empty;
    }
}

using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundQualifier : BoundSymbol
    {
        private ImmutableDictionary<SyntaxNodeOrToken, ImmutableArray<Symbol>> _identifiers;

        public BoundQualifier(SyntaxNodeOrToken syntax, BoundNode parent, ImmutableArray<Symbol> symbols, CandidateReason candidateReason, ImmutableDictionary<SyntaxNodeOrToken, ImmutableArray<Symbol>> identifiers)
            : base(syntax, parent, symbols, candidateReason)
        {
            _identifiers = identifiers;
        }

        public ImmutableArray<Symbol> GetIdentifierSymbols(SyntaxNodeOrToken identifier)
        {
            if (_identifiers.TryGetValue(identifier, out var result)) return result;
            else return default;
        }
    }
}

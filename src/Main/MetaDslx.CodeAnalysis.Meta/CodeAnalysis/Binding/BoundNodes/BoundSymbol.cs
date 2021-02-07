using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbol : BoundNode
    {
        private ImmutableArray<Symbol> _symbols;
        private CandidateReason _candidateReason;

        public BoundSymbol(SyntaxNodeOrToken syntax, BoundNode parent, ImmutableArray<Symbol> symbols, CandidateReason candidateReason) 
            : base(syntax, parent)
        {
            _symbols = symbols;
            _candidateReason = candidateReason;
        }

        public ImmutableArray<Symbol> Symbols => _symbols;

        public CandidateReason CandidateReason => _candidateReason;
    }
}

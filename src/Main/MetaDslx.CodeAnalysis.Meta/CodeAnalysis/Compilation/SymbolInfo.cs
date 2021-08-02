﻿using System;
using System.Collections.Immutable;
using System.Linq;
using Roslyn.Utilities;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;

namespace MetaDslx.CodeAnalysis
{
    public struct SymbolInfo : IEquatable<SymbolInfo>
    {
        internal static readonly SymbolInfo None = new SymbolInfo(null, ImmutableArray<Symbol>.Empty, CandidateReason.None);

        private ImmutableArray<Symbol> _candidateSymbols;

        /// <summary>
        /// The symbol that was referred to by the syntax node, if any. Returns null if the given
        /// expression did not bind successfully to a single symbol. If null is returned, it may
        /// still be that case that we have one or more "best guesses" as to what symbol was
        /// intended. These best guesses are available via the CandidateSymbols property.
        /// </summary>
        public Symbol? Symbol { get; }

        /// <summary>
        /// If the expression did not successfully resolve to a symbol, but there were one or more
        /// symbols that may have been considered but discarded, this property returns those
        /// symbols. The reason that the symbols did not successfully resolve to a symbol are
        /// available in the CandidateReason property. For example, if the symbol was inaccessible,
        /// ambiguous, or used in the wrong context.
        /// </summary>
        public ImmutableArray<Symbol> CandidateSymbols
        {
            get
            {
                return _candidateSymbols.NullToEmpty();
            }
        }

        internal ImmutableArray<Symbol> GetAllSymbols()
        {
            if (this.Symbol != null)
            {
                return ImmutableArray.Create<Symbol>(this.Symbol);
            }
            else
            {
                return _candidateSymbols;
            }
        }

        ///<summary>
        /// If the expression did not successfully resolve to a symbol, but there were one or more
        /// symbols that may have been considered but discarded, this property describes why those
        /// symbol or symbols were not considered suitable.
        /// </summary>
        public CandidateReason CandidateReason { get; }

        internal SymbolInfo(Symbol symbol)
            : this(symbol, ImmutableArray<Symbol>.Empty, CandidateReason.None)
        {
        }

        internal SymbolInfo(Symbol symbol, CandidateReason reason)
            : this(symbol, ImmutableArray<Symbol>.Empty, reason)
        {
        }

        internal SymbolInfo(ImmutableArray<Symbol> candidateSymbols, CandidateReason candidateReason)
            : this(null, candidateSymbols, candidateReason)
        {
        }

        internal SymbolInfo(Symbol? symbol, ImmutableArray<Symbol> candidateSymbols, CandidateReason candidateReason)
            : this()
        {
            this.Symbol = symbol;
            _candidateSymbols = candidateSymbols.IsDefault ? ImmutableArray.Create<Symbol>() : candidateSymbols;
            this.CandidateReason = candidateReason;
        }

        public override bool Equals(object? obj)
        {
            return obj is SymbolInfo && Equals((SymbolInfo)obj);
        }

        public bool Equals(SymbolInfo other)
        {
            if (!object.Equals(this.Symbol, other.Symbol) ||
                _candidateSymbols.IsDefault != other._candidateSymbols.IsDefault ||
                this.CandidateReason != other.CandidateReason)
            {
                return false;
            }

            return _candidateSymbols.IsDefault || _candidateSymbols.SequenceEqual(other._candidateSymbols);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Symbol, Hash.Combine(Hash.CombineValues(_candidateSymbols, 4), (int)this.CandidateReason));
        }

        internal bool IsEmpty
        {
            get
            {
                return this.Symbol == null
                    && this.CandidateSymbols.Length == 0;
            }
        }
    }
}

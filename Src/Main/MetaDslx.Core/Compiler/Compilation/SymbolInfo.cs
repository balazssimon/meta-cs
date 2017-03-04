﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Linq;
using System.Diagnostics;
using MetaDslx.Core;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler
{
    public sealed class SymbolInfo : IEquatable<SymbolInfo>
    {
        public static readonly SymbolInfo None = new SymbolInfo(null, ImmutableArray<ISymbol>.Empty, CandidateReason.None);

        private ImmutableArray<ISymbol> _candidateSymbols;

        /// <summary>
        /// The symbol that was referred to by the syntax node, if any. Returns null if the given
        /// expression did not bind successfully to a single symbol. If null is returned, it may
        /// still be that case that we have one or more "best guesses" as to what symbol was
        /// intended. These best guesses are available via the CandidateSymbols property.
        /// </summary>
        public ISymbol Symbol { get; }

        /// <summary>
        /// If the expression did not successfully resolve to a symbol, but there were one or more
        /// symbols that may have been considered but discarded, this property returns those
        /// symbols. The reason that the symbols did not successfully resolve to a symbol are
        /// available in the CandidateReason property. For example, if the symbol was inaccessible,
        /// ambiguous, or used in the wrong context.
        /// </summary>
        public ImmutableArray<ISymbol> CandidateSymbols
        {
            get
            {
                return _candidateSymbols.NullToEmpty();
            }
        }

        public ImmutableArray<ISymbol> GetAllSymbols()
        {
            if (this.Symbol != null)
            {
                return ImmutableArray.Create<ISymbol>(this.Symbol);
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

        public SymbolInfo(ISymbol symbol)
            : this(symbol, ImmutableArray<ISymbol>.Empty, CandidateReason.None)
        {
        }

        public SymbolInfo(ISymbol symbol, CandidateReason reason)
            : this(symbol, ImmutableArray<ISymbol>.Empty, reason)
        {
        }

        public SymbolInfo(ImmutableArray<ISymbol> candidateSymbols, CandidateReason candidateReason)
            : this(null, candidateSymbols, candidateReason)
        {
        }

        public SymbolInfo(ISymbol symbol, ImmutableArray<ISymbol> candidateSymbols, CandidateReason candidateReason)
        {
            this.Symbol = symbol;
            _candidateSymbols = candidateSymbols.IsDefault ? ImmutableArray.Create<ISymbol>() : candidateSymbols;
            this.CandidateReason = candidateReason;
        }

        public override bool Equals(object obj)
        {
            return obj is SymbolInfo && Equals((SymbolInfo)obj);
        }

        public bool Equals(SymbolInfo other)
        {
            return object.Equals(this.Symbol, other.Symbol)
                && ((_candidateSymbols.IsDefault && other._candidateSymbols.IsDefault) || _candidateSymbols.SequenceEqual(other._candidateSymbols))
                && this.CandidateReason == other.CandidateReason;
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Symbol, Hash.Combine(Hash.CombineValues(_candidateSymbols, 4), (int)this.CandidateReason));
        }

        public bool IsEmpty
        {
            get
            {
                return this.Symbol == null
                    && this.CandidateSymbols.Length == 0;
            }
        }
    }
}

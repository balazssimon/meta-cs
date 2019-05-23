// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public sealed class UnsupportedSymbol : Symbol, IMetaErrorSymbol
    {
        private ISymbol _symbol;

        internal UnsupportedSymbol(ISymbol symbol)
        {
            _symbol = symbol;
        }

        public ISymbol Symbol => _symbol;

        public override SymbolKind Kind => _symbol.Kind;

        public override Symbol ContainingSymbol => null;

        public override ImmutableArray<Location> Locations => _symbol.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _symbol.DeclaringSyntaxReferences;

        public override bool IsStatic => _symbol.IsStatic;

        public override void Accept(SymbolVisitor visitor)
        {
            // nop
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return default;
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return default;
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            // nop
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return default;
        }
    }
}

// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using System;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public sealed class UnsupportedCSharpSymbol : NamedTypeSymbol, IErrorSymbol
    {
        private Symbol _containingSymbol;
        private Microsoft.CodeAnalysis.CSharp.Symbol _symbol;

        internal UnsupportedCSharpSymbol(Microsoft.CodeAnalysis.CSharp.Symbol symbol, Symbol containingSymbol)
        {
            _containingSymbol = containingSymbol;
            _symbol = symbol;
        }

        public ISymbol Symbol => _symbol.GetPublicSymbol();

        public override bool IsError => true;

        public override string Name => _symbol.Name;

        public override string MetadataName => _symbol.MetadataName;

        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        public override Symbol ContainingSymbol => _containingSymbol;

        public override ImmutableArray<Location> Locations => _symbol.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public DiagnosticInfo ErrorInfo => LanguageDiagnosticInfo.EmptyErrorInfo;

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

    }
}

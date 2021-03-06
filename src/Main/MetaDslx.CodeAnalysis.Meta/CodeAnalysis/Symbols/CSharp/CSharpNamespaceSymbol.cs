﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpSymbol = Microsoft.CodeAnalysis.CSharp.Symbol;

    public class CSharpNamespaceSymbol : NamespaceSymbol
    {
        private NonMissingModuleSymbol _module;
        private CSharpSymbols.NamespaceSymbol _csharpSymbol;

        internal CSharpNamespaceSymbol(NonMissingModuleSymbol module, CSharpSymbols.NamespaceSymbol csharpSymbol)
        {
            _module = module;
            _csharpSymbol = csharpSymbol;
        }

        internal CSharpSymbolMap CSharpSymbolMap => _module.CSharpSymbolMap;

        internal CSharpSymbols.NamespaceSymbol CSharpSymbol => _csharpSymbol;

        public override string Name => _csharpSymbol.Name;

        public override string MetadataName => _csharpSymbol.MetadataName;

        public override NamespaceExtent Extent => new NamespaceExtent(_module);

        public override Symbol ContainingSymbol => CSharpSymbolMap.GetSymbol(_csharpSymbol.ContainingSymbol);

        public override ImmutableArray<Location> Locations => _csharpSymbol.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpSymbol.DeclaringSyntaxReferences;

        public override ImmutableArray<Symbol> GetMembers()
        {
            var csharpMembers = _csharpSymbol.GetMembers();
            var builder = ArrayBuilder<Symbol>.GetInstance(csharpMembers.Length);
            foreach (CSharpSymbol csharpMember in csharpMembers)
            {
                builder.Add(CSharpSymbolMap.GetSymbol(csharpMember));
            }
            return builder.ToImmutableAndFree();
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            return GetMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            var csharpMembers = _csharpSymbol.GetTypeMembers();
            var builder = ArrayBuilder<NamedTypeSymbol>.GetInstance(csharpMembers.Length);
            foreach (CSharpSymbols.NamedTypeSymbol csharpMember in csharpMembers)
            {
                builder.Add(CSharpSymbolMap.GetNamedTypeSymbol(csharpMember));
            }
            return builder.ToImmutableAndFree();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return GetTypeMembers().WhereAsArray(m => m.Name == name);
        }

    }
}

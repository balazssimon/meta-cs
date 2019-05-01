using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpSymbol = Microsoft.CodeAnalysis.CSharp.Symbol;

    public class CSharpNamespaceSymbol : NamespaceSymbol
    {
        private CSharpModuleSymbol _module;
        private CSharpSymbols.NamespaceSymbol _csharpSymbol;

        private CSharpNamespaceSymbol(CSharpModuleSymbol module, CSharpSymbols.NamespaceSymbol csharpSymbol)
        {
            _module = module;
            _csharpSymbol = csharpSymbol;
        }

        internal static CSharpNamespaceSymbol FromCSharp(CSharpSymbols.NamespaceSymbol csharpSymbol)
        {
            return new CSharpNamespaceSymbol(CSharpSymbolMap.GetModuleSymbol(csharpSymbol.ContainingModule), csharpSymbol);
        }

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

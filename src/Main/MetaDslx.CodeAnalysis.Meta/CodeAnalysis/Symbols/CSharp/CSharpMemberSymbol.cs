using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpSymbol = Microsoft.CodeAnalysis.CSharp.Symbol;

    public class CSharpMemberSymbol : MemberSymbol
    {
        private CSharpModuleSymbol _module;
        private CSharpSymbol _csharpSymbol;

        internal CSharpMemberSymbol(CSharpModuleSymbol module, CSharpSymbol csharpSymbol)
        {
            _module = module;
            _csharpSymbol = csharpSymbol;
        }

        public override Language Language => CSharpLanguage.Instance;

        public override MemberKind MemberKind => Language.SymbolFacts.MemberKindFromCSharpKind(_csharpSymbol.Kind);

        internal CSharpSymbolMap CSharpSymbolMap => _module.CSharpSymbolMap;

        internal CSharpSymbol CSharpSymbol => _csharpSymbol;

        public override string Name => _csharpSymbol.Name;

        public override string MetadataName => _csharpSymbol.MetadataName;

        public override Symbol ContainingSymbol => CSharpSymbolMap.GetSymbol(_csharpSymbol.ContainingSymbol);

        public override ImmutableArray<Location> Locations => _csharpSymbol.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpSymbol.DeclaringSyntaxReferences;

        public override bool IsStatic => _csharpSymbol.IsStatic;

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return ImmutableArray<DeclaredSymbol>.Empty;
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return GetMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return GetTypeMembers().WhereAsArray(m => m.Name == name);
        }

    }
}

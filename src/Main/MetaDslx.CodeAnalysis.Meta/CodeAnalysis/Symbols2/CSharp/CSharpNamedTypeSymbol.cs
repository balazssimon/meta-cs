using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpSymbol = Microsoft.CodeAnalysis.CSharp.Symbol;
    using Roslyn.Utilities;
    using Microsoft.CodeAnalysis.PooledObjects;

    public class CSharpNamedTypeSymbol : NamedTypeSymbol
    {
        private CSharpModuleSymbol _module;
        private CSharpSymbols.NamedTypeSymbol _csharpSymbol;
        private ImmutableArray<NamedTypeSymbol> _lazyBaseTypes;

        internal CSharpNamedTypeSymbol(CSharpModuleSymbol module, CSharpSymbols.NamedTypeSymbol csharpSymbol)
        {
            _module = module;
            _csharpSymbol = csharpSymbol;
        }

        internal CSharpSymbolMap CSharpSymbolMap => _module.CSharpSymbolMap;

        public override LanguageSymbolKind Kind => Language.SymbolFacts.FromCSharpKind(_csharpSymbol.Kind);

        public override string Name => _csharpSymbol.Name;

        public override string MetadataName => _csharpSymbol.MetadataName;

        public override int Arity => _csharpSymbol.Arity;

        public override bool MangleName => _csharpSymbol.MangleName;

        public override SpecialType SpecialType => _csharpSymbol.SpecialType;

        public override LanguageTypeKind TypeKind => Language.SymbolFacts.FromCSharpKind(_csharpSymbol.TypeKind);

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return CSharpSymbolMap.GetMemberSymbols(_csharpSymbol.GetMembers());
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return CSharpSymbolMap.GetMemberSymbols(_csharpSymbol.GetMembers(name));
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return GetMembers(name).WhereAsArray(s => s.MetadataName == metadataName);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return CSharpSymbolMap.GetNamedTypeSymbols(_csharpSymbol.GetTypeMembers());
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return CSharpSymbolMap.GetNamedTypeSymbols(_csharpSymbol.GetTypeMembers(name));
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return GetTypeMembers(name).WhereAsArray(s => s.MetadataName == metadataName);
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        internal CSharpSymbols.NamedTypeSymbol CSharpSymbol => _csharpSymbol;

        public override Symbol ContainingSymbol => CSharpSymbolMap.GetSymbol(_csharpSymbol.ContainingSymbol);

        public override ImmutableArray<Location> Locations => _csharpSymbol.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpSymbol.DeclaringSyntaxReferences;

        public override IEnumerable<string> MemberNames => _csharpSymbol.MemberNames;

        public override ImmutableArray<NamedTypeSymbol> BaseTypesNoUseSiteDiagnostics
        {
            get
            {
                if (_lazyBaseTypes.IsDefault)
                {
                    var baseTypes = ArrayBuilder<NamedTypeSymbol>.GetInstance();
                    if ((object)_csharpSymbol.BaseTypeNoUseSiteDiagnostics != null)
                    {
                        baseTypes.Add(CSharpSymbolMap.GetNamedTypeSymbol(_csharpSymbol.BaseTypeNoUseSiteDiagnostics));
                    }
                    foreach (var intf in _csharpSymbol.InterfacesNoUseSiteDiagnostics())
                    {
                        baseTypes.Add(CSharpSymbolMap.GetNamedTypeSymbol(intf));
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyBaseTypes, baseTypes.ToImmutableAndFree());
                }
                return _lazyBaseTypes;
            }
        }
    }
}
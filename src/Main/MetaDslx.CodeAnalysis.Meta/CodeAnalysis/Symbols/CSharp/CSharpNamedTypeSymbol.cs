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

        public override Language Language => CSharpLanguage.Instance;

        internal CSharpSymbolMap CSharpSymbolMap => _module.CSharpSymbolMap;

        public override string Name => _csharpSymbol.Name;

        public override string MetadataName => _csharpSymbol.MetadataName;

        public override bool CanBeReferencedByName => _csharpSymbol.CanBeReferencedByName;

        public override int Arity => _csharpSymbol.Arity;

        public override bool MangleName => _csharpSymbol.MangleName;

        public override ImmutableArray<DeclaredSymbol> Members => CSharpSymbolMap.GetMemberSymbols(_csharpSymbol.GetMembers());

        public INamedTypeSymbol CSharpSymbol => (INamedTypeSymbol)_csharpSymbol.ISymbol;

        public override Symbol ContainingSymbol => CSharpSymbolMap.GetSymbol(_csharpSymbol.ContainingSymbol);

        public override ImmutableArray<Location> Locations => _csharpSymbol.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpSymbol.DeclaringSyntaxReferences;

        public override IEnumerable<string> MemberNames => _csharpSymbol.MemberNames;

        public override ImmutableArray<NamedTypeSymbol> BaseTypes
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

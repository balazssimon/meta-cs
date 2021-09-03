using System;
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
        private CSharpModuleSymbol _module;
        private CSharpSymbols.NamespaceSymbol _csharpSymbol;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;

        internal CSharpNamespaceSymbol(CSharpModuleSymbol module, CSharpSymbols.NamespaceSymbol csharpSymbol)
        {
            _module = module;
            _csharpSymbol = csharpSymbol;
        }

        public override Language Language => CSharpLanguage.Instance;

        internal CSharpSymbolMap CSharpSymbolMap => _module.CSharpSymbolMap;

        public INamespaceSymbol CSharpSymbol => (INamespaceSymbol)_csharpSymbol.ISymbol;

        public override string Name => _csharpSymbol.Name;

        public override string MetadataName => _csharpSymbol.MetadataName;

        public override bool CanBeReferencedByName => _csharpSymbol.CanBeReferencedByName;

        public override NamespaceExtent Extent => new NamespaceExtent(_module);

        public override Symbol ContainingSymbol => _csharpSymbol.ContainingSymbol is CSharpSymbols.ModuleSymbol ? _module : CSharpSymbolMap.GetSymbol(_csharpSymbol.ContainingSymbol);

        public override ImmutableArray<Location> Locations => _csharpSymbol.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpSymbol.DeclaringSyntaxReferences;

        public override ImmutableArray<DeclaredSymbol> Members
        {
            get
            {
                if (_lazyMembers.IsDefault)
                {
                    var csharpMembers = _csharpSymbol.GetMembers();
                    var builder = ArrayBuilder<DeclaredSymbol>.GetInstance(csharpMembers.Length);
                    foreach (CSharpSymbol csharpMember in csharpMembers)
                    {
                        builder.Add((DeclaredSymbol)CSharpSymbolMap.GetSymbol(csharpMember));
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyMembers, builder.ToImmutableAndFree());
                }
                return _lazyMembers;
            }
        }

    }
}

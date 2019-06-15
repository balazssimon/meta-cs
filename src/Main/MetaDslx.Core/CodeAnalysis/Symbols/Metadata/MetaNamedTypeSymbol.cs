using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaNamedTypeSymbol : NamedTypeSymbol, IMetaMetadataSymbol
    {
        private IMetaSymbol _metaObject;
        private Symbol _container;
        private ImmutableArray<string> _lazyMemberNames;
        private ImmutableArray<Symbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public MetaNamedTypeSymbol(IMetaSymbol metaObject, Symbol container)
        {
            Debug.Assert(metaObject != null);
            _metaObject = metaObject;
            _container = container;
        }

        public MetaSymbolMap MetaSymbolMap => ((IMetaMetadataSymbol)_container).MetaSymbolMap;

        public override string Name => _metaObject.MName;

        public override SymbolKind Kind => SymbolKind.NamedType;

        public override IEnumerable<string> MemberNames
        {
            get
            {
                if (_lazyMemberNames.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyMemberNames, _metaObject.MChildren.Select(child => child.MName).ToImmutableArray());
                }
                return _lazyMemberNames;
            }
        }

        public override Symbol ContainingSymbol => _container;

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            if (_lazyMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyMembers, MetaSymbolMap.GetSymbols(_metaObject.MChildren));
            }
            return _lazyMembers;
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            return GetMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<Symbol> GetMembers(string name, string metadataName)
        {
            return GetMembers().WhereAsArray(m => m.Name == name && m.MetadataName == metadataName);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            if (_lazyTypeMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeMembers, MetaSymbolMap.GetNamedTypeSymbols(_metaObject.MChildren.Where(child => child.MId.SymbolInfo.IsNamedType)));
            }
            return _lazyTypeMembers;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return GetTypeMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return GetTypeMembers().WhereAsArray(m => m.Name == name && m.MetadataName == metadataName);
        }
    }
}

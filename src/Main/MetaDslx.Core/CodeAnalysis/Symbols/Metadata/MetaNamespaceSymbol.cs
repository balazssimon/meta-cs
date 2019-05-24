using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaNamespaceSymbol : NamespaceSymbol, IMetaMetadataSymbol
    {
        private IMetaSymbol _metaObject;
        private Symbol _container;
        private ImmutableArray<Symbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public MetaNamespaceSymbol(IMetaSymbol metaObject, Symbol container)
        {
            if (metaObject == null) throw new ArgumentNullException(nameof(metaObject));
            _metaObject = metaObject;
            _container = container;
        }

        public MetaSymbolMap MetaSymbolMap => ((IMetaMetadataSymbol)_container).MetaSymbolMap;

        public override NamespaceExtent Extent => (_container as MetaNamespaceSymbol)?.Extent ?? new NamespaceExtent(_container.ContainingModule);

        public override Symbol ContainingSymbol => _container;

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override string Name => _metaObject.MName;

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

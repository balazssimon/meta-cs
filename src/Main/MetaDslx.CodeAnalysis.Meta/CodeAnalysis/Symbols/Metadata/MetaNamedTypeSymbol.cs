using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
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
        private IModelObject _metaObject;
        private Symbol _container;
        private ImmutableArray<string> _lazyMemberNames;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public MetaNamedTypeSymbol(IModelObject metaObject, Symbol container)
        {
            Debug.Assert(metaObject != null);
            _metaObject = metaObject;
            _container = container;
        }

        public MetaSymbolMap MetaSymbolMap => ((IMetaMetadataSymbol)_container).MetaSymbolMap;

        public override string Name => _metaObject.MName;

        public override LanguageSymbolKind Kind => LanguageSymbolKind.NamedType;

        public override ModelObjectDescriptor ModelSymbolInfo => _metaObject.MId.Descriptor;

        public override IModelObject ModelObject => _metaObject;

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
            return this.GetDeclaredBaseTypes(basesBeingResolved);
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            var result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            foreach (var prop in _metaObject.MProperties.Where(p => p.IsBaseScope))
            {
                foreach (var baseType in (IEnumerable<IModelObject>)_metaObject.MGet(prop))
                {
                    result.Add(MetaSymbolMap.GetNamedTypeSymbol(baseType));
                }
            }
            return result.ToImmutableAndFree();
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            if (_lazyMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyMembers, MetaSymbolMap.GetMemberSymbols(_metaObject.MChildren));
            }
            return _lazyMembers;
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return GetMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return GetMembers().WhereAsArray(m => m.Name == name && m.MetadataName == metadataName);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            if (_lazyTypeMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeMembers, MetaSymbolMap.GetNamedTypeSymbols(_metaObject.MChildren.Where(child => child.MId.Descriptor.IsNamedType)));
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

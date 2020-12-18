using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public abstract class ModelNamespaceSymbol : NamespaceSymbol, IModelSymbol
    {
        private Symbol _container;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public ModelNamespaceSymbol(Symbol container)
        {
            _container = container;
        }

        public ModelSymbolMap ModelSymbolMap => ((IModelSymbol)_container).ModelSymbolMap;

        public abstract IModelObject ModelObject { get; }

        public override NamespaceExtent Extent
        {
            get
            {
                if (_container is ModelNamespaceSymbol containingNamespace) return containingNamespace.Extent;
                if (_container is ModuleSymbol containingModule) return new NamespaceExtent(containingModule);
                return new NamespaceExtent(_container.ContainingModule);
            }
        }

        public sealed override Symbol ContainingSymbol => _container;

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public sealed override string Name => ModelObject.MName;

        public ModelObjectDescriptor ModelSymbolInfo => ModelObject.MId.Descriptor;

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            if (_lazyMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyMembers, ModelSymbolMap.GetMemberSymbols(ModelObject.MChildren));
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
                ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeMembers, ModelSymbolMap.GetNamedTypeSymbols(ModelObject.MChildren.Where(child => child.MId.Descriptor.IsNamedType)));
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

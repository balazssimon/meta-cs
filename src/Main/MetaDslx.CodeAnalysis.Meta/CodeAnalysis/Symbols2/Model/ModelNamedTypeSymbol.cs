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
    public abstract class ModelNamedTypeSymbol : NamedTypeSymbol, IModelSymbol
    {
        private Symbol _container;
        private ImmutableArray<string> _lazyMemberNames;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public ModelNamedTypeSymbol(Symbol container)
        {
            _container = container;
        }

        public ModelSymbolMap ModelSymbolMap => ((IModelSymbol)_container).ModelSymbolMap;

        public sealed override Language Language => _container.Language;

        public abstract IModelObject ModelObject { get; }

        public sealed override string Name => ModelObject.MName;

        public ModelObjectDescriptor ModelSymbolInfo => ModelObject.MId.Descriptor;

        public override IEnumerable<string> MemberNames
        {
            get
            {
                if (_lazyMemberNames.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyMemberNames, ModelObject.MChildren.Select(child => child.MName).ToImmutableArray());
                }
                return _lazyMemberNames;
            }
        }

        public sealed override Symbol ContainingSymbol => _container;

        public sealed override NamedTypeSymbol ContainingType => _container as NamedTypeSymbol;

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            return this.GetDeclaredBaseTypes(basesBeingResolved);
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            var result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            foreach (var prop in ModelObject.MProperties.Where(p => p.IsBaseScope))
            {
                foreach (var baseType in (IEnumerable<IModelObject>)ModelObject.MGet(prop))
                {
                    result.Add(ModelSymbolMap.GetNamedTypeSymbol(baseType));
                }
            }
            return result.ToImmutableAndFree();
        }

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

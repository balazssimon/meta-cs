using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class ModelNamespaceSymbol : NamespaceSymbol, IModelSymbol
    {
        private Symbol _container;
        private object _modelObject;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public ModelNamespaceSymbol(Symbol container, object modelObject)
        {
            Debug.Assert(container is IModelSymbol);
            _container = container;
            _modelObject = modelObject;
        }

        public sealed override Language Language => ContainingModule.Language;

        public SymbolFactory SymbolFactory => ((IModelSymbol)_container).SymbolFactory;

        public object ModelObject => _modelObject;

        public Type ModelObjectType => _modelObject != null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;

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

        public sealed override string Name => _modelObject != null ? Language.SymbolFacts.GetName(_modelObject) : string.Empty;

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            if (_lazyMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyMembers, SymbolFactory.GetChildDeclaredSymbols(ModelObject));
            }
            return _lazyMembers;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            if (_lazyTypeMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeMembers, GetMembers().OfType<NamedTypeSymbol>().ToImmutableArray());
            }
            return _lazyTypeMembers;
        }

    }
}

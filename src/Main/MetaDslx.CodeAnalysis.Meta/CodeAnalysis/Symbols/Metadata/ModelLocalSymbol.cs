using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class ModelLocalSymbol : LocalSymbol
    {
        private Symbol _container;
        private object _modelObject;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public ModelLocalSymbol(Symbol container, object modelObject)
        {
            Debug.Assert(container is IModelSymbol);
            if (modelObject == null) throw new ArgumentNullException(nameof(modelObject));
            _container = container;
            _modelObject = modelObject;
        }

        public sealed override Language Language => ContainingModule.Language;

        public override LocalKind LocalKind => LocalKind.None;

        public SymbolFactory SymbolFactory => ((IModelSymbol)_container).SymbolFactory;

        public object ModelObject => _modelObject;

        public Type ModelObjectType => _modelObject != null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;

        public sealed override string Name => _modelObject != null ? Language.SymbolFacts.GetName(_modelObject) : string.Empty;

        public sealed override Symbol ContainingSymbol => _container;

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override bool IsStatic => false;

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

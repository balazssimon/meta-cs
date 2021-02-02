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
    public class ModelNamedTypeSymbol : NamedTypeSymbol, IModelSymbol
    {
        private Symbol _container;
        private object _modelObject;
        private ImmutableArray<string> _lazyMemberNames;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public ModelNamedTypeSymbol(Symbol container, object modelObject)
        {
            Debug.Assert(container is IModelSymbol);
            if (modelObject == null) throw new ArgumentNullException(nameof(modelObject));
            _container = container;
            _modelObject = modelObject;
        }

        public ObjectFactory ObjectFactory => ((IModelSymbol)_container).ObjectFactory;

        public SymbolFactory SymbolFactory => ((IModelSymbol)_container).SymbolFactory;

        public object ModelObject => _modelObject;

        public sealed override Language Language => _container.Language;

        public sealed override string Name => ObjectFactory.GetName(_modelObject);

        public override IEnumerable<string> MemberNames
        {
            get
            {
                if (_lazyMemberNames.IsDefault)
                {
                    var sf = Language.SymbolFactory;
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyMemberNames, ObjectFactory.GetChildren(_modelObject).Select(child => ObjectFactory.GetName(child)).ToImmutableArray());
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
            var sf = Language.SymbolFactory;
            foreach (var prop in sf.GetProperties(this.ModelObject, SymbolConstants.BaseTypesProperty))
            {
                var baseTypeObjects = ObjectFactory.GetPropertyValues(this.ModelObject, prop);
                var baseTypeSymbols = SymbolFactory.ResolveMetaSymbols(baseTypeObjects).OfType<NamedTypeSymbol>();
                result.AddRange(baseTypeSymbols);
            }
            return result.ToImmutableAndFree();
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            if (_lazyMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyMembers, SymbolFactory.CreateMetaMemberSymbols(this, ModelObject));
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

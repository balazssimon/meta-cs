using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaMemberSymbol : MemberSymbol, IMetaMetadataSymbol
    {
        private IMetaSymbol _metaObject;
        private Symbol _container;
        private ImmutableArray<Symbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public MetaMemberSymbol(IMetaSymbol metaObject, Symbol container)
        {
            if (metaObject == null) throw new ArgumentNullException(nameof(metaObject));
            _metaObject = metaObject;
            _container = container;
        }

        public MetaSymbolMap MetaSymbolMap => ((IMetaMetadataSymbol)_container).MetaSymbolMap;

        public override ModelSymbolInfo ModelSymbolInfo => _metaObject.MId.SymbolInfo;

        public override LanguageSymbolKind Kind => LanguageSymbolKind.Name;

        public override Symbol ContainingSymbol => _container;

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override bool IsStatic => false;
    }
}

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public partial class MetadataModuleSymbol
    {
        private readonly LanguageCompilation _compilation;
        private readonly ImmutableArray<MetadataLocation> _metadataLocation;
        private GlobalNamespaceSymbol _globalNamespace;

        public MetadataModuleSymbol(AssemblySymbol owningAssembly, object model, int ordinal, LanguageCompilation? compilation = null)
            : base(owningAssembly, model, ordinal)
        {
            _compilation = compilation;
            _metadataLocation = ImmutableArray.Create(new MetadataLocation(this));
        }

        public override Language Language => this.ContainingAssembly.Language;

        public override LanguageCompilation? DeclaringCompilation => _compilation;

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return _metadataLocation.Cast<MetadataLocation, Location>();
            }
        }

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                if (_globalNamespace == null)
                {
                    Interlocked.CompareExchange(ref _globalNamespace, new GlobalNamespaceSymbol(this), null);
                }
                return _globalNamespace;
            }
        }

        public override ICollection<string> TypeNames => ((GlobalNamespaceSymbol)GlobalNamespace).TypeNames;

        public override ICollection<string> NamespaceNames => ((GlobalNamespaceSymbol)GlobalNamespace).NamespaceNames;


    }
}

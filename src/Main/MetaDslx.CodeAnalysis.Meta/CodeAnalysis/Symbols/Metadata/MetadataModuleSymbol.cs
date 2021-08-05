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
        private readonly ImmutableArray<MetadataLocation> _metadataLocation;

        public MetadataModuleSymbol(AssemblySymbol owningAssembly, object model, int ordinal)
            : base(owningAssembly, model, ordinal)
        {
            _metadataLocation = ImmutableArray.Create(new MetadataLocation(this));
        }

        public override Language Language => this.ContainingAssembly.Language;

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return _metadataLocation.Cast<MetadataLocation, Location>();
            }
        }

    }
}

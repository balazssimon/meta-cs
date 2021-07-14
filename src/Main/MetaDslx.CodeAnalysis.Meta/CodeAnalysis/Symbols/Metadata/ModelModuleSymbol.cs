using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public partial class MetaModuleSymbol
    {
        public MetaModuleSymbol(AssemblySymbol owningAssembly, object model, int ordinal)
            : base(owningAssembly, model, ordinal)
        {
        }
    }

}

namespace MetaDslx.CodeAnalysis.Symbols.Model
{
    public partial class ModelModuleSymbol : NonMissingModuleSymbol, IModelSymbol
    {
        private ModelGlobalNamespaceSymbol _globalNamespace;
        private SymbolFactory _symbolFactory;
        private object _model;
        private readonly int _ordinal;
        private readonly ImmutableArray<MetadataLocation> _metadataLocation;

        public ModelModuleSymbol(AssemblySymbol owningAssembly, object model, int ordinal)
        {
            _container = owningAssembly;
            _state = CompletionParts.CompletionGraph.CreateState();
            _model = model;
            _ordinal = ordinal;
            _metadataLocation = ImmutableArray.Create<MetadataLocation>(new MetadataLocation(this));
        }

        public virtual object Model => _model;

        public virtual ObjectFactory ObjectFactory => null;

        public object? ModelObject => null;

        public Type? ModelObjectType => null;

        public override int Ordinal => _ordinal;

        public override bool HasUnifiedReferences => false;

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                if (_globalNamespace == null)
                {
                    Interlocked.CompareExchange(ref _globalNamespace, new ModelGlobalNamespaceSymbol(this), null);
                }
                return _globalNamespace;
            }
        }

        public override ICollection<string> TypeNames => _globalNamespace.TypeNames;

        public override ICollection<string> NamespaceNames => _globalNamespace.NamespaceNames;

        public override ImmutableArray<Location> Locations => _metadataLocation.Cast<MetadataLocation, Location>();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override Machine Machine => Machine.Unknown;

        public override bool Bit32Required => false;

        internal override bool HasAssemblyCompilationRelaxationsAttribute => false;

        internal override bool HasAssemblyRuntimeCompatibilityAttribute => false;

        internal override CharSet? DefaultMarshallingCharSet => null;

        public override ModuleMetadata GetMetadata()
        {
            return null;
        }

    }
}

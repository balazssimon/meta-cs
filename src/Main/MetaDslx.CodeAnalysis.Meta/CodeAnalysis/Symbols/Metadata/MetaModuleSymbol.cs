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
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaModuleSymbol : NonMissingModuleSymbol, IMetaMetadataSymbol
    {
        private MetaGlobalNamespaceSymbol _globalNamespace;
        private AssemblySymbol _owningAssembly;
        private ImmutableArray<ImmutableModel> _models;
        private readonly int _ordinal;
        private readonly MetaSymbolMap _symbolMap;

        public MetaModuleSymbol(AssemblySymbol owningAssembly, ImmutableArray<ImmutableModel> models, int ordinal)
        {
            _owningAssembly = owningAssembly;
            _models = models;
            _ordinal = ordinal;
            _symbolMap = new MetaSymbolMap(this);
        }

        public MetaModuleSymbol(AssemblySymbol owningAssembly, ImmutableModelGroup modelGroup, int ordinal)
        {
            _owningAssembly = owningAssembly;
            _models = modelGroup.Models.ToImmutableArray();
            _ordinal = ordinal;
            _symbolMap = new MetaSymbolMap(this);
        }

        public ImmutableArray<ImmutableModel> Models => _models;

        public MetaSymbolMap MetaSymbolMap => _symbolMap;

        internal override CSharpSymbolMap CSharpSymbolMap => throw ExceptionUtilities.Unreachable;

        public override int Ordinal => _ordinal;

        public override bool HasUnifiedReferences => false;

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                if (_globalNamespace == null)
                {
                    Interlocked.CompareExchange(ref _globalNamespace, new MetaGlobalNamespaceSymbol(this), null);
                }
                return _globalNamespace;
            }
        }

        public override ICollection<string> TypeNames => _globalNamespace.TypeNames;

        public override ICollection<string> NamespaceNames => _globalNamespace.NamespaceNames;

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override Machine Machine => Machine.Unknown;

        public override bool Bit32Required => false;

        internal override bool HasAssemblyCompilationRelaxationsAttribute => false;

        internal override bool HasAssemblyRuntimeCompatibilityAttribute => false;

        internal override CharSet? DefaultMarshallingCharSet => null;

        public override Symbol ContainingSymbol => _owningAssembly;

        public override ModuleMetadata GetMetadata()
        {
            return null;
        }

        public override bool TryGetSymbol(IMetaSymbol modelObject, out Symbol symbol)
        {
            Debug.Assert(modelObject != null);
            if (_models.Contains(modelObject.MModel))
            {
                return this.MetaSymbolMap.TryGetSymbol(modelObject, out symbol);
            }
            symbol = null;
            return false;
        }
    }
}

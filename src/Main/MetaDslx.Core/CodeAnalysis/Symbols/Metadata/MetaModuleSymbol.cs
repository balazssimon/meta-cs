using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaModuleSymbol : ModuleSymbol, IMetaMetadataSymbol
    {
        private MetaGlobalNamespaceSymbol _globalNamespace;
        private ImmutableArray<IModel> _models;
        private readonly int _ordinal;
        private readonly MetaSymbolMap _symbolMap;

        public MetaModuleSymbol(ImmutableArray<IModel> models, int ordinal)
        {
            _models = models;
            _ordinal = ordinal;
            _symbolMap = new MetaSymbolMap(this);
        }

        public MetaModuleSymbol(IModelGroup modelGroup, int ordinal)
        {
            _models = modelGroup.Models.ToImmutableArray();
            _ordinal = ordinal;
        }

        public ImmutableArray<IModel> Models => _models;

        public MetaSymbolMap MetaSymbolMap => _symbolMap;

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

        public override ImmutableArray<AssemblyIdentity> ReferencedAssemblies => ImmutableArray<AssemblyIdentity>.Empty;

        public override ImmutableArray<AssemblySymbol> ReferencedAssemblySymbols => ImmutableArray<AssemblySymbol>.Empty;

        public override ImmutableArray<string> TypeNames => _globalNamespace.TypeNames;

        public override ImmutableArray<string> NamespaceNames => _globalNamespace.NamespaceNames;

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override ModuleMetadata GetMetadata()
        {
            return null;
        }

        public override bool GetUnificationUseSiteDiagnostic(ref DiagnosticInfo result, Symbol dependentType)
        {
            return false;
        }

        internal override void SetReferences(ModuleReferences<AssemblySymbol> moduleReferences, SourceAssemblySymbol originatingSourceAssemblyDebugOnly = null)
        {
            throw new NotImplementedException();
        }

        public override NamedTypeSymbol LookupTopLevelMetadataType(ref MetadataTypeName emittedName)
        {
            return _globalNamespace.LookupMetadataType(ref emittedName);
        }
    }
}

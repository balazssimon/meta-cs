using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal sealed class RetargetingModuleSymbol : ModuleSymbol
    {
        private AssemblySymbol _assembly;
        private IModuleSymbol _module;
        private int _ordinal;

        internal RetargetingModuleSymbol(RetargetingAssemblySymbol assembly, IModuleSymbol module, int ordinal)
        {
            _assembly = assembly;
            _module = module;
            _ordinal = ordinal;
        }

        internal RetargetingModuleSymbol(SourceAssemblySymbol assembly, IModuleSymbol module, int ordinal)
        {
            _assembly = assembly;
            _module = module;
            _ordinal = ordinal;
        }

        public override int Ordinal => _ordinal;

        public override INamespaceSymbol GlobalNamespace => _module.GlobalNamespace;

        public override ImmutableArray<AssemblyIdentity> ReferencedAssemblies => _module.ReferencedAssemblies;

        public override ImmutableArray<IAssemblySymbol> ReferencedAssemblySymbols => StaticCast<IAssemblySymbol>.From(_module.ReferencedAssemblySymbols);

        public override ModuleMetadata GetMetadata()
        {
            return _module.GetMetadata();
        }

        public override Symbol ContainingSymbol => _assembly;
    }
}

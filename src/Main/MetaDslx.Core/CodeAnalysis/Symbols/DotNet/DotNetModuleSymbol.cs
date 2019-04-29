using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal sealed class DotNetModuleSymbol : ModuleSymbol
    {
        private DotNetAssemblySymbol _assembly;
        private Microsoft.CodeAnalysis.CSharp.Symbols.ModuleSymbol _module;

        internal DotNetModuleSymbol(DotNetAssemblySymbol assembly, Microsoft.CodeAnalysis.CSharp.Symbols.ModuleSymbol module)
        {
            _assembly = assembly;
            _module = module;
        }

        public override INamespaceSymbol GlobalNamespace => _module.GlobalNamespace;

        public override ImmutableArray<AssemblyIdentity> ReferencedAssemblies => _module.ReferencedAssemblies;

        public override ImmutableArray<IAssemblySymbol> ReferencedAssemblySymbols => StaticCast<IAssemblySymbol>.From(_module.ReferencedAssemblySymbols);

        public override ModuleMetadata GetMetadata()
        {
            return _module.GetMetadata();
        }

        public override INamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol)
        {
            return _module.GetModuleNamespace(namespaceSymbol);
        }

        public override Symbol ContainingSymbol => _assembly;
    }
}

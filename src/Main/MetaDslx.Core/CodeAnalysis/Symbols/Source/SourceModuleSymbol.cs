using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class SourceModuleSymbol : ModuleSymbol
    {
        public override INamespaceSymbol GlobalNamespace => throw new NotImplementedException();

        public override ImmutableArray<AssemblyIdentity> ReferencedAssemblies => throw new NotImplementedException();

        public override ImmutableArray<IAssemblySymbol> ReferencedAssemblySymbols => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ModuleMetadata GetMetadata()
        {
            throw new NotImplementedException();
        }

        public override INamespaceSymbol GetModuleNamespace(INamespaceSymbol namespaceSymbol)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class SourceAssemblySymbol : AssemblySymbol
    {
        public override bool IsInteractive => throw new NotImplementedException();

        public override AssemblyIdentity Identity => throw new NotImplementedException();

        public override INamespaceSymbol GlobalNamespace => throw new NotImplementedException();

        public override ImmutableArray<ModuleSymbol> Modules => throw new NotImplementedException();

        public override ICollection<string> TypeNames => throw new NotImplementedException();

        public override ICollection<string> NamespaceNames => throw new NotImplementedException();

        public override bool MightContainExtensionMethods => throw new NotImplementedException();

        public override AssemblyMetadata GetMetadata()
        {
            throw new NotImplementedException();
        }

        public override INamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            throw new NotImplementedException();
        }

        public override bool GivesAccessTo(IAssemblySymbol toAssembly)
        {
            throw new NotImplementedException();
        }

        public override INamedTypeSymbol ResolveForwardedType(string fullyQualifiedMetadataName)
        {
            throw new NotImplementedException();
        }
    }
}

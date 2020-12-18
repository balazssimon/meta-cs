using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IMetaNamespaceOrTypeSymbol : INamespaceOrTypeSymbol
    {
        ImmutableArray<IDeclaredSymbol> GetMembers(string name, string metadataName);
        ImmutableArray<INamedTypeSymbol> GetTypeMembers(string name, string metadataName);
    }
}

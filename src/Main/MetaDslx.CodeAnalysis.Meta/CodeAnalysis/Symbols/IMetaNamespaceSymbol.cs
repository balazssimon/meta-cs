using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IMetaNamespaceSymbol : INamespaceSymbol
    {
        INamespaceSymbol LookupNestedNamespace(ImmutableArray<string> names);
        INamespaceSymbol GetNestedNamespace(string name);
    }
}

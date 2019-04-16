using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    public abstract class SymbolFacts
    {
        internal virtual NamespaceOrTypeSymbol OfMinimalArity(IEnumerable<NamespaceOrTypeSymbol> symbols)
        {
            NamespaceOrTypeSymbol minAritySymbol = symbols.FirstOrDefault();
            return minAritySymbol;
        }

        internal virtual NamespaceOrTypeSymbol OfSimplestMetadataName(IEnumerable<NamespaceOrTypeSymbol> symbols)
        {
            NamespaceOrTypeSymbol minAritySymbol = symbols.FirstOrDefault();
            return minAritySymbol;
        }
    }
}

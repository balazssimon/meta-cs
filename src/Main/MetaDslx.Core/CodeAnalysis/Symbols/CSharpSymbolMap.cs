using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpAssemblySymbol = Microsoft.CodeAnalysis.CSharp.Symbols.AssemblySymbol;
    using CSharpModuleSymbol = Microsoft.CodeAnalysis.CSharp.Symbols.ModuleSymbol;
    using CSharpNamespaceSymbol = Microsoft.CodeAnalysis.CSharp.Symbols.NamespaceSymbol;
    using CSharpNamedTypeSymbol = Microsoft.CodeAnalysis.CSharp.Symbols.NamedTypeSymbol;
    using CSharpSymbol = Microsoft.CodeAnalysis.CSharp.Symbol;

    internal class CSharpSymbolMap
    {
        private ConditionalWeakTable<CSharpSymbol, Symbol> map = new ConditionalWeakTable<CSharpSymbol, Symbol>();

        public T GetSymbol<TCSharp, T>(TCSharp csharpSymbol, Func<TCSharp, T> createSymbol)
            where TCSharp : CSharpSymbol
            where T : Symbol
        {
            if (csharpSymbol == null) return null;
            if (!map.TryGetValue(csharpSymbol, out Symbol symbol))
            {
                symbol = createSymbol(csharpSymbol);
                map.Add(csharpSymbol, symbol);
            }
            return (T)symbol;
        }

        public AssemblySymbol GetAssemblySymbol(CSharpAssemblySymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => AssemblySymbol.FromCSharp(cs));
        }

        public ModuleSymbol GetModuleSymbol(CSharpModuleSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => ModuleSymbol.FromCSharp(cs));
        }

        public NamespaceSymbol GetNamespaceSymbol(CSharpNamespaceSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => NamespaceSymbol.FromCSharp(cs));
        }

        public NamedTypeSymbol GetNamedTypeSymbol(CSharpNamedTypeSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => NamedTypeSymbol.FromCSharp(cs));
        }
    }
}

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpSymbol = Microsoft.CodeAnalysis.CSharp.Symbol;

    internal class CSharpSymbolMap
    {
        private static ConditionalWeakTable<CSharpSymbol, Symbol> map = new ConditionalWeakTable<CSharpSymbol, Symbol>();

        private static T GetSymbol<TCSharp, T>(TCSharp csharpSymbol, Func<TCSharp, T> createSymbol)
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

        public static Symbol GetSymbol(CSharpSymbol csharpSymbol)
        {
            if (csharpSymbol is CSharpSymbols.AssemblySymbol assembly) return GetAssemblySymbol(assembly);
            if (csharpSymbol is CSharpSymbols.ModuleSymbol module) return GetModuleSymbol(module);
            if (csharpSymbol is CSharpSymbols.NamespaceSymbol ns) return GetNamespaceSymbol(ns);
            if (csharpSymbol is CSharpSymbols.NamedTypeSymbol namedType) return GetNamedTypeSymbol(namedType);
            return new UnsupportedSymbol(csharpSymbol);
        }

        public static CSharpAssemblySymbol GetAssemblySymbol(CSharpSymbols.AssemblySymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => CSharpAssemblySymbol.FromCSharp(cs));
        }

        public static CSharpModuleSymbol GetModuleSymbol(CSharpSymbols.ModuleSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => CSharpModuleSymbol.FromCSharp(cs));
        }

        public static CSharpNamespaceSymbol GetNamespaceSymbol(CSharpSymbols.NamespaceSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => CSharpNamespaceSymbol.FromCSharp(cs));
        }

        public static CSharpNamedTypeSymbol GetNamedTypeSymbol(CSharpSymbols.NamedTypeSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => CSharpNamedTypeSymbol.FromCSharp(cs));
        }
    }
}

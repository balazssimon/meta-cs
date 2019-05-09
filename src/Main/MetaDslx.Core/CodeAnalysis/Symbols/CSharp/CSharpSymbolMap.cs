using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
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

        public static ImmutableArray<Symbol> GetSymbols(ImmutableArray<CSharpSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetSymbol(symbol)).ToImmutableArray();
        }

        public static AssemblySymbol GetAssemblySymbol(CSharpSymbols.AssemblySymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => CSharpAssemblySymbol.FromCSharp(cs));
        }

        public static ImmutableArray<AssemblySymbol> GetAssemblySymbols(ImmutableArray<CSharpSymbols.AssemblySymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetAssemblySymbol(symbol)).ToImmutableArray();
        }

        public static ModuleSymbol GetModuleSymbol(CSharpSymbols.ModuleSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => CSharpModuleSymbol.FromCSharp(cs));
        }

        public static ImmutableArray<ModuleSymbol> GetModuleSymbols(ImmutableArray<CSharpSymbols.ModuleSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetModuleSymbol(symbol)).ToImmutableArray();
        }

        public static NamespaceSymbol GetNamespaceSymbol(CSharpSymbols.NamespaceSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => CSharpNamespaceSymbol.FromCSharp(cs));
        }

        public static ImmutableArray<NamespaceSymbol> GetNamespaceSymbols(ImmutableArray<CSharpSymbols.NamespaceSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetNamespaceSymbol(symbol)).ToImmutableArray();
        }

        public static NamedTypeSymbol GetNamedTypeSymbol(CSharpSymbols.NamedTypeSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => CSharpNamedTypeSymbol.FromCSharp(cs));
        }

        public static ImmutableArray<NamedTypeSymbol> GetNamedTypeSymbols(ImmutableArray<CSharpSymbols.NamedTypeSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetNamedTypeSymbol(symbol)).ToImmutableArray();
        }
    }
}

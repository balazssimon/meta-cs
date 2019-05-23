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
        private ConditionalWeakTable<CSharpSymbol, Symbol> map = new ConditionalWeakTable<CSharpSymbol, Symbol>();

        private CSharpModuleSymbol _module;

        public CSharpSymbolMap(CSharpModuleSymbol module)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            _module = module;
        }

        private T GetSymbol<TCSharp, T>(TCSharp csharpSymbol, Func<TCSharp, T> createSymbol)
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

        public Symbol GetSymbol(CSharpSymbol csharpSymbol)
        {
            if (csharpSymbol is CSharpSymbols.AssemblySymbol assembly) return GetAssemblySymbol(assembly);
            if (csharpSymbol is CSharpSymbols.ModuleSymbol module) return GetModuleSymbol(module);
            if (csharpSymbol is CSharpSymbols.NamespaceSymbol ns) return GetNamespaceSymbol(ns);
            if (csharpSymbol is CSharpSymbols.NamedTypeSymbol namedType) return GetNamedTypeSymbol(namedType);
            return new UnsupportedSymbol(csharpSymbol);
        }

        public ImmutableArray<Symbol> GetSymbols(ImmutableArray<CSharpSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetSymbol(symbol)).ToImmutableArray();
        }

        public AssemblySymbol GetAssemblySymbol(CSharpSymbols.AssemblySymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => new CSharpAssemblySymbol(cs));
        }

        public ImmutableArray<AssemblySymbol> GetAssemblySymbols(ImmutableArray<CSharpSymbols.AssemblySymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetAssemblySymbol(symbol)).ToImmutableArray();
        }

        public ModuleSymbol GetModuleSymbol(CSharpSymbols.ModuleSymbol csharpSymbol)
        {
            var assembly = (CSharpAssemblySymbol)GetAssemblySymbol(csharpSymbol.ContainingAssembly);
            return GetSymbol<CSharpSymbols.ModuleSymbol, ModuleSymbol>(csharpSymbol, cs => throw new InvalidOperationException("Module symbol should have been created by the assembly."));
        }

        public ImmutableArray<ModuleSymbol> GetModuleSymbols(ImmutableArray<CSharpSymbols.ModuleSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetModuleSymbol(symbol)).ToImmutableArray();
        }

        public NamespaceSymbol GetNamespaceSymbol(CSharpSymbols.NamespaceSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => new CSharpNamespaceSymbol(_module, cs));
        }

        public ImmutableArray<NamespaceSymbol> GetNamespaceSymbols(ImmutableArray<CSharpSymbols.NamespaceSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetNamespaceSymbol(symbol)).ToImmutableArray();
        }

        public NamedTypeSymbol GetNamedTypeSymbol(CSharpSymbols.NamedTypeSymbol csharpSymbol)
        {
            return GetSymbol(csharpSymbol, cs => new CSharpNamedTypeSymbol(_module, cs));
        }

        public ImmutableArray<NamedTypeSymbol> GetNamedTypeSymbols(ImmutableArray<CSharpSymbols.NamedTypeSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetNamedTypeSymbol(symbol)).ToImmutableArray();
        }

        public ImmutableArray<AttributeData> GetAttributes(ImmutableArray<CSharpSymbols.CSharpAttributeData> attributes, ref ImmutableArray<AttributeData> cachedAttributes)
        {
            if (!cachedAttributes.IsDefault) return cachedAttributes;
            else return ImmutableArray<AttributeData>.Empty; // TODO:MetaDslx
        }
    }
}

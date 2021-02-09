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
        private static ConditionalWeakTable<CSharpSymbols.AssemblySymbol, CSharpAssemblySymbol> assemblyMap = new ConditionalWeakTable<CSharpSymbols.AssemblySymbol, CSharpAssemblySymbol>();

        private ConditionalWeakTable<CSharpSymbol, Symbol> map = new ConditionalWeakTable<CSharpSymbol, Symbol>();

        private CSharpModuleSymbol _module;

        public CSharpSymbolMap(CSharpModuleSymbol module)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            _module = module;
        }

        public CSharpSymbolMap()
        {
        }

        public static bool TryGetAssemblySymbol(CSharpSymbols.AssemblySymbol csharpSymbol, out CSharpAssemblySymbol symbol)
        {
            if (csharpSymbol == null || !assemblyMap.TryGetValue(csharpSymbol, out CSharpAssemblySymbol cachedSymbol))
            {
                symbol = null;
                return false;
            }
            symbol = cachedSymbol;
            return (object)symbol != null;
        }

        public static AssemblySymbol GetAssemblySymbol(CSharpSymbols.AssemblySymbol csharpSymbol)
        {
            if (csharpSymbol == null) return null;
            if (!assemblyMap.TryGetValue(csharpSymbol, out CSharpAssemblySymbol symbol))
            {
                symbol = new CSharpAssemblySymbol(csharpSymbol);
                if ((object)symbol != null)
                {
                    assemblyMap.Add(csharpSymbol, symbol);
                }
            }
            return symbol;
        }

        public static ImmutableArray<AssemblySymbol> GetAssemblySymbols(ImmutableArray<CSharpSymbols.AssemblySymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetAssemblySymbol(symbol)).ToImmutableArray();
        }

        public static UnifiedAssembly<AssemblySymbol> GetAssemblySymbol(UnifiedAssembly<CSharpSymbols.AssemblySymbol> csharpSymbol)
        {
            return new UnifiedAssembly<AssemblySymbol>(GetAssemblySymbol(csharpSymbol.TargetAssembly), csharpSymbol.OriginalReference);
        }

        public static ImmutableArray<UnifiedAssembly<AssemblySymbol>> GetAssemblySymbols(ImmutableArray<UnifiedAssembly<CSharpSymbols.AssemblySymbol>> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetAssemblySymbol(symbol)).ToImmutableArray();
        }

        public static CSharpAssemblySymbol GetCSharpAssemblySymbol(CSharpSymbols.AssemblySymbol csharpSymbol)
        {
            return (CSharpAssemblySymbol)GetAssemblySymbol(csharpSymbol);
        }

        public static ImmutableArray<CSharpAssemblySymbol> GetCSharpAssemblySymbols(ImmutableArray<CSharpSymbols.AssemblySymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => (CSharpAssemblySymbol)GetAssemblySymbol(symbol)).ToImmutableArray();
        }

        public static UnifiedAssembly<CSharpAssemblySymbol> GetCSharpAssemblySymbol(UnifiedAssembly<CSharpSymbols.AssemblySymbol> csharpSymbol)
        {
            return new UnifiedAssembly<CSharpAssemblySymbol>(GetCSharpAssemblySymbol(csharpSymbol.TargetAssembly), csharpSymbol.OriginalReference);
        }

        public static ImmutableArray<UnifiedAssembly<CSharpAssemblySymbol>> GetCSharpAssemblySymbols(ImmutableArray<UnifiedAssembly<CSharpSymbols.AssemblySymbol>> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetCSharpAssemblySymbol(symbol)).ToImmutableArray();
        }

        public bool TryGetSymbol<TCSharp, T>(TCSharp csharpSymbol, out T symbol)
            where TCSharp : CSharpSymbol
            where T : Symbol
        {
            if (csharpSymbol is CSharpSymbols.AssemblySymbol) throw new ArgumentException("Use TryGetAssemblySymbol to get an assembly symbol.", nameof(csharpSymbol));
            if (csharpSymbol == null || !map.TryGetValue(csharpSymbol, out Symbol cachedSymbol))
            {
                symbol = null;
                return false;
            }
            symbol = (T)cachedSymbol;
            return (object)symbol != null;
        }

        private T GetSymbol<TCSharp, T>(TCSharp csharpSymbol, Func<TCSharp, T> createSymbol)
            where TCSharp : CSharpSymbol
            where T : Symbol
        {
            if (csharpSymbol == null) return null;
            if (csharpSymbol is CSharpSymbols.AssemblySymbol) throw new ArgumentException("Use GetAssemblySymbol to get an assembly symbol.", nameof(csharpSymbol));
            if (!map.TryGetValue(csharpSymbol, out Symbol symbol))
            {
                symbol = createSymbol(csharpSymbol);
                if ((object)symbol != null)
                {
                    map.Add(csharpSymbol, symbol);
                }
            }
            return (T)symbol;
        }

        public Symbol GetSymbol(CSharpSymbol csharpSymbol)
        {
            if (csharpSymbol is CSharpSymbols.AssemblySymbol assembly) return GetAssemblySymbol(assembly);
            if (csharpSymbol is CSharpSymbols.ModuleSymbol module) return GetModuleSymbol(module);
            if (csharpSymbol is CSharpSymbols.NamespaceSymbol ns) return GetNamespaceSymbol(ns);
            if (csharpSymbol is CSharpSymbols.NamedTypeSymbol namedType) return GetNamedTypeSymbol(namedType);
            return new UnsupportedSymbol(csharpSymbol, GetSymbol(csharpSymbol.ContainingSymbol));
        }

        public ImmutableArray<DeclaredSymbol> GetMemberSymbols(ImmutableArray<CSharpSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => (DeclaredSymbol)GetSymbol(symbol)).ToImmutableArray();
        }

        public CSharpModuleSymbol RegisterModuleSymbol(CSharpModuleSymbol moduleSymbol)
        {
            map.Add(moduleSymbol.CSharpModule, moduleSymbol);
            return moduleSymbol;
        }

        public ModuleSymbol GetModuleSymbol(CSharpSymbols.ModuleSymbol csharpSymbol)
        {
            var assembly = (CSharpAssemblySymbol)GetAssemblySymbol(csharpSymbol.ContainingAssembly);
            return GetSymbol<CSharpSymbols.ModuleSymbol, ModuleSymbol>(csharpSymbol, cs => throw new InvalidOperationException("Module symbol should have been Registered by the assembly."));
        }

        public ImmutableArray<ModuleSymbol> GetModuleSymbols(ImmutableArray<CSharpSymbols.ModuleSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetModuleSymbol(symbol)).ToImmutableArray();
        }

        public NamespaceSymbol GetNamespaceSymbol(CSharpSymbols.NamespaceSymbol csharpSymbol)
        {
            if (_module == null) return null;
            return GetSymbol(csharpSymbol, cs => new CSharpNamespaceSymbol(_module, cs));
        }

        public ImmutableArray<NamespaceSymbol> GetNamespaceSymbols(ImmutableArray<CSharpSymbols.NamespaceSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetNamespaceSymbol(symbol)).ToImmutableArray();
        }

        public NamedTypeSymbol GetNamedTypeSymbol(CSharpSymbols.NamedTypeSymbol csharpSymbol)
        {
            if (_module == null) return null;
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

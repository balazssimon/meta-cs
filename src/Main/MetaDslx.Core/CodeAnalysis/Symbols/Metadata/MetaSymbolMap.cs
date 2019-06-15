using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaSymbolMap
    {
        private ConditionalWeakTable<IMetaSymbol, Symbol> map = new ConditionalWeakTable<IMetaSymbol, Symbol>();
        private MetaModuleSymbol _module;

        public MetaSymbolMap(MetaModuleSymbol module)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            _module = module;
        }

        public bool TryGetSymbol<TMeta, T>(TMeta metaSymbol, out T symbol)
            where TMeta : IMetaSymbol
            where T : Symbol
        {
            if (metaSymbol == null || !map.TryGetValue(metaSymbol, out Symbol cachedSymbol))
            {
                symbol = null;
                return false;
            }
            symbol = (T)cachedSymbol;
            return (object)symbol != null;
        }

        private T GetSymbol<TMeta, T>(TMeta metaSymbol, Func<TMeta, T> createSymbol)
            where TMeta : IMetaSymbol
            where T : Symbol
        {
            if (metaSymbol == null) return null;
            if (!map.TryGetValue(metaSymbol, out Symbol symbol))
            {
                symbol = createSymbol(metaSymbol);
                map.Add(metaSymbol, symbol);
            }
            return (T)symbol;
        }

        public Symbol GetSymbol(IMetaSymbol metaSymbol)
        {
            if (metaSymbol.MId.SymbolInfo.IsNamespace) return GetNamespaceSymbol(metaSymbol);
            if (metaSymbol.MId.SymbolInfo.IsNamedType) return GetNamedTypeSymbol(metaSymbol);
            if (metaSymbol.MId.SymbolInfo.IsName) return GetNameSymbol(metaSymbol);
            return new UnsupportedMetaSymbol(metaSymbol);
        }

        private Symbol GetContainerSymbol(IMetaSymbol metaSymbol)
        {
            if (metaSymbol.MParent == null) return _module;
            else return GetSymbol(metaSymbol.MParent);
        }

        public ImmutableArray<Symbol> GetSymbols(IEnumerable<IMetaSymbol> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => GetSymbol(symbol)).ToImmutableArray();
        }

        public NamespaceSymbol GetNamespaceSymbol(IMetaSymbol metaSymbol)
        {
            Debug.Assert(metaSymbol.MId.SymbolInfo.IsNamespace, "Symbol must be a namespace.");
            return GetSymbol(metaSymbol, ms => new MetaNamespaceSymbol(ms, GetContainerSymbol(ms)));
        }

        public ImmutableArray<NamespaceSymbol> GetNamespaceSymbols(IEnumerable<IMetaSymbol> metaSymbols)
        {
            return metaSymbols.Select(symbol => GetNamespaceSymbol(symbol)).ToImmutableArray();
        }

        public NamedTypeSymbol GetNamedTypeSymbol(IMetaSymbol metaSymbol)
        {
            Debug.Assert(metaSymbol.MId.SymbolInfo.IsNamedType, "Symbol must be a named type.");
            return GetSymbol(metaSymbol, ms => new MetaNamedTypeSymbol(ms, GetContainerSymbol(ms)));
        }

        public ImmutableArray<NamedTypeSymbol> GetNamedTypeSymbols(IEnumerable<IMetaSymbol> metaSymbols)
        {
            return metaSymbols.Select(symbol => GetNamedTypeSymbol(symbol)).ToImmutableArray();
        }

        public MetaMemberSymbol GetNameSymbol(IMetaSymbol metaSymbol)
        {
            Debug.Assert(metaSymbol.MId.SymbolInfo.IsName, "Symbol must be a name.");
            return GetSymbol(metaSymbol, ms => new MetaMemberSymbol(ms, GetContainerSymbol(ms)));
        }

        public ImmutableArray<MetaMemberSymbol> GetNameSymbols(IEnumerable<IMetaSymbol> metaSymbols)
        {
            return metaSymbols.Select(symbol => GetNameSymbol(symbol)).ToImmutableArray();
        }
    }
}

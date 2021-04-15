using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Retargeting
{
    public class RetargetingSymbolMap
    {
        private ConditionalWeakTable<ISymbol, Symbol> map = new ConditionalWeakTable<ISymbol, Symbol>();
        private RetargetingModuleSymbol _module;

        public RetargetingSymbolMap(RetargetingModuleSymbol module)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            _module = module;
        }

        private TTarget GetSymbol<TSource, TTarget>(TSource metaSymbol, Func<TSource, TTarget> createSymbol)
            where TSource : ISymbol
            where TTarget : Symbol
        {
            if (metaSymbol == null) return null;
            if (!map.TryGetValue(metaSymbol, out Symbol symbol))
            {
                symbol = createSymbol(metaSymbol);
                map.Add(metaSymbol, symbol);
            }
            return (TTarget)symbol;
        }

        public Symbol GetSymbol(ISymbol symbol)
        {
            if (symbol is INamespaceSymbol namespaceSymbol) return GetNamespaceSymbol(namespaceSymbol);
            if (symbol is INamedTypeSymbol namedTypeSymbol) return GetNamedTypeSymbol(namedTypeSymbol);
            return new UnsupportedSymbol(symbol, GetSymbol(symbol.ContainingSymbol));
        }

        private Symbol GetContainerSymbol(ISymbol symbol)
        {
            if (symbol.ContainingSymbol == null) return _module;
            else return GetSymbol(symbol.ContainingSymbol);
        }

        public ImmutableArray<Symbol> GetSymbols(IEnumerable<ISymbol> csharpSymbols)
        {
            return csharpSymbols.Select(s => GetSymbol(s)).ToImmutableArray();
        }

        public NamespaceSymbol GetNamespaceSymbol(INamespaceSymbol symbol)
        {
            return GetSymbol(symbol, s => new RetargetingNamespaceSymbol(_module, (NamespaceSymbol)symbol));
        }

        public ImmutableArray<NamespaceSymbol> GetNamespaceSymbols(IEnumerable<INamespaceSymbol> metaSymbols)
        {
            return metaSymbols.Select(symbol => GetNamespaceSymbol(symbol)).ToImmutableArray();
        }

        public NamedTypeSymbol GetNamedTypeSymbol(INamedTypeSymbol symbol)
        {
            return GetSymbol(symbol, s => new RetargetingNamedTypeSymbol(_module, (NamedTypeSymbol)symbol));
        }

        public ImmutableArray<NamedTypeSymbol> GetNamedTypeSymbols(IEnumerable<INamedTypeSymbol> metaSymbols)
        {
            return metaSymbols.Select(symbol => GetNamedTypeSymbol(symbol)).ToImmutableArray();
        }

        public ImmutableArray<AttributeData> GetAttributes(ImmutableArray<AttributeData> attributes, ref ImmutableArray<AttributeData> cachedAttributes)
        {
            if (!cachedAttributes.IsDefault) return cachedAttributes;
            else return ImmutableArray<AttributeData>.Empty; // TODO:MetaDslx
        }
    }
}

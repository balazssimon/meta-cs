using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class ModelSymbolMap
    {
        private ConcurrentDictionary<IModelObject, Symbol> map = new ConcurrentDictionary<IModelObject, Symbol>();
        private ModelModuleSymbol _module;
        private bool _autoCreateSymbols;

        public ModelSymbolMap(ModelModuleSymbol module, bool autoCreateSymbols = false)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));
            _module = module;
            _autoCreateSymbols = autoCreateSymbols;
        }

        public bool TryGetSymbol<TMeta, T>(TMeta metaSymbol, out T symbol)
            where TMeta : IModelObject
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
            where TMeta : IModelObject
            where T : Symbol
        {
            if (metaSymbol == null) return null;
            if (!map.TryGetValue(metaSymbol, out Symbol symbol))
            {
                if (_autoCreateSymbols)
                {
                    symbol = createSymbol(metaSymbol);
                    map.TryAdd(metaSymbol, symbol);
                }
            }
            return (T)symbol;
        }

        public IEnumerable<Symbol> GetAllSymbols()
        {
            if (!(_module is IModelSourceSymbol mss) || mss?.ModelBuilder == null)
            {
                yield break;
            }
            foreach (var modelObject in mss.ModelBuilder.Objects)
            {
                yield return this.GetSymbol(modelObject);
            }
        }

        public Symbol GetSymbol(IModelObject metaSymbol)
        {
            if (metaSymbol.MId.Descriptor.IsNamespace) return GetNamespaceSymbol(metaSymbol);
            if (metaSymbol.MId.Descriptor.IsNamedType) return GetNamedTypeSymbol(metaSymbol);
            if (metaSymbol.MId.Descriptor.IsName) return GetNameSymbol(metaSymbol);
            return new UnsupportedMetaSymbol(metaSymbol);
        }

        private Symbol GetContainerSymbol(IModelObject metaSymbol)
        {
            if (metaSymbol.MParent == null) return _module;
            else return GetSymbol(metaSymbol.MParent);
        }

        public void RegisterSymbol(IModelObject modelObject, Symbol symbol)
        {
            map.TryAdd(modelObject, symbol);
        }

        public ImmutableArray<DeclaredSymbol> GetMemberSymbols(IEnumerable<IModelObject> csharpSymbols)
        {
            return csharpSymbols.Select(symbol => (DeclaredSymbol)GetSymbol(symbol)).ToImmutableArray();
        }

        public NamespaceSymbol GetNamespaceSymbol(IModelObject metaSymbol)
        {
            Debug.Assert(metaSymbol.MId.Descriptor.IsNamespace, "Symbol must be a namespace.");
            return GetSymbol(metaSymbol, ms => new MetaNamespaceSymbol(ms, GetContainerSymbol(ms)));
        }

        public ImmutableArray<NamespaceSymbol> GetNamespaceSymbols(IEnumerable<IModelObject> metaSymbols)
        {
            return metaSymbols.Select(symbol => GetNamespaceSymbol(symbol)).ToImmutableArray();
        }

        public NamedTypeSymbol GetNamedTypeSymbol(IModelObject metaSymbol)
        {
            Debug.Assert(metaSymbol.MId.Descriptor.IsNamedType, "Symbol must be a named type.");
            return GetSymbol(metaSymbol, ms => new MetaNamedTypeSymbol(ms, GetContainerSymbol(ms)));
        }

        public ImmutableArray<NamedTypeSymbol> GetNamedTypeSymbols(IEnumerable<IModelObject> metaSymbols)
        {
            return metaSymbols.Select(symbol => GetNamedTypeSymbol(symbol)).ToImmutableArray();
        }

        public ModelMemberSymbol GetNameSymbol(IModelObject metaSymbol)
        {
            Debug.Assert(metaSymbol.MId.Descriptor.IsName, "Symbol must be a name.");
            return GetSymbol(metaSymbol, ms => new MetaMemberSymbol(ms, GetContainerSymbol(ms)));
        }

        public ImmutableArray<ModelMemberSymbol> GetNameSymbols(IEnumerable<IModelObject> metaSymbols)
        {
            return metaSymbols.Select(symbol => GetNameSymbol(symbol)).ToImmutableArray();
        }
    }
}

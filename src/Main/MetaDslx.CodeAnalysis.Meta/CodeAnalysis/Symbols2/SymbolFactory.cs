using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class SymbolFactory
    {
        private ObjectFactory _objectFactory;
        private ConcurrentDictionary<object, Symbol> _map = new ConcurrentDictionary<object, Symbol>();

        public SymbolFactory(ObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
        }

        public Symbol GetSymbol(object modelObject)
        {
            _map.TryGetValue(modelObject, out var symbol);
            return symbol;
        }

        public ImmutableArray<DeclaredSymbol> CreateMetaMemberSymbols(Symbol container, object modelObject)
        {
            var builder = ArrayBuilder<DeclaredSymbol>.GetInstance();
            foreach (var child in _objectFactory.GetChildren(modelObject))
            {
                var sym = GetOrCreateMetaSymbol(child);
                var dsym = sym as DeclaredSymbol;
                if (dsym != null) builder.Add(dsym);
            }
            return builder.ToImmutableAndFree();
        }

        public ImmutableArray<DeclaredSymbol> CreateSourceMemberSymbols(Symbol container, MergedDeclaration declaration)
        {
            var builder = ArrayBuilder<DeclaredSymbol>.GetInstance();
            foreach (var decl in declaration.Children)
            {
                var obj = _objectFactory.CreateObject(declaration.ModelObjectType);
                var sym = CreateSourceDeclaredSymbol(container, obj, decl);
                var dsym = sym as DeclaredSymbol;
                if (dsym != null) builder.Add(dsym);
                _map.TryAdd(obj, sym);
            }
            return builder.ToImmutableAndFree();
        }

        public Symbol ResolveMetaSymbol(object modelObject)
        {
            if (_map.TryGetValue(modelObject, out var symbol)) return symbol;
            var of = _objectFactory.GetObjectFactory(modelObject);
            if (of != _objectFactory) return of.Module.SymbolFactory.ResolveMetaSymbol(modelObject);
            return CreateMetaSymbol(modelObject);
        }

        public IEnumerable<Symbol> ResolveMetaSymbols(IEnumerable<object> modelObjects)
        {
            var builder = ArrayBuilder<Symbol>.GetInstance();
            foreach (var mobj in modelObjects)
            {
                var sym = ResolveMetaSymbol(mobj);
                if (sym != null) builder.Add(sym);
            }
            return builder.ToImmutableAndFree();
        }

        public Symbol GetOrCreateMetaSymbol(object modelObject)
        {
            if (_map.TryGetValue(modelObject, out var symbol)) return symbol;
            return CreateMetaSymbol(modelObject);
        }

        protected Symbol CreateMetaSymbol(object modelObject)
        {
            var pobj = _objectFactory.GetParent(modelObject);
            var psym = pobj != null ? GetOrCreateMetaSymbol(pobj) : _objectFactory.Module;
            var sym = CreateMetaSymbol(psym, modelObject);
            return _map.GetOrAdd(modelObject, sym);
        }

        protected virtual Symbol CreateMetaSymbol(Symbol container, object modelObject)
        {
            var kind = this.GetSymbolKind(modelObject);
            switch(kind.Switch())
            {
                case LanguageSymbolKind.Namespace:
                    return new ModelNamespaceSymbol(container, modelObject);
                case LanguageSymbolKind.NamedType:
                    return new ModelNamedTypeSymbol(container, modelObject);
                case LanguageSymbolKind.Name:
                    return new ModelMemberSymbol(container, modelObject);
                default:
                    return new UnsupportedModelSymbol(container, modelObject);
            }
        }

        protected virtual Symbol CreateSourceDeclaredSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            var kind = this.GetSymbolKind(modelObject);
            switch (kind.Switch())
            {
                case LanguageSymbolKind.Namespace:
                    return new SourceNamespaceSymbol((SourceModuleSymbol)container.ContainingModule, container, modelObject, declaration);
                case LanguageSymbolKind.NamedType:
                    if (_objectFactory.GetName(modelObject) == null) return new SourceAnonymousTypeSymbol(container, modelObject, declaration);
                    else return new SourceNamedTypeSymbol(container, modelObject, declaration);
                case LanguageSymbolKind.Name:
                    return new SourceMemberSymbol(container, modelObject, declaration);
                default:
                    throw new NotImplementedException($"Unsupported source declaration symbol {kind.GetName()} for model object {modelObject.GetType().FullName}.");
            }
        }

        protected virtual Symbol CreateSourceSymbol(Symbol container, object modelObject, DiagnosticBag diagnostics)
        {
            var kind = this.GetSymbolKind(modelObject);
            throw new NotImplementedException($"Unsupported source symbol {kind.GetName()} for model object {modelObject.GetType().FullName}.");
        }

        public virtual LanguageSymbolKind GetSymbolKind(object modelObject)
        {
            return GetSymbolKind(modelObject.GetType());
        }

        public abstract LanguageSymbolKind GetSymbolKind(Type modelObjectType);

        public virtual IEnumerable<object> GetProperties(object modelObject, string symbolProperty)
        {
            return GetProperties(modelObject.GetType(), symbolProperty);
        }

        public virtual IEnumerable<object> GetProperties(Type modelObjectType, string symbolProperty)
        {
            foreach (var prop in _objectFactory.GetProperties(modelObjectType))
            {
                var sprop = GetSymbolProperty(modelObjectType, prop);
                if (sprop == symbolProperty) yield return prop;
            }
        }

        public abstract string GetSymbolProperty(Type modelObjectType, object property);

    }
}

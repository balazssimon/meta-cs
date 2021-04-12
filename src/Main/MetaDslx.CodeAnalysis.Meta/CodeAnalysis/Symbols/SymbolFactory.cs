using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class SymbolFactory
    {
        private ModuleSymbol _module;
        private SymbolFacts _symbolFacts;
        private ConditionalWeakTable<MergedDeclaration, object> _objectMap = new ConditionalWeakTable<MergedDeclaration, object>();
        private ConditionalWeakTable<object, Symbol> _symbolMap = new ConditionalWeakTable<object, Symbol>();

        public SymbolFactory(ModuleSymbol module)
        {
            _module = module;
            _symbolFacts = module.Language.SymbolFacts;
        }

        public bool IsSourceSymbolFactory => _module.Ordinal == 0;
        public ModuleSymbol Module => _module;

        public bool TryGetSymbol(object modelObject, out Symbol symbol)
        {
            return _symbolMap.TryGetValue(modelObject, out symbol);
        }

        public Symbol GetSymbol(object modelObject)
        {
            if (_symbolMap.TryGetValue(modelObject, out var symbol)) return symbol;
            return CreateSymbol(modelObject);
        }

        public Symbol MakeSourceSymbol(Symbol container, Type symbolType, Type modelObjectType, MergedDeclaration declaration)
        {
            object modelObject = null;
            if (modelObjectType != null)
            {
                if (declaration != null)
                {
                    modelObject = _objectMap.GetValue(declaration, decl => _module.DeclaringCompilation.ObjectFactory.CreateObject(modelObjectType));
                }
                else
                {
                    modelObject = _module.DeclaringCompilation.ObjectFactory.CreateObject(modelObjectType);
                }
                if (_symbolMap.TryGetValue(modelObject, out var symbol)) return symbol;
                symbol = CreateSourceSymbol(container, symbolType, modelObject, declaration);
                return GetOrAddSymbol(modelObject, symbol);
            }
            else
            {
                var symbol = CreateSourceSymbol(container, symbolType, null, declaration);
                if (declaration != null) return GetOrAddSymbol(declaration, symbol);
                else return symbol;
            }
        }

        public ImmutableArray<Symbol> GetChildSymbols(object modelObject)
        {
            var builder = ArrayBuilder<Symbol>.GetInstance();
            foreach (var child in _symbolFacts.GetChildren(modelObject))
            {
                var sym = GetSymbol(child);
                builder.Add(sym);
            }
            return builder.ToImmutableAndFree();
        }

        public ImmutableArray<DeclaredSymbol> GetChildDeclaredSymbols(object modelObject)
        {
            var builder = ArrayBuilder<DeclaredSymbol>.GetInstance();
            foreach (var child in _symbolFacts.GetChildren(modelObject))
            {
                var sym = GetSymbol(child);
                var dsym = sym as DeclaredSymbol;
                if (dsym != null) builder.Add(dsym);
            }
            return builder.ToImmutableAndFree();
        }

        protected Symbol CreateSymbol(object modelObject)
        {
            var pobj = _symbolFacts.GetParent(modelObject);
            var psym = pobj != null ? GetSymbol(pobj) : _module;
            var sym = CreateSymbol(psym, _symbolFacts.GetSymbolType(modelObject), modelObject);
            return GetOrAddSymbol(modelObject, sym);
        }

        protected Symbol CreateSymbol(Symbol container, Type symbolType, object modelObject)
        {
            if (IsSourceSymbolFactory)
            {
                Debug.Assert(false);
                return CreateSourceSymbol(container, symbolType, modelObject, null);
            }
            else
            {
                return CreateMetaSymbol(container, symbolType, modelObject);
            }
        }

        protected virtual Symbol CreateMetaSymbol(Symbol container, Type symbolType, object modelObject)
        {
            if (symbolType == typeof(NamespaceSymbol)) return new ModelNamespaceSymbol(container, modelObject);
            if (symbolType == typeof(NamedTypeSymbol)) return new ModelNamedTypeSymbol(container, modelObject);
            if (symbolType == typeof(MemberSymbol)) return new ModelMemberSymbol(container, modelObject);
            return new UnsupportedModelSymbol(container, modelObject);
        }

        protected virtual Symbol CreateSourceSymbol(Symbol container, Type symbolType, object modelObject, MergedDeclaration declaration)
        {
            if (symbolType == typeof(NamespaceSymbol)) return new SourceNamespaceSymbol((SourceModuleSymbol)container.ContainingModule, container, modelObject, declaration);
            if (symbolType == typeof(NamedTypeSymbol)) return new SourceNamedTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(TypeSymbol)) return new SourceAnonymousTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(MemberSymbol)) return new SourceMemberSymbol(container, modelObject, declaration);
            return new UnsupportedModelSymbol(container, modelObject);
        }

        public Symbol ResolveSymbol(object modelObject)
        {
            if (_symbolMap.TryGetValue(modelObject, out var symbol)) return symbol;
            if (ModuleContainsObject(_module, modelObject)) return GetSymbol(modelObject);
            if (_module.ContainingAssembly == null) return null;
            foreach (var module in _module.ContainingAssembly.Modules)
            {
                if (module != _module && module is ModelModuleSymbol ms && ModuleContainsObject(module, modelObject))
                {
                    return ms.SymbolFactory.GetSymbol(modelObject);
                }
            }
            return null;
        }

        private bool ModuleContainsObject(ModuleSymbol module, object modelObject)
        {
            return module is ModelModuleSymbol ms && _symbolFacts.ContainsObject(ms.Model, modelObject);
        }

        public IEnumerable<Symbol> ResolveSymbols(IEnumerable<object> modelObjects)
        {
            var builder = ArrayBuilder<Symbol>.GetInstance();
            foreach (var mobj in modelObjects)
            {
                var sym = ResolveSymbol(mobj);
                if (sym != null) builder.Add(sym);
            }
            return builder.ToImmutableAndFree();
        }

        public void RemoveSymbol(Symbol symbol)
        {
            var mobj = (symbol as IModelSourceSymbol)?.ModelObject;
            _symbolMap.Remove(mobj);
            _module.DeclaringCompilation.ObjectFactory.RemoveObject(mobj);
        }

        private Symbol GetOrAddSymbol(object modelObject, Symbol symbol)
        {
            return _symbolMap.GetValue(modelObject, mobj => symbol);
        }

    }
}

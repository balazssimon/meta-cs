using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Completion;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /*public partial class GeneratedSymbolFactory : IGeneratedSymbolFactory
    {
        public Symbol? CreateErrorSymbol(Symbol? container, Type symbolType, object? modelObject, MergedDeclaration? declaration)
        {
            return null;
        }

        public Symbol? CreateMetadataSymbol(Symbol container, Type symbolType, object modelObject)
        {
            if (symbolType == typeof(NamespaceSymbol)) return new MetadataNamespaceSymbol(container, modelObject);
            if (symbolType == typeof(NamedTypeSymbol)) return new MetadataNamedTypeSymbol(container, modelObject);
            if (symbolType == typeof(InterfaceTypeSymbol)) return new MetadataInterfaceTypeSymbol(container, modelObject);
            if (symbolType == typeof(ClassTypeSymbol)) return new MetadataClassTypeSymbol(container, modelObject);
            if (symbolType == typeof(StructTypeSymbol)) return new MetadataStructTypeSymbol(container, modelObject);
            if (symbolType == typeof(EnumTypeSymbol)) return new MetadataEnumTypeSymbol(container, modelObject);
            if (symbolType == typeof(EnumLiteralSymbol)) return new MetadataEnumLiteralSymbol(container, modelObject);
            if (symbolType == typeof(ArrayTypeSymbol)) return new MetadataArrayTypeSymbol(container, modelObject);
            if (symbolType == typeof(NullableTypeSymbol)) return new MetadataNullableTypeSymbol(container, modelObject);
            if (symbolType == typeof(TupleTypeSymbol)) return new MetadataTupleTypeSymbol(container, modelObject);
            if (symbolType == typeof(TypeParameterSymbol)) return new MetadataTypeParameterSymbol(container, modelObject);
            if (symbolType == typeof(MemberSymbol)) return new MetadataMemberSymbol(container, modelObject);
            if (symbolType == typeof(ConstructorSymbol)) return new MetadataConstructorSymbol(container, modelObject);
            if (symbolType == typeof(MethodSymbol)) return new MetadataMethodSymbol(container, modelObject);
            if (symbolType == typeof(ParameterSymbol)) return new MetadataParameterSymbol(container, modelObject);
            if (symbolType == typeof(PropertySymbol)) return new MetadataPropertySymbol(container, modelObject);
            return null;
        }

        public Symbol? CreateSourceSymbol(Symbol container, Type symbolType, object modelObject, MergedDeclaration declaration)
        {
            if (symbolType == typeof(NamespaceSymbol)) return new SourceNamespaceSymbol((SourceModuleSymbol)container.ContainingModule, container, modelObject, declaration);
            if (symbolType == typeof(NamedTypeSymbol)) return new SourceNamedTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(InterfaceTypeSymbol)) return new SourceInterfaceTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(ClassTypeSymbol)) return new SourceClassTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(StructTypeSymbol)) return new SourceStructTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(EnumTypeSymbol)) return new SourceEnumTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(EnumLiteralSymbol)) return new SourceEnumLiteralSymbol(container, modelObject, declaration);
            if (symbolType == typeof(ArrayTypeSymbol)) return new SourceArrayTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(NullableTypeSymbol)) return new SourceNullableTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(TupleTypeSymbol)) return new SourceTupleTypeSymbol(container, modelObject, declaration);
            if (symbolType == typeof(TypeParameterSymbol)) return new SourceTypeParameterSymbol(container, modelObject, declaration);
            if (symbolType == typeof(MemberSymbol)) return new SourceMemberSymbol(container, modelObject, declaration);
            if (symbolType == typeof(ConstructorSymbol)) return new SourceConstructorSymbol(container, modelObject, declaration);
            if (symbolType == typeof(MethodSymbol)) return new SourceMethodSymbol(container, modelObject, declaration);
            if (symbolType == typeof(ParameterSymbol)) return new SourceParameterSymbol(container, modelObject, declaration);
            if (symbolType == typeof(PropertySymbol)) return new SourcePropertySymbol(container, modelObject, declaration);
            return null;
        }
    }*/

    public class SymbolFactory
    {
        private static ConditionalWeakTable<Type, IGeneratedSymbolFactory?> s_generatedSymbolFactoryMap = new ConditionalWeakTable<Type, IGeneratedSymbolFactory?>();

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
                return CreateMetadataSymbol(container, symbolType, modelObject);
            }
        }

        protected virtual Symbol CreateMetadataSymbol(Symbol container, Type symbolType, object modelObject)
        {
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateMetadataSymbol(container, modelObject);
            }
            if (result is not null) return result;
            else return new UnsupportedModelSymbol(container, modelObject);
        }

        protected virtual Symbol CreateSourceSymbol(Symbol container, Type symbolType, object modelObject, MergedDeclaration declaration)
        {
            if (symbolType == typeof(NamespaceSymbol)) return new SourceNamespaceSymbol((SourceModuleSymbol)container.ContainingModule, container, modelObject, declaration);
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateSourceSymbol(container, modelObject, declaration);
            }
            if (result is not null) return result;
            else return new UnsupportedModelSymbol(container, modelObject);
        }

        public Symbol ResolveSymbol(object modelObject)
        {
            if (_symbolMap.TryGetValue(modelObject, out var symbol)) return symbol;
            if (ModuleContainsObject(_module, modelObject)) return GetSymbol(modelObject);
            if (_module.ContainingAssembly == null) return null;
            foreach (var module in _module.ContainingAssembly.Modules)
            {
                if (module != _module && module is CompletionModuleSymbol ms && ModuleContainsObject(module, modelObject))
                {
                    return ms.SymbolFactory.GetSymbol(modelObject);
                }
            }
            return null;
        }

        private bool ModuleContainsObject(ModuleSymbol module, object modelObject)
        {
            return module is CompletionModuleSymbol cms && _symbolFacts.ContainsObject(cms.Model, modelObject);
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
            var mobj = (symbol as IModelSymbol)?.ModelObject;
            _symbolMap.Remove(mobj);
            _module.DeclaringCompilation.ObjectFactory.RemoveObject(mobj);
        }

        private Symbol GetOrAddSymbol(object modelObject, Symbol symbol)
        {
            return _symbolMap.GetValue(modelObject, mobj => symbol);
        }

        private static IGeneratedSymbolFactory? GetGeneratedSymbolFactory(Type symbolType)
        {
            return s_generatedSymbolFactoryMap.GetValue(symbolType, LoadGeneratedSymbolFactory);
        }

        private static IGeneratedSymbolFactory? LoadGeneratedSymbolFactory(Type symbolType)
        {
            var className = symbolType.Namespace + ".Factory." + symbolType.Name + "Factory";
            var factoryType = symbolType.Assembly.GetType(className);
            if (factoryType is not null)
            {
                var defaultConstructor = factoryType.GetConstructor(Type.EmptyTypes);
                if (defaultConstructor is not null) return defaultConstructor.Invoke(null) as IGeneratedSymbolFactory;
            }
            return null;
        }
    }
}

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

        public bool IsSourceSymbolFactory => _module is SourceModuleSymbol;
        public ModuleSymbol Module => _module;

        internal bool TryGetSymbol(object modelObject, out Symbol symbol)
        {
            return _symbolMap.TryGetValue(modelObject, out symbol);
        }

        internal Symbol GetSymbol(object modelObject)
        {
            if (_symbolMap.TryGetValue(modelObject, out var symbol)) return symbol;
            return CreateSymbol(modelObject);
        }

        internal Symbol MakeSourceSymbol(Symbol container, Type symbolType, Type modelObjectType, MergedDeclaration declaration)
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

        protected Symbol CreateSymbol(object modelObject)
        {
            var symbolType = _symbolFacts.GetSymbolType(modelObject);
            var pobj = _symbolFacts.GetParent(modelObject);
            var psym = pobj != null ? GetSymbol(pobj) : _module;
            var sym = CreateSymbol(psym, symbolType, modelObject);
            return GetOrAddSymbol(modelObject, sym);
        }

        protected Symbol CreateSymbol(Symbol container, Type? symbolType, object modelObject)
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

        protected virtual Symbol CreateMetadataSymbol(Symbol container, Type? symbolType, object modelObject)
        {
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateMetadataSymbol(container, modelObject);
            }
            if (result is not null) return result;
            var name = _symbolFacts.GetName(modelObject);
            var metadataName = _symbolFacts.GetMetadataName(modelObject);
            return new Metadata.MetadataNamedTypeSymbol.Error(container, name, metadataName, ErrorKind.Unsupported, null, ImmutableArray<Symbol>.Empty, false, modelObject);
        }

        protected virtual Symbol CreateSourceSymbol(Symbol container, Type? symbolType, object modelObject, MergedDeclaration declaration)
        {
            if (symbolType == typeof(NamespaceSymbol)) return new SourceNamespaceSymbol((SourceModuleSymbol)container.ContainingModule, container, declaration, modelObject);
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateSourceSymbol(container, declaration, modelObject);
            }
            if (result is not null) return result;
            var name = _symbolFacts.GetName(modelObject);
            var metadataName = _symbolFacts.GetMetadataName(modelObject);
            return new Source.SourceNamedTypeSymbol.Error(container, declaration, ErrorKind.Unsupported, null, ImmutableArray<Symbol>.Empty, false, modelObject);
        }

        public T MakeMetadataErrorSymbol<T>(Symbol? container, string name, string metadataName, ErrorKind kind, DiagnosticInfo? errorInfo = null, ImmutableArray<Symbol> candidateSymbols = default, bool unreported = false, object? modelObject = null)
            where T: Symbol
        {
            var symbolType = typeof(T);
            if (container is null)
            {
                var pobj = _symbolFacts.GetParent(modelObject);
                container = pobj != null ? GetSymbol(pobj) : _module;
            }
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateMetadataErrorSymbol(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
            }
            if (result is not null) return (T)result;
            throw new ArgumentException($"Symbol type {typeof(T).FullName} has no error type.");
        }

        public T MakeMetadataErrorSymbol<T>(Symbol wrappedSymbol, ErrorKind kind = ErrorKind.Invalid, DiagnosticInfo? errorInfo = null, bool unreported = false, object? modelObject = null)
            where T : Symbol
        {
            var symbolType = typeof(T);
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateMetadataErrorSymbol(wrappedSymbol, kind, errorInfo, unreported, modelObject);
            }
            if (result is not null) return (T)result;
            throw new ArgumentException($"Symbol type {typeof(T).FullName} has no error type.");
        }

        public Symbol MakeMetadataErrorSymbol(Symbol? container, string name, string metadataName, ErrorKind kind, DiagnosticInfo? errorInfo = null, ImmutableArray<Symbol> candidateSymbols = default, bool unreported = false, object? modelObject = null)
        {
            var symbolType = _symbolFacts.GetSymbolType(modelObject);
            if (container is null)
            {
                var pobj = _symbolFacts.GetParent(modelObject);
                container = pobj != null ? GetSymbol(pobj) : _module;
            }
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateMetadataErrorSymbol(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
            }
            if (result is not null) return result;
            return new Metadata.MetadataNamedTypeSymbol.Error(container, name, metadataName, ErrorKind.Unsupported, null, ImmutableArray<Symbol>.Empty, false, modelObject);
        }

        public Symbol MakeMetadataErrorSymbol(Symbol wrappedSymbol, ErrorKind kind = ErrorKind.Invalid, DiagnosticInfo? errorInfo = null, bool unreported = false, object? modelObject = null)
        {
            var symbolType = _symbolFacts.GetSymbolType(modelObject ?? (wrappedSymbol as IModelSymbol)?.ModelObject);
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateMetadataErrorSymbol(wrappedSymbol, kind, errorInfo, unreported, modelObject);
            }
            if (result is not null) return result;
            return new Metadata.MetadataNamedTypeSymbol.Error(wrappedSymbol, ErrorKind.Unsupported, null, false, modelObject);
        }

        public Symbol ResolveSymbol(object modelObject)
        {
            if (_symbolMap.TryGetValue(modelObject, out var symbol)) return symbol;
            var result = _module.GetDeclaredModelSymbol(modelObject);
            if (result is not null) return result;
            return _module.ContainingAssembly.ResolveModelSymbol(modelObject);
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

        internal void RemoveSymbol(Symbol symbol)
        {
            var mobj = (symbol as IModelSymbol)?.ModelObject;
            _symbolMap.Remove(mobj);
            if (_module.DeclaringCompilation is not null)
            {
                _module.DeclaringCompilation.ObjectFactory.RemoveObject(mobj);
            }
        }

        private Symbol GetOrAddSymbol(object modelObject, Symbol symbol)
        {
            return _symbolMap.GetValue(modelObject, mobj => symbol);
        }

        private static IGeneratedSymbolFactory? GetGeneratedSymbolFactory(Type? symbolType)
        {
            if (symbolType is null) return null;
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

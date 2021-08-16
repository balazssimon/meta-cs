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
            return new Metadata.MetadataNamedTypeSymbol.Unsupported(container, name, metadataName, null, modelObject);
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
            return new Metadata.MetadataNamedTypeSymbol.Unsupported(container, name, metadataName, null, modelObject);
        }

        public Symbol MakeMissingSymbol<T>(string name, string metadataName, object? modelObject = null)
            where T: Symbol
        {
            return this.MakeMetadataErrorSymbol<T>(name, metadataName, ErrorKind.Missing, null, default, false, modelObject);
        }

        public Symbol MakeMissingSymbol(string name, string metadataName, object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(name, metadataName, ErrorKind.Missing, null, default, false, modelObject);
        }

        public Symbol MakeUnsupportedSymbol<T>(object? modelObject = null)
            where T : Symbol
        {
            return this.MakeMetadataErrorSymbol<T>(string.Empty, string.Empty, ErrorKind.Unsupported, null, default, false, modelObject);
        }

        public Symbol MakeUnsupportedSymbol<T>(string name, string metadataName, object? modelObject = null)
            where T : Symbol
        {
            return this.MakeMetadataErrorSymbol<T>(name, metadataName, ErrorKind.Unsupported, null, default, false, modelObject);
        }

        public Symbol MakeUnsupportedSymbol(object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(string.Empty, string.Empty, ErrorKind.Unsupported, null, default, false, modelObject);
        }

        public Symbol MakeUnsupportedSymbol(string name, string metadataName, object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(name, metadataName, ErrorKind.Unsupported, null, default, false, modelObject);
        }

        public Symbol MakeAmbiguousSymbol<T>(string name, string metadataName, ImmutableArray<Symbol> candidateSymbols, object? modelObject = null)
            where T : Symbol
        {
            return this.MakeMetadataErrorSymbol<T>(name, metadataName, ErrorKind.Ambiguous, null, candidateSymbols, false, modelObject);
        }

        public Symbol MakeAmbiguousSymbol(string name, string metadataName, ImmutableArray<Symbol> candidateSymbols, object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(name, metadataName, ErrorKind.Ambiguous, null, candidateSymbols, false, modelObject);
        }

        public Symbol MakeInaccessibleSymbol(object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(string.Empty, string.Empty, ErrorKind.Inaccessible, null, default, false, modelObject);
        }

        public Symbol MakeInaccessibleSymbol(string name, string metadataName, object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(name, metadataName, ErrorKind.Inaccessible, null, default, false, modelObject);
        }

        public Symbol MakeInaccessibleSymbol<T>(string name, string metadataName, ImmutableArray<Symbol> candidateSymbols, object? modelObject = null)
            where T : Symbol
        {
            return this.MakeMetadataErrorSymbol<T>(name, metadataName, ErrorKind.Inaccessible, null, candidateSymbols, false, modelObject);
        }

        public Symbol MakeInaccessibleSymbol(string name, string metadataName, ImmutableArray<Symbol> candidateSymbols, object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(name, metadataName, ErrorKind.Inaccessible, null, candidateSymbols, false, modelObject);
        }

        public Symbol MakeErrorSymbol<T>(object? modelObject = null)
            where T : Symbol
        {
            return this.MakeMetadataErrorSymbol<T>(string.Empty, string.Empty, ErrorKind.None, null, default, false, modelObject);
        }

        public Symbol MakeErrorSymbol<T>(string name, string metadataName, object? modelObject = null)
            where T : Symbol
        {
            return this.MakeMetadataErrorSymbol<T>(name, metadataName, ErrorKind.None, null, default, false, modelObject);
        }

        public Symbol MakeErrorSymbol(object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(string.Empty, string.Empty, ErrorKind.None, null, default, false, modelObject);
        }

        public Symbol MakeErrorSymbol(string name, string metadataName, object? modelObject)
        {
            return this.MakeMetadataErrorSymbol(name, metadataName, ErrorKind.None, null, default, false, modelObject);
        }

        public T MakeMetadataErrorSymbol<T>(string name, string metadataName, ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
            where T: Symbol
        {
            var symbolType = typeof(T);
            var pobj = _symbolFacts.GetParent(modelObject);
            var container = pobj != null ? GetSymbol(pobj) : _module;
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateMetadataErrorSymbol(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
            }
            if (result is not null) return (T)result;
            throw new ArgumentException($"Symbol type {typeof(T).FullName} has no error type.");
        }

        public Symbol MakeMetadataErrorSymbol(string name, string metadataName, ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            var symbolType = _symbolFacts.GetSymbolType(modelObject);
            var pobj = _symbolFacts.GetParent(modelObject);
            var container = pobj != null ? GetSymbol(pobj) : _module;
            Symbol? result = null;
            var generatedFactory = GetGeneratedSymbolFactory(symbolType);
            if (generatedFactory is not null)
            {
                result = generatedFactory.CreateMetadataErrorSymbol(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
            }
            if (result is not null) return result;
            return new Metadata.MetadataNamedTypeSymbol.Unsupported(container, name, metadataName, null, modelObject);
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

using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetadataSymbolImplementation : ISymbolImplementation
    {
        public static readonly MetadataSymbolImplementation Instance = new MetadataSymbolImplementation();

        public ImmutableArray<Symbol> MakeGlobalSymbols(Symbol rootSymbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var module = rootSymbol.ContainingSymbol as MetadataModuleSymbol;
            if (module is null) throw new ArgumentException("Containing symbol of the root symbol must be a MetadataModuleSymbol.");
            var location = rootSymbol.ContainingModule.Locations.FirstOrDefault();
            var symbolFactory = rootSymbol.ContainingModule.SymbolFactory;
            var result = ArrayBuilder<Symbol>.GetInstance();
            var childObjects = module.Language.SymbolFacts.GetRootObjects(module.Model);
            foreach (var childObject in childObjects)
            {
                var childSymbol = symbolFactory.GetSymbol(childObject);
                SetPropertyValue(childSymbol, location, result, false, rootSymbol, symbolPropertyName, diagnostics, cancellationToken);
            }
            return result.ToImmutableAndFree();
        }

        public ImmutableArray<Symbol> MakeChildSymbols(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (symbol is MetadataModuleSymbol mms) return ImmutableArray.Create<Symbol>(mms.GlobalNamespace);
            var msymbol = symbol as IModelSymbol;
            if (msymbol is null) throw new ArgumentException("Symbol must implement IModelSymbol.");
            var location = symbol.ContainingModule.Locations.FirstOrDefault();
            var symbolFacts = symbol.Language.SymbolFacts;
            var symbolFactory = symbol.ContainingModule.SymbolFactory;
            var result = ArrayBuilder<Symbol>.GetInstance();
            var mproperties = symbolFacts.GetProperties(msymbol.ModelObject);
            var cproperties = mproperties.Where(prop => symbolFacts.IsContainmentProperty(prop));
            foreach (var prop in cproperties)
            {
                var childObjects = symbolFacts.GetPropertyValues(msymbol.ModelObject, prop);
                foreach (var childObject in childObjects)
                {
                    if (childObject is not null)
                    {
                        var childSymbol = symbolFactory.GetSymbol(childObject);
                        SetPropertyValue(childSymbol, location, result, false, symbol, symbolPropertyName, diagnostics, cancellationToken);
                    }
                }
            }
            return result.ToImmutableAndFree();
        }

        public bool AssignSymbolPropertyValue<T>(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken, out T? result)
        {
            if (symbol is ModuleSymbol || symbol is AssemblySymbol)
            {
                result = default;
                return false;
            }
            if (symbolPropertyName == SymbolConstants.NameProperty)
            {
                throw new NotImplementedException("Call AssignNameProperty to assign the Name property of a symbol.");
            }
            if (symbolPropertyName == SymbolConstants.MetadataNameProperty)
            {
                throw new NotImplementedException("Call AssignMetadataNameProperty to assign the MetadataName property of a symbol.");
            }
            var values = ArrayBuilder<T>.GetInstance();
            try
            {
                AssignSymbolProperty(symbol, symbolPropertyName, values, true, diagnostics, cancellationToken);
                if (values.Count > 0)
                {
                    result = values[0];
                    return true;
                }
                else
                {
                    result = default;
                    return false;
                }
            }
            finally
            {
                values.Free();
            }
        }

        public bool AssignSymbolPropertyValues<T>(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken, out ImmutableArray<T> result)
        {
            if (symbol is ModuleSymbol || symbol is AssemblySymbol)
            {
                result = default;
                return false;
            }
            var values = ArrayBuilder<T>.GetInstance();
            AssignSymbolProperty<T>(symbol, symbolPropertyName, values, false, diagnostics, cancellationToken);
            result = values.ToImmutableAndFree();
            return result.Length > 0;
        }

        public string AssignNameProperty(Symbol symbol, DiagnosticBag diagnostics)
        {
            if (symbol is IModelSymbol msymbol && msymbol.ModelObject != null)
            {
                var symbolFacts = symbol.Language.SymbolFacts;
                return symbolFacts.GetName(msymbol.ModelObject);
            }
            return string.Empty;
        }

        public string AssignMetadataNameProperty(Symbol symbol, DiagnosticBag diagnostics)
        {
            if (symbol is IModelSymbol msymbol && msymbol.ModelObject != null)
            {
                var symbolFacts = symbol.Language.SymbolFacts;
                return symbolFacts.GetMetadataName(msymbol.ModelObject);
            }
            return string.Empty;
        }

        private static void AssignSymbolProperty<T>(Symbol symbol, string symbolPropertyName, ArrayBuilder<T> result, bool singleValue, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var msymbol = symbol as IModelSymbol;
            if (msymbol == null) return;
            var language = symbol.Language;
            var location = symbol.ContainingModule.Locations.FirstOrDefault();
            var symbolFactory = symbol.ContainingModule.SymbolFactory;
            var symbolFacts = language.SymbolFacts;
            var objectProperties = symbolFacts.GetPropertiesForSymbol(msymbol.ModelObject, symbolPropertyName);
            foreach (var prop in objectProperties)
            {
                var values = symbolFacts.GetPropertyValues(msymbol.ModelObject, prop);
                foreach (var value in values)
                {
                    if (value is not null)
                    {
                        var valueSymbol = symbolFactory.ResolveSymbol(value) ?? value;
                        SetPropertyValue(valueSymbol, location, result, singleValue, symbol, symbolPropertyName, diagnostics, cancellationToken);
                    }
                }
            }
        }

        private static void SetPropertyValue<T>(object? value, Location? location, ArrayBuilder<T> result, bool singleValue, Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (value != null && !typeof(T).IsAssignableFrom(value.GetType()))
            {
                diagnostics.Add(ModelErrorCode.ERR_CannotSetSymbolProperty.ToDiagnostic(location, value.ToString(), symbolPropertyName, symbol.ToString(), typeof(T).ToString(), value.GetType().ToString()));
            }
            else if (value != null)
            {
                result.Add((T)value);
            }
        }

        public void CompleteImports(Symbol symbol, Location locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void AssignNonSymbolProperties(Symbol symbol, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

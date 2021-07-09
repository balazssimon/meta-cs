using MetaDslx.CodeAnalysis.Symbols.Model;
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
    public static class ModelSymbolImplementation
    {
        public static ImmutableArray<Symbol> MakeGlobalSymbols(Symbol rootSymbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var msymbol = rootSymbol as IModelSymbol;
            var module = rootSymbol.ContainingSymbol as ModelModuleSymbol;
            if (module is null) throw new ArgumentException("Containing symbol of the root symbol must be a ModelModuleSymbol.");
            if (msymbol is null) throw new ArgumentException("Symbol must implement IModelSymbol.");
            var location = rootSymbol.ContainingModule.Locations.FirstOrDefault();
            var symbolFactory = msymbol.SymbolFactory;
            var result = ArrayBuilder<Symbol>.GetInstance();
            var childObjects = rootSymbol.Language.SymbolFacts.GetRootObjects(module.Model);
            foreach (var childObject in childObjects)
            {
                var childSymbol = symbolFactory.GetSymbol(childObject);
                SetPropertyValue(childSymbol, location, result, false, rootSymbol, symbolPropertyName, diagnostics, cancellationToken);
            }
            return result.ToImmutableAndFree();
        }

        public static ImmutableArray<Symbol> MakeChildSymbols(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var msymbol = symbol as IModelSymbol;
            if (msymbol is null) throw new ArgumentException("Symbol must implement IModelSymbol.");
            var location = symbol.ContainingModule.Locations.FirstOrDefault();
            var symbolFacts = symbol.Language.SymbolFacts;
            var symbolFactory = msymbol.SymbolFactory;
            var result = ArrayBuilder<Symbol>.GetInstance();
            var mproperties = symbolFacts.GetProperties(msymbol.ModelObject);
            var cproperties = mproperties.Select(prop => symbolFacts.IsContainmentProperty(prop));
            foreach (var prop in cproperties)
            {
                var childObjects = symbolFacts.GetPropertyValues(msymbol.ModelObject, prop);
                foreach (var childObject in childObjects)
                {
                    var childSymbol = symbolFactory.GetSymbol(childObject);
                    SetPropertyValue(childSymbol, location, result, false, symbol, symbolPropertyName, diagnostics, cancellationToken);
                }
            }
            return result.ToImmutableAndFree();
        }

        public static T? AssignSymbolPropertyValue<T>(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var values = ArrayBuilder<T>.GetInstance();
            try
            {
                AssignSymbolProperty(symbol, symbolPropertyName, values, true, diagnostics, cancellationToken);
                if (values.Count > 0) return values[0];
                else return default;
            }
            finally
            {
                values.Free();
            }
        }

        public static ImmutableArray<T> AssignSymbolPropertyValues<T>(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var values = ArrayBuilder<T>.GetInstance();
            AssignSymbolProperty<T>(symbol, symbolPropertyName, values, false, diagnostics, cancellationToken);
            return values.ToImmutableAndFree();
        }

        private static void AssignSymbolProperty<T>(Symbol symbol, string symbolPropertyName, ArrayBuilder<T> result, bool singleValue, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var msymbol = symbol as IModelSymbol;
            if (msymbol == null) return;
            var language = symbol.Language;
            var location = symbol.ContainingModule.Locations.FirstOrDefault();
            var symbolFacts = language.SymbolFacts;
            var objectProperties = symbolFacts.GetPropertiesForSymbol(msymbol.ModelObject, symbolPropertyName);
            foreach (var prop in objectProperties)
            {
                var values = symbolFacts.GetPropertyValues(msymbol.ModelObject, prop);
                foreach (var value in values)
                {
                    SetPropertyValue(value, location, result, singleValue, symbol, symbolPropertyName, diagnostics, cancellationToken);
                }
            }
        }

        private static void SetPropertyValue<T>(object? value, Location? location, ArrayBuilder<T> result, bool singleValue, Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (value != null && !typeof(T).IsAssignableFrom(value.GetType()))
            {
                diagnostics.Add(ModelErrorCode.ERR_CannotSetSymbolProperty.ToDiagnostic(location, value, symbolPropertyName, symbol, typeof(T), value.GetType()));
            }
            else if (value != null)
            {
                result.Add((T)value);
            }
        }
    }
}

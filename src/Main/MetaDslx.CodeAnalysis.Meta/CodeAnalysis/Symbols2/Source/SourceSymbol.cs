using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public struct SourceSymbol
    {
        private Symbol _symbol;

        public SourceSymbol(Symbol symbol)
        {
            _symbol = symbol;
        }

        public LanguageCompilation Compilation => _symbol.DeclaringCompilation;

        public Language Language => _symbol.Language;

        public SymbolFacts SymbolFacts => _symbol.Language.SymbolFacts;

        public object ModelObject => ((IModelSymbol)_symbol).ModelObject;

        public BinderPosition<SymbolDefBinder> GetBinder(SyntaxReference reference)
        {
            Debug.Assert(_symbol.DeclaringSyntaxReferences.Contains(reference));
            return FindBinders.FindSymbolDefBinder(_symbol, reference);
        }

        public ImmutableArray<BinderPosition<PropertyBinder>> FindPropertyBinders(BinderPosition<SymbolDefBinder> symbolDefBinder)
        {
            return FindBinders.FindPropertyBinders(symbolDefBinder);
        }

        public ImmutableArray<BinderPosition<ValueBinder>> FindValueBinders(BinderPosition<PropertyBinder> propertyBinder)
        {
            return FindBinders.FindValueBinders(propertyBinder);
        }

        public ImmutableArray<ValueBinder> GetPropertyValues(string symbolProperty)
        {
            var result = ArrayBuilder<ValueBinder>.GetInstance();
            var objectProperties = SymbolFacts.GetProperties(ModelObject, symbolProperty);
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                var symbolDef = GetBinder(reference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    if (objectProperties.Contains(property.Binder.PropertyName))
                    {
                        var values = FindValueBinders(property);
                        result.AddRange(values.Select(v => v.Binder));
                    }
                }
            }
            return result.ToImmutableAndFree();
        }
    }
}

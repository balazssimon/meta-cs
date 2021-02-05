using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
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
    public struct SourceSymbol : IModelSourceSymbol
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

        public ImmutableArray<Symbol> ChildSymbols => _symbol.ChildSymbols;

        public SymbolFactory SymbolFactory => ((IModelSymbol)_symbol).SymbolFactory;

        public Type ModelObjectType => ((IModelSymbol)_symbol).ModelObjectType;

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

        public ImmutableArray<Symbol> CreateRootSymbols(DiagnosticBag diagnostics)
        {
            Debug.Assert(_symbol.ContainingSymbol is SourceModuleSymbol);
            var result = ArrayBuilder<Symbol>.GetInstance();
            var symbolFactory = SymbolFactory;
            var declaredSymbol = _symbol as DeclaredSymbol;
            if (declaredSymbol != null)
            {
                foreach (var decl in declaredSymbol.MergedDeclaration.Children)
                {
                    var rootObject = Compilation.ObjectFactory.CreateObject(decl.ModelObjectType);
                    var rootSymbol = symbolFactory.MakeSourceSymbol(_symbol, rootObject, decl);
                    result.Add(rootSymbol);
                }
            }
            return result.ToImmutableAndFree();
        }

        public ImmutableArray<Symbol> CreateChildSymbols(DiagnosticBag diagnostics)
        {
            Debug.Assert(_symbol.ContainingSymbol is IModelSourceSymbol);
            var result = ArrayBuilder<Symbol>.GetInstance();
            var symbolFacts = SymbolFacts;
            var symbolFactory = SymbolFactory;
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                var symbolDef = GetBinder(reference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    var objectProperty = symbolFacts.GetProperty(ModelObject, property.Binder.PropertyName);
                    var isContainmentProperty = objectProperty != null && symbolFacts.IsContainmentProperty(objectProperty);
                    var values = FindValueBinders(property);
                    foreach (var value in values)
                    {
                        if (objectProperty == null) AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_PropertyDoesNotExist.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName, ModelObject));
                        if (!isContainmentProperty) AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_NotContainmentProperty.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName, ModelObject));
                        var childBinder = value.Binder as SymbolDefBinder;
                        if (childBinder == null)
                        {
                            AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_MustBeSymbolDefBound.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName));
                        }
                        else
                        {
                            object childObject = null;
                            Symbol childSymbol = null;
                            var container = childBinder.ContainingDeclaration;
                            if (container != null)
                            {
                                foreach (var decl in container.MergedDeclaration.Children)
                                {
                                    if (decl.SyntaxReferences.Any(sr => sr.GetLocation() == childBinder.Syntax.GetLocation()))
                                    {
                                        Debug.Assert(decl.ModelObjectType == childBinder.ModelObjectType);
                                        childObject = Compilation.ObjectFactory.CreateObject(decl.ModelObjectType);
                                        symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, childObject, diagnostics);
                                        childSymbol = symbolFactory.MakeSourceSymbol(_symbol, childObject, decl);
                                        result.Add(childSymbol);
                                        break;
                                    }
                                }
                            }
                            if (childObject == null && childSymbol == null)
                            {
                                childObject = Compilation.ObjectFactory.CreateObject(childBinder.ModelObjectType);
                                symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, childObject, diagnostics);
                                childSymbol = symbolFactory.MakeSourceSymbol(_symbol, childObject, null);
                                result.Add(childSymbol);
                            }
                            Debug.Assert(childObject != null);
                            Debug.Assert(childSymbol != null);
                        }
                    }
                }
            }
            return result.ToImmutableAndFree();
        }

        public void AssignNameProperty(DiagnosticBag diagnostics)
        {
            if (_symbol is DeclaredSymbol declaredSymbol)
            {
                var symbolFacts = SymbolFacts;
                var objectProperties = symbolFacts.GetPropertiesForSymbol(ModelObject, SymbolConstants.NameProperty);
                var mergedDeclaration = declaredSymbol.MergedDeclaration;
                foreach (var objectProperty in objectProperties)
                {
                    symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, mergedDeclaration.Name, diagnostics);
                }
            }
        }

        public void AssignPropertyValues(string symbolProperty, DiagnosticBag diagnostics)
        {
            var symbolFacts = SymbolFacts;
            var objectProperties = symbolFacts.GetPropertiesForSymbol(ModelObject, symbolProperty);
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                var symbolDef = GetBinder(reference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    var objectProperty = symbolFacts.GetProperty(ModelObject, property.Binder.PropertyName);
                    if (objectProperties.Contains(objectProperty))
                    {
                        var values = FindValueBinders(property);
                        foreach (var value in values)
                        {
                            if (objectProperty == null) AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_PropertyDoesNotExist.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName, ModelObject));
                            foreach (var val in value.Binder.Values)
                            {
                                symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, val, diagnostics);
                            }
                        }
                    }
                }
            }
        }

        public ImmutableArray<ValueBinder> GetPropertyValues(string symbolProperty)
        {
            var result = ArrayBuilder<ValueBinder>.GetInstance();
            var objectProperties = SymbolFacts.GetPropertiesForSymbol(ModelObject, symbolProperty);
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

        private void AssertionDiagnostic(DiagnosticBag diagnostics, Diagnostic diagnostic)
        {
            diagnostics.Add(diagnostic);
            Debug.Assert(false, diagnostic.ToString());
        }

        public Symbol GetChildSymbol(SyntaxReference syntax)
        {
            Debug.Assert(!_symbol.ChildSymbols.IsDefault);
            foreach (var child in _symbol.ChildSymbols)
            {
                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))
                {
                    return child;
                }
            }
            return null;
        }

    }
}

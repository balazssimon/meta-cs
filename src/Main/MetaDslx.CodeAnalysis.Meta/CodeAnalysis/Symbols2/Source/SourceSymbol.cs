using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
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

        public ImmutableArray<Diagnostic> Diagnostics => throw ExceptionUtilities.Unreachable;

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
                    var rootSymbol = symbolFactory.MakeSourceSymbol(_symbol, decl.ModelObjectType, decl);
                    result.Add(rootSymbol);
                }
            }
            return result.ToImmutableAndFree();
        }

        public ImmutableArray<Symbol> CreateChildSymbols(DiagnosticBag diagnostics)
        {
            Debug.Assert(_symbol.ContainingSymbol is IModelSourceSymbol);
            var childDeclarations = (_symbol as DeclaredSymbol)?.MergedDeclaration != null ? new Dictionary<MergedDeclaration, Symbol>() : null;
            var result = ArrayBuilder<Symbol>.GetInstance();
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                CreateChildSymbols(reference, childDeclarations, result, diagnostics);
            }
            return result.ToImmutableAndFree();
        }

        public void CreateChildSymbols(SyntaxReference symbolPartReference, Dictionary<MergedDeclaration, Symbol> childMap, ArrayBuilder<Symbol> result, DiagnosticBag diagnostics)
        {
            Debug.Assert(_symbol.ContainingSymbol is IModelSourceSymbol);
            var symbolFacts = SymbolFacts;
            var symbolFactory = SymbolFactory;
            var declaredSymbol = _symbol as DeclaredSymbol;
            var nestingDeclaration = NestingParentDeclaration(symbolPartReference, declaredSymbol);
            if (nestingDeclaration != null)
            {
                foreach (var childDeclaration in nestingDeclaration.Children)
                {
                    if (!childMap.ContainsKey(childDeclaration))
                    {
                        var childSingleDeclaration = childDeclaration.GetSingleDeclaration(symbolPartReference);
                        Debug.Assert(childSingleDeclaration != null);
                        if (childSingleDeclaration != null)
                        {
                            var objectProperty = symbolFacts.GetProperty(ModelObject, childSingleDeclaration.NestingProperty);
                            if (objectProperty == null)
                            {
                                AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_PropertyDoesNotExist.ToDiagnostic(childSingleDeclaration.SyntaxReference.GetLocation(), childSingleDeclaration.NestingProperty, ModelObject));
                                return;
                            }
                            var isContainmentProperty = objectProperty != null && symbolFacts.IsContainmentProperty(objectProperty);
                            if (!isContainmentProperty)
                            {
                                AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_NotContainmentProperty.ToDiagnostic(childSingleDeclaration.SyntaxReference.GetLocation(), childSingleDeclaration.NestingProperty, ModelObject));
                                return;
                            }
                            var childSymbol = symbolFactory.MakeSourceSymbol(_symbol, childSingleDeclaration.ModelObjectType, childDeclaration);
                            var childObject = (childSymbol as IModelSourceSymbol)?.ModelObject;
                            symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, childObject, childSingleDeclaration.Location, diagnostics);
                            result.Add(childSymbol);
                            childMap.Add(childDeclaration, childSymbol);
                        }
                    }
                }
            }
            else
            { 
                var symbolDef = GetBinder(symbolPartReference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    var objectProperty = symbolFacts.GetProperty(ModelObject, property.Binder.PropertyName);
                    var isContainmentProperty = objectProperty != null && symbolFacts.IsContainmentProperty(objectProperty);
                    if (isContainmentProperty)
                    {
                        var values = FindValueBinders(property);
                        foreach (var value in values)
                        {
                            if (objectProperty == null)
                            {
                                AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_PropertyDoesNotExist.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName, ModelObject));
                                continue;
                            }
                            if (!isContainmentProperty)
                            {
                                AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_NotContainmentProperty.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName, ModelObject));
                                continue;
                            }
                            var childBinder = value.Binder as SymbolDefBinder;
                            if (childBinder == null)
                            {
                                AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_MustBeSymbolDefBound.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName));
                                continue;
                            }
                            CreateChildSymbols(childBinder, objectProperty, diagnostics, childMap, result);
                        }
                    }
                }
            }
        }

        private static MergedDeclaration NestingParentDeclaration(SyntaxReference symbolPartReference, DeclaredSymbol declaredSymbol)
        {
            if (declaredSymbol == null || declaredSymbol.MergedDeclaration == null) return null;
            var singleDeclaration = declaredSymbol.MergedDeclaration.GetSingleDeclaration(symbolPartReference);
            if (singleDeclaration.IsNestingParent) return declaredSymbol.MergedDeclaration;
            else return null;
        }

        private static ImmutableArray<MergedDeclaration> GetChildDeclarations(SyntaxReference childSyntax, DeclaredSymbol declaredSymbol)
        {
            if (declaredSymbol == null || declaredSymbol.MergedDeclaration == null) return default;
            var result = ArrayBuilder<MergedDeclaration>.GetInstance();
            foreach (var childDeclaration in declaredSymbol.MergedDeclaration.Children)
            {
                foreach (var childReference in childDeclaration.SyntaxReferences)
                {
                    if (childReference.SyntaxTree == childSyntax.SyntaxTree && childSyntax.Span.Equals(childReference.Span))
                    {
                        result.Add(childDeclaration);
                    }
                }
            }
            return result.ToImmutableAndFree();
        }

        public static ImmutableArray<DeclaredSymbol> GetChildDeclaredSymbols(SyntaxReference childSyntax, DeclaredSymbol declaredSymbol)
        {
            if (declaredSymbol == null) return ImmutableArray<DeclaredSymbol>.Empty;
            var childDeclarations = GetChildDeclarations(childSyntax, declaredSymbol);
            var result = ArrayBuilder<DeclaredSymbol>.GetInstance();
            foreach (var childSymbol in declaredSymbol.ChildSymbols)
            {
                if (childSymbol is DeclaredSymbol dsim && childDeclarations.Contains(dsim.MergedDeclaration))
                {
                    result.Add(dsim);
                }
            }
            return result.ToImmutableAndFree();
        }

        public static ImmutableArray<DeclaredSymbol> GetInnermostNestedDeclaredSymbols(SyntaxReference childSyntax, DeclaredSymbol declaredSymbol)
        {
            if (declaredSymbol == null) return ImmutableArray<DeclaredSymbol>.Empty;
            var result = ArrayBuilder<DeclaredSymbol>.GetInstance();
            var childSymbols = GetChildDeclaredSymbols(childSyntax, declaredSymbol);
            result.AddRange(childSymbols);
            int index = 0;
            while (index < result.Count)
            {
                var childSymbol = result[index];
                var nestingDeclaration = NestingParentDeclaration(childSyntax, childSymbol);
                if (nestingDeclaration != null)
                {
                    var nestedChildSymbols = GetChildDeclaredSymbols(childSyntax, childSymbol);
                    result.RemoveAt(index);
                    for (int i = 0; i < nestedChildSymbols.Length; i++)
                    {
                        result.Insert(index + i, nestedChildSymbols[i]);
                    }
                    --index;
                }
                ++index;
            }
            return result.ToImmutableAndFree();
        }

        public void AssignPropertyValues(string symbolProperty, DiagnosticBag diagnostics)
        {
            if (symbolProperty == SymbolConstants.NameProperty)
            {
                AssignNameProperty(diagnostics);
            }
            else if (symbolProperty == SymbolConstants.MembersProperty)
            {
                // we have assigned these while child symbols were created
            }
            else if (symbolProperty != null)
            {
                AssignSymbolProperty(symbolProperty, diagnostics);
            }
            else
            {
                AssignNonSymbolProperties(diagnostics);
            }
        }

        private void AssignNameProperty(DiagnosticBag diagnostics)
        {
            if (_symbol is DeclaredSymbol declaredSymbol)
            {
                var symbolFacts = SymbolFacts;
                var objectProperties = symbolFacts.GetPropertiesForSymbol(ModelObject, SymbolConstants.NameProperty);
                var mergedDeclaration = declaredSymbol.MergedDeclaration;
                foreach (var objectProperty in objectProperties)
                {
                    symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, mergedDeclaration.Name, mergedDeclaration.NameLocations.FirstOrDefault(), diagnostics);
                }
            }
        }

        private void AssignSymbolProperty(string symbolProperty, DiagnosticBag diagnostics)
        {
            var objectProperties = SymbolFacts.GetPropertiesForSymbol(ModelObject, symbolProperty);
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentDeclaration(reference, _symbol as DeclaredSymbol);
                if (nestingDeclaration != null) continue;
                var symbolDef = GetBinder(reference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    var objectProperty = SymbolFacts.GetProperty(ModelObject, property.Binder.PropertyName);
                    if (objectProperty != null)
                    {
                        var isContainmentProperty = SymbolFacts.IsContainmentProperty(objectProperty);
                        if (!isContainmentProperty && objectProperties.Contains(objectProperty))
                        {
                            var values = FindValueBinders(property);
                            foreach (var value in values)
                            {
                                AssignObjectProperty(value, objectProperty, diagnostics);
                            }
                        }
                    }
                }
            }
        }

        private void AssignNonSymbolProperties(DiagnosticBag diagnostics)
        {
            var objectProperties = SymbolFacts.GetProperties(ModelObject);
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentDeclaration(reference, _symbol as DeclaredSymbol);
                if (nestingDeclaration != null) continue;
                var symbolDef = GetBinder(reference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    var objectProperty = SymbolFacts.GetProperty(ModelObject, property.Binder.PropertyName);
                    var isContainmentProperty = objectProperty != null && SymbolFacts.IsContainmentProperty(objectProperty);
                    if (!isContainmentProperty && (objectProperty == null || objectProperties.Contains(objectProperty)))
                    {
                        var values = FindValueBinders(property);
                        foreach (var value in values)
                        {
                            if (objectProperty == null)
                            {
                                AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_PropertyDoesNotExist.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName, ModelObject));
                                continue;
                            }
                            AssignObjectProperty(value, objectProperty, diagnostics);
                        }
                    }
                }
            }
        }

        private void AssignObjectProperty(BinderPosition<ValueBinder> valueBinder, object objectProperty, DiagnosticBag diagnostics)
        {
            if (valueBinder.Binder is SymbolDefBinder valueSymbolDef)
            {
                CreateChildSymbols(valueSymbolDef, objectProperty, diagnostics, null, null);
            }
            else
            {
                var location = valueBinder.Syntax.GetLocation();
                var boundValue = valueBinder.Binder.Bind(valueBinder.Syntax) as BoundValue;
                Debug.Assert(boundValue != null);
                if (boundValue != null)
                {
                    if (!boundValue.Diagnostics.IsDefaultOrEmpty)
                    {
                        diagnostics.AddRange(boundValue.Diagnostics);
                    }
                    else
                    {
                        foreach (var value in boundValue.Values)
                        {
                            if (value is Symbol)
                            {
                                Debug.Assert(value is IModelSymbol);
                                if (value is IModelSymbol modelSymbol)
                                {
                                    SymbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, modelSymbol.ModelObject, location, diagnostics);
                                }
                            }
                            else
                            {
                                SymbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, value, location, diagnostics);
                            }
                        }
                    }
                }
            }
        }

        private void CreateChildSymbols(SymbolDefBinder childBinder, object objectProperty, DiagnosticBag diagnostics, Dictionary<MergedDeclaration, Symbol> childMap, ArrayBuilder<Symbol> result)
        {
            var container = childBinder.ContainingDeclaration;
            var symbolPartReference = childBinder.Syntax.GetReference();
            var childDeclarations = GetChildDeclarations(symbolPartReference, container);
            foreach (var childDeclaration in childDeclarations)
            {
                if (childMap == null || !childMap.TryGetValue(childDeclaration, out var childSymbol))
                {
                    Debug.Assert(childDeclaration.ModelObjectType == childBinder.ModelObjectType);
                    childSymbol = SymbolFactory.MakeSourceSymbol(_symbol, childBinder.ModelObjectType, childDeclaration);
                    var childObject = (childSymbol as IModelSourceSymbol)?.ModelObject;
                    Debug.Assert(childObject != null);
                    var childSingleDeclaration = childDeclaration.GetSingleDeclaration(symbolPartReference);
                    Debug.Assert(childSingleDeclaration != null);
                    SymbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, childObject, childSingleDeclaration.Location, diagnostics);
                    Debug.Assert(childSymbol != null);
                    if (result != null) result.Add(childSymbol);
                    if (childMap != null) childMap.Add(childDeclaration, childSymbol);
                }
            }
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

        public static Symbol GetChildSymbol(string childName, Location childLocation, NamedTypeSymbol container, Type modelObjectType)
        {
            foreach (Symbol sym in container.ChildSymbols)
            {
                if ((sym as IModelSymbol)?.ModelObjectType != modelObjectType)
                {
                    continue;
                }
                if (sym.Name != childName)
                {
                    continue;
                }

                if (sym.Locations.Contains(childLocation))
                {
                    return sym;
                }
            }

            return null;
        }

        public static Symbol GetChildSymbol(Location childLocation, NamedTypeSymbol container, Type modelObjectType)
        {
            foreach (Symbol sym in container.ChildSymbols)
            {
                if ((sym as IModelSymbol)?.ModelObjectType != modelObjectType)
                {
                    continue;
                }
                if (sym.Locations.Contains(childLocation))
                {
                    return sym;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns true if the location is within the syntax tree and span.
        /// </summary>
        private static bool InSpan(Location location, SyntaxTree syntaxTree, TextSpan span)
        {
            Debug.Assert(syntaxTree != null);
            return (location.SourceTree == syntaxTree) && span.Contains(location.SourceSpan);
        }

        /// <summary>
        /// Returns true if one of the locations is within the syntax tree and span.
        /// </summary>
        private static bool InSpan(ImmutableArray<Location> locations, SyntaxTree syntaxTree, TextSpan span)
        {
            Debug.Assert(syntaxTree != null);
            foreach (var loc in locations)
            {
                if (InSpan(loc, syntaxTree, span))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

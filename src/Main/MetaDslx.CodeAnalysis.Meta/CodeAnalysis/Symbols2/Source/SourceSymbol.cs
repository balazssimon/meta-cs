using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
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
            var childDeclarations = (_symbol as DeclaredSymbol).MergedDeclaration != null ? new Dictionary<MergedDeclaration, Symbol>() : null;
            var result = ArrayBuilder<Symbol>.GetInstance();
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                CreateChildSymbols(reference, childDeclarations, result, diagnostics);
            }
            return result.ToImmutableAndFree();
        }

        public void CreateChildSymbols(SyntaxReference symbolPartReference, Dictionary<MergedDeclaration, Symbol> childDeclarations, ArrayBuilder<Symbol> result, DiagnosticBag diagnostics)
        {
            Debug.Assert(_symbol.ContainingSymbol is IModelSourceSymbol);
            var symbolFacts = SymbolFacts;
            var symbolFactory = SymbolFactory;
            var declaredSymbol = _symbol as DeclaredSymbol;
            var symbolPartSyntax = symbolPartReference.Resolve();
            var nestingDeclaration = NestingParentDeclaration(symbolPartSyntax, declaredSymbol);
            if (nestingDeclaration != null)
            {
                Debug.Assert(nestingDeclaration.Children.Length == 1);
                var childSingleDeclaration = (SingleDeclaration)nestingDeclaration.Children[0];
                Debug.Assert(childSingleDeclaration != null);
                var childDeclaration = GetChildDeclaration(symbolPartSyntax, declaredSymbol);
                Debug.Assert(childDeclaration != null);
                if (!childDeclarations.ContainsKey(childDeclaration))
                {
                    var objectProperty = symbolFacts.GetProperty(ModelObject, childSingleDeclaration.NestingProperty);
                    if (objectProperty == null)
                    {
                        AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_PropertyDoesNotExist.ToDiagnostic(childSingleDeclaration.SyntaxReference.GetLocation(), childSingleDeclaration.NestingProperty, ModelObject));
                        return;
                    }
                    var childObject = Compilation.ObjectFactory.CreateObject(childSingleDeclaration.ModelObjectType);
                    symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, childObject, diagnostics);
                    var childSymbol = symbolFactory.MakeSourceSymbol(_symbol, childObject, childDeclaration);
                    result.Add(childSymbol);
                    childDeclarations.Add(childDeclaration, childSymbol);
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
                            object childObject = null;
                            Symbol childSymbol = null;
                            var container = childBinder.ContainingDeclaration;
                            var childDeclaration = GetChildDeclaration(childBinder.Syntax, container);
                            if (childDeclaration != null && !childDeclarations.TryGetValue(childDeclaration, out childSymbol))
                            {
                                Debug.Assert(childDeclaration.ModelObjectType == childBinder.ModelObjectType);
                                childObject = Compilation.ObjectFactory.CreateObject(childDeclaration.ModelObjectType);
                                symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, childObject, diagnostics);
                                childSymbol = symbolFactory.MakeSourceSymbol(_symbol, childObject, childDeclaration);
                                result.Add(childSymbol);
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
        }

        private static SingleDeclaration NestingParentDeclaration(SyntaxNodeOrToken symbolPartReference, DeclaredSymbol declaredSymbol)
        {
            if (declaredSymbol == null) return null;
            foreach (var singleDeclaration in declaredSymbol.MergedDeclaration.Declarations)
            {
                if (singleDeclaration.SyntaxReference.SyntaxTree == symbolPartReference.SyntaxTree && singleDeclaration.SyntaxReference.Span == symbolPartReference.Span)
                {
                    if (singleDeclaration.IsNestingParent) return singleDeclaration;
                    else return null;
                }
            }
            return null;
        }

        private static MergedDeclaration GetChildDeclaration(SyntaxNodeOrToken childSyntax, DeclaredSymbol declaredSymbol)
        {
            if (declaredSymbol == null || declaredSymbol.MergedDeclaration == null) return null;
            foreach (var childDeclaration in declaredSymbol.MergedDeclaration.Children)
            {
                foreach (var childReference in childDeclaration.SyntaxReferences)
                {
                    if (childReference.SyntaxTree == childSyntax.SyntaxTree && childSyntax.Span.Equals(childReference.Span))
                    {
                        return childDeclaration;
                    }
                }
            }
            return null;
        }

        public static DeclaredSymbol GetChildDeclaredSymbol(SyntaxNodeOrToken childSyntax, DeclaredSymbol declaredSymbol)
        {
            if (declaredSymbol == null) return null;
            var childDeclaration = GetChildDeclaration(childSyntax, declaredSymbol);
            Debug.Assert(childDeclaration != null);
            if (childDeclaration != null)
            {
                foreach (var childSymbol in declaredSymbol.ChildSymbols)
                {
                    if (childSymbol is DeclaredSymbol dsim && dsim.MergedDeclaration == childDeclaration)
                    {
                        return dsim;
                    }
                }
            }
            return null;
        }

        public static DeclaredSymbol GetInnermostNestedDeclaredSymbol(SyntaxNodeOrToken childSyntax, DeclaredSymbol declaredSymbol)
        {
            if (declaredSymbol == null) return null;
            var childSymbol = GetChildDeclaredSymbol(childSyntax, declaredSymbol);
            var nestingDeclaration = NestingParentDeclaration(childSyntax, childSymbol);
            while (nestingDeclaration != null && childSymbol != null)
            {
                declaredSymbol = childSymbol;
                childSymbol = GetChildDeclaredSymbol(childSyntax, declaredSymbol);
                nestingDeclaration = NestingParentDeclaration(childSyntax, childSymbol);
            }
            return childSymbol;
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

using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
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
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public static class SourceSymbolImplementation
    {
        public static void CompleteImports(Symbol symbol, Location locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var ssymbol = symbol as ISourceSymbol;
            if (ssymbol is null) throw new ArgumentException("Symbol must implement ISourceSymbol.");
            foreach (var declaration in ssymbol.MergedDeclaration.Declarations)
            {
                if (locationOpt == null || locationOpt.SourceTree == declaration.SyntaxReference.SyntaxTree)
                {
                    if (declaration.HasImports)
                    {
                        var symbolDef = ssymbol.GetBinder(declaration.SyntaxReference);
                        if (symbolDef.Binder != null)
                        {
                            var imports = symbolDef.Binder.GetImports();
                            imports.Complete(cancellationToken);
                            diagnostics.AddRange(imports.Diagnostics);
                        }
                    }
                }
            }
        }

        public static ImmutableArray<Symbol> MakeGlobalSymbols(Symbol rootSymbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var ssymbol = rootSymbol as ISourceSymbol;
            if (rootSymbol.ContainingSymbol is not SourceModuleSymbol) throw new ArgumentException("Containing symbol of the root symbol must be a SourceModuleSymbol.");
            if (ssymbol is null) throw new ArgumentException("Symbol must implement ISourceSymbol.");
            var result = ArrayBuilder<Symbol>.GetInstance();
            foreach (var childDeclaration in ssymbol.MergedDeclaration.Children)
            {
                var childSymbol = childDeclaration.Symbol;
                if (childSymbol is null)
                {
                    childSymbol = CreateChildSymbol(childDeclaration, rootSymbol, childDeclaration.NameLocations.FirstOrDefault(), diagnostics, cancellationToken);
                }
                SetPropertyValue(childSymbol, childDeclaration.NameLocations.FirstOrDefault(), result, false, rootSymbol, symbolPropertyName, null, diagnostics, cancellationToken);
            }
            return result.ToImmutableAndFree();
        }

        public static ImmutableArray<Symbol> MakeChildSymbols(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var ssymbol = symbol as ISourceSymbol;
            if (ssymbol is null) throw new ArgumentException("Symbol must implement ISourceSymbol.");
            var symbolFacts = symbol.Language.SymbolFacts;
            var result = ArrayBuilder<Symbol>.GetInstance();
            foreach (var symbolPartReference in symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentDeclaration(symbolPartReference, symbol);
                if (nestingDeclaration != null)
                {
                    foreach (var childDeclaration in nestingDeclaration.Children)
                    {
                        if (childDeclaration.Symbol is null)
                        {
                            var childSingleDeclaration = childDeclaration.GetSingleDeclaration(symbolPartReference);
                            Debug.Assert(childSingleDeclaration != null);
                            if (childSingleDeclaration != null)
                            {
                                var childSymbol = CreateChildSymbol(childDeclaration, symbol, childSingleDeclaration.Location, diagnostics, cancellationToken);
                                object? objectProperty = null;
                                if (symbol is IModelSymbol msymbol)
                                {
                                    objectProperty = symbolFacts.GetProperty(msymbol.ModelObject, childSingleDeclaration.NestingProperty);
                                }
                                SetPropertyValue(childSymbol, childDeclaration.NameLocations.FirstOrDefault(), result, false, symbol, symbolPropertyName, objectProperty, diagnostics, cancellationToken);
                            }
                            else
                            {
                                Debug.Assert(false);
                            }
                        }
                    }
                }
                else if (ssymbol.MergedDeclaration != null)
                {
                    foreach (var childDeclaration in ssymbol.MergedDeclaration.Children)
                    {
                        var childSymbol = childDeclaration.Symbol;
                        if (childSymbol is null)
                        {
                            childSymbol = CreateChildSymbol(childDeclaration, symbol, childDeclaration.NameLocations.FirstOrDefault(), diagnostics, cancellationToken);
                        }
                        SetPropertyValue(childSymbol, childDeclaration.NameLocations.FirstOrDefault(), result, false, symbol, symbolPropertyName, null, diagnostics, cancellationToken);
                    }
                }
                else
                {
                    Debug.Assert(false);
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

        public static void AssignNonSymbolProperties(Symbol symbol, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var msymbol = symbol as IModelSymbol;
            if (msymbol is null) return;
            var language = symbol.Language;
            var symbolFacts = language.SymbolFacts;
            var mproperties = symbolFacts.GetProperties(msymbol.ModelObject);
            var objectProperties = mproperties.Where(prop => symbolFacts.GetSymbolProperty(msymbol.ModelObjectType, prop) == null).ToImmutableHashSet();
            foreach (var reference in symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentDeclaration(reference, symbol as DeclaredSymbol);
                if (nestingDeclaration != null) continue;
                var symbolDef = GetBinder(symbol, reference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    var objectProperty = symbolFacts.GetProperty(msymbol.ModelObject, property.Binder.PropertyName);
                    if (objectProperty != null)
                    {
                        if (objectProperties.Contains(objectProperty))
                        {
                            var values = FindValueBinders(property);
                            foreach (var value in values)
                            {
                                SetPropertyValue<object>(value, null, false, symbol, null, objectProperty, diagnostics, cancellationToken);
                            }
                        }
                    }
                }
            }
        }

        private static void AssignSymbolProperty<T>(Symbol symbol, string symbolPropertyName, ArrayBuilder<T> result, bool singleValue, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var msymbol = symbol as IModelSymbol;
            var language = symbol.Language;
            var symbolFacts = language.SymbolFacts;
            var objectProperties = result != null && msymbol != null ? symbolFacts.GetPropertiesForSymbol(msymbol.ModelObject, symbolPropertyName) : null;
            foreach (var reference in symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentDeclaration(reference, symbol as DeclaredSymbol);
                if (nestingDeclaration != null) continue;
                var symbolDef = GetBinder(symbol, reference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    if (msymbol is not null)
                    {
                        var objectProperty = symbolFacts.GetProperty(msymbol.ModelObject, property.Binder.PropertyName);
                        if (objectProperty != null)
                        {
                            if (objectProperties == null || objectProperties.Contains(objectProperty))
                            {
                                var values = FindValueBinders(property);
                                foreach (var value in values)
                                {
                                    SetPropertyValue(value, result, singleValue, symbol, symbolPropertyName, objectProperty, diagnostics, cancellationToken);
                                }
                            }
                        }
                    }
                    else if (result != null && property.Binder.PropertyName == symbolPropertyName)
                    {
                        var values = FindValueBinders(property);
                        foreach (var value in values)
                        {
                            SetPropertyValue(value, result, singleValue, symbol, symbolPropertyName, null, diagnostics, cancellationToken);
                        }
                    }
                }
            }
        }

        private static Symbol CreateChildSymbol(MergedDeclaration childDeclaration, Symbol symbol, Location location, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var symbolFacts = symbol.Language.SymbolFacts;
            var ssymbol = (ISourceSymbol)symbol;
            Symbol childSymbol;
            if (childDeclaration != null)
            {
                childSymbol = childDeclaration.DangerousCreateSymbol(symbol, ssymbol.SymbolFactory);
                Debug.Assert(object.ReferenceEquals(childSymbol.ContainingSymbol, symbol));
                if (childSymbol is IModelSymbol childSourceSymbol)
                {
                    Debug.Assert(childSourceSymbol.ModelObject != null);
                }
            }
            else
            {
                Debug.Assert(false);
                childSymbol = null;
            }
            if (childSymbol == null || childSymbol.Kind == SymbolKind.ErrorType)
            {
                if (childDeclaration != null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_CannotCreateSourceDeclaredSymbol.ToDiagnostic(location, symbolFacts.GetSymbolType(childDeclaration.ModelObjectType), childDeclaration.Name, childDeclaration.ModelObjectType));
                }
            }
            if (childSymbol != null)
            {
                childSymbol.ForceComplete(CompletionGraph.FinishInitializing, null, cancellationToken);
            }
            return childSymbol;
        }

        private static MergedDeclaration? NestingParentDeclaration(SyntaxReference symbolPartReference, Symbol? symbol)
        {
            if ((symbol as ISourceSymbol)?.MergedDeclaration == null) return null;
            var srcSymbol = (ISourceSymbol)symbol;
            var singleDeclaration = srcSymbol.MergedDeclaration.GetSingleDeclaration(symbolPartReference);
            if (singleDeclaration.IsNestingParent) return srcSymbol.MergedDeclaration;
            else return null;
        }

        private static BinderPosition<SymbolBinder> GetBinder(Symbol symbol, SyntaxReference reference)
        {
            Debug.Assert(symbol.DeclaringSyntaxReferences.Contains(reference));
            return FindBinders.FindSymbolBinder(symbol, reference);
        }

        private static ImmutableArray<BinderPosition<PropertyBinder>> FindPropertyBinders(BinderPosition<SymbolBinder> symbolDefBinder)
        {
            return FindBinders.FindPropertyBinders(symbolDefBinder);
        }

        private static ImmutableArray<BinderPosition<ValueBinder>> FindValueBinders(BinderPosition<PropertyBinder> propertyBinder)
        {
            return FindBinders.FindPropertyValueBinders(propertyBinder);
        }

        private static void SetPropertyValue<T>(BinderPosition<ValueBinder> valueBinder, ArrayBuilder<T> result, bool singleValue, Symbol symbol, string symbolPropertyName, object modelObjectProperty, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var boundValue = valueBinder.Binder.Bind(diagnostics, cancellationToken) as BoundValue;
            Debug.Assert(boundValue != null);
            if (boundValue != null && !boundValue.Diagnostics.HasAnyErrors())
            {
                foreach (var value in boundValue.Values)
                {
                    var location = valueBinder.Syntax.GetLocation();
                    SetPropertyValue(value, location, result, singleValue, symbol, symbolPropertyName, modelObjectProperty, diagnostics, cancellationToken);
                }
            }
        }

        private static void SetPropertyValue<T>(object? value, Location? location, ArrayBuilder<T> result, bool singleValue, Symbol symbol, string symbolPropertyName, object modelObjectProperty, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (symbol is IModelSymbol msymbol)
            {
                symbol.Language.SymbolFacts.SetOrAddPropertyValue(msymbol.ModelObject, modelObjectProperty, value, location, diagnostics, cancellationToken);
            }
            if (result != null)
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
}

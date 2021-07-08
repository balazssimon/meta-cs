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
    public readonly ref struct SymbolPropertyAssignment
    {
        public readonly Symbol Symbol { get; init; }
        public readonly string SymbolPropertyName { get; init; }
        public readonly DiagnosticBag Diagnostics { get; init; }
        public readonly CancellationToken CancellationToken { get; init; }
    }

    public readonly ref struct ModelPropertyAssignment<T>
    {
        public readonly bool SingleValue { get; init; }
        public readonly string ObjectPropertyName { get; init; }
        public readonly object ObjectProperty { get; init; }
        public readonly ArrayBuilder<T> SymbolPropertyValues { get; init; }
        public readonly SymbolPropertyAssignment SymbolPropertyAssignment { get; init; }
    }

    public static class SourceSymbolProperty
    {
        public static class CompletionParts
        {
            public static readonly CompletionPart StartInitializing = new CompletionPart(nameof(StartInitializing));
            public static readonly CompletionPart FinishInitializing = new CompletionPart(nameof(FinishInitializing));
            public static readonly CompletionPart StartCreatingChildren = new CompletionPart(nameof(StartCreatingChildren));
            public static readonly CompletionPart FinishCreatingChildren = new CompletionPart(nameof(FinishCreatingChildren));
            public static readonly CompletionPart ChildrenCompleted = new CompletionPart(nameof(ChildrenCompleted));
        }


        public static ImmutableArray<Symbol> MakeRootSymbols(SymbolPropertyAssignment symbolProperty)
        {
            var symbol = symbolProperty.Symbol;
            var ssymbol = symbol as ISourceSymbol;
            if (symbol.ContainingSymbol is not SourceModuleSymbol) throw new ArgumentException("Containing symbol of a root symbol must be a SourceModuleSymbol.");
            if (ssymbol is null) throw new ArgumentException("Symbol must implement ISourceSymbol.");
            var symbolFactory = ssymbol.SymbolFactory;
            var result = ArrayBuilder<Symbol>.GetInstance();
            foreach (var decl in ssymbol.MergedDeclaration.Children)
            {
                var rootSymbol = decl.DangerousCreateSymbol(symbol, symbolFactory);
                Debug.Assert(rootSymbol is not null);
                if (rootSymbol is not null)
                {
                    rootSymbol.ForceComplete(CompletionParts.FinishInitializing, null, symbolProperty.CancellationToken);
                    result.Add(rootSymbol);
                }
            }
            return result.ToImmutableAndFree();
        }

        public static ImmutableArray<Symbol> MakeChildSymbols(SymbolPropertyAssignment symbolProperty)
        {
            var symbol = symbolProperty.Symbol;
            var ssymbol = symbol as ISourceSymbol;
            if (symbol.ContainingSymbol is not SourceModuleSymbol) throw new ArgumentException("Containing symbol of a root symbol must be a SourceModuleSymbol.");
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
                                var childSymbol = CreateChildSymbol(symbolProperty, childSingleDeclaration.Location, childDeclaration);
                                if (symbol is IModelSymbol msymbol && childSymbol is IModelSymbol childModelSymbol)
                                {
                                    var objectProperty = symbolFacts.GetProperty(msymbol.ModelObject, childSingleDeclaration.NestingProperty);
                                    var mpa = new ModelPropertyAssignment<Symbol>() { ObjectProperty = objectProperty, ObjectPropertyName = childSingleDeclaration.NestingProperty, SymbolPropertyValues = result, SymbolPropertyAssignment = symbolProperty };
                                    SetPropertyValue(mpa, childModelSymbol, childDeclaration.NameLocations.FirstOrDefault());
                                }
                                else
                                {
                                    var mpa = new ModelPropertyAssignment<Symbol>() { SymbolPropertyValues = result, SymbolPropertyAssignment = symbolProperty };
                                    SetPropertyValue(mpa, childSymbol, childDeclaration.NameLocations.FirstOrDefault());
                                }
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
                            childSymbol = CreateChildSymbol(symbolProperty, childDeclaration.NameLocations.FirstOrDefault(), childDeclaration);
                            if (childSymbol is IModelSymbol childSourceSymbol)
                            {
                                Debug.Assert(childSourceSymbol.ModelObject != null);
                            }
                        }
                        else
                        {
                            result.Add(childDeclaration.Symbol);
                        }
                        var mpa = new ModelPropertyAssignment<Symbol>() { SymbolPropertyValues = result, SymbolPropertyAssignment = symbolProperty };
                        SetPropertyValue(mpa, childSymbol, childDeclaration.NameLocations.FirstOrDefault());
                    }
                }
                else
                {
                    Debug.Assert(false);
                }
            }
            return result.ToImmutableAndFree();
        }

        public static T? AssignValue<T>(SymbolPropertyAssignment symbolProperty)
        {
            var result = AssignSymbolProperty<T>(symbolProperty, true);
            if (result.Length > 0) return result[0];
            else return default;
        }

        public static ImmutableArray<T> AssignValues<T>(SymbolPropertyAssignment symbolProperty)
        {
            return AssignSymbolProperty<T>(symbolProperty, false);
        }

        private static ImmutableArray<T> AssignSymbolProperty<T>(SymbolPropertyAssignment symbolProperty, bool singleValue)
        {
            var symbol = symbolProperty.Symbol;
            var msymbol = symbol as IModelSymbol;
            var language = symbolProperty.Symbol.Language;
            var symbolFacts = language.SymbolFacts;
            var result = ArrayBuilder<T>.GetInstance();
            var objectProperties = msymbol != null ? symbolFacts.GetPropertiesForSymbol(msymbol.ModelObject, symbolProperty.SymbolPropertyName) : null;
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
                            if (objectProperties.Contains(objectProperty))
                            {
                                var values = FindValueBinders(property);
                                foreach (var value in values)
                                {
                                    var mpa = new ModelPropertyAssignment<T>() { SingleValue = singleValue, ObjectPropertyName = property.Binder.PropertyName, ObjectProperty = objectProperty, SymbolPropertyValues = result, SymbolPropertyAssignment = symbolProperty };
                                    SetPropertyValue(value, mpa);
                                }
                            }
                        }
                    }
                    else if (property.Binder.PropertyName == symbolProperty.SymbolPropertyName)
                    {
                        var values = FindValueBinders(property);
                        foreach (var value in values)
                        {
                            var mpa = new ModelPropertyAssignment<T>() { SingleValue = singleValue, SymbolPropertyValues = result, SymbolPropertyAssignment = symbolProperty };
                            SetPropertyValue(value, mpa);
                        }
                    }
                }
            }
            return result.ToImmutableAndFree();
        }

        private static Symbol CreateChildSymbol(SymbolPropertyAssignment symbolProperty, Location location, MergedDeclaration childDeclaration)
        {
            var symbol = symbolProperty.Symbol;
            var symbolFacts = symbol.Language.SymbolFacts;
            var ssymbol = (ISourceSymbol)symbol;
            Symbol childSymbol;
            if (childDeclaration != null)
            {
                childSymbol = childDeclaration.DangerousCreateSymbol(symbol, ssymbol.SymbolFactory);
                Debug.Assert(object.ReferenceEquals(childSymbol.ContainingSymbol, symbol));
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
                    symbolProperty.Diagnostics.Add(ModelErrorCode.ERR_CannotCreateSourceDeclaredSymbol.ToDiagnostic(location, symbolFacts.GetSymbolType(childDeclaration.ModelObjectType), childDeclaration.Name, childDeclaration.ModelObjectType));
                }
            }
            if (childSymbol != null)
            {
                childSymbol.ForceComplete(CompletionParts.FinishInitializing, null, symbolProperty.CancellationToken);
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

        private static void SetPropertyValue<T>(BinderPosition<ValueBinder> valueBinder, ModelPropertyAssignment<T> modelProperty)
        {
            var diagnostics = modelProperty.SymbolPropertyAssignment.Diagnostics;
            var boundValue = valueBinder.Binder.Bind(diagnostics, modelProperty.SymbolPropertyAssignment.CancellationToken) as BoundValue;
            Debug.Assert(boundValue != null);
            if (boundValue != null && !boundValue.Diagnostics.HasAnyErrors())
            {
                foreach (var value in boundValue.Values)
                {
                    var location = valueBinder.Syntax.GetLocation();
                    SetPropertyValue(modelProperty, value, location);
                }
            }
        }

        private static void SetPropertyValue<T>(ModelPropertyAssignment<T> modelProperty, object? value, Location? location)
        {
            var diagnostics = modelProperty.SymbolPropertyAssignment.Diagnostics;
            if (modelProperty.SymbolPropertyAssignment.Symbol is IModelSymbol msymbol)
            {
                modelProperty.SymbolPropertyAssignment.Symbol.Language.SymbolFacts.SetOrAddPropertyValue(msymbol.ModelObject, modelProperty.ObjectProperty, value, location, diagnostics);
            }
            if (modelProperty.SymbolPropertyValues != null)
            {
                if (value != null && !typeof(T).IsAssignableFrom(value.GetType()))
                {
                    diagnostics.Add(ModelErrorCode.ERR_CannotSetSymbolProperty.ToDiagnostic(location, value, modelProperty.SymbolPropertyAssignment.SymbolPropertyName, modelProperty.SymbolPropertyAssignment.Symbol, typeof(T), value.GetType()));
                }
                else if (value != null)
                {
                    modelProperty.SymbolPropertyValues.Add((T)value);
                }
            }
        }
    }
}

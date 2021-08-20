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
    public class SourceSymbolImplementation : ISymbolImplementation
    {
        public static readonly SourceSymbolImplementation Instance = new SourceSymbolImplementation();

        public void CompleteImports(Symbol symbol, Location locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (symbol is ModuleSymbol || symbol is AssemblySymbol) return;
            var ssymbol = symbol as ISourceSymbol;
            if (ssymbol is null) throw new ArgumentException("Symbol must implement ISourceSymbol.");
            if (ssymbol.MergedDeclaration is null) return;
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

        public ImmutableArray<Symbol> MakeGlobalSymbols(Symbol rootSymbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
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

        public ImmutableArray<Symbol> MakeChildSymbols(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (symbol is SourceModuleSymbol sms) return ImmutableArray.Create<Symbol>(sms.GlobalNamespace);
            var ssymbol = symbol as ISourceSymbol;
            if (ssymbol is null) throw new ArgumentException("Symbol must implement ISourceSymbol.");
            var symbolFacts = symbol.Language.SymbolFacts;
            var result = ArrayBuilder<Symbol>.GetInstance();
            foreach (var symbolPartReference in symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentMergedDeclaration(symbolPartReference, symbol);
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

        public static ImmutableArray<Symbol> GetInnermostNestedSymbols(SyntaxReference childSyntax, Symbol symbol)
        {
            if (symbol == null) return ImmutableArray<Symbol>.Empty;
            var result = ArrayBuilder<Symbol>.GetInstance();
            var childSymbols = GetChildSymbols(symbol, childSyntax);
            result.AddRange(childSymbols);
            int index = 0;
            while (index < result.Count)
            {
                var childSymbol = result[index];
                var nestingDeclaration = NestingParentMergedDeclaration(childSyntax, childSymbol);
                if (nestingDeclaration != null)
                {
                    var nestedChildSymbols = GetChildSymbols(childSymbol, childSyntax);
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

        public void AssignNonSymbolProperties(Symbol symbol, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (symbol is ModuleSymbol || symbol is AssemblySymbol) return;
            var msymbol = symbol as IModelSymbol;
            if (msymbol?.ModelObject is null) return;
            var language = symbol.Language;
            var symbolFacts = language.SymbolFacts;
            var mproperties = symbolFacts.GetProperties(msymbol.ModelObject);
            var objectProperties = mproperties.Where(prop => symbolFacts.GetSymbolProperty(msymbol.ModelObjectType, prop) == null).ToImmutableHashSet();
            foreach (var reference in symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentSingleDeclaration(reference, symbol);
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

        public string AssignNameProperty(Symbol symbol, DiagnosticBag diagnostics)
        {
            if (symbol is ISourceSymbol ssymbol && symbol is IModelSymbol msymbol && msymbol.ModelObject != null)
            {
                var symbolFacts = symbol.Language.SymbolFacts;
                var objectProperties = symbolFacts.GetPropertiesForSymbol(msymbol.ModelObject, SymbolConstants.NameProperty);
                var mergedDeclaration = ssymbol.MergedDeclaration;
                foreach (var objectProperty in objectProperties)
                {
                    symbolFacts.SetOrAddPropertyValue(msymbol.ModelObject, objectProperty, mergedDeclaration.Name, mergedDeclaration.NameLocations.FirstOrDefault(), diagnostics, default);
                }
                return mergedDeclaration.Name;
            }
            return string.Empty;
        }

        public string AssignMetadataNameProperty(Symbol symbol, DiagnosticBag diagnostics)
        {
            if (symbol is ISourceSymbol ssymbol)
            {
                var mergedDeclaration = ssymbol.MergedDeclaration;
                return mergedDeclaration.MetadataName;
            }
            return string.Empty;
        }

        private static void AssignSymbolProperty<T>(Symbol symbol, string symbolPropertyName, ArrayBuilder<T> result, bool singleValue, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var ssymbol = symbol as ISourceSymbol;
            if (ssymbol?.MergedDeclaration is null) return;
            var msymbol = symbol as IModelSymbol;
            var language = symbol.Language;
            var symbolFacts = language.SymbolFacts;
            var mobj = msymbol?.ModelObject;
            var objectProperties = result != null && mobj != null ? symbolFacts.GetPropertiesForSymbol(mobj, symbolPropertyName) : null;
            foreach (var reference in symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentMergedDeclaration(reference, symbol);
                if (nestingDeclaration != null)
                {
                    var nestingSingleDeclaration = NestingParentSingleDeclaration(reference, symbol);
                    if (nestingSingleDeclaration != null && mobj != null)
                    {
                        Debug.Assert(nestingSingleDeclaration.Children.Length == 1);
                        var singleChildDeclaration = (SingleDeclaration)nestingSingleDeclaration.Children[0];
                        var mergedChildDeclaration = nestingDeclaration.Children.FirstOrDefault(c => c.Declarations.Contains(singleChildDeclaration));
                        if (mergedChildDeclaration != null)
                        {
                            var objectProperty = symbolFacts.GetProperty(mobj, singleChildDeclaration.NestingProperty);
                            if (objectProperties != null && objectProperties.Contains(objectProperty))
                            {
                                SetPropertyValue(mergedChildDeclaration.Symbol, reference.GetLocation(), result, singleValue, symbol, symbolPropertyName, null, diagnostics, cancellationToken);
                            }
                        }
                    }
                    continue;
                }
                var symbolDef = GetBinder(symbol, reference);
                var properties = FindPropertyBinders(symbolDef);
                foreach (var property in properties)
                {
                    if (msymbol is not null)
                    {
                        if (mobj is not null)
                        {
                            var objectProperty = symbolFacts.GetProperty(mobj, property.Binder.PropertyName);
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
            if (childSymbol is null || childSymbol.IsError)
            {
                if (childDeclaration != null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_CannotCreateSourceDeclaredSymbol.ToDiagnostic(location, symbolFacts.GetSymbolType(childDeclaration.ModelObjectType).FullName, childDeclaration.Name, childDeclaration.ModelObjectType.FullName));
                }
            }
            if (childSymbol is not null)
            {
                childSymbol.ForceComplete(CompletionGraph.FinishInitializing, null, cancellationToken);
            }
            return childSymbol;
        }

        private static MergedDeclaration? NestingParentMergedDeclaration(SyntaxReference symbolPartReference, Symbol? symbol)
        {
            if ((symbol as ISourceSymbol)?.MergedDeclaration == null) return null;
            var srcSymbol = (ISourceSymbol)symbol;
            var singleDeclaration = srcSymbol.MergedDeclaration.GetSingleDeclaration(symbolPartReference);
            if (singleDeclaration != null && singleDeclaration.IsNestingParent) return srcSymbol.MergedDeclaration;
            else return null;
        }

        private static SingleDeclaration? NestingParentSingleDeclaration(SyntaxReference symbolPartReference, Symbol? symbol)
        {
            if ((symbol as ISourceSymbol)?.MergedDeclaration == null) return null;
            var srcSymbol = (ISourceSymbol)symbol;
            var singleDeclaration = srcSymbol.MergedDeclaration.GetSingleDeclaration(symbolPartReference);
            if (singleDeclaration != null && singleDeclaration.IsNestingParent) return singleDeclaration;
            else return null;
        }

        private static BinderPosition<SymbolBinder> GetBinder(Symbol symbol, SyntaxReference reference)
        {
            if (symbol.ContainingSymbol == symbol.ContainingModule) return default;
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
            if (symbol is IModelSymbol msymbol && msymbol.ModelObject is not null && modelObjectProperty is not null)
            {
                symbol.Language.SymbolFacts.SetOrAddPropertyValue(msymbol.ModelObject, modelObjectProperty, value, location, diagnostics, cancellationToken);
            }
            if (result is not null)
            {
                if (value is not null && !typeof(T).IsAssignableFrom(value.GetType()))
                {
                    if (typeof(Symbol).IsAssignableFrom(typeof(T)) && value is not Symbol)
                    {
                        var symbolFactory = symbol.ContainingModule.SymbolFactory;
                        var valueSymbol = symbolFactory.ResolveSymbol(value);
                        if (valueSymbol is not null)
                        {
                            if (!typeof(T).IsAssignableFrom(valueSymbol.GetType()))
                            {
                                diagnostics.Add(ModelErrorCode.ERR_CannotSetSymbolProperty.ToDiagnostic(location, valueSymbol.ToString(), symbolPropertyName, symbol.ToString(), typeof(T).ToString(), valueSymbol.GetType().ToString()));
                            }
                            else
                            {
                                result.Add((T)(object)valueSymbol);
                            }
                        }
                        else
                        {
                            diagnostics.Add(ModelErrorCode.ERR_CannotSetSymbolProperty.ToDiagnostic(location, value.ToString(), symbolPropertyName, symbol.ToString(), typeof(T).ToString(), value.GetType().ToString()));
                        }
                    }
                    else
                    {
                        diagnostics.Add(ModelErrorCode.ERR_CannotSetSymbolProperty.ToDiagnostic(location, value.ToString(), symbolPropertyName, symbol.ToString(), typeof(T).ToString(), value.GetType().ToString()));
                    }
                }
                else if (value != null)
                {
                    result.Add((T)value);
                }
            }
        }

        public static ImmutableArray<Symbol> GetChildSymbols(Symbol symbol, SyntaxReference childSyntax)
        {
            if (symbol == null) return ImmutableArray<Symbol>.Empty;
            var childDeclarations = GetChildDeclarations(symbol, childSyntax);
            var result = ArrayBuilder<Symbol>.GetInstance();
            foreach (var childSymbol in symbol.ChildSymbols)
            {
                if (childSymbol is ISourceSymbol srcSymbol && childDeclarations.Contains(srcSymbol.MergedDeclaration))
                {
                    result.Add(childSymbol);
                }
            }
            return result.ToImmutableAndFree();
        }

        private static ImmutableArray<MergedDeclaration> GetChildDeclarations(Symbol symbol, SyntaxReference childSyntax)
        {
            if ((symbol as ISourceSymbol)?.MergedDeclaration == null) return ImmutableArray<MergedDeclaration>.Empty;
            var srcSymbol = (ISourceSymbol)symbol;
            var result = ArrayBuilder<MergedDeclaration>.GetInstance();
            foreach (var childDeclaration in srcSymbol.MergedDeclaration.Children)
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

    }
}

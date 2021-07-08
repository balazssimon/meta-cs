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
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public struct SourceSymbol //: IModelSourceSymbol
    {
        private Symbol _symbol;

        public SourceSymbol(Symbol symbol)
        {
            Debug.Assert(symbol is ISourceSymbol);
            _symbol = symbol;
        }

        public LanguageCompilation Compilation => _symbol.DeclaringCompilation;

        public Language Language => _symbol.Language;

        public SymbolFacts SymbolFacts => _symbol.Language.SymbolFacts;

        public object ModelObject => ((IModelSymbol)_symbol).ModelObject;

        public ImmutableArray<Symbol> ChildSymbols => _symbol.ChildSymbols;

        public SymbolFactory SymbolFactory => ((IModelSymbol)_symbol).SymbolFactory;

        public Type ModelObjectType => ((IModelSymbol)_symbol).ModelObjectType;

        public ImmutableArray<Diagnostic> Diagnostics => ((IModelSourceSymbol)_symbol).Diagnostics;

        public SourceSymbol Source => this;

        public MergedDeclaration MergedDeclaration => ((ISourceSymbol)_symbol).MergedDeclaration;

        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)
        {
            Debug.Assert(_symbol.DeclaringSyntaxReferences.Contains(reference));
            return FindBinders.FindSymbolBinder(_symbol, reference);
        }

        public ImmutableArray<BinderPosition<PropertyBinder>> FindPropertyBinders(BinderPosition<SymbolBinder> symbolDefBinder)
        {
            return FindBinders.FindPropertyBinders(symbolDefBinder);
        }

        public ImmutableArray<BinderPosition<ValueBinder>> FindValueBinders(BinderPosition<PropertyBinder> propertyBinder)
        {
            return FindBinders.FindPropertyValueBinders(propertyBinder);
        }

        public void CreateRootSymbols(ArrayBuilder<Symbol> childSymbols, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            Debug.Assert(_symbol.ContainingSymbol is SourceModuleSymbol);
            var symbolFactory = SymbolFactory;
            var ssymbol = _symbol as ISourceSymbol;
            if (ssymbol != null)
            {
                foreach (var decl in ssymbol.MergedDeclaration.Children)
                {
                    var rootSymbol = decl.DangerousCreateSymbol(_symbol, symbolFactory);
                    Debug.Assert(rootSymbol != null);
                    if (rootSymbol != null)
                    {
                        rootSymbol.ForceComplete(CompletionGraph.FinishCreated, null, cancellationToken);
                        childSymbols.Add(rootSymbol);
                    }
                }
            }
        }

        public void CreateContainedChildSymbols(ArrayBuilder<Symbol> childSymbols, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            Debug.Assert(_symbol.ContainingSymbol is IModelSourceSymbol);
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                CreateContainedChildSymbols(reference, childSymbols, diagnostics, cancellationToken);
            }
        }

        public void CreateContainedChildSymbols(SyntaxReference symbolPartReference, ArrayBuilder<Symbol> childSymbols, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            Debug.Assert(_symbol.ContainingSymbol is IModelSourceSymbol);
            var symbolFacts = SymbolFacts;
            var ssymbol = _symbol as ISourceSymbol;
            var nestingDeclaration = NestingParentDeclaration(symbolPartReference, _symbol);
            if (nestingDeclaration != null)
            {
                foreach (var childDeclaration in nestingDeclaration.Children)
                {
                    if (childDeclaration.Symbol == null)
                    {
                        /*var childSymbol = CreateChildSymbol(childDeclaration.NameLocations.FirstOrDefault(), childDeclaration, diagnostics, cancellationToken);
                        if (childSymbol is IModelSourceSymbol childSourceSymbol)
                        {
                            Debug.Assert(childSourceSymbol.ModelObject != null);
                        }
                        else
                        {
                            Debug.Assert(false);
                        }*/
                        var childSingleDeclaration = childDeclaration.GetSingleDeclaration(symbolPartReference);
                        Debug.Assert(childSingleDeclaration != null);
                        if (childSingleDeclaration != null)
                        {
                            var objectProperty = symbolFacts.GetProperty(ModelObject, childSingleDeclaration.NestingProperty);
                            var childSymbol = CreateChildSymbol(childSingleDeclaration.Location, childDeclaration, diagnostics, cancellationToken);
                            if (childSymbol is IModelSourceSymbol childSourceSymbol)
                            {
                                var childObject = childSourceSymbol.ModelObject;
                                symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, childObject, childDeclaration.NameLocations.FirstOrDefault(), diagnostics);
                                childSymbols.Add(childSymbol);
                            }
                            else
                            {
                                Debug.Assert(false);
                            }
                        }
                        else
                        {
                            Debug.Assert(false);
                            //CreateChildSymbol(childDeclaration.NameLocations.FirstOrDefault(), childDeclaration, diagnostics, cancellationToken);
                        }
                    }
                }
            }
            else if (ssymbol != null && ssymbol.MergedDeclaration != null)
            {
                foreach (var childDeclaration in ssymbol.MergedDeclaration.Children)
                {
                    if (childDeclaration.Symbol == null)
                    {
                        var childSymbol = CreateChildSymbol(childDeclaration.NameLocations.FirstOrDefault(), childDeclaration, diagnostics, cancellationToken);
                        childSymbols.Add(childSymbol);
                        if (childSymbol is IModelSymbol childSourceSymbol)
                        {
                            Debug.Assert(childSourceSymbol.ModelObject != null);
                        }
                    }
                    else
                    {
                        childSymbols.Add(childDeclaration.Symbol);
                    }
                }
            }
            else
            {
                Debug.Assert(false);
            }
        }

        private static MergedDeclaration NestingParentDeclaration(SyntaxReference symbolPartReference, Symbol symbol)
        {
            if ((symbol as ISourceSymbol)?.MergedDeclaration == null) return null;
            var srcSymbol = (ISourceSymbol)symbol;
            var singleDeclaration = srcSymbol.MergedDeclaration.GetSingleDeclaration(symbolPartReference);
            if (singleDeclaration.IsNestingParent) return srcSymbol.MergedDeclaration;
            else return null;
        }

        private static ImmutableArray<MergedDeclaration> GetChildDeclarations(SyntaxReference childSyntax, Symbol symbol)
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

        public static ImmutableArray<Symbol> GetChildSymbols(SyntaxReference childSyntax, Symbol symbol)
        {
            if (symbol == null) return ImmutableArray<Symbol>.Empty;
            var childDeclarations = GetChildDeclarations(childSyntax, symbol);
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

        public static ImmutableArray<Symbol> GetInnermostNestedSymbols(SyntaxReference childSyntax, Symbol symbol)
        {
            if (symbol == null) return ImmutableArray<Symbol>.Empty;
            var result = ArrayBuilder<Symbol>.GetInstance();
            var childSymbols = GetChildSymbols(childSyntax, symbol);
            result.AddRange(childSymbols);
            int index = 0;
            while (index < result.Count)
            {
                var childSymbol = result[index];
                var nestingDeclaration = NestingParentDeclaration(childSyntax, childSymbol);
                if (nestingDeclaration != null)
                {
                    var nestedChildSymbols = GetChildSymbols(childSyntax, childSymbol);
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

        public T AssignPropertyValue<T>(string symbolProperty, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (symbolProperty == SymbolConstants.NameProperty)
            {
                AssignNameProperty(diagnostics);
                //Debug.Assert(false, "Use AssignNameProperty to assign the Name property.");
            }
            else if (symbolProperty != null)
            {
                var values = AssignPropertyValues<T>(symbolProperty, diagnostics, cancellationToken);
                if (values.Length == 1)
                {
                    return values[0];
                }
                else
                {
                    Debug.Assert(false);
                    return default;
                }
            }
            else
            {
                Debug.Assert(false, "Use AssignPropertyValues to assign non-symbol properties.");
            }
            return default;
        }

        public ImmutableArray<T> AssignPropertyValues<T>(string symbolProperty, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (symbolProperty == SymbolConstants.NameProperty)
            {
                Debug.Assert(false, "Use AssignNameProperty to assign the Name property.");
            }
            else if (symbolProperty != null)
            {
                var values = ArrayBuilder<object>.GetInstance();
                AssignSymbolProperty(symbolProperty, typeof(T), values, diagnostics, cancellationToken);
                var result = values.Cast<T>().ToImmutableArray();
                values.Free();
                return result;
            }
            else
            {
                AssignNonSymbolProperties(diagnostics, cancellationToken);
            }
            return ImmutableArray<T>.Empty;
        }

        public void AssignPropertyValues(string symbolProperty, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (symbolProperty == SymbolConstants.NameProperty)
            {
                AssignNameProperty(diagnostics);
            }
            else if (symbolProperty != null)
            {
                AssignSymbolProperty(symbolProperty, null, null, diagnostics, cancellationToken);
            }
            else
            {
                AssignNonSymbolProperties(diagnostics, cancellationToken);
            }
        }

        public string AssignNameProperty(DiagnosticBag diagnostics)
        {
            if (_symbol is ISourceSymbol ssymbol)
            {
                var symbolFacts = SymbolFacts;
                var objectProperties = symbolFacts.GetPropertiesForSymbol(ModelObject, SymbolConstants.NameProperty);
                var mergedDeclaration = ssymbol.MergedDeclaration;
                foreach (var objectProperty in objectProperties)
                {
                    symbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, mergedDeclaration.Name, mergedDeclaration.NameLocations.FirstOrDefault(), diagnostics);
                }
                return mergedDeclaration.Name;
            }
            return string.Empty;
        }

        private void AssignSymbolProperty(string symbolProperty, Type expectedType, ArrayBuilder<object> symbolPropertyValues, DiagnosticBag diagnostics, CancellationToken cancellationToken)
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
                        if (objectProperties.Contains(objectProperty))
                        {
                            var values = FindValueBinders(property);
                            foreach (var value in values)
                            {
                                AssignObjectProperty(value, property.Binder.PropertyName, objectProperty, symbolProperty, expectedType, symbolPropertyValues, diagnostics, cancellationToken);
                            }
                        }
                    }
                }
            }
        }

        private void AssignNonSymbolProperties(DiagnosticBag diagnostics, CancellationToken cancellationToken)
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
                    if (objectProperty == null || objectProperties.Contains(objectProperty))
                    {
                        var values = FindValueBinders(property);
                        foreach (var value in values)
                        {
                            if (objectProperty == null)
                            {
                                AssertionDiagnostic(diagnostics, ModelErrorCode.ERR_PropertyDoesNotExist.ToDiagnostic(value.Syntax.GetLocation(), property.Binder.PropertyName, ModelObject));
                                continue;
                            }
                            AssignObjectProperty(value, property.Binder.PropertyName, objectProperty, null, null, null, diagnostics, cancellationToken);
                        }
                    }
                }
            }
        }

        private void AssignObjectProperty(BinderPosition<ValueBinder> valueBinder, string propertyName, object objectProperty, string symbolProperty, Type expectedType, ArrayBuilder<object> symbolPropertyValues, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (ModelObject == null) return;
            if (valueBinder.Binder is DefineBinder valueSymbolDef)
            {
                AssignChildSymbols(valueSymbolDef, propertyName, objectProperty, symbolPropertyValues, diagnostics, cancellationToken);
            }
            else
            {
                var location = valueBinder.Syntax.GetLocation();
                var boundValue = valueBinder.Binder.Bind(diagnostics, cancellationToken) as BoundValue;
                Debug.Assert(boundValue != null);
                if (boundValue != null && !boundValue.Diagnostics.HasAnyErrors())
                {
                    foreach (var value in boundValue.Values)
                    {
                        SymbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, value, location, diagnostics);
                        if (symbolPropertyValues != null)
                        {
                            if (expectedType != null && value != null && expectedType.IsAssignableFrom(value.GetType()))
                            {
                                diagnostics.Add(ModelErrorCode.ERR_CannotSetSymbolProperty.ToDiagnostic(location, value, symbolProperty, _symbol, expectedType, value.GetType()));
                            }
                            symbolPropertyValues.Add(value);
                        }
                    }
                }
            }
        }

        private void AssignChildSymbols(DefineBinder childBinder, string propertyName, object objectProperty, ArrayBuilder<object> symbolPropertyValues, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var container = childBinder.ContainingDeclaration;
            var symbolPartReference = childBinder.Syntax.GetReference();
            var childDeclarations = GetChildDeclarations(symbolPartReference, container);
            if (childDeclarations.Length > 0)
            {
                foreach (var childDeclaration in childDeclarations)
                {
                    var childSymbol = childDeclaration.DangerousCreateSymbol(_symbol, SymbolFactory);
                    if (childSymbol != null)
                    {
                        if (childSymbol is IModelSymbol)
                        {
                            Debug.Assert(childDeclaration.ModelObjectType == childBinder.ModelObjectType);
                            var childSingleDeclaration = childDeclaration.GetSingleDeclaration(symbolPartReference);
                            Debug.Assert(childSingleDeclaration != null);
                            SymbolFacts.SetOrAddPropertyValue(ModelObject, objectProperty, childSymbol, childSingleDeclaration.Location, diagnostics);
                            if (symbolPropertyValues != null) symbolPropertyValues.Add(childSymbol);
                        }
                    }
                    else
                    {
                        Debug.Assert(false);
                    }
                }
            }
            else
            {
                Debug.Assert(false);
                //CreateChildSymbol(childBinder.Syntax.GetLocation(), null, symbolPartReference, childBinder.ModelObjectType, propertyName, objectProperty, diagnostics, cancellationToken);
            }
        }

        private Symbol CreateChildSymbol(Location location, MergedDeclaration childDeclaration, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            Symbol childSymbol;
            if (childDeclaration != null)
            {
                childSymbol = childDeclaration.DangerousCreateSymbol(_symbol, SymbolFactory);
                Debug.Assert(object.ReferenceEquals(childSymbol.ContainingSymbol, _symbol));
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
                    diagnostics.Add(ModelErrorCode.ERR_CannotCreateSourceDeclaredSymbol.ToDiagnostic(location, SymbolFacts.GetSymbolType(childDeclaration.ModelObjectType), childDeclaration.Name, childDeclaration.ModelObjectType));
                }
            }
            if (childSymbol != null)
            {
                childSymbol.ForceComplete(CompletionGraph.FinishCreated, null, cancellationToken);
            }
            return childSymbol;
        }

        private void AssertionDiagnostic(DiagnosticBag diagnostics, Diagnostic diagnostic)
        {
            diagnostics.Add(diagnostic);
            Debug.Assert(false, diagnostic.ToString());
        }

        public Symbol GetChildSymbol(SyntaxReference reference)
        {
            Debug.Assert(!_symbol.ChildSymbols.IsDefault);
            foreach (var child in _symbol.ChildSymbols)
            {
                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == reference.GetLocation()))
                {
                    return child;
                }
            }
            return null;
        }

        public Symbol GetChildSymbol(SyntaxNode syntax)
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

        public Symbol GetChildSymbol(SyntaxToken syntax)
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

        public void CompleteImports(Location locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (_symbol is ISourceSymbol ssymbol)
            {
                foreach (var declaration in ssymbol.MergedDeclaration.Declarations)
                {
                    if (locationOpt == null || locationOpt.SourceTree == declaration.SyntaxReference.SyntaxTree)
                    {
                        if (declaration.HasImports)
                        {
                            var imports = this.GetImports(declaration);
                            imports.Complete(cancellationToken);
                            diagnostics.AddRange(imports.Diagnostics);
                        }
                    }
                }
            }
        }

        private Imports GetImports(SingleDeclaration declaration)
        {
            var symbolDef = GetBinder(declaration.SyntaxReference);
            if (symbolDef.Binder != null)
            {
                return symbolDef.Binder.GetImports();
            }
            else
            {
                return Imports.Empty;
            }
        }

        public ImmutableArray<(CompletionPart start,CompletionPart finish)> CollectPhases()
        {
            var result = ArrayBuilder<(CompletionPart start, CompletionPart finish)>.GetInstance();
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentDeclaration(reference, _symbol as DeclaredSymbol);
                if (nestingDeclaration != null) continue;
                var symbolDef = GetBinder(reference);
                var phaseBinders = FindBinders.FindPhaseBinders(symbolDef, null, null);
                foreach (var phaseBinder in phaseBinders)
                {
                    var binder = phaseBinder.Binder;
                    if (!result.Contains((binder.StartPhase, binder.FinishPhase)))
                    {
                        result.Add((binder.StartPhase, binder.FinishPhase));
                    }
                }
            }
            return result.ToImmutableAndFree();
        }

        public ImmutableArray<CompletionPart> ExecutePhases(CompletionPart start, CompletionPart finish, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var result = ArrayBuilder<CompletionPart>.GetInstance();
            foreach (var reference in _symbol.DeclaringSyntaxReferences)
            {
                var nestingDeclaration = NestingParentDeclaration(reference, _symbol as DeclaredSymbol);
                if (nestingDeclaration != null) continue;
                var symbolDef = GetBinder(reference);
                var phaseBinders = FindBinders.FindPhaseBinders(symbolDef, start, finish);
                foreach (var phaseBinder in phaseBinders)
                {
                    phaseBinder.Binder.Bind(diagnostics, cancellationToken);
                }
            }
            return result.ToImmutableAndFree();
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

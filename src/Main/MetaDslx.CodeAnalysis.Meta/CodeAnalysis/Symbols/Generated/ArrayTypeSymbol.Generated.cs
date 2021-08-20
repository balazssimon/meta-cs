using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Roslyn.Utilities;

#nullable enable

namespace MetaDslx.CodeAnalysis.Symbols
{
	public abstract partial class ArrayTypeSymbol
	{
        public static new class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Attributes = MetaDslx.CodeAnalysis.Symbols.Symbol.CompletionParts.StartComputingProperty_Attributes;
            public static readonly CompletionPart FinishComputingProperty_Attributes = MetaDslx.CodeAnalysis.Symbols.Symbol.CompletionParts.FinishComputingProperty_Attributes;
            public static readonly CompletionPart StartComputingProperty_TypeParameters = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.StartComputingProperty_TypeParameters;
            public static readonly CompletionPart FinishComputingProperty_TypeParameters = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.FinishComputingProperty_TypeParameters;
            public static readonly CompletionPart StartComputingProperty_DeclaredAccessibility = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.StartComputingProperty_DeclaredAccessibility;
            public static readonly CompletionPart FinishComputingProperty_DeclaredAccessibility = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.FinishComputingProperty_DeclaredAccessibility;
            public static readonly CompletionPart StartComputingProperty_IsExtern = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.StartComputingProperty_IsExtern;
            public static readonly CompletionPart FinishComputingProperty_IsExtern = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.FinishComputingProperty_IsExtern;
            public static readonly CompletionPart StartComputingProperty_Members = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.StartComputingProperty_Members;
            public static readonly CompletionPart FinishComputingProperty_Members = MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol.CompletionParts.FinishComputingProperty_Members;
            public static readonly CompletionPart StartComputingProperty_BaseTypes = MetaDslx.CodeAnalysis.Symbols.TypeSymbol.CompletionParts.StartComputingProperty_BaseTypes;
            public static readonly CompletionPart FinishComputingProperty_BaseTypes = MetaDslx.CodeAnalysis.Symbols.TypeSymbol.CompletionParts.FinishComputingProperty_BaseTypes;
            public static readonly CompletionPart StartComputingProperty_LowerBound = new CompletionPart(nameof(StartComputingProperty_LowerBound));
            public static readonly CompletionPart FinishComputingProperty_LowerBound = new CompletionPart(nameof(FinishComputingProperty_LowerBound));
            public static readonly CompletionPart StartComputingProperty_Size = new CompletionPart(nameof(StartComputingProperty_Size));
            public static readonly CompletionPart FinishComputingProperty_Size = new CompletionPart(nameof(FinishComputingProperty_Size));
            public static readonly CompletionPart StartComputingProperty_ElementType = new CompletionPart(nameof(StartComputingProperty_ElementType));
            public static readonly CompletionPart FinishComputingProperty_ElementType = new CompletionPart(nameof(FinishComputingProperty_ElementType));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_BaseTypes, FinishComputingProperty_BaseTypes, StartComputingProperty_LowerBound, FinishComputingProperty_LowerBound, StartComputingProperty_Size, FinishComputingProperty_Size, StartComputingProperty_ElementType, FinishComputingProperty_ElementType, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_BaseTypes, FinishComputingProperty_BaseTypes, StartComputingProperty_LowerBound, FinishComputingProperty_LowerBound, StartComputingProperty_Size, FinishComputingProperty_Size, StartComputingProperty_ElementType, FinishComputingProperty_ElementType, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted, CompletionGraph.StartValidatingSymbol, CompletionGraph.FinishValidatingSymbol);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_BaseTypes, FinishComputingProperty_BaseTypes, StartComputingProperty_LowerBound, FinishComputingProperty_LowerBound, StartComputingProperty_Size, FinishComputingProperty_Size, StartComputingProperty_ElementType, FinishComputingProperty_ElementType, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted, CompletionGraph.StartValidatingSymbol, CompletionGraph.FinishValidatingSymbol);
        }

        public override void Accept(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor visitor)
        {
            if (visitor is ISymbolVisitor isv) isv.Visit(this);
        }

        public override TResult Accept<TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)
        {
            if (visitor is ISymbolVisitor<TResult> isv) return isv.Visit(this);
            else return default(TResult);
        }

        public override TResult Accept<TArgument, TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            if (visitor is ISymbolVisitor<TArgument, TResult> isv) return isv.Visit(this, argument);
            else return default(TResult);
        }
	}
}

namespace MetaDslx.CodeAnalysis.Symbols.Completion
{
	public abstract partial class CompletionArrayTypeSymbol : MetaDslx.CodeAnalysis.Symbols.ArrayTypeSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        private readonly Symbol _container;
        private readonly object? _modelObject;
        private readonly CompletionState _state;
        private ImmutableArray<Symbol> _childSymbols;
        private string _name;
        private string _metadataName;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> _attributes;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> _typeParameters;
        private global::Microsoft.CodeAnalysis.Accessibility _declaredAccessibility;
        private bool _isExtern;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> _members;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol> _baseTypes;
        private int _lowerBound;
        private int _size;
        private global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol _elementType;

        public CompletionArrayTypeSymbol(Symbol container, object? modelObject, bool isError = false)
        {
            _container = container;
            if (!isError && modelObject is null) throw new ArgumentNullException(nameof(modelObject));
            _modelObject = modelObject;
            _state = CompletionParts.CompletionGraph.CreateState();
        }

        public override Language Language => ContainingModule.Language;

        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;

        public object ModelObject => _modelObject;

        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;

        public override Symbol ContainingSymbol => _container;

        protected abstract ISymbolImplementation SymbolImplementation { get; }

        public override ImmutableArray<Symbol> ChildSymbols 
        {
            get
            {
                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);
                return _childSymbols;
            }
        }

        public override string Name 
        {
            get
            {
                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);
                return _name;
            }
        }

        public override string MetadataName 
        {
            get
            {
                this.ForceComplete(CompletionGraph.FinishInitializing, null, default);
                return _metadataName;
            }
        }

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> Attributes
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Attributes, null, default);
                return _attributes;
            }
        }

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> TypeParameters
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_TypeParameters, null, default);
                return _typeParameters;
            }
        }

        public override global::Microsoft.CodeAnalysis.Accessibility DeclaredAccessibility
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_DeclaredAccessibility, null, default);
                return _declaredAccessibility;
            }
        }

        public override bool IsExtern
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IsExtern, null, default);
                return _isExtern;
            }
        }

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> Members
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Members, null, default);
                return _members;
            }
        }

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol> BaseTypes
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_BaseTypes, null, default);
                return _baseTypes;
            }
        }

        public override int LowerBound
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_LowerBound, null, default);
                return _lowerBound;
            }
        }

        public override int Size
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Size, null, default);
                return _size;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol ElementType
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_ElementType, null, default);
                return _elementType;
            }
        }

        #region Completion

        public sealed override bool RequiresCompletion => true;

        public sealed override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        public override void ForceComplete(CompletionPart completionPart, SourceLocation? locationOpt, CancellationToken cancellationToken)
        {
            if (completionPart != null && _state.HasComplete(completionPart)) return;
            if (completionPart != null && !CompletionParts.All.Contains(completionPart)) throw new ArgumentException(nameof(completionPart));
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionGraph.StartInitializing || incompletePart == CompletionGraph.FinishInitializing)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartInitializing))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _name = CompleteSymbolProperty_Name(diagnostics, cancellationToken);
                        _metadataName = CompleteSymbolProperty_MetadataName(diagnostics, cancellationToken);
                        CompleteInitializingSymbol(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionGraph.FinishInitializing);
                    }
                }
                else if (incompletePart == CompletionGraph.StartCreatingChildren || incompletePart == CompletionGraph.FinishCreatingChildren)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartCreatingChildren))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _childSymbols = CompleteCreatingChildSymbols(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_Attributes || incompletePart == CompletionParts.FinishComputingProperty_Attributes)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Attributes))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _attributes = CompleteSymbolProperty_Attributes(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Attributes);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_TypeParameters || incompletePart == CompletionParts.FinishComputingProperty_TypeParameters)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_TypeParameters))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _typeParameters = CompleteSymbolProperty_TypeParameters(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_TypeParameters);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_DeclaredAccessibility || incompletePart == CompletionParts.FinishComputingProperty_DeclaredAccessibility)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_DeclaredAccessibility))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _declaredAccessibility = CompleteSymbolProperty_DeclaredAccessibility(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_DeclaredAccessibility);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_IsExtern || incompletePart == CompletionParts.FinishComputingProperty_IsExtern)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IsExtern))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _isExtern = CompleteSymbolProperty_IsExtern(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IsExtern);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_Members || incompletePart == CompletionParts.FinishComputingProperty_Members)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Members))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _members = CompleteSymbolProperty_Members(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Members);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_BaseTypes || incompletePart == CompletionParts.FinishComputingProperty_BaseTypes)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_BaseTypes))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _baseTypes = CompleteSymbolProperty_BaseTypes(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_BaseTypes);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_LowerBound || incompletePart == CompletionParts.FinishComputingProperty_LowerBound)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_LowerBound))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _lowerBound = CompleteSymbolProperty_LowerBound(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_LowerBound);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_Size || incompletePart == CompletionParts.FinishComputingProperty_Size)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Size))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _size = CompleteSymbolProperty_Size(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Size);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_ElementType || incompletePart == CompletionParts.FinishComputingProperty_ElementType)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_ElementType))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _elementType = CompleteSymbolProperty_ElementType(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_ElementType);
                    }
                }
                else if (incompletePart == CompletionGraph.StartComputingNonSymbolProperties || incompletePart == CompletionGraph.FinishComputingNonSymbolProperties)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartComputingNonSymbolProperties))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        CompleteNonSymbolProperties(locationOpt, diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionGraph.FinishComputingNonSymbolProperties);
                    }
                }
                else if (incompletePart == CompletionGraph.ChildrenCompleted)
                {
                    var diagnostics = DiagnosticBag.GetInstance();
                    CompleteImports(locationOpt, diagnostics, cancellationToken);
                    AddSymbolDiagnostics(diagnostics);
                    diagnostics.Free();
                    bool allCompleted = true;
                    if (locationOpt == null)
                    {
                        foreach (var child in _childSymbols)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            child.ForceComplete(null, locationOpt, cancellationToken);
                        }
                    }
                    else
                    {
                        foreach (var child in _childSymbols)
                        {
                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);
                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);
                        }
                    }
                    if (!allCompleted)
                    {
                        // We did not complete all members, so just kick out now.
                        var allParts = CompletionParts.AllWithLocation;
                        _state.SpinWaitComplete(allParts, cancellationToken);
                        return;
                    }
                    // We've completed all members, proceed to the next iteration.
                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);
                }
                else if (incompletePart == CompletionGraph.StartValidatingSymbol || incompletePart == CompletionGraph.FinishValidatingSymbol)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartValidatingSymbol))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        CompleteValidatingSymbol(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionGraph.FinishValidatingSymbol);
                    }
                }
                else if (incompletePart == null)
                {
                    return;
                }
                else
                {
                    // This assert will trigger if we forgot to handle any of the completion parts
                    Debug.Assert(!CompletionParts.All.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
                if (completionPart != null && _state.HasComplete(completionPart)) return;
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }
            throw ExceptionUtilities.Unreachable;
        }


        protected virtual string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolImplementation.AssignNameProperty(this, diagnostics);
        }

        protected virtual string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolImplementation.AssignMetadataNameProperty(this, diagnostics);
        }

        protected virtual void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected virtual ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);
        }

        protected virtual void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);
        }

        protected virtual global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> CompleteSymbolProperty_Attributes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.Symbol>(this, nameof(Attributes), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> CompleteSymbolProperty_TypeParameters(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol>(this, nameof(TypeParameters), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual global::Microsoft.CodeAnalysis.Accessibility CompleteSymbolProperty_DeclaredAccessibility(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValue<global::Microsoft.CodeAnalysis.Accessibility>(this, nameof(DeclaredAccessibility), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual bool CompleteSymbolProperty_IsExtern(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsExtern), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> CompleteSymbolProperty_Members(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Members), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol> CompleteSymbolProperty_BaseTypes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol>(this, nameof(BaseTypes), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual int CompleteSymbolProperty_LowerBound(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValue<int>(this, nameof(LowerBound), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual int CompleteSymbolProperty_Size(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValue<int>(this, nameof(Size), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol CompleteSymbolProperty_ElementType(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol>(this, nameof(ElementType), diagnostics, cancellationToken, out var result);
            return result;
        }

        protected virtual void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);
        }
        #endregion
    }
}

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
	public partial class MetadataArrayTypeSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionArrayTypeSymbol
	{
        public MetadataArrayTypeSymbol(Symbol container, object? modelObject, bool isError = false)
            : base(container, modelObject, isError)
        {
        }

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;
        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        protected override ISymbolImplementation SymbolImplementation => MetadataSymbolImplementation.Instance;

        public partial class Error : MetadataArrayTypeSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
        {
            private readonly string _name;
            private readonly string _metadataName;
            private DiagnosticInfo _errorInfo;
            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;
            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;
            private ImmutableArray<Symbol> _candidateSymbols;

            private Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags, object? modelObject)
                : base(container, modelObject, true)
            {
                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);
                _name = name;
                _metadataName = metadataName;
                _kind = kind;
                _errorInfo = errorInfo;
                _candidateSymbols = candidateSymbols;
                _flags = flags;
            }
            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
                : this(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None, modelObject)
            {
            }
            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
                : this(wrappedSymbol.ContainingSymbol, wrappedSymbol.Name, wrappedSymbol.MetadataName, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped, modelObject is not null ? modelObject : (wrappedSymbol as IModelSymbol)?.ModelObject)
            {
            }

            protected virtual Error Update(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags, object? modelObject)
            {
                return new Error(container, name, metadataName, kind, errorInfo, candidateSymbols, flags, modelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)
            {
                return this.IsUnreported ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported, this.ModelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)
            {
                return this.IsUnreported ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported, this.ModelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)
            {
                return _kind == kind ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, CandidateSymbols, _flags, this.ModelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)
            {
                return _kind == kind && CandidateSymbols == candidateSymbols ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, candidateSymbols, _flags, this.ModelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)
            {
                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, kind, errorInfo, candidateSymbols, _flags, this.ModelObject);
            }

            public override string Name => _name;

            public override string MetadataName => _metadataName;

            public sealed override bool IsError => true;

            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);

            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;

            public ImmutableArray<Symbol> CandidateSymbols
            {
                get
                {
                    if (_candidateSymbols.IsDefault)
                    {
                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());
                    }
                    return _candidateSymbols;
                }
            }

            public DiagnosticInfo? ErrorInfo
            {
                get
                {
                    if (_errorInfo is null)
                    {
                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);
                    }
                    return _errorInfo;
                }
            }

            protected virtual DiagnosticInfo? MakeErrorInfo()
            {
                return ErrorSymbolImplementation.MakeErrorInfo(this);
            }

            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()
            {
                return ErrorSymbolImplementation.MakeCandidateSymbols(this);
            }

            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                return _name;
            }

            protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                return _metadataName;
            }
        }
    }
}

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
	public partial class SourceArrayTypeSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionArrayTypeSymbol, MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol
	{
        private readonly MergedDeclaration _declaration;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

		public SourceArrayTypeSymbol(Symbol containingSymbol, MergedDeclaration declaration, object? modelObject, bool isError = false)
            : base(containingSymbol, modelObject, isError)
        {
            if (declaration is null) throw new ArgumentNullException(nameof(declaration));
            _declaration = declaration;
		}

        public MergedDeclaration MergedDeclaration => _declaration;

        public override ImmutableArray<Location> Locations => _declaration.NameLocations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;

        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)
        {
            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));
            return FindBinders.FindSymbolBinder(this, reference);
        }

        public Symbol GetChildSymbol(SyntaxReference syntax)
        {
            foreach (var child in this.ChildSymbols)
            {
                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))
                {
                    return child;
                }
            }
            return null;
        }
        public override LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));
            }
            return _lazyLexicalSortKey;
        }

        protected override ISymbolImplementation SymbolImplementation => SourceSymbolImplementation.Instance;

        public partial class Error : SourceArrayTypeSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
        {
            private readonly string _name;
            private readonly string _metadataName;
            private DiagnosticInfo _errorInfo;
            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;
            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags _flags;
            private ImmutableArray<Symbol> _candidateSymbols;

            private Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags, object? modelObject)
                : base(container, declaration, modelObject, true)
            {
                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);
                _name = declaration.Name;
                _metadataName = declaration.MetadataName;
                _kind = kind;
                _errorInfo = errorInfo;
                _candidateSymbols = candidateSymbols;
                _flags = flags;
            }
            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
                : this(container, declaration, kind, errorInfo, candidateSymbols, unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None, modelObject)
            {
            }
            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
                : this(wrappedSymbol.ContainingSymbol, (wrappedSymbol as ISourceSymbol).MergedDeclaration, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped, modelObject is not null ? modelObject :  (wrappedSymbol as IModelSymbol)?.ModelObject)
            {
            }

            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags, object? modelObject)
            {
                return new Error(container, declaration, kind, errorInfo, candidateSymbols, flags, modelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsReported(DiagnosticInfo? errorInfo = null)
            {
                return this.IsUnreported ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags & ~MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported, this.ModelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsUnreported(DiagnosticInfo? errorInfo = null)
            {
                return this.IsUnreported ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo is null ? ErrorInfo : errorInfo, CandidateSymbols, _flags | MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported, this.ModelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)
            {
                return _kind == kind ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, CandidateSymbols, _flags, this.ModelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)
            {
                return _kind == kind && CandidateSymbols == candidateSymbols ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, candidateSymbols, _flags, this.ModelObject);
            }

            public MetaDslx.CodeAnalysis.Symbols.Symbol AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<MetaDslx.CodeAnalysis.Symbols.Symbol> candidateSymbols)
            {
                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, errorInfo, candidateSymbols, _flags, this.ModelObject);
            }

            public override string Name => _name;

            public override string MetadataName => _metadataName;

            public sealed override bool IsError => true;

            public bool IsUnreported => _flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported);

            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;

            public ImmutableArray<Symbol> CandidateSymbols
            {
                get
                {
                    if (_candidateSymbols.IsDefault)
                    {
                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());
                    }
                    return _candidateSymbols;
                }
            }

            public DiagnosticInfo? ErrorInfo
            {
                get
                {
                    if (_errorInfo is null)
                    {
                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);
                    }
                    return _errorInfo;
                }
            }

            public DiagnosticInfo? UseSiteDiagnosticInfo => IsUnreported ? ErrorInfo : null;

            protected virtual DiagnosticInfo? MakeErrorInfo()
            {
                return null;
            }

            protected virtual ImmutableArray<Symbol> MakeCandidateSymbols()
            {
                return ImmutableArray<Symbol>.Empty;
            }

            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                return _name;
            }

            protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                return _metadataName;
            }
        }
	}
}

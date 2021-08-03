using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Completion
{
	public abstract partial class CompletionPropertySymbol : MetaDslx.CodeAnalysis.Symbols.PropertySymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        public static class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Attributes = new CompletionPart(nameof(StartComputingProperty_Attributes));
            public static readonly CompletionPart FinishComputingProperty_Attributes = new CompletionPart(nameof(FinishComputingProperty_Attributes));
            public static readonly CompletionPart StartComputingProperty_TypeParameters = new CompletionPart(nameof(StartComputingProperty_TypeParameters));
            public static readonly CompletionPart FinishComputingProperty_TypeParameters = new CompletionPart(nameof(FinishComputingProperty_TypeParameters));
            public static readonly CompletionPart StartComputingProperty_DeclaredAccessibility = new CompletionPart(nameof(StartComputingProperty_DeclaredAccessibility));
            public static readonly CompletionPart FinishComputingProperty_DeclaredAccessibility = new CompletionPart(nameof(FinishComputingProperty_DeclaredAccessibility));
            public static readonly CompletionPart StartComputingProperty_IsExtern = new CompletionPart(nameof(StartComputingProperty_IsExtern));
            public static readonly CompletionPart FinishComputingProperty_IsExtern = new CompletionPart(nameof(FinishComputingProperty_IsExtern));
            public static readonly CompletionPart StartComputingProperty_Members = new CompletionPart(nameof(StartComputingProperty_Members));
            public static readonly CompletionPart FinishComputingProperty_Members = new CompletionPart(nameof(FinishComputingProperty_Members));
            public static readonly CompletionPart StartComputingProperty_IsStatic = new CompletionPart(nameof(StartComputingProperty_IsStatic));
            public static readonly CompletionPart FinishComputingProperty_IsStatic = new CompletionPart(nameof(FinishComputingProperty_IsStatic));
            public static readonly CompletionPart StartComputingProperty_IsVirtual = new CompletionPart(nameof(StartComputingProperty_IsVirtual));
            public static readonly CompletionPart FinishComputingProperty_IsVirtual = new CompletionPart(nameof(FinishComputingProperty_IsVirtual));
            public static readonly CompletionPart StartComputingProperty_IsOverride = new CompletionPart(nameof(StartComputingProperty_IsOverride));
            public static readonly CompletionPart FinishComputingProperty_IsOverride = new CompletionPart(nameof(FinishComputingProperty_IsOverride));
            public static readonly CompletionPart StartComputingProperty_IsAbstract = new CompletionPart(nameof(StartComputingProperty_IsAbstract));
            public static readonly CompletionPart FinishComputingProperty_IsAbstract = new CompletionPart(nameof(FinishComputingProperty_IsAbstract));
            public static readonly CompletionPart StartComputingProperty_IsSealed = new CompletionPart(nameof(StartComputingProperty_IsSealed));
            public static readonly CompletionPart FinishComputingProperty_IsSealed = new CompletionPart(nameof(FinishComputingProperty_IsSealed));
            public static readonly CompletionPart StartComputingProperty_Type = new CompletionPart(nameof(StartComputingProperty_Type));
            public static readonly CompletionPart FinishComputingProperty_Type = new CompletionPart(nameof(FinishComputingProperty_Type));
            public static readonly CompletionPart StartComputingProperty_GetMethod = new CompletionPart(nameof(StartComputingProperty_GetMethod));
            public static readonly CompletionPart FinishComputingProperty_GetMethod = new CompletionPart(nameof(FinishComputingProperty_GetMethod));
            public static readonly CompletionPart StartComputingProperty_SetMethod = new CompletionPart(nameof(StartComputingProperty_SetMethod));
            public static readonly CompletionPart FinishComputingProperty_SetMethod = new CompletionPart(nameof(FinishComputingProperty_SetMethod));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_IsStatic, FinishComputingProperty_IsStatic, StartComputingProperty_IsVirtual, FinishComputingProperty_IsVirtual, StartComputingProperty_IsOverride, FinishComputingProperty_IsOverride, StartComputingProperty_IsAbstract, FinishComputingProperty_IsAbstract, StartComputingProperty_IsSealed, FinishComputingProperty_IsSealed, StartComputingProperty_Type, FinishComputingProperty_Type, StartComputingProperty_GetMethod, FinishComputingProperty_GetMethod, StartComputingProperty_SetMethod, FinishComputingProperty_SetMethod, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_IsStatic, FinishComputingProperty_IsStatic, StartComputingProperty_IsVirtual, FinishComputingProperty_IsVirtual, StartComputingProperty_IsOverride, FinishComputingProperty_IsOverride, StartComputingProperty_IsAbstract, FinishComputingProperty_IsAbstract, StartComputingProperty_IsSealed, FinishComputingProperty_IsSealed, StartComputingProperty_Type, FinishComputingProperty_Type, StartComputingProperty_GetMethod, FinishComputingProperty_GetMethod, StartComputingProperty_SetMethod, FinishComputingProperty_SetMethod, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_TypeParameters, FinishComputingProperty_TypeParameters, StartComputingProperty_DeclaredAccessibility, FinishComputingProperty_DeclaredAccessibility, StartComputingProperty_IsExtern, FinishComputingProperty_IsExtern, StartComputingProperty_Members, FinishComputingProperty_Members, StartComputingProperty_IsStatic, FinishComputingProperty_IsStatic, StartComputingProperty_IsVirtual, FinishComputingProperty_IsVirtual, StartComputingProperty_IsOverride, FinishComputingProperty_IsOverride, StartComputingProperty_IsAbstract, FinishComputingProperty_IsAbstract, StartComputingProperty_IsSealed, FinishComputingProperty_IsSealed, StartComputingProperty_Type, FinishComputingProperty_Type, StartComputingProperty_GetMethod, FinishComputingProperty_GetMethod, StartComputingProperty_SetMethod, FinishComputingProperty_SetMethod, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
        }

        private readonly Symbol _container;
        private readonly object? _modelObject;
        private readonly CompletionState _state;
        private ImmutableArray<Symbol> _childSymbols;
        private string _name;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> _attributes;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> _typeParameters;
        private global::Microsoft.CodeAnalysis.Accessibility _declaredAccessibility;
        private bool _isExtern;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> _members;
        private bool _isStatic;
        private bool _isVirtual;
        private bool _isOverride;
        private bool _isAbstract;
        private bool _isSealed;
        private global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol _type;
        private global::MetaDslx.CodeAnalysis.Symbols.MethodSymbol _getMethod;
        private global::MetaDslx.CodeAnalysis.Symbols.MethodSymbol _setMethod;

        public CompletionPropertySymbol(Symbol container, object? modelObject)
        {
            _container = container;
            if (modelObject is null) throw new ArgumentNullException(nameof(modelObject));
            _modelObject = modelObject;
            _state = CompletionParts.CompletionGraph.CreateState();
        }

        public sealed override Language Language => ContainingModule.Language;

        public SymbolFactory SymbolFactory => ContainingModule.SymbolFactory;

        public object ModelObject => _modelObject;

        public Type ModelObjectType => _modelObject is not null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;

        public sealed override Symbol ContainingSymbol => _container;

        public sealed override ImmutableArray<Symbol> ChildSymbols 
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

        public override bool IsStatic
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IsStatic, null, default);
                return _isStatic;
            }
        }

        public override bool IsVirtual
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IsVirtual, null, default);
                return _isVirtual;
            }
        }

        public override bool IsOverride
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IsOverride, null, default);
                return _isOverride;
            }
        }

        public override bool IsAbstract
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IsAbstract, null, default);
                return _isAbstract;
            }
        }

        public override bool IsSealed
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IsSealed, null, default);
                return _isSealed;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol Type
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Type, null, default);
                return _type;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.MethodSymbol GetMethod
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_GetMethod, null, default);
                return _getMethod;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.MethodSymbol SetMethod
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_SetMethod, null, default);
                return _setMethod;
            }
        }

        #region Completion

        public sealed override bool RequiresCompletion => true;

        public sealed override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)
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
                else if (incompletePart == CompletionParts.StartComputingProperty_IsStatic || incompletePart == CompletionParts.FinishComputingProperty_IsStatic)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IsStatic))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _isStatic = CompleteSymbolProperty_IsStatic(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IsStatic);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_IsVirtual || incompletePart == CompletionParts.FinishComputingProperty_IsVirtual)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IsVirtual))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _isVirtual = CompleteSymbolProperty_IsVirtual(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IsVirtual);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_IsOverride || incompletePart == CompletionParts.FinishComputingProperty_IsOverride)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IsOverride))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _isOverride = CompleteSymbolProperty_IsOverride(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IsOverride);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_IsAbstract || incompletePart == CompletionParts.FinishComputingProperty_IsAbstract)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IsAbstract))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _isAbstract = CompleteSymbolProperty_IsAbstract(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IsAbstract);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_IsSealed || incompletePart == CompletionParts.FinishComputingProperty_IsSealed)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IsSealed))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _isSealed = CompleteSymbolProperty_IsSealed(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IsSealed);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_Type || incompletePart == CompletionParts.FinishComputingProperty_Type)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Type))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _type = CompleteSymbolProperty_Type(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Type);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_GetMethod || incompletePart == CompletionParts.FinishComputingProperty_GetMethod)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_GetMethod))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _getMethod = CompleteSymbolProperty_GetMethod(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_GetMethod);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_SetMethod || incompletePart == CompletionParts.FinishComputingProperty_SetMethod)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_SetMethod))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _setMethod = CompleteSymbolProperty_SetMethod(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_SetMethod);
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

        protected abstract string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> CompleteSymbolProperty_Attributes(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> CompleteSymbolProperty_TypeParameters(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::Microsoft.CodeAnalysis.Accessibility CompleteSymbolProperty_DeclaredAccessibility(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_IsExtern(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> CompleteSymbolProperty_Members(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_IsStatic(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_IsVirtual(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_IsOverride(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_IsAbstract(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_IsSealed(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol CompleteSymbolProperty_Type(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.MethodSymbol CompleteSymbolProperty_GetMethod(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.MethodSymbol CompleteSymbolProperty_SetMethod(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        #endregion
    }
}

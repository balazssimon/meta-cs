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

namespace GeneratedSourceSymbols.Model
{
	public abstract partial class ModelCustomSymbol : GeneratedSourceSymbols.CustomSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        public static class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Left = new CompletionPart(nameof(StartComputingProperty_Left));
            public static readonly CompletionPart FinishComputingProperty_Left = new CompletionPart(nameof(FinishComputingProperty_Left));
            public static readonly CompletionPart StartComputingProperty_Right = new CompletionPart(nameof(StartComputingProperty_Right));
            public static readonly CompletionPart FinishComputingProperty_Right = new CompletionPart(nameof(FinishComputingProperty_Right));
            public static readonly CompletionPart StartComputingProperty_CustomArray = new CompletionPart(nameof(StartComputingProperty_CustomArray));
            public static readonly CompletionPart FinishComputingProperty_CustomArray = new CompletionPart(nameof(FinishComputingProperty_CustomArray));
            public static readonly CompletionPart StartComputingProperty_IntArray = new CompletionPart(nameof(StartComputingProperty_IntArray));
            public static readonly CompletionPart FinishComputingProperty_IntArray = new CompletionPart(nameof(FinishComputingProperty_IntArray));
            public static readonly CompletionPart StartComputingProperty_Int = new CompletionPart(nameof(StartComputingProperty_Int));
            public static readonly CompletionPart FinishComputingProperty_Int = new CompletionPart(nameof(FinishComputingProperty_Int));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Left, FinishComputingProperty_Left, StartComputingProperty_Right, FinishComputingProperty_Right, StartComputingProperty_CustomArray, FinishComputingProperty_CustomArray, StartComputingProperty_IntArray, FinishComputingProperty_IntArray, StartComputingProperty_Int, FinishComputingProperty_Int, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Left, FinishComputingProperty_Left, StartComputingProperty_Right, FinishComputingProperty_Right, StartComputingProperty_CustomArray, FinishComputingProperty_CustomArray, StartComputingProperty_IntArray, FinishComputingProperty_IntArray, StartComputingProperty_Int, FinishComputingProperty_Int, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Left, FinishComputingProperty_Left, StartComputingProperty_Right, FinishComputingProperty_Right, StartComputingProperty_CustomArray, FinishComputingProperty_CustomArray, StartComputingProperty_IntArray, FinishComputingProperty_IntArray, StartComputingProperty_Int, FinishComputingProperty_Int, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
        }

        private readonly Symbol _container;
        private readonly object _modelObject;
        private readonly CompletionState _state;
        private ImmutableArray<Symbol> _childSymbols;
        private global::GeneratedSourceSymbols.CustomSymbol _left;
        private global::GeneratedSourceSymbols.CustomSymbol _right;
        private global::System.Collections.Immutable.ImmutableArray<global::GeneratedSourceSymbols.CustomSymbol> _customArray;
        private global::System.Collections.Immutable.ImmutableArray<int> _intArray;
        private int _int;

        public ModelCustomSymbol(Symbol container, object modelObject)
        {
            Debug.Assert(container is IModelSymbol);
            if (modelObject == null) throw new ArgumentNullException(nameof(modelObject));
            _container = container;
            _modelObject = modelObject;
            _state = CompletionParts.CompletionGraph.CreateState();
        }

        public sealed override Language Language => ContainingModule.Language;

        public SymbolFactory SymbolFactory => ((IModelSymbol)_container).SymbolFactory;

        public object ModelObject => _modelObject;

        public Type ModelObjectType => _modelObject != null ? Language.SymbolFacts.GetModelObjectType(_modelObject) : null;

        public sealed override string Name => _modelObject != null ? Language.SymbolFacts.GetName(_modelObject) : string.Empty;

        public sealed override Symbol ContainingSymbol => _container;

        public sealed override ImmutableArray<Symbol> ChildSymbols 
        {
            get
            {
                this.ForceComplete(CompletionGraph.FinishCreatingChildren, null, default);
                return _childSymbols;
            }
        }

        public override global::GeneratedSourceSymbols.CustomSymbol Left
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Left, null, default);
                return _left;
            }
        }
        public override global::GeneratedSourceSymbols.CustomSymbol Right
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Right, null, default);
                return _right;
            }
        }
        public override global::System.Collections.Immutable.ImmutableArray<global::GeneratedSourceSymbols.CustomSymbol> CustomArray
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_CustomArray, null, default);
                return _customArray;
            }
        }
        public override global::System.Collections.Immutable.ImmutableArray<int> IntArray
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IntArray, null, default);
                return _intArray;
            }
        }
        public override int Int
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Int, null, default);
                return _int;
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
                        CompleteInitializingSymbol(locationOpt, diagnostics, cancellationToken);
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
                        _childSymbols = CompleteCreatingChildSymbols(locationOpt, diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionGraph.FinishCreatingChildren);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_Left || incompletePart == CompletionParts.FinishComputingProperty_Left)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Left))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _left = CompleteSymbolProperty_Left(locationOpt, diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Left);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_Right || incompletePart == CompletionParts.FinishComputingProperty_Right)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Right))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _right = CompleteSymbolProperty_Right(locationOpt, diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Right);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_CustomArray || incompletePart == CompletionParts.FinishComputingProperty_CustomArray)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_CustomArray))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _customArray = CompleteSymbolProperty_CustomArray(locationOpt, diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_CustomArray);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_IntArray || incompletePart == CompletionParts.FinishComputingProperty_IntArray)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IntArray))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _intArray = CompleteSymbolProperty_IntArray(locationOpt, diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IntArray);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_Int || incompletePart == CompletionParts.FinishComputingProperty_Int)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Int))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _int = CompleteSymbolProperty_Int(locationOpt, diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Int);
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

        protected abstract void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::GeneratedSourceSymbols.CustomSymbol CompleteSymbolProperty_Left(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::GeneratedSourceSymbols.CustomSymbol CompleteSymbolProperty_Right(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::System.Collections.Immutable.ImmutableArray<global::GeneratedSourceSymbols.CustomSymbol> CompleteSymbolProperty_CustomArray(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::System.Collections.Immutable.ImmutableArray<int> CompleteSymbolProperty_IntArray(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract int CompleteSymbolProperty_Int(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        #endregion

    }
}

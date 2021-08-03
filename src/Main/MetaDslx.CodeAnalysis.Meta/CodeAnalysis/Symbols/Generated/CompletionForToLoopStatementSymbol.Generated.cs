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
	public abstract partial class CompletionForToLoopStatementSymbol : MetaDslx.CodeAnalysis.Symbols.ForToLoopStatementSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        public static class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Attributes = new CompletionPart(nameof(StartComputingProperty_Attributes));
            public static readonly CompletionPart FinishComputingProperty_Attributes = new CompletionPart(nameof(FinishComputingProperty_Attributes));
            public static readonly CompletionPart StartComputingProperty_Body = new CompletionPart(nameof(StartComputingProperty_Body));
            public static readonly CompletionPart FinishComputingProperty_Body = new CompletionPart(nameof(FinishComputingProperty_Body));
            public static readonly CompletionPart StartComputingProperty_LoopControlVariable = new CompletionPart(nameof(StartComputingProperty_LoopControlVariable));
            public static readonly CompletionPart FinishComputingProperty_LoopControlVariable = new CompletionPart(nameof(FinishComputingProperty_LoopControlVariable));
            public static readonly CompletionPart StartComputingProperty_InitialValue = new CompletionPart(nameof(StartComputingProperty_InitialValue));
            public static readonly CompletionPart FinishComputingProperty_InitialValue = new CompletionPart(nameof(FinishComputingProperty_InitialValue));
            public static readonly CompletionPart StartComputingProperty_LimitValue = new CompletionPart(nameof(StartComputingProperty_LimitValue));
            public static readonly CompletionPart FinishComputingProperty_LimitValue = new CompletionPart(nameof(FinishComputingProperty_LimitValue));
            public static readonly CompletionPart StartComputingProperty_StepValue = new CompletionPart(nameof(StartComputingProperty_StepValue));
            public static readonly CompletionPart FinishComputingProperty_StepValue = new CompletionPart(nameof(FinishComputingProperty_StepValue));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_LoopControlVariable, FinishComputingProperty_LoopControlVariable, StartComputingProperty_InitialValue, FinishComputingProperty_InitialValue, StartComputingProperty_LimitValue, FinishComputingProperty_LimitValue, StartComputingProperty_StepValue, FinishComputingProperty_StepValue, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_LoopControlVariable, FinishComputingProperty_LoopControlVariable, StartComputingProperty_InitialValue, FinishComputingProperty_InitialValue, StartComputingProperty_LimitValue, FinishComputingProperty_LimitValue, StartComputingProperty_StepValue, FinishComputingProperty_StepValue, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_LoopControlVariable, FinishComputingProperty_LoopControlVariable, StartComputingProperty_InitialValue, FinishComputingProperty_InitialValue, StartComputingProperty_LimitValue, FinishComputingProperty_LimitValue, StartComputingProperty_StepValue, FinishComputingProperty_StepValue, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
        }

        private readonly Symbol _container;
        private readonly object? _modelObject;
        private readonly CompletionState _state;
        private ImmutableArray<Symbol> _childSymbols;
        private string _name;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> _attributes;
        private global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol _body;
        private global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol _loopControlVariable;
        private global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol _initialValue;
        private global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol _limitValue;
        private global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol _stepValue;

        public CompletionForToLoopStatementSymbol(Symbol container, object? modelObject)
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

        public override global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol Body
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Body, null, default);
                return _body;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol LoopControlVariable
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_LoopControlVariable, null, default);
                return _loopControlVariable;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol InitialValue
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_InitialValue, null, default);
                return _initialValue;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol LimitValue
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_LimitValue, null, default);
                return _limitValue;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol StepValue
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_StepValue, null, default);
                return _stepValue;
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
                else if (incompletePart == CompletionParts.StartComputingProperty_Body || incompletePart == CompletionParts.FinishComputingProperty_Body)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Body))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _body = CompleteSymbolProperty_Body(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Body);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_LoopControlVariable || incompletePart == CompletionParts.FinishComputingProperty_LoopControlVariable)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_LoopControlVariable))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _loopControlVariable = CompleteSymbolProperty_LoopControlVariable(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_LoopControlVariable);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_InitialValue || incompletePart == CompletionParts.FinishComputingProperty_InitialValue)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_InitialValue))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _initialValue = CompleteSymbolProperty_InitialValue(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_InitialValue);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_LimitValue || incompletePart == CompletionParts.FinishComputingProperty_LimitValue)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_LimitValue))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _limitValue = CompleteSymbolProperty_LimitValue(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_LimitValue);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_StepValue || incompletePart == CompletionParts.FinishComputingProperty_StepValue)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_StepValue))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _stepValue = CompleteSymbolProperty_StepValue(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_StepValue);
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
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol CompleteSymbolProperty_Body(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol CompleteSymbolProperty_LoopControlVariable(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol CompleteSymbolProperty_InitialValue(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol CompleteSymbolProperty_LimitValue(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol CompleteSymbolProperty_StepValue(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        #endregion
    }
}

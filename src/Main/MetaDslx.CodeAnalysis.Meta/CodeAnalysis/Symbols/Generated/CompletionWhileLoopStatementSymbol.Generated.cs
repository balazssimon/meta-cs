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
	public abstract partial class CompletionWhileLoopStatementSymbol : MetaDslx.CodeAnalysis.Symbols.WhileLoopStatementSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        public static class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Attributes = new CompletionPart(nameof(StartComputingProperty_Attributes));
            public static readonly CompletionPart FinishComputingProperty_Attributes = new CompletionPart(nameof(FinishComputingProperty_Attributes));
            public static readonly CompletionPart StartComputingProperty_Body = new CompletionPart(nameof(StartComputingProperty_Body));
            public static readonly CompletionPart FinishComputingProperty_Body = new CompletionPart(nameof(FinishComputingProperty_Body));
            public static readonly CompletionPart StartComputingProperty_Condition = new CompletionPart(nameof(StartComputingProperty_Condition));
            public static readonly CompletionPart FinishComputingProperty_Condition = new CompletionPart(nameof(FinishComputingProperty_Condition));
            public static readonly CompletionPart StartComputingProperty_ConditionIsTop = new CompletionPart(nameof(StartComputingProperty_ConditionIsTop));
            public static readonly CompletionPart FinishComputingProperty_ConditionIsTop = new CompletionPart(nameof(FinishComputingProperty_ConditionIsTop));
            public static readonly CompletionPart StartComputingProperty_ConditionIsUntil = new CompletionPart(nameof(StartComputingProperty_ConditionIsUntil));
            public static readonly CompletionPart FinishComputingProperty_ConditionIsUntil = new CompletionPart(nameof(FinishComputingProperty_ConditionIsUntil));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_Condition, FinishComputingProperty_Condition, StartComputingProperty_ConditionIsTop, FinishComputingProperty_ConditionIsTop, StartComputingProperty_ConditionIsUntil, FinishComputingProperty_ConditionIsUntil, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_Condition, FinishComputingProperty_Condition, StartComputingProperty_ConditionIsTop, FinishComputingProperty_ConditionIsTop, StartComputingProperty_ConditionIsUntil, FinishComputingProperty_ConditionIsUntil, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_Condition, FinishComputingProperty_Condition, StartComputingProperty_ConditionIsTop, FinishComputingProperty_ConditionIsTop, StartComputingProperty_ConditionIsUntil, FinishComputingProperty_ConditionIsUntil, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
        }

        private readonly Symbol _container;
        private readonly object? _modelObject;
        private readonly CompletionState _state;
        private ImmutableArray<Symbol> _childSymbols;
        private string _name;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> _attributes;
        private global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol _body;
        private global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol _condition;
        private bool _conditionIsTop;
        private bool _conditionIsUntil;

        public CompletionWhileLoopStatementSymbol(Symbol container, object? modelObject, bool isError = false)
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

        public override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol Condition
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Condition, null, default);
                return _condition;
            }
        }

        public override bool ConditionIsTop
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_ConditionIsTop, null, default);
                return _conditionIsTop;
            }
        }

        public override bool ConditionIsUntil
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_ConditionIsUntil, null, default);
                return _conditionIsUntil;
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
                else if (incompletePart == CompletionParts.StartComputingProperty_Condition || incompletePart == CompletionParts.FinishComputingProperty_Condition)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Condition))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _condition = CompleteSymbolProperty_Condition(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Condition);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_ConditionIsTop || incompletePart == CompletionParts.FinishComputingProperty_ConditionIsTop)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_ConditionIsTop))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _conditionIsTop = CompleteSymbolProperty_ConditionIsTop(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_ConditionIsTop);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_ConditionIsUntil || incompletePart == CompletionParts.FinishComputingProperty_ConditionIsUntil)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_ConditionIsUntil))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _conditionIsUntil = CompleteSymbolProperty_ConditionIsUntil(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_ConditionIsUntil);
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
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol CompleteSymbolProperty_Condition(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_ConditionIsTop(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_ConditionIsUntil(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        #endregion
    }
}

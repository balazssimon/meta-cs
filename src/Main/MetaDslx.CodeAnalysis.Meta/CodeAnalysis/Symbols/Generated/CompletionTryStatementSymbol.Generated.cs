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
	public abstract partial class CompletionTryStatementSymbol : MetaDslx.CodeAnalysis.Symbols.TryStatementSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        public static class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Attributes = new CompletionPart(nameof(StartComputingProperty_Attributes));
            public static readonly CompletionPart FinishComputingProperty_Attributes = new CompletionPart(nameof(FinishComputingProperty_Attributes));
            public static readonly CompletionPart StartComputingProperty_Body = new CompletionPart(nameof(StartComputingProperty_Body));
            public static readonly CompletionPart FinishComputingProperty_Body = new CompletionPart(nameof(FinishComputingProperty_Body));
            public static readonly CompletionPart StartComputingProperty_Catches = new CompletionPart(nameof(StartComputingProperty_Catches));
            public static readonly CompletionPart FinishComputingProperty_Catches = new CompletionPart(nameof(FinishComputingProperty_Catches));
            public static readonly CompletionPart StartComputingProperty_Finally = new CompletionPart(nameof(StartComputingProperty_Finally));
            public static readonly CompletionPart FinishComputingProperty_Finally = new CompletionPart(nameof(FinishComputingProperty_Finally));
            public static readonly CompletionPart StartComputingProperty_ExitLabel = new CompletionPart(nameof(StartComputingProperty_ExitLabel));
            public static readonly CompletionPart FinishComputingProperty_ExitLabel = new CompletionPart(nameof(FinishComputingProperty_ExitLabel));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_Catches, FinishComputingProperty_Catches, StartComputingProperty_Finally, FinishComputingProperty_Finally, StartComputingProperty_ExitLabel, FinishComputingProperty_ExitLabel, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_Catches, FinishComputingProperty_Catches, StartComputingProperty_Finally, FinishComputingProperty_Finally, StartComputingProperty_ExitLabel, FinishComputingProperty_ExitLabel, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Body, FinishComputingProperty_Body, StartComputingProperty_Catches, FinishComputingProperty_Catches, StartComputingProperty_Finally, FinishComputingProperty_Finally, StartComputingProperty_ExitLabel, FinishComputingProperty_ExitLabel, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
        }

        private readonly Symbol _container;
        private readonly object? _modelObject;
        private readonly CompletionState _state;
        private ImmutableArray<Symbol> _childSymbols;
        private string _name;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> _attributes;
        private global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol _body;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.CatchClauseSymbol> _catches;
        private global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol _finally;
        private global::MetaDslx.CodeAnalysis.Symbols.LabelSymbol _exitLabel;

        public CompletionTryStatementSymbol(Symbol container, object? modelObject)
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

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.CatchClauseSymbol> Catches
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Catches, null, default);
                return _catches;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol Finally
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Finally, null, default);
                return _finally;
            }
        }

        public override global::MetaDslx.CodeAnalysis.Symbols.LabelSymbol ExitLabel
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_ExitLabel, null, default);
                return _exitLabel;
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
                else if (incompletePart == CompletionParts.StartComputingProperty_Catches || incompletePart == CompletionParts.FinishComputingProperty_Catches)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Catches))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _catches = CompleteSymbolProperty_Catches(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Catches);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_Finally || incompletePart == CompletionParts.FinishComputingProperty_Finally)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Finally))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _finally = CompleteSymbolProperty_Finally(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Finally);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_ExitLabel || incompletePart == CompletionParts.FinishComputingProperty_ExitLabel)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_ExitLabel))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _exitLabel = CompleteSymbolProperty_ExitLabel(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_ExitLabel);
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
        protected abstract global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.CatchClauseSymbol> CompleteSymbolProperty_Catches(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.StatementSymbol CompleteSymbolProperty_Finally(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.LabelSymbol CompleteSymbolProperty_ExitLabel(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        #endregion
    }
}

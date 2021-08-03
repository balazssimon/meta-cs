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
	public abstract partial class CompletionMemberReferenceExpressionSymbol : MetaDslx.CodeAnalysis.Symbols.MemberReferenceExpressionSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        public static class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Attributes = new CompletionPart(nameof(StartComputingProperty_Attributes));
            public static readonly CompletionPart FinishComputingProperty_Attributes = new CompletionPart(nameof(FinishComputingProperty_Attributes));
            public static readonly CompletionPart StartComputingProperty_Instance = new CompletionPart(nameof(StartComputingProperty_Instance));
            public static readonly CompletionPart FinishComputingProperty_Instance = new CompletionPart(nameof(FinishComputingProperty_Instance));
            public static readonly CompletionPart StartComputingProperty_MemberName = new CompletionPart(nameof(StartComputingProperty_MemberName));
            public static readonly CompletionPart FinishComputingProperty_MemberName = new CompletionPart(nameof(FinishComputingProperty_MemberName));
            public static readonly CompletionPart StartComputingProperty_IsNullConditional = new CompletionPart(nameof(StartComputingProperty_IsNullConditional));
            public static readonly CompletionPart FinishComputingProperty_IsNullConditional = new CompletionPart(nameof(FinishComputingProperty_IsNullConditional));
            public static readonly CompletionPart StartComputingProperty_TypeArguments = new CompletionPart(nameof(StartComputingProperty_TypeArguments));
            public static readonly CompletionPart FinishComputingProperty_TypeArguments = new CompletionPart(nameof(FinishComputingProperty_TypeArguments));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Instance, FinishComputingProperty_Instance, StartComputingProperty_MemberName, FinishComputingProperty_MemberName, StartComputingProperty_IsNullConditional, FinishComputingProperty_IsNullConditional, StartComputingProperty_TypeArguments, FinishComputingProperty_TypeArguments, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Instance, FinishComputingProperty_Instance, StartComputingProperty_MemberName, FinishComputingProperty_MemberName, StartComputingProperty_IsNullConditional, FinishComputingProperty_IsNullConditional, StartComputingProperty_TypeArguments, FinishComputingProperty_TypeArguments, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Instance, FinishComputingProperty_Instance, StartComputingProperty_MemberName, FinishComputingProperty_MemberName, StartComputingProperty_IsNullConditional, FinishComputingProperty_IsNullConditional, StartComputingProperty_TypeArguments, FinishComputingProperty_TypeArguments, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
        }

        private readonly Symbol _container;
        private readonly object? _modelObject;
        private readonly CompletionState _state;
        private ImmutableArray<Symbol> _childSymbols;
        private string _name;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> _attributes;
        private global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol _instance;
        private string _memberName;
        private bool _isNullConditional;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol> _typeArguments;

        public CompletionMemberReferenceExpressionSymbol(Symbol container, object? modelObject)
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

        public override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol Instance
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Instance, null, default);
                return _instance;
            }
        }

        public override string MemberName
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_MemberName, null, default);
                return _memberName;
            }
        }

        public override bool IsNullConditional
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IsNullConditional, null, default);
                return _isNullConditional;
            }
        }

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol> TypeArguments
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_TypeArguments, null, default);
                return _typeArguments;
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
                else if (incompletePart == CompletionParts.StartComputingProperty_Instance || incompletePart == CompletionParts.FinishComputingProperty_Instance)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Instance))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _instance = CompleteSymbolProperty_Instance(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Instance);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_MemberName || incompletePart == CompletionParts.FinishComputingProperty_MemberName)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_MemberName))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _memberName = CompleteSymbolProperty_MemberName(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_MemberName);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_IsNullConditional || incompletePart == CompletionParts.FinishComputingProperty_IsNullConditional)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IsNullConditional))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _isNullConditional = CompleteSymbolProperty_IsNullConditional(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IsNullConditional);
                    }
                }
                else if (incompletePart == CompletionParts.StartComputingProperty_TypeArguments || incompletePart == CompletionParts.FinishComputingProperty_TypeArguments)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_TypeArguments))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _typeArguments = CompleteSymbolProperty_TypeArguments(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_TypeArguments);
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
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol CompleteSymbolProperty_Instance(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract string CompleteSymbolProperty_MemberName(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_IsNullConditional(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol> CompleteSymbolProperty_TypeArguments(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        #endregion
    }
}
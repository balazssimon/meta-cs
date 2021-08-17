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
	public abstract partial class ReferenceExpressionSymbol
	{
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
	public abstract partial class CompletionReferenceExpressionSymbol : MetaDslx.CodeAnalysis.Symbols.ReferenceExpressionSymbol, MetaDslx.CodeAnalysis.Symbols.Metadata.IModelSymbol
	{
        public static class CompletionParts
        {
            public static readonly CompletionPart StartComputingProperty_Attributes = new CompletionPart(nameof(StartComputingProperty_Attributes));
            public static readonly CompletionPart FinishComputingProperty_Attributes = new CompletionPart(nameof(FinishComputingProperty_Attributes));
            public static readonly CompletionPart StartComputingProperty_Reference = new CompletionPart(nameof(StartComputingProperty_Reference));
            public static readonly CompletionPart FinishComputingProperty_Reference = new CompletionPart(nameof(FinishComputingProperty_Reference));
            public static readonly CompletionPart StartComputingProperty_TypeArguments = new CompletionPart(nameof(StartComputingProperty_TypeArguments));
            public static readonly CompletionPart FinishComputingProperty_TypeArguments = new CompletionPart(nameof(FinishComputingProperty_TypeArguments));
            public static readonly CompletionPart StartComputingProperty_IsDeclaration = new CompletionPart(nameof(StartComputingProperty_IsDeclaration));
            public static readonly CompletionPart FinishComputingProperty_IsDeclaration = new CompletionPart(nameof(FinishComputingProperty_IsDeclaration));
            public static readonly ImmutableHashSet<CompletionPart> AllWithLocation = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Reference, FinishComputingProperty_Reference, StartComputingProperty_TypeArguments, FinishComputingProperty_TypeArguments, StartComputingProperty_IsDeclaration, FinishComputingProperty_IsDeclaration, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties);
            public static readonly ImmutableHashSet<CompletionPart> All = CompletionPart.Combine(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Reference, FinishComputingProperty_Reference, StartComputingProperty_TypeArguments, FinishComputingProperty_TypeArguments, StartComputingProperty_IsDeclaration, FinishComputingProperty_IsDeclaration, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
            public static readonly CompletionGraph CompletionGraph = CompletionGraph.FromCompletionParts(CompletionGraph.StartInitializing, CompletionGraph.FinishInitializing, CompletionGraph.StartCreatingChildren, CompletionGraph.FinishCreatingChildren, StartComputingProperty_Attributes, FinishComputingProperty_Attributes, StartComputingProperty_Reference, FinishComputingProperty_Reference, StartComputingProperty_TypeArguments, FinishComputingProperty_TypeArguments, StartComputingProperty_IsDeclaration, FinishComputingProperty_IsDeclaration, CompletionGraph.StartComputingNonSymbolProperties, CompletionGraph.FinishComputingNonSymbolProperties, CompletionGraph.ChildrenCompleted);
        }

        private readonly Symbol _container;
        private readonly object? _modelObject;
        private readonly CompletionState _state;
        private ImmutableArray<Symbol> _childSymbols;
        private string _name;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> _attributes;
        private global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol _reference;
        private global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol> _typeArguments;
        private bool _isDeclaration;

        public CompletionReferenceExpressionSymbol(Symbol container, object? modelObject, bool isError = false)
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

        public override global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol Reference
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_Reference, null, default);
                return _reference;
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

        public override bool IsDeclaration
        {
            get
            {
                this.ForceComplete(CompletionParts.FinishComputingProperty_IsDeclaration, null, default);
                return _isDeclaration;
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
                else if (incompletePart == CompletionParts.StartComputingProperty_Reference || incompletePart == CompletionParts.FinishComputingProperty_Reference)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_Reference))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _reference = CompleteSymbolProperty_Reference(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_Reference);
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
                else if (incompletePart == CompletionParts.StartComputingProperty_IsDeclaration || incompletePart == CompletionParts.FinishComputingProperty_IsDeclaration)
                {
                    if (_state.NotePartComplete(CompletionParts.StartComputingProperty_IsDeclaration))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _isDeclaration = CompleteSymbolProperty_IsDeclaration(diagnostics, cancellationToken);
                        AddSymbolDiagnostics(diagnostics);
                        diagnostics.Free();
                        _state.NotePartComplete(CompletionParts.FinishComputingProperty_IsDeclaration);
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
        protected abstract global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol CompleteSymbolProperty_Reference(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol> CompleteSymbolProperty_TypeArguments(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract bool CompleteSymbolProperty_IsDeclaration(DiagnosticBag diagnostics, CancellationToken cancellationToken);
        protected abstract void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);
        #endregion
    }
}

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
	public partial class MetadataReferenceExpressionSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionReferenceExpressionSymbol
	{
        public MetadataReferenceExpressionSymbol(Symbol container, object? modelObject, bool isError = false)
            : base(container, modelObject, isError)
        {
        }

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;
        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return MetadataSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);
        }

        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return MetadataSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> CompleteSymbolProperty_Attributes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return MetadataSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.Symbol>(this, nameof(Attributes), diagnostics, cancellationToken);
        }

        protected override global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol CompleteSymbolProperty_Reference(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return MetadataSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Reference), diagnostics, cancellationToken);
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol> CompleteSymbolProperty_TypeArguments(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return MetadataSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol>(this, nameof(TypeArguments), diagnostics, cancellationToken);
        }

        protected override bool CompleteSymbolProperty_IsDeclaration(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return MetadataSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsDeclaration), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        public partial class Error : MetadataReferenceExpressionSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
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
        }
    }
}

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
	public partial class SourceReferenceExpressionSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionReferenceExpressionSymbol, MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol
	{
        private readonly MergedDeclaration _declaration;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

		public SourceReferenceExpressionSymbol(Symbol containingSymbol, MergedDeclaration declaration, object? modelObject, bool isError = false)
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

        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);
        }

        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> CompleteSymbolProperty_Attributes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.Symbol>(this, nameof(Attributes), diagnostics, cancellationToken);
        }
        protected override global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol CompleteSymbolProperty_Reference(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Reference), diagnostics, cancellationToken);
        }
        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol> CompleteSymbolProperty_TypeArguments(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol>(this, nameof(TypeArguments), diagnostics, cancellationToken);
        }
        protected override bool CompleteSymbolProperty_IsDeclaration(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsDeclaration), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);
        }

        public partial class Error : SourceReferenceExpressionSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
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
        }
	}
}

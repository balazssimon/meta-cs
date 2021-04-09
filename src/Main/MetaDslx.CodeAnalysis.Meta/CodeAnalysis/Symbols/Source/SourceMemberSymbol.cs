using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceMemberSymbol : ModelMemberSymbol, IModelSourceSymbol
    {
        private readonly MergedDeclaration _declaration;
        private readonly SourceSymbol _source;
        private readonly CompletionState _state;
        private SourceDeclaration _sourceDeclaration;
        private ImmutableArray<(CompletionPart start, CompletionPart finish)> _phaseBinders;
        private DiagnosticBag _diagnostics;
        private ImmutableArray<Symbol> _childSymbols;

        public SourceMemberSymbol(
            Symbol containingSymbol,
            object modelObject,
            MergedDeclaration declaration)
            : base(containingSymbol, modelObject)
        {
            Debug.Assert(containingSymbol is IModelSourceSymbol);
            Debug.Assert(modelObject != null);
            Debug.Assert(declaration != null);
            _declaration = declaration;
            _source = new SourceSymbol(this);
            _state = CompletionState.Create(containingSymbol.ContainingModule.Language);
        }

        public override MergedDeclaration MergedDeclaration => _declaration;

        public override ImmutableArray<Symbol> ChildSymbols
        {
            get
            {
                if (_childSymbols.IsDefault)
                {
                    this.ForceComplete(CompletionPart.FinishChildrenCreated, null, default);
                    Debug.Assert(!_declaration.Children.Any(decl => decl.Symbol == null));
                    var childSymbols = _declaration.Children.Where(decl => decl.Symbol != null).Select(decl => decl.Symbol).ToImmutableArray();
                    ImmutableInterlocked.InterlockedInitialize(ref _childSymbols, childSymbols);
                }
                return _childSymbols;
            }
        }

        public override AssemblySymbol ContainingAssembly => ContainingSymbol.ContainingAssembly;

        public ImmutableArray<Diagnostic> Diagnostics => _diagnostics != null ? _diagnostics.ToReadOnly() : ImmutableArray<Diagnostic>.Empty;

        public override bool IsStatic => false;

        public override ModuleSymbol ContainingModule => ContainingSymbol.ContainingModule;

        protected SourceDeclaration SourceDeclaration
        {
            get
            {
                if (_sourceDeclaration == null)
                {
                    Interlocked.CompareExchange(ref _sourceDeclaration, new SourceDeclaration(this, _declaration, _state), null);
                }
                return _sourceDeclaration;
            }
        }

        public override LexicalSortKey GetLexicalSortKey()
        {
            return this.SourceDeclaration.GetLexicalSortKey();
        }

        public override ImmutableArray<Location> Locations => _declaration.NameLocations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;

        public virtual ImmutableArray<DeclaredSymbol> GetDeclaredChildren()
        {
            return GetMembers();
        }

        internal override ImmutableArray<DeclaredSymbol> GetMembersUnordered()
        {
            return this.SourceDeclaration.GetMembersUnordered();
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return this.SourceDeclaration.GetMembers();
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return this.SourceDeclaration.GetMembers(name);
        }

        internal override ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            return this.SourceDeclaration.GetTypeMembersUnordered();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return this.SourceDeclaration.GetTypeMembers();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return this.SourceDeclaration.GetTypeMembers(name);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return this.SourceDeclaration.GetTypeMembers(name, metadataName);
        }

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            // TODO:MetaDslx
            _state.NotePartComplete(CompletionPart.Attributes);
            return ImmutableArray<AttributeData>.Empty;
        }

        public BinderPosition<SymbolDefBinder> GetBinder(SyntaxReference syntax)
        {
            return _source.GetBinder(syntax);
        }

        public Symbol GetChildSymbol(SyntaxReference syntax)
        {
            return _source.GetChildSymbol(syntax);
        }

        #region completion

        public sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            if (completionPart != null && _state.HasComplete(completionPart)) return;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.StartCreated || incompletePart == CompletionPart.FinishCreated)
                {
                    if (_state.NotePartComplete(CompletionPart.StartCreated))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        foreach (var singleDeclaration in _declaration.Declarations)
                        {
                            diagnostics.AddRange(singleDeclaration.Diagnostics);
                        }
                        AddDeclarationDiagnostics(diagnostics);
                        _source.AssignPropertyValues(SymbolConstants.NameProperty, diagnostics, cancellationToken);
                        _state.NotePartComplete(CompletionPart.FinishCreated);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionPart.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionPart.StartChildrenCreated || incompletePart == CompletionPart.FinishChildrenCreated)
                {
                    if (_state.NotePartComplete(CompletionPart.StartChildrenCreated))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _source.CreateContainedChildSymbols(diagnostics, cancellationToken);
                        _source.AssignPropertyValues(SymbolConstants.MembersProperty, diagnostics, cancellationToken);
                        AddDeclarationDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionPart.FinishChildrenCreated);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionPart.Members)
                {
                    this.SourceDeclaration.GetMembersByName();
                }
                else if (incompletePart == CompletionPart.StartProperties || incompletePart == CompletionPart.FinishProperties)
                {
                    if (_state.NotePartComplete(CompletionPart.StartProperties))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _source.AssignPropertyValues(null, diagnostics, cancellationToken);
                        _phaseBinders = _source.CollectPhases();
                        AddSymbolDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionPart.FinishProperties);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionPart.ChildrenCompleted)
                {
                    // ensure relevant imports are complete.
                    var diagnostics = DiagnosticBag.GetInstance();
                    _source.CompleteImports(locationOpt, diagnostics, cancellationToken);
                    AddSymbolDiagnostics(diagnostics);
                    diagnostics.Free();

                    var childSymbols = _declaration.Children.Select(decl => decl.Symbol).ToArray();
                    Debug.Assert(!childSymbols.Any(s => s == null));
                    bool allCompleted = true;

                    if (this.DeclaringCompilation.Options.ConcurrentBuild)
                    {
                        var po = cancellationToken.CanBeCanceled
                            ? new ParallelOptions() { CancellationToken = cancellationToken }
                            : LanguageCompilation.DefaultParallelOptions;

                        Parallel.For(0, childSymbols.Length, po, UICultureUtilities.WithCurrentUICulture<int>(i =>
                        {
                            var child = childSymbols[i];
                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);
                        }));

                        foreach (var child in childSymbols)
                        {
                            if (!child.HasComplete(CompletionPart.All))
                            {
                                allCompleted = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var child in childSymbols)
                        {
                            ForceCompleteChildByLocation(locationOpt, child, cancellationToken);
                            allCompleted = allCompleted && child.HasComplete(CompletionPart.All);
                        }
                    }

                    if (allCompleted)
                    {
                        _state.NotePartComplete(CompletionPart.ChildrenCompleted);
                    }
                    else
                    {
                        // NOTE: we're going to kick out of the completion part loop after this,
                        // so not making progress isn't a problem.
                        goto done;
                    }
                }
                else if (incompletePart == null)
                {
                    return;
                }
                else
                {
                    if (!_phaseBinders.IsDefaultOrEmpty)
                    {
                        foreach (var phaseBinder in _phaseBinders)
                        {
                            if (incompletePart == phaseBinder.start || incompletePart == phaseBinder.finish)
                            {
                                if (_state.NotePartComplete(phaseBinder.start))
                                {
                                    var diagnostics = DiagnosticBag.GetInstance();
                                    _source.ExecutePhases(phaseBinder.start, phaseBinder.finish, diagnostics, cancellationToken);
                                    AddSymbolDiagnostics(diagnostics);
                                    _state.NotePartComplete(phaseBinder.finish);
                                    diagnostics.Free();
                                }
                            }
                        }
                    }
                    // This assert will trigger if we forgot to handle any of the completion parts
                    Debug.Assert(!CompletionPart.MemberSymbolAll.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
                if (completionPart != null && _state.HasComplete(completionPart)) return;
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }

        done:
            // Don't return until we've seen all of the CompletionParts. This ensures all
            // diagnostics have been reported (not necessarily on this thread).
            var allParts = (locationOpt == null) ? CompletionPart.MemberSymbolAll : CompletionPart.MemberSymbolWithLocationAll;
            _state.SpinWaitComplete(allParts, cancellationToken);
        }

        public override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        #endregion

        private void AddSymbolDiagnostics(DiagnosticBag diagnostics)
        {
            if (!diagnostics.IsEmptyWithoutResolution)
            {
                LanguageCompilation compilation = this.DeclaringCompilation;
                Debug.Assert(compilation != null);
                if (_diagnostics == null) _diagnostics = new DiagnosticBag();
                _diagnostics.AddRange(diagnostics);
            }
        }
    }
}

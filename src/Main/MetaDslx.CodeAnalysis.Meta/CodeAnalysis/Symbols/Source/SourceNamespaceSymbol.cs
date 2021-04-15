// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceNamespaceSymbol : ModelNamespaceSymbol, IModelSourceSymbol
    {
        private readonly SourceModuleSymbol _module;
        private readonly SourceSymbol _source;
        private readonly MergedDeclaration _declaration;
        private readonly CompletionState _state;
        private SourceDeclaration _sourceDeclaration;
        private ImmutableArray<(CompletionPart start, CompletionPart finish)> _phaseBinders;
        private ImmutableArray<Symbol> _childSymbols;
        private DiagnosticBag _diagnostics;

        public SourceNamespaceSymbol(
            SourceModuleSymbol module, 
            Symbol containingSymbol,
            object modelObject,
            MergedDeclaration declaration)
            : base(containingSymbol, modelObject)
        {
            Debug.Assert(declaration != null);
            Debug.Assert(containingSymbol == module || modelObject != null);
            _module = module;
            _declaration = declaration;
            _source = new SourceSymbol(this);
            _state = CompletionState.Create(module.Language);
        }

        public override MergedDeclaration MergedDeclaration => _declaration;

        public SourceSymbol Source => _source;

        public override ImmutableArray<Symbol> ChildSymbols
        {
            get
            {
                if (_childSymbols.IsDefault)
                {
                    this.ForceComplete(CompletionGraph.FinishChildrenCreated, null, default);
                    var childSymbols = _declaration.Children.Where(decl => decl.Symbol != null).Select(decl => decl.Symbol).ToImmutableArray();
                    ImmutableInterlocked.InterlockedInitialize(ref _childSymbols, childSymbols);
                }
                return _childSymbols;
            }
        }

        public override AssemblySymbol ContainingAssembly => _module.ContainingAssembly;

        internal IEnumerable<Imports> GetBoundImportsMerged()
        {
            var compilation = this.DeclaringCompilation;
            foreach (var declaration in _declaration.Declarations)
            {
                if (declaration.HasImports)
                {
                    yield return compilation.GetImports(declaration);
                }
            }
        }

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
            _state.NotePartComplete(CompletionGraph.Attributes);
            return ImmutableArray<AttributeData>.Empty;
        }

        public override ModuleSymbol ContainingModule => _module;

        public override NamespaceExtent Extent => new NamespaceExtent(_module);

        public override void CheckMembers(Dictionary<string, ImmutableArray<DeclaredSymbol>> result, DiagnosticBag diagnostics)
        {
            var memberOfMetadataName = new Dictionary<string, DeclaredSymbol>();
            MergedNamespaceSymbol mergedAssemblyNamespace = null;

            if (this.ContainingAssembly.Modules.Length > 1)
            {
                mergedAssemblyNamespace = this.ContainingAssembly.GetAssemblyNamespace(this) as MergedNamespaceSymbol;
            }

            foreach (var name in result.Keys)
            {
                memberOfMetadataName.Clear();
                foreach (var symbol in result[name])
                {
                    var nts = symbol as NamedTypeSymbol;
                    var metadataName = ((object)nts != null) ? nts.MetadataName : string.Empty;
                    if (metadataName == null) metadataName = string.Empty;

                    if (memberOfMetadataName.TryGetValue(metadataName, out DeclaredSymbol other))
                    {
                        if ((nts as SourceNamedTypeSymbol)?.IsPartial == true && (other as SourceNamedTypeSymbol)?.IsPartial == true)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_PartialTypeKindConflict, symbol.Locations.FirstOrNone(), symbol);
                        }
                        else
                        {
                            diagnostics.Add(InternalErrorCode.ERR_DuplicateNameInNS, symbol.Locations.FirstOrNone(), name, this);
                        }
                        memberOfMetadataName[metadataName] = symbol;
                    }
                    else if ((object)mergedAssemblyNamespace != null)
                    {
                        // Check for collision with declarations from added modules.
                        foreach (NamespaceSymbol constituent in mergedAssemblyNamespace.ConstituentNamespaces)
                        {
                            if ((object)constituent != (object)this)
                            {
                                // For whatever reason native compiler only detects conflicts against types.
                                // It doesn't complain when source declares a type with the same name as 
                                // a namespace in added module, but complains when source declares a namespace 
                                // with the same name as a type in added module.
                                var types = constituent.GetTypeMembers(symbol.Name, metadataName);

                                if (types.Length > 0)
                                {
                                    other = types[0];
                                    // Since the error doesn't specify what added module this type belongs to, we can stop searching
                                    // at the first match.
                                    break;
                                }
                            }
                        }
                        memberOfMetadataName.Add(metadataName, symbol);
                    }
                    else
                    {
                        memberOfMetadataName.Add(metadataName, symbol);
                    }
                }
            }
        }

        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference syntax)
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
                if (incompletePart == CompletionGraph.StartCreated || incompletePart == CompletionGraph.FinishCreated)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartCreated))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        foreach (var singleDeclaration in _declaration.Declarations)
                        {
                            diagnostics.AddRange(singleDeclaration.Diagnostics);
                        }
                        if (ModelObject != null)
                        {
                            _source.AssignPropertyValues(SymbolConstants.NameProperty, diagnostics, cancellationToken);
                        }
                        AddDeclarationDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionGraph.FinishCreated);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionGraph.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionGraph.StartChildrenCreated || incompletePart == CompletionGraph.FinishChildrenCreated)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartChildrenCreated))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        if (ModelObject != null)
                        {
                            _source.CreateContainedChildSymbols(diagnostics, cancellationToken);
                        }
                        else
                        {
                            _source.CreateRootSymbols(diagnostics, cancellationToken);
                        }
                        AddDeclarationDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionGraph.FinishChildrenCreated);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionGraph.Members)
                {
                    this.SourceDeclaration.GetMembersByName();
                }
                else if (incompletePart == CompletionGraph.StartProperties || incompletePart == CompletionGraph.FinishProperties)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartProperties))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        if (ModelObject != null)
                        {
                            _source.AssignPropertyValues(null, diagnostics, cancellationToken);
                            _phaseBinders = _source.CollectPhases();
                        }
                        AddSymbolDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionGraph.FinishProperties);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionGraph.ChildrenCompleted)
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
                            if (!child.HasComplete(CompletionGraph.All))
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
                            allCompleted = allCompleted && child.HasComplete(CompletionGraph.All);
                        }
                    }

                    if (allCompleted)
                    {
                        _state.NotePartComplete(CompletionGraph.ChildrenCompleted);
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
                    Debug.Assert(!CompletionGraph.NamespaceSymbolAll.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
                if (completionPart != null && _state.HasComplete(completionPart)) return;
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }

        done:
            // Don't return until we've seen all of the CompletionParts. This ensures all
            // diagnostics have been reported (not necessarily on this thread).
            var allParts = (locationOpt == null) ? CompletionGraph.NamespaceSymbolAll : CompletionGraph.NamespaceSymbolWithLocationAll;
            _state.SpinWaitComplete(allParts, cancellationToken);
        }

        public override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        #endregion

    }
}

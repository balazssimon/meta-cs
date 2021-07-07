// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    /// <summary>
    /// Represents a named type symbol whose members are declared in source.
    /// </summary>
    public class SourceNamedTypeSymbol : ModelNamedTypeSymbol, IModelSourceSymbol
    {
        private readonly MergedDeclaration _declaration;
        private readonly SourceSymbol _source;
        private readonly CompletionState _state;
        private SourceDeclaration _sourceDeclaration;
        private ImmutableArray<NamedTypeSymbol> _lazyDeclaredBases;
        private ImmutableArray<NamedTypeSymbol> _lazyBaseTypes;
        private ImmutableArray<(CompletionPart start, CompletionPart finish)> _phaseBinders;
        private ImmutableArray<Symbol> _childSymbols;
        private DiagnosticBag _diagnostics;

        public SourceNamedTypeSymbol(
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
            _state = CompletionState.Create(containingSymbol.Language);
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
                }
                return _childSymbols;
            }
        }

        public ImmutableArray<Diagnostic> Diagnostics => _diagnostics != null ? _diagnostics.ToReadOnly() : ImmutableArray<Diagnostic>.Empty;

        public virtual bool IsPartial => _declaration.Merge;

        #region Syntax

        public override bool IsScript => _declaration.IsScript;

        public override bool IsSubmission => _declaration.IsSubmission;

        public override bool IsImplicit => _declaration.IsImplicit;

        public override bool IsImplicitlyDeclared
        {
            get
            {
                return IsImplicit || IsScript || IsSubmission;
            }
        }

        public override string MetadataName => _declaration.MetadataName;

        public override bool MangleName => _declaration.Name != _declaration.MetadataName;

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

        public ImmutableArray<SyntaxReference> SyntaxReferences => _declaration.SyntaxReferences;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => SyntaxReferences;

        #endregion

        #region members

        public override IEnumerable<string> MemberNames => this.SourceDeclaration.MemberNames;

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return this.SourceDeclaration.GetMembers();
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return this.SourceDeclaration.GetMembers(name);
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return this.SourceDeclaration.GetMembers(name, metadataName);
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

        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference syntax)
        {
            return _source.GetBinder(syntax);
        }

        public Symbol GetChildSymbol(SyntaxReference syntax)
        {
            return _source.GetChildSymbol(syntax);
        }

        #endregion

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            // TODO:MetaDslx
            _state.NotePartComplete(CompletionGraph.Attributes);
            return ImmutableArray<AttributeData>.Empty;
        }

        #region Completion

        public sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        public sealed override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            if (completionPart != null && _state.HasComplete(completionPart)) return;
            while (true)
            {
                // NOTE: cases that depend on GetMembers[ByName] should call RequireCompletionPartMembers.
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionGraph.StartCreated || incompletePart == CompletionGraph.FinishCreated)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartCreated))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        if (_declaration != null)
                        {
                            foreach (var singleDeclaration in _declaration.Declarations)
                            {
                                diagnostics.AddRange(singleDeclaration.Diagnostics);
                            }
                        }
                        _source.AssignPropertyValues(SymbolConstants.NameProperty, diagnostics, cancellationToken);
                        AddDeclarationDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionGraph.FinishCreated);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionGraph.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionGraph.StartBaseTypes || incompletePart == CompletionGraph.FinishBaseTypes)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartBaseTypes))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _source.AssignPropertyValues(SymbolConstants.DeclaredBaseTypesProperty, diagnostics, cancellationToken);
                        CheckBaseTypes(diagnostics);
                        AddDeclarationDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionGraph.FinishBaseTypes);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionGraph.StartChildrenCreated || incompletePart == CompletionGraph.FinishChildrenCreated)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartChildrenCreated))
                    {
                        var childSymbols = ArrayBuilder<Symbol>.GetInstance();
                        var diagnostics = DiagnosticBag.GetInstance();
                        _source.CreateContainedChildSymbols(childSymbols, diagnostics, cancellationToken);
                        AddDeclarationDiagnostics(diagnostics);
                        diagnostics.Free();
                        ImmutableInterlocked.InterlockedInitialize(ref _childSymbols, childSymbols.ToImmutableAndFree());
                        _state.NotePartComplete(CompletionGraph.FinishChildrenCreated);
                    }
                }
                else if (incompletePart == CompletionGraph.Members)
                {
                    this.SourceDeclaration.GetMembersByName();
                }
                else if (incompletePart == CompletionGraph.TypeMembers)
                {
                    this.SourceDeclaration.GetTypeMembersUnordered();
                }
                else if (incompletePart == CompletionGraph.StartProperties || incompletePart == CompletionGraph.FinishProperties)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartProperties))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        _source.AssignPropertyValues(null, diagnostics, cancellationToken);
                        _phaseBinders = _source.CollectPhases();
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

                    if (locationOpt == null)
                    {
                        foreach (var child in childSymbols)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            child.ForceComplete(null, locationOpt, cancellationToken);
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

                    if (!allCompleted)
                    {
                        // We did not complete all members so we won't have enough information for
                        // the PointedAtManagedTypeChecks, so just kick out now.
                        var allParts = CompletionGraph.NamedTypeSymbolWithLocationAll;
                        _state.SpinWaitComplete(allParts, cancellationToken);
                        return;
                    }

                    // We've completed all members, so we're ready for the PointedAtManagedTypeChecks;
                    // proceed to the next iteration.
                    _state.NotePartComplete(CompletionGraph.ChildrenCompleted);
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
                    Debug.Assert(!CompletionGraph.NamedTypeSymbolAll.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
                if (completionPart != null && _state.HasComplete(completionPart)) return;
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }

            throw ExceptionUtilities.Unreachable;
        }

        #endregion

        public virtual void EnsureSymbolDefinitionsNoted()
        {
            // TODO:MetaDslx
        }

        public override void CheckMembers(Dictionary<string, ImmutableArray<DeclaredSymbol>> result, DiagnosticBag diagnostics)
        {
            // TODO:MetaDslx
        }

        /// <summary>
        /// Gets the set of interfaces that this type directly implements. This set does not include
        /// interfaces that are base interfaces of directly implemented interfaces.
        /// </summary>
        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (_lazyBaseTypes.IsDefault)
            {
                if (basesBeingResolved != null && basesBeingResolved.ContainsReference(this.OriginalDefinition))
                {
                    return ImmutableArray<NamedTypeSymbol>.Empty;
                }

                var diagnostics = DiagnosticBag.GetInstance();
                var acyclicBaseTypes = MakeAcyclicBaseTypes(basesBeingResolved, diagnostics);
                if (ImmutableInterlocked.InterlockedInitialize(ref _lazyBaseTypes, acyclicBaseTypes))
                {
                    AddDeclarationDiagnostics(diagnostics);
                }
                diagnostics.Free();
            }

            return _lazyBaseTypes;
        }

        private ImmutableArray<NamedTypeSymbol> MakeAcyclicBaseTypes(ConsList<TypeSymbol> basesBeingResolved, DiagnosticBag diagnostics)
        {
            var declaredBaseTypes = GetDeclaredBaseTypes(basesBeingResolved: basesBeingResolved);
            ArrayBuilder<NamedTypeSymbol> result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            foreach (var t in declaredBaseTypes)
            {
                if (BaseTypeAnalysis.TypeDependsOn(depends: t, on: this))
                {
                    result.Add(new ExtendedErrorTypeSymbol(t, LookupResultKind.NotReferencable,
                        diagnostics.Add(InternalErrorCode.ERR_CycleInInterfaceInheritance, Locations[0], this, t)));
                    continue;
                }
                else
                {
                    result.Add(t);
                }

                HashSet<DiagnosticInfo> useSiteDiagnostics = null;

                if (t.DeclaringCompilation != this.DeclaringCompilation)
                {
                    t.AddUseSiteDiagnostics(ref useSiteDiagnostics);

                    foreach (var @interface in t.AllBaseTypesNoUseSiteDiagnostics)
                    {
                        if (@interface.DeclaringCompilation != this.DeclaringCompilation)
                        {
                            @interface.AddUseSiteDiagnostics(ref useSiteDiagnostics);
                        }
                    }
                }

                if (!useSiteDiagnostics.IsNullOrEmpty())
                {
                    diagnostics.Add(Locations[0], useSiteDiagnostics);
                }
            }

            return result.ToImmutableAndFree();
        }

        protected ImmutableArray<NamedTypeSymbol> GetDeclaredBases(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (_lazyDeclaredBases.IsDefault)
            {
                var diagnostics = DiagnosticBag.GetInstance();
                if (ImmutableInterlocked.InterlockedInitialize(ref _lazyDeclaredBases, MakeDeclaredBases(basesBeingResolved, diagnostics)))
                {
                    AddDeclarationDiagnostics(diagnostics);
                }
                diagnostics.Free();
            }

            return _lazyDeclaredBases;
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            return GetDeclaredBases(basesBeingResolved);
        }

        private ImmutableArray<NamedTypeSymbol> MakeDeclaredBases(ConsList<TypeSymbol> basesBeingResolved, DiagnosticBag diagnostics)
        {
            Debug.Assert(basesBeingResolved == null || !basesBeingResolved.ContainsReference(this.OriginalDefinition));
            var newBasesBeingResolved = basesBeingResolved.Prepend(this.OriginalDefinition);
            var baseTypes = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            var baseTypeLocations = PooledDictionary<NamedTypeSymbol, Location>.GetInstance();

            foreach (var decl in this.MergedDeclaration.Declarations)
            {
                ImmutableArray<NamedTypeSymbol> partBaseTypes = ResolveBaseTypes(newBasesBeingResolved, decl, diagnostics);
                if (partBaseTypes.IsEmpty) continue;

                foreach (var t in partBaseTypes)
                {
                    if (!baseTypeLocations.ContainsKey(t))
                    {
                        baseTypes.Add(t);
                        baseTypeLocations.Add(t, decl.NameLocation);
                    }
                }
            }

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            var baseTypesRO = baseTypes.ToImmutableAndFree();
            this.CheckDeclaredBaseTypes(baseTypesRO, baseTypeLocations, diagnostics, ref useSiteDiagnostics);
            baseTypeLocations.Free();
            diagnostics.Add(Locations[0], useSiteDiagnostics);

            return baseTypesRO;
        }

        protected virtual void CheckDeclaredBaseTypes(ImmutableArray<NamedTypeSymbol> baseTypes, PooledDictionary<NamedTypeSymbol, Location> baseTypeLocations, DiagnosticBag diagnostics, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {

        }

        // process the base list for one part of a partial class, or for the only part of any other type declaration.
        protected virtual ImmutableArray<NamedTypeSymbol> ResolveBaseTypes(ConsList<TypeSymbol> newBasesBeingResolved, SingleDeclaration decl, DiagnosticBag diagnostics)
        {
            var result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            var symbolFacts = Language.SymbolFacts;
            foreach (var prop in symbolFacts.GetPropertiesForSymbol(this.ModelObject, SymbolConstants.DeclaredBaseTypesProperty))
            {
                var baseTypeObjects = symbolFacts.GetPropertyValues(this.ModelObject, prop);
                if (baseTypeObjects != null)
                {
                    var baseTypeSymbols = SymbolFactory.ResolveSymbols(baseTypeObjects.Where(bto => bto != null));
                    foreach (var value in baseTypeSymbols)
                    {
                        var symbol = value as NamedTypeSymbol;
                        if (symbol != null)
                        {
                            result.Add(symbol);
                        }
                        else
                        {
                            diagnostics.Add(ModelErrorCode.ERR_InvalidBaseType, Location.None, value); // TODO: MetaDslx location
                        }
                    }
                }
            }
            return result.ToImmutableAndFree();
        }

        protected virtual void CheckBaseTypes(DiagnosticBag diagnostics)
        {
            // TODO: MetaDslx
        }

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

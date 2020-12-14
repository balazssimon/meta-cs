// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
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
    public abstract class SourceMemberContainerTypeSymbol : NamedTypeSymbol
    {
        private readonly DeclaredSymbol _containingSymbol;
        private readonly MergedDeclaration _declaration;
        private readonly CompletionState _state;
        private readonly MutableObjectBase _modelObject;
        private SourceDeclaration _sourceDeclaration;

        public SourceMemberContainerTypeSymbol(
            DeclaredSymbol containingSymbol,
            MergedDeclaration declaration,
            DiagnosticBag diagnostics)
        {
            _containingSymbol = containingSymbol;
            _declaration = declaration;

            if (declaration.Kind != null)
            {
                _modelObject = declaration.GetModelObject(containingSymbol?.ModelObject as MutableObjectBase, containingSymbol.ModelBuilder, diagnostics);
                Debug.Assert(_modelObject != null);
            }

            foreach (var singleDeclaration in declaration.Declarations)
            {
                diagnostics.AddRange(singleDeclaration.Diagnostics);
            }
            _state = CompletionState.Create(containingSymbol.Language);
        }

        public override Language Language => _containingSymbol.Language;

        public override LanguageTypeKind TypeKind => LanguageTypeKind.NamedType;

        internal protected override MutableModel ModelBuilder => this.ContainingModule.ModelBuilder;

        public override IModelObject ModelObject => _modelObject;

        public override ModelObjectDescriptor ModelSymbolInfo => _declaration.Kind;

        public override MergedDeclaration MergedDeclaration => _declaration;

        public virtual bool IsPartial => _declaration.Merge;

        #region Containers

        public sealed override NamedTypeSymbol ContainingType => _containingSymbol as NamedTypeSymbol;

        public sealed override Symbol ContainingSymbol => _containingSymbol;

        #endregion

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

        public override string Name => _declaration.Name;

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

        // This method behaves the same was as the base class, but avoids allocations associated with DeclaringSyntaxReferences
        public override bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken)
        {
            return this.SourceDeclaration.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken);
        }

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

        #endregion

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            // TODO:MetaDslx
            _state.NotePartComplete(CompletionPart.Attributes);
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

        protected virtual void CheckBaseTypes(DiagnosticBag diagnostics)
        {

        }

        public override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            while (true)
            {
                // NOTE: cases that depend on GetMembers[ByName] should call RequireCompletionPartMembers.
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionPart.StartBaseTypes || incompletePart == CompletionPart.FinishBaseTypes)
                {
                    if (_state.NotePartComplete(CompletionPart.StartBaseTypes))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        CheckBaseTypes(diagnostics);
                        AddDeclarationDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionPart.FinishBaseTypes);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionPart.Members)
                {
                    this.SourceDeclaration.GetMembersByName();
                }
                else if (incompletePart == CompletionPart.TypeMembers)
                {
                    this.SourceDeclaration.GetTypeMembersUnordered();
                }
                else if (incompletePart == CompletionPart.MembersCompleted)
                {
                    ImmutableArray<DeclaredSymbol> members = this.GetMembersUnordered();

                    bool allCompleted = true;

                    if (locationOpt == null)
                    {
                        foreach (var member in members)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            member.ForceComplete(locationOpt, cancellationToken);
                        }
                    }
                    else
                    {
                        foreach (var member in members)
                        {
                            ForceCompleteMemberByLocation(locationOpt, member, cancellationToken);
                            allCompleted = allCompleted && member.HasComplete(CompletionPart.All);
                        }
                    }

                    if (!allCompleted)
                    {
                        // We did not complete all members so we won't have enough information for
                        // the PointedAtManagedTypeChecks, so just kick out now.
                        var allParts = CompletionPart.NamedTypeSymbolWithLocationAll;
                        _state.SpinWaitComplete(allParts, cancellationToken);
                        return;
                    }

                    // We've completed all members, so we're ready for the PointedAtManagedTypeChecks;
                    // proceed to the next iteration.
                    _state.NotePartComplete(CompletionPart.MembersCompleted);
                }
                else if (incompletePart == null)
                {
                    return;
                }
                else
                {
                    // This assert will trigger if we forgot to handle any of the completion parts
                    Debug.Assert(!CompletionPart.NamedTypeSymbolAll.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
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
    }
}

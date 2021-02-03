// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceNamespaceSymbol : ModelNamespaceSymbol
    {
        private readonly SourceModuleSymbol _module;
        private readonly MergedDeclaration _declaration;
        private readonly CompletionState _state;
        private SourceDeclaration _sourceDeclaration;

        public SourceNamespaceSymbol(
            SourceModuleSymbol module, 
            Symbol containingSymbol,
            object modelObject,
            MergedDeclaration declaration)
            : base(containingSymbol, modelObject)
        {
            Debug.Assert(containingSymbol is IModelSourceSymbol);
            Debug.Assert(declaration != null);
            _module = module;
            _declaration = declaration;
            _state = CompletionState.Create(module.Language);
        }

        public override Language Language => _module.Language;

        public override MergedDeclaration MergedDeclaration => _declaration;

        public override AssemblySymbol ContainingAssembly => _module.ContainingAssembly;

        internal IEnumerable<Imports> GetBoundImportsMerged()
        {
            var compilation = this.DeclaringCompilation;
            foreach (var declaration in _declaration.Declarations)
            {
                if (declaration.HasUsings || declaration.HasExternAliases)
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

        public override bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.SourceDeclaration.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken);
        }

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            // TODO:MetaDslx
            _state.NotePartComplete(CompletionPart.Attributes);
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

        #region completion

        public sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        public override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            // TODO: add declaration diagnostics
            /*
            foreach (var singleDeclaration in declaration.Declarations)
            {
                diagnostics.AddRange(singleDeclaration.Diagnostics);
            }
             */
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionPart.Members)
                {
                    this.SourceDeclaration.GetMembersByName();
                }
                else if (incompletePart == CompletionPart.MembersCompleted)
                {
                    // ensure relevant imports are complete.
                    foreach (var declaration in _declaration.Declarations)
                    {
                        if (locationOpt == null || locationOpt.SourceTree == declaration.SyntaxReference.SyntaxTree)
                        {
                            if (declaration.HasUsings || declaration.HasExternAliases)
                            {
                                this.DeclaringCompilation.GetImports(declaration).Complete(cancellationToken);
                            }
                        }
                    }

                    var members = this.GetMembers();

                    bool allCompleted = true;

                    if (this.DeclaringCompilation.Options.ConcurrentBuild)
                    {
                        var po = cancellationToken.CanBeCanceled
                            ? new ParallelOptions() { CancellationToken = cancellationToken }
                            : LanguageCompilation.DefaultParallelOptions;

                        Parallel.For(0, members.Length, po, UICultureUtilities.WithCurrentUICulture<int>(i =>
                        {
                            var member = members[i];
                            ForceCompleteMemberByLocation(locationOpt, member, cancellationToken);
                        }));

                        foreach (var member in members)
                        {
                            if (!member.HasComplete(CompletionPart.All))
                            {
                                allCompleted = false;
                                break;
                            }
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

                    if (allCompleted)
                    {
                        _state.NotePartComplete(CompletionPart.MembersCompleted);
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
                    // This assert will trigger if we forgot to handle any of the completion parts
                    Debug.Assert(!CompletionPart.NamespaceSymbolAll.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }

        done:
            // Don't return until we've seen all of the CompletionParts. This ensures all
            // diagnostics have been reported (not necessarily on this thread).
            var allParts = (locationOpt == null) ? CompletionPart.NamespaceSymbolAll : CompletionPart.NamespaceSymbolWithLocationAll;
            _state.SpinWaitComplete(allParts, cancellationToken);
        }

        public override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        #endregion
    }
}

// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Syntax;

namespace MetaDslx.CodeAnalysis.Declarations
{
    internal sealed partial class SyntaxAndDeclarationManager : CommonSyntaxAndDeclarationManager
    {
        private State _lazyState;

        internal SyntaxAndDeclarationManager(
            ImmutableArray<LanguageSyntaxTree> externalSyntaxTrees,
            string scriptClassName,
            SourceReferenceResolver resolver,
            LanguageCompilation compilation,
            bool isSubmission,
            State state)
            : base(externalSyntaxTrees, scriptClassName, resolver, compilation, isSubmission)
        {
            _lazyState = state;
        }

        internal State GetLazyState()
        {
            if (_lazyState == null)
            {
                Interlocked.CompareExchange(ref _lazyState, CreateState(this.ExternalSyntaxTrees, this.ScriptClassName, this.Resolver, this.Compilation, this.IsSubmission), null);
            }

            return _lazyState;
        }

        private static State CreateState(
            ImmutableArray<LanguageSyntaxTree> externalSyntaxTrees,
            string scriptClassName,
            SourceReferenceResolver resolver,
            LanguageCompilation compilation,
            bool isSubmission)
        {
            var treesBuilder = ArrayBuilder<LanguageSyntaxTree>.GetInstance();
            var ordinalMapBuilder = PooledDictionary<LanguageSyntaxTree, int>.GetInstance();
            var loadDirectiveMapBuilder = PooledDictionary<LanguageSyntaxTree, ImmutableArray<DeclarationLoadDirective>>.GetInstance();
            var loadedSyntaxTreeMapBuilder = PooledDictionary<string, LanguageSyntaxTree>.GetInstance();
            var declMapBuilder = PooledDictionary<LanguageSyntaxTree, Lazy<RootSingleDeclaration>>.GetInstance();
            var declTable = DeclarationTable.Empty;

            foreach (var tree in externalSyntaxTrees)
            {
                AppendAllSyntaxTrees(
                    treesBuilder,
                    tree,
                    scriptClassName,
                    resolver,
                    compilation,
                    isSubmission,
                    ordinalMapBuilder,
                    loadDirectiveMapBuilder,
                    loadedSyntaxTreeMapBuilder,
                    declMapBuilder,
                    ref declTable);
            }

            return new State(
                treesBuilder.ToImmutableAndFree(),
                ordinalMapBuilder.ToImmutableDictionaryAndFree(),
                loadDirectiveMapBuilder.ToImmutableDictionaryAndFree(),
                loadedSyntaxTreeMapBuilder.ToImmutableDictionaryAndFree(),
                declMapBuilder.ToImmutableDictionaryAndFree(),
                declTable);
        }

        public SyntaxAndDeclarationManager AddSyntaxTrees(IEnumerable<LanguageSyntaxTree> trees)
        {
            var scriptClassName = this.ScriptClassName;
            var resolver = this.Resolver;
            var compilation = this.Compilation;
            var isSubmission = this.IsSubmission;

            var state = _lazyState;
            var newExternalSyntaxTrees = this.ExternalSyntaxTrees.AddRange(trees);
            if (state == null)
            {
                return this.WithExternalSyntaxTrees(newExternalSyntaxTrees);
            }

            var ordinalMapBuilder = state.OrdinalMap.ToBuilder();
            var loadDirectiveMapBuilder = state.LoadDirectiveMap.ToBuilder();
            var loadedSyntaxTreeMapBuilder = state.LoadedSyntaxTreeMap.ToBuilder();
            var declMapBuilder = state.RootNamespaces.ToBuilder();
            var declTable = state.DeclarationTable;

            var treesBuilder = ArrayBuilder<LanguageSyntaxTree>.GetInstance();
            treesBuilder.AddRange(state.SyntaxTrees);

            foreach (var tree in trees)
            {
                AppendAllSyntaxTrees(
                        treesBuilder,
                        tree,
                        scriptClassName,
                        resolver,
                        compilation,
                        isSubmission,
                        ordinalMapBuilder,
                        loadDirectiveMapBuilder,
                        loadedSyntaxTreeMapBuilder,
                        declMapBuilder,
                        ref declTable);
            }

            state = new State(
                treesBuilder.ToImmutableAndFree(),
                ordinalMapBuilder.ToImmutableDictionary(),
                loadDirectiveMapBuilder.ToImmutableDictionary(),
                loadedSyntaxTreeMapBuilder.ToImmutableDictionary(),
                declMapBuilder.ToImmutableDictionary(),
                declTable);

            return new SyntaxAndDeclarationManager(
                newExternalSyntaxTrees,
                scriptClassName,
                resolver,
                compilation,
                isSubmission,
                state);
        }

        /// <summary>
        /// Appends all trees (including any trees from #load'ed files).
        /// </summary>
        private static void AppendAllSyntaxTrees(
            ArrayBuilder<LanguageSyntaxTree> treesBuilder,
            LanguageSyntaxTree tree,
            string scriptClassName,
            SourceReferenceResolver resolver,
            LanguageCompilation compilation,
            bool isSubmission,
            IDictionary<LanguageSyntaxTree, int> ordinalMapBuilder,
            IDictionary<LanguageSyntaxTree, ImmutableArray<DeclarationLoadDirective>> loadDirectiveMapBuilder,
            IDictionary<string, LanguageSyntaxTree> loadedSyntaxTreeMapBuilder,
            IDictionary<LanguageSyntaxTree, Lazy<RootSingleDeclaration>> declMapBuilder,
            ref DeclarationTable declTable)
        {
            var sourceCodeKind = tree.Options.Kind;
            if (sourceCodeKind == SourceCodeKind.Script)
            {
                AppendAllLoadedSyntaxTrees(treesBuilder, tree, scriptClassName, resolver, compilation, isSubmission, ordinalMapBuilder, loadDirectiveMapBuilder, loadedSyntaxTreeMapBuilder, declMapBuilder, ref declTable);
            }

            AddSyntaxTreeToDeclarationMapAndTable(tree, scriptClassName, isSubmission, declMapBuilder, ref declTable);

            treesBuilder.Add(tree);

            ordinalMapBuilder.Add(tree, ordinalMapBuilder.Count);
        }

        private static void AppendAllLoadedSyntaxTrees(
            ArrayBuilder<LanguageSyntaxTree> treesBuilder,
            LanguageSyntaxTree tree,
            string scriptClassName,
            SourceReferenceResolver resolver,
            LanguageCompilation compilation,
            bool isSubmission,
            IDictionary<LanguageSyntaxTree, int> ordinalMapBuilder,
            IDictionary<LanguageSyntaxTree, ImmutableArray<DeclarationLoadDirective>> loadDirectiveMapBuilder,
            IDictionary<string, LanguageSyntaxTree> loadedSyntaxTreeMapBuilder,
            IDictionary<LanguageSyntaxTree, Lazy<RootSingleDeclaration>> declMapBuilder,
            ref DeclarationTable declTable)
        {
            ArrayBuilder<DeclarationLoadDirective> loadDirectives = null;

            foreach (var d in tree.GetRootSyntax().GetLoadDirectives())
            {
                var directive = (LoadDirective)d.Directive;
                var node = (LanguageSyntaxNode)d;
                var path = directive.File;
                if (path == null)
                {
                    // If there is no path, the parser should have some Diagnostics to report (if we're in an active region).
                    Debug.Assert(!directive.IsActive || tree.GetDiagnostics().Any(d => d.Severity == DiagnosticSeverity.Error));
                    continue;
                }

                var diagnostics = DiagnosticBag.GetInstance();
                string resolvedFilePath = null;
                if (resolver == null)
                {
                    diagnostics.Add(InternalErrorCode.ERR_SourceFileReferencesNotSupported.ToDiagnosticInfo().ToDiagnostic(node.Location));
                }
                else
                {
                    resolvedFilePath = resolver.ResolveReference(path, baseFilePath: tree.FilePath);
                    if (resolvedFilePath == null)
                    {
                        diagnostics.Add(InternalErrorCode.ERR_NoSourceFile.ToDiagnosticInfo(path).ToDiagnostic(node.Location));
                    }
                    else if (!loadedSyntaxTreeMapBuilder.ContainsKey(resolvedFilePath))
                    {
                        try
                        {
                            var code = resolver.ReadText(resolvedFilePath);
                            var loadedTree = compilation.Language.SyntaxFactory.ParseSyntaxTree(
                                code,
                                tree.Options, // Use ParseOptions propagated from "external" tree.
                                resolvedFilePath);

                            // All #load'ed trees should have unique path information.
                            loadedSyntaxTreeMapBuilder.Add(loadedTree.FilePath, loadedTree);

                            AppendAllSyntaxTrees(
                                treesBuilder,
                                loadedTree,
                                scriptClassName,
                                resolver,
                                compilation,
                                isSubmission,
                                ordinalMapBuilder,
                                loadDirectiveMapBuilder,
                                loadedSyntaxTreeMapBuilder,
                                declMapBuilder,
                                ref declTable);
                        }
                        catch (Exception e)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_FileReadError.ToDiagnosticInfo(resolvedFilePath, e).ToDiagnostic(node.Location));
                        }
                    }
                    else
                    {
                        // The path resolved, but we've seen this file before,
                        // so don't attempt to load it again.
                        Debug.Assert(diagnostics.IsEmptyWithoutResolution);
                    }
                }

                if (loadDirectives == null)
                {
                    loadDirectives = ArrayBuilder<DeclarationLoadDirective>.GetInstance();
                }
                loadDirectives.Add(new DeclarationLoadDirective(resolvedFilePath, diagnostics.ToReadOnlyAndFree()));
            }

            if (loadDirectives != null)
            {
                loadDirectiveMapBuilder.Add(tree, loadDirectives.ToImmutableAndFree());
            }
        }
        
        private static void AddSyntaxTreeToDeclarationMapAndTable(
            LanguageSyntaxTree tree,
            string scriptClassName,
            bool isSubmission,
            IDictionary<LanguageSyntaxTree, Lazy<RootSingleDeclaration>> declMapBuilder,
            ref DeclarationTable declTable)
        {
            var lazyRoot = new Lazy<RootSingleDeclaration>(() => tree.Language.CompilationFactory.CreateDeclarationTree(tree, scriptClassName, isSubmission));
            declMapBuilder.Add(tree, lazyRoot); // Callers are responsible for checking for existing entries.
            declTable = declTable.AddRootDeclaration(lazyRoot);
        }

        public SyntaxAndDeclarationManager RemoveSyntaxTrees(HashSet<LanguageSyntaxTree> trees)
        {
            var state = _lazyState;
            var newExternalSyntaxTrees = this.ExternalSyntaxTrees.RemoveAll(t => trees.Contains(t));
            if (state == null)
            {
                return this.WithExternalSyntaxTrees(newExternalSyntaxTrees);
            }

            var syntaxTrees = state.SyntaxTrees;
            var loadDirectiveMap = state.LoadDirectiveMap;
            var loadedSyntaxTreeMap = state.LoadedSyntaxTreeMap;
            var removeSet = PooledHashSet<LanguageSyntaxTree>.GetInstance();
            foreach (var tree in trees)
            {
                int unused1;
                ImmutableArray<DeclarationLoadDirective> unused2;
                GetRemoveSet(
                    tree,
                    includeLoadedTrees: true,
                    syntaxTrees: syntaxTrees,
                    syntaxTreeOrdinalMap: state.OrdinalMap,
                    loadDirectiveMap: loadDirectiveMap,
                    loadedSyntaxTreeMap: loadedSyntaxTreeMap,
                    removeSet: removeSet,
                    totalReferencedTreeCount: out unused1,
                    oldLoadDirectives: out unused2);
            }

            var treesBuilder = ArrayBuilder<LanguageSyntaxTree>.GetInstance();
            var ordinalMapBuilder = PooledDictionary<LanguageSyntaxTree, int>.GetInstance();
            var declMapBuilder = state.RootNamespaces.ToBuilder();
            var declTable = state.DeclarationTable;
            foreach (var tree in syntaxTrees)
            {
                if (removeSet.Contains(tree))
                {
                    loadDirectiveMap = loadDirectiveMap.Remove(tree);
                    loadedSyntaxTreeMap = loadedSyntaxTreeMap.Remove(tree.FilePath);
                    RemoveSyntaxTreeFromDeclarationMapAndTable(tree, declMapBuilder, ref declTable);
                }
                else if (!IsLoadedSyntaxTree(tree, loadedSyntaxTreeMap))
                {
                    UpdateSyntaxTreesAndOrdinalMapOnly(
                        treesBuilder,
                        tree,
                        ordinalMapBuilder,
                        loadDirectiveMap,
                        loadedSyntaxTreeMap);
                }
            }
            removeSet.Free();

            state = new State(
                treesBuilder.ToImmutableAndFree(),
                ordinalMapBuilder.ToImmutableDictionaryAndFree(),
                loadDirectiveMap,
                loadedSyntaxTreeMap,
                declMapBuilder.ToImmutableDictionary(),
                declTable);

            return new SyntaxAndDeclarationManager(
                newExternalSyntaxTrees,
                this.ScriptClassName,
                this.Resolver,
                this.Compilation,
                this.IsSubmission,
                state);
        }

        /// <summary>
        /// Collects all the trees #load'ed by <paramref name="oldTree"/> (as well as
        /// <paramref name="oldTree"/> itself) and populates <paramref name="removeSet"/>
        /// with all the trees that are safe to remove (not #load'ed by any other tree).
        /// </summary>
        private static void GetRemoveSet(
            LanguageSyntaxTree oldTree,
            bool includeLoadedTrees,
            ImmutableArray<LanguageSyntaxTree> syntaxTrees,
            ImmutableDictionary<LanguageSyntaxTree, int> syntaxTreeOrdinalMap,
            ImmutableDictionary<LanguageSyntaxTree, ImmutableArray<DeclarationLoadDirective>> loadDirectiveMap,
            ImmutableDictionary<string, LanguageSyntaxTree> loadedSyntaxTreeMap,
            HashSet<LanguageSyntaxTree> removeSet,
            out int totalReferencedTreeCount,
            out ImmutableArray<DeclarationLoadDirective> oldLoadDirectives)
        {
            if (includeLoadedTrees && loadDirectiveMap.TryGetValue(oldTree, out oldLoadDirectives))
            {
                Debug.Assert(!oldLoadDirectives.IsEmpty);
                GetRemoveSetForLoadedTrees(oldLoadDirectives, loadDirectiveMap, loadedSyntaxTreeMap, removeSet);
            }
            else
            {
                oldLoadDirectives = ImmutableArray<DeclarationLoadDirective>.Empty;
            }

            removeSet.Add(oldTree);
            totalReferencedTreeCount = removeSet.Count;

            // Check subsequent trees to see if they #load any of the trees we're about
            // to remove.  We don't want to remove a tree until the last external tree
            // that depends on it is removed.
            if (removeSet.Count > 1)
            {
                var ordinal = syntaxTreeOrdinalMap[oldTree];
                for (int i = ordinal + 1; i < syntaxTrees.Length; i++)
                {
                    var tree = syntaxTrees[i];
                    ImmutableArray<DeclarationLoadDirective> loadDirectives;
                    if (loadDirectiveMap.TryGetValue(tree, out loadDirectives))
                    {
                        Debug.Assert(!loadDirectives.IsEmpty);
                        foreach (var directive in loadDirectives)
                        {
                            LanguageSyntaxTree loadedTree;
                            if (TryGetLoadedSyntaxTree(loadedSyntaxTreeMap, directive, out loadedTree))
                            {
                                removeSet.Remove(loadedTree);
                            }
                        }
                    }
                }
            }
        }

        private static void GetRemoveSetForLoadedTrees(
            ImmutableArray<DeclarationLoadDirective> loadDirectives,
            ImmutableDictionary<LanguageSyntaxTree, ImmutableArray<DeclarationLoadDirective>> loadDirectiveMap,
            ImmutableDictionary<string, LanguageSyntaxTree> loadedSyntaxTreeMap,
            HashSet<LanguageSyntaxTree> removeSet)
        {
            foreach (var directive in loadDirectives)
            {
                if (directive.ResolvedPath != null)
                {
                    LanguageSyntaxTree loadedTree;
                    if (TryGetLoadedSyntaxTree(loadedSyntaxTreeMap, directive, out loadedTree) && removeSet.Add(loadedTree))
                    {
                        ImmutableArray<DeclarationLoadDirective> nestedLoadDirectives;
                        if (loadDirectiveMap.TryGetValue(loadedTree, out nestedLoadDirectives))
                        {
                            Debug.Assert(!nestedLoadDirectives.IsEmpty);
                            GetRemoveSetForLoadedTrees(nestedLoadDirectives, loadDirectiveMap, loadedSyntaxTreeMap, removeSet);
                        }
                    }
                }
            }
        }

        private static void RemoveSyntaxTreeFromDeclarationMapAndTable(
            LanguageSyntaxTree tree,
            IDictionary<LanguageSyntaxTree, Lazy<RootSingleDeclaration>> declMap,
            ref DeclarationTable declTable)
        {
            var lazyRoot = declMap[tree];
            declTable = declTable.RemoveRootDeclaration(lazyRoot);
            declMap.Remove(tree);
        }

        public SyntaxAndDeclarationManager ReplaceSyntaxTree(LanguageSyntaxTree oldTree, LanguageSyntaxTree newTree)
        {
            var state = _lazyState;
            var newExternalSyntaxTrees = this.ExternalSyntaxTrees.Replace(oldTree, newTree);
            if (state == null)
            {
                return this.WithExternalSyntaxTrees(newExternalSyntaxTrees);
            }

            var newLoadDirectivesSyntax = newTree.GetRootSyntax().GetLoadDirectives();
            var loadDirectivesHaveChanged = !oldTree.GetRootSyntax().GetLoadDirectives().SequenceEqual(newLoadDirectivesSyntax);
            var syntaxTrees = state.SyntaxTrees;
            var ordinalMap = state.OrdinalMap;
            var loadDirectiveMap = state.LoadDirectiveMap;
            var loadedSyntaxTreeMap = state.LoadedSyntaxTreeMap;
            var removeSet = PooledHashSet<LanguageSyntaxTree>.GetInstance();
            int totalReferencedTreeCount;
            ImmutableArray<DeclarationLoadDirective> oldLoadDirectives;
            GetRemoveSet(
                oldTree,
                loadDirectivesHaveChanged,
                syntaxTrees,
                ordinalMap,
                loadDirectiveMap,
                loadedSyntaxTreeMap,
                removeSet,
                out totalReferencedTreeCount,
                out oldLoadDirectives);

            var loadDirectiveMapBuilder = loadDirectiveMap.ToBuilder();
            var loadedSyntaxTreeMapBuilder = loadedSyntaxTreeMap.ToBuilder();
            var declMapBuilder = state.RootNamespaces.ToBuilder();
            var declTable = state.DeclarationTable;
            foreach (var tree in removeSet)
            {
                loadDirectiveMapBuilder.Remove(tree);
                loadedSyntaxTreeMapBuilder.Remove(tree.FilePath);
                RemoveSyntaxTreeFromDeclarationMapAndTable(tree, declMapBuilder, ref declTable);
            }
            removeSet.Free();

            var oldOrdinal = ordinalMap[oldTree];
            ImmutableArray<LanguageSyntaxTree> newTrees;
            if (loadDirectivesHaveChanged)
            {
                // Should have been removed above...
                Debug.Assert(!loadDirectiveMapBuilder.ContainsKey(oldTree));
                Debug.Assert(!loadDirectiveMapBuilder.ContainsKey(newTree));

                // If we're inserting new #load'ed trees, we'll rebuild
                // the whole syntaxTree array and the ordinalMap.
                var treesBuilder = ArrayBuilder<LanguageSyntaxTree>.GetInstance();
                var ordinalMapBuilder = PooledDictionary<LanguageSyntaxTree, int>.GetInstance();
                for (var i = 0; i <= (oldOrdinal - totalReferencedTreeCount); i++)
                {
                    var tree = syntaxTrees[i];
                    treesBuilder.Add(tree);
                    ordinalMapBuilder.Add(tree, i);
                }

                AppendAllSyntaxTrees(
                    treesBuilder,
                    newTree,
                    this.ScriptClassName,
                    this.Resolver,
                    this.Compilation,
                    this.IsSubmission,
                    ordinalMapBuilder,
                    loadDirectiveMapBuilder,
                    loadedSyntaxTreeMapBuilder,
                    declMapBuilder,
                    ref declTable);

                for (var i = oldOrdinal + 1; i < syntaxTrees.Length; i++)
                {
                    var tree = syntaxTrees[i];
                    if (!IsLoadedSyntaxTree(tree, loadedSyntaxTreeMap))
                    {
                        UpdateSyntaxTreesAndOrdinalMapOnly(
                            treesBuilder,
                            tree,
                            ordinalMapBuilder,
                            loadDirectiveMap,
                            loadedSyntaxTreeMap);
                    }
                }

                newTrees = treesBuilder.ToImmutableAndFree();
                ordinalMap = ordinalMapBuilder.ToImmutableDictionaryAndFree();
                Debug.Assert(newTrees.Length == ordinalMap.Count);
            }
            else
            {
                AddSyntaxTreeToDeclarationMapAndTable(newTree, this.ScriptClassName, this.IsSubmission, declMapBuilder, ref declTable);

                if (newLoadDirectivesSyntax.Any())
                {
                    // If load directives have not changed and there are new directives,
                    // then there should have been (matching) old directives as well.
                    Debug.Assert(!oldLoadDirectives.IsDefault);
                    Debug.Assert(!oldLoadDirectives.IsEmpty);
                    Debug.Assert(oldLoadDirectives.Length == newLoadDirectivesSyntax.Count);
                    loadDirectiveMapBuilder[newTree] = oldLoadDirectives;
                }

                Debug.Assert(ordinalMap.ContainsKey(oldTree)); // Checked by RemoveSyntaxTreeFromDeclarationMapAndTable

                newTrees = syntaxTrees.SetItem(oldOrdinal, newTree);

                ordinalMap = ordinalMap.Remove(oldTree);
                ordinalMap = ordinalMap.SetItem(newTree, oldOrdinal);
            }

            state = new State(
                newTrees,
                ordinalMap,
                loadDirectiveMapBuilder.ToImmutable(),
                loadedSyntaxTreeMapBuilder.ToImmutable(),
                declMapBuilder.ToImmutable(),
                declTable);

            return new SyntaxAndDeclarationManager(
                newExternalSyntaxTrees,
                this.ScriptClassName,
                this.Resolver,
                this.Compilation,
                this.IsSubmission,
                state);
        }

        internal SyntaxAndDeclarationManager WithExternalSyntaxTrees(ImmutableArray<LanguageSyntaxTree> trees)
        {
            return new SyntaxAndDeclarationManager(trees, this.ScriptClassName, this.Resolver, this.Compilation, this.IsSubmission, state: null);
        }

        internal static bool IsLoadedSyntaxTree(LanguageSyntaxTree tree, ImmutableDictionary<string, LanguageSyntaxTree> loadedSyntaxTreeMap)
        {
            LanguageSyntaxTree loadedTree;
            return loadedSyntaxTreeMap.TryGetValue(tree.FilePath, out loadedTree) && (tree == loadedTree);
        }

        private static void UpdateSyntaxTreesAndOrdinalMapOnly(
            ArrayBuilder<LanguageSyntaxTree> treesBuilder,
            LanguageSyntaxTree tree,
            IDictionary<LanguageSyntaxTree, int> ordinalMapBuilder,
            ImmutableDictionary<LanguageSyntaxTree, ImmutableArray<DeclarationLoadDirective>> loadDirectiveMap,
            ImmutableDictionary<string, LanguageSyntaxTree> loadedSyntaxTreeMap)
        {
            var sourceCodeKind = tree.Options.Kind;
            if (sourceCodeKind == SourceCodeKind.Script)
            {
                ImmutableArray<DeclarationLoadDirective> loadDirectives;
                if (loadDirectiveMap.TryGetValue(tree, out loadDirectives))
                {
                    Debug.Assert(!loadDirectives.IsEmpty);
                    foreach (var directive in loadDirectives)
                    {
                        var resolvedPath = directive.ResolvedPath;
                        Debug.Assert((resolvedPath != null) || !directive.Diagnostics.IsEmpty);
                        if (resolvedPath == null)
                        {
                            continue;
                        }

                        LanguageSyntaxTree loadedTree;
                        if (TryGetLoadedSyntaxTree(loadedSyntaxTreeMap, directive, out loadedTree))
                        {
                            UpdateSyntaxTreesAndOrdinalMapOnly(
                                treesBuilder,
                                loadedTree,
                                ordinalMapBuilder,
                                loadDirectiveMap,
                                loadedSyntaxTreeMap);
                        }
                    }
                }
            }

            treesBuilder.Add(tree);

            ordinalMapBuilder.Add(tree, ordinalMapBuilder.Count);
        }

        internal bool MayHaveReferenceDirectives()
        {
            var state = _lazyState;
            if (state == null)
            {
                var externalSyntaxTrees = this.ExternalSyntaxTrees;
                return externalSyntaxTrees.Any(t => t.HasReferenceOrLoadDirectives());
            }

            return state.DeclarationTable.ReferenceDirectives.Any();
        }

        private static bool TryGetLoadedSyntaxTree(ImmutableDictionary<string, LanguageSyntaxTree> loadedSyntaxTreeMap, DeclarationLoadDirective directive, out LanguageSyntaxTree loadedTree)
        {
            if (loadedSyntaxTreeMap.TryGetValue(directive.ResolvedPath, out loadedTree))
            {
                return true;
            }

            // If we don't have a tree for this directive, there should be errors.
            Debug.Assert(directive.Diagnostics.HasAnyErrors());

            return false;
        }
    }
}

using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Declarations
{
    public sealed class SyntaxAndDeclarationManager
    {
        public readonly ImmutableArray<SyntaxTree> ExternalSyntaxTrees;
        public readonly string ScriptClassName;
        public readonly SourceReferenceResolver Resolver;
        public readonly bool IsSubmission;

        private ImmutableDictionary<SyntaxTree, ImmutableArray<Diagnostic>> _syntaxTreeLoadDirectiveMap;
        // This ImmutableDictionary will use default (case-sensitive) comparison
        // for its keys.  It is the responsibility of the SourceReferenceResolver
        // to normalize the paths it resolves in a way that is appropriate for the
        // platforms that the host supports.
        private ImmutableDictionary<string, SyntaxTree> _resolvedFilePathSyntaxTreeMap;

        private State _lazyState;

        private SyntaxAndDeclarationManager(
            ImmutableArray<SyntaxTree> externalSyntaxTrees,
            string scriptClassName,
            SourceReferenceResolver resolver,
            bool isSubmission,
            State state)
        {
            this.ExternalSyntaxTrees = externalSyntaxTrees;
            this.ScriptClassName = scriptClassName ?? string.Empty;
            this.Resolver = resolver;
            this.IsSubmission = isSubmission;
            _lazyState = state;
        }

        public static SyntaxAndDeclarationManager Create(
            ImmutableArray<SyntaxTree> externalSyntaxTrees,
            string scriptClassName,
            SourceReferenceResolver resolver,
            bool isSubmission)
        {
            return new SyntaxAndDeclarationManager(externalSyntaxTrees, scriptClassName, resolver, isSubmission, state: null);
        }

        internal State GetLazyState()
        {
            if (_lazyState == null)
            {
                Interlocked.CompareExchange(ref _lazyState, CreateState(this.ExternalSyntaxTrees, this.ScriptClassName, this.Resolver, this.IsSubmission), null);
            }

            return _lazyState;
        }

        private static State CreateState(
            ImmutableArray<SyntaxTree> externalSyntaxTrees,
            string scriptClassName,
            SourceReferenceResolver resolver,
            bool isSubmission)
        {
            var treesBuilder = ArrayBuilder<SyntaxTree>.GetInstance();
            var ordinalMapBuilder = PooledDictionary<SyntaxTree, int>.GetInstance();
            var loadDirectiveMapBuilder = PooledDictionary<SyntaxTree, ImmutableArray<SyntaxNode>>.GetInstance();
            var loadedSyntaxTreeMapBuilder = PooledDictionary<string, SyntaxTree>.GetInstance();
            var declMapBuilder = PooledDictionary<SyntaxTree, Lazy<RootSingleDeclaration>>.GetInstance();
            var declTable = DeclarationTable.Empty;

            foreach (var tree in externalSyntaxTrees)
            {
                AppendAllSyntaxTrees(
                    treesBuilder,
                    tree,
                    scriptClassName,
                    resolver,
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

        public SyntaxAndDeclarationManager AddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            var scriptClassName = this.ScriptClassName;
            var resolver = this.Resolver;
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

            var treesBuilder = ArrayBuilder<SyntaxTree>.GetInstance();
            treesBuilder.AddRange(state.SyntaxTrees);

            foreach (var tree in trees)
            {
                AppendAllSyntaxTrees(
                        treesBuilder,
                        tree,
                        scriptClassName,
                        resolver,
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
                isSubmission,
                state);
        }

        /// <summary>
        /// Appends all trees (including any trees from #load'ed files).
        /// </summary>
        private static void AppendAllSyntaxTrees(
            ArrayBuilder<SyntaxTree> treesBuilder,
            SyntaxTree tree,
            string scriptClassName,
            SourceReferenceResolver resolver,
            bool isSubmission,
            IDictionary<SyntaxTree, int> ordinalMapBuilder,
            IDictionary<SyntaxTree, ImmutableArray<SyntaxNode>> loadDirectiveMapBuilder,
            IDictionary<string, SyntaxTree> loadedSyntaxTreeMapBuilder,
            IDictionary<SyntaxTree, Lazy<RootSingleDeclaration>> declMapBuilder,
            ref DeclarationTable declTable)
        {
            var sourceCodeKind = tree.Options.Kind;
            if (sourceCodeKind == SourceCodeKind.Script)
            {
                AppendAllLoadedSyntaxTrees(treesBuilder, tree, scriptClassName, resolver, isSubmission, ordinalMapBuilder, loadDirectiveMapBuilder, loadedSyntaxTreeMapBuilder, declMapBuilder, ref declTable);
            }

            AddSyntaxTreeToDeclarationMapAndTable(tree, scriptClassName, isSubmission, declMapBuilder, ref declTable);

            treesBuilder.Add(tree);

            ordinalMapBuilder.Add(tree, ordinalMapBuilder.Count);
        }

        private static void AppendAllLoadedSyntaxTrees(
            ArrayBuilder<SyntaxTree> treesBuilder,
            SyntaxTree tree,
            string scriptClassName,
            SourceReferenceResolver resolver,
            bool isSubmission,
            IDictionary<SyntaxTree, int> ordinalMapBuilder,
            IDictionary<SyntaxTree, ImmutableArray<SyntaxNode>> loadDirectiveMapBuilder,
            IDictionary<string, SyntaxTree> loadedSyntaxTreeMapBuilder,
            IDictionary<SyntaxTree, Lazy<RootSingleDeclaration>> declMapBuilder,
            ref DeclarationTable declTable)
        {
            // SB-TODO
            throw new NotImplementedException();
        }

        private static void AddSyntaxTreeToDeclarationMapAndTable(
            SyntaxTree tree,
            string scriptClassName,
            bool isSubmission,
            IDictionary<SyntaxTree, Lazy<RootSingleDeclaration>> declMapBuilder,
            ref DeclarationTable declTable)
        {
            var lazyRoot = new Lazy<RootSingleDeclaration>(() => tree.Language.CompilationFactory.CreateDeclarationTree(tree, scriptClassName, isSubmission));
            declMapBuilder.Add(tree, lazyRoot); // Callers are responsible for checking for existing entries.
            declTable = declTable.AddRootDeclaration(lazyRoot);
        }

        public SyntaxAndDeclarationManager RemoveSyntaxTrees(HashSet<SyntaxTree> trees)
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
            var removeSet = PooledHashSet<SyntaxTree>.GetInstance();
            foreach (var tree in trees)
            {
                int unused1;
                ImmutableArray<SyntaxNode> unused2;
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

            var treesBuilder = ArrayBuilder<SyntaxTree>.GetInstance();
            var ordinalMapBuilder = PooledDictionary<SyntaxTree, int>.GetInstance();
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
                this.IsSubmission,
                state);
        }

        /// <summary>
        /// Collects all the trees #load'ed by <paramref name="oldTree"/> (as well as
        /// <paramref name="oldTree"/> itself) and populates <paramref name="removeSet"/>
        /// with all the trees that are safe to remove (not #load'ed by any other tree).
        /// </summary>
        private static void GetRemoveSet(
            SyntaxTree oldTree,
            bool includeLoadedTrees,
            ImmutableArray<SyntaxTree> syntaxTrees,
            ImmutableDictionary<SyntaxTree, int> syntaxTreeOrdinalMap,
            ImmutableDictionary<SyntaxTree, ImmutableArray<SyntaxNode>> loadDirectiveMap,
            ImmutableDictionary<string, SyntaxTree> loadedSyntaxTreeMap,
            HashSet<SyntaxTree> removeSet,
            out int totalReferencedTreeCount,
            out ImmutableArray<SyntaxNode> oldLoadDirectives)
        {
            if (includeLoadedTrees && loadDirectiveMap.TryGetValue(oldTree, out oldLoadDirectives))
            {
                Debug.Assert(!oldLoadDirectives.IsEmpty);
                GetRemoveSetForLoadedTrees(oldLoadDirectives, loadDirectiveMap, loadedSyntaxTreeMap, removeSet);
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
                    ImmutableArray<SyntaxNode> loadDirectives;
                    if (loadDirectiveMap.TryGetValue(tree, out loadDirectives))
                    {
                        Debug.Assert(!loadDirectives.IsEmpty);
                        foreach (var directive in loadDirectives)
                        {
                            SyntaxTree loadedTree;
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
            ImmutableArray<SyntaxNode> loadDirectives,
            ImmutableDictionary<SyntaxTree, ImmutableArray<SyntaxNode>> loadDirectiveMap,
            ImmutableDictionary<string, SyntaxTree> loadedSyntaxTreeMap,
            HashSet<SyntaxTree> removeSet)
        {
            // SB-TODO
            throw new NotImplementedException();
        }

        private static void RemoveSyntaxTreeFromDeclarationMapAndTable(
            SyntaxTree tree,
            IDictionary<SyntaxTree, Lazy<RootSingleDeclaration>> declMap,
            ref DeclarationTable declTable)
        {
            var lazyRoot = declMap[tree];
            declTable = declTable.RemoveRootDeclaration(lazyRoot);
            declMap.Remove(tree);
        }

        public SyntaxAndDeclarationManager ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            // SB-TODO
            throw new NotImplementedException();
        }

        internal SyntaxAndDeclarationManager WithExternalSyntaxTrees(ImmutableArray<SyntaxTree> trees)
        {
            return new SyntaxAndDeclarationManager(trees, this.ScriptClassName, this.Resolver, this.IsSubmission, state: null);
        }

        internal static bool IsLoadedSyntaxTree(SyntaxTree tree, ImmutableDictionary<string, SyntaxTree> loadedSyntaxTreeMap)
        {
            SyntaxTree loadedTree;
            return loadedSyntaxTreeMap.TryGetValue(tree.FilePath, out loadedTree) && (tree == loadedTree);
        }

        private static void UpdateSyntaxTreesAndOrdinalMapOnly(
            ArrayBuilder<SyntaxTree> treesBuilder,
            SyntaxTree tree,
            IDictionary<SyntaxTree, int> ordinalMapBuilder,
            ImmutableDictionary<SyntaxTree, ImmutableArray<SyntaxNode>> loadDirectiveMap,
            ImmutableDictionary<string, SyntaxTree> loadedSyntaxTreeMap)
        {
            // SB-TODO
            throw new NotImplementedException();
        }

        internal bool MayHaveReferenceDirectives()
        {
            // SB-TODO
            throw new NotImplementedException();
        }

        private static bool TryGetLoadedSyntaxTree(ImmutableDictionary<string, SyntaxTree> loadedSyntaxTreeMap, SyntaxNode directive, out SyntaxTree loadedTree)
        {
            // SB-TODO
            throw new NotImplementedException();
        }

        internal sealed class State
        {
            internal readonly ImmutableArray<SyntaxTree> SyntaxTrees; // In ordinal order.
            internal readonly ImmutableDictionary<SyntaxTree, int> OrdinalMap; // Inverse of syntaxTrees array (i.e. maps tree to index)
            internal readonly ImmutableDictionary<SyntaxTree, ImmutableArray<SyntaxNode>> LoadDirectiveMap;
            internal readonly ImmutableDictionary<string, SyntaxTree> LoadedSyntaxTreeMap;
            internal readonly ImmutableDictionary<SyntaxTree, Lazy<RootSingleDeclaration>> RootNamespaces;
            internal readonly DeclarationTable DeclarationTable;

            internal State(
                ImmutableArray<SyntaxTree> syntaxTrees,
                ImmutableDictionary<SyntaxTree, int> syntaxTreeOrdinalMap,
                ImmutableDictionary<SyntaxTree, ImmutableArray<SyntaxNode>> loadDirectiveMap,
                ImmutableDictionary<string, SyntaxTree> loadedSyntaxTreeMap,
                ImmutableDictionary<SyntaxTree, Lazy<RootSingleDeclaration>> rootNamespaces,
                DeclarationTable declarationTable)
            {
                Debug.Assert(syntaxTrees.All(tree => syntaxTrees[syntaxTreeOrdinalMap[tree]] == tree));
                Debug.Assert(syntaxTrees.SetEquals(rootNamespaces.Keys.ToImmutableArray(), EqualityComparer<SyntaxTree>.Default));

                this.SyntaxTrees = syntaxTrees;
                this.OrdinalMap = syntaxTreeOrdinalMap;
                this.LoadDirectiveMap = loadDirectiveMap;
                this.LoadedSyntaxTreeMap = loadedSyntaxTreeMap;
                this.RootNamespaces = rootNamespaces;
                this.DeclarationTable = declarationTable;
            }
        }
    }
}

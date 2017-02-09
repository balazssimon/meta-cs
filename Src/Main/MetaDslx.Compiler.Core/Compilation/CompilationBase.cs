using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// The compilation object is an immutable representation of a single invocation of the
    /// compiler. Although immutable, a compilation is also on-demand, and will realize and cache
    /// data as necessary. A compilation can produce a new compilation from existing compilation
    /// with the application of small deltas. In many cases, it is more efficient than creating a
    /// new compilation from scratch, as the new compilation can reuse information from the old
    /// compilation.
    /// </summary>
    public abstract class CompilationBase : Compilation
    {
        internal static readonly ParallelOptions DefaultParallelOptions = new ParallelOptions();

        private readonly CompilationOptions _options;
        private readonly Lazy<Imports> _globalImports;
        private readonly Lazy<Imports> _previousSubmissionImports;
        private readonly Lazy<IMetaSymbol> _globalNamespaceAlias;  // alias symbol used to resolve "global::".
        private readonly Lazy<IMetaSymbol> _scriptSymbol;

        // All imports (using directives and extern aliases) in syntax trees in this compilation.
        // NOTE: We need to de-dup since the Imports objects that populate the list may be GC'd
        // and re-created.
        private ConcurrentSet<ImportInfo> _lazyImportInfos;

        private Conversions _conversions;
        internal Conversions Conversions
        {
            get
            {
                if (_conversions == null)
                {
                    Interlocked.CompareExchange(ref _conversions, new BuckStopsHereBinder(this).Conversions, null);
                }

                return _conversions;
            }
        }

        private NameResolution _nameResolution;
        internal NameResolution NameResolution
        {
            get
            {
                if (_nameResolution == null)
                {
                    Interlocked.CompareExchange(ref _nameResolution, new NameResolution(this), null);
                }

                return _nameResolution;
            }
        }

        /// <summary>
        /// Manages anonymous types declared in this compilation. Unifies types that are structurally equivalent.
        /// </summary>
        private readonly AnonymousTypeManager _anonymousTypeManager;

        private IMetaSymbol _lazyGlobalNamespace;

        internal ModelId _lazyModelId;

        /// <summary>
        /// The <see cref="MutableModelGroup"/> for this compilation. Do not access directly, use the ModelGroupBuilder property
        /// instead. This field is lazily initialized by ReferenceManager, ReferenceManager.CacheLockObject must be locked
        /// while ReferenceManager "calculates" the value and assigns it, several threads must not perform duplicate
        /// "calculation" simultaneously.
        /// </summary>
        internal MutableModelGroup _lazyModelGroupBuilder;

        internal MutableModel _lazyModelBuilder;

        /// <summary>
        /// Holds onto data related to reference binding.
        /// The manager is shared among multiple compilations that we expect to have the same result of reference binding.
        /// In most cases this can be determined without performing the binding. If the compilation however contains a circular 
        /// metadata reference (a metadata reference that refers back to the compilation) we need to avoid sharing of the binding results.
        /// We do so by creating a new reference manager for such compilation. 
        /// </summary>
        internal ReferenceManager _referenceManager;

        private readonly SyntaxAndDeclarationManager _syntaxAndDeclarations;

        protected SyntaxAndDeclarationManager SyntaxAndDeclarations
        {
            get { return _syntaxAndDeclarations; }
        }

        /// <summary>
        /// The set of trees for which a <see cref="CompilationUnitCompletedEvent"/> has been added to the queue.
        /// </summary>
        private HashSet<SyntaxTree> _lazyCompilationUnitCompletedTrees;

        /// <summary>
        /// The options the compilation was created with. 
        /// </summary>
        protected override CompilationOptions CommonOptions
        {
            get
            {
                return _options;
            }
        }

        protected override AnonymousTypeManager CommonAnonymousTypeManager
        {
            get
            {
                return _anonymousTypeManager;
            }
        }

        #region Constructors and Factories

        protected CompilationBase(
            string name,
            CompilationOptions options,
            ImmutableArray<MetadataReference> references,
            Compilation previousSubmission,
            Type submissionReturnType,
            Type hostObjectType,
            bool isSubmission,
            ReferenceManager referenceManager,
            bool reuseReferenceManager,
            SyntaxAndDeclarationManager syntaxAndDeclarations,
            AsyncQueue<CompilationEvent> eventQueue = null)
            : base(name, references, SyntaxTreeCommonFeatures(syntaxAndDeclarations.ExternalSyntaxTrees), isSubmission, eventQueue)
        {
            _options = options;

            _scriptSymbol = new Lazy<IMetaSymbol>(BindScriptSymbol);
            _globalImports = new Lazy<Imports>(BindGlobalImports);
            _previousSubmissionImports = new Lazy<Imports>(ExpandPreviousSubmissionImports);
            _globalNamespaceAlias = new Lazy<IMetaSymbol>(CreateGlobalNamespaceAlias);
            _anonymousTypeManager = this.Language.CompilationFactory.CreateAnonymousTypeManager(this);

            if (isSubmission)
            {
                Debug.Assert(previousSubmission == null || previousSubmission.HostObjectType == hostObjectType);
                _scriptCompilationInfo = this.Language.CompilationFactory.CreateScriptCompilationInfo(previousSubmission, submissionReturnType, hostObjectType);
            }
            else
            {
                Debug.Assert(previousSubmission == null && submissionReturnType == null && hostObjectType == null);
            }

            if (reuseReferenceManager)
            {
                referenceManager.AssertCanReuseForCompilation(this);
                _referenceManager = referenceManager;
            }
            else
            {
                _referenceManager = new ReferenceManager(this.CompilationName);
            }

            _syntaxAndDeclarations = syntaxAndDeclarations;

            Debug.Assert((object)_lazyModelBuilder == null);
            Debug.Assert((object)_lazyModelGroupBuilder == null);
            if (EventQueue != null) EventQueue.TryEnqueue(new CompilationStartedEvent(this));
        }


        protected abstract CompilationBase Update(ReferenceManager referenceManager, bool reuseReferenceManager, SyntaxAndDeclarationManager syntaxAndDeclarations);

        #endregion

        #region Submission

        private readonly ScriptCompilationInfo _scriptCompilationInfo;
        protected override ScriptCompilationInfo CommonScriptCompilationInfo
        {
            get
            {
                return _scriptCompilationInfo;
            }
        }

        protected CompilationBase PreviousSubmission => (CompilationBase)ScriptCompilationInfo?.PreviousScriptCompilation;

        #endregion

        #region Syntax Trees (maintain an ordered list)

        /// <summary>
        /// The syntax trees (parsed from source code) that this compilation was created with.
        /// </summary>
        public new ImmutableArray<SyntaxTree> SyntaxTrees
        {
            get { return _syntaxAndDeclarations.GetLazyState().SyntaxTrees; }
        }

        /// <summary>
        /// Returns true if this compilation contains the specified tree.  False otherwise.
        /// </summary>
        public new bool ContainsSyntaxTree(SyntaxTree syntaxTree)
        {
            var cstree = syntaxTree as SyntaxTree;
            return cstree != null && _syntaxAndDeclarations.GetLazyState().RootNamespaces.ContainsKey(cstree);
        }

        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new CompilationBase AddSyntaxTrees(params SyntaxTree[] trees)
        {
            return AddSyntaxTrees((IEnumerable<SyntaxTree>)trees);
        }

        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new CompilationBase AddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            if (trees == null)
            {
                throw new ArgumentNullException(nameof(trees));
            }

            if (!trees.Any())
            {
                return this;
            }

            // This HashSet is needed so that we don't allow adding the same tree twice
            // with a single call to AddSyntaxTrees.  Rather than using a separate HashSet,
            // ReplaceSyntaxTrees can just check against ExternalSyntaxTrees, because we
            // only allow replacing a single tree at a time.
            var externalSyntaxTrees = PooledHashSet<SyntaxTree>.GetInstance();
            var syntaxAndDeclarations = _syntaxAndDeclarations;
            externalSyntaxTrees.AddAll(syntaxAndDeclarations.ExternalSyntaxTrees);
            bool reuseReferenceManager = true;
            int i = 0;
            foreach (var tree in trees)
            {
                if (tree == null)
                {
                    throw new ArgumentNullException($"{nameof(trees)}[{i}]");
                }

                if (!tree.HasCompilationUnitRoot)
                {
                    throw new ArgumentException("Tree must have a compilation unit root node.", $"{nameof(trees)}[{i}]");
                }

                if (externalSyntaxTrees.Contains(tree))
                {
                    throw new ArgumentException("Syntax tree already present", $"{nameof(trees)}[{i}]");
                }

                if (this.IsSubmission && tree.Options.Kind == SourceCodeKind.Regular)
                {
                    throw new ArgumentException("Submission can only include script code.", $"{nameof(trees)}[{i}]");
                }

                externalSyntaxTrees.Add(tree);
                reuseReferenceManager &= !this.Language.CompilationFactory.HasReferenceOrLoadDirectives(tree);

                i++;
            }
            externalSyntaxTrees.Free();

            if (this.IsSubmission && i > 1)
            {
                throw new ArgumentException("Submission can have at most one syntax tree.", nameof(trees));
            }

            syntaxAndDeclarations = syntaxAndDeclarations.AddSyntaxTrees(trees);

            return Update(_referenceManager, reuseReferenceManager, syntaxAndDeclarations);
        }

        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later. 
        /// </summary>
        public new CompilationBase RemoveSyntaxTrees(params SyntaxTree[] trees)
        {
            return RemoveSyntaxTrees((IEnumerable<SyntaxTree>)trees);
        }

        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later. 
        /// </summary>
        public new CompilationBase RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            if (trees == null)
            {
                throw new ArgumentNullException(nameof(trees));
            }

            if (!trees.Any())
            {
                return this;
            }

            var removeSet = PooledHashSet<SyntaxTree>.GetInstance();
            // This HashSet is needed so that we don't allow adding the same tree twice
            // with a single call to AddSyntaxTrees.  Rather than using a separate HashSet,
            // ReplaceSyntaxTrees can just check against ExternalSyntaxTrees, because we
            // only allow replacing a single tree at a time.
            var externalSyntaxTrees = PooledHashSet<SyntaxTree>.GetInstance();
            var syntaxAndDeclarations = _syntaxAndDeclarations;
            externalSyntaxTrees.AddAll(syntaxAndDeclarations.ExternalSyntaxTrees);
            bool reuseReferenceManager = true;
            int i = 0;
            foreach (var tree in trees)
            {
                if (!externalSyntaxTrees.Contains(tree))
                {
                    // Check to make sure this is not a #load'ed tree.
                    var loadedSyntaxTreeMap = syntaxAndDeclarations.GetLazyState().LoadedSyntaxTreeMap;
                    if (SyntaxAndDeclarationManager.IsLoadedSyntaxTree(tree, loadedSyntaxTreeMap))
                    {
                        throw new ArgumentException(string.Format("SyntaxTree '{0}' resulted from a load directive and cannot be removed or replaced directly.", tree), $"{nameof(trees)}[{i}]");
                    }

                    throw new ArgumentException(string.Format("SyntaxTree '{0}' not found to remove", tree), $"{nameof(trees)}[{i}]");
                }

                removeSet.Add(tree);
                reuseReferenceManager &= !this.Language.CompilationFactory.HasReferenceOrLoadDirectives(tree);

                i++;
            }
            externalSyntaxTrees.Free();

            syntaxAndDeclarations = syntaxAndDeclarations.RemoveSyntaxTrees(removeSet);
            removeSet.Free();

            return Update(_referenceManager, reuseReferenceManager, syntaxAndDeclarations);
        }

        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info
        /// from this compilation for use with trees added later. 
        /// </summary>
        public new CompilationBase RemoveAllSyntaxTrees()
        {
            var syntaxAndDeclarations = _syntaxAndDeclarations;
            return Update(
                _referenceManager,
                reuseReferenceManager: !syntaxAndDeclarations.MayHaveReferenceDirectives(),
                syntaxAndDeclarations: syntaxAndDeclarations.WithExternalSyntaxTrees(ImmutableArray<SyntaxTree>.Empty));
        }

        /// <summary>
        /// Creates a new compilation without the old tree but with the new tree.
        /// </summary>
        public new CompilationBase ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            if (oldTree == null)
            {
                throw new ArgumentNullException(nameof(oldTree));
            }

            if (newTree == null)
            {
                return this.RemoveSyntaxTrees(oldTree);
            }
            else if (newTree == oldTree)
            {
                return this;
            }

            if (!newTree.HasCompilationUnitRoot)
            {
                throw new ArgumentException("Tree must have a compilation unit root node.", nameof(newTree));
            }

            var syntaxAndDeclarations = _syntaxAndDeclarations;
            var externalSyntaxTrees = syntaxAndDeclarations.ExternalSyntaxTrees;
            if (!externalSyntaxTrees.Contains(oldTree))
            {
                // Check to see if this is a #load'ed tree.
                var loadedSyntaxTreeMap = syntaxAndDeclarations.GetLazyState().LoadedSyntaxTreeMap;
                if (SyntaxAndDeclarationManager.IsLoadedSyntaxTree(oldTree, loadedSyntaxTreeMap))
                {
                    throw new ArgumentException(string.Format("SyntaxTree '{0}' resulted from a load directive and cannot be removed or replaced directly.", oldTree), nameof(oldTree));
                }

                throw new ArgumentException(string.Format("SyntaxTree '{0}' not found to remove", oldTree), nameof(oldTree));
            }

            if (externalSyntaxTrees.Contains(newTree))
            {
                throw new ArgumentException("Syntax tree already present", nameof(newTree));
            }

            // TODO(tomat): Consider comparing #r's of the old and the new tree. If they are exactly the same we could still reuse.
            // This could be a perf win when editing a script file in the IDE. The services create a new compilation every keystroke 
            // that replaces the tree with a new one.
            var reuseReferenceManager = !this.Language.CompilationFactory.HasReferenceOrLoadDirectives(oldTree) && !this.Language.CompilationFactory.HasReferenceOrLoadDirectives(newTree);
            syntaxAndDeclarations = syntaxAndDeclarations.ReplaceSyntaxTree(oldTree, newTree);

            return Update(_referenceManager, reuseReferenceManager, syntaxAndDeclarations);
        }

        internal override int GetSyntaxTreeOrdinal(SyntaxTree tree)
        {
            Debug.Assert(this.ContainsSyntaxTree(tree));
            return _syntaxAndDeclarations.GetLazyState().OrdinalMap[tree];
        }

        #endregion

        #region References

        protected ReferenceManager GetUnboundReferenceManager()
        {
            return _referenceManager;
        }

        protected override ReferenceManager CommonGetBoundReferenceManager()
        {
            if ((object)_lazyModelBuilder == null)
            {
                _referenceManager.CreateModelBuilderForCompilation(this);
                Debug.Assert((object)_lazyModelBuilder != null);
            }

            // referenceManager can only be accessed after we initialized the lazyAssemblySymbol.
            // In fact, initialization of the assembly symbol might change the reference manager.
            return _referenceManager;
        }

        // for testing only:
        internal bool ReferenceManagerEquals(CompilationBase other)
        {
            return ReferenceEquals(_referenceManager, other._referenceManager);
        }

        public override ImmutableArray<MetadataReference> DirectiveReferences
        {
            get
            {
                return GetBoundReferenceManager().DirectiveReferences;
            }
        }

        internal override IDictionary<Tuple<string, string>, MetadataReference> ReferenceDirectiveMap
        {
            get
            {
                return GetBoundReferenceManager().ReferenceDirectiveMap;
            }
        }

        // for testing purposes
        internal IEnumerable<string> ExternAliases
        {
            get
            {
                return GetBoundReferenceManager().ExternAliases;
            }
        }

        /// <summary>
        /// Gets the <see cref="ImmutableModel"/> for a metadata reference used to create this compilation.
        /// </summary>
        /// <returns><see cref="ImmutableModel"/> corresponding to the given reference or null if there is none.</returns>
        /// <remarks>
        /// Uses object identity when comparing two references. 
        /// </remarks>
        protected override ImmutableModel CommonGetReferencedModel(MetadataReference reference)
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }

            return GetBoundReferenceManager().GetReferencedModel(reference);
        }

        public override IEnumerable<ModelIdentity> ReferencedModelNames
        {
            get
            {
                return GetBoundReferenceManager().GetReferencedModelNames();
            }
        }


        /// <summary>
        /// All reference directives used in this compilation.
        /// </summary>
        internal override IEnumerable<ReferenceDirective> ReferenceDirectives
        {
            get { return this.Declarations.ReferenceDirectives; }
        }

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new CompilationBase AddReferences(params MetadataReference[] references)
        {
            return (CompilationBase)base.AddReferences(references);
        }

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new CompilationBase AddReferences(IEnumerable<MetadataReference> references)
        {
            return (CompilationBase)base.AddReferences(references);
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new CompilationBase RemoveReferences(params MetadataReference[] references)
        {
            return (CompilationBase)base.RemoveReferences(references);
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new CompilationBase RemoveReferences(IEnumerable<MetadataReference> references)
        {
            return (CompilationBase)base.RemoveReferences(references);
        }

        /// <summary>
        /// Creates a new compilation without any metadata references
        /// </summary>
        public new CompilationBase RemoveAllReferences()
        {
            return (CompilationBase)base.RemoveAllReferences();
        }

        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata reference.
        /// </summary>
        public new CompilationBase ReplaceReference(MetadataReference oldReference, MetadataReference newReference)
        {
            return (CompilationBase)base.ReplaceReference(oldReference, newReference);
        }

        public override CompilationReference ToMetadataReference(ImmutableArray<string> aliases = default(ImmutableArray<string>))
        {
            return new CompilationReference(this, aliases);
        }


        /// <summary>
        /// Get all modules in this compilation, including the source module, added modules, and all
        /// modules of referenced assemblies that do not come from an assembly with an extern alias.
        /// Metadata imported from aliased assemblies is not visible at the source level except through 
        /// the use of an extern alias directive. So exclude them from this list which is used to construct
        /// the global namespace.
        /// </summary>
        private void GetAllUnaliasedModels(ArrayBuilder<IMetaSymbol> rootNamespaces)
        {
            var referenceManager = GetBoundReferenceManager();

            for (int i = 0; i < referenceManager.ReferencedModels.Length; i++)
            {
                if (referenceManager.DeclarationsAccessibleWithoutAlias(i))
                {
                    rootNamespaces.AddRange(referenceManager.GetRootNamespaces(i));
                }
            }
        }

        #endregion

        #region Symbols

        protected override ModelId ModelId
        {
            get
            {
                GetBoundReferenceManager();
                return _lazyModelId;
            }
        }

        /// <summary>
        /// The ModelGroupBuilder that represents the compilation.
        /// </summary>
        protected override MutableModelGroup ModelGroupBuilder
        {
            get
            {
                GetBoundReferenceManager();
                return _lazyModelGroupBuilder;
            }
        }

        /// <summary>
        /// The ModelBuilder that represents the compilation.
        /// </summary>
        protected override MutableModel ModelBuilder
        {
            get
            {
                GetBoundReferenceManager();
                return _lazyModelBuilder;
            }
        }

        /// <summary>
        /// Gets the root namespace that contains all namespaces and types defined in source code or in 
        /// referenced metadata, merged into a single namespace hierarchy.
        /// </summary>
        protected override IMetaSymbol CommonGlobalNamespace
        {
            get
            {
                if ((object)_lazyGlobalNamespace == null)
                {
                    // Get the root namespace from each module, and merge them all together
                    // Get all modules in this compilation, ones referenced directly by the compilation 
                    // as well as those referenced by all referenced assemblies.

                    var rootNamespaces = ArrayBuilder<IMetaSymbol>.GetInstance();
                    GetAllUnaliasedModels(rootNamespaces);

                    var result = this.Language.CompilationFactory.CreateMergedNamespace(this, null, rootNamespaces);

                    rootNamespaces.Free();

                    Interlocked.CompareExchange(ref _lazyGlobalNamespace, result, null);
                }

                return _lazyGlobalNamespace;
            }
        }

        /// <summary>
        /// Given for the specified module or assembly namespace, gets the corresponding compilation
        /// namespace (merged namespace representation for all namespace declarations and references
        /// with contributions for the namespaceSymbol).  Can return null if no corresponding
        /// namespace can be bound in this compilation with the same name.
        /// </summary>
        protected override IMetaSymbol CommonGetCompilationNamespace(IMetaSymbol namespaceSymbol)
        {
            if (namespaceSymbol.MIsScope && namespaceSymbol.MName == null &&
                namespaceSymbol.MGet(CompilerAttachedProperties.ContainingCompilationProperty) == this)
            {
                return namespaceSymbol;
            }

            var containingNamespace = namespaceSymbol.MParent;
            if (containingNamespace == null)
            {
                return this.GlobalNamespace;
            }

            var current = GetCompilationNamespace(containingNamespace);
            if ((object)current != null)
            {
                return this.Language.CompilationFactory.GetNestedNamespace(namespaceSymbol);
            }

            return null;
        }

        private ConcurrentDictionary<string, IMetaSymbol> _externAliasTargets;

        internal bool GetExternAliasTarget(string aliasName, out IMetaSymbol @namespace)
        {
            if (_externAliasTargets == null)
            {
                Interlocked.CompareExchange(ref _externAliasTargets, new ConcurrentDictionary<string, IMetaSymbol>(), null);
            }

            ArrayBuilder<IMetaSymbol> builder = null;
            var referenceManager = GetBoundReferenceManager();
            for (int i = 0; i < referenceManager.ReferencedModels.Length; i++)
            {
                if (referenceManager.AliasesOfReferencedModels[i].Contains(aliasName))
                {
                    builder = builder ?? ArrayBuilder<IMetaSymbol>.GetInstance();
                    builder.AddRange(referenceManager.GetRootNamespaces(i));
                }
            }

            bool foundNamespace = builder != null;

            // We want to cache failures as well as successes so that subsequent incorrect extern aliases with the
            // same alias will have the same target.
            @namespace = foundNamespace
                ? this.Language.CompilationFactory.CreateMergedNamespace(this, namespacesToMerge: builder.ToImmutableAndFree(), containingNamespace: null)
                : this.Language.CompilationFactory.CreateNamespace(this, null, null);

            // Use GetOrAdd in case another thread beat us to the punch (i.e. should return the same object for the same alias, every time).
            @namespace = _externAliasTargets.GetOrAdd(aliasName, @namespace);

            return foundNamespace;
        }

        /// <summary>
        /// A symbol representing the implicit Script class. This is null if the class is not
        /// defined in the compilation.
        /// </summary>
        protected override IMetaSymbol CommonScriptSymbol
        {
            get { return _scriptSymbol.Value; }
        }

        /// <summary>
        /// Resolves a symbol that represents script container (Script class). Uses the
        /// full name of the container class stored in <see cref="CompilationOptions.ScriptClassName"/> to find the symbol.
        /// </summary>
        /// <returns>The Script class symbol or null if it is not defined.</returns>
        protected virtual IMetaSymbol BindScriptSymbol()
        {
            if (_options.ScriptClassName == null)
            {
                return null;
            }
            return this.NameResolution.GetSymbolByQualifiedName(null, _options.ScriptClassName, '.').FirstOrDefault();
        }

        internal bool IsSubmissionSyntaxTree(SyntaxTree tree)
        {
            Debug.Assert(tree != null);
            Debug.Assert(!this.IsSubmission || _syntaxAndDeclarations.ExternalSyntaxTrees.Length <= 1);
            return this.IsSubmission && tree == _syntaxAndDeclarations.ExternalSyntaxTrees.SingleOrDefault();
        }

        /// <summary>
        /// Global imports (including those from previous submissions, if there are any).
        /// </summary>
        internal Imports GlobalImports => _globalImports.Value;

        private Imports BindGlobalImports() => Imports.FromGlobalUsings(this);

        /// <summary>
        /// Imports declared by this submission (null if this isn't one).
        /// </summary>
        internal Imports GetSubmissionImports()
        {
            Debug.Assert(this.IsSubmission);
            Debug.Assert(_syntaxAndDeclarations.ExternalSyntaxTrees.Length <= 1);

            // A submission may be empty or comprised of a single script file.
            var tree = _syntaxAndDeclarations.ExternalSyntaxTrees.SingleOrDefault();
            if (tree == null)
            {
                return Imports.Empty;
            }

            var binder = GetBinderFactory(tree).GetBinder(tree.GetRoot());
            return binder.GetImports(basesBeingResolved: null);
        }

        /// <summary>
        /// Imports from all previous submissions.
        /// </summary>
        internal Imports GetPreviousSubmissionImports() => _previousSubmissionImports.Value;

        private Imports ExpandPreviousSubmissionImports()
        {
            Debug.Assert(this.IsSubmission);
            var previous = this.PreviousSubmission;

            if (previous == null)
            {
                return Imports.Empty;
            }

            return Imports.ExpandPreviousSubmissionImports(previous.GetPreviousSubmissionImports(), this).Concat(
                Imports.ExpandPreviousSubmissionImports(previous.GetSubmissionImports(), this));
        }

        internal IMetaSymbol GlobalNamespaceAlias
        {
            get
            {
                return _globalNamespaceAlias.Value;
            }
        }

        #endregion

        #region Binding

        /// <summary>
        /// Gets a new SyntaxTreeSemanticModel for the specified syntax tree.
        /// </summary>
        public new SemanticModel GetSemanticModel(SyntaxTree syntaxTree, bool ignoreAccessibility)
        {
            if (syntaxTree == null)
            {
                throw new ArgumentNullException(nameof(syntaxTree));
            }

            if (!_syntaxAndDeclarations.GetLazyState().RootNamespaces.ContainsKey(syntaxTree))
            {
                throw new ArgumentException(string.Format("SyntaxTree '{0}' not found to remove", syntaxTree), nameof(syntaxTree));
            }

            return this.Language.CompilationFactory.CreateSyntaxTreeSemanticModel(this, syntaxTree, ignoreAccessibility);
        }

        // When building symbols from the declaration table (lazily), or inside a type, or when
        // compiling a method body, we may not have a BinderContext in hand for the enclosing
        // scopes.  Therefore, we build them when needed (and cache them) using a ContextBuilder.
        // Since a ContextBuilder is only a cache, and the identity of the ContextBuilders and
        // BinderContexts have no semantic meaning, we can reuse them or rebuild them, whichever is
        // most convenient.  We store them using weak references so that GC pressure will cause them
        // to be recycled.
        private WeakReference<BinderFactory>[] _binderFactories;

        public BinderFactory GetBinderFactory(SyntaxTree syntaxTree)
        {
            var treeNum = GetSyntaxTreeOrdinal(syntaxTree);
            var binderFactories = _binderFactories;
            if (binderFactories == null)
            {
                binderFactories = new WeakReference<BinderFactory>[this.SyntaxTrees.Length];
                binderFactories = Interlocked.CompareExchange(ref _binderFactories, binderFactories, null) ?? binderFactories;
            }

            BinderFactory previousFactory;
            var previousWeakReference = binderFactories[treeNum];
            if (previousWeakReference != null && previousWeakReference.TryGetTarget(out previousFactory))
            {
                return previousFactory;
            }

            return AddNewFactory(syntaxTree, ref binderFactories[treeNum]);
        }

        private BinderFactory AddNewFactory(SyntaxTree syntaxTree, ref WeakReference<BinderFactory> slot)
        {
            var newFactory = new BinderFactory(this, syntaxTree);
            var newWeakReference = new WeakReference<BinderFactory>(newFactory);

            while (true)
            {
                BinderFactory previousFactory;
                WeakReference<BinderFactory> previousWeakReference = slot;
                if (previousWeakReference != null && previousWeakReference.TryGetTarget(out previousFactory))
                {
                    return previousFactory;
                }

                if (Interlocked.CompareExchange(ref slot, newWeakReference, previousWeakReference) == previousWeakReference)
                {
                    return newFactory;
                }
            }
        }

        internal Binder GetBinder(SyntaxReference reference)
        {
            return GetBinderFactory(reference.SyntaxTree).GetBinder(reference.GetSyntax());
        }

        internal Binder GetBinder(SyntaxNode syntax)
        {
            return GetBinderFactory(syntax.SyntaxTree).GetBinder(syntax);
        }

        /// <summary>
        /// Returns imported symbols for the given declaration.
        /// </summary>
        internal Imports GetImports(SingleDeclaration declaration)
        {
            return GetBinderFactory(declaration.SyntaxReference.SyntaxTree).GetBinder(declaration.SyntaxReference.GetSyntax()).GetImports(basesBeingResolved: null);
        }

        private IMetaSymbol CreateGlobalNamespaceAlias()
        {
            return this.Language.CompilationFactory.CreateGlobalNamespaceAlias(this.GlobalNamespace, new InContainerBinder(this.GlobalNamespace, new BuckStopsHereBinder(this)));
        }

        private void CompleteTree(SyntaxTree tree)
        {
            if (_lazyCompilationUnitCompletedTrees == null) Interlocked.CompareExchange(ref _lazyCompilationUnitCompletedTrees, new HashSet<SyntaxTree>(), null);
            lock (_lazyCompilationUnitCompletedTrees)
            {
                if (_lazyCompilationUnitCompletedTrees.Add(tree))
                {
                    // signal the end of the compilation unit
                    EventQueue.TryEnqueue(new CompilationUnitCompletedEvent(this, tree));

                    if (_lazyCompilationUnitCompletedTrees.Count == this.SyntaxTrees.Length)
                    {
                        // if that was the last tree, signal the end of compilation
                        EventQueue.TryEnqueue(new CompilationCompletedEvent(this));
                        EventQueue.PromiseNotToEnqueue();
                        EventQueue.TryComplete();
                    }
                }
            }
        }

        internal void ReportUnusedImports(DiagnosticBag diagnostics, CancellationToken cancellationToken, SyntaxTree filterTree = null)
        {
            if (_lazyImportInfos != null)
            {
                foreach (ImportInfo info in _lazyImportInfos)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    SyntaxTree infoTree = info.Tree;
                    if (filterTree == null || filterTree == infoTree)
                    {
                        TextSpan infoSpan = info.Span;
                        if (!this.IsImportDirectiveUsed(infoTree, infoSpan.Start))
                        {
                            int code = ErrorCode.UnusedSymbol;
                            diagnostics.Add(this.MessageProvider, infoTree.GetLocation(infoSpan), code);
                        }
                    }
                }
            }

            // By definition, a tree is complete when all of its compiler diagnostics have been reported.
            // Since unused imports are the last thing we compute and report, a tree is complete when
            // the unused imports have been reported.
            if (EventQueue != null)
            {
                if (filterTree != null)
                {
                    CompleteTree(filterTree);
                }
                else
                {
                    foreach (var tree in this.SyntaxTrees)
                    {
                        CompleteTree(tree);
                    }
                }
            }
        }

        internal void RecordImport(SyntaxNode syntax)
        {
            RecordImportInternal(syntax);
        }

        private void RecordImportInternal(SyntaxNode syntax)
        {
            LazyInitializer.EnsureInitialized(ref _lazyImportInfos).
                Add(new ImportInfo(syntax.SyntaxTree, syntax.RawKind, syntax.Span));
        }

        private struct ImportInfo : IEquatable<ImportInfo>
        {
            public readonly SyntaxTree Tree;
            public readonly int Kind;
            public readonly TextSpan Span;

            public ImportInfo(SyntaxTree tree, int kind, TextSpan span)
            {
                this.Tree = tree;
                this.Kind = kind;
                this.Span = span;
            }

            public override bool Equals(object obj)
            {
                return (obj is ImportInfo) && Equals((ImportInfo)obj);
            }

            public bool Equals(ImportInfo other)
            {
                return
                    other.Kind == this.Kind &&
                    other.Tree == this.Tree &&
                    other.Span.Equals(this.Span);
            }

            public override int GetHashCode()
            {
                return Hash.Combine(Tree, Span.Start);
            }
        }

        #endregion

        #region Diagnostics

        internal override MessageProvider MessageProvider
        {
            get { return _syntaxAndDeclarations.MessageProvider; }
        }

        /// <summary>
        /// The bag in which semantic analysis should deposit its diagnostics.
        /// </summary>
        internal DiagnosticBag DeclarationDiagnostics
        {
            get
            {
                // We should only be placing diagnostics in this bag until
                // we are done gathering declaration diagnostics. Assert that is
                // the case. But since we have bugs (see https://github.com/dotnet/roslyn/issues/846)
                // we disable the assertion until they are fixed.
                Debug.Assert(!_declarationDiagnosticsFrozen || true);
                if (_lazyDeclarationDiagnostics == null)
                {
                    var diagnostics = new DiagnosticBag();
                    Interlocked.CompareExchange(ref _lazyDeclarationDiagnostics, diagnostics, null);
                }

                return _lazyDeclarationDiagnostics;
            }
        }

        private IEnumerable<Diagnostic> FreezeDeclarationDiagnostics()
        {
            _declarationDiagnosticsFrozen = true;
            var result = _lazyDeclarationDiagnostics?.AsEnumerable() ?? Enumerable.Empty<Diagnostic>();
            return result;
        }

        private DiagnosticBag _lazyDeclarationDiagnostics;
        private bool _declarationDiagnosticsFrozen;

        /// <summary>
        /// A bag in which diagnostics that should be reported after code gen can be deposited.
        /// </summary>
        internal DiagnosticBag AdditionalCodegenWarnings
        {
            get
            {
                return _additionalCodegenWarnings;
            }
        }

        private readonly DiagnosticBag _additionalCodegenWarnings = new DiagnosticBag();

        public DeclarationTable Declarations
        {
            get
            {
                return _syntaxAndDeclarations.GetLazyState().DeclarationTable;
            }
        }

        /// <summary>
        /// Gets the diagnostics produced during the parsing stage of a compilation. There are no diagnostics for declarations or accessor or
        /// method bodies, for example.
        /// </summary>
        public override ImmutableArray<Diagnostic> GetSyntaxDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(CompilationStage.Parse, false, cancellationToken);
        }

        /// <summary>
        /// Gets the diagnostics produced during symbol declaration headers.  There are no diagnostics for semantic analysis.
        /// </summary>
        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(CompilationStage.Declare, false, cancellationToken);
        }

        /// <summary>
        /// Gets the diagnostics produced during the semantic analysis.
        /// </summary>
        public override ImmutableArray<Diagnostic> GetSemanticDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(CompilationStage.Compile, false, cancellationToken);
        }

        /// <summary>
        /// Gets the all the diagnostics for the compilation, including syntax, declaration, and binding. Does not
        /// include any diagnostics that might be produced during emit.
        /// </summary>
        public override ImmutableArray<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(DefaultDiagnosticsStage, true, cancellationToken);
        }

        internal ImmutableArray<Diagnostic> GetDiagnostics(CompilationStage stage, bool includeEarlierStages, CancellationToken cancellationToken)
        {
            var builder = DiagnosticBag.GetInstance();

            if (stage == CompilationStage.Parse || (stage > CompilationStage.Parse && includeEarlierStages))
            {
                var syntaxTrees = this.SyntaxTrees;
                if (this.Options.ConcurrentBuild)
                {
                    var parallelOptions = cancellationToken.CanBeCanceled
                                        ? new ParallelOptions() { CancellationToken = cancellationToken }
                                        : DefaultParallelOptions;

                    Parallel.For(0, syntaxTrees.Length, parallelOptions,
                        i =>
                        {
                            var syntaxTree = syntaxTrees[i];
                            AppendLoadDirectiveDiagnostics(builder, _syntaxAndDeclarations, syntaxTree);
                            builder.AddRange(syntaxTree.GetDiagnostics(cancellationToken));
                        });
                }
                else
                {
                    foreach (var syntaxTree in syntaxTrees)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        AppendLoadDirectiveDiagnostics(builder, _syntaxAndDeclarations, syntaxTree);

                        cancellationToken.ThrowIfCancellationRequested();
                        builder.AddRange(syntaxTree.GetDiagnostics(cancellationToken));
                    }
                }
            }

            if (stage == CompilationStage.Declare || stage > CompilationStage.Declare && includeEarlierStages)
            {
                builder.AddRange(Options.Errors);

                cancellationToken.ThrowIfCancellationRequested();

                // the set of diagnostics related to establishing references.
                builder.AddRange(GetBoundReferenceManager().Diagnostics);

                cancellationToken.ThrowIfCancellationRequested();

                builder.AddRange(GetSourceDeclarationDiagnostics(cancellationToken: cancellationToken));
            }

            cancellationToken.ThrowIfCancellationRequested();

            if (stage == CompilationStage.Compile || stage > CompilationStage.Compile && includeEarlierStages)
            {
                var symbolDiagnostics = DiagnosticBag.GetInstance();
                GetDiagnosticsForAllSymbols(symbolDiagnostics, cancellationToken);
                builder.AddRangeAndFree(symbolDiagnostics);
            }

            // Before returning diagnostics, we filter warnings
            // to honor the compiler options (e.g., /nowarn, /warnaserror and /warn) and the pragmas.
            var result = DiagnosticBag.GetInstance();
            FilterAndAppendAndFreeDiagnostics(result, ref builder);
            return result.ToReadOnlyAndFree();
        }

        private static void AppendLoadDirectiveDiagnostics(DiagnosticBag builder, SyntaxAndDeclarationManager syntaxAndDeclarations, SyntaxTree syntaxTree, Func<IEnumerable<Diagnostic>, IEnumerable<Diagnostic>> locationFilterOpt = null)
        {
            ImmutableArray<SyntaxNode> loadDirectives;
            if (syntaxAndDeclarations.GetLazyState().LoadDirectiveMap.TryGetValue(syntaxTree, out loadDirectives))
            {
                Debug.Assert(!loadDirectives.IsEmpty);
                foreach (var directive in loadDirectives)
                {
                    IEnumerable<Diagnostic> diagnostics = directive.GetDiagnostics();
                    if (locationFilterOpt != null)
                    {
                        diagnostics = locationFilterOpt(diagnostics);
                    }
                    builder.AddRange(diagnostics);
                }
            }
        }

        // Do the steps in compilation to get the symbol diagnostics, but don't actually generate
        // IL or emit an assembly.
        private void GetDiagnosticsForAllSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolCompiler.CompileSymbols(
                compilation: this,
                moduleBeingBuiltOpt: null,
                hasDeclarationErrors: false,
                diagnostics: diagnostics,
                filterOpt: null,
                cancellationToken: cancellationToken);

            this.ReportUnusedImports(diagnostics, cancellationToken);
        }

        protected bool IsSymbolDefinedInSourceTree(IMetaSymbol symbol, SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (symbol == null) return false;
            if (tree == null) return false;

            var declaringReferencesObj = symbol.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
            ImmutableArray<SyntaxReference> declaringReferences = declaringReferencesObj != null ? (ImmutableArray<SyntaxReference>)declaringReferencesObj : ImmutableArray<SyntaxReference>.Empty;
            if (declaringReferences.Length == 0)
            {
                return this.IsSymbolDefinedInSourceTree(symbol.MParent, tree, definedWithinSpan, cancellationToken);
            }

            foreach (var syntaxRef in declaringReferences)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (syntaxRef.SyntaxTree == tree &&
                    (!definedWithinSpan.HasValue || syntaxRef.Span.IntersectsWith(definedWithinSpan.Value)))
                {
                    return true;
                }
            }

            return false;
        }


        private ImmutableArray<Diagnostic> GetDiagnosticsForSymbolsInTree(SyntaxTree tree, TextSpan? span, CancellationToken cancellationToken)
        {
            DiagnosticBag diagnostics = DiagnosticBag.GetInstance();

            SymbolCompiler.CompileSymbols(
                compilation: this,
                moduleBeingBuiltOpt: null,
                hasDeclarationErrors: false,
                diagnostics: diagnostics,
                filterOpt: s => IsSymbolDefinedInSourceTree(s, tree, span, cancellationToken),
                cancellationToken: cancellationToken);

            // Report unused directives only if computing diagnostics for the entire tree.
            // Otherwise we cannot determine if a particular directive is used outside of the given sub-span within the tree.
            if (!span.HasValue || span.Value.Equals(tree.GetRoot(cancellationToken).FullSpan))
            {
                ReportUnusedImports(diagnostics, cancellationToken, tree);
            }

            return diagnostics.ToReadOnlyAndFree();
        }

        /// <summary>
        /// Filter out warnings based on the compiler options (/nowarn, /warn and /warnaserror) and the pragma warning directives.
        /// 'incoming' is freed.
        /// </summary>
        /// <returns>True when there is no error or warning treated as an error.</returns>
        internal override bool FilterAndAppendAndFreeDiagnostics(DiagnosticBag accumulator, ref DiagnosticBag incoming)
        {
            bool result = FilterAndAppendDiagnostics(accumulator, incoming.AsEnumerableWithoutResolution());
            incoming.Free();
            incoming = null;
            return result;
        }

        /// <summary>
        /// Filter out warnings based on the compiler options (/nowarn, /warn and /warnaserror) and the pragma warning directives.
        /// </summary>
        /// <returns>True when there is no error.</returns>
        private bool FilterAndAppendDiagnostics(DiagnosticBag accumulator, IEnumerable<Diagnostic> incoming)
        {
            bool hasError = false;
            bool reportSuppressedDiagnostics = Options.ReportSuppressedDiagnostics;

            foreach (Diagnostic d in incoming)
            {
                var filtered = _options.FilterDiagnostic(d);
                if (filtered == null ||
                    (!reportSuppressedDiagnostics && filtered.IsSuppressed))
                {
                    continue;
                }
                else if (filtered.Severity == DiagnosticSeverity.Error)
                {
                    hasError = true;
                }

                accumulator.Add(filtered);
            }

            return !hasError;
        }

        private ImmutableArray<Diagnostic> GetSourceDeclarationDiagnostics(SyntaxTree syntaxTree = null, TextSpan? filterSpanWithinTree = null, Func<IEnumerable<Diagnostic>, SyntaxTree, TextSpan?, IEnumerable<Diagnostic>> locationFilterOpt = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            GlobalImports.Complete(cancellationToken);

            SourceLocation location = null;
            if (syntaxTree != null)
            {
                var root = syntaxTree.GetRoot(cancellationToken);
                location = filterSpanWithinTree.HasValue ?
                    new SourceLocation(syntaxTree, filterSpanWithinTree.Value) :
                    new SourceLocation(root);
            }

            this.ForceCompleteModel(location, cancellationToken);

            var result = this.FreezeDeclarationDiagnostics();

            if (locationFilterOpt != null)
            {
                Debug.Assert(syntaxTree != null);
                result = locationFilterOpt(result, syntaxTree, filterSpanWithinTree);
            }

            return result.ToImmutableArray();
        }

        protected abstract void ForceCompleteModel(SourceLocation location, CancellationToken cancellationToken = default(CancellationToken));

        protected abstract void ForceCompleteSymbol(IMetaSymbol symbol, SourceLocation location, CancellationToken cancellationToken = default(CancellationToken));

        private static IEnumerable<Diagnostic> FilterDiagnosticsByLocation(IEnumerable<Diagnostic> diagnostics, SyntaxTree tree, TextSpan? filterSpanWithinTree)
        {
            foreach (var diagnostic in diagnostics)
            {
                if (diagnostic.HasIntersectingLocation(tree, filterSpanWithinTree))
                {
                    yield return diagnostic;
                }
            }
        }

        internal ImmutableArray<Diagnostic> GetDiagnosticsForSyntaxTree(
            CompilationStage stage,
            SyntaxTree syntaxTree,
            TextSpan? filterSpanWithinTree,
            bool includeEarlierStages,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var builder = DiagnosticBag.GetInstance();
            if (stage == CompilationStage.Parse || (stage > CompilationStage.Parse && includeEarlierStages))
            {
                AppendLoadDirectiveDiagnostics(builder, _syntaxAndDeclarations, syntaxTree,
                    diagnostics => FilterDiagnosticsByLocation(diagnostics, syntaxTree, filterSpanWithinTree));

                var syntaxDiagnostics = syntaxTree.GetDiagnostics();
                syntaxDiagnostics = FilterDiagnosticsByLocation(syntaxDiagnostics, syntaxTree, filterSpanWithinTree);
                builder.AddRange(syntaxDiagnostics);
            }

            cancellationToken.ThrowIfCancellationRequested();
            if (stage == CompilationStage.Declare || (stage > CompilationStage.Declare && includeEarlierStages))
            {
                var declarationDiagnostics = GetSourceDeclarationDiagnostics(syntaxTree, filterSpanWithinTree, FilterDiagnosticsByLocation, cancellationToken);
                Debug.Assert(declarationDiagnostics.All(d => d.HasIntersectingLocation(syntaxTree, filterSpanWithinTree)));
                builder.AddRange(declarationDiagnostics);
            }

            cancellationToken.ThrowIfCancellationRequested();

            if (stage == CompilationStage.Compile || (stage > CompilationStage.Compile && includeEarlierStages))
            {
                //remove some errors that don't have locations in the tree, like "no suitable main method."
                //Members in trees other than the one being examined are not compiled. This includes field
                //initializers which can result in 'field is never initialized' warnings for fields in partial 
                //types when the field is in a different source file than the one for which we're getting diagnostics. 
                //For that reason the bag must be also filtered by tree.
                IEnumerable<Diagnostic> methodBodyDiagnostics = GetDiagnosticsForSymbolsInTree(syntaxTree, filterSpanWithinTree, cancellationToken);

                // TODO: Enable the below commented assert and remove the filtering code in the next line.
                //       GetDiagnosticsForMethodBodiesInTree seems to be returning diagnostics with locations that don't satisfy the filter tree/span, this must be fixed.
                // Debug.Assert(methodBodyDiagnostics.All(d => DiagnosticContainsLocation(d, syntaxTree, filterSpanWithinTree)));
                methodBodyDiagnostics = FilterDiagnosticsByLocation(methodBodyDiagnostics, syntaxTree, filterSpanWithinTree);

                builder.AddRange(methodBodyDiagnostics);
            }

            // Before returning diagnostics, we filter warnings
            // to honor the compiler options (/nowarn, /warnaserror and /warn) and the pragmas.
            var result = DiagnosticBag.GetInstance();
            FilterAndAppendAndFreeDiagnostics(result, ref builder);
            return result.ToReadOnlyAndFree();
        }

        #endregion

        #region Common Members

        protected override SemanticModel CommonGetSemanticModel(SyntaxTree syntaxTree, bool ignoreAccessibility)
        {
            return this.GetSemanticModel((SyntaxTree)syntaxTree, ignoreAccessibility);
        }

        protected override IEnumerable<SyntaxTree> CommonSyntaxTrees
        {
            get
            {
                return this.SyntaxTrees;
            }
        }

        protected override Compilation CommonAddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            return this.AddSyntaxTrees(trees);
        }

        protected override Compilation CommonRemoveSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            return this.RemoveSyntaxTrees(trees);
        }

        protected override Compilation CommonRemoveAllSyntaxTrees()
        {
            return this.RemoveAllSyntaxTrees();
        }

        protected override Compilation CommonReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            return this.ReplaceSyntaxTree((SyntaxTree)oldTree, (SyntaxTree)newTree);
        }

        protected override bool CommonContainsSyntaxTree(SyntaxTree syntaxTree)
        {
            return this.ContainsSyntaxTree(syntaxTree);
        }

        internal override int CompareSourceLocations(Location loc1, Location loc2)
        {
            Debug.Assert(loc1.IsInSource);
            Debug.Assert(loc2.IsInSource);

            var comparison = CompareSyntaxTreeOrdering(loc1.SourceTree, loc2.SourceTree);
            if (comparison != 0)
            {
                return comparison;
            }

            return loc1.SourceSpan.Start - loc2.SourceSpan.Start;
        }

        /// <summary>
        /// Return true if there is a source declaration symbol name that meets given predicate.
        /// </summary>
        public override bool ContainsSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (filter == SymbolFilter.None)
            {
                throw new ArgumentException("SearchCriteria is expected.", nameof(filter));
            }

            return this.Declarations.ContainsName(predicate, filter, cancellationToken);
        }

        /// <summary>
        /// Return source declaration symbols whose name meets given predicate.
        /// </summary>
        public override IEnumerable<IMetaSymbol> GetSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (filter == SymbolFilter.None)
            {
                throw new ArgumentException("SearchCriteria is expected.", nameof(filter));
            }

            return this.NameResolution.GetSymbolsWithName(predicate, filter, cancellationToken);
        }

        #endregion

        internal void SymbolDeclaredEvent(IMetaSymbol symbol)
        {
            EventQueue?.TryEnqueue(new SymbolDeclaredCompilationEvent(this, symbol));
        }
    }
}

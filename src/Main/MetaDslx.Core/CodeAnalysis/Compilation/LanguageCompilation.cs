// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeGen;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;
    using CSharpCompilation = Microsoft.CodeAnalysis.CSharp.CSharpCompilation;
    using MessageProvider = Microsoft.CodeAnalysis.CSharp.MessageProvider;
    using Binder = MetaDslx.CodeAnalysis.Binding.Binder;

    /// <summary>
    /// The compilation object is an immutable representation of a single invocation of the
    /// compiler. Although immutable, a compilation is also on-demand, and will realize and cache
    /// data as necessary. A compilation can produce a new compilation from existing compilation
    /// with the application of small deltas. In many cases, it is more efficient than creating a
    /// new compilation from scratch, as the new compilation can reuse information from the old
    /// compilation.
    /// </summary>
    public abstract partial class LanguageCompilation : CompilationAdapter, ICompilation
    {
        protected static readonly SyntaxTree[] NoSyntaxTrees = new SyntaxTree[0];

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //
        // Changes to the public interface of this class should remain synchronized with the VB
        // version. Do not make any changes to the public interface without making the corresponding
        // change to the VB version.
        //
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        internal static readonly ParallelOptions DefaultParallelOptions = new ParallelOptions();

        private readonly Language _language;

        private readonly LanguageCompilationOptions _options;
        private readonly Lazy<Imports> _globalImports;
        private readonly Lazy<Imports> _previousSubmissionImports;
        private readonly Lazy<AliasSymbol> _globalNamespaceAlias;  // alias symbol used to resolve "global::".
        private readonly Lazy<ImplicitNamedTypeSymbol> _scriptClass;

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

        /// <summary>
        /// Manages anonymous types declared in this compilation. Unifies types that are structurally equivalent.
        /// </summary>
        private readonly AnonymousTypeManager _anonymousTypeManager;

        private NamespaceSymbol _lazyGlobalNamespace;

        internal readonly BuiltInOperators builtInOperators;

        /// <summary>
        /// The <see cref="SourceAssemblySymbol"/> for this compilation. Do not access directly, use Assembly property
        /// instead. This field is lazily initialized by ReferenceManager, ReferenceManager.CacheLockObject must be locked
        /// while ReferenceManager "calculates" the value and assigns it, several threads must not perform duplicate
        /// "calculation" simultaneously.
        /// </summary>
        private SourceAssemblySymbol _lazyAssemblySymbol;

        /// <summary>
        /// Holds onto data related to reference binding.
        /// The manager is shared among multiple compilations that we expect to have the same result of reference binding.
        /// In most cases this can be determined without performing the binding. If the compilation however contains a circular
        /// metadata reference (a metadata reference that refers back to the compilation) we need to avoid sharing of the binding results.
        /// We do so by creating a new reference manager for such compilation.
        /// </summary>
        private ReferenceManager _referenceManager;
        internal readonly CSharpCompilation CSharpCompilationForReferenceManager;

        private readonly SyntaxAndDeclarationManager _syntaxAndDeclarations;

        /// <summary>
        /// Contains the main method of this assembly, if there is one.
        /// </summary>
        private EntryPoint _lazyEntryPoint;

        /// <summary>
        /// The set of trees for which a <see cref="CompilationUnitCompletedEvent"/> has been added to the queue.
        /// </summary>
        private HashSet<SyntaxTree> _lazyCompilationUnitCompletedTrees;

        public new Language Language => this.LanguageCore;

        protected override Language LanguageCore => _language;

        public override bool IsCaseSensitive
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// The options the compilation was created with.
        /// </summary>
        public new LanguageCompilationOptions Options
        {
            get
            {
                return _options;
            }
        }

        internal AnonymousTypeManager AnonymousTypeManager
        {
            get
            {
                return _anonymousTypeManager;
            }
        }

        internal override CommonAnonymousTypeManager CommonAnonymousTypeManager
        {
            get
            {
                return AnonymousTypeManager;
            }
        }

        /// <summary>
        /// The language version that was used to parse the syntax trees of this compilation.
        /// </summary>
        public LanguageVersion LanguageVersion
        {
            get;
        }

        protected override INamedTypeSymbol CommonCreateErrorTypeSymbol(INamespaceOrTypeSymbol container, string name, int arity)
        {
            return new ExtendedErrorTypeSymbol(
                       container.EnsureLanguageSymbolOrNull<INamespaceOrTypeSymbol, NamespaceOrTypeSymbol>(nameof(container)),
                       name, arity > 0 ? name + "`" + arity : name, errorInfo: null);
        }

        protected override INamespaceSymbol CommonCreateErrorNamespaceSymbol(INamespaceSymbol container, string name)
        {
            return new MissingNamespaceSymbol(
                       container.EnsureLanguageSymbolOrNull<INamespaceSymbol, NamespaceSymbol>(nameof(container)),
                       name);
        }

        #region Constructors and Factories

        protected LanguageCompilation(
            string assemblyName,
            LanguageCompilationOptions options,
            IEnumerable<MetadataReference> references,
            LanguageCompilation previousSubmission,
            Type submissionReturnType,
            Type hostObjectType,
            bool isSubmission,
            ReferenceManager referenceManager,
            bool reuseReferenceManager,
            SyntaxAndDeclarationManager syntaxAndDeclarations,
            AsyncQueue<CompilationEvent> eventQueue = null)
            : base(assemblyName, ValidateReferences<LanguageCompilationReference>(references), SyntaxTreeCommonFeatures(syntaxAndDeclarations.ExternalSyntaxTrees), isSubmission, eventQueue)
        {
            _options = options;
            _language = _options.Language;

            this.builtInOperators = new BuiltInOperators(this);
            _scriptClass = new Lazy<ImplicitNamedTypeSymbol>(BindScriptClass);
            _globalImports = new Lazy<Imports>(BindGlobalImports);
            _previousSubmissionImports = new Lazy<Imports>(ExpandPreviousSubmissionImports);
            _globalNamespaceAlias = new Lazy<AliasSymbol>(CreateGlobalNamespaceAlias);
            _anonymousTypeManager = new AnonymousTypeManager(this);
            this.LanguageVersion = CommonLanguageVersion(syntaxAndDeclarations.ExternalSyntaxTrees);

            if (isSubmission)
            {
                Debug.Assert(previousSubmission == null || previousSubmission.HostObjectType == hostObjectType);
                this.ScriptCompilationInfo = new LanguageScriptCompilationInfo(previousSubmission, submissionReturnType, hostObjectType);
            }
            else
            {
                Debug.Assert(previousSubmission == null && submissionReturnType == null && hostObjectType == null);
            }

            var csharpReferences = ReferenceManager.CSharpReferences(references);
            CSharpCompilationForReferenceManager = CSharpCompilation.Create(assemblyName, null, csharpReferences, options.ToCSharp());

            if (reuseReferenceManager)
            {
                referenceManager.AssertCanReuseForCompilation(this);
                _referenceManager = referenceManager;
            }
            else
            {
                _referenceManager = new ReferenceManager(MakeSourceAssemblySimpleName());
            }

            _syntaxAndDeclarations = syntaxAndDeclarations;

            Debug.Assert((object)_lazyAssemblySymbol == null);
            if (EventQueue != null) EventQueue.TryEnqueue(new CompilationStartedEvent(this));
        }


        internal override void ValidateDebugEntryPoint(IMethodSymbol debugEntryPoint, DiagnosticBag diagnostics)
        {
            Debug.Assert(debugEntryPoint != null);

            // Debug entry point has to be a method definition from this compilation.
            var methodSymbol = debugEntryPoint as MethodSymbol;
            if (methodSymbol?.DeclaringCompilation != this || !methodSymbol.IsDefinition)
            {
                diagnostics.Add(InternalErrorCode.ERR_DebugEntryPointNotSourceMethodDefinition, Location.None);
            }
        }

        private static LanguageVersion CommonLanguageVersion(ImmutableArray<SyntaxTree> syntaxTrees)
        {
            LanguageVersion result = null;
            foreach (var tree in syntaxTrees)
            {
                var version = ((LanguageParseOptions)tree.Options).LanguageVersion;
                if (result == null)
                {
                    result = version;
                }
                else if (result != version)
                {
                    throw new ArgumentException(CodeAnalysisResources.InconsistentLanguageVersions, nameof(syntaxTrees));
                }
            }

            return result ?? LanguageVersion.Default; // TODO:MetaDslx .MapSpecifiedToEffectiveVersion();
        }

        protected abstract LanguageCompilation CreateNew(
            string assemblyName,
            LanguageCompilationOptions options,
            IEnumerable<MetadataReference> references,
            LanguageCompilation previousSubmission,
            Type submissionReturnType,
            Type hostObjectType,
            bool isSubmission,
            ReferenceManager referenceManager,
            bool reuseReferenceManager,
            SyntaxAndDeclarationManager syntaxAndDeclarations,
            AsyncQueue<CompilationEvent> eventQueue = null);

        /// <summary>
        /// Create a duplicate of this compilation with different symbol instances.
        /// </summary>
        public new LanguageCompilation Clone()
        {
            return this.CreateNew(
                this.AssemblyName,
                _options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                _referenceManager,
                reuseReferenceManager: true,
                syntaxAndDeclarations: _syntaxAndDeclarations);
        }

        protected LanguageCompilation Update(
            ReferenceManager referenceManager,
            bool reuseReferenceManager,
            SyntaxAndDeclarationManager syntaxAndDeclarations)
        {
            return this.CreateNew(
                this.AssemblyName,
                _options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                referenceManager,
                reuseReferenceManager,
                syntaxAndDeclarations);
        }

        /// <summary>
        /// Creates a new compilation with the specified name.
        /// </summary>
        public new LanguageCompilation WithAssemblyName(string assemblyName)
        {
            // Can't reuse references since the source assembly name changed and the referenced symbols might
            // have internals-visible-to relationship with this compilation or they might had a circular reference
            // to this compilation.

            return this.CreateNew(
                assemblyName,
                _options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                _referenceManager,
                reuseReferenceManager: assemblyName == this.AssemblyName,
                syntaxAndDeclarations: _syntaxAndDeclarations);
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <remarks>
        /// The new <see cref="LanguageCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying
        /// metadata as soon as the are needed.
        ///
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new LanguageCompilation WithReferences(IEnumerable<MetadataReference> references)
        {
            // References might have changed, don't reuse reference manager.
            // Don't even reuse observed metadata - let the manager query for the metadata again.

            return this.CreateNew(
                this.AssemblyName,
                _options,
                ValidateReferences<LanguageCompilationReference>(references),
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                referenceManager: null,
                reuseReferenceManager: false,
                syntaxAndDeclarations: _syntaxAndDeclarations);
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        public new LanguageCompilation WithReferences(params MetadataReference[] references)
        {
            return this.WithReferences((IEnumerable<MetadataReference>)references);
        }

        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public LanguageCompilation WithOptions(LanguageCompilationOptions options)
        {
            var oldOptions = this.Options;
            bool reuseReferenceManager = oldOptions.CanReuseCompilationReferenceManager(options);
            bool reuseSyntaxAndDeclarationManager = oldOptions.ScriptClassName == options.ScriptClassName &&
                oldOptions.SourceReferenceResolver == options.SourceReferenceResolver;

            return this.CreateNew(
                this.AssemblyName,
                options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                _referenceManager,
                reuseReferenceManager,
                reuseSyntaxAndDeclarationManager ?
                    _syntaxAndDeclarations :
                    new SyntaxAndDeclarationManager(
                        _syntaxAndDeclarations.ExternalSyntaxTrees,
                        options.ScriptClassName,
                        options.SourceReferenceResolver,
                        _syntaxAndDeclarations.Language,
                        _syntaxAndDeclarations.IsSubmission,
                        state: null));
        }

        /// <summary>
        /// Returns a new compilation with the given compilation set as the previous submission.
        /// </summary>
        public LanguageCompilation WithScriptCompilationInfo(LanguageScriptCompilationInfo info)
        {
            if (info == ScriptCompilationInfo)
            {
                return this;
            }

            // Reference binding doesn't depend on previous submission so we can reuse it.

            return this.CreateNew(
                this.AssemblyName,
                _options,
                this.ExternalReferences,
                info?.PreviousScriptCompilation,
                info?.ReturnTypeOpt,
                info?.GlobalsType,
                info != null,
                _referenceManager,
                reuseReferenceManager: true,
                syntaxAndDeclarations: _syntaxAndDeclarations);
        }

        /// <summary>
        /// Returns a new compilation with a given event queue.
        /// </summary>
        internal override Compilation WithEventQueue(AsyncQueue<CompilationEvent> eventQueue)
        {
            return this.CreateNew(
                this.AssemblyName,
                _options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                _referenceManager,
                reuseReferenceManager: true,
                syntaxAndDeclarations: _syntaxAndDeclarations,
                eventQueue: eventQueue);
        }

        #endregion

        #region Submission

        public new LanguageScriptCompilationInfo ScriptCompilationInfo { get; }
        internal override ScriptCompilationInfo CommonScriptCompilationInfo => ScriptCompilationInfo;

        internal LanguageCompilation PreviousSubmission => ScriptCompilationInfo?.PreviousScriptCompilation;

        internal override bool HasSubmissionResult()
        {
            Debug.Assert(IsSubmission);

            // A submission may be empty or comprised of a single script file.
            var tree = _syntaxAndDeclarations.ExternalSyntaxTrees.SingleOrDefault();
            if (tree == null)
            {
                return false;
            }

            var root = tree.GetRoot();
            if (root.HasErrors)
            {
                return false;
            }

            // TODO:MetaDslx - in descendants:
            // Are there any top-level return statements?
            // Is there a trailing expression?

            return false;
        }

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
            return syntaxTree != null && _syntaxAndDeclarations.GetLazyState().RootNamespaces.ContainsKey(syntaxTree);
        }

        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new LanguageCompilation AddSyntaxTrees(params SyntaxTree[] trees)
        {
            return AddSyntaxTrees((IEnumerable<SyntaxTree>)trees);
        }

        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new LanguageCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            if (trees == null)
            {
                throw new ArgumentNullException(nameof(trees));
            }

            if (trees.IsEmpty())
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
            foreach (var tree in trees.Cast<LanguageSyntaxTree>())
            {
                if (tree == null)
                {
                    throw new ArgumentNullException($"{nameof(trees)}[{i}]");
                }

                if (!tree.HasCompilationUnitRoot)
                {
                    throw new ArgumentException(CSharpResources.TreeMustHaveARootNodeWith, $"{nameof(trees)}[{i}]");
                }

                if (externalSyntaxTrees.Contains(tree))
                {
                    throw new ArgumentException(CSharpResources.SyntaxTreeAlreadyPresent, $"{nameof(trees)}[{i}]");
                }

                if (this.IsSubmission && tree.Options.Kind == SourceCodeKind.Regular)
                {
                    throw new ArgumentException(CSharpResources.SubmissionCanOnlyInclude, $"{nameof(trees)}[{i}]");
                }

                externalSyntaxTrees.Add(tree);
                reuseReferenceManager &= !tree.HasReferenceOrLoadDirectives;

                i++;
            }
            externalSyntaxTrees.Free();

            if (this.IsSubmission && i > 1)
            {
                throw new ArgumentException(CSharpResources.SubmissionCanHaveAtMostOne, nameof(trees));
            }

            syntaxAndDeclarations = syntaxAndDeclarations.AddSyntaxTrees(trees);

            return Update(_referenceManager, reuseReferenceManager, syntaxAndDeclarations);
        }

        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new LanguageCompilation RemoveSyntaxTrees(params SyntaxTree[] trees)
        {
            return RemoveSyntaxTrees((IEnumerable<SyntaxTree>)trees);
        }

        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new LanguageCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            if (trees == null)
            {
                throw new ArgumentNullException(nameof(trees));
            }

            if (trees.IsEmpty())
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
            foreach (var tree in trees.Cast<LanguageSyntaxTree>())
            {
                if (!externalSyntaxTrees.Contains(tree))
                {
                    // Check to make sure this is not a #load'ed tree.
                    var loadedSyntaxTreeMap = syntaxAndDeclarations.GetLazyState().LoadedSyntaxTreeMap;
                    if (SyntaxAndDeclarationManager.IsLoadedSyntaxTree(tree, loadedSyntaxTreeMap))
                    {
                        throw new ArgumentException(CSharpResources.SyntaxTreeFromLoadNoRemoveReplace, $"{nameof(trees)}[{i}]");
                    }

                    throw new ArgumentException(CSharpResources.SyntaxTreeNotFoundToRemove, $"{nameof(trees)}[{i}]");
                }

                removeSet.Add(tree);
                reuseReferenceManager &= !tree.HasReferenceOrLoadDirectives;

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
        public new LanguageCompilation RemoveAllSyntaxTrees()
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
        public new LanguageCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            // this is just to force a cast exception
            oldTree = (LanguageSyntaxTree)oldTree;
            newTree = (LanguageSyntaxTree)newTree;

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
                throw new ArgumentException(CSharpResources.TreeMustHaveARootNodeWith, nameof(newTree));
            }

            var syntaxAndDeclarations = _syntaxAndDeclarations;
            var externalSyntaxTrees = syntaxAndDeclarations.ExternalSyntaxTrees;
            if (!externalSyntaxTrees.Contains(oldTree))
            {
                // Check to see if this is a #load'ed tree.
                var loadedSyntaxTreeMap = syntaxAndDeclarations.GetLazyState().LoadedSyntaxTreeMap;
                if (SyntaxAndDeclarationManager.IsLoadedSyntaxTree(oldTree, loadedSyntaxTreeMap))
                {
                    throw new ArgumentException(CSharpResources.SyntaxTreeFromLoadNoRemoveReplace, nameof(oldTree));
                }

                throw new ArgumentException(CSharpResources.SyntaxTreeNotFoundToRemove, nameof(oldTree));
            }

            if (externalSyntaxTrees.Contains(newTree))
            {
                throw new ArgumentException(CSharpResources.SyntaxTreeAlreadyPresent, nameof(newTree));
            }

            // TODO(tomat): Consider comparing #r's of the old and the new tree. If they are exactly the same we could still reuse.
            // This could be a perf win when editing a script file in the IDE. The services create a new compilation every keystroke
            // that replaces the tree with a new one.
            var reuseReferenceManager = !oldTree.HasReferenceOrLoadDirectives() && !newTree.HasReferenceOrLoadDirectives();
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
        protected new static ImmutableArray<MetadataReference> ValidateReferences<T>(IEnumerable<MetadataReference> references)
            where T : CompilationReference
        {
            var result = references.AsImmutableOrEmpty();
            for (int i = 0; i < result.Length; i++)
            {
                var reference = result[i];
                if (reference == null)
                {
                    throw new ArgumentNullException($"{nameof(references)}[{i}]");
                }

                var peReference = reference as PortableExecutableReference;
                var customReference = reference as CustomReference;
                if (peReference == null && customReference == null && !(reference is T))
                {
                    Debug.Assert(reference is UnresolvedMetadataReference || reference is CompilationReference);
                    throw new ArgumentException(string.Format(CodeAnalysisResources.ReferenceOfTypeIsInvalid1, reference.GetType()),
                                    $"{nameof(references)}[{i}]");
                }
            }

            return result;
        }

        internal override CommonReferenceManager CommonGetBoundReferenceManager()
        {
            return CSharpCompilationForReferenceManager.GetBoundReferenceManager();
        }

        internal new ReferenceManager GetBoundReferenceManager()
        {
            if ((object)_lazyAssemblySymbol == null)
            {
                _referenceManager.CreateSourceAssemblyForCompilation(this);
                Debug.Assert((object)_lazyAssemblySymbol != null);
            }

            // referenceManager can only be accessed after we initialized the lazyAssemblySymbol.
            // In fact, initialization of the assembly symbol might change the reference manager.
            return _referenceManager;
        }

        // for testing only:
        internal bool ReferenceManagerEquals(LanguageCompilation other)
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

        internal override IDictionary<(string path, string content), MetadataReference> ReferenceDirectiveMap
            => GetBoundReferenceManager().ReferenceDirectiveMap;

        // for testing purposes
        internal IEnumerable<string> ExternAliases
        {
            get
            {
                return GetBoundReferenceManager().ExternAliases;
            }
        }

        /// <summary>
        /// Gets the <see cref="AssemblySymbol"/> or <see cref="ModuleSymbol"/> for a metadata reference used to create this compilation.
        /// </summary>
        /// <returns><see cref="AssemblySymbol"/> or <see cref="ModuleSymbol"/> corresponding to the given reference or null if there is none.</returns>
        /// <remarks>
        /// Uses object identity when comparing two references.
        /// </remarks>
        internal new Symbol GetAssemblyOrModuleSymbol(MetadataReference reference)
        {
            if (reference == null)
            {
                throw new ArgumentNullException(nameof(reference));
            }

            if (reference.Properties.Kind == MetadataImageKind.Assembly)
            {
                return GetBoundReferenceManager().GetReferencedAssemblySymbol(reference);
            }
            else
            {
                Debug.Assert(reference.Properties.Kind == MetadataImageKind.Module);
                int index = GetBoundReferenceManager().GetReferencedModuleIndex(reference);
                return index < 0 ? null : this.Assembly.Modules[index];
            }
        }

        public override IEnumerable<AssemblyIdentity> ReferencedAssemblyNames
        {
            get
            {
                return Assembly.Modules.SelectMany(module => module.ReferencedAssemblies);
            }
        }

        /// <summary>
        /// All reference directives used in this compilation.
        /// </summary>
        public new IEnumerable<Syntax.ReferenceDirective> ReferenceDirectives
        {
            get { return this.Declarations.ReferenceDirectives; }
        }

        protected override IEnumerable<Syntax.ReferenceDirective> ReferenceDirectivesCore => this.ReferenceDirectives;

        /// <summary>
        /// Returns a metadata reference that a given #r resolves to.
        /// </summary>
        /// <param name="directive">#r directive.</param>
        /// <returns>Metadata reference the specified directive resolves to, or null if the <paramref name="directive"/> doesn't match any #r directive in the compilation.</returns>
        public MetadataReference GetDirectiveReference(Syntax.ReferenceDirective directive)
        {
            MetadataReference reference;
            return ReferenceDirectiveMap.TryGetValue((directive.SyntaxTree.FilePath, directive.File), out reference) ? reference : null;
        }

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new LanguageCompilation AddReferences(params MetadataReference[] references)
        {
            return (LanguageCompilation)base.AddReferences(references);
        }

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new LanguageCompilation AddReferences(IEnumerable<MetadataReference> references)
        {
            return (LanguageCompilation)base.AddReferences(references);
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new LanguageCompilation RemoveReferences(params MetadataReference[] references)
        {
            return (LanguageCompilation)base.RemoveReferences(references);
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new LanguageCompilation RemoveReferences(IEnumerable<MetadataReference> references)
        {
            return (LanguageCompilation)base.RemoveReferences(references);
        }

        /// <summary>
        /// Creates a new compilation without any metadata references
        /// </summary>
        public new LanguageCompilation RemoveAllReferences()
        {
            return (LanguageCompilation)base.RemoveAllReferences();
        }

        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata reference.
        /// </summary>
        public new LanguageCompilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference)
        {
            return (LanguageCompilation)base.ReplaceReference(oldReference, newReference);
        }

        public override CompilationReference ToMetadataReference(ImmutableArray<string> aliases = default(ImmutableArray<string>), bool embedInteropTypes = false)
        {
            return new LanguageCompilationReference(this, aliases, embedInteropTypes);
        }

        /// <summary>
        /// Get all modules in this compilation, including the source module, added modules, and all
        /// modules of referenced assemblies that do not come from an assembly with an extern alias.
        /// Metadata imported from aliased assemblies is not visible at the source level except through
        /// the use of an extern alias directive. So exclude them from this list which is used to construct
        /// the global namespace.
        /// </summary>
        private void GetAllUnaliasedModules(ArrayBuilder<ModuleSymbol> modules)
        {
            // NOTE: This includes referenced modules - they count as modules of the compilation assembly.
            modules.AddRange(Assembly.Modules);

            var referenceManager = GetBoundReferenceManager();

            for (int i = 0; i < referenceManager.ReferencedAssemblies.Length; i++)
            {
                if (referenceManager.DeclarationsAccessibleWithoutAlias(i))
                {
                    modules.AddRange(referenceManager.ReferencedAssemblies[i].Modules);
                }
            }
        }

        /// <summary>
        /// Return a list of assembly symbols than can be accessed without using an alias.
        /// For example:
        ///   1) /r:A.dll /r:B.dll -> A, B
        ///   2) /r:Goo=A.dll /r:B.dll -> B
        ///   3) /r:Goo=A.dll /r:A.dll -> A
        /// </summary>
        internal void GetUnaliasedReferencedAssemblies(ArrayBuilder<AssemblySymbol> assemblies)
        {
            var referenceManager = GetBoundReferenceManager();

            for (int i = 0; i < referenceManager.ReferencedAssemblies.Length; i++)
            {
                if (referenceManager.DeclarationsAccessibleWithoutAlias(i))
                {
                    assemblies.Add(referenceManager.ReferencedAssemblies[i]);
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="MetadataReference"/> that corresponds to the assembly symbol.
        /// </summary>
        public new MetadataReference GetMetadataReference(IAssemblySymbol assemblySymbol)
        {
            return base.GetMetadataReference(assemblySymbol);
        }

        #endregion

        #region Symbols

        public ImmutableModel Model
        {
            get
            {
                this.ForceComplete();
                return this.ModelBuilder.ToImmutable();
            }
        }

        public MutableModel ModelBuilder => this.SourceAssembly.SourceModule.ModelBuilder;

        /// <summary>
        /// The AssemblySymbol that represents the assembly being created.
        /// </summary>
        internal SourceAssemblySymbol SourceAssembly
        {
            get
            {
                GetBoundReferenceManager();
                return _lazyAssemblySymbol;
            }
        }

        /// <summary>
        /// The AssemblySymbol that represents the assembly being created.
        /// </summary>
        internal new AssemblySymbol Assembly
        {
            get
            {
                return SourceAssembly;
            }
        }

        /// <summary>
        /// Get a ModuleSymbol that refers to the module being created by compiling all of the code.
        /// By getting the GlobalNamespace property of that module, all of the namespaces and types
        /// defined in source code can be obtained.
        /// </summary>
        internal new ModuleSymbol SourceModule
        {
            get
            {
                return Assembly.Modules[0];
            }
        }

        /// <summary>
        /// Gets the root namespace that contains all namespaces and types defined in source code or in
        /// referenced metadata, merged into a single namespace hierarchy.
        /// </summary>
        internal new NamespaceSymbol GlobalNamespace
        {
            get
            {
                if ((object)_lazyGlobalNamespace == null)
                {
                    // Get the root namespace from each module, and merge them all together
                    // Get all modules in this compilation, ones referenced directly by the compilation
                    // as well as those referenced by all referenced assemblies.

                    var modules = ArrayBuilder<ModuleSymbol>.GetInstance();
                    GetAllUnaliasedModules(modules);

                    var result = MergedNamespaceSymbol.Create(
                        new NamespaceExtent(this),
                        null,
                        modules.SelectDistinct(m => m.GlobalNamespace));

                    modules.Free();

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
        internal new NamespaceSymbol GetCompilationNamespace(INamespaceSymbol namespaceSymbol)
        {
            if (namespaceSymbol is NamespaceSymbol &&
                namespaceSymbol.NamespaceKind == NamespaceKind.Compilation &&
                namespaceSymbol.ContainingCompilation == this)
            {
                return (NamespaceSymbol)namespaceSymbol;
            }

            var containingNamespace = namespaceSymbol.ContainingNamespace;
            if (containingNamespace == null)
            {
                return this.GlobalNamespace;
            }

            var current = GetCompilationNamespace(containingNamespace);
            if ((object)current != null)
            {
                return current.GetNestedNamespace(namespaceSymbol.Name);
            }

            return null;
        }

        private ConcurrentDictionary<string, NamespaceSymbol> _externAliasTargets;

        internal bool GetExternAliasTarget(string aliasName, out NamespaceSymbol @namespace)
        {
            if (_externAliasTargets == null)
            {
                Interlocked.CompareExchange(ref _externAliasTargets, new ConcurrentDictionary<string, NamespaceSymbol>(), null);
            }
            else if (_externAliasTargets.TryGetValue(aliasName, out @namespace))
            {
                return !(@namespace is MissingNamespaceSymbol);
            }

            ArrayBuilder<NamespaceSymbol> builder = null;
            var referenceManager = GetBoundReferenceManager();
            for (int i = 0; i < referenceManager.ReferencedAssemblies.Length; i++)
            {
                if (referenceManager.AliasesOfReferencedAssemblies[i].Contains(aliasName))
                {
                    builder = builder ?? ArrayBuilder<NamespaceSymbol>.GetInstance();
                    builder.Add(referenceManager.ReferencedAssemblies[i].GlobalNamespace);
                }
            }

            bool foundNamespace = builder != null;

            // We want to cache failures as well as successes so that subsequent incorrect extern aliases with the
            // same alias will have the same target.
            @namespace = foundNamespace
                ? MergedNamespaceSymbol.Create(new NamespaceExtent(this), namespacesToMerge: builder.ToImmutableAndFree(), containingNamespace: null, nameOpt: null)
                : new MissingNamespaceSymbol(new MissingModuleSymbol(new MissingAssemblySymbol(new AssemblyIdentity(System.Guid.NewGuid().ToString())), ordinal: -1));

            // Use GetOrAdd in case another thread beat us to the punch (i.e. should return the same object for the same alias, every time).
            @namespace = _externAliasTargets.GetOrAdd(aliasName, @namespace);

            Debug.Assert(foundNamespace == !(@namespace is MissingNamespaceSymbol));

            return foundNamespace;
        }

        /// <summary>
        /// A symbol representing the implicit Script class. This is null if the class is not
        /// defined in the compilation.
        /// </summary>
        internal new NamedTypeSymbol ScriptClass
        {
            get { return _scriptClass.Value; }
        }

        /// <summary>
        /// Resolves a symbol that represents script container (Script class). Uses the
        /// full name of the container class stored in <see cref="CompilationOptions.ScriptClassName"/> to find the symbol.
        /// </summary>
        /// <returns>The Script class symbol or null if it is not defined.</returns>
        private ImplicitNamedTypeSymbol BindScriptClass()
        {
            return (ImplicitNamedTypeSymbol)CommonBindScriptClass();
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

            var binder = GetBinderFactory(tree).GetImportsBinder((LanguageSyntaxNode)tree.GetRoot());
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

        internal AliasSymbol GlobalNamespaceAlias
        {
            get
            {
                return _globalNamespaceAlias.Value;
            }
        }

        /// <summary>
        /// Get the symbol for the predefined type from the COR Library referenced by this compilation.
        /// </summary>
        internal new NamedTypeSymbol GetSpecialType(SpecialType specialType)
        {
            if (specialType <= SpecialType.None || specialType > SpecialType.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(specialType), $"Unexpected SpecialType: '{(int)specialType}'.");
            }

            NamedTypeSymbol result;
            if (IsTypeMissing(specialType))
            {
                MetadataTypeName emittedName = MetadataTypeName.FromFullName(specialType.GetMetadataName(), useCLSCompliantNameArityEncoding: true);
                result = new MissingMetadataTypeSymbol.TopLevel(Assembly.CorLibrary.Modules[0], ref emittedName, specialType);
            }
            else
            {
                result = Assembly.GetSpecialType(specialType);
            }

            Debug.Assert(result.SpecialType == specialType);
            return result;
        }

        /// <summary>
        /// Get the symbol for the predefined type member from the COR Library referenced by this compilation.
        /// </summary>
        internal Symbol GetSpecialTypeMember(SpecialMember specialMember)
        {
            return Assembly.GetSpecialTypeMember(specialMember);
        }

        internal override ISymbol CommonGetSpecialTypeMember(SpecialMember specialMember)
        {
            return GetSpecialTypeMember(specialMember);
        }

        internal TypeSymbol GetTypeByReflectionType(Type type, DiagnosticBag diagnostics)
        {
            var result = Assembly.GetTypeByReflectionType(type, includeReferences: true);
            if ((object)result == null)
            {
                var errorType = new ExtendedErrorTypeSymbol(this, type.Name, type.Name, CreateReflectionTypeNotFoundError(type));
                diagnostics.Add(errorType.ErrorInfo, NoLocation.Singleton);
                result = errorType;
            }

            return result;
        }

        private static LanguageDiagnosticInfo CreateReflectionTypeNotFoundError(Type type)
        {
            // The type or namespace name '{0}' could not be found in the global namespace (are you missing an assembly reference?)
            return new LanguageDiagnosticInfo(
                InternalErrorCode.ERR_GlobalSingleTypeNameNotFound,
                new object[] { type.AssemblyQualifiedName },
                ImmutableArray<Symbol>.Empty,
                ImmutableArray<Location>.Empty
            );
        }

        // The type of host object model if available.
        private TypeSymbol _lazyHostObjectTypeSymbol;

        internal TypeSymbol GetHostObjectTypeSymbol()
        {
            if (HostObjectType != null && (object)_lazyHostObjectTypeSymbol == null)
            {
                TypeSymbol symbol = Assembly.GetTypeByReflectionType(HostObjectType, includeReferences: true);

                if ((object)symbol == null)
                {
                    MetadataTypeName mdName = MetadataTypeName.FromNamespaceAndTypeName(HostObjectType.Namespace ?? String.Empty,
                                                                                        HostObjectType.Name,
                                                                                        useCLSCompliantNameArityEncoding: true);

                    symbol = new MissingMetadataTypeSymbol.TopLevelWithCustomErrorInfo(
                        new MissingAssemblySymbol(AssemblyIdentity.FromAssemblyDefinition(HostObjectType.GetTypeInfo().Assembly)).Modules[0],
                        ref mdName,
                        CreateReflectionTypeNotFoundError(HostObjectType),
                        SpecialType.None);
                }

                Interlocked.CompareExchange(ref _lazyHostObjectTypeSymbol, symbol, null);
            }

            return _lazyHostObjectTypeSymbol;
        }

        internal MethodSymbol GetSubmissionInitializer()
        {
            return (IsSubmission && (object)ScriptClass != null) ?
                ScriptClass.GetScriptInitializer() :
                null;
        }

        /// <summary>
        /// Gets the type within the compilation's assembly and all referenced assemblies (other than
        /// those that can only be referenced via an extern alias) using its canonical CLR metadata name.
        /// </summary>
        internal new NamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            return this.Assembly.GetTypeByMetadataName(fullyQualifiedMetadataName, includeReferences: true, isWellKnownType: false, conflicts: out var _);
        }

        /// <summary>
        /// The TypeSymbol for the type 'dynamic' in this Compilation.
        /// </summary>
        internal new TypeSymbol DynamicType
        {
            get
            {
                return AssemblySymbol.DynamicType;
            }
        }

        /// <summary>
        /// The NamedTypeSymbol for the .NET System.Object type, which could have a TypeKind of
        /// Error if there was no COR Library in this Compilation.
        /// </summary>
        public new NamedTypeSymbol ObjectType
        {
            get
            {
                return this.Assembly.ObjectType;
            }
        }

        internal bool DeclaresTheObjectClass
        {
            get
            {
                return SourceAssembly.DeclaresTheObjectClass;
            }
        }

        internal new MethodSymbol GetEntryPoint(CancellationToken cancellationToken)
        {
            EntryPoint entryPoint = GetEntryPointAndDiagnostics(cancellationToken);
            return entryPoint?.MethodSymbol;
        }

        internal EntryPoint GetEntryPointAndDiagnostics(CancellationToken cancellationToken)
        {
            if (!this.Options.OutputKind.IsApplication() && ((object)this.ScriptClass == null))
            {
                return null;
            }

            if (this.Options.MainTypeName != null && !this.Options.MainTypeName.IsValidClrTypeName())
            {
                Debug.Assert(!this.Options.Errors.IsDefaultOrEmpty);
                return new EntryPoint(null, ImmutableArray<Diagnostic>.Empty);
            }

            if (_lazyEntryPoint == null)
            {
                ImmutableArray<Diagnostic> diagnostics;
                var entryPoint = FindEntryPoint(cancellationToken, out diagnostics);
                Interlocked.CompareExchange(ref _lazyEntryPoint, new EntryPoint(entryPoint, diagnostics), null);
            }

            return _lazyEntryPoint;
        }

        private MethodSymbol FindEntryPoint(CancellationToken cancellationToken, out ImmutableArray<Diagnostic> sealedDiagnostics)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var entryPointCandidates = ArrayBuilder<MethodSymbol>.GetInstance();

            try
            {
                NamedTypeSymbol mainType;

                string mainTypeName = this.Options.MainTypeName;
                NamespaceSymbol globalNamespace = this.SourceModule.GlobalNamespace;

                if (mainTypeName != null)
                {
                    // Global code is the entry point, ignore all other Mains.
                    var scriptClass = this.ScriptClass;
                    if ((object)scriptClass != null)
                    {
                        // CONSIDER: we could use the symbol instead of just the name.
                        diagnostics.Add(InternalErrorCode.WRN_MainIgnored, NoLocation.Singleton, mainTypeName);
                        return scriptClass.GetScriptEntryPoint();
                    }

                    var mainTypeOrNamespace = globalNamespace.GetNamespaceOrTypeByQualifiedName(mainTypeName.Split('.')).FirstOrDefault();
                    if ((object)mainTypeOrNamespace == null)
                    {
                        diagnostics.Add(InternalErrorCode.ERR_MainClassNotFound, NoLocation.Singleton, mainTypeName);
                        return null;
                    }

                    mainType = mainTypeOrNamespace as NamedTypeSymbol;
                    if ((object)mainType == null || (mainType.TypeKind != LanguageTypeKind.NamedType))
                    {
                        diagnostics.Add(InternalErrorCode.ERR_MainClassNotClass, mainTypeOrNamespace.Locations.First(), mainTypeOrNamespace);
                        return null;
                    }

                    AddEntryPointCandidates(entryPointCandidates, mainType.GetMembersUnordered());
                }
                else
                {
                    mainType = null;

                    AddEntryPointCandidates(
                        entryPointCandidates,
                        this.GetSymbolsWithName(WellKnownMemberNames.EntryPointMethodName, SymbolFilter.Member, cancellationToken));

                    // Global code is the entry point, ignore all other Mains.
                    var scriptClass = this.ScriptClass;
                    if ((object)scriptClass != null)
                    {
                        foreach (var main in entryPointCandidates)
                        {
                            diagnostics.Add(InternalErrorCode.WRN_MainIgnored, main.Locations.First(), main);
                        }
                        return scriptClass.GetScriptEntryPoint();
                    }
                }

                // Validity and diagnostics are also tracked because they must be conditionally handled
                // if there are not any "traditional" entrypoints found.
                var taskEntryPoints = ArrayBuilder<(bool IsValid, MethodSymbol Candidate, DiagnosticBag SpecificDiagnostics)>.GetInstance();

                // These diagnostics (warning only) are added to the compilation only if
                // there were not any main methods found.
                DiagnosticBag noMainFoundDiagnostics = DiagnosticBag.GetInstance();

                bool CheckValid(MethodSymbol candidate, bool isCandidate, DiagnosticBag specificDiagnostics)
                {
                    if (!isCandidate)
                    {
                        noMainFoundDiagnostics.Add(InternalErrorCode.WRN_InvalidMainSig, candidate.Locations.First(), candidate);
                        noMainFoundDiagnostics.AddRange(specificDiagnostics);
                        return false;
                    }
                    return true;
                }

                var viableEntryPoints = ArrayBuilder<MethodSymbol>.GetInstance();

                foreach (var candidate in entryPointCandidates)
                {
                    var perCandidateBag = DiagnosticBag.GetInstance();
                    var (IsCandidate, IsTaskLike) = HasEntryPointSignature(candidate, perCandidateBag);

                    if (IsTaskLike)
                    {
                        taskEntryPoints.Add((IsCandidate, candidate, perCandidateBag));
                    }
                    else
                    {
                        if (CheckValid(candidate, IsCandidate, perCandidateBag))
                        {
                            if (candidate.IsAsync)
                            {
                                diagnostics.Add(InternalErrorCode.ERR_NonTaskMainCantBeAsync, candidate.Locations.First(), candidate);
                            }
                            else
                            {
                                diagnostics.AddRange(perCandidateBag);
                                viableEntryPoints.Add(candidate);
                            }
                        }
                        perCandidateBag.Free();
                    }
                }

                if (viableEntryPoints.Count == 0)
                {
                    foreach (var (IsValid, Candidate, SpecificDiagnostics) in taskEntryPoints)
                    {
                        if (CheckValid(Candidate, IsValid, SpecificDiagnostics))
                        {
                            diagnostics.AddRange(SpecificDiagnostics);
                            viableEntryPoints.Add(Candidate);
                        }
                    }
                }

                foreach (var (_, _, SpecificDiagnostics) in taskEntryPoints)
                {
                    SpecificDiagnostics.Free();
                }

                if (viableEntryPoints.Count == 0)
                {
                    diagnostics.AddRange(noMainFoundDiagnostics);
                }
                else if ((object)mainType == null)
                {
                    // Filters out diagnostics so that only InvalidMainSig and MainCant'BeGeneric are left.
                    // The reason that Error diagnostics can end up in `noMainFoundDiagnostics` is when
                    // HasEntryPointSignature yields some Error Diagnostics when people implement Task or Task<T> incorrectly.
                    //
                    // We can't add those Errors to the general diagnostics bag because it would break previously-working programs.
                    // The fact that these warnings are not added when csc is invoked with /main is possibly a bug, and is tracked at
                    // https://github.com/dotnet/roslyn/issues/18964
                    foreach (var diagnostic in noMainFoundDiagnostics.AsEnumerable())
                    {
                        if (diagnostic.HasErrorCode(InternalErrorCode.WRN_InvalidMainSig) || diagnostic.HasErrorCode(InternalErrorCode.WRN_MainCantBeGeneric))
                        {
                            diagnostics.Add(diagnostic);
                        }
                    }
                }

                MethodSymbol entryPoint = null;
                if (viableEntryPoints.Count == 0)
                {
                    if ((object)mainType == null)
                    {
                        diagnostics.Add(InternalErrorCode.ERR_NoEntryPoint, NoLocation.Singleton);
                    }
                    else
                    {
                        diagnostics.Add(InternalErrorCode.ERR_NoMainInClass, mainType.Locations.First(), mainType);
                    }
                }
                else if (viableEntryPoints.Count > 1)
                {
                    viableEntryPoints.Sort(LexicalOrderSymbolComparer.Instance);
                    var info = new SymbolDiagnosticInfo(
                         errorCode: InternalErrorCode.ERR_MultipleEntryPoints,
                         arguments: Array.Empty<object>(),
                         symbols: viableEntryPoints.OfType<ISymbol>().AsImmutable(),
                         additionalLocations: viableEntryPoints.Select(m => m.Locations.First()).OfType<Location>().AsImmutable());

                    diagnostics.Add(new LanguageDiagnostic(info, viableEntryPoints.First().Locations.First()));
                }
                else
                {
                    entryPoint = viableEntryPoints[0];
                }

                taskEntryPoints.Free();
                viableEntryPoints.Free();
                noMainFoundDiagnostics.Free();
                return entryPoint;
            }
            finally
            {
                entryPointCandidates.Free();
                sealedDiagnostics = diagnostics.ToReadOnlyAndFree();
            }
        }

        private void AddEntryPointCandidates(
            ArrayBuilder<MethodSymbol> entryPointCandidates, IEnumerable<ISymbol> members)
        {
            foreach (var member in members)
            {
                if (member is MethodSymbol method && this.Language.SymbolFacts.IsEntryPointCandidate(method))
                {
                    entryPointCandidates.Add(method);
                }
            }
        }

        /// <summary>
        /// Checks if the method has an entry point compatible signature, i.e.
        /// - the return type is either void, int, or returns a <see cref="System.Threading.Tasks.Task" />,
        /// or <see cref="System.Threading.Tasks.Task{T}" /> where the return type of GetAwaiter().GetResult()
        /// is either void or int.
        /// - has either no parameter or a single parameter of type string[]
        /// </summary>
        protected virtual (bool IsCandidate, bool IsTaskLike) HasEntryPointSignature(MethodSymbol method, DiagnosticBag bag)
        {
            return (false, false);
        }

        internal override bool IsUnreferencedAssemblyIdentityDiagnostic(Diagnostic diagnostic)
            => diagnostic.HasErrorCode(InternalErrorCode.ERR_NoTypeDef);

        internal class EntryPoint
        {
            public readonly MethodSymbol MethodSymbol;
            public readonly ImmutableArray<Diagnostic> Diagnostics;

            public EntryPoint(MethodSymbol methodSymbol, ImmutableArray<Diagnostic> diagnostics)
            {
                this.MethodSymbol = methodSymbol;
                this.Diagnostics = diagnostics;
            }
        }

        internal bool MightContainNoPiaLocalTypes()
        {
            return SourceAssembly.MightContainNoPiaLocalTypes();
        }

        // NOTE(cyrusn): There is a bit of a discoverability problem with this method and the same
        // named method in SyntaxTreeSemanticModel.  Technically, i believe these are the appropriate
        // locations for these methods.  This method has no dependencies on anything but the
        // compilation, while the other method needs a bindings object to determine what bound node
        // an expression syntax binds to.  Perhaps when we document these methods we should explain
        // where a user can find the other.
        public Conversion ClassifyConversion(ITypeSymbol source, ITypeSymbol destination)
        {
            // Note that it is possible for there to be both an implicit user-defined conversion
            // and an explicit built-in conversion from source to destination. In that scenario
            // this method returns the implicit conversion.

            if ((object)source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if ((object)destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var cssource = source.EnsureLanguageSymbolOrNull<ITypeSymbol, TypeSymbol>(nameof(source));
            var csdest = destination.EnsureLanguageSymbolOrNull<ITypeSymbol, TypeSymbol>(nameof(destination));

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return Conversions.ClassifyConversionFromType(cssource, csdest, ref useSiteDiagnostics);
        }

        /// <summary>
        /// Classifies a conversion from <paramref name="source"/> to <paramref name="destination"/> according
        /// to this compilation's programming language.
        /// </summary>
        /// <param name="source">Source type of value to be converted</param>
        /// <param name="destination">Destination type of value to be converted</param>
        /// <returns>A <see cref="CommonConversion"/> that classifies the conversion from the
        /// <paramref name="source"/> type to the <paramref name="destination"/> type.</returns>
        public override CommonConversion ClassifyCommonConversion(ITypeSymbol source, ITypeSymbol destination)
        {
            return ClassifyConversion(source, destination).ToCommonConversion();
        }

        internal override IConvertibleConversion ClassifyConvertibleConversion(IOperation source, ITypeSymbol destination, out Optional<object> constantValue)
        {
            constantValue = default;

            if (destination is null)
            {
                return Conversion.NoConversion;
            }

            ITypeSymbol sourceType = source.Type;

            if (sourceType is null)
            {
                if (source.ConstantValue.HasValue && source.ConstantValue.Value is null && destination.IsReferenceType)
                {
                    constantValue = source.ConstantValue;
                    return Conversion.DefaultOrNullLiteral;
                }

                return Conversion.NoConversion;
            }

            Conversion result = ClassifyConversion(sourceType, destination);

            if (result.IsReference && source.ConstantValue.HasValue && source.ConstantValue.Value is null)
            {
                constantValue = source.ConstantValue;
            }

            return result;
        }

        /// <summary>
        /// Returns a new Symbol representing a constructed symbol.
        /// </summary>
        internal Symbol CreateConstructedSymbol(SyntaxReference syntaxReference, ModelSymbolInfo symbolInfo, ImmutableArray<BoundProperty> properties)
        {
            var modelObject = symbolInfo.CreateMutable(this.ModelBuilder, true);
            foreach (var boundProperty in properties)
            {
                var prop = modelObject.MGetProperty(boundProperty.Name);
                foreach (var value in boundProperty.Values)
                {
                    var symbol = value as Symbol;
                    if (symbol != null)
                    {
                        if (symbol.ModelObject != null)
                        {
                            modelObject.MAdd(prop, symbol.ModelObject);
                        }
                    }
                    else
                    {
                        modelObject.MAdd(prop, value);
                    }
                }
            }
            return new SourceConstructedTypeSymbol(this.SourceAssembly, syntaxReference, modelObject);
        }

        private protected override bool IsSymbolAccessibleWithinCore(
            ISymbol symbol,
            ISymbol within,
            ITypeSymbol throughType)
        {
            var symbol0 = symbol.EnsureLanguageSymbolOrNull<ISymbol, Symbol>(nameof(symbol));
            var within0 = within.EnsureLanguageSymbolOrNull<ISymbol, Symbol>(nameof(within));
            var throughType0 = throughType.EnsureLanguageSymbolOrNull<ITypeSymbol, TypeSymbol>(nameof(throughType));
            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return
                within0.Kind == LanguageSymbolKind.Assembly ?
                AccessCheck.IsSymbolAccessible(symbol0, (AssemblySymbol)within0, ref useSiteDiagnostics) :
                AccessCheck.IsSymbolAccessible(symbol0, (NamedTypeSymbol)within0, ref useSiteDiagnostics, throughType0);
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
                throw new ArgumentException(CSharpResources.SyntaxTreeNotFound, nameof(syntaxTree));
            }

            return new SyntaxTreeSemanticModel(this, (LanguageSyntaxTree)syntaxTree, ignoreAccessibility);
        }

        // When building symbols from the declaration table (lazily), or inside a type, or when
        // compiling a method body, we may not have a Binder in hand for the enclosing
        // scopes.  Therefore, we build them when needed (and cache them) using a BinderFactory.
        // Since a BinderFactory is only a cache, and the identity of the BinderFactories and
        // Binder have no semantic meaning, we can reuse them or rebuild them, whichever is
        // most convenient. We store them using weak references so that GC pressure will cause them
        // to be recycled.
        private WeakReference<BinderFactory>[] _binderFactories;

        internal BinderFactory GetBinderFactory(SyntaxTree syntaxTree)
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
            var newFactory = new CachingBinderFactory(this, syntaxTree);
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

        internal Binder GetBinder(LanguageSyntaxNode syntax)
        {
            return GetBinderFactory(syntax.SyntaxTree).GetBinder(syntax);
        }

        // Bound trees containing computed semantic information.
        // We store them using weak references so that GC pressure will cause them to be recycled.
        private WeakReference<BoundTree>[] _boundTrees;

        public BoundTree GetBoundTree(SyntaxTree syntaxTree)
        {
            var treeNum = GetSyntaxTreeOrdinal(syntaxTree);
            var boundTrees = _boundTrees;
            if (boundTrees == null)
            {
                boundTrees = new WeakReference<BoundTree>[this.SyntaxTrees.Length];
                boundTrees = Interlocked.CompareExchange(ref _boundTrees, boundTrees, null) ?? boundTrees;
            }

            BoundTree previousBoundTree;
            var previousWeakReference = boundTrees[treeNum];
            if (previousWeakReference != null && previousWeakReference.TryGetTarget(out previousBoundTree))
            {
                return previousBoundTree;
            }

            return AddNewBoundTree((LanguageSyntaxTree)syntaxTree, ref boundTrees[treeNum]);
        }

        internal BoundTree GetBoundTree(SyntaxNodeOrToken syntax)
        {
            var boundTree = GetBoundTree(syntax.SyntaxTree);
            return boundTree.GetEnclosingBoundTree(syntax);
        }

        private BoundTree AddNewBoundTree(LanguageSyntaxTree syntaxTree, ref WeakReference<BoundTree> slot)
        {
            var newBoundTree = new BoundTree(this, syntaxTree, GetBinder(syntaxTree.GetRootNode()), new DiagnosticBag());
            var newWeakReference = new WeakReference<BoundTree>(newBoundTree);

            while (true)
            {
                BoundTree previousBoundTree;
                WeakReference<BoundTree> previousWeakReference = slot;
                if (previousWeakReference != null && previousWeakReference.TryGetTarget(out previousBoundTree))
                {
                    return previousBoundTree;
                }

                if (Interlocked.CompareExchange(ref slot, newWeakReference, previousWeakReference) == previousWeakReference)
                {
                    return newBoundTree;
                }
            }
        }

        public T GetBoundNode<T>(SyntaxNode syntax)
            where T: BoundNode
        {
            var boundTree = GetBoundTree((LanguageSyntaxTree)syntax.SyntaxTree);
            var bindableNode = boundTree.GetBindableSyntaxNode((LanguageSyntaxNode)syntax);
            var boundNodes = boundTree.GetBoundNodes(bindableNode);
            var current = (LanguageSyntaxNode)syntax;
            while (current != null)
            {
                var currentBoundNodes = boundTree.GetBoundNodes(current);
                for (int i = currentBoundNodes.Length - 1; i >= 0; i--)
                {
                    if (currentBoundNodes[i] is T typedBoundNode) return typedBoundNode;
                }
                current = current.Parent;
            }
            return null;
        }

        public ImmutableArray<BoundNode> GetBoundNodes(SyntaxNode syntax)
        {
            var boundTree = GetBoundTree((LanguageSyntaxTree)syntax.SyntaxTree);
            var bindableNode = boundTree.GetBindableSyntaxNode((LanguageSyntaxNode)syntax);
            return boundTree.GetBoundNodes(bindableNode);
        }

        /// <summary>
        /// Returns imported symbols for the given declaration.
        /// </summary>
        internal Imports GetImports(SingleDeclaration declaration)
        {
            return GetBinderFactory(declaration.SyntaxReference.SyntaxTree).GetImportsBinder((LanguageSyntaxNode)declaration.SyntaxReference.GetSyntax()).GetImports(basesBeingResolved: null);
        }

        private AliasSymbol CreateGlobalNamespaceAlias()
        {
            return AliasSymbol.CreateGlobalNamespaceAlias(this.GlobalNamespace, new InContainerBinder(this.GlobalNamespace, new BuckStopsHereBinder(this)));
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
                        CompleteCompilationEventQueue_NoLock();
                    }
                }
            }
        }

        internal override void ReportUnusedImports(SyntaxTree filterTree, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (_lazyImportInfos != null && filterTree?.Options.DocumentationMode != DocumentationMode.None)
            {
                foreach (ImportInfo info in _lazyImportInfos)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    SyntaxTree infoTree = info.Tree;
                    if ((filterTree == null || filterTree == infoTree) && infoTree.Options.DocumentationMode != DocumentationMode.None)
                    {
                        TextSpan infoSpan = info.Span;
                        if (!this.IsImportDirectiveUsed(infoTree, infoSpan.Start))
                        {
                            InternalErrorCode code = _language.SyntaxFacts.IsExternAliasDirective(info.Kind)
                                ? InternalErrorCode.HDN_UnusedExternAlias
                                : InternalErrorCode.HDN_UnusedUsingDirective;
                            diagnostics.Add(code, infoTree.GetLocation(infoSpan));
                        }
                    }
                }
            }

            CompleteTrees(filterTree);
        }

        internal override void CompleteTrees(SyntaxTree filterTree)
        {
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

        internal void RecordImport(UsingDirective directive)
        {
            RecordImportInternal(directive.SyntaxNode);
        }

        internal void RecordImport(ExternAliasDirective directive)
        {
            RecordImportInternal(directive.SyntaxNode);
        }

        private void RecordImportInternal(LanguageSyntaxNode syntax)
        {
            LazyInitializer.EnsureInitialized(ref _lazyImportInfos).
                Add(new ImportInfo(syntax.SyntaxTree, syntax.Kind, syntax.Span));
        }

        private struct ImportInfo : IEquatable<ImportInfo>
        {
            public readonly SyntaxTree Tree;
            public readonly SyntaxKind Kind;
            public readonly TextSpan Span;

            public ImportInfo(SyntaxTree tree, SyntaxKind kind, TextSpan span)
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
                    other.Span == this.Span;
            }

            public override int GetHashCode()
            {
                return Hash.Combine(Tree, Span.Start);
            }
        }

        #endregion

        #region Diagnostics

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

        public override DeclarationTable Declarations
        {
            get
            {
                return _syntaxAndDeclarations.GetLazyState().DeclarationTable;
            }
        }

        internal MergedDeclaration MergedRootDeclaration
        {
            get
            {
                return Declarations.GetMergedRoot(this);
            }
        }

        /// <summary>
        /// Gets the diagnostics produced during the parsing stage of a compilation. There are no diagnostics for declarations or accessor or
        /// method bodies, for example.
        /// </summary>
        public override ImmutableArray<Diagnostic> GetParseDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(CompilationStage.Parse, false, cancellationToken);
        }

        /// <summary>
        /// Gets the diagnostics produced during symbol declaration headers.  There are no diagnostics for accessor or
        /// method bodies, for example.
        /// </summary>
        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(CompilationStage.Declare, false, cancellationToken);
        }

        /// <summary>
        /// Gets the diagnostics produced during the analysis of method bodies and field initializers.
        /// </summary>
        public override ImmutableArray<Diagnostic> GetSymbolDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
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
            var diagnostics = DiagnosticBag.GetInstance();
            GetDiagnostics(stage, includeEarlierStages, diagnostics, cancellationToken);
            return diagnostics.ToReadOnlyAndFree();
        }

        internal override void GetDiagnostics(CompilationStage stage, bool includeEarlierStages, DiagnosticBag diagnostics, CancellationToken cancellationToken = default)
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
                        UICultureUtilities.WithCurrentUICulture<int>(i =>
                        {
                            var syntaxTree = syntaxTrees[i];
                            AppendLoadDirectiveDiagnostics(builder, _syntaxAndDeclarations, syntaxTree);
                            builder.AddRange(syntaxTree.GetDiagnostics(cancellationToken));
                        }));
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

                var parseOptionsReported = new HashSet<ParseOptions>();
                foreach (var syntaxTree in syntaxTrees)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (!syntaxTree.Options.Errors.IsDefaultOrEmpty && parseOptionsReported.Add(syntaxTree.Options))
                    {
                        var location = syntaxTree.GetLocation(TextSpan.FromBounds(0, 0));
                        foreach (var error in syntaxTree.Options.Errors)
                        {
                            builder.Add(error.WithLocation(location));
                        }
                    }
                }
            }

            if (stage == CompilationStage.Declare || stage > CompilationStage.Declare && includeEarlierStages)
            {
                CheckAssemblyName(builder);
                builder.AddRange(Options.Errors);

                cancellationToken.ThrowIfCancellationRequested();

                // the set of diagnostics related to establishing references.
                builder.AddRange(GetBoundReferenceManager().Diagnostics);

                cancellationToken.ThrowIfCancellationRequested();

                builder.AddRange(GetSourceDeclarationDiagnostics(cancellationToken: cancellationToken));

                if (EventQueue != null && SyntaxTrees.Length == 0)
                {
                    EnsureCompilationEventQueueCompleted();
                }
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
            FilterAndAppendAndFreeDiagnostics(diagnostics, ref builder);
        }

        private static void AppendLoadDirectiveDiagnostics(DiagnosticBag builder, SyntaxAndDeclarationManager syntaxAndDeclarations, SyntaxTree syntaxTree, Func<IEnumerable<Diagnostic>, IEnumerable<Diagnostic>> locationFilterOpt = null)
        {
            ImmutableArray<DeclarationLoadDirective> loadDirectives;
            if (syntaxAndDeclarations.GetLazyState().LoadDirectiveMap.TryGetValue(syntaxTree, out loadDirectives))
            {
                Debug.Assert(!loadDirectives.IsEmpty);
                foreach (var directive in loadDirectives)
                {
                    IEnumerable<Diagnostic> diagnostics = directive.Diagnostics;
                    if (locationFilterOpt != null)
                    {
                        diagnostics = locationFilterOpt(diagnostics);
                    }
                    builder.AddRange(diagnostics);
                }
            }
        }

        // Do the steps in compilation to get the method body diagnostics, but don't actually generate
        // IL or emit an assembly.
        private void GetDiagnosticsForAllSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            this.ForceComplete(cancellationToken);
            foreach (var syntaxTree in this.SyntaxTrees)
            {
                var boundTree = GetBoundTree(syntaxTree);
                diagnostics.AddRange(boundTree.DiagnosticBag);
            }
            this.ReportUnusedImports(null, diagnostics, cancellationToken);
        }

        public void ForceComplete(CancellationToken cancellationToken = default)
        {
            this.GlobalNamespace.ForceComplete(null, cancellationToken);
            foreach (var syntaxTree in this.SyntaxTrees)
            {
                var boundTree = GetBoundTree(syntaxTree);
                boundTree.ForceComplete(cancellationToken);
            }
            this.ModelBuilder.EvaluateLazyValues(cancellationToken);
        }

        private static bool IsDefinedOrImplementedInSourceTree(Symbol symbol, SyntaxTree tree, TextSpan? span)
        {
            if (symbol.IsDefinedInSourceTree(tree, span))
            {
                return true;
            }

            if (symbol.Kind == LanguageSymbolKind.Operation && symbol.IsImplicitlyDeclared && ((MethodSymbol)symbol).MethodKind == MethodKind.Constructor)
            {
                // Include implicitly declared constructor if containing type is included
                return IsDefinedOrImplementedInSourceTree(symbol.ContainingType, tree, span);
            }

            return false;
        }

        private ImmutableArray<Diagnostic> GetDiagnosticsForSymbolsInTree(SyntaxTree tree, TextSpan? span, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("TODO:MetaDslx");

            /*DiagnosticBag diagnostics = DiagnosticBag.GetInstance();

            // Report unused directives only if computing diagnostics for the entire tree.
            // Otherwise we cannot determine if a particular directive is used outside of the given sub-span within the tree.
            if (!span.HasValue || span.Value == tree.GetRoot(cancellationToken).FullSpan)
            {
                ReportUnusedImports(tree, diagnostics, cancellationToken);
            }

            return diagnostics.ToReadOnlyAndFree();*/
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

            Assembly.ForceComplete(location, cancellationToken);

            if (syntaxTree is null)
            {
                // Don't freeze the compilation if we're getting
                // diagnostics for a single tree
                _declarationDiagnosticsFrozen = true;
            }

            var result = _lazyDeclarationDiagnostics?.AsEnumerable() ?? Enumerable.Empty<Diagnostic>();

            if (locationFilterOpt != null)
            {
                Debug.Assert(syntaxTree != null);
                result = locationFilterOpt(result, syntaxTree, filterSpanWithinTree);
            }

            return result.AsImmutable();
        }

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
                // re-enabling/fixing the below assert is tracked by https://github.com/dotnet/roslyn/issues/21020
                // Debug.Assert(declarationDiagnostics.All(d => d.HasIntersectingLocation(syntaxTree, filterSpanWithinTree)));
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
                IEnumerable<Diagnostic> symbolDiagnostics = GetDiagnosticsForSymbolsInTree(syntaxTree, filterSpanWithinTree, cancellationToken);

                // TODO: Enable the below commented assert and remove the filtering code in the next line.
                //       GetDiagnosticsForMethodBodiesInTree seems to be returning diagnostics with locations that don't satisfy the filter tree/span, this must be fixed.
                // Debug.Assert(methodBodyDiagnostics.All(d => DiagnosticContainsLocation(d, syntaxTree, filterSpanWithinTree)));
                symbolDiagnostics = FilterDiagnosticsByLocation(symbolDiagnostics, syntaxTree, filterSpanWithinTree);

                builder.AddRange(symbolDiagnostics);
            }

            // Before returning diagnostics, we filter warnings
            // to honor the compiler options (/nowarn, /warnaserror and /warn) and the pragmas.
            var result = DiagnosticBag.GetInstance();
            FilterAndAppendAndFreeDiagnostics(result, ref builder);
            return result.ToReadOnlyAndFree<Diagnostic>();
        }

        #endregion

        #region Resources

        protected override void AppendDefaultVersionResource(Stream resourceStream)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Emit


        internal override bool HasCodeToEmit()
        {
            return false;
        }

        #endregion

        #region Common Members

        protected override Compilation CommonWithReferences(IEnumerable<MetadataReference> newReferences)
        {
            return WithReferences(newReferences);
        }

        protected override Compilation CommonWithAssemblyName(string assemblyName)
        {
            return WithAssemblyName(assemblyName);
        }

        protected override IAssemblySymbol CommonAssembly
        {
            get { return this.Assembly; }
        }

        protected override INamespaceSymbol CommonGlobalNamespace
        {
            get { return this.GlobalNamespace; }
        }

        protected override CompilationOptions CommonOptions
        {
            get { return _options; }
        }

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

        protected override Compilation CommonWithOptions(CompilationOptions options)
        {
            return this.WithOptions((LanguageCompilationOptions)options);
        }

        protected override Compilation CommonWithScriptCompilationInfo(ScriptCompilationInfo info)
        {
            return this.WithScriptCompilationInfo((LanguageScriptCompilationInfo)info);
        }

        protected override bool CommonContainsSyntaxTree(SyntaxTree syntaxTree)
        {
            return this.ContainsSyntaxTree(syntaxTree);
        }

        protected override ISymbol CommonGetAssemblyOrModuleSymbol(MetadataReference reference)
        {
            return this.GetAssemblyOrModuleSymbol(reference);
        }

        protected override Compilation CommonClone()
        {
            return this.Clone();
        }

        protected override IModuleSymbol CommonSourceModule
        {
            get { return this.SourceModule; }
        }

        protected override INamedTypeSymbol CommonGetSpecialType(SpecialType specialType)
        {
            return this.GetSpecialType(specialType);
        }

        protected override INamespaceSymbol CommonGetCompilationNamespace(INamespaceSymbol namespaceSymbol)
        {
            return this.GetCompilationNamespace(namespaceSymbol);
        }

        protected override INamedTypeSymbol CommonGetTypeByMetadataName(string metadataName)
        {
            return this.GetTypeByMetadataName(metadataName);
        }

        protected override INamedTypeSymbol CommonScriptClass
        {
            get { return this.ScriptClass; }
        }

        protected override ITypeSymbol CommonDynamicType
        {
            get { return DynamicType; }
        }

        protected override INamedTypeSymbol CommonObjectType
        {
            get { return this.ObjectType; }
        }

        protected override IMethodSymbol CommonGetEntryPoint(CancellationToken cancellationToken)
        {
            return this.GetEntryPoint(cancellationToken);
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

        internal override int CompareSourceLocations(SyntaxReference loc1, SyntaxReference loc2)
        {
            var comparison = CompareSyntaxTreeOrdering(loc1.SyntaxTree, loc2.SyntaxTree);
            if (comparison != 0)
            {
                return comparison;
            }

            return loc1.Span.Start - loc2.Span.Start;
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
                throw new ArgumentException(CSharpResources.NoNoneSearchCriteria, nameof(filter));
            }

            return DeclarationTable.ContainsName(this.MergedRootDeclaration, predicate, filter, cancellationToken);
        }

        /// <summary>
        /// Return source declaration symbols whose name meets given predicate.
        /// </summary>
        public override IEnumerable<ISymbol> GetSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (filter == SymbolFilter.None)
            {
                throw new ArgumentException(CSharpResources.NoNoneSearchCriteria, nameof(filter));
            }

            return new PredicateSymbolSearcher(this, filter, predicate, cancellationToken).GetSymbolsWithName();
        }

#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters
        /// <summary>
        /// Return true if there is a source declaration symbol name that matches the provided name.
        /// This will be faster than <see cref="ContainsSymbolsWithName(Func{string, bool}, SymbolFilter, CancellationToken)"/>
        /// when predicate is just a simple string check.
        /// </summary>
        public override bool ContainsSymbolsWithName(string name, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (filter == SymbolFilter.None)
            {
                throw new ArgumentException(CSharpResources.NoNoneSearchCriteria, nameof(filter));
            }

            return DeclarationTable.ContainsName(this.MergedRootDeclaration, name, filter, cancellationToken);
        }

        /// <summary>
        /// Return source declaration symbols whose name matches the provided name.  This will be
        /// faster than <see cref="GetSymbolsWithName(Func{string, bool}, SymbolFilter,
        /// CancellationToken)"/> when predicate is just a simple string check.  <paramref
        /// name="name"/> is case sensitive.
        /// </summary>
        public override IEnumerable<ISymbol> GetSymbolsWithName(string name, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (filter == SymbolFilter.None)
            {
                throw new ArgumentException(CSharpResources.NoNoneSearchCriteria, nameof(filter));
            }

            return new NameSymbolSearcher(this, filter, name, cancellationToken).GetSymbolsWithName();
        }
#pragma warning restore RS0026 // Do not add multiple public overloads with optional parameters

        #endregion

        internal override AnalyzerDriver AnalyzerForLanguage(ImmutableArray<DiagnosticAnalyzer> analyzers, AnalyzerManager analyzerManager)
        {
            Func<SyntaxNode, int> getKind = node => node.RawKind;
            Func<SyntaxTrivia, bool> isComment = trivia => Language.SyntaxFacts.IsCommentTrivia(trivia.GetKind());
            return new AnalyzerDriver<int>(analyzers, getKind, analyzerManager, isComment);
        }

        internal void SymbolDeclaredEvent(Symbol symbol)
        {
            EventQueue?.TryEnqueue(new SymbolDeclaredCompilationEvent(this, symbol));
        }

        private abstract class AbstractSymbolSearcher
        {
            private readonly PooledDictionary<Declaration, NamespaceOrTypeSymbol> _cache;
            private readonly LanguageCompilation _compilation;
            private readonly bool _includeNamespace;
            private readonly bool _includeType;
            private readonly bool _includeMember;
            private readonly CancellationToken _cancellationToken;

            protected AbstractSymbolSearcher(
                LanguageCompilation compilation, SymbolFilter filter, CancellationToken cancellationToken)
            {
                _cache = PooledDictionary<Declaration, NamespaceOrTypeSymbol>.GetInstance();

                _compilation = compilation;

                _includeNamespace = (filter & SymbolFilter.Namespace) == SymbolFilter.Namespace;
                _includeType = (filter & SymbolFilter.Type) == SymbolFilter.Type;
                _includeMember = (filter & SymbolFilter.Member) == SymbolFilter.Member;

                _cancellationToken = cancellationToken;
            }

            protected abstract bool Matches(string name);
            protected abstract bool ShouldCheckTypeForMembers(MergedDeclaration current);

            public IEnumerable<ISymbol> GetSymbolsWithName()
            {
                var result = new HashSet<ISymbol>();
                var spine = ArrayBuilder<MergedDeclaration>.GetInstance();

                AppendSymbolsWithName(spine, _compilation.MergedRootDeclaration, result);

                spine.Free();
                _cache.Free();
                return result;
            }

            private void AppendSymbolsWithName(
                ArrayBuilder<MergedDeclaration> spine, MergedDeclaration current,
                HashSet<ISymbol> set)
            {
                if (current.IsNamespace)
                {
                    if (_includeNamespace && Matches(current.Name))
                    {
                        var container = GetSpineSymbol(spine);
                        var symbol = GetSymbol(container, current);
                        if (symbol != null)
                        {
                            set.Add(symbol);
                        }
                    }
                }
                else
                {
                    if (_includeType && Matches(current.Name))
                    {
                        var container = GetSpineSymbol(spine);
                        var symbol = GetSymbol(container, current);
                        if (symbol != null)
                        {
                            set.Add(symbol);
                        }
                    }

                    if (_includeMember)
                    {
                        var typeDeclaration = current;
                        if (ShouldCheckTypeForMembers(typeDeclaration))
                        {
                            AppendMemberSymbolsWithName(spine, typeDeclaration, set);
                        }
                    }
                }

                spine.Add(current);

                foreach (var child in current.Children)
                {
                    if (child is MergedDeclaration mergedNamespaceOrType)
                    {
                        if (_includeMember || _includeType || child.IsNamespace)
                        {
                            AppendSymbolsWithName(spine, mergedNamespaceOrType, set);
                        }
                    }
                }

                // pop last one
                spine.RemoveAt(spine.Count - 1);
            }

            private void AppendMemberSymbolsWithName(
                ArrayBuilder<MergedDeclaration> spine, MergedDeclaration current, HashSet<ISymbol> set)
            {
                _cancellationToken.ThrowIfCancellationRequested();
                spine.Add(current);

                var container = GetSpineSymbol(spine);
                if (container != null)
                {
                    foreach (var member in container.GetMembers())
                    {
                        if (!member.IsTypeOrTypeAlias() && member.CanBeReferencedByName && Matches(member.Name))
                        {
                            set.Add(member);
                        }
                    }
                }

                spine.RemoveAt(spine.Count - 1);
            }

            protected NamespaceOrTypeSymbol GetSpineSymbol(ArrayBuilder<MergedDeclaration> spine)
            {
                if (spine.Count == 0)
                {
                    return null;
                }

                var symbol = GetCachedSymbol(spine[spine.Count - 1]);
                if (symbol != null)
                {
                    return symbol;
                }

                NamespaceOrTypeSymbol current = _compilation.GlobalNamespace;
                for (var i = 1; i < spine.Count; i++)
                {
                    current = GetSymbol(current, spine[i]);
                }

                return current;
            }

            private NamespaceOrTypeSymbol GetCachedSymbol(MergedDeclaration declaration)
                => _cache.TryGetValue(declaration, out NamespaceOrTypeSymbol symbol)
                        ? symbol
                        : null;

            private NamespaceOrTypeSymbol GetSymbol(NamespaceOrTypeSymbol container, MergedDeclaration declaration)
            {
                if (container == null)
                {
                    return _compilation.GlobalNamespace;
                }

                if (declaration.IsNamespace)
                {
                    AddCache(container.GetMembers(declaration.Name).OfType<NamespaceOrTypeSymbol>());
                }
                else
                {
                    AddCache(container.GetTypeMembers(declaration.Name));
                }

                return GetCachedSymbol(declaration);
            }

            private void AddCache(IEnumerable<NamespaceOrTypeSymbol> symbols)
            {
                foreach (var symbol in symbols)
                {
                    var mergedNamespace = symbol as MergedNamespaceSymbol;
                    if (mergedNamespace != null)
                    {
                        _cache[mergedNamespace.ConstituentNamespaces.OfType<SourceNamespaceSymbol>().First().MergedDeclaration] = symbol;
                        continue;
                    }

                    var sourceNamespace = symbol as SourceNamespaceSymbol;
                    if (sourceNamespace != null)
                    {
                        _cache[sourceNamespace.MergedDeclaration] = sourceNamespace;
                        continue;
                    }

                    var sourceType = symbol as SourceMemberContainerTypeSymbol;
                    if ((object)sourceType != null)
                    {
                        _cache[sourceType.MergedDeclaration] = sourceType;
                    }
                }
            }
        }

        private class PredicateSymbolSearcher : AbstractSymbolSearcher
        {
            private readonly Func<string, bool> _predicate;

            public PredicateSymbolSearcher(
                LanguageCompilation compilation, SymbolFilter filter, Func<string, bool> predicate, CancellationToken cancellationToken)
                : base(compilation, filter, cancellationToken)
            {
                _predicate = predicate;
            }

            protected override bool ShouldCheckTypeForMembers(MergedDeclaration current)
            {
                // Note: this preserves the behavior the compiler has always had when a predicate
                // is passed in.  We could potentially be smarter by checking the predicate
                // against the list of member names in the type declaration first.
                return true;
            }

            protected override bool Matches(string name)
                => _predicate(name);
        }

        private class NameSymbolSearcher : AbstractSymbolSearcher
        {
            private readonly string _name;

            public NameSymbolSearcher(
                LanguageCompilation compilation, SymbolFilter filter, string name, CancellationToken cancellationToken)
                : base(compilation, filter, cancellationToken)
            {
                _name = name;
            }

            protected override bool ShouldCheckTypeForMembers(MergedDeclaration current)
            {
                foreach (SingleDeclaration typeDecl in current.Declarations)
                {
                    if (typeDecl.ChildNames.Contains(_name))
                    {
                        return true;
                    }
                }

                return false;
            }

            protected override bool Matches(string name)
                => _name == name;
        }
    }
}

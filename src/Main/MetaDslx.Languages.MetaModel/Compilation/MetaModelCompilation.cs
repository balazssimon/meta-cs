using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.MetaModel
{
    public class MetaModelCompilation : LanguageCompilation
    {
        protected override Language LanguageCore => MetaModelLanguage.Instance;

        /// <summary>
        /// The language version that was used to parse the syntax trees of this compilation.
        /// </summary>
        public LanguageVersion LanguageVersion
        {
            get;
        }

        private static readonly LanguageCompilationOptions s_defaultOptions = new MetaModelCompilation(OutputKind.ConsoleApplication);
        private static readonly LanguageCompilationOptions s_defaultSubmissionOptions = new MetaModelCompilation(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);

        #region Constructors and Factories

        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static MetaModelCompilation Create(
            string assemblyName,
            IEnumerable<SyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null)
        {
            return Create(
                assemblyName,
                options ?? s_defaultOptions,
                syntaxTrees,
                references,
                previousSubmission: null,
                returnType: null,
                hostObjectType: null,
                isSubmission: false);
        }

        /// <summary>
        /// Creates a new compilation that can be used in scripting.
        /// </summary>
        public static MetaModelCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null,
            MetaModelCompilation previousScriptCompilation = null,
            Type returnType = null,
            Type globalsType = null)
        {
            CheckSubmissionOptions(options);
            ValidateScriptCompilationParameters(previousScriptCompilation, returnType, ref globalsType);

            return Create(
                assemblyName,
                options?.WithReferencesSupersedeLowerVersions(true) ?? s_defaultSubmissionOptions,
                (syntaxTree != null) ? new[] { syntaxTree } : SpecializedCollections.EmptyEnumerable<SyntaxTree>(),
                references,
                previousScriptCompilation,
                returnType,
                globalsType,
                isSubmission: true);
        }

        private static MetaModelCompilation Create(
            string assemblyName,
            LanguageCompilationOptions options,
            IEnumerable<SyntaxTree> syntaxTrees,
            IEnumerable<MetadataReference> references,
            MetaModelCompilation previousSubmission,
            Type returnType,
            Type hostObjectType,
            bool isSubmission)
        {
            Debug.Assert(options != null);
            Debug.Assert(!isSubmission || options.ReferencesSupersedeLowerVersions);

            var validatedReferences = ValidateReferences<CSharpCompilationReference>(references);

            var compilation = new MetaModelCompilation(
                assemblyName,
                options,
                validatedReferences,
                previousSubmission,
                returnType,
                hostObjectType,
                isSubmission,
                referenceManager: null,
                reuseReferenceManager: false,
                syntaxAndDeclarations: new SyntaxAndDeclarationManager(
                    ImmutableArray<SyntaxTree>.Empty,
                    options.ScriptClassName,
                    options.SourceReferenceResolver,
                    CSharp.MessageProvider.Instance,
                    isSubmission,
                    state: null));

            if (syntaxTrees != null)
            {
                compilation = compilation.AddSyntaxTrees(syntaxTrees);
            }

            Debug.Assert((object)compilation._lazyAssemblySymbol == null);
            return compilation;
        }

        private MetaModelCompilation(
            string assemblyName,
            LanguageCompilationOptions options,
            ImmutableArray<MetadataReference> references,
            MetaModelCompilation previousSubmission,
            Type submissionReturnType,
            Type hostObjectType,
            bool isSubmission,
            ReferenceManager referenceManager,
            bool reuseReferenceManager,
            SyntaxAndDeclarationManager syntaxAndDeclarations,
            AsyncQueue<CompilationEvent> eventQueue = null)
            : base(assemblyName, references, SyntaxTreeCommonFeatures(syntaxAndDeclarations.ExternalSyntaxTrees), isSubmission, eventQueue)
        {
            WellKnownMemberSignatureComparer = new WellKnownMembersSignatureComparer(this);
            _options = options;

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
                this.ScriptCompilationInfo = new CSharpScriptCompilationInfo(previousSubmission, submissionReturnType, hostObjectType);
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
                _referenceManager = new ReferenceManager(
                    MakeSourceAssemblySimpleName(),
                    this.Options.AssemblyIdentityComparer,
                    observedMetadata: referenceManager?.ObservedMetadata);
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
                diagnostics.Add(ErrorCode.ERR_DebugEntryPointNotSourceMethodDefinition, Location.None);
            }
        }

        private static LanguageVersion CommonLanguageVersion(ImmutableArray<SyntaxTree> syntaxTrees)
        {
            LanguageVersion? result = null;
            foreach (var tree in syntaxTrees)
            {
                var version = ((CSharpParseOptions)tree.Options).LanguageVersion;
                if (result == null)
                {
                    result = version;
                }
                else if (result != version)
                {
                    throw new ArgumentException(CodeAnalysisResources.InconsistentLanguageVersions, nameof(syntaxTrees));
                }
            }

            return result ?? LanguageVersion.Default.MapSpecifiedToEffectiveVersion();
        }

        /// <summary>
        /// Create a duplicate of this compilation with different symbol instances.
        /// </summary>
        public new MetaModelCompilation Clone()
        {
            return new MetaModelCompilation(
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

        private MetaModelCompilation Update(
            ReferenceManager referenceManager,
            bool reuseReferenceManager,
            SyntaxAndDeclarationManager syntaxAndDeclarations)
        {
            return new MetaModelCompilation(
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
        public new MetaModelCompilation WithAssemblyName(string assemblyName)
        {
            // Can't reuse references since the source assembly name changed and the referenced symbols might
            // have internals-visible-to relationship with this compilation or they might had a circular reference
            // to this compilation.

            return new MetaModelCompilation(
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
        /// The new <see cref="MetaModelCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying
        /// metadata as soon as the are needed.
        ///
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new MetaModelCompilation WithReferences(IEnumerable<MetadataReference> references)
        {
            // References might have changed, don't reuse reference manager.
            // Don't even reuse observed metadata - let the manager query for the metadata again.

            return new MetaModelCompilation(
                this.AssemblyName,
                _options,
                ValidateReferences<CSharpCompilationReference>(references),
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
        public new MetaModelCompilation WithReferences(params MetadataReference[] references)
        {
            return this.WithReferences((IEnumerable<MetadataReference>)references);
        }

        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public MetaModelCompilation WithOptions(LanguageCompilationOptions options)
        {
            var oldOptions = this.Options;
            bool reuseReferenceManager = oldOptions.CanReuseCompilationReferenceManager(options);
            bool reuseSyntaxAndDeclarationManager = oldOptions.ScriptClassName == options.ScriptClassName &&
                oldOptions.SourceReferenceResolver == options.SourceReferenceResolver;

            return new MetaModelCompilation(
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
                        _syntaxAndDeclarations.MessageProvider,
                        _syntaxAndDeclarations.IsSubmission,
                        state: null));
        }

        /// <summary>
        /// Returns a new compilation with the given compilation set as the previous submission.
        /// </summary>
        public MetaModelCompilation WithScriptCompilationInfo(CSharpScriptCompilationInfo info)
        {
            if (info == ScriptCompilationInfo)
            {
                return this;
            }

            // Reference binding doesn't depend on previous submission so we can reuse it.

            return new MetaModelCompilation(
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
            return new MetaModelCompilation(
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

    }
}

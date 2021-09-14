// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;

namespace MetaDslx.Languages.Core
{
    public class CoreCompilation : LanguageCompilation
    {
        #region Constructors and Factories
        private static readonly CoreCompilationOptions s_defaultOptions = new CoreCompilationOptions(OutputKind.ConsoleApplication);
        private static readonly CoreCompilationOptions s_defaultSubmissionOptions = new CoreCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);
        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static CoreCompilation Create(
            string? assemblyName,
            IEnumerable<SyntaxTree>? syntaxTrees = null,
            IEnumerable<MetadataReference>? references = null,
            CoreCompilationOptions? options = null)
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
        public static CoreCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree? syntaxTree = null,
            IEnumerable<MetadataReference>? references = null,
            CoreCompilationOptions? options = null,
            CoreCompilation? previousScriptCompilation = null,
            Type? returnType = null,
            Type? globalsType = null)
        {
            CheckSubmissionOptions(options);
            ValidateScriptCompilationParameters(previousScriptCompilation, returnType, ref globalsType);
            return Create(
                assemblyName,
                options?.WithReferencesSupersedeLowerVersions(true) ?? s_defaultSubmissionOptions,
                (syntaxTree != null) ? new[] { syntaxTree } : null,
                references,
                previousScriptCompilation,
                returnType,
                globalsType,
                isSubmission: true);
        }
        private static CoreCompilation Create(
            string? assemblyName,
            CoreCompilationOptions options,
            IEnumerable<SyntaxTree>? syntaxTrees,
            IEnumerable<MetadataReference>? references,
            CoreCompilation? previousSubmission,
            Type? returnType,
            Type? hostObjectType,
            bool isSubmission)
        {
            var compilation = new CoreCompilation(
                assemblyName,
                options,
                references,
                previousSubmission,
                returnType,
                hostObjectType,
                isSubmission,
                referenceManager: null,
                reuseReferenceManager: false,
                syntaxAndDeclarations: new SyntaxAndDeclarationManager(
                    options.Language,
                    ImmutableArray<SyntaxTree>.Empty,
                    options.ScriptClassName,
                    options.SourceReferenceResolver,
                    isSubmission,
                    state: null),
                semanticModelProvider: null);
            if (syntaxTrees != null)
            {
                compilation = compilation.AddSyntaxTrees(syntaxTrees);
            }
            return compilation;
        }
        protected CoreCompilation(string assemblyName, CoreCompilationOptions options, IEnumerable<MetadataReference> references, CoreCompilation previousSubmission, Type submissionReturnType, Type hostObjectType, bool isSubmission, ReferenceManager referenceManager, bool reuseReferenceManager, SyntaxAndDeclarationManager syntaxAndDeclarations, SemanticModelProvider semanticModelProvider, AsyncQueue<CompilationEvent> eventQueue = null)
            : base(assemblyName, options, references, previousSubmission, submissionReturnType, hostObjectType, isSubmission, referenceManager, reuseReferenceManager, syntaxAndDeclarations, semanticModelProvider, eventQueue)
        {
        }
        /// <summary>
        /// Create a duplicate of this compilation with different symbol instances.
        /// </summary>
        protected override LanguageCompilation CreateNew(
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
            SemanticModelProvider semanticModelProvider,
            AsyncQueue<CompilationEvent> eventQueue = null)
        {
            return new CoreCompilation(
                assemblyName,
                (CoreCompilationOptions)options,
                references,
                (CoreCompilation)previousSubmission,
                submissionReturnType,
                hostObjectType,
                isSubmission,
                referenceManager,
                reuseReferenceManager,
                syntaxAndDeclarations,
                semanticModelProvider,
                eventQueue);
        }
        protected override Compilation CommonClone()
        {
            return this.Clone();
        }
        /// <summary>
        /// Creates a new compilation with the specified name.
        /// </summary>
        public new CoreCompilation WithAssemblyName(string assemblyName) => (CoreCompilation)base.WithAssemblyName(assemblyName);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <remarks>
        /// The new <see cref="CoreCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying
        /// metadata as soon as the are needed.
        ///
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new CoreCompilation WithReferences(IEnumerable<MetadataReference> references) => (CoreCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        public new CoreCompilation WithReferences(params MetadataReference[] references) => (CoreCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public CoreCompilation WithOptions(CoreCompilationOptions options) => (CoreCompilation)base.WithOptions(options);
        #endregion
        #region Syntax Trees (maintain an ordered list)
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new CoreCompilation AddSyntaxTrees(params SyntaxTree[] trees) => (CoreCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new CoreCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees) => (CoreCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new CoreCompilation RemoveSyntaxTrees(params SyntaxTree[] trees) => (CoreCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new CoreCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees) => (CoreCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info
        /// from this compilation for use with trees added later.
        /// </summary>
        public new CoreCompilation RemoveAllSyntaxTrees() => (CoreCompilation)base.RemoveAllSyntaxTrees();
        /// <summary>
        /// Creates a new compilation without the old tree but with the new tree.
        /// </summary>
        public new CoreCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree) => (CoreCompilation)base.ReplaceSyntaxTree(oldTree, newTree);
        #endregion
        #region References
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new CoreCompilation AddReferences(params MetadataReference[] references) => (CoreCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new CoreCompilation AddReferences(IEnumerable<MetadataReference> references) => (CoreCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new CoreCompilation RemoveReferences(params MetadataReference[] references) => (CoreCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new CoreCompilation RemoveReferences(IEnumerable<MetadataReference> references) => (CoreCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without any metadata references
        /// </summary>
        public new CoreCompilation RemoveAllReferences() => (CoreCompilation)base.RemoveAllReferences();
        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata reference.
        /// </summary>
        public new CoreCompilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference) => (CoreCompilation)base.ReplaceReference(oldReference, newReference);
        #endregion
    }
}


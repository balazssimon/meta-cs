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

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilation : LanguageCompilation
    {
        #region Constructors and Factories
        
        private static readonly MetaCompilationOptions s_defaultOptions = new MetaCompilationOptions(OutputKind.ConsoleApplication);
        private static readonly MetaCompilationOptions s_defaultSubmissionOptions = new MetaCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);

        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static MetaCompilation Create(
            string? assemblyName,
            IEnumerable<SyntaxTree>? syntaxTrees = null,
            IEnumerable<MetadataReference>? references = null,
            MetaCompilationOptions? options = null)
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
        public static MetaCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree? syntaxTree = null,
            IEnumerable<MetadataReference>? references = null,
            MetaCompilationOptions? options = null,
            MetaCompilation? previousScriptCompilation = null,
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

        private static MetaCompilation Create(
            string? assemblyName,
            MetaCompilationOptions options,
            IEnumerable<SyntaxTree>? syntaxTrees,
            IEnumerable<MetadataReference>? references,
            MetaCompilation? previousSubmission,
            Type? returnType,
            Type? hostObjectType,
            bool isSubmission)
        {
            var compilation = new MetaCompilation(
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

        protected MetaCompilation(string assemblyName, MetaCompilationOptions options, IEnumerable<MetadataReference> references, MetaCompilation previousSubmission, Type submissionReturnType, Type hostObjectType, bool isSubmission, ReferenceManager referenceManager, bool reuseReferenceManager, SyntaxAndDeclarationManager syntaxAndDeclarations, SemanticModelProvider semanticModelProvider, AsyncQueue<CompilationEvent> eventQueue = null)
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
            return new MetaCompilation(
                assemblyName,
                (MetaCompilationOptions)options,
                references,
                (MetaCompilation)previousSubmission,
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
        public new MetaCompilation WithAssemblyName(string assemblyName) => (MetaCompilation)base.WithAssemblyName(assemblyName);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <remarks>
        /// The new <see cref="MetaCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying
        /// metadata as soon as the are needed.
        ///
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new MetaCompilation WithReferences(IEnumerable<MetadataReference> references) => (MetaCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        public new MetaCompilation WithReferences(params MetadataReference[] references) => (MetaCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public MetaCompilation WithOptions(MetaCompilationOptions options) => (MetaCompilation)base.WithOptions(options);
        #endregion
        #region Syntax Trees (maintain an ordered list)
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new MetaCompilation AddSyntaxTrees(params SyntaxTree[] trees) => (MetaCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new MetaCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees) => (MetaCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new MetaCompilation RemoveSyntaxTrees(params SyntaxTree[] trees) => (MetaCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new MetaCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees) => (MetaCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info
        /// from this compilation for use with trees added later.
        /// </summary>
        public new MetaCompilation RemoveAllSyntaxTrees() => (MetaCompilation)base.RemoveAllSyntaxTrees();
        /// <summary>
        /// Creates a new compilation without the old tree but with the new tree.
        /// </summary>
        public new MetaCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree) => (MetaCompilation)base.ReplaceSyntaxTree(oldTree, newTree);
        #endregion
        #region References
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new MetaCompilation AddReferences(params MetadataReference[] references) => (MetaCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new MetaCompilation AddReferences(IEnumerable<MetadataReference> references) => (MetaCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new MetaCompilation RemoveReferences(params MetadataReference[] references) => (MetaCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new MetaCompilation RemoveReferences(IEnumerable<MetadataReference> references) => (MetaCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without any metadata references
        /// </summary>
        public new MetaCompilation RemoveAllReferences() => (MetaCompilation)base.RemoveAllReferences();
        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata reference.
        /// </summary>
        public new MetaCompilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference) => (MetaCompilation)base.ReplaceReference(oldReference, newReference);
        #endregion
    }
}


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

namespace MetaDslx.Languages.Compiler
{
    public class CompilerCompilation : LanguageCompilation
    {
        #region Constructors and Factories
        private static readonly CompilerCompilationOptions s_defaultOptions = new CompilerCompilationOptions(OutputKind.ConsoleApplication);
        private static readonly CompilerCompilationOptions s_defaultSubmissionOptions = new CompilerCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);
        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static CompilerCompilation Create(
            string? assemblyName,
            IEnumerable<SyntaxTree>? syntaxTrees = null,
            IEnumerable<MetadataReference>? references = null,
            CompilerCompilationOptions? options = null)
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
        public static CompilerCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree? syntaxTree = null,
            IEnumerable<MetadataReference>? references = null,
            CompilerCompilationOptions? options = null,
            CompilerCompilation? previousScriptCompilation = null,
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
        private static CompilerCompilation Create(
            string? assemblyName,
            CompilerCompilationOptions options,
            IEnumerable<SyntaxTree>? syntaxTrees,
            IEnumerable<MetadataReference>? references,
            CompilerCompilation? previousSubmission,
            Type? returnType,
            Type? hostObjectType,
            bool isSubmission)
        {
            var compilation = new CompilerCompilation(
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
        protected CompilerCompilation(string assemblyName, CompilerCompilationOptions options, IEnumerable<MetadataReference> references, CompilerCompilation previousSubmission, Type submissionReturnType, Type hostObjectType, bool isSubmission, ReferenceManager referenceManager, bool reuseReferenceManager, SyntaxAndDeclarationManager syntaxAndDeclarations, SemanticModelProvider semanticModelProvider, AsyncQueue<CompilationEvent> eventQueue = null)
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
            return new CompilerCompilation(
                assemblyName,
                (CompilerCompilationOptions)options,
                references,
                (CompilerCompilation)previousSubmission,
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
        public new CompilerCompilation WithAssemblyName(string assemblyName) => (CompilerCompilation)base.WithAssemblyName(assemblyName);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <remarks>
        /// The new <see cref="CompilerCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying
        /// metadata as soon as the are needed.
        ///
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new CompilerCompilation WithReferences(IEnumerable<MetadataReference> references) => (CompilerCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        public new CompilerCompilation WithReferences(params MetadataReference[] references) => (CompilerCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public CompilerCompilation WithOptions(CompilerCompilationOptions options) => (CompilerCompilation)base.WithOptions(options);
        #endregion
        #region Syntax Trees (maintain an ordered list)
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new CompilerCompilation AddSyntaxTrees(params SyntaxTree[] trees) => (CompilerCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new CompilerCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees) => (CompilerCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new CompilerCompilation RemoveSyntaxTrees(params SyntaxTree[] trees) => (CompilerCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new CompilerCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees) => (CompilerCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info
        /// from this compilation for use with trees added later.
        /// </summary>
        public new CompilerCompilation RemoveAllSyntaxTrees() => (CompilerCompilation)base.RemoveAllSyntaxTrees();
        /// <summary>
        /// Creates a new compilation without the old tree but with the new tree.
        /// </summary>
        public new CompilerCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree) => (CompilerCompilation)base.ReplaceSyntaxTree(oldTree, newTree);
        #endregion
        #region References
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new CompilerCompilation AddReferences(params MetadataReference[] references) => (CompilerCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new CompilerCompilation AddReferences(IEnumerable<MetadataReference> references) => (CompilerCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new CompilerCompilation RemoveReferences(params MetadataReference[] references) => (CompilerCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new CompilerCompilation RemoveReferences(IEnumerable<MetadataReference> references) => (CompilerCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without any metadata references
        /// </summary>
        public new CompilerCompilation RemoveAllReferences() => (CompilerCompilation)base.RemoveAllReferences();
        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata reference.
        /// </summary>
        public new CompilerCompilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference) => (CompilerCompilation)base.ReplaceReference(oldReference, newReference);
        #endregion
    }
}


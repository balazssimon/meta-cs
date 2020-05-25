// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations
{
    public class TestLanguageAnnotationsCompilation : LanguageCompilation
    {
        #region Constructors and Factories
        private static readonly TestLanguageAnnotationsCompilationOptions s_defaultOptions = new TestLanguageAnnotationsCompilationOptions(OutputKind.ConsoleApplication);
        private static readonly TestLanguageAnnotationsCompilationOptions s_defaultSubmissionOptions = new TestLanguageAnnotationsCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);
        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static TestLanguageAnnotationsCompilation Create(
            string assemblyName,
            IEnumerable<SyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            TestLanguageAnnotationsCompilationOptions options = null)
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
        public static TestLanguageAnnotationsCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            TestLanguageAnnotationsCompilationOptions options = null,
            TestLanguageAnnotationsCompilation previousScriptCompilation = null,
            Type returnType = null,
            Type globalsType = null)
        {
            CheckSubmissionOptions(options);
            ValidateScriptCompilationParameters(previousScriptCompilation, returnType, ref globalsType);
            return Create(
                assemblyName,
                options?.WithReferencesSupersedeLowerVersions(true) ?? s_defaultSubmissionOptions,
                (syntaxTree != null) ? new[] { syntaxTree } : NoSyntaxTrees,
                references,
                previousScriptCompilation,
                returnType,
                globalsType,
                isSubmission: true);
        }
        private static TestLanguageAnnotationsCompilation Create(
            string assemblyName,
            TestLanguageAnnotationsCompilationOptions options,
            IEnumerable<SyntaxTree> syntaxTrees,
            IEnumerable<MetadataReference> references,
            TestLanguageAnnotationsCompilation previousSubmission,
            Type returnType,
            Type hostObjectType,
            bool isSubmission)
        {
            Debug.Assert(options != null);
            Debug.Assert(!isSubmission || options.ReferencesSupersedeLowerVersions);
            var compilation = new TestLanguageAnnotationsCompilation(
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
                    ImmutableArray<SyntaxTree>.Empty,
                    options.ScriptClassName,
                    options.SourceReferenceResolver,
                    options.Language,
                    isSubmission,
                    state: null));
            if (syntaxTrees != null)
            {
                compilation = compilation.AddSyntaxTrees(syntaxTrees);
            }
            return compilation;
        }
        protected TestLanguageAnnotationsCompilation(string assemblyName, TestLanguageAnnotationsCompilationOptions options, IEnumerable<MetadataReference> references, TestLanguageAnnotationsCompilation previousSubmission, Type submissionReturnType, Type hostObjectType, bool isSubmission, ReferenceManager referenceManager, bool reuseReferenceManager, SyntaxAndDeclarationManager syntaxAndDeclarations, AsyncQueue<CompilationEvent> eventQueue = null)
            : base(assemblyName, options, references, previousSubmission, submissionReturnType, hostObjectType, isSubmission, referenceManager, reuseReferenceManager, syntaxAndDeclarations, eventQueue)
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
            AsyncQueue<CompilationEvent> eventQueue = null)
        {
            return new TestLanguageAnnotationsCompilation(
                assemblyName, 
                (TestLanguageAnnotationsCompilationOptions)options, 
                references, 
                (TestLanguageAnnotationsCompilation)previousSubmission, 
                submissionReturnType, 
                hostObjectType, 
                isSubmission, 
                referenceManager, 
                reuseReferenceManager, 
                syntaxAndDeclarations, 
                eventQueue);
        }
        protected override Compilation CommonClone()
        {
            return this.Clone();
        }
        /// <summary>
        /// Creates a new compilation with the specified name.
        /// </summary>
        public new TestLanguageAnnotationsCompilation WithAssemblyName(string assemblyName) => (TestLanguageAnnotationsCompilation)base.WithAssemblyName(assemblyName);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <remarks>
        /// The new <see cref="TestLanguageAnnotationsCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying
        /// metadata as soon as the are needed.
        ///
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new TestLanguageAnnotationsCompilation WithReferences(IEnumerable<MetadataReference> references) => (TestLanguageAnnotationsCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        public new TestLanguageAnnotationsCompilation WithReferences(params MetadataReference[] references) => (TestLanguageAnnotationsCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public TestLanguageAnnotationsCompilation WithOptions(TestLanguageAnnotationsCompilationOptions options) => (TestLanguageAnnotationsCompilation)base.WithOptions(options);
        #endregion
        #region Syntax Trees (maintain an ordered list)
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new TestLanguageAnnotationsCompilation AddSyntaxTrees(params SyntaxTree[] trees) => (TestLanguageAnnotationsCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new TestLanguageAnnotationsCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees) => (TestLanguageAnnotationsCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new TestLanguageAnnotationsCompilation RemoveSyntaxTrees(params SyntaxTree[] trees) => (TestLanguageAnnotationsCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new TestLanguageAnnotationsCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees) => (TestLanguageAnnotationsCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info
        /// from this compilation for use with trees added later.
        /// </summary>
        public new TestLanguageAnnotationsCompilation RemoveAllSyntaxTrees() => (TestLanguageAnnotationsCompilation)base.RemoveAllSyntaxTrees();
        /// <summary>
        /// Creates a new compilation without the old tree but with the new tree.
        /// </summary>
        public new TestLanguageAnnotationsCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree) => (TestLanguageAnnotationsCompilation)base.ReplaceSyntaxTree(oldTree, newTree);
        #endregion
        #region References
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new TestLanguageAnnotationsCompilation AddReferences(params MetadataReference[] references) => (TestLanguageAnnotationsCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new TestLanguageAnnotationsCompilation AddReferences(IEnumerable<MetadataReference> references) => (TestLanguageAnnotationsCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new TestLanguageAnnotationsCompilation RemoveReferences(params MetadataReference[] references) => (TestLanguageAnnotationsCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new TestLanguageAnnotationsCompilation RemoveReferences(IEnumerable<MetadataReference> references) => (TestLanguageAnnotationsCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without any metadata references
        /// </summary>
        public new TestLanguageAnnotationsCompilation RemoveAllReferences() => (TestLanguageAnnotationsCompilation)base.RemoveAllReferences();
        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata reference.
        /// </summary>
        public new TestLanguageAnnotationsCompilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference) => (TestLanguageAnnotationsCompilation)base.ReplaceReference(oldReference, newReference);
        #endregion
    }
}


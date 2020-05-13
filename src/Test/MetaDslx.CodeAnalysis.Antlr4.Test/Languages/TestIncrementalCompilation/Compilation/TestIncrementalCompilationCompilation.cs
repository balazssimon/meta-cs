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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation
{
    public class TestIncrementalCompilationCompilation : LanguageCompilation
    {
        #region Constructors and Factories
        private static readonly TestIncrementalCompilationCompilationOptions s_defaultOptions = new TestIncrementalCompilationCompilationOptions(TestIncrementalCompilationLanguage.Instance, OutputKind.ConsoleApplication);
        private static readonly TestIncrementalCompilationCompilationOptions s_defaultSubmissionOptions = new TestIncrementalCompilationCompilationOptions(TestIncrementalCompilationLanguage.Instance, OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);
        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static TestIncrementalCompilationCompilation Create(
            string assemblyName,
            IEnumerable<SyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            TestIncrementalCompilationCompilationOptions options = null)
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
        public static TestIncrementalCompilationCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            TestIncrementalCompilationCompilationOptions options = null,
            TestIncrementalCompilationCompilation previousScriptCompilation = null,
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
        private static TestIncrementalCompilationCompilation Create(
            string assemblyName,
            TestIncrementalCompilationCompilationOptions options,
            IEnumerable<SyntaxTree> syntaxTrees,
            IEnumerable<MetadataReference> references,
            TestIncrementalCompilationCompilation previousSubmission,
            Type returnType,
            Type hostObjectType,
            bool isSubmission)
        {
            Debug.Assert(options != null);
            Debug.Assert(!isSubmission || options.ReferencesSupersedeLowerVersions);
            var compilation = new TestIncrementalCompilationCompilation(
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
        protected TestIncrementalCompilationCompilation(string assemblyName, TestIncrementalCompilationCompilationOptions options, IEnumerable<MetadataReference> references, TestIncrementalCompilationCompilation previousSubmission, Type submissionReturnType, Type hostObjectType, bool isSubmission, ReferenceManager referenceManager, bool reuseReferenceManager, SyntaxAndDeclarationManager syntaxAndDeclarations, AsyncQueue<CompilationEvent> eventQueue = null)
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
            return new TestIncrementalCompilationCompilation(
                assemblyName, 
                (TestIncrementalCompilationCompilationOptions)options, 
                references, 
                (TestIncrementalCompilationCompilation)previousSubmission, 
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
        public new TestIncrementalCompilationCompilation WithAssemblyName(string assemblyName) => (TestIncrementalCompilationCompilation)base.WithAssemblyName(assemblyName);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <remarks>
        /// The new <see cref="TestIncrementalCompilationCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying
        /// metadata as soon as the are needed.
        ///
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new TestIncrementalCompilationCompilation WithReferences(IEnumerable<MetadataReference> references) => (TestIncrementalCompilationCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        public new TestIncrementalCompilationCompilation WithReferences(params MetadataReference[] references) => (TestIncrementalCompilationCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public TestIncrementalCompilationCompilation WithOptions(TestIncrementalCompilationCompilationOptions options) => (TestIncrementalCompilationCompilation)base.WithOptions(options);
        #endregion
        #region Syntax Trees (maintain an ordered list)
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new TestIncrementalCompilationCompilation AddSyntaxTrees(params SyntaxTree[] trees) => (TestIncrementalCompilationCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new TestIncrementalCompilationCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees) => (TestIncrementalCompilationCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new TestIncrementalCompilationCompilation RemoveSyntaxTrees(params SyntaxTree[] trees) => (TestIncrementalCompilationCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new TestIncrementalCompilationCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees) => (TestIncrementalCompilationCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info
        /// from this compilation for use with trees added later.
        /// </summary>
        public new TestIncrementalCompilationCompilation RemoveAllSyntaxTrees() => (TestIncrementalCompilationCompilation)base.RemoveAllSyntaxTrees();
        /// <summary>
        /// Creates a new compilation without the old tree but with the new tree.
        /// </summary>
        public new TestIncrementalCompilationCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree) => (TestIncrementalCompilationCompilation)base.ReplaceSyntaxTree(oldTree, newTree);
        #endregion
        #region References
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new TestIncrementalCompilationCompilation AddReferences(params MetadataReference[] references) => (TestIncrementalCompilationCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new TestIncrementalCompilationCompilation AddReferences(IEnumerable<MetadataReference> references) => (TestIncrementalCompilationCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new TestIncrementalCompilationCompilation RemoveReferences(params MetadataReference[] references) => (TestIncrementalCompilationCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new TestIncrementalCompilationCompilation RemoveReferences(IEnumerable<MetadataReference> references) => (TestIncrementalCompilationCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without any metadata references
        /// </summary>
        public new TestIncrementalCompilationCompilation RemoveAllReferences() => (TestIncrementalCompilationCompilation)base.RemoveAllReferences();
        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata reference.
        /// </summary>
        public new TestIncrementalCompilationCompilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference) => (TestIncrementalCompilationCompilation)base.ReplaceReference(oldReference, newReference);
        #endregion
    }
}


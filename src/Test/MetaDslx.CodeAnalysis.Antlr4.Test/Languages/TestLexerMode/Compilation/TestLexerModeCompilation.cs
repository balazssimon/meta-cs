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

namespace MetaDslx.CodeAnalysis.Antlr4Test
{
    public class TestLexerModeCompilation : LanguageCompilation
    {
        #region Constructors and Factories
        private static readonly TestLexerModeCompilationOptions s_defaultOptions = new TestLexerModeCompilationOptions(TestLexerModeLanguage.Instance, OutputKind.ConsoleApplication);
        private static readonly TestLexerModeCompilationOptions s_defaultSubmissionOptions = new TestLexerModeCompilationOptions(TestLexerModeLanguage.Instance, OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);
        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static TestLexerModeCompilation Create(
            string assemblyName,
            IEnumerable<SyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            TestLexerModeCompilationOptions options = null)
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
        public static TestLexerModeCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            TestLexerModeCompilationOptions options = null,
            TestLexerModeCompilation previousScriptCompilation = null,
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
        private static TestLexerModeCompilation Create(
            string assemblyName,
            TestLexerModeCompilationOptions options,
            IEnumerable<SyntaxTree> syntaxTrees,
            IEnumerable<MetadataReference> references,
            TestLexerModeCompilation previousSubmission,
            Type returnType,
            Type hostObjectType,
            bool isSubmission)
        {
            Debug.Assert(options != null);
            Debug.Assert(!isSubmission || options.ReferencesSupersedeLowerVersions);
            var compilation = new TestLexerModeCompilation(
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
        protected TestLexerModeCompilation(string assemblyName, TestLexerModeCompilationOptions options, IEnumerable<MetadataReference> references, TestLexerModeCompilation previousSubmission, Type submissionReturnType, Type hostObjectType, bool isSubmission, ReferenceManager referenceManager, bool reuseReferenceManager, SyntaxAndDeclarationManager syntaxAndDeclarations, AsyncQueue<CompilationEvent> eventQueue = null)
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
            return new TestLexerModeCompilation(
                assemblyName, 
                (TestLexerModeCompilationOptions)options, 
                references, 
                (TestLexerModeCompilation)previousSubmission, 
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
        public new TestLexerModeCompilation WithAssemblyName(string assemblyName) => (TestLexerModeCompilation)base.WithAssemblyName(assemblyName);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <remarks>
        /// The new <see cref="TestLexerModeCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying
        /// metadata as soon as the are needed.
        ///
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new TestLexerModeCompilation WithReferences(IEnumerable<MetadataReference> references) => (TestLexerModeCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        public new TestLexerModeCompilation WithReferences(params MetadataReference[] references) => (TestLexerModeCompilation)base.WithReferences(references);
        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public TestLexerModeCompilation WithOptions(TestLexerModeCompilationOptions options) => (TestLexerModeCompilation)base.WithOptions(options);
        #endregion
        #region Syntax Trees (maintain an ordered list)
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new TestLexerModeCompilation AddSyntaxTrees(params SyntaxTree[] trees) => (TestLexerModeCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        public new TestLexerModeCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees) => (TestLexerModeCompilation)base.AddSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new TestLexerModeCompilation RemoveSyntaxTrees(params SyntaxTree[] trees) => (TestLexerModeCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        public new TestLexerModeCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees) => (TestLexerModeCompilation)base.RemoveSyntaxTrees(trees);
        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info
        /// from this compilation for use with trees added later.
        /// </summary>
        public new TestLexerModeCompilation RemoveAllSyntaxTrees() => (TestLexerModeCompilation)base.RemoveAllSyntaxTrees();
        /// <summary>
        /// Creates a new compilation without the old tree but with the new tree.
        /// </summary>
        public new TestLexerModeCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree) => (TestLexerModeCompilation)base.ReplaceSyntaxTree(oldTree, newTree);
        #endregion
        #region References
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new TestLexerModeCompilation AddReferences(params MetadataReference[] references) => (TestLexerModeCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        public new TestLexerModeCompilation AddReferences(IEnumerable<MetadataReference> references) => (TestLexerModeCompilation)base.AddReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new TestLexerModeCompilation RemoveReferences(params MetadataReference[] references) => (TestLexerModeCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        public new TestLexerModeCompilation RemoveReferences(IEnumerable<MetadataReference> references) => (TestLexerModeCompilation)base.RemoveReferences(references);
        /// <summary>
        /// Creates a new compilation without any metadata references
        /// </summary>
        public new TestLexerModeCompilation RemoveAllReferences() => (TestLexerModeCompilation)base.RemoveAllReferences();
        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata reference.
        /// </summary>
        public new TestLexerModeCompilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference) => (TestLexerModeCompilation)base.ReplaceReference(oldReference, newReference);
        #endregion
    }
}


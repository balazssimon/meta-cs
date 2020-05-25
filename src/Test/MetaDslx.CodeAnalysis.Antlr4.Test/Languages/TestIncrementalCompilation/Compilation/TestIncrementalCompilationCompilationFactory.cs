// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Binding;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation
{
    public class TestIncrementalCompilationCompilationFactory : CompilationFactory
    {
        internal TestIncrementalCompilationCompilationFactory()
        {
        }

        /// <summary>
        /// Default compilation options for the TestIncrementalCompilation language
        /// </summary>
        public override LanguageCompilationOptions DefaultCompilationOptions => new TestIncrementalCompilationCompilationOptions(OutputKind.ConsoleApplication);

        /// <summary>
        /// Default compilation options for script submissions for the TestIncrementalCompilation language
        /// </summary>
        public override LanguageCompilationOptions DefaultSubmissionOptions => new TestIncrementalCompilationCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);

        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public override LanguageCompilation CreateCompilation(
            string assemblyName,
            IEnumerable<SyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null)
        {
            return TestIncrementalCompilationCompilation.Create(assemblyName, syntaxTrees, references, (TestIncrementalCompilationCompilationOptions)options);
        }

        /// <summary>
        /// Creates a new compilation that can be used in scripting.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTree">The syntax tree with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <param name="previousScriptCompilation">The compilation of the previous state of the script.</param>
        /// <param name="returnType">The return type resulting from the script.</param>
        /// <param name="globalsType">The type from which the script can take the global variables.</param>
        /// <returns>A new compilation.</returns>
        public override LanguageCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null,
            LanguageCompilation previousScriptCompilation = null,
            Type returnType = null,
            Type globalsType = null)
        {
            return TestIncrementalCompilationCompilation.CreateScriptCompilation(assemblyName, syntaxTree, references, (TestIncrementalCompilationCompilationOptions)options, (TestIncrementalCompilationCompilation)previousScriptCompilation, returnType, globalsType);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new TestIncrementalCompilationBinderFactoryVisitor(binderFactory);
        }

        public override BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree)
        {
            return new TestIncrementalCompilationBoundNodeFactoryVisitor(boundTree);
        }

		public override IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree)
        {
            return new TestIncrementalCompilationIsBindableNodeVisitor(boundTree);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return TestIncrementalCompilationDeclarationTreeBuilderVisitor.ForTree((TestIncrementalCompilationSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        /*public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new TestIncrementalCompilationScriptCompilationInfo((TestIncrementalCompilationCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new TestIncrementalCompilationSymbolBuilder((TestIncrementalCompilationCompilation)compilation);
        }*/
    }
}


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
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Binding;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Symbols;

using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations
{
    public class TestLanguageAnnotationsCompilationFactory : CompilationFactory
    {
        internal TestLanguageAnnotationsCompilationFactory()
        {
        }

        /// <summary>
        /// Default compilation options for the TestLanguageAnnotations language
        /// </summary>
        public override LanguageCompilationOptions DefaultCompilationOptions => new TestLanguageAnnotationsCompilationOptions(OutputKind.ConsoleApplication);

        /// <summary>
        /// Default compilation options for script submissions for the TestLanguageAnnotations language
        /// </summary>
        public override LanguageCompilationOptions DefaultSubmissionOptions => new TestLanguageAnnotationsCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);

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
            return TestLanguageAnnotationsCompilation.Create(assemblyName, syntaxTrees, references, (TestLanguageAnnotationsCompilationOptions)options);
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
            System.Type returnType = null,
            System.Type globalsType = null)
        {
            return TestLanguageAnnotationsCompilation.CreateScriptCompilation(assemblyName, syntaxTree, references, (TestLanguageAnnotationsCompilationOptions)options, (TestLanguageAnnotationsCompilation)previousScriptCompilation, returnType, globalsType);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new TestLanguageAnnotationsBinderFactoryVisitor(binderFactory);
        }

        public override BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree)
        {
            return new TestLanguageAnnotationsBoundNodeFactoryVisitor(boundTree);
        }

		public override IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree)
        {
            return new TestLanguageAnnotationsIsBindableNodeVisitor(boundTree);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return TestLanguageAnnotationsDeclarationTreeBuilderVisitor.ForTree((TestLanguageAnnotationsSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        /*public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new TestLanguageAnnotationsScriptCompilationInfo((TestLanguageAnnotationsCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new TestLanguageAnnotationsSymbolBuilder((TestLanguageAnnotationsCompilation)compilation);
        }*/
    }
}


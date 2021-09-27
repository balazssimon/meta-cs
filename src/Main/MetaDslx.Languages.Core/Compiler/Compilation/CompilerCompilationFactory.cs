// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Languages.Compiler;
using MetaDslx.Languages.Compiler.Syntax;
using MetaDslx.Languages.Compiler.Binding;
using MetaDslx.Languages.Compiler.Symbols;

using MetaDslx.Languages.Compiler.Model;

namespace MetaDslx.Languages.Compiler
{
    public class CompilerCompilationFactory : CompilationFactory
    {
        internal CompilerCompilationFactory()
        {
        }

        public new CompilerLanguage Language => CompilerLanguage.Instance;
        protected override Language LanguageCore => this.Language;

        /// <summary>
        /// Default compilation options for the Compiler language
        /// </summary>
        public override LanguageCompilationOptions DefaultCompilationOptions => new CompilerCompilationOptions(OutputKind.ConsoleApplication);

        /// <summary>
        /// Default compilation options for script submissions for the Compiler language
        /// </summary>
        public override LanguageCompilationOptions DefaultSubmissionOptions => new CompilerCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);

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
            return CompilerCompilation.Create(assemblyName, syntaxTrees, references, (CompilerCompilationOptions)options);
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
            global::System.Type returnType = null,
            global::System.Type globalsType = null)
        {
            return CompilerCompilation.CreateScriptCompilation(assemblyName, syntaxTree, references, (CompilerCompilationOptions)options, (CompilerCompilation)previousScriptCompilation, returnType, globalsType);
        }

        public override BinderFactory CreateBinderFactory(BinderCache binderCache)
        {
            return new CompilerBinderFactory(binderCache);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new CompilerBinderFactoryVisitor((CompilerBinderFactory)binderFactory);
        }

        public override CompletionBinderFactoryVisitor CreateCompletionBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new CompilerCompletionBinderFactoryVisitor((CompilerBinderFactory)binderFactory);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return CompilerDeclarationTreeBuilderVisitor.ForTree((CompilerSyntaxTree)syntaxTree, this.Language.SymbolFacts, scriptClassName, isSubmission);
        }
    }
}


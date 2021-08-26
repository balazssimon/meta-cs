// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Binding;
using MetaDslx.Languages.Meta.Symbols;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilationFactory : CompilationFactory
    {
        internal MetaCompilationFactory()
        {
        }

        public new MetaLanguage Language => MetaLanguage.Instance;
        protected override Language LanguageCore => this.Language;

        /// <summary>
        /// Default compilation options for the Meta language
        /// </summary>
        public override LanguageCompilationOptions DefaultCompilationOptions => new MetaCompilationOptions(OutputKind.ConsoleApplication);

        /// <summary>
        /// Default compilation options for script submissions for the Meta language
        /// </summary>
        public override LanguageCompilationOptions DefaultSubmissionOptions => new MetaCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);

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
            return MetaCompilation.Create(assemblyName, syntaxTrees, references, (MetaCompilationOptions)options);
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
            return MetaCompilation.CreateScriptCompilation(assemblyName, syntaxTree, references, (MetaCompilationOptions)options, (MetaCompilation)previousScriptCompilation, returnType, globalsType);
        }

        public override BinderFactory CreateBinderFactory(BinderCache binderCache)
        {
            return new MetaBinderFactory(binderCache);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new MetaBinderFactoryVisitor((MetaBinderFactory)binderFactory);
        }

        public override CompletionBinderFactoryVisitor CreateCompletionBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new MetaCompletionBinderFactoryVisitor((MetaBinderFactory)binderFactory);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return MetaDeclarationTreeBuilderVisitor.ForTree((MetaSyntaxTree)syntaxTree, this.Language.SymbolFacts, scriptClassName, isSubmission);
        }
    }
}


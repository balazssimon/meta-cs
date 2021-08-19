using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Completion;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    public abstract class CompilationFactory
    {
        public CompilationFactory()
        {
        }

        public Language Language => this.LanguageCore;
        protected abstract Language LanguageCore { get; }

        public abstract LanguageCompilationOptions DefaultCompilationOptions { get; }
        public abstract LanguageCompilationOptions DefaultSubmissionOptions { get; }

        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public abstract LanguageCompilation CreateCompilation(
            string assemblyName,
            IEnumerable<SyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null);

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
        public abstract LanguageCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null,
            LanguageCompilation previousScriptCompilation = null,
            Type returnType = null,
            Type globalsType = null);


        public abstract RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
        public abstract BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory);

        public virtual ObjectFactory CreateObjectFactory(LanguageCompilation compilation)
        {
            return new MetaObjectFactory(compilation);
        }

        public virtual SymbolFactory CreateSymbolFactory(ModuleSymbol module)
        {
            return new SymbolFactory(module);
        }

        public virtual Conversions CreateStandardConversions(LanguageCompilation compilation)
        {
            return new StandardConversions(compilation);
        }

        public virtual Conversions CreateUserDefinedConversions(LanguageCompilation compilation)
        {
            return new NoConversions(compilation);
        }

        public virtual UnaryOperators CreateStandardUnaryOperators(LanguageCompilation compilation)
        {
            return new StandardUnaryOperators(compilation);
        }

        public virtual UnaryOperators CreateUserDefinedUnaryOperators(LanguageCompilation compilation)
        {
            return new NoUnaryOperators(compilation);
        }

        public virtual OverloadResolution CreateOverloadResolution(LanguageCompilation compilation)
        {
            return new OverloadResolution(compilation);
        }
    }
}

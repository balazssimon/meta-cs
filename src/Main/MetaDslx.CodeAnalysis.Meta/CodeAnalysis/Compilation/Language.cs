using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    public abstract class Language
    {
        public static readonly Language None = new NoLanguage();

        public abstract string Name { get; }

        public SyntaxFacts SyntaxFacts => this.SyntaxFactsCore;
        internal protected abstract SyntaxFacts SyntaxFactsCore { get; }
        public InternalSyntaxFactory InternalSyntaxFactory => this.InternalSyntaxFactoryCore;
        internal protected abstract InternalSyntaxFactory InternalSyntaxFactoryCore { get; }
        public SyntaxFactory SyntaxFactory => this.SyntaxFactoryCore;
        internal protected abstract SyntaxFactory SyntaxFactoryCore { get; }
        public CompilationFactory CompilationFactory => this.CompilationFactoryCore;
        internal protected abstract CompilationFactory CompilationFactoryCore { get; }
        public SymbolFacts SymbolFacts => this.SymbolFactsCore;
        internal protected abstract SymbolFacts SymbolFactsCore { get; }

        public LanguageParseOptions DefaultParseOptions => this.SyntaxFactory.DefaultParseOptions;
        public LanguageCompilationOptions DefaultCompilationOptions => this.CompilationFactory.DefaultCompilationOptions;
        public LanguageCompilationOptions DefaultSubmissionOptions => this.CompilationFactory.DefaultSubmissionOptions;

        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        /// <param name="text">The source code to be parsed.</param>
        /// <param name="options">The options for parsing.</param>
        /// <param name="path">The file path of the source code. Used to provide better diagnostics.</param>
        /// <param name="cancellationToken">Can be used to cancel the parsing process.</param>
        public LanguageSyntaxTree ParseSyntaxTree(SourceText text, ParseOptions options = null, string path = "", CancellationToken cancellationToken = default)
        {
            return this.SyntaxFactory.ParseSyntaxTree(text, options, path, cancellationToken);
        }

        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public LanguageCompilation CreateCompilation(
            string assemblyName,
            IEnumerable<SyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null)
        {
            return this.CompilationFactory.CreateCompilation(assemblyName, syntaxTrees, references, options);
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
        public LanguageCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null,
            LanguageCompilation previousScriptCompilation = null,
            Type returnType = null,
            Type globalsType = null)
        {
            return this.CompilationFactory.CreateScriptCompilation(assemblyName, syntaxTree, references, options, previousScriptCompilation, returnType, globalsType);
        }

    }

    internal class NoLanguage : Language
    {
        private SymbolFacts _symbolFacts;

        public NoLanguage()
        {
            _symbolFacts = new SymbolFacts();
        }

        public override string Name => string.Empty;

        protected internal override SyntaxFacts SyntaxFactsCore => throw new NotImplementedException();

        protected internal override InternalSyntaxFactory InternalSyntaxFactoryCore => throw new NotImplementedException();

        protected internal override SyntaxFactory SyntaxFactoryCore => throw new NotImplementedException();

        protected internal override CompilationFactory CompilationFactoryCore => throw new NotImplementedException();

        protected internal override SymbolFacts SymbolFactsCore => _symbolFacts;

    }
}

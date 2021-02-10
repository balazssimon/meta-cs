using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Extensions.DependencyInjection;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    public abstract class Language
    {
        public static readonly Language None = new NoLanguage();

        private ServiceCollection _serviceCollection;
        private ServiceProvider _serviceProvider;
        private LanguageServices _languageServices;

        private SyntaxFacts _syntaxFacts;
        private InternalSyntaxFactory _internalSyntaxFactory;
        private SyntaxFactory _syntaxFactory;
        private SymbolFacts _symbolFacts;
        private CompilationFactory _compilationFactory;

        public Language()
        {
            EnumObject.Init(typeof(LanguageVersion));
            EnumObject.Init(typeof(SyntaxKind));
            EnumObject.Init(typeof(LanguageSymbolKind));
            EnumObject.Init(typeof(LanguageTypeKind));
            _serviceCollection = new ServiceCollection();
            RegisterServices(_serviceCollection);
            _serviceProvider = _serviceCollection.BuildServiceProvider();
            _syntaxFacts = _serviceProvider.GetRequiredService<SyntaxFacts>();
            _internalSyntaxFactory = _serviceProvider.GetRequiredService<InternalSyntaxFactory>();
            _syntaxFactory = _serviceProvider.GetRequiredService<SyntaxFactory>();
            _symbolFacts = _serviceProvider.GetRequiredService<SymbolFacts>();
            _compilationFactory = _serviceProvider.GetRequiredService<CompilationFactory>();
        }

        public abstract string Name { get; }
        public ServiceProvider Services => _serviceProvider;

        protected abstract LanguageServices CreateLanguageServices();
        private void RegisterServices(ServiceCollection services)
        {
            _languageServices = CreateLanguageServices();
            _languageServices.RegisterDefaultServices(services);
            _languageServices.RegisterServices(services);
        }

        public SyntaxFacts SyntaxFacts => _syntaxFacts;
        public InternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        public SyntaxFactory SyntaxFactory => _syntaxFactory;
        public SymbolFacts SymbolFacts => _symbolFacts;
        public CompilationFactory CompilationFactory => _compilationFactory;

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
        public NoLanguage()
        {
        }

        public override string Name => string.Empty;

        protected override LanguageServices CreateLanguageServices()
        {
            throw new NotImplementedException();
        }
    }
}

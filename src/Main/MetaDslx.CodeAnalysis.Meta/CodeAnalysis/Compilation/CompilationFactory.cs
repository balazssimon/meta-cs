using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    public abstract class CompilationFactory : LanguageService
    {
        private CompletionGraph _lazyCompletionGraph;

        public CompilationFactory()
        {
        }

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


        public CompletionGraph CompletionGraph
        {
            get
            {
                if (_lazyCompletionGraph == null)
                {
                    Interlocked.CompareExchange(ref _lazyCompletionGraph, this.ConstructCompletionGraph().Build(), null);
                }
                return _lazyCompletionGraph;
            }
        }

        public virtual Symbol CreateSpecialSymbol(ModuleSymbol module, object key)
        {
            if (module is MetaModuleSymbol metaModule)
            {
                var specialSymbol = Language.SymbolFacts.GetBuiltInObjects().FirstOrDefault(c => c.MName == key.ToString());
                if (specialSymbol != null && metaModule.Models.Contains(specialSymbol.MModel))
                {
                    Symbol symbol;
                    if (specialSymbol.MId.Descriptor.IsNamedType) symbol = new MetaNamedTypeSymbol(specialSymbol, module);
                    else if (specialSymbol.MId.Descriptor.IsNamespace) symbol = new MetaNamespaceSymbol(specialSymbol, module);
                    else if (specialSymbol.MId.Descriptor.IsName) symbol = new MetaMemberSymbol(specialSymbol, module);
                    else symbol = null;
                    return symbol;
                }
            }
            return null;
        }

        protected virtual CompletionGraphBuilder ConstructCompletionGraph()
        {
            return CompletionPart.ConstructDefaultCompletionGraph();
        }

        public abstract RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
        public abstract BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory);
        public abstract BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree);
        public abstract IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree);

    }
}

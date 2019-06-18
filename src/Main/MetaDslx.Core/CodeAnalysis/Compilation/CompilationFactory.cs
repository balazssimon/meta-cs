using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    public abstract class CompilationFactory
    {
        private CompletionGraph _lazyCompletionGraph;

        public CompilationFactory()
        {
        }

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

        protected virtual CompletionGraphBuilder ConstructCompletionGraph()
        {
            return CompletionPart.ConstructDefaultCompletionGraph();
        }

        public abstract RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
        public abstract BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory);
        public abstract BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree);
        public abstract IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree);

        /// <summary>
        /// Construct an unnamed symbol, e.g., an array.
        /// This method creates and caches the appropriate ModelObject wrapped into a Symbol based on the values of the properties.
        /// Lazy property values are stored as Lazy&lt;object&gt;.
        /// </summary>
        /// <param name="modelBuilder">The model builder that should contain the created model object.</param>
        /// <param name="symbolInfo">Descriptor of the model object to be created.</param>
        /// <param name="propertyValues">Values of the properties of the symbol to be created.</param>
        /// <returns>The constructed unnamed symbol.</returns>
        public virtual Symbol CreateConstructedSymbol(LanguageCompilation compilation, MutableModel modelBuilder, SyntaxReference syntaxReference, ModelSymbolInfo symbolInfo, ImmutableDictionary<string, ImmutableArray<object>> propertyValues)
        {
            var modelObject = symbolInfo.CreateMutable(modelBuilder, true);
            return ModelObjectToSourceSymbol(compilation, syntaxReference, modelObject);
        }

        public virtual Symbol ModelObjectToSourceSymbol(LanguageCompilation compilation, SyntaxReference syntaxReference, IMetaSymbol modelObject)
        {
            if (modelObject.MId.SymbolInfo.IsType)
            {
                return new SourceTypeSymbol(compilation.SourceModule, syntaxReference, modelObject);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}

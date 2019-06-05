using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
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
        public abstract BinderFactory CreateBinderFactory(LanguageCompilation compilation, SyntaxTree syntaxTree);

    }
}

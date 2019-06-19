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

        public virtual ImmutableDictionary<string, Symbol> CreateSpecialSymbols(SourceAssemblySymbol assembly)
        {
            return ImmutableDictionary<string, Symbol>.Empty;
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

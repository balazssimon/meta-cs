using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
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
            CompletionGraphBuilder builder = new CompletionGraphBuilder();
            builder.AddLast(CompletionPart.Attributes);
            builder.AddLast(CompletionPart.StartAttributeChecks);
            builder.AddLast(CompletionPart.FinishAttributeChecks);
            builder.AddLast(CompletionPart.StartBaseTypes);
            builder.AddLast(CompletionPart.FinishBaseTypes);
            builder.AddLast(CompletionPart.Members);
            builder.AddLast(CompletionPart.TypeMembers);
            builder.AddLast(CompletionPart.StartMemberChecks);
            builder.AddLast(CompletionPart.FinishMemberChecks);
            builder.AddLast(CompletionPart.MembersCompleted);
            builder.AddLast(CompletionPart.NameToMembersMap);
            builder.AddLast(CompletionPart.AliasTarget);
            builder.AddLast(CompletionPart.Module);
            builder.AddLast(CompletionPart.StartValidatingAddedModules);
            builder.AddLast(CompletionPart.FinishValidatingAddedModules);
            builder.AddLast(CompletionPart.StartValidatingReferencedAssemblies);
            builder.AddLast(CompletionPart.FinishValidatingReferencedAssemblies);
            return builder;
        }

        public abstract RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
        public abstract BinderFactory CreateBinderFactory(LanguageCompilation compilation, SyntaxTree syntaxTree);

    }
}

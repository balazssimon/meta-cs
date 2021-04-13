using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Symbols
{
    internal class MetaCompletionGraph
    {
        public static readonly CompletionPart StartAssociation = new CompletionPart(nameof(StartAssociation));
        public static readonly CompletionPart FinishAssociation = new CompletionPart(nameof(FinishAssociation));

        public static CompletionGraphBuilder Build()
        {
            var builder = CompletionGraphBuilder.BuildDefaultGraph();
            builder.Add(MetaCompletionGraph.StartAssociation);
            builder.Add(MetaCompletionGraph.FinishAssociation);
            builder.Precedes(CompletionGraph.ChildrenCompleted, MetaCompletionGraph.StartAssociation);
            builder.Precedes(MetaCompletionGraph.StartAssociation, MetaCompletionGraph.FinishAssociation);
            return builder;
        }
    }
}

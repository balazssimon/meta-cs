using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Symbols
{
    internal class MetaCompletionGraph
    {
        public static readonly CompletionPart Association = new CompletionPart(nameof(Association)); 

        public static CompletionGraphBuilder Build()
        {
            var builder = CompletionGraphBuilder.BuildDefaultGraph();
            builder.Add(MetaCompletionGraph.Association);
            builder.Precedes(CompletionGraph.ChildrenCompleted, MetaCompletionGraph.Association);
            return builder;
        }
    }
}

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta
{
    internal class CustomMetaCompilationFactory : MetaCompilationFactory
    {
        protected override CompletionGraphBuilder ConstructCompletionGraph()
        {
            return MetaCompletionGraph.Build();
        }

        public override SymbolFactory CreateSymbolFactory(ModuleSymbol module)
        {
            return new CustomSymbolFactory(module);
        }
    }
}

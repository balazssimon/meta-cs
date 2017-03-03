using MetaDslx.Compiler.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Core;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaSymbolBuilder : SymbolBuilder
    {
        public MetaSymbolBuilder(CompilationBase compilation) : base(compilation)
        {
        }

        protected override MutableSymbol CreateSymbolCore(Type symbolType)
        {
            return this.MetaFactory.Create(symbolType);
        }
    }
}

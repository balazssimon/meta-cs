using MetaDslx.Compiler.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Languages.Meta.Symbols;
using System.Threading;
using MetaDslx.Compiler;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaModelSymbolBuilder : SymbolBuilder
    {
        public MetaModelSymbolBuilder(CompilationBase compilation) : base(compilation)
        {
        }

        private MetaFactory _factory;

        private MetaFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    Interlocked.CompareExchange(ref _factory, new MetaFactory(this.ModelBuilder), null);
                }
                return _factory;
            }
        }

        protected override MutableSymbol CreateSymbolCore(Type symbolType)
        {
            return this.Factory.Create(symbolType);
        }
    }
}

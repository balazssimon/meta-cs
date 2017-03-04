// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MetaDslx.Core;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Binding;
using MetaDslx.Languages.Meta.Symbols;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaSymbolBuilder : SymbolBuilder
    {
        public MetaSymbolBuilder(CompilationBase compilation) : base(compilation)
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


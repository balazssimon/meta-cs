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

        protected override MutableSymbol CreateErrorSymbolCore()
        {
            var f = this.Factory;
            var result = f.MetaPrimitiveType();
            result.Name = "error";
            return result;
        }

        protected override MutableSymbol CreateGlobalNamespaceCore(IEnumerable<ISymbol> namespacesToMerge)
        {
            var f = this.Factory;
            var nsList = namespacesToMerge.ToList();
            string name = nsList.Count > 0 ? nsList[0].MName : string.Empty;
            var result = f.MetaNamespace();
            result.Name = name;
            return result;
        }

        protected override MutableSymbol CreateGlobalNamespaceAliasCore(ISymbol globalNamespace)
        {
            throw new NotImplementedException();
        }
    }
}

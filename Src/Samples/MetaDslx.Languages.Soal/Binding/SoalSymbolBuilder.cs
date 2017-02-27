using MetaDslx.Compiler.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Core;
using MetaDslx.Languages.Soal.Symbols;
using System.Threading;
using MetaDslx.Compiler.Binding.Binders;

namespace MetaDslx.Languages.Soal.Binding
{
    public class SoalSymbolBuilder : SymbolBuilder
    {
        public SoalSymbolBuilder(SoalCompilation compilation) : base(compilation)
        {
        }

        private SoalFactory _factory;

        private SoalFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    Interlocked.CompareExchange(ref _factory, new SoalFactory(this.ModelBuilder), null);
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
            var result = f.PrimitiveType();
            result.Name = "error";
            return result;
        }

        protected override MutableSymbol CreateGlobalNamespaceCore(IEnumerable<IMetaSymbol> namespacesToMerge)
        {
            var f = this.Factory;
            var nsList = namespacesToMerge.ToList();
            string name = nsList.Count > 0 ? nsList[0].MName : string.Empty;
            var result = f.Namespace();
            result.Name = name;
            return result;
        }

        protected override MutableSymbol CreateGlobalNamespaceAliasCore(IMetaSymbol globalNamespace, RootBinder rootBinder)
        {
            throw new NotImplementedException();
        }
    }
}

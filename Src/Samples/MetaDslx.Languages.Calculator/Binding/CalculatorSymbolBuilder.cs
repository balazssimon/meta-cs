using MetaDslx.Compiler.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Core;

namespace MetaDslx.Languages.Calculator.Binding
{
    public class CalculatorSymbolBuilder : SymbolBuilder
    {
        public CalculatorSymbolBuilder(CompilationBase compilation) : base(compilation)
        {
        }

        protected override MutableSymbol CreateErrorSymbolCore()
        {
            throw new NotImplementedException();
        }

        protected override MutableSymbol CreateGlobalNamespaceAliasCore(ISymbol globalNamespace)
        {
            throw new NotImplementedException();
        }

        protected override MutableSymbol CreateGlobalNamespaceCore(IEnumerable<ISymbol> namespacesToMerge)
        {
            throw new NotImplementedException();
        }

        protected override MutableSymbol CreateSymbolCore(Type symbolType)
        {
            throw new NotImplementedException();
        }
    }
}

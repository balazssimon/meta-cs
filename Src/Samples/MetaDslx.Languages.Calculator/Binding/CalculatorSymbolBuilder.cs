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
using MetaDslx.Languages.Calculator.Symbols;

namespace MetaDslx.Languages.Calculator.Binding
{
    public class CalculatorSymbolBuilder : SymbolBuilder
    {
        public CalculatorSymbolBuilder(CompilationBase compilation) : base(compilation)
        {
        }

        private CalculatorFactory _factory;

        private CalculatorFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    Interlocked.CompareExchange(ref _factory, new CalculatorFactory(this.ModelBuilder), null);
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


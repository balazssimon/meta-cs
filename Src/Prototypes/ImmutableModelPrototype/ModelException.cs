using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableModelPrototype
{
    public class ModelException : Exception
    {
        public ModelException()
        {

        }

        public ModelException(string message)
            : base(message)
        {

        }

        public ModelException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }

    public class CircularContainmentException : ModelException
    {
        private ImmutableList<SymbolId> symbols;

        internal CircularContainmentException(string message, ImmutableList<SymbolId> symbols)
            : base(message)
        {
            this.symbols = symbols;
        }

        internal CircularContainmentException(string message, ImmutableList<SymbolId> symbols, Exception innerException)
            : base(message, innerException)
        {
            this.symbols = symbols;
        }

        public ImmutableList<SymbolId> Symbols
        {
            get { return this.symbols; }
        }
    }

    public sealed class LazyEvalException : ModelException
    {
        private ImmutableList<LazyEvalEntry> evalStack;

        internal LazyEvalException(string message, ImmutableList<LazyEvalEntry> evalStack)
            : base(message)
        {
            this.evalStack = evalStack;
        }

        internal LazyEvalException(string message, ImmutableList<LazyEvalEntry> evalStack, Exception innerException)
            : base(message, innerException)
        {
            this.evalStack = evalStack;
        }

        public ImmutableList<LazyEvalEntry> EvalStack
        {
            get { return this.evalStack; }
        }
    }


}

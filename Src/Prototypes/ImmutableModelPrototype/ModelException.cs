using System;
using System.Collections.Generic;
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
        private List<SymbolId> symbols;

        internal CircularContainmentException(string message, List<SymbolId> symbols)
            : base(message)
        {
            this.symbols = symbols;
        }

        internal CircularContainmentException(string message, List<SymbolId> symbols, Exception innerException)
            : base(message, innerException)
        {
            this.symbols = symbols;
        }

        public IReadOnlyList<SymbolId> Symbols
        {
            get { return this.symbols; }
        }
    }
}

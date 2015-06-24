using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class MetaCompilerException : Exception
    {
        public MetaCompilerException()
        {

        }

        public MetaCompilerException(string message)
            : base(message)
        {

        }

        public MetaCompilerException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

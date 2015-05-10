using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    public class MetaException : Exception
    {
        public MetaException()
        {

        }

        public MetaException(string message)
            : base(message)
        {

        }

        public MetaException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

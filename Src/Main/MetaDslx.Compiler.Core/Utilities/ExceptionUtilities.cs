using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Core.Utilities
{
    internal static class ExceptionUtilities
    {
        internal static Exception Unreachable
        {
            get { return new InvalidOperationException("This program location is thought to be unreachable."); }
        }
    }
}

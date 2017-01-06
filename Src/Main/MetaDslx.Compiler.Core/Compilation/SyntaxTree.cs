using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Text;

namespace MetaDslx.Compiler
{
    public class SyntaxTree
    {
        public string FilePath { get; private set; }

        internal FileLinePositionSpan GetLineSpan(TextSpan _span)
        {
            throw new NotImplementedException();
        }

        internal FileLinePositionSpan GetMappedLineSpan(TextSpan _span)
        {
            throw new NotImplementedException();
        }
    }
}

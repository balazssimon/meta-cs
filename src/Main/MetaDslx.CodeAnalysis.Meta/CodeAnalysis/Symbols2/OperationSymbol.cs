using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class OperationSymbol : Symbol
    {
        public abstract IOperation ToOperation();
    }
}

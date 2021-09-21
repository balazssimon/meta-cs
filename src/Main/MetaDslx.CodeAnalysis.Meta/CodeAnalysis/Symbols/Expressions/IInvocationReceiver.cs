using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IInvocationReceiver
    {
        DeclaredSymbol ReferencedSymbol { get; }
    }
}

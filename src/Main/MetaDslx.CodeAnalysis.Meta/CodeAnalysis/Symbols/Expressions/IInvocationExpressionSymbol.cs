using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IInvocationExpressionSymbol
    {
        ImmutableArray<ArgumentSymbol> Arguments { get; }
        bool IsMethodInvocation { get; }
        bool IsPropertyInvocation { get; }
    }
}

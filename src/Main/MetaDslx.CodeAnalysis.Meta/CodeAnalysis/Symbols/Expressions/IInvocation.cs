using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IInvocation
    {
        ImmutableArray<ArgumentSymbol> Arguments { get; }
        bool IsMethodInvocation { get; }
        bool IsPropertyInvocation { get; }
    }
}

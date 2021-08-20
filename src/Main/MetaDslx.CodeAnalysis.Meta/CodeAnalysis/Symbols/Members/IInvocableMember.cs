using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IInvocableMember
    {
        ImmutableArray<ParameterSymbol> Parameters { get; }
        bool IsVarArg { get; }
    }
}

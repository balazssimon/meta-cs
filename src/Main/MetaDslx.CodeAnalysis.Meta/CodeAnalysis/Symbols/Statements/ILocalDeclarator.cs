using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface ILocalDeclarator
    {
        ImmutableArray<LocalSymbol> DeclaredLocals { get; }
    }
}

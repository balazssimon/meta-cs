using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface ISourceSymbol
    {
        MergedDeclaration MergedDeclaration { get; }
        ImmutableArray<Diagnostic> Diagnostics { get; }
    }
}

using MetaDslx.CodeAnalysis.Declarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface ISourceSymbol
    {
        MergedDeclaration MergedDeclaration { get; }
    }
}

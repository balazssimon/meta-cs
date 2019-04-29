using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IScriptSymbol : INamedTypeSymbol
    {
        IMethodSymbol GetScriptConstructor();
        IMethodSymbol GetScriptEntryPoint();
        IMethodSymbol GetScriptInitializer();
    }
}

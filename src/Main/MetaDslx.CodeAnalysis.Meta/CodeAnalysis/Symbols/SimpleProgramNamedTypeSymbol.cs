using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class SimpleProgramNamedTypeSymbol : NamedTypeSymbol
    {
        internal static MethodSymbol? GetSimpleProgramEntryPoint(LanguageCompilation languageCompilation)
        {
            throw new NotImplementedException();
        }
    }
}

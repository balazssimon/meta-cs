using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceAnonymousTypeSymbol : SourceNamedTypeSymbol
    {
        public SourceAnonymousTypeSymbol(Symbol containingSymbol, object modelObject, MergedDeclaration declaration) 
            : base(containingSymbol, modelObject, declaration)
        {
        }
    }
}

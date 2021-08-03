using MetaDslx.CodeAnalysis.Declarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IGeneratedSymbolFactory
    {
        Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration);
        Symbol? CreateMetadataSymbol(Symbol container, object modelObject);
        Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration);
    }
}
